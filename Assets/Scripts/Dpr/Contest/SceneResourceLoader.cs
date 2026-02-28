using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.U2D;
using XLSXContent;

namespace Dpr.Contest
{
	public class SceneResourceLoader
	{
		private bool bLoading;
		
		public bool Loading { get => bLoading; }
		
		public void Initialize()
		{
			this.bLoading = false;
		}
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		public void UnloadAssetBundle() { }
		
		// TODO
		public void LoadScenePrefabs(string assetBundlePath, Transform parent, Action<string, GameObject> onCompleteLoad) { }
		
		// TODO
		public void LoadSpriteAtlas(string assetBundlePath, Action<SpriteAtlas> onCompleteLoad) { }
		
		// TODO
		public void LoadContestMasterDatas(string assetBundlePath, Action<UnityEngine.Object> onCompleteLoad) { }
		
		// TODO
		public void LoadNotesPatternData(string assetBundlePath, Action<NotesInfo> onCompleteLoad) { }
		
		// TODO
		public void LoadSprite(string path, Action<Sprite> onCompleteLoad, [Optional] string[] variants) { }
		
		// TODO
		public void LoadMigawariModel(Action onCompleteLoad) { }
		
		// TODO
		public void RequestLoadAsset() { }
	}
}