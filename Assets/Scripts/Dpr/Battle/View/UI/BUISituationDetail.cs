using Dpr.Battle.Logic;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Battle.View.UI
{
	public class BUISituationDetail : BattleViewUICanvasBase
	{
		[SerializeField]
		private List<BUIButton> _lrButtons;
		[SerializeField]
		private RectTransform _cursorBase;
		[SerializeField]
		private Image _pokeImage;
		[SerializeField]
		private TextMeshProUGUI _lvText;
		[SerializeField]
		private TextMeshProUGUI _lvValue;
        [SerializeField]
        private Image _genderImage;
        [SerializeField]
        private TextMeshProUGUI _nameText;
        [SerializeField]
        private Slider _expSlider;
        [SerializeField]
        private TextMeshProUGUI _hpText;
        [SerializeField]
        private List<BUISituationDescriptionButton> _itemButtons;
        [SerializeField]
        private ScrollRect _scrollRect;
        [SerializeField]
        private BUISituationDescriptionButton _itemButtonPrefab;
        [SerializeField]
        private Image[] _blankItems;
        [SerializeField]
        private VerticalLayoutGroup _verticalLayout;
        [SerializeField]
        private GameObject _descriptionPanel;
        [SerializeField]
        private TextMeshProUGUI _descriptionText;
        [SerializeField]
        private BUISituationParam[] _params;
        [SerializeField]
        private GameObject _trainerPanel;
        [SerializeField]
        private TextMeshProUGUI _trainerName;

		private int _pokeIndex;
		private List<BTL_POKEPARAM> _pokeList;
		private List<string> _trainerNames;
		private List<Image> _icons;
		private readonly (string msgID, BTL_POKEPARAM.ValueID valueID)[] _paramIDs = new (string, BTL_POKEPARAM.ValueID)[]
		{
			("msg_ui_btl_kougeki",  BTL_POKEPARAM.ValueID.BPP_ATTACK_RANK),
			("msg_ui_btl_bougyo",   BTL_POKEPARAM.ValueID.BPP_DEFENCE_RANK),
			("msg_ui_btl_tokukou",  BTL_POKEPARAM.ValueID.BPP_SP_ATTACK_RANK),
			("msg_ui_btl_tokubou",  BTL_POKEPARAM.ValueID.BPP_SP_DEFENCE_RANK),
			("msg_ui_btl_subayasa", BTL_POKEPARAM.ValueID.BPP_AGILITY_RANK),
			("msg_ui_btl_meichu",   BTL_POKEPARAM.ValueID.BPP_HIT_RATIO),
			("msg_ui_btl_kaihi",    BTL_POKEPARAM.ValueID.BPP_AVOID_RATIO),
		};
		private List<(string name, string content, string description)> _statusTexts = new List<(string, string, string)>();

		private const string BTL_STATE_HEADER = "BTR_STATE_";
		private const string BTL_STATE_NAME_FOOTER = "_01";
		private const string BTL_STATE_DSCRIPTION_FOOTER = "_02";

		private readonly Dictionary<EffectType, string> _fieldIDs = new Dictionary<EffectType, string>()
		{
			{ EffectType.EFF_TRICKROOM,  "08" },
			{ EffectType.EFF_JURYOKU,    "29" },
			{ EffectType.EFF_FUIN,       "46" },
			{ EffectType.EFF_WONDERROOM, "10" },
			{ EffectType.EFF_MAGICROOM,  "09" },
			{ EffectType.EFF_FAIRY_LOCK, "65" },
		};
		private readonly Dictionary<BtlWeather, string> _weatherIDs = new Dictionary<BtlWeather, string>()
        {
            { BtlWeather.BTL_WEATHER_SHINE, "01" },
            { BtlWeather.BTL_WEATHER_RAIN,  "02" },
            { BtlWeather.BTL_WEATHER_SNOW,  "04" },
            { BtlWeather.BTL_WEATHER_SAND,  "03" },
            { BtlWeather.BTL_WEATHER_STORM, "70" },
        };
		private readonly Dictionary<BtlGround, string> _groundIDs = new Dictionary<BtlGround, string>()
		{
			{ BtlGround.BTL_GROUND_PHYCHO, "72" },
		};
		private readonly Dictionary<BtlSideEffect, string> _sideIDs = new Dictionary<BtlSideEffect, string>()
		{
			{ BtlSideEffect.BTL_SIDEEFF_REFLECTOR,     "45" },
			{ BtlSideEffect.BTL_SIDEEFF_HIKARINOKABE,  "44" },
			{ BtlSideEffect.BTL_SIDEEFF_SINPINOMAMORI, "31" },
			{ BtlSideEffect.BTL_SIDEEFF_SIROIKIRI,     "30" },
			{ BtlSideEffect.BTL_SIDEEFF_OIKAZE,        "19" },
			{ BtlSideEffect.BTL_SIDEEFF_OMAJINAI,      "20" },
			{ BtlSideEffect.BTL_SIDEEFF_MAKIBISI,      "48" },
			{ BtlSideEffect.BTL_SIDEEFF_DOKUBISI,      "37" },
			{ BtlSideEffect.BTL_SIDEEFF_STEALTHROCK,   "32" },
			{ BtlSideEffect.BTL_SIDEEFF_RAINBOW,       "66" },
			{ BtlSideEffect.BTL_SIDEEFF_BURNING,       "68" },
			{ BtlSideEffect.BTL_SIDEEFF_MOOR,          "67" },
			{ BtlSideEffect.BTL_SIDEEFF_NEBANEBANET,   "40" },
			{ BtlSideEffect.BTL_SIDEEFF_AURORAVEIL,    "74" },
		};
		
		// TODO
		public void Initialize(List<BTL_POKEPARAM> pokeList, List<string> trainerNames, List<Image> icons, int index) { }
		
		// TODO
		private void Initialize() { }
		
		public override void UnInitialize()
		{
			this._cachedRectTransform = 0;
			this._canvasGroup = 0;
			this._onShowComplete = 0;
			this._onHideComplete = 0;
		}
		
		// TODO
		public override void OnUpdate(float deltaTime) { }
		
		// TODO
		protected override void PreparaNext(bool isForward) { }
		
		// TODO
		protected override void OnShow() { }
		
		// TODO
		protected override void OnHide() { }
		
		// TODO
		private void SetPokeStatus(BTL_POKEPARAM btlParam, int index) { }
		
		// TODO
		private int SetFieldStatus() { return default; }
		
		// TODO
		private void SelectButton(bool isPlayse = true) { }
		
		// TODO
		private void OnChangePoke(bool isForward) { }
		
		// TODO
		private void ResetStatusButtons() { }
		
		// TODO
		private void OnCancel() { }

		private enum BattleEffectIndex : int
		{
			TOKUSEI = 0,
			ITEM = 1,
			STATUS_TOP = 2,
		}
	}
}