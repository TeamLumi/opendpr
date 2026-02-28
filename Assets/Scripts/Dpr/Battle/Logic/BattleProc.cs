using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;

namespace Dpr.Battle.Logic
{
    public sealed class BattleProc : SingletonMonoBehaviour<BattleProc>
    {
        private static BATTLE_SETUP_PARAM setupParam;
        private static bool _isInitialized;
        private static bool _isEnd;
        public static EndFuncDelegate onEndFunc;
        public static EndFuncDelegate onInitializedFunc;
        public static bool isDebugLoopStop;
        private Transform cluster;
        private MainModule mainModule;
        private UpdateCoreFunc updateCore;
        private int subSeq;
        private bool isFinalized;

        public static bool isInitialized { get => _isInitialized; }
        public Transform Cluster { get => cluster; }
        public MainModule MainModule { get => mainModule; }
        public static bool isEnd { get => _isEnd; }

        // TODO
        private void OnEnable() { }

        // TODO
        private void OnDisable() { }

        // TODO
        private void OnDestroy() { }

        // TODO
        private void Shutdown() { }

        // TODO
        [SceneBeforeActivateOperationMethod]
        public IEnumerator ActivateOperation(Transform cluster) { return null; }

        // TODO
        private void OnInitialized() { }

        private void OnUpdate(float deltaTime)
        {
        	if (this.updateCore != null) {
        	  UpdateCoreFunc.Invoke();
        	}
        }

        private void SetUpdateCore(UpdateCoreFunc func)
        {
        	this.updateCore = func;
        	this.subSeq = 0;
        }

        // TODO
        private void UpdateInitialze(float deltaTime) { }

        // TODO
        private void UpdateMainRun(float deltaTime) { }

        // TODO
        private void UpdateMainFinalize(float deltaTime) { }

        // TODO
        private void UpdateEnd(float dletaTime) { }

        // TODO
        public static void SetParam(BATTLE_SETUP_PARAM inSetupParam) { }

        // TODO
        public IEnumerator FinalizeCoroutine() { return null; }

        // TODO
        private void StopBGM() { }

        public delegate void EndFuncDelegate();

        private delegate void UpdateCoreFunc(float deltaTime);
    }
}