using Dpr.Battle.Logic;
using Dpr.Battle.View;
using Dpr.Battle.View.Objects;
using SmartPoint.AssetAssistant;
using System;
using UnityEngine;
using UnityEngine.U2D;

namespace Dpr.Contest
{
	public class SceneObjectManager : SingletonMonoBehaviour<SceneObjectManager>
	{
		[SerializeField]
		private SpriteAtlas sceneGraphicTextAtlas;

		private readonly string MAINCAMERA_TAG = "MainCamera";
		private readonly string UNTAGGED_NAME = "Untagged";

		private ContestSettings contestSetting;
		private ContestPlayerEntity[] playerEntityArray;
		private Sprite[] uiPlayerNumSprArray;
		private Sprite[] uiPlayerPlateSprArray;
		private StageModelObject stageModelObj;
		private StageEffect stageFx = new StageEffect();
		private EnvironmentController envController;
		private Transform pokemonContent;
		private Transform mainCameraTransform;
		private BOCamera mainCamera;
		private BOCamera wazaCamera;
		private Camera wazaRenderCamera;
		private Camera wazaCompositorCamera;
		private ContestViewSystem contestViewSystem;
		private ContestViewSystem wazaViewSystem;
		private ContestHeartEmitter heartEmitter = new ContestHeartEmitter();
		private BOPokemon specialWazaModelPtr;
		private BOPokemon tempWazaModelPtr;
		private SpriteAtlas sceneUISpriteAtlas;
		private float initCompositorDepth;
		private int userIndex;
		private bool bLoadedStage;
		private bool bLoadedCharacter;
		private bool bPlayingWazaAnim;
		
		// TODO
		public void SetScriptableObject(ContestSettings contestSetting) { }
		
		// TODO
		public void Initialize(Transform cluster) { }
		
		// TODO
		private void OnDestroy() { }
		
		// TODO
		public void Setup() { }
		
		// TODO
		public void ResetParam(Vector3 initMainCamDofTargetPos, Vector3 initWazaCamDofTargetPos) { }
		
		// TODO
		public void StartContest() { }
		
		// TODO
		public void ResetDofParam(Vector3 initMainCamDofTargetPos, Vector3 initWazaCamDofTargetPos) { }
		
		// TODO
		public void Stop() { }
		
		public bool IsReady { get => bLoadedStage && bLoadedCharacter && heartEmitter.IsLoaded; }
		public bool IsLoadingFx { get => stageFx.IsLoading; }
		
		// TODO
		public void CreateStageModel(Transform cluster, string path) { }
		
		// TODO
		public void CreatePlayerEntity(Transform cluster, AContestPlayerData playerData) { }

		public Vector3 StageModelPosition { get => stageModelObj.Position; }
		
		// TODO
		public void SetAudienceUpdateFlag(bool flag) { }
		
		// TODO
		public void LoadContestFx(ContestDataModel dataModel) { }
		
		// TODO
		public void LoadResultFx() { }
		
		// TODO
		public void SetUISpriteAtlas(SpriteAtlas spriteAtlas) { }
		
		// TODO
		public Sprite GetSpriteByFileName(string fileName) { return default; }
		
		// TODO
		public Sprite GetUIPlayerNumberSpr(int index) { return default; }
		
		// TODO
		public void SetUIPlayerNumSpr(int index, Sprite spr) { }
		
		// TODO
		public Sprite GetUIPlayerPlateSpr(int index) { return default; }
		
		// TODO
		public void SetUIPlayerPlateSpr(int index, Sprite spr) { }
		
		// TODO
		public Sprite GetGraphicTextByFileName(string fileName) { return default; }
		
		public int UserIndex { get => userIndex; }
		
		public ContestPlayerEntity[] GetPlayerEntities() {
		    return playerEntityArray;
		}
		
		// TODO
		public ContestPlayerEntity GetUserEntity() { return default; }
		
		public BOPokemon SpecialWazaModel { get => specialWazaModelPtr; }
		
		// TODO
		public BattleViewCharacter GetTrainerByPosID(BtlvPos posID) { return default; }
		
		// TODO
		public BOPokemon GetPokemonByPosID(BtlvPos posID) { return default; }
		
		// TODO
		public AContestPlayerData GetPlayerDataByPosID(BtlvPos posID) { return default; }
		
		// TODO
		public AContestPlayerData GetPlayerDataByPosID(int index) { return default; }
		
		// TODO
		public AContestPlayerData GetUserPlayerData() { return default; }
		
		// TODO
		public Vector3 GetDefaultPokePos(BtlvPos posID) { return default; }
		
		// TODO
		public Vector3 GetUserDefaultPokePos() { return default; }
		
		// TODO
		public BOPokemon GetUserWazaModelPokemon() { return default; }
		
		// TODO
		public ObjectEntity GetBallObjEntityByPosID(int index) { return default; }
		
		// TODO
		public void SetEnvController(EnvironmentController envController) { }
		
		public EnvironmentController EnvController { get => envController; }
		
		// TODO
		public void SetMainCamera(Camera mainCamera, Camera wazaCamera) { }
		
		// TODO
		public void ChangeMainCameraTag(bool useMainCamera) { }
		
		// TODO
		private void EnableCamera(Camera target) { }
		
		// TODO
		private void DisableCamera(Camera target) { }
		
		public Camera MainCamera { get => mainCamera.Camera; }
		public BOCamera MainBOCamera { get => mainCamera; }
		public Camera WazaCamera { get => wazaCamera.Camera; }
		public BOCamera WazaBOCamera { get => wazaCamera; }
		
		// TODO
		public void SetCameraParent(Transform newParent) { }
		
		// TODO
		public void ResetCameraParent() { }
		
		public ContestViewSystem WazaViewSystem { get => wazaViewSystem; }
		
		// TODO
		public void SetViewSystem(ContestViewSystem contestViewSystem, ContestViewSystem wazaViewSystem) { }
		
		public bool IsPlayingUserWaza { get => bPlayingWazaAnim; }
		
		// TODO
		public void StartContestWazaAnimation(int playerIndex) { }
		
		// TODO
		public void SetStagePositionOnWazaAnim() { }
		
		// TODO
		public void FinishContestWazaAnimation(int playerIndex) { }
		
		// TODO
		public void StartAnnounceTotalScore() { }
		
		// TODO
		public void OnFindSeqCommand_ContestHensin() { }
		
		// TODO
		public void PerformContestWaza_Hensin() { }
		
		// TODO
		public void SetAllPokemonAnimSound(bool enabled) { }
		
		// TODO
		public void PlayAllLightFxActive() { }
		
		// TODO
		public void StopAllLightFxActive() { }
		
		// TODO
		public void RegistVisualHeartUpdate() { }
		
		// TODO
		public void RemoveVisualHeartUpdate() { }
		
		// TODO
		public void EmitVisualHeart(int playerIndex) { }
		
		// TODO
		public DanceHeartEffect CreatePlayerHeart(Vector2 from, Vector2 to, EmitHeartPattern pattern, Action onComplete) { return default; }
		
		// TODO
		public DanceHeartEffect CreateNPCHeart(Vector2 from, Vector2 to, EmitHeartPattern pattern, Action onComplete) { return default; }
		
		public int NowMonitorIndex { get => stageFx.NowMonitorIndex; }
		public float NowMonitorPlayTime { get => stageFx.GetMonitorFxTime(); }
		
		// TODO
		public void SwitchMonitor() { }
		
		// TODO
		public BtlvBallInfo GetBallInfoByIndex(int index) { return default; }
		
		// TODO
		public void PlayAnnounceWinnerFx(int targetPlayerIndex) { }
		
		// TODO
		public void PlayConfettiFx(Vector3 emitPos) { }
		
		// TODO
		public void DevMovePosition() { }
	}
}