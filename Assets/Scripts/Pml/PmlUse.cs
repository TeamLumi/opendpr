using Dpr.Message;
using Pml.Item;
using Pml.Personal;
using Pml.PokePara;
using Pml.UgFather;
using Pml.WazaData;
using SmartPoint.AssetAssistant;
using System;
using XLSXContent;

namespace Pml
{
    public class PmlUse
    {
        private static PmlUse s_Instance;
        private static readonly string[] AB_PERSONALS = { "personal_masterdatas" };
        public bool isAutoLoad;
        private PersonalTable personalTotal;
        private GrowTable growTableTotal;
        private EvolveTable evolveTableTotal;
        private WazaOboeTable wazaOboeTotal;
        private WazaTable wazaDataTotal;
        private ItemTable itemPrmTotal;
        private TamagoWazaTable tamagoWazaTotal;
        private AddPersonalTable addPersonalTotal;
        private SealTable sealTotal;
        private UgItemTable ugItemPrmTotal;
        private TamaTable tamaTableTotal;
        private PedestalTable pedestalTableTotal;
        private StoneStatuEeffect stoneStatuEeffectTotal;
        private UgFatherPos ugfPosTotal;
        private UgFatherExpansion ugfExpansionTotal;
        private UgFatherShopTable ugfShopTotal;
        private EvolveManager evolveManager;
        private bool isABAppended;
        private bool isInitialized;

	    public static PmlUse Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new PmlUse();
                return s_Instance;
            }
        }
        public TamagoWazaTable TamagoWazaTable { get => tamagoWazaTotal; }
        public AddPersonalTable AddPersonalTable { get => addPersonalTotal; }
        public SealTable SealTable { get => sealTotal; }
        public bool IsInitialized { get => isInitialized; }
        public bool IsPersistentTiming { get; set; }

        private bool IsPmlAssetBundleName(string name)
        {
            return Array.IndexOf<string>(AB_PERSONALS, name) > -1;
        }

        public bool AppendAssetBundleRequests()
        {
            if (!isInitialized && !isABAppended)
            {
                isABAppended = true;
                for (int i=0; i<AB_PERSONALS.Length; i++)
                    AssetManager.AppendAssetBundleRequest(AB_PERSONALS[i], true, null, null);

                return true;
            }

            return false;
        }

        public bool OnDispatchRequests(RequestEventType eventType, string name, UnityEngine.Object asset)
        {
            if (!isInitialized)
            {
                if (eventType == RequestEventType.Cached)
                {
                    if (IsPmlAssetBundleName(name))
                    {
                        AssetManager.UnloadAssetBundle(name);
                        return true;
                    }    
                }
                else if (eventType == RequestEventType.Activated && asset != null)
                {
                    if (asset is PersonalTable)
                        personalTotal = asset as PersonalTable;
                    else if (asset is GrowTable)
                        growTableTotal = asset as GrowTable;
                    else if (asset is EvolveTable)
                        evolveTableTotal = asset as EvolveTable;
                    else if (asset is WazaOboeTable)
                        wazaOboeTotal = asset as WazaOboeTable;
                    else if (asset is WazaTable)
                        wazaDataTotal = asset as WazaTable;
                    else if (asset is ItemTable)
                        itemPrmTotal = asset as ItemTable;
                    else if (asset is TamagoWazaTable)
                        tamagoWazaTotal = asset as TamagoWazaTable;
                    else if (asset is AddPersonalTable)
                        addPersonalTotal = asset as AddPersonalTable;
                    else if (asset is SealTable)
                        sealTotal = asset as SealTable;
                    else if (asset is UgItemTable)
                        ugItemPrmTotal = asset as UgItemTable;
                    else if (asset is TamaTable)
                        tamaTableTotal = asset as TamaTable;
                    else if (asset is PedestalTable)
                        pedestalTableTotal = asset as PedestalTable;
                    else if (asset is StoneStatuEeffect)
                        stoneStatuEeffectTotal = asset as StoneStatuEeffect;
                    else if (asset is UgFatherPos)
                        ugfPosTotal = asset as UgFatherPos;
                    else if (asset is UgFatherExpansion)
                        ugfExpansionTotal = asset as UgFatherExpansion;
                    else if (asset is UgFatherShopTable)
                        ugfShopTotal = asset as UgFatherShopTable;
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
                return personalTotal != null &&
                    growTableTotal != null &&
                    evolveTableTotal != null &&
                    wazaOboeTotal != null &&
                    wazaDataTotal != null &&
                    itemPrmTotal != null &&
                    tamagoWazaTotal != null &&
                    addPersonalTotal != null &&
                    sealTotal != null &&
                    ugItemPrmTotal != null &&
                    tamaTableTotal != null &&
                    pedestalTableTotal != null &&
                    stoneStatuEeffectTotal != null;
            }
        }

        public void OnAfterLoadAll()
        {
            if (isInitialized)
                return;

            Accessor.Initialize();

            // This is supposed to be called twice
            CoreParam.CheckPublicDataSize();
            CoreParam.CheckPublicDataSize();

            PersonalSystem.Initialize(personalTotal, wazaOboeTotal, growTableTotal, evolveTableTotal);
            WazaDataSystem.Initialize(wazaDataTotal);
            ItemManager.Instance.Load(itemPrmTotal);
            UgItemManager.Instance.Initialize(ugItemPrmTotal, tamaTableTotal, pedestalTableTotal, stoneStatuEeffectTotal);
            UgFatherDataManager.Instance.Initialize(ugfPosTotal, ugfExpansionTotal, ugfShopTotal);
            evolveManager = new EvolveManager();

            isInitialized = true;
        }

        public EvolveManager GetEvolveManager()
        {
        	return this.evolveManager;
        }

        public int LangId { get => (int)MessageHelper.ConvertMsgId(PlayerWork.msgLangID); }

        public byte CassetVersion { get => (byte)PlayerWork.cassetVersion; }

        public uint RandFunc()
        {
        	Random.Range(0x80000000,0x7fffffff);
        	return 0;
        }

        // TODO
        public uint LimitRandFunc(uint max_range) { return 0; }
    }
}