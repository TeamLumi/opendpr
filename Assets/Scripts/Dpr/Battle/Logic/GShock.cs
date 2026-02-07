using Pml;

namespace Dpr.Battle.Logic
{
	public static class GShock
	{
		private static readonly GSHOCK_EFFECT_TABLE_ELEM[] GSHOCK_EFFECT_TABLE = new GSHOCK_EFFECT_TABLE_ELEM[]
		{
			new GSHOCK_EFFECT_TABLE_ELEM(WazaNo.DAIATAKKU,    Effect.RANKDOWN_AGI),
			new GSHOCK_EFFECT_TABLE_ELEM(WazaNo.DAIBAAN,      Effect.WEATHER_SHINE),
			new GSHOCK_EFFECT_TABLE_ELEM(WazaNo.DAISUTORIIMU, Effect.WEATHER_RAIN),
			new GSHOCK_EFFECT_TABLE_ELEM(WazaNo.DAISANDAA,    Effect.FIELD_ELEC),
			new GSHOCK_EFFECT_TABLE_ELEM(WazaNo.DAISOUGEN,    Effect.FIELD_GRASS),
			new GSHOCK_EFFECT_TABLE_ELEM(WazaNo.DAIAISU,      Effect.WEATHER_SNOW),
			new GSHOCK_EFFECT_TABLE_ELEM(WazaNo.DAINAKKURU,   Effect.RANKUP_ATK),
			new GSHOCK_EFFECT_TABLE_ELEM(WazaNo.DAIASIDDO,    Effect.RANKUP_SPATK),
			new GSHOCK_EFFECT_TABLE_ELEM(WazaNo.DAIAASU,      Effect.RANKUP_SPDEF),
			new GSHOCK_EFFECT_TABLE_ELEM(WazaNo.DAIJETTO,     Effect.RANKUP_AGI),
			new GSHOCK_EFFECT_TABLE_ELEM(WazaNo.DAISAIKO,     Effect.FIELD_PSYCO),
			new GSHOCK_EFFECT_TABLE_ELEM(WazaNo.DAIWAAMU,     Effect.RANKDOWN_SPATK),
			new GSHOCK_EFFECT_TABLE_ELEM(WazaNo.DAIROKKU,     Effect.WEATHER_SAND),
			new GSHOCK_EFFECT_TABLE_ELEM(WazaNo.DAIHOROU,     Effect.RANKDOWN_DEF),
			new GSHOCK_EFFECT_TABLE_ELEM(WazaNo.DAIDORAGUUN,  Effect.RANKDOWN_ATK),
			new GSHOCK_EFFECT_TABLE_ELEM(WazaNo.DAIAAKU,      Effect.RANKDOWN_SPDEF),
			new GSHOCK_EFFECT_TABLE_ELEM(WazaNo.DAISUTIRU,    Effect.RANKUP_DEF),
			new GSHOCK_EFFECT_TABLE_ELEM(WazaNo.DAIFEARII,    Effect.FIELD_MIST),
		};
		private static readonly GSHOCK_EFFECT_TABLE_SP_ELEM[] GSHOCK_EFFECT_TABLE_SP = new GSHOCK_EFFECT_TABLE_SP_ELEM[]
		{
			new GSHOCK_EFFECT_TABLE_SP_ELEM(MonsNo.RIZAADON,  0, (byte)PokeType.HONOO,   Effect.SIDE_HONOO,            0),
			new GSHOCK_EFFECT_TABLE_SP_ELEM(MonsNo.BATAHURII, 0, (byte)PokeType.MUSHI,   Effect.SICK_DOKU_MAHI_NEMURI, 1),
			new GSHOCK_EFFECT_TABLE_SP_ELEM(MonsNo.PIKATYUU,  0, (byte)PokeType.DENKI,   Effect.SICK_MAHI,             2),
			new GSHOCK_EFFECT_TABLE_SP_ELEM(MonsNo.NYAASU,    0, (byte)PokeType.NORMAL,  Effect.NEKONIKOBAN,           3),
			new GSHOCK_EFFECT_TABLE_SP_ELEM(MonsNo.KAIRIKII,  0, (byte)PokeType.KAKUTOU, Effect.RANKUP_CRITICAL,       4),
			new GSHOCK_EFFECT_TABLE_SP_ELEM(MonsNo.GENGAA,    0, (byte)PokeType.GHOST,   Effect.TOOSENBOU,             5),
			new GSHOCK_EFFECT_TABLE_SP_ELEM(MonsNo.RAPURASU,  0, (byte)PokeType.KOORI,   Effect.AURORAVEIL,            6),
			new GSHOCK_EFFECT_TABLE_SP_ELEM(MonsNo.IIBUI,     0, (byte)PokeType.NORMAL,  Effect.SICK_MEROMERO,         7),
			new GSHOCK_EFFECT_TABLE_SP_ELEM(MonsNo.KABIGON,   0, (byte)PokeType.NORMAL,  Effect.SYUUKAKU,              8),
			new GSHOCK_EFFECT_TABLE_SP_ELEM(MonsNo.KINGURAA,  0, (byte)PokeType.MIZU,    Effect.RANKDOWN_AGI2,         24),
		};
		
		public static Effect GetEffect(BTL_POKEPARAM poke, WazaNo wazano)
		{
			MonsNo monsno = (MonsNo)poke.GetMonsNo();
			ushort formno = poke.GetFormNo();

			for (int i = 0; i < GSHOCK_EFFECT_TABLE_SP.Length; i++)
			{
				if (GSHOCK_EFFECT_TABLE_SP[i].monsno == monsno && GSHOCK_EFFECT_TABLE_SP[i].formno == formno)
				{
					byte wazaType = (byte)WAZADATA.GetType(wazano);
					if (GSHOCK_EFFECT_TABLE_SP[i].wazaType == wazaType)
						return GSHOCK_EFFECT_TABLE_SP[i].shockEffect;
				}
			}

			for (int i = 0; i < GSHOCK_EFFECT_TABLE.Length; i++)
			{
				if (GSHOCK_EFFECT_TABLE[i].wazano == wazano)
					return GSHOCK_EFFECT_TABLE[i].effect;
			}

			return Effect.NONE;
		}

		public static int GetSpecialWazaNameIndex(MonsNo monsno, ushort formno, bool isG, bool isSpGEnable, WazaNo wazano)
		{
			if (!isG || !isSpGEnable)
				return -1;

			byte wazaType = (byte)WAZADATA.GetType(wazano);

			for (int i = 0; i < GSHOCK_EFFECT_TABLE_SP.Length; i++)
			{
				if (GSHOCK_EFFECT_TABLE_SP[i].monsno == monsno && GSHOCK_EFFECT_TABLE_SP[i].formno == formno
					&& GSHOCK_EFFECT_TABLE_SP[i].wazaType == wazaType)
				{
					return GSHOCK_EFFECT_TABLE_SP[i].specialWazaNameIndex;
				}
			}

			return -1;
		}

		public static byte GetSpecialGWazaBaseType(MonsNo monsno, ushort formno)
		{
			for (int i = 0; i < GSHOCK_EFFECT_TABLE_SP.Length; i++)
			{
				if (GSHOCK_EFFECT_TABLE_SP[i].monsno == monsno && GSHOCK_EFFECT_TABLE_SP[i].formno == formno)
					return GSHOCK_EFFECT_TABLE_SP[i].wazaType;
			}

			return (byte)PokeType.NULL;
		}

		public enum Effect : byte
		{
			NONE = 0,
			WEATHER_SHINE = 1,
			WEATHER_RAIN = 2,
			WEATHER_SNOW = 3,
			WEATHER_SAND = 4,
			FIELD_ELEC = 5,
			FIELD_GRASS = 6,
			FIELD_MIST = 7,
			FIELD_PSYCO = 8,
			RANKUP_ATK = 9,
			RANKUP_DEF = 10,
			RANKUP_SPATK = 11,
			RANKUP_SPDEF = 12,
			RANKUP_AGI = 13,
			RANKUP_CRITICAL = 14,
			RANKDOWN_ATK = 15,
			RANKDOWN_DEF = 16,
			RANKDOWN_SPATK = 17,
			RANKDOWN_SPDEF = 18,
			RANKDOWN_AGI = 19,
			RANKDOWN_AGI2 = 20,
			RANKDOWN_AVOID = 21,
			SICK_DOKU = 22,
			SICK_MAHI = 23,
			SICK_DOKU_MAHI = 24,
			SICK_DOKU_MAHI_NEMURI = 25,
			SICK_KONRAN = 26,
			SICK_MEROMERO = 27,
			SIDE_HONOO = 28,
			SIDE_IWA = 29,
			AURORAVEIL = 30,
			STEALTHROCK = 31,
			STEALTHROCK_HAGANE = 32,
			JURYOKU = 33,
			NEKONIKOBAN = 34,
			TOOSENBOU = 35,
			AKUBI = 36,
			ICHAMON = 37,
			SYUUKAKU = 38,
			SUNAZIGOKU = 39,
			HONOONOUZU = 40,
			KIRIBARAI = 41,
			DECREMENT_PP = 42,
			RECOVER_HP = 43,
			CURE_SICK = 44,
		}

		private struct GSHOCK_EFFECT_TABLE_ELEM
		{
			public WazaNo wazano;
			public Effect effect;
			
			public GSHOCK_EFFECT_TABLE_ELEM(WazaNo wazano, Effect effect)
			{
				this.wazano = wazano;
				this.effect = effect;
			}
		}

		private struct GSHOCK_EFFECT_TABLE_SP_ELEM
		{
			public MonsNo monsno;
			public ushort formno;
			public byte wazaType;
			public Effect shockEffect;
			public int specialWazaNameIndex;
			
			public GSHOCK_EFFECT_TABLE_SP_ELEM(MonsNo monsno, ushort formno, byte wazaType, Effect shockEffect, int specialWazaNameIndex)
			{
				this.monsno = monsno;
				this.formno = formno;
				this.wazaType = wazaType;
				this.shockEffect = shockEffect;
				this.specialWazaNameIndex = specialWazaNameIndex;
			}
		}
	}
}