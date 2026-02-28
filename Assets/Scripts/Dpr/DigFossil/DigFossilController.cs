using Dpr.NetworkUtils;
using Dpr.SecretBase;
using Dpr.UnderGround;
using Effect;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.DigFossil
{
	public class DigFossilController : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("ゲーム開始メッセージ表示までの待機時間(秒)")]
		private float startMessageWaitTime = 0.8f;
        [SerializeField]
        [Tooltip("ほりボーナスの最小回数")]
		private int horiBonusMinCount = 5;
        [SerializeField]
        [Tooltip("ほりボーナスの最大回数")]
		private int horiBonusMaxCount = 8;
        [SerializeField]
        [Tooltip("ほりボーナスのゲージ増加値")]
        private int horiGaugeBonus = 20;
        [SerializeField]
        [Tooltip("壁が崩れた時のカメラ揺れ時間(秒)")]
        private float cameraShakeDuration = 3.0f;
        [SerializeField]
        [Tooltip("全てアイテムを掘り出した時のリザルトまでの待機時間(秒)")]
        private float waitingTimeToDigOutAllItemsResult = 1.0f;
        [SerializeField]
        [Tooltip("カメラの揺れ強度 要素数分段階が増えます")]
        private List<float> cameraShakeStrength = new List<float>();
        [SerializeField]
        [Tooltip("追加で炊く崩れかけエフェクトの発火数 要素数分段階が増えます")]
        private List<int> crumblingEffectNum = new List<int>();
        [SerializeField]
        [Tooltip("ゲーム画面からリザルト遷移のブラックアウト開始までの待機時間(x)と、フェードの時間(y)")]
        private Vector2 toResultBlackOut = new Vector2(1.0f, 1.0f);
        [SerializeField]
        [Tooltip("ゲーム画面からリザルト遷移のブラックイン開始までの待機時間(x)と、フェードの時間(y)")]
        private Vector2 toResultBlackIn = new Vector2(1.0f, 1.0f);
        [SerializeField]
        [Tooltip("アイテムリザルトから石の箱リザルト遷移のブラックアウト開始までの待機時間(x)と、フェードの時間(y)")]
        private Vector2 toBoxResultBlackOut = new Vector2(1.0f, 1.0f);
        [SerializeField]
        [Tooltip("アイテムリザルトから石の箱リザルト遷移のブラックイン開始までの待機時間(x)と、フェードの時間(y)")]
        private Vector2 toBoxResultBlackIn = new Vector2(1.0f, 1.0f);
        [SerializeField]
        [Tooltip("宝箱ひらくモーションの再生速度")]
        private float boxOpenMotionSpeed = 1.0f;
        [SerializeField]
        [Tooltip("宝箱ひらくモーションが再生されてから、エフェクト再生までの待機時間")]
        private float boxOpenEffectDelay = 1.0f;
        [SerializeField]
        [Tooltip("石の箱エフェクト再生してからホワイトアウト開始までの待機時間(x)と、フェードの時間(y)")]
        private Vector2 toAppearStatueWhiteOut = new Vector2(1.0f, 1.0f);
        [SerializeField]
        [Tooltip("石の箱ホワイトアウトからホワイトイン開始までの待機時間(x)と、フェードの時間(y)")]
        private Vector2 toAppearStatueWhiteIn = new Vector2(1.0f, 1.0f);
		[SerializeField]
        [Tooltip("となりほりの所持数の少ない石像出現率の一人あたりの増加率")]
        private float tonariModeDropUpCorrection = 0.1f;
        [SerializeField]
        [Tooltip("となりほりのほりゲージの消費の一人あたりの低下率")]
        private float tonariModeGaugeDownCorrection = 0.1f;
        [SerializeField]
        [Tooltip("デバッグ用、抽選される石像のID: 0:指定しない 1～石像のID")]
        private int debugLotStatueId;

        [SerializeField]
        private DigCursor cursor;
        [SerializeField]
        private DigBuildupViewManager buildupViewManager;
        [SerializeField]
        private DigDepositViewManager digDepositViewManager;
        [SerializeField]
        private DigToolSwitch toolSwitch;
        [SerializeField]
        private DigCameraShaker cameraShaker;
        [SerializeField]
        private DigCameraManager cameraManager;
        [SerializeField]
        private DigGauge gauge;
        [SerializeField]
        private DigFade fade;
        [SerializeField]
        private GameObject UIRoot;
        [SerializeField]
        private Transform stoneBoxPos;
        [SerializeField]
        private DigFallBoardDirection fallBoradDirection;
        [SerializeField]
        private DigItemResult itemResult;
        [SerializeField]
        private DigBoard board;
        [SerializeField]
        private DigEffectManager effectManager;
        [SerializeField]
        private DigAudioManager audioManager;
        [SerializeField]
        private GameObject resultBg;
        [SerializeField]
        private DigVibration vibration;
        [SerializeField]
        private DigMasterDataManager masterDataManager;
        [SerializeField]
        private DigStatueCameraSelector statueCameraSelector;
        [SerializeField]
        private StatueModelLoader statueModelLoader;
        [SerializeField]
        private Text tableTypeText;
        [SerializeField]
        private Text tonariNumText;
        [SerializeField]
        private EnvironmentSettings inGameEnvironmentSettings;
        [SerializeField]
        private EnvironmentSettings resultEnvironmentSettings;
        [SerializeField]
        private EnvironmentController environmentController;
		[SerializeField]
		private List<DigCursor> tonariCursorList;

		private const int COST_DIG_HUMMER = 8;
		private const int COST_DIG_PIC = 4;
		private const int DIG_GAUGE_START = 196;

		private readonly IDigMessage message = new DigMessage();
		private float digGauge;
		private int digGaugeMax;
		private EffectInstance directionEffectInstance;
		private DigDepositViewManager.PlacementInfo stoneBoxData;
		private readonly IDigStoneBoxResult stoneBoxResult = new DigStoneBoxResult();
		private GameState gameState;
		private bool isDisplayDebugInfo = true;
		private UgNetworkManager ugNetworkManager;
		private Dictionary<int, DigCursor> tonariCursorDic = new Dictionary<int, DigCursor>();
		private DigParam digParam = new DigParam();
		
		private bool isHost { get => !UgFieldManager.isOnline || ugNetworkManager.digFossileMainPlayerStationIndex < 0; }
		
		// TODO
		public IEnumerator ActivateOperation() { return default; }
		
		// TODO
		private IEnumerator IE_LoadResource() { return default; }
		
		// TODO
		private IEnumerator SetupKeyguide() { return default; }
		
		// TODO
		private void OpenKeyguide() { }
		
		// TODO
		private void CloseKeyguide() { }
		
		// TODO
		private IEnumerator GameInitialize() { return default; }
		
		// TODO
		private IEnumerator ShowStartMessage() { return default; }
		
		// TODO
		private void SystemInitialize() { }
		
		// TODO
		private void OnClicked(in Vector2 inPos)
		{
			// TODO
			int CalcIndex(float maxValue, int count) { return default; }
        }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		private IEnumerator WaitForSeconds(float wait, Action onCompleted) { return default; }
		
		// TODO
		private IEnumerator ResultDirection() { return default; }
		
		private void SetState(GameState newState)
		{
			this.gameState = (GameState)(newState);
		}
		
		// TODO
		private void SetUIAndCamera(DigCameraManager.CameraSet set) { }
		
		// TODO
		private void SetDebugText(ref Text text, bool isDuty, string message) { }
		
		// TODO
		private void ExitDigFossil(bool isDig) { }
		
		// TODO
		private void SaveReport() { }
		
		private void SetDisplayDebugInfo(bool isDisplay)
		{
			ExtensionMethods.SetActive(this.tableTypeText,(isDisplay ? 1 : 0) & 1);
			ExtensionMethods.SetActive(this.tonariNumText,(isDisplay ? 1 : 0) & 1);
		}
		
		// TODO
		private void SendDigData(Vector2 pos, bool isHammer) { }
		
		// TODO
		private void OnReceiveDigFossileNetData(INetData data) { }
		
		// TODO
		private void HostEnd() { }
		
		// TODO
		private bool AddCursor(int stationIndex) { return default; }
		
		// TODO
		private void TonariDigAttack(NetDigAttackData data) { }

		public class DigParam
		{
			public int NumOfOtherParticipants;
			public float DropUpCorrection;
			
			public float Bonus { get => DropUpCorrection * NumOfOtherParticipants + 1.0f; }
		}

		private enum GameState : int
		{
			Init = 0,
			FadeIn = 1,
			FirstEvent = 2,
			StartMessageShow = 3,
			Dig = 4,
			EndDirection = 5,
			EndMessageShow = 6,
			ResultCommonItem = 7,
			ResultCommonItemWait = 8,
			ResultStoneBox = 9,
			MessageWait = 10,
			MessageCloseWait = 11,
		}
	}
}