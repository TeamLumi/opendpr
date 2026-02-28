using Dpr.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.SecretBase
{
	public class StatueEffectWindow : MonoBehaviour
	{
		[SerializeField]
		private Image icon;
		[SerializeField]
		private Image bg;
		[SerializeField]
		private Canvas canvas;
		[SerializeField]
		private SecretBaseMasterDataManager masterData;
		[SerializeField]
		private Sprite[] effectsTexture;
		[SerializeField]
		private Sprite[] effectsBg;
		[SerializeField]
		private Image[] effectsPower;
		[SerializeField]
		private int[] threshold;
		[SerializeField]
		private string[] MSlabels;
		[SerializeField]
		private UIText text;
		
		// TODO
		public void Show() { }
		
		public void Close()
		{
			this.canvas.enabled = 0;
		}
	}
}