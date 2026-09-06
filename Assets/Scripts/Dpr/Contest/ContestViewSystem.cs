using Dpr.Battle.Logic;
using Dpr.Battle.View;
using Dpr.Battle.View.Objects;
using Dpr.Battle.View.Systems;
using Dpr.Message;
using Dpr.SequenceEditor;
using Pml;
using Pml.PokePara;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Contest
{
	public class ContestViewSystem : ISequenceViewSystem
	{
		private const float INVALID_COMMAND_OFFSET_END_TIME = 3.0f;

		private Dictionary<int, HashSet<ObjectEntity>> hashTabel = new Dictionary<int, HashSet<ObjectEntity>>();
		private SceneObjectManager objManager;
		private BattleViewSystem.SequenceSeq m_sequenceSeq;
		private BattleSequenceSystem m_iPtrSequenceSystem;
		private SequenceCameraSystem cameraSystem;
		private BTLV_ATTR_EFF_PARAM m_attrEffParam;
		private Dictionary<int, HashSet<BtlvEffectInstance>> m_uPtrParticleVectorHash = new Dictionary<int, HashSet<BtlvEffectInstance>>();
		private Stack<Tuple<int, uint, uint>> m_uPtrSoundPlayingIDHash = new Stack<Tuple<int, uint, uint>>();
		private BattleScreenObject m_iPtrScreenObject;
		private Func<bool> m_pComWaitFunc;
		private BTLV_WAZA_EFF_PARAM m_wazaParam = BTLV_WAZA_EFF_PARAM.Factory();
		private TaskManager m_iPtrTaskManager;
		private TaskManager m_iPtrTaskManagerLate;
		private TaskManager m_iPtrTaskManagerAlways;
		private Coroutine coroutine;
		private MessageMsgFile contestMsgFile;
		private int m_soundPlayingFinishWaitCount;
		private ViewSystemType currentViewSystemType;
		private Action<CommandNo, ContestViewSystem> onFindCommand;
		private Action<CommandNo, ContestViewSystem, Macro> onPerformCommand;
		private string seqFilePath = string.Empty;
		private bool m_seqKeepResource;
		private bool canOpenMsgWindowFlag = true;
		private bool ready;
		
		public bool IsReady { get => ready; }
		public bool IsLoaded { get => m_iPtrSequenceSystem != null && m_iPtrSequenceSystem.IsLoadedSequenceFile; }
		public bool IsPause { get => m_iPtrSequenceSystem == null || m_iPtrSequenceSystem.IsPause; }
		public ViewSystemType SystemType { get => currentViewSystemType; }
		public bool IsEnd { get => m_iPtrSequenceSystem.IsFinishSequence; }
		public float MaxTime { get => m_iPtrSequenceSystem.MaxTime; }
		
		// TODO
		public void CMD_ACT_WazaEffect_Start(MonsNo monsNo, WazaNo wazaNo, int formNo, PokeType type1, PokeType type2, SequenceCameraSystem cameraSystem, Action<CommandNo, ContestViewSystem> onFindCommand, Action<CommandNo, ContestViewSystem, Macro> onPerformCommand) { }
		
		// TODO
		public void CMD_ACT_ContestMain_Start(string path, SequenceCameraSystem cameraSystem, Action<CommandNo, ContestViewSystem> onFindCommand, Action<CommandNo, ContestViewSystem, Macro> onPerformCommand) { }
		
		// TODO
		private void SetupSequence(string path) { }
		
		// TODO
		private void CommonSettings(SequenceCameraSystem cameraSystem) { }
		
		// TODO
		private IEnumerator IE_SetupSequence() { return default; }
		
		// TODO
		public void UnloadAb() { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		public void Play() { }
		
		// TODO
		public void SetPause(bool pause) { }
		
		// TODO
		public void CMD_ACT_WazaEffect_Load(MonsNo monsNo, WazaNo wazaNo, int formNo, PokeType type1, PokeType type2) { }
		
		// TODO
		public void SetAudioListenerPositionUpdate(bool flag) { }
		
		public BattleScreenObject GetScreenObject() {
		    return m_iPtrScreenObject;
		}
		
		// TODO
		private void SetupWazaParam(WazaNo waza) { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateSuspendSequenceSystem() { }
		
		// TODO
		private void __UpdateSequence__() { }
		
		// TODO
		private bool __IsSuspendSequenceSystem__ { get; }
		
		// TODO
		public void OnLateUpdate(float deltaTime) { }
		
		// TODO
		private bool __WaitLoadSequence__() { return default; }
		
		public bool IsStencilEnable { get; set; }
		public float blurry { get; set; }
		
		// TODO
		public BTL_POKEPARAM GetBattlePokeParam(BtlvPos pos) { return default; }
		
		// TODO
		public byte GetBtlvPosToClientId(BtlvPos vpos) { return default; }
		
		// TODO
		public byte GetClientID() { return default; }
		
		// TODO
		public byte GetEnemyClientID(byte idx) { return default; }
		
		// TODO
		public MainModule GetMainModule() { return default; }
		
		public Dictionary<int, HashSet<ObjectEntity>> GetModelHashTable() {
		    return hashTabel;
		}
		
		public Dictionary<int, HashSet<BtlvEffectInstance>> GetParticleVectorHashTable() {
		    return m_uPtrParticleVectorHash;
		}
		
		public Stack<Tuple<int, uint, uint>> GetSoundPlayingIDHashTable() {
		    return m_uPtrSoundPlayingIDHash;
		}
		
		public TaskManager GetTaskManager() {
		    return m_iPtrTaskManager;
		}
		
		public TaskManager GetTaskManagerLate() {
		    return m_iPtrTaskManagerLate;
		}
		
		// TODO
		public ushort GetTrainerType(byte clientID) { return default; }
		
		// TODO
		public BTLV_WAZA_EFF_PARAM GetWazaParam() { return default; }
		
		// TODO
		public void SEQ_CMD_ResetDefaultCamera(int frame, SEQ_DEF_MOVETYPE moveType, SequenceCameraSystem system) { }
		
		// TODO
		public BTLV_WAZA_EFF_PARAM SetWazaParam(BTLV_WAZA_EFF_PARAM param) { return default; }
		
		// TODO
		public void CheckWazaDataPath_Particle(ref string path, int idx, bool isBallEffect, bool isCapture, bool isAttributeEffect, bool isStreamLineEffect) { }
		
		// TODO
		public BTLV_ATTR_EFF_PARAM GetAttrEffParam() { return default; }
		
		// TODO
		public string GetBallModelPath(int idx) { return default; }
		
		// TODO
		public string GetBttleWazaModelPath(string idx) { return default; }
		
		public SequenceCameraSystem GetCameraSystem() {
		    return cameraSystem;
		}
		
		// TODO
		public BattleCharacterSystem GetCharacterSystem() { return default; }
		
		// TODO
		public void GetDefaultPokePos(BtlvPos vPos, ref Vector3 pos, ref int deg, SEQ_DEF_DEFAULT_PLACEMENT placement = SEQ_DEF_DEFAULT_PLACEMENT.SEQ_DEF_DEFAULT_PLACEMENT_DEFAULT) { }
		
		// TODO
		public PartyDesc __GetPartySetupParam__(byte clientId) { return default; }
		
		// TODO
		public BOPokemon GetPokeModel(BtlvPos vPos) { return default; }
		
		// TODO
		public Size GetPokeSize(BattleViewSystem.BattleViewSide side, bool isGPoke = false) { return default; }
		
		// TODO
		public BattleViewCharacter GetTrainerModel(BtlvPos vPos) { return default; }
		
		// TODO
		public bool __IsCanChangePinch__() { return default; }
		
		// TODO
		public bool __IsReqCheckPinch__() { return default; }
		
		// TODO
		public void ResetAll() { }
		
		// TODO
		public void ResetPokemon(BtlvPos vPos, int frame, SEQ_DEF_MOVETYPE moveType, SEQ_DEF_DEFAULT_PLACEMENT placement = SEQ_DEF_DEFAULT_PLACEMENT.SEQ_DEF_DEFAULT_PLACEMENT_DEFAULT) { }
		
		// TODO
		public void ResetTrainer(BtlvPos vPos, bool isOrigin, SEQ_DEF_DEFAULT_PLACEMENT placement = SEQ_DEF_DEFAULT_PLACEMENT.SEQ_DEF_DEFAULT_PLACEMENT_DEFAULT) { }
		
		// TODO
		public void SeqComFunc_CalcPokeDir(Vector3 nowPos, BtlvPos trgPoke, SEQ_DEF_NODE trgNode, ref Vector3 retRot, bool isVertical) { }
		
		// TODO
		public void SeqComFunc_CalcPosDir(Vector3 nowPos, Vector3 trgPos, ref Vector3 retRot, bool isVertical) { }
		
		// TODO
		public void SeqComFunc_GetPokeFiledPos(ref Vector3 retPos, ref Vector3 retRot, BtlvPos plater, bool isAttack) { }
		
		// TODO
		public void SeqComFunc_GetPokeRelativePos(ref RELARIVE_POKE_OPTION opt, ref Vector3 pRetPos, ref Vector3 pRetRot, ref Vector3 pRetScale, bool isCameraAdjust) { }
		
		// TODO
		public void SeqComFunc_GetSpecialPos(SEQ_DEF_SPPOS trgType, ref Vector3 retPos, ref Vector3 retRot) { }
		
		// TODO
		public BtlvPos SeqComFunc_GetTargetCharaVPos(SEQ_DEF_TRAINER target, int index = 0) { return default; }
		
		// TODO
		public BattleViewCharacter SeqComFunc_GetTargetChara(SEQ_DEF_TRAINER trg, int idx = 0) { return default; }
		
		// TODO
		public BattleViewCharacter SeqComFunc_GetTargetChara(SEQ_DEF_TRAINER_ADD trg, int idx = 0) { return default; }
		
		public int SeqComFunc_GetTargetPokeNum(bool isCheck = true) {
		    return 0;
		}
		
		// TODO
		public BtlvPos SeqComFunc_GetTargetPokeSub(SEQ_DEF_POS target) { return default; }
		
		// TODO
		public BtlvPos SeqComFunc_GetTargetPoke_Org(int idx) { return default; }
		
		// TODO
		public BtlvPos SeqComFunc_GetTargetPoke(SEQ_DEF_POS target, int index = 0) { return default; }
		
		public bool SeqComFunc_IsFlipEffect(BtlvPos target, BtlvPos subTarget) {
		    return false;
		}
		
		// TODO
		public void SeqComFunc_MoveRelativePoke(ITranslationObject iPtrObj, int frame, RELARIVE_POKE_OPTION opt, bool isTrainer = false) { }
		
		// TODO
		public void SeqComFunc_MoveSpecialPos(ITranslationObject iPtrObj, int frame, SEQ_DEF_SPPOS trgType, Vector3 ofs, bool isRotate, bool isFlip) { }
		
		// TODO
		public void __SetCanChangePinch__(bool value) { }
		
		// TODO
		public void SetIsSoundPlayingFinishCheckInvalid(bool value) { }
		
		// TODO
		public void __SetReqCheckPinch__(bool value) { }
		
		// TODO
		public void SetSuspendSequenceFunc(SEQ_DEF_WAIT type) { }
		
		public BattleSequenceSystem GetSequenceSystem() {
		    return m_iPtrSequenceSystem;
		}
		
		// TODO
		public void __ClearSetWords__() { }
		
		// TODO
		public MessageTextParseDataModel __GetTextParseData__(string labelName) { return default; }
		
		// TODO
		public AContestPlayerData __GetPlayerData__(int index) { return default; }
		
		// TODO
		public AContestPlayerData __GetUserData_() { return default; }
		
		// TODO
		public bool CheckCanPlayCommand(CommandParam param) { return default; }
		
		// TODO
		private BtlvPos ConvertPokeTrgTovPos(int value) { return default; }
		
		public void FindContestCommand(Macro macro)
		{
			onFindCommand?.Invoke(macro.CommandNo, this);
		}
		
		// TODO
		public void PerformContestCommand(Macro macro) { }
		
		public bool CanOpenMsgWindow { get => canOpenMsgWindowFlag; }
		
		public void SetCanOpenMsgWindowFlag(bool flag) {
		    this.canOpenMsgWindowFlag = flag;
		}
		
		// TODO
		public void SetTerrainChipVisibility(bool disp) { }
		
		// TODO
		public void StartWeather(BtlWeather weather) { }
		
		// TODO
		public BattleWeatherSystem GetBattleWeatherSystem() { return default; }
		
		// TODO
		public BattleGroundEffectSystem GetBattleGroundEffectSystem() { return default; }
		
		// TODO
		public BtlvBallInfo SeqComFunc_GetEffectBallInfo(int idx) { return default; }

		public enum ViewSystemType : int
		{
			Main = 0,
			Waza = 1,
		}
	}
}