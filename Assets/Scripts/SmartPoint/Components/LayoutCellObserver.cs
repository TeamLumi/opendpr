using UnityEngine;
using UnityEngine.EventSystems;

namespace SmartPoint.Components
{
	[RequireComponent(typeof(RectTransform))]
	public class LayoutCellObserver : MonoBehaviour, ISelectHandler, IEventSystemHandler
	{
		private LayoutScrollView.Cell _cell;
		private LayoutScrollView _scrollView;
		private bool _enabled;
		private GameObject _gameObject;
		
		// TODO
		public bool enabled { get; set; }
		
		// TODO
		public virtual void OnSelect(BaseEventData eventData) { }
		
		// TODO
		public void OnEnable() { }
		
		// TODO
		public void OnDisable() { }
		
		// TODO
		public LayoutScrollView scrollView { get; set; }
		
		// TODO
		public LayoutScrollView.Cell cell { get; set; }
		
		// TODO
		public virtual Vector2 sizeDelta { get; }
		
		// TODO
		public virtual void OnSetup() { }
		
		public virtual bool IsReady() {
		    return true;
		}
		
		public virtual bool OnRebuildLayout() {
		    return false;
		}
		
		// TODO
		public virtual void OnUpdate(float deltaTime) { }
		
		// TODO
		public virtual void OnOpen(Rect rect) { }
		
		// TODO
		public virtual void OnClose() { }
	}
}