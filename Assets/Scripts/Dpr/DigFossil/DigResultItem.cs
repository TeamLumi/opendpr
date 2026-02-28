using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.DigFossil
{
	public class DigResultItem : MonoBehaviour, IDigResultItem
	{
		[SerializeField]
		private Image image;
		private Tween tweenHandler;
		
		public int LabelID { get; private set; }
		public int UgItemId { get; private set; }
		
		// TODO
		public void Initialize(Sprite sprite, DigMasterDataManager.DepositItemData data) { }
		
		// TODO
		public void Show() { }
		
		public void Hide()
		{
			GameObject.SetActive(this.image.gameObject,0,0);
		}
		
		public DigResultItem()
		{
			// Empty, declared explicitly
		}
		
		GameObject IDigResultItem.gameObject { get => gameObject; }
	}
}