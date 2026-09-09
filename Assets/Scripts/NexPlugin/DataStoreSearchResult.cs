using System.Collections.Generic;

namespace NexPlugin
{
	public class DataStoreSearchResult
	{
		internal List<DataStoreMetaInfo> result;
		internal uint totalCount;
		internal DataStore.SearchResultTotalCountType totalCountType;
		
		public DataStoreSearchResult()
		{
			result = new List<DataStoreMetaInfo>();
		}
		
		public uint GetTotalCount() {
		    return totalCount;
		}
		
		public List<DataStoreMetaInfo> GetResult() {
		    return result;
		}
		
		public DataStore.SearchResultTotalCountType GetTotalCountType() {
		    return totalCountType;
		}
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}