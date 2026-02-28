using DPData;
using Dpr.BallDeco;
using Dpr.Battle.Logic;
using Dpr.Battle.View;
using Dpr.Battle.View.Objects;
using Dpr.Battle.View.Systems;
using Dpr.SequenceEditor;
using Pml;
using Pml.PokePara;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

namespace Dpr.SealPreview
{
	public sealed class SealPreviewViewSystem : ISequenceViewSystem
	{
		private bool m_isFinalize;
		private BTLV_WAZA_EFF_PARAM m_wazaParam;
		private BattleViewSystem.SequenceSeq m_sequenceSeq;
		private bool m_seqKeepResource;
		private bool m_isStartMsgDisplay;
		private int m_wazaMsgFrame;
		private bool m_reqCheckPinch;
		private bool m_canChangePinch;
		private bool m_isSoundPlayingFinishCheckInvalid;
		private int m_soundPlayingFinishWaitCount;
		private string m_playingSeqFileNameHash;
		private BattleDataTable m_battleDataTable;
		private BattleDefaultPlacementData m_defaultPlacementData;
		private BtlvPos[] m_comTargetPoke = new BtlvPos[(int)BtlSide.BTL_SIDE_NUM];
        private BtlvPos[] m_comTargetDamage = new BtlvPos[BattleViewDefine.POKEMON_NUM];
        private BtlvPos[] m_comTargetTrainer = new BtlvPos[(int)BtlSide.BTL_SIDE_NUM];
        private BallId[] m_effectBallId = new BallId[BattleViewDefine.POKE_BALL_MAX_NUM];
		private BtlvBallInfo[] m_effectBallInfo = new BtlvBallInfo[BattleViewDefine.POKE_BALL_MAX_NUM];
		private Dictionary<int, HashSet<ObjectEntity>> m_uPtrModelHash;
		private Dictionary<int, HashSet<BtlvEffectInstance>> m_uPtrParticleVectorHash;
		private Stack<Tuple<int, uint, uint>> m_uPtrSoundPlayingIDHash;
		private BattleSequenceSystem m_iPtrSequenceSystem;
		private BattleCharacterSystem m_iPtrCharacterSystem;
		private SealPreviewCameraSystem m_iPtrCameraSystem;
		private BattleWeatherSystem m_iPtrWeatherSystem;
		private BattleGroundEffectSystem m_iPtrBattleGroundEffectSystem;
		private BattleStatusEffectObserverSystem m_iPtrStatusEffectObserverSystem;
		private Func<bool> m_pComWaitFunc;
		private TaskManager m_iPtrTaskManager;
		private TaskManager m_iPtrTaskManagerLate;
		private TaskManager m_iPtrTaskManagerAlways;
		private MainModule m_pMainModule;

        // TODO
        private bool IsSoundPlayingFinishCheckInvalid { get; }

        // TODO
        private bool IsAllTaskFinished { get; }

        // TODO
        public bool IsReady { get; }

        // TODO
        public bool IsPlayEnd { get; }

        public TaskManager GetTaskManagerAlways()
        {
        	return this.m_iPtrTaskManagerAlways;
        }

        public SealPreviewViewSystem(MainModule mainModule, BOCamera camera)
		{
			m_isFinalize = false;
			m_wazaParam = BTLV_WAZA_EFF_PARAM.Factory();
			m_iPtrCameraSystem = new SealPreviewCameraSystem(this, camera);

			m_uPtrModelHash = new Dictionary<int, HashSet<ObjectEntity>>(64); // TODO: Find constants for these?
            m_uPtrSoundPlayingIDHash = new Stack<Tuple<int, uint, uint>>(64);
			m_uPtrParticleVectorHash = new Dictionary<int, HashSet<BtlvEffectInstance>>(64);

			m_battleDataTable = BattleDataTableManager.Instance.BattleDataTable;
			m_defaultPlacementData = BattleDataTableManager.Instance.BattleDefaultPlacementData;

			m_iPtrSequenceSystem = new BattleSequenceSystem(this);
			m_iPtrTaskManager = new TaskManager(104); // TODO: Find a constant for this?
			m_iPtrTaskManagerLate = new TaskManager();
			m_iPtrTaskManagerAlways = new TaskManager();

			trainers = new BOTrainer[BattleViewDefine.TRAINER_NUM];
			trainerEntities = new BattleCharacterEntity[BattleViewDefine.TRAINER_NUM];

			pokemons = new BOPokemon[BattleViewDefine.POKEMON_NUM];
			pokemonEntities = new BattlePokemonEntity[BattleViewDefine.POKEMON_NUM];

			affixSealDatas = new AffixSealData[BattleViewDefine.POKEMON_NUM][];
			affixSealCounts = new int[BattleViewDefine.POKEMON_NUM];

			m_pMainModule = mainModule;
		}

        private BOTrainer[] trainers;
        private BattleCharacterEntity[] trainerEntities;

        // TODO
        public void SetTrainer(BtlvPos vPos, BOTrainer trainer, BattleCharacterEntity battleCharacterEntity) { }

        private BOPokemon[] pokemons;
        private BattlePokemonEntity[] pokemonEntities;

        // TODO
        public void SetPokemon(BtlvPos vPos, BOPokemon pokemon, BattlePokemonEntity battlePokemonEntity) { }

        private AffixSealData[][] affixSealDatas;
        private int[] affixSealCounts;

        // TODO
        public void SetSealEffectData(BtlvPos vPos, AffixSealData[] affixSealDatas, int affixSealCount) { }

        private List<BtlvEffectInstance> sealEffectInstances;

        public void RegisterSealEffectInstances(List<BtlvEffectInstance> instances)
        {
        	this.sealEffectInstances = instances;
        }

        private string setupIntroSequenceFilePath;
        private string playSequenceFilePath;

        // TODO
        public void Setup() { }

        private BtlRule btlRule;

        public void SetBattleRule(BtlRule btlRule)
        {
        	this.btlRule = (BtlRule)(btlRule);
        	SetupInrtoSequence();
        	SetupThrowBallSequence();
        }

        // TODO
        public bool GetSealEffectData(BtlvPos vPos, out AffixSealData[] affixSealDatas, out int affixSealCount)
		{
			affixSealDatas = default;
			affixSealCount = default;
			return default;
		}

        // TODO
        public void Dispose() { }

        // TODO
        private void SetupInrtoSequence() { }

        // TODO
        private void SetupThrowBallSequence() { }

        // TODO
        public IEnumerator SetupIntro() { return default; }

        // TODO
        public void Play() { }

        private bool isPause;

        // TODO
        public void SetPause(bool isPause) { }

        // TODO
        public void Play(string path, bool isKeepResource = false) { }

        public BattleSequenceSystem GetSequenceSystem()
        {
        	return this.m_iPtrSequenceSystem;
        }

        public BattleCharacterSystem GetCharacterSystem()
        {
        	return this.m_iPtrCharacterSystem;
        }

        // TODO
        public SequenceCameraSystem GetCameraSystem() { return default; }

        public BattleWeatherSystem GetBattleWeatherSystem()
        {
        	return this.m_iPtrWeatherSystem;
        }

        public BattleGroundEffectSystem GetBattleGroundEffectSystem()
        {
        	return this.m_iPtrBattleGroundEffectSystem;
        }

        public bool IsStencilEnable { get; set; }
        public float blurry { get; set; }

        private SealPreviewController _sealPreviewController;
		private BattleViewSystem.InitializeSequenceStateType _initializeSequenceState;
		private int _loadObjectCnt;
		private int _subSeq;
		
		// TODO
		public BTL_POKEPARAM GetBattlePokeParam(BtlvPos pos) { return default; }
		
		public MainModule GetMainModule()
		{
			return this.m_pMainModule;
		}
		
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
		
		public BTLV_WAZA_EFF_PARAM GetWazaParam()
		{
			var uVar1 = new NotImplementedException();
			return null;
		}
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		public void SEQ_CMD_ResetDefaultCamera(int frame, SEQ_DEF_MOVETYPE moveType, SequenceCameraSystem system) { }
		
		public BTLV_WAZA_EFF_PARAM SetWazaParam(BTLV_WAZA_EFF_PARAM param)
		{
			var uVar1 = new NotImplementedException();
			return null;
		}
		
		public void CheckWazaDataPath_Particle(ref string path, int idx, bool isBallEffect, bool isCapture, bool isAttributeEffect, bool isStreamLineEffect)
		{
			if (isBallEffect)
				path = m_battleDataTable.BallEffectData[(int)m_effectBallId[idx]].IntroEffectAssetbundleName;
			else if (isCapture)
                path = m_battleDataTable.BallEffectData[(int)m_effectBallId[idx]].CaptureEffectAssetbundleName;
		}
		
		private BallId __SeqComFunc_GetEffectBallId__(int idx)
		{
			if (idx < this.m_effectBallId.Length) {
			  return this.m_effectBallId + (int)idx[0];
			}
		}
		
		// TODO
		public BtlvBallInfo SeqComFunc_GetEffectBallInfo(int idx) { return default; }
		
		// TODO
		public string GetBallModelPath(int idx) { return default; }
		
		public string GetBttleWazaModelPath(string idx)
		{
			var uVar1 = new NotImplementedException();
			return default;
		}
		
		// TODO
		public void GetDefaultPokePos(BtlvPos vPos, ref Vector3 pos, ref int deg, SEQ_DEF_DEFAULT_PLACEMENT placement = SEQ_DEF_DEFAULT_PLACEMENT.SEQ_DEF_DEFAULT_PLACEMENT_DEFAULT) { }
		
		public PartyDesc __GetPartySetupParam__(byte clientId)
		{
			var uVar1 = new NotImplementedException();
			return null;
		}
		
		// TODO
		public BOPokemon GetPokeModel(BtlvPos vPos) { return default; }
		
		public Size GetPokeSize(BattleViewSystem.BattleViewSide side, bool isGPoke = false)
		{
			var uVar1 = new NotImplementedException();
			return (Size)0;
		}
		
		// TODO
		public BattleViewCharacter GetTrainerModel(BtlvPos vPos) { return default; }
		
		// TODO
		public void ResetAll() { }
		
		// TODO
		public void ResetPokemon(BtlvPos vPos, int frame, SEQ_DEF_MOVETYPE moveType, SEQ_DEF_DEFAULT_PLACEMENT placement = SEQ_DEF_DEFAULT_PLACEMENT.SEQ_DEF_DEFAULT_PLACEMENT_DEFAULT) { }
		
		// TODO
		public void ResetTrainer(BtlvPos vPos, bool isOrigin, SEQ_DEF_DEFAULT_PLACEMENT placement = SEQ_DEF_DEFAULT_PLACEMENT.SEQ_DEF_DEFAULT_PLACEMENT_DEFAULT) { }
		
		public void SeqComFunc_CalcPokeDir(Vector3 nowPos, BtlvPos trgPoke, SEQ_DEF_NODE trgNode, ref Vector3 retRot, bool isVertical)
		{
			var uVar1 = new NotImplementedException();
		}
		
		public void SeqComFunc_CalcPosDir(Vector3 nowPos, Vector3 trgPos, ref Vector3 retRot, bool isVertical)
		{
			var uVar1 = new NotImplementedException();
		}
		
		public void SeqComFunc_GetPokeFiledPos(ref Vector3 retPos, ref Vector3 retRot, BtlvPos plater, bool isAttack)
		{
			var uVar1 = new NotImplementedException();
		}
		
		// TODO
		public void SeqComFunc_GetPokeRelativePos(ref RELARIVE_POKE_OPTION opt, ref Vector3 pRetPos, ref Vector3 pRetRot, ref Vector3 pRetScale, bool isCameraAdjust) { }
		
		public void SeqComFunc_GetSpecialPos(SEQ_DEF_SPPOS trgType, ref Vector3 retPos, ref Vector3 retRot)
		{
			var uVar1 = new NotImplementedException();
		}
		
		// TODO
		public BtlvPos SeqComFunc_GetTargetCharaVPos(SEQ_DEF_TRAINER target, int index = 0) { return default; }
		
		// TODO
		public BattleViewCharacter SeqComFunc_GetTargetChara(SEQ_DEF_TRAINER trg, int idx = 0) { return default; }
		
		// TODO
		public BattleViewCharacter SeqComFunc_GetTargetChara(SEQ_DEF_TRAINER_ADD trg, int idx = 0) { return default; }
		
		public int SeqComFunc_GetTargetPokeNum(bool isCheck = true)
		{
			var uVar1 = new NotImplementedException();
			return 0;
		}
		
		// TODO
		public BtlvPos SeqComFunc_GetTargetPokeSub(SEQ_DEF_POS target) { return default; }
		
		public BtlvPos SeqComFunc_GetTargetPoke_Org(int idx)
		{
			var uVar1 = new NotImplementedException();
			return (BtlvPos)0;
		}
		
		// TODO
		public BtlvPos SeqComFunc_GetTargetPoke(SEQ_DEF_POS target, int index = 0) { return default; }
		
		public bool SeqComFunc_IsFlipEffect(BtlvPos target, BtlvPos subTarget)
		{
			return false;
		}
		
		// TODO
		public void SeqComFunc_MoveRelativePoke(ITranslationObject iPtrObj, int frame, RELARIVE_POKE_OPTION opt, bool isTrainer = false) { }
		
		public void SeqComFunc_MoveSpecialPos(ITranslationObject iPtrObj, int frame, SEQ_DEF_SPPOS trgType, Vector3 ofs, bool isRotate, bool isFlip)
		{
			var uVar1 = new NotImplementedException();
		}
		
		public void __SetCanChangePinch__(bool value)
		{
			var uVar1 = new NotImplementedException();
		}
		
		public void SetIsSoundPlayingFinishCheckInvalid(bool value)
		{
			this.m_isSoundPlayingFinishCheckInvalid = (value ? 1 : 0) & 1;
		}
		
		public void __SetReqCheckPinch__(bool value)
		{
			var uVar1 = new NotImplementedException();
		}
		
		public void SetTerrainChipVisibility(bool disp)
		{
			var uVar1 = new NotImplementedException();
		}
		
		public void StartWeather(BtlWeather weather)
		{
			var uVar1 = new NotImplementedException();
		}
		
		// TODO
		public void SetSuspendSequenceFunc(SEQ_DEF_WAIT type) { }
		
		private bool __SeqComWaitFunc_Message__()
		{
			return true;
		}
		
		private bool __SeqComWaitFunc_LoadPoke__()
		{
			return true;
		}
		
		private bool __SeqComWaitFunc_SelectMessage__()
		{
			return true;
		}
		
		private bool __SeqComWaitFunc_UIBag__()
		{
			return true;
		}
		
		private bool __SeqComWaitFunc_UITrainerName__()
		{
			return true;
		}
		
		private bool __SeqComWaitFunc_UIFog__()
		{
			return true;
		}
		
		// TODO
		public bool CheckCanPlayCommand(CommandParam param) { return default; }
		
		// TODO
		public void OnLateUpdate(float deltaTime) { }
		
		// TODO
		private void __UpdateSequence__() { }
		
		// TODO
		private void __UpdateSuspendSequenceSystem__() { }
		
		// TODO
		private void __GetDefaultTrainerPos__(BtlvPos vPos, ref Vector3 pPos, ref int pDeg, bool isOrigin, SEQ_DEF_DEFAULT_PLACEMENT placement) { }
		
		// TODO
		private void __StartLoadSequence__() { }
		
		// TODO
		private void __SaveFog__() { }
		
		private bool __WaitSequenceResource__()
		{
			return true;
		}
		
		private bool __WaitLoadSequence__()
		{
			this.m_iPtrSequenceSystem.IsPreLoaded;
			return false;
		}
		
		// TODO
		private bool __IsWazaMsgCommandSeq__() { return default; }
		
		// TODO
		private void __StartWazaMsgCommand__() { }
		
		private bool __WaitWazaMsgCommand__()
		{
			this.m_wazaMsgFrame = this.m_wazaMsgFrame - 1;
			return this.m_wazaMsgFrame - 1 >> 0x1f;
		}
		
		// TODO
		private bool __IsSuspendSequenceSystem__ { get; }
		
		// TODO
		private void __SetComTargetReset__() { }
		
		// TODO
		public BtlRule GetBattleRule() { return default; }
		
		// TODO
		private BallId __GetCaptureBall__(BtlvPos vPos) { return default; }
		
		// TODO
		private BtlvBallInfo __GetBallInfo__(BtlvPos vPos) { return default; }
		
		public bool IsFriendExist()
		{
			return false;
		}
		
		// TODO
		private void __PlaySequenceCore__(string path, bool keepResource = false) { }
		
		// TODO
		private SealPreviewSetupParam GetSetupParam() { return default; }
		
		public SealPreviewViewSystem(in SealPreviewController controller)
		{
			_sealPreviewController = controller;
			_initializeSequenceState = BattleViewSystem.InitializeSequenceStateType.Unregistered;
			_loadObjectCnt = 0;

            pokemons = new BOPokemon[BattleViewDefine.POKEMON_NUM];
            trainers = new BOTrainer[BattleViewDefine.TRAINER_NUM];

			Sequencer.update += OnUpdate;
			Sequencer.lateUpdate += OnLateUpdate;
        }
		
		// TODO
		public void UnInitialize() { }
		
		// TODO
		public bool Initialize() { return default; }
		
		// TODO
		private IEnumerator SetupBackground() { return default; }
		
		// TODO
		private void LoadTrainerModel(MYSTATUS status, BtlvPos vPos) { }
		
		// TODO
		private void LoadPokemonModel(PokemonParam param, BtlvPos vPos) { }
		
		// TODO
		private void StartGround() { }
		
		// TODO
		public void CMD_StartSetup_ThrowSelf() { }
		
		// TODO
		public bool CMD_WaitStartSetup_ThrowSelf() { return default; }
		
		// TODO
		private void PlaySequenceCore(string path, bool isKeepResource = false) { }
		
		private bool __WaitSequence__()
		{
			return (int)this.m_sequenceSeq == 0;
		}
	}
}