using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace INL1
{
	public class IlcaNetServerDelivery : IlcaNetServer
	{
		private static Stopwatch sp = new Stopwatch();
		private static TimeSpan span;

        private static volatile bool isMount = false;

		public const int OkurimonoIdFlagArray256size = 256;
		public const int FileFlagArraySize = 13;
		public const int MaxFileNameArraySize = 100;

        private static volatile bool isReading = false;

		private static volatile uint s_directoryNum;
		private static volatile uint s_fileNum;
		private static volatile byte[] s_data;
		private static volatile bool s_finish;
		private static volatile int s_ret;
		
		// TODO
		public static void Init() { }
		
		// TODO
		public static bool MountStorageAsync(MonoBehaviour callobj, IlcaNetServerAsyncCallback callback) { return default; }
		
		// TODO
		private static IEnumerator MountStorageAsyncCore(IlcaNetServerAsyncCallback callback) { return default; }
		
		// TODO
		private static IEnumerator MountStorageAsyncCoreSub2() { return default; }
		
		// TODO
		public static bool UnMountStorage() { return default; }
		
		// TODO
		public static bool ImmediateSyncRequestAsync(MonoBehaviour callobj, IlcaNetServerAsyncCallback callback) { return default; }
		
		// TODO
		public static bool ImmediateSyncRequestAsync(MonoBehaviour callobj, IlcaNetServerAsyncCallback callback, bool mount) { return default; }
		
		// TODO
		private static IEnumerator ImmediateSyncRequestAsyncCore(IlcaNetServerAsyncCallback callback, bool mount) { return default; }
		
		// TODO
		public static int FileCountGet(uint directoryNum) { return default; }
		
		public static bool OkurimonoIdFlagCheck(int OkurimonoID, byte[] OkurimonoIdFlagArray256)
		{
			if (OkurimonoID >= OkurimonoIdFlagArray256size * 8)
				return true;

			if (OkurimonoIdFlagArray256.Length != OkurimonoIdFlagArray256size)
				return true;

			var index = OkurimonoID / 8;
			var mask = (byte)(0b10000000 >> (OkurimonoID & 0b111));

			return (OkurimonoIdFlagArray256[index] & mask) != 0;
		}
		
		public static bool OkurimonoIdFlagSet(int OkurimonoID, ref byte[] OkurimonoIdFlagArray256)
		{
            if (OkurimonoID >= OkurimonoIdFlagArray256size * 8)
                return false;

            if (OkurimonoIdFlagArray256.Length != OkurimonoIdFlagArray256size)
                return false;

            var index = OkurimonoID / 8;
            var mask = (byte)(0b10000000 >> (OkurimonoID & 0b111));

            if ((OkurimonoIdFlagArray256[index] & mask) == 0)
			{
				OkurimonoIdFlagArray256[index] |= mask;
                return true;
			}
			else
			{
				return false;
			}
        }
		
		public static bool OkurimonoIdFlagInit(ref byte[] OkurimonoIdFlagArray256)
		{
            if (OkurimonoIdFlagArray256.Length != OkurimonoIdFlagArray256size)
                return false;

			for (int i=0; i<OkurimonoIdFlagArray256.Length; i++)
				OkurimonoIdFlagArray256[i] = 0;

			return true;
        }
		
		// TODO
		public static bool FileFlagCheck(byte fileName, byte[] fileFlagArray) { return default; }
		
		// TODO
		public static bool FileFlagSet(byte fileName, ref byte[] fileFlagArray) { return default; }
		
		// TODO
		public static List<byte> FileListGetWithFlag(uint directoryNum, byte[] fileFlagArray) { return default; }
		
		// TODO
		public static int FileCountNameArrayGet(uint directoryNum, byte[] fileNameArray) { return default; }
		
		// TODO
		public static long FileSizeGet(uint directoryNum, uint fileNum) { return default; }
		
		// TODO
		public static int FileRead(uint directoryNum, uint fileNum, byte[] data) { return default; }
		
		// TODO
		public static bool FileReadAsync(MonoBehaviour callobj, uint directoryNum, uint fileNum, byte[] data, IlcaNetServerAsyncCallback callback) { return default; }
		
		// TODO
		private static IEnumerator FileReadAsyncCore(uint directoryNum, uint fileNum, byte[] data, IlcaNetServerAsyncCallback callback) { return default; }
		
		// TODO
		private static void FileReadWorkerThread() { }
	}
}