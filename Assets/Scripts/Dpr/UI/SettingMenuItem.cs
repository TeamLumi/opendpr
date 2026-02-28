using DPData;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class SettingMenuItem : MonoBehaviour
	{
		[SerializeField]
		private ItemType _itemType;
		[SerializeField]
		private RectTransform _contentRoot;
		[SerializeField]
		private Image _selectBg;
		[SerializeField]
		private SelectorParam _selectorParam;
		[SerializeField]
		private WindowSelectorParam _windowSelectorParam;
		[SerializeField]
		private GaugeSelectorParam _gaugeSelectorParam;

		private UnityAction<SettingMenuItem> _onValueChanged;
		private ConfigID _configId;
		private string _descMessageLabel;
		private RectTransform _content;
		private int _selectIndex;
		private List<UIText> _texts = new List<UIText>();
		private Slider _slider;
		private UIText _sliderText;
		
		public ConfigID configId { get => _configId; }
		public string descMessageLabel { get => _descMessageLabel; }
		public int selectIndex { get => _selectIndex; }
		public int valueCount
		{
			get
			{
				switch (_itemType)
				{
					case ItemType.Selector:
						return _texts.Count;

					case ItemType.Gauge:
						return ConfigWork.MAX_VOLUME + 1;

					default:
						return (int)WINTYPE.WINTYPE_MAX;
				}
			}
		}
		public bool isSelect { get => _selectBg.enabled; }
		public ItemType itemType { get => _itemType; }
		
		// TODO
		public void Setup(ConfigID configId, int selectIndex, string descMessageLabel, UnityAction<SettingMenuItem> onValueChanged) { }
		
		// TODO
		private void SetupContent() { }
		
		// TODO
		public bool SetSelectIndex(int selectIndex, bool isEqualChecked = true, bool isCallbacked = true) { return default; }
		
		public void Select(bool enabled)
		{
			this._selectBg.enabled = (enabled ? 1 : 0) & 1;
			SetSelectIndex(this._selectIndex,0);
		}

		public enum ItemType : int
		{
			Selector = 0,
			Gauge = 1,
			WindowSelector = 2,
		}

		[Serializable]
		private class SelectorParam
		{
			public Color[] textColors;
		}

		[Serializable]
		private class WindowSelectorParam
		{
			public Image[] arrows;
			public Color[] textColors;
			public Color[] arrowColors;
		}

		[Serializable]
		private class GaugeSelectorParam
		{
			public Image gaugeBg;
			public Image gauge;
			public Image handle;
			public Color[] gaugeBgColors;
			public Color[] gaugeColors;
			public Sprite[] spriteHandles;
			public Color[] textColors;
		}
	}
}