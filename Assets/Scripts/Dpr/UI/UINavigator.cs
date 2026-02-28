using UnityEngine;

namespace Dpr.UI
{
    public class UINavigator : MonoBehaviour
    {
        [SerializeField]
        protected UINavigator _left;
        [SerializeField]
        protected UINavigator _right;
        [SerializeField]
        protected UINavigator _top;
        [SerializeField]
        protected UINavigator _bottom;
        [SerializeField]
        protected bool _isStopLeft;
        [SerializeField]
        protected bool _isStopRight;
        [SerializeField]
        protected bool _isStopTop;
        [SerializeField]
        protected bool _isStopBottom;
        protected UINavigator[] _navigates;
        protected bool[] _isStops;
        public object userParam;
        private bool isInitialized;

        public UINavigator left { get; set; }
        public UINavigator top { get; set; }
        public UINavigator right { get; set; }
        public UINavigator bottom { get; set; }
        public UINavigator[] navigates { get; set; }

        // TODO
        public UINavigator() { }

        // TODO
        protected virtual void Awake() { }

        // TODO
        public virtual UINavigator GetNavigate(NavigateType type) { return null; }

        // TODO
        public virtual void SetNavigate(NavigateType type, UINavigator navigate) { }

        public virtual bool IsStop(NavigateType type)
        {
        	if (type < this._isStops.Length) {
        	  return this._isStops + (int)type[0];
        	}
        }

        public enum NavigateType
        {
            None = -1,
            Left = 0,
            Top = 1,
            Right = 2,
            Bottom = 3,
        }
    }
}