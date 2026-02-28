using Dpr.BallDeco;
using System;
using UnityEngine;

namespace Dpr.UI
{
	public class Capsule2DViewController : MonoBehaviour
	{
		[SerializeField]
		private GameObject frontObject;
		[SerializeField]
		private GameObject backObject;
		[SerializeField]
		private RectTransform gridRootRectTransfrom;
		[SerializeField]
		private Color gridFrontColor = Color.clear;
		[SerializeField]
		private Color gridBackColor = Color.clear;
		[SerializeField]
		private Color affixedSealGridColor = Color.clear;

		private Capsule2DGridCell[] gridCells;
		private Capsule2DGridCell currentGridCell;
		private bool isFrontView;
		private RectTransform gridCenterRectTransform;

		public event Action OnReverseAction;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void Setup(CapsuleInfo capsuleInfo, bool isReset2DFrontView) { }
		
		// TODO
		public bool MoveGridCell(int x, int y) { return default; }
		
		public Capsule2DGridCell GetCurrentGridCell()
		{
			return this.currentGridCell;
		}
		
		public void SetCurrentGridCell(Capsule2DGridCell cell)
		{
			this.currentGridCell = cell;
		}
		
		public void ResetCurrentGridCell()
		{
			if (this.gridCells.Length != 0) {
			  this.currentGridCell = this.gridCells[0];
			}
		}
		
		// TODO
		public Capsule2DGridCell GetNearGridCell(Vector3 pos) { return default; }
		
		// TODO
		public void Reverse() { }
		
		private void UpdateView()
		{
			this.frontObject.SetActive(this.isFrontView);
			this.backObject.SetActive(!this.isFrontView);
		}
		
		// TODO
		private void UpdateGridCells(AffixSealData[] affixSealDatas, int sealCount) { }
	}
}