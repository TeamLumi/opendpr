using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class Capsule2DGridCell : MonoBehaviour
	{
		[SerializeField]
		private SealIcon sealIcon;
		[SerializeField]
		private Image cellImage;
		[SerializeField]
		private RectTransform gridRectTransform;

		private Vector3 sealPosition;
		private Color clearColor = Color.clear;
		private Color affixedSealColor = Color.clear;

		public Vector2 GridPosition { get; private set; }
		public int AffixSealId { get; private set; }
		public int SealId { get; private set; }
		public bool IsSetSeal { get; private set; }
		
		// TODO
		public void Initialize(int x, int y) { }
		
		// TODO
		public void Setup(bool isFront, Color clear, Color affixed) { }
		
		public RectTransform GetRectTransform()
		{
			return this.gridRectTransform;
		}
		
		// TODO
		public void SetAffixSeal(int affixSealId, int sealId) { }
		
		// TODO
		public void ClearAffixSeal() { }
		
		// TODO
		public void ShowAffixSeal() { }
		
		// TODO
		public void HideAffixSeal() { }
		
		public Vector3 GetSealPosition()
		{
			return this.sealPosition;
		}
		
		public Vector3 GetPosition()
		{
			this.gridRectTransform.position;
			return null;
		}
		
		// TODO
		private void SetClearColor() { }
		
		// TODO
		private void SetAffixedSealColor() { }
	}
}