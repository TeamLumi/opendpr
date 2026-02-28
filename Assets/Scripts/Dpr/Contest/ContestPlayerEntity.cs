using Dpr.Battle.View.Objects;
using Dpr.Trainer;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Contest
{
	public class ContestPlayerEntity
	{
		private readonly Vector3 RESET_BALL_POS = new Vector3(0.0f, -200.0f, 0.0f);

		private XLSXContent.PokemonInfo.SheetCatalog catalog;
		private Object assetPokeModel;
		private List<BtlvEffectInstance> iPtrSealEffects = new List<BtlvEffectInstance>();
		private BtlvEffectInstance iPtrLightEffect;
		private BOPokemon wazaPoke;
		private BOTrainer boTrainer;
		private BOPokemon boPokemon;
		private ObjectEntity ballEntity;
		private AContestPlayerData playerData;
		private Sprite pmIconSpr;
		private Sprite wazaTypeIconSpr;
		private Vector3 defaultTrainerPos;
		private Vector3 defaultPokemonPos;
		private TrainerType trainerType;
		private int colorID;
		private string characterModelPath = string.Empty;
		private string pokeModelPath = string.Empty;
        private string ballModelPath = string.Empty;
        private string pokeIconPath = string.Empty;

        public ContestPlayerEntity(AContestPlayerData playerData)
		{
			this.playerData = playerData;
		}
		
		// TODO
		public void Setup() { }
		
		// TODO
		private void SetupTrainerModel() { }
		
		// TODO
		private void SetupPokeModel() { }
		
		// TODO
		public void Dispose() { }
		
		// TODO
		public void ResetParam(Vector3 trainerPos, Vector3 pokemonPos) { }
		
		public AContestPlayerData PlayerData { get => playerData; }
		public int Index { get => playerData.index; }
		public PlayerType PlayerType { get => playerData.playerType; }
		
		public Sprite GetPmIconSpr()
		{
			return this.pmIconSpr;
		}
		
		public Sprite GetWazaTypeIconSpr()
		{
			return this.wazaTypeIconSpr;
		}
		
		public BOTrainer BoTrainer { get => boTrainer; }
		public BOPokemon BoPokemon { get => boPokemon; }
		public ObjectEntity BallEntity { get => ballEntity; }
		public XLSXContent.PokemonInfo.SheetCatalog Catalog { get => catalog; }
		public bool IsActiveBOPokemon { get => boPokemon.IsActive(); }
		public bool IsActiveWazaPokemon { get => wazaPoke.IsActive(); }
		
		public int CalcTotalScore()
		{
			return this.playerData.danceDataModel.danceScore + this.playerData.visualDataModel.heartNum +
			       this.playerData.danceDataModel.skillScore;
			return 0;
		}
		
		// TODO
		public void AppendLoadResource(Transform cluster, Transform parent, Vector3 trainerPos, Vector3 pokemonPos, int colorID, TrainerType trainerType, bool isUser) { }
		
		// TODO
		private void AppendLoadTrainerModel(string path, Transform cluster, Vector3 pos, int colorID, TrainerType trainerType) { }
		
		// TODO
		private void AppendLoadPokemonModel(string path, Transform parent, Vector3 pos, bool isUser) { }
		
		// TODO
		public void CreateCopyModel(Transform parent) { }
		
		// TODO
		private void AppendLoadBallModel(string path, Transform cluster) { }
		
		// TODO
		public List<BtlvEffectInstance> SealEffects { get; }
		
		// TODO
		public BtlvEffectInstance LightEffect { get; }
		
		// TODO
		private void CreateSealEffectInstance() { }
		
		// TODO
		private void ReleaseBallEffects() { }
		
		// TODO
		private void AppendLoadWazaTypeIcon() { }
		
		// TODO
		private void AppendLoadPokemonIcon() { }
		
		public BOPokemon WazaPokemon { get => wazaPoke; }
		
		// TODO
		public void ReplaceWazaPokemon(BOPokemon boPokemon) { }
		
		// TODO
		public void OnLaunchWazaAnimation(Vector3 pos) { }
		
		public void OnFinishWazaAnimation()
		{
			this.wazaPoke.SetVisible(0);
			this.wazaPoke.SetVisibleTame(0);
			BattlePokemonEntity.SetRenderActive(this.wazaPoke.Entity,0,0);
		}
		
		public void SetModelRenderActive(bool active)
		{
			BattlePokemonEntity.SetRenderActive(this.boPokemon.Entity,(active ? 1 : 0) & 1,0);
		}
		
		// TODO
		private void UnloadAssetBundle() { }
		
		// TODO
		private void ReleaseBallResource() { }
	}
}