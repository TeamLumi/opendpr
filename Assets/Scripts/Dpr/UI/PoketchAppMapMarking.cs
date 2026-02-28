using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.UI
{
	public class PoketchAppMapMarking : PoketchAppBase
	{
		[SerializeField]
		private RectTransform _playerCursorRoot;
		[SerializeField]
		private Image _playerCursorImage;
		[SerializeField]
		private Image[] _wanderingPokemonImages;
		[SerializeField]
		private ZoneID[] _hideMapIDs;
		[SerializeField]
		private Image[] _hideMapImages;
		[SerializeField]
		private float _blinkSpeed = 0.4f;

		private int _gridSize;
		private Vector2 _grigBasePosition = Vector2.zero;
		private TownMapTable.SheetData[] _mapDatas;
		private ZoneID[] _pokeZoneIDs = new ZoneID[2];
		private float _blinkCount;
		
		// TODO
		protected override void OnInitialize() { }
		
		// TODO
		protected override void OnOpen() { }
		
		// TODO
		protected override void OnClose() { }
		
		// TODO
		protected override void OnUpdateDraw() { }
		
		// TODO
		protected override void OnUpdateControl([Optional] [DefaultParameterValue(false)] bool isAppControlEnable, [Optional] PoketchButton targetButton, PoketchWindow.TouchState state = PoketchWindow.TouchState.None) { }
		
		public override void OnSizeChanged(bool isLarge)
		{
			ResetButtonsState(isLarge);
		}
		
		// TODO
		private void SetMarker(Transform marker, int px, int py) { }
		
		// TODO
		private void ResetButtonsState([Optional] PoketchButton targetButton) { }
	}
}