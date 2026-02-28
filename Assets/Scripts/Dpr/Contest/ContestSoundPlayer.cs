using AK;
using Audio;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.Contest
{
	public class ContestSoundPlayer
	{
		public static ContestSoundPlayer player;

		private readonly Dictionary<int, uint> PLAY_SE_TABLE = new Dictionary<int, uint>()
		{
			{ (int)PlaySE_ID.CheerIntro,    EVENTS.S_CON_CHEER_INTRO },
			{ (int)PlaySE_ID.Cheer_S,       EVENTS.S_CON_CHEER_S },
			{ (int)PlaySE_ID.Cheer_M,       EVENTS.S_CON_CHEER_INTRO },
			{ (int)PlaySE_ID.TapSuccess,    EVENTS.S_CON_TAP_A },
			{ (int)PlaySE_ID.TapMiss,       EVENTS.S_CON_TAP_MISS },
			{ (int)PlaySE_ID.PointHeart,    EVENTS.S_CON_POINT_HEART },
			{ (int)PlaySE_ID.PokeHeartM,    EVENTS.S_CON_POKE_HEART_M },
			{ (int)PlaySE_ID.PokeHeartL,    EVENTS.S_CON_POKE_HEART_L },
			{ (int)PlaySE_ID.Point,         EVENTS.S_CON_POINT },
			{ (int)PlaySE_ID.Waza_L,        EVENTS.S_CON_WAZA_L },
			{ (int)PlaySE_ID.Waza_R,        EVENTS.S_CON_WAZA_R },
			{ (int)PlaySE_ID.Waza_SameType, EVENTS.S_CON_WAZA_SAME },
			{ (int)PlaySE_ID.Success,       EVENTS.S_CON_SUCCESS },
			{ (int)PlaySE_ID.GaugeFix,      EVENTS.S_CON_GAUGE_FIX },
			{ (int)PlaySE_ID.Rankup,        EVENTS.S_CON_RANKUP },
			{ (int)PlaySE_ID.DrumRoll1,     EVENTS.S_CON_DRUMROLL1 },
			{ (int)PlaySE_ID.DrumRoll2,     EVENTS.S_CON_DRUMROLL2 },
			{ (int)PlaySE_ID.Medal,         EVENTS.S_CON_MEDAL },
		};
		private readonly Dictionary<int, uint> PLAY_LOOP_SE_TABLE = new Dictionary<int, uint>()
        {
            { (int)PlayLoopSE_ID.TapLong, EVENTS.S_CON_TAP_LONG },
            { (int)PlayLoopSE_ID.Gauge,   EVENTS.S_CON_GAUGE },
            { (int)PlayLoopSE_ID.Cheer,   EVENTS.S_CON_CHEER_OUTRO },
        };
		private readonly Dictionary<int, uint> STOP_SE_TABLE = new Dictionary<int, uint>()
        {
            { (int)StopSE_ID.TapLong, EVENTS.STOP_S_CON_TAP_LONG },
            { (int)StopSE_ID.Gauge,   EVENTS.STOP_S_CON_GAUGE },
            { (int)StopSE_ID.Cheer,   EVENTS.STOP_S_CON_CHEER_OUTRO },
        };

        private const float FADE_DURATION = 0.3f;

		private AudioManager audioManager;
		private AudioInstance contestBGMInstance;
		private float diffVolume;
		private float fadeTimer;
		private float currentVolume;
		private float baseVolume;
		private bool playingMusic;
		private bool bFading;
		
		// TODO
		public static void CreateInstance() { }
		
		// TODO
		public static void DestroyInstance() { }
		
		public bool PlayingMusic { get => playingMusic; }
		
		// TODO
		private void Initialize() { }
		
		// TODO
		private void OnFinalize() { }
		
		// TODO
		public static void Stop() { }
		
		// TODO
		public void SetBGMVolumeRatio(float ratio) { }
		
		// TODO
		public void ResetBGMVolume() { }
		
		// TODO
		private void StartBGMFade(float volume) { }
		
		// TODO
		private float GetBGMOptionVolume() { return default; }
		
		public void StopBGM()
		{
			this.audioManager.StopBgm();
		}
		
		public void PlayTitleBgm()
		{
			this.audioManager.SetBgmEvent(0x14ada707,0);
			PlayBGM(0x3f0a5f97);
		}
		
		// TODO
		public void PlayVisualBgm(Action onFinished) { }
		
		// TODO
		private void PlayBGM(uint eventId, [Optional] Action onFinished) { }
		
		public void CreateMainBGM(uint eventId)
		{
			this.contestBGMInstance = this.audioManager.CreateSe(eventId,0);
		}
		
		// TODO
		public void PlayMainBGM([Optional] Action onFinished) { }
		
		// TODO
		public void PlayResultBGM(bool isBestPerformer) { }
		
		// TODO
		public void StopResultBGM(bool isBestPerformer) { }
		
		public float GetBGMPlayPosition()
		{
			if (this.contestBGMInstance != null) {
			  var fVar2 = 0.0;
			  if (0.0 < (float)this.contestBGMInstance.GetPlayPosition(1)) {
			    fVar2 = (float)this.contestBGMInstance.GetPlayPosition(1);
			  }
			  return fVar2;
			}
			return 0.0;
		}
		
		// TODO
		public void PlaySeByID(PlaySE_ID seID) { }
		
		// TODO
		public void PlayLoopSeByID(PlayLoopSE_ID seID) { }
		
		// TODO
		public void PlayTapNoteSE(NoteTapTimingID timingId) { }
		
		// TODO
		public void StopSE(StopSE_ID seID) { }
		
		// TODO
		public void PlayVoice(string eventName, Vector3 position, Quaternion rotation) { }
		
		// TODO
		private void SendAudioEvent(uint seId) { }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private float UpdateFadeTimer(float deltaTime) { return default; }
		
		private void SetBGMVolume(float volume)
		{
			if ((this.contestBGMInstance != null) && (this.playingMusic)) {
			  this.contestBGMInstance.SetVolume();
			}
		}

		public enum PlaySE_ID : int
		{
			CheerIntro = 0,
			Cheer_S = 1,
			Cheer_M = 2,
			TapSuccess = 3,
			TapMiss = 4,
			PointHeart = 5,
			PokeHeartM = 6,
			PokeHeartL = 7,
			Point = 8,
			Waza_L = 9,
			Waza_R = 10,
			Waza_SameType = 11,
			Success = 12,
			GaugeFix = 13,
			Rankup = 14,
			DrumRoll1 = 15,
			DrumRoll2 = 16,
			Medal = 17,
			Num = 18,
		}

		public enum PlayLoopSE_ID : int
		{
			TapLong = 0,
			Gauge = 1,
			Cheer = 2,
		}

		public enum StopSE_ID : int
		{
			TapLong = 0,
			Gauge = 1,
			Cheer = 2,
		}
	}
}