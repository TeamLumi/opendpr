using Dpr.Item;
using Dpr.Trainer;
using Dpr.UI;
using Pml.PokePara;
using Pml;
using SmartPoint.AssetAssistant;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using XLSXContent;
using Dpr.UnderGround;
using Dpr.EvScript;
using Effect;
using Dpr.Field;
using Dpr.SubContents;
using Dpr.Field.Walking;
using UnityEngine.Events;
using System.IO;
using Audio;
using Dpr;
using DPData;
using Pml.Item;
using FieldCommon;
using GameData;
using System.Runtime.InteropServices;
using Dpr.FureaiHiroba;
using AK;
using SmartPoint.Components;

public class FieldManager
{
    public static FieldManager Instance { private set; get; }

    private const int MapSize = 64;

    public event Action OnZoneChangeEvent;
    public Action OnZoneChangeOnce;
    public event Action OnSceneInitEvent;
    public static FieldWalkingManager fwMng = new FieldWalkingManager();
    public static Utils.AssetUnloader abUnloader = new Utils.AssetUnloader();

    public static bool IsResume { get; private set; }

    private UpdateType _updateType;
    public UpdateType updateType { get => _updateType; }

    private EncountUpdateType _encountUpdateType;
    private float _encountWait;
    private EncountFadeType _encountFadeType;
    private Queue<AttributeEvent> _attributeEntitySE = new Queue<AttributeEvent>();
    private Queue<AttributeEvent> _attributeEntityEffect = new Queue<AttributeEvent>();
    public MapType NowMapType;
    public MapType OldMapType;
    private ZoneID _now_zoneID = ZoneID.UNKNOWN;

    public MapInfo.SheetZoneData ZoneData { get => GameManager.mapInfo[(int)PlayerWork.zoneID]; }
    public AreaID areaID { get => ZoneData.AreaID; }
    public ZoneID zoneID { get => ZoneData.ZoneID; }
    public ZoneID Before_zoneID { private set; get; } = ZoneID.UNKNOWN;

    private LoadEffectData[] _effectDataArray;
    private EffectInstance _weatherEffectInstance;
    private SYS_WEATHER _nowWeather;
    private FieldWeather _weather;
    public FieldMistWork MistWork = new FieldMistWork();
    public FieldFlashWork FlashWork = new FieldFlashWork();
    private TrainerID _btl_trainerID1;
    private TrainerID _btl_trainerID2;
    private GameObject _ug_hole;

    public GameObject UG_Hole { get => _ug_hole; }

    private bool _is_ugHoleLock;
    private Vector3 _ugHolePos;
    private UgMainProc _ugMainProc;
    private GameObject _fldCanvasObject;
    private AssetRequestOperation _fldCanvasAssetReqOpe;
    private int _oldEncountWalkCount;
    private EncountFadeTextures _encFadeTextures;
    private Material _encFadeMaterial;
    private AssetRequestOperation _encFadeTexturesReqOpe;
    private EncountResult _encResult;
    private EncEffectSequenceController _encEffctController;
    private int _encEffectCount;
    private GameObject[] _encEffectAsset = new GameObject[2];
    private bool _encountAttriLog;
    private FieldFishing _fishing;
    private FishingRod _useRod;
    private FieldWazaAction _wazaAction;

    public static bool IsWazaActionEnd { get => Instance._wazaAction == null; }
    public uint _nowEventId
    {
        get => PlayerWork.SystemData.fd_bgmEvnet;
        set
        {
            var data = PlayerWork.SystemData;
            data.fd_bgmEvnet = value;
            PlayerWork.SystemData = data;
        }
    }
    public bool IsMenuOpen { private set; get; }

    private bool _isMenuOpenRequest;
    public bool isMenuOpenRequest { get => _isMenuOpenRequest; }

    private float _shortCutPushTime;
    private int _shortCutPushHoldId;

    public bool IsPoketchOpen { private set; get; }

    public bool SND_W_ID_CTRL_BGM_FLAG;

    public KinomiResources KinomiResources { private set; get; }

    private UpdateType _demoReturnType;
    private bool _demoReturnInput;
    private uint _WalkEventName_Attribute;
    private bool _initFlag;
    private AutoSaveState _autoSaveState;
    public static bool SealPrevFalg = false;
    public Vector3 eventTownMapPos = Vector3.zero;
    private List<int> unnnoonFormList = new List<int>(28);
    private int _shorCutSeq;
    private Transform _akLisnerTransform;

    // TODO: Figure out something for switch stuff
    public FieldManager()
    {
        if (Instance != null)
            return;

        Instance = this;
        SwayGrass.SwayGrass_InitSwayGrass();
        UniqueBGMEvent(PlayerWork.transitionZoneID, PlayerWork.zoneID);
        FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_INPUT_OFF, false);
        FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_AUTOSAVE_STOP, false);

        if (fwMng == null)
            fwMng = new FieldWalkingManager();

        SwitchNotification.FocusStateChanged += a =>
        {
            //if (SwitchNotification.CurrentFocusHandlingMode == 1 && Notification.GetCurrentFocusState() == 1)
            //{
                DailyEventWork.PenaltyCheck();
                IsResume = true;
            //}
        };

        SwitchNotification.Resume += a =>
        {
            //if (SwitchNotification.CurrentFocusHandlingMode != 0)
                //return;

            DailyEventWork.PenaltyCheck();
            IsResume = true;
        };

        Sequencer.onDestroy -= SeqOnDestroy;
        Sequencer.onDestroy += SeqOnDestroy;

        UnionWork.SetPenaltyTime();
    }

    private void SeqOnDestroy()
    {
        while (true)
        {
            if (EvDataManager.Instanse.ForceUnload())
                break;
        }

        KinomiResources.ReleaseAll();
        Sequencer.onDestroy -= SeqOnDestroy;
    }

    public void SetDefaultParam()
    {
        _encountUpdateType = EncountUpdateType.CallEffect;
        _encountWait = 0.0f;
        _encountFadeType = EncountFadeType.Normal;
        _btl_trainerID1 = TrainerID.NONE;
        _btl_trainerID2 = TrainerID.NONE;
        _useRod = FishingRod.None;
        _wazaAction = null;
        _updateType = NowMapType == MapType.MAPTYPE_UNDERGROUND ? UpdateType.UnderGround : UpdateType.Field;

        if (SealPrevFalg)
        {
            IsPoketchOpen = false;
        }
        else
        {
            IsMenuOpen = false;
            IsPoketchOpen = false;
        }
    }

    public IEnumerator SceneInit()
    {
        DeleteUpdate();

        var mapInfo = GameManager.mapInfo;
        var zoneData = mapInfo[(int)PlayerWork.transitionZoneID];

        if (!PlayerWork.IsZenmetuFlag && !PlayerWork.TelescopeReturn &&
            PlayerWork.zoneID != ZoneID.UNKNOWN && !IsTownMapNoSavedZone(PlayerWork.zoneID) &&
            !IsSavedMapType(mapInfo[(int)PlayerWork.zoneID].MapType) && IsSavedMapType(zoneData.MapType))
        {
            var townMapPos = FlagWork.GetFlag(EvWork.FLAG_INDEX.FLAG_STOP_ZONE_PROGRAM) ? eventTownMapPos : EntityManager.activeFieldPlayer.worldPosition;
            SetTownMapPos(PlayerWork.zoneID, ref townMapPos);
        }

        PlayerWork.TelescopeReturn = false;
        _attributeEntitySE.Clear();
        _attributeEntityEffect.Clear();

        if (PlayerWork.FieldCacheFlag)
        {
            SetDefaultParam();
            yield break;
        }

        EvDataManager.Instanse.Init_PokemonCenter();
        EvDataManager.Instanse.Init_FieldShip();

        if (KinomiResources == null)
        {
            KinomiResources = new KinomiResources();
            KinomiResources.LoadAll();

            while (!KinomiResources.IsValid())
                yield return null;
        }

        if (!FlashWork.IsValid)
        {
            FlashWork.Load();

            while (!FlashWork.IsValid)
                yield return null;
        }

        OldMapType = NowMapType;
        NowMapType = zoneData.MapType;
        _updateType = zoneData.MapType == MapType.MAPTYPE_UNDERGROUND ? UpdateType.UnderGround : UpdateType.Field;

        yield return EvDataManager.Instanse.RequestAssetSetUp(mapInfo[(int)PlayerWork.transitionZoneID].AreaID);

        if (_updateType == UpdateType.UnderGround)
        {
            UgResManager.DataLoadRequest(null);
            UgFatherResourceManager.DataLoadRequest(null);
            LightStoneResourcesManager.DataLoadRequest(null);
        }
        else
        {
            UgResManager.UnLoad();
            UgFatherResourceManager.UnLoad();
            LightStoneResourcesManager.UnLoad();
            _ugMainProc = null;
        }

        if (_fldCanvasObject == null && _fldCanvasAssetReqOpe == null)
        {
            _fldCanvasAssetReqOpe = AssetManager.AppendAssetBundleRequest("fieldui/main", true, null, null);
            AssetManager.DispatchRequests(null);
        }

        if (_encFadeTextures == null && _encFadeTexturesReqOpe == null)
        {
            _encFadeTexturesReqOpe = AssetManager.AppendAssetBundleRequest("field/fade_tex", true, null, null);
            AssetManager.DispatchRequests(null);
        }

        UIManager.onFieldWaza -= UI_onFieldWaza;
        UIManager.onFieldWaza += UI_onFieldWaza;
        UIManager.onUseFieldItem -= UI_onUseFieldItem;
        UIManager.onUseFieldItem += UI_onUseFieldItem;
        UIManager.onWazaFly -= UI_onWazaFly;
        UIManager.onWazaFly += UI_onWazaFly;

        FieldPoketch.CreanPoketchWindow();
        FieldPoketch.RegisterEvent();

        if (_weather == null)
            _weather = new FieldWeather();

        if (_fishing == null)
            _fishing = new FieldFishing();

        if (ZoneWork.IsSpFishingZone(PlayerWork.transitionZoneID))
        {
            yield return SpFishing.LoadFishingData();
        }

        AudioAmbientManager.SetEnabled(true);
        SetAkLisnerTransform(EntityManager.activeFieldPlayer.transform);
        RecordWork.AddDataMineNull();
    }

    private bool IsSavedMapType(MapType mapType)
    {
        switch (mapType)
        {
            case MapType.MAPTYPE_ROAD:
            case MapType.MAPTYPE_CAVE:
            case MapType.MAPTYPE_ROOM:
            case MapType.MAPTYPE_POKECEN:
            case MapType.MAPTYPE_UNDERGROUND:
                return true;

            default:
                return false;
        }
    }

    private bool IsTownMapNoSavedZone(ZoneID zoneid)
    {
        switch (zoneid)
        {
            case ZoneID.D05R0104:
            case ZoneID.D05R0105:
            case ZoneID.D05R0114:
            case ZoneID.D05R0115:
            case ZoneID.D05R0116:
            case ZoneID.D06R0201:
            case ZoneID.D06R0202:
            case ZoneID.D06R0203:
            case ZoneID.D06R0204:
            case ZoneID.D06R0205:
            case ZoneID.D06R0206:
            case ZoneID.D07R0113:
            case ZoneID.D07R0114:
            case ZoneID.D07R0115:
            case ZoneID.D09R0105:
            case ZoneID.D09R0106:
            case ZoneID.D10R0101:
            case ZoneID.D11R0101:
            case ZoneID.D13R0101:
            case ZoneID.D23R0101:
                return true;

            default:
                return false;
        }
    }

    public bool IsSceneLoadEnd()
    {
        if (!EvDataManager.Instanse.IsLoadAssetBundle())
            return false;

        if (_fldCanvasAssetReqOpe != null && !_fldCanvasAssetReqOpe.assetBundleRequest.isComplete)
            return false;

        if (_encFadeTexturesReqOpe != null && !_encFadeTexturesReqOpe.assetBundleRequest.isComplete)
            return false;

        if (_effectDataArray == null || _effectDataArray.Length < 1)
            return true;

        for (int i=0; i<_effectDataArray.Length; i++)
        {
            if (_effectDataArray[i].isLoading)
                return false;
        }

        return true;
    }

    public bool UnUsed_UnloadAsset()
    {
        return EvDataManager.Instanse.RefCountZeroUnload();
    }

    public IEnumerator SceneInitAfter()
    {
        if (PlayerWork.FieldCacheFlag)
        {
            EvDataManager.Instanse.SaveDataReflection();
            EvDataManager.Instanse.SetupGimmickEntity();

            if (fwMng.isBattleRetrurnCreate)
            {
                fwMng.isBattleRetrurnCreate = false;
                yield return fwMng.CreatePartner(true, true, false);
            }

            ActiveUpdate();
            PlayerWork.FieldCacheFlag = false;
            OnSceneInitEvent?.Invoke();

            yield break;
        }

        if (_fldCanvasAssetReqOpe != null)
        {
            while (!_fldCanvasAssetReqOpe.assetBundleRequest.isComplete)
                yield return null;

            if (_fldCanvasObject == null)
            {
                var go = _fldCanvasAssetReqOpe.assetBundleRequest.cache.loadedFirstAsset as GameObject;
                _fldCanvasObject = UnityEngine.Object.Instantiate(go);
                _fldCanvasObject.name = "Field Canvas";
                _fldCanvasObject.transform.position = Vector3.zero;
            }

            AssetManager.UnloadAssetBundle(_fldCanvasAssetReqOpe.assetBundleRequest.uri);
            _fldCanvasAssetReqOpe = null;
        }

        if (_encFadeTexturesReqOpe != null)
        {
            while (!_encFadeTexturesReqOpe.assetBundleRequest.isComplete)
                yield return null;

            if (_encFadeTextures == null)
            {
                _encFadeTextures = _encFadeTexturesReqOpe.assetBundleRequest.cache.loadedFirstAsset as EncountFadeTextures;
                _encFadeMaterial = new Material(AssetManager.FindShader("Delphis/Battle/Encount02"));
            }

            AssetManager.UnloadAssetBundle(_encFadeTexturesReqOpe.assetBundleRequest.uri);
            _encFadeTexturesReqOpe = null;
        }

        EvDataManager.Instanse.SetCreateParent(GameManager.connector.characterCacheObjects);
        EvDataManager.Instanse.SortLoadObjectData(EntityManager.activeFieldPlayer.gridPosition);
        
        yield return EvDataManager.Instanse.StartUpCreate();

        EvDataManager.Instanse.SaveDataReflection();
        EvDataManager.Instanse.SetupGimmickEntity();

        if (_updateType == UpdateType.UnderGround)
        {
            while (!UgResManager.IsDataLoadEnd)
                yield return null;

            while (!UgFatherResourceManager.IsDataLoadEnd)
                yield return null;

            while (!LightStoneResourcesManager.IsDataLoadEnd)
                yield return null;

            if (_ugMainProc == null)
            {
                _ugMainProc = new UgMainProc();
                _ugMainProc.Init();
            }

            yield return UgResManager.CreateAsset();

            yield return UgFatherResourceManager.CreateAsset();

            yield return LightStoneResourcesManager.CreateAsset();

            if (PlayerWork.transitionZoneID != zoneID)
                _ugMainProc.EncountMonsLot(GameManager.mapInfo[(int)PlayerWork.transitionZoneID].LandmarkType);

            yield return _ugMainProc.CreateObject();

            UgMiniMapComponent.Init();
        }

        yield return EffectLoad();

        if (_ug_hole == null)
        {
            _ug_hole = new GameObject("ug hole");
            _ug_hole.transform.SetParent(EntityManager.activeFieldPlayer.transform);
            _ug_hole.transform.localPosition = new Vector3(0.0f, 0.1f, 0.0f);
            _ug_hole.transform.localScale = Vector3.zero;

            var sprite = new GameObject("sprite");
            sprite.transform.SetParent(_ug_hole.transform);
            sprite.transform.localPosition = Vector3.zero;
            sprite.transform.localScale = Vector3.one;
            sprite.transform.SetLocalRotationEuler(new Vector3(-90.0f, 0.0f, 0.0f));
            var renderer = sprite.AddComponent<SpriteRenderer>();
            renderer.sprite = FieldCanvas.UgHoleSprite;
        }
        _ug_hole.SetActive(false);

        if (fwMng.isBattleRetrurnCreate)
        {
            fwMng.isBattleRetrurnCreate = false;
            yield return fwMng.CreatePartner(true, true, false);
        }

        ActiveUpdate();
        _initFlag = true;
    }

    private IEnumerator EffectLoad()
    {
        if (EffectManager.Instance != null && EffectManager.Instance.dbEffects != null && _effectDataArray == null)
        {
            _effectDataArray = new LoadEffectData[EffectManager.Instance.dbEffects.FieldEffectData.Length];
            var loadingList = new List<EffectManager.LoadParam>();

            int loadCount = 0;
            for (int i=0; i<EffectManager.Instance.dbEffects.FieldEffectData.Length; i++)
            {
                var data = EffectManager.Instance.dbEffects.FieldEffectData[i];
                _effectDataArray[i] = new LoadEffectData();
                _effectDataArray[i].name = Path.GetFileName(data.AssetBundleName);
                _effectDataArray[i].isComplete = false;
                _effectDataArray[i].isLoading = false;

                if (data.InitLoad)
                {
                    _effectDataArray[i].isLoading = true;
                    loadingList.Add(data);
                    loadCount++;
                }
            }

            yield return EffectManager.Instance.OpLoad(loadingList.ToArray(), (effectData, isAllLoaded) =>
            {
                loadCount--;
                for (int i=0; i<_effectDataArray.Length; i++)
                {
                    if (_effectDataArray[i].name == effectData.prefab.name)
                    {
                        _effectDataArray[i].isLoading = false;
                        _effectDataArray[i].isComplete = true;
                        _effectDataArray[i].effect = effectData;
                        return;
                    }
                }
            });

            while (loadCount > 0)
                yield return null;
        }
    }

    public void SceneStart()
    {
        OnZoneChange(false);
        EvDataManager.Instanse.DelteAruseus();

        EntityManager.activeFieldPlayer.moveVector = Vector3.zero;
        EntityManager.activeFieldPlayer.StopBicycleDecelerate();
        EntityManager.activeFieldPlayer.EvEntityCmd.ScritpStopStateEnd();
        EntityManager.activeFieldPlayer.rodVariation = -1;
        EntityManager.activeFieldPlayer.TenkaiWwise();

        EvDataManager.Instanse.UpdateStart();
        SealPrevFalg = false;
        EntityManager.BuildFieldEntities();

        if (EntityManager.activeFieldPlayer.isActiveAndEnabled == PlayerWork.Telescope)
            EntityManager.activeFieldPlayer.gameObject.SetActive(!PlayerWork.Telescope);

        if (SwayGrass.BattleEndRensaStart)
        {
            var grid = EntityManager.activeFieldPlayer.gridPosition;
            SwayGrass.LotSwayGrass(ref grid, EntityManager.activeFieldPlayer.Height);

            if (PlayerWork.evolveRequets.Count == 0)
                SwayGrass._callSwayBGM = false;

            SwayGrass.BattleEndRensaStart = false;
        }

        PlayerWork.MovePokemonIndex = -1;

        if (UgFieldManager.Instance != null)
            UgFieldManager.Instance.AddInputUpdate();
    }

    public void OnDestroy()
    {
        DeleteUpdate();
        _ug_hole = null;
        fwMng = null;
        abUnloader = null;
    }

    private bool IsDemoReqestStop()
    {
        if (PlayerWork.evolveRequets.Count != 0)
            return true;

        if (PlayerWork.isEvolveDemo)
            return true;

        if (PlayerWork.isHatchDemo)
            return true;

        if (PlayerWork.capturedPokemon != null)
            return true;

        return false;
    }

    public void ActiveUpdate()
    {
        Sequencer.update += update;
        Sequencer.lateUpdate += lateupdate;
        Sequencer.postLateUpdate += postLateUpdate;
    }

    public void DeleteUpdate()
    {
        Sequencer.update -= update;
        Sequencer.lateUpdate -= lateupdate;
        Sequencer.postLateUpdate -= postLateUpdate;
    }

    public void update(float deltatime)
    {
        if (PlayerWork.transitionZoneID != ZoneID.UNKNOWN)
            return;

        if (EntityManager.activeFieldPlayer == null)
            return;

        if (FieldConnector.IsSetupOperationRunning)
            return;

        if (_updateType != UpdateType.DemoWait && IsDemoReqestStop())
        {
            _demoReturnType = _updateType;
            _demoReturnInput = PlayerWork.isPlayerInputActive;
            _updateType = UpdateType.DemoWait;
        }

        UpdateAkLisner();
        EvDataManager.Instanse.UpdateCreate();
        CheckWeather();

        if (_wazaAction != null)
        {
            if (!_wazaAction.Invoke(deltatime))
                _wazaAction = null;
        }

        switch (_updateType)
        {
            case UpdateType.Field:
                if (SwayGrass.SwayGrass_CheckValid() && SwayGrass._callSwayBGM)
                {
                    AudioManager.Instance.RePostEvent(AK.EVENTS.BA013);
                    SwayGrass._callSwayBGM = false;
                }
                fdUpdate(deltatime);
                break;

            case UpdateType.UnderGround:
                ugUpdate(deltatime);
                break;

            case UpdateType.Encount:
                EncountUpdate(deltatime);
                break;

            case UpdateType.Fishing:
                var result = _fishing.Update(deltatime);
                result.encResult = null;

                if (result.isFishing)
                    break;

                switch (result.state)
                {
                    case FieldFishing.ResultState.Sucsess:
                        EvDataManager.Instanse.JumpLabel("ev_fish_ok", () =>
                        {
                            ushort seikaku = 0xFFFF;
                            ushort sex = 0xFF;
                            switch (result.encResult.HatudouTokusei)
                            {
                                case TokuseiNo.SINKURO:
                                    seikaku = result.encResult.FixSeikaku[0] == Seikaku.NUM ? (ushort)0xFFFF : (ushort)result.encResult.FixSeikaku[0];
                                    break;

                                case TokuseiNo.MEROMEROBODHI:
                                    sex = result.encResult.FixSex[0] > Sex.FEMALE ? (ushort)0xFF : (ushort)result.encResult.FixSex[0];
                                    break;
                            }

                            ushort formno = GetFormNo(result.encResult.Enemy[0], result.encResult.karanaForm, result.encResult.annoForm);
                            MonsNo monsno = result.encResult.Enemy[0];
                            int level = result.encResult.Level[0];

                            var party = EncountTools.CreateSimpleParty(monsno, level, MonsNo.NULL, 1, null, sex, seikaku, form0: formno);
                            var pp0 = party.GetMemberPointer(0);

                            int item1rate = 50;
                            switch (result.encResult.HatudouTokusei)
                            {
                                case TokuseiNo.HUKUGAN:
                                case TokuseiNo.KYOUUN:
                                    item1rate = 60;
                                    break;
                            }
                            // BUG?: Rate for held item 2 is hardcoded to 20% instead of 5% as in previous games.
                            EncountTools.SetWildPokemonItem(pp0, UnityEngine.Random.Range(0, 100), item1rate, 20);

                            TvWork.SetFishing(_useRod, result.encResult.Enemy[0]);
                            PlayReportManager.StartWildBattle(PlayReportManager.eCaptureType.Fishing);

                            int safariBallNum = result.encResult.Type == EncountResult.BtlType.Safari ? PlayerWork.SafariBallNum : -1;
                            EncountTools.SetupBattleWild(PlayerWork.battleSetupParam, party, GameManager.mapInfo[(int)PlayerWork.zoneID].BattleBg[1],
                                result.attriEx, GetBatleWeather(), false, true, TrainerID.NONE, false, safariBallNum, false, false, null);

                            PreLoadEncEffect("mizu01");
                            EncountStart(EncountFadeType.Normal);
                            RecordWork.Add(RECORD_ID.RECID_FISHING_SUCCESS);
                            _useRod = FishingRod.None;
                        });
                        _updateType = UpdateType.Field;
                        break;

                    case FieldFishing.ResultState.NoneEnc:
                        EvDataManager.Instanse.JumpLabel("ev_fish_no_hit", null);
                        _updateType = UpdateType.Field;
                        _useRod = FishingRod.None;
                        break;

                    case FieldFishing.ResultState.MissInput:
                        TvWork.SetFishing(_useRod, MonsNo.NULL);
                        EvDataManager.Instanse.JumpLabel("ev_fish_nige", null);
                        _updateType = UpdateType.Field;
                        _useRod = FishingRod.None;
                        break;

                    case FieldFishing.ResultState.Cancel:
                        EvDataManager.Instanse.JumpLabel("ev_fish_fast_inpu", null);
                        _updateType = UpdateType.Field;
                        _useRod = FishingRod.None;
                        break;
                }
                break;

            case UpdateType.DemoWait:
                if (IsDemoReqestStop())
                {
                    EntityManager.activeFieldPlayer.PlayIdle();
                    PlayerWork.isPlayerInputActive = false;
                    if (PlayerWork.isHatchDemo && _autoSaveState != AutoSaveState.Stop)
                        _autoSaveState = AutoSaveState.EventScript;
                }
                else
                {
                    PlayerWork.isPlayerInputActive = _demoReturnInput;
                    _updateType = _demoReturnType;
                }
                break;
        }
    }

    public void lateupdate(float deltatime)
    {
        if (PlayerWork.transitionZoneID != ZoneID.UNKNOWN)
            return;

        if (_updateType == UpdateType.Field || _updateType == UpdateType.UnderGround)
        {
            if (EvDataManager.Instanse.m_LateUpdate(deltatime))
            {
                IsMenuOpen = false;
                _isMenuOpenRequest = false;
            }
        }

        AttributeEventSE();
        AttributeEventEffect();

        if (!_is_ugHoleLock)
            return;

        _ug_hole.transform.position = _ugHolePos;
    }

    public void postLateUpdate(float deltatime)
    {
        LateMenuOpen();

        if (_autoSaveState == AutoSaveState.EventScript && !IsMenuOpen && !FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_INPUT_OFF))
        {
            if (PlayerWork.isPlayerInputActive && !EvDataManager.Instanse.IsRunningEvent())
            {
                AutoSave();
                _autoSaveState = AutoSaveState.None;
            }
        }

        IsResume = false;
    }

    public void OnZoneChange(bool walk = true)
    {
        var originalZoneData = ZoneData;

        Before_zoneID = _now_zoneID;
        _now_zoneID = ZoneData.ZoneID;

        if (Before_zoneID != _now_zoneID)
            StopSwayGrass_NextArea();

        if (!walk)
        {
            if (Before_zoneID != _now_zoneID)
                GameManager.useSubAttribute = false;

            if (Before_zoneID == ZoneID.UNKNOWN)
                SaveCheckCyclingRoad();
        }

        if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_MAP_INFO_STOP))
        {
            FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_MAP_INFO_STOP, false);
            FieldCanvas.ResetAreaNameWindow();
        }
        else if (originalZoneData.MapType == MapType.MAPTYPE_ROOM ||
            originalZoneData.MapType == MapType.MAPTYPE_POKECEN ||
            ZoneWork.IsSafariZone(ZoneData.ZoneID))
        {
            FieldCanvas.ResetAreaNameWindow();
        }
        else if (Before_zoneID != _now_zoneID)
        {
            FieldCanvas.OpenAreaNameWindow(originalZoneData.MSLabel);
        }

        if (PlayerWork.ReserveZoneChangeNaminoriEnd)
        {
            if (EntityManager.activeFieldPlayer.IsSwim())
                EntityManager.activeFieldPlayer.ChangeSwim(false);

            PlayerWork.ReserveZoneChangeNaminoriEnd = false;
        }

        if (!SND_W_ID_CTRL_BGM_FLAG)
        {
            if (SwayGrass._callStopSwayBGM)
                AudioManager.Instance.RePostEvent(AK.EVENTS.EV_END);

            if (Before_zoneID != _now_zoneID && FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_BGM_D02))
                AudioManager.Instance.SetBgmEvent(AK.EVENTS.D02_GINGA_FALSE);

            if (!walk && (Before_zoneID == ZoneID.UNKNOWN || Before_zoneID == _now_zoneID) && PlayerWork.Warp == PlayerWork.WarpType.None)
            {
                SetBgmEvent(GetNowBgmState());
            }
            else
            {
                if (!PlayerWork.IsFormSwim())
                {
                    SetBgmEvent(AudioManager.Instance.GetIdByName(GetMapBgmState()));
                }
            }

            if (ZoneData.EnvironmentalSound != "")
                AudioManager.Instance.PlaySe(AudioManager.Instance.GetIdByName(ZoneData.EnvironmentalSound), null);

            SwayGrass._callSwayBGM = false;
            SwayGrass._callStopSwayBGM = false;
        }

        _weather.CheckZoneWeather();

        if (!walk && Before_zoneID != _now_zoneID)
        {
            PlayerWork.UsedFieldWazaInArea.Clear();

            if (PlayerWork.Flash)
            {
                if (Before_zoneID != ZoneID.UNKNOWN)
                {
                    if (GameManager.mapInfo[(int)_now_zoneID].MapType == GameManager.mapInfo[(int)Before_zoneID].MapType)
                    {
                        PlayerWork.UsedFieldWazaInArea.Add(WazaNo.HURASSYU);
                    }
                }

                PlayerWork.Flash = false;
            }
        }
        bool isSnow = false;
        switch (_now_zoneID)
        {
            case ZoneID.C09:
            case ZoneID.L03:
            case ZoneID.R212AR0103:
            case ZoneID.R212B:
                isSnow = true;
                break;
        }

        EnvironmentController.globalSnowFieldEnable = isSnow;

        if (isSnow)
        {
            ParamIndx param;
            if (PlayerWork.Week < DayOfWeek.Sunday)
                param = ParamIndx.SnowCover_Sun;
            else if (PlayerWork.Week > DayOfWeek.Saturday)
                param = ParamIndx.SnowCover_Sat;
            else
                param = ((int)PlayerWork.Week) + ParamIndx.SnowCover_Sun;

            Snowfield.global.snowCover = DataManager.GetFieldCommonParam(param);
        }

        if (GameManager.waterSettings != null)
        {
            WaterInteraction.waterSettings = null;

            bool isWater = false;
            for (int i=0; i<GameManager.waterSettings.Settings.Length; i++)
            {
                var waterSetting = GameManager.waterSettings.Settings[i];
                if (Array.IndexOf(waterSetting.ZoneIDs, _now_zoneID) > -1)
                {
                    WaterInteraction.waterSettings = waterSetting;
                    isWater = true;
                    break;
                }
            }
            EnvironmentController.globalWaterFieldEnable = isWater;
        }

        if (FieldMistWork.CheckMistWeather())
        {
            if (PlayerWork.Kiribarai)
            {
                if (MistWork.IsEnable)
                {
                    if (walk)
                        MistWork.ChangeMist(0.0f, DataManager.FieldCommonParam[(int)ParamIndx.MistFadeOutTime].param);
                    else
                        MistWork.ChangeMist(0.0f, 0.0f);
                }
            }
            else
            {
                MistWork.Setup();

                if (walk)
                    MistWork.ChangeMist(1.0f, DataManager.FieldCommonParam[(int)ParamIndx.MistFadeInTime].param);
                else
                    MistWork.ChangeMist(1.0f, 0.0f);
            }
        }
        else
        {
            if (!walk && Before_zoneID != _now_zoneID)
                PlayerWork.Kiribarai = false;

            if (MistWork.IsEnable)
            {
                if (walk)
                    MistWork.ChangeMist(0.0f, DataManager.FieldCommonParam[(int)ParamIndx.MistFadeOutTime].param);
                else
                    MistWork.ChangeMist(0.0f, 0.0f);
            }
        }

        if (WeatherWork.WeatherID == SYS_WEATHER.FLASH && !PlayerWork.Flash)
            FlashWork.ChangeDark(1.0f);
        else if (FlashWork.IsEnable)
            FlashWork.ChangeDark(0.0f);

        FieldObjWork.Clear();

        if (walk)
        {
            EncountDataWork.MovePoke_NextZone();
            SetMapInfoCameraData(false);
            UniqueBGMEvent(_now_zoneID, Before_zoneID);
            EvDataManager.Instanse.FieldZoneChange();
        }
        else
        {
            SetMapInfoCameraData(true);
            _weatherEffectInstance?.Stop(0.0f, true);

            for (int i=0; i<_encEffectAsset.Length; i++)
            {
                if (_encEffectAsset[i] != null)
                {
                    UnityEngine.Object.Destroy(_encEffectAsset[i]);
                    _encEffectAsset[i] = null;
                }
            }

            _encEffectCount = 0;
            if (!ZoneWork.IsSpFishingZone(_now_zoneID))
                SpFishing.UnloadFishngData();
        }

        CheckWeather();
        OnZoneChange_Subcontents(walk);

        OnZoneChangeOnce?.Invoke();
        OnZoneChangeOnce = null;

        OnZoneChangeEvent?.Invoke();

        if (Before_zoneID != _now_zoneID)
            FieldBattleSearcher.WalkClearFlag();
    }

    public void SetAutoSaveState(AutoSaveState state)
    {
        switch (_autoSaveState)
        {
            case AutoSaveState.None:
                _autoSaveState = state;
                break;

            case AutoSaveState.Stop:
                if (state == AutoSaveState.None)
                    _autoSaveState = state;
                break;

            default:
                if (state != AutoSaveState.Zone_Change)
                    _autoSaveState = state;
                break;
        }
    }

    public bool AutoSave(bool isForce = false, bool mainsave = true, bool backup = true, bool underground = false)
    {
        if (!isForce)
        {
            if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_AUTOSAVE_STOP))
                return true;

            if (!IsEnableSave(underground))
                return true;

            if (ZoneWork.IsSafariZone(ZoneData.ZoneID))
                return true;

            mainsave = PlayerWork.config.autoreport && mainsave;
        }

        if (mainsave || backup)
            PlayerWork.AutoSave(mainsave, backup);

        return true;
    }

    public IEnumerator ZoneChangeAutoSave()
    {
        if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_AUTOSAVE_STOP))
            yield break;

        if (PlayerWork.GetInt(EvWork.WORK_INDEX.WK_SCENE_GAME_START) == 0)
            yield break;

        if(_autoSaveState == AutoSaveState.None)
        {
            SetAutoSaveState(AutoSaveState.None);
            yield break;
        }

        bool main = true;
        bool ug = false;
        bool backup = _autoSaveState != AutoSaveState.BattleResult;

        if (_autoSaveState == AutoSaveState.BattleResult && ZoneWork.IsUnderGround(zoneID))
            ug = true;

        while (!AutoSave(false, main, backup, ug))
            yield return null;

        while (PlayerWork.IsSaveSystemBusy())
            yield return null;

        SetAutoSaveState(AutoSaveState.None);
    }

    public void ZoneChangeSetZenmetu(ZoneID transition)
    {
        for (int i=0; i<DataManager.ZenmetuZone.data.Length; i++)
        {
            var zone = DataManager.ZenmetuZone.data[i];
            if (zone.zoneID == transition)
            {
                var saveData = PlayerWork.PlayerSaveData;
                saveData.worpPoint.zenmetu.dir = zone.dir;
                saveData.worpPoint.zenmetu.posX = zone.gridX;
                saveData.worpPoint.zenmetu.posY = zone.height;
                saveData.worpPoint.zenmetu.posZ = zone.gridZ;
                saveData.worpPoint.zenmetu.zoneID = (int)transition;
                PlayerWork.PlayerSaveData = saveData;
            }
        }
    }

    public IEnumerator OnSceneChange()
    {
        DeleteUpdate();
        if (EffectManager.isInstantiated)
            EffectManager.Instance.RemoveInstances(true);

        StopShortCutData();
        _isMenuOpenRequest = false;
        if (!PlayerWork.isSealPreview)
            IsMenuOpen = true;

        if (UgFieldManager.Instance != null)
            UgFieldManager.Instance.RemoveInputUpdate();

        if (!_initFlag)
            yield break;

        SetAutoSaveState(AutoSaveState.None);
        if (!GameManager.playEnding)
        {
            PlayerWork.FieldCacheFlag = true;
            EvDataManager.Instanse.CacheSceneChangeRelease();
            UIContestPhoto.ReleasePhotoResources();
            _weatherEffectInstance?.Stop(0.0f, false);
            _weatherEffectInstance = null;
            _nowWeather = SYS_WEATHER.MAX;
            yield break;
        }

        while (!EvDataManager.Instanse.ForceUnload())
            yield return null;

        EvDataManager.Instanse.SceneChangeRelease();
        if (_effectDataArray != null)
        {
            for (int i=0; i<_effectDataArray.Length; i++)
            {
                _effectDataArray[i].effect?.Release();
                _effectDataArray[i] = null;
            }
        }
        _effectDataArray = null;

        _weatherEffectInstance?.Stop(0.0f, false);
        _weatherEffectInstance = null;
        _nowWeather = SYS_WEATHER.MAX;
        _fishing.Clear();
        _fishing = null;

        FieldPoketch.UnregisterEvent();
        FieldPoketch.CreanPoketchWindow();
        GameManager.fieldCamera.EventCamera.Release();
    }

    private void fdUpdate(float deltatime)
    {
        _weather.Update(deltatime);
        MistWork.Update(deltatime);
        FlashWork.Update(deltatime);
        SwayGrass.Update(deltatime);

        if (EvDataManager.Instanse.m_Update(deltatime))
            return;

        if (CheckEncount())
            return;

        if (FishingUpdate(deltatime))
            return;

        if (ControlPoketch())
            return;

        if (!MenuOpenInvalidZone())
            MenuOpen(deltatime);
    }

    private void fdLateUpdate(float deltatime)
    {
        if (EvDataManager.Instanse.m_LateUpdate(deltatime))
        {
            IsMenuOpen = false;
            _isMenuOpenRequest = false;
        }
    }

    private void ugUpdate(float deltatime)
    {
        if (UgFieldManager.Instance.IsContextMenuOpend)
            return;

        if (!EvDataManager.Instanse.m_Update(deltatime) && !_isMenuOpenRequest && _ugMainProc.update(deltatime))
        {
            if (!ZoneWork.IsSecretBase(PlayerWork.zoneID))
                MenuOpen(deltatime, true);
        }
    }

    // TODO
    private void ugLateUpdate(float deltatime) { }

    // TODO
    private void EncountUpdate(float deltatime) { }

    // TODO
    public void PreLoadEncEffect(string assetname) { }

    // TODO
    public uint GetNowBgmState() { return 0; }

    // TODO
    public string GetMapBgmState() { return null; }

    // TODO
    public uint CheckMapBgmState(uint id) { return 0; }

    // TODO
    public string GetEnvironmentalSound() { return null; }

    // TODO
    public void ResetSaveZoneBgm() { }

    // TODO
    public void SetCutOutFade(int index) { }

    // TODO
    private bool CheckEncount() { return false; }

    // TODO
    private void ResultSetUpWildBattle(EncountResult result, int btlBgIndex, out PokeParty party, out int safariball)
    {
        party = null;
        safariball = 0;
    }

    // TODO
    private ushort GetFormNo(MonsNo mons, int karana, int anno) { return 0; }

    // TODO
    public void EventWildBattle(MonsNo mons, int level, bool isCaptureDemo = false, bool isSymbol = false, bool isMitu = false, byte talentVNum = 0, bool isCantUseBall = false, int formNo = 0, bool tokusei3rd = false) { }

    // TODO
    public void EventWildBattle(PokeParty pokeParty, bool isCaptureDemo = false, bool isSymbol = false, bool isMitu = false, bool isCantUseBall = false) { }

    // TODO
    public void EncountStart(EncountFadeType type, TrainerID trainerid1 = TrainerID.NONE, TrainerID trainerid2 = TrainerID.NONE) { }

    // TODO
    public bool IsEncountUpdate() { return false; }

    // TODO
    private void AttributeEventEffect() { }

    // TODO
    private void AttributeEventSE() { }

    // TODO
    private void FootSE_Walk(string name, AttributeEventCallType callType, int graphicIndex, Transform tra) { }

    // TODO
    private void FootSE_Bic(string name) { }

    // TODO
    public void FootEventEffect(FieldObjectEntity entity, bool running, bool bicycle, AttributeEventCallType calltype) { }

    public void FootEventSE(FieldObjectEntity entity, bool running, bool bicycle, AttributeEventCallType calltype)
    {
        _attributeEntitySE.Enqueue(new AttributeEvent()
        {
            chartype = 0,
            isRun = running,
            isBic = bicycle,
            entity = entity,
            eventType = AttributeEventType.Run,
            callType = calltype,
        });
    }

    // TODO
    public void RequestAttributeEffect(FieldObjectEntity entity, AttributeEventType attri) { }

    // TODO
    public void RequestAttributeSE(FieldObjectEntity entity, AttributeEventType attri) { }

    // TODO
    public void CallEffect(EffectFieldID index, Transform parent, Vector3 ofs, Vector3 rot, [Optional] Action<EffectInstance> loadcallback, [Optional] UnityAction<EffectInstance> eff_onFinished) { }

    // TODO
    public void CallEffect(EffectFieldID index, Transform parent, Vector3 ofs, [Optional] Action<EffectInstance> loadcallback, [Optional] UnityAction<EffectInstance> eff_onFinished) { }

    // TODO
    public void CallEffect(EffectFieldID index, Transform parent, [Optional] Action<EffectInstance> loadcallback, [Optional] UnityAction<EffectInstance> eff_onFinished) { }

    // TODO
    public void CallEffect(EffectFieldID index, Vector3 pos, [Optional] Action<EffectInstance> loadcallback, [Optional] UnityAction<EffectInstance> eff_onFinished) { }

    // TODO
    private IEnumerator PlayEffect(EffectFieldID index, Transform parent, Vector3 pos, Quaternion rot, Action<EffectInstance> loadcallback, UnityAction<EffectInstance> eff_onFinished) { return null; }

    // TODO
    private bool ControlPoketch() { return false; }

    // TODO
    public void ChangePoketchLarge() { }

    // TODO
    public void ChangePoketchSmall() { }

    public void MenuOpen(float deltatime, bool isIgnoreGround = false)
    {
        if (IsMenuOpen)
            return;

        if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_INPUT_OFF))
            return;

        if (UseShotCut(deltatime))
            return;

        if (!PlayerWork.isPlayerInputActive)
            return;

        if (PlayerWork.transitionZoneID != ZoneID.UNKNOWN)
            return;

        if (OpenUnionRoomWarp(isIgnoreGround))
            return;

        if (!FieldInput.PushX())
            return;

        if (!IsEnableSave(isIgnoreGround))
            return;

        if (IsKariEyeHitCheck())
            return;

        _isMenuOpenRequest = true;
    }

    private void LateMenuOpen()
    {
        if (!_isMenuOpenRequest)
            return;

        var eyeCheck = IsKariEyeHitCheck();
        _isMenuOpenRequest = false;

        if (eyeCheck)
            return;

        IsMenuOpen = true;

        if (!FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_INPUT_OFF) &&
            PlayerWork.isPlayerInputActive &&
            !EvDataManager.Instanse.IsRunningEvent() &&
            !UIManager.IsFieldOpenMenu()) // Added in some update, was not in 1.0.0
        {
            EvDataManager.Instanse.OnOpenMenu();
            var window = UIManager.Instance.CreateUIWindow<XMenuTop>(UIWindowID.XMENU);
            window.onClosed = __ =>
            {
                IsMenuOpen = false;
                EvDataManager.Instanse.OnCloseMenu();

                if (CheckUseItem())
                {
                    UseFieldItem();
                }
                else if (PlayerWork.UsedFieldWazaNo != WazaNo.NULL)
                {
                    UI_SelectWaza(PlayerWork.UsedFieldWazaNo);
                    PlayerWork.UsedFieldWazaNo = WazaNo.NULL;
                }
            };

            var param = new XMenuTop.Param();
            param.menuType = XMenuTop.Param.MenuType.Normal;

            if (FureaiManager.isInstantiated && FureaiManager.Instance.isInHiroba)
                param.menuType = XMenuTop.Param.MenuType.Fureai;

            if (UgFieldManager.isInstantiated)
                param.menuType = XMenuTop.Param.MenuType.UnderGround;

            if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_SAFARI_MODE))
            {
                param.menuType = XMenuTop.Param.MenuType.SafariGame;
                param.safari = new XMenuTop.Param.Safari()
                {
                    ballNum = PlayerWork.SafariBallNum,
                    onRetire = () => EvDataManager.Instanse.RetireSafari(),
                };
            }

            window.Open(param);
            AudioManager.Instance.PlaySe(EVENTS.UI_TOP_XOPEN, null);
        }
        else
        {
            IsMenuOpen = false;
            _isMenuOpenRequest = false;
        }
    }

    // TODO
    private bool MenuOpenInvalidZone() { return false; }

    private bool OpenUnionRoomWarp(bool isUnderGround)
    {
        if (!FieldInput.Push(GameController.ButtonMask.Y))
            return false;

        if (PlayerWork.IsSaveSystemBusy())
            return false;

        if (PlayerWork.IsAutoSaveSystemBusy() || Fader.isBusy)
            return false;

        if (EvDataManager.Instanse.IsRunningEvent() || !IsEnableUnionRoomWarp(isUnderGround))
            return false;

        IsMenuOpen = true;
        EvDataManager.Instanse.OnOpenMenu();

        var window = UIManager.Instance.CreateUIWindow<YunionMenu>(UIWindowID.YUNION);
        window.onClosed = __ =>
        {
            IsMenuOpen = false;
            EvDataManager.Instanse.OnCloseMenu();
        };

        window.Open();
        return true;
    }

    // TODO
    public bool IsEnableUnionRoomWarp(bool isUnderGround) { return false; }

    private bool UseShotCut(float deltatime)
    {
        if (FureaiManager.isInstantiated && FureaiManager.Instance.isInHiroba)
            return false;

        if (UIManager.IsUnion())
            return false;

        switch (_shorCutSeq)
        {
            case 0:
                if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_INPUT_OFF))
                {
                    StopShortCutData();
                    return false;
                }

                if (!PlayerWork.isPlayerInputActive ||
                    UIRegisterItemShortcut.GetHighPriorityShortcutItemNo() == (ushort)ItemNo.DUMMY_DATA ||
                    !IsMenuOpen)
                {
                    StopShortCutData();
                    return false;
                }

                if (EvDataManager.Instanse.IsRunningEvent() ||
                    IsKariEyeHitCheck())
                {
                    StopShortCutData();
                    return false;
                }

                if (FieldInput.Push(GameController.ButtonMask.Plus | GameController.ButtonMask.Minus))
                {
                    _shortCutPushHoldId = 1;
                    _shortCutPushTime += deltatime;
                }
                else if (FieldInput.ButtonOn(GameController.ButtonMask.Plus | GameController.ButtonMask.Minus))
                {
                    if (_shortCutPushHoldId == 1)
                    {
                        _shortCutPushTime += deltatime;

                        if (_shortCutPushTime > 0.5f)
                        {
                            PlayerWork.isPlayerInputActive = false;
                            if (UIRegisterItemShortcut.GetRegisteredShortcutItemCount() > 1)
                                _shorCutSeq = 2;
                            else
                                _shorCutSeq = 1;
                        }
                    }
                }
                else if (FieldInput.ButtonRelease(GameController.ButtonMask.Plus | GameController.ButtonMask.Minus))
                {
                    if (_shortCutPushHoldId == 1)
                    {
                        if (_shortCutPushTime <= 0.0f)
                        {
                            _shorCutSeq = 0;
                            return false;
                        }

                        PlayerWork.isPlayerInputActive = false;
                        _shortCutPushTime = 0.0f;

                        if (UIRegisterItemShortcut.GetRegisteredShortcutItemCount() > 1)
                            _shorCutSeq = 2;
                        else
                            _shorCutSeq = 1;
                    }

                    _shortCutPushHoldId = 0;
                }
                else
                {
                    StopShortCutData();
                }
                break;

            case 1:
                if (IsKariEyeHitCheck())
                {
                    PlayerWork.isPlayerInputActive = true;
                    StopShortCutData();
                    return false;
                }
                else
                {
                    StopShortCutData();
                    var itemNo = UIRegisterItemShortcut.GetHighPriorityShortcutItemNo();
                    var fieldUsability = UI_onUseFieldItem((ItemNo)itemNo);
                    switch (fieldUsability)
                    {
                        case UIManager.FieldUseResult.Available:
                            UseFieldItem((ItemNo)itemNo);
                            break;

                        case UIManager.FieldUseResult.Unusable:
                            if ((ItemNo)itemNo == ItemNo.ZITENSYA && ZoneData.Bicycle)
                            {
                                GameManager.GetAttribute(EntityManager.activeFieldPlayer.gridPosition, out int code, out int stop);
                                if (!PlayerWork.IsFormSwim() &&
                                   (AttributeID.MATR_IsBridgeV(code) || AttributeID.MATR_IsBridgeH(code) || FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_CYCLINGROAD)))
                                {
                                    EvDataManager.Instanse.JumpLabel("ev_no_getoff_bycycle", null);
                                    break;
                                }
                            }

                            EvDataManager.Instanse.JumpLabel("ev_noused_item_talk", null);
                            break;

                        case UIManager.FieldUseResult.Unusable_PairTrainer:
                            EvDataManager.Instanse.JumpLabel("ev_unusable_pair_trainer", null);
                            break;
                    }
                }
                break;

            case 2:
                StopShortCutData();
                OpenShortCut();
                break;
        }

        return _shorCutSeq != 0;
    }

    private bool IsKariEyeHitCheck()
    {
        var codes = EvDataManager.Instanse.FieldObjectMoveCodes;
        var moveVector = Vector3.zero;
        var hitPos = Vector2.zero;

        for (int i=0; i<codes.Count; i++)
        {
            var code = codes[i];
            if (code != null & code.TrainerEyeUpdate(ref moveVector, ref hitPos))
                return true;
        }

        return false;
    }

    private void OpenShortCut()
    {
        AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_MENU_OPEN, null);
        EvDataManager.Instanse.OnOpenMenu();
        IsMenuOpen = true;
        var window = UIManager.Instance.CreateUIWindow<UIRegisterItemShortcut>(UIWindowID.REGISTER_ITEM_SHORTCUT);
        window.OpenUse(itemNo =>
        {
            IsMenuOpen = false;
            EvDataManager.Instanse.OnCloseMenu();
            PlayerWork.isPlayerInputActive = false;

            var fieldUsability = UI_onUseFieldItem((ItemNo)itemNo);
            switch (fieldUsability)
            {
                case UIManager.FieldUseResult.Available:
                    UseFieldItem((ItemNo)itemNo);
                    break;

                case UIManager.FieldUseResult.Unusable:
                    if ((ItemNo)itemNo == ItemNo.ZITENSYA && ZoneData.Bicycle)
                    {
                        GameManager.GetAttribute(EntityManager.activeFieldPlayer.gridPosition, out int code, out int stop);
                        if (!AttributeID.MATR_IsBridgeV(code) && !AttributeID.MATR_IsBridgeH(code))
                        {
                            if (!FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_CYCLINGROAD))
                                EvDataManager.Instanse.JumpLabel("ev_noused_item_talk", null);
                        }

                        EvDataManager.Instanse.JumpLabel("ev_no_getoff_bycycle", null);
                    }
                    else
                    {
                        EvDataManager.Instanse.JumpLabel("ev_noused_item_talk", null);
                    }
                    break;

                case UIManager.FieldUseResult.Unusable_PairTrainer:
                    EvDataManager.Instanse.JumpLabel("ev_unusable_pair_trainer", null);
                    break;
            }
        });

        window.onClosed = __ =>
        {
            if (IsMenuOpen)
            {
                IsMenuOpen = false;
                EvDataManager.Instanse.OnCloseMenu();
            }
        };
    }

    public void StopShortCutData()
    {
        _shorCutSeq = 0;
        _shortCutPushTime = 0.0f;
        _shortCutPushHoldId = 0;
    }

    // TODO
    public void LockHolePos(Vector3 pos) { }

    // TODO
    public void LockHoleEnd() { }

    // TODO
    public static void DebugLot(int randmark) { }

    private void SetMapInfoCameraData(bool isforce)
    {
        if (ZoneData.ZoneID != ZoneID.UNKNOWN)
            GameManager.fieldCamera.SetTempNormalCamera(GameManager.mapInfo.Camera[(int)ZoneData.ZoneID], isforce, 0.0f);
    }

    private bool CheckWeather()
    {
        if (PlayerWork.isEncount)
            return false;

        if (_nowWeather != WeatherWork.WeatherID)
        {
            _nowWeather = WeatherWork.WeatherID;
            WeatherEffectPlay();
            CheckWeatherBGM();
            return true;
        }

        return false;
    }

    private void WeatherEffectPlay()
    {
        _weatherEffectInstance?.Stop();
        _weatherEffectInstance = null;

        var effectId = WeatherWork.GetFieldEffectID();
        if (effectId != EffectFieldID.NONE)
            CallEffect(effectId, null, eff =>
            {
                _weatherEffectInstance = eff;
                var cam = _weatherEffectInstance.gameObject.GetComponent<CameraFollower>();
                if (cam != null)
                    cam.SetCamera(GameManager.fieldCamera.GetComponent<Camera>());
            }, null);
    }

    private void CheckWeatherBGM()
    {
        switch (ZoneData.MapType)
        {
            case MapType.MAPTYPE_TOWN:
            case MapType.MAPTYPE_ROAD:
                switch (_nowWeather)
                {
                    case SYS_WEATHER.SUNNY:
                        AudioManager.Instance.PostEvent(AK.EVENTS.SUNNY);
                        break;

                    case SYS_WEATHER.CLOUDINESS:
                        AudioManager.Instance.PostEvent(AK.EVENTS.CLOUDINESS);
                        break;

                    case SYS_WEATHER.RAIN:
                        AudioManager.Instance.PostEvent(AK.EVENTS.RAIN);
                        break;

                    case SYS_WEATHER.STRAIN:
                        AudioManager.Instance.PostEvent(AK.EVENTS.STRAIN);
                        break;

                    case SYS_WEATHER.SPARK:
                        AudioManager.Instance.PostEvent(AK.EVENTS.SPARK);
                        break;

                    case SYS_WEATHER.SNOW:
                        AudioManager.Instance.PostEvent(AK.EVENTS.SNOW);
                        break;

                    case SYS_WEATHER.SNOWSTORM:
                        AudioManager.Instance.PostEvent(AK.EVENTS.SNOWSTORM);
                        break;

                    case SYS_WEATHER.SNOWSTORM_H:
                        AudioManager.Instance.PostEvent(AK.EVENTS.SNOWSTORM_H);
                        break;

                    case SYS_WEATHER.FOG:
                        AudioManager.Instance.PostEvent(AK.EVENTS.FOG);
                        break;

                    case SYS_WEATHER.VOLCANO:
                        AudioManager.Instance.PostEvent(AK.EVENTS.VOLCANO);
                        break;

                    case SYS_WEATHER.SANDSTORM:
                        AudioManager.Instance.PostEvent(AK.EVENTS.SANDSTORM);
                        break;

                    case SYS_WEATHER.DIAMONDDUST:
                        AudioManager.Instance.PostEvent(AK.EVENTS.DIAMONDDUDT);
                        break;

                    case SYS_WEATHER.SPIRIT:
                        AudioManager.Instance.PostEvent(AK.EVENTS.SPIRIT);
                        break;

                    case SYS_WEATHER.MYSTIC:
                        AudioManager.Instance.PostEvent(AK.EVENTS.MISTIC);
                        break;

                    case SYS_WEATHER.MIST1:
                        AudioManager.Instance.PostEvent(AK.EVENTS.MIST1);
                        break;

                    case SYS_WEATHER.MIST2:
                        AudioManager.Instance.PostEvent(AK.EVENTS.MIST2);
                        break;

                    case SYS_WEATHER.FLASH:
                        AudioManager.Instance.PostEvent(AK.EVENTS.FLASH);
                        break;

                    default:
                        AudioManager.Instance.PostEvent(AK.EVENTS.WEATHER_SILENCE);
                        break;
                }
                break;

            default:
                AudioManager.Instance.PostEvent(AK.EVENTS.WEATHER_SILENCE);
                break;
        }
    }

    public void SetCloudShadowBaseEnable()
    {
        if (_weather != null)
            _weather.SetCloudShadowBaseEnable();
    }

    // TODO
    public void SetCloudShadowBaseDisable() { }

    private UIManager.FieldUseResult UI_onFieldWaza(UIManager.FieldWazaParam param)
    {
        switch (param.wazaNo)
        {
            case WazaNo.ANAWOHORU:
                if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_PAIR))
                    return UIManager.FieldUseResult.Unusable_PairTrainer;
                else if (ZoneData.Escape)
                    return UIManager.FieldUseResult.Available;
                else
                    return UIManager.FieldUseResult.Unusable;

            case WazaNo.TEREPOOTO:
                if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_PAIR))
                    return UIManager.FieldUseResult.Unusable_PairTrainer;
                else if (ZoneData.Fly)
                    return UIManager.FieldUseResult.Available;
                else
                    return UIManager.FieldUseResult.Unusable;

            case WazaNo.TAMAGOUMI:
            case WazaNo.MIRUKUNOMI:
                if (param.targetPokemon == null)
                {
                    if (param.pokemon.GetMaxHp() / 5 < param.pokemon.GetHp())
                        return UIManager.FieldUseResult.Available;
                }
                else if (param.targetPokemon != param.pokemon &&
                    !param.targetPokemon.IsEgg(EggCheckType.BOTH_EGG) &&
                    param.targetPokemon.GetHp() != 0)
                {
                    if (param.targetPokemon.GetHp() != param.targetPokemon.GetMaxHp())
                        return UIManager.FieldUseResult.Available;
                }
                return UIManager.FieldUseResult.Unusable;

            case WazaNo.AMAIKAORI:
                if (FieldEncount.SetSweetEncount() == null)
                    return UIManager.FieldUseResult.Unusable;
                else
                    return UIManager.FieldUseResult.Available;

            case WazaNo.KIRIBARAI:
                if (FieldMistWork.AvailableKiribarai())
                    return UIManager.FieldUseResult.Available;
                else
                    return UIManager.FieldUseResult.Unusable;

            case WazaNo.HURASSYU:
                if (FieldFlashWork.AvailableFlash())
                    return UIManager.FieldUseResult.Available;
                else
                    return UIManager.FieldUseResult.Unusable;

            default:
                return UIManager.FieldUseResult.Unusable;
        }
    }

    // TODO
    public void UI_SelectWaza(WazaNo waza) { }

    private UIManager.FieldUseResult UI_onUseFieldItem(ItemInfo item)
    {
        return UI_onUseFieldItem((ItemNo)item.Id);
    }

    private UIManager.FieldUseResult UI_onUseFieldItem(ItemNo id)
    {
        switch (id)
        {
            case ItemNo.ANANUKENOHIMO:
            case ItemNo.BORONOTURIZAO:
            case ItemNo.IITURIZAO:
            case ItemNo.SUGOITURIZAO:
            case ItemNo.ZITENSYA:
                if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_PAIR))
                    return UIManager.FieldUseResult.Unusable_PairTrainer;
                break;
        }

        return CheckAvailableFieldItem(id) ? UIManager.FieldUseResult.Available : UIManager.FieldUseResult.Unusable;
    }

    private bool CheckAvailableFieldItem(ItemNo id)
    {
        switch (id)
        {            
            case ItemNo.SIRUBAASUPUREE:
            case ItemNo.GOORUDOSUPUREE:
            case ItemNo.MUSIYOKESUPUREE:
                if (ZoneData.MapType != MapType.MAPTYPE_UNDERGROUND)
                    return !ItemWork.IsUseSpray(out ItemNo item);
                else
                    return false;

            case ItemNo.ANANUKENOHIMO:
                return ZoneData.Escape;

            case ItemNo.AMAIMITU:
                return FieldEncount.SetSweetEncount() != null;

            case ItemNo.TANKENSETTO:
                if (!FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_CYCLINGROAD))
                {
                    if (!EntityManager.activeFieldPlayer.IsSwim())
                    {
                        GameManager.GetAttribute(EntityManager.activeFieldPlayer.gridPosition, out int code, out int stop);
                        if (!AttributeID.MATR_IsBridge(code) && IsEnableSave())
                            return EvDataManager.Instanse.IsCanGotoUG();
                    }
                }
                return false;

            case ItemNo.POKETORE:
                if (!PlayerWork.IsFormBicycle())
                {
                    GameManager.GetAttribute(EntityManager.activeFieldPlayer.gridPosition, out int code, out int stop);
                    if (AttributeID.MATR_IsGrass(code))
                        return true;
                }
                return false;

            case ItemNo.POINTOKAADO:
            case ItemNo.BOUKENNOOTO:
            case ItemNo.POFINKEESU:
            case ItemNo.DSPLAYER:
                return true;

            case ItemNo.BATORUSAATYAA:
                return ZoneData.BattleSearcher;

            case ItemNo.BORONOTURIZAO:
                return _fishing.StartFishing(FishingRod.BoroiTurizao);

            case ItemNo.IITURIZAO:
                return _fishing.StartFishing(FishingRod.IiTurizao);

            case ItemNo.SUGOITURIZAO:
                return _fishing.StartFishing(FishingRod.SugoiTurizao);

            case ItemNo.KODAKKUZYOURO:
                return KinomiWork.IsWaterContactEntity() != null;

            case ItemNo.ZITENSYA:
                if (ZoneData.Bicycle)
                {
                    if (!EntityManager.activeFieldPlayer.IsSwim())
                    {
                        if (AttributeID.IsUseBicycle(EntityManager.activeFieldPlayer.gridPosition, EntityManager.activeFieldPlayer.Height))
                            return !FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_CYCLINGROAD);
                    }
                }
                return false;

            default:
                return false;
        }
    }

    private bool CheckUseItem()
    {
        if (PlayerWork.UsedFieldItem == null)
            return false;

        var array = new ItemNo[18]
        {
            ItemNo.ANANUKENOHIMO,  ItemNo.AMAIMITU,       ItemNo.TANKENSETTO,     ItemNo.POKETORE,
            ItemNo.BATORUSAATYAA,  ItemNo.BORONOTURIZAO,  ItemNo.IITURIZAO,       ItemNo.SUGOITURIZAO,
            ItemNo.KODAKKUZYOURO,  ItemNo.ZITENSYA,       ItemNo.MUSIYOKESUPUREE, ItemNo.SIRUBAASUPUREE,
            ItemNo.GOORUDOSUPUREE, ItemNo.KINOMIPURANTAA, ItemNo.POINTOKAADO,     ItemNo.POFINKEESU,
            ItemNo.BOUKENNOOTO,    ItemNo.DSPLAYER,
        };

        for (int i=0; i<array.Length; i++)
        {
            if ((int)array[i] == PlayerWork.UsedFieldItem.Id)
                return true;
        }

        return PlayerWork.UsedFieldItem.GetItemType() == ItemInfo.eItemType.Kinomi;
    }

    private void UseFieldItem()
    {
        UseFieldItem((ItemNo)PlayerWork.UsedFieldItem.Id);
        PlayerWork.UsedFieldItem = null;
    }

    private void UseFieldItem(ItemNo itemno)
    {
        switch (itemno)
        {
            case ItemNo.DUMMY_DATA:
                break;

            case ItemNo.SIRUBAASUPUREE:
            case ItemNo.GOORUDOSUPUREE:
            case ItemNo.MUSIYOKESUPUREE:
                var param = PlayerWork.UsedFieldItem.GetParam(ItemData.PrmID.ATTACK);
                ItemWork.SetSpray(itemno, (short)(param * 5));
                break;

            case ItemNo.ANANUKENOHIMO:
                EvDataManager.Instanse.JumpLabel("ev_exec_item_ananukenohimo", null);
                break;

            case ItemNo.AMAIMITU:
                EvDataManager.Instanse.JumpLabel("ev_exec_item_amaimitu", null);
                break;

            case ItemNo.TANKENSETTO:
                EvDataManager.Instanse.JumpLabel("ev_ug_tankenset_do", null);
                break;

            case ItemNo.POKETORE:
                EvDataManager.Instanse.JumpLabel("ev_poketore", null);
                break;

            case ItemNo.POINTOKAADO:
                EvDataManager.Instanse.JumpLabel("ev_pointcard", null);
                break;

            case ItemNo.BOUKENNOOTO:
                EvDataManager.Instanse.JumpLabel("ev_boukennooto", null);
                break;

            case ItemNo.BATORUSAATYAA:
                EvDataManager.Instanse.JumpLabel("ev_btl_searcher", null);
                break;

            case ItemNo.BORONOTURIZAO:
                _useRod = FishingRod.BoroiTurizao;
                break;

            case ItemNo.IITURIZAO:
                _useRod = FishingRod.IiTurizao;
                break;

            case ItemNo.SUGOITURIZAO:
                _useRod = FishingRod.SugoiTurizao;
                break;

            case ItemNo.KODAKKUZYOURO:
                var kinomi = KinomiWork.IsWaterContactEntity();
                if (kinomi == null)
                    break;

                PlayerWork.isPlayerInputActive = false;
                FlagWork.SetWork(EvWork.WORK_INDEX.SCWK_TARGET_OBJID, kinomi.EventParams.FieldObjectIndex);
                EvDataManager.Instanse.JumpLabel("ev_kinomi_bag_zyouro", null);
                break;

            case ItemNo.POFINKEESU:
                EvDataManager.Instanse.JumpLabel("ev_pofinkeesu", null);
                break;

            case ItemNo.ZITENSYA:
                RidBicycle(() => PlayerWork.isPlayerInputActive = true);
                break;

            case ItemNo.DSPLAYER:
                EvDataManager.Instanse.JumpLabel("ev_dsplayer", null);
                break;

            default:
                if (PlayerWork.UsedFieldItem.GetItemType() != ItemInfo.eItemType.Kinomi)
                    break;

                PlayerWork.isPlayerInputActive = false;
                FlagWork.SetWork(EvWork.WORK_INDEX.SCWK_PARAM0, (int)itemno);
                FlagWork.SetWork(EvWork.WORK_INDEX.SCWK_TARGET_OBJID, KinomiWork.IsKinomiContactEntity().EventParams.FieldObjectIndex);
                EvDataManager.Instanse.JumpLabel("ev_kinomi_bag_kinomi", null);
                break;
        }
    }

    private void UI_onWazaFly(ZoneID zoneid, int locatorIndex)
    {
        EvDataManager.Instanse.SorawotobuZoneId = zoneid;
        EvDataManager.Instanse.SorawotobuLocatorIndex = locatorIndex;

        FieldPoketch.UseHidenWaza(FieldPoketch.HidenWazaType.Sorawotobu);
        EncountDataWork.MovePoke_RandomZone();
        EncountDataWork.MovePoke_PlayerEqualZoneNextZone(zoneid);
        StopSwayGrass_NextArea();
    }

    public bool StopSwayGrass_NextArea()
    {
        if (!SwayGrass.SwayGrass_CheckValid())
            return false;

        AudioManager.Instance.PostEvent(AK.EVENTS.BA013_TO_NEXT_AREA);
        SwayGrass.SwayGrass_InitSwayGrass();
        return true;
    }

    private bool CheckIgnoreWeatherSweetEncount(SYS_WEATHER weather)
    {
        switch (weather)
        {
            case SYS_WEATHER.CLOUDINESS:
            case SYS_WEATHER.RAIN:
            case SYS_WEATHER.STRAIN:
            case SYS_WEATHER.SPARK:
            case SYS_WEATHER.SNOW:
            case SYS_WEATHER.SNOWSTORM:
            case SYS_WEATHER.SNOWSTORM_H:
            case SYS_WEATHER.VOLCANO:
            case SYS_WEATHER.SANDSTORM:
            case SYS_WEATHER.MYSTIC:
            case SYS_WEATHER.MIST1:
            case SYS_WEATHER.MIST2:
            case SYS_WEATHER.FLASH:
            case SYS_WEATHER.SPARK_EFF:
                return true;

            default:
                return false;
        }
    }

    // TODO
    public bool StartSweetEncount() { return false; }

    public void SetBgmEvent(string eventName)
    {
        SetBgmEvent(AkSoundEngine.GetIDFromString(eventName));
    }

    public void SetBgmEvent(uint eventid)
    {
        uint finalEventId = BGMFlagCheck(eventid);
        AudioManager.Instance.SetBgmEvent(finalEventId);

        switch (finalEventId)
        {
            case AK.EVENTS.PC_NIGHT:
            case AK.EVENTS.PC_DAY:
            case AK.EVENTS.NAZO_A:
            case AK.EVENTS.NAZO_B:
                finalEventId = 0;
                break;
        }

        var sysData = PlayerWork.SystemData;
        sysData.fd_bgmEvnet = finalEventId;
        PlayerWork.SystemData = sysData;
    }

    // TODO
    public void SetWwiseEvent(string eventName) { }

    private uint BGMFlagCheck(uint eventid)
    {
        if (ItemWork.IsDsPlayer())
            AudioManager.Instance.SetBgmEvent(AK.EVENTS.DSPLAYER_ON);
        else
            AudioManager.Instance.SetBgmEvent(AK.EVENTS.DSPLAYER_OFF);

        if (FlagWork.GetFlag(EvWork.FLAG_INDEX.BGM_FLAG_C04_GINGA_FALSE))
            AudioManager.Instance.SetBgmEvent(AK.EVENTS.C04_GINGA_FALSE);

        switch (eventid)
        {
            case AK.EVENTS.B_OPE003:
                if (GameManager.nowTime.DayOfWeek != DayOfWeek.Friday ||
                    GameManager.nowTime.Hour < 19)
                    return AK.EVENTS.B_OPE003;
                else
                    return AK.EVENTS.B_BOU002;

            case AK.EVENTS.D29:
            case AK.EVENTS.D29R0103:
                if (FlagWork.GetWork(EvWork.WORK_INDEX.TOWNMAP_GUIDE_SEQUENCE) < 9000)
                    break;

                if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_BGM_D29))
                    AudioManager.Instance.SetBgmEvent(AK.EVENTS.D29_GINGA_FALSE);
                else
                    AudioManager.Instance.SetBgmEvent(AK.EVENTS.GINGA_TRUE);
                break;

            case AK.EVENTS.D28:
            case AK.EVENTS.D28R0103:
                if (FlagWork.GetWork(EvWork.WORK_INDEX.TOWNMAP_GUIDE_SEQUENCE) < 9000)
                    break;

                if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_BGM_D28))
                    AudioManager.Instance.SetBgmEvent(AK.EVENTS.D28_GINGA_FALSE);
                else
                    AudioManager.Instance.SetBgmEvent(AK.EVENTS.GINGA_TRUE);
                break;

            case AK.EVENTS.D27:
            case AK.EVENTS.D27R0103:
                if (FlagWork.GetWork(EvWork.WORK_INDEX.TOWNMAP_GUIDE_SEQUENCE) < 9000)
                    break;

                if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_BGM_D27))
                    AudioManager.Instance.SetBgmEvent(AK.EVENTS.D27_GINGA_FALSE);
                else
                    AudioManager.Instance.SetBgmEvent(AK.EVENTS.GINGA_TRUE);
                break;

            case AK.EVENTS.D26:
                if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_BGM_D26))
                    return AK.EVENTS.D26_KEY;
                else
                    return AK.EVENTS.D26;
        }

        return eventid;
    }

    private bool NotSaveBgmEvent(uint eventid)
    {
        switch (eventid)
        {
            case AK.EVENTS.PC_NIGHT:
            case AK.EVENTS.PC_DAY:
            case AK.EVENTS.NAZO_A:
            case AK.EVENTS.NAZO_B:
                return true;

            default:
                return false;
        }
    }

    public void SetWwiseEvent(uint eventid)
    {
        AudioManager.Instance.PostEvent(eventid);
    }

    public void UniqueBGMEvent(ZoneID nextid, ZoneID oldid)
    {
        if (nextid == ZoneID.UNKNOWN)
            return;

        if (PlayerWork.IsFormBicycle())
        {
            if (oldid == ZoneID.UNKNOWN)
            {
                SetWwiseEvent(AK.EVENTS.FADEIN_ON);
            }
            else
            {
                if (GameManager.mapInfo[(int)nextid].MapType == MapType.MAPTYPE_CAVE &&
                    GameManager.mapInfo[(int)oldid].MapType != MapType.MAPTYPE_CAVE)
                {
                    SetWwiseEvent(AK.EVENTS.FADEIN_OFF);
                }
                else if (GameManager.mapInfo[(int)nextid].MapType != MapType.MAPTYPE_CAVE &&
                    GameManager.mapInfo[(int)oldid].MapType == MapType.MAPTYPE_CAVE)
                {
                    SetWwiseEvent(AK.EVENTS.FADEIN_ON);
                }
            }
        }
        else
        {
            SetWwiseEvent(AK.EVENTS.FADEIN_OFF);
        }
    }

    // TODO
    public void RidBicycle(Action onfinish) { }

    private bool FishingUpdate(float time)
    {
        if (_useRod == FishingRod.None)
            return false;

        if (!_fishing.StartFishing(_useRod))
            return false;

        EvDataManager.Instanse.Cmd_ObjPauseAll();
        if (StopSwayGrass_NextArea())
            SetBgmEvent(GetNowBgmState());

        _updateType = UpdateType.Fishing;
        return true;
    }

    // TODO
    public void SetWazaAction(FieldWazaAction action) { }

    public void SetTownMapPos(ZoneID zoneid, ref Vector3 pos)
    {
        var save = PlayerWork.PlayerSaveData;
        save.TownMapLocation.zoneID = (int)zoneid;
        save.TownMapLocation.posX = pos.x;
        save.TownMapLocation.posY = pos.y;
        save.TownMapLocation.posZ = pos.z;
        save.TownMapLocation.dir = 0;
        PlayerWork.PlayerSaveData = save;
    }

    // TODO
    public void GetTownMapPos(out ZoneID zoneid, out Vector3 pos, bool isForcePrevious = false)
    {
        zoneid = ZoneID.UNKNOWN;
        pos = Vector3.zero;
    }

    // TODO
    public void SetAkLisnerTransform(Transform tra) { }

    // TODO
    public void UpdateAkLisner() { }

    public void OnZoneChange_Subcontents(bool walk)
    {
        if (PlayerWork.zoneID != ZoneID.D11R0101)
            DeleteFreaiManager();
        else
            CreateFreaiManager();

        if (PlayerWork.zoneID == ZoneID.D11R0101 || PlayerWork.zoneID == ZoneID.C05R1001)
        {
            if (!PoffinCookingSceneManager.isInstantiated)
                new GameObject("PoffinCookingManager").AddComponent<PoffinCookingSceneManager>();
        }
        else
        {
            if (PoffinCookingSceneManager.isInstantiated)
                UnityEngine.Object.Destroy(PoffinCookingSceneManager.Instance.gameObject);
        }

        if (fwMng.PartnerPokeParam == null)
            fwMng.LoadPartnerPoke();

        if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_PAIR))
        {
            TrainerID partner = (TrainerID)FlagWork.GetWork(EvWork.WORK_INDEX.SYS_WORK_PAIR_TRAINER_ID);
            if (partner != TrainerID.NONE)
            {
                if (fwMng.SetPartnerNpcName(partner))
                {
                    fwMng.NPCToPartner();
                    if (fwMng.isLoaded)
                        fwMng.TurearukiWarp();
                }
            }
        }
        else
        {
            if (FlagWork.GetWork(EvWork.WORK_INDEX.WK_PAIR_POKEMON_INDEX) != 0)
            {
                if (fwMng.PartnerPokeParam != null)
                    Sequencer.Start(fwMng.CreatePartner(false, false, !walk));
            }
        }

        fwMng.prevArea = ZoneData.AreaID;
    }

    public void CreateFreaiManager()
    {
        if (FureaiDataManager.Instance == null)
            new GameObject("FureaiDataManager").AddComponent<FureaiDataManager>();
    }

    public void DeleteFreaiManager()
    {
        if (FureaiManager.isInstantiated)
            FureaiManager.Instance.Destroy();
    }

    private void GetLegendPokeEncountInfo(PokemonParam param, out string encSec, ref ArenaID arenaID, out string bgm, out BattleSetupEffectId setupEffect)
    {
        encSec = null;
        bgm = null;
        setupEffect = BattleSetupEffectId.DEFAULT;

        var encount = GetFieldEncountTableLegendPoke(param.GetMonsNo(), param.GetFormNo());
        if (encount != null)
        {
            if (encount.isFixedEncSeq)
                encSec = encount.encSeq;

            if (encount.isFixedBGM)
                bgm = encount.bgmEvent;

            if (encount.isFixedBtlBg)
                arenaID = encount.btlBg;

            if (encount.isFixedSetupEffect)
                setupEffect = encount.setupEffect;

            if (encount.waza1 > -1)
                param.SetWaza(0, (WazaNo)encount.waza1);

            if (encount.waza2 > -1)
                param.SetWaza(1, (WazaNo)encount.waza2);

            if (encount.waza3 > -1)
                param.SetWaza(2, (WazaNo)encount.waza3);

            if (encount.waza4 > -1)
                param.SetWaza(3, (WazaNo)encount.waza4);
        }
    }

    private static FieldEncountTable.Sheetlegendpoke GetFieldEncountTableLegendPoke(MonsNo monsNo, ushort formNo)
    {
        for (int i=0; i<GameManager.fieldEncountTable.legendpoke.Length; i++)
        {
            var legendpoke = GameManager.fieldEncountTable.legendpoke[i];
            if (legendpoke.monsNo == monsNo && (legendpoke.formNo == -1 || legendpoke.formNo == formNo))
                return legendpoke;
        }

        return null;
    }

    public bool IsEnableSave(bool isIgnoreGround = false)
    {
        var player = EntityManager.activeFieldPlayer;

        if (IsNoEntry(player.gridPosition, player.worldPosition))
            return false;

        if (IsNoEntrySea(player.gridPosition, player.worldPosition))
            return false;

        if (isIgnoreGround)
            return true;

        // Ground BoxCollider check
        return CollisionUtility.IsCollideGround(player.worldPosition, 1.0f, Layer.Ground);
    }

    // TODO
    public bool IsNoEntry(Vector2Int gridPos, Vector3 worldPos) { return false; }

    // TODO
    public bool IsNoEntrySea(Vector2Int gridPos, Vector3 worldPos) { return false; }

    // TODO
    public SYS_WEATHER GetBatleWeather() { return SYS_WEATHER.SUNNY; }

    public UgMainProc GetUgMainProc() {
        return _ugMainProc;
    }

    private void SaveCheckCyclingRoad()
    {
        if (!FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_CYCLINGROAD) && _now_zoneID == ZoneID.R206)
        {
            float x = EntityManager.activeFieldPlayer.worldPosition.x;
            float y = EntityManager.activeFieldPlayer.worldPosition.y;
            float z = EntityManager.activeFieldPlayer.worldPosition.z;

            if (-298.0f >= x && x >= -307.0f && 681.0f >= z && z >= 576.0f && y > 2.99f)
                FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_CYCLINGROAD, true);
        }
    }

    public enum UpdateType : int
    {
        Field = 0,
        UnderGround = 1,
        Encount = 2,
        Fishing = 3,
        DemoWait = 4,
    }

    private enum EncountUpdateType : int
    {
        CallEffect = 0,
        EndWait = 1,
        CallBackWait = 2,
        TrainerEffWait = 3,
        End = 4,
    }

    public enum EncountFadeType : int
    {
        Normal = 0,
        Trainer = 1,
    }

    public enum AttributeEventType : int
    {
        Run = 0,
        Jump = 1,
    }

    public enum AttributeEventCallType : int
    {
        Player = 0,
        NPC_Heel = 1,
        NPC = 2,
    }

    public struct AttributeEvent
    {
	    public int chartype;
        public bool isRun;
        public bool isBic;
        public FieldObjectEntity entity;
        public AttributeEventType eventType;
        public AttributeEventCallType callType;
    }

    private class LoadEffectData
    {
	    public string name;
        public EffectData effect;
        public bool isLoading;
        public bool isComplete;
    }

    public delegate bool FieldWazaAction(float deltatime);

    public enum AutoSaveState : int
    {
        None = 0,
        Zone_Change = 1,
        BattleResult = 2,
        EventScript = 3,
        Stop = 4,
    }
}