using AK;
using Audio;
using DPData;
using Dpr.Battle.Logic;
using Dpr.Battle.View;
using Dpr.Battle.View.Systems;
using Dpr.Box;
using Dpr.EvScript;
using Dpr.Item;
using Dpr.Message;
using GameData;
using Pml;
using Pml.PokePara;
using Pml.WazaData;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.Events;
using UnityEngine.Profiling;
using UnityEngine.U2D;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.UI
{
    public class UIManager : SingletonMonoBehaviour<UIManager>
    {
        [SerializeField]
        private Transform _activeRoot;
        [SerializeField]
        private UIModelViewController _modelView;
        [SerializeField]
        private Transform _blurBgRoot;

        public static int StickLLeft = 0;
        public static int StickLRight = 0;
        public static int StickLUp = 0;
        public static int StickLDown = 0;
        public static int ButtonA = 0;
        public static int ButtonB = 0;
        public static int ButtonX = 0;
        public static int ButtonY = 0;
        public static int ButtonPlusMinus = GameController.ButtonMask.Plus | GameController.ButtonMask.Minus;

        private const int _sortingOrderPoketch = 200;
        private const int _sortingOrderWindow = 400;
        private const int _sortingOrderContextMenu = 9900;
        private const int _sortingOrderTransition = 16384;
        private const int _sortingOrderFatalErrorDialog = 16484;
        private const int _sortingOrderWindowAdd = 100;
        private const int _sortingOrderIgnore = 9900;

        private const string _hpBarSpriteName = "cmn_pl_txt_hpbar_01";

        private UIDatabase _mdUis;
        private TownMapGuideTable _mdTownmapGuide;
        private TownMapTable _mdTownmap;
        private DistributionTable _mdDistribution;
        private PlaceNameTable _mdPlaceName;
        private InputLimitTable _mdInputLimit;
        private HashSet<int>[] _inputLimitHashSets = new HashSet<int>[5];
        private SearchIndexData _mdSearchIndexData;
        private Dictionary<BallId, MonsterBallParam> _spriteMonsterBallDict = new Dictionary<BallId, MonsterBallParam>();
        private Sprite _spriteMonsterBallStrange;
        private Sprite _spriteMonsterBallIllegal;
        private List<SpriteAtlasParam> _spriteAtlasParams = new List<SpriteAtlasParam>();
        private Keyguide _keyguide;
        private int _InitializeStateBits;
        private UnityAction<UIWindow> onXMenuClosed;
        private bool _fureaiLimit;

        public static UnityAction<ZoneID, int> onWazaFly = null;
        public static UnityAction<int> onDressChanged = null;
        public static Func<FieldWazaParam, FieldUseResult> onFieldWaza = null;
        public static Func<ItemInfo, FieldUseResult> onUseFieldItem = null;
        public static Action<int, int, ItemInfo> onUseItemInBattle = null;
        public static Action<FieldPoketch.HidenWazaType> onUseHidenWaza = null;
        public static Func<Vector2, FieldPoketch.DowsingResult> onUseDowsing = null;

        private ObjectPool<UIWindowID, UIInstance> _objectPool = new ObjectPool<UIWindowID, UIInstance>();
        private ObjectPool<TransitionID, TransitionInstance> _objectPoolTransition = new ObjectPool<TransitionID, TransitionInstance>();
        private List<TransitionInstance> _transitionInstances = new List<TransitionInstance>();
        private TransitionID _transitionId = (TransitionID)(-1);
        private bool _isFadeTransition;
        private CacheList<CacheSpritePokemonParam> _cacheSpritePokemons = new CacheList<CacheSpritePokemonParam>(10);
        private RawImage _blurBg;
        private BlugBgParam _blurBgParam = new BlugBgParam();
        private float _debugInstrument;
        private string[] _databaseAssetBundleNames = new string[1] { "masterdatas/uimasterdatas" };
        private bool _isLoadedDatabase;
        private Dictionary<AtlasSpriteKey, Sprite> _atlasSpriteDict = new Dictionary<AtlasSpriteKey, Sprite>();
        private string _assetPathIndexdata = "searchdatas/indexdata";
        private UIWindowID[] _transitionWindowIds = new UIWindowID[2] { UIWindow.WINDOWID_FIELD, UIWindow.WINDOWID_FIELD };
        private XMenuTop _xMenu;

        private static ComparerPokemonIcon _comparerPokemonIcon = new ComparerPokemonIcon();
        private static ComparerAshiatoIcon _comparerAshiatoIcon = new ComparerAshiatoIcon();
        private static ComparerZukanDisplay _comparerZukanDisplay = new ComparerZukanDisplay();
        private static ComparerPokemonVoice _comparerPokemonVoice = new ComparerPokemonVoice();
        private static ComparerZukanCompareHeight _comparerZukanCompareHeight = new ComparerZukanCompareHeight();
        private static readonly LangParam[] _langParams = new LangParam[9]
        {
            new LangParam() { langId = MessageEnumData.MsgLangId.JPN, label = "SS_status_83", ietfTags = new string[1]{ "ja" } },
            new LangParam() { langId = MessageEnumData.MsgLangId.USA, label = "SS_status_84", ietfTags = new string[1]{ "en-US" } },
            new LangParam() { langId = MessageEnumData.MsgLangId.ESP, label = "SS_status_85", ietfTags = new string[1]{ "es" } },
            new LangParam() { langId = MessageEnumData.MsgLangId.FRA, label = "SS_status_86", ietfTags = new string[1]{ "fr" } },
            new LangParam() { langId = MessageEnumData.MsgLangId.DEU, label = "SS_status_87", ietfTags = new string[1]{ "de" } },
            new LangParam() { langId = MessageEnumData.MsgLangId.ITA, label = "SS_status_88", ietfTags = new string[1]{ "it" } },
            new LangParam() { langId = MessageEnumData.MsgLangId.KOR, label = "SS_status_91", ietfTags = new string[1]{ "ko" } },
            new LangParam() { langId = MessageEnumData.MsgLangId.TCH, label = "SS_status_92", ietfTags = new string[1]{ "zh-Hant" } },
            new LangParam() { langId = MessageEnumData.MsgLangId.SCH, label = "SS_status_93", ietfTags = new string[1]{ "zh-Hans" } },
        };
        private static List<PokemonParamMapping> _pokemonParamMappings = new List<PokemonParamMapping>();
        private static int _id_GrayscaleAmount = Shader.PropertyToID("_GrayscaleAmount");
        private static ComparerTownMapGuide _comparerTownMapGuide = new ComparerTownMapGuide();
        private static ComparerPlaceName _comparerPlaceName = new ComparerPlaceName();

        private NowloadingController _nowLoadingController;

        public static bool isInitialized { get => _instance != null ? ((InitializeStateBit)_instance._InitializeStateBits).HasFlag(InitializeStateBit.Loaded) : false; }
        public TransitionID transitionId { get => _transitionId; }
        public bool isFadeTransition { get => _isFadeTransition; }
        public RectTransform modelBgRoot { get => _modelView.modelBgRoot; }
        public UIDatabase database { get => _mdUis; }
        public TownMapGuideTable townMapGuideTable { get => _mdTownmapGuide; }
        public TownMapTable townMapTable { get => _mdTownmap; }
        public DistributionTable distributionTable { get => _mdDistribution; }
        public PlaceNameTable placeNameTable { get => _mdPlaceName; }
        public InputLimitTable inputLimitTable { get => _mdInputLimit; }
        public bool IsResidentSpriteAtlases { get => ((InitializeStateBit)_InitializeStateBits).HasFlag(InitializeStateBit.LoadedSpriteAtlas); }
        public UIModelViewController modelView { get => _modelView; }
        public SearchIndexData searchIndexData { get => _mdSearchIndexData; }

        protected override bool Awake()
        {
            _blurBg = _blurBgRoot.GetComponentInChildren<RawImage>();
            _blurBg.color = new Color(_blurBg.color.r, _blurBg.color.g, _blurBg.color.b, 0.0f);
            return base.Awake();
        }

        public void RegisterOnDestroy()
        {
            Sequencer.onDestroy -= Destroy;
            Sequencer.onDestroy += Destroy;
        }

        private void OnEnable()
        {
            SpriteAtlasManager.atlasRequested += OnAtlasRequested;
        }

        private void OnDisable()
        {
            SpriteAtlasManager.atlasRequested -= OnAtlasRequested;
        }

        private void Destroy()
        {
            Sequencer.onDestroy -= Destroy;

            UnloadResidentWindows(false);
            UnloadResidentSpriteAtlases(false);
            UnloadResidentSpriteAtlases(true, MessageHelper.ConvertMsgId(PlayerWork.msgLangID));
            UnloadAssetBundle(_assetPathIndexdata, true, MessageHelper.ConvertMsgId(PlayerWork.msgLangID));
            BattleViewUISystem.UnloadAssetSelf();
            UnloadDatabase();
        }

        public IEnumerator Start()
        {
            while (_mdUis == null)
                yield return null;

            _spriteAtlasParams.Clear();

            for (int i=0; i<_mdUis.SpriteAtlas.Length; i++)
            {
                var param = new SpriteAtlasParam();
                param.assetBundleName = _mdUis.SpriteAtlas[i].AssetBundleName;
                param.assetName = _mdUis.SpriteAtlas[i].AssetName;
                _spriteAtlasParams.Add(param);
            }

            _SetupKeyAssign(INPUTMODE.INPUTMODE_NORMAL);
            _modelView.gameObject.SetActive(false);
        }

        public void LoadResidents()
        {
            Sequencer.Start(OpLoad(0, false));
        }

        public void LoadWindows(bool isOpening)
        {
            if (((InitializeStateBit)_InitializeStateBits).HasFlag(InitializeStateBit.EntryWindows))
                return;

            Sequencer.Start(OpLoad(1, isOpening));
        }

        public void Reload(MessageEnumData.MsgLangId unloadLangId, UnityAction onComplete)
        {
            Sequencer.Start(OpReload(unloadLangId, onComplete, null));
        }

        private IEnumerator OpReload(MessageEnumData.MsgLangId unloadLangId, UnityAction onComplete, [Optional] UnityAction onUnloadComplete)
        {
            BeginDebugInstrument();
            _InitializeStateBits &= ~(int)(InitializeStateBit.EntryWindows | InitializeStateBit.LoadedWindows | InitializeStateBit.EntryAterLang | InitializeStateBit.LoadAterLang);

            ClearAtlasSprites();
            UnloadResidentWindows(false);
            UnloadResidentSpriteAtlases(true, unloadLangId);
            UnloadSearchIndexData(unloadLangId);

            var unloader = BattleViewUISystem.UnloadAssetSelf();
            while (!unloader.isUnloaded)
                yield return null;

            DebugInstrument("Reset Unload");
            onUnloadComplete?.Invoke();

            yield return OpLoad(1, false);

            onComplete?.Invoke();
            yield return null;
        }

        private void BeginDebugInstrument()
        {
            _debugInstrument = Time.realtimeSinceStartup;
        }

        private void DebugInstrument(string label)
        {
            _debugInstrument = Time.realtimeSinceStartup;
        }

        private IEnumerator OpLoad(int type, bool isOpening = false)
        {
            switch (type)
            {
                case 0:
                    _InitializeStateBits |= (int)InitializeStateBit.EntrySpriteAtlas;
                    BeginDebugInstrument();

                    yield return OpLoadResidentSpriteAtlases(false);

                    SetupSpriteMonsterBall();
                    _InitializeStateBits |= (int)InitializeStateBit.LoadedSpriteAtlas;
                    DebugInstrument(InitializeStateBit.LoadedSpriteAtlas.ToString());
                    break;

                case 1:
                    _InitializeStateBits |= (int)InitializeStateBit.EntryWindows;
                    if (!isOpening)
                    {
                        Sequencer.Start(DoParallel());
                        yield break;
                    }
                    BeginDebugInstrument();

                    yield return OpLoadResidentWindows(true);

                    _InitializeStateBits |= (int)InitializeStateBit.LoadedWindows;
                    DebugInstrument(InitializeStateBit.LoadedWindows.ToString());
                    break;

                default:
                    yield break;
            }
        }

        private IEnumerator DoParallel()
        {
            BeginDebugInstrument();

            yield return OpLoadResidentSpriteAtlases(true);
            yield return OpLoadResidentWindows(false);

            _InitializeStateBits |= (int)InitializeStateBit.LoadedWindows;
            DebugInstrument(InitializeStateBit.LoadedWindows.ToString());
        }

        public bool isLoadedDatabase { get => _isLoadedDatabase; }

        public void LoadDatabase()
        {
            Sequencer.Start(OpLoadDatabase());
        }

        private IEnumerator OpLoadDatabase()
        {
            _isLoadedDatabase = false;
            BeginDebugInstrument();

            for (int i=0; i<_databaseAssetBundleNames.Length; i++)
                AssetManager.AppendAssetBundleRequest(_databaseAssetBundleNames[i], true, null, null);

            yield return AssetManager.DispatchRequests((eventType, name, asset) =>
            {
                if (eventType != RequestEventType.Activated)
                    return;

                var scriptableObject = asset as ScriptableObject;
                if (scriptableObject == null)
                    return;

                switch (name)
                {
                    case "UIDatabase":
                        _mdUis = scriptableObject as UIDatabase;
                        break;

                    case "TownMapGuideTable":
                        _mdTownmapGuide = scriptableObject as TownMapGuideTable;
                        break;

                    case "TownMapTable":
                        _mdTownmap = scriptableObject as TownMapTable;
                        break;

                    case "DistributionTable":
                        _mdDistribution = scriptableObject as DistributionTable;
                        break;

                    case "PlaceNameTable":
                        _mdPlaceName = scriptableObject as PlaceNameTable;
                        break;

                    case "InputLimitTable":
                        _mdInputLimit = scriptableObject as InputLimitTable;
                        CreateInputLimitHashSet(InputLimitType.JPN, _mdInputLimit.J);
                        CreateInputLimitHashSet(InputLimitType.KOR, _mdInputLimit.K);
                        CreateInputLimitHashSet(InputLimitType.TCH, _mdInputLimit.TC);
                        CreateInputLimitHashSet(InputLimitType.SCH, _mdInputLimit.SC);
                        CreateInputLimitHashSet(InputLimitType.EFIGS, _mdInputLimit.EFIGS);
                        break;
                }
            });

            DebugInstrument("uimasterdatas");
            _isLoadedDatabase = true;
        }

        private void UnloadDatabase()
        {
            for (int i=0; i<_databaseAssetBundleNames.Length; i++)
                AssetManager.UnloadAssetBundle(_databaseAssetBundleNames[i]);

            _isLoadedDatabase = false;
        }

        private void CreateInputLimitHashSet(InputLimitType type, SheetInputLimitTable[] inputLimitDatas)
        {
            HashSet<int> hashSet = new HashSet<int>();
            for (int i=0; i<inputLimitDatas.Length; i++)
                hashSet.Add(inputLimitDatas[i].DecimalNumber);

            _inputLimitHashSets[(int)type] = hashSet;
        }

        private void UnloadResidentSpriteAtlases(bool isVariant, MessageEnumData.MsgLangId langId = (MessageEnumData.MsgLangId)(-1))
        {
            var spriteAtlasIds = new List<SpriteAtlasID>();
            for (int i=0; i<_mdUis.SpriteAtlas.Length; i++)
            {
                if (_mdUis.SpriteAtlas[i].Resident && _mdUis.SpriteAtlas[i].IsLanguage == isVariant)
                    spriteAtlasIds.Add((SpriteAtlasID)i);
            }

            UnloadSpriteAtlases(spriteAtlasIds, isVariant, langId);
        }

        private IEnumerator OpLoadResidentSpriteAtlases(bool isVariant)
        {
            var atlases = new List<SpriteAtlasID>();

            for (int i=0; i<_mdUis.SpriteAtlas.Length; i++)
            {
                if (_mdUis.SpriteAtlas[i].Resident && _mdUis.SpriteAtlas[i].IsLanguage == isVariant)
                    atlases.Add((SpriteAtlasID)i);
            }

            yield return OpLoadSpriteAtlases(atlases, isVariant);
        }

        private IEnumerator OpLoadSpriteAtlases(List<SpriteAtlasID> spriteAtlasIds, bool isVariant)
        {
            yield return null;

            for (int i=0; i<spriteAtlasIds.Count; i++)
            {
                var item = spriteAtlasIds[i];
                var spriteAtlasParam = _spriteAtlasParams[(int)item];

                spriteAtlasParam.variantAssetBundleName = isVariant ? MessageHelper.AddVariantNameToPath(spriteAtlasParam.assetBundleName) : null;
                AssetManager.AppendAssetBundleRequest(_mdUis.SpriteAtlas[(int)item].AssetBundleName, true, null, isVariant ? MessageHelper.GetLocalizeVariants() : null);
            }

            yield return AssetManager.DispatchRequests((eventType, name, asset) =>
            {
                if (eventType != RequestEventType.Activated)
                    return;

                var spriteAtlas = asset as SpriteAtlas;
                if (spriteAtlas == null)
                    return;

                _spriteAtlasParams[FindSpriteAtlasIndex(name)].SetSpriteAtlas(spriteAtlas);
            });
        }

        private int FindSpriteAtlasIndex(string assetName)
        {
            for (int i=0; i<_mdUis.SpriteAtlas.Length; i++)
            {
                if (_mdUis.SpriteAtlas[i].AssetName == assetName)
                    return i;
            }

            return -1;
        }

        public void UnloadSpriteAtlases(List<SpriteAtlasID> spriteAtlasIds, bool isVariant, MessageEnumData.MsgLangId langId)
        {
            for (int i=0; i<spriteAtlasIds.Count; i++)
            {
                UnloadAssetBundle(_spriteAtlasParams[(int)spriteAtlasIds[i]].assetBundleName, isVariant, langId);
                _spriteAtlasParams[(int)spriteAtlasIds[i]].Clear();
            }
        }

        private void OnAtlasRequested(string name, Action<SpriteAtlas> atlasCallback)
        {
            if (_mdUis == null)
            {
                Sequencer.Start(OpWaitDatabase(name, atlasCallback));
            }
            else
            {
                for (int i=0; i<_spriteAtlasParams.Count; i++)
                {
                    if (_spriteAtlasParams[i].assetName == name)
                    {
                        if (_spriteAtlasParams[i] == null)
                            break;

                        _spriteAtlasParams[i].SetAtlasCallback(atlasCallback);
                        break;
                    }
                }
            }
        }

        private IEnumerator OpWaitDatabase(string name, Action<SpriteAtlas> atlasCallback)
        {
            while (_mdUis == null)
                yield return null;

            OnAtlasRequested(name, atlasCallback);
        }

        public SpriteAtlas GetSpriteAtlas(SpriteAtlasID spriteAtlasId)
        {
            return _spriteAtlasParams[(int)spriteAtlasId].spriteAtlas;
        }

        public Sprite GetAtlasSprite(SpriteAtlasID spriteAtlasId, string name)
        {
            if (!_atlasSpriteDict.TryGetValue(new AtlasSpriteKey() { spriteAtlasId = spriteAtlasId, name = name }, out Sprite sprite))
            {
                sprite = GetSpriteAtlas(spriteAtlasId).GetSprite(name);
                _atlasSpriteDict.Add(new AtlasSpriteKey() { spriteAtlasId = spriteAtlasId, name = name }, sprite);
            }

            return sprite;
        }

        public void ClearCachedSprites()
        {
            // Empty
        }

        public void ClearAtlasSprites()
        {
            var keys = _atlasSpriteDict.Keys.ToArray();
            for (int i=0; i<keys.Length; i++)
            {
                var param = _spriteAtlasParams.FirstOrDefault(x => x.spriteAtlasId == keys[i].spriteAtlasId);
                if (param == null)
                    _atlasSpriteDict.Remove(keys[i]);
            }
        }

        public void ClearAtlasSprite(SpriteAtlasID spriteAtlasId)
        {
            var arr = _atlasSpriteDict.Keys.ToArray();
            if (arr.Length < 1)
                return;

            for (int i=0; i<arr.Length; i++)
            {
                if (arr[i].spriteAtlasId == spriteAtlasId)
                    _atlasSpriteDict.Remove(arr[i]);
            }
        }

        private void SetupSpriteMonsterBall()
        {
            _spriteMonsterBallDict.Clear();

            for (int i=0; i<_mdUis.MonsterBall.Length; i++)
            {
                var monsterBallData = _mdUis.MonsterBall[i];
                if (monsterBallData.BallId != BallId.NULL)
                {
                    ItemInfo.LoadItemIcon((int)monsterBallData.ItemNo, sprite =>
                    {
                        var item = new MonsterBallParam();
                        _spriteMonsterBallDict.Add(monsterBallData.BallId, item);
                    }, false, false);
                }
            }

            _spriteMonsterBallStrange = GetAtlasSprite(SpriteAtlasID.COMMON, _mdUis.CommonSprite[21].SpriteName);
            _spriteMonsterBallIllegal = GetAtlasSprite(SpriteAtlasID.COMMON, _mdUis.CommonSprite[22].SpriteName);
        }

        public IEnumerator LoadSearchIndexData()
        {
            AssetManager.AppendAssetBundleRequest(_assetPathIndexdata, true, null, MessageHelper.GetLocalizeVariants());

            yield return AssetManager.DispatchRequests((eventType, name, asset) =>
            {
                if (eventType != RequestEventType.Activated)
                    return;

                var scriptableObject = asset as ScriptableObject;
                if (scriptableObject == null)
                    return;

                _mdSearchIndexData = scriptableObject as SearchIndexData;
            });
        }

        private void UnloadSearchIndexData(MessageEnumData.MsgLangId langId)
        {
            UnloadAssetBundle(_assetPathIndexdata, true, langId);
        }

        public void InitializeAfterLangDecide([Optional] UnityAction onComplete)
        {
            Sequencer.Start(OpInitializeAfterLangDecide(onComplete));
        }

        public IEnumerator OpInitializeAfterLangDecide([Optional] UnityAction onComplete)
        {
            if (((InitializeStateBit)_InitializeStateBits).HasFlag(InitializeStateBit.EntryAterLang))
            {
                onComplete?.Invoke();
                yield break;
            }

            _InitializeStateBits |= (int)InitializeStateBit.EntryAterLang;

            yield return BattleViewUISystem.LoadAssetSelf(GameManager.battleObjectHolder, null);
            yield return Instance.LoadSearchIndexData();

            ItemWork.Create();
            _InitializeStateBits |= (int)InitializeStateBit.LoadAterLang;
            onComplete?.Invoke();
        }

        public static bool IsMaleDress(CharacterDressData.SheetData dressData)
        {
            return dressData.Index < 100;
        }

        public void PlayTransition(TransitionID transitionId, UITransition.FadeType fadeType, [Optional] UnityAction<UITransition.FadeType> onComplete)
        {
            if (fadeType != UITransition.FadeType.In)
                _transitionId = (TransitionID)(-1);
            else
                _transitionId = transitionId;

            onComplete?.Invoke(fadeType);
        }

        private IEnumerator OpLoadResidentWindows(bool isCheckFirstLoad = false)
        {
            var windows = new List<UIWindowID>();

            for (int i=0; i<_mdUis.UIWindow.Length; i++)
            {
                if (_mdUis.UIWindow[i].Resident && (!isCheckFirstLoad || _mdUis.UIWindow[i].Firstload))
                    windows.Add((UIWindowID)i);
            }

            yield return OpLoadWindows(windows, true);
        }

        private void UnloadResidentWindows(bool isCheckFirstLoad)
        {
            var bundles = new HashSet<string>();

            for (int i=0; i<_mdUis.UIWindow.Length; i++)
            {
                var item = _mdUis.UIWindow[i];
                if (item.Resident && (!isCheckFirstLoad || item.Firstload))
                {
                    bundles.Add(item.AssetBundleName);
                    _objectPool.Destroies((UIWindowID)i);
                }
            }

            foreach (var bundle in bundles)
                UnloadAssetBundle(bundle, false);
        }

        private void UnloadWindows(List<UIWindowID> windowIds)
        {
            var bundles = new HashSet<string>();

            for (int i=0; i<windowIds.Count; i++)
            {
                bundles.Add(_mdUis.UIWindow[(int)windowIds[i]].AssetBundleName);
                _objectPool.Destroies(windowIds[i]);
            }

            foreach (var bundle in bundles)
                UnloadAssetBundle(bundle, false);
        }

        public IEnumerator OpLoadWindows(List<UIWindowID> windowIds, bool isVariant = true)
        {
            var bundles = new HashSet<string>();

            for (int i=0; i<windowIds.Count; i++)
                bundles.Add(_mdUis.UIWindow[i].AssetBundleName);

            foreach (var bundle in bundles)
                AssetManager.AppendAssetBundleRequest(bundle, true, null, isVariant ? MessageHelper.GetLocalizeVariants() : null);

            yield return AssetManager.DispatchRequests((eventType, name, asset) =>
            {
                if (eventType != RequestEventType.Activated)
                    return;

                var go = asset as GameObject;
                if (go == null)
                    return;

                int foundWindow = -1;
                for (int i=0; i<_mdUis.UIWindow.Length; i++)
                {
                    if (_mdUis.UIWindow[i].AssetName == name)
                    {
                        foundWindow = i;
                        break;
                    }
                }

                _objectPool.Destroies((UIWindowID)foundWindow);
                _objectPool.Instantiates(0, (UIWindowID)foundWindow, go, transform);
            });
        }

        private int UnloadAssetBundle(string assetBundleName, bool isVariant, MessageEnumData.MsgLangId langId = (MessageEnumData.MsgLangId)(-1))
        {
            string bundleName = assetBundleName;

            if (isVariant)
            {
                if (langId == (MessageEnumData.MsgLangId)(-1))
                    bundleName = MessageHelper.AddVariantNameToPath(bundleName);
                else
                    bundleName = MessageHelper.AddVariantNameToPath(MessageHelper.GetLanguageVariant(langId));
            }

            if (!AssetManager.IsExistAssetBundle(bundleName))
                return 0;

            // Result is ignored
            AssetBundleCache.Get(bundleName, false);

            var unloader = new AssetBundleUnloader();
            unloader.assetBundleName = bundleName;
            unloader.isUnloadAllLoadedObjects = true;
            return unloader.Release();
        }

        private int FindWindowDataIndex(string assetName)
        {
            for (int j=0; j<_mdUis.UIWindow.Length; j++)
            {
                if (assetName == _mdUis.UIWindow[j].AssetName)
                {
                    return j;
                }
            }

            return -1;
        }

        public void UnloadWindows(List<UIWindowID> windowIds, bool isVariant = false)
        {
            if (windowIds.Count < 1)
                return;

            if (isVariant)
            {
                for (int i=0; i<windowIds.Count; i++)
                {
                    var windowId = windowIds[i];
                    var assetName = MessageHelper.AddVariantNameToPath(_mdUis.UIWindow[(int)windowId].AssetName);

                    UIWindowID foundId = (UIWindowID)FindWindowDataIndex(assetName);
                    _objectPool.Destroies(foundId);
                }
            }
            else
            {
                for (int i=0; i<windowIds.Count; i++)
                {
                    var windowId = windowIds[i];
                    var assetName = _mdUis.UIWindow[(int)windowId].AssetName;

                    UIWindowID foundId = (UIWindowID)FindWindowDataIndex(assetName);
                    _objectPool.Destroies(foundId);
                }
            }
        }

        public T CreateUIWindow<T>(UIWindowID windowId) where T : UIWindow
        {
            var obj = _objectPool.Create(windowId, true);
            switch (windowId)
            {
                case UIWindowID.CONTEXTMENU:
                case UIWindowID.KEYGUIDE:
                case UIWindowID.SHOP_BOUTIQUE_BUY:
                case UIWindowID.ZUKAN_COMPARE:
                case UIWindowID.POFIN_CASE:
                    var exist = GetExistWindow(windowId);
                    bool isNull = exist;
                    // Presumably there is some sort of commented out logging here
                    break;
            }

            obj.uiWindow.transform.SetParent(_activeRoot, false);
            obj.uiWindow.transform.localPosition = Vector3.zero;
            obj.windowId = windowId;
            obj.uiWindow.instance = obj;
            obj.uiWindow.OnCreate();

            return obj.uiWindow as T;
        }

        public void ForceCrash(ForcedCrashCategory category = ForcedCrashCategory.Abort)
        {
            Utils.ForceCrash(category);
        }

        public void SetTransitionWindowIds(UIWindowID prevWindowId, UIWindowID nextWindowId, bool isOpen)
        {
            if (!isOpen)
            {
                if (nextWindowId == UIWindow.WINDOWID_PARENT)
                    return;
            }
            else if (prevWindowId == UIWindow.WINDOWID_PARENT)
            {
                return;
            }

            UIWindowID windowId = isOpen ? nextWindowId : prevWindowId;
            switch (windowId)
            {
                case UIWindowID.CONTEXTMENU:
                case UIWindowID.KEYGUIDE:
                case UIWindowID.CONTEST_POKEMON:
                case UIWindowID.CONTEST_WAZA:
                case UIWindowID.CONTEST_CAPSULE:
                case UIWindowID.CONTEST_BOUTIQUE:
                case UIWindowID.CONTEST_PHOTO:
                case UIWindowID.POKETCH:
                case UIWindowID.FIELD_FLOOR:
                case UIWindowID.FIELD_MONEY:
                case UIWindowID.FUREAI_POKESELECT:
                case UIWindowID.ZUKAN_COMPARE:
                case UIWindowID.POFIN_CASE:
                case UIWindowID.FIELD_AUTOSAVE:
                case UIWindowID.SELL_ITEM_UG:
                case UIWindowID.SELL_UG_ITEM:
                case UIWindowID.SHOP_UG:
                case UIWindowID.UG_BASE_EXPANSION:
                case UIWindowID.CERTIFICATE:
                case UIWindowID.TVRANKING:
                case UIWindowID.YUNION:
                    return;
            }

            if (!isOpen)
            {
                if (_transitionWindowIds[1] != prevWindowId)
                    return;
            }
            else if (_transitionWindowIds[1] != UIWindow.WINDOWID_FIELD)
            {
                if (_transitionWindowIds[1] != nextWindowId)
                    return;

                if (_transitionWindowIds[0] != prevWindowId)
                    return;
            }

            _transitionWindowIds[0] = prevWindowId;
            _transitionWindowIds[1] = nextWindowId;
        }

        public void SetupSortOrder(UIWindow uiwindow)
        {
            if (uiwindow.instance.windowId == UIWindowID.KEYGUIDE)
                return;

            var canvas = uiwindow.canvas;
            if (canvas == null)
            {
                canvas = uiwindow.gameObject.AddComponent<Canvas>();
                canvas.enabled = true;
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvas.overrideSorting = true;
            }

            switch (uiwindow.instance.windowId)
            {
                case UIWindowID.CONTEXTMENU:
                case UIWindowID.CONTEXTMENU_SCROLL:
                    canvas.sortingOrder = _sortingOrderContextMenu;
                    break;

                case UIWindowID.POKETCH:
                    canvas.sortingOrder = _sortingOrderPoketch;
                    break;

                case UIWindowID.FATAL_ERROR_DIALOG:
                    canvas.sortingOrder = _sortingOrderFatalErrorDialog;
                    break;

                default:
                    if (_activeRoot.childCount < 2)
                    {
                        canvas.sortingOrder = _sortingOrderWindow;
                    }
                    else
                    {
                        for (int i=_activeRoot.childCount-2; i>-1; i--)
                        {
                            var activeCanvas = _activeRoot.GetChild(i).GetComponent<UIWindow>().canvas;
                            if (activeCanvas != null && activeCanvas.sortingOrder < _sortingOrderContextMenu)
                                canvas.sortingOrder = Mathf.Max(activeCanvas.sortingOrder + 100, 400);
                            else
                                canvas.sortingOrder = _sortingOrderWindow;
                        }
                    }
                    break;
            }

            if (uiwindow.prevWindowId >= 0)
                return;

            if (Instance._activeRoot != null)
            {
                _ = Instance._activeRoot.childCount;
            }

            _ = Instance.GetCurrentUIWindow<UIWindow>();
        }

        public T GetCurrentUIWindow<T>() where T : UIWindow
        {
            var foregroundWin = GetForegroundWindow();
            if (foregroundWin == null)
                return null;

            if (foregroundWin.canvas.sortingOrder >= _sortingOrderTransition)
                return foregroundWin as T;

            var lastWindow = GetLastWindow();
            if (lastWindow == null)
                return null;

            if (lastWindow.transform == null)
                return null;

            return lastWindow.transform.GetComponent<T>();
        }

        private UIWindow GetLastWindow()
        {
            for (int i=_activeRoot.childCount-1; i>-1; i--)
            {
                var window = _activeRoot.GetChild(i).GetComponent<UIWindow>();
                if (window.instance.windowId != UIWindowID.KEYGUIDE)
                    return window;
            }

            return null;
        }

        private UIWindow GetForegroundWindow()
        {
            UIWindow topWindow = null;
            int topSorting = -1;
            for (int i=_activeRoot.childCount-1; i>-1; i--)
            {
                var window = _activeRoot.GetChild(i).GetComponent<UIWindow>();
                if (window.instance.windowId != UIWindowID.KEYGUIDE && window.canvas != null)
                {
                    if (window.canvas.sortingOrder > topSorting)
                    {
                        topSorting = window.canvas.sortingOrder;
                        topWindow = window;
                    }
                }
            }

            return topWindow;
        }

        public UIWindow GetUIWindowByIndex(int index)
        {
            if (index >= _activeRoot.childCount)
                return null;

            var child = _activeRoot.GetChild(index);
            if (child == null)
                return null;

            return child.GetComponent<UIWindow>();
        }

        public int GetUIWindowCount()
        {
            if (_activeRoot == null)
                return 0;

            return _activeRoot.childCount;
        }

        public T GetExistWindow<T>() where T : UIWindow
        {
            for (int i=Instance.GetUIWindowCount()-1; i>-1; i--)
            {
                var window = Instance.GetUIWindowByIndex(i);
                if (window is T)
                    return (T)window;
            }

            return null;
        }

        public UIWindow GetExistWindow(UIWindowID windowId)
        {
            for (int i=GetUIWindowCount()-1; i>-1; i--)
            {
                var window = Instance.GetUIWindowByIndex(i);
                if (window.instance.windowId == windowId)
                    return window;
            }

            return null;
        }

        public List<T> GetExistWindows<T>() where T : UIWindow
        {
            var list = new List<T>();

            for (int i=Instance.GetUIWindowCount(); i>-1; i--)
            {
                var window = Instance.GetUIWindowByIndex(i);
                if (window is T)
                    list.Add((T)window);
            }

            return list;
        }

        public int GetExistWindowCount<T>()
        {
            int count = 0;

            for (int i=Instance.GetUIWindowCount(); i>-1; i--)
            {
                var window = Instance.GetUIWindowByIndex(i);
                if (window is T)
                    count++;
            }

            return count;
        }

        public UIWindow GetReduplicationWindow(UIWindow baseWindow)
        {
            for (int i=GetUIWindowCount()-1; i>-1; i--)
            {
                var window = Instance.GetUIWindowByIndex(i);
                if (window == null)
                    continue;

                if (window.GetType() == baseWindow.GetType() && window != baseWindow)
                    return window;
            }

            return null;
        }

        internal void _ReleaseUIWindow(UIWindow window)
        {
            _objectPool.Release(window.instance.windowId, window.instance, true);
        }

        internal void _SetupKeyAssign(INPUTMODE inputMode)
        {
            switch (inputMode)
            {
                case INPUTMODE.INPUTMODE_NORMAL:
                    StickLLeft = GameController.ButtonMask.Left | GameController.ButtonMask.StickLLeft | GameController.ButtonMask.StickRLeft;
                    StickLUp = GameController.ButtonMask.Up | GameController.ButtonMask.StickLUp | GameController.ButtonMask.StickRUp;
                    StickLRight = GameController.ButtonMask.Right | GameController.ButtonMask.StickLRight | GameController.ButtonMask.StickRRight;
                    StickLDown = GameController.ButtonMask.Down | GameController.ButtonMask.StickLDown | GameController.ButtonMask.StickRDown;
                    ButtonA = GameController.ButtonMask.A | GameController.ButtonMask.ZL | GameController.ButtonMask.ZR;
                    ButtonB = GameController.ButtonMask.B;
                    ButtonX = GameController.ButtonMask.X;
                    ButtonY = GameController.ButtonMask.Y;
                    break;

                default:
                    StickLLeft = GameController.ButtonMask.StickLLeft | GameController.ButtonMask.StickRLeft;
                    StickLUp = GameController.ButtonMask.StickLUp | GameController.ButtonMask.StickRUp;
                    StickLRight = GameController.ButtonMask.StickLRight | GameController.ButtonMask.StickRRight;
                    StickLDown = GameController.ButtonMask.StickLDown | GameController.ButtonMask.StickRDown;
                    ButtonA = GameController.ButtonMask.A | GameController.ButtonMask.ZL | GameController.ButtonMask.ZR | GameController.ButtonMask.Right;
                    ButtonB = GameController.ButtonMask.B | GameController.ButtonMask.Down;
                    ButtonX = GameController.ButtonMask.X | GameController.ButtonMask.Up;
                    ButtonY = GameController.ButtonMask.Y | GameController.ButtonMask.Left;
                    break;
            }
        }

        private void LateUpdate()
        {
            UpdateBlurBg();
            _modelView._UpdateModelView();
        }

        public Sprite GetSharedSprite(SharedSpriteID sharedSpriteId)
        {
            return GetAtlasSprite(SpriteAtlasID.SHAREDUI, _mdUis.SharedSprite[(int)sharedSpriteId].SpriteName);
        }

        public Sprite GetSpritePokemonSex(Sex sex)
        {
            if (sex == Sex.UNKNOWN)
                return null;

            return GetAtlasSprite(SpriteAtlasID.SHAREDUI, _mdUis.SharedSprite[(int)sex].SpriteName);
        }

        public UIDatabase.SheetPokemonIcon GetPokemonIconData(MonsNo monsNo, ushort formNo, Sex sex, RareType rareType, bool isEgg)
        {
            int uniqueId = DataManager.GetUniqueID(monsNo, formNo, sex, rareType, isEgg);
            int searchResult = Array.BinarySearch(_mdUis.PokemonIcon, uniqueId, _comparerPokemonIcon);
            if (searchResult < 0) searchResult = 0;

            return _mdUis.PokemonIcon[searchResult];
        }

        public UIDatabase.SheetAshiatoIcon GetAshiatoIconData(MonsNo monsNo, ushort formNo, Sex sex, RareType rareType, bool isEgg)
        {
            int uniqueId = DataManager.GetUniqueID(monsNo, formNo, sex, rareType, isEgg);
            int searchResult = Array.BinarySearch(_mdUis.AshiatoIcon, uniqueId, _comparerAshiatoIcon);
            if (searchResult < 0) searchResult = 0;

            return _mdUis.AshiatoIcon[searchResult];
        }

        // TODO
        public UIDatabase.SheetZukanDisplay GetZukanDisplayData(PokemonParam pokemonParam) { return null; }

        // TODO
        public UIDatabase.SheetZukanDisplay GetZukanDisplayData(MonsNo monsNo, ushort formNo, Sex sex, RareType rareType, bool isEgg) { return null; }

        // TODO
        public UIDatabase.SheetPokemonVoice GetPokemonVoiceData(MonsNo monsNo, ushort formNo, Sex sex, RareType rareType, bool isEgg) { return null; }

        // TODO
        public UIDatabase.SheetPokemonVoice GetPokemonVoiceData(int uniqueId) { return null; }

        // TODO
        public UIDatabase.SheetZukanComparePlayer GetZukanComparePlayerData(bool playerSex) { return null; }

        // TODO
        public UIDatabase.SheetZukanCompareHeight GetZukanCompareHeightData(MonsNo monsNo, ushort formNo, Sex sex, RareType rareType, bool isEgg) { return null; }

        // TODO
        public UIDatabase.SheetZukanCompareWeight GetZukanCompareWeightData(int diffWeight) { return null; }

        // TODO
        public UIDatabase.SheetZukanRating GetZukanRatingData(bool isZenkokuZukan) { return null; }

        // TODO
        public static string GetPokemonAssetbundleName(int uniqueId) { return null; }

        public UIDatabase.SheetContextMenu GetContextMenuData(ContextMenuID contextMenuId)
        {
            return _mdUis­.ContextMenu[(int)contextMenuId];
        }

        public static (string, string) GetLanguageMessage(uint langId)
        {
            var message = _langParams.FirstOrDefault(x => (uint)x.langId == langId);
            return ("ss_status", message.label);
        }

        // TODO: Figure out an alternative for PC or something
        public static string GetCurrentIetfCode()
        {
#if SWITCH
            return nn.oe.Language.GetDesired();
#else
            // I'm just defaulting to english for now
            return "en-US";
#endif
        }

        public static MessageEnumData.MsgLangId GetMessageLangIdFromIetfCode(string ietfCode)
        {
            var result = _langParams.FirstOrDefault(x => x.ietfTags.FirstOrDefault(y => y == ietfCode) != null);
            return result?.langId ?? MessageEnumData.MsgLangId.USA;
        }

        // TODO
        public Sprite GetSpriteMonsterBall(BallId ballId) { return null; }

        public Sprite GetSpriteIllegalMonsterBall()
        {
        	return this._spriteMonsterBallIllegal;
        }

        // TODO
        public static uint GetParentId(PokemonParam pokemonParam) { return 0; }

        // TODO
        public static uint GetParentId(PokemonParam pokemonParam, out int digitNum)
        {
            digitNum = 0;
            return 0;
        }

        public static void SetMessageWordParentId(int argIndex, PokemonParam pokemonParam)
        {
            if (pokemonParam.GetCassetteVersion() < CassetVersion.SUN)
                MessageWordSetHelper.SetStringWord(argIndex, string.Format("{0:d5}", pokemonParam.GetID() & 0xFFFF));
            else
                MessageWordSetHelper.SetStringWord(argIndex, string.Format("{0:d6}", pokemonParam.GetID() % 1000000));
        }

        // TODO
        public Sprite GetSpritePokemonType(int typeNo) { return null; }

        // TODO
        public Sprite GetSpritePokemonTypeZukan(int typeNo, MessageEnumData.MsgLangId langId) { return null; }

        // TODO
        public Sprite GetSpritePokemonLanguage(MessageEnumData.MsgLangId langId) { return null; }

        // TODO
        public Sprite GetSpritePlaceMark(uint cassetVersion) { return null; }

        // TODO
        public Sprite GetSpriteWazaDamageType(WazaDamageType wazaDamageType) { return null; }

        // TODO
        public Sprite GetHpBgSprite() { return null; }

        // TODO
        public Color32 GetMarkColor(int type) { return default(Color32); }

        // TODO
        public Color32 GetPokeColor(int type) { return default(Color32); }

        // TODO
        public UIDatabase.SheetWallpaper GetWallPaper(int type) { return null; }

        // TODO
        public int GetWallPaperMax() { return 0; }

        // TODO
        public int GetSearchPokeIconSex(MonsNo monsNo) { return 0; }

        // TODO
        public UIDatabase.SheetBox GetBoxData(int no) { return null; }

        // TODO
        public UIDatabase.SheetBoxOpenParam GetBoxOpenData(int type) { return null; }

        // TODO
        public bool IsDisplayWazaString(string wazaMessageID) { return false; }

        // TODO
        public bool IsDisplayTokuseiString(string tokuseiMessageID) { return false; }

        public Keyguide GetKeyguide([Optional] Transform transform, bool isCreate = true)
        {
            if (isCreate && (_keyguide == null || _keyguide.gameObject == null))
                _keyguide = Instance.CreateUIWindow<Keyguide>(UIWindowID.KEYGUIDE);

            if (transform != null)
                _keyguide.transform.SetParent(transform, false);

            return _keyguide;
        }

        internal void _ClearKeyguide()
        {
            _keyguide = null;
        }

        public UIDatabase.SheetKeyguide GetKeyguideData(KeyguideID keyguideId)
        {
            return _mdUis.Keyguide[(int)keyguideId];
        }

        public void ReleaseKeyguide()
        {
            // Empty
        }

        public static Taste GetLikeTaste(PokemonParam pokemonParam)
        {
        	var iVar1 = pokemonParam.JudgeTaste(0);
        	var uVar2 = 0;
        	if (iVar1 != 1) {
        	  uVar2 = 1;
        	  iVar1 = pokemonParam.JudgeTaste(1);
        	  if (iVar1 != 1) {
        	    uVar2 = 2;
        	    iVar1 = pokemonParam.JudgeTaste(2);
        	    if (iVar1 != 1) {
        	      uVar2 = 3;
        	      iVar1 = pokemonParam.JudgeTaste(3);
        	      if (iVar1 != 1) {
        	        iVar1 = pokemonParam.JudgeTaste(4);
        	        uVar2 = 4;
        	        if (iVar1 != 1) {
        	          uVar2 = 5;
        	        }
        	        return uVar2;
        	      }
        	    }
        	  }
        	}
        	return uVar2;
        }

        // TODO
        public static BTL_POKEPARAM ToBattlePokemonParam(PokemonParam pokemonParam) { return null; }

        // TODO
        public static PokemonParam ToPokemonParam(BTL_POKEPARAM battlePokemonParam) { return null; }

        // TODO
        public static PokemonParam ToPokemonParamBySrcData(PokemonParam pokemonParam) { return null; }

        public static bool IsMyParty(PokemonParam pokemonParam)
        {
            return !_pokemonParamMappings.FirstOrDefault(x => x.pokemonParam == pokemonParam).isFriend;
        }

        public static int GetFriendPartyFirstIndex()
        {
            return _pokemonParamMappings.FindIndex(x => x.isFriend);
        }

        // TODO
        public static void SetTrainerName(int tagIndex, PokemonParam pokemonParam)
        {
            var mapping = _pokemonParamMappings.FirstOrDefault(x => x.pokemonParam == pokemonParam);
            var name = BattleViewCore.Instance.ViewSystem.GetTrainerNameLabel(mapping.clientId);

            if (name != null)
            {
                MessageWordSetHelper.SetTrainerNameWord(tagIndex, name);
                return;
            }
        }

        // TODO
        public static BTL_PARTY GetMultiPlayerFriendParty() { return null; }

        // TODO
        public static List<PokemonParam> CreatePokemonParamsByBattle() { return null; }

        public static PokemonParam CreatePokemonParamByBattle(BTL_POKEPARAM battlePokemonParam)
        {
        	byte bVar2;
        	var uVar4 = battlePokemonParam.GetSrcDataConst();
        	var uVar5 = new PokemonParam(uVar4);
        	var uVar3 = battlePokemonParam.GetValue(0xd);
        	uVar5.SetHp(uVar3);
        	uVar3 = (ushort)(battlePokemonParam.GetValue(0xf));
        	uVar5.SetMaxHp(uVar3);
        	uVar3 = (ushort)(battlePokemonParam.GetValue(0x17));
        	uVar5.SetExp(uVar3);
        	uVar3 = (ushort)(battlePokemonParam.GetPokeSick());
        	uVar5.SetSick(uVar3);
        	uVar3 = (ushort)(battlePokemonParam.GetItem());
        	uVar5.SetItem(uVar3);
        	var cVar1 = battlePokemonParam.WAZA_GetCount_Org();
        	if (cVar1 != 0) {
        	  var uVar6 = 0;
        	  do {
        	    uVar3 = (ushort)(battlePokemonParam.WAZA_GetID_Org(uVar6));
        	    uVar5.SetWaza(uVar6,uVar3);
        	    uVar4 = battlePokemonParam.GetSrcData();
        	    uVar3 = (ushort)(uVar4.GetWazaPPUpCount(uVar6));
        	    uVar5.SetWazaPPUpCount(uVar6,uVar3);
        	    uVar3 = (ushort)(battlePokemonParam.WAZA_GetPP_Org(uVar6));
        	    uVar5.SetWazaPP(uVar6,uVar3);
        	    uVar6 = uVar6 + 1;
        	    bVar2 = (byte)(battlePokemonParam.WAZA_GetCount_Org());
        	  } while (uVar6 < bVar2);
        	}
        	return uVar5;
        }

        public static PokemonParam GetTeamPokemon(int team, int pos)
        {
            if (TryGetTeamPokemonTrayIndex(team, pos, out int tray, out int index))
                return BoxPokemonWork.GetPokemon(tray, index);

            return null;
        }

        public static bool TryGetTeamPokemonTrayIndex(int team, int pos, out int tray, out int index)
        {
            tray = BoxWork.GetTeamPokeBoxTray(team, pos);
            index = -1;

            if (tray == 255)
                return false;

            index = BoxWork.GetTeamPokeBoxPos(team, pos);
            return index != 255;
        }

        public static bool IsFieldWaza(WazaNo wazaNo)
        {
            switch (wazaNo)
            {
                case WazaNo.ANAWOHORU:
                case WazaNo.TEREPOOTO:
                case WazaNo.TAMAGOUMI:
                case WazaNo.HURASSYU:
                case WazaNo.MIRUKUNOMI:
                case WazaNo.AMAIKAORI:
                    return true;

                default:
                    return false;
            }
        }

        public static void ReturnItemInBag(PokemonParam pokemonParam)
        {
            ItemWork.AddItem(pokemonParam.GetItem());
            pokemonParam.RemoveItem();
        }

        // TODO
        public void LoadSpritePokemon(PokemonParam pokemonParam, UnityAction<Sprite> onComplete) { }

        // TODO
        public Sprite LoadSpritePokemonDirect(MonsNo monsNo, ushort formNo, Sex sex, RareType rareType, bool isEgg) { return null; }

        // TODO
        public void LoadSpritePokemon(MonsNo monsNo, ushort formNo, Sex sex, RareType rareType, bool isEgg, UnityAction<Sprite> onComplete) { }

        // TODO
        public void LoadSpritePokemonLarge(PokemonParam pokemonParam, UnityAction<Sprite> onComplete) { }

        // TODO
        public void LoadSpritePokemonLarge(MonsNo monsNo, ushort formNo, Sex sex, RareType rareType, bool isEgg, UnityAction<Sprite> onComplete)
        {
            // TODO
            IEnumerator OpCompleteSprite<T>(CacheSpritePokemonParam cache_, UnityAction<Sprite> onComplete_) { return default; }
        }

        // TODO
        public void LoadSpritePokemonDot(PokemonParam pokemonParam, UnityAction<Sprite> onComplete) { }

        // TODO
        public void LoadSpritePokemonDot(MonsNo monsNo, ushort formNo, Sex sex, RareType rareType, bool isEgg, UnityAction<Sprite> onComplete) { }

        // TODO
        public void LoadSpriteItem(ItemNo itemNo, UnityAction<Sprite> onComplete) { }

        public static int Repeat(int value, int start, int end)
        {
            var range = end - start + 1;
            var iVar1 = value - start + range;
            var iVar2 = (range != 0) ? iVar1 / range : 0;
            return iVar1 - iVar2 * range + start;
        }

        public static void ScreenScaled(ref Vector2 v)
        {
            v.x *= Screen.width / 1280.0f;
            v.x *= Screen.height / 720.0f;
        }

        public static Vector2 ComputeLocalCornerPosition(RectTransform rectTrans, int cornerIndex, [Optional] RectTransform baseRectTrans, [Optional] Camera canvasCamera)
        {
            var corners = new Vector3[4];
            rectTrans.GetWorldCorners(corners);

            var screenPoint = RectTransformUtility.WorldToScreenPoint(canvasCamera, corners[cornerIndex]);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(baseRectTrans, screenPoint, canvasCamera, out Vector2 point);

            return point;
        }

        public static List<DuplicateImageMaterialParam> DuplicateImageMaterials(Transform trans)
        {
            var list = new List<DuplicateImageMaterialParam>();
            var children = trans.GetComponentsInChildren<Image>();

            for (int i=0; i<children.Length; i++)
            {
                var image = children[i];

                if (image.material != null && image.material.shader.name != "UI-Default")
                {
                    list.Add(new DuplicateImageMaterialParam()
                    {
                        image = image,
                        material = image.material,
                    });

                    image.material = new Material(image.material);
                }
            }

            return list;
        }

        public static void RestoreDuplicateImageMaterials(List<DuplicateImageMaterialParam> duplicateImageMaterialParams)
        {
            if (duplicateImageMaterialParams == null)
                return;

            for (int i=0; i<duplicateImageMaterialParams.Count; i++)
            {
                var param = duplicateImageMaterialParams[i];
                Destroy(param.image.material);
                param.image.material = param.material;
            }

            duplicateImageMaterialParams.Clear();
        }

        public static void DestroyCanvasRendererMaterials(GameObject gameObj)
        {
            if (gameObj == null)
                return;

            var renderers = gameObj.GetComponentsInChildren<CanvasRenderer>();
            for (int i=0; i<renderers.Length; i++)
            {
                var renderer = renderers[i];
                for (int j=renderer.materialCount-1; j>-1; j--)
                    Destroy(renderer.GetMaterial(j));
            }
        }

        public void Grayscale(Transform trans, float value)
        {
            var images = trans.GetComponentsInChildren<Image>(true);
            for (int i=0; i<images.Length; i++)
            {
                var image = images[i];
                if (image.material != null && image.material.shader.name != "UI-Default")
                    image.material.SetFloat(_id_GrayscaleAmount, value);
            }
        }

        public void SetOnCloseXMenu(UnityAction<UIWindow> onClosed_)
        {
            onXMenuClosed = onClosed_;
        }

        public void CloseXMenu(UnityAction<UnityAction<UIWindow>> onCall)
        {
            var instance = Instance;
            if (instance._activeRoot != null)
            {
                // Result ignored, likely a commented out log
                _ = instance._activeRoot.childCount;
            }

            // Result ignored, likely a commented out log
            _ = Instance.GetCurrentUIWindow<UIWindow>();

            AudioManager.Instance.PlaySe(EVENTS.UI_TOP_XCLOSE, null);
            onCall.Invoke(onXMenuClosed);

            _blurBgParam.onComplete?.Invoke();
            _blurBgParam.fadeType = BlugBgParam.FadeType.Out;
            _blurBgParam.srcAlpha = _blurBg.color.a;
            _blurBgParam.destAlpha = 0.0f;
            _blurBgParam.time = 0.0f;
            _blurBgParam.maxTime = 0.5f;
            _blurBgParam.onComplete = null;

            _pokemonParamMappings.Clear();
        }

        public TownMapGuideTable.SheetGuide SetupCurrentTownmapGuideMessage()
        {
            var guide = GetTownmapGuideData(FlagWork.GetWork(EvWork.WORK_INDEX.TOWNMAP_GUIDE_SEQUENCE));
            MessageWordSetHelper.SetRivalNickNameWord(1);
            MessageWordSetHelper.SetSupporterName(2);
            return guide;
        }

        public TownMapGuideTable.SheetGuide GetCurrentTownmapGuideData()
        {
            return GetTownmapGuideData(FlagWork.GetWork(EvWork.WORK_INDEX.TOWNMAP_GUIDE_SEQUENCE));
        }

        public TownMapGuideTable.SheetGuide GetTownmapGuideData(int guideId)
        {
            int searchResult = Array.BinarySearch(_mdTownmapGuide.Guide, guideId, _comparerTownMapGuide);
            if (searchResult < 0) searchResult = 0;

            return _mdTownmapGuide.Guide[searchResult];
        }

        public PlaceNameTable.SheetDprPlaceName GetPlaceNameData(ZoneID zoneId)
        {
            int searchResult = Array.BinarySearch(_mdPlaceName.DprPlaceName, zoneId, _comparerPlaceName);
            if (searchResult < 0) searchResult = 0;

            return _mdPlaceName.DprPlaceName[searchResult];
        }

        public PlaceNameTable.SheetDprPlaceName GetPlaceNameData(int placeId)
        {
            int searchResult = Array.BinarySearch(_mdPlaceName.DprPlaceName, placeId, _comparerPlaceName);
            if (searchResult < 0) searchResult = 0;

            return _mdPlaceName.DprPlaceName[searchResult];
        }

        public UIDatabase.SheetCharacterBag GetPlayerCharacterBagData()
        {
            int dressId = FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_CYCLINGROAD) ?
                (int)(PlayerWork.playerSex ? ShopBoutiqueChange.DressType.Bicycle : 100 + ShopBoutiqueChange.DressType.Bicycle) :
                PlayerWork.playerFashion;

            return GetCharacterBagData(dressId);
        }

        public UIDatabase.SheetCharacterBag GetCharacterBagData(int characterDressId)
        {
            return _mdUis.CharacterBag.FirstOrDefault(x => x.Index == characterDressId);
        }

        public void RegisterNowloading(NowloadingController nowloding)
        {
            _nowLoadingController = nowloding;
        }

        public void NowLoadingOpen(float waitTime = 5.0f, int sortOrder = 16390, bool isBackground = false)
        {
            _nowLoadingController.EnableBackground(isBackground);
            _nowLoadingController.Open(waitTime, sortOrder);
        }

        public void NowLoadingClose()
        {
            if (_nowLoadingController.gameObject.activeSelf)
            {
                _nowLoadingController.Close();
                _nowLoadingController.EnableBackground(false);
            }
        }

        public void UseDSPlayerItem()
        {
            bool isOn = ItemWork.IsDsPlayer();
            ItemWork.SetDsPlayer(!isOn);
            AudioManager.Instance.SetBgmEvent(isOn ? AK.EVENTS.DSPLAYER_ON : AK.EVENTS.DSPLAYER_OFF);
        }

        public void FadeinBlurBg([Optional, DefaultParameterValue(0.5f)] float time, [Optional] UnityAction onComplete)
        {
            if (!IsActiveFadeBlur())
                SetActiveFadeBlur(true);

            _blurBgParam.onComplete?.Invoke();
            _blurBgParam.fadeType = BlugBgParam.FadeType.In;
            _blurBgParam.srcAlpha = _blurBg.color.a;
            _blurBgParam.destAlpha = 1.0f;
            _blurBgParam.time = 0.0f;
            _blurBgParam.maxTime = time;
            _blurBgParam.onComplete = onComplete;
            _blurBgParam.isCapture = false;
        }

        public void FadeoutBlurBg([Optional, DefaultParameterValue(0.5f)] float time, [Optional] UnityAction onComplete)
        {
            _blurBgParam.onComplete?.Invoke();
            _blurBgParam.fadeType = BlugBgParam.FadeType.Out;
            _blurBgParam.srcAlpha = _blurBg.color.a;
            _blurBgParam.destAlpha = 0.0f;
            _blurBgParam.time = 0.0f;
            _blurBgParam.maxTime = time;
            _blurBgParam.onComplete = onComplete;
        }

        public bool IsActiveFadeBlur()
        {
            return _blurBgRoot.gameObject.activeSelf;
        }

        public void SetActiveFadeBlur(bool enabled)
        {
            _blurBgRoot.gameObject.SetActive(enabled);
        }

        // TODO
        internal void _CaptureBlueImage(bool enabled) { }

        // TODO
        private void UpdateBlurBg() { }

        public static float FrameCountToSeconds(int frameCount)
        {
            return frameCount / 30.0f;
        }

        // TODO
        public SheetDistributionTable[] GetDistributionDatas(bool isField = true) { return null; }

        public static bool IsUnion()
        {
            return PlayerWork.zoneID == ZoneID.UNION01 || PlayerWork.zoneID == ZoneID.UNION02 || PlayerWork.zoneID == ZoneID.UNION03;
        }

        // TODO
        public HashSet<int> GetInputLimitHashSet(MessageEnumData.MsgLangId langId = (MessageEnumData.MsgLangId)(-1)) { return null; }

        public static int GetDigit(int num)
        {
            if (num == 0)
                return 1;

            return 1 + (int)Mathf.Log10(num);
        }

        // TODO
        public static void UnloadUnusedAssets(bool isGcCollect = false) { }

        // TODO
        public static IEnumerator OpUnloadUnusedAssets(bool isGcCollect = false) { return null; }

        public void EnableFureaiLimit(bool enabled)
        {
            _fureaiLimit = enabled;
        }

        public bool IsFureaiLimit()
        {
            return _fureaiLimit;
        }

        private static long GetUsedMemorySize()
        {
            return Profiler.GetTotalAllocatedMemoryLong();
        }

        private static long GetUnusedMemorySize()
        {
            return Profiler.GetTotalUnusedReservedMemoryLong();
        }

        public static bool IsLumpingRibbon(int ribbonNo)
        {
        	return ribbonNo - 0x25U < 2;
        }

        // TODO
        public static int GetLumpingRibbonMaxNum(int ribbonNo) { return 0; }

        // TODO
        public Sprite GetSpriteRibbon(PokemonParam pokemonParam, int ribbonNo) { return null; }

        public static string ToBinaryString(int val)
        {
            return Convert.ToString(val, 2);
        }

        public static bool IsLeanFly()
        {
            return FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.BADGE_ID_C07) && FlagWork.GetFlag(EvWork.FLAG_INDEX.FE_HIDEN_02_GET);
        }

        public static int Fps()
        {
            if (QualitySettings.vSyncCount > 0)
            {
                var vSyncCount = QualitySettings.vSyncCount;
                if (vSyncCount == 0)
                    return 0;
                else
                    return 60 / vSyncCount;
            }

            return 60;
        }

        public static MessageEnumData.MsgLangId GetCurrentLangId()
        {
            return MessageHelper.ConvertMsgId(PlayerWork.msgLangID);
        }

        // TODO
        public static void SetAllObjectLayer(GameObject obj, int layer) { }

        public static bool IsFieldOpenMenu()
        {
            if (Instance == null)
                return false;

            if (Instance._activeRoot != null)
            {
                int activeCount = 0;
                for (int i=0; i<Instance._activeRoot.childCount; i++)
                {
                    var window = Instance.GetUIWindowByIndex(i);
                    if (window == null)
                        continue;

                    if (!(window is AutoSaveWindow) && !(window is PoketchWindow))
                        activeCount++;
                }

                if (activeCount > 0)
                    return true;
            }

            return FieldPoketch.IsControlPoketch();
        }

        public void EnableFadeTransition(bool enabled)
        {
            _isFadeTransition = enabled;
        }

        public static Sprite CastSprite(object asset)
        {
            var sprite = asset as Sprite;
            if (sprite != null)
                return sprite;

            var texture = asset as Texture2D;
            return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), Vector2.zero);
        }

        private enum InputLimitType : int
        {
	        JPN = 0,
            KOR = 1,
            TCH = 2,
            SCH = 3,
            EFIGS = 4,
            Num = 5,
        }

        private class MonsterBallParam
        {
            public ItemNo itemNo;
            public BallId ballId;
            public Sprite sprite;
        }

        public class SpriteAtlasParam
        {
	        public SpriteAtlasID spriteAtlasId;
            public string assetBundleName;
            public string assetName;
            public string variantAssetBundleName;
            public SpriteAtlas spriteAtlas;
            public Action<SpriteAtlas> atlasCallback;

            public void Clear()
            {
                spriteAtlas = null;
            }

            public void SetSpriteAtlas(SpriteAtlas spriteAtlas_)
            {
                spriteAtlas = spriteAtlas_;
                Call();
            }

            public void SetAtlasCallback(Action<SpriteAtlas> atlasCallback_)
            {
                if (atlasCallback != null)
                    return;

                atlasCallback = atlasCallback_;
                Call();
            }

            private void Call()
            {
                if (spriteAtlas == null)
                    return;

                atlasCallback?.Invoke(spriteAtlas);
            }
        }

        [Flags]
        private enum InitializeStateBit : int
        {
            EntrySpriteAtlas = 1,
            LoadedSpriteAtlas = 2,
            EntryWindows = 4,
            LoadedWindows = 8,
            EntryAterLang = 16,
            LoadAterLang = 32,
            Loaded = 10,
        }

        public enum FieldUseResult : int
        {
            Available = 0,
            Unusable = 1,
            Unusable_PairTrainer = 2,
        }

        public class FieldWazaParam
        {
	        public WazaNo wazaNo;
            public PokemonParam pokemon;
            public PokemonParam targetPokemon;
        }

        public class UIInstance : IObjectPoolInstance
        {
	        private UIWindow _uiWindow;
            private UIWindowID _windowId = UIWindow.WINDOWID_PARENT;

            public UIWindow uiWindow { get => _uiWindow; }
            public UIWindowID windowId { get => _windowId; set => _windowId = value; }

            void IObjectPoolInstance.SetGameObject(GameObject obj)
            {
                _uiWindow = obj.GetComponent<UIWindow>();
            }

            GameObject IObjectPoolInstance.GetGameObject()
            {
                if (_uiWindow == null)
                    return null;

                return _uiWindow.gameObject;
            }

            void IObjectPoolInstance.OnCreate()
            {
                // Empty
            }

            void IObjectPoolInstance.OnRelease()
            {
                _uiWindow = null;
            }
        }

        private class TransitionInstance : IObjectPoolInstance
        {
	        public UITransition transition;
            public TransitionID transitionId;

            void IObjectPoolInstance.SetGameObject(GameObject obj)
            {
                transition = obj.GetComponent<UITransition>();
            }

            GameObject IObjectPoolInstance.GetGameObject()
            {
                return transition.gameObject;
            }

            void IObjectPoolInstance.OnCreate()
            {
                // Empty
            }

            void IObjectPoolInstance.OnRelease()
            {
                // Empty
            }
        }

        private class CacheSpritePokemonParam
        {
	        public int uniqueId;
            public Sprite sprite;

            public void Destroy()
            {
                UnityEngine.Object.Destroy(sprite);
                sprite = null;
            }
        }

        private class BlugBgParam
        {
	        public FadeType fadeType;
            public float srcAlpha;
            public float destAlpha;
            public float time;
            public float maxTime = 0.5f;
            public UnityAction onComplete;
            public bool isCapture;
            public RenderTexture captureBlurTexture;
            public Texture2D blankTexture;

            public enum FadeType : int
            {
                In = 0,
                Out = 1,
            }
        }

        public class EnvironmentControllerSaver
        {
	        public bool isSaved;
            public bool actived;
            public bool enabled;

            public void Save(bool isReset = false)
            {
                if (isReset)
                    Restore();

                if (isSaved)
                    return;

                if (EnvironmentController.global == null)
                    return;

                isSaved = true;
                actived = EnvironmentController.global.gameObject.activeSelf;
                enabled = EnvironmentController.global.enabled;
            }

            public void Restore()
            {
                if (!isSaved)
                    return;

                isSaved = false;

                if (EnvironmentController.global == null)
                    return;

                EnvironmentController.global.gameObject.SetActive(actived);
                EnvironmentController.global.enabled = enabled;
            }
        }

        private struct AtlasSpriteKey
        {
	        public SpriteAtlasID spriteAtlasId;
            public string name;
        }

        private class ComparerPokemonIcon : IComparer
        {
            public int Compare(object x, object y)
            {
                var icon = x as UIDatabase.SheetPokemonIcon;
                return icon.UniqueID - Convert.ToInt32(y);
            }
        }

        private class ComparerAshiatoIcon : IComparer
        {
            public int Compare(object x, object y)
            {
                var icon = x as UIDatabase.SheetAshiatoIcon;
                int icon2 = Convert.ToInt32(y);

                if (icon.UniqueID < icon2)
                    return -1;

                if (icon.UniqueID > icon2)
                    return 1;

                return 0;
            }
        }

        private class ComparerZukanDisplay : IComparer
        {
            public int Compare(object x, object y)
            {
                var display = x as UIDatabase.SheetZukanDisplay;
                return display.UniqueID - Convert.ToInt32(y);
            }
        }

        private class ComparerPokemonVoice : IComparer
        {
            public int Compare(object x, object y)
            {
                var voice = x as UIDatabase.SheetPokemonVoice;
                return voice.UniqueID - Convert.ToInt32(y);
            }
        }

        private class ComparerZukanCompareHeight : IComparer
        {
            public int Compare(object x, object y)
            {
                var height = x as UIDatabase.SheetZukanCompareHeight;
                int height2 = Convert.ToInt32(y);

                if (height.UniqueID < height2)
                    return -1;

                if (height.UniqueID > height2)
                    return 1;

                return 0;
            }
        }

        private class LangParam
        {
	        public MessageEnumData.MsgLangId langId;
            public string label;
            public string[] ietfTags;
        }

        private class PokemonParamMapping
        {
	        public BTL_POKEPARAM battlePokemonParam;
            public PokemonParam pokemonParam;
            public byte clientId;

            public bool isFriend { get => clientId != BattleViewCore.Instance.ViewSystem.GetClientID(); }
        }

        public class DuplicateImageMaterialParam
        {
	        public Image image;
            public Material material;
        }

        private class ComparerTownMapGuide : IComparer
        {
            public int Compare(object x, object y)
            {
                var guide = x as TownMapGuideTable.SheetGuide;
                return guide.Id - Convert.ToInt32(y);
            }
        }

        private class ComparerPlaceName : IComparer
        {
            public int Compare(object x, object y)
            {
                var guide = x as PlaceNameTable.SheetDprPlaceName;
                return guide.Index - Convert.ToInt32(y);
            }
        }
    }
}