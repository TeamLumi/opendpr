using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class ZukanCompareWeightController : MonoBehaviour
	{
		private static readonly int AnimatorStateInitialize = Animator.StringToHash("Ini");
		private static readonly int AnimatorParamStateId = Animator.StringToHash("stateId");
        private static readonly int AnimatorParamSideId = Animator.StringToHash("sideId");
        private static readonly int AnimatorParamWeightId = Animator.StringToHash("weightId");

        private const int StateIdInitialize = -1;
		private const int StateIdStart = 1;
		private const int SideIdBalance = 0;
		private const int SideIdPlayer = 1;
		private const int SideIdPokemon = 2;
		private const string PlayerIconSpriteNameFormat = "dex_ico_compare_player_01_{0:D3}_{1:D2}";

		[SerializeField]
		private Animator animator;
		[SerializeField]
		private Image[] playerImages;
		[SerializeField]
		private Image pokemonIconImage;

		private ushort playerWeight;
		private ZukanInfo currentZukanInfo;
		private bool isSetupEnd;
		
		public bool IsLoadEnd { get; private set; }
		
		// TODO
		public void Initialize(ushort playerWeight) { }
		
		// TODO
		public void Dispose() { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		public void Setup(ZukanInfo zukanInfo)
		{
			this.currentZukanInfo = zukanInfo;
			this.isSetupEnd = false;
		}
		
		// TODO
		public void RequestLoadModel() { }
		
		// TODO
		public void Show() { }
		
		// TODO
		public void Hide() { }
		
		// TODO
		private void LoadPlayerIcon(int fashionId, int colorId) { }
	}
}