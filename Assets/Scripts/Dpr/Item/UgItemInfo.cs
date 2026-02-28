using System;
using UnityEngine;

namespace Dpr.Item
{
    public class UgItemInfo
    {
        public const int ItemSaveSize = 999;
        public const int ItemMaxCount = 999;
        public const int StatueMaxCount = 99;

        private int _workNo;
        private int _dummyCount;
        private bool _dummyIsVanishNew;
        private int _sortNum = -1;

        public UgItemInfo(int item_no)
        {
            _workNo = item_no;
        }

        // TODO
        public int count { set; get; }
        public bool bIsNew { set; get; }
        public int UgItemId { get; }
        public string Name { get; }
        public string DescriptionText { get; }
        public CategoryType Category { get; }
        public int SortNumber { get; }

        // TODO
        public int AddItem(int num = 1) { return 0; }

        // TODO
        public int SubItem(int num = 1) { return 0; }

        // TODO
        public bool IsAddItem(int num = 1) { return false; }

        private int GetMaxCount()
        {
        	var iVar1 = get_Category();
        	var uVar2 = 99;
        	if (iVar1 != 2) {
        	  uVar2 = 999;
        	}
        	return uVar2;
        }

        // TODO
        public static void LoadItemIcon(int itemId, Action<Sprite> onLoadedCallback) { }

        // TODO
        public static void LoadItemIconL(int itemId, Action<Sprite> onLoadedCallback) { }

        public enum CategoryType : int
        {
            Tama = 0,
            Pedestal = 1,
            Statue = 2,
            Unknown = 3,
            Length = 4,
        }
    }
}