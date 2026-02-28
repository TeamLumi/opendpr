using Dpr.Playables;
using Pml.PokePara;
using UnityEngine;

namespace Dpr.UI
{
	public class ZukanCompareHeightController : MonoBehaviour
	{
		private static readonly int AnimatorStateInitialize = Animator.StringToHash("Ini");
		private static readonly int AnimatorStateWait = Animator.StringToHash("Wait");
        private static readonly int AnimatorParamTransId = Animator.StringToHash("transId");

        private const string AnimatorTransLayerName = "Trans";

		private const int TransIdIn = 1;
		private const int TransIdOut = 2;

		[SerializeField]
		private PokemonModelView pokemonModelView;

		private ushort playerHeight;
		private PokemonParam currentPokemonParam;
		internal State currentState;
		private UIModelViewController.ModelParam playerModelParam;
		private AnimationLayer playerModelAnimationLayer;
		private int playerModelWaitAnimationIndex = -1;
		private bool isDisposed;
		
		public bool IsLoadEnd { get => currentState == State.None; }
		
		// TODO
		public void Initialize(ushort playerHeight) { }
		
		// TODO
		public void Dispose() { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		public void SetRawImageEnable(bool isEnable) { }
		
		public void Setup(ZukanInfo zukanInfo)
		{
			var uVar1 = zukanInfo.GetCurrentPokemonParam();
			this.currentPokemonParam = uVar1;
			this.currentState = (State)1;
		}
		
		public void RequestLoadModel()
		{
			if ((int)this.currentState == 1) {
			  this.currentState = (State)2;
			}
		}
		
		// TODO
		public void Show() { }
		
		// TODO
		public void Hide() { }
		
		// TODO
		private void LoadPlayerModel() { }
		
		// TODO
		private void LoadPokemonModel(PokemonParam pokemonParam) { }
		
		// TODO
		private UIModelViewController.ModelParam GetLatestModelParam() { return default; }
		
		// TODO
		private void SetupMaterials(GameObject obj) { }
		
		// TODO
		private int GetPlayerWaitAnimationIndex(AnimationLayer animationLayer) { return default; }

		internal enum State : int
		{
			None = 0,
			BeforeLoad = 1,
			StartLoad = 2,
			LoadPlayer = 3,
			LoadPlayerEnd = 4,
			LoadPokemon = 5,
			LoadWait = 6,
			Show = 7,
		}
	}
}