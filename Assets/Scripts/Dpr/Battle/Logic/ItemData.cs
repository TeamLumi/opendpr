namespace Dpr.Battle.Logic
{
    public static class ItemData
    {
        public static bool HaveItem(ushort itemno)
        {
            var itemInfo = ItemWork.GetItemInfo(itemno);
            if (itemInfo == null)
            {
                return false;
            }
            return itemInfo.count > 0;
        }

        public static bool IsBallExist()
        {
            var balls = ItemWork.GetItemInfosByCategory(Dpr.Item.ItemInfo.CategoryType.Ball);
            if (balls == null)
            {
                return false;
            }
            return balls.Count > 0;
        }
    }
}