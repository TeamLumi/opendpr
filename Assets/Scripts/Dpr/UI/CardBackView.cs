using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class CardBackView : MonoBehaviour
	{
		private const string TrainerCommonMessageFileName = "ss_trainer_license_common";
		private const int ContestRankLabelNameIndex = 25;

		[SerializeField]
		private Image cardImage;
		[SerializeField]
		private Image titleImage;
		[SerializeField]
		private UIText contest01Text;
		[SerializeField]
		private UIText contest02Text;
		[SerializeField]
		private UIText contest03Text;
		[SerializeField]
		private UIText contest04Text;
		[SerializeField]
		private UIText contest05Text;
		[SerializeField]
		private UIText tower01Text;
		[SerializeField]
		private UIText tower02Text;
		[SerializeField]
		private UIText tower03Text;
		[SerializeField]
		private UIText tower04Text;
		[SerializeField]
		private UIText poffinCountText;
		[SerializeField]
		private UIText fossilCountText;
		[SerializeField]
		private UIText statueCountText;
		
		public bool IsShow { get => gameObject.activeSelf; }
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void Initialize(UICard.Param param) { }
		
		public void SetCardImageSprite(Sprite cardSprite, Sprite titleSprite)
		{
			this.cardImage.sprite = cardSprite;
			this.titleImage.sprite = titleSprite;
		}
		
		// TODO
		public void Show() { }
		
		// TODO
		public void Hide() { }
		
		// TODO
		public void SetContetText(string txtContest01, string txtContest02, string txtContest03, string txtContest04, string txtContest05) { }
		
		// TODO
		public void SetTowerText(string txtTower01, string txtTower02, string txtTower03, string txtTower04) { }
		
		// TODO
		public void SetCardBackOtherText(string txtPoffin, string txtFossil, string txtStatue) { }
		
		// TODO
		public void SetContestTexts(uint styleRank, uint beatifulRank, uint cureRank, uint cleverRank, uint strongRank)
		{
			void SetText(UIText uiText, uint rank) { }
        }
		
		// TODO
		public void SetTowerTexts(uint singleRenshouCount, uint doubleRenshouCount, uint masterSingleRenshouCount, uint masterDoubleRenshouCount) { }
		
		// TODO
		public void SetOtherTexts(int cookingCount, int fossilCount, int statueCount) { }
	}
}