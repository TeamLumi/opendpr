using XLSXContent;

namespace Pml.Item
{
    public class UgItemManager
    {
        public static UgItemManager Instance { get; } = new UgItemManager();

        private UgItemTable m_ugItemTable;
        private TamaTable m_tamaTable;
        private PedestalTable m_pedestalTable;
        private StoneStatuEeffect m_stoneStatuEeffect;

        public int UgItemTotal { get => m_ugItemTable.table.Length; }

        public void Initialize(UgItemTable ugItemTable, TamaTable tamaTable, PedestalTable pedestalTable, StoneStatuEeffect stoneStatuEeffect)
        {
            m_ugItemTable = ugItemTable;
            m_tamaTable = tamaTable;
            m_pedestalTable = pedestalTable;
            m_stoneStatuEeffect = stoneStatuEeffect;
        }

        // TODO
        public bool IsExclusiveUseUG(int ugItemId) { return false; }

        // TODO
        public int GetItemId(int ugItemId) { return 0; }

        public UgItemTable.Sheettable GetUgItemData(int ugItemId)
        {
        	var lVar1 = GetUgItemDataRaw();
        	if (lVar1 != null) {
        	}
        	this.m_ugItemTable[0];
        	return null;
        }

        // TODO
        public TamaTable.Sheettable GetTamaData(int ugItemId) { return null; }

        // TODO
        public PedestalTable.SheetInfo GetPedestalData(int ugItemId) { return null; }

        // TODO
        public StoneStatuEeffect.Sheettable GetStoneStatuEeffectData(int ugItemId) { return null; }

        // TODO
        public UgItemTable.Sheettable GetUgItemDataFromPedestalId(int pedestalId) { return null; }

        // TODO
        public UgItemTable.Sheettable GetUgItemDataFromTamaId(int tamaId) { return null; }

        // TODO
        public UgItemTable.Sheettable GetUgItemDataStatueId(int statueId) { return null; }

        // TODO
        private UgItemTable.Sheettable GetUgItemDataRaw(int ugItemId) { return null; }

        // TODO
        public int GetNumStatueKInd() { return 0; }

        public bool IsTama(int ugItemId)
        {
        	var lVar1 = GetUgItemDataRaw();
        	return 0 < lVar1.Length;
        }

        // TODO
        public bool IsPedestal(int ugItemId) { return false; }

        public bool IsStatue(int ugItemId)
        {
        	var lVar1 = GetUgItemDataRaw();
        	return 0 < lVar1[0];
        }
    }
}