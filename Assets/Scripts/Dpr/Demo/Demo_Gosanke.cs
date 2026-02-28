using DG.Tweening;
using Pml;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Demo
{
	public class Demo_Gosanke : DemoBase
	{
		private Animator BagAnimator;
		private RectTransform CursolParent;
		private Image CursolImage;
		private PokeRenderViewer PokemonViewer;
		private Transform RenderCamera;
		private Vector2[] CursolPositions = new Vector2[]
		{
			new Vector2(-216.0f, 80.0f), new Vector2(-45.0f, -10.0f), new Vector2(175.0f, 95.0f),
        };
		private Image Blur;
		private bool isSelectEnd;
		private int[] CatalogIDs = new int[3];

		private static readonly MonsNo[] monsNos = new MonsNo[] { MonsNo.NAETORU, MonsNo.HIKOZARU, MonsNo.POTTYAMA };
		private static readonly int _pokeLightColorID = Shader.PropertyToID("_PokeLightColor");
		private static readonly int _pokeReflectionColorID = Shader.PropertyToID("_PokeReflectorColor");

        private bool isEnd;
		private int nowCursolPosIndex;
		
		public Demo_Gosanke()
		{
			AssetBundlePath = "demo/gosankeprefab";

			Messages.Add(CreateMsgWindowParam("dp_scenario1", "8-EV_POKESELECT_00", false));
			Messages.Add(CreateMsgWindowParam("dp_scenario1", "8-EV_POKESELECT_08"));
			Messages.Add(CreateMsgWindowParam("dp_scenario1", "8-EV_POKESELECT_02"));
			Messages.Add(CreateMsgWindowParam("dp_scenario1", "8-EV_POKESELECT_03"));
			Messages.Add(CreateMsgWindowParam("dp_scenario1", "8-EV_POKESELECT_04"));

			FadeColor = Color.black;
			StartEnterFadeDuration = 0.5f;
			StartExitFadeDuration = 0.5f;
			EndEnterFadeDuration = 0.5f;
			EndExitFadeDuration = 0.5f;
			isDisableMainCamera = true;
        }
		
		// TODO
		public override void Destroy() { }
		
		// TODO
		public override void Init() { }
		
		// TODO
		public override IEnumerator Enter() { return default; }
		
		// TODO
		public override void PostProcessSetting() { }
		
		// TODO
		public override IEnumerator Main() { return default; }
		
		// TODO
		public override IEnumerator Exit() { return default; }
		
		// TODO
		public override void LightUpdate() { }
		
		// TODO
		private IEnumerator BagAnimation() { return default; }
		
		// TODO
		private IEnumerator SelectPoke() { return default; }
		
		// TODO
		private IEnumerator PokeConfirm(int pokeNo) { return default; }
		
		// TODO
		private void UpdateCursolPos() { }
		
		// TODO
		private void ShowCursol(bool isVisible) { }
		
		// TODO
		private void UpdateBallAnimation() { }
		
		// TODO
		private Tweener ShowPokeView(int cursolIndex) { return default; }
		
		private Tweener HidePokeView()
		{
			DOTweenModuleUI.DOFade(0,0x3e4ccccd,this.Blur);
			this.PokemonViewer.HidePokeView();
			return null;
		}
		
		// TODO
		public override void _DebugMethod(int TestNo) { }
	}
}