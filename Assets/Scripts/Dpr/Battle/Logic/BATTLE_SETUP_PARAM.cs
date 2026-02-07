using Dpr.BallDeco;
using Pml;
using Pml.PokePara;

namespace Dpr.Battle.Logic
{
    public class BATTLE_SETUP_PARAM
    {
        public BtlCompetitor competitor;
        public BtlRule rule;
        public RaidBattleParam raidBattleParam = new RaidBattleParam();
        public BTL_FIELD_SITUATION fieldSituation = new BTL_FIELD_SITUATION();
        public BattleEffectComponentData btlEffComponent = new BattleEffectComponentData();
        public EvolveSituation evolveSituation = new EvolveSituation();
        public BtlCommMode commMode;
        public BtlMultiMode multiMode;
        public byte commPos;
        public BtlRecordDataMode recordDataMode;
        public MiseaiData[] miseaiData = Arrays.InitializeWithDefaultInstances<MiseaiData>((int)BTL_CLIENT_ID.BTL_CLIENT_NUM);
        public int[] stations = new int[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        public bool isPlayerRatingDisplay;
        public bool isLiveRecSendEnable;
        public PokeParty[] party = new PokeParty[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        public PartyDesc[] partyDesc = Arrays.InitializeWithDefaultInstances<PartyDesc>((int)BTL_CLIENT_ID.BTL_CLIENT_NUM);
        public MyStatus[] playerStatus = new MyStatus[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        public ushort[] playerRating = new ushort[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        public CapsuleData[][] ballDecoDesc = RectangularArrays.RectangularDefaultArray<CapsuleData>((int)BTL_CLIENT_ID.BTL_CLIENT_NUM, DefineConstants.BTL_PARTY_MEMBER_MAX);
        public BSP_TRAINER_DATA[] tr_data = new BSP_TRAINER_DATA[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
        public bool bGakusyuSouti;
        public ushort LimitTimeGame;
        public ushort LimitTimeClient;
        public ushort LimitTimeCommand;
        public bool bEnableTimeStop;
        public SHOOTER_ITEM_BIT_WORK shooterBitWork = new SHOOTER_ITEM_BIT_WORK();
        public bool reduceHighLevelCaptureRate;
        public byte maxFollowPokeLevel;
        public byte captureLevelCap;
        public byte expLevelCap;
        public ushort commNetIDBit;
        public uint btl_status_flag;
        public uint wildPokeAiBitFlag;
        public float moneyRate;
        public byte forceQuitTurnCount;
        public bool bSkyBattle;
        public bool bSakasaBattle;
        public bool bMustCapture;
        public bool bNoGainBattle;
        public int safariBallNum;
        public bool bVoiceChat;
        public BATTLE_CONVENTION_INFO[] conventionInfo = Arrays.InitializeWithDefaultInstances<BATTLE_CONVENTION_INFO>(2);
        public int getMoney;
        public BtlResult result;
        public byte fairyGymResult;
        public bool honooGymResult_wonByPlayer;
        public byte capturedPokeIdx;
        public byte capturedClientID;
        public byte commServerVer;
        public int commError;
        public bool isDisplayedCommError;
        public unsafe byte* recBuffer;
        public uint recDataSize;
        public ulong recRandSeed;
        public BattleRecordHeader recHeader = new BattleRecordHeader();
        public BATTLE_KENTEI_RESULT kenteiResult = new BATTLE_KENTEI_RESULT();
        public bool cmdIllegalFlag;
        public bool recPlayCompleteFlag;
        public bool WifiBadNameFlag;
        public bool isDisconnectOccur;
        public bool isWatchMember;
        public bool[] fightPokeIndex = new bool[DefineConstants.BTL_PARTY_MEMBER_MAX];
        public bool[] turnedLvUpPokeIndex = new bool[DefineConstants.BTL_PARTY_MEMBER_MAX];
        public PokeResult[] pokeResult = Arrays.InitializeWithDefaultInstances<PokeResult>(DefineConstants.BTL_PARTY_MEMBER_MAX);
        public byte[][] party_state = RectangularArrays.RectangularDefaultArray<byte>((int)BTL_CLIENT_ID.BTL_CLIENT_NUM, DefineConstants.BTL_PARTY_MEMBER_MAX);
        public uint[] restHPRatio = new uint[5];
        public BATTLE_PGL_RECORD_SET PGL_Record = new BATTLE_PGL_RECORD_SET()
        {
            myParty = Arrays.InitializeWithDefaultInstances<BATTLE_PGL_RECORD>(DefineConstants.BTL_PARTY_MEMBER_MAX),
            enemysParty = Arrays.InitializeWithDefaultInstances<BATTLE_PGL_RECORD>(DefineConstants.BTL_PARTY_MEMBER_MAX),
        };
        public BATTLE_TVNAVI_DATA tvNaviData = new BATTLE_TVNAVI_DATA()
        {
            frontPoke = new ushort[2],
        };
        public PokeMemoryResult pokeMemoryResult = new PokeMemoryResult();

        public int throwBallNum { get; set; }

        public void Clear()
        {
            competitor = 0;
            rule = 0;
            commMode = 0;
            multiMode = 0;
            commPos = 0;
            recordDataMode = 0;
            isPlayerRatingDisplay = false;
            isLiveRecSendEnable = false;
            bGakusyuSouti = false;
            LimitTimeGame = 0;
            LimitTimeClient = 0;
            LimitTimeCommand = 0;
            bEnableTimeStop = false;
            reduceHighLevelCaptureRate = false;
            maxFollowPokeLevel = 0;
            captureLevelCap = 0;
            expLevelCap = 0;
            commNetIDBit = 0;
            btl_status_flag = 0;
            wildPokeAiBitFlag = 0;
            moneyRate = 0;
            forceQuitTurnCount = 0;
            bSkyBattle = false;
            bSakasaBattle = false;
            bMustCapture = false;
            bNoGainBattle = false;
            safariBallNum = 0;
            bVoiceChat = false;
            getMoney = 0;
            result = 0;
            fairyGymResult = 0;
            honooGymResult_wonByPlayer = false;
            capturedPokeIdx = 0;
            capturedClientID = 0;
            commServerVer = 0;
            commError = 0;
            isDisplayedCommError = false;
            recDataSize = 0;
            recRandSeed = 0;
            cmdIllegalFlag = false;
            recPlayCompleteFlag = false;
            WifiBadNameFlag = false;
            isDisconnectOccur = false;
            isWatchMember = false;
            throwBallNum = 0;
            for (int i = 0; i < (int)BTL_CLIENT_ID.BTL_CLIENT_NUM; i++)
            {
                stations[i] = 0;
                party[i] = null;
                playerStatus[i] = null;
                playerRating[i] = 0;
                tr_data[i] = null;
            }
            for (int i = 0; i < conventionInfo.Length; i++)
            {
                conventionInfo[i].Clear();
            }
            kenteiResult.Clear();
            tvNaviData.Clear();
            for (int i = 0; i < fightPokeIndex.Length; i++)
            {
                fightPokeIndex[i] = false;
                turnedLvUpPokeIndex[i] = false;
            }
            for (int i = 0; i < restHPRatio.Length; i++)
            {
                restHPRatio[i] = 0;
            }
        }
    }
}