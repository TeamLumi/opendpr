using AK;
using Audio;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class ZukanMovingEqualizer : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _levelRoot;
		[SerializeField]
		private RectTransform _headRoot;

		private List<Image[]> _levelGauges = new List<Image[]>();
		private List<HeadParam> _headParams = new List<HeadParam>();
		private float _headMinPosY;

		private const float _minDecibel = -48.0f;
		private const float _maxDecibel = 0.0f;

		private VoiceRTPC.VoiceRTPCDataList _voiceRtpcData;
		private uint[] _gameParamIds = new uint[]
		{
			GAME_PARAMETERS.POKEDEXEQ_01, GAME_PARAMETERS.POKEDEXEQ_02, GAME_PARAMETERS.POKEDEXEQ_03, GAME_PARAMETERS.POKEDEXEQ_04,
			GAME_PARAMETERS.POKEDEXEQ_05, GAME_PARAMETERS.POKEDEXEQ_06, GAME_PARAMETERS.POKEDEXEQ_07, GAME_PARAMETERS.POKEDEXEQ_08,
            GAME_PARAMETERS.POKEDEXEQ_09,
        };
		
		// TODO
		private void Awake() { }
		
		// TODO
		public void Setup(VoiceRTPC.VoiceRTPCDataList voiceRtpcData) { }
		
		public void OnUpdate(float deltaTime, AudioInstance audioInstance)
		{
			UpdateHeads();
			UpdateLevels(deltaTime,audioInstance);
		}
		
		// TODO
		private void UpdateLevels(AudioInstance audioInstance) { }
		
		private float GetRTPCValue(AudioInstance audioInstance, uint paramId, int gaugeIndex)
		{
			paramId.GetRTPCValue(gaugeIndex);
			return 0;
		}
		
		private float ToLevelValue(float value, float min = _minDecibel, float max = _maxDecibel)
		{
			return (value - min) / (max - min);
		}
		
		// TODO
		private void SetLevelValue(int level, float value) { }
		
		// TODO
		private void UpdateHeads(float deltaTime) { }

		private class HeadParam
		{
			public Image image;
		}
	}
}