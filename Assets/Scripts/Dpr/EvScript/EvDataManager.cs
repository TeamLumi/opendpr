using System;
using System.Collections;
using System.Text;
using UnityEngine;
using Pml;
using Dpr.Trainer;
using DPData;
using Dpr.UI;
using SmartPoint.AssetAssistant;
using Audio;
using Pml.PokePara;
using XLSXContent;
using Dpr.Battle.Logic;
using System.Collections.Generic;
using Dpr.MsgWindow;
using Effect;
using Dpr.Message;
using GameData;
using FieldCommon;
using Dpr.UnderGround;
using SmartPoint.Components;
using Dpr.BattleMatching;
using System.Linq;
using Dpr.SubContents;
using System.Runtime.InteropServices;
using Dpr.FureaiHiroba;
using Dpr.Field;
using Dpr;
using Dpr.NetworkUtils;

namespace Dpr.EvScript
{
    public class EvDataManager
    {
        private static EvDataManager _instanse = null;
        public static EvDataManager Instanse
        {
            get
            {
                if (_instanse == null)
                    _instanse = new EvDataManager();

                return _instanse;
            }
        }

        public static bool IsFirstInitializedAfterSaveDataLoad = false;
        private const string Path_Parsons = "persons/field/";
        private const string Path_Poke_Model = "pokemons/field/";
        private const int Graphic_Gimmick = 500;
        private const int Graphic_Poke = 10000;
        private const float HitMinSize = 3.0f;
        private const int Graphic_SekiZou = 1000;
        private const int Graphic_SekiZouMAX = 3000;
        public event Action<EntityParam> OnTalkStartCallBack;
        private bool _isScriptLoad = true;
        private EvScriptData[] _eventList;
        private int _eventListIndex;
        private Stack<EvCallData> _callQueue = new Stack<EvCallData>(10);
        private Dictionary<string, int[]> _findAllLabel;
        private FieldObjectEntity _hit_object;
        private FieldObjectEntity _hit_object_sub;
        private Vector3 _hit_position;
        private CmpResult _cmp_flag;
        private AssetRequestOperation _scriptOperation;
        private AreaID _areaID;
        private const int WarpListLength = 30;
        private List<FieldEventEntity> _warpList = new List<FieldEventEntity>(WarpListLength);
        private MapWarp _warpData;
        private GameObject _warpRoot;
        private PlaySeData[] _se_datas;
        private PlaySeData[] _voice_datas;
        private Vector2Int _eventEndPosition;

        private string _posEventLabelReserve;
        public bool IsPosEventReserved { get => !string.IsNullOrEmpty(_posEventLabelReserve); }

        private const int EntityParamLength = 50;
        private EntityParam[] _entityParamList;
        private GameObject _stopRoot;
        private bool _isInitFirstMap;

        public FieldObjectEntity _dummyPlayer { get; private set; }

        private UpdateDelegate _updateDelegate;
        private EventEndDelegate _eventEndDelegate;
        private FieldEventDoorEntity _doorEntity;
        private WorpEventData _worpEventData;

        public bool IsContactDoor() => _doorEntity != null || _worpEventData.Entity != null;

        private Vector2Int _eqZoneWorpGrid;
        private bool _isEqZoneWorp;
        private FieldEventLiftEntity _liftEntity;
        private FieldTobariGymWallEntity _tobariGymWallEntity;
        private FieldNagisaGymGearEntity _nagisaGymGearEntity;
        private FieldNomoseGymSwitchEntity _nomoseGymSwitchEntity;
        private FieldEyePaintingEntity _eyePaintingEntity;
        private FieldEmbankmentEntity _embankmentEntity;
        private FieldMistPlate _mistPlate = new FieldMistPlate();

        public FieldPokemonCenter PokemonCenter { get; private set; }
        public Telescope Telescope { get; private set; } = new Telescope();
        public TelescopeNagisa TelescopeNagisa { get; private set; } = new TelescopeNagisa();

        private bool AzukariyaInitEventFlag;

        public FieldWazaCutIn FieldWazaCutIn { get; private set; } = new FieldWazaCutIn();
        public InterviewWork InterviewWork { get; private set; } = new InterviewWork();

        private int[] TvCommercials;
        private int TvCommercialsCurrentIndex;

        public FieldShip FieldShip { get; private set; } = new FieldShip();

        private string _callLabel_SceneChange = "";
        private string _callLabel_UpdateSP = "";
        private string _callLabel_AdjustHeroPos = "";
        private const int FieldObjectMoveCodesLength = 200;
        public List<FieldObjectMoveCode> FieldObjectMoveCodes;
        private bool _lateUpdateMoveCode;
        private bool _isCall_TrainerBtl;
        private EvCallData _battleReturnData;
        private FieldObjectEntity _battleReturnHitObject;

        private const int TRAINER_EYE_HITMAX = 2;
        private const int SCR_EYE_TR_TYPE_SINGLE = 0;
        private const int SCR_EYE_TR_TYPE_DOUBLE = 1;
        private const int SCR_EYE_TR_TYPE_TAG = 2;

        private FieldObjectMoveCode[] _eyeEncountTarget = new FieldObjectMoveCode[2];
        private Balloon[] _eyeEncountBallon = new Balloon[2];
        private float _eyeEncountWait;
        private int _eyeEncountSeq;
        private int[] _talkTrinerIndex = new int[2];
        public TrainerType Btl_TrainerType1 = TrainerType.INVALID;
        public TrainerType Btl_TrainerType2 = TrainerType.INVALID;
        private int _ugSeq;
        private Vector3 _ugEndPos;
        private Vector3 _ugHoleRot = new Vector3(0.0f, 0.0f, 0.0f);

        private const float _fallSpd = 0.25f;
        private const float _fallOffset = 15.0f;
        private const float _fallRotSpd = 35.0f;
        private const float _fallDiveSpd = 15.0f;
        private const float _fallDiveAcce = 0.1f;

        private float _ugFallSpdCurrent;
        private int _ugDiveSeq = 100;
        private float _ugDiveUpdateTime;
        private float _ugDiveRotTime;
        private float _ugDiveRotStart;
        private float _ugDiveRotEnd;
        private float _ugDiveJumpingTime;

        private const float _fromRotSpd = 50.0f;
        private const float _fromRotAcce = 4.0f;
        private const float _fromRotSpdMin = 10.0f;

        private int _ugFromSeq;
        private float _ugFromJumpTime;
        private float _ugFromRotSpdCurrent;
        private UgJumpPos.SheetData _ugNextJumpPos;
        private FieldToUgInvisibleObjects _toUgInvisibleObjects = new FieldToUgInvisibleObjects();
        private ZoneID _cacheZoneID_SceneChange;
        private bool _pendingInitScripts;
        public ZoneID SorawotobuZoneId = ZoneID.UNKNOWN;
        public int SorawotobuLocatorIndex = -1;
        private EventCameraTable _evCameraTable;
        private TairyouHasseiPokeManager _tairyouHasseiMane;
        private bool _isFadeEventReturnInput;
        private float _cloudSpeed;
        private float _cloudTime = 1.0f;
        private const float _const_cloudTime = 5.0f;
        private const float _app_frame = 0.033333335f;

        private const int _WORK_TRUE = 1;
        private const int _WORK_FALSE = 0;

        private const string SEQ_SE_DP_SELECT = "UI_common_decide";

        private int _switch_work_index = -1;
        private float _timeWait;
        private MsgWindowParam _msgWindowParam = new MsgWindowParam();
        private MsgWindowParam _msgWindowParamOther = new MsgWindowParam();
        private MsgOpenParam _msgOpenParam;
        private bool _isAutoMsg;
        private MSGSPEED _eMsgSpeed = MSGSPEED.MSGSPEED_NORMAL;
        private float _autoTime;
        private BOARD _boardState;
        private MsgWindow.MsgWindow _msgWindow;
        private MsgWindow.MsgWindow _msgWindowOther;
        private Coroutine _msgWindowCoroutine;
        private TalkState _talkStart;
        private EvCmdID.NAME _macroCmd;
        private EvCmdID.NAME _procCmd;
        private string _talkOpenMsbt;
        private string _talkOpenLabel;
        private float _turnEndFrame_Hero = 0.3333333f;
        private float _turnEndFrame_Obj = 0.3333333f;
        private float[] _turnTime = new float[2];
        private Quaternion[] _turnEndQuaternion = new Quaternion[2];
        private bool[] _turnDiffFlag = new bool[2];
        private float _deltatime;
        private string _mapChangeZoneID;
        private int _mapChangeIndex;
        private Quaternion _moveGridCenterStart;
        private Quaternion _moveGridCenterEnd;
        private bool _isOpenSubContentsMenu;
        private bool _isWaitCheckOnlineAccount;
        private string _custumWindow_msbt;
        private List<string> _custumWindow_Labels = new List<string>();
        private List<int> _custumWindow_RetIndex = new List<int>();
        private FieldEventEntity _selectDoorObject;
        private float _fadeSpeed = 0.5f;
        private HeroReqBit _heroReqBit;
        private DIR _heroMoveGridCenterFrontDir;
        private bool _heroMoveGridCenterFrontStat;
        private FieldObjectMove _fieldObjectMove = new FieldObjectMove();
        private FieldObjectRotateYaw _fieldObjectRotateYaw = new FieldObjectRotateYaw();
        private FieldFloatMove _fieldFloatMove = new FieldFloatMove();
        private int _hidenSequence;
        private Vector3 _takiTargetPosition;
        private Vector3 _rockClimbingEndPos;
        private Vector3 _rockClimbingStandPos;
        private bool _hidenEffectWait;
        private bool _rideBicycleReserve;
        private FieldEventLiftEntity _runEventLiftEntity;
        private int _liftSequence;
        private int _gearSequence;
        private int _waterSequence;
        private int _kinomiSequence;
        private float _kinomiSequenceTime;
        private EffectInstance _kinomiEffect;
        private int _warpSequence;
        private int _warpSpeedSequence;
        private float _warpSpeedSequenceTime;
        private int _scopeSequence;
        private int _azukariyaSequence;
        private int _pokelistSequence;
        private int _pokelistBox;
        private int _pokelistIndex;
        private int _trainSequence;
        private int _itemSequence;
        private int _btwrSequence;
        private bool _isOpenSpecialWin;
        private int _openSpecialWinLabelSelected = -1;
        private TV_PROGRAM _currentTvProgram = TV_PROGRAM.MAX;
        private CutInState _cutinState;

        private const int TRMSG_FIGHT_START = 0;
        private const int TRMSG_FIGHT_LOSE = 1;
        private const int TRMSG_FIGHT_AFTER = 2;
        private const int TRMSG_FIGHT_START_1 = 3;
        private const int TRMSG_FIGHT_LOSE_1 = 4;
        private const int TRMSG_FIGHT_AFTER_1 = 5;
        private const int TRMSG_POKE_ONE_1 = 6;
        private const int TRMSG_FIGHT_START_2 = 7;
        private const int TRMSG_FIGHT_LOSE_2 = 8;
        private const int TRMSG_FIGHT_AFTER_2 = 9;
        private const int TRMSG_POKE_ONE_2 = 10;
        private const int TRMSG_FIGHT_NONE_DN = 11;
        private const int TRMSG_FIGHT_NONE_D = 12;
        private const int TRMSG_FIGHT_FIRST_DAMAGE = 13;
        private const int TRMSG_FIGHT_POKE_HP_HALF = 14;
        private const int TRMSG_FIGHT_POKE_LAST = 15;
        private const int TRMSG_FIGHT_POKE_LAST_HP_HALF = 16;
        private const int TRMSG_REVENGE_FIGHT_START = 17;
        private const int TRMSG_REVENGE_FIGHT_START_1 = 18;
        private const int TRMSG_REVENGE_FIGHT_START_2 = 19;
        private const int MUGEN_LOOP = 5000;

        private bool _isShopOpen;
        private int _bagSelectItemNo;
        private FloorWindow _floorWindow;
        private MoneyWindow _moneyWindow;
        private StringBuilder matchingPassword = new StringBuilder();
        private static Dictionary<int, MonsNo> KasekiFukugenTable = new Dictionary<int, MonsNo>()
        {
            { 103, MonsNo.PUTERA },
            { 101, MonsNo.OMUNAITO },
            { 102, MonsNo.KABUTO },
            { 99, MonsNo.RIRIIRA },
            { 100, MonsNo.ANOPUSU },
            { 104, MonsNo.TATETOPUSU },
            { 105, MonsNo.ZUGAIDOSU },
        };
        private int _openTownMapSeq;
        private bool _isOpenBtlTowerRecode;
        private int _softwareKeyboardSubState;
        private int _effSeq;
        private bool _pc_window_close;
        private int _dendou;
        private FieldAnimatorController[] _umaAnimatorCtr;
        private bool _isOpenCustomBallTrainer;
        private int _nicknamePlacementSequence;
        private EffectInstance[] _scriptEffects = new EffectInstance[10];
        private Coroutine[] _scriptScaleCorutine = new Coroutine[10];
        private bool[] _scriptScaleVectol = new bool[10];
        private PokemonParam _temp_PokePara;
        private bool _isBattleTowerBtl;
        private bool _isBattleTowerWin;
        private Vector2 _playerMoveGridCenterAngle;
        private EvScriptData _evData;
        private EvData.Script _evScript;
        private EvData.Command _evCommand;
        private EvData.Aregment[] _evArg;
        private int btlsearchSeq;
        private AudioInstance btlserchAudio;
        private bool _isOpenHallOfFame;

        private const int RockClimbSequence_None = 0;
        private const int RockClimbSequence_JumpUp = 1;
        private const int RockClimbSequence_JumpLoop = 2;
        private const int RockClimbSequence_Climb = 3;
        private const int RockClimbSequence_EndJumpUp = 4;
        private const int RockClimbSequence_EndJumpLoop = 5;
        private const int RockClimbSequence_EndJumpEnd = 6;

        private Coroutine _cmdReportSaveCoroutine;
        private int _seqRankingView;

        private static (int, int, int)[] PokemonSizeTable = new (int, int, int)[16]
        {
            (290, 1, 0),
            (300, 1, 10),
            (400, 2, 110),
            (500, 4, 310),
            (600, 20, 710),
            (700, 50, 2710),
            (800, 100, 7710),
            (900, 150, 17710),
            (1000, 150, 50886),
            (1100, 100, 47710),
            (1200, 50, 57710),
            (1300, 20, 62710),
            (1400, 5, 64710),
            (1500, 2, 65210),
            (1600, 1, 65410),
            (1700, 1, 65510),
        };

        private bool _isOpenCertificate;
        private int returnSequenceID;
        public static bool EventCameraEnable = false;
        private bool _boukennootoTipsOpen;

        private const int FashionSeq_Reqest = 0;
        private const int FashionSeq_Wait = 1;
        private const int FashionSeq_End = 2;
        private const int FashionSeq_Error = 999;

        private int _fashionLoadSeq;
        private string _oldfashionAssetReqUri = "";
        private AssetRequestOperation _fashionAssetReqOp;
        private float _fashionYawAngle;
        private Vector3 _fashionWorldpos;
        private bool _isTraining;
        private bool _isOpenTraining;

        private const int LIGHT_FILED = 0;
        private const int LIGHT_CHAR = 1;
        private const int LIGHT_POKE = 2;
        private const int LIGHT_MAX = 3;

        private float[] _setlight_timer = new float[3];
        private float[] _setlight_timer_limit = new float[3];
        private float[] _start_lightIntensity = new float[3];
        private float[] _end_lightIntensity = new float[3];
        private bool[] _isRunningLight = new bool[3];

        private bool isSpBtlAruseus;
        public List<string> Debug_01_DebugLabel = new List<string>();
        public List<string> DebugSceneEventLabel = new List<string>();

        private const int FieldObjectEntityLength = 100;
        private const int FieldKinomiGrowEntityLength = 30;

        public List<FieldObjectEntity> _fieldObjectEntity = new List<FieldObjectEntity>(FieldObjectEntityLength);
        public List<FieldKinomiGrowEntity> _FieldKinomiGrowEntity = new List<FieldKinomiGrowEntity>(FieldKinomiGrowEntityLength);
        private List<AssetReqOpeRef> _AssetReqOpeList = new List<AssetReqOpeRef>();
        private List<LoadObjectData> _loadObjectList = new List<LoadObjectData>();
        private int _loadObjectIndex;
        private Transform _loadObjectParent;
        private bool _nowInstantiate;

        private const int _PoolLength = 100;

        private Dictionary<int, GameObject> _poolLoadObjects = new Dictionary<int, GameObject>(_PoolLength);

        public EvDataManager()
        {
            _isScriptLoad = true;
            _eventList = null;
            SetCloudScaleEnd();
            _eventListIndex = -1;
            _findAllLabel = new Dictionary<string, int[]>(10000);
            _msgOpenParam.TrainerName = new string[5];
            for (int i=0; i<_msgOpenParam.TrainerName.Length; i++)
                _msgOpenParam.TrainerName[i] = "";

            _se_datas = new PlaySeData[5];
            _voice_datas = new PlaySeData[5];
            _battleReturnData.EventListIndex = -1;
            _battleReturnHitObject = null;
            _worpEventData.Entity = null;
            _worpEventData.State = 0;
            _worpEventData.Time = 0.0f;
            for (int i=0; i<_talkTrinerIndex.Length; i++)
                _talkTrinerIndex[i] = -1;

            for (int i=0; i<_eyeEncountTarget.Length; i++)
                _eyeEncountTarget[i] = null;

            _cacheZoneID_SceneChange = ZoneID.UNKNOWN;
            _entityParamList = new EntityParam[EntityParamLength];
            FieldObjectMoveCodes = new List<FieldObjectMoveCode>(FieldObjectMoveCodesLength);
            PokemonCenter = new FieldPokemonCenter();
            PokemonCenter.Initialize();
            _tairyouHasseiMane = new TairyouHasseiPokeManager();
        }

        // TODO
        public void Destroy() { }

        // TODO
        public void SceneChangeRelease() { }

        // TODO
        public void CacheSceneChangeRelease() { }

        public bool UpdateStart()
        {
            Jump_InitScr();
            CreateWorpPoint();

            for (int i=0; i<FieldObjectMoveCodes.Count; i++)
            {
                var moveCode = FieldObjectMoveCodes[i];
                if (moveCode != null)
                {
                    if (moveCode.IsMissing())
                    {
                        FieldObjectMoveCodes[i] = null;
                    }
                    else
                    {
                        if (moveCode.IsNoneStart())
                            moveCode.MVCodeStart();
                    }
                }
            }

            FieldZoneChange(false);
            SceneStartGimmickEntity();
            _isScriptLoad = false;

            var mapInfo = GameManager.mapInfo[(int)PlayerWork.zoneID];
            if (!PlayerWork.IsFieldKuruKuruStart && mapInfo.KuruKuru)
            {
                _updateDelegate = Utils.PlayerGuruguru;

                var pos = EntityManager.activeFieldPlayer.transform.position;
                float height = Utils.GetGuruGuruHeight(PlayerWork.zoneID);

                EntityManager.activeFieldPlayer.isLanding = false;
                EntityManager.activeFieldPlayer.worldPosition = new Vector3(pos.x, height, pos.z);
                Instanse._dummyPlayer.transform.position = new Vector3(pos.x, 0.0f, pos.z);

                Sequencer.update += PlayerFall;

                Utils.PlayGuruguruSE(false);
                Sequencer.Start(Utils.PlayerGuruguruStop(0.0f, 0.0f, false, () => _updateDelegate = null));
            }

            if (!PlayerWork.IsFieldFallStart && UgFieldManager.isFallEnter && mapInfo.Fall)
            {
                var pos = EntityManager.activeFieldPlayer.transform.position;
                float height = Utils.GetGuruGuruHeight(PlayerWork.zoneID);

                EntityManager.activeFieldPlayer.isLanding = false;
                EntityManager.activeFieldPlayer.worldPosition = new Vector3(pos.x, height, pos.z);
                Instanse._dummyPlayer.transform.position = new Vector3(pos.x, 0.0f, pos.z);

                _ugFallSpdCurrent = 15.0f;

                Sequencer.update += PlayerFall;

                Sequencer.Start(Utils.PlayerFallStop(0.0f, false, () => _updateDelegate = null));
            }

            if (PlayerWork.IsFromUg)
            {
                PlayerWork.IsFromUg = false;
                FromUnderGround();
            }

            if (PlayerWork.IsToUg)
                PlayerWork.IsToUg = false;

            if (mapInfo != null)
            {
                PlayerWork.IsFieldKuruKuruStart = mapInfo.KuruKuru || ZoneWork.IsSecretBase(PlayerWork.zoneID);
                PlayerWork.IsFieldFallStart = mapInfo.Fall || ZoneWork.IsSecretBase(PlayerWork.zoneID);
            }

            _ugDiveSeq = 100;

            CallFieldWarpExitLabel();
            CloudScaleReset();

            if (!FieldManager.SealPrevFalg && _eventListIndex < 0 && _battleReturnData.EventListIndex < 0)
                _isFadeEventReturnInput = true;

            if (UnionRoomManager.Instance != null && UnionRoomManager.Instance.isBattle)
                UnionRoomManager.Instance.ReturnBattle();

            if (ColiseumRoomManager.Instance != null && ColiseumRoomManager.Instance.isBattle)
                ColiseumRoomManager.Instance.ReturnBattle();

            return true;
        }

        public void CallFieldWarpExitLabel()
        {
            if (JumpLabel(PlayerWork.FieldWorpLabel, null))
            {
                if (!string.IsNullOrEmpty(PlayerWork.FieldWorpLinkName))
                {
                    for (int i=0; i<EntityManager.fieldDoorObjects.Length; i++)
                    {
                        var door = EntityManager.fieldDoorObjects[i];
                        if (door.gameObject != null && door.entityEname == PlayerWork.FieldWorpLinkName)
                        {
                            _selectDoorObject = door;
                            break;
                        }
                    }
                }
            }

            PlayerWork.FieldWorpLabel = "";
            PlayerWork.FieldWorpLinkName = "";
        }

        public void FieldZoneChange(bool walk = true)
        {
            if (_cacheZoneID_SceneChange != PlayerWork.zoneID)
            {
                if (walk)
                    WalkInit();
                else
                    MapJumpInit();

                _tairyouHasseiMane.ZoneChange(walk);
                if (IsFirstInitializedAfterSaveDataLoad)
                {
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK0, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK1, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK2, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK3, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK4, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK5, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK6, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK7, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK8, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK9, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK10, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK11, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK12, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK13, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK14, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK15, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK16, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK17, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK18, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK19, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK20, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK21, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK22, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK23, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK24, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK25, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK26, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK27, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK28, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK29, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK30, 0);
                    FlagWork.SetWork(EvWork.WORK_INDEX.LOCALWORK31, 0);

                    for (EvWork.FLAG_INDEX i=0; i<=EvWork.FLAG_INDEX.FH_OBJ31; i++)
                        FlagWork.SetFlag(i, false);
                }

                IsFirstInitializedAfterSaveDataLoad = true;
                FlagWork.SetFlag(EvWork.FLAG_INDEX.FH_NECK_LOCK, false);
            }

            AzukariyaInitEventFlag = AzukariyaWork.IsExistOldmanZone() && AzukariyaWork.IsExistEgg();

            PlayHoneyTreeAnimation(PlayerWork.zoneID);

            if (_battleReturnData.EventListIndex > -1)
            {
                if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_BTL_RETURN_CALL_SP))
                    _pendingInitScripts = true;

                if (_battleReturnHitObject != null)
                {
                    var playerForward = _battleReturnHitObject.worldPosition - EntityManager.activeFieldPlayer.worldPosition;
                    EntityManager.activeFieldPlayer.SetYawAngleDirect(Quaternion.LookRotation(playerForward).eulerAngles.y);

                    if (!_battleReturnHitObject.EventParams.BattleReturnNotRotate)
                    {
                        var trainerForward = EntityManager.activeFieldPlayer.worldPosition - _battleReturnHitObject.worldPosition;
                        _battleReturnHitObject.SetYawAngleDirect(Quaternion.LookRotation(trainerForward).eulerAngles.y);
                    }
                }

                FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_BTL_RETURN_CALL_SP, false);
            }
            else
            {
                if (_eventListIndex < 0)
                {
                    SpLabel_Init(PlayerWork.zoneID);
                    SpLabel_Obj(PlayerWork.zoneID);
                    SpLabel_Flag(PlayerWork.zoneID);

                    if (!FieldManager.SealPrevFalg)
                    {
                        SpLabel_Scene(PlayerWork.zoneID);
                        _mistPlate.Setup(PlayerWork.zoneID);
                    }

                    if (AzukariyaInitEventFlag && AzukariyaWork.IsLoadedOldman())
                    {
                        AzukariyaWork.InitOldmanEvent();
                        UpdateEvdata(0.0f, true);
                        AzukariyaInitEventFlag = false;
                    }
                }
                else
                {
                    _pendingInitScripts = true;
                }
            }

            _cacheZoneID_SceneChange = ZoneID.UNKNOWN;
            _posEventLabelReserve = null;
            TvCommercials = null;
            TvCommercialsCurrentIndex = 0;
            ResetVanishFlagObject();

            if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_CYCLINGROAD))
            {
                if (!EntityManager.activeFieldPlayer.IsRideBicycle())
                    PlayerWork.SetFormBicycle();
            }
            else
            {
                if (!FieldManager.Instance.ZoneData.Bicycle && EntityManager.activeFieldPlayer.IsRideBicycle())
                    PlayerWork.SetFormNormal();
            }

            if (!walk)
            {
                if (EntityManager.activeFieldPlayer.IsRideBicycle())
                    EntityManager.activeFieldPlayer.SetRideBicycle(null);
                else if (EntityManager.activeFieldPlayer.IsSwim())
                    EntityManager.activeFieldPlayer.ChangeSwim(true);
                else
                    EntityManager.activeFieldPlayer.SetNormalForm(null);

                if (PlayerWork.IsZenmetuFlag)
                {
                    _battleReturnData.EventListIndex = -1;

                    if (PlayerWork.zoneID == ZoneID.T01R0201)
                        JumpLabel("ev_game_over_recover_myhome", null);
                    else if (UgFieldManager.Instance == null)
                        JumpLabel("ev_game_over_recover_pc", null);
                    else if (ZoneWork.IsSecretBase(PlayerWork.zoneID))
                        JumpLabel("ev_ug_0000", null);
                    else
                        JumpLabel("ev_ug_0010", null);
                }
            }

            _liftEntity = null;
            _tobariGymWallEntity = null;
            _nagisaGymGearEntity = null;
            _nomoseGymSwitchEntity = null;
            _eyePaintingEntity = null;
            _embankmentEntity = null;
            _isEqZoneWorp = false;
            _eqZoneWorpGrid = new Vector2Int(-1, -1);

            if (EntityManager.fieldEmbankment != null)
            {
                for (int i=0; i<EntityManager.fieldEmbankment.Length; i++)
                {
                    if (EntityManager.fieldEmbankment[i] != null)
                        EntityManager.fieldEmbankment[i].UpdateEmbankment();
                }
            }

            Btl_TrainerType1 = TrainerType.INVALID;
            Btl_TrainerType2 = TrainerType.INVALID;
            _toUgInvisibleObjects.Reset();
        }

        public void ResetVanishFlagObject()
        {
            foreach (var obj in _fieldObjectEntity)
            {
                if (obj != null)
                {
                    var flag = (EvWork.FLAG_INDEX)obj.EventParams.VanishFlagIndex;
                    if ((int)flag > -1 && flag != EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE && FlagWork.GetFlag(flag))
                    {
                        obj.SetActive(false);
                    }
                    else
                    {
                        if (!obj.EventParams.IsInvalidVanishActive)
                            obj.SetActive(true);
                    }
                }
            }
        }

        private void PendingInitScripts()
        {
            if (_pendingInitScripts)
            {
                SpLabel_Init(PlayerWork.zoneID);
                SpLabel_Obj(PlayerWork.zoneID);
                SpLabel_Flag(PlayerWork.zoneID);
                SpLabel_Scene(PlayerWork.zoneID);
                _mistPlate.Setup(PlayerWork.zoneID);
                _pendingInitScripts = false;
            }
        }

        private void WalkInit()
        {
            PlayerWork.WalkEncountCount = 0;
            ARRIVEDATA_SetArriveFlag(PlayerWork.zoneID);
            FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_KAIRIKI, false);
        }

        private void MapJumpInit()
        {
            if (_isInitFirstMap)
                FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_CYCLINGROAD, false);

            _isInitFirstMap = true;
            EvCmd__CAMERA_TARGET_HERO();
            PlayerWork.WalkEncountCount = 0;
            ARRIVEDATA_SetArriveFlag(PlayerWork.zoneID);

            for (int i=0; i<_se_datas.Length; i++)
            {
                _se_datas[i].AudioInstance = null;
                _se_datas[i].playEventId = 0;
                _se_datas[i].name = "";
            }

            for (int i=0; i<_voice_datas.Length; i++)
            {
                _se_datas[i].AudioInstance = null;
                _se_datas[i].playEventId = 0;
                _se_datas[i].name = "";
            }

            FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_KAIRIKI, false);
            FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_CAMERA_REVERSAL, false);
            FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.FLAG_STOP_EYE_ENCOUNT, false);
            SetCommandUseTime();
        }

        public bool m_Update(float time)
        {
            EntityMoveCodeCheck();
            FieldShip.Update(time);
            _lateUpdateMoveCode = false;

            if (UpdateEvdata(time))
                return true;

            if (_updateDelegate != null)
            {
                _updateDelegate.Invoke(time);
                if (_updateDelegate != null)
                    return true;
            }

            if (_isFadeEventReturnInput && _eventListIndex < 0 && _battleReturnData.EventListIndex < 0 && !Fader.isBusy)
            {
                if (Fader.fillPower <= 0.0f)
                {
                    PlayerInputActive(true);
                    _isFadeEventReturnInput = false;
                }
            }

            PendingInitScripts();

            if (CheckSceneChangeLabel())
                return true;

            if (CheckBattleReturnLabel())
                return true;

            if (CheckUpdateSPLabel())
                return true;

            if (Fader.isBusy)
                return true;

            HoneyWork.UpdateTime();
            KinomiWork.UpdateGrowTime();

            bool daycareEgg = AzukariyaWork.IsExistEgg();
            AzukariyaWork.CheckLayEgg();

            bool movedDaycareMan;
            bool hatching;
            if ((AzukariyaInitEventFlag || (!daycareEgg && AzukariyaWork.IsExistEgg())) &&
                AzukariyaWork.IsExistOldmanZone() &&
                AzukariyaWork.IsLoadedOldman())
            {
                AzukariyaWork.MoveOldmanEvent();
                movedDaycareMan = true;
                AzukariyaInitEventFlag = false;
                hatching = CheckPartyEggHatching();
            }
            else
            {
                movedDaycareMan = false;
                hatching = CheckPartyEggHatching();
            }

            if (hatching)
            {
                EntityManager.activeFieldPlayer.StopCrossInputAndBicycle();
                JumpLabel("ev_egg_hatching", null);
                return true;
            }

            if (movedDaycareMan)
                return true;

            if (ScriptStartCheck(time))
                return true;

            var playerPos = EntityManager.activeFieldPlayer.worldPosition;
            var playerGridPos = EntityManager.activeFieldPlayer.gridPosition;

            for (int i=0; i<FieldObjectMoveCodes.Count; i++)
            {
                var moveCode = FieldObjectMoveCodes[i];
                if (moveCode != null && !moveCode.IsMissing())
                {
                    if (moveCode.IsNoneStart())
                        moveCode.MVCodeStart();

                    moveCode.MoveCodeUpdate(time, ref playerPos, ref playerGridPos, EntityManager.activeFieldPlayer.IsRun());
                }
            }

            _tairyouHasseiMane.Update(time);
            _lateUpdateMoveCode = true;
            return false;
        }

        public bool m_LateUpdate(float time)
        {
            if (_lateUpdateMoveCode)
            {
                for (int i=0; i<FieldObjectMoveCodes.Count; i++)
                {
                    var moveCode = FieldObjectMoveCodes[i];
                    if (moveCode != null && !moveCode.IsMissing())
                        moveCode.MoveCodeLateUpdate(time);
                }
            }

            if (_isEqZoneWorp && EntityManager.activeFieldPlayer.gridPosition != _eqZoneWorpGrid)
                _isEqZoneWorp = false;

            if (_eventListIndex > -1 || _battleReturnData.EventListIndex > -1)
                return false;

            if (EntityManager.activeFieldPlayer == null)
                return false;

            var playerPos = EntityManager.activeFieldPlayer.worldPosition;
            var playerVec = EntityManager.activeFieldPlayer.InputMoveVector;

            for (int i=0; i<EntityManager.fieldTobariGymWalls.Length; i++)
            {
                var wall = EntityManager.fieldTobariGymWalls[i];
                if (wall != null && wall.CheckHit(playerPos, playerVec))
                {
                    _tobariGymWallEntity = wall;
                    return true;
                }
            }

            return false;
        }

        private bool FindLabel(string label)
        {
            return _findAllLabel.ContainsKey(label);
        }

        private bool CheckSceneChangeLabel()
        {
            bool result = JumpLabel(_callLabel_SceneChange, null);
            _callLabel_SceneChange = "";
            return result;
        }

        // TODO
        private void SetBattleReturn() { }

        private bool CheckBattleReturnLabel()
        {
            if (_battleReturnData.EventListIndex == -1)
                return false;

            if (_eventListIndex == -1)
                SetCloudScaleStart();

            _eventListIndex = _battleReturnData.EventListIndex;
            _eventList­[_eventListIndex].LabelIndex = _battleReturnData.LabelIndex;
            _eventList­[_eventListIndex].CommandIndex = _battleReturnData.CommandIndex;

            var eventItem = _eventList­[_eventListIndex];
            _battleReturnData.EventListIndex = -1;

            for (int i=0; i<FieldObjectMoveCodes.Count; i++)
            {
                var moveCode = FieldObjectMoveCodes[i];
                if (moveCode != null && !moveCode.IsMissing())
                {
                    moveCode.MVCodeStop();
                }
            }

            PlayerInputActive(false);

            if (!_isBattleTowerBtl)
            {
                FieldManager.Instance.SetAutoSaveState(FieldManager.AutoSaveState.None);
            }
            else
            {
                _isBattleTowerWin = FlagWork.GetWork(EvWork.WORK_INDEX.SCWK_ANSWER) == _WORK_TRUE;
                if (_isBattleTowerWin)
                    EvCmd_PLAY_REPORT_BTLTOWER_WIN();

                if (BattleMatchingWork.pokemonParams != null)
                {
                    var mode = BtlTowerWork.GetMode();
                    var rank = (uint)BtlTowerWork.GetRank(mode);

                    var monsnoList = new List<uint>();
                    var formnoList = new List<uint>();

                    for (int i=0; i<BattleMatchingWork.orderIndexList.Length; i++)
                    {
                        var mon = BattleMatchingWork.pokemonParams[BattleMatchingWork.orderIndexList[i]];
                        if (mon != null)
                        {
                            monsnoList.Add((uint)mon.GetMonsNo());
                            formnoList.Add(mon.GetFormNo());
                        }
                    }

                    bool master = mode == 2 || mode == 3;
                    bool single = mode == 0 || mode == 2;

                    if (single)
                        PlayReportManager.SaveReportLog_TowerSingle(rank, master ? 1u : 0u, monsnoList.ToArray(), formnoList.ToArray(), (uint)BattleMatchingWork.orderIndexList.Length);
                    else
                        PlayReportManager.SaveReportLog_TowerDouble(rank, master ? 1u : 0u, monsnoList.ToArray(), formnoList.ToArray(), (uint)BattleMatchingWork.orderIndexList.Length);
                }
            }

            _isBattleTowerBtl = false;
            _battleReturnHitObject = null;
            return true;
        }

        private bool CheckUpdateSPLabel()
        {
            bool result = JumpLabel(_callLabel_UpdateSP, null);
            _callLabel_UpdateSP = "";
            return result;
        }

        // TODO
        private bool CheckSafariEvent() { return false; }

        // TODO
        public void SetSafariEndEventFromBattle(BtlResult btlResult) { }

        // TODO
        public void RetireSafari() { }

        public void SetSafariScopeEvent()
        {
        	this._callLabel_SceneChange = _StringLiteral_9186;
        }

        public void SetSafariScopeEndEvent()
        {
        	this._callLabel_SceneChange = _StringLiteral_9187;
        }

        public void SetNagisaScopeEvent()
        {
        	this._callLabel_SceneChange = _StringLiteral_9188;
        }

        public void SetNagisaScopeEndEvent()
        {
        	this._callLabel_SceneChange = _StringLiteral_9189;
        }

        // TODO
        public void UpdatePartyEggHatchingCount(int step) { }

        // TODO
        private int GetPartyEggHatchingValue(int step) { return 0; }

        // TODO
        private bool CheckPartyEggHatching() { return false; }

        // TODO
        private int CheckPartyEggHatchingCount() { return 0; }

        // TODO
        private void EggHatchingEvent() { }

        // TODO
        private void UpdateWait(float time) { }

        // TODO
        public void OnOpenMenu() { }

        // TODO
        public void OnCloseMenu() { }

        public bool IsRunningEvent()
        {
        	if (-1 < this._eventListIndex) {
        	  return true;
        	}
        	return ~this._battleReturnData >> 0x1f;
        }

        public bool CheckPosEvent(out Vector3 outWorldPos, FieldPlayerEntity player)
        {
            outWorldPos = Vector3.zero;

            if (_eventListIndex >= 0)
                return false;

            if (_battleReturnData.EventListIndex >= 0)
                return false;

            if (PlayerWork.IsToUg)
                return false;

            if (PlayerWork.IsFromUg)
                return false;

            if (_posEventLabelReserve != null)
                return false;

            if (_eventEndPosition == FieldObjectEntity.PositionToGrid(player.worldPosition + player.moveVector))
                return false;

            _eventEndPosition = Vector2Int.zero;

            var entityParam = FieldGridCollision.CheckGridEventMoveEntity(out outWorldPos, player);
            if (entityParam != null)
            {
                PlayerInputActive(false, false);
                _heroMoveGridCenterFrontDir = SetupHeroMoveGridCenterFrontDir(entityParam.StopGridArea, FieldObjectEntity.PositionToGrid(outWorldPos), player.oldGridPosition);
                _posEventLabelReserve = entityParam.ContactLabel;
                return true;
            }

            return false;
        }

        // TODO
        public EntityParam GetPosEventFromGrid(Vector2Int gridPos) { return null; }

        // TODO
        private bool IsPosEventOverWarp(ref Vector3 pos) { return false; }

        private void PlayerInputActive(bool active, bool animation = true)
        {
            PlayerWork.isPlayerInputActive = active;

            if (active)
            {
                EntityManager.activeFieldPlayer.EvEntityCmd.ScritpStopStateEnd();
            }
            else
            {
                EntityManager.activeFieldPlayer.EvEntityCmd.ScritpStopState();
                EntityManager.activeFieldPlayer.StopBicycleDecelerate();

                if (animation)
                    EntityManager.activeFieldPlayer.PlayIdle();
            }
        }

        private void SetEventListIndex(int idx)
        {
        	if (idx == -1) {
        	  SetCloudScaleEnd();
        	  this._eventListIndex = 0xffffffff;
        	}
        	if (this._eventListIndex != -1) {
        	  this._eventListIndex = idx;
        	}
        	SetCloudScaleStart();
        	this._eventListIndex = idx;
        }

        private void CloudScaleReset()
        {
            _cloudTime = _const_cloudTime;
            EnvironmentController.global.callback -= EnvironmentControllerCallBack;
        }

        private void SetCloudScaleStart()
        {
            if (EnvironmentController.global == null)
                return;

            _cloudSpeed = -1.0f;

            EnvironmentController.global.callback -= EnvironmentControllerCallBack;
            EnvironmentController.global.callback += EnvironmentControllerCallBack;
        }

        private void SetCloudScaleEnd()
        {
            if (EnvironmentController.global == null)
                return;

            _cloudSpeed = 1.0f;

            EnvironmentController.global.callback -= EnvironmentControllerCallBack;
            EnvironmentController.global.callback += EnvironmentControllerCallBack;
        }

        private void EnvironmentControllerCallBack(EnvironmentController controller, float deltaTime)
        {
            _cloudTime += _cloudSpeed * deltaTime;

            float scale;

            if (_cloudTime <= 0.0f)
            {
                _cloudTime = 0.0f;
                scale = 0.0f;
            }
            else if (_cloudTime >= _const_cloudTime)
            {
                _cloudTime = _const_cloudTime;
                EnvironmentController.global.callback -= EnvironmentControllerCallBack;
                scale = 1.0f;
            }
            else
            {
                scale = _cloudTime / _const_cloudTime;
            }

            controller._CloudShadowScale = scale * controller.latestParameters.CloudShadowScale;
        }

        public bool JumpLabel(string label, [Optional] EventEndDelegate callback)
        {
            if (string.IsNullOrEmpty(label) || !FindLabel(label))
                return false;

            int nextEventListIndex = _findAllLabel[label][0];

            if (nextEventListIndex == -1)
                SetCloudScaleEnd();
            else if (_eventListIndex == -1)
                SetCloudScaleStart();

            _eventListIndex = nextEventListIndex;

            _eventList[_eventListIndex].LabelIndex = _findAllLabel[label][1];
            _eventList[_eventListIndex].CommandIndex = 0;

            XMenuTop.CloseForce();
            BoxWindow.CloseForce();

            _eventEndDelegate += callback;
            return true;
        }

        public bool CallLabel(string label)
        {
            if (string.IsNullOrEmpty(label) || !FindLabel(label))
                return false;

            EvCallData call;
            call.EventListIndex = _eventListIndex;
            call.LabelIndex = _eventList[_eventListIndex].LabelIndex;
            call.CommandIndex = _eventList[_eventListIndex].CommandIndex + 1;
            _callQueue.Push(call);

            int nextEventListIndex = _findAllLabel[label][0];

            if (nextEventListIndex == -1)
                SetCloudScaleEnd();
            else if (_eventListIndex == -1)
                SetCloudScaleStart();

            _eventListIndex = nextEventListIndex;

            _eventList[_eventListIndex].LabelIndex = _findAllLabel[label][1];
            _eventList[_eventListIndex].CommandIndex = 0;
            return true;
        }

        public bool ReturnEvData()
        {
            if (_callQueue.Count <= 0)
                return false;

            EvCallData popped = _callQueue.Pop();

            if (popped.EventListIndex == -1)
                SetCloudScaleEnd();
            else if (_eventListIndex == -1)
                SetCloudScaleStart();

            _eventListIndex = popped.EventListIndex;

            _eventList[popped.EventListIndex].LabelIndex = popped.LabelIndex;
            _eventList[popped.EventListIndex].CommandIndex = popped.CommandIndex;
            return true;
        }

        // TODO
        private FieldCharacterEntity GetFieldCharacterEntity(string id) { return null; }

        private FieldObjectEntity Find_fieldObjectEntity(string id)
        {
            if (id == "HERO")
                return EntityManager.activeFieldPlayer;

            foreach (var entity in _fieldObjectEntity)
            {
                if (entity != null && entity.gameObject.name == id)
                    return entity;
            }

            return null;
        }

        // TODO
        public FieldObjectEntity GetFieldObject(string id) { return null; }

        // TODO
        private FieldObjectEntity GetFieldObject(int id) { return null; }

        // TODO
        public FieldEventEntity GetFieldEventEntity(string id) { return null; }

        private bool IsMoveEnd(string id = "")
        {
            if (!string.IsNullOrEmpty(id))
            {
                if (id == "HERO" && EntityManager.activeFieldPlayer.gameObject.activeInHierarchy)
                    return EntityManager.activeFieldPlayer.EvEntityCmd.IsScriptMoveEnd();

                for (int i=0; i<EntityManager.fieldObjects.Length; i++)
                {
                    var entity = EntityManager.fieldObjects[i];
                    if (entity != null && entity.gameObject != null && entity.gameObject.activeInHierarchy)
                    {
                        if (entity.gameObject.name == id)
                            return !entity.EvEntityCmd.IsScriptMoveEnd(); // BUG: Inverted?
                    }
                }

                return true;
            }
            else
            {
                if (EntityManager.activeFieldPlayer.gameObject.activeInHierarchy &&
                    !EntityManager.activeFieldPlayer.EvEntityCmd.IsScriptMoveEnd())
                    return false;

                for (int i=0; i<EntityManager.fieldObjects.Length; i++)
                {
                    var entity = EntityManager.fieldObjects[i];
                    if (entity != null && entity.gameObject != null && entity.gameObject.activeInHierarchy)
                    {
                        if (!entity.EvEntityCmd.IsScriptMoveEnd())
                            return false;
                    }
                }

                return true;
            }
        }

        private bool ScriptStartCheck(float time)
        {
            if (EntityManager.activeFieldPlayer == null)
                return false;

            if (PlayerWork.Telescope ||
                PlayerWork.IsToUg ||
                PlayerWork.IsFromUg)
                return false;

            bool pushedA = FieldInput.PushA() && !FieldPoketch.IsControlPoketch();
            bool inputActive = PlayerWork.isPlayerInputActive;

            if (CheckSafariEvent())
                return true;

            if (_posEventLabelReserve != null)
            {
                StartAdjustHeroPos(time, _posEventLabelReserve);
                _posEventLabelReserve = null;
                return true;
            }

            if (_tobariGymWallEntity != null)
            {
                JumpLabel(_tobariGymWallEntity.GymWallPushEventLabel, null);
                return true;
            }

            for (int i = 0; i < _fieldObjectEntity.Count; i++)
            {
                var entity = _fieldObjectEntity[i];
                if (entity != null)
                {
                    entity.EventParams.isTalkHit = false;
                    if (!entity.EventParams.IsEventRunning)
                        entity.EventParams.isTalkHit = CanContact2(entity, EntityManager.activeFieldPlayer.worldPosition);
                }
            }

            float angle = 999.0f;
            int idx = -1;
            for (int i = 0; i < _fieldObjectEntity.Count; i++)
            {
                var entity = _fieldObjectEntity[i];
                if (entity != null && entity.EventParams.isTalkHit && entity.EventParams.TalkAngle < angle)
                {
                    angle = entity.EventParams.TalkAngle;
                    idx = i;
                }
            }

            if (idx != -1)
            {
                var eventParam = _fieldObjectEntity[idx].EventParams;
                string label;

                if (pushedA && inputActive)
                {
                    if (UIManager.IsFieldOpenMenu())
                        return false;

                    if (string.IsNullOrEmpty(eventParam.TalkLabel))
                        label = eventParam.ContactLabel;
                    else
                        label = eventParam.TalkLabel;

                    var charaEntity = _fieldObjectEntity[idx] as FieldCharacterEntity;
                    if (charaEntity != null)
                    {
                        _talkTrinerIndex[0] = -1;
                        var trainerID = charaEntity.EventParams.TrainerID;
                        if (trainerID != TrainerID.NONE && trainerID != TrainerID.MAX)
                            _talkTrinerIndex[0] = (int)trainerID;
                    }

                    OnTalkStartCallBack?.Invoke(eventParam);

                    _hit_position.x = _fieldObjectEntity[idx].worldPosition.x;
                    _hit_position.z = _fieldObjectEntity[idx].worldPosition.z;
                }
                else
                {
                    label = eventParam.ContactLabel;
                }

                var pokemonEntity = _fieldObjectEntity[idx] as FieldPokemonEntity;
                if (pokemonEntity == null || (FieldManager.fwMng?.GetPartnerPokeController()?.IsEventTalkOK(pokemonEntity) ?? true))
                {
                    if (RunObjectEvent(idx, _fieldObjectEntity[idx], label))
                        return true;
                }
            }

            if (WarpListCheck())
                return true;

            if (_doorEntity != null && !_warpList.Contains(_doorEntity) && WarpHit(_doorEntity))
                return true;

            if (_liftEntity != null && IsLiftHit(_liftEntity))
                return true;

            if (_nagisaGymGearEntity != null && IsNagisaGymGearHit(_nagisaGymGearEntity))
                return true;

            if (_nomoseGymSwitchEntity != null && IsNomoseGymSwitchHit(_nomoseGymSwitchEntity))
                return true;

            if (_eyePaintingEntity != null && IsWorpHit(_eyePaintingEntity))
                _eyePaintingEntity.ChangeEyePainting();

            if (_embankmentEntity != null && IsEmbankmentHit(_embankmentEntity))
                return true;

            return false;
        }

        // TODO
        public Vector3 CalcContactCheckPos() { return Vector3.zero; }

        public bool CanContact(FieldObjectEntity obj, Vector3 playerpos)
        {
            return CanContact2(obj, playerpos);
        }

        public bool CanContact2(FieldObjectEntity obj, Vector3 playerpos)
        {
            var player = EntityManager.activeFieldPlayer;

            if (obj == null)
                return false;

            if (player == obj)
                return false;

            if (!obj.gameObject.activeInHierarchy)
                return false;

            var eventParams = obj.EventParams;
            if (eventParams.ContactLabel == "" && eventParams.TalkLabel == "")
                return false;

            var vanishFlag = (EvWork.FLAG_INDEX)eventParams.VanishFlagIndex;
            if ((int)vanishFlag > -1 && vanishFlag != EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE && FlagWork.GetFlag(vanishFlag))
                return false;

            var workIndex = eventParams.WorkIndex;
            if (workIndex != EvWork.WORK_INDEX.SCWK_WK_SAVE_SIZE && FlagWork.GetWork(workIndex) != eventParams.WorkValue)
                return false;

            if (eventParams.Rockclimb && !player.CheckRockClimbing(obj))
                return false;

            if (!eventParams.HeightIgnore)
            {
                var isSwim = player.IsSwim();
                var playerHeight = isSwim ? (playerpos.y - 0.6f) : playerpos.y;
                var threshold = (isSwim || eventParams.Kairiki) ? 0.6f : 0.3f;

                if (threshold < Math.Abs(playerHeight - obj.Height))
                    return false;
            }

            if (eventParams.IsContactCenter && IsHit(playerpos, obj.worldPosition, eventParams.ContactSize, true))
                return true;

            var playerPos2D = new Vector2(playerpos.x, playerpos.z);
            var objPos = new Vector2(obj.worldPosition.x, obj.worldPosition.z);
            var objCorner = objPos + eventParams.TalkSegment;

            // Check that the player is within 10 tiles (circle) of two of the corners of the tile of the obj
            if (new Vector2(objPos.x - playerPos2D.x, objPos.y - playerPos2D.y).sqrMagnitude > 100.0f &&
                new Vector2(objCorner.x - playerPos2D.x, objCorner.y - playerPos2D.y).sqrMagnitude > 100.0f)
                return false;

            float distance;
            int hitstatus;
            SegmentHit(ref objPos, ref objCorner, ref playerPos2D, eventParams.TalkRange, out _, out _, out distance, out hitstatus);

            if (hitstatus == 0)
            {
                if (!eventParams.Rockclimb)
                    return false;

                var rockClimbPos = player.CalcRockClimbingAnotherTalkPosition(obj);
                var rockClimbPos2D = new Vector2(rockClimbPos.x, rockClimbPos.z);
                var rockClimbCorner = rockClimbPos2D + eventParams.TalkSegment;

                SegmentHit(ref rockClimbPos2D, ref rockClimbCorner, ref playerPos2D, eventParams.TalkRange, out _, out _, out distance, out hitstatus);

                Vector2 talkAnglePos;
                switch (hitstatus)
                {
                    case 0:
                        return false;

                    case 1:
                        var normalSize = (new Vector2(rockClimbCorner.x, rockClimbCorner.y) - rockClimbPos2D).normalized;
                        talkAnglePos = playerPos2D - (new Vector2(-normalSize.y, normalSize.x) * distance);
                        break;

                    case 2:
                        talkAnglePos = rockClimbPos2D;
                        break;

                    default:
                        talkAnglePos = rockClimbCorner;
                        break;
                }

                var diff = new Vector2(talkAnglePos.x - playerPos2D.x, talkAnglePos.y - playerPos2D.y);
                var diffAngle = PlayerDiffAngle(ref diff);

                if (diffAngle <= DataManager.GetFieldCommonParam(ParamIndx.TalkAngleLimit))
                {
                    eventParams.TalkAngle = diffAngle;
                    _hit_position.x = talkAnglePos.x;
                    _hit_position.y = obj.Height;
                    _hit_position.z = talkAnglePos.y;
                    return true;
                }
                else
                {
                    eventParams.TalkAngle = -1.0f;
                    return false;
                }
            }
            else
            {
                Vector2 talkAnglePos;
                switch (hitstatus)
                {
                    case 1:
                        var normalSize = (new Vector2(objCorner.x, objCorner.y) - objPos).normalized;
                        talkAnglePos = playerPos2D - (new Vector2(-normalSize.y, normalSize.x) * distance);
                        break;

                    case 2:
                    default:
                        talkAnglePos = objPos;
                        break;
                }

                if (!IsTalkBitMask(ref playerPos2D, ref talkAnglePos, eventParams.TalkBit))
                    return false;

                var diff = new Vector2(talkAnglePos.x - playerPos2D.x, talkAnglePos.y - playerPos2D.y);
                var diffAngle = PlayerDiffAngle(ref diff);

                if (diffAngle <= DataManager.GetFieldCommonParam(ParamIndx.TalkAngleLimit))
                {
                    eventParams.TalkAngle = diffAngle;
                    _hit_position.x = talkAnglePos.x;
                    _hit_position.y = obj.Height;
                    _hit_position.z = talkAnglePos.y;
                    return true;
                }
                else
                {
                    eventParams.TalkAngle = -1.0f;
                    return false;
                }
            }
        }

        public void ClearPlayerMoveVector()
        {
            EntityManager.activeFieldPlayer.moveVector = Vector3.zero;
        }

        // TODO
        public bool RunObjectEvent(int idx, FieldObjectEntity obj, string label) { return false; }

        // TODO
        private bool IsTalkBitMask(ref Vector2 target, ref Vector2 talkpont, byte mask) { return false; }

        // TODO
        private bool IsHit(Vector3 traA, Vector3 traB, Vector2 rangB, bool center) { return false; }

        // TODO
        private float PlayerDiffAngle(ref Vector2 diff) { return 0.0f; }

        // TODO
        private bool IsCircleHit(ref Vector2 v1, ref Vector2 v2, float range, out float outAngle)
        {
            outAngle = 0.0f;
            return false;
        }

        // TODO
        private bool IsCircleHit(ref Vector2 v1, ref Vector2 v2, float range) { return false; }

        // TODO
        private bool WarpListCheck()
        {
            if (PlayerWork.IsToUg)
                return false;
            
            if (PlayerWork.IsFromUg)
                return false;

            var doors = EntityManager.fieldDoorObjects;
            for (int i=0; i<doors.Length; i++)
            {
                var door = doors[i];

                if (door != null && door.doorEnable)
                {
                    if (door.EventParams.WorkValue > -1)
                    {
                        var flagIndex = _warpData.Data[door.EventParams.WorkValue].FlagIndex;
                        if (flagIndex != EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE && FlagWork.GetFlag(flagIndex))
                            continue;
                    }

                    // TODO: Collision math
                    if (true)
                    {
                        if (WarpSegmentHitCheck(door, out Vector3 resultPosition, out float subAngle, out float lineDist, DataManager.GetFieldCommonParam(ParamIndx.WarpSegmentRadius)))
                        {
                            var player = EntityManager.activeFieldPlayer;
                            if (player.InputMoveVector.z != 0.0f || player.InputMoveVector.z != 0.0f)
                            {
                                // TODO
                            }
                        }
                    }
                }
            }

            // TODO
            return false;
        }

        private void EvCmdCmpMain(EvWork.WORK_INDEX r1, EvWork.WORK_INDEX r2)
        {
            int workValue1 = FlagWork.GetWork(r1);
            int workValue2 = FlagWork.GetWork(r2);

            if (workValue1 < workValue2)
                _cmp_flag = CmpResult.MINUS;
            else if (workValue1 == workValue2)
                _cmp_flag = CmpResult.EQUAL;

            _cmp_flag = CmpResult.PLUS; // BUG: Will always be returning work1 as greater
        }

        public void OnEventEnter(float deltaTime, FieldEventEntity eventEntity)
        {
            if (EntityManager.activeFieldPlayer.currentSequence != FieldPlayerEntity.SequenceID.Active)
                return;

            if (_liftEntity == null)
                _liftEntity = eventEntity as FieldEventLiftEntity;

            _nagisaGymGearEntity = eventEntity as FieldNagisaGymGearEntity;
            _nomoseGymSwitchEntity = eventEntity as FieldNomoseGymSwitchEntity;
            _eyePaintingEntity = eventEntity as FieldEyePaintingEntity;
            _embankmentEntity = eventEntity as FieldEmbankmentEntity;
            _doorEntity = eventEntity as FieldEventDoorEntity;
        }

        public void OnEventStay(float deltaTime, FieldEventEntity eventEntity)
        {
            if (EntityManager.activeFieldPlayer.currentSequence != FieldPlayerEntity.SequenceID.Active)
                return;

            if (_liftEntity == null)
                _liftEntity = eventEntity as FieldEventLiftEntity;

            _nagisaGymGearEntity = eventEntity as FieldNagisaGymGearEntity;
            _nomoseGymSwitchEntity = eventEntity as FieldNomoseGymSwitchEntity;
            _eyePaintingEntity = eventEntity as FieldEyePaintingEntity;
            _embankmentEntity = eventEntity as FieldEmbankmentEntity;
            _doorEntity = eventEntity as FieldEventDoorEntity;
        }

        public void OnEventLeave(float deltaTime, FieldEventEntity eventEntity)
        {
            _doorEntity = null;
            _liftEntity = null;
            _nagisaGymGearEntity = null;
            _nomoseGymSwitchEntity = null;
            _eyePaintingEntity = null;
            _embankmentEntity = null;
        }

        public void ResetGimmickEntityRef()
        {
            _liftEntity = null;
            _tobariGymWallEntity = null;
            _nagisaGymGearEntity = null;
            _nomoseGymSwitchEntity = null;
            _eyePaintingEntity = null;
            _embankmentEntity = null;
        }

        // TODO
        public bool IsDowsingEnable(FieldObjectEntity entity) { return false; }

        // TODO
        private bool WarpHit(FieldEventDoorEntity eventEntity) { return false; }

        private void CorrectionEventEntityWait(float deltatime)
        {
            if (EntityManager.activeFieldPlayer.IsEventCorrectionMoveEnd())
            {
                EntityManager.activeFieldPlayer.nextSequence = FieldPlayerEntity.SequenceID.Active;
                PlayerWork.isPlayerInputActive = false;
                _updateDelegate = WarpUpdate;
                WarpUpdate(deltatime);
            }
        }

        private bool CorrectionDirCheck(FieldEventEntity eventEntity)
        {
            return true;
        }

        private void CorrectionDirSegment(FieldEventEntity eventEntity, out Vector2 segStart, out Vector2 segEnd)
        {
            segStart.x = eventEntity.worldPosition.x - 0.5f - eventEntity.offset.x;
            segStart.y = eventEntity.worldPosition.z - 0.5f + eventEntity.offset.y;
            segEnd.x = eventEntity.worldPosition.x + 0.5f - eventEntity.offset.x - eventEntity.size.x;
            segEnd.y = eventEntity.worldPosition.z + 0.5f + eventEntity.offset.y - eventEntity.size.y;
        }

        private float CorrectionDirAngle(FieldEventEntity eventEntity)
        {
            float[] angles = { 180.0f, 0.0f, 90.0f, 270.0f };

            var doorEntity = eventEntity as FieldEventDoorEntity;
            if (doorEntity != null)
                return angles[(int)doorEntity.startVectol];
            else
                return angles[(int)eventEntity.correctionDir];
        }

        // TODO
        private bool IsLiftHit(FieldEventLiftEntity liftEntity) { return false; }

        // TODO
        private bool IsNagisaGymGearHit(FieldNagisaGymGearEntity gymGearEntity) { return false; }

        // TODO
        private bool IsNomoseGymSwitchHit(FieldNomoseGymSwitchEntity gymSwitchEntity) { return false; }

        // TODO
        private bool IsEyePaintingHit(FieldEyePaintingEntity eyePaintingEntity) { return false; }

        // TODO
        private bool IsEmbankmentHit(FieldEmbankmentEntity embankmentEntity) { return false; }

        // TODO
        private bool IsEventHit(FieldEventEntity eventEntity) { return false; }

        private bool IsWorpHit(FieldEventEntity eventEntity)
        {
            if (eventEntity == null)
                return false;

            if (!eventEntity.gameObject.activeInHierarchy)
                return false;

            var vanishFlag = (EvWork.FLAG_INDEX)eventEntity.EventParams.VanishFlagIndex;
            if ((int)vanishFlag > -1 && vanishFlag != EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE && FlagWork.GetFlag(vanishFlag))
                return false;

            var workIndex = eventEntity.EventParams.WorkIndex;
            if (workIndex == EvWork.WORK_INDEX.SCWK_WK_SAVE_SIZE || FlagWork.GetWork(workIndex) == eventEntity.EventParams.WorkValue)
                return true;

            return false;
        }

        private void WarpUpdate(float time)
        {
            if (_worpEventData.Entity.callLabel == FieldDoor.CallLabel.none)
            {
                Cmd_ObjPauseAll();
                WarpUpdateEnd();
            }
            else
            {
                if (_worpEventData.State != 0)
                    return;

                Cmd_ObjPauseAll();

                if (JumpLabel(_worpEventData.Entity.callLabel.ToString(), WarpUpdateEnd))
                {
                    _updateDelegate = null;
                    _worpEventData.State++;
                }
                else
                {
                    WarpUpdateEnd();
                }
            }
        }

        // TODO
        private void WarpUpdateEnd()
        {
            PlayerWork.FieldWorpLabel = _worpEventData.Entity.exitLabel == FieldDoor.ExitLabel.none ? "" : _worpEventData.Entity.exitLabel.ToString();
            PlayerWork.FieldWorpLinkName = _worpEventData.Entity.connectionName;
        }

        // TODO
        private void EqualZoneWarp(float time) { }

        // TODO
        public void SetWork(int index, int val) { }

        // TODO
        public void SetWork(EvWork.WORK_INDEX index, int val) { }

        // TODO
        public int GetWork(int index) { return 0; }

        // TODO
        public int GetWork(EvWork.WORK_INDEX index) { return 0; }

        // TODO
        public EvWork.FLAG_INDEX SetFlag(int index, bool val) { return EvWork.FLAG_INDEX.FH_01; }

        // TODO
        public void SetFlag(EvWork.FLAG_INDEX index, bool val) { }

        // TODO
        public int GetFlag(EvWork.FLAG_INDEX index) { return 0; }

        // TODO
        public int GetFlag(int index) { return 0; }

        // NOTE: This one doesn't seem to be used, use the other SetSysFlag in this class
        public void SetSysFlag(EvWork.SYSFLAG_INDEX index, bool val)
        {
            FlagWork.SetSysFlag(index, val);
        }

        public void SetSysFlag(int index, bool val)
        {
            FlagWork.SetSysFlag((EvWork.SYSFLAG_INDEX)index, val);

            byte badgeCount = 0;
            if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.BADGE_ID_C03)) badgeCount++;
            if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.BADGE_ID_C04)) badgeCount++;
            if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.BADGE_ID_C07)) badgeCount++;
            if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.BADGE_ID_C06)) badgeCount++;
            if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.BADGE_ID_C05)) badgeCount++;
            if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.BADGE_ID_C02)) badgeCount++;
            if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.BADGE_ID_C09)) badgeCount++;
            if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.BADGE_ID_C08)) badgeCount++;
            PlayerWork.badge = badgeCount;
        }

        public int GetSysFlag(EvWork.SYSFLAG_INDEX index)
        {
            return FlagWork.GetSysFlag(index) ? 1 : 0;
        }

        public int GetSysFlag(int index)
        {
            return FlagWork.GetSysFlag((EvWork.SYSFLAG_INDEX)index) ? 1 : 0;
        }

        public int GetArgInt(EvData.Aregment arg)
        {
            switch (arg.argType)
            {
                case EvData.ArgType.Work:
                    return PlayerWork.GetInt((EvWork.WORK_INDEX)arg.data);

                case EvData.ArgType.Float:
                    return (int)BitConverter.ToSingle(BitConverter.GetBytes(arg.data), 0);

                default:
                    return 0;
            }
        }

        public float GetArgFloat(EvData.Aregment arg)
        {
            switch (arg.argType)
            {
                case EvData.ArgType.Work:
                    return PlayerWork.GetInt((EvWork.WORK_INDEX)arg.data);

                case EvData.ArgType.Float:
                    return BitConverter.ToSingle(BitConverter.GetBytes(arg.data), 0);

                default:
                    return 0;
            }
        }

        public string GetArgString(EvScriptData ev, EvData.Aregment arg)
        {
            if (arg.argType == EvData.ArgType.String)
                return ev.EvData.GetString(arg.data);
            else
                return "";
        }

        public int GetBadgeCount()
        {
        	var uVar1 = FlagWork.GetSysFlag(0x81);
        	var uVar2 = FlagWork.GetSysFlag(0x7c);
        	var uVar3 = FlagWork.GetSysFlag(0x7d);
        	var uVar4 = FlagWork.GetSysFlag(0x80);
        	var uVar5 = FlagWork.GetSysFlag(0x7f);
        	var uVar6 = FlagWork.GetSysFlag(0x7e);
        	var uVar7 = FlagWork.GetSysFlag(0x83);
        	var uVar8 = FlagWork.GetSysFlag(0x82);
        	return (uVar2 & 1) + (uVar1 & 1) + (uVar3 & 1) + (uVar4 & 1) + (uVar5 & 1) + (uVar6 & 1) +
        	       (uVar7 & 1) + (uVar8 & 1);
        	return 0;
        }

        // TODO
        private string GetTrainerMsg(int tr_id, int kind) { return null; }

        // TODO
        private string GetTrainerRevengeMsg(int tr_id, int kind) { return null; }

        private bool PlaySe(string name)
        {
            int freeIndex = 0;
            for (int i=0; i<_se_datas.Length; i++)
            {
                if (string.IsNullOrEmpty(_se_datas[i].name))
                {
                    freeIndex = i;
                    break;
                }
            }

            if (freeIndex >= _se_datas.Length)
                freeIndex = 0;

            string upperName = name.ToUpper();
            uint eventID = AudioManager.Instance.GetIdByName(upperName);
            var se = AudioManager.Instance.CreateSe(eventID);

            _se_datas[freeIndex].AudioInstance = se;
            _se_datas[freeIndex].name = upperName;

            if (_se_datas[freeIndex].AudioInstance == null)
            {
                _se_datas[freeIndex].AudioInstance = null;
                _se_datas[freeIndex].name = "";
                _se_datas[freeIndex].playEventId = 0;
            }
            else
            {
                _se_datas[freeIndex].playEventId = _se_datas[freeIndex].AudioInstance.playEventId;
                _se_datas[freeIndex].AudioInstance.Play(instance =>
                {
                    for (int i=0; i<_se_datas.Length; i++)
                    {
                        if (_se_datas[i].AudioInstance != null && _se_datas[i].playEventId == instance.playEventId)
                        {
                            _se_datas[i].playEventId = 0;
                            _se_datas[i].name = "";
                            _se_datas[i].AudioInstance = null;
                        }
                    }
                });

                if (_se_datas[freeIndex].AudioInstance != null && _se_datas[freeIndex].AudioInstance.postEventNumber == 0)
                {
                    _se_datas[freeIndex].AudioInstance = null;
                    _se_datas[freeIndex].name = "";
                }
            }

            return true;
        }

        // TODO
        private bool PlayVoice(string name) { return false; }

        // TODO
        private bool StopSe(string name) { return false; }

        // TODO
        private bool StopVoice(string name) { return false; }

        // TODO
        private bool IsPlayingSe(string name = "") { return false; }

        // TODO
        private bool IsPlayingVoice(string name = "") { return false; }

        // TODO
        public void PlayVoice(int monsNo, int formNo, int voiceType) { }

        // TODO
        public void PlayVoiceUI(int monsNo, int formNo, int voiceType) { }

        private void SpLabel_Init(ZoneID id)
        {
            JumpLabel("SP_" + id.ToString() + "_INIT", null);
            UpdateEvdata(0.0f, true);
        }

        private void SpLabel_Obj(ZoneID id)
        {
            JumpLabel("SP_" + id.ToString() + "_OBJ", null);
            UpdateEvdata(0.0f, true);
        }

        public void SpLabel_Scene(ZoneID id)
        {
            _callLabel_UpdateSP = "SP_" + id.ToString() + "_SCENE";
        }

        private void SpLabel_Flag(ZoneID id)
        {
            JumpLabel("SP_" + id.ToString() + "_FLAG", null);
            UpdateEvdata(0.0f, true);
        }

        public void Jump_InitScr()
        {
            if (FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.FIRST_SAVE))
                return;

            JumpLabel("ev_init_script", null);
            UpdateEvdata(0.0f, true);
            FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.FIRST_SAVE, true);
        }

        // TODO
        private void FindTrainerIndex(int index, TrainerID id) { }

        // TODO
        private TrainerTable.SheetTrainerData GetTrainer(int index) { return null; }

        // TODO
        private TrainerTable.SheetTrainerType GetTrainerType(TrainerType id) { return null; }

        // TODO
        private void BattleTrainer(TrainerID enemy1, TrainerID enemy2 = TrainerID.NONE, TrainerID partner = TrainerID.NONE) { }

        // TODO
        public void ForceEyeEncount(TrainerID trainerID) { }

        // TODO
        public bool TrainerEyeCheck(ref Vector3 moveVector, ref Vector2 hitpos) { return false; }

        // TODO
        private void OnEyeCallBack(FieldObjectMoveCode mvobj) { }

        // TODO
        private void EyeTrainerSetUp(float time) { }

        // TODO
        private bool EyeEncount(FieldObjectMoveCode mvobj, float time) { return false; }

        // TODO
        private bool EyeEncountTagTrainer(FieldObjectMoveCode mvobj1, FieldObjectMoveCode mvobj2, float time) { return false; }

        // TODO
        private void UG_GuruGuruHole(float time) { }

        // TODO
        public bool isUpdateDelegate() { return false; }

        private void ARRIVEDATA_SetArriveFlag(ZoneID id)
        {
            if (id >= ZoneID.D10R0902)
                FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.FLAG_ARRIVE_D10R0902 + (int)id - (int)ZoneID.D10R0902, true);
            else
                FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.FLAG_ARRIVE_C01 + (int)id, true);
        }

        // TODO
        private bool IsPlayingUgEnterOrExit() { return false; }

        // TODO
        public void UG_EnterOrExit() { }

        // TODO
        public bool IsCanGotoUG() { return false; }

        // TODO
        public bool CheckPlaceData() { return false; }

        // TODO
        private UgJumpPos.SheetData GetUgJumpPosData(int MatrixID) { return null; }

        // TODO
        private void GotoOnTheGround()
        {
            // TODO
            void CheckSessionFinish(float deltaTime) { }
        }

        // TODO
        private void SetupUgHolePosRot(GameObject ugObject) { }

        // TODO
        private void GotoUnderGround() { }

        // TODO
        private void FromUnderGround() { }

        // TODO
        public void PlayerRising(float deltaTime) { }

        // TODO
        public void PlayerFall(float deltaTime) { }

        // TODO
        private void UG_HoleDive(float time) { }

        // TODO
        private void UG_From(float time) { }

        private void StartAdjustHeroPos(float deltaTime, string label)
        {
            ClearPlayerMoveVector();
            _callLabel_AdjustHeroPos = label;

            if (!CheckUpdateAdjustHeroPos(deltaTime))
                _updateDelegate = UpdateAdjustHeroPos;
        }

        private bool CheckUpdateAdjustHeroPos(float deltaTime)
        {
            if (!HeroMoveGridCenterFront(deltaTime))
                return false;

            var label = _callLabel_AdjustHeroPos;
            _callLabel_AdjustHeroPos = null;

            if (FieldManager.Instance.StopSwayGrass_NextArea())
                FieldManager.Instance.SetBgmEvent(FieldManager.Instance.GetNowBgmState());

            JumpLabel(label, null);
            return true;
        }

        private void UpdateAdjustHeroPos(float deltaTime)
        {
            if (CheckUpdateAdjustHeroPos(deltaTime))
                _updateDelegate = null;
        }

        // TODO
        public bool CheckEventObjectGrid(int x, int y, float height) { return false; }

        // TODO
        private static bool CheckEventObjectGridCore(FieldObjectEntity entity, int x, int y, float height) { return false; }

        // TODO
        private void EntityMoveCodeCheck() { }

        // TODO
        private bool SetNearIndex(ref EntityParam param, int index) { return false; }

        public void SetBtlSearchEndEvent(UpdateDelegate degate)
        {
            _updateDelegate = degate;
        }

        // TODO
        public void EndSpray() { }

        // TODO
        private void ChkFadeInput() { }

        private void SetCommandUseTime()
        {
            int value = ((int)GameManager.nowTime.DayOfWeek + 1) * 100000000 +
                GameManager.nowTime.Month * 1000000 +
                GameManager.nowTime.Day * 10000 +
                GameManager.nowTime.Hour * 100 +
                GameManager.nowTime.Minute;
            FlagWork.SetWork(EvWork.WORK_INDEX.USE_COMMAND_TIME, value);
        }

        // TODO
        private int GetCommandUseTime(COMMAND_USE_TIME use) { return 0; }

        private void VariableReset()
        {
            _talkStart = TalkState.Init;
            _macroCmd = EvCmdID.NAME._NONE_USE_NUMBER;
            _procCmd = EvCmdID.NAME._NONE_USE_NUMBER;
            _timeWait = 0.0f;
            _heroMoveGridCenterFrontStat = false;

            _fieldObjectMove.Reset();
            _fieldObjectMove.FloatMove.EaseFunc = FieldFloatMove.EaseDefault;
            _fieldObjectRotateYaw.Reset();
            _fieldObjectRotateYaw.FloatMove.EaseFunc = FieldFloatMove.EaseDefault;

            _hidenSequence = 0;
            _runEventLiftEntity = null;
            _kinomiEffect = null;

            _liftSequence = 0;
            _gearSequence = 0;
            _waterSequence = 0;
            _kinomiSequence = 0;
            _kinomiSequenceTime = 0.0f;
            _trainSequence = 0;
            _itemSequence = 0;
            _btwrSequence = 0;
            _nicknamePlacementSequence = 0;
            _softwareKeyboardSubState = 0;
            _effSeq = 0;
            _dendou = 0;
            _warpSequence = 0;
            _warpSpeedSequence = 0;
            _warpSpeedSequenceTime = 0.0f;
            _scopeSequence = 0;
            _azukariyaSequence = 0;
            _pokelistSequence = 0;

            _turnTime[0] = 0.0f;
            _turnTime[1] = 0.0f;

            _seqRankingView = 0;
        }

        private void EventEnd()
        {
            _msgWindow = null;
            _msgWindowCoroutine = null;

            SetCloudScaleEnd();

            _selectDoorObject = null;

            _eventListIndex = -1;
            _rideBicycleReserve = false;
            _isOpenSpecialWin = false;
            _openSpecialWinLabelSelected = -1;

            if (!FlagWork.GetFlag(EvWork.FLAG_INDEX.FH_NECK_LOCK))
                EntityManager.activeFieldPlayer.NeckAngle = Vector3.zero;

            PlayerWork._isPlayerInputActive_ContactEvent = true;
            
            if (_hit_object != null)
            {
                var hitEntity = _hit_object as FieldCharacterEntity;
                if (hitEntity != null)
                    hitEntity.NeckAngle = Vector3.zero;

                if (_hit_object.EventParams.MoveCodeIndex > -1)
                    FieldObjectMoveCodes[_hit_object.EventParams.MoveCodeIndex].MVCodeRestart();

                _hit_object.EventParams.IsEventRunning = false;
                _hit_object = null;
            }

            if (_hit_object_sub != null)
            {
                var hitEntitySub = _hit_object_sub as FieldCharacterEntity;
                if (hitEntitySub != null)
                    hitEntitySub.NeckAngle = Vector3.zero;

                if (_hit_object_sub.EventParams.MoveCodeIndex > -1)
                    FieldObjectMoveCodes[_hit_object_sub.EventParams.MoveCodeIndex].MVCodeRestart();

                _hit_object_sub.EventParams.IsEventRunning = false;
                _hit_object_sub = null;
            }

            FlagWork.SetWork(EvWork.WORK_INDEX.SCWK_TARGET_OBJID, -1);
            _heroMoveGridCenterFrontDir = DIR.DIR_NOT;

            EntityManager.activeFieldPlayer.EvEntityCmd.ReleaseMoveData();
            EntityManager.activeFieldPlayer.EvEntityCmd.ScritpStopStateEnd();

            for (int i=0; i<_se_datas.Length; i++)
            {
                _se_datas[i].name = "";
                _se_datas[i].AudioInstance = null;
            }

            for (int i=0; i<_voice_datas.Length; i++)
            {
                _voice_datas[i].name = "";
                _voice_datas[i].AudioInstance = null;
            }

            _cutinState = CutInState.None;
            _liftEntity = null;
            _tobariGymWallEntity = null;
            _nagisaGymGearEntity = null;
            _nomoseGymSwitchEntity = null;
            _eyePaintingEntity = null;
            _embankmentEntity = null;
            _isOpenBtlTowerRecode = false;
            _temp_PokePara = null;
        }

        private bool OpenTalk(MsgOpenParam msgparam)
        {
            if (_msgWindowCoroutine != null)
            {
                Sequencer.Stop(_msgWindowCoroutine);
            }

            _msgWindowCoroutine = Sequencer.Start(OpenMsgFile(msgparam));
            return true;
        }

        private MessageMsgFile GetMSBTFile(string msbtfilename)
        {
            var msbt = msbtfilename.ToLower();
            var msgFile = MessageManager.Instance.GetMsgFile(msbt.ToLower());

            if (msgFile == null)
            {
                for (int i=5001; i>0; i--)
                {
                    msgFile = MessageManager.Instance.GetMsgFile(msbt);
                    if (msgFile != null)
                        return msgFile;
                }

                return null;
            }
            else
            {
                return msgFile;
            }
        }

        private IEnumerator OpenMsgFile(MsgOpenParam msgparam)
        {
            bool talking = true;
            var msgFile = GetMSBTFile(msgparam.MsbtFile);

            if (msgFile == null)
                yield return null;

            if (_msgWindow != null)
            {
                while (_msgWindow.MsgState == MsgWindowDataModel.MsgWindowState.PlayingClose)
                    yield return null;
            }

            _msgWindowParam.useMsgFile = msgFile;
            _msgWindowParam.labelName = string.Empty;
            _msgWindowParam.labelIndex = -1;

            if (string.IsNullOrEmpty(msgparam.Label))
            {
                _msgWindowParam.labelIndex = msgparam.LabelIndex;
                SetWork(EvWork.WORK_INDEX.SCWK_MSGINDEX, msgparam.LabelIndex);
            }
            else
            {
                _msgWindowParam.labelName = msgparam.Label;
            }

            _msgWindowParam.dataValue = 0;
            _msgWindowParam.inputEnabled = msgparam.Input;
            _msgWindowParam.onFinishedShowAllMessage = () => talking = false;
            _msgWindowParam.playTextFeedSe = msgparam.PlayTextFeedSe;

            if (MsgWindowManager.IsOpen)
            {
                MsgWindowManager.ReplaceMsg(_msgWindowParam);
            }
            else
            {
                _msgWindow = null;
                switch (msgparam.WindowType)
                {
                    case MsgWindowType.DEFAULT:
                    default:
                        _msgWindow = MsgWindowManager.OpenMsg(_msgWindowParam);
                        break;

                    case MsgWindowType.BOARD_TYPE_TOWN:
                        _msgWindowParam.frameTypeIndex = MsgWindowDataModel.WindowFrameType.Frame_Brown;
                        _msgWindow = MsgWindowManager.OpenBoardMsg(_msgWindowParam);
                        break;

                    case MsgWindowType.BOARD_TYPE_ROAD:
                        _msgWindowParam.frameTypeIndex = MsgWindowDataModel.WindowFrameType.Frame_Green;
                        _msgWindow = MsgWindowManager.OpenBoardMsg(_msgWindowParam, GetArgInt(_evArg[4]));
                        break;

                    case MsgWindowType.BOARD_TYPE_POST:
                        _msgWindowParam.frameTypeIndex = MsgWindowDataModel.WindowFrameType.Frame_Gray;
                        _msgWindow = MsgWindowManager.OpenBoardMsg(_msgWindowParam);
                        break;

                    case MsgWindowType.BOARD_TYPE_INFO:
                        _msgWindowParam.frameTypeIndex = MsgWindowDataModel.WindowFrameType.Frame_Blue;
                        _msgWindow = MsgWindowManager.OpenBoardMsg(_msgWindowParam);
                        break;

                    case MsgWindowType.ITEM:
                        _msgWindow = MsgWindowManager.OpenItemGetMsg(_msgWindowParam);
                        break;
                }
            }

            if (_isAutoMsg)
                _msgWindow.EnableAutoMode(_eMsgSpeed, _autoTime);
            else
                _msgWindow.DisableAutoMode();

            while (talking)
                yield return null;

            talking = true;

            if (!MsgWindowManager.Instance.MsgWindow.IsAuto && msgparam.EndType == MsgEndType.Input)
            {
                while (talking)
                {
                    if (FieldInput.PushAB())
                        talking = false;

                    yield return null;
                }
            }

            _msgWindowCoroutine = null;
        }

        private void CloseMsg()
        {
            if (_msgWindowCoroutine != null)
                Sequencer.Stop(_msgWindowCoroutine);

            _msgWindowCoroutine = null;
            MsgWindowManager.CloseMsg();
        }

        private bool CommandEquals(string eq, int val1, int val2)
        {
            string comparison = ReEQType(eq);
            switch (comparison)
            {
                case "EQ":
                    //Equals
                    return val1 == val2;
                case "NE":
                    //Not Equals
                    return val1 != val2;
                case "GT":
                    //Greater
                    return val1 > val2;
                case "GE":
                    //Greater or equal
                    return val1 >= val2;
                case "LT":
                    //Less
                    return val1 < val2;
                case "LE":
                    //Less or equal
                    return val1 <= val2;
                default:
                    return false;
            }
        }

        private bool IfJump_Call(bool jump, string eq, string label)
        {
            string comparison = ReEQType(eq);
            switch (comparison)
            {
                case "EQ":
                    //Exclude Less and Greater
                    if (_cmp_flag != CmpResult.EQUAL)
                    {
                        return false;
                    }
                    break;
                case "NE":
                    //Exclude Equal
                    if (_cmp_flag == CmpResult.EQUAL)
                    {
                        return false;
                    }
                    break;
                case "GT":
                    //Exclude Less and Equal
                    if (_cmp_flag != CmpResult.PLUS)
                    {
                        return false;
                    }
                    break;
                case "GE":
                    //Exclude Less
                    if (_cmp_flag == CmpResult.MINUS)
                    {
                        return false;
                    }
                    break;
                case "LT":
                    //Exclude Greater and Equal
                    if (_cmp_flag != CmpResult.MINUS)
                    {
                        return false;
                    }
                    break;
                case "LE":
                    //Exclude Greater
                    if (_cmp_flag == CmpResult.PLUS)
                    {
                        return false;
                    }
                    break;
                default:
                    return false;
            }

            if (jump)
            {
                return JumpLabel(label, null);
            }
            return CallLabel(label);
        }

        private string ReEQType(string eq)
        {
            switch (eq)
            {
                case "EQUAL":
                    return "EQ";
                case "LITTLER":
                    return "LT";
                case "GREATER":
                    return "GT";
                case "LT_EQ":
                    return "LE";
                case "GT_EQ":
                    return "GE";
                case "FLGON":
                    return "EQ";
                case "FLGOFF":
                    return "LT";
                default:
                    return eq;
            }
        }

        private bool Cmd_TalkMsg(EvScriptData ev, bool index = false)
        {
            switch (_talkStart)
            {
                case TalkState.Init:
                    EvData.Command command = ev.GetScript.Commands[ev.CommandIndex];

                    if (index)
                    {
                        _msgOpenParam.MsbtFile = GetArgString(ev, command.Arg[1]);
                        _msgOpenParam.Label = "";
                        _msgOpenParam.LabelIndex = GetArgInt(command.Arg[2]);

                        if (command.Arg.Count < 4)
                            _msgOpenParam.PlayTextFeedSe = false;
                        else
                            _msgOpenParam.PlayTextFeedSe = GetArgInt(command.Arg[3]) == 1;
                    }
                    else
                    {
                        string label = GetArgString(ev, command.Arg[1]);

                        string[] file = label.Split(new char[1] { '%' });
                        _msgOpenParam.MsbtFile = file[0];
                        _msgOpenParam.Label = file[1];

                        if (command.Arg.Count < 3)
                            _msgOpenParam.PlayTextFeedSe = false;
                        else
                            _msgOpenParam.PlayTextFeedSe = GetArgInt(command.Arg[2]) == 1;
                    }

                    _msgOpenParam.WindowType = MsgWindowType.DEFAULT;
                    _msgOpenParam.Input = true;
                    _msgOpenParam.EndType = MsgEndType.Input;
                    OpenTalk(_msgOpenParam);
                    _talkStart = TalkState.EndWait;
                    return false;

                case TalkState.EndWait:
                    if (_msgWindowCoroutine != null)
                        return false;

                    _talkStart = TalkState.Init;
                    return true;

                default:
                    return false;
            }
        }

        // TODO
        private bool Cmd_ExplanationMsg(string msgfile, string label) { return false; }

        private bool Cmd_TalkMsg(string msbt, string label)
        {
            switch (_talkStart)
            {
                case TalkState.Init:
                    _msgOpenParam.MsbtFile = msbt;
                    _msgOpenParam.Label = label;
                    _msgOpenParam.WindowType = MsgWindowType.DEFAULT;
                    _msgOpenParam.EndType = MsgEndType.Input;
                    _msgOpenParam.Input = true;
                    _msgOpenParam.PlayTextFeedSe = false;
                    OpenTalk(_msgOpenParam);
                    _talkStart = TalkState.EndWait;
                    return false;

                case TalkState.EndWait:
                    if (_msgWindowCoroutine != null)
                        return false;

                    _talkStart = TalkState.Init;
                    return true;

                default:
                    return false;
            }
        }

        private void Cmd_TalkWindOpen()
        {
            if (_talkStart == TalkState.Init &&
                !string.IsNullOrEmpty(_talkOpenMsbt) &&
                !string.IsNullOrEmpty(_talkOpenLabel))
            {
                FlagWork.SetWork(EvWork.WORK_INDEX.SCWK_WIN_OPEN_FLAG, _WORK_TRUE);
                _talkStart = TalkState.Init;
            }
        }

        private void Cmd_TalkWindClose()
        {
            if (_msgWindowCoroutine != null)
                return;

            _talkOpenMsbt = "";
            _talkOpenLabel = "";

            CloseMsg();
            _talkStart = TalkState.Init;
        }

        // TODO
        private void Cmd_TrainerTalkTypeGet(int wk1, int wk2, int wk3) { }

        // TODO
        private void Cmd_RevengeTrainerTalkTypeGet(int wk1, int wk2, int wk3) { }

        // TODO
        private bool CheckTrainer2vs2Type(int tr_id) { return false; }

        // TODO
        private bool EvCmdTrainerMessageSet(int wk1, int wk2) { return false; }

        // TODO
        private void EvCmdBoardMake(EvScriptData ev) { }

        // TODO
        private bool EvCmdBoardReqDpr(EvScriptData ev) { return false; }

        // TODO
        private bool EvCmdBoardReqDpr() { return false; }

        private bool EvCmdBoardReqWait()
        {
            if (_msgWindow == null)
                return true;

            return _boardState == BOARD.BOARD_REQ_WAIT;
        }

        private bool EvCmdBoardEndWait(EvWork.WORK_INDEX work)
        {
            if (_msgWindow == null)
                return true;

            if (_msgWindowCoroutine != null)
                return false;

            if (MsgWindowManager.Instance.MsgWindow.IsAuto || FieldInput.PushAB())
            {
                FlagWork.SetWork(work, 1);
                return true;
            }

            if (FieldInput.PushX())
            {
                FlagWork.SetWork(work, 0);
                return true;
            }

            return false;
        }

        // TODO
        private void EvCmdInfoBoardMake(EvScriptData ev) { }

        // TODO
        private void Cmd_If_Jump(string type, string label) { }

        private bool Cmd_TalkObjStart()
        {
        	if ((int)this._procCmd == 0x343) {
        	  NeckRotateHero();
        	  NeckRotateTarget();
        	  this._procCmd = (NAME)0;
        	  return true;
        	}
        	if ((int)this._procCmd == 0x8e) {
        	  Cmd_ObjPauseAll();
        	  this._procCmd = (NAME)0x343;
        	  return false;
        	}
        	if ((int)this._procCmd == 0x6d) {
        	  PlaySe(StringLiteral_9145);
        	  this._procCmd = (NAME)0x8e;
        	  return false;
        	}
        	this._procCmd = (NAME)0x6d;
        	return false;
        }

        private bool Cmd_TalkObjStartTurnNot()
        {
        	uint uVar2;
        	uint uVar3;
        	if ((int)this._procCmd == 0x343) {
        	  NeckRotateHero();
        	  uVar3 = 1;
        	  NeckRotateTarget(1);
        	  uVar2 = 0;
        	}
        	else if ((int)this._procCmd == 0x8e) {
        	  Cmd_ObjPauseAll();
        	  uVar3 = 0;
        	  uVar2 = 0x343;
        	}
        	else if ((int)this._procCmd == 0x6d) {
        	  PlaySe(StringLiteral_9145);
        	  uVar3 = 0;
        	  uVar2 = 0x8e;
        	}
        	else {
        	  uVar3 = 0;
        	  uVar2 = 0x6d;
        	}
        	this._procCmd = (NAME)(uVar2);
        	return uVar3;
        }

        private bool Cmd_LastKeyWait()
        {
        	return true;
        }

        private bool Cmd_TalkStart()
        {
        	if ((int)this._procCmd != 0x8e) {
        	  if ((int)this._procCmd == 0x6d) {
        	    PlaySe(StringLiteral_9145);
        	    this._procCmd = (NAME)0x8e;
        	    return false;
        	  }
        	  this._procCmd = (NAME)0x6d;
        	  return false;
        	}
        	Cmd_ObjPauseAll();
        	this._procCmd = (NAME)0;
        	return true;
        }

        // TODO
        public bool Cmd_ObjPauseAll() { return false; }

        // TODO
        public bool Cmd_ObjPauseClearAll() { return false; }

        // TODO
        private IEnumerator TurnEnumerator(int index) { return null; }

        // TODO
        private bool Turn_HitObjectToHero() { return false; }

        // TODO
        private bool Turn_HeroToHitObject() { return false; }

        // TODO
        private bool ObjectTurn(float time, float endtime, ref Vector3 target, FieldObjectEntity myEntity, int index) { return false; }

        // TODO
        private string[] GetMsbtFileLabel(string cmdarg) { return null; }

        // TODO
        private bool CmdMapChange(EvScriptData ev) { return false; }

        private bool CmdMapChangeNoneFade(EvScriptData ev)
        {
        	CmdMapChange();
        	return true;
        }

        private bool StackMapChange()
        {
            if (string.IsNullOrEmpty(_mapChangeZoneID))
                return false;

            for (int i=0; i<GameManager.mapInfo.ZoneData.Length; i++)
            {
                if (GameManager.mapInfo.ZoneData[i].ToString() == _mapChangeZoneID)
                {
                    if (GameManager.mapInfo.ZoneData[i] == null)
                    {
                        _mapChangeZoneID = null;
                        return false;
                    }

                    PlayerWork.SetTransitionZone(GameManager.mapInfo.ZoneData[i].ZoneID, _mapChangeIndex);
                    _mapChangeZoneID = null;
                    return true;
                }
            }

            _mapChangeZoneID = null;
            return false;
        }

        private bool YesNoWindow(EvScriptData ev)
        {
            var data = ev.GetScript.Commands[ev.CommandIndex];
            bool useCancel;
            if (data.Arg.Count < 3)
                useCancel = true;
            else
                useCancel = GetArgInt(data.Arg[2]) == 1;

            switch (_talkStart)
            {
                case TalkState.Init:
                    _talkStart = TalkState.EndWait;
                    MsgWindowManager.OpenYesNoMenu(i =>
                    {
                        SetWork(data.Arg[1].data, i);
                        _talkStart = TalkState.CloseWait;
                    }, ContextMenuWindow.CursorType.Arrow, useCancel, true, null);
                    return false;

                case TalkState.EndWait:
                    return false;

                case TalkState.CloseWait:
                    _talkStart = TalkState.Init;
                    return true;

                default:
                    return false;
            }
        }

        // TODO
        private bool CustumWindow(EvData.Command data, bool wordSet = false)
        {
            // TODO
            void OnSelectChoices(int i) { }

            return false;
        }

        // TODO
        private bool CmdPlayerMoveGridCenter(EvData.Command data) { return false; }

        // TODO
        private bool CmdPokemonName(EvData.Command data) { return false; }

        // TODO
        private bool CmdFirstPokemonName(EvData.Command data) { return false; }

        // TODO
        private bool CmdRivalPokemonName(EvData.Command data) { return false; }

        // TODO
        private bool CmdSupportPokemonName(EvData.Command data) { return false; }

        // TODO
        private bool CmdPokemonNameIndex(int index, int pos) { return false; }

        // TODO
        private bool CmdPokemonNickNameIndex(int index, int pos) { return false; }

        // TODO
        private bool CmdPokemonNickNameIndexBox(int index, int tray, int pos) { return false; }

        // TODO
        private bool CmdGetRelPosHero(EvScriptData ev) { return false; }

        // TODO
        private bool CmdSxyExitPosChange(EvData.Command data) { return false; }

        private TrainerID GetArgTrainerID(EvScriptData ev, EvData.Aregment arg)
        {
            switch (arg.argType)
            {
                case EvData.ArgType.Work:
                case EvData.ArgType.Float:
                    return (TrainerID)GetArgInt(arg);

                case EvData.ArgType.String:
                    string trainerName = ev.EvData.GetString(arg.data);
                    for (int i=0; i<(int)TrainerID.MAX; i++)
                    {
                        if (trainerName == Enum.GetName(typeof(TrainerID), i))
                        {
                            return (TrainerID)i;
                        }
                    }
                    return TrainerID.NONE;

                default:
                    return TrainerID.NONE;
            }
        }

        // TODO
        private bool CmdTrainerBtlSet(EvScriptData ev) { return false; }

        // TODO
        private bool CmdTrainerBtlSetMulti(EvScriptData ev) { return false; }

        // TODO
        private bool CmdTrainerBgmSet(EvData.Command data) { return false; }

        // TODO
        private bool CmdVisibleObjProp(EvScriptData ev, bool flag) { return false; }

        // TODO
        private bool CmdFirstPokeSelectProc(EvScriptData ev) { return false; }

        private bool UpdateEvdata(float time, bool sp_script = false)
        {
            if (_eventListIndex < 0)
                return false;

            TairyouHasseiPokeManager.ForceStopObject();
            TairyouHasseiPokeManager.ForceStop = true;

            _deltatime = time;

            int maxCommands = 5001;
            do
            {
                _evData = _eventList[_eventListIndex];
                _evScript = _evData.GetScript;
                _evCommand = _evScript.Commands[_evData.CommandIndex];
                _evArg = _evCommand.Arg.ToArray();

                maxCommands--;
                if (maxCommands == 0)
                {
                    SetCloudScaleEnd();
                    _eventListIndex = -1;
                    return true;
                }

                int prevIndex = _eventListIndex;
                int prevLabelIndex = _evData.LabelIndex;

                if (!RunEvCmd((EvCmdID.NAME)_evArg[0].data))
                    return false;

                if (_eventListIndex == prevIndex && _eventList[prevIndex].LabelIndex == prevLabelIndex)
                    _evData.CommandIndex++;

                VariableReset();

                if (_eventListIndex < 0)
                    break;
            }
            while (_eventList[_eventListIndex].CommandIndex < _eventList[_eventListIndex].GetScript.Commands.Count);

            EventEnd();

            if (StackMapChange() || _isCall_TrainerBtl || _eventListIndex > -1 || _battleReturnData.EventListIndex > -1)
            {
                _eventEndDelegate?.Invoke();
                _eventEndDelegate = null;
                return true;
            }

            if (!sp_script)
            {
                if (EntityManager.activeFieldPlayer != null)
                {
                    _eventEndPosition = EntityManager.activeFieldPlayer.gridPosition;
                    if (Fader.fillPower <= 0.0f)
                        PlayerInputActive(true);
                    else
                        _isFadeEventReturnInput = true;
                }

                for (int i=0; i<_talkTrinerIndex.Length; i++)
                    _talkTrinerIndex[i] = -1;

                for (int i=0; i<_eyeEncountTarget.Length; i++)
                    _eyeEncountTarget[i] = null;
            }

            TairyouHasseiPokeManager.ForceStop = false;
            _callQueue.Clear();

            _eventEndDelegate?.Invoke();
            _eventEndDelegate = null;
            return true;
        }

        private bool EvCmdNop()
        {
            return EvCmdEnd();
        }

        private bool EvCmdDummy()
        {
            return true;
        }

        private bool EvCmdEnd()
        {
            SetCloudScaleEnd();
            _eventListIndex = -1;
            return true;
        }

        private bool EvCmdTimeWait()
        {
            float frames = GetArgFloat(_evArg[1]);
            if (frames * 0.03333334 < _timeWait)
            {
                FlagWork.SetWork(_evArg[2].data, _WORK_FALSE);
                return true;
            }
            else
            {
                FlagWork.SetWork(_evArg[2].data, _WORK_TRUE);
                _timeWait += _deltatime;
                return false;
            }
        }

        private bool EvCmdLoadRegValue()
        {
            return true;
        }

        private bool EvCmdLoadRegWData()
        {
            return true;
        }

        private bool EvCmdLoadRegAdrs()
        {
            return true;
        }

        private bool EvCmdLoadAdrsValue()
        {
            return true;
        }

        private bool EvCmdLoadAdrsReg()
        {
            return true;
        }

        private bool EvCmdLoadRegReg()
        {
            return true;
        }

        private bool EvCmdLoadAdrsAdrs()
        {
            return true;
        }

        private bool EvCmdCmpRegReg()
        {
            return true;
        }

        private bool EvCmdCmpRegValue()
        {
            return true;
        }

        private bool EvCmdCmpRegAdrs()
        {
            return true;
        }

        private bool EvCmdCmpAdrsReg()
        {
            return true;
        }

        private bool EvCmdCmpAdrsValue()
        {
            return true;
        }

        private bool EvCmdCmpAdrsAdrs()
        {
            return true;
        }

        private bool EvCmdCmpWkValue()
        {
            return true;
        }

        private bool EvCmdCmpWkWk()
        {
            EvCmdCmpMain((EvWork.WORK_INDEX)GetArgInt(_evArg[1]), (EvWork.WORK_INDEX)GetArgInt(_evArg[2]));
            return true;
        }

        private bool EvCmdDebugWatch()
        {
            return true;
        }

        private bool EvCmdVMMachineAdd()
        {
            return true;
        }

        private bool EvCmdChangeCommonScr()
        {
            CallLabel(GetArgString(_evData, _evArg[1]));
            return true;
        }

        private bool EvCmdChangeLocalScr()
        {
            if (ReturnEvData())
                return true;
            else
                return EvCmdEnd();
        }

        private bool EvCmdGlobalJump()
        {
            JumpLabel(GetArgString(_evData, _evArg[1]), null);
            return true;
        }

        private bool EvCmdObjIDJump()
        {
            return true;
        }

        private bool EvCmdBgIDJump()
        {
            return true;
        }

        private bool EvCmdPlayerDirJump()
        {
            return true;
        }

        private bool EvCmdGlobalCall()
        {
            CallLabel(GetArgString(_evData, _evArg[1]));
            return true;
        }

        private bool EvCmdRet()
        {
            if (ReturnEvData())
                return true;
            else
                return EvCmdEnd();
        }

        private bool EvCmdIfJump()
        {
            string eq = GetArgString(_evData, _evArg[1]);
            string label = GetArgString(_evData, _evArg[2]);

            IfJump_Call(true, eq, label);
            return true;
        }

        private bool EvCmdIfCall()
        {
            string eq = GetArgString(_evData, _evArg[1]);
            string label = GetArgString(_evData, _evArg[2]);

            IfJump_Call(false, eq, label);
            return true;
        }

        private bool EvMacro_IFVAL_JUMP()
        {
            int val1 = GetArgInt(_evArg[1]);
            string eq = GetArgString(_evData, _evArg[2]);
            int val2 = GetArgInt(_evArg[3]);
            string label = GetArgString(_evData, _evArg[4]);

            if (CommandEquals(eq, val1, val2))
                JumpLabel(label, null);

            return true;
        }

        private bool EvMacro_IFVAL_CALL()
        {
            int val1 = GetArgInt(_evArg[1]);
            string eq = GetArgString(_evData, _evArg[2]);
            int val2 = GetArgInt(_evArg[3]);
            string label = GetArgString(_evData, _evArg[4]);

            if (CommandEquals(eq, val1, val2))
                CallLabel(label);

            return true;
        }

        private bool EvMacro_IFWK_JUMP()
        {
            return EvMacro_IFVAL_JUMP();
        }

        private bool EvMacro_IFWK_CALL()
        {
            return EvMacro_IFVAL_CALL();
        }

        private bool EvMacro_SWITCH()
        {
            _switch_work_index = _evArg[1].data;
            return true;
        }

        private bool EvMacro_CASE_JUMP()
        {
            int actualVal = FlagWork.GetWork(_switch_work_index);
            int checkedVal = GetArgInt(_evArg[1]);
            string label = GetArgString(_evData, _evArg[2]);

            if (actualVal == checkedVal)
                JumpLabel(label, null);

            return true;
        }

        private bool EvMacro_CASE_CANCEL()
        {
            EvCmdCmpMain(EvWork.WORK_INDEX.SCWK_REG0, EvWork.WORK_INDEX.EV_WIN_B_CANCEL);

            string label = GetArgString(_evData, _evArg[1]);

            IfJump_Call(true, "EQ", label);
            return true;
        }

        private bool EvCmdTimeWaitIconAdd()
        {
            return true;
        }

        private bool EvCmdTimeWaitIconDel()
        {
            return true;
        }

        private bool EvCmdFlagSet()
        {
            int flagNo = _evArg[1].data;
            if (flagNo > -1)
            {
                FlagWork.SetFlag(flagNo, true);
                if (flagNo == (int)EvWork.FLAG_INDEX.FLAG_STOP_ZONE_PROGRAM)
                    FieldManager.Instance.eventTownMapPos = EntityManager.activeFieldPlayer.worldPosition;
            }
            return true;
        }

        private bool EvMacro_ARRIVE_FLAG_SET()
        {
            SetSysFlag(_evArg[1].data, true);
            return true;
        }

        private bool EvCmdFlagReset()
        {
            int flagNo = _evArg[1].data;
            if (flagNo > -1)
                FlagWork.SetFlag(flagNo, false);

            return true;
        }

        private bool EvCmdFlagCheck()
        {
            int flagNo = _evArg[1].data;
            _cmp_flag = flagNo >= 0 && flagNo != (int)EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE && FlagWork.GetFlag(flagNo) ? CmpResult.MINUS : CmpResult.EQUAL;

            return true;
        }

        private bool EvMacro_IF_FLAGON_JUMP()
        {
            string label = GetArgString(_evData, _evArg[2]);
            int flagState = GetIF_FLAG(_evArg[1]);

            if (flagState == -100)
                return true;

            if (flagState == _WORK_TRUE)
            {
                _cmp_flag = CmpResult.EQUAL;
                IfJump_Call(true, "FLGON", label);
            }

            return true;
        }

        private bool EvMacro_IF_FLAGOFF_JUMP()
        {
            string label = GetArgString(_evData, _evArg[2]);
            int flagState = GetIF_FLAG(_evArg[1]);

            if (flagState == -100)
                return true;

            if (flagState == _WORK_FALSE)
            {
                _cmp_flag = CmpResult.MINUS;
                IfJump_Call(true, "FLGOFF", label);
            }

            return true;
        }

        private bool EvMacro_IF_FLAGON_CALL()
        {
            string label = GetArgString(_evData, _evArg[2]);
            int flagState = GetIF_FLAG(_evArg[1]);

            if (flagState == -100)
                return true;

            if (flagState == _WORK_TRUE)
            {
                _cmp_flag = CmpResult.EQUAL;
                IfJump_Call(false, "FLGON", label);
            }

            return true;
        }

        private bool EvMacro_IF_FLAGOFF_CALL()
        {
            string label = GetArgString(_evData, _evArg[2]);
            int flagState = GetIF_FLAG(_evArg[1]);

            if (flagState == -100)
                return true;

            if (flagState == _WORK_FALSE)
            {
                _cmp_flag = CmpResult.MINUS;
                IfJump_Call(false, "FLGOFF", label);
            }

            return true;
        }

        private int GetIF_FLAG(EvData.Aregment arg)
        {
            switch (arg.argType)
            {
                case EvData.ArgType.SysFlag:
                    return FlagWork.GetSysFlag((EvWork.SYSFLAG_INDEX)arg.data) ? _WORK_TRUE : _WORK_FALSE;

                case EvData.ArgType.Flag:
                    if (arg.data < 0 || arg.data == (int)EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE)
                        return _WORK_FALSE;

                    return FlagWork.GetFlag(arg.data) ? _WORK_TRUE : _WORK_FALSE;

                default:
                    return -100;
            }
        }

        private bool EvCmdFlagCheckWk()
        {
            int workValue = GetArgInt(_evArg[1]);

            if (workValue < 0 || workValue == (int)EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE)
                FlagWork.SetWork(_evArg[2].data, _WORK_TRUE);
            else if (FlagWork.GetFlag(workValue))
                FlagWork.SetWork(_evArg[2].data, _WORK_FALSE);
            else
                FlagWork.SetWork(_evArg[2].data, _WORK_TRUE);

            return true;
        }

        private bool EvCmdFlagSetWk()
        {
            int flagNo = GetArgInt(_evArg[1]);
            if (flagNo >= 0)
                FlagWork.SetFlag(flagNo, true);

            return true;
        }

        private bool EvCmdTrainerFlagSet()
        {
            TrainerID id = GetArgTrainerID(_evData, _evArg[1]);
            TrainerWork.SetWinFlag(id);
            TrainerWork.ReSetBattleSaercher(id);
            return true;
        }

        private bool EvCmdTrainerFlagReset()
        {
            TrainerID id = GetArgTrainerID(_evData, _evArg[1]);
            TrainerWork.ResetWinFlag(id);
            TrainerWork.ReSetBattleSaercher(id);
            return true;
        }

        private bool EvCmdTrainerFlagCheck()
        {
            TrainerID id = GetArgTrainerID(_evData, _evArg[1]);
            if (TrainerWork.GetWinFlag(id) && !TrainerWork.GetBattleSearcher(id))
                _cmp_flag = CmpResult.EQUAL;
            else
                _cmp_flag = CmpResult.MINUS;

            return true;
        }

        private bool EvMacro_IF_TR_FLAGON_JUMP()
        {
            TrainerID id = GetArgTrainerID(_evData, _evArg[1]);
            _cmp_flag = TrainerWork.GetWinFlag(id) ? CmpResult.EQUAL : CmpResult.MINUS;

            string label = GetArgString(_evData, _evArg[2]);

            IfJump_Call(true, "FLGON", label);
            return true;
        }

        private bool EvMacro_IF_TR_FLAGOFF_JUMP()
        {
            TrainerID id = GetArgTrainerID(_evData, _evArg[1]);
            _cmp_flag = TrainerWork.GetWinFlag(id) ? CmpResult.EQUAL : CmpResult.MINUS;

            string label = GetArgString(_evData, _evArg[2]);

            IfJump_Call(true, "FLGOFF", label);
            return true;
        }

        private bool EvMacro_IF_TR_FLAGON_CALL()
        {
            TrainerID id = GetArgTrainerID(_evData, _evArg[1]);
            _cmp_flag = TrainerWork.GetWinFlag(id) && !TrainerWork.GetBattleSearcher(id) ? CmpResult.EQUAL : CmpResult.MINUS;

            string label = GetArgString(_evData, _evArg[2]);

            IfJump_Call(false, "FLGON", label);
            return true;
        }

        private bool EvMacro_IF_TR_FLAGOFF_CALL()
        {
            TrainerID id = GetArgTrainerID(_evData, _evArg[1]);
            _cmp_flag = TrainerWork.GetWinFlag(id) && !TrainerWork.GetBattleSearcher(id) ? CmpResult.EQUAL : CmpResult.MINUS;

            string label = GetArgString(_evData, _evArg[2]);

            IfJump_Call(false, "FLGOFF", label);
            return true;
        }

        private bool EvCmdWkAdd()
        {
            int initialValue = GetArgInt(_evArg[1]);
            int addedValue = GetArgInt(_evArg[2]);

            FlagWork.SetWork(_evArg[1].data, initialValue + addedValue);
            return true;
        }

        private bool EvCmdWkSub()
        {
            int initialValue = GetArgInt(_evArg[1]);
            int addedValue = GetArgInt(_evArg[2]);

            FlagWork.SetWork(_evArg[1].data, initialValue - addedValue);
            return true;
        }

        private bool EvCmdLoadWkValue()
        {
            int newValue = GetArgInt(_evArg[2]);

            FlagWork.SetWork(_evArg[1].data, newValue);
            return true;
        }

        private bool EvCmdLoadWkWk()
        {
            return EvCmdLoadWkValue();
        }

        private bool EvCmdLoadWkWkValue()
        {
            return EvCmdLoadWkValue();
        }

        private bool EvCmdTalkMsgAllPut()
        {
            return true;
        }

        private bool EvCmdTalkMsgAllPutOtherArc()
        {
            return true;
        }

        private bool EvCmdTalkMsgOtherArc()
        {
            return true;
        }

        private bool EvCmdTalkMsgAllPutPMS()
        {
            return true;
        }

        private bool EvCmdTalkMsgPMS()
        {
            return true;
        }

        private bool EvCmdTalkMsgTowerApper()
        {
            switch (_talkStart)
            {
                case TalkState.Init:
                    int index = GetArgInt(_evArg[1]);
                    int mode = BtlTowerWork.GetMode();
                    BtlTowerWork.GetNowModeEnum(out TowerLotRule rule, out TowerLotCls cls);
                    int rank = BtlTowerWork.GetRank(mode);
                    int round = BtlTowerWork.GetRound(mode);
                    ulong seed = BtlTowerWork.GetTrainerRand(round - 1);

                    var towerLot = TrainerSystem.CreateTowerLotResult(rule, cls, rank, round, seed);
                    TowerTrID id = towerLot.GetTrainerID(index);

                    var trainerData = DataManager.TowerTrainerTable.TrainerData[(int)id];
                    if (trainerData != null)
                    {
                        _msgOpenParam.MsbtFile = "DP_trainer_msg";
                        _msgOpenParam.Label = trainerData.MsgFieldBefore;
                        _msgOpenParam.PlayTextFeedSe = false;
                        _msgOpenParam.WindowType = MsgWindowType.DEFAULT;
                        _msgOpenParam.Input = true;
                        _msgOpenParam.EndType = MsgEndType.Input;
                        FlagWork.SetWork(EvWork.WORK_INDEX.SCWK_WIN_OPEN_FLAG, _WORK_TRUE);
                        OpenTalk(_msgOpenParam);

                        _talkStart = TalkState.EndWait;
                        return false;
                    }

                    _talkStart = TalkState.Init;
                    return true;

                case TalkState.EndWait:
                    if (_msgWindowCoroutine != null)
                        return false;

                    _talkStart = TalkState.Init;
                    return true;

                default:
                    return false;
            }
        }

        private bool EvCmdTalkMsgNgPokeName()
        {
            return true;
        }

        private bool EvCmdTalkMsg()
        {
            return Cmd_TalkMsg(_evData, false);
        }

        private bool EvCmdTalkMsgSp()
        {
            return Cmd_TalkMsg(_evData, true);
        }

        private bool EvCmdTalkMsgSpAuto()
        {
            return true;
        }

        private bool EvCmdTalkMsgNoSkip()
        {
            return true;
        }

        private bool EvCmdTalkConSioMsg()
        {
            return true;
        }

        private bool EvCmdMsgAutoGet()
        {
            return true;
        }

        private bool EvCmdABKeyWait()
        {
            return FieldInput.PushAB();
        }

        private bool EvCmdABKeyTimeWait()
        {
            float time = GetArgFloat(_evArg[1]);
            if (_timeWait <= time)
            {
                _timeWait += _deltatime;
                return false;
            }

            if (FieldInput.PushAB())
                return true;

            _timeWait += _deltatime;
            return false;
        }

        private bool EvCmdLastKeyWait()
        {
            return true;
        }

        private bool EvCmdNextAnmLastKeyWait()
        {
            return true;
        }

        private bool EvCmdTalkWinOpen()
        {
            Cmd_TalkWindOpen();
            return true;
        }

        private bool EvCmdTalkWinClose()
        {
            FlagWork.SetWork(EvWork.WORK_INDEX.SCWK_WIN_OPEN_FLAG, _WORK_FALSE);
            Cmd_TalkWindClose();
            return true;
        }

        private bool EvCmdTalkWinCloseNoClear()
        {
            return EvCmdTalkWinClose();
        }

        private bool EvMacro_TALK_KEYWAIT()
        {
            return Cmd_TalkMsg(_evData, false);
        }

        private bool EvMacro_EASY_OBJ_MSG()
        {
            switch (_macroCmd)
            {
                default:
                    _macroCmd = EvCmdID.NAME._TALK_OBJ_START;
                    return false;

                case EvCmdID.NAME._TALK_OBJ_START:
                    _custumWindow_msbt = "";
                    _custumWindow_Labels.Clear();
                    _custumWindow_RetIndex.Clear();

                    if (!Cmd_TalkObjStart())
                        return false;

                    _macroCmd = EvCmdID.NAME._TALKMSG;
                    return false;

                case EvCmdID.NAME._TALKMSG:
                    if (!Cmd_TalkMsg(_evData))
                        return false;

                    _macroCmd = EvCmdID.NAME._LAST_KEYWAIT;
                    return false;

                case EvCmdID.NAME._LAST_KEYWAIT:
                    _macroCmd = EvCmdID.NAME._TALK_CLOSE;
                    return false;

                case EvCmdID.NAME._TALK_CLOSE:
                    CloseMsg();
                    _macroCmd = EvCmdID.NAME._TALK_OBJ_END;
                    return false;

                case EvCmdID.NAME._TALK_OBJ_END:
                    Cmd_ObjPauseClearAll();
                    _macroCmd = EvCmdID.NAME._NONE_USE_NUMBER;
                    return true;
            }
        }

        private bool EvMacro_EASY_MSG()
        {
            switch (_macroCmd)
            {
                default:
                    _macroCmd = EvCmdID.NAME._TALK_START;
                    return false;

                case EvCmdID.NAME._TALK_START:
                    if (!EvMacro_TALK_START())
                        return false;

                    _macroCmd = EvCmdID.NAME._TALKMSG;
                    return false;

                case EvCmdID.NAME._TALKMSG:
                    if (!Cmd_TalkMsg(_evData))
                        return false;

                    _macroCmd = EvCmdID.NAME._LAST_KEYWAIT;
                    return false;

                case EvCmdID.NAME._LAST_KEYWAIT:
                    _macroCmd = EvCmdID.NAME._TALK_CLOSE;
                    return false;

                case EvCmdID.NAME._TALK_CLOSE:
                    CloseMsg();
                    _macroCmd = EvCmdID.NAME._TALK_END;
                    return false;

                case EvCmdID.NAME._TALK_END:
                    Cmd_ObjPauseClearAll();
                    _macroCmd = EvCmdID.NAME._NONE_USE_NUMBER;
                    return true;
            }
        }

        private bool EvCmdBoardMake()
        {
            string label = GetArgString(_evData, _evArg[1]);
            var splitLabel = label.Split(new char[1] { '%' });
            string winTypeStr = GetArgString(_evData, _evArg[2]);

            MsgWindowType winType = MsgWindowType.BOARD_TYPE_TOWN;
            for (MsgWindowType i=MsgWindowType.DEFAULT; i<MsgWindowType.END; i++)
            {
                if (winTypeStr == i.ToString())
                {
                    winType = i;
                    break;
                }
            }

            _msgOpenParam.MsbtFile = splitLabel[0];
            _msgOpenParam.Label = splitLabel[1];
            _msgOpenParam.EndType = MsgEndType.Manual;
            _msgOpenParam.WindowType = winType;
            _msgOpenParam.Input = true;

            if (_evArg.Length < 4)
                _msgOpenParam.PlayTextFeedSe = false;
            else
                _msgOpenParam.PlayTextFeedSe = GetArgInt(_evArg[3]) == 1;

            _boardState = BOARD.BOARD_REQ_ADD;
            return true;
        }

        private bool EvCmdInfoBoardMake()
        {
            string label = GetArgString(_evData, _evArg[1]);
            var splitLabel = label.Split(new char[1] { '%' });
            string winTypeStr = GetArgString(_evData, _evArg[2]);

            MsgWindowType winType = MsgWindowType.BOARD_TYPE_TOWN;
            for (MsgWindowType i=MsgWindowType.DEFAULT; i<MsgWindowType.END; i++)
            {
                if (winTypeStr == i.ToString())
                {
                    winType = i;
                    break;
                }
            }

            _msgOpenParam.MsbtFile = splitLabel[0];
            _msgOpenParam.Label = splitLabel[1];
            _msgOpenParam.EndType = MsgEndType.Manual;
            _msgOpenParam.WindowType = winType;
            _msgOpenParam.Input = true;

            if (_evArg.Length < 4)
                _msgOpenParam.PlayTextFeedSe = false;
            else
                _msgOpenParam.PlayTextFeedSe = GetArgInt(_evArg[3]) == 1;

            _boardState = BOARD.BOARD_REQ_ADD;
            return true;
        }

        private bool EvCmdBoardReq()
        {
            string boardReqStr = GetArgString(_evData, _evArg[1]);

            for (BOARD i=BOARD.BOARD_REQ_WAIT; i<BOARD.END; i++)
            {
                if (boardReqStr == i.ToString())
                {
                    _boardState = i;
                    break;
                }
            }

            return BoardReq();
        }

        private bool EvCmdBoardWait()
        {
            if (_msgWindow == null)
                return true;

            return _boardState == BOARD.BOARD_REQ_WAIT;
        }

        private bool EvCmdBoardMsg()
        {
            return BoardEndWait(EvWork.WORK_INDEX.SCWK_ANSWER);
        }

        private bool EvCmdBoardEndWait()
        {
            return BoardEndWait(EvWork.WORK_INDEX.SCWK_ANSWER);
        }

        private bool EvMacro_EASY_BOARD_MSG()
        {
            switch (_macroCmd)
            {
                default:
                    PlayerInputActive(false);
                    Cmd_ObjPauseAll();
                    _macroCmd = EvCmdID.NAME._TURN_HERO_TALK_OBJ;
                    return false;

                case EvCmdID.NAME._TURN_HERO_TALK_OBJ:
                    NeckRotateHero();
                    _macroCmd = EvCmdID.NAME._BOARD_MAKE;
                    return false;

                case EvCmdID.NAME._BOARD_MAKE:
                    EvCmdBoardMake();
                    _macroCmd = EvCmdID.NAME._BOARD_REQ;
                    return false;

                case EvCmdID.NAME._BOARD_REQ:
                    _boardState = BOARD.BOARD_REQ_UP;
                    if (!EvCmdBoardReqDpr())
                        return false;

                    _macroCmd = EvCmdID.NAME._BOARD_REQ_WAIT;
                    return false;

                case EvCmdID.NAME._BOARD_REQ_WAIT:
                    if (!EvCmdBoardReqWait())
                        return false;

                    _macroCmd = EvCmdID.NAME._BOARD_END_WAIT;
                    return false;

                case EvCmdID.NAME._BOARD_END_WAIT:
                    if (!EvCmdBoardEndWait())
                        return false;

                    _macroCmd = EvCmdID.NAME._CHG_COMMON_SCR;
                    return false;

                case EvCmdID.NAME._CHG_COMMON_SCR:
                    Cmd_ObjPauseClearAll();
                    CallLabel("ev_common_board");
                    _macroCmd = EvCmdID.NAME._NONE_USE_NUMBER;
                    return false; // Always returns false but that's ok, the execution goes to the _CALL
            }
        }

        private bool EvMacro_EASY_INFOBOARD_MSG()
        {
            switch (_macroCmd)
            {
                default:
                    PlayerInputActive(false);
                    Cmd_ObjPauseAll();
                    _macroCmd = EvCmdID.NAME._TURN_HERO_TALK_OBJ;
                    return false;

                case EvCmdID.NAME._TURN_HERO_TALK_OBJ:
                    NeckRotateHero();
                    _macroCmd = EvCmdID.NAME._INFOBOARD_MAKE;
                    return false;

                case EvCmdID.NAME._INFOBOARD_MAKE:
                    EvCmdInfoBoardMake();
                    _macroCmd = EvCmdID.NAME._BOARD_REQ;
                    return false;

                case EvCmdID.NAME._BOARD_REQ:
                    _boardState = BOARD.BOARD_REQ_UP;
                    if (!EvCmdBoardReqDpr())
                        return false;

                    _macroCmd = EvCmdID.NAME._BOARD_REQ_WAIT;
                    return false;

                case EvCmdID.NAME._BOARD_REQ_WAIT:
                    if (!EvCmdBoardReqWait())
                        return false;

                    _macroCmd = EvCmdID.NAME._BOARD_MSG;
                    return false;

                case EvCmdID.NAME._BOARD_MSG:
                    if (!EvCmdBoardMsg())
                        return false;

                    _macroCmd = EvCmdID.NAME._CHG_COMMON_SCR;
                    return false;

                case EvCmdID.NAME._CHG_COMMON_SCR:
                    Cmd_ObjPauseClearAll();
                    CallLabel("ev_common_board");
                    _macroCmd = EvCmdID.NAME._NONE_USE_NUMBER;
                    return true;
            }
        }

        private bool EvCmdMenuReq()
        {
            return true;
        }

        private bool EvCmdBgScroll()
        {
            return true;
        }

        private bool EvCmdYesNoWin()
        {
            return YesNoWindow(_evData);
        }

        private bool EvCmdGuinnessWin()
        {
            return true;
        }

        private bool EvCmdBmpMenuInit()
        {
            return true;
        }

        private bool EvCmdBmpMenuInitEx()
        {
            return true;
        }

        private bool EvCmdBmpMenuMakeList()
        {
            return true;
        }

        private bool EvCmdBmpMenuMakeList16()
        {
            return true;
        }

        private bool EvCmdBmpMenuStart()
        {
            return true;
        }

        private bool EvCmdBmpListInit()
        {
            return true;
        }

        private bool EvCmdBmpListInitEx()
        {
            return true;
        }

        private bool EvCmdBmpListMakeList()
        {
            return true;
        }

        private bool EvCmdBmpListStart()
        {
            return true;
        }

        private bool EvCmdBmpMenuHVStart()
        {
            return true;
        }

        private bool EvCmdSePlay()
        {
            return PlaySe(GetArgString(_evData, _evArg[1]));
        }

        // TODO
        private bool EvCmdSeStop() { return false; }

        // TODO
        private bool EvCmdSeWait() { return false; }

        // TODO
        private bool EvCmdVoicePlay() { return false; }

        // TODO
        private bool EvCmdVoicePlayWait() { return false; }

        // TODO
        private bool EvMacro_EASY_VOICE_MSG() { return false; }

        private bool EvCmdMePlay()
        {
            return EvCmdSePlay();
        }

        // TODO
        private bool EvCmdMeWait() { return false; }

        private bool EvCmdSndInitialVolSet()
        {
        	return true;
        }

        private bool EvCmdBgmPlay()
        {
            FieldManager.Instance.SetBgmEvent(GetArgString(_evData, _evArg[1]));
            return true;
        }

        private bool EvCmdBgmPlayCheck()
        {
        	return true;
        }

        // TODO
        private bool EvCmdBgmStop() { return false; }

        // TODO
        private bool EvCmdBgmNowMapPlay() { return false; }

        // TODO
        private bool EvCmdBgmSpecialSet() { return false; }

        private bool EvMacro_BGM_SPECIAL_CLR()
        {
        	return true;
        }

        private bool EvCmdBgmFadeOut()
        {
        	return true;
        }

        private bool EvMacro_BGM_FADEOUT_PLAY()
        {
        	return true;
        }

        private bool EvCmdBgmFadeIn()
        {
        	return true;
        }

        private bool EvCmdBgmPlayerPause()
        {
        	return true;
        }

        // TODO
        private bool EvCmdPlayerFieldDemoBgmPlay() { return false; }

        // TODO
        private bool EvCmdCtrlBgmFlagSet() { return false; }

        // TODO
        private bool EvCmdCtrlBgmFlagReSet() { return false; }

        private bool EvCmdPerapDataCheck()
        {
        	return true;
        }

        private bool EvCmdPerapRecStart()
        {
        	return true;
        }

        private bool EvCmdPerapRecStop()
        {
        	return true;
        }

        private bool EvCmdPerapSave()
        {
        	return true;
        }

        private bool EvCmdSndClimaxDataLoad()
        {
        	return true;
        }

        private bool EvCmdObjAnime()
        {
            var label = GetArgString(_evData, _evArg[2]);

            FieldObjectEntity entity;
            if (_evArg[1].argType == EvData.ArgType.String)
                entity = Find_fieldObjectEntity(GetArgString(_evData, _evArg[1]));
            else
            {
                var objectID = GetArgInt(_evArg[1]);
                entity = objectID > -1 ? _fieldObjectEntity[objectID] : null;
            }

            if (entity != null)
            {
                float startFrame = 0.0f;
                if (_evArg.Length > 3)
                    startFrame = GetArgFloat(_evArg[3]);

                var evMove = _evData.FindLabelScript(label);
                if (evMove != null)
                    entity.EvEntityCmd.SetScriptMoveData(evMove, startFrame);
            }

            return true;
        }

        private bool EvCmdObjAnimePos()
        {
        	return true;
        }

        private bool EvMacro_ANIME_LABEL()
        {
        	return true;
        }

        private bool EvMacro_ANIME_DATA()
        {
        	return true;
        }

        private bool EvCmdObjAnimeWait()
        {
            return IsMoveEnd("");
        }

        private bool EvCmdTalkObjPauseAll()
        {
        	return true;
        }

        private bool EvCmdObjPauseAll()
        {
        	Cmd_ObjPauseAll();
        	return true;
        }

        private bool EvCmdObjPauseClearAll()
        {
        	return true;
        }

        // TODO
        private bool EvCmdObjPause() { return false; }

        // TODO
        private bool EvCmdObjPauseClear() { return false; }

        // TODO
        private bool EvCmdObjAdd() { return false; }

        // TODO
        private bool EvCmdObjDel() { return false; }

        private bool EvCmdVanishDummyObjAdd()
        {
        	return true;
        }

        private bool EvCmdVanishDummyObjDel()
        {
        	return true;
        }

        private bool EvCmdObjTurn()
        {
        	Turn_HitObjectToHero();
        	return true;
        }

        // TODO
        private bool EvMacro_TALK_OBJ_START() { return false; }

        private bool EvMacro_TALK_OBJ_START_TURN_NOT()
        {
        	uint uVar2;
        	uint uVar3;
        	if ((int)this._procCmd == 0x343) {
        	  NeckRotateHero();
        	  uVar3 = 1;
        	  NeckRotateTarget(1);
        	  uVar2 = 0;
        	}
        	else if ((int)this._procCmd == 0x8e) {
        	  Cmd_ObjPauseAll();
        	  uVar3 = 0;
        	  uVar2 = 0x343;
        	}
        	else if ((int)this._procCmd == 0x6d) {
        	  PlaySe(StringLiteral_9145);
        	  uVar3 = 0;
        	  uVar2 = 0x8e;
        	}
        	else {
        	  uVar3 = 0;
        	  uVar2 = 0x6d;
        	}
        	this._procCmd = (NAME)(uVar2);
        	return uVar3;
        }

        // TODO
        private bool EvMacro_TALK_OBJ_END() { return false; }

        private bool EvMacro_TALK_START()
        {
            switch (_procCmd)
            {
                default:
                    _procCmd = EvCmdID.NAME._SE_PLAY;
                    return false;

                case EvCmdID.NAME._SE_PLAY:
                    PlaySe(SEQ_SE_DP_SELECT);
                    _procCmd = EvCmdID.NAME._OBJ_PAUSE_ALL;
                    return false;

                case EvCmdID.NAME._OBJ_PAUSE_ALL:
                    Cmd_ObjPauseAll();
                    _procCmd = EvCmdID.NAME._NONE_USE_NUMBER;
                    return true;
            }
        }

        // TODO
        private bool EvMacro_EVENT_START() { return false; }

        private bool EvMacro_TALK_END()
        {
        	Cmd_ObjPauseClearAll();
        	return true;
        }

        private bool EvMacro_EVENT_END()
        {
        	Cmd_ObjPauseClearAll();
        	return true;
        }

        // TODO
        private bool EvCmdPlayerPosGet() { return false; }

        // TODO
        private bool EvCmdObjPosGet() { return false; }

        private bool EvCmdPlayerPosOffsetSet()
        {
        	return true;
        }

        // TODO
        private bool EvCmdPlayerDirGet() { return false; }

        private bool EvCmdNotZoneDelSet()
        {
        	return true;
        }

        // TODO
        private bool EvCmdMoveCodeChange() { return false; }

        private bool EvCmdMoveCodeGet()
        {
        	return true;
        }

        // TODO
        private bool EvCmdPairObjIdSet() { return false; }

        private bool EvMacro_EVENT_DATA()
        {
        	return true;
        }

        private bool EvMacro_EVENT_DATA_END()
        {
        	return true;
        }

        private bool EvMacro_SP_EVENT_DATA_END()
        {
            return EvCmdEnd();
        }

        private bool EvMacro_SCENE_CHANGE_LABEL()
        {
            return EvCmdGlobalJump();
        }

        private bool EvMacro_SCENE_CHANGE_DATA()
        {
            var arg1 = GetArgInt(_evArg[1]);
            var arg2 = GetArgInt(_evArg[2]);

            if (arg1 == arg2)
                CallLabel(GetArgString(_evData, _evArg[3]));

            return true;
        }

        private bool EvMacro_SCENE_CHANGE_END()
        {
            return EvCmdEnd();
        }

        private bool EvMacro_FLAG_CHANGE_LABEL()
        {
            return EvCmdGlobalJump();
        }

        private bool EvMacro_OBJ_CHANGE_LABEL()
        {
            return EvCmdGlobalJump();
        }

        private bool EvMacro_INIT_CHANGE_LABEL()
        {
            return EvCmdGlobalJump();
        }

        private bool EvCmdAddGold()
        {
            MoneyWork.Add(GetArgInt(_evArg[1]));
            return true;
        }

        // TODO
        private bool EvCmdSubGold() { return false; }

        // TODO
        private bool EvCmdCompGold() { return false; }

        // TODO
        private bool EvCmd_GET_GOLD() { return false; }

        private bool EvCmdGoldWinWrite()
        {
        	return true;
        }

        private bool EvCmdGoldWinDel()
        {
        	return true;
        }

        private bool EvCmdGoldWrite()
        {
        	return true;
        }

        private bool EvCmdCoinWinWrite()
        {
        	return true;
        }

        private bool EvCmdCoinWinDel()
        {
        	return true;
        }

        private bool EvCmdCoinWrite()
        {
        	return true;
        }

        private bool EvCmdCheckCoin()
        {
        	return true;
        }

        private bool EvCmdAddCoin()
        {
        	return true;
        }

        private bool EvCmdSubCoin()
        {
        	return true;
        }

        // TODO
        private bool EvMacro_FLD_ITEM_EVENT() { return false; }

        private bool EvMacro_HIDE_ITEM_EVENT()
        {
        	return true;
        }

        private bool EvCmdAddItem()
        {
            ItemWork.AddItem(GetArgInt(_evArg[1]), GetArgInt(_evArg[2]));
            FlagWork.SetWork(_evArg[3].data, _WORK_TRUE);
            return true;
        }

        // TODO
        private bool EvCmdSubItem() { return false; }

        // TODO
        private bool EvCmdAddItemChk() { return false; }

        // TODO
        private bool EvCmdCheckItem() { return false; }

        // TODO
        private bool EvCmd_GET_ITEM_COUNT() { return false; }

        // TODO
        private bool EvCmd_PLAY_EMO_SE() { return false; }

        // TODO
        private bool EvCmdWazaMachineItemNoCheck() { return false; }

        // TODO
        private bool EvCmdGetPocketNo() { return false; }

        // TODO
        private bool EvCmdPocketCheck() { return false; }

        // TODO
        private bool EvCmdPofinCheck() { return false; }

        private bool EvCmdAddPCBoxItem()
        {
        	return true;
        }

        private bool EvCmdCheckPCBoxItem()
        {
        	return true;
        }

        private bool EvCmdAddGoods()
        {
        	return true;
        }

        private bool EvCmdSubGoods()
        {
        	return true;
        }

        private bool EvCmdAddGoodsChk()
        {
        	return true;
        }

        private bool EvCmdCheckGoods()
        {
        	return true;
        }

        private bool EvCmdAddTrap()
        {
        	return true;
        }

        private bool EvCmdSubTrap()
        {
        	return true;
        }

        private bool EvCmdAddTrapChk()
        {
        	return true;
        }

        private bool EvCmdCheckTrap()
        {
        	return true;
        }

        private bool EvCmdAddTreasure()
        {
        	return true;
        }

        private bool EvCmdSubTreasure()
        {
        	return true;
        }

        private bool EvCmdAddTreasureChk()
        {
        	return true;
        }

        private bool EvCmdCheckTreasure()
        {
        	return true;
        }

        private bool EvCmdAddTama()
        {
        	return true;
        }

        private bool EvCmdSubTama()
        {
        	return true;
        }

        private bool EvCmdAddTamaChk()
        {
        	return true;
        }

        private bool EvCmdCheckTama()
        {
        	return true;
        }

        private bool EvCmdCBSealKindNumGet()
        {
        	return true;
        }

        // TODO
        private bool EvCmdCBItemNumGet() { return false; }

        // TODO
        private bool EvCmdCBItemNumAdd() { return false; }

        // TODO
        private bool EvCmdUnknownFormGet() { return false; }

        // TODO
        private bool EvCmdAddPokemon() { return false; }

        // TODO
        private bool EvCmdAddPokemonUI() { return false; }

        // TODO
        private bool EvCmdAddUniquePokemonUI() { return false; }

        // TODO
        private bool EvCmdAddTamago() { return false; }

        private bool EvCmdChgPokeWaza()
        {
        	return true;
        }

        // TODO
        private bool EvCmdChkPokeWaza() { return false; }

        // TODO
        private bool EvCmdChkPokeWazaGroup() { return false; }

        // TODO
        private bool EvCmdAddWaza() { return false; }

        private bool EvCmdApprovePoisonDead()
        {
        	return true;
        }

        // TODO
        private bool EvCmdRevengeTrainerSearch() { return false; }

        private bool EvCmdSetWeather()
        {
        	return true;
        }

        private bool EvCmdInitWeather()
        {
        	return true;
        }

        private bool EvCmdUpdateWeather()
        {
        	return true;
        }

        private bool EvCmdGetMapPosition()
        {
        	return true;
        }

        private bool EvCmdGetTemotiPokeNum()
        {
        	return true;
        }

        private bool EvCmdSetMapProc()
        {
        	return true;
        }

        private bool EvCmdFinishMapProc()
        {
        	return this._openTownMapSeq == 1;
        }

        private bool EvCmdWiFiAutoReg()
        {
        	return true;
        }

        private bool EvCmdWiFiP2PMatchEventCall()
        {
        	return true;
        }

        private bool EvCmdWiFiP2PMatchSetDel()
        {
        	return true;
        }

        private bool EvCmdCommGetCurrentID()
        {
        	return true;
        }

        // TODO
        private bool EvCmdDendouNumGet() { return false; }

        // TODO
        private bool EvCmdPokeWindowPut() { return false; }

        private bool EvCmdPokeWindowPutPP()
        {
        	return true;
        }

        private bool EvCmdPokeWindowDel()
        {
        	return true;
        }

        private bool EvCmdPokeWindowAnm()
        {
        	return true;
        }

        private bool EvCmdPokeWindowAnmWait()
        {
        	return true;
        }

        // TODO
        private bool EvCmdBtlSearcherEventCall() { return false; }

        private bool EvCmdBtlSearcherDirMvSet()
        {
        	return true;
        }

        private bool EvCmdMsgBoyEvent()
        {
        	return true;
        }

        private bool EvCmdImageClipSetProc()
        {
        	return true;
        }

        private bool EvCmdImageClipPreviewTvProc()
        {
        	return true;
        }

        // TODO
        private bool EvCmdImageClipPreviewConProc() { return false; }

        // TODO
        private bool EvCmdCustomBallEventCall() { return false; }

        // TODO
        private bool EvCmdTMapBGSetProc() { return false; }

        // TODO
        private bool EvCmdBoxSetProc() { return false; }

        private bool EvCmd_BOX_SEAL_UI_WAIT()
        {
        	return this._pc_window_close;
        }

        private bool EvCmdOekakiBoardSetProc()
        {
        	return true;
        }

        private bool EvCmdCallTrCard()
        {
        	return true;
        }

        private bool EvCmdTradeListSetProc()
        {
        	return true;
        }

        private bool EvCmdRecordCornerSetProc()
        {
        	return true;
        }

        // TODO
        private bool EvCmdDendouSetProc() { return false; }

        // TODO
        private bool EvCmdPcDendouSetProc() { return false; }

        private bool EvCmdPcDendouSetProcOpenWait()
        {
        	return !this._isOpenHallOfFame;
        }

        private bool EvCmdWorldTradeSetProc()
        {
        	return true;
        }

        private bool EvCmdDPWInitProc()
        {
        	return true;
        }

        // TODO
        private bool EvCmdFirstPokeSelectProc() { return false; }

        private bool EvCmdFirstPokeSelectSetAndDel()
        {
        	return true;
        }

        private bool EvCmdBagSetProcNormal()
        {
        	return true;
        }

        // TODO
        private bool EvCmdBagSetProcKinomi() { return false; }

        // TODO
        private bool EvCmdBagGetResult() { return false; }

        // TODO
        private bool EvCmdPokeListSetProc() { return false; }

        private bool EvCmdNpcTradePokeListSetProc()
        {
        	return true;
        }

        private bool EvCmdUnionPokeListSetProc()
        {
        	return true;
        }

        // TODO
        private bool EvCmdPokeListGetResult() { return false; }

        private bool EvCmdConPokeListSetProc()
        {
        	return true;
        }

        private bool EvCmdConPokeListGetResult()
        {
        	return true;
        }

        private bool EvCmdConPokeStatusSetProc()
        {
        	return true;
        }

        private bool EvCmdPokeStatusGetResult()
        {
        	return true;
        }

        // TODO
        private bool EvCmdWifiEarthSetProc() { return false; }

        // TODO
        private bool EvCmdEyeTrainerMoveSet() { return false; }

        // TODO
        private bool EvCmdEyeTrainerMoveCheck() { return false; }

        // TODO
        private bool EvCmdEyeTrainerTypeGet() { return false; }

        // TODO
        private bool EvCmdEyeTrainerIdGet() { return false; }

        private bool EvCmdNameIn()
        {
        	return true;
        }

        // TODO
        private bool EvCmdNameInPoke() { return false; }

        private bool EvCmdWipeFadeStart()
        {
        	return true;
        }

        private bool EvCmdWipeFadeCheck()
        {
        	return true;
        }

        private bool EvMacro_WHITE_OUT()
        {
        	0.white;
        	Fader.fillColor = 0;
        	Fader.FadeOut(this._fadeSpeed);
        	return true;
        }

        private bool EvMacro_WHITE_IN()
        {
        	0.white;
        	Fader.fillColor = 0;
        	Fader.FadeIn(this._fadeSpeed);
        	return true;
        }

        private bool EvMacro_BLACK_OUT()
        {
        	0.black;
        	Fader.fillColor = 0;
        	Fader.FadeOut(this._fadeSpeed);
        	return true;
        }

        private bool EvMacro_BLACK_IN()
        {
        	0.black;
        	Fader.fillColor = 0;
        	Fader.FadeIn(this._fadeSpeed);
        	return true;
        }

        private bool EvMacro_MAP_CHANGE()
        {
        	CmdMapChange(this._evData);
        	return true;
        }

        private bool EvCmdMapChange()
        {
        	CmdMapChange(this._evData);
        	return true;
        }

        // TODO
        private bool EvCmdColosseumMapChangeIn() { return false; }

        private bool EvCmdColosseumMapChangeOut()
        {
        	return true;
        }

        // TODO
        private bool EvCmdGetBeforeZoneID() { return false; }

        // TODO
        private bool EvCmdGetNowZoneID() { return false; }

        // TODO
        private bool EvCmdKabeNobori() { return false; }

        // TODO
        private bool EvCmdNaminori() { return false; }

        // TODO
        private bool EvCmdBicycleCheck() { return false; }

        // TODO
        private bool EvCmdBicycleReq() { return false; }

        // TODO
        private bool EvCmdBicycleReqNonBgm() { return false; }

        private bool EvCmdCyclingRoadSet()
        {
        	return true;
        }

        private bool EvCmdPlayerFormGet()
        {
        	return true;
        }

        // TODO
        private bool EvCmdPlayerReqBitOn() { return false; }

        // TODO
        private bool EvCmdPlayerReqStart() { return false; }

        // TODO
        private bool EvCmdTakinobori() { return false; }

        // TODO
        private bool EvCmdSorawotobu() { return false; }

        // TODO
        private bool EvCmdSorawotobuEnd() { return false; }

        // TODO
        private bool EvCmdHidenFlash() { return false; }

        // TODO
        private bool EvCmd_DARKNESS_TEMPORARILY_OFF() { return false; }

        // TODO
        private bool EvCmd_DARKNESS_TEMPORARILY_ON() { return false; }

        // TODO
        private bool EvCmdHidenKiribarai() { return false; }

        // TODO
        private bool EvCmdCutIn() { return false; }

        // TODO
        private MonsNo GetHidenWazaMonsNo(WazaNo wazaNo) { return MonsNo.NULL; }

        // TODO
        private bool CheckHidenWazaForceResetForm(WazaNo wazaNo) { return false; }

        private bool EvCmdConHeroChange()
        {
        	return true;
        }

        // TODO
        private bool EvCmdPlayerName() { return false; }

        // TODO
        private bool EvCmdRivalName() { return false; }

        // TODO
        private bool EvCmdSupportName() { return false; }

        private bool EvCmdPokemonName()
        {
        	CmdPokemonName(this._evCommand);
        	return true;
        }

        // TODO
        private bool EvCmdItemName() { return false; }

        // TODO
        private bool EvCmdPocketName() { return false; }

        // TODO
        private bool EvCmdItemWazaName() { return false; }

        // TODO
        private bool EvCmdWazaName() { return false; }

        // TODO
        private bool EvCmdNumberName() { return false; }

        // TODO
        private bool EvCmdNumberNameEx() { return false; }

        // TODO
        private bool EvCmdSpeakersName() { return false; }

        // TODO
        private bool EvCmdContestCategoryName() { return false; }

        // TODO
        private bool EvCmdContestRankName() { return false; }

        // TODO
        private bool EvCmdPokeTypeName() { return false; }

        // TODO
        private bool EvCmdPofifinName() { return false; }

        // TODO
        private bool EvCmdDressName() { return false; }

        // TODO
        private bool EvCmdBirthDayCheck() { return false; }

        // TODO
        private bool EvCmdBirthMonthInput() { return false; }

        // TODO
        private bool EvCmdBirthDayInput() { return false; }

        // TODO
        private int DayNumInMonth(int month) { return 0; }

        // TODO
        private bool EvCmdAnoonSeeNum() { return false; }

        // TODO
        private bool EvCmdNickName() { return false; }

        // TODO
        private bool EvCmdPoketchName() { return false; }

        // TODO
        private bool EvCmdTrTypeName() { return false; }

        // TODO
        private bool EvCmdPartnerNameSet() { return false; }

        private bool EvCmdMyTrTypeName()
        {
        	return true;
        }

        // TODO
        private bool EvCmdPokemonNameExtra() { return false; }

        private bool EvCmdFirstPokemonName()
        {
        	CmdFirstPokemonName(this._evCommand);
        	return true;
        }

        private bool EvCmdRivalPokemonName()
        {
        	CmdRivalPokemonName(this._evCommand);
        	return true;
        }

        private bool EvCmdSupportPokemonName()
        {
        	CmdSupportPokemonName(this._evCommand);
        	return true;
        }

        // TODO
        private bool EvCmdFirstPokeNoGet() { return false; }

        // TODO
        private bool EvCmdNutsName() { return false; }

        // TODO
        private bool EvCmdSeikakuName() { return false; }

        private bool EvCmdGoodsName()
        {
        	return true;
        }

        private bool EvCmdTrapName()
        {
        	return true;
        }

        private bool EvCmdTamaName()
        {
        	return true;
        }

        // TODO
        private bool EvCmdZoneName() { return false; }

        // TODO
        private bool EvCmdZoneName2() { return false; }

        // TODO
        private bool EvCmdZoneNameLabel() { return false; }

        // TODO
        private bool EvCmdGenerateInfoGet() { return false; }

        // TODO
        private bool EvCmdTrainerIdGet() { return false; }

        private bool EvCmdTrainerBattleSet()
        {
        	CmdTrainerBtlSet(this._evData);
        	return true;
        }

        private bool EvCmdTrainerMultiBattleSet()
        {
        	CmdTrainerBtlSetMulti(this._evData);
        	return true;
        }

        // TODO
        private bool EvCmdTrainerMessageSet() { return false; }

        // TODO
        private bool EvCmdTrainerTalkTypeGet() { return false; }

        // TODO
        private bool EvCmdRevengeTrainerTalkTypeGet() { return false; }

        private bool EvCmdTrainerTypeGet()
        {
        	return true;
        }

        private bool EvCmdTrainerBgmSet()
        {
        	CmdTrainerBgmSet(this._evCommand);
        	return true;
        }

        private bool EvCmdTrainerLose()
        {
        	return true;
        }

        private bool EvCmdTrainerLoseCheck()
        {
        	return true;
        }

        private bool EvCmdNormalLose()
        {
        	return true;
        }

        private bool EvCmdNormalLoseCheck()
        {
        	return true;
        }

        // TODO
        private bool EvCmdSeacretPokeRetryCheck() { return false; }

        private bool EvCmdHaifuPokeRetryCheck()
        {
        	return true;
        }

        // TODO
        private bool EvCmd2vs2BattleCheck() { return false; }

        private bool EvCmdDebugBattleSet()
        {
        	return true;
        }

        private bool EvCmdDebugTrainerFlagSet()
        {
        	return true;
        }

        private bool EvCmdDebugTrainerFlagOnJump()
        {
        	return true;
        }

        private bool EvMacro_DEBUG_TR_TALK_BTL()
        {
        	return true;
        }

        private bool EvCmdConnectSelParentWin()
        {
        	return true;
        }

        private bool EvCmdConnectSelChildWin()
        {
        	return true;
        }

        private bool EvCmdConnectDebugParentWin()
        {
        	return true;
        }

        private bool EvCmdConnectDebugChildWin()
        {
        	return true;
        }

        private bool EvCmdDebugSioEncount()
        {
        	return true;
        }

        private bool EvCmdDebugSioContest()
        {
        	return true;
        }

        private bool EvCmdConSioTimingSend()
        {
        	return true;
        }

        private bool EvCmdConSioTimingCheck()
        {
        	return true;
        }

        private bool EvCmdConSystemCreate()
        {
        	return true;
        }

        private bool EvCmdConSystemExit()
        {
        	return true;
        }

        private bool EvCmdConJudgeNameGet()
        {
        	return true;
        }

        private bool EvCmdConBreederNameGet()
        {
        	return true;
        }

        private bool EvCmdConNickNameGet()
        {
        	return true;
        }

        private bool EvCmdConNumTagSet()
        {
        	return true;
        }

        private bool EvCmdConSioParamInitSet()
        {
        	return true;
        }

        // TODO
        private bool EvCmdContestProc() { return false; }

        private bool EvCmdConRankNameGet()
        {
        	return true;
        }

        private bool EvCmdConTypeNameGet()
        {
        	return true;
        }

        private bool EvCmdConVictoryBreederNameGet()
        {
        	return true;
        }

        private bool EvCmdConVictoryItemNoGet()
        {
        	return true;
        }

        private bool EvCmdConVictoryNickNameGet()
        {
        	return true;
        }

        private bool EvCmdConRankingCheck()
        {
        	return true;
        }

        private bool EvCmdConVictoryEntryNoGet()
        {
        	return true;
        }

        private bool EvCmdConMyEntryNoGet()
        {
        	return true;
        }

        private bool EvCmdConObjCodeGet()
        {
        	return true;
        }

        private bool EvCmdConPopularityGet()
        {
        	return true;
        }

        private bool EvCmdConDeskModeGet()
        {
        	return true;
        }

        // TODO
        private bool EvCmdConHaveRibbonCheck() { return false; }

        private bool EvCmdConRibbonNameGet()
        {
        	return true;
        }

        private bool EvCmdConAcceNoGet()
        {
        	return true;
        }

        private bool EvCmdConEntryParamGet()
        {
        	return true;
        }

        private bool EvCmdConCameraFlashSet()
        {
        	return true;
        }

        private bool EvCmdConCameraFlashCheck()
        {
        	return true;
        }

        private bool EvCmdConHBlankStop()
        {
        	return true;
        }

        private bool EvCmdConHBlankStart()
        {
        	return true;
        }

        private bool EvCmdConEndingSkipCheck()
        {
        	return true;
        }

        // TODO
        private bool EvCmdConRecordDisp() { return false; }

        private bool EvCmdConMsgPrintFlagSet()
        {
        	return true;
        }

        private bool EvCmdConMsgPrintFlagReset()
        {
        	return true;
        }

        private bool EvCmdSpLocationSet()
        {
        	return true;
        }

        private bool EvCmdElevatorNowFloorGet()
        {
        	return true;
        }

        private bool EvCmdElevatorFloorWrite()
        {
        	return true;
        }

        // TODO
        private bool EvCmdGetShinouZukanSeeNum() { return false; }

        // TODO
        private bool EvCmdGetShinouZukanGetNum() { return false; }

        // TODO
        private bool EvCmdGetZenkokuZukanSeeNum() { return false; }

        // TODO
        private bool EvCmdGetZenkokuZukanGetNum() { return false; }

        private bool EvCmdChkZenkokuZukan()
        {
        	return true;
        }

        private bool EvCmdGetZukanHyoukaMsgID()
        {
        	return true;
        }

        // TODO
        private bool EvCmdWildBattleSet() { return false; }

        // TODO
        private bool EvCmdSpWildBattleSet() { return false; }

        // TODO
        private bool EvCmdFirstBattleSet() { return false; }

        // TODO
        private bool EvCmdCaptureBattleSet() { return false; }

        // TODO
        private bool EvCmdHoneyTree() { return false; }

        // TODO
        private bool EvCmdGetHoneyTreeState() { return false; }

        // TODO
        private bool EvCmdHoneyTreeBattleSet() { return false; }

        private bool EvCmdHoneyAfterTreeBattleSet()
        {
        	return true;
        }

        private bool EvCmdTSignSetProc()
        {
        	return true;
        }

        private bool EvCmdReportSaveCheck()
        {
        	return this._cmdReportSaveCoroutine == null;
        }

        // TODO
        private bool EvCmdReportSave() { return false; }

        // TODO
        private IEnumerator evReportSaveCoroutine() { return null; }

        private bool EvCmdReportInfoWinOpen()
        {
        	return true;
        }

        private bool EvCmdReportInfoWinClose()
        {
        	return true;
        }

        private bool EvCmdImageClipTvSaveDataCheck()
        {
        	return true;
        }

        private bool EvCmdImageClipConSaveDataCheck()
        {
        	return true;
        }

        private bool EvCmdImageClipTvSaveTitle()
        {
        	return true;
        }

        private bool EvCmdGetPoketch()
        {
        	FlagWork.SetFlag(0xcb,1);
        	return true;
        }

        // TODO
        private bool EvCmdGetPoketchFlag() { return false; }

        private bool EvCmdPoketchAppAdd()
        {
            FieldPoketch.SetAvailablePoketchApp((POKETCH_APPID)GetArgInt(_evArg[1]));
            return true;
        }

        // TODO
        private bool EvCmdPoketchAppCheck() { return false; }

        private bool EvCmdCommTimingSyncStart()
        {
        	return true;
        }

        private bool EvCmdCommTempDataReset()
        {
        	return true;
        }

        // TODO
        private bool EvCmdUnionProc() { return false; }

        private bool EvCmdUnionParentCardTalkNo()
        {
        	return true;
        }

        private bool EvCmdUnionGetInfoTalkNo()
        {
        	return true;
        }

        private bool EvCmdUnionBeaconChange()
        {
        	return true;
        }

        private bool EvCmdUnionConnectTalkDenied()
        {
        	return true;
        }

        private bool EvCmdUnionConnectTalkOk()
        {
        	return true;
        }

        private bool EvCmdUnionTrainerNameRegist()
        {
        	return true;
        }

        private bool EvCmdUnionReturnSetUp()
        {
        	return true;
        }

        private bool EvCmdUnionConnectCutRestart()
        {
        	return true;
        }

        private bool EvCmdUnionGetTalkNumber()
        {
        	return true;
        }

        private bool EvCmdUnionIdSet()
        {
        	return true;
        }

        private bool EvCmdUnionResultGet()
        {
        	return true;
        }

        private bool EvCmdUnionObjAllVanish()
        {
        	return true;
        }

        private bool EvCmdUnionScriptResultSet()
        {
        	return true;
        }

        private bool EvCmdUnionParentStartCommandSet()
        {
        	return true;
        }

        private bool EvCmdUnionChildSelectCommandSet()
        {
        	return true;
        }

        private bool EvCmdUnionConnectStart()
        {
        	return true;
        }

        private bool EvCmdUnionMapChange()
        {
        	return true;
        }

        private bool EvCmdUnionViewSetUpTrainerTypeSelect()
        {
        	return true;
        }

        private bool EvCmdUnionViewGetTrainerType()
        {
        	return true;
        }

        private bool EvCmdUnionViewGetTrainerTypeNo()
        {
        	return true;
        }

        private bool EvCmdUnionViewMyStatusSet()
        {
        	return true;
        }

        // TODO
        private bool EvCmdSysFlagZukanGet() { return false; }

        // TODO
        private bool EvCmdSysFlagZukanSet() { return false; }

        // TODO
        private bool EvCmdSysFlagShoesGet() { return false; }

        // TODO
        private bool EvCmdSysFlagShoesSet() { return false; }

        // TODO
        private bool EvCmdSysFlagBadgeGet() { return false; }

        // TODO
        private bool EvCmdSysFlagBadgeSet() { return false; }

        // TODO
        private bool EvCmdSysFlagBadgeCount() { return false; }

        // TODO
        private bool EvCmdSysFlagBagGet() { return false; }

        private bool EvCmdSysFlagBagSet()
        {
        	FlagWork.SetSysFlag(1,1);
        	return true;
        }

        // TODO
        private bool EvCmdSysFlagPairGet() { return false; }

        private bool EvCmdSysFlagPairSet()
        {
        	FlagWork.SetSysFlag(2,1);
        	return true;
        }

        // TODO
        private bool EvCmdSysFlagPairReset() { return false; }

        // TODO
        private bool EvCmdSysFlagOneStepGet() { return false; }

        private bool EvCmdSysFlagOneStepSet()
        {
        	FlagWork.SetSysFlag(6,1);
        	return true;
        }

        private bool EvCmdSysFlagOneStepReset()
        {
        	FlagWork.SetSysFlag(6,0);
        	return true;
        }

        // TODO
        private bool EvCmdSysFlagGameClearGet() { return false; }

        private bool EvCmdSysFlagGameClearSet()
        {
        	FlagWork.SetSysFlag(5,1);
        	return true;
        }

        private bool EvCmdSysFlagKairikiSet()
        {
        	FlagWork.SetSysFlag(3,1);
        	return true;
        }

        private bool EvCmdSysFlagKairikiReset()
        {
        	FlagWork.SetSysFlag(3,0);
        	return true;
        }

        // TODO
        private bool EvCmdSysFlagKairikiGet() { return false; }

        // TODO
        private bool EvCmdSysFlagFlashSet() { return false; }

        // TODO
        private bool EvCmdSysFlagFlashReset() { return false; }

        // TODO
        private bool EvCmdSysFlagFlashGet() { return false; }

        // TODO
        private bool EvCmdSysFlagKiribaraiSet() { return false; }

        // TODO
        private bool EvCmdSysFlagKiribaraiReset() { return false; }

        // TODO
        private bool EvCmdSysFlagKiribaraiGet() { return false; }

        private bool EvCmdShopCall()
        {
        	return true;
        }

        private bool EvCmdFixShopCall()
        {
        	return true;
        }

        private bool EvCmdFixGoodsCall()
        {
        	return true;
        }

        private bool EvCmdFixSealCall()
        {
        	return true;
        }

        private bool EvCmdAcceShopCall()
        {
        	return true;
        }

        private bool EvCmdReportDrawProcSet()
        {
        	return true;
        }

        private bool EvCmdReportDrawProcDel()
        {
        	return true;
        }

        private bool EvCmdGameOverCall()
        {
        	return true;
        }

        // TODO
        private bool EvCmdSetWarpId() { return false; }

        // TODO
        private bool EvCmd_SET_TELEPORT_ID() { return false; }

        // TODO
        private bool EvCmdGetMySex() { return false; }

        // TODO
        private bool EvCmdPcKaifuku() { return false; }

        private bool EvCmdUgManShopNpcRandomPlace()
        {
        	return true;
        }

        private bool EvCmdCommDirectEnd()
        {
        	return true;
        }

        private bool EvCmdCommDirectEndTiming()
        {
        	return true;
        }

        private bool EvCmdCommDirectEnterBtlRoom()
        {
        	return true;
        }

        private bool EvCmdCommPlayerSetDir()
        {
        	return true;
        }

        private bool EvCmdSetUpDoorAnime()
        {
        	return true;
        }

        // TODO
        private bool EvCmdWait3DAnime() { return false; }

        private bool EvCmdFree3DAnime()
        {
        	this._selectDoorObject = null;
        	return true;
        }

        // TODO
        private bool EvCmdOpenDoor() { return false; }

        // TODO
        private bool EvCmdCloseDoor() { return false; }

        private bool EvCmdPMSInputSingleProc()
        {
        	return true;
        }

        private bool EvCmdPMSInputDoubleProc()
        {
        	return true;
        }

        private bool EvCmdPMSBuf()
        {
        	return true;
        }

        // TODO
        private FieldKinomiGrowEntity GetCurrentKinomiGrowEntity() { return null; }

        // TODO
        private int GetCurrentKinomiGrowId() { return 0; }

        // TODO
        private bool EvCmdSeedGetStatus() { return false; }

        // TODO
        private bool EvCmdSeedGetType() { return false; }

        private bool EvCmdSeedGetCompost()
        {
        	return true;
        }

        private bool EvCmdSeedGetGroundStatus()
        {
        	return true;
        }

        // TODO
        private bool EvCmdSeedGetNutsCount() { return false; }

        private bool EvCmdSeedSetCompost()
        {
        	return true;
        }

        // TODO
        private bool EvCmdSeedSetNuts() { return false; }

        // TODO
        private bool EvCmdSeedSetWater() { return false; }

        // TODO
        private bool EvCmdSeedTakeNuts() { return false; }

        // TODO
        private bool EvCmdSxyPosChange() { return false; }

        // TODO
        private bool EvCmdObjPosChange() { return false; }

        // TODO
        private bool EvCmd_OBJ_POS_CHANGE_WORLD() { return false; }

        // TODO
        private bool EvCmd_OBJ_DIR_CHANGE_WORLD() { return false; }

        // TODO
        private bool EvCmd_OBJ_POS_CHANGE_WORLD_FIND() { return false; }

        // TODO
        private bool EvCmdSxyMoveCodeChange() { return false; }

        private bool EvCmdSxyDirChange()
        {
            var entity = Find_fieldObjectEntity(GetArgString(_evData, _evArg[1]));
            if (entity != null)
                entity.SetYawAngleDirect(GetArgInt(_evArg[2]) + 360);

            return true;
        }

        private bool EvCmdSxyExitPosChange()
        {
        	CmdSxyExitPosChange(this._evCommand);
        	return true;
        }

        private bool EvCmdSxyBgPosChange()
        {
        	return true;
        }

        private bool EvCmdObjDirChange()
        {
            return EvCmdSxyDirChange();
        }

        // TODO
        private bool EvCmdReturnScriptWkSet() { return false; }

        private bool EvCmdMsgExpandBuf()
        {
        	return true;
        }

        private bool EvCmdGetSodateyaName()
        {
        	return true;
        }

        // TODO
        private bool EvCmdGetSodateyaZiisan() { return false; }

        private bool EvCmdInitWaterGym()
        {
        	return true;
        }

        // TODO
        private bool EvCmdPushWaterGymButton() { return false; }

        // TODO
        private bool EvCmdGetWaterGymWaterLevel() { return false; }

        // TODO
        private bool EvCmdResetWaterGymWaterLevel() { return false; }

        private bool EvCmdInitGhostGym()
        {
        	EvCmdInitFldLift();
        	return true;
        }

        // TODO
        private bool EvCmdMoveGhostGymLift() { return false; }

        private bool EvCmdInitSteelGym()
        {
        	return true;
        }

        // TODO
        private bool EvCmdInitCombatGym() { return false; }

        private bool EvCmdInitElecGym()
        {
        	return true;
        }

        // TODO
        private bool EvCmdRotElecGymGear() { return false; }

        // TODO
        private bool EvCmdGetPokeCount() { return false; }

        // TODO
        private bool EvCmdGetPokeCount2() { return false; }

        // TODO
        private bool EvCmdGetPokeCount3() { return false; }

        // TODO
        private bool EvCmdGetPokeCount4() { return false; }

        // TODO
        private bool EvCmdGetPokeCount5() { return false; }

        private bool EvCmdGetTamagoCount()
        {
        	return true;
        }

        // TODO
        private bool EvCmdUgShopMenuInit() { return false; }

        private DayOfWeek GetShopUgWeek()
        {
        	var iVar1 = FlagWork.GetWork(0x16d);
        	if (0 < iVar1) {
        	  return iVar1 + -1;
        	}
        	iVar1 = FlagWork.GetWork(0x1a2);
        	FlagWork.SetWork(0x16d,iVar1 / 100000000);
        	return iVar1 / 100000000 + -1;
        }

        // TODO
        private bool EvCmdUgLevaeHyouta()
        {
            // TODO
            void AnimationEnd() { }

            return false;
        }

        private bool EvCmdAGAnimationHyouta()
        {
            void AnimationEnd()
            {
                UgFieldManager.isGuruGuruAnimEnd = true;
            }

            if (UgFieldManager.isStartLeave)
            {
                if (UgFieldManager.isGuruGuruAnimEnd)
                {
                    UgFieldManager.isStartLeave = false;
                    return true;
                }

                return false;
            }

            if (_evArg[1].argType == EvData.ArgType.String)
            {
                var entity = GetFieldObject(GetArgString(_evData, _evArg[1])).GetComponent<FieldCharacterEntity>();
                var animPlayer = entity.GetAnimationPlayer();

                bool isRising;
                float height;
                if (_evArg.Length < 4)
                {
                    height = 20.0f;
                    isRising = true;
                }
                else
                {
                    height = GetArgFloat(_evArg[2]);
                    isRising = GetArgInt(_evArg[3]) == 0;
                }

                if (isRising)
                    animPlayer.Play(FieldCharacterEntity.Animation.Spin);

                Sequencer.Start(TransitionAnimation.AgEntityTransitionAnimationStop(entity, height, 0.0f, isRising, AnimationEnd, false));
            }

            UgFieldManager.isStartLeave = true;
            UgFieldManager.isGuruGuruAnimEnd = false;
            return false;
        }

        private bool EvCmdUgShopTalkStart()
        {
        	return true;
        }

        private bool EvCmdUgShopTalkEnd()
        {
        	return true;
        }

        private bool EvCmdUgShopTalkRegisterItemName()
        {
        	return true;
        }

        private bool EvCmdUgShopTalkRegisterTrapName()
        {
        	return true;
        }

        private bool EvCmdDelSodateyaEgg()
        {
        	return true;
        }

        private bool EvCmdGetSodateyaEgg()
        {
        	return true;
        }

        private bool EvCmdMsgSodateyaAishou()
        {
        	return true;
        }

        private bool EvCmdMsgAzukeSet()
        {
        	return true;
        }

        private bool EvCmdSetSodateyaPoke()
        {
        	return true;
        }

        private bool EvCmdSodateyaPokeList()
        {
        	return true;
        }

        private bool EvCmdHikitoriList()
        {
        	return true;
        }

        private bool EvCmdSodatePokeLevelStr()
        {
        	return true;
        }

        private bool EvCmdHikitoriRyoukin()
        {
        	return true;
        }

        private bool EvCmdHikitoriPoke()
        {
        	return true;
        }

        // TODO
        private bool EvCmdTamagoDemo() { return false; }

        // TODO
        private bool EvCmdTemotiMonsNo() { return false; }

        // TODO
        private bool EvCmdMonsOwnChk() { return false; }

        // TODO
        private bool EvCmdChkTemotiPokerus() { return false; }

        private bool EvCmdTemotiPokeSexGet()
        {
        	return true;
        }

        // TODO
        private bool EvCmdSubMyGold() { return false; }

        // TODO
        private bool EvCmdCompMyGold() { return false; }

        // TODO
        private bool EvCmdObjVisible() { return false; }

        // TODO
        private bool EvCmdObjInvisible() { return false; }

        private bool EvCmdMailBox()
        {
        	return true;
        }

        private bool EvCmdGetMailBoxDataNum()
        {
        	return true;
        }

        // TODO
        private bool EvCmdRankingView() { return false; }

        // TODO
        private bool EvCmdGetTimeZone() { return false; }

        private bool EvCmdGetRand()
        {
            FlagWork.SetWork(_evArg[1].data, UnityEngine.Random.Range(0, GetArgInt(_evArg[2])));
            return true;
        }

        private bool EvCmdGetRandNext()
        {
            return EvCmdGetRand();
        }

        // TODO
        private bool EvCmdGetNatsuki() { return false; }

        // TODO
        private bool EvCmdAddNatsuki() { return false; }

        private bool EvCmdSubNatsuki()
        {
        	return true;
        }

        private bool EvCmdHikitoriListNameSet()
        {
        	return true;
        }

        private bool EvCmdGetSodateyaAishou()
        {
        	return true;
        }

        private bool EvCmdGetSodateyaTamagoCheck()
        {
        	return true;
        }

        // TODO
        private bool EvCmdTemotiPokeChk() { return false; }

        // TODO
        private bool EvCmdOokisaRecordChk() { return false; }

        // TODO
        private int CalcPokemonSizeValue(PokemonParam param) { return 0; }

        // TODO
        private float CalcPokemonSize(MonsNo monsNo, int sizeValue) { return 0.0f; }

        // TODO
        private bool EvCmdOokisaRecordSet() { return false; }

        // TODO
        private bool EvCmdOokisaTemotiSet() { return false; }

        // TODO
        private bool EvCmdOokisaKirokuSet() { return false; }

        // TODO
        private bool EvCmdOokisaValueSet() { return false; }

        // TODO
        private void SetOokisaDigit(int idx0, int idx1, float size) { }

        private bool EvCmdOokisaKurabeInit()
        {
        	FlagWork.SetWork(0xfd,0x8200);
        	return true;
        }

        private bool EvCmdWazaListSetProc()
        {
        	return true;
        }

        private bool EvCmdWazaListGetResult()
        {
        	return true;
        }

        // TODO
        private bool EvCmdWazaCount() { return false; }

        // TODO
        private bool EvCmdWazaDel() { return false; }

        private bool EvCmdTemotiWazaNo()
        {
        	return true;
        }

        // TODO
        private bool EvCmdTemotiWazaName() { return false; }

        private bool EvCmdFNoteStartSet()
        {
        	return true;
        }

        private bool EvCmdFNoteDataMake()
        {
        	return true;
        }

        private bool EvCmdFNoteDataSave()
        {
        	return true;
        }

        private bool EvCmdImcAcceAddItem()
        {
        	return true;
        }

        private bool EvCmdImcAcceAddItemChk()
        {
        	return true;
        }

        private bool EvCmdImcAcceCheckItem()
        {
        	return true;
        }

        private bool EvCmdImcBgAddItem()
        {
        	return true;
        }

        private bool EvCmdImcBgCheckItem()
        {
        	return true;
        }

        // TODO
        private bool EvCmdNutMixerProc() { return false; }

        private bool EvCmdNutMixerPlayStateCheck()
        {
        	return true;
        }

        // TODO
        private bool EvCmdZukanChkShinou() { return false; }

        // TODO
        private bool EvCmdZukanChkNational() { return false; }

        // TODO
        private bool EvCmdZukanRecongnizeShinou() { return false; }

        // TODO
        private bool EvCmdZukanRecongnizeNational() { return false; }

        // TODO
        private bool EvCmdRecongnizeTokikake() { return false; }

        private bool EvCmdRecongnizeOpenWait()
        {
        	return !this._isOpenCertificate;
        }

        private bool EvCmdUrayamaEncountSet()
        {
        	EncountDataWork.ChangeUrayamaIndex(1);
        	return true;
        }

        // TODO
        private bool EvCmdUrayamaEncountNoChk() { return false; }

        private bool EvCmdPokeMailChk()
        {
        	return true;
        }

        private bool EvCmdPaperplaneSet()
        {
        	return true;
        }

        private bool EvCmdPokeMailDel()
        {
        	return true;
        }

        // TODO
        private bool EvCmdKasekiCount() { return false; }

        private bool EvCmdItemListSetProc()
        {
        	return true;
        }

        private bool EvCmdItemListGetResult()
        {
        	return true;
        }

        // TODO
        private bool EvCmdItemNoToMonsNo() { return false; }

        // TODO
        private bool EvCmdKasekiItemNo() { return false; }

        // TODO
        private bool EvCmdPokeLevelChk() { return false; }

        // TODO
        private bool EvCmdBTowerAppSetProc() { return false; }

        private bool EvCmdBattleTowerRecordMenuWait()
        {
        	return !this._isOpenBtlTowerRecode;
        }

        private bool EvCmdBattleTowerWorkClear()
        {
        	return true;
        }

        private bool EvCmdBattleTowerWorkInit()
        {
        	return true;
        }

        private bool EvCmdBattleTowerWorkRelease()
        {
        	return true;
        }

        private bool EvCmdBattleTowerTools()
        {
        	return true;
        }

        private bool EvCmdBattleTowerGetSevenPokeData()
        {
        	return true;
        }

        private bool EvCmdBattleTowerIsPrizeGet()
        {
        	return true;
        }

        private bool EvCmdBattleTowerIsPrizemanSet()
        {
        	return true;
        }

        private bool EvCmdBattleTowerSendBuf()
        {
        	return true;
        }

        private bool EvCmdBattleTowerRecvBuf()
        {
        	return true;
        }

        private bool EvCmdBattleTowerGetLeaderRoomID()
        {
        	return true;
        }

        private bool EvCmdBattleTowerIsLeaderDataExist()
        {
        	return true;
        }

        // TODO
        private bool EvCmdRecordInc() { return false; }

        private bool EvCmdRecordGet()
        {
        	return true;
        }

        private bool EvCmdRecordAdd()
        {
        	return true;
        }

        private bool EvCmdRecordSet()
        {
        	return true;
        }

        private bool EvCmdRecordSetIflarge()
        {
        	return true;
        }

        // TODO
        private bool EvCmdSafariControlStart() { return false; }

        // TODO
        private bool EvCmdSafariControlEnd() { return false; }

        // TODO
        private bool EvCmdCallSafariScope() { return false; }

        private bool EvCmdClimaxDemoCall()
        {
        	return true;
        }

        private bool EvCmdInitSafariTrain()
        {
        	return true;
        }

        // TODO
        private bool EvCmdMoveSafariTrain() { return false; }

        // TODO
        private bool EvCmdCheckSafariTrain() { return false; }

        // TODO
        private FieldEventTrainEntity GetTrain() { return null; }

        // TODO
        private bool EvCmdPlayerHeightValid() { return false; }

        // TODO
        private bool EvCmdGetPokeSeikaku() { return false; }

        // TODO
        private bool EvCmdChkPokeSeikakuAll() { return false; }

        private bool EvCmdUnderGroundTalkCount()
        {
        	return true;
        }

        // TODO
        private bool EvCmdNaturalParkWalkCountClear() { return false; }

        private bool EvCmdNaturalParkWalkCountGet()
        {
        	return true;
        }

        private bool EvCmdNaturalParkAccessoryNoGet()
        {
        	return true;
        }

        // TODO
        private bool EvCmdGetNewsPokeNo() { return false; }

        private bool EvCmdNewsCountSet()
        {
        	return true;
        }

        private bool EvCmdNewsCountChk()
        {
        	return true;
        }

        // TODO
        private bool EvCmdStartGenerate() { return false; }

        // TODO
        private bool EvCmdAddMovePoke() { return false; }

        private bool EvCmdOshieWazaCount()
        {
        	return true;
        }

        // TODO
        private bool EvCmdRemaindWazaCount() { return false; }

        private bool EvCmdOshieWazaListSetProc()
        {
        	return true;
        }

        private bool EvCmdRemaindWazaListSetProc()
        {
        	return true;
        }

        private bool EvCmdOshieWazaListGetResult()
        {
        	return true;
        }

        private bool EvCmdRemaindWazaListGetResult()
        {
        	return true;
        }

        private bool EvCmdNormalWazaListSetProc()
        {
        	return true;
        }

        private bool EvCmdNormalWazaListGetResult()
        {
        	return true;
        }

        private bool EvCmdFldTradeAlloc()
        {
        	return true;
        }

        private bool EvCmdFldTradeMonsno()
        {
        	return true;
        }

        private bool EvCmdFldTradeChgMonsno()
        {
        	return true;
        }

        private bool EvCmdFldTradeEvent()
        {
        	return true;
        }

        private bool EvCmdFldTradeDel()
        {
        	return true;
        }

        private bool EvCmdZukanTextVerUp()
        {
        	return true;
        }

        private bool EvCmdZukanSexVerUp()
        {
        	return true;
        }

        // TODO
        private bool EvCmdZenkokuZukanFlag() { return false; }

        private bool EvCmdChkRibbonCount()
        {
        	return true;
        }

        // TODO
        private bool EvCmdChkRibbonCountAll() { return false; }

        // TODO
        private bool EvCmdChkRibbon() { return false; }

        // TODO
        private bool EvCmdSetRibbon() { return false; }

        // TODO
        private bool EvCmdRibbonName() { return false; }

        // TODO
        private bool EvCmdChkPrmExp() { return false; }

        // TODO
        private bool EvCmdChkWeek() { return false; }

        // TODO
        private bool EvCmdTVEntryWatchHideItem() { return false; }

        // TODO
        private bool EvCmdTVEntryWatchChangeName() { return false; }

        private bool EvCmdRegulationListCall()
        {
        	return true;
        }

        // TODO
        private bool EvCmdAshiatoChk() { return false; }

        // TODO
        private bool EvCmdPcRecoverAnm() { return false; }

        // TODO
        private bool EvCmdElevatorAnm() { return false; }

        // TODO
        private bool EvCmdCallShipDemo() { return false; }

        // TODO
        private bool EvCmdCallShipDemoSeaMap() { return false; }

        // TODO
        private bool EvCmdSetupShip() { return false; }

        // TODO
        private bool EvCmdGetUsedPoketchAppID() { return false; }

        private bool EvCmdDebugPrintWork()
        {
        	return true;
        }

        private bool EvCmdDebugPrintFlag()
        {
        	return true;
        }

        private bool EvCmdDebugPrintWorkStationed()
        {
        	return true;
        }

        private bool EvCmdDebugPrintFlagStationed()
        {
        	return true;
        }

        // TODO
        private bool EvCmdPMVersionGet() { return false; }

        // TODO
        private bool EvCmdFrontPokemon() { return false; }

        // TODO
        private bool EvCmdTemotiPokeType() { return false; }

        private bool EvCmdAikotobaKabegamiSet()
        {
        	return true;
        }

        private bool EvCmdGetUgHataNum()
        {
        	return true;
        }

        private bool EvCmdSetUpPasoAnime()
        {
        	return true;
        }

        private bool EvCmdStartPasoOnAnime()
        {
        	return true;
        }

        private bool EvCmdStartPasoOffAnime()
        {
        	return true;
        }

        // TODO
        private bool EvCmdGetKujiAtariNum() { return false; }

        // TODO
        private bool EvCmdKujiAtariChk() { return false; }

        private bool EvCmdKujiAtariInit()
        {
        	FieldLotteryWork.InitNumber(0);
        	return true;
        }

        private bool EvCmdNickNamePC()
        {
        	return true;
        }

        // TODO
        private bool EvCmdTVInterviewerCheck() { return false; }

        private bool EvCmdTVInterviewerMsg()
        {
        	return true;
        }

        // TODO
        private bool EvCmdTVInterviewerEntry() { return false; }

        // TODO
        private bool EvCmdTVStart() { return false; }

        // TODO
        private void PlayTv(TvDataTable.Sheetdata data) { }

        // TODO
        private FieldTvEntity FindTvEntity() { return null; }

        // TODO
        private bool EvCmdTVEnd() { return false; }

        // TODO
        private bool EvCmdTVStartNumber() { return false; }

        // TODO
        private bool EvCmdTVTopicBranchGet() { return false; }

        // TODO
        private bool EvCmdTVTopicIntGet() { return false; }

        // TODO
        private bool EvCmdTVTopicStrWordSet() { return false; }

        // TODO
        private bool EvCmdTVTopicStrGenderWordSet() { return false; }

        // TODO
        private bool EvCmdTvInterviewStrWordSet() { return false; }

        // TODO
        private bool EvCmdTVMonitorSet() { return false; }

        // TODO
        private bool EvCmdTVMonitorReset() { return false; }

        // TODO
        private bool EvCmdPokeBoxCountEmptySpace() { return false; }

        // TODO
        private bool EvCmdConOpenPokeSelectMenu() { return false; }

        // TODO
        private bool EvCmdConOpenCapsuleSelectMenu() { return false; }

        // TODO
        private bool EvCmdConOpenBoutiqueSelectMenu() { return false; }

        // TODO
        private bool EvCmdConOpenMatchingMenu() { return false; }

        // TODO
        private bool EvCmdConOpenResumeMatchingMenu() { return false; }

        // TODO
        private IEnumerator OpOpenSubContentsWindow<T>(UIWindowID windowID, Action<T> onCompletedLoad) { return null; }

        private bool EvCmdConWaitContestMenu()
        {
        	return !this._isOpenSubContentsMenu;
        }

        // TODO
        private bool EvCmdConMyEntryNumberWordSet() { return false; }

        // TODO
        private bool EvCmdConBestPerformerCheck() { return false; }

        // TODO
        private bool EvCmdConCategoryRibbonNameSet() { return false; }

        // TODO
        private bool EvCmdConHaveContestStarCheck() { return false; }

        // TODO
        private bool EvCmdConContestStarNameSet() { return false; }

        // TODO
        private bool EvCmdConRewardNameSet() { return false; }

        // TODO
        private bool EvCmdConTwinkleStarNameSet() { return false; }

        // TODO
        private bool EvCmdRewardShowMasterNameSet() { return false; }

        // TODO
        private bool EvCmdConCategoryAndRankSet() { return false; }

        private bool EvCmdConRankSet()
        {
        	return true;
        }

        // TODO
        private bool EvCmdConCheckEntryPoke() { return false; }

        // TODO
        private bool EvCmdConResetParameter() { return false; }

        // TODO
        private bool EvCmdConSelectSingleMode() { return false; }

        // TODO
        private bool EvCmdConSelectMultiMode() { return false; }

        // TODO
        private bool ExCmdImageClipViewConCheckProc() { return false; }

        private bool EvCmdPokeParkControl()
        {
        	return true;
        }

        private bool EvCmdPokeParkDepositCount()
        {
        	return true;
        }

        private bool EvCmdPokeParkTransMons()
        {
        	return true;
        }

        private bool EvCmdPokeParkGetScore()
        {
        	return true;
        }

        private bool EvCmdDendouBallAnm()
        {
        	return true;
        }

        // TODO
        private bool EvCmdInitFldLift() { return false; }

        // TODO
        private bool EvCmdMoveFldLift() { return false; }

        // TODO
        private bool EvCmdCheckFldLift() { return false; }

        private bool EvCmdSetupRAHCyl()
        {
        	return true;
        }

        private bool EvCmdStartRAHCyl()
        {
        	return true;
        }

        private bool EvCmdAddScore()
        {
        	return true;
        }

        private bool EvCmdAcceName()
        {
        	return true;
        }

        // TODO
        private bool EvCmdPartyMonsNoCheck() { return false; }

        // TODO
        private bool EvCmdPartyDeokisisuFormChange() { return false; }

        // TODO
        private bool EvCmdCheckMinomuchiComp() { return false; }

        private bool EvCmdPoketchHookSet()
        {
        	return true;
        }

        private bool EvCmdPoketchHookReset()
        {
        	return true;
        }

        private bool EvCmdSlotMachine()
        {
        	return true;
        }

        // TODO
        private bool EvCmdGetNowHour() { return false; }

        private bool EvCmdObjShakeAnm()
        {
        	return true;
        }

        private bool EvCmdObjBlinkAnm()
        {
        	return true;
        }

        // TODO
        private bool EvCmd_D20R0106Legend_IsUnseal() { return false; }

        private bool EvCmdDressingImcAcceCheck()
        {
        	return true;
        }

        private bool EvCmdTalkMsgUnknownFont()
        {
        	return true;
        }

        private bool EvCmdAgbCartridgeVerGet()
        {
        	return true;
        }

        private bool EvCmdUnderGroundTalkCountClear()
        {
        	return true;
        }

        private bool EvCmdHideMapStateChange()
        {
        	return true;
        }

        // TODO
        private bool EvCmdNameInStone() { return false; }

        // TODO
        private bool EvCmdMonumantName() { return false; }

        private bool EvCmdImcBgNameSet()
        {
        	return true;
        }

        private bool EvCmdCompCoin()
        {
        	return true;
        }

        private bool EvCmdSlotRentyanChk()
        {
        	return true;
        }

        private bool EvCmdAddCoinChk()
        {
        	return true;
        }

        // TODO
        private bool EvCmdLevelJijiiNo() { return false; }

        // TODO
        private bool EvCmdPokeLevelGet() { return false; }

        private bool EvCmdImcAcceSubItem()
        {
        	return true;
        }

        // TODO
        private bool EvCmdc08r0801ScopeCameraSet() { return false; }

        // TODO
        private bool EvCmdc08r0801ScopeSequence() { return false; }

        // TODO
        private bool EvCmdLevelJijiiInit() { return false; }

        private bool EvCmdNewNankaiWordSet()
        {
        	return true;
        }

        // TODO
        private bool EvCmdRegularCheck() { return false; }

        private bool EvCmdNankaiWordCompleteCheck()
        {
        	return true;
        }

        // TODO
        private bool EvCmdTemotiPokeContestStatusGet() { return false; }

        private bool EvCmdD17SystemMapSelect()
        {
        	return true;
        }

        private bool EvCmdUnderGroundToolGiveCount()
        {
        	return true;
        }

        private bool EvCmdUnderGroundKasekiDigCount()
        {
        	return true;
        }

        private bool EvCmdUnderGroundTrapHitCount()
        {
        	return true;
        }

        private bool EvCmdPofinAdd()
        {
        	return true;
        }

        private bool EvCmdPofinAddCheck()
        {
        	EvCmdPofinCheck();
        	return true;
        }

        // TODO
        private bool EvCmdIsHaihuEventEnable() { return false; }

        private bool EvCmdSodateyaPokeListSetProc()
        {
        	return true;
        }

        private bool EvCmdSodateyaPokeListGetResult()
        {
        	return true;
        }

        // TODO
        private bool EvCmdGetRandomHit() { return false; }

        private bool EvCmdUnderGroundTalkCount2()
        {
        	return true;
        }

        // TODO
        private bool EvCmdHidenEffStart() { return false; }

        private bool EvCmdZishin()
        {
        	return true;
        }

        private bool EvCmdBtlPointWinWrite()
        {
        	return true;
        }

        private bool EvCmdBtlPointWinDel()
        {
        	return true;
        }

        private bool EvCmdBtlPointWrite()
        {
        	return true;
        }

        private bool EvCmdCheckBtlPoint()
        {
        	return true;
        }

        private bool EvCmdAddBtlPoint()
        {
        	return true;
        }

        private bool EvCmdSubBtlPoint()
        {
        	return true;
        }

        private bool EvCmdCompBtlPoint()
        {
        	return true;
        }

        private bool EvCmdGetBtlPointGift()
        {
        	return true;
        }

        private bool EvCmdUgBallCheck()
        {
        	return true;
        }

        // TODO
        private bool EvCmdAusuItemCheck() { return false; }

        private bool EvCmdCheckMyGSID()
        {
        	return true;
        }

        private bool EvCmdGetFriendDataNum()
        {
        	return true;
        }

        private bool EvCmdGetCoinGift()
        {
        	return true;
        }

        private bool EvCmdSubWkCoin()
        {
        	return true;
        }

        private bool EvCmdCompWkCoin()
        {
        	return true;
        }

        private bool EvCmdAikotobaOkurimonoChk()
        {
        	return true;
        }

        private bool EvCmdWifiHusiginaokurimonoOpenFlagSet()
        {
        	return true;
        }

        private bool EvCmdUnionGetCardTalkNo()
        {
        	return true;
        }

        private bool EvCmdWirelessIconEasy()
        {
        	return true;
        }

        private bool EvCmdWirelessIconEasyEnd()
        {
        	return true;
        }

        private bool EvCmdSaveFieldObj()
        {
        	return true;
        }

        // TODO
        private bool EvCmdSealName() { return false; }

        private bool EvCmdSetEscapeLocation()
        {
        	return true;
        }

        private bool EvCmdFieldObjBitSetFellowHit()
        {
        	return true;
        }

        // TODO
        private bool EvCmdDameTamagoChkAll() { return false; }

        private bool EvCmdUnionBmpMenuStart()
        {
        	return true;
        }

        private bool EvCmdUnionBattleStartCheck()
        {
        	return true;
        }

        // TODO
        private bool EvCmdGetCardRank() { return false; }

        private bool EvCmdFieldScopeModeSet()
        {
        	return true;
        }

        private bool EvCmdFieldScopeModeReSet()
        {
        	return true;
        }

        // TODO
        private bool EvCmd_SET_TURN_HERO_FRAME() { return false; }

        // TODO
        private bool EvCmd_SET_TURN_OBJ_FRAME() { return false; }

        private bool EvCmd_DEBUG_PRINT()
        {
        	if (1 < this._evArg.Length) {
        	  return true;
        	}
        }

        // TODO
        private bool EvCmd_FADE_WAIT() { return false; }

        private bool EvCmd_HERO_MOVE_GRID_CENTER()
        {
        	CmdPlayerMoveGridCenter(this._evCommand);
        	return false;
        }

        // TODO
        private bool EvCmd_SET_POS_HERO_MATCH_X() { return false; }

        // TODO
        private bool EvCmd_SET_POS_HERO_MATCH_Z() { return false; }

        // TODO
        private bool EvCmd_GET_LANGUAGE() { return false; }

        private bool EvCmd__GET_REL_POS_HERO()
        {
        	CmdGetRelPosHero(this._evData);
        	return true;
        }

        private bool EvCmd__CAMERA_TARGET_HERO()
        {
            GameManager.fieldCamera.Target = EntityManager.activeFieldPlayer.transform;
            return true;
        }

        // TODO
        private bool EvCmd__CAMERA_TARGET_DUMMY() { return false; }

        // TODO
        private bool EvCmd_DUMMY_ANIME() { return false; }

        // TODO
        private bool EvCmd__DUMMY_ANIME_WAIT() { return false; }

        // TODO
        private bool EvCmd_DUMMY_SET_POS() { return false; }

        // TODO
        private bool EvCmd_DUMMY_SET_POS_HERO() { return false; }

        // TODO
        private bool EvCmd_SET_CUSTUM_WIN_MSBT() { return false; }

        // TODO
        private bool EvCmd_ADD_CUSTUM_WIN_LABEL() { return false; }

        // TODO
        private bool EvCmd_ADD_CUSTUM_WIN_LABEL_TWO_WINDOW() { return false; }

        private bool EvCmd_OPEN_CUSTUM_WIN()
        {
        	CustumWindow(this._evCommand);
        	return false;
        }

        // TODO
        private bool EvCmd_OPEN_CUSTUM_WIN_FIXED() { return false; }

        private bool EvCmd_VISIBLE_OBJ_PROP()
        {
        	CmdVisibleObjProp(this._evData,1);
        	return true;
        }

        private bool EvCmd_INVISIBLE_OBJ_PROP()
        {
        	CmdVisibleObjProp(this._evData);
        	return true;
        }

        private bool EvCmd_EVENT_CAMERA_MODE()
        {
        	return true;
        }

        private bool EvCmd_SET_EVENT_CAMERA_PARAM()
        {
        	return true;
        }

        private bool EvCmd_EVENT_CAMERA_WAIT()
        {
            return true;
        }

        private bool EvCmd_EVENT_CAMERA_FRAME()
        {
        	return true;
        }

        // TODO
        private bool EvCmd_HIT_DOOR_ANIME() { return false; }

        // TODO
        private bool EvCmd_HIT_DOOR_ANIME_WAIT() { return false; }

        // TODO
        private bool EvCmd_SET_DOOR_OBJ() { return false; }

        // TODO
        private bool EvCmdRotomuFormCheck()
        {
            int GetRotomuFormBitFlag(PokemonParam param) { return 0; }

            return false;
        }

        // TODO
        private bool EvCmdRotomuFormWazaChange() { return false; }

        // TODO
        private bool EvCmdTemotiRotomuFormChangeGet() { return false; }

        // TODO
        private bool EvCmdTemotiPokeChkNum()
        {
            // TODO
            bool CheckDuplicate() { return false; }

            return false;
        }

        // TODO
        private bool EvCmdTemotiRotomuFormNoGet() { return false; }

        // TODO
        private bool EvCmdEventGetTemotiPokeChkGetPos() { return false; }

        private bool EvCmd_TURN_HERO_TALK_OBJ()
        {
        	Turn_HeroToHitObject();
        	return true;
        }

        // TODO
        private bool EvCmd_FADE_SPEED() { return false; }

        private bool EvCmd_FADE_BALL()
        {
        	return true;
        }

        private bool EvCmd_FADE_DEFAULT()
        {
        	return true;
        }

        // TODO
        private bool EvCmd_DOOR_FORCE_ANIME_END() { return false; }

        // TODO
        private bool EvMacro_LDVAL_VERSION() { return false; }

        // TODO
        private bool EvMacro_LDVAL_SEX() { return false; }

        // TODO
        private bool EvCmd_DEBUG_RESET_WORK() { return false; }

        private bool EvCmd_SET_SYS_FLAG()
        {
            SetSysFlag(_evArg[1].data, true);
            return true;
        }

        private bool EvCmd_RESET_SYS_FLAG()
        {
            SetSysFlag(_evArg[1].data, false);
            return true;
        }

        // TODO
        private bool EvCmd_CAMERA_SET_COS_ANGLE() { return false; }

        private bool EvCmd_CAMERA_COS_ANGLE_WAIT()
        {
            return true;
        }

        private bool EvCmd_HERO_MOVE_GRID_CENTER_FRONT()
        {
        	HeroMoveGridCenterFront(this._deltatime);
        	return false;
        }

        // TODO
        private bool EvCmd_WARP_ENABLE_SET() { return false; }

        // TODO
        private bool EvCmd_DOOR_ENABLE_SET() { return false; }

        // TODO
        private bool EvCmd_AC_ANIM_LOCK() { return false; }

        // TODO
        private bool EvCmd_AC_ANIM_RELEASE() { return false; }

        private bool EvCmd_CAMERA_SET_OFFSET()
        {
            // The results of these are ignored.
            if (_evArg[1].argType == EvData.ArgType.Work)
                FlagWork.GetWork(_evArg[1].data);
            if (_evArg[2].argType == EvData.ArgType.Work)
                FlagWork.GetWork(_evArg[2].data);
            if (_evArg[3].argType == EvData.ArgType.Work)
                FlagWork.GetWork(_evArg[3].data);
            if (_evArg[4].argType == EvData.ArgType.Work)
                FlagWork.GetWork(_evArg[4].data);

            return true;
        }

        private bool EvCmd_CAMERA_OFFSET_WAIT()
        {
        	return true;
        }

        // TODO
        private bool EvCmdNaminoriEnd() { return false; }

        // TODO
        private bool EvCmdTakikudari() { return false; }

        // TODO
        private bool EvCmdKabeNoboriCheck() { return false; }

        // TODO
        private bool EvCmdTalkPokeGetTemotiIndex() { return false; }

        // TODO
        private bool EvCmdNaturalParkGetMonohiroiItemNo() { return false; }

        private bool EvCmdNaturalParkPokeCreate()
        {
            var manager = FureaiManager.Instance;
            var obj = FlagWork.GetWork((EvWork.WORK_INDEX)_evArg[1].data);

            if (manager.isCanCreatePoke)
                manager._EnterHirobaCreate.Invoke((uint)obj);

            return !manager.isCreatingPoke;
        }

        // TODO
        private bool EvCmdNaturalParkPokeKaisan() { return false; }

        // TODO
        private bool EvCmdNaturalParkPokeSyuugou() { return false; }

        // TODO
        private bool EvCmdNaturalParkPokeSelectMenu() { return false; }

        // TODO
        private bool EvCmdObjAnimeFureai() { return false; }

        // TODO
        private FieldEventEntity FindEventEntity(string name) { return null; }

        // TODO
        private FieldEventEntity FindEventDoorEntity(string name) { return null; }

        private bool HeroMoveGridCenterFront(float deltaTime)
        {
            var player = EntityManager.activeFieldPlayer;

            _fieldObjectMove.Update(deltaTime);
            _fieldObjectRotateYaw.Update(deltaTime);

            if (!_heroMoveGridCenterFrontStat)
            {
                if (_heroMoveGridCenterFrontDir == DIR.DIR_NOT)
                    _heroMoveGridCenterFrontDir = player.GetDir();

                var tilePos = FieldObjectEntity.GridToPosition(player.gridPosition);

                var x = player.worldPosition.x;
                var y = player.worldPosition.y;
                var z = player.worldPosition.z;

                var vec = new Vector3();
                float angle = 0.0f;

                switch (_heroMoveGridCenterFrontDir)
                {
                    case DIR.DIR_UP:
                        vec.x = x;
                        vec.y = y;
                        vec.z = tilePos.y;
                        angle = 180.0f;
                        break;

                    case DIR.DIR_DOWN:
                    default:
                        vec.x = x;
                        vec.y = y;
                        vec.z = tilePos.y;
                        angle = 0.0f;
                        break;

                    case DIR.DIR_LEFT:
                        vec.x = tilePos.x;
                        vec.y = y;
                        vec.z = z;
                        angle = 90.0f;
                        break;

                    case DIR.DIR_RIGHT:
                        vec.x = tilePos.x;
                        vec.y = y;
                        vec.z = z;
                        angle = 270.0f;
                        break;
                }

                _fieldObjectMove.SetObjectEntity(player);
                _fieldObjectMove.MoveSpeed(vec, DataManager.GetFieldCommonParam(ParamIndx.WalkSpd));
                _fieldObjectMove.Update(deltaTime);

                _fieldObjectRotateYaw.SetObjectEntity(player);
                _fieldObjectRotateYaw.MoveTime(angle, 0.1f);
                _fieldObjectRotateYaw.Update(deltaTime);

                player.PlayWalk();

                _heroMoveGridCenterFrontStat = true;
            }

            if (!_fieldObjectMove.IsBusy && !_fieldObjectRotateYaw.IsBusy)
            {
                player.PlayIdle();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool BoardReq()
        {
            switch (_talkStart)
            {
                case TalkState.Init:
                    _talkStart = TalkState.EndWait;
                    switch (_boardState)
                    {
                        case BOARD.BOARD_REQ_ADD:
                        case BOARD.BOARD_REQ_UP:
                            OpenTalk(_msgOpenParam);
                            return false;

                        case BOARD.BOARD_REQ_DOWN:
                        case BOARD.BOARD_REQ_DEL:
                            CloseMsg();
                            return false;
                    }
                    break;

                case TalkState.EndWait:
                    switch (_boardState)
                    {
                        case BOARD.BOARD_REQ_ADD:
                        case BOARD.BOARD_REQ_UP:
                            if (_msgWindow.MsgState == MsgWindowDataModel.MsgWindowState.FinishedOpen)
                                _boardState = BOARD.BOARD_REQ_WAIT;
                            break;

                        case BOARD.BOARD_REQ_DOWN:
                        case BOARD.BOARD_REQ_DEL:
                            if (_msgWindow.MsgState == MsgWindowDataModel.MsgWindowState.Inactive)
                                _boardState = BOARD.BOARD_REQ_WAIT;
                            break;
                    }
                    break;
            }

            if (_boardState != BOARD.BOARD_REQ_WAIT)
                return false;

            _talkStart = TalkState.Init;
            return true;
        }

        private bool BoardEndWait(EvWork.WORK_INDEX work)
        {
            if (_msgWindow == null)
                return true;

            if (_msgWindowCoroutine != null)
                return false;

            if (FieldInput.PushAB() || GameController.analogStickL != Vector2.zero)
            {
                FlagWork.SetWork(work, 1);
                return true;
            }

            if (FieldInput.PushX())
            {
                FlagWork.SetWork(work, 0);
                return true;
            }

            return false;
        }

        // TODO
        private Vector3 ArgPosToPosition(int gx, int gy, int gz) { return Vector3.zero; }

        // TODO
        private bool CheckValidPokemonParam(PokemonParam param) { return false; }

        // TODO
        private bool CheckCanBattlePokemonParam(PokemonParam param) { return false; }

        // TODO
        private int GetPokemonFormNo(PokemonParam param) { return 0; }

        // TODO
        private void TemotiBoxScan(Action<PokemonParam> action) { }

        // TODO
        private void TemotiBoxScan(Func<PokemonParam, int, int, bool> action) { }

        // TODO
        private void BoxScan(Action<PokemonParam> action) { }

        // TODO
        private void BoxScan(Func<PokemonParam, int, int, bool> action) { }

        // TODO
        private int GetOriginalCassetVersion() { return 0; }

        // TODO
        private DIR SetupHeroMoveGridCenterFrontDir(in RectInt stopGridArea, in Vector2Int nowGrid, in Vector2Int oldGrid) { return DIR.DIR_NOT; }

        // TODO
        private static bool InGridArea(in RectInt area, int x, int y) { return false; }

        // TODO
        private bool EvCmdShopOpen() { return false; }

        private bool EvCmdShopOpenWait()
        {
        	return !this._isShopOpen;
        }

        // TODO
        private bool EvCmdDoorTransitionZoneSet() { return false; }

        // TODO
        private bool EvCmdMoveCombatGymWall() { return false; }

        // TODO
        private bool EvCmdEventEntityPlayerMoveStart() { return false; }

        // TODO
        private bool EvCmdEventEntityPlayerMoveEnd() { return false; }

        // TODO
        private bool EvCmdEventEntityPlayerMoveReset() { return false; }

        // TODO
        public bool CheckCanSeedWater(int groupId) { return false; }

        // TODO
        private bool EvCmdCheckCanSeedWater() { return false; }

        // TODO
        private bool EvCmdOpenFixedShop() { return false; }

        // TODO
        private bool EvCmdOpenSealShop() { return false; }

        // TODO
        private bool EvCmdOpenBattleParkShop() { return false; }

        // TODO
        private bool EvCmdOpenTobari4fShop() { return false; }

        // TODO
        private bool EvCmdOpenFlowerShop() { return false; }

        // TODO
        private bool EvCmdOpenOtenkiShop() { return false; }

        // TODO
        private bool EvCmdOpenPalParkShop() { return false; }

        // TODO
        private bool EvCmdOpenSellShop() { return false; }

        // TODO
        private bool EvCmdOpenBoutiqueShopBuy() { return false; }

        // TODO
        private bool EvCmdOpenBoutiqueShopChange() { return false; }

        // TODO
        private bool EvCmdOpenFloor() { return false; }

        // TODO
        private bool EvCmdCloseFloor() { return false; }

        // TODO
        private bool EvCmdOpenMoney() { return false; }

        // TODO
        private bool EvCmdCloseMoney() { return false; }

        // TODO
        private bool EvCmdGetCostume() { return false; }

        // TODO
        private bool EvCmdAnawohoru() { return false; }

        // TODO
        private bool EvCmdAnanukenohimo() { return false; }

        // TODO
        private bool EvCmdTeleport() { return false; }

        // TODO
        private bool EvCmdAmaikaori() { return false; }

        // TODO
        private bool EvCmdAmaimitu() { return false; }

        // TODO
        private bool NeckRotateHero() { return false; }

        // TODO
        private bool NeckOnlyRotateHero() { return false; }

        // TODO
        private bool NeckRotateTarget(bool isTurnNotFlag) { return false; }

        private bool CalcNeckRotateAngle(FieldCharacterEntity player, ref Vector3 tPos, out float angle)
        {
            var playerAngle = player.yawAngle;
            var playerWorld = player.worldPosition;

            _ = player.transform.forward;

            var diff = tPos - playerWorld;
            diff.Normalize();

            angle = FieldCalc.DiffAngle(playerAngle, Quaternion.LookRotation(diff).eulerAngles.y);

            if (angle <= -45.0f)
            {
                angle = -45.0f;
                return false;
            }

            if (angle >= 45.0f)
            {
                angle = 45.0f;
                return false;
            }

            return true;
        }

        // TODO
        private bool EvCmdWarpStartAnimation() { return false; }

        // TODO
        private bool EvCmdWarpEndAnimation() { return false; }

        // TODO
        private bool EvCmdSafariScopeSequence() { return false; }

        private bool EvCmdEventCameraIndex()
        {
            int index = GetArgInt(_evArg[1]);

            GameManager.fieldCamera.EventCamera.SetCameraData(_evCameraTable, index);
            return true;
        }

        // TODO
        private bool EvCmdEventCameraEndWait() { return false; }

        // TODO
        private bool EvCmdAzukariyaExistEgg() { return false; }

        // TODO
        private bool EvCmdAzukariyaStoredCount() { return false; }

        // TODO
        private bool EvCmdAzukariyaSetStoredName() { return false; }

        // TODO
        private bool EvCmdAzukariyaStoreUI() { return false; }

        // TODO
        private bool EvCmdAzukariyaStore() { return false; }

        // TODO
        private bool EvCmdAzukariyaRestore() { return false; }

        // TODO
        private bool EvCmdAzukariyaLoveLevel() { return false; }

        // TODO
        private bool EvCmdAzukariyaGetStoredMonsNo() { return false; }

        // TODO
        private bool EvCmdAzukariyaGetEgg() { return false; }

        // TODO
        private bool EvCmdAzukariyaDiscardEgg() { return false; }

        // TODO
        private bool EvCmdAzukariyaSetStoredInfoStr() { return false; }

        // TODO
        private bool EvCmdAzukariyaGetStoredSex() { return false; }

        // TODO
        private bool EvCmdAzukariyOldmanInit() { return false; }

        // TODO
        private bool EvCmd_ADD_CUSTUM_WIN_LABEL_WORD_SET() { return false; }

        private bool EvCmd_OPEN_CUSTUM_WIN_WORD_SET()
        {
        	CustumWindow(this._evCommand,1);
        	return false;
        }

        // TODO
        private bool EvCmd_BTL_ENCSEQ_LOAD() { return false; }

        // TODO
        private bool EvCmd_UseSpray() { return false; }

        // TODO
        private bool EvCmd_GET_PLAYER_CAP() { return false; }

        // TODO
        private bool EvCmdCameraShake() { return false; }

        // TODO
        private bool EvCmdEventEntityClipPlay() { return false; }

        // TODO
        private bool EvCmdEventEntityClipWait() { return false; }

        // TODO
        private bool EvCmdEventEntityAttachPlayer() { return false; }

        // TODO
        private bool EvCmdEventEntityVisible() { return false; }

        // TODO
        private bool EvCmd_FACE_INDEX() { return false; }

        // TODO
        private bool EvCmd_GROUP_EXIST_CHECK() { return false; }

        // TODO
        private bool EvCmd_GROUP_ENTRY_CHECK() { return false; }

        // TODO
        private bool EvCmd_GROUP_NAME() { return false; }

        // TODO
        private bool EvCmd_GROUP_LEADER_NAME() { return false; }

        // TODO
        private bool EvCmd_GROUP_NAME_IN() { return false; }

        // TODO
        private bool EvCmd_GROUP_ENTRY() { return false; }

        // TODO
        private bool EvCmd_GROUP_MAKE() { return false; }

        // TODO
        private bool EvCmdTemotiBallLoad() { return false; }

        // TODO
        private bool EvCmdTemotiBallLoadWait() { return false; }

        // TODO
        private bool EvCmdPokecenPutBall() { return false; }

        // TODO
        private bool EvCmdPokecenClearBall() { return false; }

        // TODO
        private bool EvCmd_CHARA_LOOK_LOCK() { return false; }

        // TODO
        private bool EvCmd_CHARA_LOOK_RELEASE() { return false; }

        private bool EvCmd_TALK_OBJ_START_LOOK_NONE()
        {
        	if ((int)this._procCmd != 0x8e) {
        	  if ((int)this._procCmd == 0x6d) {
        	    PlaySe(StringLiteral_9145);
        	    this._procCmd = (NAME)0x8e;
        	    return false;
        	  }
        	  this._procCmd = (NAME)0x6d;
        	  return false;
        	}
        	Cmd_ObjPauseAll();
        	this._procCmd = (NAME)0;
        	return true;
        }

        // TODO
        private bool EvCmdBoukennootoTipsOpen() { return false; }

        private bool EvCmdBoukennootoTipsOpenWait()
        {
        	return !this._boukennootoTipsOpen;
        }

        // TODO
        private bool EvCmdOpenSpecialWinLabel() { return false; }

        // TODO
        private bool EvCmdWaitSpecialWinLabel() { return false; }

        private bool EvCmdHidenEffWait()
        {
        	return this._hidenEffectWait;
        }

        // TODO
        private bool EvCmd_GET_URAYAMA_ENCOUNT_INDEX() { return false; }

        // TODO
        private bool EvCmd_CUSTOM_BALL_NUM_ADD() { return false; }

        // TODO
        private bool EvCmd_CHANGE_FASHION_REQ() { return false; }

        // TODO
        private bool EvCmdWarpPanelStart() { return false; }

        // TODO
        private bool EvCmdWarpPanelEnd() { return false; }

        // TODO
        private bool EvCmdOpenPasswordSWKeyboard() { return false; }

        // TODO
        private bool EvCmdSetMatchingGroup() { return false; }

        // TODO
        private bool EvCmdCheckOnlineAccount() { return false; }

        // TODO
        private bool EvCmdCheckGMSOnlineAccount() { return false; }

        private bool EvCmdWaitCheckOnlineAccount()
        {
        	return this._isWaitCheckOnlineAccount;
        }

        // TODO
        private bool EvCmdGMSEnd() { return false; }

        // TODO
        private bool EvCmd_DENDOU_NUM_SET() { return false; }

        // TODO
        private bool EvCmdTemotiBoxPokeChk()
        {
            bool CheckMonsNo(PokemonParam param, MonsNo monsNo) { return false; }

            return false;
        }

        // TODO
        private bool EvCmdTemotiBoxMonsNo() { return false; }

        // TODO
        private PokemonParam GetPokemonParam(int trayIndex, int index) { return null; }

        // TODO
        private bool EvCmdCallWazaOmoidashiUi() { return false; }

        // TODO
        private bool EvCmdCallWazaWasureUi() { return false; }

        // TODO
        private bool EvCmdCallWazaOshieUi() { return false; }

        // TODO
        private bool CallWazaUiCommon(UIWazaManage.BootType bootType, PokemonParam pokemonParam, Action<WazaNo, WazaNo> resultCallback, WazaNo oshieWazaNo = WazaNo.NULL) { return false; }

        // TODO
        private void LearnWaza(PokemonParam param, WazaNo learnWazaNo, WazaNo unlearnWazaNo) { }

        // TODO
        private bool EvCmdCheckWazaOshie() { return false; }

        // TODO
        private bool EvCmdCheckWazaOshieAll() { return false; }

        // TODO
        private WazaOshieResult CheckWazaOshie(PokemonParam param, WazaNo oshieWazaNo) { return WazaOshieResult.OK; }

        // TODO
        private bool EvCmdTemotiBoxPokemonName() { return false; }

        private bool EvCmd_BTWR_TOOL_CHK_ENTRY_POKE_NUM()
        {
        	return true;
        }

        // TODO
        private bool EvCmd_BTWR_TOOL_CLEAR_PLAY_DATA() { return false; }

        // TODO
        private bool EvCmd_BTWR_TOOL_PUSH_NOW_LOCATION() { return false; }

        // TODO
        private bool EvCmd_BTWR_TOOL_POP_NOW_LOCATION() { return false; }

        private bool EvCmd_BTWR_TOOL_GET_WIFI_RANK()
        {
        	return true;
        }

        // TODO
        private bool EvCmd_BTWR_TOOL_SET_PLAY_MODE() { return false; }

        // TODO
        private bool EvCmd_BTWR_TOOL_SET_NOW_WIN() { return false; }

        // TODO
        private bool EvCmd_BTWR_TOOL_SET_RANK() { return false; }

        // TODO
        private bool EvCmd_BTWR_SUB_GET_RANK() { return false; }

        // TODO
        private bool EvCmd_BTWR_SUB_RANK_DOWN_LOSE() { return false; }

        // TODO
        private bool EvCmd_BTWR_SUB_RANK_DOWN_LOSE_RESET() { return false; }

        // TODO
        private bool EvCmd_BTWR_SUB_ADD_LOSE() { return false; }

        private bool EvCmd_BTWR_SUB_CHK_ENTRY_POKE()
        {
        	return true;
        }

        // TODO
        private bool EvCmd_BTWR_SUB_GET_NOW_ROUND() { return false; }

        // TODO
        private bool EvCmd_BTWR_SUB_INC_ROUND() { return false; }

        // TODO
        private bool EvCmd_BTWR_SUB_IS_CLEAR() { return false; }

        // TODO
        private bool EvCmd_BTWR_SUB_GET_RENSHOU_CNT() { return false; }

        // TODO
        private bool EvCmd_BTWR_SUB_SET_SCORE() { return false; }

        private bool EvCmd_BTWR_SUB_CHOICE_BTL_PARTNER()
        {
        	return true;
        }

        // TODO
        private bool EvCmd_BTWR_SUB_LOCAL_BTL_CALL() { return false; }

        // TODO
        private bool EvCmd_BTWR_SUB_GET_PLAY_MODE() { return false; }

        private bool EvCmd_BTWR_SUB_SET_LEADER_CLEAR_FLAG()
        {
        	return true;
        }

        private bool EvCmd_BTWR_SUB_GET_LEADER_CLEAR_FLAG()
        {
        	return true;
        }

        // TODO
        private bool EvCmd_BTWR_SUB_ADD_BATTLE_POINT() { return false; }

        // TODO
        private bool EvCmd_BTWR_SUB_RENSHOU_RIBBON_SET() { return false; }

        private bool EvCmd_BTWR_SUB_GET_MINE_OBJ()
        {
        	return true;
        }

        // TODO
        private bool EvCmd_BTWR_SUB_UPDATE_RANDOM() { return false; }

        private bool EvCmd_BTWR_DEB_IS_WORK_NULL()
        {
        	return true;
        }

        private bool EvCmd_BTWR_SUB_BTL_TRAINER_SET()
        {
        	return true;
        }

        // TODO
        private bool EvCmd_BTWR_PLAYER_WIN_CHECK() { return false; }

        // TODO
        private bool EvCmd_BTWR_SUB_ADD_BATTLE_POINT_MANUAL() { return false; }

        // TODO
        private bool EvCmdSaveRendouEnable() { return false; }

        // TODO
        private bool EvCmd_RETURN_LOOP() { return false; }

        // TODO
        private bool EvCmd_INPUT_JUMP() { return false; }

        // TODO
        private bool EvCmd_SET_VISIBILITY() { return false; }

        // TODO
        private void ChangeVisibility(FieldCharacterEntity entity, int type, bool flag) { }

        // TODO
        private bool EvCmd_LOAD_CAMERA_CONTROLLER() { return false; }

        // TODO
        private bool EvCmd_RELEASE_CAMERA_CONTROLLER() { return false; }

        // TODO
        private bool EvCmd_LOAD_WAIT_CAMERA_CONTROLLER() { return false; }

        private bool EvCmd_CAMERA_CONTROLLER_PLAY()
        {
            string statename = GetArgString(_evData, _evArg[1]);

            FieldAnimeCamera.instance.Play(statename);
            return true;
        }

        // TODO
        private bool EvCmd_CAMERA_CONTROLLER_WAIT() { return false; }

        // TODO
        private bool EvCmd_CAMERA_CONTROLLER_END() { return false; }

        // TODO
        private bool EvCmd_TUREARUKI_POKEMON_TALK() { return false; }

        // TODO
        private bool EvCmd_TUREARUKI_POKEMON_INDEX() { return false; }

        // TODO
        private bool EvCmd_TUREARUKI_TAKE_ITEM() { return false; }

        private bool EvCmd_TUREARUKI_ITEM_TIMER_SET()
        {
        	return true;
        }

        // TODO
        private bool EvCmd_TUREARUKI_POKE_CREATE() { return false; }

        // TODO
        private bool EvCmd_TUREARUKI_POKE_DELETE() { return false; }

        // TODO
        private bool EvCmd_FIND_BG_ENABLE() { return false; }

        // TODO
        private bool EvCmd_FIND_BG_DISABLE() { return false; }

        // TODO
        private bool EvCmd_CALL_EFFECT() { return false; }

        // TODO
        private bool EvCmd_STOP_EFFECT() { return false; }

        // TODO
        public bool EvCmd_RELEASE_EFFECT() { return false; }

        // TODO
        private bool EvCmd_CALL_EFFECT_OBJ() { return false; }

        // TODO
        private bool EvCmd_EFF_SCALE() { return false; }

        // TODO
        private IEnumerator EffScaleAnime(int index, float min, float max, float spd) { return null; }

        // TODO
        private bool EvCmd_POKELIST_FORM_CHANGE_SET_PROC() { return false; }

        // TODO
        private bool EvCmd_POKELIST_FORM_CHANGE_GET_RESULT() { return false; }

        // TODO
        private bool EvCmd_CASSET_VERSION_GET() { return false; }

        // TODO
        private bool EvCmd_BOX_OPEN_NORMAL() { return false; }

        // TODO
        private bool EvCmd_BOX_OPEN_SELECT() { return false; }

        // TODO
        private bool EvCmd_AK_LISNER_TRA() { return false; }

        // TODO
        private bool EvCmd_AK_LISNER_POS() { return false; }

        // TODO
        private bool EvCmd_AK_LISNER_ROT() { return false; }

        // TODO
        private bool EvCmd_SET_TV_INT() { return false; }

        // TODO
        private bool EvCmd_SET_TV_PLAYER_NAME() { return false; }

        // TODO
        private bool EvCmd_SET_TV_POKE_NICK_NAME() { return false; }

        // TODO
        private bool EvCmd_TV_TPIC_ENABLE() { return false; }

        // TODO
        private bool EvCmd_TV_TPIC_BRANCH() { return false; }

        // TODO
        private bool EvCmd_AUTO_TANKEN_SET() { return false; }

        private bool EvCmd_AUTO_TANKEN_SET_WAIT()
        {
        	var iVar1 = FlagWork.GetWork(0xf2);
        	if (iVar1 == 1) {
        	  FlagWork.SetWork(0xf2,0);
        	  return true;
        	}
        	return false;
        }

        // TODO
        private bool EvCmd_USE_TANKENSET() { return false; }

        // TODO
        private bool EvCmd_LOCALKOUKAN_APPLY() { return false; }

        // TODO
        private bool EvCmd_ZUKAN_TOUROKU() { return false; }

        private bool EvCmd_ZUKAN_TOUROKU_WAIT()
        {
        	var iVar1 = FlagWork.GetWork(0xf2);
        	if (iVar1 == 1) {
        	  FlagWork.SetWork(0xf2,0);
        	  return true;
        	}
        	return false;
        }

        // TODO
        private bool EvCmd_CHK_ZUKAN_TOUROKU() { return false; }

        // TODO
        private bool EvCmd_AUTO_SAVE() { return false; }

        // TODO
        private bool EvCmd_AUTO_SAVE_BACK_UP_ON() { return false; }

        // TODO
        private bool EvCmd_ENDING_DEMO() { return false; }

        // TODO
        private bool EvCmdAzukariyaTakeOverPoke() { return false; }

        // TODO
        private bool EvCmd_TALK_UNION_NPC() { return false; }

        // TODO
        private bool EvCmd_TALK_COLISEUM_NPC() { return false; }

        // TODO
        private bool EvCmd_POKETORE_GET_CHARGE() { return false; }

        // TODO
        private bool EvCmd_POKETORE_START() { return false; }

        // TODO
        private bool EvCmd_BICYCLE_COLOR_SET() { return false; }

        // TODO
        private bool EvCmd_BICYCLE_COLOR_GET() { return false; }

        // TODO
        private bool EvCmd_PARK_ITEM_NAME() { return false; }

        // TODO
        private bool EvCmd_LOAD_UMA_ANIME() { return false; }

        // TODO
        private IEnumerator LoadUMAAsset() { return null; }

        // TODO
        private bool EvCmd_RELEASE_UMA_ANIME() { return false; }

        // TODO
        private bool EvCmd_LOAD_UMA_ANIME_WAIT() { return false; }

        // TODO
        private bool EvCmd_UMA_ANIME_PLAY() { return false; }

        // TODO
        private bool EvCmd_UMA_ANIME_ATTACH() { return false; }

        // TODO
        private bool EvCmd_UMA_PLAY_WAIT() { return false; }

        // TODO
        private bool EvCmd_OBJ_ANIME_SPEED() { return false; }

        // TODO
        private bool EvCmd_OBJ_SCALE() { return false; }

        // TODO
        private bool EvCmd_BADGE_GET() { return false; }

        // TODO
        private bool EvCmdAddUgItem() { return false; }

        // TODO
        private bool EvCmd_DOF_FAR_DEPTH() { return false; }

        private bool EvCmd_DISPLAY_MESSAGE()
        {
            if (_evArg.Length < 2)
            {
                FieldCanvas.RedGyaradosMessage(true);
                FieldCanvas.ShowDisplayMessage("100-msg_telop_01", "dp_scenario3");
            }
            else
            {
                string[] label = GetArgString(_evData, _evArg[1]).Split(new char[1] { '%' });
                FieldCanvas.RedGyaradosMessage(false);
                FieldCanvas.ShowDisplayMessage(label[1], label[0]);
            }
            
            return true;
        }

        private bool EvCmd_DISPLAY_MESSAGE_CLOSE()
        {
            FieldCanvas.CloseDisplayMessage();
            return true;
        }

        // TODO
        private bool EvCmdCustomBallTrainerPage() { return false; }

        // TODO
        private bool EvCmdCustomBallTrainerCopyOpen() { return false; }

        // TODO
        private bool EvCmdUgItemName() { return false; }

        // TODO
        private bool EvCmdFureaiTalkStart() { return false; }

        private bool EvCmdFureaiTalkEnd()
        {
        	return true;
        }

        // TODO
        private bool EvCmdPlayFureaiVoiceNakayoshiRank() { return false; }

        // TODO
        private bool EvCmdCreateHyouta() { return false; }

        // TODO
        private bool EvCmd_FADE_DUNGEON_OUT() { return false; }

        // TODO
        private bool EvCmd_FADE_DUNGEON_IN() { return false; }

        // TODO
        private bool EvCmd_FADE_BUILDING_OUT() { return false; }

        // TODO
        private bool EvCmd_FADE_BUILDING_IN() { return false; }

        // TODO
        private bool EvCmd_FADE_AREA_OUT() { return false; }

        // TODO
        private bool EvCmd_FADE_AREA_IN() { return false; }

        private bool EvCmdCustomBallTrainerOpenWait()
        {
        	return !this._isOpenCustomBallTrainer;
        }

        // TODO
        private bool EvCmd_EMBANKMENT() { return false; }

        // TODO
        private bool EvCmdEntryUwasaZukan() { return false; }

        // TODO
        private bool EvCmdTrainingOpen() { return false; }

        // TODO
        private bool EvCmdTrainingOpenWait() { return false; }

        // TODO
        private bool EvCmdTalkUgNpc() { return false; }

        // TODO
        private bool EvCmd_CAMERA_CONTROLLER_IS_NULL() { return false; }

        // TODO
        private bool EvCmd_UMA_IS_NULL() { return false; }

        // TODO
        private bool EvCmdGetIsHaveSecretBase() { return false; }

        // TODO
        private bool EvCmdGetUgNpcTalkCount() { return false; }

        // TODO
        private bool EvCmdResetUgNpcTalkCount() { return false; }

        // TODO
        private bool EvCmd_TEMOTI_POKE_CHK_GET_POS() { return false; }

        // TODO
        private bool EvCmd_SET_FORCE_BLINK() { return false; }

        // TODO
        private bool EvCmd_CheckSecretBaseExpantion() { return false; }

        private bool EvCmd_END_LIGHTINTENSITY()
        {
        	if (this._isRunningLight.Length != 0) {
        	  return this._isRunningLight[0] == 0;
        	}
        }

        // TODO
        private bool EvCmd_END_LIGHTINTENSITY_CHARCTER() { return false; }

        // TODO
        private bool EvCmd_END_LIGHTINTENSITY_POKE() { return false; }

        // TODO
        private bool EvCmd_SET_LIGHTINTENSITY() { return false; }

        // TODO
        private bool EvCmd_SET_LIGHTINTENSITY_CHARCTER() { return false; }

        // TODO
        private bool EvCmd_SET_LIGHTINTENSITY_POKE() { return false; }

        // TODO
        private void EnvironmentControllerSetLight(EnvironmentController controller, float deltaTime) { }

        // TODO
        private void EnvironmentControllerSetLightCharacter(EnvironmentController controller, float deltaTime) { }

        // TODO
        private void EnvironmentControllerSetLightPoke(EnvironmentController controller, float deltaTime) { }

        // TODO
        private bool EnviromentLightUpdate(int index, float deltaTime, out float ret)
        {
            ret = 0.0f;
            return false;
        }

        private bool EvCmd_TV_RED_GYARADOS_ON()
        {
            var entity = FieldTvRedGyaradosEntity.GetTvRedGyarados();

            if (entity != null)
                entity.SetActive(true);

            return true;
        }

        // TODO
        private bool EvCmd_TV_RED_GYARADOS_OFF() { return false; }

        // TODO
        private bool EvCmd_AUTO_MSG() { return false; }

        private bool EvCmd_AUTO_MSG_STOP()
        {
        	this._isAutoMsg = false;
        	return true;
        }

        // TODO
        private bool EvCmd_GET_TAG_PATNER_ID() { return false; }

        // TODO
        private bool EvCmd_UNIQUE_POKE_TEMP() { return false; }

        // TODO
        private bool EvCmd_UNIQUE_POKE_FIX() { return false; }

        // TODO
        private bool EvCmd_NICKNAME_PLACEMENT() { return false; }

        // TODO
        private bool EvCmd_GET_FORM() { return false; }

        // TODO
        private void CreateTurearuki() { }

        // TODO
        private void DeleteTurearuki() { }

        // TODO
        private bool EvCmd_NICK_NAME_ALL() { return false; }

        // TODO
        private bool EvCmd_DOF_CHANGE_TARGET_POS() { return false; }

        // TODO
        private bool EvCmd_DOF_RESET_TARGET_POS() { return false; }

        // TODO
        private bool EvCmd_ADD_MAROYAKA_POFFIN() { return false; }

        // TODO
        private bool EvCmd_ALL_MONSNO() { return false; }

        // TODO
        private bool EvCmd_ALL_MONS_OWN_CHK() { return false; }

        // TODO
        private bool EvCmd_POKE_LVUP_HOW_MANY() { return false; }

        // TODO
        private bool EvCmd_USE_SPECIAL_ITEM() { return false; }

        // TODO
        private bool EvCmd_GET_BP() { return false; }

        // TODO
        private bool EvCmd_FOV_OFFSET_RATE() { return false; }

        // TODO
        private bool EvCmd_USE_SUB_ATTRIBUTE() { return false; }

        // TODO
        private bool EvCmd_POKE_LEVEL_GET_ALL() { return false; }

        // TODO
        private bool EvCmd_RESET_SAVEBGM() { return false; }

        // TODO
        private bool EvCmd_BTWR_SUB_SELECT_POKE() { return false; }

        // TODO
        private bool EvCmd_BTWR_SUB_GET_ENTRY_POKE() { return false; }

        // TODO
        private bool EvCmd_SET_GLOBALWATERFIELD() { return false; }

        // TODO
        private bool EvCmd_GET_STATUENUM() { return false; }

        // TODO
        private bool EvCmdGetFureaiSelectPokeTemotiNo() { return false; }

        // TODO
        private bool EvCmd_POKE_TARENT_POW_MAX() { return false; }

        // TODO
        private bool EvCmd_OPEN_BATTLE_WIN() { return false; }

        // TODO
        private IEnumerator LoadBattleWindow(Action onLoad) { return null; }

        // TODO
        private void OpenBattleWindow()
        {
            // TODO
            void OnSelectChoices(int i) { }
        }

        // TODO
        private bool EvCmd_OJIGI() { return false; }

        // TODO
        private bool OjibiCallback(AnimationPlayer anime) { return false; }

        // TODO
        private bool EvCmdSavePlayReport() { return false; }

        private bool EvCmd_SET_STOP_EYE_ENCOUNT()
        {
        	FlagWork.SetSysFlag(0x3c4,1);
        	return true;
        }

        private bool EvCmd_RESET_STOP_EYE_ENCOUNT()
        {
        	FlagWork.SetSysFlag(0x3c4,0);
        	return true;
        }

        // TODO
        private bool EvCmd_PLAY_REPORT_TRAINING() { return false; }

        // TODO
        private bool EvCmd_PLAY_REPORT_BTLTOWER_WIN() { return false; }

        // TODO
        private bool EvCmd_GET_RECORD_TOWOR_WIN() { return false; }

        // TODO
        private void ResetSelectMsgWindowStringDate() { }

        // TODO
        private bool EvCmd_TEMOTI_PER_RND() { return false; }

        // TODO
        private bool EvCmd_ADD_BTLTWR_CHALLENGE() { return false; }

        // TODO
        private bool EvCmd_BTLTWR_CONTINUE_ROUND() { return false; }

        // TODO
        public void DelteAruseus() { }

        private bool RunEvCmd(EvCmdID.NAME index)
        {
            if (index < EvCmdID.NAME.CMD_NAME_END)
            {
                // TODO: Keep implementing stuff here
                switch (index)
                {
                    case EvCmdID.NAME._NOP:
                        return EvCmdNop();

                    case EvCmdID.NAME._DUMMY:
                        return EvCmdDummy();

                    case EvCmdID.NAME._END:
                        return EvCmdEnd();

                    case EvCmdID.NAME._TIME_WAIT:
                        return EvCmdTimeWait();

                    case EvCmdID.NAME._LD_REG_VAL:
                        return EvCmdLoadRegValue();

                    case EvCmdID.NAME._LD_REG_WDATA:
                        return EvCmdLoadRegWData();

                    case EvCmdID.NAME._LD_REG_ADR:
                        return EvCmdLoadRegAdrs();

                    case EvCmdID.NAME._LD_ADR_VAL:
                        return EvCmdLoadAdrsValue();

                    case EvCmdID.NAME._LD_ADR_REG:
                        return EvCmdLoadAdrsReg();

                    case EvCmdID.NAME._LD_REG_REG:
                        return EvCmdLoadRegReg();

                    case EvCmdID.NAME._LD_ADR_ADR:
                        return EvCmdLoadAdrsAdrs();

                    case EvCmdID.NAME._CP_REG_REG:
                        return EvCmdCmpRegReg();

                    case EvCmdID.NAME._CP_REG_VAL:
                        return EvCmdCmpRegValue();

                    case EvCmdID.NAME._CP_REG_ADR:
                        return EvCmdCmpRegAdrs();

                    case EvCmdID.NAME._CP_ADR_REG:
                        return EvCmdCmpAdrsReg();

                    case EvCmdID.NAME._CP_ADR_VAL:
                        return EvCmdCmpAdrsValue();

                    case EvCmdID.NAME._CP_ADR_ADR:
                        return EvCmdCmpAdrsAdrs();

                    case EvCmdID.NAME._CMPVAL:
                        return EvCmdCmpWkValue();

                    case EvCmdID.NAME._CMPWK:
                        return EvCmdCmpWkWk();

                    case EvCmdID.NAME._DEBUG_WATCH_WORK:
                        return EvCmdDebugWatch();

                    case EvCmdID.NAME._VM_ADD:
                        return EvCmdVMMachineAdd();

                    case EvCmdID.NAME._CHG_COMMON_SCR:
                        return EvCmdChangeCommonScr();

                    case EvCmdID.NAME._CHG_LOCAL_SCR:
                        return EvCmdChangeLocalScr();

                    case EvCmdID.NAME._JUMP:
                        return EvCmdGlobalJump();

                    case EvCmdID.NAME._OBJ_ID_JUMP:
                        return EvCmdObjIDJump();

                    case EvCmdID.NAME._BG_ID_JUMP:
                        return EvCmdBgIDJump();

                    case EvCmdID.NAME._PLAYER_DIR_JUMP:
                        return EvCmdPlayerDirJump();

                    case EvCmdID.NAME._CALL:
                        return EvCmdGlobalCall();

                    case EvCmdID.NAME._RET:
                        return EvCmdRet();

                    case EvCmdID.NAME._IF_JUMP:
                        return EvCmdIfJump();

                    case EvCmdID.NAME._IF_CALL:
                        return EvCmdIfCall();

                    case EvCmdID.NAME._IFVAL_JUMP:
                        return EvMacro_IFVAL_JUMP();

                    case EvCmdID.NAME._IFVAL_CALL:
                        return EvMacro_IFVAL_CALL();

                    case EvCmdID.NAME._IFWK_JUMP:
                        return EvMacro_IFWK_JUMP();
                    
                    case EvCmdID.NAME._IFWK_CALL:
                        return EvMacro_IFWK_CALL();

                    case EvCmdID.NAME._SWITCH:
                        return EvMacro_SWITCH();

                    case EvCmdID.NAME._CASE_JUMP:
                        return EvMacro_CASE_JUMP();

                    case EvCmdID.NAME._CASE_CANCEL:
                        return EvMacro_CASE_CANCEL();

                    case EvCmdID.NAME._ADD_WAITICON:
                        return EvCmdTimeWaitIconAdd();

                    case EvCmdID.NAME._DEL_WAITICON:
                        return EvCmdTimeWaitIconDel();

                    case EvCmdID.NAME._FLAG_SET:
                        return EvCmdFlagSet();

                    case EvCmdID.NAME._ARRIVE_FLAG_SET:
                        return EvMacro_ARRIVE_FLAG_SET();

                    case EvCmdID.NAME._FLAG_RESET:
                        return EvCmdFlagReset();

                    case EvCmdID.NAME._FLAG_CHECK:
                        return EvCmdFlagCheck();

                    case EvCmdID.NAME._IF_FLAGON_JUMP:
                        return EvMacro_IF_FLAGON_JUMP();

                    case EvCmdID.NAME._IF_FLAGOFF_JUMP:
                        return EvMacro_IF_FLAGOFF_JUMP();

                    case EvCmdID.NAME._IF_FLAGON_CALL:
                        return EvMacro_IF_FLAGON_CALL();

                    case EvCmdID.NAME._IF_FLAGOFF_CALL:
                        return EvMacro_IF_FLAGOFF_CALL();

                    case EvCmdID.NAME._FLAG_CHECK_WK:
                        return EvCmdFlagCheckWk();

                    case EvCmdID.NAME._FLAG_SET_WK:
                        return EvCmdFlagSetWk();

                    case EvCmdID.NAME._TRAINER_FLAG_SET:
                        return EvCmdTrainerFlagSet();

                    case EvCmdID.NAME._TRAINER_FLAG_RESET:
                        return EvCmdTrainerFlagReset();

                    case EvCmdID.NAME._TRAINER_FLAG_CHECK:
                        return EvCmdTrainerFlagCheck();

                    case EvCmdID.NAME._IF_TR_FLAGON_JUMP:
                        return EvMacro_IF_TR_FLAGON_JUMP();

                    case EvCmdID.NAME._IF_TR_FLAGOFF_JUMP:
                        return EvMacro_IF_TR_FLAGOFF_JUMP();

                    case EvCmdID.NAME._IF_TR_FLAGON_CALL:
                        return EvMacro_IF_TR_FLAGON_CALL();

                    case EvCmdID.NAME._IF_TR_FLAGOFF_CALL:
                        return EvMacro_IF_TR_FLAGOFF_CALL();

                    case EvCmdID.NAME._ADD_WK:
                        return EvCmdWkAdd();

                    case EvCmdID.NAME._SUB_WK:
                        return EvCmdWkSub();

                    case EvCmdID.NAME._LDVAL:
                        return EvCmdLoadWkValue();

                    case EvCmdID.NAME._LDWK:
                        return EvCmdLoadWkWk();

                    case EvCmdID.NAME._LDWKVAL:
                        return EvCmdLoadWkWkValue();

                    case EvCmdID.NAME._TALKMSG_ALLPUT:
                        return EvCmdTalkMsgAllPut();

                    case EvCmdID.NAME._TALKMSG_ALLPUT_ARC:
                        return EvCmdTalkMsgAllPutOtherArc();

                    case EvCmdID.NAME._TALKMSG_ARC:
                        return EvCmdTalkMsgOtherArc();

                    case EvCmdID.NAME._TALKMSG_ALLPUT_PMS:
                        return EvCmdTalkMsgAllPutPMS();

                    case EvCmdID.NAME._TALKMSG_PMS:
                        return EvCmdTalkMsgPMS();

                    case EvCmdID.NAME._TALKMSG_BTOWER_APPEAR:
                        return EvCmdTalkMsgTowerApper();

                    case EvCmdID.NAME._TALKMSG_NG_POKE_NAME:
                        return EvCmdTalkMsgNgPokeName();

                    case EvCmdID.NAME._TALKMSG:
                        return EvCmdTalkMsg();

                    case EvCmdID.NAME._TALKMSG_SP:
                        return EvCmdTalkMsgSp();

                    case EvCmdID.NAME._TALKMSG_SP_AUTO:
                        return EvCmdTalkMsgSpAuto();

                    case EvCmdID.NAME._TALKMSG_NOSKIP:
                        return EvCmdTalkMsgNoSkip();

                    case EvCmdID.NAME._TALKMSG_CON_SIO:
                        return EvCmdTalkConSioMsg();

                    case EvCmdID.NAME._TALKMSG_AUTOGET:
                        return EvCmdMsgAutoGet();

                    case EvCmdID.NAME._AB_KEYWAIT:
                        return EvCmdABKeyWait();

                    case EvCmdID.NAME._AB_KEY_TIME_WAIT:
                        return EvCmdABKeyTimeWait();

                    case EvCmdID.NAME._LAST_KEYWAIT:
                        return EvCmdLastKeyWait();

                    case EvCmdID.NAME._NEXT_ANM_LAST_KEYWAIT:
                        return EvCmdNextAnmLastKeyWait();

                    case EvCmdID.NAME._TALK_OPEN:
                        return EvCmdTalkWinOpen();

                    case EvCmdID.NAME._TALK_CLOSE:
                        return EvCmdTalkWinClose();

                    case EvCmdID.NAME._TALK_CLOSE_NO_CLEAR:
                        return EvCmdTalkWinCloseNoClear();

                    case EvCmdID.NAME._TALK_KEYWAIT:
                        return EvMacro_TALK_KEYWAIT();

                    case EvCmdID.NAME._EASY_OBJ_MSG:
                        return EvMacro_EASY_OBJ_MSG();

                    case EvCmdID.NAME._EASY_MSG:
                        return EvMacro_EASY_MSG();

                    case EvCmdID.NAME._BOARD_MAKE:
                        return EvCmdBoardMake();

                    case EvCmdID.NAME._INFOBOARD_MAKE:
                        return EvCmdInfoBoardMake();

                    case EvCmdID.NAME._BOARD_REQ:
                        return EvCmdBoardReq();

                    case EvCmdID.NAME._BOARD_REQ_WAIT:
                        return EvCmdBoardWait();

                    case EvCmdID.NAME._BOARD_MSG:
                        return EvCmdBoardMsg();

                    case EvCmdID.NAME._BOARD_END_WAIT:
                        return EvCmdBoardEndWait();

                    case EvCmdID.NAME._EASY_BOARD_MSG:
                        return EvMacro_EASY_BOARD_MSG();

                    case EvCmdID.NAME._EASY_INFOBOARD_MSG:
                        return EvMacro_EASY_INFOBOARD_MSG();

                    case EvCmdID.NAME._MENU_REQ:
                        return EvCmdMenuReq();

                    case EvCmdID.NAME._BG_SCROLL:
                        return EvCmdBgScroll();

                    case EvCmdID.NAME._YES_NO_WIN:
                        return EvCmdYesNoWin();

                    case EvCmdID.NAME._GUINNESS_WIN:
                        return EvCmdGuinnessWin();

                    case EvCmdID.NAME._BMPMENU_INIT:
                        return EvCmdBmpMenuInit();

                    case EvCmdID.NAME._BMPMENU_INIT_EX:
                        return EvCmdBmpMenuInitEx();

                    case EvCmdID.NAME._BMPMENU_MAKE_LIST:
                        return EvCmdBmpMenuMakeList();

                    case EvCmdID.NAME._BMPMENU_MAKE_LIST16:
                        return EvCmdBmpMenuMakeList16();

                    case EvCmdID.NAME._BMPMENU_START:
                        return EvCmdBmpMenuStart();

                    case EvCmdID.NAME._BMPLIST_INIT:
                        return EvCmdBmpListInit();

                    case EvCmdID.NAME._BMPLIST_INIT_EX:
                        return EvCmdBmpListInitEx();

                    case EvCmdID.NAME._BMPLIST_MAKE_LIST:
                        return EvCmdBmpListMakeList();

                    case EvCmdID.NAME._BMPLIST_START:
                        return EvCmdBmpListStart();

                    case EvCmdID.NAME._BMPMENU_HV_START:
                        return EvCmdBmpMenuHVStart();

                    case EvCmdID.NAME._SE_PLAY:
                        return EvCmdSePlay();

                    case EvCmdID.NAME._ME_PLAY:
                        return EvCmdMePlay();

                    case EvCmdID.NAME._BGM_PLAY:
                        return EvCmdBgmPlay();

                    case EvCmdID.NAME._OBJ_ANIME:
                        return EvCmdObjAnime();

                    case EvCmdID.NAME._OBJ_ANIME_WAIT:
                        return EvCmdObjAnimeWait();

                    case EvCmdID.NAME._SP_EVENT_DATA_END:
                        return EvMacro_SP_EVENT_DATA_END();

                    case EvCmdID.NAME._SCENE_CHANGE_LABEL:
                        return EvMacro_SCENE_CHANGE_LABEL();

                    case EvCmdID.NAME._SCENE_CHANGE_DATA:
                        return EvMacro_SCENE_CHANGE_DATA();

                    case EvCmdID.NAME._SCENE_CHANGE_END:
                        return EvMacro_SCENE_CHANGE_END();

                    case EvCmdID.NAME._FLAG_CHANGE_LABEL:
                        return EvMacro_FLAG_CHANGE_LABEL();

                    case EvCmdID.NAME._OBJ_CHANGE_LABEL:
                        return EvMacro_OBJ_CHANGE_LABEL();

                    case EvCmdID.NAME._INIT_CHANGE_LABEL:
                        return EvMacro_INIT_CHANGE_LABEL();

                    case EvCmdID.NAME._ADD_GOLD:
                        return EvCmdAddGold();

                    case EvCmdID.NAME._ADD_ITEM:
                        return EvCmdAddItem();

                    case EvCmdID.NAME._POKETCH_ADD:
                        return EvCmdPoketchAppAdd();

                    case EvCmdID.NAME._SXY_DIR_CHANGE:
                        return EvCmdSxyDirChange();

                    case EvCmdID.NAME._OBJ_DIR_CHANGE:
                        return EvCmdObjDirChange();

                    case EvCmdID.NAME._GET_RND:
                        return EvCmdGetRand();

                    case EvCmdID.NAME._GET_RND_NEXT:
                        return EvCmdGetRandNext();

                    case EvCmdID.NAME._EVENT_CAMERA_WAIT:
                        return EvCmd_EVENT_CAMERA_WAIT();

                    case EvCmdID.NAME._SET_SYS_FLAG:
                        return EvCmd_SET_SYS_FLAG();

                    case EvCmdID.NAME._RESET_SYS_FLAG:
                        return EvCmd_RESET_SYS_FLAG();

                    case EvCmdID.NAME._CAMERA_COS_ANGLE_WAIT:
                        return EvCmd_CAMERA_COS_ANGLE_WAIT();

                    case EvCmdID.NAME._SET_OFFSET:
                        return EvCmd_CAMERA_SET_OFFSET();

                    case EvCmdID.NAME._NATURAL_PARK_POKE_CREATE:
                        return EvCmdNaturalParkPokeCreate();

                    case EvCmdID.NAME._EVENT_CAMERA_INDEX:
                        return EvCmdEventCameraIndex();

                    case EvCmdID.NAME._CAMERA_CONTROLLER_PLAY:
                        return EvCmd_CAMERA_CONTROLLER_PLAY();

                    case EvCmdID.NAME._DISPLAY_MESSAGE:
                        return EvCmd_DISPLAY_MESSAGE();

                    case EvCmdID.NAME._DISPLAY_MESSAGE_CLOSE:
                        return EvCmd_DISPLAY_MESSAGE_CLOSE();

                    case EvCmdID.NAME._TV_RED_GYARADOS_ON:
                        return EvCmd_TV_RED_GYARADOS_ON();

                    case EvCmdID.NAME._AG_TRANSITION_HOYUTA:
                        return EvCmdAGAnimationHyouta();

                    default:
                        {
#if NON_DECOMP
                            Debug.Log(string.Format("Running unimplemented EvCommand: {0}", index.ToString()));
#endif
                            return true;
                        }
                }
            }
            return true;
        }

        // TODO
        private bool WarpSegmentHitCheck(FieldEventDoorEntity entity, out Vector3 reusltPosition, out float subtendedAngle, out float lineDistance, float hitrange)
        {
            reusltPosition = Vector3.zero;
            subtendedAngle = 0.0f;
            lineDistance = 0.0f;
            return false;
        }

        // TODO
        private void SegmentHit(ref Vector2 segA, ref Vector2 segB, ref Vector2 targetPos, float radius, out float angleAT, out float angleBT, out float distance, out int hitstatus)
        {
            angleAT = 0.0f;
            angleBT = 0.0f;
            distance = 0.0f;
            hitstatus = 0;
        }

        public void InitScriptLoad()
        {
            MessageManager.Instance.Initialize(MessageEnumData.MsgLangId.JPN);
            _scriptOperation = AssetManager.AppendAssetBundleRequest("ev_script", true, null, null);
            AssetManager.DispatchRequests(null);
        }

        public bool InitScriptLoadWait()
        {
            if (_scriptOperation == null)
                return true;

            if (!_scriptOperation.assetBundleRequest.isComplete)
                return false;

            _eventList = new EvScriptData[_scriptOperation.assetBundleRequest.cache.loadedAssets.Length];
            for (int i=0; i<_eventList.Length; i++)
            {
                var asset = _scriptOperation.assetBundleRequest.cache.loadedAssets[i];
                if (asset != null)
                {
                    if (asset is EvData)
                    {
                        if (asset != null)
                        {
                            _eventList[i] = new EvScriptData((EvData)asset);
                        }
                    }
                    else if (asset is EventCameraTable)
                    {
                        _evCameraTable = (EventCameraTable)asset;
                    }
                }
            }

            AssetManager.UnloadAssetBundle(_scriptOperation.assetBundleRequest.uri);
            _scriptOperation = null;

            return true;
        }

        public void InitScriptEnd()
        {
            if (!_isScriptLoad)
                return;

            for (int i=0; i<_eventList.Length; i++)
            {
                var _event = _eventList[i];
                if (_event != null)
                {
                    for (int j=0; j<_event.EvData.Scripts.Count; j++)
                    {
                        var script = _event.EvData.Scripts[j];
                        if (!FindLabel(script.Label))
                            _findAllLabel.Add(script.Label, new int[2] { i, j });
                    }
                }
            }
        }

        // TODO
        private bool IsRockclimbLabel(string label) { return false; }

        public void SaveDataReflection()
        {
            EntityManager.BuildFieldEntities();

            foreach (var obj in _fieldObjectEntity)
            {
                if (obj != null && obj.gameObject != null)
                {
                    var objSave = FieldObjWork.Get(obj.gameObject.name.GetHashCode(), out bool found);
                    if (found)
                    {
                        obj.gridPosition = new Vector2Int(objSave.grid_x, objSave.grid_y);
                        obj.worldPosition.y = objSave.height;
                        obj.yawAngle = objSave.angle;

                        var moveIndex = obj.EventParams.MoveCodeIndex;
                        if (moveIndex > -1)
                        {
                            var moveCode = FieldObjectMoveCodes[moveIndex];
                            moveCode.MoveCode = objSave.movecode;
                            moveCode.MoveDirHead = (DIR)objSave.dir_head;
                            moveCode.MoveParam0 = objSave.mvParam0;
                            moveCode.MoveParam1 = objSave.mvParam1;
                            moveCode.MoveParam2 = objSave.mvParam2;
                            moveCode.MoveLimitX = objSave.limitX;
                            moveCode.MoveLimitZ = objSave.limitZ;
                            moveCode.Ev_Type = objSave.ev_type;
                            moveCode.mv_old_dir = objSave.mv_old_dir;
                            moveCode.mv_dir = objSave.mv_dir;
                        }
                    }
                }
            }

            for (int i=0; i<EntityManager.fieldTobariGymWalls.Length; i++)
            {
                var wall = EntityManager.fieldTobariGymWalls[i];
                if (wall != null && wall.gameObject != null)
                {
                    var objSave = FieldObjWork.Get(wall.gameObject.name.GetHashCode(), out bool found);
                    if (found)
                        wall.ApplySaveData(objSave);
                }
            }

            if (EntityManager.fieldNomoseGymWater.Length != 0)
            {
                var water = EntityManager.fieldNomoseGymWater[0];
                if (water != null && water.gameObject != null)
                {
                    var objSave = FieldObjWork.Get(water.gameObject.name.GetHashCode(), out bool found);
                    if (found)
                        water.ApplySaveData(objSave);
                }
            }
        }

        // TODO
        public void SetSaveObj() { }

        public void SetupGimmickEntity()
        {
            EntityManager.BuildFieldEntities();

            for (int i=0; i<EntityManager.fieldTobariGymWalls.Length; i++)
            {
                var wall = EntityManager.fieldTobariGymWalls[i];
                if (wall != null && wall.gameObject != null)
                    wall.Setup();
            }

            if (EntityManager.fieldNagisaGymGears == null || EntityManager.fieldNagisaGymGears.Length == 0)
            {
                GimmickWork.ClearGearRotate();
            }
            else
            {
                for (int i=0; i<EntityManager.fieldNagisaGymGears.Length; i++)
                {
                    var gear = EntityManager.fieldNagisaGymGears[i];
                    if (gear != null && gear.gameObject != null)
                        gear.Setup(_areaID);
                }
            }

            for (int i=0; i<EntityManager.fieldLiftObjects.Length; i++)
            {
                var lift = EntityManager.fieldLiftObjects[i];
                if (lift != null && lift.gameObject != null)
                    lift.Setup();
            }

            if (EntityManager.fieldNomoseGymWater.Length != 0)
            {
                var water = EntityManager.fieldNomoseGymWater[0];
                if (water != null && water.gameObject != null)
                    water.Setup();
            }

            for (int i=0; i<EntityManager.fieldNomoseGymSwitches.Length; i++)
            {
                var gymSwitch = EntityManager.fieldNomoseGymSwitches[i];
                if (gymSwitch != null && gymSwitch.gameObject != null)
                    gymSwitch.Setup();
            }

            if (EntityManager.fieldElevatorBackground.Length != 0)
            {
                var elevatorBg = EntityManager.fieldElevatorBackground[0];
                if (elevatorBg != null && elevatorBg.gameObject != null)
                    elevatorBg.Setup();
            }
        }

        public void SceneStartGimmickEntity()
        {
            if (EntityManager.fieldNagisaGymGears == null)
                return;

            if (EntityManager.fieldNagisaGymGears.Length == 0)
                return;

            for (int i=0; i<EntityManager.fieldNagisaGymGears.Length; i++)
            {
                var gear = EntityManager.fieldNagisaGymGears[i];
                if (gear != null && gear.gameObject != null)
                    gear.SceneStart();
            }
        }

        // TODO
        public static void PlayHoneyTreeAnimation(ZoneID zoneId) { }

        private void CreateWorpPoint()
        {
            if (_warpRoot == null)
            {
                _warpRoot = new GameObject();
                _warpRoot.name = "WarpObjectRoot";
            }

            for (int i=0; i<_warpRoot.transform.childCount; i++)
                UnityEngine.Object.Destroy(_warpRoot.transform.GetChild(i).gameObject);

            _warpList.Clear();
            _warpData = null;

            string label = string.Format("MapWarp_{0}", _areaID.ToString());
            if (!DataManager.MapWarpData.ContainsKey(label))
                return;

            _warpData = DataManager.MapWarpData[label];

            var dict = new Dictionary<int, List<CreateWarp>>(50);
            for (int i=0; i<_warpData.Data.Length; i++)
            {
                var warp = new CreateWarp();
                warp.data = _warpData.Data[i];
                warp.index = i;

                if (dict.ContainsKey(warp.data.GruopID))
                    dict[warp.data.GruopID].Add(warp);
                else
                    dict.Add(warp.data.GruopID, new List<CreateWarp>(WarpListLength) { warp });
            }

            foreach (var entry in dict)
            {
                if (entry.Key == -1 || entry.Key == 0)
                {
                    foreach (var warp in dict[entry.Key])
                        _warpList.Add(CreateWarpEntity(warp.data, new int[1] { warp.index }, warp.data.Size, new int[1] { warp.data.WarpIndex }));
                }
                else
                {
                    var data = entry.Value[0].data;
                    float fullsizex = data.Size.x;
                    float fullsizey = data.Size.y;

                    Vector2 position = new Vector2(data.Position.x, data.Position.z);

                    var indices = new int[entry.Value.Count];
                    indices[0] = entry.Value[0].index;
                    var locators = new int[entry.Value.Count];
                    locators[0] = data.WarpIndex;

                    for (int i=1; i<entry.Value.Count; i++)
                    {
                        indices[i] = entry.Value[i].index;
                        locators[i] = entry.Value[i].data.WarpIndex;

                        fullsizex += entry.Value[i].data.Position.x - position.x;
                        fullsizey += entry.Value[i].data.Position.z - position.y;

                        position.x = entry.Value[i].data.Position.x;
                        position.y = entry.Value[i].data.Position.z;
                    }

                    _warpList.Add(CreateWarpEntity(data, indices, new Vector2(fullsizex, fullsizey), locators));
                }
            }
        }

        private FieldEventDoorEntity CreateWarpEntity(MapWarp.SheetData data, int[] index, Vector2 size, int[] locator)
        {
            var go = new GameObject();
            go.name = string.Format("{0}_W{1:D2}", _areaID.ToString(), index[0]);

            var door = go.AddComponent<FieldEventDoorEntity>();
            door.transform.SetParent(_warpRoot.transform);
            door.transform.localPosition = new Vector3(-data.Position.x, data.Position.y, data.Position.z);
            door.EventParams.IsContact = false;
            door.mdIndexArray = index;
            door.EventParams.Type = EntityType.Warp;
            door.entityEname = go.name;

            door.size.x = size.x <= 0.0f ? 1.0f : size.x;
            door.size.y = size.y <= 0.0f ? 1.0f : size.y;
            door.shapeType = FieldEventEntity.ShapeType.Box;
            door.offset.x = size.x >= 1.0f ? -0.5f : size.x * -0.5f;
            door.offset.y = size.y >= 1.0f ? -0.5f : size.y * 0.5f;

            switch (data.InputDir)
            {
                case 0: door.startVectol = FieldDoor.StartVectol.Up; break;
                case 1: door.startVectol = FieldDoor.StartVectol.Left; break;
                case 2: door.startVectol = FieldDoor.StartVectol.Down; break;
                case 3: door.startVectol = FieldDoor.StartVectol.Right; break;
                case 4: door.startVectol = FieldDoor.StartVectol.All; break;
            }
#if PEARL
            door.transitionZone = data.WarpZone == ZoneID.D05R0114 ? ZoneID.D05R0115 : data.WarpZone;
#else
            door.transitionZone = data.WarpZone == ZoneID.D05R0115 ? ZoneID.D05R0114 : data.WarpZone;
#endif
            door.locatorIndex = data.WarpIndex;
            door.locatorArray = locator;
            door.callLabel = data.ScriptLabel;
            door.exitLabel = data.ExitLabel;
            door.connectionName = data.ConnectionName;

            switch (door.startVectol)
            {
                case FieldDoor.StartVectol.Up:
                    door.offset.y -= 1.0f;
                    break;

                case FieldDoor.StartVectol.Down:
                    door.offset.y += 1.0f;
                    break;

                case FieldDoor.StartVectol.Left:
                    door.offset.x -= 1.0f;
                    break;

                case FieldDoor.StartVectol.Right:
                    door.offset.x += 1.0f;
                    break;
            }

            return door;
        }

        public IEnumerator RequestAssetSetUp(AreaID areaid)
        {
            while (!DataManager.IsLoaded())
                yield return null;

            if (_isScriptLoad)
            {
                InitScriptLoad();
                while (!InitScriptLoadWait())
                    yield return null;

                InitScriptEnd();
            }

            if (PlayerWork.Warp == PlayerWork.WarpType.None && areaid == _areaID)
            {
                if (!GameManager.mapInfo[(int)PlayerWork.transitionZoneID].Reload)
                    yield break;
            }

            _areaID = areaid;

            if (_areaID == AreaID.UNKNOWN)
                yield break;

            if (FieldObjectMoveCodes == null)
                FieldObjectMoveCodes = new List<FieldObjectMoveCode>(FieldObjectMoveCodesLength);

            FieldObjectMoveCodes.Clear();
            _fieldObjectEntity.Clear();
            _FieldKinomiGrowEntity.Clear();
            _loadObjectList.Clear();

            _loadObjectIndex = 0;

            _AssetReqOpeList.RemoveAll(val => val == null);
            for (int i=0; i<_AssetReqOpeList.Count; i++)
                _AssetReqOpeList[i].RefCount = 0;

            var placedataStr = "PlaceData_" + _areaID;
            if (!DataManager.PlaceData.ContainsKey(placedataStr))
                yield break;

            var placedatas = DataManager.PlaceData[placedataStr].Data;
            for (int i=0; i<placedatas.Length; i++)
            {
                var placedata = placedatas[i];
                if (placedata != null && (placedata.DoNotLoad == EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE || !FlagWork.GetFlag(placedata.DoNotLoad)))
                {
                    var loadObj = new LoadObjectData
                    {
                        IsLoadFast = placedata.LoadFirst,
                        ObjectName = placedata.ID,
                        PlaceData = placedata,
                        Position = placedata.Position,
                        Height = placedata.HeightLayer,
                        IsCreated = false,
                        Angle = placedata.Rotation,
                        MoveCode = placedata.MoveCode,
                        MoveDirHead = FieldObjectEntity.GetDir(placedata.Rotation),
                        MoveParam0 = placedata.MoveParam0,
                        MoveParam1 = placedata.MoveParam1,
                        MoveParam2 = placedata.MoveParam2,
                        MoveLimitX = (int)placedata.MoveLimit.x,
                        MoveLimitZ = (int)placedata.MoveLimit.y,
                        Ev_Type = placedata.EventType,
                    };
                    loadObj.mv_old_dir = (int)loadObj.MoveDirHead;
                    loadObj.mv_dir = (int)loadObj.MoveDirHead;

                    SetSaveDataParam(ref loadObj);

                    int graphicIndex = placedata.ObjectGraphicIndex;
                    if (_areaID == AreaID.D31R0205 || _areaID == AreaID.D31R0206)
                    {
                        int mode = BtlTowerWork.GetMode();
                        int towerRank = BtlTowerWork.GetRank(mode);

                        if (placedata.ID == "TOWER_PLAYER_01_01")
                        {
                            BtlTowerWork.GetNowModeEnum(out TowerLotRule rule, out TowerLotCls cls);
                            var lot = TrainerSystem.CreateTowerLotResult(rule, cls, towerRank, 1, BtlTowerWork.GetTrainerRand(0));
                            graphicIndex = lot.GetTrainerData(0).fldGraphic;
                            loadObj.replaceGraphicIndex = graphicIndex;
                        }
                        else if (placedata.ID == "TOWER_PLAYER_02_01")
                        {
                            BtlTowerWork.GetNowModeEnum(out TowerLotRule rule, out TowerLotCls cls);
                            var lot = TrainerSystem.CreateTowerLotResult(rule, cls, towerRank, 2, BtlTowerWork.GetTrainerRand(1));
                            graphicIndex = lot.GetTrainerData(0).fldGraphic;
                            loadObj.replaceGraphicIndex = graphicIndex;
                        }
                        else if (placedata.ID == "TOWER_PLAYER_03_01")
                        {
                            BtlTowerWork.GetNowModeEnum(out TowerLotRule rule, out TowerLotCls cls);
                            var lot = TrainerSystem.CreateTowerLotResult(rule, cls, towerRank, 3, BtlTowerWork.GetTrainerRand(2));
                            graphicIndex = lot.GetTrainerData(0).fldGraphic;
                            loadObj.replaceGraphicIndex = graphicIndex;
                        }
                        else if (placedata.ID == "TOWER_PLAYER_04_01")
                        {
                            BtlTowerWork.GetNowModeEnum(out TowerLotRule rule, out TowerLotCls cls);
                            var lot = TrainerSystem.CreateTowerLotResult(rule, cls, towerRank, 4, BtlTowerWork.GetTrainerRand(3));
                            graphicIndex = lot.GetTrainerData(0).fldGraphic;
                            loadObj.replaceGraphicIndex = graphicIndex;
                        }
                        else if (placedata.ID == "TOWER_PLAYER_05_01")
                        {
                            BtlTowerWork.GetNowModeEnum(out TowerLotRule rule, out TowerLotCls cls);
                            var lot = TrainerSystem.CreateTowerLotResult(rule, cls, towerRank, 5, BtlTowerWork.GetTrainerRand(4));
                            graphicIndex = lot.GetTrainerData(0).fldGraphic;
                            loadObj.replaceGraphicIndex = graphicIndex;
                        }
                        else if (placedata.ID == "TOWER_PLAYER_06_01")
                        {
                            BtlTowerWork.GetNowModeEnum(out TowerLotRule rule, out TowerLotCls cls);
                            var lot = TrainerSystem.CreateTowerLotResult(rule, cls, towerRank, 6, BtlTowerWork.GetTrainerRand(5));
                            graphicIndex = lot.GetTrainerData(0).fldGraphic;
                            loadObj.replaceGraphicIndex = graphicIndex;
                        }
                        else if (placedata.ID == "TOWER_PLAYER_07_01")
                        {
                            BtlTowerWork.GetNowModeEnum(out TowerLotRule rule, out TowerLotCls cls);
                            var lot = TrainerSystem.CreateTowerLotResult(rule, cls, towerRank, 7, BtlTowerWork.GetTrainerRand(6));
                            graphicIndex = lot.GetTrainerData(0).fldGraphic;
                            loadObj.replaceGraphicIndex = graphicIndex;
                        }
                        else if (mode == 3)
                        {
                            if (placedata.ID == "TOWER_PLAYER_01_02")
                            {
                                BtlTowerWork.GetNowModeEnum(out TowerLotRule rule, out TowerLotCls cls);
                                var lot = TrainerSystem.CreateTowerLotResult(rule, cls, towerRank, 1, BtlTowerWork.GetTrainerRand(0));
                                graphicIndex = lot.GetTrainerData(1).fldGraphic;
                                loadObj.replaceGraphicIndex = graphicIndex;
                            }
                            else if (placedata.ID == "TOWER_PLAYER_02_02")
                            {
                                BtlTowerWork.GetNowModeEnum(out TowerLotRule rule, out TowerLotCls cls);
                                var lot = TrainerSystem.CreateTowerLotResult(rule, cls, towerRank, 2, BtlTowerWork.GetTrainerRand(1));
                                graphicIndex = lot.GetTrainerData(1).fldGraphic;
                                loadObj.replaceGraphicIndex = graphicIndex;
                            }
                            else if (placedata.ID == "TOWER_PLAYER_03_02")
                            {
                                BtlTowerWork.GetNowModeEnum(out TowerLotRule rule, out TowerLotCls cls);
                                var lot = TrainerSystem.CreateTowerLotResult(rule, cls, towerRank, 3, BtlTowerWork.GetTrainerRand(2));
                                graphicIndex = lot.GetTrainerData(1).fldGraphic;
                                loadObj.replaceGraphicIndex = graphicIndex;
                            }
                            else if (placedata.ID == "TOWER_PLAYER_04_02")
                            {
                                BtlTowerWork.GetNowModeEnum(out TowerLotRule rule, out TowerLotCls cls);
                                var lot = TrainerSystem.CreateTowerLotResult(rule, cls, towerRank, 4, BtlTowerWork.GetTrainerRand(3));
                                graphicIndex = lot.GetTrainerData(1).fldGraphic;
                                loadObj.replaceGraphicIndex = graphicIndex;
                            }
                            else if (placedata.ID == "TOWER_PLAYER_05_02")
                            {
                                BtlTowerWork.GetNowModeEnum(out TowerLotRule rule, out TowerLotCls cls);
                                var lot = TrainerSystem.CreateTowerLotResult(rule, cls, towerRank, 5, BtlTowerWork.GetTrainerRand(4));
                                graphicIndex = lot.GetTrainerData(1).fldGraphic;
                                loadObj.replaceGraphicIndex = graphicIndex;
                            }
                            else if (placedata.ID == "TOWER_PLAYER_06_02")
                            {
                                BtlTowerWork.GetNowModeEnum(out TowerLotRule rule, out TowerLotCls cls);
                                var lot = TrainerSystem.CreateTowerLotResult(rule, cls, towerRank, 6, BtlTowerWork.GetTrainerRand(5));
                                graphicIndex = lot.GetTrainerData(1).fldGraphic;
                                loadObj.replaceGraphicIndex = graphicIndex;
                            }
                            else if (placedata.ID == "TOWER_PLAYER_07_02")
                            {
                                BtlTowerWork.GetNowModeEnum(out TowerLotRule rule, out TowerLotCls cls);
                                var lot = TrainerSystem.CreateTowerLotResult(rule, cls, towerRank, 7, BtlTowerWork.GetTrainerRand(6));
                                graphicIndex = lot.GetTrainerData(1).fldGraphic;
                                loadObj.replaceGraphicIndex = graphicIndex;
                            }
                        }
                    }

                    if (graphicIndex < 0)
                    {
                        loadObj.AssetReqIndex = -1;
                    }
                    else
                    {
                        string assetBundleName;
                        if (graphicIndex == 4) // Assistant (4)
                        {
                            int supportGraphic = PlayerWork.playerSex ? 140 : 139;
                            assetBundleName = "";
                            if (-1 < supportGraphic && supportGraphic < DataManager.CharacterGraphics.Data.Length)
                                assetBundleName = Path_Parsons + DataManager.CharacterGraphics.Data[supportGraphic].FieldGraphic;
                        }
                        else if (graphicIndex >= Graphic_Poke) // Pokémon (10000+)
                        {
                            assetBundleName = string.Format("{0}pm{1:D4}_{2:D2}_{3:D2}", Path_Poke_Model, graphicIndex / 10000,
                                (graphicIndex / 100) + (graphicIndex / 10000 * -100), graphicIndex % 100);
                        }
                        else if (graphicIndex >= Graphic_Gimmick && graphicIndex < Graphic_SekiZou) // Gimmick (500-999)
                        {
                            assetBundleName = DataManager.GimmickGraphics.Data[graphicIndex - 500].AssetPath;
                        }
                        else if (graphicIndex >= Graphic_SekiZou && graphicIndex < Graphic_SekiZouMAX) // Statue (1000-2999)
                        {
                            assetBundleName = string.Format("pokemons/statue/{0}", graphicIndex - Graphic_SekiZou);
                        }
                        else // Character (0-3, 5-499, 3000-9999)
                        {
                            assetBundleName = "";
                            if (-1 < graphicIndex && graphicIndex < DataManager.CharacterGraphics.Data.Length)
                                assetBundleName = Path_Parsons + DataManager.CharacterGraphics.Data[graphicIndex].FieldGraphic;
                        }

                        if (string.IsNullOrEmpty(assetBundleName))
                            continue;

                        for (int j=0; j<_AssetReqOpeList.Count; j++)
                        {
                            if (_AssetReqOpeList[j].ReqOpe.assetBundleRequest.uri == assetBundleName)
                            {
                                _AssetReqOpeList[j].RefCount = 1;
                                loadObj.AssetReqIndex = j;
                                break;
                            }
                        }

                        var req = new AssetReqOpeRef
                        {
                            RefCount = 1,
                            ReqOpe = AssetManager.AppendAssetBundleRequest(assetBundleName, true, null, null)
                        };
                        _AssetReqOpeList.Add(req);
                        loadObj.AssetReqIndex = _AssetReqOpeList.Count - 1;
                    }

                    _loadObjectList.Add(loadObj);
                }
            }

            for (int i=0; i<_AssetReqOpeList.Count; i++)
            {
                if (_AssetReqOpeList[i] != null)
                {
                    // Presumed commented out log, otherwise the string function results are ignored.
                    //Debug.Log("fieldasset request \n" + string.Format("[{0}]{1}  [{2}]\n", i, _AssetReqOpeList[i].isEnd, _AssetReqOpeList[i].ReqOpe.assetBundleRequest.uri));
                }
            }

            AssetManager.DispatchRequests(null);
        }

        // TODO
        public IEnumerator PreRequestAssetSetUp(AreaID areaid) { return null; }

        private void SetSaveDataParam(ref LoadObjectData lodata)
        {
            var data = FieldObjWork.Get(lodata.ObjectName.GetHashCode(), out bool flag);
            if (flag)
            {
                lodata.Position = new Vector2(data.grid_x, data.grid_y);
                lodata.Height = data.height;
                lodata.Angle = data.angle;
                lodata.MoveCode = data.movecode;
                lodata.MoveParam0 = data.mvParam0;
                lodata.MoveParam1 = data.mvParam1;
                lodata.MoveParam2 = data.mvParam2;
                lodata.MoveLimitX = data.limitX;
                lodata.MoveLimitZ = data.limitZ;
                lodata.Ev_Type = data.ev_type;
                lodata.mv_old_dir = data.mv_old_dir;
                lodata.mv_dir = data.mv_dir;
            }
            
            lodata.useloadData = flag;
        }

        public void SetCreateParent(Transform parent)
        {
            _loadObjectParent = parent;
        }

        public void SortLoadObjectData(Vector2Int grid)
        {
            for (int i=0; i<_loadObjectList.Count; i++)
            {
                if (!_loadObjectList[i].IsCreated && _loadObjectList[i].IsLoadFast)
                {
                    float posx = _loadObjectList[i].Position.x >= 0.0f ? _loadObjectList[i].Position.x : -_loadObjectList[i].Position.x;
                    float deltax = Mathf.Abs(grid.x - posx);
                    float deltay = Mathf.Abs(grid.y - _loadObjectList[i].Position.y);

                    if (deltax > 32.0f || deltay > 32.0f)
                        _loadObjectList[i].Distance = (int)(deltax + deltay);
                    else
                        _loadObjectList[i].Distance = 0;
                }
                else
                {
                    _loadObjectList[i].Distance = 0;
                }
            }

            _loadObjectList.Sort((a, b) => a.Distance - b.Distance);
        }

        public IEnumerator StartUpCreate()
        {
            while (!IsLoadAssetBundle())
                yield return null;

            if (_dummyPlayer == null)
            {
                var go = new GameObject();
                go.name = "ev_dummy";
                _dummyPlayer = go.AddComponent<FieldObjectEntity>();
            }

            DailyEventWork.UpdateEvent();
            PokeWork.CheckTimeChangeLandformSheimi();

            FieldWazaCutIn?.Initialize();
            HoneyWork.UpdateTime();

            _loadObjectIndex = 0;

            for (_loadObjectIndex=0; _loadObjectIndex<_loadObjectList.Count; _loadObjectIndex++)
            {
                var obj = _loadObjectList[_loadObjectIndex];
                if (!obj.IsCreated)
                {
                    if (_loadObjectList[_loadObjectIndex].Distance != 0)
                        break;

                    _loadObjectList[_loadObjectIndex].IsCreated = true;
                    LoadObjectCreate(_loadObjectList[_loadObjectIndex]);
                }
            }

            KinomiWork.UpdateGrowTime();
            var placeData = KinomiWork.GetPlaceDataByAreaId(_areaID);

            for (int i=0; i<placeData.Length; i++)
                LoadObjectCreate_KinomiGrow(placeData[i]);

            if (_stopRoot == null)
            {
                _stopRoot = new GameObject();
                _stopRoot.name = "stop_root";
            }

            for (int i=0; i<_stopRoot.transform.childCount; i++)
                UnityEngine.Object.Destroy(_stopRoot.transform.GetChild(i).gameObject);

            if (_entityParamList == null)
                _entityParamList = new EntityParam[EntityParamLength];

            for (int i=0; i<_entityParamList.Length; i++)
                _entityParamList[i] = null;

            var stopDataStr = string.Format("StopData_{0}", _areaID);
            if (DataManager.StopData.ContainsKey(stopDataStr))
            {
                var stopData = DataManager.StopData[stopDataStr];
                _entityParamList = new EntityParam[stopData.Data.Length];

                for (int i=0; i<stopData.Data.Length; i++)
                {
                    var stop = stopData.Data[i];
                    if (stop != null)
                    {
                        var pos = new Vector3(-stop.Position.x, stop.HeightLayer, stop.Position.y);
                        var pos2D = new Vector2Int((int)stop.Position.x, (int)stop.Position.y);
                        var param = new EntityParam
                        {
                            ContactLabel = stop.ContactLabel,
                            IsContact = false,
                            WorkIndex = stop.Work,
                            WorkValue = stop.Param,
                            StopGridArea = new RectInt(pos2D.x, pos2D.y, (int)(stop.Size.x - 1), (int)(stop.Size.y - 1)),
                        };
                        _entityParamList[i] = param;
                    }
                }
            }
        }

        public void UpdateCreate()
        {
            if (_loadObjectIndex < _loadObjectList.Count && !_nowInstantiate)
            {
                if (!_loadObjectList[_loadObjectIndex].IsCreated)
                {
                    var loadObject = _loadObjectList[_loadObjectIndex];
                    loadObject.IsCreated = true;
                    LoadObjectCreate(loadObject);
                }

                _loadObjectIndex++;
                EntityManager.BuildFieldEntities();
            }
        }

        // TODO
        public void Init_PokemonCenter() { }

        // TODO
        public void Init_FieldShip() { }

        public bool RefCountZeroUnload()
        {
            if (_nowInstantiate)
                return false;

            if (_AssetReqOpeList.Count < 1)
                return true;

            for (int i = 0; i < _AssetReqOpeList.Count; i++)
            {
                if (_AssetReqOpeList[i] != null)
                {
                    if (!_AssetReqOpeList[i].isEnd)
                        return false;
                }
            }

            for (int i = 0; i < _AssetReqOpeList.Count; i++)
            {
                if (_AssetReqOpeList[i] != null)
                {
                    if (_AssetReqOpeList[i].RefCount < 1)
                    {
                        var req = _AssetReqOpeList[i].ReqOpe.assetBundleRequest;
                        AssetManager.UnloadAssetBundle(req.uri);

                        // This string is ignored. There likely was a commented out log here.
                        var str = "fieldasset unload\n" + string.Format("[{0}]{1}  [{2}]\n", i, _AssetReqOpeList[i].isEnd, req.uri);
                        //Debug.Log(str);

                        _AssetReqOpeList[i] = null;
                    }
                }
            }

            for (int i = 0; i < _AssetReqOpeList.Count; i++)
            {
                if (_AssetReqOpeList[i] == null)
                {
                    // This string is ignored. There likely was a commented out log here.
                    var str = "fieldasset cache \n" + string.Format("[{0}] null\n", i);
                    //Debug.Log(str);
                }
                else
                {
                    // This string is ignored. There likely was a commented out log here.
                    var str = "fieldasset cache \n" + string.Format("[{0}]{1}  [{2}]\n", i, _AssetReqOpeList[i].isEnd, _AssetReqOpeList[i].ReqOpe.assetBundleRequest.uri);
                    //Debug.Log(str);
                }
            }

            return true;
        }

        public bool ForceUnload()
        {
            PokemonCenter.ReleaseAll();
            FieldShip.Terminate();

            if (_nowInstantiate)
                return false;

            for (int i=0; i<_AssetReqOpeList.Count; i++)
            {
                if (_AssetReqOpeList[i] != null && !_AssetReqOpeList[i].isEnd)
                    return false;
            }

            for (int i=0; i<_AssetReqOpeList.Count; i++)
            {
                if (_AssetReqOpeList[i] != null)
                {
                    AssetManager.UnloadAssetBundle(_AssetReqOpeList[i].ReqOpe.assetBundleRequest.uri);
                    _AssetReqOpeList[i] = null;
                }
            }

            _AssetReqOpeList.Clear();
            _loadObjectList.Clear();
            _loadObjectIndex = 0;
            return true;
        }

        public bool IsLoadAssetBundle()
        {
            if (_AssetReqOpeList.Count < 1)
                return true;

            bool allLoaded = true;
            for (int i = 0; i < _AssetReqOpeList.Count; i++)
            {
                if (_AssetReqOpeList[i] != null)
                {
                    if (!_AssetReqOpeList[i].isEnd)
                    {
                        if (_AssetReqOpeList[i].ReqOpe.assetBundleRequest.isComplete)
                            _AssetReqOpeList[i].isEnd = true;
                        else
                            allLoaded = false;
                    }
                }
            }

            return allLoaded;
        }

        private void LoadObjectCreate(LoadObjectData lodata)
        {
            _nowInstantiate = true;

            if (lodata.AssetReqIndex == -1)
                LoadObjectCreate_BOX(lodata);
            else
                LoadObjectCreate_Asset(lodata);
        }

        private void LoadObjectCreate_BOX(LoadObjectData lodata)
        {
            var placedata = lodata.PlaceData;

            if (placedata.TalkLabel.Contains("ev_kinomi"))
            {
                _nowInstantiate = false;
                return;
            }

            var go = new GameObject();
            go.name = placedata.ID;
            go.transform.SetParent(_loadObjectParent);

            var fieldObject = go.AddComponent<FieldObjectEntity>();

            if (placedata.Size.x < 1.0f)
                placedata.Size.x = 1.0f;

            if (placedata.Size.y < 1.0f)
                placedata.Size.y = 1.0f;

            fieldObject.SetYawAngleDirect(lodata.Angle);
            fieldObject.transform.localScale = Vector3.one;

            var pos = new Vector3(lodata.Position.x >= 0.0f ? -lodata.Position.x : lodata.Position.x, lodata.Height, lodata.Position.y);

            var eventParams = fieldObject.EventParams;
            eventParams.ContactSize = new Vector2(placedata.Size.x, placedata.Size.y);
            eventParams.ContactLabel = placedata.ContactLabel;
            eventParams.TalkLabel = placedata.TalkLabel;
            eventParams.Type = EntityType.Board;
            eventParams.Dowsing = placedata.Dowsing;
            eventParams.HeightIgnore = placedata.HeightIgnore;
            eventParams.Rockclimb = placedata.TalkLabel == "ev_hiden_kabenobori";

            if (eventParams.Rockclimb)
                fieldObject.isLanding = false;

            eventParams.TalkRange = placedata.TalkToRange <= 0.0f ? 1.0f : placedata.TalkToRange;
            eventParams.LocaitionZoneID = placedata.zoneID;

            fieldObject.SetPositionDirect(pos);

            eventParams.VanishFlagIndex = placedata.Work >= EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE ? -1 : (int)placedata.Work;
            if (eventParams.VanishFlagIndex > -1 && eventParams.VanishFlagIndex != (int)EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE)
            {
                if (FlagWork.GetFlag(eventParams.VanishFlagIndex))
                    fieldObject.gameObject.SetActive(false);
            }

            eventParams.SaveObject = false;
            eventParams.TalkSegment = placedata.TalkToSize;
            eventParams.TalkBit = (byte)placedata.TalkBit;

            if (_fieldObjectEntity.Contains(fieldObject))
            {
                _ = _fieldObjectEntity.IndexOf(fieldObject);
            }
            else
            {
                _fieldObjectEntity.Add(fieldObject);
                eventParams.FieldObjectIndex = _fieldObjectEntity.Count - 1;
            }

            _nowInstantiate = false;
        }

        private void LoadObjectCreate_Asset(LoadObjectData lodata)
        {
            var placedata = lodata.PlaceData;

            var flag = placedata.Work;
            if (flag >= EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE)
                flag = (EvWork.FLAG_INDEX)(-1);

            var ogi = placedata.ObjectGraphicIndex;
            if (lodata.replaceGraphicIndex != -1)
                ogi = lodata.replaceGraphicIndex;

            if (ogi == 4 && !PlayerWork.playerSex)
                ogi = 0;

            var bundleRequest = _AssetReqOpeList[lodata.AssetReqIndex].ReqOpe.assetBundleRequest;
            var loadedAssets = bundleRequest.cache.loadedAssets;
            float contactSizeMin = 1.0f;
            for (int i=0; i<loadedAssets.Length; i++)
            {
                var loadedAsset = loadedAssets[i];

                if (loadedAsset != null && loadedAsset is GameObject)
                {
                    ((GameObject)loadedAsset).SetActive(false);
                    if (ogi >= Graphic_SekiZou && ogi < Graphic_SekiZouMAX)
                    {
                        for (int j=0; j<DataManager.statueEffectRawData.table.Length; j++)
                        {
                            var statue = DataManager.statueEffectRawData[j];
                            if (ogi - Graphic_SekiZou == statue.statueId)
                            {
                                var newObject = UnityEngine.Object.Instantiate((GameObject)loadedAsset, _loadObjectParent);
                                newObject.transform.localPosition = new Vector3(placedata.Position.x, placedata.HeightLayer, placedata.Position.y);
                                newObject.transform.localEulerAngles = new Vector3(0.0f, placedata.Rotation, 0.0f);
                                newObject.name = placedata.ID;
                                newObject.transform.localScale = new Vector3(statue.fieldScale, statue.fieldScale, statue.fieldScale);

                                bool visible = false;
                                if (flag > (EvWork.FLAG_INDEX)(-1) && flag != EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE)
                                    visible = FlagWork.GetFlag(flag);

                                newObject.SetActive(visible);
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (((GameObject)loadedAsset).GetComponent<FieldObjectEntity>() == null)
                            return;

                        var newObject = UnityEngine.Object.Instantiate((GameObject)loadedAsset, _loadObjectParent);
                        newObject.name = placedata.ID;
                        newObject.SetActive(true);

                        var fieldObject = newObject.GetComponent<FieldObjectEntity>();
                        var pos = FieldObjectEntity.GridToPosition(new Vector2Int((int)lodata.Position.x, (int)lodata.Position.y));
                        fieldObject.SetPositionDirect(new Vector3(pos.x, lodata.Height, pos.y));
                        fieldObject.SetYawAngleDirect(lodata.Angle);
                        fieldObject.transform.localScale = Vector3.one;

                        var eventParams = fieldObject.EventParams;
                        eventParams.ContactSize = new Vector2(placedata.Size.x <= contactSizeMin ? contactSizeMin : placedata.Size.x, placedata.Size.y <= contactSizeMin ? contactSizeMin : placedata.Size.y);

                        if (ogi < Graphic_Poke)
                        {
                            if (ogi < DataManager.CharacterGraphics.Data.Length)
                            {
                                fieldObject.transform.localScale = fieldObject.transform.localScale * DataManager.CharacterGraphics.Data[ogi].Scale;
                                var fieldCharacter = fieldObject as FieldCharacterEntity;
                                if (fieldCharacter != null)
                                {
                                    fieldCharacter.HandScale = DataManager.CharacterGraphics.Data[ogi].HandScale;
                                    if (ogi == 9)
                                        fieldCharacter.watchVisibility = true;
                                    else if (ogi == 8)
                                        fieldCharacter.watchVisibility = FlagWork.GetFlag(EvWork.FLAG_INDEX.FE_POKETCH_GET);

                                    fieldCharacter.SetAnimationEvents(DataManager.CharacterGraphics.Data[ogi].animTbl);
                                }

                                eventParams.IsObject = false;
                                eventParams.CharacterGraphicsIndex = ogi;
                            }
                        }
                        else
                        {
                            var scale = Vector3.one;

                            var uri = _AssetReqOpeList[lodata.AssetReqIndex].ReqOpe.assetBundleRequest.uri;
                            var splitUri = uri.Split(new char[1] { '/' });
                            uri = splitUri[splitUri.Length - 1];

                            var pokemonInfo = DataManager.PokemonInfo.Catalog.FirstOrDefault(__ => __.AssetBundleName == uri);
                            if (pokemonInfo != null)
                                scale *= pokemonInfo.FieldScale;

                            fieldObject.transform.localScale = scale * (placedata.Size.x <= 0.0f ? contactSizeMin : placedata.Size.x);

                            eventParams.IsObject = false;
                            if ((ogi >= 4250000 && ogi < 4260000) || (ogi >= 4270000 && ogi < 4280000))
                            {
                                var fieldPokemon = fieldObject as FieldPokemonEntity;
                                if (fieldPokemon != null)
                                    fieldPokemon.SetAlwaysAnimateCullingMode();
                            }
                        }

                        if (flag > (EvWork.FLAG_INDEX)(-1) && flag != EvWork.FLAG_INDEX.FLAG_END_SAVE_SIZE && FlagWork.GetFlag(flag))
                            fieldObject.SetActive(false);

                        if (PlayerWork.isDebugNpcVisble)
                            fieldObject.SetActive(false);

                        if (placedata.MoveParam2 == 1)
                        {
                            var originBone = fieldObject.transform.Find("Origin");
                            originBone.localPosition = new Vector3(originBone.localPosition.x, (fieldObject.transform.localScale.y - 1.0f) * 10.0f * -0.04f, originBone.localPosition.z);
                        }

                        eventParams.ContactLabel = placedata.ContactLabel;
                        eventParams.TalkLabel = placedata.TalkLabel;
                        eventParams.VanishFlagIndex = (int)flag;
                        eventParams.Type = EntityType.Npc;
                        eventParams.Dowsing = placedata.Dowsing;
                        eventParams.HeightIgnore = placedata.HeightIgnore;
                        eventParams.Kairiki = placedata.ObjectGraphicIndex == 503;
                        eventParams.Iwakudaki = placedata.ObjectGraphicIndex == 502;
                        eventParams.Iaigiri = placedata.ObjectGraphicIndex == 501;
                        eventParams.SnowBall = placedata.ObjectGraphicIndex == 506;
                        eventParams.AzukariyaOldMan = placedata.TalkLabel.Contains("ev_sodateya_m");
                        eventParams.HoneyTree = placedata.ObjectGraphicIndex == 505;
                        eventParams.Sit = placedata.MoveParam2 == 1;
                        eventParams.IdleAnimOverride = -1;
                        eventParams.WalkAnimOverride = -1;

                        switch (placedata.MoveParam2)
                        {
                            case 2:
                                eventParams.IdleAnimOverride = 34;
                                eventParams.WalkAnimOverride = 35;
                                break;

                            case 3:
                                eventParams.IdleAnimOverride = 18;
                                break;

                            case 4:
                                eventParams.BattleReturnNotRotate = true;
                                break;

                            case 2400:
                                eventParams.IdleAnimOverride = 24;
                                break;
                        }

                        if (eventParams.Sit)
                            eventParams.BattleReturnNotRotate = true;

                        eventParams.TrainerID = placedata.TrainerID;
                        eventParams.TalkRange = placedata.TalkToRange <= 0.0f ? contactSizeMin : placedata.TalkToRange;
                        eventParams.LocaitionZoneID = placedata.zoneID;
                        eventParams.TalkSegment = placedata.TalkToSize;
                        eventParams.TalkBit = (byte)placedata.TalkBit;

                        var moveCode = new FieldObjectMoveCode();
                        moveCode.SetEntity(fieldObject);
                        moveCode._mv_defaultPosition = new Vector3Int((int)-placedata.Position.x, placedata.HeightLayer, (int)placedata.Position.y);
                        moveCode.Ev_Type = lodata.Ev_Type;
                        moveCode.MoveCode = lodata.MoveCode;
                        moveCode.MoveParam0 = lodata.MoveParam0;
                        moveCode.MoveParam1 = lodata.MoveParam1;
                        moveCode.MoveParam2 = lodata.MoveParam2;
                        moveCode.MoveLimitX = lodata.MoveLimitX;
                        moveCode.MoveLimitZ = lodata.MoveLimitZ;
                        moveCode.mv_dir = lodata.mv_dir;
                        moveCode.mv_old_dir = lodata.mv_old_dir;
                        moveCode.MoveDirHead = lodata.MoveDirHead;
                        moveCode.Param_from_LoadData = lodata.useloadData;
                        moveCode.BaseMoveCode = placedata.MoveCode;

                        if (placedata.TrainerID != TrainerID.NONE)
                        {
                            moveCode.OnEyeAction = OnEyeCallBack;
                            moveCode.TrainerID = placedata.TrainerID;
                        }

                        int index;
                        if (FieldObjectMoveCodes.Contains(moveCode))
                        {
                            index = FieldObjectMoveCodes.IndexOf(moveCode);
                        }
                        else
                        {
                            FieldObjectMoveCodes.Add(moveCode);
                            index = FieldObjectMoveCodes.Count - 1;
                        }

                        eventParams.MoveCodeIndex = index;

                        var colorVariation = fieldObject.GetComponent<ColorVariation>();
                        if (colorVariation != null)
                        {
                            if (placedata.ColorIndex < 0)
                                colorVariation.ColorIndex = PlayerWork.colorID;
                            else
                                colorVariation.ColorIndex = placedata.ColorIndex;
                        }

                        if (_fieldObjectEntity.Contains(fieldObject))
                        {
                            _ = _fieldObjectEntity.IndexOf(fieldObject);
                        }
                        else
                        {
                            _fieldObjectEntity.Add(fieldObject);
                            eventParams.FieldObjectIndex = _fieldObjectEntity.Count - 1;
                        }
                    }
                }
            }

            _nowInstantiate = false;
        }

        private void LoadObjectCreate_KinomiGrow(KinomiPlaceData.SheetSheet1 kinomiPlaceData)
        {
            var pos = FieldObjectEntity.Vec2ToVec3Position(FieldObjectEntity.GridToPosition(new Vector2Int((int)kinomiPlaceData.Position.x, (int)kinomiPlaceData.Position.z)), kinomiPlaceData.Position.y);

            var obj = new GameObject();
            obj.name = kinomiPlaceData.ID;
            obj.transform.SetParent(_loadObjectParent);

            var growEntity = obj.AddComponent<FieldKinomiGrowEntity>();
            growEntity.transform.localEulerAngles = Vector3.zero;
            growEntity.transform.localScale = Vector3.one;
            growEntity.SetPositionDirect(pos);
            growEntity.KinomiPlaceIndex = kinomiPlaceData.Index;
            growEntity.EventParams.ContactSize.x = pos.x;
            growEntity.EventParams.ContactSize.y = pos.y;
            growEntity.EventParams.ContactLabel = string.Empty;
            growEntity.EventParams.TalkLabel = "ev_kinomi";
            growEntity.EventParams.Type = EntityType.Board;
            growEntity.EventParams.TalkRange = DataManager.GetFieldCommonParam(ParamIndx.KinomiTalkRange);
            growEntity.EventParams.TalkAngle = -1.0f;
            growEntity.EventParams.TalkSegment = Vector2.zero;
            growEntity.EventParams.TalkBit = 0xF;

            FieldObjectEntityAdd(growEntity);

            _FieldKinomiGrowEntity.Add(growEntity);
            growEntity.UpdateStatus();
            _nowInstantiate = false;
        }

        public int FieldObjectEntityAdd(FieldObjectEntity entity)
        {
            if (!_fieldObjectEntity.Contains(entity))
            {
                _fieldObjectEntity.Add(entity);
                entity.EventParams.FieldObjectIndex = _fieldObjectEntity.Count - 1;
                return entity.EventParams.FieldObjectIndex;
            }
            else
            {
                return _fieldObjectEntity.IndexOf(entity);
            }
        }

        // TODO
        public void FieldObjectEntityRemove(FieldObjectEntity entity) { }

        public class EntityParam
        {
            public const int NearNone = -10;

            public string TalkLabel = "";
            public string ContactLabel = "";
            public int VanishFlagIndex = -1;
            public bool IsContact = true;
            public EvWork.WORK_INDEX WorkIndex = EvWork.WORK_INDEX.SCWK_WK_SAVE_SIZE;
            public int WorkValue = -1;
            public EntityType Type;
            public RectInt StopGridArea;
            public bool IsEventRunning;
            public int MoveCodeIndex = -1;
            public bool Kairiki;
            public bool Iwakudaki;
            public bool Iaigiri;
            public bool Rockclimb;
            public int Dowsing;
            public bool SnowBall;
            public bool AzukariyaOldMan;
            public bool HoneyTree;
            public bool HeightIgnore;
            public Vector2 ContactSize;
            public bool IsContactCenter;
            public bool Sit;
            public int IdleAnimOverride = -1;
            public int WalkAnimOverride = -1;
            public TrainerID TrainerID;
            public int FieldObjectIndex = -1;
            public int[] NearObject = new int[8];
            public float TalkRange = 1.0f;
            public bool isTalkHit;
            public float TalkAngle;
            public bool SaveObject = true;
            public ZoneID LocaitionZoneID;
            public bool IsObject = true;
            public Vector2 TalkSegment;
            public byte TalkBit;
            public int CharacterGraphicsIndex = -1;
            public bool BattleReturnNotRotate;
            public bool isNoPlayerHit;
            public bool IsInvalidVanishActive;
        }

        public enum EntityType : int
        {
            Stop = 0,
            Warp = 1,
            Board = 2,
            Npc = 3
        }

        private enum CmpResult : int
        {
            MINUS = 0,
            EQUAL = 1,
            PLUS = 2
        }

        private struct EvCallData
        {
            public int EventListIndex;
            public int LabelIndex;
            public int CommandIndex;
        }

        private struct PlaySeData
        {
            public string name;
            public AudioInstance AudioInstance;
            public uint playEventId;
        }

        public delegate void UpdateDelegate(float time);
        public delegate void EventEndDelegate();

        private struct WorpEventData
        {
            public FieldEventDoorEntity Entity;
            public int State;
            public float Time;
        }

        private enum COMMAND_USE_TIME : int
        {
            Week = 0,
            Month = 1,
            Day = 2,
            Hour = 3,
            Minute = 4,
        }

        private enum MsgWindowType : int
        {
            DEFAULT = 0,
            NAME_PLATE = 1,
            BOARD_TYPE_TOWN = 2,
            BOARD_TYPE_ROAD = 3,
            BOARD_TYPE_POST = 4,
            BOARD_TYPE_INFO = 5,
            ITEM = 6,
            END = 7
        }

        private enum MsgEndType : int
        {
            Input = 0,
            Auto = 1,
            Time = 2,
            Manual = 3
        }

        private struct MsgOpenParam
        {
            public string MsbtFile;
            public string Label;
            public int LabelIndex;
            public MsgWindowType WindowType;
            public bool Input;
            public string[] TrainerName;
            public MsgEndType EndType;
            public bool PlayTextFeedSe;
        }

        private enum BOARD : int
        {
            BOARD_REQ_WAIT = 0,
            BOARD_REQ_ADD = 1,
            BOARD_REQ_DOWN = 2,
            BOARD_REQ_UP = 3,
            BOARD_REQ_DEL = 4,
            END = 5
        }

        private enum TalkState : int
        {
            Init = 0,
            EndWait = 1,
            CloseWait = 2
        }

        private enum HeroReqBit : int
        {
            Non = 0,
            Normal = 1,
            Banzai = 256
        }

        private enum CutInState : int
        {
            None = 0,
            ResetForm = 1,
            PostResetForm = 2,
            Rotate = 3,
            PoketchAnimeStart = 4,
            WaitLoad = 5,
            WaitCutIn = 6,
            Sorawotobu_WaitPlayEffect = 7,
            Sorawotobu_WaitPreCaptureInvisible = 8,
            Sorawotobu_WaitNextCommand = 9,
            PoketchAnimeEnd = 10,
            End = 11
        }

        private enum WazaOshieResult : int
        {
            OK = 0,
            NG = 1,
            Egg = 2,
            Learned = 3,
        }

        private class LoadObjectData
        {
            public bool IsLoadFast;
            public int Distance;
            public bool IsCreated;
            public int AssetReqIndex = -1;
            public string ObjectName = "";
            public PlaceData.SheetData PlaceData;
            public Vector2 Position = Vector2.zero;
            public float Height;
            public float Angle;
            public int MoveCode;
            public DIR MoveDirHead;
            public int MoveParam0;
            public int MoveParam1;
            public int MoveParam2;
            public int MoveLimitX;
            public int MoveLimitZ;
            public int Ev_Type;
            public int mv_old_dir;
            public int mv_dir;
            public bool useloadData;
            public int replaceGraphicIndex = -1;
        }

        private class AssetReqOpeRef
        {
            public AssetRequestOperation ReqOpe;
            public int RefCount;
            public bool isEnd;
        }

        private class CreateWarp
        {
            public int index;
            public MapWarp.SheetData data;
        }
    }
}