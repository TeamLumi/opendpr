using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class BoxSearchItem : MonoBehaviour, IUIButton
	{
		[SerializeField]
		private UIText _enabledTitle;
		[SerializeField]
		private UIText _enabledText;
		[SerializeField]
		private UIText _disabledTitle;
		[SerializeField]
		private UIText _disabledText;
		[SerializeField]
		private GameObject _mark;
		[SerializeField]
		private Image[] _markImages;
		[SerializeField]
		private GameObject _body;
		private int _index;
		private RectTransform _rectTransform;
		
		public Image[] MarkImages { get => _markImages; }
		
		// TODO
		public void Initialize(int no, string selectItemText) { }
		
		// TODO
		public void SetMark(int data) { }
		
		// TODO
		public void ResetStatus() { }
		
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