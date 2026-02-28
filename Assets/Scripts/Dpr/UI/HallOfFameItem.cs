using DPData;
using System;
using UnityEngine;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.UI
{
	public class HallOfFameItem : MonoBehaviour
	{
		[SerializeField]
		private Image _imagePokemon;
		[SerializeField]
		private InfoStatus _infoStatus;
		[SerializeField]
		private InfoBattle _infoBattle;
		private Vector3 _imagePokemonLoacalPos;
		private UIDatabase.SheetPokemonVoice _voiceData;
		
		public UIDatabase.SheetPokemonVoice voiceData { get => _voiceData; }
		
		// TODO
		private void Awake() { }
		
		// TODO
		public void Setup(DENDOU_POKEMON_DATA_INSIDE pokemonData, RE_DENDOU_POKEMON_DATA_INSIDE re_namedata, DENDOU_SAVE_ADD_POKE add_pokemon) { }
		
		public void EnableInfo(int index)
		{
			var uVar1 = this._infoStatus.root.gameObject
			;
			uVar1.SetActive(index == 0);
			uVar1 = this._infoBattle.root.gameObject
			;
			uVar1.SetActive(index != 0);
		}

		[Serializable]
		private class InfoStatus
		{
			public RectTransform root;
			public Image _sex;
			public Image _rare;
			public UIText _parentName;
			public UIText _name;
			public UIText _level;
		}

		[Serializable]
		private class InfoBattle
		{
			public RectTransform root;
			public RectTransform[] wazaRoots;
			public Sprite[] spriteTypes;
		}
	}
}