using UnityEngine;

namespace Dpr.Contest
{
	public class NotesObjectEmitter
	{
		private ObjectPoolSystem<NoteIcon> noteIconPool = new ObjectPoolSystem<NoteIcon>();
		private ObjectPoolSystem<LongTapNotesBg> notesBgPool = new ObjectPoolSystem<LongTapNotesBg>();
		private float moveSpeed;
		private float noteFadeDuration;
		private int currentCreateNum;
		
		// TODO
		public void Initialize(NoteIcon noteComponent, Transform noteParent, LongTapNotesBg bgComponent, Transform bgContent) { }
		
		// TODO
		public void SetupParam(float moveSpeed, float noteFadeDuration) { }
		
		// TODO
		public void OnFinalize() { }
		
		public bool CanCreateNoteIcon { get => currentCreateNum < ContestDataConstants.INIT_CREATE_NOTE_POOL_NUM; }
		
		// TODO
		public NoteIcon CreateNextNoteIcon(float elapsedTime, NotesDataModel noteData, float validTapTimeRange) { return default; }
		
		public void DecCreateIconNum()
		{
			if (0 < this.currentCreateNum) {
			  this.currentCreateNum = this.currentCreateNum + -1;
			}
			ContestUtils.EmitLog(_StringLiteral_8901,0);
		}
		
		// TODO
		public LongTapNotesBg CreateNotesBg(NotesDataModel startNote, NotesDataModel endNote, double elapsedTime) { return default; }
	}
}