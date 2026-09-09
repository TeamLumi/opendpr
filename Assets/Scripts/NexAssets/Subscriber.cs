using NexPlugin;
using nn;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace NexAssets
{
	public class Subscriber : Common
	{
		[SerializeField]
		private bool m_IsPeriodObject;

		private Dictionary<int, FunctionInfo> FunctionInfos;
		private static List<ApiCallsFrequency> s_ApiCallsFrequencyList = new List<ApiCallsFrequency>();
		
		// TODO
		public ASYNCSTATE PostContentAsync(SubscriberPostContentParam param, [Optional] NexPlugin.Subscriber.PostContentCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE PostContentAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetContentAsync(SubscriberGetContentParam param, [Optional] NexPlugin.Subscriber.GetContentCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetContentAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetContentsAsync(List<SubscriberGetContentParam> paramList, [Optional] NexPlugin.Subscriber.GetContentsCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetContentsAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE DeleteContentAsync(List<uint> topics, ulong contentId, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE DeleteContentAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetFriendUserStatusesAsync([Optional] NexPlugin.Subscriber.GetSubscriberUserStatusInfoCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetFriendUserStatusesAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetFriendUserStatusesAsync(List<byte> keys, [Optional] NexPlugin.Subscriber.GetSubscriberUserStatusInfoCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetFriendUserStatusesWithKeyAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE GetUserStatusesAsync(List<ulong> users, List<byte> keys, [Optional] NexPlugin.Subscriber.GetSubscriberUserStatusInfoCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE GetUserStatusesAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public ASYNCSTATE UpdateUserStatusAsync(List<SubscriberUserStatusParam> param, [Optional] [DefaultParameterValue(false)] bool isNotify, [Optional] AsyncResultCB callback, [Optional] IntPtr pNgsFacade, int timeOut = 0) { return default; }
		
		// TODO
		private ASYNCSTATE UpdateUserStatusAsync_(AsyncResult asyncResult, CORE_ARG param) { return default; }
		
		// TODO
		public bool EnableFriendUserStatusesCache([Optional] IntPtr pNgsFacade) { return default; }
		
		// TODO
		public bool DisableFriendUserStatusesCache([Optional] IntPtr pNgsFacade) { return default; }
		
		// TODO
		public bool GetFriendUserStatusesCacheMode(out bool result, [Optional] IntPtr pNgsFacade)
		{
			result = default;
			return default;
		}
		
		// TODO
		public bool GetFriendUserStatusesCacheLastResult(out Result result, [Optional] IntPtr pNgsFacade)
        {
            result = default;
            return default;
        }

        // TODO
        public bool GetFriendUserStatuses(out List<NexPlugin.SubscriberUserStatusInfo> infos, out Result result, [Optional] IntPtr pNgsFacade)
        {
            infos = default;
            result = default;
            return default;
        }

        // TODO
        public bool GetFriendUserStatuses(List<ulong> users, out List<NexPlugin.SubscriberUserStatusInfo> infos, out Result result, [Optional] IntPtr pNgsFacade)
        {
            infos = default;
            result = default;
            return default;
        }

        // TODO
        public bool GetUserStatusRevision(out uint revision, [Optional] IntPtr pNgsFacade)
        {
            revision = default;
            return default;
        }

        private bool ApiCallsFrequencyCheck(int type) {
            return false;
        }
		
		// TODO
		public Subscriber() { }

		private class POSTCONTENT_ARG : CORE_ARG
		{
			public NexPlugin.SubscriberPostContentParam param;
			public int timeOut;
			public NexPlugin.Subscriber.PostContentCB callback;
		}

		private class GETCONTENT_ARG : CORE_ARG
		{
			public NexPlugin.SubscriberGetContentParam param;
			public int timeOut;
			public NexPlugin.Subscriber.GetContentCB callback;
		}

		private class GETCONTENTS_ARG : CORE_ARG
		{
			public List<NexPlugin.SubscriberGetContentParam> paramList;
			public int timeOut;
			public NexPlugin.Subscriber.GetContentsCB callback;
		}

		private class DELETECONTENT_ARG : CORE_ARG
		{
			public List<uint> topics;
			public ulong contentId;
			public int timeOut;
			public AsyncResultCB callback;
		}

		private class GETFRIENDUSERSTATUSES_ARG : CORE_ARG
		{
			public int timeOut;
			public List<byte> keys;
			public List<ulong> users;
			public NexPlugin.Subscriber.GetSubscriberUserStatusInfoCB callback;
		}

		private class UPDATEUSERSTATUS_ARG : CORE_ARG
		{
			public int timeOut;
			public List<NexPlugin.SubscriberUserStatusParam> param;
			public bool isNotify;
			public AsyncResultCB callback;
		}

		private enum Functions : int
		{
			PostContent = 0,
			GetContent = 1,
			GetContents = 2,
			DeleteContent = 3,
			UpdateUserStatus = 4,
			GetFriendUserStatuses = 5,
			GetUserStatuses = 6,
		}
	}
}