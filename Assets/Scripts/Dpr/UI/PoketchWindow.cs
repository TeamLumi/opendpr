using Audio;
using Pml;
using Pml.PokePara;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.UI
{
    public class PoketchWindow : UIWindow
    {
        private const float _buttonOffsetX = 140;
        private const float _buttonOffsetY = 260;
        private const float _changeButtonUnderOffset = 16;

        [SerializeField]
        private CanvasGroup _canvasGroup;
        [SerializeField]
        private RawImage _imageBg;
        [SerializeField]
        private RectTransform _root;
        [SerializeField]
        private RectTransform _rootTopShutter;
        [SerializeField]
        private RectTransform _rootBottomShutter;
        [SerializeField]
        private PoketchButton _changeButton;
        [SerializeField]
        private Image _cursor;
        [SerializeField]
        private RawImage _appBG;
        [SerializeField]
        private Image[] _bodyImages;
        [SerializeField]
        private Sprite[] _bodySprites;
        [SerializeField]
        private Image[] _numImages;
        [SerializeField]
        private Sprite[] _numSprites;
        [SerializeField]
        private List<PoketchAppBase> _poketchAppList;
        [SerializeField]
        [Tooltip("サイズ変更の時間")]
        private float _resizeDuration = 0.05f;
        [SerializeField]
        [Tooltip("切り替え時の黒幕アニメ時間")]
        private float _changeDuration = 0.1f;
        [SerializeField]
        [Tooltip("黒幕が閉まっている時間")]
        private float _closeWait = 0.3f;
        [SerializeField]
        [Tooltip("スティック押し込みで切り替え時のボタン受付延長時間")]
        private float _changeWait = 0.75f;
        [SerializeField]
        private float _smallScale = 0.4f;
        [SerializeField]
        private float _largeScale = 1.0f;
        [SerializeField]
        private Vector3 _smallPos = Vector3.zero;
        [SerializeField]
        private Vector3 _largePos = Vector3.zero;
        [SerializeField]
        [Tooltip("小さくなる時の遅延時間")]
        private float _toSmallDelay = 0.2f;
        [SerializeField]
        [Tooltip("大きくなる時の遅延時間")]
        private float _toLargeDelay;
        [SerializeField]
        [Tooltip("バックライト加算色")]
        private Color32 _lightColor = new Color32(32, 32, 32, 255);
        [SerializeField]
        [Tooltip("アプリ背景色")]
        private Color32[] _bgColors;
        [SerializeField]
        [Tooltip("カーソル移動量")]
        private float _cursolMoveValue = 8.0f;
        [SerializeField]
        [Tooltip("ポケモン鳴き声のインターバル(秒)")]
        private float _voiceWait = 0.1f;
        private UIInputButton _buttonR = new UIInputButton();
        private UIInputButton _buttonSR = new UIInputButton();
        private bool _isSizeChanging;
        private bool _isBackLight;
        private bool _isTouch;
        private bool _isSelecting;
        private PoketchButton _preButton;
        private Coroutine _appChangeCoroutine;
        private float _appCloseTime;
        private DG.Tweening.Sequence _twSeqence;
        private Coroutine _openColoutine;
        private Coroutine _closeColoutine;
        private MonsNo _voiceMonsNo;
        private AudioInstance _voiceInstance;
        private UIDatabase.SheetPokemonVoice _voiceData;
        private float _voiceTimer;
        private float _cursorMinX;
        private float _cursorMaxX;
        private float _cursorMinY;
        private float _cursorMaxY;

        public int CurrentAppIndex { get; private set; }
        public bool IsLarge { get; private set; }
        public bool IsPauseContinue { get; set; }
        public bool IsCloseOnce { get; set; }

        public int AppWidth;
        public int AppHeight;

        public PoketchAppBase CurrentApp { get => _poketchAppList[CurrentAppIndex]; }

        private float _cursorX;
        private float _cursorY;
        private TouchState _touchState;
        
        public bool IsControlPoketch { get => IsLarge || IsPauseContinue; }
        public bool IsClosingPoketch { get => _closeColoutine != null; }
        public Image Cursor { get => _cursor; }
        public float CursorX { get => _cursor.transform.position.x; }
        public float CursorY { get => _cursor.transform.position.y; }
        public float Scale { get => IsLarge ? _largeScale : _smallScale; }
        public static PoketchWindow Instance { get; private set; }

        // TODO
        public override void OnCreate() { }

        // TODO
        protected override void OnDestroy() { }

        // TODO
        public void Clean() { }

        // TODO
        public void Open(UIWindowID prevWindowId) { }

        // TODO
        private IEnumerator OpOpen(UIWindowID prevWindowId) { return null; }

        // TODO
        public void Close([Optional] UnityAction<UIWindow> onClosed_) { }

        // TODO
        private IEnumerator OpClose(UnityAction<UIWindow> onClosed_) { return null; }

        // TODO
        private void OnUpdate(float deltaTime) { }

        // TODO
        private void OnInputButton(int button, UIInputButton.State state) { }

        // TODO
        public void ChangePoketchSize([Optional, DefaultParameterValue(false)] bool notReleaseUncontrol, [Optional] UnityAction callback) { }

        // TODO
        private bool IsInRange(PoketchButton target, float posX, float posY) { return false; }

        // TODO
        private void SetCursorPosition(float posX, float posY) { }

        private void OnInputPrev(int button, UIInputButton.State state)
        {
        	SelectApp(button);
        }

        private void OnInputNext(int button, UIInputButton.State state)
        {
        	SelectApp(button,1);
        }

        // TODO
        private void SelectApp(bool isForward) { }

        // TODO
        private IEnumerator ChangeAppProc(int nextIndex) { return null; }

        // TODO
        private IEnumerator ShutterProc(bool isOpen) { return null; }

        // TODO
        private void ChangeApp(int nextIndex) { }

        // TODO
        public void SetAppColor(int index) { }

        public void SetAppBackLight()
        {
        	SetBackLight(this._isTouch);
        }

        // TODO
        public void SetBackLight(bool isEnable) { }

        // TODO
        public void PlayPokemonVoice(MonsNo monsNo, int formNo = 0, Sex monsSex = Sex.NUM, RareType rareType = RareType.NOT_RARE) { }

        // TODO
        public bool IsCursorOnDisplay() { return false; }

        // TODO
        public static void SetNumImage(ulong num, int digit, Image[] numImage, Sprite[] numSprite, int dispIndex = 0) { }

        public enum TouchState : int
        {
            None = 0,
            Touch = 1,
            Hold = 2,
            Release = 3,
            Push = 4,
        }
    }
}