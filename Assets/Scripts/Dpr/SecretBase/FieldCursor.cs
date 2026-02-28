using UnityEngine;

namespace Dpr.SecretBase
{
	public class FieldCursor : MonoBehaviour
	{
		[SerializeField]
		private Transform cursorRoot;
		[SerializeField]
		private FieldCursorGrid fieldCursorGrid;
		[SerializeField]
		private Transform field;
		[SerializeField]
		private bool isMove;
		[SerializeField]
		private Transform pointer;
		[SerializeField]
		private Transform node;
		[SerializeField]
		private Transform statueRoot;
		[SerializeField]
		private BoxCollider boxCollider;

		private RectInt rect;
		private Vector3 cursorOffset = new Vector3(-0.5f, 0.0015f, 0.5f);
		private Vector3 cursorPosition = new Vector3(0.0f, 0.0f, 0.0f);
		
		public int Width { get => fieldCursorGrid.Width; }
		public int Height { get => fieldCursorGrid.Height; }
		public Transform Node { get => node; }
		public Transform StatueRoot { get => statueRoot; }
		public BoxCollider BoxCollider { get => boxCollider; }
		
		// TODO
		private void Update() { }
		
		// TODO
		public void SetPosition(Vector2Int gridPosition) { }
		
		// TODO
		public void SetRect(RectInt value) { }
		
		// TODO
		public void SetRect(int x, int y, int width, int height) { }
		
		// TODO
		public RectInt GetRect() { return default; }
		
		// TODO
		public void SetActiveField(bool value) { }
		
		public void SetActiveCursor(bool value)
		{
			GameObject.SetActive(this.cursorRoot.gameObject,(value ? 1 : 0) & 1,0);
		}
		
		public void SetActivePointer(bool value)
		{
			if (this.pointer != null) {
			  GameObject.SetActive(this.pointer.gameObject,(value ? 1 : 0) & 1,0);
			}
		}
		
		// TODO
		public void SetPointerHeight(float height) { }
	}
}