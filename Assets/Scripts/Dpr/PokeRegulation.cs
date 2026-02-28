using Pml;
using Pml.PokePara;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Dpr
{
	public static class PokeRegulation
	{
        private static readonly MonsNo[] legend_monsno = new MonsNo[]
		{
            MonsNo.MYUUTUU,   MonsNo.MYUU,      MonsNo.RUGIA,    MonsNo.HOUOU,
			MonsNo.SEREBHI,   MonsNo.KAIOOGA,   MonsNo.GURAADON, MonsNo.REKKUUZA,
			MonsNo.ZIRAATI,   MonsNo.DEOKISISU, MonsNo.DHIARUGA, MonsNo.PARUKIA,
			MonsNo.GIRATHINA, MonsNo.FIONE,     MonsNo.MANAFI,   MonsNo.DAAKURAI,
			MonsNo.SHEIMI,    MonsNo.ARUSEUSU,
		};
        private static readonly MonsNo[] sub_legend_monsno = new MonsNo[]
        {
			MonsNo.HURIIZAA,   MonsNo.SANDAA,   MonsNo.FAIYAA,    MonsNo.RAIKOU,
			MonsNo.ENTEI,      MonsNo.SUIKUN,   MonsNo.REZIROKKU, MonsNo.REZIAISU,
			MonsNo.REZISUTIRU, MonsNo.RATHIASU, MonsNo.RATHIOSU,  MonsNo.YUKUSII,
			MonsNo.EMURITTO,   MonsNo.AGUNOMU,  MonsNo.HIIDORAN,  MonsNo.REZIGIGASU,
			MonsNo.KURESERIA,
        };

        // TODO
        public static bool CheckLegend(MonsNo monsno, byte formno = 0) { return default; }
		
		// TODO
		public static bool CheckSubLegend(MonsNo monsno) { return default; }
		
		// TODO
		public static void ModifyLevelPokeParty(PokeParty iPtrPokeParty, Regulation.LevelRangeType levelRangeType, uint modify_level = 50) { }
		
		// TODO
		public static void ModifyLevelPokeParam(PokemonParam pp, Regulation.LevelRangeType levelRangeType, uint modify_level = 50) { }
		
		// TODO
		private static void MakeLevelRevise(PokemonParam iPtrPokePara, int level) { }
		
		private static uint ModifyLevelCalc(Regulation.LevelRangeType levelRangeType, uint level, uint modify_level = 50)
		{
			if (((int)levelRangeType != 0) && ((levelRangeType != '\x01' || (level <= modify_level)))) {
			  modify_level = level;
			}
			return modify_level;
		}
		
		// TODO
		public static bool CheckBothPoke(PokeParty iPtrPokeParty, [Optional] List<MonsNo> bothPoke) { return default; }
		
		// TODO
		public static bool CheckBothItem(PokeParty iPtrPokeParty, [Optional] List<ItemNo> bothItem) { return default; }
	}
}