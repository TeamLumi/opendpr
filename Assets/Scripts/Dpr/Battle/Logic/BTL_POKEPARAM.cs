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
        	return (byte)(this.m_formNo);
        }

        public byte GetFriendship()
        {
        	return (byte)(this.m_friendship);
        }

        public static byte PokeIDtoFreeFallCounter(byte pokeID)
        {
        	return (byte)(pokeID + 1);
        }

        public static byte FreeFallCounterToPokeID(byte counter)
        {
        	uint uVar1;
        	if ((counter == 0) || (uVar1 = counter - 1, 0x1d < (uVar1 & 0xfe))) {
        	  uVar1 = 0x1f;
        	}
        	return (byte)(uVar1);
        }

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

        private void setupBySrcDataBase(bool fTypeUpdate, bool fParamUpdate, bool isGMode)
        {
        	uint uVar3;
        	if (fTypeUpdate) {
        	  this.m_baseParam.type1 = this.m_coreParam.ppSrc.GetType1();
        	  this.m_baseParam.type2 = this.m_coreParam.ppSrc.GetType2();
        	  this.m_baseParam.type_ex = 0x12;
        	  this.m_baseParam.type_ex_cause = 0;
        	}
        	this.m_baseParam.sex = this.m_coreParam.ppSrc.GetSex();
        	if (fParamUpdate) {
        	  if (!isGMode) {
        	    uVar3 = Pml_PokePara_CoreParam__GetPower_NotG
        	                      (this.m_coreParam.ppSrc,1,0);
        	  }
        	  else {
        	    uVar3 = CoreParam.GetPower_G();
        	  }
        	  this.m_baseParam.attack = uVar3;
        	  if (!isGMode) {
        	    uVar3 = Pml_PokePara_CoreParam__GetPower_NotG
        	                      (this.m_coreParam.ppSrc,2,0);
        	  }
        	  else {
        	    uVar3 = CoreParam.GetPower_G();
        	  }
        	  this.m_baseParam.defence = uVar3;
        	  if (!isGMode) {
        	    uVar3 = Pml_PokePara_CoreParam__GetPower_NotG
        	                      (this.m_coreParam.ppSrc,3,0);
        	  }
        	  else {
        	    uVar3 = CoreParam.GetPower_G();
        	  }
        	  this.m_baseParam.sp_attack = uVar3;
        	  if (!isGMode) {
        	    uVar3 = Pml_PokePara_CoreParam__GetPower_NotG
        	                      (this.m_coreParam.ppSrc,4,0);
        	  }
        	  else {
        	    uVar3 = CoreParam.GetPower_G();
        	  }
        	  this.m_baseParam.sp_defence = uVar3;
        	  if (!isGMode) {
        	    uVar3 = Pml_PokePara_CoreParam__GetPower_NotG
        	                      (this.m_coreParam.ppSrc,5,0);
        	  }
        	  else {
        	    uVar3 = CoreParam.GetPower_G();
        	  }
        	  this.m_baseParam.agility = uVar3;
        	}
        	this.m_baseParam.monsno = this.m_coreParam.ppSrc.GetMonsNo();
        	this.m_baseParam.formno = this.m_coreParam.ppSrc.GetFormNo();
        }

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
        	return (byte)(this.m_coreParam.myID);
        }

        public ushort GetMonsNo()
        {
        	return (ushort)(this.m_coreParam.monsno);
        }

        public Seikaku GetSeikaku()
        {
        	return this.m_coreParam.seikaku;
        }

        public ushort GetHenshinMonsNo()
        {
        	if (this.m_coreParam.fHensin != 0) {
        	  return (ushort)(this.m_baseParam.monsno);
        	}
        	return (ushort)(this.m_coreParam.monsno);
        }

        public ushort GetHenshinFormNo()
        {
        	if (this.m_coreParam.fHensin != 0) {
        	  return (ushort)(this.m_baseParam.formno);
        	}
        	return (ushort)(this.m_coreParam.formno);
        }

        public DefaultPowerUpDesc GetDefaultPowerUpDesc()
        {
        	return this.m_coreParam.defaultPowerUpDesc;
        }

        public DamageCause GetDeadCause()
        {
        	return this.m_coreParam.deadCause;
        }

        public byte GetDeadCausePokeID()
        {
        	return (byte)(this.m_coreParam.deadCausePokeID);
        }

        // TODO
        public void SetDeadCause(DamageCause damageCause, byte damageCausePokeID) { }

        public void ClearDeadCause()
        {
        	this.m_coreParam.deadCause = 0;
        	this.m_coreParam.deadCausePokeID = 0x1f;
        }

        public byte GetKillCount()
        {
        	return (byte)(this.m_coreParam.killCount);
        }

        public void SetKillCount(byte killCount)
        {
        	this.m_coreParam.killCount = killCount;
        }

        public void IncKillCount()
        {
        	if (this.m_coreParam.killCount != -1) {
        	  this.m_coreParam.killCount = this.m_coreParam.killCount + '\x01';
        	}
        }

        public BtlSpecialPri GetSpActPriority()
        {
        	return this.m_spActPriority;
        }

        public void SetSpActPriority(byte priority)
        {
        	this.m_spActPriority = (byte)(priority);
        }

        private void resetSpActPriority()
        {
        	this.m_spActPriority = (byte)1;
        }

        public PokemonParam GetSrcData()
        {
        	return this.m_coreParam.ppSrc;
        }

        public PokemonParam GetSrcDataConst()
        {
        	return this.m_coreParam.ppSrc;
        }

        public void SetViewSrcPokeID(byte fakeTargetPokeID)
        {
        	this.m_coreParam.fFakeEnable = 1;
        	this.m_coreParam.fakeViewTargetPokeId = fakeTargetPokeID;
        }

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

        private void dmgrec_FwdTurn()
        {
        	var bVar1 = (byte)0;
        	if ((byte)(this.m_dmgrecTurnPtr + 1U) < 3) {
        	}
        	this.m_dmgrecTurnPtr = (byte)(this.m_dmgrecTurnPtr + 1);
        	if ((uint)this.m_dmgrecTurnPtr + 1 < this.m_dmgrecCount.Length) {
        	  this.m_dmgrecCount + (ulong)this.m_dmgrecTurnPtr + 1[0] = 0;
        	}
        }

        private void confrontRec_Clear()
        {
        	this.m_coreParam.confrontRecCount = 0;
        }

        // TODO
        public void Confront_Set(byte pokeID) { }

        public byte Confront_GetCount()
        {
        	return (byte)(this.m_coreParam.confrontRecCount);
        }

        // TODO
        public byte Confront_GetPokeID(byte idx) { return 0; }

        // TODO
        public int GetValue(ValueID vid) { return 0; }

        // TODO
        public int GetValue_Base(ValueID vid) { return 0; }

        public byte GetEffortValue(PowerID powerID)
        {
        	switch(powerID) {
        	case 1:
        	  return (byte)(this.m_doryokuParam.srcPow);
        	case 2:
        	  return (byte)(this.m_doryokuParam.srcDef);
        	case 3:
        	  return (byte)(this.m_doryokuParam.srcSpPow);
        	case 4:
        	  return (byte)(this.m_doryokuParam.srcSpDef);
        	case 5:
        	  return (byte)(this.m_doryokuParam.srcAgi);
        	default:
        	  return 0;
        	}
        }

        public bool IsEffortValueFull()
        {
        	return this.m_doryokuParam.srcSum == 0x1fe;
        }

        public byte GetNativeTalentPower(PowerID powerID)
        {
        	switch(powerID) {
        	case 0:
        	  return (byte)(this.m_coreParam.native_talent_hp);
        	case 1:
        	  return (byte)(this.m_coreParam.native_talent_atk);
        	case 2:
        	  return (byte)(this.m_coreParam.native_talent_def);
        	case 3:
        	  return (byte)(this.m_coreParam.native_talent_spatk);
        	case 4:
        	  return (byte)(this.m_coreParam.native_talent_spdef);
        	case 5:
        	  return (byte)(this.m_coreParam.native_talent_agi);
        	default:
        	  return 0;
        	}
        }

        private ValueID convertValueID(ValueID vid)
        {
        	if (this.m_fldSim != null) {
        	  if ((int)vid == 0xb) {
        	    var uVar2 = this.m_fldSim.CheckEffect(4);
        	    vid = (ValueID)9;
        	    if ((uVar2 & 1) == 0) {
        	      vid = (ValueID)0xb;
        	    }
        	  }
        	  else if ((int)vid == 9) {
        	    uVar2 = this.m_fldSim.CheckEffect(4);
        	    var iVar3 = 0xb;
        	    if ((uVar2 & 1) == 0) {
        	      iVar3 = 9;
        	    }
        	    return iVar3;
        	  }
        	}
        	return vid;
        }

        public bool IsHPFull()
        {
        	return this.m_coreParam.hp ==
        	       this.m_coreParam.hpMax;
        	return false;
        }

        public bool IsDead()
        {
        	return this.m_coreParam.hp == 0;
        }

        public bool IsFightEnable()
        {
        	if ((this.m_coreParam.ppSrc.IsEgg(2) & 1) != 0) {
        	  return false;
        	}
        	return this.m_coreParam.hp != 0;
        }

        // TODO
        public bool CheckSick(WazaSick sickType) { return false; }

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

        // TODO
        public BTL_SICKCONT GetSickCont(WazaSick sick) { return default(BTL_SICKCONT); }

        public byte GetSickTurnCount(WazaSick sick)
        {
        	if (sick < this.m_coreParam.wazaSickCounter.Length) {
        	  return (byte)(this.m_coreParam.wazaSickCounter + (int)sick[0]);
        	}
        }

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

        private void clearHensin()
        {
        	if (this.m_coreParam.fHensin != 0) {
        	  setupBySrcData(0,1,1,1);
        	  wazaWork_ClearSurface();
        	  this.m_coreParam.fHensin = 0;
        	}
        }

        // TODO
        private void clearUsedWazaFlag() { }

        // TODO
        private void clearCounter() { }

        public byte WAZA_GetCount()
        {
        	return (byte)(this.m_wazaCnt);
        }

        // TODO
        public byte WAZA_GetCount_Org() { return 0; }

        // TODO
        public byte WAZA_GetUsedCountInAlive() { return 0; }

        // TODO
        public byte WAZA_GetUsedCount() { return 0; }

        // TODO
        public byte WAZA_GetUsableCount() { return 0; }

        // TODO
        public WazaNo WAZA_GetID(byte idx) { return WazaNo.NULL; }

        // TODO
        public WazaNo WAZA_GetID_Org(byte idx) { return WazaNo.NULL; }

        // TODO
        public bool WAZA_CheckUsedInAlive(byte idx) { return false; }

        // TODO
        public void WAZA_Copy(BTL_POKEPARAM bppDst) { }

        // TODO
        public byte WAZA_GetUsedCount(byte wazaIdx) { return 0; }

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

        // TODO
        public bool WAZA_IsUsable(WazaNo waza) { return false; }

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

        public byte GetOriginalPokeType1()
        {
        	this.m_coreParam.ppSrc.GetType1();
        	return 0;
        }

        public byte GetOriginalPokeType2()
        {
        	this.m_coreParam.ppSrc.GetType2();
        	return 0;
        }

        // TODO
        public bool IsMatchType(byte type) { return false; }

        // TODO
        public void SetBaseStatus(ValueID vid, ushort value) { }

        // TODO
        public int GetValue_Critical(ValueID vid) { return 0; }

        public ushort GetItem()
        {
        	return (ushort)(this.m_coreParam.item);
        }

        public void SetItem(ushort itemID)
        {
        	this.m_coreParam.item = itemID;
        }

        // TODO
        public ushort GetItemEffective(in FieldStatus fldSim) { return 0; }

        public ushort GetTotalTurnCount()
        {
        	return (ushort)(this.m_coreParam.totalTurnCount);
        }

        public void IncTotalTurnCount()
        {
        	this.m_coreParam.totalTurnCount = this.m_coreParam.totalTurnCount + 1;
        }

        public ushort GetTurnCount()
        {
        	return (ushort)(this.m_turnCount);
        }

        public ushort GetAppearTurn()
        {
        	return (ushort)(this.m_appearedTurn);
        }

        public bool TURNFLAG_Get(TurnFlag flagID)
        {
        	var uVar1 = (int)flagID >> 3 & 0xff;
        	if (uVar1 < this.m_turnFlag.Length) {
        	  return (1 << (int)((int)flagID & 7) &
        	         (uint)this.m_turnFlag + (ulong)uVar1[0]) != 0;
        	}
        	return false;
        }

        public bool CONTFLAG_Get(ContFlag flagID)
        {
        	var uVar1 = (int)flagID >> 3 & 0xff;
        	if (uVar1 < this.m_contFlag.Length) {
        	  return (1 << (int)((int)flagID & 7) &
        	         (uint)this.m_contFlag + (ulong)uVar1[0]) != 0;
        	}
        	return false;
        }

        public bool PERMFLAG_Get(PermFlag flagID)
        {
        	var uVar1 = (int)flagID >> 3 & 0xff;
        	if (uVar1 < this.m_permFlag.Length) {
        	  return (1 << (int)((int)flagID & 7) &
        	         (uint)this.m_permFlag + (ulong)uVar1[0]) != 0;
        	}
        	return false;
        }

        public void PERMFLAG_Set(PermFlag flagID)
        {
        	var uVar2 = (int)flagID >> 3 & 0xff;
        	if (uVar2 < this.m_permFlag.Length) {
        	  this.m_permFlag + (ulong)uVar2[0] = this.m_permFlag + (ulong)uVar2[0] | (byte)(1 << (int)((int)flagID & 7));
        	}
        }

        // TODO
        public ContFlag CONTFLAG_CheckWazaHide() { return ContFlag.CONTFLG_ACTION_DONE; }

        public bool IsWazaHide()
        {
        	var iVar1 = CONTFLAG_CheckWazaHide();
        	return (int)iVar1 != 0x19;
        }

        // TODO
        public bool IsUsingFreeFall() { return false; }

        // TODO
        public int GetHPRatio() { return 0; }

        // TODO
        public void SetHPRatio(int ratio) { }

        // TODO
        public uint calcHpRatio(uint maxHP, int ratio) { return 0; }

        private uint getHPBeforeG()
        {
        	if (this.m_coreParam.gParam.isGMode != 0) {
        	  var dVar4 = (double)NEON_ucvtf((ulong)this.m_coreParam.hpMax);
        	  var uVar1 = FX32.CONST((double)((uint)this.m_coreParam.hp * 100) / dVar4,0);
        	  var uVar2 = GetValue(0x10);
        	  calcHpRatio(uVar2,uVar2 & 0xffffffff,uVar1);
        	}
        	return 0;
        }

        private sbyte getRankVaryStatus(ValueID type, out sbyte min, out sbyte max)
        {
        	min = (sbyte)0;
        	max = (sbyte)0xc;
        	switch(type) {
        	case 1:
        	  return (sbyte)(this.m_varyParam.attack);
        	case 2:
        	  return (sbyte)(this.m_varyParam.defence);
        	case 3:
        	  return (sbyte)(this.m_varyParam.sp_attack);
        	case 4:
        	  return (sbyte)(this.m_varyParam.sp_defence);
        	case 5:
        	  return (sbyte)(this.m_varyParam.agility);
        	case 6:
        	  return (sbyte)(this.m_varyParam.hit);
        	case 7:
        	  return (sbyte)(this.m_varyParam.avoid);
        	default:
        	  return 0;
        	}
        }

        public bool IsRankEffectValid(ValueID rankType, int volume)
        {
        	switch(rankType) {
        	case 1:
        	  break;
        	case 2:
        	  break;
        	case 3:
        	  break;
        	case 4:
        	  break;
        	case 5:
        	  break;
        	case 6:
        	  break;
        	case 7:
        	  break;
        	default:
        	  this.m_varyParam.avoid = 0;
        	}
        	var bVar1 = 0 < this.m_varyParam.avoid;
        	if (0 < volume) {
        	  bVar1 = this.m_varyParam.avoid < '\f';
        	}
        	return bVar1;
        }

        // TODO
        public int RankEffectUpLimit(ValueID rankType) { return 0; }

        public int RankEffectDownLimit(ValueID rankType)
        {
        	switch(rankType) {
        	case 1:
        	  return (int)this.m_varyParam.attack;
        	case 2:
        	  return (int)this.m_varyParam.defence;
        	case 3:
        	  return (int)this.m_varyParam.sp_attack;
        	case 4:
        	  return (int)this.m_varyParam.sp_defence;
        	case 5:
        	  return (int)this.m_varyParam.agility;
        	case 6:
        	  return (int)this.m_varyParam.hit;
        	case 7:
        	  return (int)this.m_varyParam.avoid;
        	default:
        	  return 0;
        	}
        }

        public bool IsRankEffectDowned()
        {
        	if (((('\x05' < this.m_varyParam.attack) && ('\x05' < this.m_varyParam.defence)) &&
        	    ('\x05' < this.m_varyParam.sp_attack)) &&
        	   ((('\x05' < this.m_varyParam.sp_defence && ('\x05' < this.m_varyParam.agility)) &&
        	    ('\x05' < this.m_varyParam.hit)))) {
        	  return this.m_varyParam.avoid < '\x06';
        	}
        	return true;
        }

        public byte RankUp(ValueID rankType, byte volume)
        {
        	switch(rankType) {
        	case 1:
        	  if (this.m_varyParam.attack < '\f') {
        	    if (0xc < (int)((int)this.m_varyParam.attack + (volume & 0xff))) {
        	      volume = (byte)(0xc - (int)this.m_varyParam.attack);
        	    }
        	    this.m_varyParam.attack = (char)volume + this.m_varyParam.attack;
        	    return (byte)(volume);
        	  }
        	  break;
        	case 2:
        	  if (this.m_varyParam.defence < '\f') {
        	    if (0xc < (int)((int)this.m_varyParam.defence + (volume & 0xff))) {
        	      volume = (byte)(0xc - (int)this.m_varyParam.defence);
        	    }
        	    this.m_varyParam.defence = (char)volume + this.m_varyParam.defence;
        	    return (byte)(volume);
        	  }
        	  break;
        	case 3:
        	  if (this.m_varyParam.sp_attack < '\f') {
        	    if (0xc < (int)((int)this.m_varyParam.sp_attack + (volume & 0xff))) {
        	      volume = (byte)(0xc - (int)this.m_varyParam.sp_attack);
        	    }
        	    this.m_varyParam.sp_attack = (char)volume + this.m_varyParam.sp_attack;
        	    return (byte)(volume);
        	  }
        	  break;
        	case 4:
        	  if (this.m_varyParam.sp_defence < '\f') {
        	    if (0xc < (int)((int)this.m_varyParam.sp_defence + (volume & 0xff))) {
        	      volume = (byte)(0xc - (int)this.m_varyParam.sp_defence);
        	    }
        	    this.m_varyParam.sp_defence = (char)volume + this.m_varyParam.sp_defence;
        	    return (byte)(volume);
        	  }
        	  break;
        	case 5:
        	  if (this.m_varyParam.agility < '\f') {
        	    if (0xc < (int)((int)this.m_varyParam.agility + (volume & 0xff))) {
        	      volume = (byte)(0xc - (int)this.m_varyParam.agility);
        	    }
        	    this.m_varyParam.agility = (char)volume + this.m_varyParam.agility;
        	    return (byte)(volume);
        	  }
        	  break;
        	case 6:
        	  if (this.m_varyParam.hit < '\f') {
        	    if (0xc < (int)((int)this.m_varyParam.hit + (volume & 0xff))) {
        	      volume = (byte)(0xc - (int)this.m_varyParam.hit);
        	    }
        	    this.m_varyParam.hit = (char)volume + this.m_varyParam.hit;
        	    return (byte)(volume);
        	  }
        	  break;
        	case 7:
        	  if (this.m_varyParam.avoid < '\f') {
        	    if (0xc < (int)((int)this.m_varyParam.avoid + (volume & 0xff))) {
        	      volume = (byte)(0xc - (int)this.m_varyParam.avoid);
        	    }
        	    this.m_varyParam.avoid = (char)volume + this.m_varyParam.avoid;
        	    return (byte)(volume);
        	  }
        	}
        	return 0;
        }

        // TODO
        private byte RankUp_Core(byte volume, ref sbyte ptr) { return 0; }

        public byte RankDown(ValueID rankType, byte volume)
        {
        	switch(rankType) {
        	case 1:
        	  if (0 < this.m_varyParam.attack) {
        	    var uVar1 = (int)this.m_varyParam.attack;
        	    if ((int)(volume & 0xff) <= (int)this.m_varyParam.attack) {
        	      uVar1 = volume;
        	    }
        	    this.m_varyParam.attack = this.m_varyParam.attack - (char)uVar1;
        	    return (byte)(uVar1);
        	  }
        	  break;
        	case 2:
        	  if (0 < this.m_varyParam.defence) {
        	    uVar1 = (int)this.m_varyParam.defence;
        	    if ((int)(volume & 0xff) <= (int)this.m_varyParam.defence) {
        	      uVar1 = volume;
        	    }
        	    this.m_varyParam.defence = this.m_varyParam.defence - (char)uVar1;
        	    return (byte)(uVar1);
        	  }
        	  break;
        	case 3:
        	  if (0 < this.m_varyParam.sp_attack) {
        	    uVar1 = (int)this.m_varyParam.sp_attack;
        	    if ((int)(volume & 0xff) <= (int)this.m_varyParam.sp_attack) {
        	      uVar1 = volume;
        	    }
        	    this.m_varyParam.sp_attack = this.m_varyParam.sp_attack - (char)uVar1;
        	    return (byte)(uVar1);
        	  }
        	  break;
        	case 4:
        	  if (0 < this.m_varyParam.sp_defence) {
        	    uVar1 = (int)this.m_varyParam.sp_defence;
        	    if ((int)(volume & 0xff) <= (int)this.m_varyParam.sp_defence) {
        	      uVar1 = volume;
        	    }
        	    this.m_varyParam.sp_defence = this.m_varyParam.sp_defence - (char)uVar1;
        	    return (byte)(uVar1);
        	  }
        	  break;
        	case 5:
        	  if (0 < this.m_varyParam.agility) {
        	    uVar1 = (int)this.m_varyParam.agility;
        	    if ((int)(volume & 0xff) <= (int)this.m_varyParam.agility) {
        	      uVar1 = volume;
        	    }
        	    this.m_varyParam.agility = this.m_varyParam.agility - (char)uVar1;
        	    return (byte)(uVar1);
        	  }
        	  break;
        	case 6:
        	  if (0 < this.m_varyParam.hit) {
        	    uVar1 = (int)this.m_varyParam.hit;
        	    if ((int)(volume & 0xff) <= (int)this.m_varyParam.hit) {
        	      uVar1 = volume;
        	    }
        	    this.m_varyParam.hit = this.m_varyParam.hit - (char)uVar1;
        	    return (byte)(uVar1);
        	  }
        	  break;
        	case 7:
        	  if (0 < this.m_varyParam.avoid) {
        	    uVar1 = (int)this.m_varyParam.avoid;
        	    if ((int)(volume & 0xff) <= (int)this.m_varyParam.avoid) {
        	      uVar1 = volume;
        	    }
        	    this.m_varyParam.avoid = this.m_varyParam.avoid - (char)uVar1;
        	    return (byte)(uVar1);
        	  }
        	}
        	return 0;
        }

        // TODO
        private byte RankDown_Core(byte volume, ref sbyte ptr) { return 0; }

        public void RankSet(ValueID rankType, byte value)
        {
        	switch(rankType) {
        	case 1:
        	  if (value < 0xd) {
        	    this.m_varyParam.attack = value;
        	  }
        	  break;
        	case 2:
        	  if (value < 0xd) {
        	    this.m_varyParam.defence = value;
        	  }
        	  break;
        	case 3:
        	  if (value < 0xd) {
        	    this.m_varyParam.sp_attack = value;
        	  }
        	  break;
        	case 4:
        	  if (value < 0xd) {
        	    this.m_varyParam.sp_defence = value;
        	  }
        	  break;
        	case 5:
        	  if (value < 0xd) {
        	    this.m_varyParam.agility = value;
        	  }
        	  break;
        	case 6:
        	  if (value < 0xd) {
        	    this.m_varyParam.hit = value;
        	  }
        	  break;
        	case 7:
        	  if (value < 0xd) {
        	    this.m_varyParam.avoid = value;
        	    break;
        	  }
        	}
        }

        // TODO
        private void RankSet_Core(byte value, ref sbyte ptr) { }

        public bool RankRecover()
        {
        	var bVar1 = this.m_varyParam.attack < '\x06';
        	if (bVar1) {
        	  this.m_varyParam.attack = 6;
        	  var cVar3 = this.m_varyParam.defence;
        	}
        	else {
        	  cVar3 = (sbyte)(this.m_varyParam.defence);
        	}
        	if (cVar3 < '\x06') {
        	  this.m_varyParam.defence = 6;
        	}
        	var bVar2 = this.m_varyParam.sp_attack < '\x06';
        	if (bVar2) {
        	  this.m_varyParam.sp_attack = 6;
        	  var cVar4 = this.m_varyParam.sp_defence;
        	}
        	else {
        	  cVar4 = (sbyte)(this.m_varyParam.sp_defence);
        	}
        	if (cVar4 < '\x06') {
        	  this.m_varyParam.sp_defence = 6;
        	  var cVar5 = this.m_varyParam.agility;
        	}
        	else {
        	  cVar5 = (sbyte)(this.m_varyParam.agility);
        	}
        	if (cVar5 < '\x06') {
        	  this.m_varyParam.agility = 6;
        	  var cVar6 = this.m_varyParam.hit;
        	}
        	else {
        	  cVar6 = (sbyte)(this.m_varyParam.hit);
        	}
        	if (cVar6 < '\x06') {
        	  this.m_varyParam.hit = 6;
        	  var cVar7 = this.m_varyParam.avoid;
        	}
        	else {
        	  cVar7 = (sbyte)(this.m_varyParam.avoid);
        	}
        	if ('\x05' < cVar7) {
        	  return cVar6 < '\x06' ||
        	         (cVar5 < '\x06' || (cVar4 < '\x06' || (bVar2 || (cVar3 < '\x06' || bVar1))));
        	}
        	this.m_varyParam.avoid = 6;
        	return true;
        }

        public void RankReset()
        {
        	this.m_varyParam.sp_defence = 0x6060606;
        	this.m_varyParam.attack = 0x6060606;
        }

        public bool RankUpReset()
        {
        	var bVar1 = '\x06' < this.m_varyParam.attack;
        	if (bVar1) {
        	  this.m_varyParam.attack = 6;
        	  var cVar3 = this.m_varyParam.defence;
        	}
        	else {
        	  cVar3 = (sbyte)(this.m_varyParam.defence);
        	}
        	if ('\x06' < cVar3) {
        	  this.m_varyParam.defence = 6;
        	}
        	var bVar2 = '\x06' < this.m_varyParam.sp_attack;
        	if (bVar2) {
        	  this.m_varyParam.sp_attack = 6;
        	  var cVar4 = this.m_varyParam.sp_defence;
        	}
        	else {
        	  cVar4 = (sbyte)(this.m_varyParam.sp_defence);
        	}
        	if ('\x06' < cVar4) {
        	  this.m_varyParam.sp_defence = 6;
        	  var cVar5 = this.m_varyParam.agility;
        	}
        	else {
        	  cVar5 = (sbyte)(this.m_varyParam.agility);
        	}
        	if ('\x06' < cVar5) {
        	  this.m_varyParam.agility = 6;
        	  var cVar6 = this.m_varyParam.hit;
        	}
        	else {
        	  cVar6 = (sbyte)(this.m_varyParam.hit);
        	}
        	if ('\x06' < cVar6) {
        	  this.m_varyParam.hit = 6;
        	  var cVar7 = this.m_varyParam.avoid;
        	}
        	else {
        	  cVar7 = (sbyte)(this.m_varyParam.avoid);
        	}
        	if (cVar7 < '\a') {
        	  return '\x06' < cVar6 ||
        	         ('\x06' < cVar5 || ('\x06' < cVar4 || (bVar2 || ('\x06' < cVar3 || bVar1))));
        	}
        	this.m_varyParam.avoid = 6;
        	return true;
        }

        // TODO
        public byte GetCriticalRank() { return 0; }

        public byte GetCriticalRankPure()
        {
        	return (byte)(this.m_criticalRank);
        }

        public bool AddCriticalRank(int value)
        {
        	if (value < 1) {
        	  if (this.m_criticalRank != 0) {
        	    if (-value < (int)(uint)this.m_criticalRank) {
        	      this.m_criticalRank = (byte)(this.m_criticalRank + (char)value);
        	      return true;
        	    }
        	    this.m_criticalRank = (byte)0;
        	    return true;
        	  }
        	}
        	else if (this.m_criticalRank < 3) {
        	  var uVar1 = (byte)(uint)this.m_criticalRank + value;
        	  if (2 < ((uint)this.m_criticalRank + value & 0xff)) {
        	    uVar1 = 3;
        	  }
        	  this.m_criticalRank = (byte)(uVar1);
        	  return true;
        	}
        	return false;
        }

        public void SetCriticalRank(byte rank)
        {
        	if (rank < 4) {
        	  this.m_criticalRank = (byte)(rank);
        	}
        }

        public void HpMinus(ushort value)
        {
        	var uVar1 = 0;
        	if ((uint)(value * 0x10000) <= (uint)this.m_coreParam.hp * 0x10000) {
        	  uVar1 = (short)((uint)this.m_coreParam.hp * 0x10000 + value * -0x10000 >> 0x10);
        	}
        	this.m_coreParam.hp = uVar1;
        }

        public void HpPlus(ushort value)
        {
        	this.m_coreParam.hp =
        	     this.m_coreParam.hp + value;
        	if (this.m_coreParam.hpMax < this.m_coreParam.hp) {
        	  this.m_coreParam.hp = this.m_coreParam.hpMax;
        	}
        }

        public void HpZero()
        {
        	this.m_coreParam.hp = 0;
        }

        public void TURNFLAG_Set(TurnFlag flagID)
        {
        	var uVar2 = (int)flagID >> 3 & 0xff;
        	if (uVar2 < this.m_turnFlag.Length) {
        	  this.m_turnFlag + (ulong)uVar2[0] = this.m_turnFlag + (ulong)uVar2[0] | (byte)(1 << (int)((int)flagID & 7));
        	}
        }

        public void CONTFLAG_Set(ContFlag flagID)
        {
        	var uVar2 = (int)flagID >> 3 & 0xff;
        	if (uVar2 < this.m_contFlag.Length) {
        	  this.m_contFlag + (ulong)uVar2[0] = this.m_contFlag + (ulong)uVar2[0] | (byte)(1 << (int)((int)flagID & 7));
        	}
        }

        public void CONTFLAG_Clear(ContFlag flagID)
        {
        	var uVar2 = (int)flagID >> 3 & 0xff;
        	if (uVar2 < this.m_contFlag.Length) {
        	  this.m_contFlag + (ulong)uVar2[0] = this.m_contFlag + (ulong)uVar2[0] & ((byte)(1 << (int)((int)flagID & 7)) ^ 0xff);
        	}
        }

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

        public void SetAppearTurn(ushort turn)
        {
        	this.m_appearedTurn = (ushort)(turn);
        	this.m_turnCount = (ushort)0;
        	this.m_coreParam.fBtlIn = 1;
        	dmgrec_ClearWork();
        }

        // TODO
        public void TurnCheck() { }

        public void TURNFLAG_ForceOff(TurnFlag flagID)
        {
        	var uVar2 = (int)flagID >> 3 & 0xff;
        	if (uVar2 < this.m_turnFlag.Length) {
        	  this.m_turnFlag + (ulong)uVar2[0] = this.m_turnFlag + (ulong)uVar2[0] & ((byte)(1 << (int)((int)flagID & 7)) ^ 0xff);
        	}
        }

        // TODO
        public void Clear_ForDead() { }

        // TODO
        public void Clear_ForOut() { }

        // TODO
        public void Clear_ForIn() { }

        // TODO
        public void CopyBatonTouchParams(BTL_POKEPARAM user) { }

        public bool ChangePokeType(PokeTypePair type, ExTypeCause exTypeCause)
        {
        	long uVar5;
        	var cVar1 = this.m_baseParam.type1;
        	var cVar2 = this.m_baseParam.type2;
        	var cVar3 = this.m_baseParam.type_ex;
        	var uVar4 = PokeTypePair.GetType1(type);
        	this.m_baseParam.type1 = uVar4;
        	uVar4 = (byte)(PokeTypePair.GetType2(type));
        	this.m_baseParam.type2 = uVar4;
        	uVar4 = (byte)(PokeTypePair.GetTypeEx(type));
        	this.m_baseParam.type_ex = uVar4;
        	this.m_baseParam.type_ex_cause = exTypeCause;
        	if ((((cVar1 == this.m_baseParam.type1) && (cVar2 == this.m_baseParam.type2)) ||
        	    ((cVar2 == this.m_baseParam.type1 && (cVar1 == this.m_baseParam.type2)))) &&
        	   (cVar3 == this.m_baseParam.type_ex)) {
        	  uVar5 = 0;
        	}
        	else {
        	  uVar5 = 1;
        	}
        	return uVar5;
        }

        public void ExPokeType(byte type, ExTypeCause exTypeCause)
        {
        	if ((this.m_baseParam.type1 != type) && (this.m_baseParam.type2 != type)) {
        	  this.m_baseParam.type_ex = type;
        	  this.m_baseParam.type_ex_cause = exTypeCause;
        	}
        }

        public byte GetExType()
        {
        	return (byte)(this.m_baseParam.type_ex);
        }

        public bool HaveExType()
        {
        	return this.m_baseParam.type_ex != '\x12';
        }

        public ExTypeCause GetExTypeCause()
        {
        	return this.m_baseParam.type_ex_cause;
        }

        public void ChangeTokusei(TokuseiNo tok)
        {
        	this.m_tokusei = (ushort)(tok);
        }

        // TODO
        public void ChangeForm(byte formNo, bool dontResetFormByOut = false) { }

        private void correctMaxHP()
        {
        	uint uVar6;
        	var cVar2 = this.m_coreParam.gParam.isGMode;
        	var uVar3 = this.m_coreParam.hp;
        	var uVar4 = this.m_coreParam.hpMax;
        	if (!cVar2) {
        	  uVar6 = this.m_coreParam.ppSrc.GetPower_NotG(0);
        	  cVar2 = this.m_coreParam.isRaidBoss;
        	}
        	else {
        	  uVar6 = CoreParam.GetPower_G();
        	  cVar2 = this.m_coreParam.isRaidBoss;
        	}
        	if (cVar2) {
        	  var fVar8 = (float)this.m_coreParam.raidBossParam.GetHPCoef();
        	  uVar6 = (uint)(fVar8 * (float)(uVar6 & 0xffff));
        	}
        	this.m_coreParam.hpMax = (short)uVar6;
        	if ((uint)uVar4 < (uVar6 & 0xffff)) {
        	  this.m_coreParam.hp =
        	       ((short)uVar6 - uVar4) + this.m_coreParam.hp;
        	  if (this.m_coreParam.hpMax < this.m_coreParam.hp) {
        	    this.m_coreParam.hp = this.m_coreParam.hpMax;
        	  }
        	}
        	if (((uVar6 & 0xffff) < (uint)uVar4) && ((uVar6 & 0xffff) < (uint)uVar3)) {
        	  var iVar5 = uVar3 - uVar6;
        	  var uVar1 = 0;
        	  if ((uint)(iVar5 * 0x10000) <= (uint)this.m_coreParam.hp * 0x10000) {
        	    uVar1 = (short)((uint)this.m_coreParam.hp * 0x10000 + iVar5 * -0x10000 >> 0x10);
        	  }
        	  this.m_coreParam.hp = uVar1;
        	}
        }

        public void RemoveItem()
        {
        	this.m_coreParam.usedItem =
        	     this.m_coreParam.item;
        	this.m_coreParam.item = 0;
        }

        public void ConsumeItem(ushort itemID)
        {
        	this.m_coreParam.usedItem = itemID;
        	this.m_coreParam.item = 0;
        }

        public void ClearConsumedItem()
        {
        	this.m_coreParam.usedItem = 0;
        }

        public ushort GetConsumedItem()
        {
        	return (ushort)(this.m_coreParam.usedItem);
        }

        public void UpdateWazaProcResult(BtlPokePos actTargetPos, byte actWazaType, bool fActEnable, WazaNo actWaza, WazaNo orgWaza)
        {
        	this.m_prevActWazaID = (WazaNo)(actWaza);
        	this.m_prevSelectWazaID = (WazaNo)(orgWaza);
        	this.m_prevTargetPos = (BtlPokePos)(actTargetPos);
        	this.m_prevWazaType = (byte)(actWazaType);
        	if (this.m_prevActWazaID != actWaza) {
        	  this.m_wazaContCounter = (ushort)((fActEnable ? 1 : 0) & 1);
        	}
        	if (fActEnable) {
        	  this.m_wazaContCounter = (ushort)(this.m_wazaContCounter + 1);
        	}
        	this.m_wazaContCounter = (ushort)0;
        }

        public uint GetWazaContCounter()
        {
        	return this.m_wazaContCounter;
        }

        public WazaNo GetPrevWazaID()
        {
        	return this.m_prevActWazaID;
        }

        public byte GetPrevWazaType()
        {
        	return (byte)(this.m_prevWazaType);
        }

        public WazaNo GetPrevOrgWazaID()
        {
        	return this.m_prevSelectWazaID;
        }

        public BtlPokePos GetPrevTargetPos()
        {
        	return this.m_prevTargetPos;
        }

        public bool GetBtlInFlag()
        {
        	return this.m_coreParam.fBtlIn;
        }

        public void SetWeight(ushort weight)
        {
        	if (weight == 0) {
        	  weight = (ushort)1;
        	}
        	this.m_weight = (ushort)(weight);
        }

        public ushort GetWeight()
        {
        	return (ushort)(this.m_weight);
        }

        // TODO
        public void WAZADMGREC_Add(WAZADMG_REC rec) { }

        public byte WAZADMGREC_GetCount(byte turn_ridx)
        {
        	if (2 < turn_ridx) {
        	  return 0;
        	}
        	if ((int)(uint)this.m_dmgrecTurnPtr - (uint)turn_ridx < 0) {
        	  (uint)this.m_dmgrecTurnPtr - (uint)turn_ridx = (uint)this.m_dmgrecTurnPtr - (uint)turn_ridx + 3;
        	}
        	if ((uint)this.m_dmgrecTurnPtr - (uint)turn_ridx < this.m_dmgrecCount.Length) {
        	  return (byte)(this.m_dmgrecCount + (int)(uint)this.m_dmgrecTurnPtr - (uint)turn_ridx[0]);
        	}
        }

        // TODO
        public bool WAZADMGREC_Get(byte turn_ridx, byte rec_ridx, WAZADMG_REC dst) { return false; }

        public void COUNTER_Set(Counter cnt, byte value)
        {
        	if (cnt < this.m_counter.Length) {
        	  this.m_counter + (int)cnt[0] = value;
        	}
        }

        // TODO
        public void COUNTER_Inc(Counter cnt) { }

        public byte COUNTER_Get(Counter cnt)
        {
        	if (cnt < this.m_counter.Length) {
        	  return (byte)(this.m_counter + (int)cnt[0]);
        	}
        }

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

        public bool IsFakeEnable()
        {
        	return this.m_coreParam.fFakeEnable;
        }

        public void FakeDisable()
        {
        	this.m_coreParam.fFakeEnable = 0;
        	this.m_coreParam.fakeViewTargetPokeId = 0x1f;
        }

        public byte GetFakeTargetPokeID()
        {
        	return (byte)(this.m_coreParam.fakeViewTargetPokeId);
        }

        // TODO
        public bool HENSIN_CheckEnable(BTL_POKEPARAM target) { return false; }

        // TODO
        public void HENSIN_Set(BTL_POKEPARAM target) { }

        // TODO
        private void henshinCopyFrom(in BTL_POKEPARAM src) { }

        public bool HENSIN_Check()
        {
        	return this.m_coreParam.fHensin;
        }

        public void MIGAWARI_Create(ushort migawariHP)
        {
        	this.m_migawariHP = (ushort)(migawariHP);
        	CureWazaSick(8);
        }

        public void MIGAWARI_Delete()
        {
        	this.m_migawariHP = (ushort)0;
        }

        public bool MIGAWARI_IsExist()
        {
        	return this.m_migawariHP != 0;
        }

        public uint MIGAWARI_GetHP()
        {
        	return this.m_migawariHP;
        }

        public bool MIGAWARI_AddDamage(ref ushort damage)
        {
        	var iVar2 = (uint)this.m_migawariHP - (uint)damage;
        	if ((uint)damage <= (uint)this.m_migawariHP && iVar2 != 0) {
        	  this.m_migawariHP = (ushort)((short)iVar2);
        	  return false;
        	}
        	damage = (ushort)(this.m_migawariHP);
        	this.m_migawariHP = (ushort)0;
        	return true;
        }

        // TODO
        public void CONFRONT_REC_Set(byte pokeID) { }

        public byte CONFRONT_REC_GetCount()
        {
        	return (byte)(this.m_coreParam.confrontRecCount);
        }

        // TODO
        public byte CONFRONT_REC_GetPokeID(byte idx) { return 0; }

        public bool CONFRONT_REC_IsMatch(byte pokeID)
        {
        	if (this.m_coreParam.confrontRecCount != 0) {
        	  var bVar3 = (byte)0;
        	  do {
        	    if (this.m_coreParam.confrontRec.Length <= (uint)bVar3) {
        	    }
        	    if (this.m_coreParam.confrontRec + (ulong)bVar3[0] == pokeID) {
        	      return true;
        	    }
        	    bVar3 = (byte)(bVar3 + 1);
        	  } while (bVar3 < this.m_coreParam.confrontRecCount);
        	}
        	return false;
        }

        public void SetCaptureBallID(ushort ballItemID)
        {
        	var cVar2 = ItemData.GetBallID(ballItemID);
        	var cVar1 = '\x04';
        	if (cVar2 != 0) {
        	  cVar1 = cVar2;
        	}
        	this.m_coreParam.ppSrc.SetMemories(8,cVar1);
        	if (cVar1 == '\x16') {
        	  this.m_coreParam.ppSrc.SetFriendship(0x96);
        	}
        }

        public void CombiWaza_SetParam(byte combiPokeID, WazaNo combiUsedWaza)
        {
        	this.m_combiPokeID = (byte)(combiPokeID);
        	this.m_combiWazaID = (WazaNo)(combiUsedWaza);
        }

        public bool CombiWaza_GetParam(out byte combiPokeID, out WazaNo combiUsedWaza)
        {
        	if (this.m_combiPokeID == '\x1f') {
        	  combiPokeID = (byte)('\x1f');
        	  combiUsedWaza = (WazaNo)0;
        	  return false;
        	}
        	combiPokeID = (byte)(this.m_combiPokeID);
        	combiUsedWaza = (WazaNo)(this.m_combiWazaID);
        	return true;
        }

        public bool CombiWaza_IsSetParam()
        {
        	return this.m_combiPokeID != '\x1f';
        }

        public void CombiWaza_ClearParam()
        {
        	if (this.m_combiPokeID != '\x1f') {
        	  this.m_combiPokeID = (byte)0x1f;
        	  this.m_combiWazaID = (WazaNo)0;
        	}
        }

        // TODO
        public bool IsMatchTokusei(TokuseiNo tokusei) { return false; }

        public bool HavePokerus()
        {
        	return this.m_doryokuParam.bPokerus;
        }

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

        public void AddEffortG(byte value)
        {
        	this.m_doryokuParam.srcG =
        	     this.m_doryokuParam.srcG + value;
        	if (10 < this.m_doryokuParam.srcG) {
        	  this.m_doryokuParam.srcG = 10;
        	}
        	this.m_doryokuParam.bModified = 1;
        }

        // TODO
        public void SetRaidBoss(byte grade, in RaidBossDesc desc) { }

        public bool IsRaidBoss()
        {
        	return this.m_coreParam.isRaidBoss;
        }

        public RaidBossParam GetRaidBossParam()
        {
        	return this.m_coreParam.raidBossParam;
        }

        public bool IsGMode()
        {
        	return this.m_coreParam.gParam.isGMode;
        }

        // TODO
        public bool IsSpecialG() { return false; }

        // TODO
        public bool CanStartG() { return false; }

        // TODO
        public void StartGMode() { }

        // TODO
        public void EndGMode() { }

        public byte GetGModePassedTurnCount()
        {
        	return (byte)(this.m_coreParam.gParam.passedTurnCount);
        }

        public void IncGModePassedTurnCount()
        {
        	var uVar2 = GMode.GetMaxTurn(0);
        	if (this.m_coreParam.gParam.passedTurnCount < uVar2) {
        	  this.m_coreParam.gParam.passedTurnCount = this.m_coreParam.gParam.passedTurnCount + '\x01';
        	}
        }

        // TODO
        public bool IsSpecialGEnable() { return false; }

        public void ReflectForExpUI([Optional] PokemonParam pp)
        {
        	if (pp != null) {
        	  pp.SetItem(this.m_coreParam.item);
        	}
        	this.m_coreParam.ppSrc.SetItem(this.m_coreParam.item);
        }

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
