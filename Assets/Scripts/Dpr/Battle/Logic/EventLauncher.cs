using Pml;
using Pml.Battle;
using Pml.PokePara;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
    public sealed class EventLauncher
    {
        private readonly MainModule m_pMainModule;
        private EventSystem m_pEventSystem;
        private BattleEnv m_pBattleEnv;
        private const int FALSE = 0;
        private const int TRUE = 1;

        private static EventVar.Label LABEL_OFFSET(EventVar.Label label, uint i)
        {
            return (EventVar.Label)((short)i + (ushort)label);
        }

        public EventLauncher(in SetupParam setupParam)
        {
            m_pMainModule = setupParam.pMainModule;
            m_pEventSystem = setupParam.pEventSystem;
            m_pBattleEnv = setupParam.pBattleEnv;
        }

        // TODO
        public WazaNo Event_ChangeGWaza(BTL_POKEPARAM attacker, WazaNo gWaza, WazaNo srcWaza) { return WazaNo.NULL; }

        // TODO
        public void Event_GetWazaParam(WazaNo waza, WazaNo orgWaza, WazaNo gSrcWaza, int wazaPri, BTL_POKEPARAM attacker, WazaParam param) { }

        // TODO
        public bool Event_CheckMigawariThrew(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaNo waza) { return false; }

        // TODO
        public bool Event_CheckCritical(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaNo waza, ref bool pByFriendship) { return false; }

        // TODO
        public bool Event_CalcDamage(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam, TypeAffinity.AffinityID typeAff, int targetDmgRatio, bool isCritical, bool isRandDisable, bool isMigawariExist, BtlWeather defLocalWeather, out ushort dstDamage)
        {
            dstDamage = 0;
            return false;
        }

        // TODO
        public BtlWeather Event_GetWeather() { return BtlWeather.BTL_WEATHER_NONE; }

        // TODO
        public BtlWeather Event_CheckLocalWeather(byte pokeID, BtlWeather weather) { return BtlWeather.BTL_WEATHER_NONE; }

        // TODO
        public ushort Event_getWazaPower(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam) { return 0; }

        // TODO
        public ushort Event_getAttackPower(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam, bool isCritical, out bool isYakedoDisable)
        {
            isYakedoDisable = false;
            return 0;
        }

        // TODO
        public BTL_POKEPARAM.ValueID Event_getAttackerPowerVID(BTL_POKEPARAM attacker, WazaParam wazaParam) { return BTL_POKEPARAM.ValueID.BPP_VALUE_NULL; }

        // TODO
        public bool shouldAttackerPowerFlat(BTL_POKEPARAM attacker, BTL_POKEPARAM.ValueID vid, bool isCritical) { return false; }

        // TODO
        public ushort Event_getDefenderGuard(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam, bool isCritical) { return 0; }

        // TODO
        public int Event_CalcTypeMatchRatio(BTL_POKEPARAM attacker, byte waza_type) { return 0; }

        // TODO
        public TypeAffinity.AffinityID Event_CheckDamageAffinity(in BTL_POKEPARAM attacker, in BTL_POKEPARAM defender, byte wazaType, bool onlyAttacker) { return TypeAffinity.AffinityID.TYPEAFF_0; }

        // TODO
        public TypeAffinity.AffinityID Event_CheckDamageAffinity(in BTL_POKEPARAM attacker, in BTL_POKEPARAM defender, byte waza_type, byte defenderType, bool onlyAttacker) { return TypeAffinity.AffinityID.TYPEAFF_0; }

        // TODO
        public TypeAffinity.AffinityID Event_RewriteWazaAffinity(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, byte wazaType, TypeAffinity.AffinityID affinity) { return TypeAffinity.AffinityID.TYPEAFF_0; }

        // TODO
        public bool Event_CheckFloating(BTL_POKEPARAM poke, bool isIncludeHikouType) { return false; }

        // TODO
        public bool Event_AffineFloatingCancel(BTL_POKEPARAM attacker, BTL_POKEPARAM defender) { return false; }

        // TODO
        public uint Event_CalcKickBack(BTL_POKEPARAM attacker, WazaNo waza, uint inDamage, out bool isMustEnable)
        {
            isMustEnable = false;
            return 0;
        }

        // TODO
        public bool Event_CheckEnableSimpleDamage(BTL_POKEPARAM bpp, uint damage, DamageCause damageCause) { return false; }

        // TODO
        public void Event_SimpleDamage_Before(in BTL_POKEPARAM bpp, uint damage) { }

        // TODO
        public void Event_SimpleDamage_After(in BTL_POKEPARAM bpp, uint damage) { }

        // TODO
        public bool Event_CheckIchigeki(ref bool pIsFailMsgDisplayed, BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam) { return false; }

        // TODO
        public uint Event_getHitPer(EventID eventID, BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam) { return 0; }

        // TODO
        public bool Event_CheckIchigekiGuard(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam) { return false; }

        public void Event_IchigekiSucceed(BTL_POKEPARAM attacker, BTL_POKEPARAM target)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = attacker.GetID();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(3,uVar1);
        	uVar1 = target.GetID();
        	this.m_pEventSystem.EVENTVAR_SetRewriteOnceValue(4,uVar1);
        	this.m_pEventSystem.CallEvent(0xdb);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        // TODO
        public bool Event_SkipNigeruCalc(BTL_POKEPARAM bpp) { return false; }

        public void Event_ChangePokeBefore(BTL_POKEPARAM bpp)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = bpp.GetID();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(2,uVar1);
        	this.m_pEventSystem.CallEvent(0xd1);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        public void Event_ChangeTokuseiAfter(byte pokeID)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(2,pokeID);
        	this.m_pEventSystem.CallEvent(0xac);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        // TODO
        public void Event_WazaExeEnd_Common(byte pokeID, WazaNo waza, in ActionDesc actionDesc, EventID eventID) { }

        public void Event_GetWazaRankEffectValue(WazaNo waza, uint waza_effect_index, BTL_POKEPARAM attacker, BTL_POKEPARAM target, out WazaRankEffect effect, out int volume)
        {
        	var iVar2 = WAZADATA.GetRankEffect(waza,waza_effect_index,volume);
        	effect = (WazaRankEffect)(iVar2);
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = attacker.GetID();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(3,uVar1);
        	uVar1 = target.GetID();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(4,uVar1);
        	this.m_pEventSystem.EVENTVAR_SetValue(0x22,effect);
        	this.m_pEventSystem.EVENTVAR_SetValue(0x23,volume);
        	this.m_pEventSystem.EVENTVAR_SetValue(0x38,1);
        	this.m_pEventSystem.CallEvent(0x71);
        	effect = (WazaRankEffect)(this.m_pEventSystem.EVENTVAR_GetValue(0x22));
        	volume = this.m_pEventSystem.EVENTVAR_GetValue(0x23);
        	if (1 < (this.m_pEventSystem.EVENTVAR_GetValue(0x38) & 0xff)) {
        	  volume = volume * (this.m_pEventSystem.EVENTVAR_GetValue(0x38) & 0xff);
        	}
        	this.m_pEventSystem.EVENTVAR_Pop();
        	if ((int)effect == 8) {
        	  effect = (WazaRankEffect)0;
        	}
        }

        // TODO
        public void Event_WazaRankEffectFixed(BTL_POKEPARAM target, WazaNo wazaID, WazaRankEffect effectID, int volume) { }

        // TODO
        public void Event_RankEffect_Failed(BTL_POKEPARAM target, uint wazaRankEffSerial) { }

        // TODO
        public bool Event_CheckRankEffectSuccess(BTL_POKEPARAM target, WazaRankEffect effect, byte wazaUsePokeID, int volume, RankEffectCause cause, uint wazaRankEffSerial) { return false; }

        // TODO
        public int Event_RankValueChange(BTL_POKEPARAM target, WazaRankEffect rankType, byte wazaUsePokeID, ushort itemID, int volume) { return 0; }

        // TODO
        public void Event_RankEffect_Fix(byte atkPokeID, BTL_POKEPARAM bpp, WazaRankEffect rankType, int volume) { }

        // TODO
        public bool Event_CheckRankEffectReflect(BTL_POKEPARAM target, byte wazaUsePokeID, WazaRankEffect effect, int volume, RankEffectCause cause) { return false; }

        // TODO
        public void Event_RankEffectReflect(BTL_POKEPARAM target, byte wazaUsePokeID, WazaRankEffect effect, int volume) { }

        // TODO
        public void Event_UnDamageProcEnd(WazaParam wazaParam, BTL_POKEPARAM attacker) { }

        public void Event_TurnEnd()
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	this.m_pEventSystem.CallEvent(0xdf);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        // TODO
        public byte Event_GetWazaPriority(WazaNo waza, BTL_POKEPARAM bpp) { return 0; }

        // TODO
        public ushort Event_CalcAgility(BTL_POKEPARAM attacker, bool fTrickRoomEnable) { return 0; }

        // TODO
        public void Event_ActProcStart(PokeAction action) { }

        // TODO
        public void Event_ActProcEnd(BTL_POKEPARAM bpp, PokeActionCategory actionCmd) { }

        // TODO
        public void Event_ActProcCanceled(PokeAction action) { }

        // TODO
        public bool Event_CheckInemuriFail(BTL_POKEPARAM bpp) { return false; }

        public void Event_AfterMove(BTL_POKEPARAM bpp)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = bpp.GetID();
        	this.m_pEventSystem.EVENTVAR_SetValue(2,uVar1);
        	this.m_pEventSystem.CallEvent(200);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        // TODO
        public bool Event_CheckNigeruForbid(BTL_POKEPARAM bpp) { return false; }

        // TODO
        public bool Event_NigeruExMessage(BTL_POKEPARAM bpp) { return false; }

        public void Event_AfterMemberIn(BTL_POKEPARAM bpp, EventID eventID)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = bpp.GetID();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(2,uVar1);
        	this.m_pEventSystem.CallEvent(eventID);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        public void Event_AfterMemberInForce(BTL_POKEPARAM bpp, EventID eventID)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = bpp.GetID();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(2,uVar1);
        	this.m_pEventSystem.CallEvent_Force(eventID);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        public void Event_AfterMemberInComp()
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	this.m_pEventSystem.CallEvent(0x6f);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        public void Event_DasshutuPackLaunch()
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	this.m_pEventSystem.CallEvent(0x70);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        public void Event_MemberOutFixed(BTL_POKEPARAM outPoke)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = outPoke.GetID();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(2,uVar1);
        	this.m_pEventSystem.CallEvent(0x68);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        // TODO
        public void Event_ReplaceActWaza(BTL_POKEPARAM attacker, WazaNo originWaza, WazaNo nextWaza) { }

        // TODO
        public void Event_AfterWazaParamFixed(BTL_POKEPARAM attacker, WazaNo orgWazaID, WazaNo actWazaID) { }

        // TODO
        public void Event_CheckCombiWazaExe(BTL_POKEPARAM attacker, WazaParam wazaParam) { }

        // TODO
        public void Event_WazaCallDecide(BTL_POKEPARAM attacker, WazaParam wazaParamOrg, WazaParam wazaParamAct) { }

        // TODO
        public void Event_WazaExeDecide(BTL_POKEPARAM attacker, WazaParam wazaParam, EventID evType) { }

        // TODO
        public void Event_CheckDelayWazaSet(in BTL_POKEPARAM attacker, ref BtlPokePos targetPos, out bool isTried, out bool isSuccessed)
        {
            isTried = false;
            isSuccessed = false;
        }

        public void Event_DecideDelayWaza(in BTL_POKEPARAM attacker)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = attacker.GetID();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(3,uVar1);
        	this.m_pEventSystem.CallEvent(7);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        // TODO
        public void Event_StartWazaSeq(BTL_POKEPARAM attacker, WazaNo waza) { }

        // TODO
        public void Event_EndWazaSeq(BTL_POKEPARAM attacker, WazaNo waza, bool fWazaEnable, ActionDesc actionDesc) { }

        // TODO
        public void Event_WazaRob(BTL_POKEPARAM robPoke, BTL_POKEPARAM orgAtkPoke, WazaNo waza) { }

        // TODO
        public void Event_WazaReflect(BTL_POKEPARAM robPoke, BTL_POKEPARAM orgAtkPoke, WazaNo waza) { }

        // TODO
        public bool Event_CheckWazaRob(BTL_POKEPARAM attacker, WazaNo waza, PokeSet targetRec, ref byte robberPokeID, ref byte robTargetPokeID) { return false; }

        // TODO
        public bool Event_IsRemoveAllFailCancel(BTL_POKEPARAM attacker, WazaParam wazaParam) { return false; }

        // TODO
        public bool Event_WazaAffineCheckEnable(WazaParam wazaParam, BTL_POKEPARAM attacker) { return false; }

        // TODO
        public void Event_checkNoEffectBySideEffectGuard_Begin(WazaParam wazaParam, BTL_POKEPARAM attacker, PokeSet targets) { }

        // TODO
        public void Event_checkNoEffectBySideEffectGuard_End(WazaParam wazaParam, BTL_POKEPARAM attacker, PokeSet targets) { }

        // TODO
        public void Event_MamoruSuccess(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaParam wazaParam) { }

        // TODO
        public void Event_CheckNotEffect(WazaParam wazaParam, BTL_POKEPARAM attacker, BTL_POKEPARAM defender, DmgAffRec affinityRecorder, EventID eventID, out bool isNoEffect, out bool isNoReaction, out bool isNoEffectMessageDisplayed, out bool isTokuseiWindowDisplay, StrParam customMessage)
        {
            isNoEffect = false;
            isNoReaction = false;
            isNoEffectMessageDisplayed = false;
            isTokuseiWindowDisplay = false;
        }

        // TODO
        public bool Event_SkipAvoidCheck(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam) { return false; }

        // TODO
        public bool Event_CheckHit(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam, out bool bFriendshipActive)
        {
            bFriendshipActive = false;
            return false;
        }

        // TODO
        public void Event_WazaAvoid(BTL_POKEPARAM attacker, bool fDelayAttack) { }

        // TODO
        public bool Event_Check_FreeFallStart_Guard(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaParam wazaParam, StrParam strParam) { return false; }

        // TODO
        public void Event_TameReleaseFailed(BTL_POKEPARAM attacker, PokeSet targetRec, WazaParam wazaParam) { }

        // TODO
        public bool Event_ExeFailThrew(BTL_POKEPARAM bpp, WazaNo waza, WazaFailCause cause) { return false; }

        // TODO
        public WazaFailCause Event_CheckWazaExecute(BTL_POKEPARAM attacker, WazaNo waza, EventID eventID, WazaParam wazaParam, PokeSet targets)
        {
            return WazaFailCause.NONE;
        }

        // TODO
        public bool Event_IsWazaMeltMustFail(BTL_POKEPARAM attacker, WazaNo waza) { return false; }

        // TODO
        public uint Event_DecrementPPVolume(BTL_POKEPARAM attacker, byte wazaIdx, WazaNo waza, PokeSet rec) { return 0; }

        // TODO
        public bool Event_CheckAttackerDeadPreTarget(BTL_POKEPARAM attacker, WazaParam wazaParam) { return false; }

        // TODO
        public void Event_WazaDamageDetermine(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam) { }

        // TODO
        public KoraeruCause Event_CheckKoraeru(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, bool isWazaDamage, ref ushort damage) { return KoraeruCause.NONE; }

        public void Event_KoraeruExe(BTL_POKEPARAM poke, KoraeruCause cause)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = poke.GetID();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(2,uVar1);
        	this.m_pEventSystem.CallEvent(0x90);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        // TODO
        public void Event_WazaDamageSideAfter(BTL_POKEPARAM attacker, WazaParam wazaParam, uint damage) { }

        // TODO
        public void Event_CheckItemReaction(BTL_POKEPARAM bpp, byte reactionType) { }

        // TODO
        public void Event_DamageProcStart(BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet targets) { }

        // TODO
        public void Event_DamageProcEndSub(BTL_POKEPARAM attacker, PokeSet targets, ActionDesc actionDesc, WazaParam wazaParam, bool fDelayAttack, bool fRealHitOnly, EventID eventID) { }

        // TODO
        public void Event_DamageProcEnd(BTL_POKEPARAM attacker, PokeSet targets, WazaParam wazaParam, bool fDelayAttack) { }

        // TODO
        public void Event_SimpleDamage_Failed(in BTL_POKEPARAM bpp, DamageCause damageCause, byte damageCausePokeID) { }

        // TODO
        public bool Event_CheckItemEquipFail(BTL_POKEPARAM bpp, ushort itemID) { return false; }

        // TODO
        public void Event_AfterItemEquip(BTL_POKEPARAM bpp, ushort itemID, bool bCheckKinomi) { }

        public void Event_KillHandler(BTL_POKEPARAM target, byte atkPokeID)
        {
        	var uVar1 = target.GetID();
        	this.m_pEventSystem.EVENTVAR_Push();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(4,uVar1);
        	this.m_pEventSystem.EVENTVAR_SetConstValue(3,atkPokeID);
        	this.m_pEventSystem.CallEvent(0xcf);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        // TODO
        public WazaSick Event_CheckWazaAddSick(WazaNo waza, BTL_POKEPARAM attacker, BTL_POKEPARAM defender, out BTL_SICKCONT pSickCont)
        {
            pSickCont = default;
            return WazaSick.WAZASICK_NONE;
        }

        public uint Event_CheckSpecialWazaAdditionalPer(byte atkPokeID, byte defPokeID, uint defaultPer)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(4,defPokeID);
        	this.m_pEventSystem.EVENTVAR_SetConstValue(3,atkPokeID);
        	this.m_pEventSystem.EVENTVAR_SetValue(0x29,defaultPer);
        	this.m_pEventSystem.CallEvent(0xcd);
        	this.m_pEventSystem.EVENTVAR_Pop();
        	return this.m_pEventSystem.EVENTVAR_GetValue(0x29);
        }

        // TODO
        public void Event_CheckRecoverMsgCustom(StrParam pCustomMsg, BTL_POKEPARAM pAttacker, BTL_POKEPARAM pTarget, WazaNo wazano) { }

        // TODO
        public void Event_GetWazaSickAddStr(WazaSick sick, BTL_POKEPARAM attacker, BTL_POKEPARAM defender, StrParam str) { }

        // TODO
        public void Event_WazaSickCont(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaSick sick, BTL_SICKCONTOBJ sickCont) { }

        // TODO
        public bool Event_CheckAddSickFailStdSkip(BTL_POKEPARAM target, BTL_POKEPARAM attacker, WazaSick sick, SickCause cause) { return false; }

        // TODO
        public bool Event_WazaSick_CheckFail(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaSick sick, SickCause cause, ref bool bCallFailedEvent) { return false; }

        // TODO
        public void Event_AddSick_Failed(BTL_POKEPARAM target, BTL_POKEPARAM attacker, WazaSick sick, SickCause cause, uint wazaSerial) { }

        // TODO
        public void Event_PokeSickFixed(BTL_POKEPARAM target, BTL_POKEPARAM attacker, Sick sick, BTL_SICKCONT inSickCont) { }

        // TODO
        public void Event_WazaSickFixed(BTL_POKEPARAM target, BTL_POKEPARAM attacker, WazaSick sick) { }

        // TODO
        public bool Event_CheckKodawariFactorExist(BTL_POKEPARAM poke) { return false; }

        public void Event_TokuseiDisabled(BTL_POKEPARAM target)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = target.GetID();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(2,uVar1);
        	this.m_pEventSystem.CallEvent_Force(0x83);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        // TODO
        public bool Event_CheckAddRankEffectOccur(WazaParam wazaParam, BTL_POKEPARAM attacker, BTL_POKEPARAM target) { return false; }

        // TODO
        public ushort Event_CheckPushOutEffectNo(BTL_POKEPARAM attacker, WazaNo waza) { return 0; }

        // TODO
        public void Event_CheckPushOutFail(out bool isFailed, out bool isFailMessageDisplayed, BTL_POKEPARAM attacker, BTL_POKEPARAM target)
        {
            isFailed = false;
            isFailMessageDisplayed = false;
        }

        // TODO
        public byte Event_WazaWeatherTurnUp(BtlWeather weather, BTL_POKEPARAM attacker) { return 0; }

        // TODO
        public bool Event_CheckChangeWeather(BtlWeather weather, ref byte turn) { return false; }

        // TODO
        public void Event_ChangeGroundBefore(byte pokeID, byte ground, ref BTL_SICKCONT contParam) { }

        // TODO
        public void Event_ChangeGroundAfter(byte pokeID, byte ground) { }

        public bool Event_FieldEffectCall(BTL_POKEPARAM attacker, WazaNo waza)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = attacker.GetID();
        	this.m_pEventSystem.EVENTVAR_SetValue(3,uVar1);
        	this.m_pEventSystem.EVENTVAR_SetValue(0x12,waza);
        	this.m_pEventSystem.EVENTVAR_SetValue(0x78,0);
        	this.m_pEventSystem.CallEvent(0xc2);
        	this.m_pEventSystem.EVENTVAR_Pop();
        	return this.m_pEventSystem.EVENTVAR_GetValue(0x78) != 0;
        }

        // TODO
        public void Event_ChangeFieldAfter(byte pokeID, EffectType field) { }

        // TODO
        public void Event_WazaDamageReaction(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam, TypeAffinity.AffinityID aff, uint damage, bool fCritical, bool fMigawari) { }

        // TODO
        public bool Event_UnCategoryWaza(WazaParam wazaParam, BTL_POKEPARAM attacker, PokeSet targets, out bool fFailMsgEnable)
        {
            fFailMsgEnable = false;
            return false;
        }

        public void Event_TurnCheck(byte pokeID, EventID event_type)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(2,pokeID);
        	this.m_pEventSystem.CallEvent(event_type);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        // TODO
        public uint Event_SickDamage(BTL_POKEPARAM bpp, WazaSick sickID, uint damage) { return 0; }

        // TODO
        public int Event_CheckWeatherReaction(BTL_POKEPARAM bpp, BtlWeather weather, uint damage) { return 0; }

        public void Event_PokeDeadActionAfter(byte deadPokeID)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	this.m_pEventSystem.EVENTVAR_SetValue(2,deadPokeID);
        	this.m_pEventSystem.CallEvent(0xd5);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        public void Event_PokeDeadAfter(byte deadPokeID)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	this.m_pEventSystem.EVENTVAR_SetValue(2,deadPokeID);
        	this.m_pEventSystem.CallEvent(0xd6);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        public void Event_BeforeDead(BTL_POKEPARAM bpp)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = bpp.GetID();
        	this.m_pEventSystem.EVENTVAR_SetValue(2,uVar1);
        	this.m_pEventSystem.CallEvent(199);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        // TODO
        public void Event_AfterCritical(WazaParam wazaParam, BTL_POKEPARAM attacker, BTL_POKEPARAM defender) { }

        // TODO
        public bool Event_GetReqWazaParam(BTL_POKEPARAM attacker, WazaNo orgWazaId, BtlPokePos orgTargetPos, REQWAZA_WORK reqWaza) { return false; }

        // TODO
        public byte Event_CheckSpecialActPriority(BTL_POKEPARAM attacker) { return 0; }

        public void Event_BeforeFight(BTL_POKEPARAM bpp, WazaNo waza)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = bpp.GetID();
        	this.m_pEventSystem.EVENTVAR_SetValue(2,uVar1);
        	this.m_pEventSystem.EVENTVAR_SetValue(0x12,waza);
        	this.m_pEventSystem.CallEvent(0x17);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        public void Event_FixConfDamage(BTL_POKEPARAM poke, ref ushort damage)
        {
        	var uVar2 = damage;
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = poke.GetID();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(2,uVar1);
        	this.m_pEventSystem.EVENTVAR_SetValue(0x3a,uVar2);
        	this.m_pEventSystem.EVENTVAR_SetValue(0x3b,0);
        	this.m_pEventSystem.EVENTVAR_SetValue(0x3c,0);
        	this.m_pEventSystem.CallEvent(0x15);
        	this.m_pEventSystem.EVENTVAR_Pop();
        	if (this.m_pEventSystem.EVENTVAR_GetValue(0x3b) != 0 || EventSystem.EVENTVAR_GetValue(this.m_pEventSystem,0x3c) != 0) {
        	  if (this.m_pEventSystem.EVENTVAR_GetValue(0x3c) != 0) {
        	    this.m_pEventSystem.EVENTVAR_GetValue(0x3a) = 0;
        	  }
        	  damage = (ushort)(this.m_pEventSystem.EVENTVAR_GetValue(0x3a));
        	}
        }

        public void Event_ConfDamageReaction(BTL_POKEPARAM attacker, BTL_POKEPARAM defender)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = attacker.GetID();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(3,uVar1);
        	uVar1 = defender.GetID();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(4,uVar1);
        	this.m_pEventSystem.CallEvent(0x16);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        // TODO
        public bool Event_CheckWazaMsgCustom(BTL_POKEPARAM attacker, WazaNo orgWazaID, WazaNo actWazaID, StrParam str) { return false; }

        // TODO
        public void Event_CheckWazaExeFail(BTL_POKEPARAM bpp, WazaNo waza, WazaFailCause cause) { }

        // TODO
        public WazaForceEnableMode Event_WazaExecuteStart(ActionDesc actionDesc, BTL_POKEPARAM attacker, WazaParam wazaParam, PokeSet rec, WazaEffectParams pWazaEffectParams) { return default; }

        public bool Event_CheckMamoruBreak(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaNo waza)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = attacker.GetID();
        	this.m_pEventSystem.EVENTVAR_SetValue(3,uVar1);
        	this.m_pEventSystem.EVENTVAR_SetValue(0x59,0);
        	this.m_pEventSystem.CallEvent(0x3a);
        	this.m_pEventSystem.EVENTVAR_Pop();
        	return this.m_pEventSystem.EVENTVAR_GetValue(0x59) != 0;
        }

        // TODO
        public bool Event_CheckTameFail(BTL_POKEPARAM attacker, PokeSet targetRec) { return false; }

        // TODO
        public bool Event_CheckTameTurnSkip(BTL_POKEPARAM attacker, WazaNo waza) { return false; }

        // TODO
        public bool Event_TameStart(BTL_POKEPARAM attacker, PokeSet targetRec, WazaParam wazaParam, ref byte hideTargetPokeID, ref bool fFailMsgDisped) { return false; }

        public void Event_TameStartFixed(BTL_POKEPARAM attacker)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = attacker.GetID();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(3,uVar1);
        	this.m_pEventSystem.CallEvent(0xb9);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        public void Event_TameSkip(BTL_POKEPARAM attacker, WazaNo waza)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = attacker.GetID();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(3,uVar1);
        	this.m_pEventSystem.CallEvent(0xba);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        // TODO
        public bool Event_TameRelease(BTL_POKEPARAM attacker, PokeSet rec, WazaNo waza) { return false; }

        // TODO
        public bool Event_CheckPokeHideAvoid(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaNo waza, ref bool bEnableAvoidMsg) { return false; }

        // TODO
        public bool Event_IsCalcHitCancel(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaNo waza) { return false; }

        // TODO
        public bool Event_CheckDmgToRecover(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam) { return false; }

        public void Event_DmgToRecover(BTL_POKEPARAM attacker, BTL_POKEPARAM defender)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = attacker.GetID();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(3,uVar1);
        	uVar1 = defender.GetID();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(4,uVar1);
        	this.m_pEventSystem.CallEvent(0x3d);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        // TODO
        public bool Event_CheckKinomiEffectUp(BTL_POKEPARAM poke, out bool pNeedTokuseiWindowDisplayOnItemUseAct)
        {
            pNeedTokuseiWindowDisplayOnItemUseAct = false;
            return false;
        }

        // TODO
        public bool Event_CheckKinomiEffectUp(BTL_POKEPARAM poke) { return false; }

        // TODO
        public bool Event_ItemEquip(BTL_POKEPARAM poke, out bool pNeedTokuseiWindowDisplayOnItemUseAct, out bool pNeedToConsumeItemMessageDisplay)
        {
            pNeedTokuseiWindowDisplayOnItemUseAct = false;
            pNeedToConsumeItemMessageDisplay = false;
            return false;
        }

        // TODO
        public bool Event_ItemEquipTmp(BTL_POKEPARAM target, byte atkPokeID, out bool pNeedTokuseiWindowDisplayOnItemUseAct)
        {
            pNeedTokuseiWindowDisplayOnItemUseAct = false;
            return false;
        }

        // TODO
        public bool Event_WazaNoEffectByFlying(BTL_POKEPARAM poke) { return false; }

        // TODO
        public bool Event_DecrementPP_Reaction(BTL_POKEPARAM attacker, byte wazaIdx) { return false; }

        public void Event_HitCheckParam(BTL_POKEPARAM attacker, WazaNo waza, HITCHECK_PARAM param, bool fDelayAttack)
        {
            uint max = WAZADATA.GetHitCountMax(waza);
            uint rolled;

            if (max == 0 || max == 1)
            {
                rolled = 1;
                max = 1;
            }
            else
            {
                rolled = calc.HitCountStd((byte)max);
            }

            param.count = 0;
            param.pluralHitAffinity = TypeAffinity.AffinityID.TYPEAFF_1;

            var byteMax = (byte)(max % 256);

            m_pEventSystem.EVENTVAR_Push();
            m_pEventSystem.EVENTVAR_SetConstValue(EventVar.Label.POKEID_ATK, attacker.GetID());
            m_pEventSystem.EVENTVAR_SetConstValue(EventVar.Label.HITCOUNT_MAX, byteMax);
            m_pEventSystem.EVENTVAR_SetConstValue(EventVar.Label.WAZAID, (int)waza);
            m_pEventSystem.EVENTVAR_SetConstValue(EventVar.Label.DELAY_ATTACK_FLAG, fDelayAttack ? TRUE : FALSE);
            m_pEventSystem.EVENTVAR_SetValue(EventVar.Label.HITCOUNT, (int)rolled);
            m_pEventSystem.EVENTVAR_SetRewriteOnceValue(EventVar.Label.GEN_FLAG, FALSE);
            m_pEventSystem.EVENTVAR_SetRewriteOnceValue(EventVar.Label.AVOID_FLAG, FALSE);
            m_pEventSystem.CallEvent(EventID.WAZA_HIT_COUNT);

            var actualCount = m_pEventSystem.EVENTVAR_GetValue(EventVar.Label.HITCOUNT);

            if (byteMax < 2)
            {
                if (actualCount == 0 || actualCount == 1)
                {
                    param.needCheckEveryTime = false;
                    param.isPluralHitWaza = false;
                    param.isDeadMessageDisplay = true;
                    param.isAffinityMessageDisplay = true;
                    param.countMax = 1;
                }
                else
                {
                    param.countMax = (byte)actualCount;
                    param.needCheckEveryTime = m_pEventSystem.EVENTVAR_GetValue(EventVar.Label.AVOID_FLAG) != FALSE;
                    param.isPluralHitWaza = false;
                    param.isDeadMessageDisplay = false;
                    param.isAffinityMessageDisplay = false;
                }
            }
            else if (byteMax < 6 && m_pEventSystem.EVENTVAR_GetValue(EventVar.Label.GEN_FLAG) != FALSE)
            {
                param.countMax = (byte)max;
                param.needCheckEveryTime = false;
                param.isPluralHitWaza = true;
                param.isDeadMessageDisplay = false;
                param.isAffinityMessageDisplay = false;
            }
            else
            {
                param.countMax = (byte)actualCount;
                param.needCheckEveryTime = m_pEventSystem.EVENTVAR_GetValue(EventVar.Label.AVOID_FLAG) != FALSE;
                param.isPluralHitWaza = true;
                param.isDeadMessageDisplay = false;
                param.isAffinityMessageDisplay = false;
            }

            m_pEventSystem.EVENTVAR_Pop();
        }

        // TODO
        public uint Event_GetWazaShrinkPer(WazaNo waza, BTL_POKEPARAM attacker) { return 0; }

        // TODO
        public bool Event_CheckShrink(BTL_POKEPARAM target, uint percentage) { return false; }

        public void Event_FailShrink(BTL_POKEPARAM target)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = target.GetID();
        	this.m_pEventSystem.EVENTVAR_SetValue(2,uVar1);
        	this.m_pEventSystem.CallEvent(0x87);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        // TODO
        public ushort Event_RecalcDrainVolume(BTL_POKEPARAM attacker, BTL_POKEPARAM target, ushort volume) { return 0; }

        // TODO
        public void Event_AfterChangeWeather(BtlWeather weather) { }

        // TODO
        public uint Event_CalcWazaRecoverHP(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaNo waza) { return 0; }

        // TODO
        public bool Event_CheckItemSet(BTL_POKEPARAM bpp, ushort itemID) { return false; }

        public void Event_ItemSetFailed(BTL_POKEPARAM bpp)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = bpp.GetID();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(2,uVar1);
        	this.m_pEventSystem.CallEvent(0xbf);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        // TODO
        public void Event_ItemSetDecide(BTL_POKEPARAM bpp, ushort nextItemID) { }

        public void Event_ItemSetFixed(BTL_POKEPARAM bpp)
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	var uVar1 = bpp.GetID();
        	this.m_pEventSystem.EVENTVAR_SetConstValue(2,uVar1);
        	this.m_pEventSystem.CallEvent(0xc1);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        // TODO
        public void Event_ChangeTokuseiBefore(byte pokeID, TokuseiNo prev_tokuseiID, ushort next_tokuseiID) { }

        // TODO
        public void Event_CheckSideEffectParam(byte userPokeID, BtlSideEffect effect, BtlSide side, BTL_SICKCONTOBJ cont) { }

        public void Event_NotifyAirLock()
        {
        	this.m_pEventSystem.EVENTVAR_Push();
        	this.m_pEventSystem.CallEvent(0x94);
        	this.m_pEventSystem.EVENTVAR_Pop();
        }

        // TODO
        public bool Event_CheckTokuseiChangeEnable(byte targetPokeID, TokuseiNo nextTokusei, TokuseiChangeCause cause) { return false; }

        // TODO
        public void Event_TokuseiChangeFailed(byte targetPokeID, TokuseiNo nextTokusei, TokuseiChangeCause cause) { }

        // TODO
        public byte Event_GetWazaTargetIntr(BTL_POKEPARAM attacker, WazaParam wazaParam) { return 0; }

        // TODO
        public bool Event_CheckWazaTargetTemptEnable(BTL_POKEPARAM attacker, in bool enable) { return false; }

        // TODO
        public byte Event_GetWazaTargetTempt(BTL_POKEPARAM attacker, WazaParam wazaParam, byte defaultTargetPokeID, out TemptTargetCause outTemptCause)
        {
            outTemptCause = TemptTargetCause.NONE;
            return 0;
        }

        // TODO
        public void Event_WazaTargetTemptEnd(BTL_POKEPARAM attacker, ushort temptPokeId, WazaParam wazaParam, TemptTargetCause temptCause) { }

        // TODO
        public int svEvent_GetWeightRatio(BTL_POKEPARAM bpp) { return 0; }

        // TODO
        public bool Event_CheckAimTargetEnable(BTL_POKEPARAM attacker, WazaParam wazaParam) { return false; }

        // TODO
        public bool Event_CheckWazaTargetIncrease(BTL_POKEPARAM attacker, BTL_POKEPARAM defender, BTL_POKEPARAM target) { return false; }

        // TODO
        public bool Event_CheckHitCountMessageDisplay(BTL_POKEPARAM attacker) { return false; }

        private bool perOccur(byte per, out byte rnd)
        {
            uint rolledRnd = calc.GetRand(100);
            rnd = (byte)rolledRnd;
            return (rolledRnd & 0xFF) < per;
        }

        public class SetupParam
        {
            public MainModule pMainModule;
            public EventSystem pEventSystem;
            public BattleEnv pBattleEnv;
        }

        public enum ReactionType : int
        {
            SV_REACTION_NONE = 0,
            SV_REACTION_DAMAGE = 1,
            SV_REACTION_HP = 2,
        }
    }
}