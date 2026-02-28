using DG.Tweening;
using Dpr.SubContents;
using Effect;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Contest
{
	public class NotesLane : MonoBehaviour
	{
		private readonly EmitEffectParam[] COMMON_TAP_GRADE_FX = new EmitEffectParam[]
		{
			new EmitEffectParam() { fxID = EffectContestID.EF_SU_CONTEST_RHYTHM_GREAT, poolCount = ContestDataConstants.GENERATE_TIMING_GRADE_POOL_COUNT },
			new EmitEffectParam() { fxID = EffectContestID.EF_SU_CONTEST_RHYTHM_NICE,  poolCount = ContestDataConstants.GENERATE_TIMING_GRADE_POOL_COUNT },
			new EmitEffectParam() { fxID = EffectContestID.EF_SU_CONTEST_RHYTHM_FAST,  poolCount = ContestDataConstants.GENERATE_TIMING_GRADE_POOL_COUNT },
		};

		[SerializeField]
		private GameObject barLineObj;
		[SerializeField]
		private GameObject noteObj;
		[SerializeField]
		private GameObject longTapBgObj;
		private Sprite[] tapGradeSprArray;
		private List<NoteIcon> currentUseNoteList = new List<NoteIcon>(ContestDataConstants.INIT_CREATE_NOTE_POOL_NUM);
		private List<LongTapNotesBg> currentNotesBgList = new List<LongTapNotesBg>(ContestDataConstants.INIT_CREATE_NOTE_BG_NUM);
		private List<BarLine> currentBarLineList = new List<BarLine>();
		private UITimingGrade[] uiTimingGradeArray;
		private NotesObjectEmitter noteObjEmitter = new NotesObjectEmitter();
		private EffectEmitter fxEmitter = new EffectEmitter();
		private EffectInstance holdFxInst;
		private DOTweenAnimation uiMusicFadeTween;
		private NoteIcon longStartNote;
		private NoteIcon longEndNote;
		private Image heartGaugeImage;
		private RectTransform tapIconRect;
		private Transform fxCanvasTransform;
		private Transform objParent;
		private float validTapTimeRange;
		private int loadCount;
		private int loadedCount;
		private Action<NoteTypeID> onFailedTap;
		private Action<NoteIcon> onDeactiveNote;
		private Action onStopHoldFx;
		
		public Vector3 TapIconCenterPos { get => tapIconRect.position; }
		
		// TODO
		public void Initialize(Action<NoteTypeID> onFailedTap, Action<NoteIcon> onDeactiveNote, Action onStopHoldFx) { }
		
		// TODO
		private void GenerateTimingGradePool() { }
		
		// TODO
		private void CreateTapGradeSpr() { }
		
		// TODO
		private string GetBestTapGradeTexName() { return default; }
		
		// TODO
		public bool IsReady() { return default; }
		
		// TODO
		public void Setup(float validTimeSpan, float moveSpeed, float beatSec, float noteFadeDuration, int bgmSigunature, int lineNum) { }
		
		// TODO
		private void CreateBarLine(float moveSpeed, float beatSec, int bgmSigunature, int lineNum) { }
		
		private void LoadFx()
		{
			this.loadCount = 0;
			LoadTapGradeFx();
			LoadLongTapFx();
		}
		
		// TODO
		private void LoadTapGradeFx() { }
		
		// TODO
		private void LoadLongTapFx() { }
		
		// TODO
		public void ResetParam(float beatSec, int bgmSigunature) { }
		
		// TODO
		public void OnFinalize() { }
		
		public bool CanCreateNote { get => noteObjEmitter.CanCreateNoteIcon; }
		
		// TODO
		public void CreateNote(float elapsedTime, NotesDataModel nextNoteData) { }
		
		// TODO
		public void CreateLongTapNotesBG(float elapsedTime, NotesDataModel startNoteData, NotesDataModel endNoteData) { }
		
		// TODO
		public void OnUpdate(float elapsedTime) { }
		
		// TODO
		private void UpdateNotes(float elapsedTime) { }
		
		// TODO
		private int FailedNote(int noteIndex, NoteIcon note) { return default; }
		
		// TODO
		private void RemoveNote(int listIndex, NoteIcon target) { }
		
		// TODO
		private void UpdateNoteUI(float elapsedTime) { }
		
		// TODO
		private void UpdateBarLine(float elapsedTime) { }
		
		// TODO
		private void UpdateFx() { }
		
		// TODO
		public NoteIcon OnInputDecideButton() { return default; }
		
		// TODO
		private NoteIcon FindNearTapTimingNote() { return default; }
		
		// TODO
		private bool IsValidNormalTap(float noteLifeTime) { return default; }
		
		// TODO
		private void TapNormalNote(NoteIcon targetNote) { }
		
		// TODO
		private void TapLongStartNote(NoteIcon targetNote) { }
		
		// TODO
		public void OnStartLongTap(int startNoteID) { }
		
		// TODO
		private NoteIcon FindNoteByID(int targetId) { return default; }
		
		// TODO
		public float OnReleaseHold() { return default; }
		
		public void DeactiveHoldFx()
		{
			var uVar2 = GameObject.get_activeSelf(this.holdFxInst.gameObject,0);
			if (uVar2) {
			  GameObject.SetActive(this.holdFxInst.gameObject,0,0);
			  if (this.onStopHoldFx != null) {
			    this.onStopHoldFx.Invoke();
			  }
			}
		}
		
		// TODO
		public void FailedTapLongStart() { }
		
		// TODO
		public void HideNotesUntilTime(float elaspedTimeRange) { }
		
		// TODO
		public void DeactiveNotesBg(int endNoteId) { }
		
		public void SetHeartGaugeRatio(float ratio)
		{
			this.heartGaugeImage.set_fillAmount();
		}
		
		// TODO
		public void ShowTimingGrade(NoteTapTimingID timingID) { }
		
		// TODO
		private UITimingGrade FindInactiveTimingGradeObj() { return default; }
		
		// TODO
		private EffectContestID ConvertTimingIDToEffectID(NoteTapTimingID timingID) { return default; }
		
		// TODO
		public void DoPlayUIFadeTween(bool forward) { }
	}
}