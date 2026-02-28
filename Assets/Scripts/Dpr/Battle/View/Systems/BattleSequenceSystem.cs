using Audio;
using Dpr.Battle.Logic;
using Dpr.Battle.View.Objects;
using Dpr.Contest;
using Dpr.Message;
using Dpr.Sequence;
using Dpr.SequenceEditor;
using Effect;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using XLSXContent;

namespace Dpr.Battle.View.Systems
{
	public sealed class BattleSequenceSystem : SequenceSystem
	{
		public const int ADD_FIXED_FRAME = 1;
		public const float SEQ_COM_REJECT_FOV_VALUE = 0.0f;
		public const int DEFAULT_IMMEDIATELY_FRAME = 0;
		public const int NOT_UPDATE_FOV_VALUE = 0;
		public const int DEFAULT_MOVE_RATE = 100;
		public const int TARGET_ELEM_NUM = 3;
		public const int DEFAULT_DISP_LEAST_TARGET_NUM = 1;
		public const int GAUGE_ANM_DEFAULT_CNT = 20;
		public const float HIT_BACK_LENGTH = 0.6f;
		public const int HIT_BACK_BACK_FRAME_CNT = 3;
		public const int HIT_BACK_RETURN_FRAME_CNT = 11;
		public const int HIT_BACK_NOT_DEFAULT_CAMERA_BACK_FRAME_CNT = 6;
		public const int MESSAGE_DISP_STD_FRIEND_SHIP_CLOSE_VALUE = 100;
		public const int SEQ_COM_OPTION_MULTI = 1;
		public const int FADE_DEFAULT_SYNC = 2;
		public const int DISP_MSG_WINDOW_WAIT_CNT = 10;
		public const int MAX_PRELOAD_NUM = 64;
		public const int DEFAULT_TARGET_INDEX = 0;
		public const int RELEASE_GROUP_NO = -1;
		public const float DEFAULT_MOTION_SPEED = 1.0f;
		public const float OBJECT_OSCILLATION_OFFSET = 360.0f;

		public static readonly Tuple<float, float> ROTATION_ADJUST = new Tuple<float, float>(180.0f, 360.0f);

		public const int CAMERA_SET_NEAR_ELEM = 0;
		public const int CAMERA_SET_FAR_ELEM = 1;
		public const int CAMERA_SET_FOV_ELEM = 2;

		private ISequenceViewSystem _ISequenceViewSystem;
		private bool _isPlayWaitCamera;
		private VectorHash<int, ObjectEntity> _uPtrModelHash;
		private VectorHash<int, BtlvEffectInstance> _uPtrParticleVectorHash;
		private VectorHash<int, BtlvSound> _uPtrSoundHash;
		private List<CommandParam> _removeCommands = new List<CommandParam>();
		private List<EffectManager.LoadParam> _effectLoadParams = new List<EffectManager.LoadParam>();
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraMovePosition(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraMovePosition(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraMoveRelativePoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraReset(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraReset(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraResetFieldAll(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraResetFieldAll(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraMoveRelativeTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraMoveSpecialPos(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraRotateTrg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraRotatePos(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraRotatePosPoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraShake(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraTwist(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_PRE_FUNC_DEF_CameraAnimationPoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraAnimationPoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_PRE_FUNC_DEF_CameraAnimationPosition(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraAnimationPosition(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_PRE_FUNC_DEF_CameraAnimationTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraAnimationTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraAnimationDoubleIntro(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_PRE_FUNC_DEF_CameraAnimationSpecialPos(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraAnimationSpecialPos(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraAnimationEnd(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraAnimationRotate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraAnimationScale(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraAnimationChangeSpeed(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraCheckGroundFlg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_CameraNearFarFovSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_LabelCamera(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraMoveRelativeCameraSp(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraMoveRelativeTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraMoveSpecialPos(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraRotateTrg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraRotatePos(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraRotatePosPoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraShake(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraTwist(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_PRE_FUNC_DEF_CameraAnimationPoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraAnimationPoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraAnimationPosition(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_PRE_FUNC_DEF_CameraAnimationPosition(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraAnimationTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_PRE_FUNC_DEF_CameraAnimationTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraAnimationDoubleIntro(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraAnimationSpecialPos(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_PRE_FUNC_DEF_CameraAnimationSpecialPos(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraAnimationEnd(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraAnimationRotate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraAnimationScale(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraAnimationChangeSpeed(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraCheckGroundFlg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraNearFarFovSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SetDOFSensorScale(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprDispTrainerReflection(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_LabelCluster(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ClusterCreate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ClusterCreateEffect(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ClusterMovePosition(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ClusterMoveRelativePoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ClusterMoveSpecialPos(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ClusterScale(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ClusterRotate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ClusterRotatePoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ClusterSpeedDiffuse(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ClusterSpeedDir(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ClusterAccelGravity(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ClusterStartScale(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ClusterStartRotate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ClusterAnimeScale(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ClusterAnimeRotate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ClusterSetRefrect(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ClusterSetSpawnTime(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ClusterSetChild(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private static int CALC_FRAME(CommandParam param) { return default; }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DummyLabel(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_LabelBelugaSound(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_BelugaSoundPlaySe(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_BelugaSoundPlaySeVersion(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_BelugaSoundAddEvent(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_BelugaSoundLoadBank(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_BelugaSoundPlayVoice(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SoundBelugaMovePosition(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SoundBelugaMoveRelativePoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SoundBelugaMoveSpecialPos(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SoundBelugaFollowPoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SoundBelugaFollowObj(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SoundBelugaAutoCameraRotate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_LabelVibration(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_VibrationPlay(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_VibrationLoad(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_LabelSpecial(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialAllReset(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_MessageDispStd(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_MessageDispSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_MessageDispTalk(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_MessageDispSelect(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_MessageHide(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_MessageWazaStart(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialQuizResult(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialWaitSequence(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialSyncDemoFade(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialChangeWeather(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialChangePokemon(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialTameVisible(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialMigawariVisible(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialMigawariVisibleZenryoku(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_PRE_FUNC_DEF_SpecialChainAttakDefine(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialChainAttakDefine(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialChangeReferencePokemon(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialChangePokemonFromSimpleParam(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialFieldEffectCreate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialDeleteCamera(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialDeleteParticle(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialDeleteModel(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialDeleteModelAnime(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialDeleteKisekaeAnime(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialFesTrainerSetup(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_MessageDispSFes(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialLoadTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialDeleteTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialAutoPilotSetEnable(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialAutoPilotTrigger(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialTutorialUISelect(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialTutorialUIBag(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialCheckHitCameraAABBFlg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialRenderPathVisible(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialPokemonRenderVisible(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialTrainerRenderVisible(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialObjectRenderVisible(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialSetTimeZone(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SpecialDynamicResolution(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_LabelRotom(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_RotomStartEvent(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_RotomStartMessage(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_RotomDelete(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_LabelOtherModel(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_PRE_FUNC_DEF_OtherModelCreate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_OtherModelCreate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_OtherModelMovePosition(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_OtherModelScaleNode(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_OtherModelRotatePoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_OtherModelVisible(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_OtherModelMotionState(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_OtherModelFollowMode(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_CameraMoveRelativeOtherModel(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleMoveRelativeOtherModel(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleFollowOtherModel(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelMoveRelativeOtherModel(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelFollowOtherModelNodeName(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_BugFixLabel(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_VsDemoDisp(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffShadowBox(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonDisableSleepEye(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_LabelDisp(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_GaugeDisp(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_GaugeDispAll(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_GaugeDamage(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_BallBarDisp(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_HitBack(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerNameUI(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_UIFogSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprPokemonMoveReset(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprPokemonMoveResetAll(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprPokemonMotionIndex(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprPokemonUndiscoveredSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprPokemonVisibleOther(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprPokemonRateMotion(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprPokemonWaitBEnable(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprTrainerMoveReset(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprTrainerMoveResetAll(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprTrainerChangeMotionIndex(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprTrainerChangeMotionThrowBall(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprTrainerScale(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprCameraMovePosition(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprCameraRotate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprCameraLookAtPokemon(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprCameraLookAtTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprCameraLookAtPath(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprCameraGroundCheckFlg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprCameraRotationFreeze(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprCameraMovePositionBezier(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprCameraMoveRelativeTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprCameraMoveRelativeModel(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_DprCameraAnimationTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_DprCameraAnimation(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void SEQ_CAMERA_FUNC_DEF_DprSetTargetPos(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprParticleHide(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprParticleMoveRelativeModel(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprParticleFollowModel(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprParticleMultiplyColorSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprParticleCreateSeal(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprCutSceneTrainerParticleCreate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SWQ_FINC_DEF_DprParticleMoveRelativeTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SWQ_FINC_DEF_DprParticleFollowTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprModelAnimationPlayIndex(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprModelFollowModel(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprModelFollowModelMove(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprModelAttachTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprModelParticlePlay(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprModelParticleStop(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_LabelSound(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SoundPostEvent(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SoundSetState(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SoundPostTrigger(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SoundSetSwitch(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SoundSetRTPC(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SoundLoadBank(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SoundFinishCheckInvalid(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SoundPokePinchFlg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_LabelSound3D(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_PRE_FUNC_DEF_Sound3DCreate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_Sound3DCreate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_Sound3DDelete(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_Sound3DPostEvent(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_Sound3DPostTrigger(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_Sound3DSetSwitch(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_Sound3DSetRTPC(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_Sound3DMovePosition(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_Sound3DMoveSpecialPos(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_Sound3DMoveRelativePoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_Sound3DMoveRelativeTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_Sound3DFollowModel(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_Sound3DFollowPoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_Sound3DAttachTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_Sound3DPlayVoice(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_Sound3DPlayPokeVoice(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_Sound3DPlayPokeVoiceObject(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_LabelDispUI(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DispUIBallBar(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_LabelDprEffectSp(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DispEffectSpBackgroundTranslate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DispEffectDispBackGroundTrg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DispEffectDispBackGroundAll(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DispEffectSpEnvironmentLightDir(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DispEffectSpEnvironmentCharacterColorSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DispEffectSpEnvironmentPokemonColorSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DispCloudShadow(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_DprMessageDispTrainerTalk(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_UniQualitySettingsShadow(SequenceFile pSequenceFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_LabelEffectSp(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffSpBackColFlg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffSpBackColSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffDispBg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffBackGroundLightDirection(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffBackGroundLightColor(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffBackGroundChangeAnimState(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffBackGroundTrgChangeAnimState(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffSpFadeIn(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffSpFadeOut(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffLightDirection(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffCharaLightDirection(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffCharaLightEnv(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffCharaLightFile(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffPokeLightDirection(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_LightDirectionControl(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffGlareControl(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffRadialBlurFlg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffRadialBlurSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffFeedbackEffectFlg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffFeedbackEffectSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffLensDistortionFlg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffLensDistortionSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffStencilBufferEnable(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffStencilBufferDisable(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleColorChange(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleShaderParam(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_RaidWallGaugeVisible(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_RaidWallGaugeUpdate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_PRE_FUNC_DEF_SplitScreenEnable(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_SplitScreenEnable(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffColorCorrectionFlg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffColorCorrectionSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffMagnificationFlg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffMagnificationSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffColorVignetteFlg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffColorVignetteSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffFogFlg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffFogSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffFixParamSetVector(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffFixParamRemoveVector(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffFixParamSetFloat(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffFixParamRemoveFloat(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffFixParamSetBool(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffFixParamRemoveBool(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffFixParamSaveVector(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffFixParamSaveFloat(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffFixParamSaveBool(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffLightShaftFlg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffLightShaftSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffLightGhostFlg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffLightGhostSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffDepthOfFieldFlg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffDepthOfFieldSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffCascadeLevelSetModel(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_EffShadowBoxSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_LabelModel(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_PRE_FUNC_DEF_ModelCreate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelCreate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_PRE_FUNC_DEF_ModelCreateBall(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelCreateBall(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_PRE_FUNC_DEF_ModelCreateGBall(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelCreateGBall(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelDelete(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelMovePosition(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelMoveRelativePoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelMoveRelativeTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelMoveSpecialPos(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelScale(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelRotate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelRotatePoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelRotateTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelRotateOffset(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelLengthScale(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelVisible(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelFollowModel(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelFollowPoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelFollowPokeNodeName(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelFollowTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelAttachTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelSetAutoRotate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelAutoCameraRotate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelSetConstantColor(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelLightDir(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelSetVectorParam(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelSetFloatParam(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelSetBoolParam(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelSetAnimation(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelSetAnimationConfig(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelAnimationStop(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelSetAnimationSpeed(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelCahngeAnimationState(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelReplaceTexture(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelReplaceTextureTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelSpMoveReset(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ModelSpMoveShake(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_LabelParticle(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_PRE_FUNC_DEF_ParticleCreate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleCreate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleStop(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleDelete(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleMovePosition(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleMoveRelativePoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleMoveRelativeTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleMoveSpecialPos(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleMoveRelativeModel(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleMoveRelativeParticle(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleScale(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleRotate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleRotatePoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleRotateTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleRotateOffset(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleLengthScale(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleFollowModel(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleFollowPoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleFollowPokeNodeName(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleFollowTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleSetAutoRotate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticlCameraAutoRotate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleLightDir(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleSpMoveReset(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ParticleSpMoveShake(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_LabelPokemon(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonMovePosition(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonMoveRelativePoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonMoveRelativeTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonMoveReset(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonMoveResetAll(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonScale(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonScaleNode(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonRotate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonRotatePoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonRotateSpecialPos(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonRotateOrder(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonRotateNode(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonVisible(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonVisibleOther(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonVisibleAll(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonVisibleShadow(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonMotion(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonMotionState(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonMotionStateBool(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonMotionStateInt(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonMotionStopResource(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonAttackMotion(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonSetMotionSpeed(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonIntroMotion(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonHappyMotion(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonEdgeEnable(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonShaderCol(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonShaderFullPower(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonFollowMode(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonSpMoveReset(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonSpMoveShake(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonSetOriginScale(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonSetEnableFloat(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonRareEffect(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonLookAt(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonSetEye(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_GPokemonEffectVisible(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_GPokemonIntroMotion(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_GPokemonFieldEffect(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_GPokemonSetLookAtPosition(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonSetAnimationConfig(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemontRevertAnimationConfige(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonChangeAnimationConfig(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PokemonReplaceAnimationConfig(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PostEffectDepthOfFieldFlg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PostEffectDepthOfFieldSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PostEffectColorGradingFlg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PostEffectColorGradingSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PostEffectRadialBlurFlg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_PostEffectRadialBlurSet(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_LabelTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerMove(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerMoveRelativePoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerMoveRelativeTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerMoveReset(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerMoveResetAll(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerRotate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerDisp(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerDispAll(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerDispOther(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerDispShadow(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerChangeMotion(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerChangeMotionInt(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerChangeMotionBool(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerChangeMotionResource(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerChangeMotionKisekae(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerChangeMotionSpeed(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerSetMotionFrame(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerEdgeEnable(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerSetAnimationConfig(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerRevertAnimationConfige(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_TrainerSetEyeBlinkFlg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		public BattleSequenceSystem(ISequenceViewSystem system)
		{
			_ISequenceViewSystem = system;
			_isPlayWaitCamera = false;
			_uPtrModelHash = new VectorHash<int, ObjectEntity>(MAX_PRELOAD_NUM);
			_uPtrParticleVectorHash = new VectorHash<int, BtlvEffectInstance>(0);
			_uPtrSoundHash = new VectorHash<int, BtlvSound>(0);
		}
		
		// TODO
		public override void UnInitialize() { }
		
		// TODO
		public override void LoadSequence(string path, bool isWaitCamera = false) { }
		
		// TODO
		public void LoadSequence(string path, Action onLoaded, bool isWaitCamera = false) { }
		
		// TODO
		public void LoadSequenceForWaitCamera(string path) { }
		
		// TODO
		public void SetupSequence() { }
		
		// TODO
		public void StartPreLoad() { }
		
		// TODO
		public void SetupPreLoad() { }
		
		// TODO
		public override void SetPause(bool value) { }
		
		// TODO
		public override void Stop() { }
		
		protected override void OnUpdate(float deltaTime, int step = 1)
		{
			OnUpdateCore(deltaTime,step,1);
		}
		
		protected override void OnLateUpdate(float deltaTime, int step)
		{
			OnUpdateCore(deltaTime,step);
		}
		
		// TODO
		private void OnUpdateCore(float deltaTime, int step, bool isUpdate) { }
		
		// TODO
		protected override void OnComplete() { }
		
		// TODO
		private bool CheckCanPlayCommand(SequenceFile file, CommandParam param, bool isSkip) { return default; }
		
		// TODO
		public override void CommandCallback(SequenceFile file, CommandParam param, bool isSkip)
		{
			if (!CheckCanPlayCommand(file, param, false))
				return;

			if (isSkip)
			{
				// This variable is assigned to but nothing is done with it.
                Action<SequenceFile, ISequenceViewSystem, CommandParam> action = null;
                switch (param.CommandNo)
                {
                    case CommandNo.DprParticleCreateSeal:
						PreloadParticleSeal(file, _ISequenceViewSystem, param);
						break;

					case CommandNo.ModelCreateBall:
						PreloadModelBall(file, _ISequenceViewSystem, param);
                        action = BTL_SEQ_FUNC_DEF_ModelCreateBall;
						break;

					case CommandNo.ContestHensin:
					case CommandNo.SpecialMigawariVisible:
					case CommandNo.ContestCaptureScene:
						if (_ISequenceViewSystem != null && _ISequenceViewSystem is ContestViewSystem)
							((ContestViewSystem)_ISequenceViewSystem).FindContestCommand(param.Macro);
                        break;

                    case CommandNo.SubCameraAnimationTrainer:
                    case CommandNo.DprCameraAnimationTrainer:
                    case CommandNo.CameraAnimationTrainer:
                        PreloadCameraAnimationTrainer(file, _ISequenceViewSystem, param);
                        break;

                    case CommandNo.DprParticleCreateCutSceneTrainer:
                        PreloadParticleCutSceneTrainer(file, _ISequenceViewSystem, param);
						action = BTL_SEQ_FUNC_DEF_DprCutSceneTrainerParticleCreate;
                        break;

                    case CommandNo.DprCameraAnimation:
                    case CommandNo.SubCameraAnimationSpecialPos:
                    case CommandNo.SubCameraAnimationPoke:
                    case CommandNo.CameraAnimationPosition:
                    case CommandNo.SubCameraAnimationPosition:
                    case CommandNo.CameraAnimationPoke:
                    case CommandNo.CameraAnimationSpecialPos:
                        PreloadCameraAnimation(file, _ISequenceViewSystem, param);
                        break;

                    case CommandNo.ModelCreate:
                        PreloadModel(file, _ISequenceViewSystem, param);
                        break;

                    case CommandNo.ParticleCreate:
                        PreloadParticle(file, _ISequenceViewSystem, param);
						action = BTL_SEQ_PRE_FUNC_DEF_ParticleCreate;
                        break;

                    case CommandNo.SoundLoadBank:
                        PreloadSoundBank(file, _ISequenceViewSystem, param);
                        break;

                    case CommandNo.PokemonAttackMotion:
                    case CommandNo.ContestUserPokemonAttackMotion:
                        CheckAttackMotionTimming(file, _ISequenceViewSystem, param);
                        break;

                    case CommandNo.SpecialFieldEffectCreate:
                        PreloadGroundParticle(file, _ISequenceViewSystem, param);
                        break;

                    case CommandNo.SpecialChainAttakDefine:
                        CheckSpecialChainAttakDefine(file, _ISequenceViewSystem, param);
                        break;
                }
            }
			else
			{
                if (param.IsAlreadyCalled)
                    return;

                Action<SequenceFile, ISequenceViewSystem, CommandParam> action = null;
                switch (param.CommandNo)
                {
                    case CommandNo.ModelCreateGBall:
                        action = BTL_SEQ_FUNC_DEF_ModelCreateGBall;
                        break;

                    case CommandNo.DispEffectSpEnvironmentPokemonColorSet:
                        action = BTL_SEQ_FUNC_DEF_DispEffectSpEnvironmentPokemonColorSet;
                        break;

                    case CommandNo.DprModelParticleStop:
                        action = BTL_SEQ_FUNC_DEF_DprModelParticleStop;
                        break;

                    case CommandNo.SpecialRenderPathVisible:
                        action = BTL_SEQ_FUNC_DEF_SpecialRenderPathVisible;
                        break;

					// TODO: more cases
                }

                if (action == null)
                    return;

                param.IsAlreadyCalled = true;
                action.Invoke(file, _ISequenceViewSystem, param);
            }
		}
		
		// TODO
		public override void CommandCallbackLate(SequenceFile file, CommandParam param, bool isSkip) { }
		
		// TODO
		private void CheckAttackMotionTimming(SequenceFile file, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CheckSpecialChainAttakDefine(SequenceFile file, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void PreloadModel(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void PreloadModelBall(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void PreloadModelGBall(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }

		private void PreloadParticle(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param)
		{
			if (param.Macro == null)
				return;

			if (param.Macro is ParticleCreate macro)
			{
				var effData = EffectManager.Instance.dbEffects.BattleEffectData;
				var path = macro.file;

                pViewSystem.CheckWazaDataPath_Particle(ref path, macro.index, macro.isBallEffect, macro.isCapture, macro.isAttrEffect, macro.isStreamLineEffect);
				if (BattleViewAssetManager.CachedEffectData.Any(x => x.Item1 == path))
				{
					var cachedEff = BattleViewAssetManager.CachedEffectData.Find(x => x.Item1 == path);
					if (cachedEff.Item2.referencedCount != 0)
						return;

					BattleViewAssetManager.CachedEffectData.Remove(cachedEff);
                }

				var assetPath = IsAttributeEffect(macro) ? path : BattleViewDefine.Path.GetFXPath(path);

				var eff = Array.Find(effData, x => x.AssetBundleName == assetPath);

                if (eff != null)
				{
					eff.AssetBundleName = eff.AssetBundleName.ToLower();
					_preLoadCoroutines.Add(Sequencer.Start(EffectManager.Instance.OpLoad(new EffectManager.LoadParam[] { eff }, (effectData, isAllLoaded) =>
					{
						BattleViewAssetManager.CachedEffectData.Add(new Tuple<string, EffectData>(path, effectData));
                    })));
				}
            }
		}
		
		// TODO
		private void PreloadParticleCutSceneTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void PreloadParticleSeal(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param)
		{

		}
		
		// TODO
		private void PreloadModelAnimationConfig(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void PreloadCameraAnimation(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void PreloadCameraAnimationTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void PreloadSoundBank(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private IEnumerator LoadSoundBank(string bankName, Action<AudioData> onLoaded) { return default; }
		
		// TODO
		private void PreloadGroundParticle(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void PreloadMaskTexture(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void PreloadPokemonAnimationConfig(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void PreloadPokemonAnimationConfigReplace(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void PreloadTrainerAnimationConfig(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void PreloadGPokemonIntro(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		private void PreloadPokemonIntro(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param)
		{
			// Empty
		}
		
		// TODO
		private void PreloadVibration(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void PreloadOtherModel(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		public VectorHash<int, ObjectEntity> GetModelHashTable() { return default; }
		
		// TODO
		public VectorHash<int, BtlvEffectInstance> GetParticleHashTable() { return default; }
		
		// TODO
		private VectorHash<int, BtlvSound> GetSoundHashTable() { return default; }
		
		// TODO
		public void DeleteAllVector() { }
		
		// TODO
		public static void SetVectorSelectElem(ref Vector3 retVec, ref Vector3 vec, bool[] enableFlags) { }
		
		// TODO
		public static int GetWildEncountMsg(ISequenceViewSystem pViewSys, BTL_POKEPARAM pDefBpp, int msgId) { return default; }
		
		// TODO
		private static string GetEffectToRangeEffectPath(string path) { return default; }
		
		// TODO
		public SequenceCameraSystem GetCameraSystem() { return default; }
		
		private static bool IsAttributeEffect(ParticleCreate macro)
		{
			return macro.isAttrEffect || macro.isStreamLineEffect;
		}
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_PokemonActive(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_ContestPokemonMotionIndex(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_ContestPokemonMovePosition(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_PokemonMoveRelativePoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_PokemonIntroMotion(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_PokemonSetMotionSpeed(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_ContestPokemonMovePositionRelativeStage(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_PokemonRotate(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_PokemonScale(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_PokemonSpMoveShake(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_ModelCreateBall(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_ContestModelAttachTrainer(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private JointName GetJointName(JointName jointName, TrainerTable.SheetTrainerType trainerType) { return default; }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_ContestModelAnimationPlayIndex(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void BTL_SEQ_FUNC_DEF_ContestModelScale(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_ShowMsg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_ShowOpeningMsg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_ShowIntroductionMsg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_ShowWazaAppealMsg(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void OpenMsgWindow(MessageTextParseDataModel dataModel) { }
		
		private void CNT_SEQ_FUNC_DEF_CloseMessage(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param)
		{
			var uVar1 = 0.IsOpen;
			if ((uVar1 & 1) != 0) {
			  MsgWindowManager.CloseMsg(0);
			}
		}
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_SwitchMonitor(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_EmitBalloutFx(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_EmitHeart(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_CameraMoveRelativePoke(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_CameraMoveRelativeStage(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_ContestLaunchUserWaza(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void FindContestCommand(ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_HideDanceUI(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_ContestCaptureScene(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_ContestHensin(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
		
		// TODO
		private void CNT_SEQ_FUNC_DEF_ContestPlaySE(SequenceFile pSeqFile, ISequenceViewSystem pViewSystem, CommandParam param) { }
	}
}