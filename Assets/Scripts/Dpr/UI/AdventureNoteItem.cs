using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.UI
{
	public class AdventureNoteItem : MonoBehaviour, IUIButton
	{
		[SerializeField]
		private UIText _title;
		[SerializeField]
		private RectTransform _cursorRoot;
		[SerializeField]
		private Image _newIcon;
		[SerializeField]
		private Image _body;
		[SerializeField]
		private Sprite[] _spriteBodys;
		[SerializeField]
		private Color[] _colors;
		private Param _param;
		private int _index;
		
		public Param param { get => _param; }
		public int index { get => _index; }
		public RectTransform cursorRoot { get => _cursorRoot; }
		
		// TODO
		public void Setup(Param param, int pageIndex = 0) { }
		
		// TODO
		public virtual bool GetActive() { return default; }
		
		// TODO
		public virtual void SetActive(bool isActive) { }
		
		public virtual int GetIndex()
		{
			return this._index;
		}
		
		public virtual void SetIndex(int index)
		{
			this._index = index;
		}
		
		// TODO
		public virtual RectTransform GetRectTransform() { return default; }
		
		// TODO
		public virtual void Select() { }
		
		// TODO
		public virtual void UnSelect() { }
		
		// TODO
		public void SetNew(Param.StateNew stateNew) { }

		public class Param
		{
			public AdventureNoteID noteId = (AdventureNoteID)(-1);
			public List<AdventureNoteData.SheetData> datas;
			public StateNew stateNew;

            public enum StateNew : int
			{
				Show = 0,
				Hide = 1,
			}
		}
	}
}