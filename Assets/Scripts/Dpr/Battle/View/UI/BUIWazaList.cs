using AK;
using Dpr.Battle.Logic;
using Dpr.MsgWindow;
using Dpr.NetworkUtils;
using Dpr.UI;
using Pml;
using Pml.WazaData;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Dpr.Battle.View.UI
{
    public sealed class BUIWazaList : BattleViewUICanvasBase, IResultable<int>
    {
        private const string WazaNameMessageLabel = "msg_ui_btl_pokewaza";
        private const string WazaDescriptionOpenMessageLabel = "msg_ui_btl_06";
        private const string WazaDescriptionCloseMessageLabel = "msg_ui_btl_07";

        [SerializeField]
        private BUIButton _wazaDescriptionButton;
        [SerializeField]
        [Header("必ず4つバインドする")]
        private BUIWazaButton[] _wazaButtons;
        [SerializeField]
        private Sprite[] _wazaTypeSprites;
        [SerializeField]
        private Sprite[] _effectBgSprites;
        [SerializeField]
        private Color _wazaTextColor = Color.black;
        [SerializeField]
        private Sprite[] _disableWazaSprites;
        [SerializeField]
        private Sprite _disableEffectBgSprite;
        [SerializeField]
        private Color _disableWazaTextColor = Color.black;
        [SerializeField]
        private TextMeshProUGUI _yButtonText;
        [SerializeField]
        private Color _ppColorNormal = Color.black;
        [SerializeField]
        private Color _ppColorWarning = Color.yellow;
        [SerializeField]
        private Color _ppColorDanger = new Color(1.0f, 0.5f, 0.3f);
        [SerializeField]
        private Color _ppColorEmpty = Color.red;

        private BTL_ACTION_PARAM_OBJ _destActionParam;
        private List<BTLV_WAZA_INFO?> _btlvWazaInfos;
        private BTL_POKEPARAM _btlPokeParam;
        private int _wazaCount = -1;
        private Dictionary<int, PrevWazaData> _prevUseWazas;
        private int _pokeIndex;

        public int Result { get; private set; }

        public override void Startup()
        {
            base.Startup();

            CurrentIndex = 0;
            _wazaDescriptionButton.SetOnSubmit(OnSubmitWazaDescription);

            for (int i=0; i<_wazaButtons.Length; i++)
            {
                var wazaButton = _wazaButtons[i];
                wazaButton.SetOnSelected(() => OnSelectedWazaButton(wazaButton));
                wazaButton.SetOnSubmit(() => OnSubmitWazaButton(wazaButton));
            }

            _btlvWazaInfos = new List<BTLV_WAZA_INFO?>();
            _prevUseWazas = new Dictionary<int, PrevWazaData>();
        }

        // TODO
        public void Initialize(BTL_POKEPARAM bpp, byte pokeIndex, BTL_ACTION_PARAM_OBJ dest) { }

        public void Remove()
        {
        	this._btlPokeParam = null;
        	this._destActionParam = null;
        }

        public override void OnUpdate(float deltaTime)
        {
            if (!IsFocus)
                return;

            if (MsgWindowManager.IsOpen)
                return;

            if (NetworkManager.IsShowApplicationErrorDialog())
                return;

            if (BtlvInput.GetPush(UIManager.ButtonA))
                OnSubmit();

            if (IsValid)
                return;

            if (BtlvInput.GetPush(UIManager.StickLDown) ||
                BtlvInput.GetRepeat(UIManager.StickLDown))
            {
                PreparaNext(true);
            }

            if (BtlvInput.GetPush(UIManager.StickLUp) ||
                BtlvInput.GetRepeat(UIManager.StickLUp))
            {
                PreparaNext(false);
            }

            if (BtlvInput.GetPush(UIManager.ButtonB))
                OnCancel();

            if (BtlvInput.GetPush(UIManager.ButtonY))
                OnSubmitWazaDescription();
        }

        // TODO
        protected override void PreparaNext(bool isForward) { }

        protected override void OnShow()
        {
            base.OnShow();
            SelectButton(_wazaButtons, CurrentIndex, false);
            BattleViewCore.Instance.UISystem.CursorFrame.SetActive(true);
        }

        protected override void OnHide()
        {
            base.OnHide();
            var wazaDesc = BattleViewCore.Instance.UISystem.WazaDescription;

            if (wazaDesc)
                wazaDesc.Hide(false, null);
        }

        // TODO
        public void SetSelect(int num) { }

        // TODO
        public void ResetSelect() { }

        // TODO
        private void OnSubmitWazaDescription() { }

        // TODO
        private void OnSelectedWazaButton(BUIWazaButton button) { }

        private void OnSubmitWazaButton(BUIWazaButton button)
        {
            _destActionParam.value.fight_pokeID = _btlPokeParam.GetID();
            _destActionParam.value.fight_targetPos = (byte)BtlPokePos.POS_NULL;
            _destActionParam.value.fight_cmd = (byte)PokeActionCategory.Fight; // Unsure if this is the right enum
            _destActionParam.value.fight_waza = (ushort)_btlPokeParam.WAZA_GetID((byte)button.Index);
            _destActionParam.value.fight_wazaInfoFlag = false;
            _destActionParam.value.fight_gFlag = false;

            Result = button.Index;
        }

        private void OnSubmit()
        {
            var wazaButton = _wazaButtons[CurrentIndex];
            var wazaInfo = wazaButton.Info.Value;

            if (WazaDataSystem.IsValid(wazaInfo.WazaNo))
            {
                if (wazaInfo.PP == 0 && wazaButton.Info.HasValue)
                {
                    BattleViewCore.Instance.UISystem.PlaySe(EVENTS.UI_COMMON_BEEP);
                }
                else
                {
                    UpdateSelectedWazaNo(_pokeIndex, _btlPokeParam.GetID(), wazaInfo.WazaNo);
                    wazaButton.Submit();
                    IsValid = true;
                }
            }
        }

        private void OnCancel()
        {
            _destActionParam.value.fight_cmd = (byte)PokeActionCategory.Null; // Unsure if this is the right enum

            Result = -1;
            IsValid = true;

            BattleViewCore.Instance.UISystem.CursorFrame.SetActive(false);
            BattleViewCore.Instance.UISystem.PlaySe(EVENTS.UI_COMMON_CANCEL);
        }

        // TODO
        private void SetYbuttonText(bool isDescriptionShow) { }

        // TODO
        public void SetInvalid() { }

        // TODO
        public void ExecuteCurrentButton() { }

        private WazaNo GetSelectedWazaNo(int pokemonIndex, int id)
        {
            if (_prevUseWazas.ContainsKey(pokemonIndex))
            {
                var prevWaza = _prevUseWazas[pokemonIndex];
                if (prevWaza.id == id)
                    return prevWaza.wazaNo;
            }

            return WazaNo.NULL;
        }

        // TODO
        private void UpdateSelectedWazaNo(int pokemonIndex, int id, WazaNo selectdWazaNo) { }

        public enum ColorForPP : int
        {
            Normal = 0,
            Warning = 1,
            Danger = 2,
            Empty = 3,
        }

        private class PrevWazaData
        {
	        public WazaNo wazaNo;
            public int id;

            public PrevWazaData(WazaNo wazaNo, int id)
            {
                this.wazaNo = wazaNo;
                this.id = id;
            }
        }
    }
}