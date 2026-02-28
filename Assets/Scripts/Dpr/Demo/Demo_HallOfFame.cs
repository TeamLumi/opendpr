using Dpr.SubContents;
using Pml.PokePara;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Demo
{
	public class Demo_HallOfFame : DemoBase
	{
		private TimeLineBinder timeLine;
		private uint pokeCount;
		private TimeLineText LevelText;
		private TimeLineText PokeNameText;
		private TimeLineText PlayerNameText;
		private List<PokemonParam> pokes = new List<PokemonParam>();
		
		public Demo_HallOfFame()
		{
			UseCamera = true;
			FadeColor = Color.black;
			isDisablePostProcess = true;
			DisableEnvironmentController = false;
		}
		
		// TODO
		public override void Destroy() { }
		
		// TODO
		public override IEnumerator Enter() { return default; }
		
		// TODO
		public override IEnumerator Main() { return default; }
		
		// TODO
		public override IEnumerator Exit() { return default; }
		
		// TODO
		public void CheckPokeEnd(int num, float frame) { }
		
		// TODO
		public void UpdateText(int index) { }
		
		public void ToBattleScale(int index)
		{
			this.timeLine.ChangePokeBattleScale();
		}
		
		public void ToMenuScale(int index)
		{
			this.timeLine.ChangePokeMenuScale();
		}
		
		// TODO
		private void SetUpGraphicText(TimeLineBinder timeline) { }
	}
}