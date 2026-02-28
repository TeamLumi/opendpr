using Pml.PokePara;
using System;
using UnityEngine;

namespace Dpr.UI
{
	public class PokemonStatusPanelTrainerMemo : PokemonStatusPanel
	{
		[SerializeField]
		private PanelParam[] _panels;
		private EggStateParam[] _eggStateParams = new EggStateParam[]
		{
			new EggStateParam() { value = 5,            label = "SS_trainermemo_085" },
			new EggStateParam() { value = 10,           label = "SS_trainermemo_086" },
			new EggStateParam() { value = 40,           label = "SS_trainermemo_087" },
			new EggStateParam() { value = int.MaxValue, label = "SS_trainermemo_088" },
		};
		private bool _isLayoutUpdate;
		
		// TODO
		private void Awake() { }
		
		// TODO
		public override void Setup(PokemonParam pokemonParam) { }
		
		// TODO
		private void LateUpdate() { }
		
		// TODO
		private int GetEncounterId() { return default; }
		
		// TODO
		private bool IsVc(uint version) { return default; }
		
		// TODO
		private bool IsOtherVersion(uint iVersion) { return default; }
		
		// TODO
		private bool IsMegaTurtle(PlaceNo place2) { return default; }
		
		// TODO
		private bool IsMegaTurtle(PokemonParam pokemonParam) { return default; }
		
		// TODO
		private bool IsMegaTurtleEvent(PokemonParam pokemonParam) { return default; }
		
		// TODO
		private void SetupEncounterText(UIText uiText) { }
		
		// TODO
		private uint GetExternalPlaceNo(uint cassetteVersion) { return default; }
		
		// TODO
		private void SetPlaceNameWord(int index, uint place) { }
		
		// TODO
		private void SetEggStateText(UIText uiText) { }
		
		// TODO
		public override void Select(bool enabled) { }
		
		public override bool OnUpdate(float deltaTime)
		{
			var uVar1 = deltaTime.gameObject;
			uVar1.activeSelf;
			return false;
		}

		[Serializable]
		private class PanelParam
		{
			public RectTransform root;
			public UIText[] texts;
		}

		private enum PanelType : int
		{
			Normal = 0,
			Egg = 1,
		}

		private enum EncounterId : int
		{
			L26_02_01_1 = 26,
			L27_02_01_2 = 27,
			L28_02_02_1 = 28,
			L29_02_02_2 = 29,
			L30_02_03_1 = 30,
			L31_02_03_2 = 31,
			L32_02_04_1 = 32,
			L33_02_04_2 = 33,
			L34_02_05_1 = 34,
			L35_02_05_2 = 35,
			L36_02_06_1 = 36,
			L37_02_06_2 = 37,
			L38_02_07_1 = 38,
			L39_02_07_2 = 39,
			L40_02_08_1 = 40,
			L41_02_08_2 = 41,
			L42_02_09_1 = 42,
			L43_02_09_2 = 43,
			L44_02_10_1 = 44,
			L45_02_10_2 = 45,
			L80_T01_01 = 80,
			L81_T01_02 = 81,
			L82_T01_03 = 82,
			L83_T01_04 = 83,
			L95 = 95,
			L96 = 96,
			L97 = 97,
			L98 = 98,
		}

		private class EggStateParam
		{
			public int value;
			public string label;
		}

		private enum PlaceNo : int
		{
			START_PERSON = 60001,
			SPECIAL_OUTER_TRADE = 30002,
			SPECIAL_MEGATURTLE = 30018,
			SPECIAL_MEGATURTLE2 = 40086,
			UNKNOWN = 65535,
			TOOKUHANARETATOTI = 30007,
			HOUEN = 30005,
			KANTO = 30003,
			ZYOTO = 30004,
			SINOH = 30006,
			IISHU = 30009,
			KAROSU = 30010,
			CTR_HOUEN = 30014,
			AROORA = 30015,
			HOLOHOLO = 30012,
			VC_KANTO = 30013,
			VC_ZYOTO = 30017,
			LETSGO_KANTO = 30019,
			GARARU = 30020,
			HAYABUSA = 30021,
		}
	}
}