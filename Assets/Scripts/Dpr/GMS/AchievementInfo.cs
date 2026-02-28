using UnityEngine;
using XLSXContent;

namespace Dpr.GMS
{
	public class AchievementInfo
	{
		private Sprite titleSpr;
		private GMSMasterData.SheetPutRank currentRankData;
		
		public void Clear()
		{
			this.titleSpr = null;
			this.currentRankData = null;
		}
		
		// TODO
		public Sprite TitleSpr { get => titleSpr; }
		
		// TODO
		public void SetTitleSpr(Sprite titleSpr) { }
		
		// TODO
		public bool HasSoundEvent() { return default; }
		
		// TODO
		public string GetSoundEventName() { return default; }
		
		// TODO
		public void SetRankData(GMSMasterData.SheetPutRank data) { }
	}
}