using DPData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
    public class ReportWindowBase : UIWindow
    {
        [SerializeField]
        protected float _closeWaitTimeBySave = 0.5f;
        [SerializeField]
        protected UIText _place;
        [SerializeField]
        protected UIText _nowDatetime;
        [SerializeField]
        protected UIText _name;
        [SerializeField]
        protected UIText _badge;
        [SerializeField]
        protected RectTransform _zukanRoot;
        [SerializeField]
        protected UIText _zukanRegistNum;
        [SerializeField]
        protected UIText _playTime;
        [SerializeField]
        protected UIText _saveDatetime;
        [SerializeField]
        protected RectTransform _iconContent;
        private DateTime _prevNow;
        private PLAYTIME _prevPlayTime;

        public override void OnCreate()
        {
        	UIWindow.OnCreate();
        	var uVar1 = UnityEngine_Component__GetComponentInChildren<object>
        	                  (this,1);
        	this._animator = uVar1;
        }

        // TODO
        public virtual void Open(UIWindowID prevWindowId) { }

        // TODO
        public virtual IEnumerator OpOpen(UIWindowID prevWindowId) { return null; }

        // TODO
        public virtual void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }

        // TODO
        public virtual IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return null; }

        // TODO
        protected virtual void Setup() { }

        // TODO
        protected virtual void OnUpdate(float deltaTime) { }

        // TODO
        protected virtual void SaveReport() { }

        // TODO
        protected virtual IEnumerator OpSave() { return null; }

        // TODO
        protected virtual IEnumerator OpWaitingClose() { return null; }

        // TODO
        protected override void OnAddContextMenuYesNoItemParams(List<ContextMenuItem.Param> contextMenuItemParams) { }
    }
}