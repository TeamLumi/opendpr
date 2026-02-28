using Dpr.SubContents;
using Pml.PokePara;
using System.Collections;
using UnityEngine;

namespace Dpr.Demo
{
	public class Demo_MysteryGift : DemoBase
	{
		private TimeLineBinder timeLine;
		public PokemonParam gift_Pokemon;
		public bool isGetMons;
		
		public Demo_MysteryGift()
		{
			UseCamera = true;
			FadeColor = Color.black;
			DisableEnvironmentController = false;
			isDisablePostProcess = true;
			isDisableMainCamera = true;
		}
		
		public override void Destroy()
		{
			DemoBase.Destroy();
			this.timeLine = null;
		}
		
		// TODO
		public override IEnumerator Enter() { return default; }
		
		// TODO
		public override IEnumerator Main() { return default; }
		
		// TODO
		public override IEnumerator Exit() { return default; }
	}
}