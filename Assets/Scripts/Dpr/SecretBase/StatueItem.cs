using Dpr.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.SecretBase
{
	public class StatueItem : SelectItemBase<StatueEffectData>
	{
		[SerializeField]
		private Image icon;
		[SerializeField]
		private Image placementSize;
		[SerializeField]
		private Image pokeTypeIcon1;
		[SerializeField]
		private Image pokeTypeIcon2;
		[SerializeField]
		private UIText num;
		[SerializeField]
		private GameObject disable;
		[SerializeField]
		private StatueSelectWindow selectWindow;
		[SerializeField]
		private Image rareIcon;
		[SerializeField]
		private Image legendIcon;

		private bool isLoading;
		private bool isDisable;
		private bool isFilterd;
		
		// TODO
		public int Filter(int type1, int type2, int size, int category) { return default; }
		
		// TODO
		public override void SetData(StatueEffectData statueData) { }
		
		// TODO
		public void UpdateData() { }
		
		// TODO
		public void SetDisable(bool isDisable) { }
		
		// TODO
		public void SetDisableForce(bool isDisable) { }
		
		public bool IsDisable()
		{
			return this.isDisable;
		}
	}
}