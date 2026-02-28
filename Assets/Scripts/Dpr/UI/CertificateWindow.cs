using Pml.PokePara;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class CertificateWindow : UIWindow
	{
		[SerializeField]
		private UIText _text0;
		[SerializeField]
		private UIText _text1;
		[SerializeField]
		private Image _imageBg;
		[SerializeField]
		private Image _imagePokemon;
		[SerializeField]
		private Sprite[] _spriteBgs;
		
		public override void OnCreate()
		{
			UIWindow.OnCreate();
			var uVar1 = UnityEngine_Component__GetComponentInChildren<object>
			                  (this,1);
			this._animator = uVar1;
		}
		
		// TODO
		public void Open(Param param, UIWindowID prevWindowId) { }
		
		// TODO
		public IEnumerator OpOpen(Param param, UIWindowID prevWindowId) { return default; }
		
		// TODO
		private void SetupKeyguide() { }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }

		public class Param
		{
			public CertificateType type;
			public PokemonParam pokemonParam;

            public enum CertificateType : int
            {
                Zukan = 0,
                ZenkokuZukan = 1,
                Akashi = 2,
            }
        }
	}
}