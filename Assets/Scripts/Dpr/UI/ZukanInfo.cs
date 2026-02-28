using DPData;
using Pml;
using Pml.PokePara;
using XLSXContent;

namespace Dpr.UI
{
	public class ZukanInfo
	{
		private const string ZukanMessageFileName = "ss_pokedex";
		private const string NameMessageFileName = "ss_monsname";
		private const string FormMessageFileName = "ss_zkn_form";
		private const string TypeMessageFileName = "ss_zkn_type";
		private const string HeightMessageFileName = "ss_zkn_height";
		private const string WeightMessageFileName = "ss_zkn_weight";
		private const string UnknownNameMessageLabel = "SS_pokedex_029";
		private const string HeightMessageLabelNameFormat = "ZKN_HEIGHT_{0:D3}_{1:D3}";
		private const string WeightMessageLabelNameFormat = "ZKN_WEIGHT_{0:D3}_{1:D3}";
		
		public MonsNo MonsNo { get; private set; }
		public int ZukanNo { get; private set; }
		public string Name { get; private set; }
		public ushort Height { get; private set; }
		public ushort Weight { get; private set; }
		public string HeightText { get; private set; }
		public string WeightText { get; private set; }
		public PokeType Type1 { get; private set; }
		public PokeType Type2 { get; private set; }
		public GET_STATUS GetStatus { get; private set; }

        internal ModelParam[] modelParams;
        private int formIndex;
        private IndexSelector modelIndexSelector;

        public bool ExistForm { get => formIndex > 0; }
		public bool CanChangeModel { get => modelParams.Length > 1; }
		public bool CanShowDescription { get => GetStatus == GET_STATUS.SEE || GetStatus == GET_STATUS.GET; }
		private string DescriptionMessageFileName { get => PlayerWork.cassetVersion == CassetVersion.DPR_B ? "dp_pokedex_diamond" : "dp_pokedex_pearl"; }
		
		// TODO
		public ZukanInfo(MonsNo monsNo, bool isShinouZukan) { }
		
		// TODO
		public void SetFormNo(int formNo) { }
		
		// TODO
		public void Set(int formNo, Sex sex, bool isRare)
		{
			// TODO
            bool IsSex(ModelSexType modelSexType) { return default; }
        }
		
		// TODO
		public void SetupUITexts(UIText nameText, UIText classText, UIText heightText, UIText weightText, UIText descText, UIText formNameText) { }
		
		// TODO
		public ModelSexType GetCurrentModelSexType() { return default; }
		
		// TODO
		public bool IsRareCurrentModel() { return default; }
		
		// TODO
		public void MoveModelSelect(int value) { }
		
		// TODO
		public PokemonParam GetCurrentPokemonParam() { return default; }
		
		// TODO
		private void UpdateInfo() { }
		
		// TODO
		private PokemonInfo.SheetCatalog[] GetCatalogs(MonsNo monsNo, int formMax, bool isUnknownSex) { return default; }

		public enum ModelSexType : int
		{
			Male = 0,
			Female = 1,
			Unknown = 2,
			Both = 3,
		}

		internal class ModelParam
		{
			public int UniqueID;
			public ModelSexType SexType;
			public int FormNo;
			public bool IsRare;
			
			public ModelParam(PokemonInfo.SheetCatalog catalog)
			{
				UniqueID = catalog.UniqueID;
				SexType = (ModelSexType)catalog.Sex;
				FormNo = catalog.FormNo;
				IsRare = catalog.Rare;
			}
			
			public Sex GetSex()
			{
				if (SexType == ModelSexType.Both)
					return Sex.MALE;
				else
                    return (Sex)SexType;
			}
		}
	}
}