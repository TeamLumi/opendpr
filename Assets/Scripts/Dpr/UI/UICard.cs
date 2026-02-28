using Dpr.Message;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UICard : UIWindow
	{
		private const string CardImageSpriteNameFormat = "prf_pl_card_01_{0:00}_{1:00}";
		private const string TitleImageSpriteNameFormat = "prf_txt_title_01_{0:00}";
		private const string FrontCover1ImageSpriteNameFormat = "prf_pl_card_01_{0:00}_01_parts_01";
		private const string FrontCover2ImageSpriteNameFormat = "prf_pl_card_01_{0:00}_01_parts_02";

		[SerializeField]
		private SpriteAtlas cardSpriteAtlas;
		[SerializeField]
		private RectTransform bgImageRectTransform;
		[SerializeField]
		private GameObject cardWindowObject;
		[SerializeField]
		private GameObject badgeCaseIconObject;
		[SerializeField]
		private GameObject modelViewPrefab;
		[SerializeField]
		private CardFrontView cardFrontView;
		[SerializeField]
		private CardBackView cardBackView;
		[SerializeField]
		private RawImage modelViewRawImage;
		[SerializeField]
		private CardAnimationController animationController;
		[SerializeField]
		private Image badgeCaseIconImage;
		[Header("ケースアイコン(ダイアモンド)")]
		[SerializeField]
		private Sprite diamondBadeCaseIconSprite;
		[Header("ケースアイコン(パール)")]
		[SerializeField]
		private Sprite pearlBadeCaseIconSprite;
		[Header("プレイヤーモデルの回転量")]
		[SerializeField]
		private float PlayerModelRotateValue = 5.0f;

		private readonly int _animStateIn = Animator.StringToHash("in");
		private readonly int _animStateOut = Animator.StringToHash("out");

        private GameObject modelViewObject;
		private CardModelViewController modelViewController;
		private bool isWaitUpdate;
		private Param param;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(UIWindowID prevWindowId) { }
		
		// TODO
		public void Open(Param param, UIWindowID prevWindowId = WINDOWID_FIELD) { }
		
		// TODO
		public IEnumerator OpOpen(UIWindowID prevWindowId) { return default; }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void OnUpdateTrainerCard(float deltaTime) { }
		
		private void OnUpdateBadgeCase(float deltaTime)
		{
			if ((this.modelViewController.IsEndBadgeCase & 1) != 0) {
			  this.modelViewController.ResetRotatePlayerModel();
			  ShowPlayerModel();
			}
		}
		
		// TODO
		private void UpdateKeyGuide() { }
		
		// TODO
		private void SetupCardImage(int rank) { }
		
		// TODO
		private void SetupBadgeCaseIcon() { }
		
		// TODO
		private void ShowPlayerModel()
		{
            IEnumerator Show() { return default; }
        }
		
		// TODO
		private void ShowBadgeCase()
		{
            IEnumerator Show() { return default; }
        }
		
		public void SetTextFront(uint id, PlayerNameData nameData, int money, int zukanCount, ushort playTimeHour, ushort playTimeMinute, long startTime, uint clearTime)
		{
			uStack0000000000000008 = 0;
			this.cardFrontView.SetText();
		}
		
		public void SetTextBackContest(uint styleRank, uint beatifulRank, uint cuteRank, uint cleverRank, uint strongRank)
		{
			this.cardBackView.SetContestTexts();
		}
		
		public void SetTextBackTower(uint singleRenshouCount, uint doubleRenshouCount, uint masterSingleRenshouCount, uint masterDoubleRenshouCount)
		{
			this.cardBackView.SetTowerTexts();
		}
		
		public void SetTextBackOther(int cookingCount, int fossilCount, int statueCount)
		{
			this.cardBackView.SetOtherTexts();
		}

		public class Param
		{
			public bool IsShowBadgeCase;
			public int CardRank;
			public byte PlayerFashion;
			public byte PlayerBodyType;
			public bool PlayerSex;
			public uint PlayerId;
			public PlayerNameData PlayerNameData;
			public int Money;
			public bool IsGetZukan;
			public int ZukanSeeCount;
			public ushort PlayTimeHour;
			public ushort PlayTimeMinute;
			public long StartTime;
			public uint ClearTime;
			public uint ContestStyleRank;
			public uint ContestBeatifulRank;
			public uint ContestCuteRank;
			public uint ContestCleverRank;
			public uint ContestStrongRank;
			public uint TowerRenshouSingle;
			public uint TowerRenshouDouble;
			public uint TowerRenshouMasterSingle;
			public uint TowerRenshouMasterDouble;
			public int PoffinCookingCount;
			public short DigFossilPlayCount;
			public int HaveStatueKindNum;
		}
	}
}