using System.Collections.Generic;

namespace NexPlugin
{
	public class Ranking2ChartInfo
	{
		internal uint index;
		internal uint category;
		internal uint season;
		internal uint samplingRate;
		internal bool scoreOrder;
		internal uint estimateLength;
		internal uint estimateHighestScore;
		internal uint estimateLowestScore;
		internal uint estimateMedianScore;
		internal uint highestBinsScore;
		internal uint lowestBinsScore;
		internal uint binsWidth;
		internal uint attribute1;
		internal uint attribute2;
		internal NpDateTime createTime;
		internal double estimateAverageScore;
		internal List<uint> quantities;
		internal byte binsSize;
		
		// TODO
		public NpDateTime GetCreateTime() { return default; }
		
		public uint GetIndex() {
		    return index;
		}
		
		public uint GetCategory() {
		    return category;
		}
		
		public uint GetSeason() {
		    return season;
		}
		
		public uint GetBinsSize() {
		    return binsSize;
		}
		
		// TODO
		public bool IsValid() { return default; }
		
		public uint GetSamplingRate() {
		    return samplingRate;
		}
		
		public bool GetScoreOrder() {
		    return scoreOrder;
		}
		
		public uint GetEstimateLength() {
		    return estimateLength;
		}
		
		public uint GetEstimateHighestScore() {
		    return estimateHighestScore;
		}
		
		public uint GetEstimateLowestScore() {
		    return estimateLowestScore;
		}
		
		public uint GetEstimateMedianScore() {
		    return estimateMedianScore;
		}
		
		public double GetEstimateAverageScore() {
		    return estimateAverageScore;
		}
		
		public uint GetHighestBinsScore() {
		    return highestBinsScore;
		}
		
		public uint GetLowestBinsScore() {
		    return lowestBinsScore;
		}
		
		public uint GetBinsWidth() {
		    return binsWidth;
		}
		
		public uint GetAttribute1() {
		    return attribute1;
		}
		
		public uint GetAttribute2() {
		    return attribute2;
		}
		
		// TODO
		public List<uint> GetQuantities() { return default; }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}