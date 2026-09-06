using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.SecretBase
{
	public class FillterTopItem : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _enabledTitle;
		[SerializeField]
		private TextMeshProUGUI _enabledText;
		[SerializeField]
		private TextMeshProUGUI _disabledTitle;
		[SerializeField]
		private TextMeshProUGUI _disabledText;
		[SerializeField]
		private Image _enabledMark;
		[SerializeField]
		private Image _disabledMark;
		[SerializeField]
		private GameObject _body;

		private int _index;
		private RectTransform _rectTransform;
		
		// TODO
		public void Initialize(string titleText, string text) { }
		
		// TODO
		public void SetText(string text) { }
		
		// TODO
		public void SetSelect(bool isEnable) { }
		
		public int GetIndex() {
		    return _index;
		}
		
		public void SetIndex(int index) {
		    this._index = index;
		}
		
		// TODO
		public RectTransform GetRectTransform() { return default; }
		
		// TODO
		public bool GetActive() { return default; }
		
		// TODO
		public void SetActive(bool isActive) { }
		
		// TODO
		public void Select() { }
		
		// TODO
		public void UnSelect() { }
	}
}