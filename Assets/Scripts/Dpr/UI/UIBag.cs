using Dpr.Item;
using Pml.PokePara;
using Pml;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System.Runtime.InteropServices;
using Pml.Item;
using Dpr.Demo;

namespace Dpr.UI
{
    public class UIBag : UIWindow
    {
        private const string QuestionWhichUseItemMessageLabel = "SS_bag_035";
        private const string ResultCantLearnWazaMachineMessageLabel = "SS_bag_036";
        private const string ResultExistWazaMessageLabel = "SS_bag_037";
        private const string QuestionUseWazaMachine1MessageLabel = "SS_bag_038";
        private const string QuestionUseWazaMachine2MessageLabel = "SS_bag_045";
        private const string QuestionUseWazaMachine3MessageLabel = "SS_bag_047";
        private const string ResultLearnWazaMessageLabel = "SS_bag_039";
        private const string ResultUnlearnWazaMessageLabel = "SS_bag_149";
        private const string QuestionUnlernToLearnWazaMessageLabel = "SS_bag_040";
        private const string ResultUnlernToLearnWazaMessageLabel = "SS_bag_041";
        private const string ResultNotLearnWazaMessageLabel = "SS_bag_042";
        private const string QuestionUnlearnWazaMessageLabel = "SS_bag_043";
        private const string TypeSortMessageLabel = "SS_bag_077";
        private const string NameSortMessageLabel = "SS_bag_078";
        private const string NewSortMessageLabel = "SS_bag_079";
        private const string NumberSortMessageLabel = "SS_bag_080";
        private const string FavoriteSortMessageLabel = "SS_bag_081";
        private const string CancelSortMessageLabel = "SS_bag_082";
        private const string QuestionSortMessageLabel = "SS_bag_083";
        private const string TypeSortResultMessageLabel = "SS_bag_084";
        private const string NameSortResultMessageLabel = "SS_bag_085";
        private const string NumberSortResultMessageLabel = "SS_bag_086";
        private const string FavoriteSortResultMessageLabel = "SS_bag_087";
        private const string NewSortResultMessageLabel = "SS_bag_088";
        private const string RecoveryHpResultMessageLabel = "SS_bag_098";
        private const string RecoveryDeadResultMessageLabel = "SS_bag_099";
        private const string RecoveryPoisonResultMessageLabel = "SS_bag_100";
        private const string RecoveryParalyzeResultMessageLabel = "SS_bag_101";
        private const string RecoveryBurnResultMessageLabel = "SS_bag_102";
        private const string RecoveryIceResultMessageLabel = "SS_bag_103";
        private const string RecoverySleepResultMessageLabel = "SS_bag_104";
        private const string RecoveryAllSickResultMessageLabel = "SS_bag_105";
        private const string AddEffortPowerHPResultMessageLabel = "SS_bag_106";
        private const string AddEffortPowerResultMessageLabel = "SS_bag_358";
        private const string AddFriendshipAndSubEffortPowerHPResultMessageLabel = "SS_bag_107";
        private const string AddFriendshipAndSubEffortPowerResultMessageLabel = "SS_bag_359";
        private const string NotAddFriendshipAndSubEffortPowerHPResultMessageLabel = "SS_bag_108";
        private const string NotAddFriendshipAndSubEffortPowerResultMessageLabel = "SS_bag_360";
        private const string AddFriendshipAndNotSubEffortPowerHPResultMessageLabel = "SS_bag_109";
        private const string AddFriendshipAndNotSubEffortPowerResultMessageLabel = "SS_bag_361";
        private const string UsedItemMessageLabel = "SS_bag_110";
        private const string EquipItemResultMessageLabel = "SS_bag_112";
        private const string SwapItemResultMessageLabel = "SS_bag_113";
        private const string DontUseSprayItemMessageLabel = "SS_bag_111";
        private const string NoEffectUseItemResultMessageLabel = "SS_bag_115";
        private const string DontUseItemDoctorsAdviceMessageLabel = "SS_bag_337";
        private const string DontUseItemMessageLabel = "SS_bag_337";
        private const string QuestionWhichEquipItemMessageLabel = "SS_bag_119";
        private const string DontEquipItemForEggMessageLabel = "SS_bag_120";
        private const string QuestionSwapItemMessageLabel = "SS_bag_122";
        private const string QuestionRecoverWazaPPMessageLabel = "SS_bag_123";
        private const string RecoverWazaPPResultMessageLabel = "SS_bag_121";
        private const string QuestionWazaPPUpMessageLabel = "SS_bag_124";
        private const string WazaPPUpResultMessageLabel = "SS_bag_125";
        private const string DontAddItemMessageLabel = "SS_bag_126";
        private const string FormChangeResultMessageLabel = "SS_bag_146";
        private const string QuestionUseTokuseiItemMessageLabel = "SS_bag_151";
        private const string UseTokuseiItemResultMessageLabel = "SS_bag_152";
        private const string QuestionUseMintItemMessageLabel = "SS_bag_161";
        private const string UseMintItemResultMessageLabel = "SS_bag_162";
        private const string QuestionHowManyUseItemMessageLabel = "SS_bag_163";
        private const string QuestionRotomFormChangeMessageLabel = "SS_bag_175";
        private const string CantGetOffBicycleMessageLabel = "SS_bag_352";
        private const string DsPlayerOnMessageLabel = "SS_bag_353";
        private const string DsPlayerOffMessageLabel = "SS_bag_354";
        private const string PointCardMessageLabel = "SS_bag_355";
        private const int NonTargetIndex = -1;

        [SerializeField]
        private BagItemPanel bagItemPanel;
        [SerializeField]
        private PokemonParty pokemonParty;
        [SerializeField]
        private BagWazaSelectPanel wazaSelectPanel;
        [SerializeField]
        private RectTransform effectRoot;
        private readonly int _animStateIn = Animator.StringToHash("in");
        private readonly int _animStateOut = Animator.StringToHash("out");
        private BootType bootType;
        private ModeType modeType;
        private PokemonParam onlyViewPokemonParam;
        private int onlyViewPartyIndex;
        private int onlyViewBattlePokemonId = -1;
        private BattleBootParam battleBootParam;
        private Action<int> onSelectedKinomiItem;
        private Action onCompleteAutoPilot;
        private UIMsgWindowController msgWindowController;
        private PokemonParty.Param pokemonPartyParam;
        private int displayMoney = -1;
        private bool isWaitUpdate;
        private bool isWaitPokemonParty;
        private bool isKinomiContact;
        private bool isDontBuryNuts;
        private bool isAutoPilot;

        private bool isBattle { get => PlayerWork.isBattling; }
        private bool isNeedBgmDuck { get => (isBattle && modeType == ModeType.Default) || bootType == BootType.Poffine; }
        private bool canSwitchFavorite { get => !isBattle && !bagItemPanel.IsNoItem; }
        private bool canSort { get => !isBattle && !bagItemPanel.IsNoItem; }
        private bool canUseItem { get => bootType != BootType.Poffine; }
        public bool IsOpenFromBattleTeam { get; set; }

        public override void OnCreate()
        {
        	UIWindow.OnCreate();
        	var uVar1 = UnityEngine_Component__GetComponentInChildren<object>
        	                  (this);
        	this._animator = uVar1;
        	uVar1 = new UIMsgWindowController();
        	uVar1 = new UIMsgWindowController();
        	this.msgWindowController = uVar1;
        }

        // TODO
        public void Open([Optional, DefaultParameterValue(BootType.Default)] BootType bootType, [Optional, DefaultParameterValue(ModeType.Default)] ModeType modeType, [Optional] PokemonParam pokemonParam, int displayMoney = -1, bool isDontBuryNuts = false, UIWindowID prevWindowId = WINDOWID_PARENT) { }

        // TODO
        public void OpenSelectKinomi(Action<int> onSelectedKinomiItem, UIWindowID prevWindowId = WINDOWID_PARENT) { }

        // TODO
        public void OpenWazaMachineOnly(bool isContestWaza, PokemonParam pokemonParam, UIWindowID prevWindowId = WINDOWID_PARENT) { }

        // TODO
        public void OpenAutoPilot(ushort useItemNo, [Optional, DefaultParameterValue(BootType.Default)] BootType bootType, [Optional] Action onComplete, UIWindowID prevWindowId = WINDOWID_PARENT) { }

        // TODO
        public IEnumerator OpOpen(UIWindowID prevWindowId) { return null; }

        // TODO
        public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId, bool isPlayCloseSe = true) { }

        // TODO
        public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId, bool isPlayCloseSe = true) { return null; }

        // TODO
        private void OnUpdate(float deltaTime) { }

        // TODO
        private void OnUpdateDefault() { }

        // TODO
        private void OnUpdateSelectAmount() { }

        // TODO
        private void OnUpdatePokemonParty(float deltaTime) { }

        // TODO
        private void UpdateKeyGuide() { }

        // TODO
        private void SetupBagItemPanel() { }

        // TODO
        private void SetupBattleBootParam() { }

        // TODO
        private void OnChangeBagPanelSelectItem(BagItemButton bagItemButton) { }

        // TODO
        private void CreatePokemonPartyParam(int selectIndex = 0) { }

        // TODO
        private void StartSelectPokemonParty(UnityAction<PokemonPartyItem, int> onClicked) { }

        // TODO
        private void EndSelectPokemonParty() { }

        // TODO
        private void OpenContextMenu(ContextMenuID[] contextMenuIDs, Action<ContextMenuID> onSelected, Vector2 pivot, Vector3 pos, [Optional] Action onClosed, bool isNoDecideSe = false, bool isNoCancelSe = false) { }

        // TODO
        private void ShowItemContextMenu(ItemInfo item)
        {
            // TODO
            void EndUseAction() { }

            // TODO
            void OnSelected(ContextMenuID menuID) { }

            // TODO
            void UpdateHp() { }
        }

        // TODO
        private void SwitchSelectedItemFavorite() { }

        // TODO
        private void ShowWazaOboeWindow(PokemonParam pokemonParam, WazaNo learnWazaNo, Action<WazaNo, WazaNo> resultCallBack) { }

        private void StartSortItems()
        {
        	this.bagItemPanel.SetRemoveNewEnable(0);
        	var uVar1 = new Action(this);
        	this.msgWindowController.OpenMsgWindow(0,_StringLiteral_11687,1,0,uVar1,0);
        }

        // TODO
        private void SortItems(ItemInfo.SortType sortType) { }

        // TODO
        private void ShowSortResultMessage(ItemInfo.SortType sortType) { }

        // TODO
        private void OnPokemonPartyClickedToUseItem(PokemonPartyItem pokemonPartyItem, int index)
        {
            // TODO
            void OnResult(Demo_Evolve.Result result) { }

            // TODO
            void DecideAction(int amount) { }

            // TODO
            void EvolveResult(Demo_Evolve.Result result) { }
        }

        // TODO
        private void UseWazaMachine(PokemonParam pokeParam, ItemInfo itemInfo) { }

        // TODO
        private void UseApplicationItem(PokemonParam pokeParam, ItemInfo itemInfo) { }

        // TODO
        private void UseTokuseiItem(PokemonParam pokeParam, ItemInfo itemInfo, Func<PokemonParam, bool> useItemFunc) { }

        // TODO
        private bool CheckAndUseRecoveryItem(PokemonParam pokeParam, ItemInfo itemInfo, bool isUse, out RecoveryResultType resultType)
        {
            // TODO
            bool RecoverySick(Sick sick) { return default; }

            // TODO
            void SetRecoverySickResult(ref RecoveryResultType targetResultType, RecoveryResultType setResultType) { }

            resultType = RecoveryResultType.None;
            return false;
        }

        // TODO
        private string GetRecoveryResultLabelName(RecoveryResultType recoveryResult) { return null; }

        // TODO
        private float GetRecoverHpRate(ItemData.HpRecoverType recoveryHpValue) { return 0.0f; }

        // TODO
        private bool CheckExpItem(ItemInfo itemInfo, out PowerID powerID, out int addExpValue)
        {
            powerID = PowerID.HP;
            addExpValue = 0;
            return false;
        }

        // TODO
        private Action GetUseItemToNothingAction() { return null; }

        // TODO
        private bool CanUseWazaMachine(MonsNo monsNo, ushort formNo, ushort machineNo) { return false; }

        // TODO
        private void EndUseItemAction(PokemonParam pokemonParam, ItemInfo itemInfo, int useCount = 1, bool isForceEnd = false) { }

        // TODO
        private void UseFormChangeItem(PokemonPartyItem pokemonPartyItem, ItemInfo itemInfo) { }

        // TODO
        private void ShowFormChangeResult(PokemonParam pokemonParam)
        {
            // TODO
            void AddWaza() { }
        }

        // TODO
        private void OnBattleBootPokemonPartyClickedToUseItem(PokemonPartyItem pokemonPartyItem, int index)
        {
            // TODO
            void UseItem(bool isUsable, int subSelectIndex) { }
        }

        // TODO
        private void OnPokemonPartyClickedToEquipItem(PokemonPartyItem pokemonPartyItem, int index) { }

        // TODO
        private void EndItemEquip(PokemonPartyItem pokemonPartyItem) { }

        // TODO
        public IEnumerator ResetBallTab() { return null; }

        // TODO
        private IEnumerator StartAutoPilot(ItemInfo useItem) { return null; }

        public enum BootType : int
        {
            Default = 0,
            Pokemon = 1,
            Status = 2,
            Poffine = 3,
            Battle = 4,
            BattleAutoPilot = 5,
            WazaMachine = 6,
            Important = 7,
            Length = 8,
        }

        public enum ModeType : int
        {
            Default = 0,
            Recovery = 1,
            Equip = 2,
            EquipOnly = 3,
        }

        private enum RecoveryResultType : int
        {
            None = 0,
            RecoveryPoison = 1,
            RecoveryBurn = 2,
            RecoveryIce = 3,
            RecoveryPanic = 4,
            RecoveryParalyze = 5,
            RecoverySleep = 6,
            RecoveryMeroMero = 7,
            RecoveryAllSick = 8,
            RecoveryHp = 9,
            RecoveryDead = 10,
        }

        private struct BattleBootParam
        {
            public int TopMemberIndex;
            public bool IsTrainerBattle;
            public bool isDouble;
            public bool[] SasiosaeFlags;
        }
    }
}