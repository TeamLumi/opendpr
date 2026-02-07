using AttributeData;
using SmartPoint.AssetAssistant;
using System;
using XLSXContent;

namespace Dpr.Battle.Logic
{
    public sealed class BattleDataTableManager
    {
        private static BattleDataTableManager s_Instance;
        private static readonly string[] AB_NAMES = { "battle_masterdatas" };

        public static BattleDataTableManager Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new BattleDataTableManager();
                return s_Instance;
            }
        }
        public BattleDataTable BattleDataTable { get; private set; }
        public BattleDefaultPlacementData BattleDefaultPlacementData { get; private set; }
        public BattleWaitCameraData BattleWaitCameraData { get; private set; }
        public BattleSetupEffectLots BattleSetupEffectLots { get; private set; }
        public bool IsInitialized { get; private set; }
        private bool IsABAppended { get; set; }

        public bool AppendAssetBundleRequests()
        {
            if (!IsInitialized && !IsABAppended)
            {
                IsABAppended = true;
                for (int i=0; i<AB_NAMES.Length; i++)
                    AssetManager.AppendAssetBundleRequest(AB_NAMES[i], true, null, null);

                return true;
            }

            return false;
        }

        public bool OnDispatchRequests(RequestEventType eventType, string name, UnityEngine.Object asset)
        {
            if (!IsInitialized)
            {
                if (eventType == RequestEventType.Cached)
                {
                    if (Array.IndexOf<string>(AB_NAMES, name) > -1)
                    {
                        AssetManager.UnloadAssetBundle(name);
                        return true;
                    }
                }
                else if (eventType == RequestEventType.Activated && asset != null)
                {
                    if (asset is BattleDataTable)
                        BattleDataTable = asset as BattleDataTable;
                    else if (asset is BattleDefaultPlacementData)
                        BattleDefaultPlacementData = asset as BattleDefaultPlacementData;
                    else if (asset is BattleWaitCameraData)
                        BattleWaitCameraData = asset as BattleWaitCameraData;
                    else if (asset is BattleSetupEffectLots)
                        BattleSetupEffectLots = asset as BattleSetupEffectLots;
                    else
                        return false;

                    return true;
                }
            }

            return false;
        }

        private bool IsLoaded
        {
            get
            {
                return BattleDataTable != null &&
                    BattleDefaultPlacementData != null &&
                    BattleWaitCameraData != null &&
                    BattleSetupEffectLots != null;
            }
        }

        public void OnAfterLoadAll()
        {
            if (!IsInitialized)
            {
                Sequencer.update += OnAfterLoadAll_Update;
                IsInitialized = true;
            }
        }

        private static void OnAfterLoadAll_Update(float deltaTime)
        {
            Sequencer.update -= OnAfterLoadAll_Update;
        }

        public static BattleSetupEffectLots.SheetArenaEffTable GetArenaEff(ArenaID arenaID)
        {
            var table = Instance.BattleSetupEffectLots?.ArenaEffTable;
            if (table != null)
            {
                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i].ArenaID == arenaID)
                        return table[i];
                }
            }
            return null;
        }

        public static BattleSetupEffectLots.SheetAttEffTable GetAttEff(MapAttributeEx mapAttributeEx, ArenaID arenaID)
        {
            var table = Instance.BattleSetupEffectLots?.AttEffTable;
            if (table != null)
            {
                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i].AttributeEx == mapAttributeEx && table[i].ArenaID == arenaID)
                        return table[i];
                }
            }
            return null;
        }

        public static BattleSetupEffectLots.SheetRuleEffTable GetRuleEff(BattleSetupEffectLot lot)
        {
            var table = Instance.BattleSetupEffectLots?.RuleEffTable;
            if (table != null)
            {
                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i].Rule == lot)
                        return table[i];
                }
            }
            return null;
        }
    }
}
