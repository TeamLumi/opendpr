namespace Dpr.Contest
{
	public sealed class ResultPlayerDataModel : ResultPlayerData
	{
		public int GetTotalScore()
		{
			return this.danceScore + this.visualScore + this.wazaScore;
		}
	}
}