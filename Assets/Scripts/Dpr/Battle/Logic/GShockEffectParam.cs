using Pml.PokePara;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public class GShockEffectParam
	{
		private readonly MainModule m_pMainModule;
		private readonly BattleEnv m_pBattleEnv;
		private BTL_POKEPARAM m_pAttaker;
		private BTL_POKEPARAM m_pDefender;
		private readonly ActionDesc m_pActionDesc;
		private readonly WazaParam m_pWazaParam;
		private GShock.Effect m_gShockEffect;
		private PosData[] m_posData = Arrays.InitializeWithDefaultInstances<PosData>(DefineConstants.BTL_POSIDX_MAX);

		private static readonly IsNeedSummarizeTableElem[] IsNeedSummarizeTable = new IsNeedSummarizeTableElem[]
		{
			new IsNeedSummarizeTableElem(GShock.Effect.NONE,                  false, false),
			new IsNeedSummarizeTableElem(GShock.Effect.WEATHER_SHINE,         false, false),
			new IsNeedSummarizeTableElem(GShock.Effect.WEATHER_RAIN,          false, false),
			new IsNeedSummarizeTableElem(GShock.Effect.WEATHER_SNOW,          false, false),
			new IsNeedSummarizeTableElem(GShock.Effect.WEATHER_SAND,          false, false),
			new IsNeedSummarizeTableElem(GShock.Effect.FIELD_ELEC,            false, false),
			new IsNeedSummarizeTableElem(GShock.Effect.FIELD_GRASS,           false, false),
			new IsNeedSummarizeTableElem(GShock.Effect.FIELD_MIST,            false, false),
			new IsNeedSummarizeTableElem(GShock.Effect.FIELD_PSYCO,           false, false),
			new IsNeedSummarizeTableElem(GShock.Effect.RANKUP_ATK,            false, true),
			new IsNeedSummarizeTableElem(GShock.Effect.RANKUP_DEF,            false, true),
			new IsNeedSummarizeTableElem(GShock.Effect.RANKUP_SPATK,          false, true),
			new IsNeedSummarizeTableElem(GShock.Effect.RANKUP_SPDEF,          false, true),
			new IsNeedSummarizeTableElem(GShock.Effect.RANKUP_AGI,            false, true),
			new IsNeedSummarizeTableElem(GShock.Effect.RANKUP_CRITICAL,       false, true),
			new IsNeedSummarizeTableElem(GShock.Effect.RANKDOWN_ATK,          true,  false),
			new IsNeedSummarizeTableElem(GShock.Effect.RANKDOWN_DEF,          true,  false),
			new IsNeedSummarizeTableElem(GShock.Effect.RANKDOWN_SPATK,        true,  false),
			new IsNeedSummarizeTableElem(GShock.Effect.RANKDOWN_SPDEF,        true,  false),
			new IsNeedSummarizeTableElem(GShock.Effect.RANKDOWN_AGI,          true,  false),
			new IsNeedSummarizeTableElem(GShock.Effect.RANKDOWN_AGI2,         true,  false),
			new IsNeedSummarizeTableElem(GShock.Effect.RANKDOWN_AVOID,        true,  false),
			new IsNeedSummarizeTableElem(GShock.Effect.SICK_DOKU,             true,  false),
			new IsNeedSummarizeTableElem(GShock.Effect.SICK_MAHI,             true,  false),
			new IsNeedSummarizeTableElem(GShock.Effect.SICK_DOKU_MAHI,        true,  false),
			new IsNeedSummarizeTableElem(GShock.Effect.SICK_DOKU_MAHI_NEMURI, true,  false),
			new IsNeedSummarizeTableElem(GShock.Effect.SICK_KONRAN,           true,  false),
			new IsNeedSummarizeTableElem(GShock.Effect.SICK_MEROMERO,         true,  false),
			new IsNeedSummarizeTableElem(GShock.Effect.SIDE_HONOO,            false, false),
			new IsNeedSummarizeTableElem(GShock.Effect.SIDE_IWA,              false, false),
			new IsNeedSummarizeTableElem(GShock.Effect.AURORAVEIL,            false, false),
			new IsNeedSummarizeTableElem(GShock.Effect.STEALTHROCK,           false, false),
			new IsNeedSummarizeTableElem(GShock.Effect.STEALTHROCK_HAGANE,    false, false),
			new IsNeedSummarizeTableElem(GShock.Effect.JURYOKU,               false, false),
			new IsNeedSummarizeTableElem(GShock.Effect.NEKONIKOBAN,           false, false),
			new IsNeedSummarizeTableElem(GShock.Effect.TOOSENBOU,             true,  false),
			new IsNeedSummarizeTableElem(GShock.Effect.AKUBI,                 true,  false),
			new IsNeedSummarizeTableElem(GShock.Effect.ICHAMON,               true,  false),
			new IsNeedSummarizeTableElem(GShock.Effect.SYUUKAKU,              false, false),
            new IsNeedSummarizeTableElem(GShock.Effect.SUNAZIGOKU,            true,  false),
            new IsNeedSummarizeTableElem(GShock.Effect.HONOONOUZU,            true,  false),
            new IsNeedSummarizeTableElem(GShock.Effect.KIRIBARAI,             false, false),
            new IsNeedSummarizeTableElem(GShock.Effect.DECREMENT_PP,          true,  false),
            new IsNeedSummarizeTableElem(GShock.Effect.RECOVER_HP,            false, true),
            new IsNeedSummarizeTableElem(GShock.Effect.CURE_SICK,             false, true),
        };
		
		public GShockEffectParam(in SetupParam param)
		{
			m_pMainModule = param.pMainModule;
			m_pBattleEnv = param.pBattleEnv;
			m_pAttaker = param.pAttaker;
			m_pDefender = param.pDefender;
			m_pActionDesc = param.pActionDesc;
			m_pWazaParam = param.pWazaParam;
			m_gShockEffect = param.gShockEffect;

			m_posData[0].isEffected = false;
			m_posData[0].effectNo = (ushort)BtlEff.BTLEFF_MAX;
			m_posData[0].effectVolume = 0;
			m_posData[0].curedPokeSick = Sick.NONE;
			m_posData[0].targetPokeID = PokeID.INVALID;

            m_posData[1].isEffected = false;
            m_posData[1].effectNo = (ushort)BtlEff.BTLEFF_MAX;
            m_posData[1].effectVolume = 0;
            m_posData[1].curedPokeSick = Sick.NONE;
            m_posData[1].targetPokeID = PokeID.INVALID;

            m_posData[2].isEffected = false;
            m_posData[2].effectNo = (ushort)BtlEff.BTLEFF_MAX;
            m_posData[2].effectVolume = 0;
            m_posData[2].curedPokeSick = Sick.NONE;
            m_posData[2].targetPokeID = PokeID.INVALID;

            m_posData[3].isEffected = false;
            m_posData[3].effectNo = (ushort)BtlEff.BTLEFF_MAX;
            m_posData[3].effectVolume = 0;
            m_posData[3].curedPokeSick = Sick.NONE;
            m_posData[3].targetPokeID = PokeID.INVALID;

            m_posData[4].isEffected = false;
            m_posData[4].effectNo = (ushort)BtlEff.BTLEFF_MAX;
            m_posData[4].effectVolume = 0;
            m_posData[4].curedPokeSick = Sick.NONE;
            m_posData[4].targetPokeID = PokeID.INVALID;
        }
		
		// TODO
		public bool IsNeedSummarize() { return default; }
		
		public ActionDesc GetActionDesc() {
		    return m_pActionDesc;
		}
		
		public WazaParam GetWazaParam() {
		    return m_pWazaParam;
		}
		
		public BTL_POKEPARAM GetAttacker() {
		    return m_pAttaker;
		}
		
		public BTL_POKEPARAM GetDefender() {
		    return m_pDefender;
		}
		
		public GShock.Effect GetGShockEffect() {
		    return m_gShockEffect;
		}
		
		// TODO
		public ushort GetEffectNo(BtlPokePos pos) { return default; }
		
		// TODO
		public int GetEffectVolume(BtlPokePos pos) { return default; }
		
		// TODO
		public int GetEffectVolume(byte pokeID) { return default; }
		
		// TODO
		public Sick GetCuredPokeSick(BtlPokePos pos) { return default; }
		
		// TODO
		public byte GetTargetPokeID(BtlPokePos pos) { return default; }
		
		// TODO
		public bool IsEffected(BtlPokePos pos) { return default; }
		
		// TODO
		public bool IsEffectedAny() { return default; }
		
		// TODO
		public void SetEffected(BtlPokePos pos, ushort effectNo) { }
		
		// TODO
		public void SetEffected_Rank(BtlPokePos pos, int volume) { }
		
		// TODO
		public void SetEffected_Sick(BtlPokePos pos, WazaSick sick) { }
		
		// TODO
		public void SetEffected_CureSick(BtlPokePos pos, Sick sick) { }

		public class SetupParam
		{
			public MainModule pMainModule;
			public BattleEnv pBattleEnv;
			public ActionDesc pActionDesc;
			public WazaParam pWazaParam;
			public BTL_POKEPARAM pAttaker;
			public BTL_POKEPARAM pDefender;
			public GShock.Effect gShockEffect;
		}

		private class PosData
		{
			public bool isEffected;
			public byte targetPokeID;
			public ushort effectNo;
			public int effectVolume;
			public Sick curedPokeSick;
		}

		private struct IsNeedSummarizeTableElem
		{
			public GShock.Effect effect;
			public bool needSummarize_ByBossAttack;
			public bool needSummarize_ByPlayerAttack;
			
			public IsNeedSummarizeTableElem(GShock.Effect effect, bool needSummarize_ByBossAttack, bool needSummarize_ByPlayerAttack)
			{
				this.effect = effect;
				this.needSummarize_ByBossAttack = needSummarize_ByBossAttack;
				this.needSummarize_ByPlayerAttack = needSummarize_ByPlayerAttack;
			}
		}
	}
}