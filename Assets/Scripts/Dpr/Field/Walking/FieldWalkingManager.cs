using DG.Tweening;
using Dpr.Trainer;
using Pml.PokePara;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

namespace Dpr.Field.Walking
{
    public class FieldWalkingManager : WalkingAIManager
    {
        public static bool DebugMode;
        public static TalkState talkState = TalkState.None;
        public AreaID prevArea = AreaID.NOTHING;

        public bool isLoaded { get => prevArea == AreaID.NOTHING; }
        public PokemonParam PartnerPokeParam { get; private set; }

        public string PartnerNPC_ObjectName = "";
        public static Dictionary<int, string> PartnerNPC_Dic = new Dictionary<int, string>()
        {
            { (int)TrainerID.MUSHI_01,   "R201_RIVAL" },
            { (int)TrainerID.MUSHI_02,   "L01_RIVAL" },
            { (int)TrainerID.BTFIVE1_01, "PAIR_D03R0101_SEVEN1" },
            { (int)TrainerID.BTFIVE2_01, "PAIR_D24R0105_SEVEN2" },
            { (int)TrainerID.BTFIVE3_01, "PAIR_D09R0104_SEVEN4" },
            { (int)TrainerID.BTFIVE4_01, "PAIR_D16R0102_SEVEN4" },
            { (int)TrainerID.BTFIVE5_01, "PAIR_D21R0101_SEVEN5" },
        };
        public static Dictionary<string, string> PartnerNameToLabel = new Dictionary<string, string>()
        {
            { "PAIR_D03R0101_SEVEN1", "DLP_SPEAKERS_NAME_024" },
            { "PAIR_D24R0105_SEVEN2", "DLP_SPEAKERS_NAME_068" },
            { "PAIR_D09R0104_SEVEN4", "DLP_SPEAKERS_NAME_059" },
            { "PAIR_D16R0102_SEVEN4", "DLP_SPEAKERS_NAME_063" },
            { "PAIR_D21R0101_SEVEN5", "DLP_SPEAKERS_NAME_030" },
        };

        public Vector3 EntryPoint { get; private set; }

        private Dictionary<int, Object> PokeAssets = new Dictionary<int, Object>();
        private WalkingCharacterController Controller;
        public FieldPokeTalkModel pokeTalkModel;
        private bool isCancel;
        private bool isForceEnter;
        private List<FieldWalkingPokeTalk.SheetSheet1> talkList;
        private FieldWalkingKinomiTable kinomiTable;
        private List<FieldWalkingKinomiSeikakuTable.SheetSheet1> seikakuTable;
        public bool isEvent;
        public bool isBattleRetrurnCreate;
        private Tween deleteTween;
        public Tweener ChangePos;

        // TODO
        public WalkingCharacterController GetPartnerPokeController() { return null; }

        // TODO
        public bool IsCanTalk() { return false; }

        // TODO
        public void NPCToPartner()
        {
            // TODO
            IEnumerator NpcSearch() { return null; }
        }

        // TODO
        public IEnumerator LoadMD() { return null; }

        // TODO
        public void SetPartnerNpcName(string npcName) { }

        // TODO
        public bool SetPartnerNpcName(TrainerID id) { return false; }

        // TODO
        public void SetPartnerNameToLabel(int index) { }

        // TODO
        public void TurearukiWarp() { }

        // TODO
        public void SetPartnerPoke(PokemonParam poke) { }

        // TODO
        public void UpdatePartnerPokeIndex() { }

        // TODO
        public bool IsPokeParaOK(PokemonParam pokepara) { return false; }

        // TODO
        private int GetTurearukiIndex() { return 0; }

        // TODO
        public void LoadPartnerPoke() { }

        // TODO
        public void SetEntryPoint(Vector3 pos) { }

        // TODO
        public void CreateTurearuki() { }

        // TODO
        public void DeleteTurearuki() { }

        // TODO
        public IEnumerator CreatePartner(bool isQuiet = false, bool isFormChange = false, bool isAnimeStateReset = false) { return null; }

        // TODO
        public override void Destroy(bool isDestroyGameObject = false) { }

        // TODO
        public void CheckPartnerPokeChange(PokemonParam param, bool isDelete) { }

        // TODO
        public bool BtlCheckPartnerPokeChangeFrom(int memberIndex, PokemonParam param) { return false; }

        // TODO
        public void BtlSetPartnerPokeChangeFrom(PokemonParam param) { }

        // TODO
        public void PokeUpdate(float deltaTime) { }

        // TODO
        public void DeleteTurearukiUpdate() { }

        // TODO
        public void ChangePositionNPC() { }

        // TODO
        public bool IsCanTurearuki(PokemonParam param) { return false; }

        // TODO
        public bool IsCanTurearukiState() { return false; }

        // TODO
        public bool IsCanTurearukiMap() { return false; }

        // TODO
        public bool IsCanTurearukiPoke(PokemonParam param) { return false; }

        public void Turearuki_Talk()
        {
        	if (this.pokeTalkModel != null) {
        	  FieldPokeTalkModel.StartTalk();
        	}
        }

        public static void ResetMonohiroiTime()
        {
        	FlagWork.SetWork(0x1a0,0);
        }

        public enum TalkState : int
        {
            None = 0,
            Talking = 1,
            TalkEnd = 2,
            DontTalk = 3,
        }
    }
}