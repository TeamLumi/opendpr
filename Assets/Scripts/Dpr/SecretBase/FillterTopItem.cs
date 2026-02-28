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
		
		public void SetSelect(bool isEnable)
		{
			this._body.SetActive((isEnable ? 1 : 0) & 1);
		}
		
		public int GetIndex()
		{
			return this._index;
		}
		
		public void SetIndex(int index)
		{
			this._index = index;
		}
		
		// TODO
		public RectTransform GetRectTransform() { return default; }
		
		// TODO
		public bool GetActive() { return default; }
		
		// TODO
		public void SetActive(bool isActive) { }
		
		public void Select()
		{
			this._body.SetActive(1);
		}
		
		public void UnSelect()
		{
			this._body.SetActive(0);
		}
	}
}