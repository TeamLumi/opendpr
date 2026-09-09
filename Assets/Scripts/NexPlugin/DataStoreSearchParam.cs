using System.Collections.Generic;

namespace NexPlugin
{
	public class DataStoreSearchParam
	{
		internal DataStore.SearchType searchTarget;
		internal List<ulong> ownerIds;
		internal DataStore.SearchTarget ownerType;
		internal List<ulong> destinationIds;
		internal List<ushort> dataTypes;
		internal NpDateTime createdAfter;
		internal NpDateTime createdBefore;
		internal NpDateTime updatedAfter;
		internal NpDateTime updatedBefore;
		internal DataStore.SearchSortColumn resultOrderColumn;
		internal DataStore.SearchSortOrder resultOrder;
		internal ResultRange resultRange;
		internal DataStore.ResultFlag resultOption;
		internal List<string> tags;
		internal uint minimalRatingFrequency;
		internal bool totalCountEnabled;
		internal bool useCache;
		
		public DataStoreSearchParam()
		{
			Reset();
		}
		
		public void SetSearchType(DataStore.SearchType searchType) {
		    this.searchTarget = searchType;
		}
		
		public DataStore.SearchType GetSearchType() {
		    return searchTarget;
		}
		
		// TODO
		public void SetOwnerIds(List<ulong> ownerIds_) { }
		
		public List<ulong> GetOwnerIds() {
		    return ownerIds;
		}
		
		public void SetOwnerType(DataStore.SearchTarget ownerType_) {
		    this.ownerType = ownerType_;
		}
		
		public DataStore.SearchTarget GetOwnerType() {
		    return ownerType;
		}
		
		// TODO
		public void SetDestinationIds(List<ulong> destinationIds_) { }
		
		public List<ulong> GetDestinationIds() {
		    return destinationIds;
		}
		
		// TODO
		public void SetDataType(ushort dataType_) { }
		
		// TODO
		public void SetDataType(List<ushort> dataTypes_) { }
		
		// TODO
		public ushort GetDataType() { return default; }
		
		// TODO
		public void GetDataType(ref List<ushort> dataTypes_) { }
		
		// TODO
		public void SetCreatedAfter(NpDateTime createdAfter_) { }
		
		// TODO
		public NpDateTime GetCreatedAfter() { return default; }
		
		// TODO
		public void SetCreatedBefore(NpDateTime createdBefore_) { }
		
		// TODO
		public NpDateTime GetCreatedBefore() { return default; }
		
		// TODO
		public void SetUpdatedAfter(NpDateTime updatedAfter_) { }
		
		// TODO
		public NpDateTime GetUpdatedAfter() { return default; }
		
		// TODO
		public void SetUpdatedBefore(NpDateTime updatedBefore_) { }
		
		// TODO
		public NpDateTime GetUpdatedBefore() { return default; }
		
		public void SetSearchSortOrderColumn(DataStore.SearchSortColumn resultOrderColumn_) {
		    this.resultOrderColumn = resultOrderColumn_;
		}
		
		public DataStore.SearchSortColumn GetSearchSortOrderColumn() {
		    return resultOrderColumn;
		}
		
		public void SetSearchSortOrder(DataStore.SearchSortOrder resultOrder_) {
		    this.resultOrder = resultOrder_;
		}
		
		public DataStore.SearchSortOrder GetSearchSortOrder() {
		    return resultOrder;
		}
		
		// TODO
		public void SetResultRange(ResultRange resultRange_) { }
		
		public ResultRange GetResultRange() {
		    return resultRange;
		}
		
		public void SetResultOption(DataStore.ResultFlag resultOption_) {
		    this.resultOption = resultOption_;
		}
		
		public DataStore.ResultFlag GetResultOption() {
		    return resultOption;
		}
		
		// TODO
		public void SetTags(List<string> tags_) { }
		
		public List<string> GetTags() {
		    return tags;
		}
		
		public void SetMinimalRatingFrequency(uint minimalRatingFrequency_) {
		    this.minimalRatingFrequency = minimalRatingFrequency_;
		}
		
		public uint GetMinimalRatingFrequency() {
		    return minimalRatingFrequency;
		}
		
		public void SetUseCache(bool useCache_) {
		    this.useCache = useCache_;
		}
		
		public bool GetUseCache() {
		    return useCache;
		}
		
		public void SetTotalCountEnabled(bool totalCountEnabled_) {
		    this.totalCountEnabled = totalCountEnabled_;
		}
		
		public bool GetTotalCountEnabled() {
		    return totalCountEnabled;
		}
		
		// TODO
		private void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}