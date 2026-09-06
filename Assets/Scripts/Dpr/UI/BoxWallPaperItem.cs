using Pml.PokePara;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class BoxWallPaperItem : MonoBehaviour, IUIButton
	{
		[SerializeField]
		private UIText _enabledText;
		[SerializeField]
		private UIText _disabledText;
		[SerializeField]
		private Image _mark;
		[SerializeField]
		private GameObject _body;

		private int _index;
		private RectTransform _rectTransform;

		private static Vector3 _markPosition = new Vector3(0.0f, -2.0f, 0.0f);
		private static Vector3 _iconPosition = new Vector3(116.0f, 6.0f, 0.0f);
		
		// TODO
		public string ItemText { get; }
		
		// TODO
		public void Initialize(int no) { }
		
		// TODO
		public void Initialize(int no, string itemText, bool isEnable = true) { }
		
		// TODO
		public void Initialize(int no, Sprite mark, BoxMarkColor markColor = BoxMarkColor.NONE) { }
		
		// TODO
		public void ChangeMarkColor() { }
		
		// TODO
		public void SetPokemonIcon(Sprite iconSprite) { }
		
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