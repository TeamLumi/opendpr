using Pml;
using Pml.PokePara;
using Pml.WazaData;
using System.Runtime.InteropServices;

namespace Dpr.Battle.Logic
{
    public class BTL_POKEPARAM
    {
        private static readonly ContFlag[] WAZAHIDE_FLAGS = new ContFlag[]
        {
            ContFlag.CONTFLG_SORAWOTOBU,
            ContFlag.CONTFLG_DIVING,
            ContFlag.CONTFLG_ANAWOHORU,
            ContFlag.CONTFLG_SHADOWDIVE,
        };

        public const int WAZADMG_REC_TURN_MAX = 3;
        public const int WAZADMG_REC_MAX = 6;
        public const int RANK_STATUS_MIN = 0;
        public const int RANK_STATUS_MAX = 12;
        public const int RANK_STATUS_DEFAULT = 6;
        public const uint PERMCOUNTER_MAX = 65535;
        private const int TURNFLG_BUF_SIZE = 4;
        private const int CONTFLG_BUF_SIZE = 4;
        private const int PERMFLG_BUF_SIZE = 1;
        private const int TURNCOUNT_NULL = 10000;
        private CORE_PARAM m_coreParam;
        private BASE_PARAM m_baseParam;
        private VARIABLE_PARAM m_varyParam;
        private DORYOKU_PARAM m_doryokuParam;
        private WAZA_SET[] m_waza;
        private ushort m_tokusei;
        private ushort m_weight;
        private byte m_wazaCnt;
        private byte m_formNo;
        private byte m_friendship;
        private byte m_criticalRank;
        private byte m_usedWazaCount;
        private byte m_prevWazaType;
        private byte m_spActPriority;
        private ushort m_turnCount;
        private ushort m_appearedTurn;
        private ushort m_wazaContCounter;
        private BtlPokePos m_prevTargetPos;
        private WazaNo m_prevActWazaID;
        private WazaNo m_prevSelectWazaID;
        private WazaNo m_prevDamagedWaza;
        private byte[] m_turnFlag;
        private byte[] m_contFlag;
        private byte[] m_permFlag;
        private byte[] m_counter;
        private uint[] m_permCounter;
        private WAZADMG_REC[][] m_wazaDamageRec;
        private byte[] m_dmgrecCount;
        private byte m_dmgrecTurnPtr;
        private byte m_dmgrecPtr;
        private ushort m_migawariHP;
        private WazaNo m_combiWazaID;
        private byte m_combiPokeID;
        private readonly FieldStatus m_fldSim;
        private const int SICK_ID = 6;
        private static WAZA_SET[] HENSIN_Set_wazaWork;
        private static byte s_DmyByte;

        public static void WAZADMG_REC_Setup(WAZADMG_REC rec, byte pokeID, BtlPokePos pokePos, ushort wazaID, byte wazaType, ushort damage, WazaDamageType damageType)
        {
            rec.pokeID = pokeID;
            rec.pokePos = pokePos;
            rec.wazaID = wazaID;
            rec.wazaType = wazaType;
            rec.damage = damage;
            rec.damageType = damageType;
        }

        public byte GetFormNo() { return m_formNo; }

        public byte GetFriendship() { return m_friendship; }

        public static byte PokeIDtoFreeFallCounter(byte pokeID) { return (byte)(pokeID + 1); }

        public static byte FreeFallCounterToPokeID(byte counter) { return (byte)(counter - 1); }

        private void flgbuf_clear(byte[] buf)
        {
            for (int i = 0; i < buf.Length; i++)
                buf[i] = 0;
        }

        private void flgbuf_set(byte[] buf, uint flagID)
        {
            buf[flagID >> 3] |= (byte)(1 << (int)(flagID & 7));
        }

        private void flgbuf_reset(byte[] buf, uint flagID)
        {
            buf[flagID >> 3] &= (byte)~(1 << (int)(flagID & 7));
        }

        private bool flgbuf_get(byte[] buf, uint flagID)
        {
            return (buf[flagID >> 3] & (1 << (int)(flagID & 7))) != 0;
        }

        public BTL_POKEPARAM([Optional] FieldStatus fieldStatus)
        {
            m_coreParam = new CORE_PARAM();
            m_baseParam = new BASE_PARAM();
            m_varyParam = new VARIABLE_PARAM();
            m_doryokuParam = new DORYOKU_PARAM();
            m_waza = new WAZA_SET[4] { new WAZA_SET(), new WAZA_SET(), new WAZA_SET(), new WAZA_SET() };
            m_turnFlag = new byte[TURNFLG_BUF_SIZE];
            m_contFlag = new byte[CONTFLG_BUF_SIZE];
            m_permFlag = new byte[PERMFLG_BUF_SIZE];
            m_counter = new byte[(int)Counter.COUNTER_MAX];
            m_permCounter = new uint[(int)PermCounter.NUM];
            m_wazaDamageRec = new WAZADMG_REC[WAZADMG_REC_TURN_MAX][];
            for (int i = 0; i < WAZADMG_REC_TURN_MAX; i++)
            {
                m_wazaDamageRec[i] = new WAZADMG_REC[WAZADMG_REC_MAX];
                for (int j = 0; j < WAZADMG_REC_MAX; j++)
                    m_wazaDamageRec[i][j] = new WAZADMG_REC();
            }
            m_dmgrecCount = new byte[WAZADMG_REC_TURN_MAX];
            m_fldSim = fieldStatus;
            m_coreParam.ppSrc = new PokemonParam();
            m_coreParam.raidBossParam = new RaidBossParam();
        }

        public void Dispose() { }

        public void Setup(in SetupParam setupParam)
        {
            bool fastMode = setupParam.srcParam.StartFastMode();
            m_coreParam.ppSrc.CopyFrom(setupParam.srcParam);
            m_coreParam.isRaidBoss = false;
            m_coreParam.myID = setupParam.pokeID;
            m_coreParam.monsno = (ushort)setupParam.srcParam.GetMonsNo();
            m_coreParam.formno = setupParam.srcParam.GetFormNo();
            m_coreParam.hp = (ushort)setupParam.srcParam.GetHp();
            ushort hpMax = (ushort)setupParam.srcParam.GetPower_NotG(PowerID.HP);
            if (m_coreParam.isRaidBoss)
            {
                float coef = m_coreParam.raidBossParam.GetHPCoef();
                hpMax = (ushort)(int)(coef * hpMax);
            }
            m_coreParam.hpMax = hpMax;
            m_coreParam.item = (ushort)setupParam.srcParam.GetItem();
            if (m_coreParam.item > 0x71e)
                m_coreParam.item = 0;
            m_coreParam.usedItem = 0;
            m_coreParam.fHensin = false;
            m_coreParam.fDontResetFormByByOut = false;
            m_coreParam.totalTurnCount = 0;
            m_coreParam.fakeViewTargetPokeId = 0x1f;
            m_coreParam.fFakeEnable = false;
            m_coreParam.personalRand = setupParam.srcParam.GetPersonalRnd();
            m_coreParam.seikaku = (byte)setupParam.srcParam.GetSeikaku();
            m_coreParam.native_talent_hp = (byte)setupParam.srcParam.GetNativeTalentPower(PowerID.HP);
            m_coreParam.native_talent_atk = (byte)setupParam.srcParam.GetNativeTalentPower(PowerID.ATK);
            m_coreParam.native_talent_def = (byte)setupParam.srcParam.GetNativeTalentPower(PowerID.DEF);
            m_coreParam.native_talent_spatk = (byte)setupParam.srcParam.GetNativeTalentPower(PowerID.SPATK);
            m_coreParam.native_talent_spdef = (byte)setupParam.srcParam.GetNativeTalentPower(PowerID.SPDEF);
            m_coreParam.native_talent_agi = (byte)setupParam.srcParam.GetNativeTalentPower(PowerID.AGI);
            m_coreParam.defaultFormNo = setupParam.srcParam.GetFormNo();
            m_coreParam.defaultTokusei = (ushort)setupParam.srcParam.GetTokuseiNo();
            m_coreParam.level = (byte)setupParam.srcParam.GetLevel();
            m_coreParam.mons_pow = (byte)calc.PERSONAL_GetParam(m_coreParam.monsno, m_coreParam.defaultFormNo, (Pml.Personal.ParamID)1);
            m_coreParam.mons_agility = (byte)calc.PERSONAL_GetParam(m_coreParam.monsno, m_coreParam.defaultFormNo, (Pml.Personal.ParamID)3);
            m_coreParam.killCount = 0;
            m_coreParam.deadCausePokeID = 0;
            m_coreParam.fForceGEnable = setupParam.isForceGEnable;
            m_coreParam.gParam.isGMode = false;
            m_coreParam.gParam.passedTurnCount = 0;
            m_coreParam.fBtlIn = false;
            m_coreParam.deadCause = DamageCause.OTHER;
            m_coreParam.deadCausePokeID = 0x1f;
            DEFAULT_POWERUP_DESC.Copy(m_coreParam.defaultPowerUpDesc, setupParam.defaultPowerUpDesc);
            doryoku_InitParam(m_doryokuParam, setupParam.srcParam);
            setupBySrcData(true, true, true, true);
            m_wazaCnt = (byte)wazaWork_setupByPP(setupParam.srcParam, true);
            m_usedWazaCount = 0;
            effrank_Init(m_varyParam);
            clearWazaSickWork((uint)SickWorkClearCode.SICKWORK_CLEAR_ALL);
            Sick pokeSick = setupParam.srcParam.GetSick();
            if (pokeSick != Sick.NONE)
            {
                BTL_SICKCONT cont = calc.MakeDefaultPokeSickCont(pokeSick, m_coreParam.myID, true);
                m_coreParam.sickCont[(int)pokeSick] = cont;
                m_coreParam.wazaSickCounter[(int)pokeSick] = 0;
            }
            m_appearedTurn = (ushort)TURNCOUNT_NULL;
            m_prevWazaType = 0x12;
            m_turnCount = 0;
            m_migawariHP = 0;
            m_prevTargetPos = 0;
            m_prevActWazaID = WazaNo.NULL;
            m_prevSelectWazaID = WazaNo.NULL;
            m_prevDamagedWaza = WazaNo.NULL;
            m_combiWazaID = WazaNo.NULL;
            m_combiPokeID = 0x1f;
            m_criticalRank = 0;
            m_friendship = setupParam.friendship;
            m_spActPriority = 1;
            flgbuf_clear(m_turnFlag);
            flgbuf_clear(m_contFlag);
            flgbuf_clear(m_permFlag);
            for (int i = 0; i < m_counter.Length; i++)
                m_counter[i] = 0;
            for (int i = 0; i < m_permCounter.Length; i++)
                m_permCounter[i] = 0;
            dmgrec_ClearWork();
            m_coreParam.confrontRecCount = 0;
            setupParam.srcParam.EndFastMode(fastMode);
        }

        private void setupBySrcData(bool fReflectHP, bool fParamUpdate, bool fTokuseiUpdate, bool fWeightUpdate)
        {
            bool isGMode = m_coreParam.gParam.isGMode;
            if (fReflectHP)
            {
                m_coreParam.hp = (ushort)m_coreParam.ppSrc.GetHp();
                ushort hpMax;
                if (isGMode)
                    hpMax = (ushort)m_coreParam.ppSrc.GetPower_G(PowerID.HP);
                else
                    hpMax = (ushort)m_coreParam.ppSrc.GetPower_NotG(PowerID.HP);
                if (m_coreParam.isRaidBoss)
                {
                    float coef = m_coreParam.raidBossParam.GetHPCoef();
                    hpMax = (ushort)(int)(coef * hpMax);
                }
                m_coreParam.hpMax = hpMax;
            }
            m_coreParam.exp = m_coreParam.ppSrc.GetExp();
            setupBySrcDataBase(fTokuseiUpdate, fParamUpdate, isGMode);
            if (fTokuseiUpdate)
                m_tokusei = (ushort)m_coreParam.ppSrc.GetTokuseiNo();
            m_formNo = (byte)m_coreParam.ppSrc.GetFormNo();
            if (fWeightUpdate)
                updateWeight();
        }

        private void setupBySrcDataBase(bool fTypeUpdate, bool fParamUpdate, bool isGMode)
        {
            if (fTypeUpdate)
            {
                m_baseParam.type1 = (byte)m_coreParam.ppSrc.GetType1();
                m_baseParam.type2 = (byte)m_coreParam.ppSrc.GetType2();
                m_baseParam.type_ex = 0x12;
                m_baseParam.type_ex_cause = ExTypeCause.EXTYPE_CAUSE_NONE;
            }
            m_baseParam.sex = (byte)m_coreParam.ppSrc.GetSex();
            if (fParamUpdate)
            {
                if (isGMode)
                {
                    m_baseParam.attack = (ushort)m_coreParam.ppSrc.GetPower_G(PowerID.ATK);
                    m_baseParam.defence = (ushort)m_coreParam.ppSrc.GetPower_G(PowerID.DEF);
                    m_baseParam.sp_attack = (ushort)m_coreParam.ppSrc.GetPower_G(PowerID.SPATK);
                    m_baseParam.sp_defence = (ushort)m_coreParam.ppSrc.GetPower_G(PowerID.SPDEF);
                    m_baseParam.agility = (ushort)m_coreParam.ppSrc.GetPower_G(PowerID.AGI);
                }
                else
                {
                    m_baseParam.attack = (ushort)m_coreParam.ppSrc.GetPower_NotG(PowerID.ATK);
                    m_baseParam.defence = (ushort)m_coreParam.ppSrc.GetPower_NotG(PowerID.DEF);
                    m_baseParam.sp_attack = (ushort)m_coreParam.ppSrc.GetPower_NotG(PowerID.SPATK);
                    m_baseParam.sp_defence = (ushort)m_coreParam.ppSrc.GetPower_NotG(PowerID.SPDEF);
                    m_baseParam.agility = (ushort)m_coreParam.ppSrc.GetPower_NotG(PowerID.AGI);
                }
            }
            m_baseParam.monsno = (ushort)m_coreParam.ppSrc.GetMonsNo();
            m_baseParam.formno = m_coreParam.ppSrc.GetFormNo();
        }

        private ushort getBasePower(PowerID powerID, bool isGMode, bool isApplyRaidBossHpCoef = true)
        {
            ushort val;
            if (isGMode)
                val = (ushort)m_coreParam.ppSrc.GetPower_G(powerID);
            else
                val = (ushort)m_coreParam.ppSrc.GetPower_NotG(powerID);
            if (powerID == PowerID.HP && m_coreParam.isRaidBoss && isApplyRaidBossHpCoef)
            {
                float coef = m_coreParam.raidBossParam.GetHPCoef();
                val = (ushort)(int)(coef * val);
            }
            return val;
        }

        private void updateWeight()
        {
            short w = (short)calc.PERSONAL_GetParam(m_coreParam.monsno, m_formNo, (Pml.Personal.ParamID)0x22);
            if (w == 0) w = 1;
            m_weight = (ushort)w;
        }

        private uint wazaWork_setupByPP(PokemonParam pp_src, bool fLinkSurface)
        {
            bool fastMode = pp_src.StartFastMode();
            if (fLinkSurface)
            {
                for (int i = 0; i < m_waza.Length; i++)
                {
                    m_waza[i].truth.usedCount = 0;
                    m_waza[i].truth.killCount = 0;
                    m_waza[i].truth.usedFlag = false;
                    m_waza[i].truth.usedFlagFix = false;
                    m_waza[i].surface.usedCount = 0;
                    m_waza[i].surface.killCount = 0;
                    m_waza[i].surface.usedFlag = false;
                    m_waza[i].surface.usedFlagFix = false;
                }
            }
            byte count = 0;
            for (int i = 0; i < m_waza.Length; i++)
            {
                if (wazaCore_SetupByPP(m_waza[i].truth, pp_src, (byte)i))
                    count++;
            }
            if (fLinkSurface)
            {
                for (int i = 0; i < m_waza.Length; i++)
                {
                    m_waza[i].surface.CopyFrom(m_waza[i].truth);
                    m_waza[i].fLinked = true;
                }
            }
            pp_src.EndFastMode(fastMode);
            return count;
        }

        private void wazaWork_ReflectToPP()
        {
            bool fastMode = m_coreParam.ppSrc.StartFastMode();
            for (byte i = 0; i < m_wazaCnt; i++)
            {
                WAZA_CORE core = m_waza[i].truth;
                m_coreParam.ppSrc.SetWaza(i, (WazaNo)core.number);
                m_coreParam.ppSrc.SetWazaPP(i, core.pp);
                m_coreParam.ppSrc.SetWazaPPUpCount(i, core.ppCnt);
            }
            m_coreParam.ppSrc.EndFastMode(fastMode);
        }

        private void wazaWork_ReflectFromPP()
        {
            bool fastMode = m_coreParam.ppSrc.StartFastMode();
            for (byte i = 0; i < m_wazaCnt; i++)
            {
                wazaCore_SetupByPP(m_waza[i].truth, m_coreParam.ppSrc, i);
            }
            m_coreParam.ppSrc.EndFastMode(fastMode);
        }

        private void wazaWork_ClearSurface()
        {
            for (int i = 0; i < m_waza.Length; i++)
            {
                m_waza[i].surface.CopyFrom(m_waza[i].truth);
                m_waza[i].fLinked = true;
            }
        }

        private void wazaSet_ClearUsedFlag(WAZA_SET waza)
        {
            waza.truth.usedFlag = false;
            waza.surface.usedFlag = false;
        }

        private bool wazaCore_SetupByPP(WAZA_CORE core, PokemonParam pp, byte index)
        {
            WazaNo wazaNo = pp.GetWazaNo(index);
            if ((int)core.number != (int)wazaNo)
            {
                core.usedCount = 0;
                core.killCount = 0;
                core.usedFlag = false;
                core.usedFlagFix = false;
            }
            core.number = wazaNo;
            if (wazaNo == WazaNo.NULL)
            {
                core.pp = 0;
                core.ppMax = 0;
                core.ppCnt = 0;
            }
            else
            {
                core.pp = (byte)pp.GetWazaPP(index);
                core.ppMax = (byte)pp.GetWazaMaxPP(index);
                core.ppCnt = (byte)pp.GetWazaPPUpCount(index);
            }
            return wazaNo != WazaNo.NULL;
        }

        public void CopyFrom(in BTL_POKEPARAM srcParam, bool isCompletely = false)
        {
            henshinCopyFrom(srcParam);
            CORE_PARAM_Copy(m_coreParam, srcParam.m_coreParam);
            if (!isCompletely)
                return;
            m_doryokuParam.CopyFrom(srcParam.m_doryokuParam);
            m_spActPriority = srcParam.m_spActPriority;
            for (int i = 0; i < m_permCounter.Length; i++)
                m_permCounter[i] = srcParam.m_permCounter[i];
            m_fldSim.CopyFrom(srcParam.m_fldSim);
        }

        private void CORE_PARAM_Copy(CORE_PARAM dest, in CORE_PARAM src)
        {
            dest.ppSrc.CopyFrom(src.ppSrc);
            dest.exp = src.exp;
            dest.monsno = src.monsno;
            dest.formno = src.formno;
            dest.hpMax = src.hpMax;
            dest.hp = src.hp;
            dest.item = src.item;
            dest.usedItem = src.usedItem;
            dest.defaultTokusei = src.defaultTokusei;
            dest.level = src.level;
            dest.myID = src.myID;
            dest.mons_pow = src.mons_pow;
            dest.mons_agility = src.mons_agility;
            dest.defaultFormNo = src.defaultFormNo;
            dest.fHensin = src.fHensin;
            dest.fDontResetFormByByOut = src.fDontResetFormByByOut;
            dest.fFakeEnable = src.fFakeEnable;
            dest.fBtlIn = src.fBtlIn;
            dest.fForceGEnable = src.fForceGEnable;
            dest.deadCause = src.deadCause;
            dest.deadCausePokeID = src.deadCausePokeID;
            dest.killCount = src.killCount;
            dest.confrontRecCount = src.confrontRecCount;
            dest.totalTurnCount = src.totalTurnCount;
            dest.fakeViewTargetPokeId = src.fakeViewTargetPokeId;
            for (int i = 0; i < src.sickCont.Length; i++)
                dest.sickCont[i] = src.sickCont[i];
            for (int i = 0; i < src.wazaSickCounter.Length; i++)
                dest.wazaSickCounter[i] = src.wazaSickCounter[i];
            for (int i = 0; i < src.confrontRec.Length; i++)
                dest.confrontRec[i] = src.confrontRec[i];
            dest.gParam.CopyFrom(src.gParam);
            DEFAULT_POWERUP_DESC.Copy(dest.defaultPowerUpDesc, src.defaultPowerUpDesc);
            dest.isRaidBoss = src.isRaidBoss;
            dest.raidBossParam.CopyFrom(src.raidBossParam);
        }

        public byte GetID() { return m_coreParam.myID; }

        public ushort GetMonsNo() { return m_coreParam.monsno; }

        public Seikaku GetSeikaku() { return (Seikaku)m_coreParam.seikaku; }

        public ushort GetHenshinMonsNo() { return m_baseParam.monsno; }

        public ushort GetHenshinFormNo() { return m_baseParam.formno; }

        public DefaultPowerUpDesc GetDefaultPowerUpDesc() { return m_coreParam.defaultPowerUpDesc; }

        public DamageCause GetDeadCause() { return m_coreParam.deadCause; }

        public byte GetDeadCausePokeID() { return m_coreParam.deadCausePokeID; }

        public void SetDeadCause(DamageCause damageCause, byte damageCausePokeID)
        {
            m_coreParam.deadCause = damageCause;
            m_coreParam.deadCausePokeID = damageCausePokeID;
        }

        public void ClearDeadCause()
        {
            m_coreParam.deadCause = DamageCause.OTHER;
            m_coreParam.deadCausePokeID = 0x1f;
        }

        public byte GetKillCount() { return m_coreParam.killCount; }

        public void SetKillCount(byte killCount) { m_coreParam.killCount = killCount; }

        public void IncKillCount() { m_coreParam.killCount++; }

        public BtlSpecialPri GetSpActPriority() { return (BtlSpecialPri)m_spActPriority; }

        public void SetSpActPriority(byte priority) { m_spActPriority = priority; }

        private void resetSpActPriority() { m_spActPriority = 1; }

        public PokemonParam GetSrcData() { return m_coreParam.ppSrc; }

        public PokemonParam GetSrcDataConst() { return m_coreParam.ppSrc; }

        public void SetViewSrcPokeID(byte fakeTargetPokeID) { m_coreParam.fakeViewTargetPokeId = fakeTargetPokeID; }

        public byte GetViewSrcPokeID() { return m_coreParam.fakeViewTargetPokeId; }

        private void effrank_Init(VARIABLE_PARAM rank)
        {
            rank.attack = RANK_STATUS_DEFAULT;
            rank.defence = RANK_STATUS_DEFAULT;
            rank.sp_attack = RANK_STATUS_DEFAULT;
            rank.sp_defence = RANK_STATUS_DEFAULT;
            rank.agility = RANK_STATUS_DEFAULT;
            rank.hit = RANK_STATUS_DEFAULT;
            rank.avoid = RANK_STATUS_DEFAULT;
        }

        private void effrank_Reset(VARIABLE_PARAM rank)
        {
            rank.attack = RANK_STATUS_DEFAULT;
            rank.defence = RANK_STATUS_DEFAULT;
            rank.sp_attack = RANK_STATUS_DEFAULT;
            rank.sp_defence = RANK_STATUS_DEFAULT;
            rank.agility = RANK_STATUS_DEFAULT;
            rank.hit = RANK_STATUS_DEFAULT;
            rank.avoid = RANK_STATUS_DEFAULT;
        }

        private bool effrank_ResetRankUp(VARIABLE_PARAM rank)
        {
            bool changed = false;
            if (rank.attack > RANK_STATUS_DEFAULT) { rank.attack = RANK_STATUS_DEFAULT; changed = true; }
            if (rank.defence > RANK_STATUS_DEFAULT) { rank.defence = RANK_STATUS_DEFAULT; changed = true; }
            if (rank.sp_attack > RANK_STATUS_DEFAULT) { rank.sp_attack = RANK_STATUS_DEFAULT; changed = true; }
            if (rank.sp_defence > RANK_STATUS_DEFAULT) { rank.sp_defence = RANK_STATUS_DEFAULT; changed = true; }
            if (rank.agility > RANK_STATUS_DEFAULT) { rank.agility = RANK_STATUS_DEFAULT; changed = true; }
            if (rank.hit > RANK_STATUS_DEFAULT) { rank.hit = RANK_STATUS_DEFAULT; changed = true; }
            if (rank.avoid > RANK_STATUS_DEFAULT) { rank.avoid = RANK_STATUS_DEFAULT; changed = true; }
            return changed;
        }

        private bool effrank_Recover(VARIABLE_PARAM rank)
        {
            bool changed = false;
            if (rank.attack < RANK_STATUS_DEFAULT) { rank.attack = RANK_STATUS_DEFAULT; changed = true; }
            if (rank.defence < RANK_STATUS_DEFAULT) { rank.defence = RANK_STATUS_DEFAULT; changed = true; }
            if (rank.sp_attack < RANK_STATUS_DEFAULT) { rank.sp_attack = RANK_STATUS_DEFAULT; changed = true; }
            if (rank.sp_defence < RANK_STATUS_DEFAULT) { rank.sp_defence = RANK_STATUS_DEFAULT; changed = true; }
            if (rank.agility < RANK_STATUS_DEFAULT) { rank.agility = RANK_STATUS_DEFAULT; changed = true; }
            if (rank.hit < RANK_STATUS_DEFAULT) { rank.hit = RANK_STATUS_DEFAULT; changed = true; }
            if (rank.avoid < RANK_STATUS_DEFAULT) { rank.avoid = RANK_STATUS_DEFAULT; changed = true; }
            return changed;
        }

        private void dmgrec_ClearWork()
        {
            for (int t = 0; t < WAZADMG_REC_TURN_MAX; t++)
            {
                for (int r = 0; r < WAZADMG_REC_MAX; r++)
                    m_wazaDamageRec[t][r].Clear();
            }
            for (int i = 0; i < m_dmgrecCount.Length; i++)
                m_dmgrecCount[i] = 0;
            m_dmgrecTurnPtr = 0;
            m_dmgrecPtr = 0;
        }

        private void dmgrec_FwdTurn()
        {
            byte next = (byte)(m_dmgrecTurnPtr + 1);
            if (next >= WAZADMG_REC_TURN_MAX)
                next = 0;
            m_dmgrecTurnPtr = next;
            m_dmgrecCount[next] = 0;
        }

        private void confrontRec_Clear()
        {
            m_coreParam.confrontRecCount = 0;
        }

        public void Confront_Set(byte pokeID)
        {
            if (m_coreParam.confrontRecCount < m_coreParam.confrontRec.Length)
            {
                m_coreParam.confrontRec[m_coreParam.confrontRecCount] = pokeID;
                m_coreParam.confrontRecCount++;
            }
        }

        public byte Confront_GetCount() { return m_coreParam.confrontRecCount; }

        public byte Confront_GetPokeID(byte idx) { return m_coreParam.confrontRec[idx]; }

        public int GetValue(ValueID vid)
        {
            ValueID convertedVid = vid;
            if (m_fldSim != null)
                convertedVid = convertValueID(vid);
            switch (convertedVid)
            {
                case ValueID.BPP_ATTACK_RANK: return m_varyParam.attack;
                case ValueID.BPP_DEFENCE_RANK: return m_varyParam.defence;
                case ValueID.BPP_SP_ATTACK_RANK: return m_varyParam.sp_attack;
                case ValueID.BPP_SP_DEFENCE_RANK: return m_varyParam.sp_defence;
                case ValueID.BPP_AGILITY_RANK: return m_varyParam.agility;
                case ValueID.BPP_HIT_RATIO: return m_varyParam.hit;
                case ValueID.BPP_AVOID_RATIO: return m_varyParam.avoid;
                case ValueID.BPP_ATTACK: return calc.StatusRank((ushort)GetValue_Base(ValueID.BPP_ATTACK), (byte)m_varyParam.attack);
                case ValueID.BPP_DEFENCE: return calc.StatusRank((ushort)GetValue_Base(ValueID.BPP_DEFENCE), (byte)m_varyParam.defence);
                case ValueID.BPP_SP_ATTACK: return calc.StatusRank((ushort)GetValue_Base(ValueID.BPP_SP_ATTACK), (byte)m_varyParam.sp_attack);
                case ValueID.BPP_SP_DEFENCE: return calc.StatusRank((ushort)GetValue_Base(ValueID.BPP_SP_DEFENCE), (byte)m_varyParam.sp_defence);
                case ValueID.BPP_AGILITY: return calc.StatusRank((ushort)GetValue_Base(ValueID.BPP_AGILITY), (byte)m_varyParam.agility);
                case ValueID.BPP_HP: return m_coreParam.hp;
                case ValueID.BPP_HP_BEFORE_G:
                {
                    if (!m_coreParam.gParam.isGMode)
                        return m_coreParam.hp;
                    int ratio = FX32.CONST((double)(m_coreParam.hp * 100) / (double)m_coreParam.hpMax);
                    return (int)calcHpRatio((uint)GetValue(ValueID.BPP_MAX_HP_BEFORE_G), ratio);
                }
                case ValueID.BPP_MAX_HP: return m_coreParam.hpMax;
                case ValueID.BPP_MAX_HP_BEFORE_G: return (int)m_coreParam.ppSrc.GetPower_NotG(PowerID.HP);
                case ValueID.BPP_LEVEL: return m_coreParam.level;
                case ValueID.BPP_TOKUSEI: return m_tokusei;
                case ValueID.BPP_TOKUSEI_EFFECTIVE:
                {
                    if (CheckSick(WazaSick.WAZASICK_IEKI))
                        return 0;
                    if (m_fldSim != null &&
                        !m_fldSim.CheckTokuseiEffectiveOnKagakuhenkaGas((TokuseiNo)m_tokusei) &&
                        m_fldSim.IsKagakuhenkaGasEffective())
                        return 0;
                    return m_tokusei;
                }
                case ValueID.BPP_SEX: return m_baseParam.sex;
                case ValueID.BPP_SEIKAKU: return m_coreParam.seikaku;
                case ValueID.BPP_PERSONAL_RAND: return (int)m_coreParam.personalRand;
                case ValueID.BPP_EXP: return (int)m_coreParam.exp;
                case ValueID.BPP_MONS_POW: return m_coreParam.mons_pow;
                case ValueID.BPP_MONS_AGILITY: return m_coreParam.mons_agility;
                default: return 0;
            }
        }

        public int GetValue_Base(ValueID vid)
        {
            ValueID convertedVid = vid;
            if (m_fldSim != null)
                convertedVid = convertValueID(vid);
            switch (convertedVid)
            {
                case ValueID.BPP_HIT_RATIO:
                case ValueID.BPP_AVOID_RATIO: return RANK_STATUS_DEFAULT;
                case ValueID.BPP_ATTACK: return m_baseParam.attack;
                case ValueID.BPP_DEFENCE: return m_baseParam.defence;
                case ValueID.BPP_SP_ATTACK: return m_baseParam.sp_attack;
                case ValueID.BPP_SP_DEFENCE: return m_baseParam.sp_defence;
                case ValueID.BPP_AGILITY: return m_baseParam.agility;
                default: return GetValue(convertedVid);
            }
        }

        public byte GetEffortValue(PowerID powerID)
        {
            switch (powerID)
            {
                case PowerID.ATK: return m_doryokuParam.srcPow;
                case PowerID.DEF: return m_doryokuParam.srcDef;
                case PowerID.SPATK: return m_doryokuParam.srcSpPow;
                case PowerID.SPDEF: return m_doryokuParam.srcSpDef;
                case PowerID.AGI: return m_doryokuParam.srcAgi;
                default: return 0;
            }
        }

        public bool IsEffortValueFull() { return m_doryokuParam.srcSum == 0x1fe; }

        public byte GetNativeTalentPower(PowerID powerID)
        {
            switch (powerID)
            {
                case PowerID.HP: return m_coreParam.native_talent_hp;
                case PowerID.ATK: return m_coreParam.native_talent_atk;
                case PowerID.DEF: return m_coreParam.native_talent_def;
                case PowerID.SPATK: return m_coreParam.native_talent_spatk;
                case PowerID.SPDEF: return m_coreParam.native_talent_spdef;
                case PowerID.AGI: return m_coreParam.native_talent_agi;
                default: return 0;
            }
        }

        private ValueID convertValueID(ValueID vid)
        {
            if (m_fldSim != null)
            {
                if (vid == ValueID.BPP_SP_DEFENCE)
                {
                    return m_fldSim.CheckEffect(EffectType.EFF_WONDERROOM) ? ValueID.BPP_DEFENCE : ValueID.BPP_SP_DEFENCE;
                }
                else if (vid == ValueID.BPP_DEFENCE)
                {
                    return m_fldSim.CheckEffect(EffectType.EFF_WONDERROOM) ? ValueID.BPP_SP_DEFENCE : ValueID.BPP_DEFENCE;
                }
            }
            return vid;
        }

        public bool IsHPFull() { return m_coreParam.hp == m_coreParam.hpMax; }

        public bool IsDead() { return m_coreParam.hp == 0; }

        public bool IsFightEnable()
        {
            if (m_coreParam.ppSrc.IsEgg(EggCheckType.BOTH_EGG))
                return false;
            return m_coreParam.hp != 0;
        }

        public bool CheckSick(WazaSick sickType)
        {
            return (m_coreParam.sickCont[(int)sickType].raw & 7) != 0;
        }

        public bool CheckNemuri(NemuriCheckMode checkMode)
        {
            if (checkMode == NemuriCheckMode.NEMURI_CHECK_INCLUDE_ZETTAINEMURI &&
                GetValue(ValueID.BPP_TOKUSEI_EFFECTIVE) == 0xd5)
                return true;
            return (m_coreParam.sickCont[(int)WazaSick.WAZASICK_NEMURI].raw & 7) != 0;
        }

        public bool CheckMoudoku()
        {
            if (!CheckSick(WazaSick.WAZASICK_DOKU))
                return false;
            return SICKCONT.IsMoudokuCont(m_coreParam.sickCont[(int)WazaSick.WAZASICK_DOKU]);
        }

        public WazaNo GetWazaLockID()
        {
            BTL_SICKCONT cont = m_coreParam.sickCont[(int)WazaSick.WAZASICK_ENCORE];
            uint type = (uint)(cont.raw & 7);
            if (type != 1 && type != 2)
                return WazaNo.NULL;
            return (WazaNo)((cont.raw >> 14) & 0xffff);
        }

        private void clearWazaSickWork(uint clearCode)
        {
            int start = 0;
            if ((clearCode & 2) != 0)
                start = SICK_ID;
            BTL_SICKCONT savedSleep = m_coreParam.sickCont[(int)WazaSick.WAZASICK_NEMURI];
            byte savedSleepCounter = m_coreParam.wazaSickCounter[(int)WazaSick.WAZASICK_NEMURI];
            for (int i = start; i < m_coreParam.sickCont.Length; i++)
            {
                m_coreParam.sickCont[i] = default;
            }
            for (int i = 0; i < m_coreParam.wazaSickCounter.Length; i++)
                m_coreParam.wazaSickCounter[i] = 0;
            if ((clearCode & 1) == 0)
                return;
            m_coreParam.sickCont[(int)WazaSick.WAZASICK_NEMURI] = savedSleep;
            m_coreParam.wazaSickCounter[(int)WazaSick.WAZASICK_NEMURI] = savedSleepCounter;
        }

        public Sick GetPokeSick()
        {
            if ((m_coreParam.sickCont[(int)WazaSick.WAZASICK_MAHI].raw & 7) != 0) return Sick.MAHI;
            if ((m_coreParam.sickCont[(int)WazaSick.WAZASICK_NEMURI].raw & 7) != 0) return Sick.NEMURI;
            if ((m_coreParam.sickCont[(int)WazaSick.WAZASICK_KOORI].raw & 7) != 0) return Sick.KOORI;
            if ((m_coreParam.sickCont[(int)WazaSick.WAZASICK_YAKEDO].raw & 7) != 0) return Sick.YAKEDO;
            if ((m_coreParam.sickCont[(int)WazaSick.WAZASICK_DOKU].raw & 7) != 0) return Sick.DOKU;
            return Sick.NONE;
        }

        public ushort GetSickParam(WazaSick sick)
        {
            return SICKCONT.GetParam(m_coreParam.sickCont[(int)sick]);
        }

        public BTL_SICKCONT GetSickCont(WazaSick sick)
        {
            return m_coreParam.sickCont[(int)sick];
        }

        public byte GetSickTurnCount(WazaSick sick)
        {
            return m_coreParam.wazaSickCounter[(int)sick];
        }

        public bool IsSickLastTurn(WazaSick sickType)
        {
            BTL_SICKCONT cont = m_coreParam.sickCont[(int)sickType];
            if (SICKCONT.IsNull(cont))
                return false;
            byte turnMax = SICKCONT.GetTurnMax(cont);
            byte turnCount = m_coreParam.wazaSickCounter[(int)sickType];
            return (turnMax - turnCount) < 2;
        }

        public int CalcSickDamage(WazaSick sick)
        {
            if ((m_coreParam.sickCont[(int)sick].raw & 7) == 0)
                return 0;
            switch (sick)
            {
                case WazaSick.WAZASICK_YAKEDO:
                    return (int)calc.QuotMaxHP(this, 16, true);
                case WazaSick.WAZASICK_DOKU:
                    if (SICKCONT.IsMoudokuCont(m_coreParam.sickCont[(int)sick]))
                    {
                        int baseDmg = (int)calc.QuotMaxHP(this, 16, true);
                        return baseDmg * m_coreParam.wazaSickCounter[(int)sick];
                    }
                    return (int)calc.QuotMaxHP(this, 8, true);
                case WazaSick.WAZASICK_AKUMU:
                {
                    int tokID = GetValue(ValueID.BPP_TOKUSEI_EFFECTIVE);
                    if (tokID != 0xd5)
                    {
                        if (!CheckSick(WazaSick.WAZASICK_NEMURI))
                            return 0;
                    }
                    return (int)calc.QuotMaxHP(this, 4, true);
                }
                case WazaSick.WAZASICK_NOROI:
                    return (int)calc.QuotMaxHP(this, 4, true);
                default:
                    return 0;
            }
        }

        public WazaNo GetKodawariWazaID()
        {
            BTL_SICKCONT cont = m_coreParam.sickCont[(int)WazaSick.WAZASICK_KODAWARI];
            if (SICKCONT.IsNull(cont))
                return WazaNo.NULL;
            return (WazaNo)SICKCONT.GetParam(cont);
        }

        public bool IsTokuseiDisabledByKagakuHenkaGas()
        {
            if (m_fldSim != null &&
                !m_fldSim.CheckTokuseiEffectiveOnKagakuhenkaGas((TokuseiNo)m_tokusei))
            {
                return m_fldSim.IsKagakuhenkaGasEffective();
            }
            return false;
        }

        public void ReflectToPP(bool fDefaultForm)
        {
            bool fastMode = m_coreParam.ppSrc.StartFastMode();
            m_coreParam.ppSrc.SetHp(m_coreParam.hp);
            m_coreParam.ppSrc.SetItem(m_coreParam.item);
            if (fDefaultForm)
                m_coreParam.ppSrc.ChangeFormNo(m_coreParam.defaultFormNo);
            else
                m_coreParam.ppSrc.ChangeFormNo(m_formNo);
            wazaWork_ReflectToPP();
            m_coreParam.ppSrc.EndFastMode(fastMode);
        }

        private void wazaWork_UpdateNumber(WAZA_SET waza, WazaNo nextNumber, byte ppMax, bool fPermenent)
        {
            wazaCore_UpdateNumber(waza.surface, nextNumber, ppMax);
            if (fPermenent)
            {
                wazaCore_UpdateNumber(waza.truth, nextNumber, ppMax);
                waza.fLinked = true;
            }
            else
            {
                waza.fLinked = false;
            }
        }

        private void wazaCore_UpdateNumber(WAZA_CORE core, WazaNo nextID, byte ppMax)
        {
            core.number = nextID;
            core.pp = ppMax;
            core.ppMax = ppMax;
            core.ppCnt = 0;
        }

        private void clearHensin()
        {
            m_coreParam.fHensin = false;
        }

        private void clearUsedWazaFlag()
        {
            for (int i = 0; i < m_waza.Length; i++)
                wazaSet_ClearUsedFlag(m_waza[i]);
        }

        private void clearCounter()
        {
            for (int i = 0; i < m_counter.Length; i++)
                m_counter[i] = 0;
        }

        public byte WAZA_GetCount() { return m_wazaCnt; }

        public byte WAZA_GetCount_Org()
        {
            byte count = 0;
            for (int i = 0; i < m_wazaCnt; i++)
            {
                if (m_waza[i].truth.number != WazaNo.NULL)
                    count++;
            }
            return count;
        }

        public byte WAZA_GetUsedCountInAlive() { return m_usedWazaCount; }

        public byte WAZA_GetUsedCount()
        {
            byte count = 0;
            for (int i = 0; i < m_wazaCnt; i++)
            {
                if (m_waza[i].surface.usedFlag || m_waza[i].surface.usedFlagFix)
                    count++;
            }
            return count;
        }

        public byte WAZA_GetUsableCount()
        {
            byte count = 0;
            for (int i = 0; i < m_wazaCnt; i++)
            {
                if (m_waza[i].surface.number != WazaNo.NULL && m_waza[i].surface.pp > 0)
                    count++;
            }
            return count;
        }

        public WazaNo WAZA_GetID(byte idx) { return m_waza[idx].surface.number; }

        public WazaNo WAZA_GetID_Org(byte idx) { return m_waza[idx].truth.number; }

        public bool WAZA_CheckUsedInAlive(byte idx) { return m_waza[idx].surface.usedFlag || m_waza[idx].surface.usedFlagFix; }

        public void WAZA_Copy(BTL_POKEPARAM bppDst)
        {
            for (int i = 0; i < m_waza.Length; i++)
                bppDst.m_waza[i].CopyFrom(m_waza[i]);
            bppDst.m_wazaCnt = m_wazaCnt;
        }

        public byte WAZA_GetUsedCount(byte wazaIdx) { return m_waza[wazaIdx].surface.usedCount; }

        public void WAZA_SetUsedCount(byte wazaIdx, byte value) { m_waza[wazaIdx].surface.usedCount = value; }

        public byte WAZA_GetKillCount(byte wazaIdx) { return m_waza[wazaIdx].surface.killCount; }

        public void WAZA_SetKillCount(byte wazaIdx, byte value) { m_waza[wazaIdx].surface.killCount = value; }

        public byte WAZA_GetPPShort(byte idx) { return (byte)(m_waza[idx].surface.ppMax - m_waza[idx].surface.pp); }

        public byte WAZA_GetPPShort_Org(byte idx) { return (byte)(m_waza[idx].truth.ppMax - m_waza[idx].truth.pp); }

        public bool WAZA_CheckPPShortAny()
        {
            for (int i = 0; i < m_wazaCnt; i++)
            {
                if (m_waza[i].surface.number != WazaNo.NULL && m_waza[i].surface.pp < m_waza[i].surface.ppMax)
                    return true;
            }
            return false;
        }

        public bool WAZA_CheckPPShortAny_Org()
        {
            for (int i = 0; i < m_wazaCnt; i++)
            {
                if (m_waza[i].truth.number != WazaNo.NULL && m_waza[i].truth.pp < m_waza[i].truth.ppMax)
                    return true;
            }
            return false;
        }

        public ushort WAZA_GetPP(byte wazaIdx) { return m_waza[wazaIdx].surface.pp; }

        public ushort WAZA_GetPP_ByNumber(WazaNo waza)
        {
            for (int i = 0; i < m_wazaCnt; i++)
            {
                if (m_waza[i].surface.number == waza)
                    return m_waza[i].surface.pp;
            }
            return 0;
        }

        public ushort WAZA_GetPP_Org(byte wazaIdx) { return m_waza[wazaIdx].truth.pp; }

        public ushort WAZA_GetMaxPP(byte wazaIdx) { return m_waza[wazaIdx].surface.ppMax; }

        public ushort WAZA_GetMaxPP_Org(byte wazaIdx) { return m_waza[wazaIdx].truth.ppMax; }

        public bool WAZA_IsPPFull(byte wazaIdx, bool fOrg)
        {
            WAZA_CORE core = fOrg ? m_waza[wazaIdx].truth : m_waza[wazaIdx].surface;
            return core.pp >= core.ppMax;
        }

        public void WAZA_DecrementPP(byte wazaIdx, byte value)
        {
            if (m_waza[wazaIdx].surface.pp <= value)
                m_waza[wazaIdx].surface.pp = 0;
            else
                m_waza[wazaIdx].surface.pp -= value;
        }

        public void WAZA_DecrementPP_Org(byte wazaIdx, byte value)
        {
            if (m_waza[wazaIdx].truth.pp <= value)
                m_waza[wazaIdx].truth.pp = 0;
            else
                m_waza[wazaIdx].truth.pp -= value;
        }

        public void WAZA_SetUsedFlag_Org(byte wazaIdx) { m_waza[wazaIdx].truth.usedFlagFix = true; }

        public WazaNo WAZA_IncrementPP(byte wazaIdx, byte value)
        {
            WAZA_CORE core = m_waza[wazaIdx].surface;
            core.pp = (byte)System.Math.Min(core.pp + value, core.ppMax);
            return core.number;
        }

        public WazaNo WAZA_IncrementPP_Org(byte wazaIdx, byte value)
        {
            WAZA_CORE core = m_waza[wazaIdx].truth;
            core.pp = (byte)System.Math.Min(core.pp + value, core.ppMax);
            return core.number;
        }

        public bool WAZA_IsLinkOut(byte wazaIdx) { return !m_waza[wazaIdx].fLinked; }

        public void WAZA_SetUsedFlag(byte wazaIdx) { m_waza[wazaIdx].surface.usedFlag = true; }

        public void WAZA_UpdateID(byte wazaIdx, WazaNo waza, byte ppMax, bool fPermenent)
        {
            wazaWork_UpdateNumber(m_waza[wazaIdx], waza, ppMax, fPermenent);
        }

        public bool WAZA_IsUsable(WazaNo waza)
        {
            for (int i = 0; i < m_wazaCnt; i++)
            {
                if (m_waza[i].surface.number == waza && m_waza[i].surface.pp > 0)
                    return true;
            }
            return false;
        }

        public byte WAZA_SearchIdx(WazaNo waza)
        {
            for (byte i = 0; i < m_wazaCnt; i++)
            {
                if (m_waza[i].surface.number == waza)
                    return i;
            }
            return m_wazaCnt;
        }

        private void splitTypeCore(out byte type1, out byte type2)
        {
            bool sickActive = (m_coreParam.sickCont[(int)WazaSick.WAZASICK_HANEYASUME].raw & 7) != 0;
            byte t1 = m_baseParam.type1;
            byte t2 = m_baseParam.type2;
            if (sickActive && t1 == (byte)PokeType.HIKOU) t1 = (byte)PokeType.NULL;
            if (sickActive && t2 == (byte)PokeType.HIKOU) t2 = (byte)PokeType.NULL;
            if (CONTFLAG_Get(ContFlag.CONTFLG_MOETUKIRU))
            {
                if (t1 == 0x12)
                {
                    if (t2 != 0x12)
                        t1 = t2;
                }
                else if (t2 == 0x12)
                {
                    t2 = t1;
                }
            }
            else
            {
                if (t1 == 0x12)
                {
                    if (t2 == 0x12)
                    {
                        t1 = 0;
                        t2 = 0;
                    }
                    else
                    {
                        t1 = t2;
                    }
                }
                else if (t2 == 0x12)
                {
                    t2 = t1;
                }
            }
            type1 = t1;
            type2 = t2;
        }

        public PokeTypePair GetPokeType()
        {
            splitTypeCore(out byte t1, out byte t2);
            return PokeTypePair.Make(t1, t2, m_baseParam.type_ex);
        }

        public byte GetOriginalPokeType1() { return m_baseParam.type1; }

        public byte GetOriginalPokeType2() { return m_baseParam.type2; }

        public bool IsMatchType(byte type)
        {
            splitTypeCore(out byte t1, out byte t2);
            return t1 == type || t2 == type || m_baseParam.type_ex == type;
        }

        public void SetBaseStatus(ValueID vid, ushort value)
        {
            ValueID convertedVid = vid;
            if (m_fldSim != null)
                convertedVid = convertValueID(vid);
            switch (convertedVid)
            {
                case ValueID.BPP_ATTACK: m_baseParam.attack = value; break;
                case ValueID.BPP_DEFENCE: m_baseParam.defence = value; break;
                case ValueID.BPP_SP_ATTACK: m_baseParam.sp_attack = value; break;
                case ValueID.BPP_SP_DEFENCE: m_baseParam.sp_defence = value; break;
                case ValueID.BPP_AGILITY: m_baseParam.agility = value; break;
            }
        }

        public int GetValue_Critical(ValueID vid)
        {
            ValueID convertedVid = vid;
            if (m_fldSim != null)
                convertedVid = convertValueID(vid);
            sbyte rank;
            switch (convertedVid)
            {
                case ValueID.BPP_ATTACK: rank = m_varyParam.attack; break;
                case ValueID.BPP_DEFENCE: rank = m_varyParam.defence; break;
                case ValueID.BPP_SP_ATTACK: rank = m_varyParam.sp_attack; break;
                case ValueID.BPP_SP_DEFENCE: rank = m_varyParam.sp_defence; break;
                default: return GetValue(convertedVid);
            }
            if (rank < RANK_STATUS_DEFAULT)
                return GetValue_Base(convertedVid);
            return GetValue(convertedVid);
        }

        public ushort GetItem() { return m_coreParam.item; }

        public void SetItem(ushort itemID) { m_coreParam.item = itemID; }

        public ushort GetItemEffective(in FieldStatus fldSim)
        {
            if (fldSim.CheckEffect(EffectType.EFF_MAGICROOM))
                return 0;
            if (CheckSick(WazaSick.WAZASICK_SASIOSAE))
                return 0;
            if (GetValue(ValueID.BPP_TOKUSEI_EFFECTIVE) == 0x67)
                return 0;
            return m_coreParam.item;
        }

        public ushort GetTotalTurnCount() { return m_coreParam.totalTurnCount; }

        public void IncTotalTurnCount() { m_coreParam.totalTurnCount++; }

        public ushort GetTurnCount() { return m_turnCount; }

        public ushort GetAppearTurn() { return m_appearedTurn; }

        public bool TURNFLAG_Get(TurnFlag flagID) { return flgbuf_get(m_turnFlag, (uint)flagID); }

        public bool CONTFLAG_Get(ContFlag flagID) { return flgbuf_get(m_contFlag, (uint)flagID); }

        public bool PERMFLAG_Get(PermFlag flagID) { return flgbuf_get(m_permFlag, (uint)flagID); }

        public void PERMFLAG_Set(PermFlag flagID) { flgbuf_set(m_permFlag, (uint)flagID); }

        public ContFlag CONTFLAG_CheckWazaHide()
        {
            for (int i = 0; i < WAZAHIDE_FLAGS.Length; i++)
            {
                if (flgbuf_get(m_contFlag, (uint)WAZAHIDE_FLAGS[i]))
                    return WAZAHIDE_FLAGS[i];
            }
            return ContFlag.CONTFLG_MAX;
        }

        public bool IsWazaHide() { return CONTFLAG_CheckWazaHide() != ContFlag.CONTFLG_MAX; }

        public bool IsUsingFreeFall()
        {
            byte counter = m_counter[(int)Counter.COUNTER_FREEFALL];
            if (counter == 0)
                return false;
            byte pokeID = FreeFallCounterToPokeID(counter);
            return pokeID != 0x1f && pokeID < 0x1e;
        }

        public int GetHPRatio()
        {
            return FX32.CONST((double)(m_coreParam.hp * 100) / (double)m_coreParam.hpMax);
        }

        public void SetHPRatio(int ratio)
        {
            m_coreParam.hp = (ushort)calcHpRatio(m_coreParam.hpMax, ratio);
        }

        public uint calcHpRatio(uint maxHP, int ratio)
        {
            uint result = calc.MulRatio(maxHP, ratio);
            uint quotient = result / 100;
            if (result % 100 != 0)
                quotient++;
            if (FX32.ToFloat(ratio) != 0.0 && quotient == 0)
                quotient = 1;
            return quotient;
        }

        private uint getHPBeforeG()
        {
            if (!m_coreParam.gParam.isGMode)
                return m_coreParam.hp;
            int ratio = FX32.CONST((double)(m_coreParam.hp * 100) / (double)m_coreParam.hpMax);
            return calcHpRatio((uint)GetValue(ValueID.BPP_MAX_HP_BEFORE_G), ratio);
        }

        private sbyte getRankVaryStatus(ValueID type, out sbyte min, out sbyte max)
        {
            min = RANK_STATUS_MIN;
            max = RANK_STATUS_MAX;
            switch (type)
            {
                case ValueID.BPP_ATTACK_RANK: return m_varyParam.attack;
                case ValueID.BPP_DEFENCE_RANK: return m_varyParam.defence;
                case ValueID.BPP_SP_ATTACK_RANK: return m_varyParam.sp_attack;
                case ValueID.BPP_SP_DEFENCE_RANK: return m_varyParam.sp_defence;
                case ValueID.BPP_AGILITY_RANK: return m_varyParam.agility;
                case ValueID.BPP_HIT_RATIO: return m_varyParam.hit;
                case ValueID.BPP_AVOID_RATIO: return m_varyParam.avoid;
                default: return 0;
            }
        }

        public bool IsRankEffectValid(ValueID rankType, int volume)
        {
            sbyte rank = getRankVaryStatus(rankType, out _, out _);
            if (volume > 0)
                return rank < RANK_STATUS_MAX;
            return rank > RANK_STATUS_MIN;
        }

        public int RankEffectUpLimit(ValueID rankType)
        {
            sbyte rank = getRankVaryStatus(rankType, out _, out _);
            return RANK_STATUS_MAX - rank;
        }

        public int RankEffectDownLimit(ValueID rankType)
        {
            sbyte rank = getRankVaryStatus(rankType, out _, out _);
            return rank;
        }

        public bool IsRankEffectDowned()
        {
            return m_varyParam.attack < RANK_STATUS_DEFAULT ||
                   m_varyParam.defence < RANK_STATUS_DEFAULT ||
                   m_varyParam.sp_attack < RANK_STATUS_DEFAULT ||
                   m_varyParam.sp_defence < RANK_STATUS_DEFAULT ||
                   m_varyParam.agility < RANK_STATUS_DEFAULT ||
                   m_varyParam.hit < RANK_STATUS_DEFAULT ||
                   m_varyParam.avoid < RANK_STATUS_DEFAULT;
        }

        public byte RankUp(ValueID rankType, byte volume)
        {
            switch (rankType)
            {
                case ValueID.BPP_ATTACK_RANK: return RankUp_Core(volume, ref m_varyParam.attack);
                case ValueID.BPP_DEFENCE_RANK: return RankUp_Core(volume, ref m_varyParam.defence);
                case ValueID.BPP_SP_ATTACK_RANK: return RankUp_Core(volume, ref m_varyParam.sp_attack);
                case ValueID.BPP_SP_DEFENCE_RANK: return RankUp_Core(volume, ref m_varyParam.sp_defence);
                case ValueID.BPP_AGILITY_RANK: return RankUp_Core(volume, ref m_varyParam.agility);
                case ValueID.BPP_HIT_RATIO: return RankUp_Core(volume, ref m_varyParam.hit);
                case ValueID.BPP_AVOID_RATIO: return RankUp_Core(volume, ref m_varyParam.avoid);
                default: return 0;
            }
        }

        private byte RankUp_Core(byte volume, ref sbyte ptr)
        {
            if (ptr >= RANK_STATUS_MAX) return 0;
            if (ptr + volume > RANK_STATUS_MAX)
                volume = (byte)(RANK_STATUS_MAX - ptr);
            ptr = (sbyte)(ptr + volume);
            return volume;
        }

        public byte RankDown(ValueID rankType, byte volume)
        {
            switch (rankType)
            {
                case ValueID.BPP_ATTACK_RANK: return RankDown_Core(volume, ref m_varyParam.attack);
                case ValueID.BPP_DEFENCE_RANK: return RankDown_Core(volume, ref m_varyParam.defence);
                case ValueID.BPP_SP_ATTACK_RANK: return RankDown_Core(volume, ref m_varyParam.sp_attack);
                case ValueID.BPP_SP_DEFENCE_RANK: return RankDown_Core(volume, ref m_varyParam.sp_defence);
                case ValueID.BPP_AGILITY_RANK: return RankDown_Core(volume, ref m_varyParam.agility);
                case ValueID.BPP_HIT_RATIO: return RankDown_Core(volume, ref m_varyParam.hit);
                case ValueID.BPP_AVOID_RATIO: return RankDown_Core(volume, ref m_varyParam.avoid);
                default: return 0;
            }
        }

        private byte RankDown_Core(byte volume, ref sbyte ptr)
        {
            if (ptr <= RANK_STATUS_MIN) return 0;
            byte actual = (byte)System.Math.Min(volume, ptr);
            ptr = (sbyte)(ptr - actual);
            return actual;
        }

        public void RankSet(ValueID rankType, byte value)
        {
            switch (rankType)
            {
                case ValueID.BPP_ATTACK_RANK: RankSet_Core(value, ref m_varyParam.attack); break;
                case ValueID.BPP_DEFENCE_RANK: RankSet_Core(value, ref m_varyParam.defence); break;
                case ValueID.BPP_SP_ATTACK_RANK: RankSet_Core(value, ref m_varyParam.sp_attack); break;
                case ValueID.BPP_SP_DEFENCE_RANK: RankSet_Core(value, ref m_varyParam.sp_defence); break;
                case ValueID.BPP_AGILITY_RANK: RankSet_Core(value, ref m_varyParam.agility); break;
                case ValueID.BPP_HIT_RATIO: RankSet_Core(value, ref m_varyParam.hit); break;
                case ValueID.BPP_AVOID_RATIO: RankSet_Core(value, ref m_varyParam.avoid); break;
            }
        }

        private void RankSet_Core(byte value, ref sbyte ptr)
        {
            if (value <= RANK_STATUS_MAX)
                ptr = (sbyte)value;
        }

        public bool RankRecover() { return effrank_Recover(m_varyParam); }

        public void RankReset() { effrank_Reset(m_varyParam); }

        public bool RankUpReset() { return effrank_ResetRankUp(m_varyParam); }

        public byte GetCriticalRank()
        {
            byte rank = m_criticalRank;
            if (CONTFLAG_Get(ContFlag.CONTFLG_KIAIDAME))
                rank += 2;
            if (CheckSick(WazaSick.WAZASICK_TOGISUMASU))
                rank += 3;
            if (rank > 3) rank = 3;
            return rank;
        }

        public byte GetCriticalRankPure() { return m_criticalRank; }

        public bool AddCriticalRank(int value)
        {
            if (value > 0)
            {
                if (m_criticalRank >= 3) return false;
                int result = m_criticalRank + value;
                m_criticalRank = (byte)(result > 3 ? 3 : result);
                return true;
            }
            else if (value < 0)
            {
                if (m_criticalRank == 0) return false;
                if (-value >= m_criticalRank)
                    m_criticalRank = 0;
                else
                    m_criticalRank = (byte)(m_criticalRank + value);
                return true;
            }
            return false;
        }

        public void SetCriticalRank(byte rank) { m_criticalRank = rank; }

        public void HpMinus(ushort value)
        {
            if (value >= m_coreParam.hp)
                m_coreParam.hp = 0;
            else
                m_coreParam.hp = (ushort)(m_coreParam.hp - value);
        }

        public void HpPlus(ushort value)
        {
            m_coreParam.hp = (ushort)(m_coreParam.hp + value);
            if (m_coreParam.hp > m_coreParam.hpMax)
                m_coreParam.hp = m_coreParam.hpMax;
        }

        public void HpZero() { m_coreParam.hp = 0; }

        public void TURNFLAG_Set(TurnFlag flagID) { flgbuf_set(m_turnFlag, (uint)flagID); }

        public void CONTFLAG_Set(ContFlag flagID) { flgbuf_set(m_contFlag, (uint)flagID); }

        public void CONTFLAG_Clear(ContFlag flagID) { flgbuf_reset(m_contFlag, (uint)flagID); }

        public void SetWazaSick(WazaSick sick, in BTL_SICKCONT contParam)
        {
            m_coreParam.sickCont[(int)sick] = contParam;
            m_coreParam.wazaSickCounter[(int)sick] = 0;
        }

        public bool WazaSick_TurnCheck(WazaSick sick, out BTL_SICKCONT pOldContDest, out bool fCured)
        {
            pOldContDest = m_coreParam.sickCont[(int)sick];
            fCured = false;
            if (SICKCONT.IsNull(pOldContDest))
                return false;
            m_coreParam.wazaSickCounter[(int)sick]++;
            byte turnMax = SICKCONT.GetTurnMax(pOldContDest);
            if (turnMax != 0 && m_coreParam.wazaSickCounter[(int)sick] >= turnMax)
            {
                CureWazaSick(sick);
                fCured = true;
            }
            return true;
        }

        public bool CheckNemuriWakeUp()
        {
            BTL_SICKCONT cont = m_coreParam.sickCont[(int)WazaSick.WAZASICK_NEMURI];
            if (SICKCONT.IsNull(cont))
                return false;
            byte turnMax = SICKCONT.GetTurnMax(cont);
            return turnMax != 0 && m_coreParam.wazaSickCounter[(int)WazaSick.WAZASICK_NEMURI] >= turnMax;
        }

        public bool CheckKonranWakeUp()
        {
            BTL_SICKCONT cont = m_coreParam.sickCont[(int)WazaSick.WAZASICK_KONRAN];
            if (SICKCONT.IsNull(cont))
                return false;
            byte turnMax = SICKCONT.GetTurnMax(cont);
            return turnMax != 0 && m_coreParam.wazaSickCounter[(int)WazaSick.WAZASICK_KONRAN] >= turnMax;
        }

        public void CurePokeSick()
        {
            for (int i = 1; i <= 5; i++)
            {
                if ((m_coreParam.sickCont[i].raw & 7) != 0)
                {
                    cureDependSick((WazaSick)i);
                    m_coreParam.sickCont[i] = default;
                    m_coreParam.wazaSickCounter[i] = 0;
                    break;
                }
            }
        }

        private void cureDependSick(WazaSick sickID)
        {
            if (sickID == WazaSick.WAZASICK_NEMURI)
                m_coreParam.sickCont[(int)WazaSick.WAZASICK_AKUMU] = default;
        }

        public void CureWazaSick(WazaSick sick)
        {
            cureDependSick(sick);
            m_coreParam.sickCont[(int)sick] = default;
            m_coreParam.wazaSickCounter[(int)sick] = 0;
        }

        public void CureWazaSickDependPoke(byte depend_pokeID)
        {
            for (int i = 0; i < m_coreParam.sickCont.Length; i++)
            {
                BTL_SICKCONT cont = m_coreParam.sickCont[i];
                if ((cont.raw & 7) != 0)
                {
                    byte causePokeID = (byte)((cont.raw >> 3) & 0x1f);
                    if (causePokeID == depend_pokeID)
                    {
                        m_coreParam.sickCont[i] = default;
                        m_coreParam.wazaSickCounter[i] = 0;
                    }
                }
            }
        }

        public void SetAppearTurn(ushort turn) { m_appearedTurn = turn; }

        public void TurnCheck()
        {
            flgbuf_clear(m_turnFlag);
            m_turnCount++;
            dmgrec_FwdTurn();
        }

        public void TURNFLAG_ForceOff(TurnFlag flagID) { flgbuf_reset(m_turnFlag, (uint)flagID); }

        public void Clear_ForDead()
        {
            clearWazaSickWork((uint)SickWorkClearCode.SICKWORK_CLEAR_ALL);
            flgbuf_clear(m_contFlag);
            clearCounter();
            m_migawariHP = 0;
            m_criticalRank = 0;
            effrank_Reset(m_varyParam);
            clearUsedWazaFlag();
            wazaWork_ClearSurface();
        }

        public void Clear_ForOut()
        {
            clearWazaSickWork((uint)SickWorkClearCode.SICKWORK_CLEAR_ONLY_WAZASICK);
            flgbuf_clear(m_contFlag);
            clearCounter();
            m_migawariHP = 0;
            m_criticalRank = 0;
            effrank_Reset(m_varyParam);
            clearUsedWazaFlag();
            wazaWork_ClearSurface();
            m_usedWazaCount = 0;
            if (!m_coreParam.fDontResetFormByByOut)
            {
                if (m_coreParam.fHensin)
                    clearHensin();
            }
        }

        public void Clear_ForIn()
        {
            m_coreParam.fBtlIn = true;
            flgbuf_clear(m_turnFlag);
            m_turnCount = 0;
            m_prevWazaType = 0x12;
            m_prevActWazaID = WazaNo.NULL;
            m_prevSelectWazaID = WazaNo.NULL;
            m_prevDamagedWaza = WazaNo.NULL;
            m_prevTargetPos = 0;
            m_wazaContCounter = 0;
            dmgrec_ClearWork();
            confrontRec_Clear();
            resetSpActPriority();
        }

        public void CopyBatonTouchParams(BTL_POKEPARAM user)
        {
            m_varyParam.CopyFrom(user.m_varyParam);
            for (int i = SICK_ID; i < m_coreParam.sickCont.Length; i++)
            {
                if (CONTFLAG_Get(ContFlag.CONTFLG_BATONTOUCH))
                {
                    m_coreParam.sickCont[i] = user.m_coreParam.sickCont[i];
                    m_coreParam.wazaSickCounter[i] = user.m_coreParam.wazaSickCounter[i];
                }
            }
            for (int i = 0; i < m_contFlag.Length; i++)
                m_contFlag[i] = user.m_contFlag[i];
            m_criticalRank = user.m_criticalRank;
            m_migawariHP = user.m_migawariHP;
        }

        public bool ChangePokeType(PokeTypePair type, ExTypeCause exTypeCause)
        {
            byte t1 = PokeTypePair.GetType1(type);
            byte t2 = PokeTypePair.GetType2(type);
            if (m_baseParam.type1 == t1 && m_baseParam.type2 == t2)
                return false;
            m_baseParam.type1 = t1;
            m_baseParam.type2 = t2;
            m_baseParam.type_ex = 0x12;
            m_baseParam.type_ex_cause = exTypeCause;
            return true;
        }

        public void ExPokeType(byte type, ExTypeCause exTypeCause)
        {
            m_baseParam.type_ex = type;
            m_baseParam.type_ex_cause = exTypeCause;
        }

        public byte GetExType() { return m_baseParam.type_ex; }

        public bool HaveExType() { return m_baseParam.type_ex != 0x12; }

        public ExTypeCause GetExTypeCause() { return m_baseParam.type_ex_cause; }

        public void ChangeTokusei(TokuseiNo tok) { m_tokusei = (ushort)tok; }

        public void ChangeForm(byte formNo, bool dontResetFormByOut = false)
        {
            m_formNo = formNo;
            m_coreParam.ppSrc.ChangeFormNo(formNo);
            m_coreParam.fDontResetFormByByOut = dontResetFormByOut;
            setupBySrcData(false, true, false, true);
            correctMaxHP();
        }

        private void correctMaxHP()
        {
            ushort newMax = getBasePower(PowerID.HP, m_coreParam.gParam.isGMode);
            if (newMax != m_coreParam.hpMax)
            {
                if (m_coreParam.hp > newMax)
                    m_coreParam.hp = newMax;
                m_coreParam.hpMax = newMax;
            }
        }

        public void RemoveItem() { m_coreParam.item = 0; }

        public void ConsumeItem(ushort itemID)
        {
            m_coreParam.item = 0;
            m_coreParam.usedItem = itemID;
        }

        public void ClearConsumedItem() { m_coreParam.usedItem = 0; }

        public ushort GetConsumedItem() { return m_coreParam.usedItem; }

        public void UpdateWazaProcResult(BtlPokePos actTargetPos, byte actWazaType, bool fActEnable, WazaNo actWaza, WazaNo orgWaza)
        {
            if (fActEnable && m_prevActWazaID == actWaza)
                m_wazaContCounter++;
            else
                m_wazaContCounter = 0;
            m_prevTargetPos = actTargetPos;
            m_prevWazaType = actWazaType;
            m_prevActWazaID = fActEnable ? actWaza : WazaNo.NULL;
            m_prevSelectWazaID = orgWaza;
            if (fActEnable)
                m_usedWazaCount++;
        }

        public uint GetWazaContCounter() { return m_wazaContCounter; }

        public WazaNo GetPrevWazaID() { return m_prevActWazaID; }

        public byte GetPrevWazaType() { return m_prevWazaType; }

        public WazaNo GetPrevOrgWazaID() { return m_prevSelectWazaID; }

        public BtlPokePos GetPrevTargetPos() { return m_prevTargetPos; }

        public bool GetBtlInFlag() { return m_coreParam.fBtlIn; }

        public void SetWeight(ushort weight) { m_weight = weight; }

        public ushort GetWeight() { return m_weight; }

        public void WAZADMGREC_Add(WAZADMG_REC rec)
        {
            byte count = m_dmgrecCount[m_dmgrecTurnPtr];
            if (count < WAZADMG_REC_MAX)
            {
                m_wazaDamageRec[m_dmgrecTurnPtr][count].CopyFrom(rec);
                m_dmgrecCount[m_dmgrecTurnPtr]++;
            }
        }

        public byte WAZADMGREC_GetCount(byte turn_ridx)
        {
            int idx = m_dmgrecTurnPtr - turn_ridx;
            if (idx < 0) idx += WAZADMG_REC_TURN_MAX;
            return m_dmgrecCount[idx];
        }

        public bool WAZADMGREC_Get(byte turn_ridx, byte rec_ridx, WAZADMG_REC dst)
        {
            int idx = m_dmgrecTurnPtr - turn_ridx;
            if (idx < 0) idx += WAZADMG_REC_TURN_MAX;
            if (rec_ridx >= m_dmgrecCount[idx])
                return false;
            dst.CopyFrom(m_wazaDamageRec[idx][rec_ridx]);
            return true;
        }

        public void COUNTER_Set(Counter cnt, byte value) { m_counter[(int)cnt] = value; }

        public void COUNTER_Inc(Counter cnt) { m_counter[(int)cnt]++; }

        public byte COUNTER_Get(Counter cnt) { return m_counter[(int)cnt]; }

        public void PERMCOUNTER_Set(PermCounter counter, uint value) { m_permCounter[(int)counter] = value; }

        public void PERMCOUNTER_Add(PermCounter counter, uint value)
        {
            m_permCounter[(int)counter] += value;
            if (m_permCounter[(int)counter] > PERMCOUNTER_MAX)
                m_permCounter[(int)counter] = PERMCOUNTER_MAX;
        }

        public void PERMCOUNTER_Inc(PermCounter counter)
        {
            if (m_permCounter[(int)counter] < PERMCOUNTER_MAX)
                m_permCounter[(int)counter]++;
        }

        public uint PERMCOUNTER_Get(PermCounter counter) { return m_permCounter[(int)counter]; }

        public bool AddExp(uint exp)
        {
            m_coreParam.exp += exp;
            m_coreParam.ppSrc.SetExp(m_coreParam.exp);
            return true;
        }

        public uint GetExpMargin()
        {
            uint nextLvExp = m_coreParam.ppSrc.GetExpForNextLevel();
            uint curExp = m_coreParam.ppSrc.GetExp();
            if (nextLvExp <= curExp) return 0;
            return nextLvExp - curExp;
        }

        public void ReflectByPP()
        {
            bool fastMode = m_coreParam.ppSrc.StartFastMode();
            setupBySrcData(true, true, true, true);
            wazaWork_ReflectFromPP();
            m_coreParam.ppSrc.EndFastMode(fastMode);
        }

        public bool IsFakeEnable() { return m_coreParam.fFakeEnable; }

        public void FakeDisable() { m_coreParam.fFakeEnable = false; }

        public byte GetFakeTargetPokeID() { return m_coreParam.fakeViewTargetPokeId; }

        public bool HENSIN_CheckEnable(BTL_POKEPARAM target)
        {
            if (m_coreParam.fHensin) return false;
            if (target.m_coreParam.fHensin) return false;
            return true;
        }

        public void HENSIN_Set(BTL_POKEPARAM target)
        {
            m_coreParam.fHensin = true;
            henshinCopyFrom(target);
            m_tokusei = target.m_tokusei;
            m_formNo = target.m_formNo;
            m_wazaCnt = target.m_wazaCnt;
            for (int i = 0; i < m_waza.Length; i++)
            {
                if (HENSIN_Set_wazaWork == null)
                    HENSIN_Set_wazaWork = new WAZA_SET[4] { new WAZA_SET(), new WAZA_SET(), new WAZA_SET(), new WAZA_SET() };
                m_waza[i].CopyFrom(target.m_waza[i]);
                for (int j = 0; j < m_wazaCnt; j++)
                {
                    m_waza[j].truth.pp = 5;
                    m_waza[j].truth.ppMax = 5;
                    m_waza[j].surface.pp = 5;
                    m_waza[j].surface.ppMax = 5;
                }
            }
            updateWeight();
        }

        private void henshinCopyFrom(in BTL_POKEPARAM src)
        {
            m_baseParam.CopyFrom(src.m_baseParam);
            m_varyParam.CopyFrom(src.m_varyParam);
            m_tokusei = src.m_tokusei;
            m_weight = src.m_weight;
            m_wazaCnt = src.m_wazaCnt;
            m_formNo = src.m_formNo;
            m_friendship = src.m_friendship;
            m_criticalRank = src.m_criticalRank;
            m_usedWazaCount = src.m_usedWazaCount;
            m_prevWazaType = src.m_prevWazaType;
            m_turnCount = src.m_turnCount;
            m_appearedTurn = src.m_appearedTurn;
            m_wazaContCounter = src.m_wazaContCounter;
            m_prevTargetPos = src.m_prevTargetPos;
            m_prevActWazaID = src.m_prevActWazaID;
            m_prevSelectWazaID = src.m_prevSelectWazaID;
            m_prevDamagedWaza = src.m_prevDamagedWaza;
            m_dmgrecTurnPtr = src.m_dmgrecTurnPtr;
            m_dmgrecPtr = src.m_dmgrecPtr;
            m_migawariHP = src.m_migawariHP;
            m_combiWazaID = src.m_combiWazaID;
            m_combiPokeID = src.m_combiPokeID;
            for (int i = 0; i < m_waza.Length; i++)
                m_waza[i].CopyFrom(src.m_waza[i]);
            for (int i = 0; i < m_turnFlag.Length; i++)
                m_turnFlag[i] = src.m_turnFlag[i];
            for (int i = 0; i < m_contFlag.Length; i++)
                m_contFlag[i] = src.m_contFlag[i];
            for (int i = 0; i < m_counter.Length; i++)
                m_counter[i] = src.m_counter[i];
            for (int i = 0; i < m_permCounter.Length; i++)
                m_permCounter[i] = src.m_permCounter[i];
            for (int t = 0; t < WAZADMG_REC_TURN_MAX; t++)
            {
                for (int r = 0; r < WAZADMG_REC_MAX; r++)
                    m_wazaDamageRec[t][r].CopyFrom(src.m_wazaDamageRec[t][r]);
            }
            for (int i = 0; i < m_dmgrecCount.Length; i++)
                m_dmgrecCount[i] = src.m_dmgrecCount[i];
        }

        public bool HENSIN_Check() { return m_coreParam.fHensin; }

        public void MIGAWARI_Create(ushort migawariHP) { m_migawariHP = migawariHP; }

        public void MIGAWARI_Delete() { m_migawariHP = 0; }

        public bool MIGAWARI_IsExist() { return m_migawariHP > 0; }

        public uint MIGAWARI_GetHP() { return m_migawariHP; }

        public bool MIGAWARI_AddDamage(ref ushort damage)
        {
            if (m_migawariHP == 0) return false;
            if (damage >= m_migawariHP)
            {
                damage = m_migawariHP;
                m_migawariHP = 0;
            }
            else
            {
                m_migawariHP = (ushort)(m_migawariHP - damage);
            }
            return true;
        }

        public void CONFRONT_REC_Set(byte pokeID) { Confront_Set(pokeID); }

        public byte CONFRONT_REC_GetCount() { return Confront_GetCount(); }

        public byte CONFRONT_REC_GetPokeID(byte idx) { return Confront_GetPokeID(idx); }

        public bool CONFRONT_REC_IsMatch(byte pokeID)
        {
            for (int i = 0; i < m_coreParam.confrontRecCount; i++)
            {
                if (m_coreParam.confrontRec[i] == pokeID)
                    return true;
            }
            return false;
        }

        public void SetCaptureBallID(ushort ballItemID)
        {
            m_coreParam.ppSrc.SetGetBall(ballItemID);
        }

        public void CombiWaza_SetParam(byte combiPokeID, WazaNo combiUsedWaza)
        {
            m_combiPokeID = combiPokeID;
            m_combiWazaID = combiUsedWaza;
        }

        public bool CombiWaza_GetParam(out byte combiPokeID, out WazaNo combiUsedWaza)
        {
            combiPokeID = m_combiPokeID;
            combiUsedWaza = m_combiWazaID;
            return m_combiWazaID != WazaNo.NULL;
        }

        public bool CombiWaza_IsSetParam() { return m_combiWazaID != WazaNo.NULL; }

        public void CombiWaza_ClearParam()
        {
            m_combiPokeID = 0x1f;
            m_combiWazaID = WazaNo.NULL;
        }

        public bool IsMatchTokusei(TokuseiNo tokusei) { return m_tokusei == (ushort)tokusei; }

        public bool HavePokerus() { return m_doryokuParam.bPokerus; }

        public void AddEffortPower(PowerID id, byte value)
        {
            doryoku_AddPower(m_doryokuParam, id, value);
            doryoku_PutToPP(m_doryokuParam, m_coreParam.ppSrc);
        }

        private void doryoku_InitParam(DORYOKU_PARAM work, PokemonParam pp)
        {
            work.srcHp = (byte)pp.GetEffortPower(PowerID.HP);
            work.srcPow = (byte)pp.GetEffortPower(PowerID.ATK);
            work.srcDef = (byte)pp.GetEffortPower(PowerID.DEF);
            work.srcAgi = (byte)pp.GetEffortPower(PowerID.AGI);
            work.srcSpPow = (byte)pp.GetEffortPower(PowerID.SPATK);
            work.srcSpDef = (byte)pp.GetEffortPower(PowerID.SPDEF);
            work.srcSum = (ushort)(work.srcHp + work.srcPow + work.srcDef + work.srcAgi + work.srcSpPow + work.srcSpDef);
            work.srcG = 0;
            work.bPokerus = pp.HavePokerusJustNow();
            work.bModified = false;
        }

        private void doryoku_AddPower(DORYOKU_PARAM work, PowerID powID, byte value)
        {
            ref byte target = ref doryoku_ParamIDtoValueAdrs(work, powID);
            int newVal = target + value;
            if (newVal > 252) newVal = 252;
            int newSum = work.srcSum + (newVal - target);
            if (newSum > 510) newVal = target + (510 - work.srcSum);
            work.srcSum = (ushort)(work.srcSum + (newVal - target));
            target = (byte)newVal;
            work.bModified = true;
        }

        private void doryoku_PutToPP(DORYOKU_PARAM work, PokemonParam pp)
        {
            if (!work.bModified) return;
            pp.ChangeEffortPower(PowerID.HP, work.srcHp);
            pp.ChangeEffortPower(PowerID.ATK, work.srcPow);
            pp.ChangeEffortPower(PowerID.DEF, work.srcDef);
            pp.ChangeEffortPower(PowerID.AGI, work.srcAgi);
            pp.ChangeEffortPower(PowerID.SPATK, work.srcSpPow);
            pp.ChangeEffortPower(PowerID.SPDEF, work.srcSpDef);
            work.bModified = false;
        }

        private ref byte doryoku_ParamIDtoValueAdrs(DORYOKU_PARAM work, PowerID powID)
        {
            switch (powID)
            {
                case PowerID.HP: return ref work.srcHp;
                case PowerID.ATK: return ref work.srcPow;
                case PowerID.DEF: return ref work.srcDef;
                case PowerID.AGI: return ref work.srcAgi;
                case PowerID.SPATK: return ref work.srcSpPow;
                case PowerID.SPDEF: return ref work.srcSpDef;
                default: return ref s_DmyByte;
            }
        }

        public void AddEffortG(byte value)
        {
            m_doryokuParam.srcG = (byte)System.Math.Min(m_doryokuParam.srcG + value, 255);
        }

        public void SetRaidBoss(byte grade, in RaidBossDesc desc)
        {
            m_coreParam.isRaidBoss = true;
            var setupParam = new RaidBossParam.SetupParam { grade = grade, pDesc = desc };
            m_coreParam.raidBossParam.Setup(in setupParam);
            ushort hpMax = getBasePower(PowerID.HP, false);
            m_coreParam.hpMax = hpMax;
            m_coreParam.hp = hpMax;
        }

        public bool IsRaidBoss() { return m_coreParam.isRaidBoss; }

        public RaidBossParam GetRaidBossParam() { return m_coreParam.raidBossParam; }

        public bool IsGMode() { return m_coreParam.gParam.isGMode; }

        public bool IsSpecialG()
        {
            return m_coreParam.ppSrc.IsSpecialGEnable();
        }

        public bool CanStartG()
        {
            if (m_coreParam.gParam.isGMode) return false;
            if (m_coreParam.fForceGEnable) return true;
            return false;
        }

        public void StartGMode()
        {
            m_coreParam.gParam.isGMode = true;
            m_coreParam.gParam.passedTurnCount = 0;
            int ratio = GetHPRatio();
            setupBySrcData(false, true, false, true);
            ushort newMax = getBasePower(PowerID.HP, true);
            m_coreParam.hpMax = newMax;
            SetHPRatio(ratio);
        }

        public void EndGMode()
        {
            m_coreParam.gParam.isGMode = false;
            int ratio = GetHPRatio();
            setupBySrcData(false, true, false, true);
            ushort newMax = getBasePower(PowerID.HP, false);
            m_coreParam.hpMax = newMax;
            SetHPRatio(ratio);
        }

        public byte GetGModePassedTurnCount() { return m_coreParam.gParam.passedTurnCount; }

        public void IncGModePassedTurnCount() { m_coreParam.gParam.passedTurnCount++; }

        public bool IsSpecialGEnable() { return m_coreParam.fForceGEnable; }

        public void ReflectForExpUI([Optional] PokemonParam pp)
        {
            PokemonParam target = pp ?? m_coreParam.ppSrc;
            target.SetExp(m_coreParam.exp);
        }

        public class SetupParam
        {
            public PokemonParam srcParam;
            public DefaultPowerUpDesc defaultPowerUpDesc;
            public byte pokeID;
            public byte friendship;
            public bool isForceGEnable;

            public SetupParam()
            {
                srcParam = null;
                defaultPowerUpDesc = null;
                pokeID = 0;
                friendship = 0;
                isForceGEnable = false;
            }
        }

        public enum ValueID : int
        {
            BPP_VALUE_NULL = 0,
            BPP_ATTACK_RANK = 1,
            BPP_DEFENCE_RANK = 2,
            BPP_SP_ATTACK_RANK = 3,
            BPP_SP_DEFENCE_RANK = 4,
            BPP_AGILITY_RANK = 5,
            BPP_HIT_RATIO = 6,
            BPP_AVOID_RATIO = 7,
            BPP_ATTACK = 8,
            BPP_DEFENCE = 9,
            BPP_SP_ATTACK = 10,
            BPP_SP_DEFENCE = 11,
            BPP_AGILITY = 12,
            BPP_HP = 13,
            BPP_HP_BEFORE_G = 14,
            BPP_MAX_HP = 15,
            BPP_MAX_HP_BEFORE_G = 16,
            BPP_LEVEL = 17,
            BPP_TOKUSEI = 18,
            BPP_TOKUSEI_EFFECTIVE = 19,
            BPP_SEX = 20,
            BPP_SEIKAKU = 21,
            BPP_PERSONAL_RAND = 22,
            BPP_EXP = 23,
            BPP_MONS_POW = 24,
            BPP_MONS_AGILITY = 25,
            BPP_RANKVALUE_START = 1,
            BPP_RANKVALUE_END = 7,
            BPP_RANKVALUE_RANGE = 7,
        }

        public class WAZADMG_REC
        {
            public ushort wazaID;
            public ushort damage;
            public WazaDamageType damageType;
            public byte wazaType;
            public byte pokeID;
            public BtlPokePos pokePos;

            public void CopyFrom(WAZADMG_REC src)
            {
                wazaID = src.wazaID;
                damage = src.damage;
                damageType = src.damageType;
                wazaType = src.wazaType;
                pokeID = src.pokeID;
                pokePos = src.pokePos;
            }

            public void Clear()
            {
                wazaID = 0;
                damage = 0;
                damageType = 0;
                wazaType = 0;
                pokeID = 0;
                pokePos = 0;
            }
        }

        public enum TurnFlag : int
        {
            TURNFLG_ACTION_START = 0,
            TURNFLG_ACTION_DONE = 1,
            TURNFLG_DAMAGED = 2,
            TURNFLG_WAZAPROC_DONE = 3,
            TURNFLG_SHRINK = 4,
            TURNFLG_KIAI_READY = 5,
            TURNFLG_KIAI_SHRINK = 6,
            TURNFLG_MAMORU = 7,
            TURNFLG_ITEM_CONSUMED = 8,
            TURNFLG_ITEM_CANT_USE = 9,
            TURNFLG_COMBIWAZA_READY = 10,
            TURNFLG_TAMEHIDE_OFF = 11,
            TURNFLG_MOVED = 12,
            TURNFLG_TURNCHECK_SICK_PASSED = 13,
            TURNFLG_HITRATIO_UP = 14,
            TURNFLG_NAGETUKERU_USING = 15,
            TURNFLG_MAMORU_ONLY_DAMAGE_WAZA = 16,
            TURNFLG_RESERVE_ITEM_SPEND = 17,
            TURNFLG_APPEARED_BY_POKECHANGE = 18,
            TURNFLG_CANT_ACTION = 19,
            TURNFLG_TRAPPSHELL_READY = 20,
            TURNFLG_GWALL_BROKEN = 21,
            TURNFLG_RAIDBOSS_REINFORCE_DONE = 22,
            TURNFLG_RAIDBOSS_ANGRY = 23,
            TURNFLG_RAIDBOSS_ANGRY_WAZA_ADD_DONE = 24,
            TURNFLG_RANK_UP = 25,
            TURNFLG_RANK_DOWN = 26,
            TURNFLG_MAX = 27,
        }

        public enum PermFlag : int
        {
            PERMFLAG_ATE_KINOMI = 0,
            PERMFLAG_LEVELUP = 1,
            PERMFLAG_KIZUNAHENGE_DONE = 2,
            PERMFLAG_MAX = 3,
            PERMFLAG_NULL = 3,
        }

        public enum Counter : int
        {
            COUNTER_TAKUWAERU = 0,
            COUNTER_TAKUWAERU_DEF = 1,
            COUNTER_TAKUWAERU_SPDEF = 2,
            COUNTER_MAMORU = 3,
            COUNTER_FREEFALL = 4,
            COUNTER_TURN_FROM_GWALL_BROKEN = 5,
            COUNTER_MAX = 6,
        }

        public enum PermCounter : byte
        {
            CRITICAL = 0,
            DEAD = 1,
            TOTAL_DAMAGE_RECIEVED = 2,
            GSHOCK_NEKONIKOBAN_USE_COUNT = 3,
            NUM = 4,
        }

        public enum ExTypeCause : int
        {
            EXTYPE_CAUSE_NONE = 0,
            EXTYPE_CAUSE_HALLOWEEN = 1,
            EXTYPE_CAUSE_MORINONOROI = 2,
        }

        public enum NemuriCheckMode : int
        {
            NEMURI_CHECK_ONLY_SICK = 0,
            NEMURI_CHECK_INCLUDE_ZETTAINEMURI = 1,
        }

        private class WAZA_CORE
        {
            public WazaNo number;
            public byte pp;
            public byte ppMax;
            public byte ppCnt;
            public bool usedFlag;
            public bool usedFlagFix;
            public byte usedCount;
            public byte killCount;

            public void CopyFrom(WAZA_CORE src)
            {
                number = src.number;
                pp = src.pp;
                ppMax = src.ppMax;
                ppCnt = src.ppCnt;
                usedFlag = src.usedFlag;
                usedFlagFix = src.usedFlagFix;
                usedCount = src.usedCount;
                killCount = src.killCount;
            }
        }

        private class WAZA_SET
        {
            public WAZA_CORE truth = new WAZA_CORE();
            public WAZA_CORE surface = new WAZA_CORE();
            public bool fLinked;

            public void CopyFrom(WAZA_SET src)
            {
                truth.CopyFrom(src.truth);
                surface.CopyFrom(src.surface);
                fLinked = src.fLinked;
            }
        }

        private class GModeParam
        {
            public bool isGMode;
            public byte passedTurnCount;

            public void CopyFrom(GModeParam src)
            {
                isGMode = src.isGMode;
                passedTurnCount = src.passedTurnCount;
            }
        }

        private class CORE_PARAM
        {
            public PokemonParam ppSrc;
            public uint personalRand;
            public uint exp;
            public ushort monsno;
            public ushort formno;
            public ushort hpMax;
            public ushort hp;
            public ushort item;
            public ushort usedItem;
            public ushort defaultTokusei;
            public byte level;
            public byte myID;
            public byte mons_pow;
            public byte mons_agility;
            public byte seikaku;
            public byte native_talent_hp;
            public byte native_talent_atk;
            public byte native_talent_def;
            public byte native_talent_spatk;
            public byte native_talent_spdef;
            public byte native_talent_agi;
            public ushort defaultFormNo;
            public bool fHensin;
            public bool fFakeEnable;
            public bool fBtlIn;
            public bool fDontResetFormByByOut;
            public bool fForceGEnable;
            public BTL_SICKCONT[] sickCont = new BTL_SICKCONT[45];
            public byte[] wazaSickCounter = new byte[45];
            public byte confrontRecCount;
            public byte[] confrontRec = new byte[30];
            public ushort totalTurnCount;
            public byte fakeViewTargetPokeId;
            public DefaultPowerUpDesc defaultPowerUpDesc = new DefaultPowerUpDesc();
            public DamageCause deadCause;
            public byte deadCausePokeID;
            public byte killCount;
            public bool isRaidBoss;
            public RaidBossParam raidBossParam;
            public GModeParam gParam = new GModeParam();
        }

        private class BASE_PARAM
        {
            public ushort monsno;
            public ushort formno;
            public ushort attack;
            public ushort defence;
            public ushort sp_attack;
            public ushort sp_defence;
            public ushort agility;
            public byte type1;
            public byte type2;
            public byte type_ex;
            public byte sex;
            public ExTypeCause type_ex_cause;

            public void CopyFrom(BASE_PARAM src)
            {
                monsno = src.monsno;
                formno = src.formno;
                attack = src.attack;
                defence = src.defence;
                sp_attack = src.sp_attack;
                sp_defence = src.sp_defence;
                agility = src.agility;
                type1 = src.type1;
                type2 = src.type2;
                type_ex = src.type_ex;
                sex = src.sex;
                type_ex_cause = src.type_ex_cause;
            }
        }

        private class VARIABLE_PARAM
        {
            public sbyte attack;
            public sbyte defence;
            public sbyte sp_attack;
            public sbyte sp_defence;
            public sbyte agility;
            public sbyte hit;
            public sbyte avoid;

            public void CopyFrom(VARIABLE_PARAM src)
            {
                attack = src.attack;
                defence = src.defence;
                sp_attack = src.sp_attack;
                sp_defence = src.sp_defence;
                agility = src.agility;
                hit = src.hit;
                avoid = src.avoid;
            }
        }

        private class DORYOKU_PARAM
        {
            public ushort srcSum;
            public byte srcHp;
            public byte srcPow;
            public byte srcDef;
            public byte srcAgi;
            public byte srcSpPow;
            public byte srcSpDef;
            public byte srcG;
            public bool bPokerus;
            public bool bModified;

            public void CopyFrom(DORYOKU_PARAM src)
            {
                srcSum = src.srcSum;
                srcHp = src.srcHp;
                srcPow = src.srcPow;
                srcDef = src.srcDef;
                srcAgi = src.srcAgi;
                srcSpPow = src.srcSpPow;
                srcSpDef = src.srcSpDef;
                srcG = src.srcG;
                bPokerus = src.bPokerus;
                bModified = src.bModified;
            }
        }

        private enum SickWorkClearCode : int
        {
            SICKWORK_CLEAR_ALL = 0,
            SICKWORK_CLEAR_WITHOUT_SLEEP = 1,
            SICKWORK_CLEAR_ONLY_WAZASICK = 2,
        }
    }
}
