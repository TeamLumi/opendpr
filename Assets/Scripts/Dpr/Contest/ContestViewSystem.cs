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
		internal bool ready;
		
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
		
		public BattleScreenObject GetScreenObject()
		{
			return this.m_iPtrScreenObject;
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
		
		private bool __WaitLoadSequence__()
		{
			this.m_iPtrSequenceSystem.IsPreLoaded;
			return false;
		}
		
		public bool IsStencilEnable { get; set; }
		public float blurry { get; set; }
		
		// TODO
		public BTL_POKEPARAM GetBattlePokeParam(BtlvPos pos) { return default; }
		
		public byte GetBtlvPosToClientId(BtlvPos vpos)
		{
			var uVar1 = new NotImplementedException();
			return 0;
		}
		
		public byte GetClientID()
		{
			var uVar1 = new NotImplementedException();
			return 0;
		}
		
		public byte GetEnemyClientID(byte idx)
		{
			var uVar1 = new NotImplementedException();
			return 0;
		}
		
		public MainModule GetMainModule()
		{
			var uVar1 = new NotImplementedException();
			return null;
		}
		
		// TODO
		public Dictionary<int, HashSet<ObjectEntity>> GetModelHashTable() { return default; }
		
		// TODO
		public Dictionary<int, HashSet<BtlvEffectInstance>> GetParticleVectorHashTable() { return default; }
		
		// TODO
		public Stack<Tuple<int, uint, uint>> GetSoundPlayingIDHashTable() { return default; }
		
		public TaskManager GetTaskManager()
		{
			return this.m_iPtrTaskManager;
		}
		
		public TaskManager GetTaskManagerLate()
		{
			return this.m_iPtrTaskManagerLate;
		}
		
		public ushort GetTrainerType(byte clientID)
		{
			var uVar1 = new NotImplementedException();
			return 0;
		}
		
		// TODO
		public BTLV_WAZA_EFF_PARAM GetWazaParam() { return default; }
		
		// TODO
		public void SEQ_CMD_ResetDefaultCamera(int frame, SEQ_DEF_MOVETYPE moveType, SequenceCameraSystem system) { }
		
		// TODO
		public BTLV_WAZA_EFF_PARAM SetWazaParam(BTLV_WAZA_EFF_PARAM param) { return default; }
		
		// TODO
		public void CheckWazaDataPath_Particle(ref string path, int idx, bool isBallEffect, bool isCapture, bool isAttributeEffect, bool isStreamLineEffect) { }
		
		public BTLV_ATTR_EFF_PARAM GetAttrEffParam()
		{
			return this.m_attrEffParam;
		}
		
		// TODO
		public string GetBallModelPath(int idx) { return default; }
		
		// TODO
		public string GetBttleWazaModelPath(string idx) { return default; }
		
		public SequenceCameraSystem GetCameraSystem()
		{
			return this.cameraSystem;
		}
		
		public BattleCharacterSystem GetCharacterSystem()
		{
			var uVar1 = new NotImplementedException();
			return null;
		}
		
		// TODO
		public void GetDefaultPokePos(BtlvPos vPos, ref Vector3 pos, ref int deg, SEQ_DEF_DEFAULT_PLACEMENT placement = SEQ_DEF_DEFAULT_PLACEMENT.SEQ_DEF_DEFAULT_PLACEMENT_DEFAULT) { }
		
		public PartyDesc __GetPartySetupParam__(byte clientId)
		{
			var uVar1 = new NotImplementedException();
			return null;
		}
		
		public BOPokemon GetPokeModel(BtlvPos vPos)
		{
			if ((int)this.currentViewSystemType != 0) {
			  this.objManager.GetUserWazaModelPokemon();
			}
			this.objManager.GetPokemonByPosID(vPos);
			return null;
		}
		
		public Size GetPokeSize(BattleViewSystem.BattleViewSide side, bool isGPoke = false)
		{
			var uVar1 = new NotImplementedException();
			return (Size)0;
		}
		
		public BattleViewCharacter GetTrainerModel(BtlvPos vPos)
		{
			this.objManager.GetTrainerByPosID(vPos);
			return null;
		}
		
		public bool __IsCanChangePinch__()
		{
			var uVar1 = new NotImplementedException();
			return false;
		}
		
		public bool __IsReqCheckPinch__()
		{
			var uVar1 = new NotImplementedException();
			return false;
		}
		
		public void ResetAll()
		{
			var uVar1 = new NotImplementedException();
		}
		
		// TODO
		public void ResetPokemon(BtlvPos vPos, int frame, SEQ_DEF_MOVETYPE moveType, SEQ_DEF_DEFAULT_PLACEMENT placement = SEQ_DEF_DEFAULT_PLACEMENT.SEQ_DEF_DEFAULT_PLACEMENT_DEFAULT) { }
		
		// TODO
		public void ResetTrainer(BtlvPos vPos, bool isOrigin, SEQ_DEF_DEFAULT_PLACEMENT placement = SEQ_DEF_DEFAULT_PLACEMENT.SEQ_DEF_DEFAULT_PLACEMENT_DEFAULT) { }
		
		// TODO
		public void SeqComFunc_CalcPokeDir(Vector3 nowPos, BtlvPos trgPoke, SEQ_DEF_NODE trgNode, ref Vector3 retRot, bool isVertical) { }
		
		// TODO
		public void SeqComFunc_CalcPosDir(Vector3 nowPos, Vector3 trgPos, ref Vector3 retRot, bool isVertical) { }
		
		public void SeqComFunc_GetPokeFiledPos(ref Vector3 retPos, ref Vector3 retRot, BtlvPos plater, bool isAttack)
		{
			var uVar1 = new NotImplementedException();
		}
		
		// TODO
		public void SeqComFunc_GetPokeRelativePos(ref RELARIVE_POKE_OPTION opt, ref Vector3 pRetPos, ref Vector3 pRetRot, ref Vector3 pRetScale, bool isCameraAdjust) { }
		
		// TODO
		public void SeqComFunc_GetSpecialPos(SEQ_DEF_SPPOS trgType, ref Vector3 retPos, ref Vector3 retRot) { }
		
		public BtlvPos SeqComFunc_GetTargetCharaVPos(SEQ_DEF_TRAINER target, int index = 0)
		{
			if (2 < index - 1U) {
			  index = 0;
			}
			return index;
		}
		
		// TODO
		public BattleViewCharacter SeqComFunc_GetTargetChara(SEQ_DEF_TRAINER trg, int idx = 0) { return default; }
		
		// TODO
		public BattleViewCharacter SeqComFunc_GetTargetChara(SEQ_DEF_TRAINER_ADD trg, int idx = 0) { return default; }
		
		public int SeqComFunc_GetTargetPokeNum(bool isCheck = true)
		{
			return 0;
		}
		
		public BtlvPos SeqComFunc_GetTargetPokeSub(SEQ_DEF_POS target)
		{
			if ((int)this.currentViewSystemType == 1) {
			  return this.objManager.userIndex;
			}
			if (2 < (int)target - 1U) {
			  target = (SEQ_DEF_POS)0;
			}
			return target;
		}
		
		public BtlvPos SeqComFunc_GetTargetPoke_Org(int idx)
		{
			var uVar1 = new NotImplementedException();
			return (BtlvPos)0;
		}
		
		public BtlvPos SeqComFunc_GetTargetPoke(SEQ_DEF_POS target, int index = 0)
		{
			if ((int)this.currentViewSystemType == 1) {
			  return this.objManager.userIndex;
			}
			if (2 < (int)target - 1U) {
			  target = (SEQ_DEF_POS)0;
			}
			return target;
		}
		
		public bool SeqComFunc_IsFlipEffect(BtlvPos target, BtlvPos subTarget)
		{
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
		
		public void __SetReqCheckPinch__(bool value)
		{
			var uVar1 = new NotImplementedException();
		}
		
		public void SetSuspendSequenceFunc(SEQ_DEF_WAIT type)
		{
			var uVar1 = new NotImplementedException();
		}
		
		public BattleSequenceSystem GetSequenceSystem()
		{
			return this.m_iPtrSequenceSystem;
		}
		
		public void __ClearSetWords__()
		{
			this.contestMsgFile.ClearWordParam();
		}
		
		public MessageTextParseDataModel __GetTextParseData__(string labelName)
		{
			if (this.contestMsgFile.GetTextDataModel(labelName) != 0) {
			  MessageTextParseDataModel.ApplyFormat(this.contestMsgFile.GetTextDataModel(labelName),0);
			}
			return this.contestMsgFile.GetTextDataModel(labelName);
		}
		
		public AContestPlayerData __GetPlayerData__(int index)
		{
			if ((int)this.currentViewSystemType != 0) {
			  this.objManager.GetUserPlayerData();
			}
			this.objManager.GetPlayerDataByPosID(index);
			return null;
		}
		
		public AContestPlayerData __GetUserData_()
		{
			this.objManager.GetUserPlayerData();
			return null;
		}
		
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
		
		public void SetCanOpenMsgWindowFlag(bool flag)
		{
			this.canOpenMsgWindowFlag = (flag ? 1 : 0) & 1;
		}
		
		// TODO
		public void SetTerrainChipVisibility(bool disp) { }
		
		public void StartWeather(BtlWeather weather)
		{
			var uVar1 = new NotImplementedException();
		}
		
		public BattleWeatherSystem GetBattleWeatherSystem()
		{
			var uVar1 = new NotImplementedException();
			return null;
		}
		
		public BattleGroundEffectSystem GetBattleGroundEffectSystem()
		{
			var uVar1 = new NotImplementedException();
			return null;
		}
		
		// TODO
		public BtlvBallInfo SeqComFunc_GetEffectBallInfo(int idx) { return default; }

		public enum ViewSystemType : int
		{
			Main = 0,
			Waza = 1,
		}
	}
}