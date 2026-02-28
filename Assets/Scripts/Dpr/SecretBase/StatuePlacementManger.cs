using System.Collections;
using UnityEngine;

namespace Dpr.SecretBase
{
	public class StatuePlacementManger : MonoBehaviour
	{
		[SerializeField]
		private SecretBaseMasterDataManager masterData;
		[SerializeField]
		private GameObject placementGuide;
		[SerializeField]
		private StatuePlacementGridManager gridManager;
		[SerializeField]
		private FieldCursor fieldCursor;
		[SerializeField]
		private FieldCursor placementCursor;
		[SerializeField]
		private FieldCursor placementCursorSelect;
		[SerializeField]
		private FieldCursor impossibleField;
		[SerializeField]
		private Transform statueRoot;
		[SerializeField]
		private StatuePlacementCrystal crystal;
		[SerializeField]
		private StatuePlacementEffectManager effectManager;
		[SerializeField]
		private SecretBaseAudioManager audioManager;
		private FieldCursor currentCursor;
		private Vector2Int gridPosition = new Vector2Int(0, 0);
		private CursorMode cursorMode;
		
		public FieldCursor FieldCursor { get => fieldCursor; }
		public FieldCursor PlacementCursor { get => placementCursor; }
		public Transform StatueRoot { get => statueRoot; }
		public Vector2Int GridPosition { get => gridPosition; }
		
		// TODO
		public IEnumerator Load() { return default; }
		
		// TODO
		public bool IsLoadCompleted() { return default; }
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void SetCursorMode(CursorMode mode) { }
		
		public void SetActivePlaceMentGuide(bool isActive)
		{
			this.placementGuide.SetActive((isActive ? 1 : 0) & 1);
		}
		
		// TODO
		public void CursorMoveToLeft() { }
		
		// TODO
		public void CursorMoveToRight() { }
		
		// TODO
		public void CursorMoveToUp() { }
		
		// TODO
		public void CursorMoveToDown() { }
		
		// TODO
		private void ApplyCursorPos() { }
		
		// TODO
		public void AddStatue(PlacementData info) { }
		
		// TODO
		public void SetPlacementCursorRect(RectInt rect) { }
		
		// TODO
		public bool IsCanBePlacement() { return default; }
		
		// TODO
		public bool IsCanBeSelectedField() { return default; }
		
		// TODO
		public PlacementData GetOverlapedPlacementData() { return default; }
		
		// TODO
		public bool SetStatueDir(PlacementData target, int placement_dir) { return default; }
		
		public void UpdateCrystalColor()
		{
			this.crystal.UpdateCrystalColor();
		}
		
		// TODO
		private void SetCurrentCursor(FieldCursor current) { }
		
		public void SetSelectPedestalMode(bool isPedestalMode)
		{
			if (isPedestalMode) {
			  this.currentCursor.SetActiveCursor(0);
			  ExtensionMethods.SetActive(this.gridManager,0);
			  this.crystal.StopyCrystalEffect();
			  ExtensionMethods.SetActive(this.crystal,0);
			  ExtensionMethods.SetActive(this.impossibleField,0);
			}
			this.currentCursor.SetActiveCursor(1);
			ExtensionMethods.SetActive(this.gridManager,1);
			ExtensionMethods.SetActive(this.crystal,1);
			ExtensionMethods.SetActive(this.impossibleField,1);
			this.crystal.UpdateCrystalColor();
		}

		public enum CursorMode : int
		{
			Field = 0,
			Placement = 1,
		}
	}
}