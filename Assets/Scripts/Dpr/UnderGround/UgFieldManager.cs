using DPData;
using Dpr.Field.Walking;
using Dpr.Message;
using Dpr.MsgWindow;
using Dpr.NetworkUtils;
using Dpr.SubContents;
using Dpr.UI;
using Effect;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.UnderGround
{
    public class UgFieldManager : MonoBehaviour
    {
        [SerializeField]
        private int d_stationIndex;
        [SerializeField]
        private int d_digGroupID;
        public static UgFieldManager Instance;
        public static bool isFallEnter = false;
        public bool isUgExiting;
        public bool isErrorDialogVisible;
        public Action OnCloseErrorDialog;
        private bool IsClosableMessage;
        private Action OnFinishMsg;
        private Action OnFinishBusy;
        private Action OnCreateOtherSecretBase;
        private bool IsBase;
        public bool isLoadedOrVisit = true;
        private UgNetworkManager ugNetManager;

        private int myStationIndex { get => NetworkManager.Instance.MyStationIndex; }

        public float KousekiBonusTime;

        public bool isKousekiBonus { get => KousekiBonusTime > 0.0f; }

        public byte KousekiCount;

        private bool IsKousekiFull { get => KousekiCount >= KOUSEKI_BONUS_START_NUM; }

        public byte BonusCount;

        public const int KOUSEKI_BONUS_START_NUM = 40;
        private const string UG_MSG_FILE = "dlp_underground";
        private const string YOBIKAKE = "DLP_underground_615";
        private const string BIG_MAP = "DLP_underground_430";
        private const string BIG_MAP_MESSAGE = "DLP_underground_431";
        private const string GOTO_GROUND = "DLP_underground_370";
        private const string GOTO_GROUND_MESSAGE = "DLP_underground_296";
        private const string CANCEL = "DLP_underground_371";
        private const string DIG_START_MESSAGE = "DLP_underground_263";
        private const string DRILL_USE_MESSAGE = "DLP_underground_471";
        private const string DRILL_USE_HIKKOSHI = "DLP_underground_280";
        private const string DRILL_TOO_NEAR = "DLP_underground_472";
        private const string DRILL_SAME_POS = "DLP_underground_473";
        private const string DRILL_TOO_NARROW = "DLP_underground_474";
        private const string ENTER_BASE = "DLP_underground_285";
        private const string ENTER_BASE_FRIEND = "DLP_underground_475";
        public StatueEffectRawData ugStatueEffectData;
        public static bool isDebug_RarePoke = false;
        public static bool isForceRareColor = false;
        private static readonly string[] Y_MENU_LABEL = { "DLP_underground_430", "DLP_underground_370", "DLP_underground_371" };
        private static readonly string[] Y_MENU_LABEL_ONLINE = { "DLP_underground_615", "DLP_underground_430", "DLP_underground_370", "DLP_underground_371" };

        private UgFieldDataManager dataMng;
        public static DigData digData;
        private static List<DigPointModel> DigPoints;

        [SerializeField]
        private UgMiniMapComponent miniMap;

        public UgMiniMapComponent Minimap { get => miniMap; }

        private ZoneID prevZoneID;
        private NowZoneType nowZoneType;
        private WalkingAIManager walkingManager;
        public FieldObjectEntity NpcEntity;
        public StatueBuff statueBuff;
        public UgSecretBase nowBaseModel;
        private int nowBasePlayerIndex = -1;
        private UgNetworkManager.UgOnlinePlayerData nowBasePlayerData;
        public UgSecretBase EffectiveBase;

        public UgFieldDataManager GetDataMng()
        {
        	return this.dataMng;
        }

        public UgNetworkManager.UgOnlinePlayerData nowBasePlayerInfo { get => nowBasePlayerIndex == -1 ? null : nowBasePlayerData; }
        public bool isOtherBase { get => nowBasePlayerInfo != null; }
        public static bool isOnline { get => UgNetworkManager.isInstantiated && NetworkManager.SessionState == INL1.IlcaNetSessionState.SS_Gaming; }
        public static bool isJoinOther { get => NetworkManager.Instance.IsJoinOtherPlayer(); }
        public int effectiveBasePlayerIndex { get; private set; }

        public List<SecretBaseModel> SecretBases;
        public UgStationID_to_DigFossilIDList ugDigGroupList;
        private bool isDigCancel;
        private int targetStationIndex;
        private Action OnLeaveTargetPlayer;
        public static bool isEnableInput;
        public Action OnDestroyCallBack;
        public Action OnZoneChangeCallBack;
        public static bool isStartLeave = false;
        public static bool isGuruGuruAnimEnd = false;
        private float OnZoneChangeTime;
        private bool isDebugDraw;
        [SerializeField]
        private float duration = 0.85f;
        [SerializeField]
        private float searchSize = 900.0f;
        [SerializeField]
        private float searchDist = 9.0f;
        [SerializeField]
        private float TalkDistance = 3.0f;
        private List<Vector2Int> buffPosList = new List<Vector2Int>(20);
        private bool isSearching;
        private Transform _dummy;

        [Button("SearchDigPoint", "SearchDigPoint", new object[0])]
        public int Button02;
        [Button("KiraKra", "KiraKra", new object[0])]
        public int Button04;

        private ContextMenuWindow contextMenu;
        private bool isContextMenuOpend;

        [Button("MoveTargetPos", "MoveTargetPos", new object[0])]
        public int Button03;

        private Action OnComplete;
        private FieldObjectMove move;
        private FieldObjectRotateYaw rot;

        [Button("D_GetNPCTalkCount", "D_GetNPCTalkCount", new object[0])]
        public int Button01;
        [Button("D_AddNPCTalkCount", "D_AddNPCTalkCount", new object[0])]
        public int Button05;
        [Button("D_ResetNPCTalkCount", "D_ResetNPCTalkCount", new object[0])]
        public int Button06;

        public UgNPCTalkModel NpcTalkModel;
        private bool[] results = new bool[8];
        private static readonly Vector3[] eightDirect =
        {
            new Vector3(-1, 0, -1),
            new Vector3(0, 0, -1),
            new Vector3(1, 0, -1),
            new Vector3(-1, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(-1, 0, 1),
            new Vector3(0, 0, 1),
            new Vector3(1, 0, 1),
        };

        [Button("DebugCheckWalls", "DebugCheckWalls", new object[0])]
        public int button111;
        [Button("DebugCreateTonarihori", "デバッグ隣堀生成", new object[0])]
        public int Button001;
        [Button("TEST", "TEST", new object[0])]
        public int button01;
        [Button("SAVE_POKE", "SAVE_POKE", new object[0])]
        public int button02;
        [Button("LOAD_POKE", "LOAD_POKE", new object[0])]
        public int button03;
        [Button("AddKousekiCount", "AddKousekiCount", new object[0])]
        public int Button010;

        private bool _isInitAddUpdate;

        // TODO
        private void InputUpdate(float deltaTime) { }

        // TODO
        private void Update() { }

        // TODO
        public static bool IsBusy() { return false; }

        // TODO
        private void SceneEndCheck() { }

        // TODO
        public void ErrorDialogCheck() { }

        // TODO
        private void ShowErrorDialog(bool PrevInputActive) { }

        // TODO
        private void MsgFinishCheck(float deltaTime) { }

        // TODO
        private void CloseMsgWindows() { }

        // TODO
        public void OnZoneChange() { }

        // TODO
        public void CreateDigPoints(int stationIndex) { }

        // TODO
        public void DeleteAllDigPoints() { }

        // TODO
        private void OnZoneChangeAfter(ZoneID zoneID) { }

        // TODO
        private void MyUpdate(float deltaTime) { }

        // TODO
        private void Awake() { }

        // TODO
        public static bool isInstantiated { get; }

        // TODO
        private IEnumerator Start() { return null; }

        // TODO
        private void StartSession() { }

        // TODO
        private void OnEmoticonDeside(int index) { }

        // TODO
        private void OnDestroy() { }

        // TODO
        public void ToAroundMapMode() { }

        // TODO
        public void ToAllOverMapMode() { }

        // TODO
        private void DebugDrawPokeRate() { }

        // TODO
        private void DebugKasekihoriDraw() { }

        // TODO
        private EntryType CheckEntryType(ZoneID zoneID, bool isLoaded) { return EntryType.FirstEnter; }

        // TODO
        private void CheckWall() { }

        // TODO
        private void CreateDigPointGameObject(DigPointModel model) { }

        // TODO
        private void SetDigPointPosition(Transform transform, int x, int y) { }

        // TODO
        private Vector2Int GetGridPosByDigPointPosition(Transform transform) { return Vector2Int.zero; }

        // TODO
        private DigPointModel CreateDigPointModel(UgDigFossilePosGroup fossilPosData) { return default; }

        // TODO
        private bool isNear(Vector2Int pos1, Vector2Int pos2) { return false; }

        // TODO
        private Transform dummy { get; }

        // TODO
        public void SearchDigPoint()
        {
            // TODO
            void update(float deltaTime) { }
        }

        // TODO
        public void KiraKira() { }

        // TODO
        private bool CheckDigPoint(DIR wallDIR)
        {
            // TODO
            void GotoDigFossil(bool isOK) { }

            return default;
        }

        // TODO
        public void DigCancelCheck(float deltaTime) { }

        // TODO
        private bool CheckSecretBase(Vector2Int grid)
        {
            // TODO
            void Cancel() { }

            // TODO
            void OnReceiveSBData(NetSecretBaseData netSBData) { }

            return default;
        }

        // TODO
        private Vector2Int? GetWallGridPos() { return null; }

        // TODO
        public static void PlayerStop() { }

        // TODO
        private void OpenCreateHoleSelector(DIR wallDir, Vector2Int grid)
        {
            // TODO
            bool isOtherSecBaseExists() { return default; }

            // TODO
            void CancelCheck() { }
        }

        // TODO
        public GameObject HoleInstantiate(DIR wallDir, Vector3 pos) { return null; }

        // TODO
        private void PlayHoleEffect(Vector3 pos, Quaternion rot) { }

        // TODO
        public Vector2Int GetReturnUGPos() { return Vector2Int.zero; }

        // TODO
        public float GetReturnYawAngle() { return 0.0f; }

        public ZoneID GetSecBaseReturnZoneID()
        {
        	return (long)this.nowBaseModel;
        }

        // TODO
        private void YmenuHandler(int selectIndex) { }

        // TODO
        public bool IsContextMenuOpend { get; }

        // TODO
        private void OpenCustomMenu() { }

        // TODO
        private void OpenGotoGroundSelector() { }

        // TODO
        private MsgWindowParam CreateMsgWindowParam(string msgFileName, string labelName) { return null; }

        // TODO
        public void GotoSecretBase(SecretBaseModel sbModel) { }

        // TODO
        private ZoneID GetSecretBaseZone(ZoneID zone, int expansionStatus) { return ZoneID.UNKNOWN; }

        // TODO
        private void SetSecretBasePlayerNameData(PlayerNameData nameData) { }

        // TODO
        private void CreateSecretBase(UgSecretBase secretBase) { }

        // TODO
        private void Anahori(UgSecretBase secretBase, Vector3 secBasePos) { }

        // TODO
        private Vector3 GetHoleCreatePosition(UgSecretBase secretBase) { return Vector3.zero; }

        // TODO
        private float GetAngle(Vector3 targetPos, DIR wallDIR) { return 0.0f; }

        // TODO
        private float GetHoleCreateAngle(UgSecretBase secretBase) { return 0.0f; }

        // TODO
        public SecretBaseModel CreateSecretBase_Immidiate(UgSecretBase secretBase, int stationIndex) { return null; }

        // TODO
        public void DeleteTargetSecretBase(int stationIndex) { }

        // TODO
        private void DeleteSecretBase(SecretBaseModel model, bool immidiate) { }

        // TODO
        public void DeleteAllSecretBase() { }

        // TODO
        public bool GetNowSecretBaseEffective() { return false; }

        // TODO
        public void SetEffectiveBase(UgSecretBase ugSecretBase) { }

        // TODO
        public bool IsUseTargetSecretBase(int stationIndex) { return false; }

        // TODO
        public void EffectiveMyBase() { }

        // TODO
        public bool IsHaveSecretBase() { return false; }

        // TODO
        private bool IsSecretBaseSameArea() { return false; }

        // TODO
        public bool IsSameArea(ZoneID zoneID) { return false; }

        // TODO
        public int GetAreaIDfromZoneID(ZoneID zoneID) { return 0; }

        // TODO
        public void CreateReturnPoint() { }

        // TODO
        public void MoveTargetPos(Vector3 pos, float angle, Action onComplete) { }

        // TODO
        private void MoveUpdate(float deltaTime) { }

        // TODO
        public void SetMoveController() { }

        // TODO
        public void DeleteMoveController() { }

        // TODO
        public void CreateHyouta() { }

        // TODO
        public Vector2Int GetNpcRandomPos(ZoneID zoneID) { return Vector2Int.zero; }

        // TODO
        public void CreateNPC(ZoneID zoneID) { }

        // TODO
        public void DeleteNpc() { }

        // TODO
        public static int GetNPCTalkCount() { return 0; }

        // TODO
        public static void AddNPCTalkCount() { }

        // TODO
        private void D_GetNPCTalkCount() { }

        // TODO
        private void D_AddNPCTalkCount() { }

        // TODO
        private void D_ResetNPCTalkCount() { }

        // TODO
        public static void ResetNPCTalkCount() { }

        // TODO
        public void NPCTalk() { }

        // TODO
        public void DebugCheckWalls() { }

        // TODO
        private bool CheckAroundWalls() { return false; }

        // TODO
        private Vector3 GetAdjustPos() { return Vector3.zero; }

        // TODO
        private bool CheckResults(int[] index) { return false; }

        // TODO
        private void DebugOnZoneChange() { }

        // TODO
        public void CreateSecretBaseRandom(int stationIndex) { }

        // TODO
        public void DebugCreateTonarihori() { }

        // TODO
        private void CreateTonarihoriGrids(Vector2Int mainPoint) { }

        // TODO
        public void CreateOtherTonariHori(NetDigData netDigData)
        {
            // TODO
            void CreateDigPoint(int stationIndex, DigPos p) { }

            // TODO
            void Create(int stationIndex, DigPos p) { }

            // TODO
            bool CheckSamePosMySecretBase() { return default; }
        }

        // TODO
        private void ReplayTonarihoriEffect() { }

        // TODO
        public void DeleteTargetTonarihori(int stationIndex) { }

        // TODO
        private void SetLeaveCheckTarget(int stationIndex) { }

        // TODO
        private void ClearLeaveCheckTarget() { }

        private void OnLeaveOther(int LeavePlayerStationIndex)
        {
        	if (this.targetStationIndex == LeavePlayerStationIndex) {
        	  if (this.OnLeaveTargetPlayer != null) {
        	    this.OnLeaveTargetPlayer.Invoke();
        	  }
        	  ClearLeaveCheckTarget();
        	}
        }

        // TODO
        public void TEST() { }

        // TODO
        public void SAVE_POKE() { }

        // TODO
        public void LOAD_POKE() { }

        // TODO
        public bool AddKousekiCount(int num) { return false; }

        public void UpdateKousekiUI()
        {
        	if (this.miniMap != null) {
        	  this.miniMap.UpdateLightStoneCount();
        	}
        }

        // TODO
        public void StartKousekiBonus(float RemainTime = 300.0f) { }

        // TODO
        public void RemoveInputUpdate() { }

        // TODO
        public void AddInputUpdate() { }

        public enum NowZoneType : int
        {
            Way = 0,
            SecretBase = 1,
            Kakurega = 2,
        }

        private enum EntryType : int
        {
            FirstEnter = 0,
            NotZoneChange = 1,
            ZoneChange = 2,
            DigReturn = 3,
            SaveReturn = 4,
            _Error = 5,
        }

        public class DigData
        {
            private UgFieldManager mng;
            public bool PrevSceneisDigFossil;

            public List<DigPointModel> DigPoints { get => UgFieldManager.DigPoints; }
            public List<SecretBaseModel> SecretBases { get => UgFieldManager.Instance.SecretBases; }

            public DigData(UgFieldManager mng)
            {
                this.mng = mng;
            }
        }

        [Serializable]
        public class DigPointModel : MiniMapUIModelBase
        {
            public int StationIndex;
            public GameObject cube;
            public Transform EffectTra;
            public EffectInstance effIns;
            private bool isKirakiraNow;
            private static readonly Vector3[] directs =
            {
                new Vector3(0.0f,  0.0f, 1.0f),
                new Vector3(1.0f,  0.0f, 0.0f),
                new Vector3(-1.0f, 0.0f, 0.0f),
            };
            private static readonly Vector2Int[] offsets =
            {
                new Vector2Int(0,  1),
                new Vector2Int(1,  0),
                new Vector2Int(-1, 0),
            };

            public DigPointModel(int x, int y, int staionIndex)
            {
                gridPos = new Vector2Int(x, y);
            }

            // TODO
            public Vector2Int GetEffOffset() { return Vector2Int.zero; }

            // TODO
            public Vector3 GetPosition() { return Vector3.zero; }

            // TODO
            public void SetActive(bool isActive) { }

            // TODO
            public void Destroy() { }

            // TODO
            public void KiraKira(float startDelay) { }
        }

        public abstract class MiniMapUIModelBase
        {
            public Vector2Int gridPos;
            public Image image;
            public bool isFriends;

            // TODO
            public void ToOverAllSizeUI() { }

            // TODO
            public void ToAroundSizeUI() { }
        }

        [Serializable]
        public class SecretBaseModel : MiniMapUIModelBase
        {
            public int StationIndex;
            public GameObject go;
            public UgSecretBase data;

            public SecretBaseModel(UgSecretBase secretBase, bool isFriends, GameObject go, int stationIndex)
            {
                data = secretBase;
                gridPos = new Vector2Int(data.posX, data.posY);
                this.go = go;
                this.isFriends = isFriends;
                StationIndex = stationIndex;
            }

            // TODO
            public bool IsCollide() { return false; }
        }
    }
}