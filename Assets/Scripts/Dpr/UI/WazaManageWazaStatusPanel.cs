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
		private int selectIndex;
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
		
		// TODO
		public bool MoveIndex(int value) { return default; }
		
		// TODO
		public void ResumeMoveIndex() { }
		
		// TODO
		public void SetCursorActive(bool isActive) { }
		
		public int GetSelectedIndex() {
		    return selectIndex;
		}
		
		// TODO
		public WazaNo GetSelectedWazaNo() { return default; }
		
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