using Pml.PokePara;

namespace Pml.Battle
{
    public static class TypeAffinity
    {
        // TODO: cctor

        private const byte x0 = 0;
        private const byte xH = 2;
        private const byte x1 = 4;
        private const byte x2 = 8;
        internal static readonly byte[][] TYPE_AFF_TBL;
        private const uint VALUE_0 = 0;
        private const uint VALUE_1_64 = 1;
        private const uint VALUE_1_32 = 2;
        private const uint VALUE_1_16 = 4;
        private const uint VALUE_1_8 = 8;
        private const uint VALUE_1_4 = 16;
        private const uint VALUE_1_2 = 32;
        private const uint VALUE_1 = 64;
        private const uint VALUE_2 = 128;
        private const uint VALUE_4 = 256;
        private const uint VALUE_8 = 512;
        private const uint VALUE_16 = 1024;
        private const uint VALUE_32 = 2048;
        private const uint VALUE_64 = 4096;
        private static readonly uint[] VALUE_TABLE;

        private static uint calcLSB(uint value)
        {
        	uint uVar1;
        	var uVar2 = 0;
        	do {
        	  if (uVar2 == 0x20) {
        	    return 0;
        	  }
        	  uVar1 = uVar2 & 0x1f;
        	  uVar2 = uVar2 + 1;
        	} while ((1 << (int)uVar1 & value) == 0);
        	return uVar2;
        }

        // TODO
        public static AffinityID CalcAffinity(PokeType wazaType, PokeType pokeType, bool isSakasaBattle) { return AffinityID.TYPEAFF_0; }

        // TODO
        public static AffinityID CalcAffinity(PokeType wazaType, PokeType pokeType1, PokeType pokeType2, bool isSakasaBattle) { return AffinityID.TYPEAFF_0; }

        // TODO
        public static AffinityID CalcAffinity(PokeType wazaType, PokemonParam pokeParam, bool isSakasaBattle) { return AffinityID.TYPEAFF_0; }

        // TODO
        public static AffinityID MulAffinity(AffinityID aff1, AffinityID aff2) { return AffinityID.TYPEAFF_0; }

        public static AboutAffinityID ConvAboutAffinity(AffinityID aff)
        {
        	if (7 < (int)aff) {
        	  return (AboutAffinityID)2;
        	}
        	if ((int)aff == 7) {
        	  return (AboutAffinityID)1;
        	}
        	var uVar1 = 0;
        	if ((int)aff != 0) {
        	  uVar1 = 3;
        	}
        	return uVar1;
        }

        // TODO
        public static AboutAffinityID TCalcAffinityAbout(PokeType wazaType, PokeType pokeType, bool isSakasaBattle) { return AboutAffinityID.NONE; }

        // TODO
        public static AboutAffinityID CalcAffinityAbout(PokeType wazaType, PokeType pokeType1, PokeType pokeType2, bool isSakasaBattle) { return AboutAffinityID.NONE; }

        // TODO
        public static AboutAffinityID CalcAffinityAbout(PokeType wazaType, PokemonParam pokeParam, bool isSakasaBattle) { return AboutAffinityID.NONE; }

        public enum AffinityID : int
        {
            TYPEAFF_0 = 0,
            TYPEAFF_1_64 = 1,
            TYPEAFF_1_32 = 2,
            TYPEAFF_1_16 = 3,
            TYPEAFF_1_8 = 4,
            TYPEAFF_1_4 = 5,
            TYPEAFF_1_2 = 6,
            TYPEAFF_1 = 7,
            TYPEAFF_2 = 8,
            TYPEAFF_4 = 9,
            TYPEAFF_8 = 10,
            TYPEAFF_16 = 11,
            TYPEAFF_32 = 12,
            TYPEAFF_64 = 13,
            TYPEAFF_MAX = 14,
            TYPEAFF_NULL = 14,
        }

        public enum AboutAffinityID : int
        {
            NONE = 0,
            NORMAL = 1,
            ADVANTAGE = 2,
            DISADVANTAGE = 3,
        }
    }
}