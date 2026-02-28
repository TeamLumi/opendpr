using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.Battle.View.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class BattleViewUICanvasBase : MonoBehaviour
    {
        [Header("[TransitionType]")]
        [Tooltip("遷移種別")]
        [SerializeField]
        protected TransitionType _transitionType;
        [Header("[TransitionParams]")]
        [SerializeField]
        protected TransitionParams _transitionParams = TransitionParams.Factory();
        internal RectTransform _cachedRectTransform;
        protected CanvasGroup _canvasGroup;
        protected Action _onShowComplete;
        protected Action _onHideComplete;

        public RectTransform RectTransform
        {
            get
            {
                if (_cachedRectTransform != null)
                    return _cachedRectTransform;

                _cachedRectTransform = transform as RectTransform;
                return _cachedRectTransform;
            }
        }
        protected int MaxIndex { get; set; }
        public CanvasGroup CanvasGroup { get => this.GetComponentThis(ref _canvasGroup); }
        public int CurrentIndex { get; protected set; }
        public bool IsFocus { get; protected set; }
        public bool IsShow { get; protected set; }
        public bool IsValid { get; protected set; }
        public bool IsTransition { get; protected set; }
        public BattleUIAnimationState animationState { get; protected set; }
        public bool isOpenState { get => animationState == BattleUIAnimationState.Opening || animationState == BattleUIAnimationState.Opened; }
        public bool isCloseState { get => animationState == BattleUIAnimationState.closing || animationState == BattleUIAnimationState.Closed; }

        // TODO
        private void OnDestroy() { }

        public virtual void Startup()
        {
            IsValid = false;
            IsFocus = false;
            IsShow = false;
            animationState = BattleUIAnimationState.Closed;

            CanvasGroup.alpha = 0.0f;
        }

        // TODO
        public virtual void Reset() { }

        public virtual void UnInitialize()
        {
        	this._cachedRectTransform = null;
        	this._canvasGroup = null;
        	this._onShowComplete = null;
        	this._onHideComplete = null;
        }

        // TODO
        public abstract void OnUpdate(float deltaTime);

        public void Show([Optional] Action onComplete)
        {
            _onShowComplete = onComplete;

            if (DOTween.IsTweening(CanvasGroup))
                CanvasGroup.DOKill();

            PlayTransitionAnimation(true);
        }

        public void Hide([Optional, DefaultParameterValue(false)] bool isForce, [Optional] Action onComplete)
        {
            IsFocus = false;
            _onHideComplete = onComplete;
            PlayTransitionAnimation(false);
        }

        // TODO
        protected void PlayTransitionAnimation(bool isShow) { }

        // TODO
        private IEnumerator OnPlayAnimationCor(float time) { return null; }

        protected virtual void PreparaNext(bool isForward)
        {
            if (isForward)
                CurrentIndex++;
            else
                CurrentIndex--;
        }

        public virtual void ForceHide()
        {
            // Empty
        }

        protected virtual void OnShow()
        {
            IsFocus = true;
            IsShow = true;
            animationState = BattleUIAnimationState.Opened;
        }

        protected virtual void OnHide()
        {
            IsShow = false;
            animationState = BattleUIAnimationState.Closed;
        }

        protected virtual void OnPlayAnimation()
        {
            // Empty
        }

        // TODO
        protected virtual void SetAlpha(float alpha, float duration = 0.0f) { }

        // TODO
        protected void SelectButton<T>(ICollection<T> buttons, int index, bool isPlaySe = true) { }

        public enum TransitionType : byte
        {
            FadeInOut = 0,
            SlideInOut = 1,
            Animator = 2,
        }

        public enum BattleUIAnimationState : int
        {
            None = 0,
            Opening = 1,
            Opened = 2,
            closing = 3,
            Closed = 4,
        }

        [Serializable]
        public struct TransitionParams
        {
            [Tooltip("表示位置")]
            public Vector2 HideAnchorPosition;
            [Tooltip("非表示位置")]
            public Vector2 ShowAnchorPosition;
            public Ease Ease;
            public float Duration;
            public float Delay;

            public static TransitionParams Factory()
            {
                return new TransitionParams()
                {
                    HideAnchorPosition = Vector2.zero,
                    ShowAnchorPosition = Vector2.zero,
                    Ease = Ease.OutSine,
                    Duration = 0.25f,
                    Delay = 0.0f,
                };
            }
        }
    }
}