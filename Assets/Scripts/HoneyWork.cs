using DPData;
using Pml;
using System;
using XLSXContent;

public class HoneyWork
{
    private static DateTime? LastUpdateTime;
    private const int EncountTime = 360;
    private const int VanishTime = 1440;
    public const int RareTreeCount = 4;
    public const int ContinueProbability = 90;

    // TODO
    public static int GetTblMonsCount() { return 0; }

    public static int GetRareLvCount() {
        return 4;
    }

    public static int GetSwayLvCount() {
        return 4;
    }

    // TODO
    public static HONEY_DATA? GetHoneyData(ZoneID zoneId) { return null; }

    // TODO
    public static HONEY_DATA GetHoneyDataByIndex(int treeIndex) { return default(HONEY_DATA); }

    // TODO
    public static void SetHoneyData(ZoneID zoneId, in HONEY_DATA honeyData) { }

    // TODO
    public static void SetHoneyDataByIndex(int treeIndex, in HONEY_DATA honeyData) { }

    // TODO
    public static ZoneID IndexToZoneId(int treeIndex) { return ZoneID.UNKNOWN; }

    // TODO
    public static int ZoneIdToIndex(ZoneID zoneId) { return 0; }

    // TODO
    public static HoneyTree.SheetHoneyTreeIndex[] GetIndexToZoneIdTable() { return null; }

    // TODO
    public static int GetTreeCount() { return 0; }

    // TODO
    public static void UpdateTime() { }

    // TODO
    public static void UpdateTime(int minute) { }

    // TODO
    public static void Spread(int treeIndex) { }

    // TODO
    public static bool IsRateTree(int checkTreeIndex) { return false; }

    // TODO
    public static TableType LotteryTableType(bool isRareTree) { return TableType.Normal; }

    // TODO
    public static int LotteryTableMonsNo() { return 0; }

    // TODO
    public static MonsNo GetMonsNo(TableType tableType, int tblMonsNo) { return MonsNo.NULL; }

    // TODO
    public static SwayType LotterySwayType(TableType tableType) { return SwayType.Normal; }

    // TODO
    public static State CalcState(in HONEY_DATA data) { return State.HONEY_SPREAD_OK; }

    public enum State : int
    {
        Invalid = 0,
        HONEY_SPREAD_OK = 1,
        HONEY_SPREAD_ALREADY = 2,
        HONEY_SPREAD_ENCOUNT = 3,
    }

    public enum TableType : int
    {
        Normal = 0,
        Rare = 1,
        SuperRare = 2,
        Miss = 3,
        Count = 4,
    }

    public enum SwayType : int
    {
        Normal = 0,
        Big = 1,
        Super = 2,
        None = 3,
        Count = 4,
    }
}