using Audio;
using Dpr.Battle.Logic;
using Dpr.Battle.View.Objects;
using Dpr.SequenceEditor;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.Battle.View.Systems
{
	public sealed class BattleWeatherSystem
	{
		private BattleViewSystem _pViewSystem;
		private BtlvEffectInstance _iPtrWeatherEffectMain;
		private BtlvEffectInstance _iPtrWeatherEffectCamera;
		private BtlvEffectInstance _iPtrWeatherEffectRange;
		private WeatherParam _currentWeatherParam;
		private WeatherParam _reservationWeatherParam;
		private bool _shortMode;
		private AudioInstance _audio;
		private Coroutine _changeWeatherCol;
		private Action<BtlvWeather, BtlvWeather> _onChanged;
		
		// TODO
		public static BtlvWeather BtlWeatherToBtlvWeather(BtlWeather wather) { return default; }
		
		// TODO
		public void Initialize(BtlWeather weather, BattleViewSystem pViewSystem) { }
		
		// TODO
		public void Request(BtlWeather weather, [Optional] Action<BtlvWeather, BtlvWeather> onChanged) { }
		
		// TODO
		public void Request(BtlvWeather weather, [Optional] Action<BtlvWeather, BtlvWeather> onChanged) { }
		
		// TODO
		private IEnumerator ChangeWeather(BtlvWeather weather) { return default; }
		
		// TODO
		private IEnumerator PlayWeatherEffect() { return default; }
		
		// TODO
		private IEnumerator LoadWeatherEffect(string file, Action<BtlvEffectInstance> setter, SEQ_DEF_EFF_DRAWTYPE drawType = SEQ_DEF_EFF_DRAWTYPE.SEQ_DEF_EFF_DRAWTYPE_NORAML) { return default; }
		
		// TODO
		private void SetColors(float duration) { }
		
		// TODO
		private void SetInitColors(float weight) { }
		
		private bool CheckAlreadyChanged()
		{
			return this._iPtrWeatherEffectMain != null;
		}
		
		// TODO
		private IEnumerator EffectStop(BtlvWeather nextWeather) { return default; }
		
		// TODO
		private bool LoadWeatherParam(BtlvWeather weather) { return default; }
		
		// TODO
		public void SetWeatherVisibility(bool visible) { }

		private class WeatherParam
		{
			public BtlvWeather weather;
			public string mainFileName;
			public string cameraFileName;
			public string rangeFileName;
			public string registerName;
			public Vector3 cameraEffctScale;
			public float lightPower;
			public int time;
			public int shortTime;
			
			public void SetParam(WeatherParam param)
			{
				weather = param.weather;
				mainFileName = param.mainFileName;
				cameraFileName = param.cameraFileName;
				rangeFileName = param.rangeFileName;
				registerName = param.registerName;
				cameraEffctScale = param.cameraEffctScale;
				lightPower = param.lightPower;
				time = param.time;
				shortTime = param.shortTime;
			}
		}
	}
}