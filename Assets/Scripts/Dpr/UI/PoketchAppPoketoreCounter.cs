using Pml;
using Pml.PokePara;
using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PoketchAppPoketoreCounter : PoketchAppBase
	{
		[SerializeField]
		private PoketoreCounterImages _current;
		[SerializeField]
		private PoketoreCounterImages[] _ranking;
		[SerializeField]
		private Sprite[] _numberSprites;
		[SerializeField]
		private static Vector3 _jumpValue = new Vector3(0.0f, 30.0f, 0.0f);
		[SerializeField]
		private static float _jumpTime = 0.1f;

		private Material _matGrayScale;
		private MonsNo[] _monsNos;
		private int _prevCount;
		
		// TODO
		protected override void OnInitialize() { }
		
		protected override void OnOpen()
		{
			ApplyRanking();
			this._prevCount = 0;
		}
		
		// TODO
		protected override void OnClose() { }
		
		// TODO
		protected override void OnUpdateDraw() { }
		
		// TODO
		protected override void OnUpdateControl([Optional] [DefaultParameterValue(false)] bool isAppControlEnable, [Optional] PoketchButton targetButton, PoketchWindow.TouchState state = PoketchWindow.TouchState.None) { }
		
		// TODO
		private void ApplyRanking() { }
		
		// TODO
		private void SetPoketoreInfo(PoketoreCounterImages images, PokemonParam pp, int count) { }
		
		// TODO
		private void JumpIcon(int index) { }

		[Serializable]
		private struct PoketoreCounterImages
		{
			public GameObject _root;
			public PokemonIcon _pokemonIcon;
			public Image[] _counterImages;
			public DG.Tweening.Sequence _sequence;
		}
	}
}