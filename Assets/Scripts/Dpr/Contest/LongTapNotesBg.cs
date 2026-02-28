using UnityEngine;

namespace Dpr.Contest
{
	public class LongTapNotesBg : MonoBehaviour, IPoolObject
	{
		private RectTransform rect;
		private NotesDataModel endNoteData;
		private float moveSpeed;
		private float arriveSec;
		private float lifeTime;
		private int startNoteID;
		private int endNoteID;
		private bool active;
		private bool isHold;
		
		public bool IsActive()
		{
			return this.active;
		}
		
		public int StartNoteID { get => startNoteID; }
		public int EndNoteID { get => endNoteID; }
		
		// TODO
		public void Create(NotesDataModel startNoteData, NotesDataModel endNoteData, double elapsedTime, float moveSpeed) { }
		
		public void Deactive()
		{
			this.active = false;
			var uVar1 = this.gameObject;
			var uVar2 = uVar1.activeSelf;
			if ((uVar2 & 1) != 0) {
			  uVar1 = this.gameObject;
			  uVar1.SetActive(0);
			}
		}
		
		// TODO
		private void SetActive(bool active) { }
		
		// TODO
		private void CalcWidth(float startSecTime, float endSecTime) { }
		
		public void OnStartHold()
		{
			this.isHold = true;
			UpdateMovePosition(0);
		}
		
		// TODO
		public void OnUpdate(double elapsedTime) { }
		
		// TODO
		private void UpdateMovePosition(float time) { }
	}
}