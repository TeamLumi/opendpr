using nn;
using nn.account;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NexPlugin
{
	internal static class Detail
	{
		public const string DLL_NAME = "__Internal";

		private static List<NotificationEventCB> s_NotificationEventCB = new List<NotificationEventCB>();
		private static Dictionary<uint, object> s_NexAsyncCall = new Dictionary<uint, object>();
		private static uint m_AsyncId = 0;
		
		// TODO
		public static void GetAsyncResult(ref AsyncResultInt asyncResult, object callback) { }
		
		// TODO
		public static bool RegisterNotificationEventHandler(NotificationEventCB callback) { return default; }
		
		// TODO
		public static bool UnregisterNotificationEventHandler(NotificationEventCB callback) { return default; }
		
		// TODO
		public static void NotificationEventListCallback(List<NotificationEvent> notificationEventList) { }
		
		// TODO
		public static void AddNexResultCallback(uint asyncId, object callback) { }
		
		// TODO
		public static void AsyncResultCallback(ref List<AsyncResultInt> AsyncResultList) { }
		
		// TODO
		public static uint PublishAsyncId() { return default; }
		
		// TODO
		public static int GetNexAsyncCallCount() { return default; }
		
		// TODO
		public static void DumpNexAsyncCallList() { }
		
		// TODO
		public static void NP_LOG(string str) { }
		
		// TODO
		public static void NP_LOG(string format, object[] arg) { }
		
		// TODO
		public static T ExchangePtrToStruct<T>(IntPtr src) { return default; }
		
		// TODO
		public static IntPtr CopyStruct<T>(T[] param) { return default; }

		public struct AsyncResultInt
		{
			private long pad;
			public uint asyncId;
			public AsyncResultNum asyncNum;
			public Result nnResult;
			public uint netErrCode;
			public int returnCode;
			public uint errorCode;
			public IntPtr pParam1;
			public IntPtr pParam2;
			
			// TODO
			public static AsyncResult GetAsyncResult(AsyncResultInt res) { return default; }
			
			// TODO
			public long GetLong(IntPtr pParam) { return default; }
			
			// TODO
			public ulong GetUlong(IntPtr pParam) { return default; }
			
			// TODO
			public int GetInt(IntPtr pParam) { return default; }
			
			// TODO
			public uint GetUint(IntPtr pParam) { return default; }
			
			// TODO
			public void Trace() { }
			
			// TODO
			public override string ToString() { return default; }
		}

		public struct NotificationEventInt : IExchangeList<NotificationEvent>
		{
			public ulong param1;
			public ulong param2;
			public uint type;
			public uint subType;
			public CppArray stringParam;
			public ulong pid;
			
			// TODO
			public static NotificationEvent ExchangePtrToStruct(IntPtr src) { return default; }
			
			// TODO
			public NotificationEvent ExchangeStruct() { return default; }
		}

		public static class Common
		{
			private static List<AsyncResultInt> asyncResultList = new List<AsyncResultInt>();
			private static List<NotificationEvent> notificationEventList = new List<NotificationEvent>();

			// TODO
			private static extern bool InitializeNexAsyncInt(uint asyncId, int threadMode);
			
			// TODO
			public static bool InitializeNexAsync(out uint asyncId, NexPlugin.Common.ThreadMode threadMode, [Optional] AsyncResultCB callback)
			{
				asyncId = default;
				return default;
			}

			// TODO
			private static extern bool FinalizeNexAsyncInt(uint asyncId);
			
			// TODO
			public static bool FinalizeNexAsync(out uint asyncId, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            public static extern void SetTerminateImmediately(uint terminate);

			// TODO
			private static extern uint DispatchInt(uint dispatchTimeout, uint dispatchFlags);
			
			// TODO
			public static uint Dispatch(uint dispatchTimeout, [Optional] NexPlugin.Common.DispachFlag? dispatchFlags) { return default; }

			// TODO
			public static extern void DispatchAll();

			// TODO
			public static extern uint GetReadyJobsSize();

			// TODO
			private static extern bool UpdateAsyncResultInt(ref IntPtr pAsyncResult);
			
			// TODO
			public static bool UpdateAsyncResult() { return default; }

			// TODO
			public static extern void InitAsyncResultByAsyncId(uint asyncId);
			
			// TODO
			public static void Wait(uint dispatchTimeOut, NexPlugin.Common.DispachFlag? dispatchFlags) { }

			// TODO
			private static extern bool GetNotificationEventInt(ref IntPtr pNotificationEvent);
			
			// TODO
			public static bool GetNotificationEvent() { return default; }
			
			// TODO
			public static void Callback(AsyncResultInt res, object callback) { }
		}

		public interface IExchangeList<T>
		{
			T ExchangeStruct();
		}

		public struct CppArray
		{
			public int count;
			public IntPtr ptr;
			
			public CppArray(IntPtr src)
            {
                this = ExchangePtrToStruct<CppArray>(src);
            }
			
			// TODO
			public void ToArray<T>(ref T[] list, int size) { }
			
			// TODO
			public void ToList<T>(ref List<T> list) { }
			
			// TODO
			public List<T> ToList<T, U>() { return default; }
			
			// TODO
			public string ToStr() { return default; }
			
			// TODO
			public static CppArray StringToArray(List<IntPtr> useptr, string param) { return default; }
			
			// TODO
			public static CppArray StringsToArray(List<IntPtr> useptr, List<string> param) { return default; }
			
			// TODO
			public static CppArray ArrayToArray<T>(List<IntPtr> useptr, T[] param) { return default; }
			
			// TODO
			public static CppArray ListToArray<T>(List<IntPtr> useptr, List<T> param) { return default; }
			
			// TODO
			public static CppArray ListToArray<U, T>(List<IntPtr> useptr, List<T> param) { return default; }
		}

		public static class DataStore
		{
			// TODO
			private static List<Dictionary<sbyte, DataStoreRatingInfo>> DataStore_ExchangeRatingInfosList(IntPtr src) { return default; }

			// TODO
			private static extern bool DataStore_PostObjectAsync(uint asyncId, IntPtr pNgsFacade, ref DataStorePreparePostParamInt pParam, IntPtr pUpBuf, int timeOut);
			
			// TODO
			public static bool PostObjectAsync<T>(out uint asyncId, IntPtr pNgsFacade, DataStorePreparePostParam param, T[] array, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.PostCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_PostMetaAsync(uint asyncId, IntPtr pNgsFacade, ref DataStorePreparePostParamInt pParam, int timeOut);
			
			// TODO
			public static bool PostMetaAsync(out uint asyncId, IntPtr pNgsFacade, DataStorePreparePostParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.PostCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_PostMetaAsyncByDataID(uint asyncId, IntPtr pNgsFacade, ulong dataId, ref DataStorePreparePostParamInt pParam, int timeOut);
			
			// TODO
			public static bool PostMetaAsync(out uint asyncId, IntPtr pNgsFacade, ulong dataId, DataStorePreparePostParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_PostMetaAsyncByDataList(uint asyncId, IntPtr pNgsFacade, int useOneParam, ref CppArray dataIds, ref CppArray param, int transactional, int timeOut);
			
			// TODO
			public static bool PostMetaAsync(out uint asyncId, IntPtr pNgsFacade, bool useOneParam, List<ulong> dataIds, List<DataStorePreparePostParam> param, [Optional] [DefaultParameterValue(true)] bool transactional, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.ResultListCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_CompleteSuspendedPostObjectAsync(uint asyncId, IntPtr pNgsFacade, ref CppArray pParam, int timeOut);
			
			// TODO
			public static bool CompleteSuspendedPostObjectAsync(out uint asyncId, IntPtr pNgsFacade, List<ulong> dataIds, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_SearchObjectAsync(uint asyncId, IntPtr pNgsFacade, ref DataStoreSearchParamInt pParam, int timeOut);
			
			// TODO
			public static bool SearchObjectAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreSearchParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.SearchObjectCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_SearchObjectLightAsync(uint asyncId, IntPtr pNgsFacade, ref DataStoreSearchParamInt pParam, int timeOut);
			
			// TODO
			public static bool SearchObjectLightAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreSearchParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.SearchObjectCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_DeleteObjectAsync(uint asyncId, IntPtr pNgsFacade, ref DataStoreDeleteParamInt pParam, int timeOut);
			
			// TODO
			public static bool DeleteObjectAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreDeleteParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_DeleteObjectAsyncByDataList(uint asyncId, IntPtr pNgsFacade, ref CppArray param, int transactional, int timeOut);
			
			// TODO
			public static bool DeleteObjectAsync(out uint asyncId, IntPtr pNgsFacade, List<DataStoreDeleteParam> param, [Optional] [DefaultParameterValue(true)] bool transactional, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.ResultListCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_UpdateObjectAsync(uint asyncId, IntPtr pNgsFacade, ref DataStorePrepareUpdateParamInt pParam, IntPtr pUpBuf, int timeOut);
			
			// TODO
			public static bool UpdateObjectAsync<T>(out uint asyncId, IntPtr pNgsFacade, DataStorePrepareUpdateParam param, T[] array, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_GetObjectAsync(uint asyncId, IntPtr pNgsFacade, ref DataStorePrepareGetParamInt pParam, ulong getBufSize, int timeOut);
			
			// TODO
			public static bool GetObjectAsync(out uint asyncId, IntPtr pNgsFacade, DataStorePrepareGetParam param, ulong getBufSize, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.GetObjectCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_TouchObjectAsync(uint asyncId, IntPtr pNgsFacade, ref DataStoreTouchObjectParamInt param, int timeOut);
			
			// TODO
			public static bool TouchObjectAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreTouchObjectParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_GetMetaAsync(uint asyncId, IntPtr pNgsFacade, ref DataStoreGetMetaParamInt pParam, int timeOut);
			
			// TODO
			public static bool GetMetaAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreGetMetaParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.GetMetaCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_GetMetaAsyncByDataList(uint asyncId, IntPtr pNgsFacade, int useDataIds, ref CppArray dataIds, ref CppArray param, int timeOut);
			
			// TODO
			public static bool GetMetaAsync(out uint asyncId, IntPtr pNgsFacade, bool useDataIds, List<ulong> dataIds, List<DataStoreGetMetaParam> param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.GetMetaListCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_ChangeMetaAsync(uint asyncId, IntPtr pNgsFacade, ref DataStoreChangeMetaParamInt pParam, int timeOut);
			
			// TODO
			public static bool ChangeMetaAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreChangeMetaParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_ChangeMetaAsyncByDataList(uint asyncId, IntPtr pNgsFacade, int useDataIds, ref CppArray dataIds, ref CppArray param, int transactional, int timeOut);
			
			// TODO
			public static bool ChangeMetaAsync(out uint asyncId, IntPtr pNgsFacade, bool useDataIds, List<ulong> dataIds, List<DataStoreChangeMetaParam> param, [Optional] [DefaultParameterValue(true)] bool transactional, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.ResultListCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_RateObjectAsync(uint asyncId, IntPtr pNgsFacade, ref DataStoreRatingTargetInt pTarget, ref DataStoreRateObjectParamInt pRateParam, int timeOut);
			
			// TODO
			public static bool RateObjectAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreRatingTarget target, DataStoreRateObjectParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.RatingInfoCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_RateObjectAsyncByDataList(uint asyncId, IntPtr pNgsFacade, int useOneObjectParam, ref CppArray target, ref CppArray param, int transactional, int timeOut);
			
			// TODO
			public static bool RateObjectAsync(out uint asyncId, IntPtr pNgsFacade, bool useOneObjectParam, List<DataStoreRatingTarget> target, List<DataStoreRateObjectParam> param, [Optional] [DefaultParameterValue(true)] bool transactional, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.RatingInfoListCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_RateObjectWithPostingAsync(uint asyncId, IntPtr pNgsFacade, ref DataStoreRatingTargetInt pParam, ref DataStoreRateObjectParamInt pObject, ref DataStorePreparePostParamInt pPostParam, int timeOut);
			
			// TODO
			public static bool RateObjectWithPostingAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreRatingTarget pParam, DataStoreRateObjectParam pObject, DataStorePreparePostParam pPostParam, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.RatingInfoCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_RateObjectsWithPostingAsync(uint asyncId, IntPtr pNgsFacade, int useOneParam, ref CppArray pParam, ref CppArray pObject, ref CppArray pPostParam, int transactional, int timeOut);
			
			// TODO
			public static bool RateObjectsWithPostingAsync(out uint asyncId, IntPtr pNgsFacade, bool useOneParam, List<DataStoreRatingTarget> pParam, List<DataStoreRateObjectParam> pObject, List<DataStorePreparePostParam> pPostParam, bool transactional, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.RatingInfoListCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_GetRatingAsync(uint asyncId, IntPtr pNgsFacade, ref DataStoreRatingTargetInt target, ulong accessPassword, int timeOut);
			
			// TODO
			public static bool GetRatingAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreRatingTarget target, ulong accessPassword, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.RatingInfoCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_GetRatingAllSlotAsync(uint asyncId, IntPtr pNgsFacade, ulong dataId, int timeOut);
			
			// TODO
			public static bool GetRatingAsync(out uint asyncId, IntPtr pNgsFacade, ulong dataId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.RatingInfoAllSlotCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_GetRatingAsyncByDataList(uint asyncId, IntPtr pNgsFacade, ref CppArray dataIds, int timeOut);
			
			// TODO
			public static bool GetRatingAsync(out uint asyncId, IntPtr pNgsFacade, List<ulong> dataIds, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.RatingInfosListCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_GetRatingWithLogAsync(uint asyncId, IntPtr pNgsFacade, ref DataStoreRatingTargetInt target, ulong accessPassword, int timeOut);
			
			// TODO
			public static bool GetRatingAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreRatingTarget target, ulong accessPassword, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.RatingInfoWithLogCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_ResetRatingAsync(uint asyncId, IntPtr pNgsFacade, ref DataStoreRatingTargetInt target, ulong accessPassword, int timeOut);
			
			// TODO
			public static bool ResetRatingAsync(out uint asyncId, IntPtr pNgsFacade, DataStoreRatingTarget target, ulong accessPassword, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_ResetRatingAllSlotAsync(uint asyncId, IntPtr pNgsFacade, ulong dataId, int timeOut);
			
			// TODO
			public static bool ResetRatingAsync(out uint asyncId, IntPtr pNgsFacade, ulong dataId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_ResetRatingAsyncByDataList(uint asyncId, IntPtr pNgsFacade, ref CppArray dataIds, int transactional, int timeOut);
			
			// TODO
			public static bool ResetRatingAsync(out uint asyncId, IntPtr pNgsFacade, List<ulong> dataIds, [Optional] [DefaultParameterValue(true)] bool transactional, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.ResultListCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_GetPersistenceInfoAsync(uint asyncId, IntPtr pNgsFacade, ulong principalId, ushort slotId, int timeOut);
			
			// TODO
			public static bool GetPersistenceInfoAsync(out uint asyncId, IntPtr pNgsFacade, ulong principalId, ushort persistenceSlotId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.GetPersistenceInfoCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_GetPersistenceInfoAsyncByDataList(uint asyncId, IntPtr pNgsFacade, ulong principalId, ref CppArray persistenceSlotIds, int timeOut);
			
			// TODO
			public static bool GetPersistenceInfoAsync(out uint asyncId, IntPtr pNgsFacade, ulong principalId, List<ushort> persistenceSlotIds, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.GetPersistenceInfoListCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_PerpetuateObjectAsync(uint asyncId, IntPtr pNgsFacade, ushort slotId, ulong dataId, int deleteFlag, int timeOut);
			
			// TODO
			public static bool PerpetuateObjectAsync(out uint asyncId, IntPtr pNgsFacade, ushort persistenceSlotId, ulong dataId, [Optional] [DefaultParameterValue(true)] bool deleteLastObject, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_UnperpetuateObjectAsync(uint asyncId, IntPtr pNgsFacade, ushort slotId, int deleteFlag, int timeOut);
			
			// TODO
			public static bool UnperpetuateObjectAsync(out uint asyncId, IntPtr pNgsFacade, ushort persistenceSlotId, [Optional] [DefaultParameterValue(false)] bool deleteLastObject, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_GetPasswordInfoAsync(uint asyncId, IntPtr pNgsFacade, ulong dataId, int timeOut);
			
			// TODO
			public static bool GetPasswordInfoAsync(out uint asyncId, IntPtr pNgsFacade, ulong dataId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.GetPasswordInfoCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool DataStore_GetPasswordInfoAsyncByDataList(uint asyncId, IntPtr pNgsFacade, ref CppArray pParam, int timeOut);
			
			// TODO
			public static bool GetPasswordInfoAsync(out uint asyncId, IntPtr pNgsFacade, List<ulong> dataIds, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.DataStore.GetPasswordInfoListCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static void DataStore_PostResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void DataStore_ResultListResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void DataStore_SearchObjectResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void DataStore_GetObjectResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void DataStore_GetMetaResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void DataStore_GetMetaByDataListResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void DataStore_RatingInfoResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void DataStore_RatingInfoAllSlotResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void DataStore_RatingInfoListResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void DataStore_RatingInfosListResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void DataStore_RatingInfoWithLogResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void DataStore_GetPersistenceInfoResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void DataStore_GetPersistenceInfoListResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void DataStore_GetPasswordInfoResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void DataStore_GetPasswordInfoListResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			public static void Callback(AsyncResultInt res, object callback) { }

            private struct DataStorePersistenceInfoInt : IExchangeList<DataStorePersistenceInfo>
            {
                private ulong dataId;
                private ulong principalId;
                private ushort persistenceSlotId;

                // TODO
                public DataStorePersistenceInfo ExchangeStruct() { return default; }

                // TODO
                public static DataStorePersistenceInfo ExchangePtrToStruct(IntPtr src) { return default; }

                public DataStorePersistenceInfoInt(DataStorePersistenceInfo param)
                {
                    if (param == null)
                        param = new DataStorePersistenceInfo();

                    dataId = param.dataId;
                    principalId = param.principalId;
                    persistenceSlotId = param.persistenceSlotId;
                }
            }

            private struct DataStorePasswordInfoInt : IExchangeList<DataStorePasswordInfo>
            {
                private ulong dataId;
                private ulong accessPassword;
                private ulong updatePassword;

                // TODO
                public DataStorePasswordInfo ExchangeStruct() { return default; }

                // TODO
                public static DataStorePasswordInfo ExchangePtrToStruct(IntPtr src) { return default; }

                public DataStorePasswordInfoInt(DataStorePasswordInfo param)
                {
                    if (param == null)
                        param = new DataStorePasswordInfo();

                    dataId = param.dataId;
                    accessPassword = param.accessPassword;
                    updatePassword = param.updatePassword;
                }
            }

            private struct DataStorePermissionInt : IExchangeList<DataStorePermission>
            {
                private CppArray recipientIds;
                private uint permission;

                // TODO
                public DataStorePermission ExchangeStruct() { return default; }

                public DataStorePermissionInt(List<IntPtr> useptr, DataStorePermission param)
                {
                    if (param == null)
                        param = new DataStorePermission();

                    permission = (uint)param.permission;
                    recipientIds = CppArray.ListToArray(useptr, param.recipientIds);
                }
            }

            private struct DataStoreMetaInfoInt : IExchangeList<DataStoreMetaInfo>
            {
                private ulong dataId;
                private ulong ownerId;
                private uint size;
                private ushort dataType;
                private ushort period;
                private uint status;
                private uint referDataId;
                private uint flag;
                private DataStorePermissionInt accessPermission;
                private DataStorePermissionInt updatePermission;
                private CppArray name;
                private CppArray meta;
                private CppArray tags;
                private CppArray ratingInfo;
                private NpDateTime createdTime;
                private NpDateTime updatedTime;
                private NpDateTime expireTime;

                // TODO
                public static DataStoreMetaInfo ExchangePtrToStruct(IntPtr src) { return default; }

                // TODO
                public DataStoreMetaInfo ExchangeStruct() { return default; }
            }

            private struct DataStoreSearchResultInt
            {
                private CppArray result;
                private uint totalCount;
                private uint totalCountType;

                // TODO
                public static DataStoreSearchResult ExchangePtrToStruct(IntPtr src) { return default; }
            }

            private struct DataStoreRatingLogInt
            {
                private NpDateTime lockExpirationTime;
                private ulong pid;
                private int ratingValue;
                private bool isRated;

                // TODO
                public static DataStoreRatingLog ExchangePtrToStruct(IntPtr src) { return default; }
            }

            private struct DataStorePersistenceInitParamInt
            {
                private ushort persistenceSlotId;
                private byte deleteLastObject;

                public DataStorePersistenceInitParamInt(DataStorePersistenceInitParam param)
                {
                    if (param == null)
                        param = new DataStorePersistenceInitParam();

                    persistenceSlotId = param.persistenceSlotId;
                    deleteLastObject = param.deleteLastObject ? (byte)1 : (byte)0;
                }
            }

            private struct DataStoreRatingInitParamInt
            {
                private long initialValue;
                private int rangeMin;
                private int rangeMax;
                private int flag;
                private int internalFlag;
                private int lockType;
                private short periodDuration;
                private sbyte periodHour;
                private sbyte slot;

                public DataStoreRatingInitParamInt(DataStoreRatingInitParam param)
                {
                    if (param == null)
                        param = new DataStoreRatingInitParam();

                    initialValue = param.initialValue;
                    rangeMin = param.rangeMin;
                    rangeMax = param.rangeMax;
                    flag = (int)param.flag;
                    internalFlag = (int)param.internalFlag;
                    lockType = (short)param.lockType;
                    periodDuration = param.periodDuration;
                    periodHour = param.periodHour;
                    slot = param.slot;
                }
            }

            private struct DataStorePreparePostParamInt
            {
                private DataStorePermissionInt accessPermission;
                private DataStorePermissionInt updatePermission;
                private DataStorePersistenceInitParamInt persistenceInitParam;
                private CppArray name;
                private CppArray tags;
                private CppArray ratingInitParams;
                private CppArray meta;
                private uint size;
                private uint dataFlag;
                private ushort dataType;
                private ushort period;

                public DataStorePreparePostParamInt(List<IntPtr> useptr, DataStorePreparePostParam param, uint size) : this(useptr, param)
                {
                    this.size = size;
                }

                public DataStorePreparePostParamInt(List<IntPtr> useptr, DataStorePreparePostParam param)
                {
                    if (param == null)
                        param = new DataStorePreparePostParam();

                    size = param.size;
                    dataFlag = (uint)param.flag;
                    dataType = param.dataType;
                    period = param.period;

                    accessPermission = new DataStorePermissionInt(useptr, param.accessPermission);
                    updatePermission = new DataStorePermissionInt(useptr, param.updatePermission);
                    persistenceInitParam = new DataStorePersistenceInitParamInt(param.persistenceInitParam);

                    name = CppArray.StringToArray(useptr, param.name);
                    tags = CppArray.StringsToArray(useptr, param.tags);
                    meta = CppArray.ListToArray(useptr, param.meta);

                    var ratings = new List<DataStoreRatingInitParamInt>();
                    foreach (var kvp in param.ratingInitParams)
                    {
                        kvp.Value.slot = kvp.Key;
                        ratings.Add(new DataStoreRatingInitParamInt(kvp.Value));
                    }
                    ratingInitParams = CppArray.ListToArray(useptr, ratings);
                }
            }

            private struct ResultRangeInt
            {
                private uint offset;
                private uint size;

                public ResultRangeInt(ResultRange param)
                {
                    if (param == null)
                        param = new ResultRange();

                    offset = param.offset;
                    size = param.size;
                }
            }

            private struct DataStoreSearchParamInt
            {
                private uint searchType;
                private uint ownerType;
                private CppArray ownerIds;
                private CppArray destinationIds;
                private NpDateTime createdAfter;
                private NpDateTime createdBefore;
                private NpDateTime updatedAfter;
                private NpDateTime updatedBefore;
                private uint sortOrderColumn;
                private uint sortOrder;
                private ResultRangeInt resultRange;
                private CppArray tags;
                private uint resultOption;
                private uint minimalRatingFrequency;
                private int totalCountEnabled;
                private int useCache;
                private CppArray dataTypes;

                public DataStoreSearchParamInt(List<IntPtr> useptr, DataStoreSearchParam param)
                {
                    searchType = (uint)param.searchTarget;
                    ownerType = (uint)param.ownerType;
                    sortOrderColumn = (uint)param.resultOrderColumn;
                    sortOrder = (uint)param.resultOrder;
                    resultOption = (uint)param.resultOption;
                    minimalRatingFrequency = param.minimalRatingFrequency;

                    dataTypes = CppArray.ListToArray(useptr, param.dataTypes);

                    totalCountEnabled = param.totalCountEnabled ? 1 : 0;
                    useCache = param.useCache ? 1 : 0;

                    ownerIds = CppArray.ListToArray(useptr, param.ownerIds);
                    destinationIds = CppArray.ListToArray(useptr, param.destinationIds);

                    createdAfter = param.createdAfter;
                    createdBefore = param.createdBefore;
                    updatedAfter = param.updatedAfter;
                    updatedBefore = param.updatedBefore;

                    resultRange = new ResultRangeInt(param.resultRange);

                    tags = CppArray.StringsToArray(useptr, param.tags);
                }
            }

            private struct DataStoreDeleteParamInt
            {
                private ulong dataId;
                private ulong updatePassword;

                public DataStoreDeleteParamInt(DataStoreDeleteParam param)
                {
                    if (param == null)
                        param = new DataStoreDeleteParam();

                    dataId = param.dataId;
                    updatePassword = param.updatePassword;
                }
            }

            private struct DataStorePrepareUpdateParamInt
            {
                private ulong dataId;
                private ulong updatePassword;
                private uint size;

                public DataStorePrepareUpdateParamInt(DataStorePrepareUpdateParam param)
                {
                    if (param == null)
                        param = new DataStorePrepareUpdateParam();

                    dataId = param.dataId;
                    updatePassword = param.updatePassword;
                    size = param.size;
                }
            }

            private struct DataStorePersistenceTargetInt
            {
                private ulong ownerId;
                private ushort persistenceSlotId;

                public DataStorePersistenceTargetInt(DataStorePersistenceTarget param)
                {
                    if (param == null)
                        param = new DataStorePersistenceTarget();

                    ownerId = param.ownerId;
                    persistenceSlotId = param.persistenceSlotId;
                }
            }

            private struct DataStorePrepareGetParamInt
            {
                private ulong dataId;
                private ulong accessPassword;
                private DataStorePersistenceTargetInt persistenceTarget;
                private int useDataId;

                public DataStorePrepareGetParamInt(DataStorePrepareGetParam param)
                {
                    if (param == null)
                        param = new DataStorePrepareGetParam();

                    useDataId = (param.dataId != 0) ? 1 : 0;
                    dataId = param.dataId;
                    accessPassword = param.accessPassword;

                    persistenceTarget = new DataStorePersistenceTargetInt(param.persistenceTarget);
                }
            }

            private struct DataStoreTouchObjectParamInt
            {
                private ulong dataId;
                private ulong accessPassword;

                public DataStoreTouchObjectParamInt(DataStoreTouchObjectParam param)
                {
                    if (param == null)
                        param = new DataStoreTouchObjectParam();

                    dataId = param.dataId;
                    accessPassword = param.accessPassword;
                }
            }

            private struct DataStoreGetMetaParamInt
            {
                private ulong dataId;
                private ulong accessPassword;
                private DataStorePersistenceTargetInt persistenceTarget;
                private uint resultOption;
                private int useDataId;

                public DataStoreGetMetaParamInt(DataStoreGetMetaParam param)
                {
                    if (param == null)
                        param = new DataStoreGetMetaParam();

                    useDataId = (param.dataId != 0) ? 1 : 0;
                    dataId = param.dataId;
                    resultOption = (uint)param.resultOption;
                    accessPassword = param.accessPassword;

                    persistenceTarget = new DataStorePersistenceTargetInt(param.persistenceTarget);
                }
            }

            private struct DataStoreChangeMetaCompareParamInt
            {
                private DataStorePermissionInt accessPermission;
                private DataStorePermissionInt updatePermission;
                private CppArray name;
                private CppArray tags;
                private CppArray metaBinary;
                private uint comparisonFlag;
                private uint status;
                private ushort dataType;
                private ushort period;

                public DataStoreChangeMetaCompareParamInt(List<IntPtr> useptr, DataStoreChangeMetaCompareParam param)
                {
                    if (param == null)
                        param = new DataStoreChangeMetaCompareParam();

                    comparisonFlag = (uint)param.comparisonFlag;
                    status = (uint)param.status;
                    dataType = param.dataType;
                    period = param.period;

                    accessPermission = new DataStorePermissionInt(useptr, param.accessPermission);
                    updatePermission = new DataStorePermissionInt(useptr, param.updatePermission);

                    name = CppArray.StringToArray(useptr, param.name);
                    tags = CppArray.StringsToArray(useptr, param.tags);
                    metaBinary = CppArray.ListToArray(useptr, param.metaBinary);
                }
            }

            private struct DataStoreChangeMetaParamInt
            {
                private DataStorePermissionInt accessPermission;
                private DataStorePermissionInt updatePermission;
                private CppArray name;
                private CppArray tags;
                private CppArray metaBinary;
                private DataStoreChangeMetaCompareParamInt compareParam;
                private ulong dataId;
                private ulong updatePassword;
                private uint modifiesFlag;
                private uint dataStatus;
                private DataStorePersistenceTargetInt persistenceTarget;
                private ushort dataType;
                private ushort period;

                public DataStoreChangeMetaParamInt(List<IntPtr> useptr, DataStoreChangeMetaParam param)
                {
                    if (param == null)
                        param = new DataStoreChangeMetaParam();

                    dataId = param.dataId;
                    updatePassword = param.updatePassword;
                    modifiesFlag = (uint)param.modifiesFlag;
                    dataStatus = (uint)param.status;
                    dataType = param.dataType;
                    period = param.period;

                    persistenceTarget = new DataStorePersistenceTargetInt(param.persistenceTarget);
                    accessPermission = new DataStorePermissionInt(useptr, param.accessPermission);
                    updatePermission = new DataStorePermissionInt(useptr, param.updatePermission);

                    name = CppArray.StringToArray(useptr, param.name);
                    tags = CppArray.StringsToArray(useptr, param.tags);
                    metaBinary = CppArray.ListToArray(useptr, param.metaBinary);

                    compareParam = new DataStoreChangeMetaCompareParamInt(useptr, param.compareParam);
                }
            }

            private struct DataStoreRatingTargetInt
            {
                private ulong dataId;
                private sbyte slot;

                public DataStoreRatingTargetInt(DataStoreRatingTarget param)
                {
                    if (param == null)
                        param = new DataStoreRatingTarget();

                    dataId = param.dataId;
                    slot = param.slot;
                }
            }

            private struct DataStoreRateObjectParamInt
            {
                private ulong accessPassword;
                private int ratingValue;

                public DataStoreRateObjectParamInt(DataStoreRateObjectParam param)
                {
                    if (param == null)
                        param = new DataStoreRateObjectParam();

                    accessPassword = param.accessPassword;
                    ratingValue = param.ratingValue;
                }
            }
        }

		public static class NgsFacade
		{
			// TODO
			private static extern bool Ngs_LoginAsync(uint asyncId, uint gameServerId, ref CppArray accessKey, ulong nsaId, ref CppArray nsaIdToken, int timeOut);
			
			// TODO
			public static bool LoginAsync(out uint asyncId, uint gameServerId, string accessKey, NetworkServiceAccountId nsaId, byte[] nsaIdToken, [Optional] [DefaultParameterValue(30000)] int timeOut, [Optional] NexPlugin.NgsFacade.LoginCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ngs_LogoutAsync(uint asyncId, IntPtr pNgsFacade);
			
			// TODO
			public static bool LogoutAsync(out uint asyncId, IntPtr pNgsFacade, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ngs_TestConnectivityAsync(uint asyncId, IntPtr pNgsFacade);
			
			// TODO
			public static bool TestConnectivityAsync(out uint asyncId, IntPtr pNgsFacade, [Optional] NexPlugin.NgsFacade.TestConnectivityCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static void NGSLoginResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void TestConnectivityResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			public static void Callback(AsyncResultInt res, object callback) { }
		}

		public static class Ranking
		{
			// TODO
			private static extern bool Ranking_UploadCommonDataAsync(uint asyncId, IntPtr pNgsFacade, ref CppArray commonData, ulong nexUniqueId, int timeOut);
			
			// TODO
			public static bool UploadCommonDataAsync(out uint asyncId, IntPtr pNgsFacade, List<byte> commonData, ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking_DeleteCommonDataAsync(uint asyncId, IntPtr pNgsFacade, ulong nexUniqueId, int timeOut);
			
			// TODO
			public static bool DeleteCommonDataAsync(out uint asyncId, IntPtr pNgsFacade, ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking_GetCommonDataAsync(uint asyncId, IntPtr pNgsFacade, ulong nexUniqueId, int timeOut);
			
			// TODO
			public static bool GetCommonDataAsync(out uint asyncId, IntPtr pNgsFacade, ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.Ranking.GetCommonDataCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking_UploadScoreAsync(uint asyncId, IntPtr pNgsFacade, ref RankingScoreDataInt scoreData, ulong nexUniqueId, int timeOut);
			
			// TODO
			public static bool UploadScoreAsync(out uint asyncId, IntPtr pNgsFacade, RankingScoreData scoreData, ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking_DeleteScoreAsync(uint asyncId, IntPtr pNgsFacade, int useCategory, uint category, ulong nexUniqueId, int timeOut);
			
			// TODO
			public static bool DeleteScoreAsync(out uint asyncId, IntPtr pNgsFacade, bool useCategory, uint category, ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking_GetRankingAsync(uint asyncId, IntPtr pNgsFacade, uint rankingMode, uint category, ref RankingOrderParamInt orderParam, ulong nexUniqueId, ulong principalId, int timeOut);
			
			// TODO
			public static bool GetRankingAsync(out uint asyncId, IntPtr pNgsFacade, NexPlugin.Ranking.RankingMode rankingMode, uint category, RankingOrderParam orderParam, ulong nexUniqueId, ulong principalId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.Ranking.GetRankingCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking_GetRankingByPIDListAsync(uint asyncId, IntPtr pNgsFacade, ref CppArray principalIdList, uint rankingMode, uint category, ref RankingOrderParamInt orderParam, ulong nexUniqueId, int timeOut);
			
			// TODO
			public static bool GetRankingByPIDListAsync(out uint asyncId, IntPtr pNgsFacade, List<ulong> principalIdList, NexPlugin.Ranking.RankingMode rankingMode, uint category, RankingOrderParam orderParam, ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.Ranking.GetRankingCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking_GetRankingByUIDListAsync(uint asyncId, IntPtr pNgsFacade, ref CppArray nexUniqueIdList, uint rankingMode, uint category, ref RankingOrderParamInt orderParam, ulong nexUniqueId, int timeOut);
			
			// TODO
			public static bool GetRankingByUIDListAsync(out uint asyncId, IntPtr pNgsFacade, List<ulong> nexUniqueIdList, NexPlugin.Ranking.RankingMode rankingMode, uint category, RankingOrderParam orderParam, ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.Ranking.GetRankingCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking_GetApproxOrderAsync(uint asyncId, IntPtr pNgsFacade, uint category, ref RankingOrderParamInt orderParam, uint score, ulong nexUniqueId, ulong principalId, int timeOut);
			
			// TODO
			public static bool GetApproxOrderAsync(out uint asyncId, IntPtr pNgsFacade, uint category, RankingOrderParam orderParam, uint score, ulong nexUniqueId, ulong principalId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.Ranking.GetApproxOrderCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking_GetStatsAsync(uint asyncId, IntPtr pNgsFacade, uint category, ref RankingOrderParamInt orderParam, uint flags, int timeOut);
			
			// TODO
			public static bool GetStatsAsync(out uint asyncId, IntPtr pNgsFacade, uint category, RankingOrderParam orderParam, NexPlugin.Ranking.StatsFlag flags, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.Ranking.GetStatsCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking_ChangeAttributesAsync(uint asyncId, IntPtr pNgsFacade, int useCategory, uint category, ref RankingChangeAttributesParamInt changeParam, ulong nexUniqueId, int timeOut);
			
			// TODO
			public static bool ChangeAttributesAsync(out uint asyncId, IntPtr pNgsFacade, bool useCategory, uint category, RankingChangeAttributesParam changeParam, ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking_GetCachedTopXRankingAsync(uint asyncId, IntPtr pNgsFacade, uint category, ref RankingOrderParamInt orderParam, int timeOut);
			
			// TODO
			public static bool GetCachedTopXRankingAsync(out uint asyncId, IntPtr pNgsFacade, uint category, RankingOrderParam orderParam, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.Ranking.GetCachedTopXRankingCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking_GetCachedTopXRankingsAsync(uint asyncId, IntPtr pNgsFacade, int useOneRankingOrderParam, ref CppArray categories, ref CppArray orderParams, int timeOut);
			
			// TODO
			public static bool GetCachedTopXRankingsAsync(out uint asyncId, IntPtr pNgsFacade, bool useOneRankingOrderParam, List<uint> categories, List<RankingOrderParam> orderParams, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.Ranking.GetCachedTopXRankingsCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern RankingCachedResult.LocalUpdateState Ranking_LocalUpdate(ref IntPtr pNewResult, ref RankingCachedResultInt cachedResult, ref RankingOrderParamInt orderParam, ref RankingScoreDataInt scoreData, ulong pid, ulong nexUniqueId, ref NpDateTime utcCurrentTime, ref CppArray pCommonData);
			
			// TODO
			public static RankingCachedResult.LocalUpdateState LocalUpdate(out RankingCachedResult newResult, RankingCachedResult result, RankingOrderParam orderParam, RankingScoreData scoreData, ulong pid, ulong nexUniqueId, NpDateTime utcCurrentTime, List<byte> pCommonData)
            {
                newResult = default;
                return default;
            }

            // TODO
            private static extern void Ranking_DeleteCachedResult(IntPtr cachedResult);
			
			// TODO
			private static void Ranking_GetCommonDataResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void Ranking_GetRankingResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void Ranking_GetApproxOrderResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void Ranking_GetStatsResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void Ranking_GetCachedTopXRankingResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void Ranking_GetCachedTopXRankingsResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			public static void Callback(AsyncResultInt res, object callback) { }

            private struct RankingRankDataInt : IExchangeList<RankingRankData>
            {
                private ulong uniqueId;
                private uint category;
                private uint score;
                private ulong param;
                private NpDateTime updateTime;
                private CppArray commonData;
                private ulong principalId;
                private uint order;
                private byte group0;
                private byte group1;

                // TODO
                public RankingRankData ExchangeStruct() { return default; }

                public RankingRankDataInt(List<IntPtr> useptr, RankingRankData param)
                {
                    if (param == null)
                        param = new RankingRankData();

                    principalId = param.principalId;
                    order = param.order;
                    uniqueId = param.uniqueId;
                    category = param.category;
                    score = param.score;
                    this.param = param.param;
                    updateTime = param.updateTime;
                    group0 = param.group0;
                    group1 = param.group1;

                    commonData = CppArray.ListToArray(useptr, param.commonData);
                }
            }

            private struct RankingResultInt : IExchangeList<RankingResult>
            {
                private CppArray rankDataList;
                private NpDateTime sinceTime;
                private uint totalCount;

                // TODO
                public static RankingResult ExchangePtrToStruct(IntPtr src) { return default; }

                // TODO
                public RankingResult ExchangeStruct() { return default; }

                // TODO
                public RankingResultInt(List<IntPtr> useptr, RankingResult param)
                {
                    if (param == null)
                        param = new RankingResult();

                    totalCount = param.totalCount;
                    sinceTime = param.sinceTime;

                    // Result ignored?
                    _ = CppArray.ListToArray(new List<IntPtr>(), new RankingRankData().commonData);

                    rankDataList = CppArray.ListToArray(useptr, param.rankDataList);
                }
            }

            private struct RankingCachedResultInt : IExchangeList<RankingCachedResult>
            {
                public NpDateTime createdTime;
                public NpDateTime expiredTime;
                public RankingResultInt rankingResult;
                public uint maxLength;

                // TODO
                public static RankingCachedResult ExchangePtrToStruct(IntPtr src) { return default; }

                // TODO
                public RankingCachedResult ExchangeStruct() { return default; }

                public RankingCachedResultInt(List<IntPtr> useptr, RankingCachedResult param)
                {
                    if (param == null)
                        param = new RankingCachedResult();

                    maxLength = param.maxLength;
                    createdTime = param.createdTime;
                    expiredTime = param.expiredTime;

                    rankingResult = new RankingResultInt(useptr, param);
                }
            }

            private struct RankingScoreDataInt
            {
                private ulong param;
                private uint category;
                private uint score;
                private byte orderBy;
                private byte updateMode;
                private byte group0;
                private byte group1;

                public RankingScoreDataInt(RankingScoreData param)
                {
                    if (param == null)
                        param = new RankingScoreData();

                    this.param = param.param;
                    category = param.category;
                    score = param.score;
                    orderBy = (byte)param.orderBy;
                    updateMode = (byte)param.updateMode;
                    group0 = param.group0;
                    group1 = param.group1;
                }
            }

            private struct RankingOrderParamInt
            {
                private byte orderCalc;
                private byte groupIndex;
                private byte groupNum;
                private byte timeScope;
                private uint offset;
                private byte length;

                public RankingOrderParamInt(RankingOrderParam param)
                {
                    if (param == null)
                        param = new RankingOrderParam();

                    orderCalc = (byte)param.orderCalculation;
                    groupIndex = (byte)param.groupIndex;
                    groupNum = param.groupNum;
                    timeScope = (byte)param.timeScope;
                    offset = param.offset;
                    length = param.length;
                }
            }

            private struct RankingChangeAttributesParamInt
            {
                private ulong param;
                private byte modificationFlag;
                private byte group0;
                private byte group1;

                public RankingChangeAttributesParamInt(RankingChangeAttributesParam param)
                {
                    if (param == null)
                        param = new RankingChangeAttributesParam();

                    this.param = param.param;
                    modificationFlag = (byte)param.modificationFlag;
                    group0 = param.group0;
                    group1 = param.group1;
                }
            }
        }

		public static class Ranking2
		{
			// TODO
			private static extern bool Ranking2_PutScoreAsync(uint asyncId, IntPtr pNgsFacade, ref Ranking2ScoreDataInt pParam, ulong nexUniqueId, int timeOut);
			
			// TODO
			public static bool PutScoreAsync(out uint asyncId, IntPtr pNgsFacade, Ranking2ScoreData scoreData, ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

			// TODO
			private static extern bool Ranking2_PutScoreListAsync(uint asyncId, IntPtr pNgsFacade, ref CppArray pParam, ulong nexUniqueId, int timeOut);
			
			// TODO
			public static bool PutScoreAsync(out uint asyncId, IntPtr pNgsFacade, List<Ranking2ScoreData> scoreDataList, ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking2_PutCommonDataAsync(uint asyncId, IntPtr pNgsFacade, ref Ranking2CommonDataInt commonData, ulong nexUniqueId, int timeOut);
			
			// TODO
			public static bool PutCommonDataAsync(out uint asyncId, IntPtr pNgsFacade, Ranking2CommonData commonData, ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking2_GetCommonDataAsync(uint asyncId, IntPtr pNgsFacade, uint optionFlags, ulong principalId, ulong nexUniqueId, int timeOut);
			
			// TODO
			public static bool GetCommonDataAsync(out uint asyncId, IntPtr pNgsFacade, NexPlugin.Ranking2.Ranking2GetOptionFlags optionFlags, ulong principalId, ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, NexPlugin.Ranking2.GetCommonDataCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking2_DeleteCommonDataAsync(uint asyncId, IntPtr pNgsFacade, ulong nexUniqueId, int timeOut);
			
			// TODO
			public static bool DeleteCommonDataAsync(out uint asyncId, IntPtr pNgsFacade, ulong nexUniqueId, [Optional] [DefaultParameterValue(0)] int timeOut, AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking2_GetRankingAsync(uint asyncId, IntPtr pNgsFacade, ref Ranking2GetParamInt getParam, int timeOut);
			
			// TODO
			public static bool GetRankingAsync(out uint asyncId, IntPtr pNgsFacade, Ranking2GetParam getParam, [Optional] [DefaultParameterValue(0)] int timeOut, NexPlugin.Ranking2.GetRankingCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking2_GetRankingByListAsync(uint asyncId, IntPtr pNgsFacade, ref Ranking2GetByListParamInt getParam, ref CppArray principalIdList, int timeOut);
			
			// TODO
			public static bool GetRankingAsync(out uint asyncId, IntPtr pNgsFacade, Ranking2GetByListParam getParam, List<ulong> principalIdList, [Optional] [DefaultParameterValue(0)] int timeOut, NexPlugin.Ranking2.GetRankingCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking2_GetCategorySettingAsync(uint asyncId, IntPtr pNgsFacade, uint category, int timeOut);

			// TODO
			public static bool GetCategorySettingAsync(out uint asyncId, IntPtr pNgsFacade, uint category, [Optional] [DefaultParameterValue(0)] int timeOut, NexPlugin.Ranking2.GetCategorySettingCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking2_GetRankingChartAsync(uint asyncId, IntPtr pNgsFacade, ref Ranking2ChartInfoInput info, int timeOut);
			
			// TODO
			public static bool GetRankingChartAsync(out uint asyncId, IntPtr pNgsFacade, Ranking2ChartInfoInput info, [Optional] [DefaultParameterValue(0)] int timeOut, NexPlugin.Ranking2.GetRanking2ChartInfoCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking2_GetRankingChartsAsync(uint asyncId, IntPtr pNgsFacade, ref CppArray info, int timeOut);
			
			// TODO
			public static bool GetRankingChartAsync(out uint asyncId, IntPtr pNgsFacade, List<Ranking2ChartInfoInput> info, [Optional] [DefaultParameterValue(0)] int timeOut, NexPlugin.Ranking2.GetRanking2ChartInfoListCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Ranking2_GetEstimateScoreRankAsync(uint asyncId, IntPtr pNgsFacade, ref Ranking2EstimateScoreRankInput info, int timeOut);
			
			// TODO
			public static bool GetEstimateScoreRankAsync(out uint asyncId, IntPtr pNgsFacade, Ranking2EstimateScoreRankInput info, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.Ranking2.GetRanking2EstimateScoreRankCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static void Ranking2_GetCommonDataResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void Ranking2_GetRankingResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void Ranking2_GetCategorySettingResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void Ranking2_GetRanking2ChartInfoResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void Ranking2_GetRanking2ChartInfoListResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void Ranking2_GetRanking2EstimateScoreRankResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			public static void Callback(AsyncResultInt res, object callback) { }

            private struct Ranking2CommonDataInt
            {
                public CppArray binaryData;
                public CppArray userName;

                // TODO
                public static Ranking2CommonData ExchangePtrToStruct(IntPtr src) { return default; }

                // TODO
                public Ranking2CommonData ExchangeStruct() { return default; }

                public Ranking2CommonDataInt(List<IntPtr> useptr, Ranking2CommonData param)
                {
                    if (param == null)
                        param = new Ranking2CommonData();

                    binaryData = CppArray.ListToArray(useptr, param.binaryData);
                    userName = CppArray.StringToArray(useptr, param.userName);
                }
            }

            private struct Ranking2RankDataInt : IExchangeList<Ranking2RankData>
            {
                private Ranking2CommonDataInt commonData;
                private ulong misc;
                private ulong nexUniqueId;
                private uint rank;
                private uint score;
                private ulong principalId;

                // TODO
                public Ranking2RankData ExchangeStruct() { return default; }
            }

            private struct Ranking2InfoInt
            {
                private CppArray ranking2RankDataList;
                private uint numRankedIn;
                private uint lowestRank;
                private int season;

                // TODO
                public static Ranking2Info ExchangePtrToStruct(IntPtr src) { return default; }
            }

            private struct Ranking2CategorySettingInt
            {
                private uint minScore;
                private uint maxScore;
                private ushort lowestRank;
                private byte maxSeasonsToGoBack;
                private byte resetMode;
                private byte resetHour;
                private byte resetDay;
                private ushort resetMonth;
                private byte scoreorder;

                // TODO
                public static Ranking2CategorySetting ExchangePtrToStruct(IntPtr src) { return default; }
            }

            private struct Ranking2ChartInfoInt : IExchangeList<Ranking2ChartInfo>
            {
                private uint index;
                private uint category;
                private uint season;
                private uint samplingRate;
                private uint scoreOrder;
                private uint estimateLength;
                private uint estimateHighestScore;
                private uint estimateLowestScore;
                private uint estimateMedianScore;
                private uint highestBinsScore;
                private uint lowestBinsScore;
                private uint binsWidth;
                private uint attribute1;
                private uint attribute2;
                private NpDateTime createTime;
                private double estimateAverageScore;
                private CppArray quantities;
                private byte binsSize;

                // TODO
                public static Ranking2ChartInfo ExchangePtrToStruct(IntPtr src) { return default; }

                // TODO
                public Ranking2ChartInfo ExchangeStruct() { return default; }
            }

            private struct Ranking2ScoreDataInt
            {
                private uint category;
                private uint score;
                private ulong misc;

                public Ranking2ScoreDataInt(Ranking2ScoreData param)
                {
                    if (param == null)
                        param = new Ranking2ScoreData();

                    category = param.category;
                    score = param.score;
                    misc = param.misc;
                }
            }

            private struct Ranking2GetParamInt
            {
                private ulong nexUniqueId;
                private ulong principalId;
                private uint category;
                private uint offset;
                private uint length;
                private uint optionFlags;
                private uint sortFlags;
                private byte mode;
                private byte numSeasonsToGoBack;

                public Ranking2GetParamInt(List<IntPtr> useptr, Ranking2GetParam param)
                {
                    if (param == null)
                        param = new Ranking2GetParam();

                    nexUniqueId = param.nexUniqueId;
                    category = param.category;
                    offset = param.offset;
                    length = param.length;
                    principalId = param.principalId;
                    optionFlags = (uint)param.optionFlags;
                    sortFlags = (uint)param.sortFlags;
                    mode = (byte)param.mode;
                    numSeasonsToGoBack = param.numSeasonsToGoBack;
                }
            }

            private struct Ranking2GetByListParamInt
            {
                private uint category;
                private uint offset;
                private uint length;
                private uint optionFlags;
                private uint sortFlags;
                private byte numSeasonsToGoBack;

                public Ranking2GetByListParamInt(List<IntPtr> useptr, Ranking2GetByListParam param)
                {
                    if (param == null)
                        param = new Ranking2GetByListParam();

                    category = param.category;
                    offset = param.offset;
                    length = param.length;
                    optionFlags = (uint)param.optionFlags;
                    sortFlags = (uint)param.sortFlags;
                    numSeasonsToGoBack = param.numSeasonsToGoBack;
                }
            }
        }

		public static class SmartDeviceVoiceChat
		{
			// TODO
			private static extern bool SmartDeviceVoiceChat_ShowAppPageAsync(uint asyncId, ref SmartDeviceVoiceChatShowAppPageParamInt pParam);
			
			// TODO
			public static bool ShowAppPageAsync(out uint asyncId, SmartDeviceVoiceChatShowAppPageParam param, [Optional] NexPlugin.SmartDeviceVoiceChat.ShowAppPageCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool SmartDeviceVoiceChat_ChangeVoiceChatChannelAsync(uint asyncId, ref SmartDeviceVoiceChatChangeVoiceChatChannelParamInt pParam, int timeOut);
			
			// TODO
			public static bool ChangeVoiceChatChannelAsync(out uint asyncId, SmartDeviceVoiceChatChangeVoiceChatChannelParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool SmartDeviceVoiceChat_GetAvailabilityAsync(uint asyncId, int timeOut);
			
			// TODO
			public static bool GetAvailabilityAsync(out uint asyncId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.SmartDeviceVoiceChat.GetAvailabilityCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool SmartDeviceVoiceChat_JoinRoomAsync(uint asyncId, ref SmartDeviceVoiceChatJoinRoomParamInt pParam, int timeOut = 0);
			
			// TODO
			public static bool JoinRoomAsync(out uint asyncId, SmartDeviceVoiceChatJoinRoomParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.SmartDeviceVoiceChat.JoinRoomCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool SmartDeviceVoiceChat_LeaveRoomAsync(uint asyncId, ref SmartDeviceVoiceChatLeaveRoomParamInt pParam, int timeOut = 0);
			
			// TODO
			public static bool LeaveRoomAsync(out uint asyncId, SmartDeviceVoiceChatLeaveRoomParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

			// TODO
			private static extern bool SmartDeviceVoiceChat_LeaveRoom(ref SmartDeviceVoiceChatLeaveRoomParamInt pParam);
			
			// TODO
			public static bool LeaveRoom(SmartDeviceVoiceChatLeaveRoomParam param) { return default; }
			
			// TODO
			private static void SmartDeviceVoiceChat_GetAvailabilityResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void SmartDeviceVoiceChat_JoinRoomResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void SmartDeviceVoiceChat_ShowAppPageResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			public static void Callback(AsyncResultInt res, object callback) { }

            private struct SmartDeviceVoiceChatJoinRoomResultInt
            {
                private ulong roomId;

                public SmartDeviceVoiceChatJoinRoomResultInt(SmartDeviceVoiceChatJoinRoomResult param)
                {
                    if (param == null)
                        param = new SmartDeviceVoiceChatJoinRoomResult();

                    roomId = param.roomId;
                }

                // TODO
                public static SmartDeviceVoiceChatJoinRoomResult ExchangePtrToStruct(IntPtr src) { return default; }
            }

            private struct SmartDeviceVoiceChatShowAppPageResultInt
            {
                private int status;

                public SmartDeviceVoiceChatShowAppPageResultInt(SmartDeviceVoiceChatShowAppPageResult param)
                {
                    if (param == null)
                        param = new SmartDeviceVoiceChatShowAppPageResult();

                    status = (int)param.status;
                }

                // TODO
                public static SmartDeviceVoiceChatShowAppPageResult ExchangePtrToStruct(IntPtr src) { return default; }
            }

            private struct SmartDeviceVoiceChatJoinRoomParamInt
            {
                private ulong sessionId;
                private uint gameMode;
                private uint channelId;

                public SmartDeviceVoiceChatJoinRoomParamInt(SmartDeviceVoiceChatJoinRoomParam param)
                {
                    if (param == null)
                        param = new SmartDeviceVoiceChatJoinRoomParam();

                    sessionId = param.sessionId;
                    gameMode = param.gameMode;
                    channelId = param.channelId;
                }
            }

            private struct SmartDeviceVoiceChatLeaveRoomParamInt
            {
                private ulong roomId;

                public SmartDeviceVoiceChatLeaveRoomParamInt(SmartDeviceVoiceChatLeaveRoomParam param)
                {
                    if (param == null)
                        param = new SmartDeviceVoiceChatLeaveRoomParam();

                    roomId = param.roomId;
                }
            }

            private struct SmartDeviceVoiceChatChangeVoiceChatChannelParamInt
            {
                private ulong roomId;
                private uint channelId;

                public SmartDeviceVoiceChatChangeVoiceChatChannelParamInt(SmartDeviceVoiceChatChangeVoiceChatChannelParam param)
                {
                    if (param == null)
                        param = new SmartDeviceVoiceChatChangeVoiceChatChannelParam();

                    roomId = param.roomId;
                    channelId = param.channelId;
                }
            }

            private struct SmartDeviceVoiceChatShowAppPageParamInt
            {
                private UserHandle userHandle;

                public SmartDeviceVoiceChatShowAppPageParamInt(ref SmartDeviceVoiceChatShowAppPageParam param)
                {
                    if (param == null)
                        param = new SmartDeviceVoiceChatShowAppPageParam();

                    userHandle = param.userHandle;
                }
            }
        }

		public static class Subscriber
		{
			// TODO
			private static List<List<SubscriberContent>> Exchange(IntPtr src) { return default; }

			// TODO
			private static extern bool Subscriber_PostContentAsync(uint asyncId, IntPtr pNgsFacade, ref SubscriberPostContentParamInt pParam, int timeOut);
			
			// TODO
			public static bool PostContentAsync(out uint asyncId, IntPtr pNgsFacade, SubscriberPostContentParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.Subscriber.PostContentCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Subscriber_GetContentAsync(uint asyncId, IntPtr pNgsFacade, ref SubscriberGetContentParamInt pParam, int timeOut);
			
			// TODO
			public static bool GetContentAsync(out uint asyncId, IntPtr pNgsFacade, SubscriberGetContentParam param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.Subscriber.GetContentCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Subscriber_GetContentsAsync(uint asyncId, IntPtr pNgsFacade, ref CppArray pParam, int timeOut);
			
			// TODO
			public static bool GetContentAsync(out uint asyncId, IntPtr pNgsFacade, List<SubscriberGetContentParam> param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.Subscriber.GetContentsCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Subscriber_DeleteContentAsync(uint asyncId, IntPtr pNgsFacade, ref CppArray topics, ulong contentId, int timeOut);
			
			// TODO
			public static bool DeleteContentAsync(out uint asyncId, IntPtr pNgsFacade, List<uint> topics, ulong contentId, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Subscriber_GetFriendUserStatusesAsync(uint asyncId, IntPtr pNgsFacade, int timeOut);
			
			// TODO
			public static bool GetFriendUserStatusesAsync(out uint asyncId, IntPtr pNgsFacade, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.Subscriber.GetSubscriberUserStatusInfoCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Subscriber_GetFriendUserStatusesWithKeyAsync(uint asyncId, IntPtr pNgsFacade, ref CppArray keys, int timeOut);
			
			// TODO
			public static bool GetFriendUserStatusesAsync(out uint asyncId, IntPtr pNgsFacade, List<byte> keys, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.Subscriber.GetSubscriberUserStatusInfoCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Subscriber_GetUserStatusesAsync(uint asyncId, IntPtr pNgsFacade, ref CppArray users, ref CppArray keys, int timeOut);
			
			// TODO
			public static bool GetUserStatusesAsync(out uint asyncId, IntPtr pNgsFacade, List<ulong> users, List<byte> keys, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.Subscriber.GetSubscriberUserStatusInfoCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Subscriber_UpdateUserStatusAsync(uint asyncId, IntPtr pNgsFacade, ref CppArray param, int isNotify, int timeOut);
			
			// TODO
			public static bool UpdateUserStatusAsync(out uint asyncId, IntPtr pNgsFacade, List<SubscriberUserStatusParam> param, bool isNotify, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Subscriber_GetFriendUserStatusesCacheMode(IntPtr pNgsFacade, ref int result);
			
			// TODO
			public static bool GetFriendUserStatusesCacheMode(IntPtr pNgsFacade, out bool result)
            {
                result = default;
                return default;
            }

            // TODO
            private static extern bool Subscriber_GetFriendUserStatusesCacheLastResult(IntPtr pNgsFacade, ref Result result);
			
			// TODO
			public static bool GetFriendUserStatusesCacheLastResult(IntPtr pNgsFacade, out Result result)
            {
                result = default;
                return default;
            }

            // TODO
            private static extern bool Subscriber_GetFriendUserStatuses(IntPtr pNgsFacade, ref IntPtr infos, ref Result result);
			
			// TODO
			public static bool GetFriendUserStatuses(IntPtr pNgsFacade, out List<SubscriberUserStatusInfo> infos, out Result result)
            {
                infos = default;
                result = default;
                return default;
            }

            // TODO
            private static extern bool Subscriber_GetFriendUserStatusesWithKey(IntPtr pNgsFacade, ref CppArray users, ref IntPtr infos, ref Result result);
			
			// TODO
			public static bool GetFriendUserStatuses(IntPtr pNgsFacade, List<ulong> users, out List<SubscriberUserStatusInfo> infos, out Result result)
            {
                infos = default;
                result = default;
                return default;
            }

			// TODO
			private static extern void Subscriber_DeleteSubscriberUserStatusInfo(IntPtr info);
			
			// TODO
			private static void Subscriber_PostContentResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void Subscriber_GetContentResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void Subscriber_GetContentsResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void Subscriber_UserStatusInfoResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			public static void Callback(AsyncResultInt res, object callback) { }

            private struct SubscriberContentInt : IExchangeList<SubscriberContent>
            {
                private ulong contentId;
                private NpDateTime postTime;
                private CppArray topics;
                private CppArray binary;
                private CppArray message;
                private ulong pid;

                // TODO
                public SubscriberContent ExchangeStruct() { return default; }
            }

            private struct SubscriberPostContentParamInt
            {
                private CppArray topics;
                private CppArray contentBinary;
                private CppArray contentMessage;

                public SubscriberPostContentParamInt(List<IntPtr> useptr, SubscriberPostContentParam param)
                {
                    if (param == null)
                        param = new SubscriberPostContentParam();

                    topics = CppArray.ListToArray(useptr, param.topics);
                    contentBinary = CppArray.ListToArray(useptr, param.binary);
                    contentMessage = CppArray.StringToArray(useptr, param.message);
                }
            }

            public struct SubscriberGetContentParamInt
            {
                private uint size;
                private uint offset;
                private ulong minimumContentId;
                private uint topic;

                public SubscriberGetContentParamInt(SubscriberGetContentParam param)
                {
                    if (param == null)
                        param = new SubscriberGetContentParam();

                    size = param.size;
                    offset = param.offset;
                    minimumContentId = param.minimumContentId;
                    topic = param.topic;
                }
            }

            private struct SubscriberUserStatusInfoInt : IExchangeList<SubscriberUserStatusInfo>
            {
                private CppArray keys;
                private CppArray values;
                private ulong pid;

                // TODO
                public static SubscriberUserStatusInfo ExchangePtrToStruct(IntPtr src) { return default; }

                // TODO
                public SubscriberUserStatusInfo ExchangeStruct() { return default; }
            }

            private struct SubscriberUserStatusParamInt
            {
                private CppArray value;
                private byte key;

                public SubscriberUserStatusParamInt(List<IntPtr> useptr, SubscriberUserStatusParam param)
                {
                    if (param == null)
                        param = new SubscriberUserStatusParam();

                    value = CppArray.ListToArray(useptr, param.value);
                    key = param.key;
                }
            }
        }

		public class Util_UnmanagedManager
		{
			// TODO
			public static IntPtr AllocHGlobal(int size, bool output = true) { return default; }
			
			// TODO
			public static bool FreeHGlobal(IntPtr p, bool output = true) { return default; }
			
			public static int GetAllocedCount() {
			    return 0;
			}
			
			public static int GetUsedAllocsize() {
			    return 0;
			}
		}

		public static class Utility
		{
			// TODO
			private static extern bool Utility_AcquireNexUniqueIdAsync(uint asyncId, IntPtr pNgsFacade, int timeOut);
			
			// TODO
			public static bool AcquireNexUniqueIdAsync(out uint asyncId, IntPtr pNgsFacade, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.Utility.AcquireNexUniqueIdCB callback)
            {
                asyncId = default;
                return default;
            }

			// TODO
			private static extern bool Utility_AcquireNexUniqueIdWithPasswordAsync(uint asyncId, IntPtr pNgsFacade, int timeOut);
			
			// TODO
			public static bool AcquireNexUniqueIdWithPasswordAsync(out uint asyncId, IntPtr pNgsFacade, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.Utility.AcquireNexUniqueIdWithPasswordCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Utility_AssociateNexUniqueIdWithMyPrincipalIdAsync(uint asyncId, IntPtr pNgsFacade, ref UniqueIdInfoInt pParam, int timeOut);
			
			// TODO
			public static bool AssociateNexUniqueIdWithMyPrincipalIdAsync(out uint asyncId, IntPtr pNgsFacade, UniqueIdInfo param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Utility_AssociateNexUniqueIdWithMyPrincipalIdListAsync(uint asyncId, IntPtr pNgsFacade, ref CppArray pParam, int timeOut);
			
			// TODO
			public static bool AssociateNexUniqueIdWithMyPrincipalIdAsync(out uint asyncId, IntPtr pNgsFacade, List<UniqueIdInfo> param, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Utility_GetAssociatedNexUniqueIdWithMyPrincipalIdAsync(uint asyncId, IntPtr pNgsFacade, int timeOut);
			
			// TODO
			public static bool GetAssociatedNexUniqueIdWithMyPrincipalIdAsync(out uint asyncId, IntPtr pNgsFacade, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.Utility.GetAssociatedNexUniqueIdWithMyPrincipalIdCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Utility_GetAssociatedNexUniqueIdWithMyPrincipalIdListAsync(uint asyncId, IntPtr pNgsFacade, int timeOut);
			
			// TODO
			public static bool GetAssociatedNexUniqueIdWithMyPrincipalIdAsync(out uint asyncId, IntPtr pNgsFacade, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.Utility.GetAssociatedNexUniqueIdWithMyPrincipalIdListCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static extern bool Utility_GetIntegerSettingsAsync(uint asyncId, IntPtr pNgsFacade, uint integerSettingIndex, int timeOut);
			
			// TODO
			public static bool GetIntegerSettingsAsync(out uint asyncId, IntPtr pNgsFacade, uint integerSettingIndex, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] NexPlugin.Utility.GetIntegerSettingsCB callback)
            {
                asyncId = default;
                return default;
            }

            // TODO
            private static void AcquireNexUniqueIdResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void AcquireNexUniqueIdWithPasswordResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void GetAssociatedNexUniqueIdWithMyPrincipalIdResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void GetAssociatedNexUniqueIdWithMyPrincipalIdListResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			private static void GetIntegerSettingsResult(ref AsyncResultInt asyncResult, object callback) { }
			
			// TODO
			public static void Callback(AsyncResultInt res, object callback) { }

            private struct UniqueIdInfoInt : IExchangeList<UniqueIdInfo>
            {
                private ulong nexUniqueId;
                private ulong nexUniqueIdPassword;

                // TODO
                public UniqueIdInfo ExchangeStruct() { return default; }

                // TODO
                public static UniqueIdInfo ExchangePtrToStruct(IntPtr src) { return default; }

                public UniqueIdInfoInt(UniqueIdInfo param)
                {
                    if (param == null)
                        param = new UniqueIdInfo();

                    nexUniqueId = param.nexUniqueId;
                    nexUniqueIdPassword = param.nexUniqueIdPassword;
                }
            }

            private struct IntegerSettings
            {
                public int value;
                public ushort key;
            }
        }
	}
}