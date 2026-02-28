using Dpr.UI;
using Pml.PokePara;
using UnityEngine;

namespace Dpr.SubContents
{
	public class TimeLineText : MonoBehaviour
	{
		public Mode mode;
		private UIText text;
		private const string fileName = "dlp_halloffame_demo";

		private static readonly string[] Labels = new string[]
		{
            "DLP_halloffame_demo_015", "DLP_halloffame_demo_014", "DLP_halloffame_demo_013",
        };
		
		private void OnEnable()
		{
			Transform.SetSiblingIndex(Text.get_rectTransform(this.text),100,0);
		}
		
		// TODO
		private void Awake() { }
		
		// TODO
		public void UpdateText(PokemonParam param) { }

		public enum Mode : int
		{
			Level = 0,
			PokeName = 1,
			PlayerName = 2,
		}
	}
}