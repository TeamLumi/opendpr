using Dpr.Battle.Logic;
using Dpr.SequenceEditor;
using Pml;
using Pml.PokePara;
using UnityEngine;
using XLSXContent;

namespace Dpr.Battle.View.Objects
{
	public sealed class BOPokemon : BattleViewCharacter
	{
		private const float MIGAWARI_SIZE_M = 1.5f;
		private const float MIGAWARI_SIZE_L = 2.0f;
		private const float DHIGUDA_STONE_SIZE = 0.2f;
		private const float DAGUTORIO_STONE_SIZE = 0.4f;
		private const float ANIM_SPEED_STATUS_ABNORMALITY = 0.5f;
		private const float ANIM_SPEED_STATUS_ABNORMALITY_KOORI = 0.0f;

		private BattlePokemonEntity _entity;
		private PokemonParam _param;
		private BattlePokemonEntity.AnimationState _lastPlayAnimationState;
		private MotionTimingData _motionTimingData;
		private BattleDataTable.SheetMotionReplaceData _motionReplaceData;
		private bool m_isPlayPinchSoundRTPC;
		private bool m_isPlayPinchSound;
		private ObjectEntity _iPtrMigawariObject;
		private ObjectEntity _iPtrDigudaStone;
		
		public BattlePokemonEntity Entity { get => this.GetComponentThis(ref _entity); }
		public PokemonParam Param { get => _param; }
		public bool IsEnableFloat { get; private set; }
		public bool IsVisibleDigudaStone { get; set; }
		public bool HitBackFlg { get; set; }
		public bool IsVisibleMigawari { get; set; }
		public ObjectEntity MigawariObject { get => _iPtrMigawariObject; }
		public bool IsVisibleTame { get; set; }
		public GState IsGChange { get => GState.NONE; }
		public bool IsDisp { get => m_isVisible && IsVisibleTame; }
		
		// TODO
		public void Initialize(BtlvPos vPos, PokemonParam param) { }
		
		private static int GetUniqueID(MonsNo monsNo, int formNo)
		{
			return formNo + monsNo * 100;
		}
		
		// TODO
		private void SetupAdjustHeight() { }
		
		// TODO
		public override void StartDelete() { }
		
		// TODO
		public override void OnUpdatePreJob(float deltaTime) { }
		
		// TODO
		protected override void UpdateVisible() { }
		
		// TODO
		public Size GetSize() { return default; }
		
		// TODO
		public LandingType GetPokeLandingType() { return default; }
		
		// TODO
		public LandingType GetPokeLandingEXType() { return default; }
		
		// TODO
		public MotionTimingData GetMotionTimingData() { return default; }
		
		// TODO
		public void SetMotionTimingData(MotionTimingData data) { }
		
		public float GetCamAdjustHeight()
		{
			return this.m_cameraAdjustHeight;
		}
		
		public float GetAdjustHeight()
		{
			return this.m_adjustHeight;
		}
		
		// TODO
		public PokeEffWeight CheckPokemonEffectWeight() { return default; }
		
		// TODO
		public void GetNodeBasePositionSequence(SEQ_DEF_NODE node, ref Vector3 pRetPos) { }
		
		// TODO
		public void GetNodePositionSequence(SEQ_DEF_NODE node, ref Vector3 pos) { }
		
		// TODO
		private bool GetNodeBaseMatrixSequenceCore(SEQ_DEF_NODE node, ref Vector3 pos) { return default; }
		
		// TODO
		public bool GetNodeJointModelSpaceMatrix(JointName jointName, ref Vector3 retPos) { return default; }
		
		// TODO
		public Transform GetNodeTransformSequence(SEQ_DEF_NODE node) { return default; }
		
		public BattlePokemonEntity.AnimationState GetLastPlayAnim()
		{
			return this._lastPlayAnimationState;
		}
		
		public BattlePokemonEntity.AnimationState CurrentAnimationState { get => Entity.CurrentAnimationState; }
		public float CurrentRemaingTime { get => Entity.GetAnimationPlayer().currentRemaingTime; }
		
		// TODO
		public BattlePokemonEntity.AnimationState CheckReplaceWazaAnimationState(BattlePokemonEntity.AnimationState state, WazaNo wazaNo) { return default; }
		
		// TODO
		public BattlePokemonEntity.AnimationState CheckReplaceAnimationState(BattlePokemonEntity.AnimationState state) { return default; }
		
		// TODO
		public void ChangeAnimStatePoke(BattlePokemonEntity.AnimationState state, float duration = 0.15f, float startTime = 0.0f) { }
		
		// TODO
		protected override void UpdateAnimSpeed() { }
		
		public void PostPokeVoice(JointName joint, string voiceName, VOICE_TYPE voiceType)
		{
			var uVar1 = new NotImplementedException();
		}
		
		// TODO
		private void PostEventAnimationSoundComponent(string eventName, JointName joint) { }
		
		// TODO
		public PokeVoiceParameter GetPokeVoiceParams(string voiceName, VOICE_TYPE voiceType) { return default; }
		
		public bool GetRTPC_IsPlayPinchSound()
		{
			return this.m_isPlayPinchSoundRTPC;
		}
		
		public void SetRTPC_IsPlayPinchSound(bool value)
		{
			this.m_isPlayPinchSoundRTPC = (value ? 1 : 0) & 1;
		}
		
		public bool GetIsPlayPinchSound()
		{
			return this.m_isPlayPinchSound;
		}
		
		public void SetIsPlayPinchSound(bool value)
		{
			this.m_isPlayPinchSound = (value ? 1 : 0) & 1;
		}
		
		// TODO
		public void SetEnableFloat(bool flg) { }
		
		// TODO
		public void SetVisibleDigudaStone(bool value) { }
		
		// TODO
		private void CreateDigudaStone() { }
		
		// TODO
		public void SetVisibleTame(bool value) { }
		
		// TODO
		public void SetVisibleMigawari(bool value) { }
		
		// TODO
		public bool IsLoadedMigawari() { return default; }
		
		// TODO
		private void CreateMigawari() { }
		
		public void DisableSleepEye(bool value)
		{
			this.m_disableSleepEye = (value ? 1 : 0) & 1;
		}
		
		// TODO
		public override void SetVisibleShadow(bool value) { }
	}
}