using Dpr.Battle.Logic;
using Dpr.Battle.View.UI;
using Dpr.Message;
using Dpr.UI;
using Pml;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Battle.View.Systems
{
    public sealed class BattleViewUISystem : MonoBehaviour
    {
        public const int POKE_BALL_MAX = 6;
        private const float DECO_SHOW_POS_X = 570.0f;
        private const float DECO_HIDE_POS_X = 960.0f;
        private const float DECO_POS_Y = -340.0f;
        private const float DECO_SHOW_ROT = 340.0f;
        private const float DECO_HIDE_ROT = 160.0f;
        private const int SEQ_END_WAIT_SAFETY_COUNT = 100;
        private const int SEQ_END_WAIT_DOT_DIST_MAX = 10;
        public const string PokemonNameMessageLabel = "msg_ui_btl_pokename";
        public static readonly string[] AffinityText = new string[4]
        {
            "msg_ui_btl_kouka_03", "msg_ui_btl_kouka_01", "msg_ui_btl_kouka_00", "msg_ui_btl_kouka_02"
        };
        public const string ContextMenuMsgFile = "ss_btl_app";
        public static readonly string[][] ContextMenuText = 
        {
            new string[2] { "msg_ui_btl_yesno_02", "msg_ui_btl_yesno_03" },
            new string[2] { "msg_ui_btl_yesno_00", "msg_ui_btl_yesno_01" },
            new string[2] { "msg_ui_btl_yesno_04", "msg_ui_btl_yesno_05" },
        };
        public static readonly string[] AffinitySpriteName = new string[4]
        {
            "btl_txt_resist_01_04", "btl_txt_resist_01_02", "btl_txt_resist_01_01", "btl_txt_resist_01_03"
        };
        private const float _msgTimeOut = 20.0f;

        [SerializeField]
        private RawImage _decoImage;
        [SerializeField]
        [Tooltip("BtlvPosの順番に設定する")]
        private BUIStatusWindow[] _statusWindows;
        [SerializeField]
        [Tooltip("BattleViewUISystem.BallSpriteType 順")]
        private Sprite[] _ballSprites;
        [SerializeField]
        [Tooltip("BattleViewUISystem.BallSpriteType 順")]
        private Sprite[] _ballLargeSprites;
        [SerializeField]
        private BUIActionList _actionList;
        [SerializeField]
        private BUIWazaList _wazaList;
        [SerializeField]
        private BUIWazaDescription _wazaDescription;
        [SerializeField]
        private BUITokuseiPlate _tokuseiNear;
        [SerializeField]
        private BUITokuseiPlate _tokuseiFar;
        [SerializeField]
        private BUIBallPlate _ballPlateNear;
        [SerializeField]
        private BUIBallPlate _ballPlateFar;
        [SerializeField]
        private BUIPokeBallList _pokeBallList;
        [SerializeField]
        private BUISafariBall _safariBall;
        [SerializeField]
        private BUITargetSelect _targetSelect;
        [SerializeField]
        private BUICommTime _commTime;
        [SerializeField]
        private Dpr.UI.Cursor _cursor;

        [SerializeField]
        [Tooltip("チュートリアル カーソル移動ウェイト")]
        private float _cursorWait = 0.7f;
        [SerializeField]
        [Tooltip("チュートリアル ボタン押下ウェイト")]
        private float _executeWait = 2.5f;
        [SerializeField]
        [Tooltip("チュートリアル ボール個数")]
        private int _tutorialBallCount = 20;
        [SerializeField]
        [Tooltip("チュートリアル キズぐすり個数")]
        private int _tutorialDrugCount = 9;
        [SerializeField]
        [Tooltip("チュートリアル おこづかい")]
        private int _tutorialMoney = 10000;

        private bool _isMenuUIEnd;
        private bool _isFirstTime;
        private bool _isPlaySound;
        private bool _isShowDeco;
        private bool _isMsgEnd;
        private bool _isMessageSleep;
        [SerializeField]
        private bool _isMessageOpen;
        private float _msgTimer;
        private MsgShowParam _showParam = MsgShowParam.Default;
        private Queue<(MessageTextParseDataModel, MsgShowParam)> _messagePramQueue = new Queue<(MessageTextParseDataModel, MsgShowParam)>();
        private Coroutine _coMsgQueue;
        private Action _endMsgAction;
        private MsgWindow.MsgWindow _msgWindow;
        private BtlYesNo? _yesnoResult;
        private UIWindow _uiWindow;
        private PokemonBattleWindow.Param _pokeWinParam;
        private Coroutine _coCloseMenuUI;
        private PokeSelParam _pokeSelParam;
        private PokeSelResult _pokeSelResult;
        private BattleViewBase.SelectActionParam _actionParam;
        private BTL_POKEPARAM _swapWaitPokemon;
        private HUDEventID preHUDEventId;
        private uint _outMemberIndex;
        private ItemNo _selectItem;
        private int _selectWaza = -1;
        private int _selectPoke = -1;
        private BUIAutoPilot _autoPilot;
        private BTL_POKEPARAM _currentPoke;
        private DG.Tweening.Sequence _decoballSequence;
        private int SeqEndWaitSafetyCount;
        public int seqDotDispWaitTime;
        private static uint _lastSelectedBallId = 0;
        public static bool IsDebugHide = false;
        private CanvasGroup _uiCanvasGroup;
        private static BattleViewUISystem _instance = null;

        // TODO
        public void HUD_Hide() { }

        public void CMD_UI_SelectAction_Start(in BattleViewBase.SelectActionParam param, BTL_ACTION_PARAM_OBJ dest)
        {
            Debug.Log("[BattleUI]SelectAction");

            _actionList.Initialize(param);
            _actionParam = param;
            _currentPoke = param.pActPoke;

            if (param.pokeIndex == 0)
                _swapWaitPokemon = null;

            SwitchShowActionList(true, !IsOpenedStatus(), !_wazaList.IsShow);
        }

        public BtlAction CMD_UI_SelectAction_Wait()
        {
            if (!_actionList.IsValid)
                return BtlAction.BTL_ACTION_NULL;

            switch (_actionList.Result)
            {
                case BtlAction.BTL_ACTION_FIGHT:
                    SwitchShowActionList(false, false, false);
                    return _actionList.Result;

                case BtlAction.BTL_ACTION_ESCAPE:
                    SwitchShowActionList(false, !_actionList.IsReturnable, true);
                    return _actionList.Result;

                default:
                    SwitchShowActionList(false, true, true);
                    return _actionList.Result;
            }
        }

        public void CMD_UI_SelectAction_ForceQuit()
        {
            _actionList.ForceHide();
        }

        public void CMD_UI_SelectWaza_Start(BTL_POKEPARAM bpp, byte pokeIndex, BTL_ACTION_PARAM_OBJ dest)
        {
            _wazaList.Initialize(bpp, pokeIndex, dest);
            _wazaList.Show(null);
            SwitchShowDecoImage(true);
        }

        public void CMD_UI_SelectWaza_Restart(byte pokeIndex)
        {
            _wazaList.Show(null);
            SwitchShowStatusWindows(true);
            SwitchShowDecoImage(true);
        }

        public bool CMD_UI_SelectWaza_Wait()
        {
            if (!_wazaList.IsValid)
                return false;

            if (_wazaList.Result == -1)
            {
                _wazaList.Hide(false, null);
            }
            else
            {
                _wazaList.SetInvalid();
                SwitchShowDecoImage(false);
            }

            return true;
        }

        public bool CMD_UI_SelectWaza_End()
        {
            if (_wazaList.IsShow)
                _wazaList.Hide(false, null);

            return true;
        }

        public void CMD_UI_SelectWaza_ForceQuit()
        {
            _wazaList.Hide(false, null);
        }

        // TODO
        public void CMD_UI_SelectTarget_Start(byte poke_index, BTL_POKEPARAM bpp, BTL_ACTION_PARAM_OBJ dest) { }

        // TODO
        public BattleViewBase.BtlvResult CMD_UI_SelectTarget_Wait() { return default; }

        // TODO
        public void CMD_UI_SelectTarget_ForceQuit() { }

        // TODO
        public void CMD_StartPokeList(PokeSelParam param, BTL_POKEPARAM outMemberParam, uint outMemberIndex, bool fCantEsc, PokeSelResult result) { }

        public bool CMD_WaitPokeList() {
            return _isMenuUIEnd;
        }

        // TODO
        public void CMD_ForceQuitPokeList() { }

        public bool CMD_WaitForceQuitPokeList() {
            return _isMenuUIEnd;
        }

        // TODO
        public void CMD_StartPokeSelect(PokeSelParam param, uint outMemberIndex, bool bCancelable, PokeSelResult result) { }

        public bool CMD_WaitPokeSelect() {
            return _isMenuUIEnd;
        }

        // TODO
        public void CMD_ForceQuitPokeSelect() { }

        public bool CMD_WaitForceQuitPokeSelect() {
            return _isMenuUIEnd;
        }

        // TODO
        public void CMD_ExpGet_Start(in BattleViewBase.ExpGetDesc desc, BattleViewBase.ExpGetResult pResult) { }

        public bool CMD_ExpGet_Wait(ref BattleViewBase.ExpGetResult pResult) {
            return _isMenuUIEnd;
        }

        // TODO
        public void MSG_Start(MessageTextParseDataModel pStrBuf, bool isKeyWait = true) { }

        // TODO
        public void MSG_Hide() { }

        // TODO
        public void MSG_AutoOnce() { }

        // TODO
        public void CMD_StartMsg(BTLV_STRPARAM param, bool isKeyWait = false) { }

        // TODO
        public void CMD_StartMsgWaza(byte pokeId, WazaNo waza, bool isZenryokuWaza) { }

        // TODO
        public void CMD_StartMsgStd(ushort strID, int[] args) { }

        // TODO
        public void CMD_StartMsgSet(ushort strID, int[] args) { }

        // TODO
        public void CMD_StartMsgTrainer(byte clientID, uint param, bool isKeyWait = true, bool needSleep = false) { }

        // TODO
        public bool CMD_WaitMsg() { return false; }

        public bool CMD_WaitMsg_WithoutHide() {
            return _isMsgEnd;
        }

        // TODO
        public void CMD_HideMsg() { }

        // TODO
        public void CMD_ITEMSELECT_Start(byte bagMode, byte energy, byte reserved_energy, bool fFirstPokemon, bool fBallTargetHide, bool canUseReliveItem) { }

        // TODO
        public bool CMD_ITEMSELECT_Wait() { return false; }

        // TODO
        public void CMD_ITEMSELECT_ForceQuit() { }

        // TODO
        public ItemNo CMD_ITEMSELECT_GetItemID() { return ItemNo.DUMMY_DATA; }

        // TODO
        public byte CMD_ITEMSELECT_GetTargetIdx() { return 0; }

        // TODO
        public byte CMD_ITEMSELECT_GetWazaIdx() { return 0; }

        // TODO
        public void CMD_ITEMSELECT_ReflectUsedItem() { }

        // TODO
        public void CMD_TokWin_DispStartEx(BtlPokePos pos, TokuseiNo overrideTokusei) { }

        // TODO
        public bool CMD_TokWin_DispWait(BtlPokePos pos) { return false; }

        // TODO
        public void CMD_QuitTokWin(BtlPokePos pos) { }

        // TODO
        public bool CMD_QuitTokWinWait(BtlPokePos pos) { return false; }

        // TODO
        public void CMD_TokWin_Renew_Start(BtlPokePos pos) { }

        // TODO
        public bool CMD_TokWin_Renew_Wait(BtlPokePos pos) { return false; }

        // TODO
        public void CMD_StartCommWait() { }

        // TODO
        public bool CMD_WaitCommWait() { return false; }

        // TODO
        public void CMD_ResetCommWaitInfo() { }

        // TODO
        public void CMD_YESNO_Start(bool bCancel, YesNoMode mode) { }

        // TODO
        public bool CMD_YESNO_Wait(out BtlYesNo result)
        {
            result = default;
            return default;
        }

        // TODO
        public void CMD_YESNO_ForceQuit() { }

        // TODO
        public void CMD_EFFECT_DrawEnableTimer(GameTimer.TimerType type, bool enable) { }

        // TODO
        public bool MSG_IsRunnning() { return false; }

        public bool MSG_WaitMenu(ref byte selectId) {
            return true;
        }

        public bool AutoPilot_EventTest(AutoPilotEventID id) {
            return true;
        }

        public bool HUD_StartingDemo_Wait() {
            return true;
        }

        public bool UIFog_Wait() {
            return true;
        }

        // TODO
        public bool HUD_IsPinch(BtlvPos vPos) { return false; }

        // TODO
        public bool HUD_IsShowing(BtlvPos vPos) { return false; }

        // TODO
        public void DispBallBar(BtlvPos vPos, bool isDisp) { }

        public static uint lastSelectedBallItemNo
        {
            get => _lastSelectedBallId;
            set
            {
                if (calc.ITEM_IsBall((ushort)value) && value != (ushort)ItemNo.SAFARIBOORU && value != (ushort)ItemNo.PAAKUBOORU)
                    _lastSelectedBallId = value;
            }
        }

        public BUIActionList ActionList { get => _actionList; }
        public BUIWazaList WazaList { get => _wazaList; }
        public BUIPokeBallList PokeBallList { get => _pokeBallList; }
        public BUIWazaDescription WazaDescription { get => _wazaDescription; }
        public BUIStatusWindow[] StatusWindows { get => _statusWindows; }
        public BUITokuseiPlate TokuseiNear { get => _tokuseiNear; }
        public BUITokuseiPlate TokuseiFar { get => _tokuseiFar; }
        public BUIBallPlate BallPlateNear { get => _ballPlateNear; }
        public BUIBallPlate BallPlateFar { get => _ballPlateFar; }
        public BUISafariBall SafariBall { get => _safariBall; }
        public BUITargetSelect TargetSelect { get => _targetSelect; }
        public BUICommTime CommTime { get => _commTime; }

        public Dpr.UI.Cursor CursorFrame { get => _cursor; }
        public ItemNo SelectItem { get => _pokeBallList.IsValid ? _pokeBallList.Result : _selectItem; }
        public static BattleViewUISystem Instance { get => _instance; }

        public static IEnumerator LoadAssetSelf(Transform parent, [Optional] Action callback)
        {
            if (_instance != null)
                yield break;

            AssetManager.AppendAssetBundleRequest(BattleViewDefine.Path.GetUISystemPath(), true, null, MessageHelper.GetLocalizeVariants());

            yield return AssetManager.DispatchRequests((eventType, name, asset) =>
            {
                if (eventType != RequestEventType.Activated)
                    return;

                var go = asset as GameObject;
                if (go == null)
                    return;

                _instance = Instantiate(go, parent).GetComponent<BattleViewUISystem>();
            });

            callback?.Invoke();
        }

        public static AssetBundleUnloader UnloadAssetSelf()
        {
            var unloader = new AssetBundleUnloader
            {
                assetBundleName = BattleViewDefine.Path.GetUISystemPath(),
                isUnloadAllLoadedObjects = true
            };

            unloader.Release();
            return unloader;
        }

        // TODO
        public void Remove() { }

        // TODO
        private void RemoveImpl() { }

        // TODO
        public void Startup() { }

        // TODO
        public void OnUpdate(float deltaTime) { }

        // TODO
        public void Show(bool isWithBallPlate = false) { }

        // TODO
        public void Hide() { }

        // TODO
        public void HideHpGuge() { }

        // TODO
        public void OnHUDEvent(HUDEventID eventId, BattleViewSystem pViewSystem) { }

        // TODO
        public void Apply(int interpFrame) { }

        // TODO
        public void SetCurrentPokemonStatus() { }

        // TODO
        public BUIStatusWindow GetStatusWindow(BtlvPos pos) { return null; }

        // TODO
        private void InitStatusWindows(bool isEnableTokusei) { }

        // TODO
        private void InitializeStatusWindow(BtlvPos pos, bool isEnableTokusei) { }

        // TODO
        public void SetVisible(BtlvPos vPos, bool isVibivle, bool isWithBallPlate, bool isForced = false) { }

        // TODO
        public void SetVisibleForced(BtlvPos vPos, bool isVisible, bool isWithBallPlate) { }

        // TODO
        public void SwitchShowStatusWindow(BtlvPos vPos, bool isShow) { }

        // TODO
        private IEnumerator SwitchShowStatusWindowCoroutine(BtlvPos vPos, bool isShow) { return null; }

        public void SwitchShowStatusWindows(bool isShow)
        {
            StartCoroutine(SwitchShowStatusWindowsCoroutine(isShow));
        }

        // TODO
        private IEnumerator SwitchShowStatusWindowsCoroutine(bool isShow) { return null; }

        // TODO
        private void SwitchShowStatusWindowsCore(bool isShow, bool isForceBallHide = true) { }

        public bool IsOpenedStatus()
        {
            for (int i=0; i<_statusWindows.Length; i++)
            {
                if (_statusWindows[i].isInitialized && _statusWindows[i].isCloseState)
                    return false;
            }

            return true;
        }

        // TODO
        public bool IsClosingStatus() { return false; }

        // TODO
        public bool IsSeqEndWait() { return false; }

        // TODO
        private IEnumerator CloseStatusWindow(BUIStatusWindow window) { return null; }

        // TODO
        private bool IsShowStatusEnemyOnly(List<bool> flags) { return false; }

        private bool IsStatusWindowTarasit()
        {
            for (int i=0; i<_statusWindows.Length; i++)
            {
                if (_statusWindows[i].IsTransition)
                    return true;
            }

            return false;
        }

        // TODO
        public bool Wait() { return false; }

        public void SwitchShowActionList(bool isShow, bool withStatusWindow = false, bool withDecoraton = true)
        {
            StartCoroutine(SwitchActionListCoroutine(isShow, withStatusWindow, withDecoraton));
        }

        private IEnumerator SwitchActionListCoroutine(bool isShow, bool withStatusWindow = false, bool withDecoraton = true)
        {
            while (IsOpenMessage() || IsStatusWindowTarasit() || _actionList.IsTransition)
                yield return null;

            if (!isShow)
            {
                if (_actionList.IsShow)
                    _actionList.Hide(false, null);
            }
            else if (!_actionList.IsShow)
            {
                _actionList.Show(null);
                _actionList.UpdateActionButton(false);
                _pokeBallList.SetInvalid();
                PlaySe(AK.EVENTS.UI_COMMON_SLIDE);
            }

            SetCurrentPokemonStatus();
            if (withStatusWindow)
            {
                Apply(0);
                SwitchShowStatusWindowsCore(isShow, false);
            }

            if (withDecoraton)
                SwitchShowDecoImage(isShow);
        }

        // TODO
        private void ShowActionListOnly(bool isShow) { }

        private IEnumerator ShowActionListOnlyCoroutine(bool isShow)
        {
            while (IsOpenMessage() || _actionList.IsTransition)
                yield return null;

            if (!isShow)
            {
                if (_actionList.IsShow)
                    _actionList.Hide(false, null);
            }
            else if (!_actionList.IsShow)
            {
                _actionList.Show(null);
                _actionList.UpdateActionButton(false);
                _pokeBallList.SetInvalid();
                PlaySe(AK.EVENTS.UI_COMMON_SLIDE);
            }
        }

        // TODO
        private void SwitchShowDecoImage(bool isShow) { }

        // TODO
        private bool IsNearSide(BtlPokePos pos) { return default; }

        // TODO
        private BUITokuseiPlate GetTokuseiPlate(BtlPokePos pos) { return default; }

        // TODO
        private void OpenPokemonWindow(PokeSelParam selParam, PokemonBattleWindow.Param winParam, uint outMemberIndex, PokeSelResult result) { }

        // TODO
        private void OpenPokemonBattleWindow(PokemonBattleWindow uiWindow, PokemonBattleWindow.Param winParam) { }

        // TODO
        private void OnSwapPokemon(List<BTL_POKEPARAM> pokemonParams, PokemonBattleWindow.PositionType posType) { }

        // TODO
        private void OnSwapCancel() { }

        // TODO
        private PokemonBattleWindow.Param.BattleType GetBattleType() { return default; }

        // TODO
        private bool IsOpenMessage() { return false; }

        // TODO
        private bool IsEndMessage() { return false; }

        // TODO
        private void SetMessageQueue(MessageTextParseDataModel strBuf, MsgShowParam showParam) { }

        // TODO
        private IEnumerator MessageWindowCoroutine() { return null; }

        // TODO
        private void OpenMessageWindow(MessageTextParseDataModel strBuf, MsgShowParam showParam) { }

        // TODO
        private void CloseMessageWindow() { }

        // TODO
        private void OpenSelectWindow(bool bCancel, YesNoMode mode) { }

        // TODO
        private void OpenMenuUI<T>(UIWindowID id, Action<T> openProc, bool doDuckoff = true) { }

        // TODO
        private void ForceQuitMenuUI<T>(Action<T> closeProc, bool isMenuShow = true) { }

        // TODO
        private IEnumerator CloseMenuUICoroutine<T>(Action<T> closeProc, bool isMenuShow = true) { return null; }

        // TODO
        private void BeginTutorialCapture() { }

        // TODO
        public IEnumerator WaitForStandbyAction(float wait) { return null; }

        // TODO
        public IEnumerator WaitForStandbyWaza(float wait) { return null; }

        // TODO
        public IEnumerator SelectActionListButton(BUIActionList.ActionButtonType target, float wait) { return default; }

        // TODO
        public IEnumerator ExecuteActionButton(float wait) { return null; }

        // TODO
        public IEnumerator ExecuteWazaButton(float wait) { return null; }

        // TODO
        public IEnumerator SetDumyBag(bool enable, float wait = 0.0f) { return null; }

        // TODO
        private void SetTutorialItem(ItemNo itemNo, int count) { }

        // TODO
        public string GetAffinityText(BTL_POKEPARAM bpp, WazaNo wazaNo, BTL_POKEPARAM target) { return null; }

        // TODO
        public string GetAffinityText(BTL_POKEPARAM bpp, WazaNo wazaNo, List<BTL_POKEPARAM> targets) { return null; }

        // TODO
        public Sprite GetAffinitySprite(BTL_POKEPARAM bpp, WazaNo wazaNo, BTL_POKEPARAM target) { return null; }

        // TODO
        public Sprite GetAffinitySprite(BTL_POKEPARAM bpp, WazaNo wazaNo, List<BTL_POKEPARAM> targets) { return null; }

        // TODO
        public void PlaySe(uint eventId) { }

        // TODO
        public void SetSexIcon(Sex sex, Image target) { }
    }
}