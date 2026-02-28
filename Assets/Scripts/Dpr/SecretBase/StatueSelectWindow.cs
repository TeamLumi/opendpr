using System.Collections.Generic;
using UnityEngine;

namespace Dpr.SecretBase
{
	public class StatueSelectWindow : GridSelectWindow<StatueItem, StatueEffectData>
	{
		[SerializeField]
		private Canvas canvas;
		[SerializeField]
		private List<Sprite> placementSizeIcons = new List<Sprite>();
		[SerializeField]
		private List<Sprite> typeEffectIcons = new List<Sprite>();

		private int pokeType1 = -1;
		private int pokeType2 = -1;
		private int size;
		private int category;
		private int legend;

		private static int ListColumnNum_Normal = 6;
		private static int ListColumnNum_Large = 8;
		private static int ListContentSpacing_Normal = 30;
		private static int ListContentSpacing_Large = 4;

		private bool isListSizeNormal;
		private bool isBuildedLayout;
		private Vector2 baseCellSize;
		
		// TODO
		public Sprite GetPlacementSizeIcon(byte width, byte height) { return default; }
		
		// TODO
		public Sprite GetTypeEffectIcon(sbyte id) { return default; }
		
		// TODO
		private void Start() { }
		
		// TODO
		public void PreBuildLayout() { }
		
		public void Show()
		{
			this.isBuildedLayout = true;
			this.canvas.enabled = 1;
		}
		
		public void Close()
		{
			this.canvas.enabled = 0;
		}
		
		// TODO
		public void SetCursorFromRatio(float ratio, bool left) { }
		
		// TODO
		public void UpdateIcon(int id) { }
		
		// TODO
		public void UpdateIconAll(bool isDisable) { }
		
		// TODO
		public void SortIcon(bool isDisable) { }
		
		// TODO
		public static int Compare(StatueItem dataA, StatueItem dataB) { return default; }
		
		// TODO
		public void SetFillter(int pokeType1, int pokeType2, int size, int category, int legend, int indexId, bool isDisable) { }
		
		// TODO
		public void UpdateListSize() { }

		public class StatueItemCompare : IComparer<StatueItem>
		{
			// TODO
			public int Compare(StatueItem a, StatueItem b) { return default; }
		}

		private class NGMotionMono : MonoBehaviour
		{
			private float length = 1.0f;
			private int count;
			private Vector3 initPos;
			
			// TODO
			private void Start() { }
			
			// TODO
			private void Update() { }
		}
	}
}