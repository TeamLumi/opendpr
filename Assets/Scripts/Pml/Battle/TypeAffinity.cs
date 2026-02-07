using Pml.PokePara;

namespace Pml.Battle
{
    public static class TypeAffinity
    {
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

        static TypeAffinity()
        {
            VALUE_TABLE = new uint[]
            {
                VALUE_0, VALUE_1_64, VALUE_1_32, VALUE_1_16, VALUE_1_8, VALUE_1_4, VALUE_1_2,
                VALUE_1, VALUE_2, VALUE_4, VALUE_8, VALUE_16, VALUE_32, VALUE_64
            };

            // Row = attacking type, Col = defending type
            // Order: NORMAL, KAKUTOU, HIKOU, DOKU, JIMEN, IWA, MUSHI, GHOST, HAGANE,
            //        HONOO, MIZU, KUSA, DENKI, ESPER, KOORI, DRAGON, AKU, FAIRY
            TYPE_AFF_TBL = new byte[][]
            {
                //                NOR  KAK  HIK  DOK  JIM  IWA  MUS  GHO  HAG  HON  MIZ  KUS  DEN  ESP  KOO  DRA  AKU  FAI
                new byte[] { x1,  x1,  x1,  x1,  x1, xH,  x1,  x0, xH,  x1,  x1,  x1,  x1,  x1,  x1,  x1,  x1,  x1 }, // NORMAL
                new byte[] { x2,  x1, xH,  xH,  x1,  x2, xH,  x0,  x2,  x1,  x1,  x1,  x1, xH,  x2,  x1,  x2, xH  }, // KAKUTOU
                new byte[] { x1,  x2,  x1,  x1,  x1, xH,  x2,  x1, xH,  x1,  x1,  x2, xH,  x1,  x1,  x1,  x1,  x1 }, // HIKOU
                new byte[] { x1,  x1,  x1, xH, xH, xH,  x1, xH,  x0,  x1,  x1,  x2,  x1,  x1,  x1,  x1,  x1,  x2 }, // DOKU
                new byte[] { x1,  x1,  x0,  x2,  x1,  x2, xH,  x1,  x2,  x2,  x1, xH,  x2,  x1,  x1,  x1,  x1,  x1 }, // JIMEN
                new byte[] { x1, xH,  x2,  x1, xH,  x1,  x2,  x1, xH,  x2,  x1,  x1,  x1,  x1,  x2,  x1,  x1,  x1 }, // IWA
                new byte[] { x1, xH, xH, xH,  x1,  x1,  x1, xH, xH, xH,  x1,  x2,  x1,  x2,  x1,  x1,  x2, xH  }, // MUSHI
                new byte[] { x0,  x1,  x1,  x1,  x1,  x1,  x1,  x2,  x1,  x1,  x1,  x1,  x1,  x2,  x1,  x1, xH,  x1 }, // GHOST
                new byte[] { x1,  x1,  x1,  x1,  x1,  x2,  x1,  x1, xH, xH, xH,  x1, xH,  x1,  x2,  x1,  x1,  x2 }, // HAGANE
                new byte[] { x1,  x1,  x1,  x1,  x1, xH,  x2,  x1,  x2, xH, xH,  x2,  x1,  x1,  x2, xH,  x1,  x1 }, // HONOO
                new byte[] { x1,  x1,  x1,  x1,  x2,  x2,  x1,  x1,  x1,  x2, xH, xH,  x1,  x1,  x1, xH,  x1,  x1 }, // MIZU
                new byte[] { x1,  x1, xH, xH,  x2,  x2, xH,  x1, xH, xH,  x2, xH,  x1,  x1,  x1, xH,  x1,  x1 }, // KUSA
                new byte[] { x1,  x1,  x2,  x1,  x0,  x1,  x1,  x1,  x1,  x1,  x2, xH, xH,  x1,  x1, xH,  x1,  x1 }, // DENKI
                new byte[] { x1,  x2,  x1,  x2,  x1,  x1,  x1,  x1, xH,  x1,  x1,  x1,  x1, xH,  x1,  x1,  x0,  x1 }, // ESPER
                new byte[] { x1,  x1,  x2,  x1,  x2,  x1,  x1,  x1, xH, xH, xH,  x2,  x1,  x1, xH,  x2,  x1,  x1 }, // KOORI
                new byte[] { x1,  x1,  x1,  x1,  x1,  x1,  x1,  x1, xH,  x1,  x1,  x1,  x1,  x1,  x1,  x2,  x1,  x0 }, // DRAGON
                new byte[] { x1, xH,  x1,  x1,  x1,  x1,  x1,  x2,  x1,  x1,  x1,  x1,  x1,  x2,  x1,  x1, xH, xH  }, // AKU
                new byte[] { x1,  x2,  x1, xH,  x1,  x1,  x1,  x1, xH, xH,  x1,  x1,  x1,  x1,  x1,  x2,  x2,  x1 }, // FAIRY
            };
        }

        private static uint calcLSB(uint value)
        {
            if (value == 0)
            {
                return 0;
            }
            uint n = 0;
            while ((value & 1) == 0)
            {
                value >>= 1;
                n++;
            }
            return n;
        }

        public static AffinityID CalcAffinity(PokeType wazaType, PokeType pokeType, bool isSakasaBattle)
        {
            if (wazaType >= PokeType.MAX || pokeType >= PokeType.MAX)
            {
                return AffinityID.TYPEAFF_1;
            }
            byte aff = TYPE_AFF_TBL[(int)wazaType][(int)pokeType];
            if (isSakasaBattle)
            {
                switch (aff)
                {
                    case x0:
                        return AffinityID.TYPEAFF_0;
                    case xH:
                        return AffinityID.TYPEAFF_2;
                    case x2:
                        return AffinityID.TYPEAFF_1_2;
                    default:
                        return AffinityID.TYPEAFF_1;
                }
            }
            else
            {
                switch (aff)
                {
                    case x0:
                        return AffinityID.TYPEAFF_0;
                    case xH:
                        return AffinityID.TYPEAFF_1_2;
                    case x2:
                        return AffinityID.TYPEAFF_2;
                    default:
                        return AffinityID.TYPEAFF_1;
                }
            }
        }

        public static AffinityID CalcAffinity(PokeType wazaType, PokeType pokeType1, PokeType pokeType2, bool isSakasaBattle)
        {
            AffinityID aff1 = CalcAffinity(wazaType, pokeType1, isSakasaBattle);
            if (pokeType1 == pokeType2)
            {
                return aff1;
            }
            AffinityID aff2 = CalcAffinity(wazaType, pokeType2, isSakasaBattle);
            return MulAffinity(aff1, aff2);
        }

        public static AffinityID CalcAffinity(PokeType wazaType, PokemonParam pokeParam, bool isSakasaBattle)
        {
            return CalcAffinity(wazaType, pokeParam.GetType1(), pokeParam.GetType2(), isSakasaBattle);
        }

        public static AffinityID MulAffinity(AffinityID aff1, AffinityID aff2)
        {
            if (aff1 == AffinityID.TYPEAFF_0 || aff2 == AffinityID.TYPEAFF_0)
            {
                return AffinityID.TYPEAFF_0;
            }
            uint val = VALUE_TABLE[(int)aff1] * VALUE_TABLE[(int)aff2];
            uint lsb = calcLSB(val);
            if (lsb >= (uint)AffinityID.TYPEAFF_MAX)
            {
                lsb = (uint)AffinityID.TYPEAFF_MAX - 1;
            }
            return (AffinityID)lsb;
        }

        public static AboutAffinityID ConvAboutAffinity(AffinityID aff)
        {
            if (aff == AffinityID.TYPEAFF_0)
            {
                return AboutAffinityID.NONE;
            }
            if (aff < AffinityID.TYPEAFF_1)
            {
                return AboutAffinityID.DISADVANTAGE;
            }
            if (aff > AffinityID.TYPEAFF_1)
            {
                return AboutAffinityID.ADVANTAGE;
            }
            return AboutAffinityID.NORMAL;
        }

        public static AboutAffinityID TCalcAffinityAbout(PokeType wazaType, PokeType pokeType, bool isSakasaBattle)
        {
            AffinityID aff = CalcAffinity(wazaType, pokeType, isSakasaBattle);
            return ConvAboutAffinity(aff);
        }

        public static AboutAffinityID CalcAffinityAbout(PokeType wazaType, PokeType pokeType1, PokeType pokeType2, bool isSakasaBattle)
        {
            AffinityID aff = CalcAffinity(wazaType, pokeType1, pokeType2, isSakasaBattle);
            return ConvAboutAffinity(aff);
        }

        public static AboutAffinityID CalcAffinityAbout(PokeType wazaType, PokemonParam pokeParam, bool isSakasaBattle)
        {
            AffinityID aff = CalcAffinity(wazaType, pokeParam, isSakasaBattle);
            return ConvAboutAffinity(aff);
        }

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
