using Pml;
using Pml.PokePara;
using Pml.WazaData;
using System.Runtime.InteropServices;

namespace Dpr.Battle.Logic
{
    public class BTL_POKEPARAM
    {
        // TODO: cctor

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

        // TODO
        public static void WAZADMG_REC_Setup(WAZADMG_REC rec, byte pokeID, BtlPokePos pokePos, ushort wazaID, byte wazaType, ushort damage, WazaDamageType damageType) { }

        public byte GetFormNo()
        {
            return m_formNo;
        }

        public byte GetFriendship() {
            return m_friendship;
        }

        // TODO
        public static byte PokeIDtoFreeFallCounter(byte pokeID) { return 0; }

        // TODO
        public static byte FreeFallCounterToPokeID(byte counter) { return 0; }

        // TODO
        private void flgbuf_clear(byte[] buf) { }

        // TODO
        private void flgbuf_set(byte[] buf, uint flagID) { }

        // TODO
        private void flgbuf_reset(byte[] buf, uint flagID) { }

        // TODO
        private bool flgbuf_get(byte[] buf, uint flagID) { return false; }

        // TODO
        public BTL_POKEPARAM([Optional] FieldStatus fieldStatus) { }

        // TODO
        public void Dispose() { }

        // TODO
        public void Setup(in SetupParam setupParam) { }

        // TODO
        private void setupBySrcData(bool fReflectHP, bool fParamUpdate, bool fTokuseiUpdate, bool fWeightUpdate) { }

        // TODO
        private void setupBySrcDataBase(bool fTypeUpdate, bool fParamUpdate, bool isGMode) { }

        // TODO
        private ushort getBasePower(PowerID powerID, bool isGMode, bool isApplyRaidBossHpCoef = true) { return 0; }

        // TODO
        private void updateWeight() { }

        // TODO
        private uint wazaWork_setupByPP(PokemonParam pp_src, bool fLinkSurface) { return 0; }

        // TODO
        private void wazaWork_ReflectToPP() { }

        // TODO
        private void wazaWork_ReflectFromPP() { }

        // TODO
        private void wazaWork_ClearSurface() { }

        // TODO
        private void wazaSet_ClearUsedFlag(WAZA_SET waza) { }

        // TODO
        private bool wazaCore_SetupByPP(WAZA_CORE core, PokemonParam pp, byte index) { return false; }

        // TODO
        public void CopyFrom(in BTL_POKEPARAM srcParam, bool isCompletely = false) { }

        // TODO
        private void CORE_PARAM_Copy(CORE_PARAM dest, in CORE_PARAM src) { }

        public byte GetID()
        {
            return m_coreParam.myID;
        }

        public ushort GetMonsNo()
        {
            return m_coreParam.monsno;
        }

        // TODO
        public Seikaku GetSeikaku() { return Seikaku.GANBARIYA; }

        // TODO
        public ushort GetHenshinMonsNo() { return 0; }

        // TODO
        public ushort GetHenshinFormNo() { return 0; }

        // TODO
        public DefaultPowerUpDesc GetDefaultPowerUpDesc() { return null; }

        // TODO
        public DamageCause GetDeadCause() { return DamageCause.OTHER; }

        // TODO
        public byte GetDeadCausePokeID() { return 0; }

        // TODO
        public void SetDeadCause(DamageCause damageCause, byte damageCausePokeID) { }

        // TODO
        public void ClearDeadCause() { }

        // TODO
        public byte GetKillCount() { return 0; }

        // TODO
        public void SetKillCount(byte killCount) { }

        // TODO
        public void IncKillCount() { }

        // TODO
        public BtlSpecialPri GetSpActPriority() { return BtlSpecialPri.BTL_SPPRI_LOW; }

        public void SetSpActPriority(byte priority) {
            this.m_spActPriority = priority;
        }

        // TODO
        private void resetSpActPriority() { }

        // TODO
        public PokemonParam GetSrcData() { return null; }

        // TODO
        public PokemonParam GetSrcDataConst() { return null; }

        // TODO
        public void SetViewSrcPokeID(byte fakeTargetPokeID) { }

        // TODO
        public byte GetViewSrcPokeID() { return 0; }

        // TODO
        private void effrank_Init(VARIABLE_PARAM rank) { }

        // TODO
        private void effrank_Reset(VARIABLE_PARAM rank) { }

        // TODO
        private bool effrank_ResetRankUp(VARIABLE_PARAM rank) { return false; }

        // TODO
        private bool effrank_Recover(VARIABLE_PARAM rank) { return false; }

        // TODO
        private void dmgrec_ClearWork() { }

        // TODO
        private void dmgrec_FwdTurn() { }

        // TODO
        private void confrontRec_Clear() { }

        // TODO
        public void Confront_Set(byte pokeID) { }

        // TODO
        public byte Confront_GetCount() { return 0; }

        // TODO
        public byte Confront_GetPokeID(byte idx) { return 0; }

        public int GetValue(ValueID vid)
        {
            vid = convertValueID(vid);

            switch (vid)
            {
                case ValueID.BPP_ATTACK_RANK:       return m_varyParam.attack;
                case ValueID.BPP_DEFENCE_RANK:      return m_varyParam.defence;
                case ValueID.BPP_SP_ATTACK_RANK:    return m_varyParam.sp_attack;
                case ValueID.BPP_SP_DEFENCE_RANK:   return m_varyParam.sp_defence;
                case ValueID.BPP_AGILITY_RANK:      return m_varyParam.agility;
                case ValueID.BPP_HIT_RATIO:         return m_varyParam.hit;
                case ValueID.BPP_AVOID_RATIO:       return m_varyParam.avoid;
                case ValueID.BPP_ATTACK:            return calc.StatusRank((ushort)GetValue_Base(ValueID.BPP_ATTACK), (byte)m_varyParam.attack);
                case ValueID.BPP_DEFENCE:           return calc.StatusRank((ushort)GetValue_Base(ValueID.BPP_DEFENCE), (byte)m_varyParam.defence);
                case ValueID.BPP_SP_ATTACK:         return calc.StatusRank((ushort)GetValue_Base(ValueID.BPP_SP_ATTACK), (byte)m_varyParam.sp_attack);
                case ValueID.BPP_SP_DEFENCE:        return calc.StatusRank((ushort)GetValue_Base(ValueID.BPP_SP_DEFENCE), (byte)m_varyParam.sp_defence);
                case ValueID.BPP_AGILITY:           return calc.StatusRank((ushort)GetValue_Base(ValueID.BPP_AGILITY), (byte)m_varyParam.agility);
                case ValueID.BPP_HP:                return m_coreParam.hp;
                case ValueID.BPP_HP_BEFORE_G:       return (ushort)getHPBeforeG();
                case ValueID.BPP_MAX_HP:            return m_coreParam.hpMax;
                case ValueID.BPP_MAX_HP_BEFORE_G:   return (ushort)m_coreParam.ppSrc.GetPower_NotG(PowerID.HP);
                case ValueID.BPP_LEVEL:             return m_coreParam.level;
                case ValueID.BPP_TOKUSEI:           return m_tokusei;
                case ValueID.BPP_TOKUSEI_EFFECTIVE: return (CheckSick(WazaSick.WAZASICK_IEKI) || IsTokuseiDisabledByKagakuHenkaGas()) ? (int)TokuseiNo.NULL : m_tokusei;
                case ValueID.BPP_SEX:               return m_baseParam.sex;
                case ValueID.BPP_SEIKAKU:           return m_coreParam.seikaku;
                case ValueID.BPP_PERSONAL_RAND:     return (int)m_coreParam.personalRand;
                case ValueID.BPP_EXP:               return (int)m_coreParam.exp;
                case ValueID.BPP_MONS_POW:          return m_coreParam.mons_pow;
                case ValueID.BPP_MONS_AGILITY:
                default:                            return m_coreParam.mons_agility;
            }
        }

        public int GetValue_Base(ValueID vid)
        {
            vid = convertValueID(vid);

            switch (vid)
            {
                case ValueID.BPP_HIT_RATIO:   return DefineConstants.BTL_CALC_HITRATIO_MID;
                case ValueID.BPP_AVOID_RATIO: return DefineConstants.BTL_CALC_HITRATIO_MID;
                case ValueID.BPP_ATTACK:      return m_baseParam.attack;
                case ValueID.BPP_DEFENCE:     return m_baseParam.defence;
                case ValueID.BPP_SP_ATTACK:   return m_baseParam.sp_attack;
                case ValueID.BPP_SP_DEFENCE:  return m_baseParam.sp_defence;
                case ValueID.BPP_AGILITY:     return m_baseParam.agility;
                default:                      return GetValue(vid);
            }
        }

        // TODO
        public byte GetEffortValue(PowerID powerID) { return 0; }

        // TODO
        public bool IsEffortValueFull() { return false; }

        // TODO
        public byte GetNativeTalentPower(PowerID powerID) { return 0; }

        private ValueID convertValueID(ValueID vid)
        {
            if (m_fldSim == null)
                return vid;

            if (vid == ValueID.BPP_SP_DEFENCE)
            {
                if (m_fldSim.CheckEffect(EffectType.EFF_WONDERROOM))
                    return ValueID.BPP_DEFENCE;
                else
                    return ValueID.BPP_SP_DEFENCE;
            }
            else if (vid == ValueID.BPP_DEFENCE)
            {
                if (m_fldSim.CheckEffect(EffectType.EFF_WONDERROOM))
                    return ValueID.BPP_SP_DEFENCE;
                else
                    return ValueID.BPP_DEFENCE;
            }
            else
            {
                return vid;
            }
        }

        // TODO
        public bool IsHPFull() { return false; }

        // TODO
        public bool IsDead() { return false; }

        // TODO
        public bool IsFightEnable() { return false; }

        public bool CheckSick(WazaSick sickType)
        {
            return m_coreParam.sickCont[(int)sickType].turn_type_turn != 0;
        }

        // TODO
        public bool CheckNemuri(NemuriCheckMode checkMode) { return false; }

        // TODO
        public bool CheckMoudoku() { return false; }

        // TODO
        public WazaNo GetWazaLockID() { return WazaNo.NULL; }

        // TODO
        private void clearWazaSickWork(uint clearCode) { }

        // TODO
        public Sick GetPokeSick() { return Sick.NONE; }

        // TODO
        public ushort GetSickParam(WazaSick sick) { return 0; }

        public BTL_SICKCONT GetSickCont(WazaSick sick)
        {
            return m_coreParam.sickCont[(int)sick];
        }

        // TODO
        public byte GetSickTurnCount(WazaSick sick) { return 0; }

        // TODO
        public bool IsSickLastTurn(WazaSick sickType) { return false; }

        // TODO
        public int CalcSickDamage(WazaSick sick) { return 0; }

        // TODO
        public WazaNo GetKodawariWazaID() { return WazaNo.NULL; }

        // TODO
        public bool IsTokuseiDisabledByKagakuHenkaGas() { return false; }

        // TODO
        public void ReflectToPP(bool fDefaultForm) { }

        // TODO
        private void wazaWork_UpdateNumber(WAZA_SET waza, WazaNo nextNumber, byte ppMax, bool fPermenent) { }

        // TODO
        private void wazaCore_UpdateNumber(WAZA_CORE core, WazaNo nextID, byte ppMax) { }

        // TODO
        private void clearHensin() { }

        // TODO
        private void clearUsedWazaFlag() { }

        // TODO
        private void clearCounter() { }

        public byte WAZA_GetCount()
        {
            return m_wazaCnt;
        }

        // TODO
        public byte WAZA_GetCount_Org() { return 0; }

        // TODO
        public byte WAZA_GetUsedCountInAlive() { return 0; }

        public byte WAZA_GetUsedCount() {
            return m_usedWazaCount;
        }

        // TODO
        public byte WAZA_GetUsableCount() { return 0; }

        public WazaNo WAZA_GetID(byte idx)
        {
            return m_waza[idx].surface.number;
        }

        // TODO
        public WazaNo WAZA_GetID_Org(byte idx) { return WazaNo.NULL; }

        // TODO
        public bool WAZA_CheckUsedInAlive(byte idx) { return false; }

        // TODO
        public void WAZA_Copy(BTL_POKEPARAM bppDst) { }

        public byte WAZA_GetUsedCount(byte wazaIdx) {
            return m_usedWazaCount;
        }

        // TODO
        public void WAZA_SetUsedCount(byte wazaIdx, byte value) { }

        // TODO
        public byte WAZA_GetKillCount(byte wazaIdx) { return 0; }

        // TODO
        public void WAZA_SetKillCount(byte wazaIdx, byte value) { }

        // TODO
        public byte WAZA_GetPPShort(byte idx) { return 0; }

        // TODO
        public byte WAZA_GetPPShort_Org(byte idx) { return 0; }

        // TODO
        public bool WAZA_CheckPPShortAny() { return false; }

        // TODO
        public bool WAZA_CheckPPShortAny_Org() { return false; }

        // TODO
        public ushort WAZA_GetPP(byte wazaIdx) { return 0; }

        // TODO
        public ushort WAZA_GetPP_ByNumber(WazaNo waza) { return 0; }

        // TODO
        public ushort WAZA_GetPP_Org(byte wazaIdx) { return 0; }

        // TODO
        public ushort WAZA_GetMaxPP(byte wazaIdx) { return 0; }

        // TODO
        public ushort WAZA_GetMaxPP_Org(byte wazaIdx) { return 0; }

        // TODO
        public bool WAZA_IsPPFull(byte wazaIdx, bool fOrg) { return false; }

        // TODO
        public void WAZA_DecrementPP(byte wazaIdx, byte value) { }

        // TODO
        public void WAZA_DecrementPP_Org(byte wazaIdx, byte value) { }

        // TODO
        public void WAZA_SetUsedFlag_Org(byte wazaIdx) { }

        // TODO
        public WazaNo WAZA_IncrementPP(byte wazaIdx, byte value) { return WazaNo.NULL; }

        // TODO
        public WazaNo WAZA_IncrementPP_Org(byte wazaIdx, byte value) { return WazaNo.NULL; }

        // TODO
        public bool WAZA_IsLinkOut(byte wazaIdx) { return false; }

        // TODO
        public void WAZA_SetUsedFlag(byte wazaIdx) { }

        // TODO
        public void WAZA_UpdateID(byte wazaIdx, WazaNo waza, byte ppMax, bool fPermenent) { }

        public bool WAZA_IsUsable(WazaNo waza)
        {
            for (byte i=0; i<m_waza.Length; i++)
            {
                if (m_waza[i].surface.number == waza)
                    return true;
            }

            return false;
        }

        // TODO
        public byte WAZA_SearchIdx(WazaNo waza) { return 0; }

        // TODO
        private void splitTypeCore(out byte type1, out byte type2)
        {
            type1 = 0;
            type2 = 0;
        }

        // TODO
        public PokeTypePair GetPokeType() { return default(PokeTypePair); }

        // TODO
        public byte GetOriginalPokeType1() { return 0; }

        // TODO
        public byte GetOriginalPokeType2() { return 0; }

        // TODO
        public bool IsMatchType(byte type) { return false; }

        // TODO
        public void SetBaseStatus(ValueID vid, ushort value) { }

        // TODO
        public int GetValue_Critical(ValueID vid) { return 0; }

        // TODO
        public ushort GetItem() { return 0; }

        // TODO
        public void SetItem(ushort itemID) { }

        // TODO
        public ushort GetItemEffective(in FieldStatus fldSim) { return 0; }

        // TODO
        public ushort GetTotalTurnCount() { return 0; }

        // TODO
        public void IncTotalTurnCount() { }

        public ushort GetTurnCount() {
            return m_turnCount;
        }

        public ushort GetAppearTurn() {
            return m_appearedTurn;
        }

        // TODO
        public bool TURNFLAG_Get(TurnFlag flagID) { return false; }

        // TODO
        public bool CONTFLAG_Get(ContFlag flagID) { return false; }

        // TODO
        public bool PERMFLAG_Get(PermFlag flagID) { return false; }

        // TODO
        public void PERMFLAG_Set(PermFlag flagID) { }

        // TODO
        public ContFlag CONTFLAG_CheckWazaHide() { return ContFlag.CONTFLG_ACTION_DONE; }

        // TODO
        public bool IsWazaHide() { return false; }

        // TODO
        public bool IsUsingFreeFall() { return false; }

        // TODO
        public int GetHPRatio() { return 0; }

        // TODO
        public void SetHPRatio(int ratio) { }

        // TODO
        public uint calcHpRatio(uint maxHP, int ratio) { return 0; }

        // TODO
        private uint getHPBeforeG() { return 0; }

        // TODO
        private sbyte getRankVaryStatus(ValueID type, out sbyte min, out sbyte max)
        {
            min = 0;
            max = 0;
            return 0;
        }

        // TODO
        public bool IsRankEffectValid(ValueID rankType, int volume) { return false; }

        // TODO
        public int RankEffectUpLimit(ValueID rankType) { return 0; }

        // TODO
        public int RankEffectDownLimit(ValueID rankType) { return 0; }

        // TODO
        public bool IsRankEffectDowned() { return false; }

        // TODO
        public byte RankUp(ValueID rankType, byte volume) { return 0; }

        // TODO
        private byte RankUp_Core(byte volume, ref sbyte ptr) { return 0; }

        // TODO
        public byte RankDown(ValueID rankType, byte volume) { return 0; }

        // TODO
        private byte RankDown_Core(byte volume, ref sbyte ptr) { return 0; }

        // TODO
        public void RankSet(ValueID rankType, byte value) { }

        // TODO
        private void RankSet_Core(byte value, ref sbyte ptr) { }

        // TODO
        public bool RankRecover() { return false; }

        // TODO
        public void RankReset() { }

        // TODO
        public bool RankUpReset() { return false; }

        // TODO
        public byte GetCriticalRank() { return 0; }

        public byte GetCriticalRankPure() {
            return m_criticalRank;
        }

        // TODO
        public bool AddCriticalRank(int value) { return false; }

        // TODO
        public void SetCriticalRank(byte rank) { }

        // TODO
        public void HpMinus(ushort value) { }

        // TODO
        public void HpPlus(ushort value) { }

        // TODO
        public void HpZero() { }

        // TODO
        public void TURNFLAG_Set(TurnFlag flagID) { }

        // TODO
        public void CONTFLAG_Set(ContFlag flagID) { }

        // TODO
        public void CONTFLAG_Clear(ContFlag flagID) { }

        // TODO
        public void SetWazaSick(WazaSick sick, in BTL_SICKCONT contParam) { }

        // TODO
        public bool WazaSick_TurnCheck(WazaSick sick, out BTL_SICKCONT pOldContDest, out bool fCured)
        {
            pOldContDest = default(BTL_SICKCONT);
            fCured = false;
            return false;
        }

        // TODO
        public bool CheckNemuriWakeUp() { return false; }

        // TODO
        public bool CheckKonranWakeUp() { return false; }

        // TODO
        public void CurePokeSick() { }

        // TODO
        private void cureDependSick(WazaSick sickID) { }

        // TODO
        public void CureWazaSick(WazaSick sick) { }

        // TODO
        public void CureWazaSickDependPoke(byte depend_pokeID) { }

        // TODO
        public void SetAppearTurn(ushort turn) { }

        // TODO
        public void TurnCheck() { }

        // TODO
        public void TURNFLAG_ForceOff(TurnFlag flagID) { }

        // TODO
        public void Clear_ForDead() { }

        // TODO
        public void Clear_ForOut() { }

        // TODO
        public void Clear_ForIn() { }

        // TODO
        public void CopyBatonTouchParams(BTL_POKEPARAM user) { }

        // TODO
        public bool ChangePokeType(PokeTypePair type, ExTypeCause exTypeCause) { return false; }

        // TODO
        public void ExPokeType(byte type, ExTypeCause exTypeCause) { }

        // TODO
        public byte GetExType() { return 0; }

        // TODO
        public bool HaveExType() { return false; }

        // TODO
        public ExTypeCause GetExTypeCause() { return ExTypeCause.EXTYPE_CAUSE_NONE; }

        // TODO
        public void ChangeTokusei(TokuseiNo tok) { }

        // TODO
        public void ChangeForm(byte formNo, bool dontResetFormByOut = false) { }

        // TODO
        private void correctMaxHP() { }

        // TODO
        public void RemoveItem() { }

        // TODO
        public void ConsumeItem(ushort itemID) { }

        // TODO
        public void ClearConsumedItem() { }

        // TODO
        public ushort GetConsumedItem() { return 0; }

        // TODO
        public void UpdateWazaProcResult(BtlPokePos actTargetPos, byte actWazaType, bool fActEnable, WazaNo actWaza, WazaNo orgWaza) { }

        public uint GetWazaContCounter() {
            return m_wazaContCounter;
        }

        public WazaNo GetPrevWazaID()
        {
            return m_prevActWazaID;
        }

        public byte GetPrevWazaType() {
            return m_prevWazaType;
        }

        // TODO
        public WazaNo GetPrevOrgWazaID() { return WazaNo.NULL; }

        // TODO
        public BtlPokePos GetPrevTargetPos() { return BtlPokePos.POS_1ST_0; }

        // TODO
        public bool GetBtlInFlag() { return false; }

        // TODO
        public void SetWeight(ushort weight) { }

        public ushort GetWeight() {
            return m_weight;
        }

        // TODO
        public void WAZADMGREC_Add(WAZADMG_REC rec) { }

        // TODO
        public byte WAZADMGREC_GetCount(byte turn_ridx) { return 0; }

        // TODO
        public bool WAZADMGREC_Get(byte turn_ridx, byte rec_ridx, WAZADMG_REC dst) { return false; }

        // TODO
        public void COUNTER_Set(Counter cnt, byte value) { }

        // TODO
        public void COUNTER_Inc(Counter cnt) { }

        // TODO
        public byte COUNTER_Get(Counter cnt) { return 0; }

        // TODO
        public void PERMCOUNTER_Set(PermCounter counter, uint value) { }

        // TODO
        public void PERMCOUNTER_Add(PermCounter counter, uint value) { }

        // TODO
        public void PERMCOUNTER_Inc(PermCounter counter) { }

        // TODO
        public uint PERMCOUNTER_Get(PermCounter counter) { return 0; }

        // TODO
        public bool AddExp(uint exp) { return false; }

        // TODO
        public uint GetExpMargin() { return 0; }

        // TODO
        public void ReflectByPP() { }

        // TODO
        public bool IsFakeEnable() { return false; }

        // TODO
        public void FakeDisable() { }

        // TODO
        public byte GetFakeTargetPokeID() { return 0; }

        // TODO
        public bool HENSIN_CheckEnable(BTL_POKEPARAM target) { return false; }

        // TODO
        public void HENSIN_Set(BTL_POKEPARAM target) { }

        // TODO
        private void henshinCopyFrom(in BTL_POKEPARAM src) { }

        // TODO
        public bool HENSIN_Check() { return false; }

        // TODO
        public void MIGAWARI_Create(ushort migawariHP) { }

        // TODO
        public void MIGAWARI_Delete() { }

        // TODO
        public bool MIGAWARI_IsExist() { return false; }

        public uint MIGAWARI_GetHP() {
            return m_migawariHP;
        }

        // TODO
        public bool MIGAWARI_AddDamage(ref ushort damage) { return false; }

        // TODO
        public void CONFRONT_REC_Set(byte pokeID) { }

        // TODO
        public byte CONFRONT_REC_GetCount() { return 0; }

        // TODO
        public byte CONFRONT_REC_GetPokeID(byte idx) { return 0; }

        // TODO
        public bool CONFRONT_REC_IsMatch(byte pokeID) { return false; }

        // TODO
        public void SetCaptureBallID(ushort ballItemID) { }

        // TODO
        public void CombiWaza_SetParam(byte combiPokeID, WazaNo combiUsedWaza) { }

        // TODO
        public bool CombiWaza_GetParam(out byte combiPokeID, out WazaNo combiUsedWaza)
        {
            combiPokeID = 0;
            combiUsedWaza = WazaNo.NULL;
            return false;
        }

        // TODO
        public bool CombiWaza_IsSetParam() { return false; }

        // TODO
        public void CombiWaza_ClearParam() { }

        // TODO
        public bool IsMatchTokusei(TokuseiNo tokusei) { return false; }

        // TODO
        public bool HavePokerus() { return false; }

        // TODO
        public void AddEffortPower(PowerID id, byte value) { }

        // TODO
        private void doryoku_InitParam(DORYOKU_PARAM work, PokemonParam pp) { }

        // TODO
        private void doryoku_AddPower(DORYOKU_PARAM work, PowerID powID, byte value) { }

        // TODO
        private void doryoku_PutToPP(DORYOKU_PARAM work, PokemonParam pp) { }

        // TODO
        private ref byte doryoku_ParamIDtoValueAdrs(DORYOKU_PARAM work, PowerID powID) { return ref m_wazaCnt; }

        // TODO
        public void AddEffortG(byte value) { }

        // TODO
        public void SetRaidBoss(byte grade, in RaidBossDesc desc) { }

        // TODO
        public bool IsRaidBoss() { return false; }

        // TODO
        public RaidBossParam GetRaidBossParam() { return null; }

        // TODO
        public bool IsGMode() { return false; }

        // TODO
        public bool IsSpecialG() { return false; }

        // TODO
        public bool CanStartG() { return false; }

        // TODO
        public void StartGMode() { }

        // TODO
        public void EndGMode() { }

        // TODO
        public byte GetGModePassedTurnCount() { return 0; }

        // TODO
        public void IncGModePassedTurnCount() { }

        // TODO
        public bool IsSpecialGEnable() { return false; }

        // TODO
        public void ReflectForExpUI([Optional] PokemonParam pp) { }

        public class SetupParam
        {
            public PokemonParam srcParam;
            public DefaultPowerUpDesc defaultPowerUpDesc;
            public byte pokeID;
            public byte friendship;
            public bool isForceGEnable;

            // TODO
            public SetupParam() { }
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

            // TODO
            public void CopyFrom(WAZADMG_REC src) { }

            // TODO
            public void Clear() { }
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

            // TODO
            public void CopyFrom(WAZA_CORE src) { }
        }

        private class WAZA_SET
        {
            public WAZA_CORE truth = new WAZA_CORE();
            public WAZA_CORE surface = new WAZA_CORE();
            public bool fLinked;

            // TODO
            public void CopyFrom(WAZA_SET src) { }
        }

        private class GModeParam
        {
            public bool isGMode;
            public byte passedTurnCount;

            // TODO
            public void CopyFrom(GModeParam src) { }
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

            // TODO
            public void CopyFrom(BASE_PARAM src) { }
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

            // TODO
            public void CopyFrom(VARIABLE_PARAM src) { }
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

            // TODO
            public void CopyFrom(DORYOKU_PARAM src) { }
        }

        private enum SickWorkClearCode : int
        {
            SICKWORK_CLEAR_ALL = 0,
            SICKWORK_CLEAR_WITHOUT_SLEEP = 1,
            SICKWORK_CLEAR_ONLY_WAZASICK = 2,
        }
    }
}
