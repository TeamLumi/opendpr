using TMPro;
using UnityEngine;

namespace Dpr.SecretBase
{
	public class FilterDetailItem : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _enabledText;
		[SerializeField]
		private TextMeshProUGUI _disabledText;
		[SerializeField]
		private GameObject _body;

        public string ItemTextxt { get; private set; }

        private int _index;
		private RectTransform _rectTransform;
		
		// TODO
		public void Initialize(string itemText) { }
		
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