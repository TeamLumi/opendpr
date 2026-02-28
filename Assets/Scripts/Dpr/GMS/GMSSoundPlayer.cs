using AK;
using Audio;
using System.Collections.Generic;

namespace Dpr.GMS
{
	public class GMSSoundPlayer
	{
		public static GMSSoundPlayer player;

		private readonly Dictionary<int, uint> PLAY_SE_TABLE = new Dictionary<int, uint>()
		{
			{ 0,  EVENTS.S_FI258_LOGO },
			{ 1,  EVENTS.S_FI253 },
			{ 2,  EVENTS.S_FI253_FOUND },
			{ 3,  EVENTS.S_FI253_NOTFOUND },
			{ 4,  EVENTS.S_FI254 },
			{ 5,  EVENTS.S_FI255 },
			{ 6,  EVENTS.S_FI256 },
			{ 7,  EVENTS.S_FI257 },
			{ 8,  EVENTS.UI_COMMON_DECIDE },
			{ 9,  EVENTS.S_GMS_DELETE },
			{ 10, EVENTS.S_GMS_POKE_APPEAR },
			{ 11, EVENTS.S_GMS_POKE_DISAPPEAR },
			{ 12, EVENTS.S_GMS_ZOOMOUT },
			{ 13, EVENTS.S_GMS_TITLEBACK },
			{ 14, EVENTS.S_GMS_COMP_CLOSE },
			{ 15, EVENTS.UI_COMMON_CANCEL },
			{ 16, EVENTS.UI_COMMON_MENU_CLOSE },
		};

		private AudioManager audioManager;
		private bool lockPlaySe;
		private bool isPlayVoice;
		
		// TODO
		public static void CreateInstance() { }
		
		// TODO
		public static void DestroyInstance() { }
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void OnFinalize() { }
		
		public void SetLockPlaySe(bool lockSe)
		{
			this.lockPlaySe = (lockSe ? 1 : 0) & 1;
		}
		
		public void PlaySe(string eventName)
		{
			uint uVar1 = default;
			var uVar2 = String.IsNullOrEmpty(eventName);
			if ((uVar2 & 1) != 0) {
			}
			AudioInstance.Play(this.audioManager.CreateSe(uVar1,0),0,0,0);
		}
		
		// TODO
		public void PlaySeByID(PlaySE_ID seID) { }
		
		// TODO
		public void PlayVoice(string eventName) { }
		
		private void SendAudioEvent(uint seId)
		{
			AudioInstance.Play(this.audioManager.CreateSe(seId,0),0,0,0);
		}
		
		// TODO
		public void SetDuckingEnabled(bool enabled) { }

		public enum PlaySE_ID : int
		{
			Logo = 0,
			Connecting = 1,
			FoundPlayer = 2,
			NotFoundPlayer = 3,
			ZoomIn = 4,
			ZoomOut = 5,
			SnapPoint = 6,
			MarkPoint = 7,
			Decide = 8,
			Delete = 9,
			PokeAppear = 10,
			PokeDisappear = 11,
			SystemZoomOut = 12,
			Titleback = 13,
			CompClose = 14,
			ReplaceCancel = 15,
			BackTop = 16,
		}
	}
}