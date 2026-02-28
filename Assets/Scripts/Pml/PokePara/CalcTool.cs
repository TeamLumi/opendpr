namespace Pml.PokePara
{
    public static class CalcTool
    {
        private const ushort MIN_HP = 10;
        private const ushort HP_BASE_COEFFICIENT = 2;
        private const ushort HP_EXP_COEFFICIENT = 4;
        private const ushort MIN_ATK = 5;
        private const ushort ATK_BASE_COEFFICIENT = 2;
        private const ushort ATK_EXP_COEFFICIENT = 4;
        private const ushort MIN_DEF = 5;
        private const ushort DEF_BASE_COEFFICIENT = 2;
        private const ushort DEF_EXP_COEFFICIENT = 4;
        private const ushort MIN_SPATK = 5;
        private const ushort SPATK_BASE_COEFFICIENT = 2;
        private const ushort SPATK_EXP_COEFFICIENT = 4;
        private const ushort MIN_SPDEF = 5;
        private const ushort SPDEF_BASE_COEFFICIENT = 2;
        private const ushort SPDEF_EXP_COEFFICIENT = 4;
        private const ushort MIN_AGI = 5;
        private const ushort AGI_BASE_COEFFICIENT = 2;
        private const ushort AGI_EXP_COEFFICIENT = 4;
        private const byte NUKENIN_MAX_HP = 1;
        private const byte MAX_POKE_LEVEL = 100;
        private const int VERSION_HOLOHOLO = 34;
        private static sbyte[][] SEIKAKU_ABI_TBL = // The 0s are not explicitely defined in the code but I couldn't figure out a way to do it like that
        {
            new sbyte[5] { 0,  0,  0,  0,  0,  }, // 0
            new sbyte[5] { 1,  -1, 0,  0,  0,  }, // 1
            new sbyte[5] { 1,  0,  0,  0,  -1, }, // 2
            new sbyte[5] { 1,  0,  -1, 0,  0,  }, // 3
            new sbyte[5] { 1,  0,  0,  -1, 0,  }, // 4
            new sbyte[5] { -1, 1,  0,  0,  0,  }, // 5
            new sbyte[5] { 0,  0,  0,  0,  0,  }, // 6
            new sbyte[5] { 0,  1,  0,  0,  -1, }, // 7
            new sbyte[5] { 0,  1,  -1, 0,  0,  }, // 8
            new sbyte[5] { 0,  1,  0,  -1, 0,  }, // 9
            new sbyte[5] { -1, 0,  0,  0,  1,  }, // 10
            new sbyte[5] { 0,  -1, 0,  0,  1,  }, // 11
            new sbyte[5] { 0,  0,  0,  0,  0,  }, // 12
            new sbyte[5] { 0,  0,  -1, 0,  1,  }, // 13
            new sbyte[5] { 0,  0,  0,  -1, 1,  }, // 14
            new sbyte[5] { -1, 0,  1,  0,  0,  }, // 15
            new sbyte[5] { 0,  -1, 1,  0,  0,  }, // 16
            new sbyte[5] { 0,  0,  1,  0,  -1, }, // 17
            new sbyte[5] { 0,  0,  0,  0,  0,  }, // 18
            new sbyte[5] { 0,  0,  1,  -1, 0,  }, // 19
            new sbyte[5] { -1, 0,  0,  1,  0,  }, // 20
            new sbyte[5] { 0,  -1, 0,  1,  0,  }, // 21
            new sbyte[5] { 0,  0,  0,  1,  -1, }, // 22
            new sbyte[5] { 0,  0,  -1, 1,  0,  }, // 23
            new sbyte[5] { 0,  0,  0,  0,  0,  }, // 24
        };
        private static Seikaku[] HIGH_SEIKAKU = new Seikaku[13]
        {
            Seikaku.IJIPPARI, Seikaku.YANTYA,   Seikaku.YUUKAN,    Seikaku.WANPAKU,
            Seikaku.NOUTENKI, Seikaku.UKKARIYA, Seikaku.NAMAIKI,   Seikaku.SEKKATI,
            Seikaku.YOUKI,    Seikaku.MUJYAKI,  Seikaku.GANBARIYA, Seikaku.SUNAO,
            Seikaku.KIMAGURE,
        };
        private static Seikaku[] LOW_SEIKAKU = new Seikaku[12]
        {
            Seikaku.SAMISHIGARI, Seikaku.ZUBUTOI, Seikaku.NONKI,     Seikaku.OKUBYOU,
            Seikaku.MAJIME,      Seikaku.HIKAEME, Seikaku.OTTORI,    Seikaku.REISEI,
            Seikaku.TEREYA,      Seikaku.ODAYAKA, Seikaku.OTONASHII, Seikaku.SINTYOU,
        };
        private static PokeType[] TYPE_TABLE = new PokeType[16]
        {
            PokeType.KAKUTOU, PokeType.HIKOU, PokeType.DOKU,   PokeType.JIMEN,
            PokeType.IWA,     PokeType.MUSHI, PokeType.GHOST,  PokeType.HAGANE,
            PokeType.HONOO,   PokeType.MIZU,  PokeType.KUSA,   PokeType.DENKI,
            PokeType.ESPER,   PokeType.KOORI, PokeType.DRAGON, PokeType.AKU,
        };
        public static TasteJudge[,] DESIRED_TASTE_TBL = new TasteJudge[(int)Seikaku.NUM, (int)Taste.MAX]
        {
            { TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  },
            { TasteJudge.LIKE,    TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.DISLIKE, },
            { TasteJudge.LIKE,    TasteJudge.NORMAL,  TasteJudge.DISLIKE, TasteJudge.NORMAL,  TasteJudge.NORMAL,  },
            { TasteJudge.LIKE,    TasteJudge.DISLIKE, TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  },
            { TasteJudge.LIKE,    TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.DISLIKE, TasteJudge.NORMAL,  },
            { TasteJudge.DISLIKE, TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.LIKE,    },
            { TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  },
            { TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.DISLIKE, TasteJudge.NORMAL,  TasteJudge.LIKE,    },
            { TasteJudge.NORMAL,  TasteJudge.DISLIKE, TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.LIKE,    },
            { TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.DISLIKE, TasteJudge.LIKE,    },
            { TasteJudge.DISLIKE, TasteJudge.NORMAL,  TasteJudge.LIKE,    TasteJudge.NORMAL,  TasteJudge.NORMAL,  },
            { TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.LIKE,    TasteJudge.NORMAL,  TasteJudge.DISLIKE, },
            { TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  },
            { TasteJudge.NORMAL,  TasteJudge.DISLIKE, TasteJudge.LIKE,    TasteJudge.NORMAL,  TasteJudge.NORMAL,  },
            { TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.LIKE,    TasteJudge.DISLIKE, TasteJudge.NORMAL,  },
            { TasteJudge.DISLIKE, TasteJudge.LIKE,    TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  },
            { TasteJudge.NORMAL,  TasteJudge.LIKE,    TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.DISLIKE, },
            { TasteJudge.NORMAL,  TasteJudge.LIKE,    TasteJudge.DISLIKE, TasteJudge.NORMAL,  TasteJudge.NORMAL,  },
            { TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  },
            { TasteJudge.NORMAL,  TasteJudge.LIKE,    TasteJudge.NORMAL,  TasteJudge.DISLIKE, TasteJudge.NORMAL,  },
            { TasteJudge.DISLIKE, TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.LIKE,    TasteJudge.NORMAL,  },
            { TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.LIKE,    TasteJudge.DISLIKE, },
            { TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.DISLIKE, TasteJudge.LIKE,    TasteJudge.NORMAL,  },
            { TasteJudge.NORMAL,  TasteJudge.DISLIKE, TasteJudge.NORMAL,  TasteJudge.LIKE,    TasteJudge.NORMAL,  },
            { TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  TasteJudge.NORMAL,  },
        };
        private static WazaNo[] ROTOM_WAZA_TBL = new WazaNo[6]
        {
            WazaNo.NULL, WazaNo.OOBAAHIITO, WazaNo.HAIDOROPONPU, WazaNo.HUBUKI, WazaNo.EASURASSYU, WazaNo.RIIHUSUTOOMU,
        };
        private static ITEM_TYPE_PARAM[] ITEM_TYPE_ARUSEUSU = new ITEM_TYPE_PARAM[17]
        {
            new ITEM_TYPE_PARAM(ItemNo.HINOTAMAPUREETO, PokeType.HONOO),
            new ITEM_TYPE_PARAM(ItemNo.SIZUKUPUREETO,   PokeType.MIZU),
            new ITEM_TYPE_PARAM(ItemNo.IKAZUTIPUREETO,  PokeType.DENKI),
            new ITEM_TYPE_PARAM(ItemNo.MIDORINOPUREETO, PokeType.KUSA),
            new ITEM_TYPE_PARAM(ItemNo.TURARANOPUREETO, PokeType.KOORI),
            new ITEM_TYPE_PARAM(ItemNo.KOBUSINOPUREETO, PokeType.KAKUTOU),
            new ITEM_TYPE_PARAM(ItemNo.MOUDOKUPUREETO,  PokeType.DOKU),
            new ITEM_TYPE_PARAM(ItemNo.DAITINOPUREETO,  PokeType.JIMEN),
            new ITEM_TYPE_PARAM(ItemNo.AOZORAPUREETO,   PokeType.HIKOU),
            new ITEM_TYPE_PARAM(ItemNo.HUSIGINOPUREETO, PokeType.ESPER),
            new ITEM_TYPE_PARAM(ItemNo.TAMAMUSIPUREETO, PokeType.MUSHI),
            new ITEM_TYPE_PARAM(ItemNo.GANSEKIPUREETO,  PokeType.IWA),
            new ITEM_TYPE_PARAM(ItemNo.MONONOKEPUREETO, PokeType.GHOST),
            new ITEM_TYPE_PARAM(ItemNo.RYUUNOPUREETO,   PokeType.DRAGON),
            new ITEM_TYPE_PARAM(ItemNo.KOWAMOTEPUREETO, PokeType.AKU),
            new ITEM_TYPE_PARAM(ItemNo.KOUTETUPUREETO,  PokeType.HAGANE),
            new ITEM_TYPE_PARAM(ItemNo.SEIREIPUREETO,   PokeType.FAIRY),
        };
        private static ITEM_TYPE_PARAM[] ITEM_TYPE_Guripusu2 = new ITEM_TYPE_PARAM[17]
        {
            new ITEM_TYPE_PARAM(ItemNo.FAIYAAMEMORI,    PokeType.HONOO),
            new ITEM_TYPE_PARAM(ItemNo.UOOTAAMEMORI,    PokeType.MIZU),
            new ITEM_TYPE_PARAM(ItemNo.EREKUTOROMEMORI, PokeType.DENKI),
            new ITEM_TYPE_PARAM(ItemNo.GURASUMEMORI,    PokeType.KUSA),
            new ITEM_TYPE_PARAM(ItemNo.AISUMEMORI,      PokeType.KOORI),
            new ITEM_TYPE_PARAM(ItemNo.FAITOMEMORI,     PokeType.KAKUTOU),
            new ITEM_TYPE_PARAM(ItemNo.POIZUNMEMORI,    PokeType.DOKU),
            new ITEM_TYPE_PARAM(ItemNo.GURAUNDOMEMORI,  PokeType.JIMEN),
            new ITEM_TYPE_PARAM(ItemNo.HURAINGUMEMORI,  PokeType.HIKOU),
            new ITEM_TYPE_PARAM(ItemNo.SAIKIKKUMEMORI,  PokeType.ESPER),
            new ITEM_TYPE_PARAM(ItemNo.BAGUMEMORI,      PokeType.MUSHI),
            new ITEM_TYPE_PARAM(ItemNo.ROKKUMEMORI,     PokeType.IWA),
            new ITEM_TYPE_PARAM(ItemNo.GOOSUTOMEMORI,   PokeType.GHOST),
            new ITEM_TYPE_PARAM(ItemNo.DORAGONMEMORI,   PokeType.DRAGON),
            new ITEM_TYPE_PARAM(ItemNo.DAAKUMEMORI,     PokeType.AKU),
            new ITEM_TYPE_PARAM(ItemNo.SUTIIRUMEMORI,   PokeType.HAGANE),
            new ITEM_TYPE_PARAM(ItemNo.FEARIIMEMORI,    PokeType.FAIRY),
        };
        private static ITEM_VIEW_PARAM[] CREAM2_ITEM_TABLE = new ITEM_VIEW_PARAM[(int)Cream2ViewID.NUM]
        {
            new ITEM_VIEW_PARAM(ItemNo.ITIGONOAMEZAIKU,  Cream2ViewID.STRAWBERRY),
            new ITEM_VIEW_PARAM(ItemNo.HAATONOHAMEZAIKU, Cream2ViewID.HEART),
            new ITEM_VIEW_PARAM(ItemNo.BERIIAMEZAIKU,    Cream2ViewID.BERRY),
            new ITEM_VIEW_PARAM(ItemNo.YOTUBAAMEZAIKU,   Cream2ViewID.CLOVER),
            new ITEM_VIEW_PARAM(ItemNo.OHANAAMEZAIKU,    Cream2ViewID.FLOWER),
            new ITEM_VIEW_PARAM(ItemNo.SUTAAAMEZAIKU,    Cream2ViewID.STAR),
            new ITEM_VIEW_PARAM(ItemNo.RIBONAMEZAIKU,    Cream2ViewID.RIBBON),
        };

        // TODO
        public static byte CalcLevel(MonsNo monsno, ushort formno, uint exp) { return 0; }

        public static ushort CalcMaxHp(MonsNo monsno, byte level, ushort basev, ushort rnd, ushort exp)
        {
            if (monsno == MonsNo.NUKENIN)
                return 1;

            return (ushort)((short)((basev * 2u + rnd + exp / 4u * level) / 100u) + (ushort)level + 10u);
        }

        public static ushort CalcAtk(byte level, ushort basev, ushort rnd, ushort exp, Seikaku seikaku)
        {
            var calcv = (ushort)((short)((basev * 2u + rnd + exp / 4u * level) / 100u) + 5u);
            return CalcCorrectedPowerBySeikaku(calcv, (ushort)seikaku, PowerID.ATK);
        }

        public static ushort CalcDef(byte level, ushort basev, ushort rnd, ushort exp, Seikaku seikaku)
        {
            var calcv = (ushort)((short)((basev * 2u + rnd + exp / 4u * level) / 100u) + 5u);
            return CalcCorrectedPowerBySeikaku(calcv, (ushort)seikaku, PowerID.DEF);
        }

        public static ushort CalcSpAtk(byte level, ushort basev, ushort rnd, ushort exp, Seikaku seikaku)
        {
            var calcv = (ushort)((short)((basev * 2u + rnd + exp / 4u * level) / 100u) + 5u);
            return CalcCorrectedPowerBySeikaku(calcv, (ushort)seikaku, PowerID.SPATK);
        }

        public static ushort CalcSpDef(byte level, ushort basev, ushort rnd, ushort exp, Seikaku seikaku)
        {
            var calcv = (ushort)((short)((basev * 2u + rnd + exp / 4u * level) / 100u) + 5u);
            return CalcCorrectedPowerBySeikaku(calcv, (ushort)seikaku, PowerID.SPDEF);
        }

        public static ushort CalcAgi(byte level, ushort basev, ushort rnd, ushort exp, Seikaku seikaku)
        {
            var calcv = (ushort)((short)((basev * 2u + rnd + exp / 4u * level) / 100u) + 5u);
            return CalcCorrectedPowerBySeikaku(calcv, (ushort)seikaku, PowerID.AGI);
        }

        public static sbyte GetPowerTransformBySeikaku(ushort seikaku, PowerID powerId)
        {
            switch (powerId)
            {
                case PowerID.ATK:
                case PowerID.DEF:
                case PowerID.SPATK:
                case PowerID.SPDEF:
                case PowerID.AGI:
                    return SEIKAKU_ABI_TBL[seikaku][((uint)powerId) - 1];

                default:
                    return 0;
            }
        }

        private static ushort CalcCorrectedPowerBySeikaku(ushort value, ushort seikaku, PowerID powerId)
        {
            var transform = GetPowerTransformBySeikaku(seikaku, powerId);
            switch (transform)
            {
                case -1:
                    return (ushort)(((value * 90u) & 0xFFFE) / 100UL);

                case 1:
                    return (ushort)(((value * 110u) & 0xFFFE) / 100UL);

                default:
                    return value;
            }
        }

        public static bool IsRareColor(uint id, uint rnd)
        {
            return ((id & 0xFFF0) ^ (id >> 0x10) ^ (rnd >> 0x10) ^ (rnd & 0xFFF0)) < 0x10;
        }

        private static uint CalcRareCheckValue(uint id, uint rnd)
        {
            return (id & 0xFFFF) ^ (id >> 0x10) ^ (rnd >> 0x10) ^ (rnd & 0xFFFF);
        }

        // TODO
        public static uint CorrectColorRndForNormal(uint id, uint rnd) { return 0; }

        // TODO
        public static uint CorrectColorRndForRare(uint id, uint rnd) { return 0; }

        // TODO
        public static RareType CalcRareColorType(uint id, uint rnd, uint cassetVersion, bool isEventGetPoke) { return RareType.NOT_RARE; }

        public static RareType CalcRareColorTypeByID(uint id, uint rnd)
        {
            if (!IsRareColor(id, rnd))
                return RareType.NOT_RARE;
            else if (((id & 0xFFFF) ^ (id >> 0x10) ^ (rnd >> 0x10)) == (rnd & 0xFFFF))
                return RareType.DISTRIBUTED;
            else
                return RareType.CAPTURED;
        }

        // TODO
        public static uint CorrectColorRndForRareType(uint id, uint rnd, RareType type) { return 0; }

        // TODO
        public static Sex GetCorrectSexInPersonalData(MonsNo monsno, ushort formno, Sex bothCase) { return Sex.MALE; }

        // TODO
        public static bool IsSeikakuHigh(Seikaku seikaku) { return false; }

        // TODO
        public static bool IsSeikakuLow(Seikaku seikaku) { return false; }

        // TODO
        public static Seikaku[] GetSeikakuHigh(out byte pNum)
        {
            pNum = 0;
            return null;
        }

        // TODO
        public static Seikaku[] GetSeikakuLow(out byte pNum)
        {
            pNum = 0;
            return null;
        }

        // TODO
        public static ushort GetTokuseiNo(MonsNo monsno, ushort formno, byte tokuseiIndex) { return 0; }

        // TODO
        public static PokeType CalcMezamerupawaaType(byte hp, byte atk, byte def, byte agi, byte spatk, byte spdef) { return PokeType.NORMAL; }

        public static uint CalcMezamerupawaaPower(byte hp, byte atk, byte def, byte agi, byte spatk, byte spdef)
        {
        	return ((atk & 2 | hp >> 1 & 1 | (def >> 1 & 1) << 2 | (agi >> 1 & 1) << 3 |
        	         (spatk >> 1 & 1) << 4 | (spdef >> 1 & 1) << 5) * 0x28) / 0x3f + 0x1e;
        	return 0;
        }

        // TODO
        public static TasteJudge JudgeTaste(Seikaku seikaku, Taste taste) { return TasteJudge.NORMAL; }

        // TODO
        public static bool CanCreateEgg(MonsNo monsno1, Sex sex1, uint eggGroup1_1, uint eggGroup1_2, MonsNo monsno2, Sex sex2, uint eggGroup2_1, uint eggGroup2_2) { return false; }

        public static LoveLevel CalcLoveLevel(MonsNo monsno1, uint id1, MonsNo monsno2, uint id2)
        {
        	if (monsno1 == monsno2) {
        	  return id1 == id2;
        	}
        	var uVar1 = 1;
        	if (id1 == id2) {
        	  uVar1 = 2;
        	}
        	return (bool)uVar1;
        }

        // TODO
        public static WazaNo GetRotomuWazaNo(ushort formno) { return WazaNo.NULL; }

        // TODO
        public static PokeType GetAruseusuType(uint itemno) { return PokeType.NORMAL; }

        // TODO
        public static PokeType GetGuripusu2Type(uint itemno) { return PokeType.NORMAL; }

        // TODO
        public static bool IsAmezaikuForCream2Evolution(uint itemno) { return false; }

        // TODO
        public static Cream2ViewID GetCream2ViewID(uint itemno) { return Cream2ViewID.STRAWBERRY; }

        // TODO
        public static bool DecideFormNoFromHoldItem(MonsNo monsno, uint holdItemno, out ushort formno)
        {
            formno = 0;
            return false;
        }

        private struct ITEM_TYPE_PARAM
        {
            public ItemNo item;
            public PokeType type;

            public ITEM_TYPE_PARAM(ItemNo _item, PokeType _type)
            {
                item = _item;
                type = _type;
            }
        }

        private struct ITEM_VIEW_PARAM
        {
            public ItemNo item;
            public Cream2ViewID viewID;

            public ITEM_VIEW_PARAM(ItemNo _item, Cream2ViewID _view)
            {
                item = _item;
                viewID = _view;
            }
        }
    }
}