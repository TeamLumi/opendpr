using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class MultiModelView : MonoBehaviour
	{
		private const int RT_DEPTH = 16;

		[SerializeField]
		private RawImage[] targetRawImages;
		[SerializeField]
		private Camera rtCamera;
		[SerializeField]
		private Vector2Int rtSize = new Vector2Int(1280, 720);
		[SerializeField]
		private float modelPosY;
		[SerializeField]
		private int objectLayer;

		private Dictionary<int, AssetBundleUnloader> unloaders = new Dictionary<int, AssetBundleUnloader>();
		private ViewModelData[] viewModelDataArray;
		private RenderTexture renderTexture;
		private Transform modelRoot;
		private float modelViewPortSpace = 1.0f;
		private int modelViewCount;
		
		public bool bIsInitialize { get; private set; }
		
		// TODO
		private void Start() { }
		
		// TODO
		private void Initialize() { }
		
		// TODO
		private void CreateRenderTexture() { }
		
		public void SetRawImage(RawImage[] rawImages)
		{
			this.targetRawImages = rawImages;
			Initialize();
		}
		
		// TODO
		private void SettingRawImages() { }
		
		// TODO
		public Rect CalcRawImageRect(int index, float width, float height, ref Rect rect) { return default; }
		
		// TODO
		private void OnDestroy() { }
		
		public int ModelViewCount { get => modelViewCount; }
		public int TotalModelViewCount { get => viewModelDataArray?.Length ?? 0; }
		
		// TODO
		public bool HasViewModelByIndex(int index) { return default; }
		
		// TODO
		public void LoadCharacterModel(int index, string modelPath, Action<ViewModelData> onCompleteLoad) { }
		
		// TODO
		private void SettingModelData(int createIndex, string modelPath, GameObject modelObj) { }
		
		// TODO
		public void DestroyModel(int index) { }
		
		// TODO
		public void ChangeModelMotion(int index, int motionIndex) { }

		public class ViewModelData
		{
			public GameObject modelObj;
			public BattleCharacterEntity entity;
		}
	}
}