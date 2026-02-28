using Dpr.Demo;
using Dpr.MsgWindow;
using Pml;
using Pml.PokePara;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
    public class PokemonStatusWindow : UIWindow
    {
        [SerializeField]
        private RectTransform _messageWindowRoot;
        [SerializeField]
        private UIText _panelTitle;
        [SerializeField]
        private PokemonStatusTab[] _tabs;
        [SerializeField]
        private Image[] _imageTabCorners;
        [SerializeField]
        private UIPokeStatusSelectPanel _uiPokeStatus;
        [SerializeField]
        private GameObject _aButton;
        [SerializeField]
        private PokemonModelView _modelView;
        [SerializeField]
        private Image[] _arrows;
        private List<PokemonStatusTab> _activeTabs = new List<PokemonStatusTab>();
        private List<PokemonStatusTab> _enableTabs = new List<PokemonStatusTab>();
        private List<int> BattlePanelList = new List<int>() { 0, 1, 2, 3 };
        private int _selectIndex;
        private int _selectTabIndex;
        private Param _param;

        private static ConditionParam _conditionParam = null;
        private static bool _isClosedPofinEating = true;

        public int selectIndex { get => _selectIndex; }

        private void Awake()
        {
        	var uVar1 = UnityEngine_Component__GetComponentInChildren<object>
        	                  (this,1);
        	this._animator = uVar1;
        }

        // TODO
        public override void OnCreate() { }

        // TODO
        public void OpenForBattle(Param param, UIWindowID prevWindowId) { }

        // TODO
        public void Open(Param param, UIWindowID prevWindowId) { }

        // TODO
        public IEnumerator OpOpen(Param param, UIWindowID prevWindowId) { return default; }

        // TODO
        public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }

        // TODO
        public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }

        // TODO
        private void UpdateBoxPokemonParams() { }

        // TODO
        private void OnUpdate(float deltaTime) { }

        // TODO
        private bool UpdateSelect(float deltaTime) { return default; }

        // TODO
        private bool SetSelectIndex(int selectIndex, int move, bool isInitialized = false) { return default; }

        // TODO
        private void SetupTabs() { }

        // TODO
        private void SetupPanel() { }

        // TODO
        private void onChangeMemberSelectArrow(bool isShow) { }

        // TODO
        private void OnChangeAbuttonGuide(bool isShow, string messageFile, string messageLabel) { }

        // TODO
        private void OnOpenBag() { }

        // TODO
        private void OnOpenBagOfWazaMachine(bool isContest) { }

        // TODO
        private void OnOpenPofinCase() { }

        // TODO
        private void OnOpenMessageWindow(MsgWindowParam messageParam) { }

        // TODO
        private void OnForceClosed() { }

        // TODO
        protected override void OpenMessageWindow(MsgWindowParam messageParam) { }

        // TODO
        private bool UpdateSelectTab(float deltaTime) { return default; }

        // TODO
        private bool SetSelectTabIndex(int selectTabIndex, int move, bool isForce = false) { return default; }

        // TODO
        private void PlayAnimTabArrow(int move) { }

        // TODO
        public static void SetPofinEatParam(ConditionParam conditionParam, bool isClosed = true) { }

        // TODO
        public static ConditionParam GetConditionParam() { return default; }

        // TODO
        public static bool IsPofinEatingMode() { return default; }

        // TODO
        public static bool IsClosedPofinEating() { return default; }

        private enum PanelType : int
        {
            BasicInfo = 0,
            TrainerMemo = 1,
            Ability = 2,
            Waza = 3,
            Condition = 4,
            ContestWaza = 5,
            Ribbon = 6,
        }

        public class Param
        {
            public List<PokemonParam> pokemonParams = new List<PokemonParam>();
            public int selectIndex;
            public int selectTabIndex;
            public TrainingParam training;
            public LimitType limitType;
            public List<BoxParam> boxParams;

            public class TrainingParam
            {
                public ItemNo itemNo = ItemNo.GINNOOUKAN;
                public UnityAction onTraining;
            }

            public enum LimitType : int
            {
                None = 0,
                Battle = 1,
                BoxOtherStatus = 2,
                BoxSelect = 3,
                ZukanRegister = 4,
            }

            public class BoxParam
            {
                public int tray = -1;
                public int pos = -1;
                public bool isPrevExchangePartner;
            }
        }
    }
}