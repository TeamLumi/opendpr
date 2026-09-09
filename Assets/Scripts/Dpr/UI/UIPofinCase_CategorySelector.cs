using UnityEngine;

namespace Dpr.UI
{
	public class UIPofinCase_CategorySelector : MonoBehaviour
	{
		[SerializeField]
		private UIPofinCase_CategoryButton[] categoryBtns;
		private Category nowCategory;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void ChangeCategoryNext() { }
		
		public Category GetCurrentCategory() {
		    return nowCategory;
		}
		
		// TODO
		private void ChangeCategory(Category category) { }

		public enum Category : int
		{
			All = 0,
			Spicy = 1,
			Dry = 2,
			Sweet = 3,
			Bitter = 4,
			Sour = 5,
		}
	}
}