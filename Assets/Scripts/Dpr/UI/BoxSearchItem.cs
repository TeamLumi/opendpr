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
		
		// TODO
		public void SetSelect(bool isEnable) { }
		
		public int GetIndex() {
		    return _index;
		}
		
		public void SetIndex(int index) {
		    _index = index;
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