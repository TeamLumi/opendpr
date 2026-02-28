using Dpr.Message;
using Dpr.UI;
using SmartPoint.AssetAssistant;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.SecretBase
{
	public class StatuePlacementEditController : MonoBehaviour
	{
		public const string PedestalListAssetBundleName = "pedestallist";

		[SerializeField]
		private StatueSelectWindow statueSelectWindow;
		[SerializeField]
		private FieldCursor impossible;
        [SerializeField]
        private int statueMax = 18;
        [SerializeField]
        private UIText statueNumLabel;
        [SerializeField]
        private UIText statueNum;

		public static GameObject[] PedestalModels;
		private Coroutine statueItemCoroutine;

        [SerializeField]
        private Pedestal pedestals;

		public static Dictionary<int, int> statueItemNum = new Dictionary<int, int>();
		public static Dictionary<int, int> pedestalsNum = new Dictionary<int, int>();

        [SerializeField]
        private PedestalWindow pedestalWindow;
        [SerializeField]
        private RawImage fieldView;
        [SerializeField]
        private StatuePlacementFilterWindow fillterWindow;

		private MessageMsgFile msgFile;

        [SerializeField]
        private Color[] pokeTypeColor;
        [SerializeField]
        private SecretBaseMasterDataManager masterData;
        [SerializeField]
        private SecretBaseCamera secretBaseCamera;
        [SerializeField]
        private StatuePlacementManger placementManager;
        [SerializeField]
        private Transform keyGuideRoot;
        [SerializeField]
        private StatueModelLoader statueModelLoader;
        [SerializeField]
        private SecretBaseAudioManager audioManager;
        [SerializeField]
        private GameObject statueNumView;

		public OnExit onExitCallback;

		private StateMachine<State, StatuePlacementEditController> stateMachine;
		private StateStatueWindow stateStatueWindow = new StateStatueWindow();
		private StateSelectFromStatueWindow stateSelectFromStatueWindow = new StateSelectFromStatueWindow();
		private StateField stateField = new StateField();
		private StateConfirmReset stateConfirmReset = new StateConfirmReset();
		private StateSelectFromField stateSelectFromField = new StateSelectFromField();
		private StateWaitStatueWindow stateWaitStatueWindow = new StateWaitStatueWindow();
		private StatePlacement statePlacement = new StatePlacement();
		private StatePedestalWindow statePedestalWindow = new StatePedestalWindow();
		private StateFillterWindow stateFillterWindow = new StateFillterWindow();
		private StateNone stateNone = new StateNone();
		private StateViewMode stateViewMode = new StateViewMode();
		
		public StatueSelectWindow StatueSelectWindow { get => statueSelectWindow; }
		public int StatueMax { get => statueMax; }
		
		// TODO
		private void OnDestroy() { }
		
		public PedestalWindow PedestalWindow { get => pedestalWindow; }
		public StatuePlacementFilterWindow FillterWindow { get => fillterWindow; }
		public MessageMsgFile MsgFile { get => msgFile; }
		public SecretBaseAudioManager AudioManager { get => audioManager; }
		public StatuePlacementManger PlacementManager { get => placementManager; }
		public StatueModelLoader StatueModelLoader { get => statueModelLoader; }
		
		// TODO
		public IEnumerator Load() { return default; }
		
		public bool IsLoadCompleted()
		{
			this.placementManager.IsLoadCompleted();
			return false;
		}
		
		// TODO
		public void OnUpdate() { }
		
		// TODO
		public IEnumerator ApplyRoom(AssetRequestOperation pedestalLoadOperation) { return default; }
		
		// TODO
		public bool OpenEnable() { return default; }
		
		// TODO
		public void Show() { }
		
		public void Close()
		{
			ExtensionMethods.SetActive(this.placementManager,0);
			ExtensionMethods.SetActive(this.keyGuideRoot,0);
			this.statueNumView.SetActive(0);
		}
		
		// TODO
		private void StatueAndPedestalSetup() { }
		
		// TODO
		public IEnumerator StatueItemOperation(List<StatueEffectData> effectDatas) { return default; }
		
		// TODO
		public IEnumerator Initialize() { return default; }
		
		// TODO
		private void OpenKeyguide() { }
		
		// TODO
		public bool IsStatueMax() { return default; }
		
		// TODO
		public bool IsStatueZero() { return default; }
		
		// TODO
		public void AddStatue(PlacementData info) { }
		
		// TODO
		public PlacementData GetPlacementData(RectInt rect) { return default; }
		
		// TODO
		public int GetPlacementNum(RectInt rect) { return default; }
		
		// TODO
		public void RemoveStatue(PlacementData remove) { }
		
		// TODO
		public void RemoveStatuesAll() { }
		
		// TODO
		public void OperationTopView(int mask) { }
		
		public void ResetLookAt()
		{
			GameObject.SetActive(this.fieldView.gameObject,0,0);
			this.secretBaseCamera.ResetLookAt();
			this.fieldView.gameObject = Dpr_SecretBase_StatuePlacementManger__SetSelectPedestalMode
			                  (this.placementManager,0,0);
			SetDisplayStatueCursor(this.fieldView.gameObject,1);
		}
		
		// TODO
		public void TargetLookAt(PlacementData target) { }
		
		// TODO
		private void SetDisplayStatueCursor(bool isActive) { }
		
		// TODO
		public void OperationTopView(int mask, PlacementData target) { }
		
		// TODO
		private void IconListUpdate() { }
		
		// TODO
		private void UpdatePlacementNum() { }
		
		// TODO
		public void Enter_StatueWindow() { }
		
		// TODO
		public void Enter_SelectFromStatueWindow(PlacementData statue) { }
		
		// TODO
		public void Enter_Field() { }
		
		// TODO
		public void Enter_ConfirmReset() { }
		
		// TODO
		public void Enter_SelectFromField() { }
		
		// TODO
		public void Enter_WaitStatueWindow(PlacementData statue) { }
		
		// TODO
		public void Enter_Placement(PlacementData statue, bool isField) { }
		
		// TODO
		public void Enter_PedestalWindow(PlacementData placement) { }
		
		// TODO
		public void ChangePrevState() { }
		
		// TODO
		public void Enter_FillterWindow() { }
		
		// TODO
		public void Exit_StatuePlacementEdit() { }
		
		// TODO
		private void AddStatueWindowItem(StatueEffectData data) { }

		public delegate void OnExit();

		public enum State : int
		{
			StatueWindow = 0,
			SelectFromStatueWindow = 1,
			Field = 2,
			ConfirmReset = 3,
			SelectFromField = 4,
			WaitStatueWindow = 5,
			Placement = 6,
			PedestalWindow = 7,
			FillterWindow = 8,
			None = 9,
			ViewMode = 10,
		}
	}
}