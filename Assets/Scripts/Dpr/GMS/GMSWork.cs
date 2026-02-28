using DPData;
using UnityEngine;

namespace Dpr.GMS
{
    public static class GMSWork
    {
        public static ushort GetStartTradeListIndex { get => PlayerWork.gmsData.tradeListIndex; }

        // TODO
        public static void SetStartTradeListIndex(ushort index) { }

        public static ushort GetStartBrowsingListIndex { get => PlayerWork.gmsData.browsingListIndex; }

        // TODO
        public static void SetStartBrowsingListIndex(ushort index) { }

        public static byte GetUserAchievementStep { get => PlayerWork.gmsData.achievementStep; }

        // TODO
        public static void SetUserAchievementStep(byte step) { }

        // TODO
        public static void ApplyAllPointData(GMSPointDataModel pointData) { }

        // TODO
        public static void ApplyPointData(PointHistoryDataModel pointData, int pointIndex, int dataIndex) { }

        public static int CalcPointExtDataIndex(int pointIndex, int historyIndex)
        {
        	return pointIndex * 5 + historyIndex;
        }

        // TODO
        public static void OverwriteHistoryData(int pointIndex, int dataIndex, IntermediatePointData newHistoryData) { }

        // TODO
        private static void SwapHistoryData(int srcPointIndex, int srcDataIndex, int destPointIndex, int destDataIndex) { }

        // TODO
        public static void DeleteHistoryData(int pointIndex, int dataIndex) { }

        // TODO
        public static void SortHistoryData(int pointIndex) { }

        // TODO
        public static IntermediatePointData ConvertPointData(GMS_POINT_HISTORY_DATA hitsoryData, GMS_POINT_HISTORY_EXT_DATA extData) { return default; }

        // TODO
        public static IntermediatePointData ConvertPointData(TradeResultData resultData) { return default; }

        // TODO
        public static void ResetGMSData() { }

        // TODO
        public static void ResetAllPointHistoryData() { }

        // TODO
        private static void SetHistoryData(ref GMS_POINT_HISTORY_DATA historyData, ref GMS_POINT_HISTORY_EXT_DATA extData, IntermediatePointData newHistoryData) { }

        // TODO
        private static void ResetHistoryData(ref GMS_POINT_HISTORY_DATA historyData) { }

        // TODO
        public static void AddReward(int itemNo, int itemNum) { }

        // TODO
        public static void ApplyReportData_MagicalTrade(TradeResultData tradeResult) { }

        // TODO
        public static void EmitLog(string log, LogType logType = LogType.Log) { }
    }
}