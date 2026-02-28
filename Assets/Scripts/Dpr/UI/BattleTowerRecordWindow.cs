using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
    public class BattleTowerRecordWindow : UIWindow
    {
        [SerializeField]
        private RecordParam[] _recordParams;

        public override void OnCreate()
        {
        	UIWindow.OnCreate();
        	var uVar1 = UnityEngine_Component__GetComponentInChildren<object>
        	                  (this,1);
        	this._animator = uVar1;
        }

        // TODO
        public void Open(Param param, UIWindowID prevWindowId) { }

        // TODO
        public IEnumerator OpOpen(Param param, UIWindowID prevWindowId) { return default; }

        // TODO
        private void SetupKeyguide() { }

        // TODO
        private void EnableRecordParam(RecordParam recordParam, bool enabled) { }

        // TODO
        public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }

        // TODO
        public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }

        // TODO
        private void OnUpdate(float deltaTime) { }

        [Serializable]
        private class RecordParam
        {
            public RectTransform root;
            public RectTransform bgRoot;
            public RectTransform titleRoot;
            public UIText rank;
            public UIText consecutiveWinsTitle;
            public UIText consecutiveWins;
            public UIText maxConsecutiveWins;
        }

        public class Param
        {
            public RecordType recordType;
            public int rank = 1;
            public int consecutiveWins;
            public int maxConsecutiveWins;
            public bool isSuspended;

            public enum RecordType : int
            {
                Single = 0,
                Double = 1,
                MasterSingle = 2,
                MasterDouble = 3,
            }
        }
    }
}