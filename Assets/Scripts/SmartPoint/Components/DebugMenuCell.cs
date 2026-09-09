using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SmartPoint.Components
{
	public class DebugMenuCell : LayoutCellObserver, IMoveHandler, IEventSystemHandler, IScrollHandler
	{
		private static DebugMenuCell _currentSelected;
		private static DebugMenuCell _previousSelected;
		private static int _lastDPadH;
		private static int _lastDPadV;
		public LayoutScrollView.Cell _cell;
		public TextMeshProUGUI _contentText;
		public Button _button;
		public Slider _slider;
		public TextMeshProUGUI _valueText;
		
		// TODO
		public void OnScroll(PointerEventData eventData) { }
		
		// TODO
		public override Vector2 sizeDelta { get; }
		
		// TODO
		public override void OnSelect(BaseEventData eventData) { }
		
		// TODO
		public override void OnUpdate(float deltaTime) { }
		
		// TODO
		public void UpdateInformation() { }
		
		// TODO
		public void OnMove(AxisEventData axisEventData) { }
		
		// TODO
		private static void ChangedControllerParameter(DebugMenuCell observer, Vector2 moveVector, int scale) { }
		
		public override bool OnRebuildLayout() {
		    return true;
		}
		
		// TODO
		public void OnClick() { }
		
		// TODO
		public void OnSliderValueChanged(float value) { }
		
		// TODO
		public override bool IsReady() { return default; }
		
		// TODO
		public override void OnClose() { }

		public enum Controller : int
		{
			Text = 0,
			SubMenu = 1,
			Slider = 2,
			Selector = 3,
			List = 4,
			Checkbox = 5,
		}

		public delegate int InputIntegerDelegate();
		public delegate float InputFloatDelegate();
		public delegate void OutputIntegerDelegate(int value);
		public delegate void OutputFloatDelegate(float value);
		public delegate string[] InputStringArrayDelegate();
		public delegate string UpdateTextDelegate(int value);
		public delegate string UpdateInformationDelegate(int value = 0);
		public delegate void Click([Optional] object reference);
		public delegate void SelectedIndexChanged(int selected);

		public class Item
		{
			public Controller controllerType;
			public string text;
			public string[] values;
			public int selected;
			public InputFloatDelegate inputFloatValue;
			public InputIntegerDelegate inputIntegerValue;
			public OutputFloatDelegate outputFloatValue;
			public OutputIntegerDelegate outputIntegerValue;
			public InputStringArrayDelegate inputStringArrayValue;
			public float minValue;
			public float maxValue;
			public int low;
			public int high;
			public int decimals;
			public Click onClick;
			public SelectedIndexChanged onSelectedIndexChanged;
			public object reference;
			public UpdateTextDelegate updateText;
			public UpdateInformationDelegate updateInformation;
			
			public Item(string text, Click onClick, object reference, UpdateInformationDelegate updateInformation, bool isChild = false)
			{
				this.onClick = onClick;
				this.reference = reference;
				this.text = text;

				if (isChild)
                    this.controllerType = Controller.SubMenu;

				this.updateInformation = updateInformation;
			}
			
			public Item(string text, InputFloatDelegate input, OutputFloatDelegate output, float minValue, float maxValue, int decimals)
			{
                this.controllerType = Controller.Slider;
                this.inputFloatValue = input;
                this.outputFloatValue = output;
				this.minValue = minValue;
				this.maxValue = maxValue;
				this.decimals = decimals;
				this.text = text;
                this.updateText = null;
                this.updateInformation = null;
			}
			
			public Item(string text, SelectedIndexChanged onSelect, InputIntegerDelegate selected, string[] values, Click onClick, UpdateInformationDelegate updateInformation)
			{
                this.controllerType = Controller.List;
                this.onSelectedIndexChanged = onSelect;
				this.onClick = onClick;
				this.inputStringArrayValue = null;
                this.values = values;
				this.inputIntegerValue = selected;
				this.selected = 0;
                this.text = text;
                this.updateText = null;
				this.updateInformation = updateInformation;
            }
			
			public Item(string text, SelectedIndexChanged onSelect, InputIntegerDelegate selected, InputStringArrayDelegate inputList, Click onClick, UpdateInformationDelegate updateInformation)
			{
                this.controllerType = Controller.List;
                this.onSelectedIndexChanged = onSelect;
                this.onClick = onClick;
                this.inputStringArrayValue = inputList;
                this.values = null;
                this.inputIntegerValue = selected;
                this.selected = 0;
                this.text = text;
                this.updateText = null;
                this.updateInformation = updateInformation;
            }
			
			public Item(string text, InputIntegerDelegate input, OutputIntegerDelegate output, int low, int high, Click onClick, UpdateTextDelegate updateText, UpdateInformationDelegate updateInformation)
			{
                this.controllerType = Controller.Selector;
                this.onClick = onClick;
                this.inputIntegerValue = input;
                this.outputIntegerValue = output;
                this.low = low;
				this.high = high;
				this.selected = 0;
                this.text = text;
				this.updateText = updateText;
				this.updateInformation = updateInformation;
            }
			
			// TODO
			public bool SetListElements(string[] newValues) { return default; }
			
			// TODO
			public void SetClickDelegate(Click newOnClick) { }
		}
	}
}