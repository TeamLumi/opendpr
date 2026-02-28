using DPData;
using Dpr.Battle.View.Objects;
using Dpr.Battle.View.Systems;
using Dpr.Contest;
using Effect;
using Pml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.UI
{
    public class UIContestPhoto : UIWindow
    {
        private static Dictionary<int, List<PhotoWazaEffect>> _wazaEffectsTable;
        private static Dictionary<int, PhotoPokemonModel> _pokeModelTable;
        private static StageModel _stageModel;
        private static bool _haveCache;
        private const string CNT_PHOTO_FRAME_PATH = "contestphoto/cnt_photo_frame_";
        private readonly string GRAPHIC_TEXT_NAME = "cnt_photo_best";
        [SerializeField]
        private EnvironmentController _envController;
        [SerializeField]
        private BOCamera _boCamera;
        [SerializeField]
        private CanvasGroup canvasGroup;
        [SerializeField]
        private Image photoTitleImage;
        private CON_PHOTO_DATA _photoData;
        private CON_PHOTO_EXT_DATA _extData;
        private ContestMasterDatas.SheetContestData useContestData;
        private ContestMasterDatas.SheetRankData useRankData;
        private StageEffect _stageFx = new StageEffect();
        private BattleSequenceSystem _iPtrSequenceSystem = new BattleSequenceSystem(null);
        private EnvironmentSettings _currentRenderSettings;
        private ContestSettings _settingData;
        private Coroutine colSetupMotion;
        private UIText messageTxt;
        private Image photoFrameImage;
        private Sprite photoFrameSpr;
        private Sprite titleSprite;
        private Vector3 _offsetPos;
        private CategoryID _selectCategoryID;
        private string wazaSeqPath;
        private int _loadFxCount;
        private bool _bLoadAssetBundle;
        private string _photoFrameSprPath;

        // TODO
        public static void ReleasePhotoResources() { }

        // TODO
        private static void ReleasePokeModel() { }

        // TODO
        private static void ReleaseWazaEffect() { }

        public override void OnCreate()
        {
        	UIWindow.OnCreate();
        	this._bLoadAssetBundle = false;
        	var uVar1 = ComponentExtensions.FindDeep(StringLiteral_11795,0);
        	uVar1 = UnityEngine_GameObject__GetComponent<object>
        	                  (uVar1);
        	this.photoFrameImage = uVar1;
        	uVar1 = ComponentExtensions.FindDeep(StringLiteral_11796,0);
        	uVar1 = UnityEngine_GameObject__GetComponent<object>
        	                  (uVar1);
        	this.messageTxt = uVar1;
        	this._stageFx.Initialize();
        }

        // TODO
        public void Open(int categoryID, CON_PHOTO_DATA photoData, CON_PHOTO_EXT_DATA extData) { }

        // TODO
        private IEnumerator OpOpen()
        {
            return null;
        }

        // TODO
        private bool LoadingFx { get; }

        private bool IsMigawari { get => _photoData.wazaNo == (int)WazaNo.MIGAWARI; }

        // TODO
        private void AppendContestMasterData() { }

        // TODO
        private void AppendContestSettings() { }

        // TODO
        private void AppendPhotoFrameSprite() { }

        // TODO
        private void AppendLoadSpriteTask(string path, Action<Sprite> onCompleteLoad, [Optional] string[] variants) { }

        // TODO
        private void AppendStageResource() { }

        // TODO
        private void AppendPokemonResource() { }

        // TODO
        private void AppendLoadMigawariModel() { }

        // TODO
        private void RequestLoadAssetBundle() { }

        // TODO
        private IEnumerator OpLoadSequence()
        {
            return null;
        }

        // TODO
        private void LoadStageFx() { }

        // TODO
        private EffectContestID[] CreateMonitorIDs() { return default; }

        // TODO
        private void LoadWazaFx() { }

        // TODO
        private void CreateEffectByFilePath(CON_PHOTO_FX_DATA fxData, EffectDatabase.SheetBattleEffectData fxParam) { }

        // TODO
        private string CreatePokeModelPathByCatalog(XLSXContent.PokemonInfo.SheetCatalog catalog) { return default; }

        // TODO
        private void Setup() { }

        // TODO
        private void SetupUI() { }

        // TODO
        private void SetupLight() { }

        // TODO
        private void ActivateCamera() { }

        // TODO
        private void SetupFx() { }

        // TODO
        private IEnumerator OpSetupMotion()
        {
            return null;
        }

        // TODO
        private void SetPhotoMessage() { }

        // TODO
        private void OnUpdate(float deltaTime) { }

        // TODO
        private void OnLateUpdate(float deltaTime) { }

        // TODO
        private void UpdateInput() { }

        // TODO
        private void CloseWindow() { }

        // TODO
        private IEnumerator OpClose()
        {
            return null;
        }

        // TODO
        private void HideCachedObject() { }

        // TODO
        private void Release() { }

        // TODO
        private void ReleaseCamera() { }

        // TODO
        private void UnloadResource() { }

        private class StageModel
        {
	        public GameObject modelObj;
            public string stageModelPath;

            // TODO
            public void Show(Transform parentTransform) { }

            public void Hide()
            {
            	if (this.fxInst != null) {
            	  GameObject.SetActive(this.fxInst.gameObject,0,0);
            	}
            }

            // TODO
            public void Release() { }
        }

        private class PhotoPokemonModel
        {
	        public BattlePokemonEntity pokeEntity;
            public GameObject migawariObj;
            public string photoTargetModelPath;

            private bool IsMigawari { get => migawariObj != null; }

            // TODO
            public void Show(Transform parentTransform) { }

            public void Hide()
            {
            	if (this.fxInst != null) {
            	  GameObject.SetActive(this.fxInst.gameObject,0,0);
            	}
            }

            // TODO
            public void Release() { }
        }

        private class PhotoWazaEffect
        {
	        public EffectData effectData;
            public EffectInstance fxInst;
            public float particlePlayTime;

            // TODO
            public void Show() { }

            public void Hide()
            {
            	if (this.fxInst != null) {
            	  GameObject.SetActive(this.fxInst.gameObject,0,0);
            	}
            }
        }
    }
}