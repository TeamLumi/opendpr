using System;
using System.Collections.Generic;
using Dpr;
using Dpr.Battle.View;
using Dpr.Battle.View.Objects;
using Pml.PokePara;
using SmartPoint.Components;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering;
using XLSXContent;

[RequireComponent(typeof(Animator))]
public sealed class BattlePokemonEntity : BattleObjectEntity
{
    public const float DEFAULT_MOTION_TRANSITION_TIME = 0.0f;
    public const float DEFAULT_MOTION_START_TIME = 0.0f;
    private const float DEFAULT_MOTION_BLEND_TIME = 0.14f;

    [SerializeField]
    private AnimationPlayer _animationPlayer = new AnimationPlayer();
    [SerializeField]
    private Size _size;
    [SerializeField]
    private float _scale = 1.0f;
    [SerializeField]
    private LandingType _landingType;
    [SerializeField]
    private AnimationState _animationState = AnimationState.Max;
    [SerializeField]
    private RenderingParam _renderingParam = RenderingParam.Factory();
    [SerializeField]
    private SkinnedMeshRendererCluster[] _rendererClusters;
    [SerializeField]
    private PokeAnimSound _pokeAnimSound = new PokeAnimSound();
    private MaterialPropertyBlock _propertyBlock;
    private Color _fixMultiplierColor = Color.white;
    private SimpleParam _simpleParam;
    private Vector3 _adjustScale = Vector3.one;
    private Transform _origin;
    private Dictionary<int, int> _renderObjectMasks = new Dictionary<int, int>();
    private float _motionBlendTime = 0.14f;

    public BattleDataTable.SheetPokemonMotionBlendTime PokemonMotionBlendTimeData { get; set; }

    public bool isAnimationWaitAWhenDisable;
    private int waitALoopCount;
    private bool _isPokeAnimSoundEnable = true;

    public override string entityType { get => "BattlePokemon"; }
    public Size Size { get => _size; }
    public LandingType LandingType { get => _landingType; }
    public AnimationState CurrentAnimationState { get => _animationState; private set => _animationState = value; }
    public bool PokeAnimSoundEnable
    {
        get => _isPokeAnimSoundEnable;
        set
        {
            _isPokeAnimSoundEnable = value;
            _pokeAnimSound.Enable = value;
        }
    }
    public Color FixMultiplierColor { get => _fixMultiplierColor; set => _fixMultiplierColor = value; }
    private PokemonVariation PokemonVariation { get; set; }
    public PokemonCustomNodeAnim PokemonCustomNodeAnim { get; private set; }
    private PokemonAnime PokemonAnime { get; set; }
    private PokemonPrefabInfo PokemonPrefabInfo { get; set; }
    private PatcheelPattern patcheelPattern { get; set; }

    public bool isZIBAKOIRU;

    // TODO
    protected override void Awake() { }

    // TODO
    protected override void OnDestroy() { }

    // TODO
    protected override void OnEnable() { }

    // TODO
    protected override void OnDisable() { }

    // TODO
    protected override void OnUpdate(float deltaTime) { }

    // TODO
    protected override void OnEarlyLateUpdate(float deltatime) { }

    // TODO
    private void LateUpdate() { }

    // TODO
    protected override void OnLateUpdate(float deltaTime) { }

    protected override void ProcessSequence(float deltaTime)
    {
        switch (currentSequence)
        {
            case SequenceID.Animation:
                if (_animationPlayer.currentRemaingTime <= 0.0f)
                    nextSequence = SequenceID.Initialize;
                break;

            case SequenceID.Initialize:
                if (_animationPlayer.forceLoop)
                {
                    nextSequence = SequenceID.Active;
                }
                else
                {
                    if (isZIBAKOIRU && _animationPlayer.layerClipPlayable.IsValid())
                        _animationPlayer.layerClipPlayable.SetTime(0.0f);

                    _animationPlayer.Play((int)AnimationState.WaitA01);
                }
                break;

            case SequenceID.ToWaitB:
                if (_motionBlendTime >= _animationPlayer.currentPlayable.GetAnimationClip().length * waitALoopCount - _animationPlayer.currentPlayingTime)
                {
                    _animationPlayer.Play((int)AnimationState.WaitB01, _motionBlendTime);
                    nextSequence = SequenceID.ToBlend;
                    _animationState = AnimationState.WaitB01;
                    _motionBlendTime = 0.05f;
                }
                break;

            case SequenceID.ToWaitC:
                if (_motionBlendTime >= _animationPlayer.currentPlayable.GetAnimationClip().length * waitALoopCount - _animationPlayer.currentPlayingTime)
                {
                    _animationPlayer.Play((int)AnimationState.WaitC01, _motionBlendTime);
                    nextSequence = SequenceID.ToBlend;
                    _animationState = AnimationState.WaitC01;
                    _motionBlendTime = 0.05f;
                }
                break;

            case SequenceID.ToLandState:
                switch (_animationState)
                {
                    case AnimationState.LandA01:
                        if (_animationPlayer.currentRemaingTime <= 0.0f)
                        {
                            if (isZIBAKOIRU && _landingType != LandingType.NORMAL)
                                _animationPlayer.layerClipPlayable.SetTime(0.0f);

                            RequestAnimationState(_landingType == LandingType.NORMAL ? AnimationState.LandB01 : AnimationState.WaitA01);
                        }
                        break;

                    case AnimationState.LandC01:
                        if (_animationPlayer.currentRemaingTime <= 0.0f)
                            _animationPlayer.Play((int)AnimationState.WaitA01);
                        break;
                }
                break;

            case SequenceID.ToBlend:
                if (_motionBlendTime >= _animationPlayer.currentRemaingTime)
                {
                    if (isZIBAKOIRU && _animationPlayer.layerClipPlayable.IsValid())
                        _animationPlayer.layerClipPlayable.SetTime(0.0f);

                    _animationPlayer.Play((int)AnimationState.WaitA01, _motionBlendTime);
                    _animationState = AnimationState.WaitA01;
                    nextSequence = SequenceID.Active;
                }
                break;
        }
    }

    // TODO
    public void Initialize(PokemonInfo.SheetCatalog catalog, bool isContest = false) { }

    // TODO
    private void CreateShadowCastSystem() { }

    public SimpleParam GetSimpleParam()
    {
        return _simpleParam;
    }

    public void ResetAnimation()
    {
        if (isAnimationWaitAWhenDisable && !_animationPlayer.IsPlayingEnd && _animationState != AnimationState.WaitA01)
        {
            if (isZIBAKOIRU && _animationPlayer.layerClipPlayable.IsValid())
                _animationPlayer.layerClipPlayable.SetTime(0.0f);

            _animationPlayer.Play((int)AnimationState.WaitA01);
            _animationState = AnimationState.WaitA01;
            nextSequence = SequenceID.Active;
        }
    }

    public override AnimationPlayer GetAnimationPlayer()
    {
        return _animationPlayer;
    }

    // TODO
    public void RequestAnimationState(AnimationState state, float duration = 0.0f, float startTime = 0.0f) { }

    // TODO
    public void SetAnimationSpeed(float animationSpeed) { }

    public float GetAnimationSpeed() {
        return _animationSpeed;
    }

    public void SetBlinkEnabled(bool value)
    {
        _blinkProcess?.SetBlinkEnabled(value);
    }

    // TODO
    public void SetBlinkIntParameter(CharaAutomaticBlinkProcess.BlinkIntParameter param) { }

    public PokeAnimSound GetPokeAnimSound()
    {
        return _pokeAnimSound;
    }

    // TODO
    private void AK_EffectStart00(int value) { }

    // TODO
    private void AK_EffectStart01(int value) { }

    // TODO
    private void AK_ButuriStart01(int value) { }

    // TODO
    private void AK_SEStart01(int value) { }

    // TODO
    private void AK_SEStart02(int value) { }

    // TODO
    private void AK_SEStart03(int value) { }

    // TODO
    private void AK_SEStart04(int value) { }

    // TODO
    private void AK_PartsMaterial01(int value) { }

    // TODO
    private void AK_PartsSkel01(int value) { }

    // TODO
    public void SetRenderActive(bool isActive) { }

    // TODO
    private void UpdateFixMultiplyColor() { }

    // TODO
    public RenderingParam GetRenderingParam() { return default(RenderingParam); }

    // TODO
    public void SetStencilWriteValue(bool f, int value) { }

    // TODO
    private void AdjustModel() { }

    // TODO
    public ModelEntityType GetModelEntityType() { return ModelEntityType.Battle; }

    // TODO
    public void SetPatcheelPattern(uint rand) { }

    public class SequenceID : BaseEntity.SequenceID
    {
	    public const int Active = 4096;
        protected const int User = 8192;
        public const int Attack = 12288;
        public const int Animation = 16384;
        public const int ToDown = 20480;
        public const int ToLandState = 24576;
        public const int ToBlend = 28672;
        public const int ToWaitB = 32768;
        public const int ToWaitC = 36864;
    }

    public enum AnimationState : int
    {
        WaitA01 = 0,
        WaitB01 = 1,
        LandA01 = 2,
        LandB01 = 3,
        LandC01 = 4,
        Buturi01 = 5,
        Buturi02 = 6,
        Buturi03 = 7,
        Tokusyu01 = 8,
        Tokusyu02 = 9,
        Tokusyu03 = 10,
        BodyBlow = 11,
        Punch = 12,
        Kick = 13,
        Tail = 14,
        Bite = 15,
        Peck = 16,
        Radial = 17,
        Cry = 18,
        Dust = 19,
        Shot = 20,
        Guard = 21,
        TurnNormal = 22,
        TurnSmile = 23,
        Damage = 24,
        Down = 25,
        Roar01 = 26,
        F_Walk = 27,
        F_Happy = 28,
        F_Hate = 29,
        F_Eat = 30,
        F_Happy_A = 31,
        F_Happy_C = 32,
        WaitC01 = 33,
        Wait04 = 34,
        Max = 35,
    }

    [Serializable]
    public struct RenderingParam
    {
        public int stencilRef;
        public CompareFunction stencilComp;
        public StencilOp stencilOp;

        public static RenderingParam Factory()
        {
            return default(RenderingParam);
        }
    }
}