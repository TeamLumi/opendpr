using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Contest
{
	public class NoteIcon : MonoBehaviour, IPoolObject
	{
		private static readonly Vector3 HIDE_NOTE_POS = new Vector3(2000.0f, 0.0f, 0.0f);

		private Image iconImage;
		private RectTransform rect;
		private NotesDataModel noteData;
		private NoteStatusID statusID;
		private Vector3 iconPos;
		private float lifeTime;
		private float fadeTime;
		private float moveSpeed;
		private float validTapTimeRange;
		private float fadeDuration;
		private bool canTap;
		private bool isTap;
		private bool active;
		
		public NotesDataModel NoteData { get => noteData; }
		public NoteTypeID NoteType { get => noteData.notesType; }
		public float arriveSec { get => noteData.arriveSec; }
		public NoteStatusID StatusID { get => statusID; }
		public float LifeTime { get => lifeTime; }
		public float AbsLifeTime { get => lifeTime >= 0.0f ? lifeTime : -lifeTime; }
		
		public bool IsActive() {
		    return active;
		}
		
		// TODO
		public void Create(NotesDataModel noteData, float elapsedTime, float moveSpeed, float validTapTimeRange, float fadeDuration) { }
		
		// TODO
		public void Deactive() { }
		
		// TODO
		private void SetActive(bool active) { }
		
		// TODO
		public void OnUpdate(float elapsedTime) { }
		
		// TODO
		private void UpdateNormalNote() { }
		
		// TODO
		private void UpdateLongStartNote() { }
		
		// TODO
		private void UpdateLongEndNote() { }
		
		// TODO
		private void MoveNote() { }
		
		// TODO
		private void UpdatePosition(float time) { }
		
		// TODO
		private void FadeOut() { }
		
		// TODO
		private void UpdateColor(float ratio) { }
		
		public bool CanTap { get => NoteType != NoteTypeID.LongEnd && canTap; }
		
		// TODO
		public void OnTap() { }
		
		public void SetTapEnabled(bool enabled) {
		    this.canTap = enabled;
		}
		
		// TODO
		public void ChangeStateMiss() { }

		public enum NoteStatusID : int
		{
			Move = 0,
			Miss = 1,
			ReachedEnd = 2,
			InActive = 3,
		}
	}
}