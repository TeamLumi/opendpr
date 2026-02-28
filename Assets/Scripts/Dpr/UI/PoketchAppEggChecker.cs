using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PoketchAppEggChecker : PoketchAppBase
	{
		[SerializeField]
		private PoketchEggCheckerPokeIcon[] _pokeIcon;
		[SerializeField]
		private Image _eggImage;
		[SerializeField]
		private Image _blurImage;
		[SerializeField]
		private float _inBlurTime = 0.2f;
		[SerializeField]
		private float _outBlurTime = 0.2f;
		[SerializeField]
		private float _maxBlurSize = 5.0f;

		private EggCheckerState _state;
		private float _blurTimeCount;
		private Material _matGrayScale;
		private Material _matBlur;
		
		// TODO
		protected override void OnInitialize() { }
		
		protected override void OnOpen()
		{
			this._state = (EggCheckerState)0;
			var uVar1 = Shader.PropertyToID(_StringLiteral_11548);
			0.SetFloat(this._matBlur,uVar1);
			UpdateAzukariyaInfo();
		}
		
		// TODO
		protected override void OnClose() { }
		
		// TODO
		protected override void OnUpdateDraw() { }
		
		// TODO
		protected override void OnUpdateControl([Optional][DefaultParameterValue(false)] bool isAppControlEnable, [Optional] PoketchButton targetButton, PoketchWindow.TouchState state = PoketchWindow.TouchState.None) { }
		
		private void StartBlur()
		{
			if ((int)this._state != 0) {
			}
			this._state = (EggCheckerState)1;
		}
		
		// TODO
		private void UpdateAzukariyaInfo() { }
		
		// TODO
		private void UpdateBlur(float deltaTime) { }

		private enum EggCheckerState : int
		{
			None = 0,
			BlurOut = 1,
			BlurIn = 2,
			End = 3,
		}
	}
}