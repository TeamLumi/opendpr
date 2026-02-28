using Pml.PokePara;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class BoxMarkingSettingPanel : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup _canvasGroup;
		[SerializeField]
		private Image[] _markImages;
		[SerializeField]
		private Cursor _cursor;
		private int _markIndex;
		private PokemonParam _pokemonParam;
		private BoxMarkColor[] _markColors = new BoxMarkColor[(int)PowerID.NUM];
		private int _trayIndex;
		private int _posIndex;
		private Action<PokemonParam, int, int> _onClosed;
		
		public void Initialize(Action<PokemonParam, int, int> onClosed)
		{
			0.alpha = this._canvasGroup;
			this._onClosed = Action<PokemonParam;
			var uVar1 = this.gameObject;
			uVar1.SetActive(0);
			this._cursor.SetActive(0);
		}
		
		// TODO
		public void Open(PokemonParam param, int trayIndex, int posIndex) { }
		
		// TODO
		public void Close() { }
		
		// TODO
		public void OnUpdate() { }
		
		// TODO
		private void SetCursor(int index) { }
	}
}