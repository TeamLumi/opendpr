using Audio;
using Pml.PokePara;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using XLSXContent;

namespace Dpr.UI
{
    public class PokemonModelView : ModelViewBase
    {
        [SerializeField]
        private Transform _transModel;
        [SerializeField]
        private float _fov = 30.0f;
        [SerializeField]
        private float _reflectionAlpha;
        [SerializeField]
        private float _rotateSpeed;
        private Param _param;
        private AudioInstance _voiceInstance;
        private UIDatabase.SheetPokemonVoice _voiceData;
        private Vector2 _rotationLimitX = Vector2.zero;
        private int _animationIdle = -1;
        private int _animActionIndex;

        public int animActionIndex { get => _animActionIndex; }

        protected override void OnEnable()
        {
            // No extra code
            base.OnEnable();
        }

        // TODO
        public void Setup(Param param, [Optional] UnityAction<PokemonParam> onSetup) { }

        public bool IsEnableAction()
        {
        	if (this._param.type == 9) {
        	  return false;
        	}
        	return this._param.type != 0x41;
        }

        // TODO
        public bool OnUpdate(float deltaTime, UIInputController input, int playAnimButtonMask = GameController.ButtonMask.StickL | GameController.ButtonMask.StickR, int rotYPlusButtonMask = 0, int rotYMinusButtonMask = 0, int rotXPlusButtonMask = 0, int rotXMinusButtonMask = 0) { return false; }

        // TODO
        private void AddRotationX(float speed) { }

        // TODO
        public void PlayAnimation(bool looped = false) { }

        // TODO
        public bool IsPlayAnimation() { return false; }

        // TODO
        public void Pause(bool paused) { }

        // TODO
        public void Loop(bool looped) { }

        // TODO
        public void PlayVoice() { }

        // TODO
        protected override void UpdateAnimation(float deltaTime) { }

        public class Param
        {
	        public UIModelViewController.ModelViewType type = UIModelViewController.ModelViewType.Party;
            public PokemonParam pokemonParam;
            public float offsetX;
            public Canvas canvas;
        }
    }
}