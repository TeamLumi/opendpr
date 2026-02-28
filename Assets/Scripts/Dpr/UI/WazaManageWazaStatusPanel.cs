using Pml;
using Pml.PokePara;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class WazaManageWazaStatusPanel : PokemonStatusPanel
	{
		[SerializeField]
		private UIScrollView wazaScrollView;
		[SerializeField]
		private Cursor cursor;
		[SerializeField]
		private DetailParam detail;
		[SerializeField]
		private bool isContestPanel;

		private WazaNo[] detailWazaNos;
		internal int selectIndex;
		private int newWazaIndex = -1;
		private UIInputController inputController = new UIInputController();
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void Setup(PokemonParam pokemonParam, WazaNo[] wazaNos, int newWazaIndex = -1) { }
		
		// TODO
		public void UpdateSelect(float deltaTime, bool isPlaySound = true) { }
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
		
		public bool MoveIndex(int value)
		{
			this.wazaScrollView.MoveSelect(value);
			return false;
		}
		
		public void ResumeMoveIndex()
		{
			this.wazaScrollView.ResumeMoveSelect();
		}
		
		public void SetCursorActive(bool isActive)
		{
			this.cursor.SetActive((isActive ? 1 : 0) & 1);
		}
		
		public int GetSelectedIndex()
		{
			return this.selectIndex;
		}
		
		public unsafe WazaNo GetSelectedWazaNo()
		{
			if (this.selectIndex < this.detailWazaNos.Length) {
			  return *(uint *)
			          (this.detailWazaNos + (int)this.selectIndex * 4 + 0x20);
			}
			return (WazaNo)0;
		}
		
		// TODO
		private void SetupDetail(WazaNo wazaNo) { }

		[Serializable]
		private class DetailParam
		{
			public Image category;
			public UIText power;
			public UIText hitRate;
			public UIText description;
			public RectTransform contents;
			public PokemonStatusContestWazaAppealItem prefab;
		}
	}
}