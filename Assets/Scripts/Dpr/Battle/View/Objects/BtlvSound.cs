using Audio;
using System;
using System.Runtime.InteropServices;

namespace Dpr.Battle.View.Objects
{
	public sealed class BtlvSound : BtlvPureObject
	{
		private AudioInstance _instance;
		private uint _playEventId;
		private bool _isPerpetuate;
		private Action _onComplete;
		private bool isVoice;
		
		public bool IsPlaying { get; private set; }
		
		public BtlvSound(string name)
		{
			_name = name;
			_playEventId = 0;
			_isPerpetuate = false;
			IsPlaying = false;
		}
		
		// TODO
		public override void Dispose() { }
		
		// TODO
		public void CreateSound(string registerName, bool isVoice = false) { }
		
		// TODO
		public static BtlvSound CreatePerpetuateSound(uint playEventId) { return default; }
		
		public void SetVoiceFlag()
		{
			this.isVoice = true;
		}
		
		public void SetSEFlag()
		{
			this.isVoice = false;
		}
		
		// TODO
		public bool Register(string name, bool isVoice) { return default; }
		
		// TODO
		public bool Unregister() { return default; }
		
		public void SetRTPC(uint trpcName, float value, int interpolationMs)
		{
			if (this._instance != null) {
			  this._instance.SetRTPCValue(trpcName);
			}
		}
		
		// TODO
		public bool SetSwitch(string switchGroup, string switchName) { return default; }
		
		// TODO
		public bool SetSwitch(uint switchGroup, uint switchName) { return default; }
		
		// TODO
		private bool CheckAkResult(AKRESULT result) { return default; }
		
		// TODO
		public INVALID_AUDIO PostEvent(uint postEventId, [Optional] Action onComplete) { return default; }
		
		// TODO
		public INVALID_AUDIO PostEvent(string eventName, [Optional] Action onComplete) { return default; }
		
		// TODO
		public INVALID_AUDIO PostEvent([Optional] Action onComplete) { return default; }
		
		// TODO
		private void OnPostEventComplete(object in_cookie, AkCallbackType in_type, AkCallbackInfo in_info) { }
		
		// TODO
		public override void OnUpdatePostJob(float deltaTime) { }
		
		// TODO
		protected override void UpdateSRT() { }
		
		// TODO
		public override bool IsActive() { return default; }
	}
}