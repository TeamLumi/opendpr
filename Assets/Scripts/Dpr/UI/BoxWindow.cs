using DG.Tweening;
using Dpr.Box;
using Dpr.Message;
using Dpr.MsgWindow;
using Dpr.NetworkUtils;
using Effect;
using Pml;
using Pml.PokePara;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.UI
{
    public class BoxWindow : UIWindow
    {
        private static string[] _operationLabels = new string[3]
        {
            "SS_box_037", "SS_box_039", "SS_box_038",
        };
        private static string[] _displayModeLabels = new string[3]
        {
            "SS_box_034", "SS_box_035", "SS_box_036",
        };
        public static readonly List<(SearchType type, string textId, string nameId, string descriptionId, string subDescriptionId)> SearchMsgData = new List<(SearchType type, string textId, string nameId, string descriptionId, string subDescriptionId)>()
        {
            (SearchType.Pokemon,     "SS_box_105", "SS_box_116", "SS_box_129", "SS_box_130"),
            (SearchType.Type1,       "SS_box_106", "SS_box_117", "SS_box_131", "SS_box_144"),
            (SearchType.Type2,       "SS_box_107", "SS_box_117", "SS_box_132", "SS_box_145"),
            (SearchType.Waza,        "SS_box_108", "SS_box_118", "SS_box_133", "SS_box_134"),
            (SearchType.Machine,     "SS_box_109", "SS_box_119", "SS_box_135", ""),
            (SearchType.Tokusei,     "SS_box_110", "SS_box_120", "SS_box_136", "SS_box_137"),
            (SearchType.Personality, "SS_box_111", "SS_box_121", "SS_box_138", "SS_box_{0}"),
            (SearchType.Sex,         "SS_box_112", "SS_box_122", "SS_box_139", ""),
            (SearchType.Item,        "SS_box_113", "SS_box_126", "SS_box_140", ""),
            (SearchType.Mark,        "SS_box_114", "",           "SS_box_141", ""),
            (SearchType.Team,        "SS_box_115", "SS_box_128", "SS_box_143", ""),
        };
        public const string BoxMsgFileName = "ss_box";
        public const string BoxNameFileName = "ss_boxname";
        public const string BoxSearchFileName = "ss_initial";
        public const string BoxMsgSearchBlank = "SS_box_583";
        public const string BoxMsgSearchItemBase = "SS_initial_";
        public const string BoxMsgDescriptionDefault = "SS_box_104";
        private const string _boxTitleNameBase = "box_bt_box_01_body_";
        private const string _boxBgNameBase = "box_pl_box_01_";
        public const int PartyMemberNum = 6;
        public const int TrayCellWidth = 6;
        public const int TrayCellHeight = 5;
        public const float PanelDuration = 0.2f;
        public const Ease PanelEase = Ease.OutSine;
        private const float _pokeIconDuration = 0.2f;
        private const float _modelApplyDuration = 0.7f;
        private const int _cursorSortOrderAddValue = 80;
        private const float _cursorOffsetX = 4.0f;
        private const float _cursorPartyOffsetX = -90.0f;
        private const float _cursorOffsetY = 32.0f;
        private const float _cursorHoldOffsetY = 42.0f;
        private const float NetTradeOutTime = 7.0f;
        private const int LocalTradeOpenID = 15;
        public const float PokeIconSelectAlpha = 0.5f;

        public static readonly Color32 DisableIconColor = new Color32(0, 0, 0, 160);
        public static readonly Color32 EnableIconColor = new Color32(255, 255, 255, 255);

        [SerializeField]
        private Image _displayTitle;
        [SerializeField]
        private UIText _displayModeText;
        [SerializeField]
        private Image _operationTitle;
        [SerializeField]
        private UIText _operationTypeText;
        [SerializeField]
        private Color32[] _operationTypeColors;
        [SerializeField]
        private RectTransform _partyTrayRoot;
        [SerializeField]
        private CanvasGroup _partyTrayCanvasGroup;
        [SerializeField]
        protected Image[] _partyArrows;
        [SerializeField]
        private BoxParty _partyNormal;
        [SerializeField]
        private BoxInfinityScroll _battleTeamScroll;
        [SerializeField]
        private RectTransform _boxTrayRoot;
        [SerializeField]
        private CanvasGroup _boxTrayCanvasGroup;
        [SerializeField]
        protected Image[] _trayArrows;
        [SerializeField]
        private BoxInfinityScroll _trayScroll;
        [SerializeField]
        private RectTransform _naviPartyRoot;
        [SerializeField]
        private RectTransform _naviTrayRoot;
        [SerializeField]
        private BoxMultiNavigator[] _multiNavis;
        [SerializeField]
        private UINavigator _naviPartySelect;
        [SerializeField]
        private UIText[] _leftButtonTexts;
        [SerializeField]
        private Image _searchButtunImage;
        [SerializeField]
        private Image _searchIconImage;
        [SerializeField]
        private Image _boxButtunImage;
        [SerializeField]
        private Image _boxIconImage;
        [SerializeField]
        private BoxListPanel _boxListPanel;
        [SerializeField]
        private PokemonIcon _swapRootPrefab;
        [SerializeField]
        private RectTransform _contextMenuRoot;
        [SerializeField]
        private Cursor _cursor;
        [SerializeField]
        private Transform _cursorBody;
        [SerializeField]
        private Image _rangeCursor;
        [SerializeField]
        private Image _rangePlate;
        [SerializeField]
        private Canvas _cursorCanvas;
        [SerializeField]
        private PokemonModelView _modelViewSide;
        [SerializeField]
        private PokemonModelView _modelViewTrade;
        [SerializeField]
        private RectTransform _modelSideRoot;
        [SerializeField]
        private RectTransform _modelTradeRoot;
        [SerializeField]
        private BoxSearchPanel _searchPanel;
        [SerializeField]
        private BoxTextSelector _searchSubPanel;
        [SerializeField]
        private BoxSearchDescription _searchDescription;
        [SerializeField]
        private GameObject _tradeInfo;
        [SerializeField]
        private UIText _traderName;
        [SerializeField]
        private BoxNamePlate _namePlate;
        [SerializeField]
        private BoxSelectNumberPlate _numberPlate;
        [SerializeField]
        private BoxStatusPanel _statusPanel;
        [SerializeField]
        private BoxMarkingSettingPanel _markSettingPanel;
        [SerializeField]
        private GameObject _selectCountPlate;
        [SerializeField]
        private UIText _selectCountText;
        [SerializeField]
        private BoxWallPaperSelector _wallPaperSelector;
        [SerializeField]
        private CanvasGroup _topCanvasGroup;
        [SerializeField]
        private CanvasGroup _bottomCanvasGroup;
        [SerializeField]
        private Image _darkScreen;
        [SerializeField]
        private Transform _effectRoot;

        private readonly int _animStateIn = Animator.StringToHash("in");
        private readonly int _animStateOut = Animator.StringToHash("out");

        private ControlType _controlType;
        private OperationType _operationType;
        private DisplayMode _displayMode;
        private StatusType _statusType;
        private BoxParty _battleTeam;
        private BoxTray _boxTray;
        private UINavigator _navigator;
        private PokemonIcon _swapIcon;
        private PokemonParam _currentPokeParam;
        private string _currentMsgID;
        private int _currentTrayIndex;
        private int _currentTeamIndex;
        private int _wallNo;
        private UINavigator _lastNaviBoxTrayItem;
        private UINavigator _fromNavigator;
        private UINavigator _returnNavigator;
        private int _fromTrayIndex = -1;
        private int _fromTeamIndex = -1;
        private BoxInfinityScrollItem _fromTray;
        private List<int> _hideIconIndexes;
        private List<int> _effectIndexes;
        private bool _isRepeatCancel;
        private int _rangeX;
        private int _rangeY;
        private int _rangeWidth;
        private int _rangeHeight;
        private UINavigator _rangeBeginNavigator;
        private List<PokemonIcon> _swapIcons;
        private List<UINavigator> _fromNavigators;
        private List<UINavigator> _toNavigators;
        private HashSet<int> _existSwapIndexes;
        private SearchType _searchType = SearchType.MAX;
        private SEARCH_DATA _searchData;
        private bool _isDuckOn;
        private OpenParam _param;
        private List<SelectedPokemon> _selected;
        private Action<BoxWindow, SelectedPokemon[]> _onSelected;
        private Action<BoxWindow> _onDecide;
        private Action<BoxWindow> _onConfirm;
        private Action<BoxWindow> _onComplete;
        private Action<BoxWindow> _onCancelSelect;
        private MessageEnumData.MsgLangId _targetLangId = MessageEnumData.MsgLangId.JPN;
        private Coroutine _coOpen;
        private Coroutine _coClose;
        private PokemonModelView _modelView;
        private MsgWindowParam _messageParam;
        private Keyguide.Param _keyguideParam;
        private Material _matSearchButton;
        private Material _matBoxButton;
        private DG.Tweening.Sequence _twSequence;
        private ContextMenuWindow _contextMenu;
        private float _waitSave;
        private EffectInstance _formChangeEffectInstance;
        private bool isCancelFormChange;
        private TradeParam _tradeParam;
        private CanvasGroup _tradeInfoCanvasGroup;
        private DialogWindow _networkDialog;
        private bool _isPhaseProcDone;
        private bool _isTradeInfoEnable;
        private float _tradeTimeoutCount;
        private bool _isTradeCheckIllegal;
        private float _modelOpenPosX;
        private float _modelClosePosX;
        private float _modelTradeOpenPosX;
        private float _modelTradeClosePosX;
        private float _partyOpenPosX;
        private float _partyClosePosX;
        private float _boxTrayPosX;
        private float _boxTraySlideX;
        private float _trayCellSizeX;
        private float _trayCellSizeY;
        private bool _isControlEnable;
        public static bool IsPanelTrasition = false;
        public static SearchIndexData SearchIndexData = null;
	    private bool _isForceClosing;
        private static int _limitBoxRefCount = 0;

        // TODO
        public NetTradePhase TradePhase { get; }
        public bool IsOpenRunning { get; }
        public bool IsCloseRunning { get; }
        public bool IsClosed { get; }
        public bool IsTradeCheckIllegal { get; set; }

        public static Color32[] MarkColorSet { get; private set; }

        // TODO
        public static void SetPanelTransitionSide(GameObject parentObject, RectTransform targetTransform, float targetPosX, [Optional] Action callback) { }

        // TODO
        public static void SetPanelTransitionFade(GameObject parentObject, CanvasGroup targetCanvas, float targetAlpha, [Optional] Action callback) { }

        // TODO
        public static void SetPanelTransitionBoth(GameObject parentObject, RectTransform targetTransform, float targetPosX, CanvasGroup targetCanvas, float targetAlpha, [Optional] Action callback) { }

        // TODO
        private static void SetPanelTransition(GameObject parentObject, Tween[] tweens, [Optional] Action callback) { }

        // TODO
        public static void CloseForce() { }

        // TODO
        private void CloseForceInternal(bool isCloseCallback = true) { }

        // TODO
        public static void CloseOverUIWindows() { }

        public void Awake()
        {
        	var uVar1 = UnityEngine_Component__GetComponentInChildren<object>
        	                  (this);
        	this._animator = uVar1;
        }

        // TODO
        public void Open(UIWindowID prevWindowId, bool isDuckOn = false) { }

        // TODO
        public void Open(OpenParam param, UIWindowID prevWindowId, bool isDuckOn = false) { }

        // TODO
        public void Open(int openType, Action<BoxWindow, SelectedPokemon[]> onSelected, UIWindowID prevWindowId = WINDOWID_FIELD) { }

        // TODO
        public void Open(OpenParam param, Action<BoxWindow, SelectedPokemon[]> onSelected, UIWindowID prevWindowId = WINDOWID_PARENT) { }

        // TODO
        public void Open(string otherName, MessageEnumData.MsgLangId msgLangId, Action<BoxWindow, SelectedPokemon[]> onSelected, Action<BoxWindow> onDecide, Action<BoxWindow> onConfirm, Action<BoxWindow> onComplete, Action<BoxWindow> onCancelSelect, bool isFirst = true, UIWindowID prevWindowId = WINDOWID_FIELD) { }

        // TODO
        public void Open(OpenParam param, TradeParam tradeParam, UIWindowID prevWindowId = WINDOWID_FIELD) { }

        // TODO
        public IEnumerator OpOpen(UIWindowID prevWindowId) { return null; }

        // TODO
        private void OnPartySelectChanged(BoxInfinityScrollItem scrollItem) { }

        // TODO
        private void OnTraySelectChanged(BoxInfinityScrollItem scrollItem) { }

        // TODO
        public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }

        // TODO
        private IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return null; }

        // TODO
        private void ApplyPokemonStatusAndModel(UINavigator navigator, bool isImmidiate = false, bool isPlateEnable = true) { }

        // TODO
        private void ApplyPokemonStatusAndModel(PokemonParam param, bool isImmidiate = false, bool isPlateEnable = true) { }

        // TODO
        private void SetModelPanel(bool isEnable, [Optional, DefaultParameterValue(false)] bool isImmediate, [Optional] Action callBack) { }

        // TODO
        private void SetTrayNamePlate(UINavigator navigator) { }

        // TODO
        private void SetModelTradePanel(bool isEnable) { }

        // TODO
        private void SetWallPaperImage(BoxTray item, int wallNo) { }

        // TODO
        private void SetTradeInfo(bool isEnable) { }

        // TODO
        private void SetSelectBoxPanel(bool isEnable, [Optional] int? index) { }

        // TODO
        private void SetPanelsToSearchMode(bool isEnable) { }

        // TODO
        private void SetSelectBoxMode(bool isEnable) { }

        private void SetMarkingMode(bool isEnable)
        {
        	var uVar1 = 2;
        	if (!isEnable) {
        	  uVar1 = 0;
        	}
        	this._controlType = (ControlType)(uVar1);
        	SetupKeyguide();
        }

        private void SetWallPaperSelectMode(bool isEnable)
        {
        	var uVar1 = 3;
        	if (!isEnable) {
        	  uVar1 = 0;
        	}
        	this._controlType = (ControlType)(uVar1);
        	if (!isEnable) {
        	  ExtensionMethods.SetActive(this._cursorBody,1);
        	}
        	SetupKeyguide();
        }

        // TODO
        private void SetupKeyguide() { }

        private void SetBoxButtonGray(bool isGray)
        {
        	var uVar1 = Shader.PropertyToID(StringLiteral_11179);
        	var uVar3 = 0x3f800000;
        	if (!isGray) {
        	  uVar3 = 0;
        	}
        	uVar3.SetFloat(this._matBoxButton,uVar1);
        }

        private void SetSearchButtonGray(bool isGray)
        {
        	var uVar1 = Shader.PropertyToID(StringLiteral_11179);
        	var uVar3 = 0x3f800000;
        	if (!isGray) {
        	  uVar3 = 0;
        	}
        	uVar3.SetFloat(this._matSearchButton,uVar1);
        }

        // TODO
        private bool IsSwap() { return false; }

        // TODO
        private bool IsRangeSelecting() { return false; }

        // TODO
        private bool IsRangeSwap() { return false; }

        // TODO
        public static bool isLimitBox { get; }

        // TODO
        public static void LimitBox(bool enabled) { }

        // TODO
        private bool IsCheckCloseForce() { return false; }

        // TODO
        private void ExecCloseForce() { }

        // TODO
        private void OnUpdate(float deltaTime) { }

        // TODO
        private bool UpdateNetworkTrade(float deltaTime) { return false; }

        public void ToNextPhase(NetTradePhase next = NetTradePhase.None)
        {
        	ExtensionMethods.SetActive(this._darkScreen,0);
        	var uVar1 = 0.IsOpen;
        	if ((uVar1 & 1) == 0) {
        	  this._isPhaseProcDone = false;
        	}
        	else {
        	  MsgWindowManager.CloseMsg(0);
        	  this._isPhaseProcDone = false;
        	}
        	if ((int)next != 0) {
        	  this._tradeParam.tradePhase = next;
        	}
        	this._tradeParam.tradePhase = this._tradeParam.tradePhase + 1;
        }

        // TODO
        public void SetOtherPokeParam(PokemonParam param, int cassetVersion) { }

        // TODO
        public void SetTradeMessageID(string messageId, ErrorCodeID errorId = ErrorCodeID.NUM) { }

        // TODO
        private void DispTradeMessage([Optional] Action callback) { }

        // TODO
        private IEnumerator WaitTradeSave() { return null; }

        // TODO
        private IEnumerator WaitLastConfirm() { return null; }

        // TODO
        private void CloseOverBoxWindows() { }

        // TODO
        private bool UpdateFunctionButton(float deltaTime) { return false; }

        // TODO
        private bool UpdatePlusMinusButton(float deltaTime) { return false; }

        // TODO
        private bool UpdateTray(float deltaTime) { return false; }

        // TODO
        private bool UpdateSwap() { return false; }

        // TODO
        private void CancelCursorMove() { }

        // TODO
        private bool UpdateBoxList(float deltaTime) { return false; }

        // TODO
        private bool DropToBox(int toTrayIndex) { return false; }

        // TODO
        private void BackTrayByBoxlist() { }

        // TODO
        private void UpdateSelect(float deltaTime, [Optional] UnityAction onMoveComplete) { }

        // TODO
        private void SetOperationType(OperationType operationType) { }

        // TODO
        private void SetDisplayMode(DisplayMode displayMode) { }

        // TODO
        private bool SetNavigate(UINavigator.NavigateType dirType, [Optional] UINavigator navigator, bool isSE = true) { return false; }

        // TODO
        private bool SetNavigateInTray(UINavigator.NavigateType dirType, [Optional] UINavigator navigator, bool isSE = true) { return false; }

        // TODO
        private bool SetRangeNavigateInTray(UINavigator.NavigateType dirType, bool isSE = true) { return false; }

        // TODO
        private void SetNavigateFunction(UINavigator.NavigateType dirType) { }

        // TODO
        private bool SetNavigateBoxSelect(UINavigator.NavigateType type, UINavigator navigator, bool isSE = true) { return false; }

        // TODO
        private void SetCursor([Optional, DefaultParameterValue(true)] bool isSE, [Optional] UINavigator navigator) { }

        // TODO
        private void SetCursorPattern(OperationType type, CursorPattern pattern = CursorPattern.Normal) { }

        // TODO
        private void SetSelectIcons(UINavigator.NavigateType dirType = UINavigator.NavigateType.None) { }

        // TODO
        private void SetSwapRootParent() { }

        // TODO
        private void ApplyModel(BoxItem naviItem) { }

        // TODO
        private void ApplyModel(PokemonParam param, bool isTrade = false) { }

        // TODO
        private IEnumerator CoApplyModel(PokemonParam param) { return null; }

        // TODO
        private void InitRangeSelect() { }

        // TODO
        private void BeginRangeSelect() { }

        // TODO
        private void BeginRangeCursorMove() { }

        // TODO
        private void SetRangeIcons(List<UINavigator> navigators) { }

        // TODO
        private void GetRangeFromNavigators(ref List<UINavigator> recieveList, UINavigator startNavi) { }

        // TODO
        private bool GetRangeToNavigators(ref List<UINavigator> recieveList, UINavigator selectNavi, List<UINavigator> fromTargetList, [Optional] BoxInfinityScrollItem fromTray) { return default; }

        // TODO
        private void UpdatePokemonPaaram(int trayIndex, int index, PokemonParam param) { }

        // TODO
        private BoxItem GetNaviItem(UINavigator navigator) { return default; }

        // TODO
        private BoxParty GetCurrentParty() { return default; }

        // TODO
        private void ApplyBoxList(int index) { }

        // TODO
        private void ApplyCurrentTrayAtBoxList() { }

        // TODO
        private void ApplyTrayAtBoxList() { }

        // TODO
        private void ApplyTray(bool isParty) { }

        // TODO
        private void SetSelectCountPlate() { }

        // TODO
        public IEnumerator DebugNext([Optional, DefaultParameterValue(0)] int waitSec, [Optional, DefaultParameterValue(NetTradePhase.None)] NetTradePhase phase, [Optional] Action callback) { return null; }

        // TODO
        public void SetTraderName(string traderName, MessageEnumData.MsgLangId langID) { }

        // TODO
        private void OpenContextMenu() { }

        // TODO
        private void SelectPokemon(BoxItem item, bool isItemMode = false) { }

        // TODO
        private bool OnContextMenu(ContextMenuItem menuItem) { return false; }

        // TODO
        private bool OnTradeContextMenu(ContextMenuItem item) { return false; }

        // TODO
        private void OpenStatusWindow(PokemonStatusWindow.Param statusParams, OpenParam reopenParam) { }

        // TODO
        private PokemonStatusWindow.Param GetStatusParams(NaviParam naviParam) { return default; }

        // TODO
        private PokemonStatusWindow.Param GetStatusParams(NaviParam.ItemType type, int index) { return default; }

        // TODO
        private void BeginIconSelect(UINavigator navigator, bool isRemoveByTeam = false) { }

        // TODO
        private bool SetSendPokemon(SelectedPokemon target, bool isTrade = false, bool isGMS = false) { return false; }

        // TODO
        private void ResetSendPokemon(SelectedPokemon target) { }

        // TODO
        private void SetItem(NaviParam naviParam, BoxItem naviItem) { }

        // TODO
        private void RemoveItem(BoxItem naviItem) { }

        // TODO
        private void formChangeEffect(bool isFormChange, BoxItem naviItem) { }

        // TODO
        private void CancelNetworkMine() { }

        // TODO
        private void CancelNetworkTrade() { }

        // TODO
        public void ClearTradeSelected() { }

        // TODO
        private void OpenYesNoContextMenu(Func<ContextMenuItem, bool> onClicked, [Optional] UnityAction<UIWindow> onClosed, int selectIndex = 0) { }

        // TODO
        private void OpenTradeConfirmContextMenu(Func<ContextMenuItem, bool> onClicked, [Optional] UnityAction<UIWindow> onClosed, int selectIndex = 0) { }

        // TODO
        private void OpenContextMenu(List<ContextMenuItem.Param> menuItems, Func<ContextMenuItem, bool> onClicked, [Optional] UnityAction<UIWindow> onClosed, int selectIndex = 0, uint seDecide = 0) { }

        // TODO
        private void SetMessage(string messageID, [Optional, DefaultParameterValue(true)] bool isCloseEnable, [Optional] Action onClose, [Optional] Action onShow, bool isNetTrade = false) { }

        // TODO
        private void SetMessage(string msgFile, string messageID, [Optional, DefaultParameterValue(true)] bool isCloseEnable, [Optional] Action onClose, [Optional] Action onShow, bool isNetTrade = false) { }

        // TODO
        private SelectedPokemon GetSelected() { return null; }

        // TODO
        private OpenParam GetReOpenParam(NaviParam naviParam) { return null; }

        // TODO
        private bool IsSelectNgPoke(PokemonParam pokemonParam) { return false; }

        // TODO
        private void BeginRangeSwap() { }

        // TODO
        private void MoveRangePartyByParty() { }

        // TODO
        private void MoveRangeTeamByTeam() { }

        // TODO
        private void BeginRangeTrayByTray() { }

        // TODO
        private void MoveRangePartyByTray() { }

        // TODO
        private void MoveRangeTeamByTray() { }

        // TODO
        private void MoveRangeTrayByParty() { }

        // TODO
        private void RangeUnregistTeam() { }

        // TODO
        private void BeginSwap() { }

        // TODO
        private void BeginTrayByTray(UINavigator toNavigator) { }

        // TODO
        private void MoveTrayByTray(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void SwapTrayByTray(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void BeginPartyByParty(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void MoveLastPartyByParty(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void SwapPartyByParty(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void BeginPartyByTray(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void MoveLastPartyByTray(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void SwapPartyByTray(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void BeginTeamPartyByParty(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void MoveLastTeamPartyByParty(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void SwapTeamPartyByParty(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void BeginRegistTeamByTray(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void MoveLastTeamPartyByTray(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void SwapAndPackRegistTeamByTray(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void AddRegistTeam(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void SwapRegistTeamByTray(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void UnregistTeam(UINavigator fromNavigator) { }

        // TODO
        private void BeginTrayByParty(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void MoveTrayByParty(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void SwapTrayByParty(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void MoveItem(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void SwapItem(UINavigator fromNavigator, UINavigator toNavigator) { }

        // TODO
        private void RestoreSelect([Optional, DefaultParameterValue(true)] bool isDecide, [Optional, DefaultParameterValue(true)] bool isUpdate, [Optional, DefaultParameterValue(true)] bool isFromHide, [Optional] UINavigator toNavigator, [Optional] Action callback) { }

        // TODO
        private void RestoreSelectItem(bool isToChange, bool isFormChange, UINavigator toNavigator, UINavigator fromNavigator, PokemonParam toPokemonParam, PokemonParam fromPokemonParam) { }

        // TODO
        private void RestoreRangeSelect([Optional, DefaultParameterValue(true)] bool isDecide, [Optional, DefaultParameterValue(true)] bool isUpdate, [Optional, DefaultParameterValue(true)] bool isFromHide, [Optional] List<UINavigator> toNavigators, [Optional] Action callback) { }

        // TODO
        private void EndSwap(bool isParty) { }

        // TODO
        private void EndRangeSwap(bool isParty) { }

        // TODO
        private void SetPartyLast(UINavigator toNavigator, [Optional] Action<UINavigator> callback) { }

        // TODO
        private void FillPartyGap(UINavigator blankNavigator, [Optional, DefaultParameterValue(1)] int packCount, [Optional, DefaultParameterValue(true)] bool isExceptLast, [Optional] Action callback) { }

        // TODO
        private void SetIconSelect(PokemonIcon swapIcon, UINavigator navigator, bool isEnable, bool isFromHide, [Optional] Action callback) { }

        // TODO
        private void SetIconSelect(List<PokemonIcon> swapIcons, List<UINavigator> navigators, bool isEnable, bool isFromHide, [Optional] Action callback) { }

        // TODO
        private void SetTrayIconSwap(PokemonIcon swapIcon, UINavigator fromNavigator, UINavigator toNavigator, [Optional] Action callback) { }

        // TODO
        public static DG.Tweening.Sequence SetIconMoveSequence(PokemonIcon fromIcon, Vector3 toPosition, [Optional] Action callback) { return default; }

        // TODO
        public static DG.Tweening.Sequence SetIconMoveSequence(int count, PokemonIcon[] fromIcons, Vector3[] toPositions, [Optional] Action callback) { return default; }

        // TODO
        private void SetRangeSwapIcon(int index, PokemonIcon icon) { }

        // TODO
        private bool SetFormChangeByItem(PokemonParam pokemonParam) { return false; }

        // TODO
        private bool SetFormChangeByMove(PokemonParam pokemonParam) { return false; }

        // TODO
        private void PlayFormChangeeffect(bool isPlay, PokemonParam pokemonParam, PokemonIcon pokeIcon, [Optional, DefaultParameterValue(true)] bool isSingle, [Optional] Action onChangeIcon, [Optional] Action onComplete)
        {
            // TODO
            IEnumerator EffectProc() { return default; }

            // TODO
            void Complete() { }
        }

        // TODO
        private bool CanBattlePokemon(PokemonParam param) { return false; }

        // TODO
        private PokemonParam GetPartyPokemonParam(int index) { return null; }

        // TODO
        private UINavigator GetLastPartyNavigator() { return null; }

        // TODO
        private void SetPairPokemon(PokemonParam pokeParam) { }

        // TODO
        private void ReturnPairPokemon(PokemonParam pokeParam) { }

        // TODO
        private int GetPairPokemonIndex() { return 0; }

        // TODO
        public static bool IsHitSearchType(PokemonParam pokemonParam, SEARCH_DATA data, int tray = BoxWork.TRAY_MAX, int pos = BoxWork.TRAY_POKE_MAX) { return false; }

        // TODO
        public static bool IsHitSelectType(PokemonParam pokemonParam, OpenParam param) { return false; }

        // TODO
        private void SetSearchMode(bool isEnable) { }

        private void SetSearchSubMode(bool isEnable)
        {
        	var uVar1 = 4;
        	if (isEnable) {
        	  uVar1 = 5;
        	}
        	this._controlType = (ControlType)(uVar1);
        	SetupKeyguide();
        }

        // TODO
        private void ApplyBoxTrayBySearch() { }

        // TODO
        private void ApplyPartyTrayBySearch() { }

        // TODO
        private void ApplyTeamTrayBySearch() { }

        // TODO
        private void ApplyBoxListBySearch(int trayNum) { }

        // TODO
        private void ApplyDescription() { }

        private enum ControlType : int
        {
            SelectPoke = 0,
            SelectBox = 1,
            SetMark = 2,
            SelectWallPaper = 3,
            SelectSearch = 4,
            SelectSearchSub = 5,
        }

        public enum OperationType : int
        {
            Default = 0,
            Useful = 1,
            Range = 2,
            Num = 3,
        }

        public enum DisplayMode : int
        {
            Arrangement = 0,
            Item = 1,
            Battle = 2,
            Num = 3,
        }

        public enum CursorPattern : int
        {
            Normal = 0,
            Hold = 1,
            Num = 2,
        }

        public class OpenParam
        {
            public DisplayMode dispMode;
            public int tray;
            public int index;
            public int teamIndex = -1;
            public bool isSelectParty;
            public OpenType openType = OpenType.External;
            public int selectCount = 1;
            public int targetLevel;
            public bool isEnableDying = true;
            public bool isEnableEgg;
            public bool isEnableTeam;
            public bool isEnableParty = true;
            public bool isShowSelectCount;
            public bool isEnableKeyboard = true;
            public bool isOpenFromBattleTeam;
            public bool isDisableUseful;
            public bool isDisableDuplicate;
            public bool isDontDuckOffBGM;
            public bool isExternalTrade;
            public bool isGMS;
            public int[] targetsPokeNo;
            public int[] selectNgPokeNos;
            public string tradeName;
            public List<SelectedPokemon> selected;
            public SEARCH_DATA searchData;
        }

        public class TradeParam
        {
            public int selectIndex;
            public Action<BoxWindow, SelectedPokemon[]> onSelected;
            public Action<BoxWindow> onDecide;
            public Action<BoxWindow> onConfirm;
            public Action<BoxWindow> onComplete;
            public Action<BoxWindow> onCancelSelect;
            public PokemonParam otherOriginalParam;
            public PokemonParam otherPokeParam;
            public NetTradePhase tradePhase;
            public string messageId;
            public MessageEnumData.MsgLangId langId = MessageEnumData.MsgLangId.JPN;
            public ErrorCodeID errorId = ErrorCodeID.NUM;
        }

        public enum OpenType : int
        {
            Normal = 0,
            External = 1,
            TradeNPC = 2,
            TradeNetwork = 3,
        }

        public enum NetTradePhase : int
        {
            None = 0,
            WaitSave = 1,
            PlayerSelecting = 2,
            WaitSend = 3,
            OtherPokeConfirm = 4,
            WaitOtherDecide = 5,
            LastConfirm = 6,
            WaitTrading = 7,
            Complete = 8,
            WaitClose = 9,
            CancelOther = 10,
            Error = 11,
        }

        public class SelectedPokemon
        {
            public PokemonParam Param;
            public int TrayIndex;
            public int IndexInTray;
        }

        public class NaviParam
        {
            public ItemType itemType;
            public int index = -1;

            public enum ItemType : int
            {
                Party = 0,
                Tray = 1,
                Box = 2,
            }
        }

        private enum MultiNaviType : int
        {
            BoxSelect = 0,
            UnitLook = 1,
            UnitSearch = 2,
            BoxLook = 3,
            BoxSearch = 4,
        }

        public enum StatusType : int
        {
            None = 0,
            Status = 1,
            Judge = 2,
        }

        public enum SearchType : int
        {
            Pokemon = 0,
            Type1 = 1,
            Type2 = 2,
            Waza = 3,
            Machine = 4,
            Tokusei = 5,
            Personality = 6,
            Sex = 7,
            Item = 8,
            Mark = 9,
            Team = 10,
            None = 11,
            MAX = 11,
        }

        public enum SearchItem : int
        {
            YES = 0,
            NO = 1,
            MAX = 2,
            NONE = 2,
        }

        public class SEARCH_DATA
        {
            public MonsNo mons;
            public PokeType type1;
            public PokeType type2;
            public WazaNo waza;
            public int waza_machine;
            public TokuseiNo tokusei;
            public Seikaku seikaku;
            public Sex sex;
            public SearchItem item;
            public int mark;
            public int team;
            public int form;
            public bool is_active;

            public SEARCH_DATA()
            {
                Clear();
            }

            public void Clear()
            {
                type1 = PokeType.NULL;
                type2 = PokeType.NULL;
                sex = Sex.NUM;
                waza = WazaNo.NULL;
                waza_machine = 0x7FFFFFFF;
                tokusei = TokuseiNo.NULL;
                seikaku = Seikaku.NUM;
                item = SearchItem.MAX;
                mark = 0;
                mons = MonsNo.NULL;
                team = BoxWork.TEAM_MAX;
                form = 0;
                is_active = false;
            }

            public void SetActive()
            {
            	if (((((((int)this.mons == 0) && (this.type1 == '\x12')) &&
            	      (this.type2 == '\x12')) &&
            	     (((int)this.waza == 0 && (this.waza_machine == 0x7fffffff)))) &&
            	    (((int)this.tokusei == 0 &&
            	     (((int)this.seikaku == 0x19 && (this.sex == '\x03')))))) &&
            	   (((int)this.item == 2 &&
            	    ((this.mark == 0 && (this.team == 6)))))) {
            	  this.is_active = this.form != 0;
            	}
            	this.is_active = true;
            }
        }

        public class SearchItemData
        {
            public string Label;
            public Sprite MarkSprite;
            public bool IsEnable;

            public SearchItemData(string label, [Optional] Sprite sprite)
            {
                Label = label;
                MarkSprite = sprite;
                IsEnable = true;
            }
        }
    }
}