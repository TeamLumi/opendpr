using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

namespace INL1
{
	public class IlcaNetServerSerial : IlcaNetServer
	{
		private static CheckSerialRequest scsr;
		private static SerialResponseAuth sra;
		private static SerialResponseUpdate sru;
		private static volatile bool next;
		private static volatile bool abort;
		
		// TODO
		public static bool CheckSerialResponseGet(ref SerialResponseAuth RetSra) { return default; }
		
		// TODO
		public static bool UpdateSerialResponseGet(ref SerialResponseUpdate RetSru) { return default; }
		
		// TODO
		public static bool CheckSerialRequestAsync(MonoBehaviour callobj, CheckSerialRequest csr, IlcaNetServerAsyncCallback callback, [Optional] string nsaidtOver, ulong nexid = 0) { return default; }
		
		// TODO
		public static bool UpdateSerialRequestAsync(MonoBehaviour callobj, IlcaNetServerAsyncCallback callback) { return default; }
		
		// TODO
		private static void CallbackNSAIDT(bool isSuccess, IlcaNetServerCallbackEventType eve, IlcaNetServerCallbackResult result, long responseCode, string responseStr) { }
		
		// TODO
		private static void NextAbort(bool isSuccess) { }
		
		// TODO
		private static IEnumerator CheckSerialRequestAsyncCore(MonoBehaviour callobj, CheckSerialRequest csr, IlcaNetServerAsyncCallback callback, bool auth) { return default; }

		[Serializable]
		public class CheckSerialRequest
		{
			public string nuid;
			public string rom = "48";
			public string serialcode = "QQQAVTVN68RTPUT6";
			public string tok;
			public string langcode = "01";
			
			// TODO
			public static string Serialize(CheckSerialRequest data) { return default; }
		}

		[Serializable]
		public class SerialResponseAuth
		{
			public string serialcodeStatus;
			public ushort dataNo;
			
			// TODO
			public static SerialResponseAuth Deserialize(string json) { return default; }
		}

		[Serializable]
		public class SerialResponseUpdate
		{
			public string serialcodeStatus;
			
			// TODO
			public static SerialResponseUpdate Deserialize(string json) { return default; }
		}
	}
}