using DPData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
    public class TvRankingWindow : UIWindow
    {
        [SerializeField]
        private UIText _title;
        [SerializeField]
        private UIText _subTitie;
        [SerializeField]
        private Image _titleBg;
        [SerializeField]
        private Cursor _cursorMenu;
        [SerializeField]
        private Cursor _cursorRank;
        [SerializeField]
        private RectTransform _menuItemRoot;
        [SerializeField]
        private RectTransform _rankItemRoot;
        [SerializeField]
        private UIText _menuDescription;
        [SerializeField]
        private RankingParam[] _rankingParam;

        private int _selectMenuIndex;
        private int _selectRankIndex;
        private List<TvRankingMenuItem> _menuItems = new List<TvRankingMenuItem>();
        private List<TvRankingRankItem> _rankItems = new List<TvRankingRankItem>();
        private bool _isActiveMenu = true;

        private const int _rankMaxNum = 6;

        private Param _param;

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
        public static int GetRankingId(RECORD_ID recordId) { return default; }

        public static int GetRankingFlagIndex(int rankingId, Param.RankingType rankingType)
        {
        	return rankingType + rankingId * 2;
        }

        // TODO
        private void SetupRankParamRanks(List<TvRankingMenuItem.RankParam> rankParams) { }

        // TODO
        private void SetupRanking(TvRankingMenuItem menuItem) { }

        // TODO
        private void SetupKeyguide() { }

        // TODO
        public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }

        // TODO
        public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }

        // TODO
        private void OnUpdate(float deltaTime) { }

        // TODO
        private void DeleteRank() { }

        // TODO
        protected override void OnAddContextMenuYesNoItemParams(List<ContextMenuItem.Param> contextMenuItemParams) { }

        // TODO
        private void SetActiveList(bool isActiveMenu) { }

        private bool UpdateSelect()
        {
        	if (this._isActiveMenu) {
        	  UpdateSelectMenu();
        	}
        	UpdateSelectRank();
        	return false;
        }

        // TODO
        private bool UpdateSelectMenu() { return default; }

        // TODO
        private bool SetSelectMenuIndex(int selectIndex, bool isInitialize = false) { return default; }

        // TODO
        private bool UpdateSelectRank() { return default; }

        // TODO
        private bool SetSelectRankingIndex(int selectIndex, bool isInitialize = false) { return default; }

        [Serializable]
        private class RankingParam
        {
            public Sprite titleBg;
        }

        public class Param
        {
            public RankingType rankingType;
            public RankingCategory rankingCategory;

            public enum RankingType : int
            {
                Group = 0,
                Global = 1,
                Num = 2,
            }

            public enum RankingCategory : int
            {
                Pokemon = 0,
                BattleTower = 1,
                Contest = 2,
                Num = 3,
            }
        }
    }
}