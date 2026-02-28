using Pml.PokePara;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class BoxItem : MonoBehaviour
	{
		public static readonly Vector3 _selectIconOffset = new Vector3(0.0f, 24.0f, 0.0f);
		public static readonly Vector3 _moveIconOffset = new Vector3(0.0f, 56.0f, 0.0f);

		[SerializeField]
		protected PokemonIcon _root;
		[SerializeField]
		protected Image _shadow;
		[SerializeField]
		protected Image _imageSelect;
		[SerializeField]
		protected UINavigator _navigator;

		private Vector3 _swapRootPos = Vector3.zero;
		protected Param _param;
		protected bool _isItemMode;
		
		public UINavigator navigator { get => _navigator; }
		public virtual PokemonParam pokemonParam { get => _param.scrollParam.itemParams[Index].pokemonParam; }
		public virtual bool isSearchTarget { get => _param.isSearchTarget; }
		public virtual bool isForceHide { get => _param.isForceHide; }
		public virtual bool isForceSelect { get => _param.isForceSelect; }
		public virtual bool isExSelected { get => _param.isExSelected; }
		public int Index { get => _param.index; }
		
		// TODO
		private void Awake() { }
		
		// TODO
		public virtual void Setup(Param param) { }
		
		// TODO
		public virtual void Setup() { }
		
		// TODO
		public virtual void Clear() { }
		
		public virtual PokemonIcon GetSwapRoot()
		{
			return this._root;
		}
		
		// TODO
		public virtual void SetIconDefault(bool isShow = true) { }
		
		// TODO
		public void SetDefaultPosition() { }
		
		// TODO
		public virtual void Select(bool isSelect, bool isImmidiate = false) { }
		
		// TODO
		private void SetIconSelect(bool isSelect) { }
		
		// TODO
		public virtual void SetSearch(bool isSearchTarget) { }
		
		// TODO
		public virtual void SetItemState(bool isEnable) { }
		
		// TODO
		public virtual void ReturnItemInBag() { }
		
		public void SetExternalSelectIcon(bool isSelect)
		{
			GameObject.SetActive(this._imageSelect.gameObject,(isSelect ? 1 : 0) & 1,0);
		}

		public class Param
		{
			public BoxInfinityScrollItem.BaseParam scrollParam;
			public bool isSearchTarget = true;
			public bool isForceHide;
			public bool isForceSelect;
			public bool isExSelected;
			public int index = -1;
		}
	}
}