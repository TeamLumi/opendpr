using Pml;
using UnityEngine;

namespace Dpr.Contest
{
	public sealed class ResultDataModel : ResultData
	{
		private float playerNumDivid;
		private Sprite resultMessageSpr;
		
		// TODO
		public void ResetData() { }
		
		// TODO
		public void OnFinalize() { }
		
		public ResultPlayerDataModel GetPlayerData()
		{
			if (this.userIndex < this.playerDataModelArray.Length) {
			  return *
			          (this.playerDataModelArray + (int)this.userIndex * 8 + 0x20);
			}
			return null;
		}
		
		public int GetPersonalTotalScore()
		{
			return (int)(this.playerNumDivid * (float)this.maxTotalScore);
		}
		
		// TODO
		public bool IsUserWin() { return default; }
		
		// TODO
		public Sprite GetResultMessageSpr() { return default; }
		
		// TODO
		public float CalcVisualGaugeRatio(int playerIndex) { return default; }
		
		// TODO
		public float CalcDanceGaugeRatio(int playerIndex) { return default; }
		
		// TODO
		public float CalcWazaGaugeRatio(int playerIndex) { return default; }
		
		// TODO
		public void ApplyContestPoint() { }
		
		// TODO
		private uint CalcAddRankPoint() { return default; }
		
		private float CalcRatio(float a, float b)
		{
			a = a / b;
			if (1.0 < a) {
			  a = 1.0;
			}
			return a;
		}
		
		// TODO
		public void SetPlayerDataModelArray(ResultPlayerDataModel[] playerDataModelArray) { }
		
		// TODO
		public void CreateVoiceEventName(MonsNo monsNo, uint formNo, int voiceNo) { }
	}
}