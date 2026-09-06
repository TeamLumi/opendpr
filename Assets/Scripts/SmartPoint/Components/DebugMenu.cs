using SmartPoint.AssetAssistant;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SmartPoint.Components
{
    public class DebugMenu : SingletonMonoBehaviour<DebugMenu>
    {
        [SerializeField]
        private GameObject template;
        [SerializeField]
        private RectTransform informationWindow;
        [SerializeField]
        private Canvas topCanvas;
        [SerializeField]
        private CanvasGroup topCanvasGroup;
        [SerializeField]
        private TextMeshProUGUI informationText;
        [SerializeField]
        private TextMeshProUGUI _caption;
        public static EventCallback onVisibleChanged;
        public static EventCallback onActiveChange;
        public static TryCallback tryOpenDelegate;
        private Image _image;
        public bool _isOpaque;
        private static MenuInstance _globalMenu;
        private static MenuInstance _rootMenu;
        private static MenuInstance _currentMenu;
        private static MenuInstance _nextMenu;

        // TODO
        public bool IsOpaque { get; set; }

        // TODO
        public void OnEnable() { }

        // TODO
        public void OnDisable() { }

        // TODO
        public bool GetActive() { return false; }

        // TODO
        public void SetActive(bool value) { }

        // TODO
        public void SetVisibled(bool value) { }

        // TODO
        public static bool visible { get; set; }

        // TODO
        public static MenuInstance Create(string caption, [Optional] MenuInstance parent) { return null; }

        // TODO
        public static bool GetInformationWindowEnable() { return false; }

        // TODO
        public static void ShowInformationWindow(bool show) { }

        // TODO
        public static void SetInformationText(string text) { }

        // TODO
        public static void SetRoot(MenuInstance menuInstance) { }

        // TODO
        public static MenuInstance GetRoot() { return null; }

        // TODO
        protected override bool Awake() { return false; }

        // TODO
        private void Start() { }

        // TODO
        private void OnDestroy() { }

        // TODO
        public static MenuInstance GetCurrentMenu() { return null; }

        // TODO
        public static void SetCurrentMenu(MenuInstance currentMenu) { }

        // TODO
        private static void OnUpdate(float deltaTime) { }

        // TODO
        public static void GoBack() { }

        public delegate void EventCallback(bool visibled);
        public delegate bool TryCallback();

        public class MenuInstance
        {
            // TODO
            public MenuInstance(string caption, GameObject gameObject, LayoutScrollView scrollView) { }

            public string caption { get; set; }
            public LayoutScrollView scrollView { get; }
            public List<LayoutScrollView.Cell> cells { get; }
            public bool visible { get; set; }

            // TODO
            public LayoutScrollView.Cell AddMenu(MenuInstance subMenu) { return default; }

            // TODO
            public LayoutScrollView.Cell AddItem(string text, DebugMenuCell.Click callback, object reference, [Optional] DebugMenuCell.UpdateInformationDelegate updateInformation) { return default; }

            // TODO
            public LayoutScrollView.Cell AddSlider(string text, DebugMenuCell.InputFloatDelegate input, DebugMenuCell.OutputFloatDelegate output, float minValue, float maxValue) { return default; }

            // TODO
            public LayoutScrollView.Cell AddSpinner(string text, DebugMenuCell.InputIntegerDelegate input, DebugMenuCell.OutputIntegerDelegate output, int low, int high, [Optional] DebugMenuCell.Click onClick, [Optional] DebugMenuCell.UpdateTextDelegate updateText, [Optional] DebugMenuCell.UpdateInformationDelegate updateInformation) { return default; }

            // TODO
            public LayoutScrollView.Cell AddSelector(string text, DebugMenuCell.SelectedIndexChanged onSelect, DebugMenuCell.InputIntegerDelegate selected, string[] values, [Optional] DebugMenuCell.Click onClick, [Optional] DebugMenuCell.UpdateInformationDelegate updateInformation) { return default; }

            // TODO
            public LayoutScrollView.Cell AddSelector(string text, DebugMenuCell.SelectedIndexChanged onSelect, DebugMenuCell.InputIntegerDelegate selected, DebugMenuCell.InputStringArrayDelegate inputList, [Optional] DebugMenuCell.Click onClick, [Optional] DebugMenuCell.UpdateInformationDelegate updateInformation) { return default; }

            // TODO
            public LayoutScrollView.Cell AddItem(MenuInstance subMenu) { return default; }

            // TODO
            public LayoutScrollView.Cell AddItem(string text, DebugMenuCell.InputFloatDelegate input, DebugMenuCell.OutputFloatDelegate output, float minValue, float maxValue) { return default; }

            // TODO
            public LayoutScrollView.Cell AddItem(string text, DebugMenuCell.InputIntegerDelegate input, DebugMenuCell.OutputIntegerDelegate output, int low, int high, [Optional] DebugMenuCell.Click onClick, [Optional] DebugMenuCell.UpdateTextDelegate updateText, [Optional] DebugMenuCell.UpdateInformationDelegate updateInformation) { return default; }

            // TODO
            public void Remove(LayoutScrollView.Cell cell, bool remove = true) { }

            // TODO
            public void RemoveByReference(object reference) { }

            // TODO
            public void Previous() { }

            // TODO
            public void Next() { }

            // TODO
            public LayoutScrollView.Cell GetCurrentCell() { return default; }

            // TODO
            public void SetCurrentIndex(int index) { }

            // TODO
            public void SetCurrentCell(LayoutScrollView.Cell cell) { }

            // TODO
            public DebugMenuCell.Item GetCurrentItem() { return default; }

            // TODO
            public void Update(bool reselect = true) { }

            // TODO
            public void Reload() { }

            public MenuInstance GetParent() {
                return _parent;
            }

            // TODO
            private LayoutScrollView.Cell AddChild(DebugMenuCell.Item item) { return default; }

            public LayoutScrollView.Cell ownerCell { get; set; }

            private string _caption;
            private LayoutScrollView _scrollView;
            private GameObject _gameObject;
            private int _currentIndex;
            private MenuInstance _parent;
            private Canvas _canvas;
            private CanvasGroup _canvasGroup;
            private LayoutGroup _layoutGroup;
            private List<LayoutScrollView.Cell> _cells;
        }
    }
}