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
		
		public bool IsActive() {
		    return active;
		}
		
		public int StartNoteID { get => startNoteID; }
		public int EndNoteID { get => endNoteID; }
		
		// TODO
		public void Create(NotesDataModel startNoteData, NotesDataModel endNoteData, double elapsedTime, float moveSpeed) { }
		
		// TODO
		public void Deactive() { }
		
		// TODO
		private void SetActive(bool active) { }
		
		// TODO
		private void CalcWidth(float startSecTime, float endSecTime) { }
		
		// TODO
		public void OnStartHold() { }
		
		// TODO
		public void OnUpdate(double elapsedTime) { }
		
		// TODO
		private void UpdateMovePosition(float time) { }
	}
}