using Dpr.Message;
using Dpr.Trainer;
using Pml;
using System.Runtime.InteropServices;
using System.Text;

namespace Dpr.Battle.Logic
{
    public class BattleStr
    {
        private static readonly string[] MSBT_MSG_FILES = new string[]
        {
            "ss_btl_std",     "ss_btl_set",         "ss_btl_attack", "ss_btl_talk",
            "dp_trainer_msg", "dp_trainer_msg_sub", "ss_btl_app",    "ss_btl_pokelist",
        };
        private static BattleStr s_Instance;
        private static bool isInitializedOwner = false;
        private MainModule mainModule;
        private POKECON pokeCon;
        private MessageMsgFile[] _msgFiles = new MessageMsgFile[(int)MsgSrcID.MAX];
        private uint clientID;
        private bool fIgnoreFormat;
        private bool fForceTrueName;

        private const int MAX_TAG_NUM = 20;
        private const int BUFIDX_POKE_1ST = 0;
        private const int BUFIDX_POKE_2ND = 1;
        private const int BUFIDX_TRAINER_NAME_1ST = 10;
        private const int BUFIDX_TRAINER_NAME_2ND = 11;

        private static readonly ushort[] USE_TRMSG_SUB_TABLE = new ushort[]
        {
            (ushort)TrainerID.AROMA_06,     (ushort)TrainerID.ARTIST_03,
            (ushort)TrainerID.BREEDERW_04,  (ushort)TrainerID.CAMERAMAN_03,
            (ushort)TrainerID.COLLECTOR_10, (ushort)TrainerID.DAISUKIW_05,
            (ushort)TrainerID.GAMBLER_03,   (ushort)TrainerID.GENTLE_03,
            (ushort)TrainerID.MADAM_03,     (ushort)TrainerID.MINI_13,
            (ushort)TrainerID.PRINCE_06,    (ushort)TrainerID.PRINCESS_04,
            (ushort)TrainerID.REPORTER_02,  (ushort)TrainerID.SCHOOLB_06,
            (ushort)TrainerID.SCIENTIST_08, (ushort)TrainerID.SISTER_10,
            (ushort)TrainerID.SISTER_11,    (ushort)TrainerID.VETERAN_11,
            (ushort)TrainerID.SCHOOLB_04,   (ushort)TrainerID.SCHOOLG_04,
        };
        private StringBuilder checkTagSb = new StringBuilder();
        private static StringBuilder textSb = new StringBuilder();

        public static BattleStr Instance { get => s_Instance; }

        // TODO
        private MessageMsgFile GetMsgFile(MsgSrcID id) { return null; }

        // TODO
        public static void InitSystem(MainModule mainModule, byte playerClientID, POKECON pokeCon) { }

        // TODO
        public static void QuitSystem() { }

        public BattleStr(MainModule mainModule, byte playerClientID, POKECON pokeCon)
        {
            this.mainModule = mainModule;
            this.pokeCon = pokeCon;

            clientID = playerClientID;
            fIgnoreFormat = mainModule == null;
            fForceTrueName = false;
        }

        // TODO
        public void SetupMsgFiles() { }

        // TODO
        private void UnSetupMsgFiles() { }

        // TODO
        private bool register_PokeNickname(MessageMsgFile msgFile, byte pokeID, int bufID, bool isTruth = false) { return false; }

        // TODO
        private void register_PokeName(MessageMsgFile msgFile, byte pokeID, byte bufID) { }

        // TODO
        private void register_TrainerType(MessageMsgFile msgFile, byte bufIdx, byte clientID) { }

        // TODO
        private bool register_TrainerName(MessageMsgFile msgFile, byte bufIdx, byte clientID) { return false; }

        // TODO
        private void register_TrainerTypeAndTrainerName(MessageMsgFile msgFile, byte typeAndNameBufIdx, byte trainerNameBufIdx, byte clientID) { }

        // TODO
        private void register_ItemName(MessageMsgFile msgFile, byte bufIdx, ItemNo itemNo) { }

        // TODO
        public MessageTextParseDataModel MakeStringStd(int strID, int[] inArgs) { return null; }

        // TODO
        public MessageTextParseDataModel MakeStringStdWithArgArray(int strID, int[] args) { return null; }

        // TODO
        private MessageTextParseDataModel mkstr_std_simple(MessageMsgFile msgFile, int strID, int[] args) { return null; }

        // TODO
        private MessageTextParseDataModel mkstr_std_side(MessageMsgFile msgFile, int strID, int[] args) { return null; }

        private MessageTextParseDataModel mkstr_std_cheer(MessageMsgFile msgFile, int strID, int[] args)
        {
        	if ((int)strID - 399U < 2) {
        	  if (args.Length == 0) {
        	  }
        	  if (args[0] != (uint)this.mainModule.m_myClientID) {
        	    var uVar2 = 0x207;
        	    if ((int)strID != 399) {
        	      uVar2 = 0x208;
        	    }
        	    strID = (ulong)uVar2;
        	  }
        	}
        	mkstr_std_simple(this,msgFile,strID);
        	return null;
        }

        // TODO
        private MessageTextParseDataModel mkstr_std_useitem(MessageMsgFile msgFile, int strID, int[] args) { return null; }

        // TODO
        private MessageTextParseDataModel mkstr_std_gshockwave_rank(MessageMsgFile msgFile, int strID, int[] args) { return null; }

        // TODO
        private void registerWords(MessageMsgFile msgFile, MessageTextParseDataModel textData, int[] args) { }

        // TODO
        public MessageTextParseDataModel MakeStringSet(int strID, int[] args) { return null; }

        // TODO
        private MessageTextParseDataModel mkstr_set_auto(MessageMsgFile msgFile, int strID, int[] args) { return null; }

        // TODO
        private MessageTextParseDataModel mkstr_set_default(MessageMsgFile msgFile, int defaultStrID, int[] args) { return null; }

        // TODO
        private MessageTextParseDataModel mkstr_set_poke2(MessageMsgFile msgFile, int strID, int[] args) { return null; }

        // TODO
        private MessageTextParseDataModel mkstr_set_rankup(MessageMsgFile msgFile, int strID, int[] args) { return null; }

        // TODO
        private MessageTextParseDataModel mkstr_set_rankup_at_once(MessageMsgFile msgFile, int strID, int[] args) { return null; }

        // TODO
        private MessageTextParseDataModel mkstr_set_rankup_item(MessageMsgFile msgFile, int strID, int[] args) { return null; }

        // TODO
        private MessageTextParseDataModel mkstr_set_rank_limit(MessageMsgFile msgFile, int strID, int[] args) { return null; }

        // TODO
        private SetStrFormat get_strFormat(byte pokeID) { return SetStrFormat.MINE; }

        // TODO
        private bool isIgnoreStrFormat(byte pokeID) { return false; }

        // TODO
        private int get_setStrID(byte pokeID, int defaultStrID) { return 0; }

        // TODO
        private int get_setStrID_Poke2(byte pokeID1, byte pokeID2, int defaultStrID) { return 0; }

        // TODO
        private int get_setPtnStrID(byte pokeID, int originStrID, byte ptnNum) { return 0; }

        // TODO
        private int searchPokeTagCount(MessageMsgFile msgFile, int strID) { return 0; }

        // TODO
        public MessageTextParseDataModel MakeStringWaza(byte pokeID, ushort waza) { return null; }

        // TODO
        private MessageTextParseDataModel makeStringWaza(byte pokeID, ushort waza) { return null; }

        // TODO
        public MessageTextParseDataModel MakeStringTrainer(TrainerID trainerID, string msgLabel) { return null; }

        // TODO
        private MsgSrcID GetTrainerMsgSrcFromTrainerID(TrainerID trainerID) { return MsgSrcID.STD; }

        // TODO
        public MessageTextParseDataModel MakeStringTalk(int strID, int[] args) { return null; }

        // TODO
        public MessageTextParseDataModel MakeStringTalk_simple(int strID) { return null; }

        // TODO
        private MessageTextParseDataModel formatTextMessage(MessageMsgFile msgFile, MessageTextParseDataModel textData) { return null; }

        // TODO
        private void CheckTagSet(MessageMsgFile msgFile, MessageTextParseDataModel textData, int strID) { }

        // TODO
        private bool getTextDataModel(MessageMsgFile msgFile, int strID, out MessageTextParseDataModel outTextData)
        {
            outTextData = null;
            return false;
        }

        // TODO
        private MsgSrcID GetMsgSrcID(MessageMsgFile msgFile) { return MsgSrcID.STD; }

        // TODO
        public static string MakeText(MessageTextParseDataModel textData) { return null; }

        // TODO
        public string GetFormatUIText(string label, [Optional] MessageMsgFile msgFile) { return null; }

        // TODO
        public string GetFormatUIText(string label, MsgSrcID srcId) { return null; }

        // TODO
        public string GetFormatUIPokeName(string label, byte pokeID, bool isTruth = false, byte bufID = 0) { return null; }

        // TODO
        public string GetFormatUITrainerName(string label, byte clientID, byte bufID = 0) { return null; }

        // TODO
        public static string GetMonsName(MonsNo monsNo) { return null; }

        // TODO
        public static string GetWazaName(WazaNo wazaNo) { return null; }

        // TODO
        public static string GetTokuseiName(TokuseiNo tokuseiNo) { return null; }

        // TODO
        public static string GetItemName(ItemNo itemNo) { return null; }

        // TODO
        public static string GetWazaInfo(WazaNo wazaNo) { return null; }

        // TODO
        public static string GetTokuseiInfo(TokuseiNo tokuseiNo) { return null; }

        public enum MsgSrcID : int
        {
            STD = 0,
            SET = 1,
            ATK = 2,
            TALK = 3,
            TRMSG = 4,
            TRMSG_SUB = 5,
            APP = 6,
            POKELIST = 7,
            MAX = 8,
        }

        private enum SetStrFormat : int
        {
            MINE = 0,
            WILD = 1,
            ENEMY = 2,
            TRAINER = 3,
            MAX = 4,
        }
    }
}