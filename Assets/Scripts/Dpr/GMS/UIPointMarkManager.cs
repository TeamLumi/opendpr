using DG.Tweening;
using Dpr.Contest;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.GMS
{
	public class UIPointMarkManager : MonoBehaviour
	{
		private readonly Vector3 VECTOR_ZERO = new Vector3(0.0f, 0.0f, 0.0f);

		[SerializeField]
		private UINetworkIcon uiNetworkIcon;
		[SerializeField]
		private Image cursorImage;
		[SerializeField]
		private Sprite[] pointMarkSprArray;
		[SerializeField]
		private RectTransform cursorParentContent;
		private ObjectPoolSystem<UIPointMark> markObjPool = new ObjectPoolSystem<UIPointMark>();
		private UIPointMark[] pointMarkArray;
		private DOTweenAnimation[] cursorTweenArray;
		private Image cursorEffImage;
		private RectTransform cursorRect;
		private Canvas canvas;
		private GameObject template;
		private Transform poolParent;
		private int nowShowIconNum;
		private int currentSelectIndex = -1;
		private int generatedCount;
		private bool isGeneratedPool;
		private bool isModeBrowsing;
		private bool isMaxZoom;
		private bool active;
		
		public bool IsGeneratedPool { get => isGeneratedPool; }
		
		// TODO
		public void Initialize() { }
		
		// TODO
		private void Initializing(float deltaTime) { }
		
		// TODO
		public void OnFinalize() { }
		
		public void Setup(GMSPointDataModel[] points)
		{
			var uVar1 = new GMS_UIPointMark[points.Length];
			this.pointMarkArray = uVar1;
			this.active = true;
		}
		
		public void ShowGMSMark(GMSMode gmsMode)
		{
			this.canvas.enabled = 1;
			this.isMaxZoom = 0x100;
			this.isModeBrowsing = (int)gmsMode == 1;
		}
		
		// TODO
		public void ResetPoints() { }
		
		// TODO
		public void OnStartMove() { }
		
		// TODO
		public Vector2 GetMarkPos() { return default; }
		
		public void ShowUIMark()
		{
			this.canvas.enabled = 1;
			this.active = true;
		}
		
		// TODO
		public void ShowOnlySelectMark() { }
		
		public void HideUIMark()
		{
			this.canvas.enabled = 0;
			this.active = false;
		}
		
		// TODO
		public void OnChangeDistanceLevel(bool isMaxZoom) { }
		
		// TODO
		public void OnSelectPoint(int dataIndex, bool isMaxZoom, bool isActiveCursorEff = true) { }
		
		// TODO
		private void UnSelectPrevPoint() { }
		
		// TODO
		private void SetCursorParent(UIPointMark target, bool isActiveCursorEff = true) { }
		
		// TODO
		public void PlayCursorTween() { }
		
		// TODO
		public void StopCursorTween() { }
		
		public void ShowMatchingIcon()
		{
			this.uiNetworkIcon.ShowMatchingIcon();
		}
		
		public void HideMatchingIcon()
		{
			this.uiNetworkIcon.matchingIconObj.SetActive(0);
		}
		
		public void ShowAttentionIcon()
		{
			this.uiNetworkIcon.ShowAttentionIcon();
		}
		
		public void HideAttentionIcon()
		{
			this.uiNetworkIcon.attentionIconObj.SetActive(0);
		}
		
		// TODO
		public void UpdatePointPosition(int index, GMSPointDataModel pointDataModel) { }
		
		// TODO
		private void UpdatePointMark(int index, GMSPointDataModel pointDataModel, bool isMaxZoom) { }
		
		private bool CanAddPool { get => nowShowIconNum < GMSDataConstants.INIT_GENERATE_MARK_NUM; }
		
		// TODO
		private void HidePointMark(int index) { }
		
		// TODO
		public void UpdatePointView(int index) { }
	}
}