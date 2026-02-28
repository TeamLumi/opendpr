using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Dpr.NX
{
	public class SaveSystem
	{
		public const string MOUNT_NAME = "SaveData";
		public const string SAVEDATA_PATH = "SaveData:/SaveData.bin";
		public const string BACKUP_PATH = "SaveData:/Backup.bin";

		public static readonly int SAVELOAD_BUFFER_SIZE = Marshal.SizeOf(typeof(PlayerWork.SaveData));
		private static SaveSystem _Instance = new SaveSystem();

		private bool _isMounted;
		private bool _isBusy;
		private byte[] _buffer = new byte[SAVELOAD_BUFFER_SIZE];
		private Thread _saveLoadThread;
		private bool _threadEnable;
		private bool _saveRequest;
		private byte[] _saveDataPtr;
		private bool _writeMain;
		private bool _writeBackup;
		private bool _loadRequest;
		private bool _fromBackup;
		private bool _loadResult;
		private Action<bool> _postLoadFunction;
		private SynchronizationContext _mainThread = SynchronizationContext.Current;
		
		private SaveSystem()
		{
			// Empty
		}
		
		// TODO
		public static bool IsBusy() { return default; }
		
		// TODO
		public static byte[] GetLoadedData() { return default; }
		
		// TODO
		public static bool Save(byte[] data, bool writeMain, bool writeBackup) { return default; }
		
		// TODO
		public static void SaveAsync(byte[] data, bool writeMain, bool writeBackup) { }
		
		// TODO
		public static bool Load(bool fromBackup) { return default; }
		
		// TODO
		public static bool LoadCore(string path) { return default; }
		
		// TODO
		public static void LoadAsync(bool fromBackup, [Optional] Action<bool> onComplete) { }
		
		// TODO
		public static bool SaveDataExists() { return default; }
		
		// TODO
		public static bool BackupExists() { return default; }
		
		// TODO
		private void MountSaveData() { }
		
		private void StartThread()
		{
			if (this._saveLoadThread != null) {
			}
			var uVar1 = new Threading_ThreadStart(this);
			var uVar2 = new Threading_Thread(uVar1);
			this._saveLoadThread = uVar2;
			this._saveLoadThread.Priority = 0;
			this._threadEnable = true;
			this._saveLoadThread.Start();
		}
		
		// TODO
		private void ThreadLoop() { }
		
		// TODO
		private static void OnPostSave(object state) { }
		
		// TODO
		private static void OnPostLoad(object state) { }
	}
}