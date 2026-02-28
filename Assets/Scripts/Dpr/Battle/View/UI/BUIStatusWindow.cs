using Dpr.Battle.Logic;
using Dpr.Battle.View.Systems;
using Dpr.UI;
using Pml;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Battle.View.UI
{
    public class BUIStatusWindow : BattleViewUICanvasBase
    {
        [SerializeField]
        private GameObject _pokemonPlate;
        [SerializeField]
        private Image _windowImage;
        [SerializeField]
        private UIText _nameText;
        [SerializeField]
        private Image _sexImage;
        [SerializeField]
        private UIText _lvText;
        [SerializeField]
        private UIText _lvValueText;
        [SerializeField]
        private Image _hpBG;
        [SerializeField]
        private HpBar _hpBar;
        [SerializeField]
        private Slider _expSlider;
        [SerializeField]
        private UIText _hpText;
        [SerializeField]
        private PokemonSick _condPanel;
        [SerializeField]
        private Image _captureImage;
        [SerializeField]
        private GameObject _ballBar;
        [SerializeField]
        private Image[] _pokeBallList;

        public bool DoDisplay { get; private set; }

        private uint _currentHP;
        private uint _maxHP;
        private byte _currentLevel;
        private byte _pokeID;
        private bool _isPlayer;
        private bool _needHpApply;
        private bool _enableBallBar;
        private bool _isTag;
        private float _pokePlateYpos;
        private Vector2 _originalSize = Vector2.zero;
        private BattleViewSystem.BattleViewSide _side;
        private Sprite[] _ballStateSprites;
        private bool _isInitialized;
        private bool _isSetup;
        private bool _isCurrentUp;
        private const float _singleOffsetX = 30.0f;
        private const float _actOffsetY = 10.0f;
        private const float _ballBarBaseWidth = 168.0f;
        private const float _ballBarHalfWidth = 114.0f;
        private const float _hpDuration = 0.7f;

        public bool IsHpBarPlaying { get => _hpBar.IsAnimation; }
        public GameObject BallBarObject { get => _ballBar; }
        public bool isInitialized { get => _isInitialized; }
        public bool isReservationClose { get; set; }
        public bool isReservationOpen { get; set; }

        // TODO
        public override void OnUpdate(float deltaTime) { }

        // TODO
        protected override void OnShow() { }

        // TODO
        public HpStatus CurrentHpStatus() { return default; }

        // TODO
        public override void Startup() { }

        // TODO
        public override void Reset() { }

        // TODO
        public void Initialize(BtlvPos pos, BTL_POKEPARAM btlParam, byte clientID, [Optional] BTL_PARTY party, [Optional] Sprite[] ballSprites, bool isTrainerBattle = true) { }

        public override void UnInitialize()
        {
        	this._cachedRectTransform = 0;
        	this._canvasGroup = 0;
        	this._onShowComplete = 0;
        	this._onHideComplete = 0;
        }

        // TODO
        private void InitBallBar(bool isShowBallBar) { }

        // TODO
        public void ShowBallBar(bool forceHide) { }

        // TODO
        public void SetBallBar(BTL_PARTY party) { }

        // TODO
        private bool IsEnableBallBar(BtlvPos pos, bool isTrainerBattle) { return false; }

        // TODO
        public void Apply(BTL_PARTY party, BTL_POKEPARAM param, bool isImmediate = false, bool isUpPosition = false) { }

        // TODO
        public void SetCurrentPokemonStatus(bool isUpPosition = false) { }

        // TODO
        public void SetHPDuration(float duration) { }

        // TODO
        private void UpdateHPText(int value) { }

        // TODO
        private void SetName(uint pokeID) { }

        // TODO
        private void SetSexIcon(Sex sex) { }

        // TODO
        private void SetPrams(BTL_POKEPARAM btlParam, bool isForced = false) { }
    }
}