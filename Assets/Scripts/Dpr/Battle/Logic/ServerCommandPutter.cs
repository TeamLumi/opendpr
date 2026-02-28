using Pml;
using Pml.Battle;
using Pml.PokePara;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
    public sealed class ServerCommandPutter
    {
        private readonly MainModule m_pMainModule;
        private BattleEnv m_pBattleEnv;
        private ServerCommandQueue m_pQueue;
        private ServerCommandExecutor m_pExecutor;

        // TODO
        private static void SCQUE_PUT_OP_HpMinus(ServerCommandQueue queue, byte pokeID, ushort value, DamageCause damageCause, byte damageCausePokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_HpMinusForSyncWazaEffect(ServerCommandQueue queue, byte pokeID, ushort value, DamageCause damageCause, byte damageCausePokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_HpPlus(ServerCommandQueue queue, byte pokeID, ushort value) { }

        // TODO
        private static void SCQUE_PUT_OP_HpZero(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_PPMinus(ServerCommandQueue queue, byte pokeID, byte wazaIdx, byte value) { }

        // TODO
        private static void SCQUE_PUT_OP_PPMinus_Org(ServerCommandQueue queue, byte pokeID, byte wazaIdx, byte value) { }

        // TODO
        private static void SCQUE_PUT_OP_WazaUsed(ServerCommandQueue queue, byte pokeID, byte wazaIdx) { }

        // TODO
        private static void SCQUE_PUT_OP_IncWazaUsedCount(ServerCommandQueue queue, byte pokeID, byte wazaIdx) { }

        // TODO
        private static void SCQUE_PUT_OP_IncWazaKillCount(ServerCommandQueue queue, byte pokeID, byte wazaIdx) { }

        // TODO
        private static void SCQUE_PUT_OP_PPPlus(ServerCommandQueue queue, byte pokeID, byte wazaIdx, byte value) { }

        // TODO
        private static void SCQUE_PUT_OP_PPPlus_Org(ServerCommandQueue queue, byte pokeID, byte wazaIdx, byte value) { }

        // TODO
        private static void SCQUE_PUT_OP_RankUp(ServerCommandQueue queue, byte pokeID, byte statusType, byte volume) { }

        // TODO
        private static void SCQUE_PUT_OP_RankDown(ServerCommandQueue queue, byte pokeID, byte statusType, byte volume) { }

        // TODO
        private static void SCQUE_PUT_OP_RankSet8(ServerCommandQueue queue, byte pokeID, byte atk, byte def, byte sp_atk, byte sp_def, byte agi, byte hit, byte avoid, byte critical) { }

        // TODO
        private static void SCQUE_PUT_OP_RankRecover(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_RankUpReset(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_RankReset(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_AddCritical(ServerCommandQueue queue, byte pokeID, int value) { }

        // TODO
        private static void SCQUE_PUT_OP_SetSick(ServerCommandQueue queue, byte pokeID, byte sick, in BTL_SICKCONT contParam) { }

        // TODO
        private static void SCQUE_PUT_OP_CurePokeSick(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_CureWazaSick(ServerCommandQueue queue, byte pokeID, ushort sickID) { }

        // TODO
        private static void SCQUE_PUT_OP_MemberIn(ServerCommandQueue queue, byte clientID, byte posIdx, byte memberIdx, ushort turnCount) { }

        // TODO
        private static void SCQUE_PUT_OP_SetStatus(ServerCommandQueue queue, byte pokeID, byte vid, ushort value) { }

        // TODO
        private static void SCQUE_PUT_OP_SetWeight(ServerCommandQueue queue, byte pokeID, ushort weight) { }

        // TODO
        private static void SCQUE_PUT_OP_WazaSickTurnCheck(ServerCommandQueue queue, byte pokeID, WazaSick sick) { }

        // TODO
        private static void SCQUE_PUT_OP_ChangePokeType(ServerCommandQueue queue, byte pokeID, ushort nextType, BTL_POKEPARAM.ExTypeCause exTypeCause) { }

        // TODO
        private static void SCQUE_PUT_OP_ExPokeType(ServerCommandQueue queue, byte pokeID, byte exType, BTL_POKEPARAM.ExTypeCause exTypeCause) { }

        // TODO
        private static void SCQUE_PUT_OP_ConsumeItem(ServerCommandQueue queue, byte pokeID, ushort itemID) { }

        // TODO
        private static void SCQUE_PUT_OP_UpdateWazaProcResult(ServerCommandQueue queue, byte pokeID, BtlPokePos actTargetPos, byte actWazaType, bool fActEnable, WazaNo actWaza, WazaNo orgWaza) { }

        // TODO
        private static void SCQUE_PUT_OP_SetTurnFlag(ServerCommandQueue queue, byte pokeID, BTL_POKEPARAM.TurnFlag flag) { }

        // TODO
        private static void SCQUE_PUT_OP_ResetTurnFlag(ServerCommandQueue queue, byte pokeID, BTL_POKEPARAM.TurnFlag flag) { }

        // TODO
        private static void SCQUE_PUT_OP_SetContFlag(ServerCommandQueue queue, byte pokeID, ContFlag flag) { }

        // TODO
        private static void SCQUE_PUT_OP_ResetContFlag(ServerCommandQueue queue, byte pokeID, ContFlag flag) { }

        // TODO
        private static void SCQUE_PUT_OP_SetPermFlag(ServerCommandQueue queue, byte pokeID, BTL_POKEPARAM.PermFlag flag) { }

        // TODO
        private static void SCQUE_PUT_OP_IncPokeTurnCount(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_ChangeTokusei(ServerCommandQueue queue, byte pokeID, TokuseiNo tokusei) { }

        // TODO
        private static void SCQUE_PUT_OP_SetItem(ServerCommandQueue queue, byte pokeID, ushort itemID) { }

        // TODO
        private static void SCQUE_PUT_OP_UpdateWaza(ServerCommandQueue queue, byte pokeID, byte wazaIdx, WazaNo wazaID, byte ppMax, bool fPermanent) { }

        // TODO
        private static void SCQUE_PUT_OP_OutClear(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_DeadClear(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_SetBattleFlag(ServerCommandQueue queue, BattleFlags.Flag flag) { }

        // TODO
        private static void SCQUE_PUT_OP_RemoveBattleFlag(ServerCommandQueue queue, BattleFlags.Flag flag) { }

        // TODO
        private static void SCQUE_PUT_OP_IncBattleCount(ServerCommandQueue queue, BattleCounter.UniqueCounter counterID) { }

        // TODO
        private static void SCQUE_PUT_OP_DecBattleCount(ServerCommandQueue queue, BattleCounter.UniqueCounter counterID) { }

        // TODO
        private static void SCQUE_PUT_OP_IncBattleCount(ServerCommandQueue queue, BattleCounter.ClientCounter counterID, BTL_CLIENT_ID clientID) { }

        // TODO
        private static void SCQUE_PUT_OP_IncBattleCount(ServerCommandQueue queue, BattleCounter.SideCounter counterID, BtlSide side) { }

        // TODO
        private static void SCQUE_OP_ChangeGround(ServerCommandQueue queue, BtlGround ground, in BTL_SICKCONT contParam) { }

        // TODO
        private static void SCQUE_PUT_OP_AddFieldEffect(ServerCommandQueue queue, EffectType effect, in BTL_SICKCONT cont) { }

        // TODO
        private static void SCQUE_PUT_OP_RemoveFieldEffect(ServerCommandQueue queue, EffectType effect) { }

        // TODO
        private static void SCQUE_PUT_OP_AddFieldEffectDepend(ServerCommandQueue queue, EffectType effect, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_DeleteDependPokeFieldEffect(ServerCommandQueue queue, byte causedPokeID, EffectType fieldEffect) { }

        // TODO
        private static void SCQUE_PUT_OP_SetPokeCounter(ServerCommandQueue queue, byte pokeID, byte counterID, byte value) { }

        // TODO
        private static void SCQUE_PUT_OP_SetPokePermCounter(ServerCommandQueue queue, byte pokeID, BTL_POKEPARAM.PermCounter counterID, uint value) { }

        // TODO
        private static void SCQUE_PUT_OP_AddPokePermCounter(ServerCommandQueue queue, byte pokeID, BTL_POKEPARAM.PermCounter counterID, uint value) { }

        // TODO
        private static void SCQUE_PUT_OP_IncKillCount(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_BatonTouch(ServerCommandQueue queue, byte userPokeID, byte targetPokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_MigawariCreate(ServerCommandQueue queue, byte pokeID, ushort migawariHP) { }

        // TODO
        private static void SCQUE_PUT_OP_MigawariDelete(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_SetIllusionForParty(ServerCommandQueue queue, BTL_CLIENT_ID clientID) { }

        // TODO
        private static void SCQUE_PUT_OP_FakeDisable(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_ClearConsumedItem(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_CureDependPokeSick(ServerCommandQueue queue, byte pokeID, byte causePokeID) { }

        // TODO
        private static void SCQUE_OP_AddWazaDmgRec(ServerCommandQueue queue, byte defPokeID, byte atkPokeID, BtlPokePos atkPokePos, byte wazaType, WazaDamageType damageType, ushort wazaID, ushort damage) { }

        // TODO
        private static void SCQUE_PUT_OP_TurnCheck(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_IncFieldTurn(ServerCommandQueue queue, EffectType effect) { }

        // TODO
        private static void SCQUE_PUT_OP_Doryoku(ServerCommandQueue queue, byte pokeID, byte hp, byte pow, byte def, byte sp_pow, byte sp_def, byte agi) { }

        // TODO
        private static void SCQUE_PUT_OP_AddEffort_G(ServerCommandQueue queue, byte pokeID, byte value) { }

        // TODO
        private static void SCQUE_OP_StartPosEffect(ServerCommandQueue queue, BtlPosEffect effect, BtlPokePos pos, uint effectParam) { }

        // TODO
        public static void SCQUE_OP_RemovePosEffect(ServerCommandQueue queue, BtlPosEffect effect, BtlPokePos pos) { }

        // TODO
        public static void SCQUE_OP_UpdatePosEffectParam(ServerCommandQueue queue, BtlPosEffect effect, BtlPokePos pos, uint effectParam) { }

        // TODO
        private static void SCQUE_PUT_OP_PGLRecord(ServerCommandQueue queue, byte defPokeID, byte atkPokeID, ushort atkWazaNo) { }

        // TODO
        private static void SCQUE_PUT_OP_SideEffect_Add(ServerCommandQueue queue, BtlSide side, BtlSideEffect sideEffect, in BTL_SICKCONT contParam) { }

        // TODO
        private static void SCQUE_PUT_OP_SideEffect_Remove(ServerCommandQueue queue, BtlSide side, BtlSideEffect sideEffect) { }

        // TODO
        private static void SCQUE_PUT_OP_SideEffect_IncTurnCount(ServerCommandQueue queue, BtlSide side, BtlSideEffect sideEffect) { }

        // TODO
        private static void SCQUE_PUT_OP_SideEffect_Swap(ServerCommandQueue queue, BtlSide side1, BtlSide side2, BtlSideEffect sideEffect) { }

        // TODO
        private static void SCQUE_PUT_OP_PublishClientInformation_AppearedPokemon(ServerCommandQueue queue, byte appeardPokeId) { }

        // TODO
        private static void SCQUE_PUT_OP_PublishClientInformation_HavePokemonItem(ServerCommandQueue queue, byte pokeID, bool haveItem) { }

        // TODO
        private static void SCQUE_PUT_ACT_WazaEffect(ServerCommandQueue queue, BtlPokePos atPokePos, BtlPokePos defPokePos, WazaNo waza, byte wazaType, byte arg, byte pluralHitIndex, bool bSyncDamageEffect, bool isGShockOccur) { }

        // TODO
        private static void SCQUE_PUT_ACT_TameWazaHide(ServerCommandQueue queue, byte pokeID, bool hideFlag) { }

        // TODO
        private static void SCQUE_PUT_ACT_WazaDamage(ServerCommandQueue queue, byte defPokeID, TypeAffinity.AboutAffinityID affAbout, WazaNo wazaID) { }

        // TODO
        private static void SCQUE_PUT_ACT_WazaDamagePlural(ServerCommandQueue queue, byte pokeCnt, byte affAbout, ushort wazaID) { }

        // TODO
        private static void SCQUE_PUT_ACT_MigawariDamage(ServerCommandQueue queue, byte defPokeID, TypeAffinity.AffinityID affine, WazaNo waza) { }

        // TODO
        private static void SCQUE_PUT_ACT_WazaIchigeki(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_ACT_SickIcon(ServerCommandQueue queue, byte pokeID, Sick sick) { }

        // TODO
        private static void SCQUE_PUT_ACT_ConfDamage(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_ACT_RankUp(ServerCommandQueue queue, byte pokeID, byte statusType, byte volume, RankEffectViewType viewType) { }

        // TODO
        private static void SCQUE_PUT_ACT_RankDown(ServerCommandQueue queue, byte pokeID, byte statusType, byte volume, RankEffectViewType viewType) { }

        // TODO
        private static void SCQUE_PUT_ACT_Dead(ServerCommandQueue queue, byte pokeID, bool isKillCountEffect) { }

        // TODO
        private static void SCQUE_PUT_ACT_RelivePoke(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_ACT_MemberOutMsg(ServerCommandQueue queue, byte clientID, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_ACT_MemberOut(ServerCommandQueue queue, BtlPokePos pos, ushort effectNo) { }

        // TODO
        private static void SCQUE_PUT_ACT_MemberIn(ServerCommandQueue queue, byte clientID, byte posIdx, byte memberIdx, bool fPutMsg) { }

        // TODO
        private static void SCQUE_PUT_ACTOP_WeatherStart(ServerCommandQueue queue, byte weather, byte turn, byte turnUpCount, byte causePokeID, ChangeWeatherCause cause) { }

        // TODO
        private static void SCQUE_PUT_ACT_WeatherEnd(ServerCommandQueue queue, byte weather) { }

        // TODO
        private static void SCQUE_PUT_OP_WeatherEnd(ServerCommandQueue queue) { }

        // TODO
        private static void SCQUE_PUT_ACT_SimpleHP(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_ACT_USE_ITEM(ServerCommandQueue queue, byte pokeID, byte bNuts) { }

        // TODO
        private static void SCQUE_PUT_ACT_KINOMI_PRE_WAZA(ServerCommandQueue queue, byte pokeCnt, byte pokeID_1, byte pokeID_2, byte pokeID_3, byte pokeID_4, byte pokeID_5) { }

        // TODO
        private static void SCQUE_PUT_ACT_Kill(ServerCommandQueue queue, byte pokeID, byte effectType) { }

        // TODO
        private static void SCQUE_PUT_OP_MemberMove(ServerCommandQueue queue, byte clientID, BtlPokePos pos1, BtlPokePos pos2) { }

        // TODO
        private static void SCQUE_PUT_ACT_MemberMove(ServerCommandQueue queue, byte clientID, BtlPokePos pos1, BtlPokePos pos2) { }

        // TODO
        private static void SCQUE_PUT_ACT_AddExp_InitParam(ServerCommandQueue queue) { }

        // TODO
        private static void SCQUE_PUT_ACT_AddExp_AddParam(ServerCommandQueue queue, byte pokeID, uint exp, uint effort_hp, uint effort_pow, uint effort_def, uint effort_sp_pow, uint effort_sp_def, uint effort_agi) { }

        // TODO
        private static void SCQUE_PUT_ACT_AddExp(ServerCommandQueue queue) { }

        // TODO
        private static void SCQUE_PUT_OP_AddExp(ServerCommandQueue queue, byte pokeID, uint exp) { }

        // TODO
        private static void SCQUE_PUT_ACT_BallThrow(ServerCommandQueue queue, BtlPokePos userPos, BtlPokePos targetPos, byte yureCnt, bool fSuccess, bool fZukanRegister, bool fCritical, ushort ballItemID) { }

        // TODO
        private static void SCQUE_PUT_ACT_BallThrow_Captured(ServerCommandQueue queue, BtlPokePos pos, bool bZukanRegister) { }

        // TODO
        private static void SCQUE_PUT_ACT_BallThrowForbidden(ServerCommandQueue queue, BtlPokePos targetPos, ushort ballItemID, BallThrowForbiddenCause cause) { }

        // TODO
        private static void SCQUE_PUT_ACTOP_ChangeTokusei(ServerCommandQueue queue, byte pokeID, ushort tokuseiID) { }

        // TODO
        private static void SCQUE_PUT_ACTOP_SkillSwap(ServerCommandQueue queue, byte pokeID_1, byte pokeID_2, TokuseiNo tokID_1, TokuseiNo tokID_2) { }

        // TODO
        private static void SCQUE_PUT_ACT_FakeDisable(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_ACT_EffectSimple(ServerCommandQueue queue, ushort effectNo) { }

        // TODO
        private static void SCQUE_PUT_ACT_EffectByPos(ServerCommandQueue queue, BtlPokePos pos, ushort effectNo) { }

        // TODO
        private static void SCQUE_PUT_ACT_EffectByVector(ServerCommandQueue queue, BtlPokePos pos_from, BtlPokePos pos_to, ushort effectNo) { }

        // TODO
        private static void SCQUE_PUT_ACT_EffectBySide(ServerCommandQueue queue, BtlPokePos pos_from, BtlPokePos pos_to, ushort effectNo) { }

        // TODO
        private static void SCQUE_PUT_ACT_ChangeGround(ServerCommandQueue queue, BtlGround ground) { }

        // TODO
        private static void SCQUE_PUT_ACT_ExPlural2ndHit(ServerCommandQueue queue, BtlPokePos pos, ushort effectNo) { }

        // TODO
        private static void SCQUE_PUT_ACT_ChangeForm(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_ChangeForm(ServerCommandQueue queue, byte pokeID, byte formNo, bool dontResetFormByOut) { }

        // TODO
        private static void SCQUE_PUT_OP_Hensin(ServerCommandQueue queue, byte userID, byte targetID) { }

        // TODO
        private static void SCQUE_PUT_OP_AddWazaHandler(ServerCommandQueue queue, byte pokeID, WazaNo waza, uint subPri) { }

        // TODO
        private static void SCQUE_PUT_OP_RemoveWazaHandler(ServerCommandQueue queue, byte pokeID, WazaNo waza) { }

        // TODO
        private static void SCQUE_PUT_OP_RemoveForceWazaHandler(ServerCommandQueue queue, byte pokeID, WazaNo waza) { }

        // TODO
        private static void SCQUE_PUT_OP_RemoveForceAllWazaHandler(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_AddTokuseiHandler(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_RemoveTokuseiHandler(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_SwapTokuseiHandler(ServerCommandQueue queue, byte pokeID1, byte pokeID2) { }

        // TODO
        private static void SCQUE_PUT_OP_AddItemHandler(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_RemoveItemHandler(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_AddPosEffectHandler(ServerCommandQueue queue, BtlPosEffect effect, BtlPokePos pos, byte pokeID, int[] param, byte param_cnt) { }

        // TODO
        private static void SCQUE_PUT_OP_RemovePosHandler(ServerCommandQueue queue, BtlPosEffect effect, BtlPokePos pos) { }

        // TODO
        private static void SCQUE_PUT_OP_AddSideHandler(ServerCommandQueue queue, BtlSide side, BtlSideEffect sideEffect, in BTL_SICKCONT contParam) { }

        // TODO
        private static void SCQUE_PUT_OP_RemoveSideHandler(ServerCommandQueue queue, BtlSide side, BtlSideEffect sideEffect) { }

        // TODO
        private static void SCQUE_PUT_OP_SleepSideHandler(ServerCommandQueue queue, BtlSide side, BtlSideEffect sideEffect) { }

        // TODO
        private static void SCQUE_PUT_OP_WakeSideHandler(ServerCommandQueue queue, BtlSide side, BtlSideEffect sideEffect) { }

        // TODO
        private static void SCQUE_PUT_OP_AddFieldHandler(ServerCommandQueue queue, EffectType effect, byte sub_param) { }

        // TODO
        private static void SCQUE_PUT_OP_RemoveFieldHandler(ServerCommandQueue queue, EffectType effect) { }

        // TODO
        private static void SCQUE_PUT_OP_AddDefaultPowerUpHandler(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_RemoveDefaultPowerUpHandler(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_AddRaidBossHandler(ServerCommandQueue queue, byte pokeID, RaidBossHandlerType handlerType) { }

        // TODO
        private static void SCQUE_PUT_OP_RemoveRaidBossHandler(ServerCommandQueue queue, byte pokeID, RaidBossHandlerType handlerType) { }

        // TODO
        private static void SCQUE_PUT_ACT_MigawariCreate(ServerCommandQueue queue, BtlPokePos pos) { }

        // TODO
        private static void SCQUE_PUT_ACT_MigawariDelete(ServerCommandQueue queue, BtlPokePos pos) { }

        // TODO
        private static void SCQUE_PUT_ACT_Hensin(ServerCommandQueue queue, byte atkPokeID, byte tgtPokeID) { }

        // TODO
        public static void SCQUE_PUT_ACT_PlayWinBGM(ServerCommandQueue queue, uint bgmNo) { }

        // TODO
        private static void SCQUE_PUT_ACT_MsgWinHide(ServerCommandQueue queue, byte dmy) { }

        // TODO
        private static void SCQUE_PUT_ACT_FriendshipEffect(ServerCommandQueue queue, byte pokeID, FriendshipEffect effect) { }

        // TODO
        private static void SCQUE_PUT_ACT_FriendshipEffectWithMsg(ServerCommandQueue queue, byte pokeID, FriendshipEffect effect, BtlStrType msgType, ushort strID, ushort arg1, ushort arg2) { }

        // TODO
        private static void SCQUE_PUT_OP_INC_WEATHER_PASSED_TURN(ServerCommandQueue queue) { }

        // TODO
        private static void SCQUE_PUT_OP_SET_SPACT_PRIORITY(ServerCommandQueue queue, byte pokeID, byte priority) { }

        // TODO
        private static void SCQUE_PUT_OP_SetActionRecord(ServerCommandQueue queue, byte pokeID, ActionRecorder.ActionID actionID) { }

        // TODO
        private static void SCQUE_PUT_OP_AddEscapeInfo(ServerCommandQueue queue, BTL_CLIENT_ID clientID) { }

        // TODO
        private static void SCQUE_PUT_ACT_TurnStart(ServerCommandQueue queue) { }

        // TODO
        private static void SCQUE_PUT_OP_GWallBreak(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_GWallGaugeAdd(ServerCommandQueue queue, byte pokeID, byte value) { }

        // TODO
        private static void SCQUE_PUT_OP_GWallGaugeSub(ServerCommandQueue queue, byte pokeID, byte value) { }

        // TODO
        private static void SCQUE_PUT_OP_GWallGaugeInit(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_DecGWallRepairTurnCount(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_RepairGWall(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_G_Start(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_G_End(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_G_IncTurn(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_GGauge_Inc(ServerCommandQueue queue, BTL_CLIENT_ID clientID) { }

        // TODO
        private static void SCQUE_PUT_OP_GGauge_Empty(ServerCommandQueue queue, BTL_CLIENT_ID clientID) { }

        // TODO
        private static void SCQUE_PUT_ACT_G_Start(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_ACT_G_End(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_RaidBoss_DecReinforceTurn(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_RaidBoss_SetReinforceTurn(ServerCommandQueue queue, byte pokeID, byte turn) { }

        // TODO
        private static void SCQUE_PUT_OP_RaidBoss_SetAngry(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_RaidBoss_GWazaUseSchedule_DecTurn(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_RaidBoss_GWazaUseSchedule_SetUsed(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_OP_RaidBoss_GWazaUseSchedule_Reset(ServerCommandQueue queue, byte pokeID, byte turn) { }

        // TODO
        private static void SCQUE_PUT_OP_TransferGRights(ServerCommandQueue queue, BtlSide side) { }

        // TODO
        private static void SCQUE_PUT_OP_IncGRightsPassedTurnCount(ServerCommandQueue queue, BtlSide side) { }

        // TODO
        private static void SCQUE_PUT_OP_InvalidateGRights(ServerCommandQueue queue, BTL_CLIENT_ID clientID) { }

        // TODO
        private static void SCQUE_PUT_ACT_GetGRights(ServerCommandQueue queue, BTL_CLIENT_ID clientID, bool canAnotherClientDisplayMessage) { }

        // TODO
        private static void SCQUE_PUT_RaidBattleStatus_IncAllDeadCount(ServerCommandQueue queue) { }

        // TODO
        private static void SCQUE_PUT_RaidBattleStatus_IncTurnCountAfterAllDead(ServerCommandQueue queue, BTL_CLIENT_ID clientID) { }

        // TODO
        private static void SCQUE_PUT_RaidBattleStatus_ResetTurnCountAfterAllDead(ServerCommandQueue queue, BTL_CLIENT_ID clientID) { }

        // TODO
        private static void SCQUE_PUT_ACT_RaidResult(ServerCommandQueue queue) { }

        // TODO
        private static void SCQUE_PUT_TOKWIN_IN(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_TOKWIN_OUT(ServerCommandQueue queue, byte pokeID) { }

        // TODO
        private static void SCQUE_PUT_MSG_WAZA(ServerCommandQueue queue, byte pokeID, ushort waza, BtlPokePos targetPos, bool needMsgDisplay) { }

        // TODO
        private static void SCQUE_PUT_MSG_WAZA_ToReservedPos(ServerCommandQueue queue, byte pokeID, ushort waza, BtlPokePos targetPos, bool needMsgDisplay, ushort reservedPos) { }

        private static void SCQUE_PUT_MSG_STD(ServerCommandQueue queue, int[] args)
        {
        	queue.Put_MsgImpl(0xb9,args);
        }

        private static void SCQUE_PUT_MSG_SET(ServerCommandQueue queue, int[] args)
        {
        	queue.Put_MsgImpl(0xba,args);
        }

        private static void SCQUE_PUT_MSG_STD_SE(ServerCommandQueue queue, int[] args)
        {
        	queue.Put_MsgImpl(0xbb,args);
        }

        private static void SCQUE_PUT_MSG_SET_SE(ServerCommandQueue queue, int[] args)
        {
        	queue.Put_MsgImpl(0xbc,args);
        }

        public static void SCQUE_PUT_MSG_STD_TO_RESERVED_POS(ServerCommandQueue queue, ushort pos, int[] args)
        {
        	queue.Put_ToReservedPos_Msg(pos,0xb9,args);
        }

        public static void SCQUE_PUT_MSG_SET_TO_RESERVED_POS(ServerCommandQueue queue, ushort pos, int[] args)
        {
        	queue.Put_ToReservedPos_Msg(pos,0xba,args);
        }

        // TODO
        private static void SCQUE_PUT_ACT_Safari(ServerCommandQueue queue, byte pokeID, byte param0, byte param1) { }

        public ServerCommandPutter(in SetupParam param)
        {
            m_pMainModule = param.pMainModule;
            m_pBattleEnv = param.pBattleEnv;
            m_pQueue = param.pQueue;
            m_pExecutor = param.pServerCmdExecutor;
        }

        // TODO
        public bool Message(in StrParam strParam) { return false; }

        // TODO
        public void Message_Std(ushort strID) { }

        // TODO
        public void Message_Std(ushort strID, int arg) { }

        // TODO
        public void Message_Std(ushort strID, int arg1, int arg2) { }

        // TODO
        public void Message_Std(ushort strID, int arg1, int arg2, int arg3) { }

        // TODO
        public void Message_Std(ushort strID, int arg1, int arg2, int arg3, int arg4) { }

        // TODO
        public void Message_StdEx(ushort strID, uint argsCount, int[] args) { }

        // TODO
        public void Message_StdSE(ushort strID, uint SENo, uint argsCount, int[] args) { }

        // TODO
        public void Message_Set(BTL_POKEPARAM poke, ushort strID) { }

        // TODO
        public void Message_Set(ushort strID, int arg1) { }

        // TODO
        public void Message_Set(ushort strID, int arg1, int arg2) { }

        // TODO
        public void Message_SetEx(ushort strID, uint argsCount, int[] args) { }

        // TODO
        public void Message_SetSE(ushort strID, uint SENo, uint argsCount, int[] args) { }

        public void Message_Waza(byte attackerID, WazaNo waza, BtlPokePos targetPos, bool needMsgDisplay)
        {
        	SCQUE_PUT_MSG_WAZA(this.m_pQueue);
        }

        // TODO
        public void Message_Waza_ToReservedPos(byte attackerID, WazaNo waza, BtlPokePos targetPos, bool needMsgDisplay, ushort reservedPos) { }

        // TODO
        public void Message_DamageAffinity(TypeAffinity.AffinityID affinity) { }

        // TODO
        public void Message_WazaAffinity(BTL_POKEPARAM attacker, uint targetCount, TypeAffinity.AffinityID[] affinityArray, BTL_POKEPARAM[] targets, bool isPluralHitWaza) { }

        // TODO
        public void Message_WazaFailed() { }

        // TODO
        public void Message_WazaAvoid(BTL_POKEPARAM defender, WazaNo waza) { }

        // TODO
        public void Message_WazaAvoidByFriendship(BTL_POKEPARAM defender, WazaNo waza) { }

        // TODO
        public void Message_NoEffect(BTL_POKEPARAM defender) { }

        // TODO
        public void Message_NoEffect_Ichigeki(BTL_POKEPARAM defender) { }

        // TODO
        public void Message_WazaExecuteFailed(BTL_POKEPARAM attacker, WazaNo waza, WazaFailCause cause) { }

        // TODO
        public void Message_MemberOut(BTL_POKEPARAM bpp) { }

        // TODO
        public void Message_AffGoodFriendship(BTL_POKEPARAM poke) { }

        // TODO
        public void Message_AddSickFailed(BTL_POKEPARAM target, AddSickFailCode failCode, WazaSick sick, SickCause cause) { }

        // TODO
        public void Message_SideEffectOff(BtlSide side, BtlSideEffect sideEffect) { }

        // TODO
        public bool ChangeGround(byte ground, in BTL_SICKCONT contParam) { return false; }

        // TODO
        public void AddFieldEffect(EffectType effect, in BTL_SICKCONT cont) { }

        // TODO
        public bool RemoveFieldEffect(EffectType effect) { return false; }

        // TODO
        public bool IncFieldTurnCount(EffectType effect) { return false; }

        // TODO
        public void AddFieldEffect_DependPoke(EffectType effect, byte pokeID) { }

        // TODO
        public bool RemoveFieldEffect_DependPoke(BTL_POKEPARAM causedPoke, EffectType fieldEffect) { return false; }

        // TODO
        public bool SideEffect_Add(BtlSide side, BtlSideEffect sideEffect, in BTL_SICKCONT contParam) { return false; }

        // TODO
        public bool SideEffect_Remove(BtlSide side, BtlSideEffect sideEffect) { return false; }

        // TODO
        public void SideEffect_IncTurnCount(BtlSide side, BtlSideEffect sideEffect) { }

        // TODO
        public bool SideEffect_Swap(BtlSide side1, BtlSide side2, BtlSideEffect sideEffect) { return false; }

        // TODO
        public bool PosEffect_Add(BtlPokePos effectPos, BtlPosEffect posEffect, in PosEffect.EffectParam effectParam) { return false; }

        // TODO
        public void EffectByPos(BTL_POKEPARAM poke, ushort effectNo) { }

        // TODO
        public void EffectByPos(BtlPokePos pos, ushort effectNo) { }

        // TODO
        public void EffectByClient(BTL_CLIENT_ID clientID, ushort effectNo) { }

        public void EffectBySide(BtlPokePos pos_from, BtlPokePos pos_to, ushort effectNo)
        {
        	SCQUE_PUT_ACT_EffectBySide(this.m_pQueue);
        }

        // TODO
        public void ConfusionAct(BTL_POKEPARAM poke) { }

        // TODO
        public void MeromeroAct(BTL_POKEPARAM poke) { }

        public void UseItemAct(BTL_POKEPARAM poke)
        {
        	var uVar3 = poke.GetItem();
        	var uVar1 = ItemData.IsNuts(uVar3);
        	var uVar2 = poke.GetID();
        	SCQUE_PUT_ACT_USE_ITEM(this.m_pQueue,uVar2,uVar1 & 1);
        }

        // TODO
        public void CantAction(BTL_POKEPARAM poke) { }

        // TODO
        public void MemberIn(byte clientID, byte posIdx, byte nextPokeIdx, uint turnCount) { }

        // TODO
        public void SetTurnFlag(BTL_POKEPARAM poke, BTL_POKEPARAM.TurnFlag flag) { }

        // TODO
        public void ResetTurnFlag(BTL_POKEPARAM poke, BTL_POKEPARAM.TurnFlag flag) { }

        // TODO
        public void SetContFlag(BTL_POKEPARAM poke, ContFlag flag) { }

        // TODO
        public void ResetContFlag(BTL_POKEPARAM poke, ContFlag flag) { }

        // TODO
        public void SetPermFlag(BTL_POKEPARAM poke, BTL_POKEPARAM.PermFlag flag) { }

        // TODO
        public void SetBppCounter(BTL_POKEPARAM poke, BTL_POKEPARAM.Counter counterID, byte value) { }

        public void IncBppCounter(BTL_POKEPARAM poke, BTL_POKEPARAM.Counter counterID)
        {
        	if (poke != null) {
        	  poke.COUNTER_Inc(counterID);
        	  var uVar1 = poke.COUNTER_Get(counterID);
        	  var uVar2 = poke.GetID();
        	  SCQUE_PUT_OP_SetPokeCounter(this.m_pQueue,uVar2,counterID,uVar1);
        	}
        }

        // TODO
        public void SetPokePermCounter(byte pokeID, BTL_POKEPARAM.PermCounter counterID, uint value) { }

        // TODO
        public void AddPokePermCounter(byte pokeID, BTL_POKEPARAM.PermCounter counterID, uint value) { }

        // TODO
        public void IncPokePermCounter(byte pokeID, BTL_POKEPARAM.PermCounter counterID) { }

        // TODO
        public void IncTotalTurnCount(byte pokeID) { }

        // TODO
        public void IncKillCount(byte pokeID) { }

        // TODO
        public void SetItem(BTL_POKEPARAM poke, ushort itemID) { }

        // TODO
        public void ConsumeItem(BTL_POKEPARAM poke, ushort itemID) { }

        // TODO
        public void ClearConsumedItem(byte pokeID) { }

        // TODO
        public void SimpleHp(BTL_POKEPARAM poke, int value, DamageCause damageCause, byte damageCausePokeID, bool isEffectEnable) { }

        // TODO
        public void DecreaseHP(BTL_POKEPARAM poke, uint value, bool byWazaDamage, DamageCause damageCause, byte damageCausePokeID) { }

        // TODO
        public void ConfDamage(BTL_POKEPARAM poke, uint damage) { }

        // TODO
        public void HpZero(BTL_POKEPARAM poke) { }

        // TODO
        public void KillPokemon(BTL_POKEPARAM poke, byte attackerID, DamageCause deadCause, byte effectType) { }

        // TODO
        public void DecrementPP(BTL_POKEPARAM poke, byte wazaIdx, byte volume) { }

        // TODO
        public void RecoverPP(BTL_POKEPARAM poke, byte wazaIdx, byte volume, bool isOriginalWaza) { }

        // TODO
        public void AddSick(BTL_POKEPARAM target, WazaSick sick, in BTL_SICKCONT sickCont) { }

        // TODO
        public void CureSick(BTL_POKEPARAM poke, WazaSick sick, out BTL_SICKCONT pOldCont)
        {
            pOldCont = default;
        }

        // TODO
        public void CureDependPokeSick(BTL_POKEPARAM poke, BTL_POKEPARAM causedPoke) { }

        // TODO
        public void RankEffect(BTL_POKEPARAM target, WazaRankEffect effect, int volume, ushort itemID, bool putStdMsg, RankEffectViewType viewType) { }

        // TODO
        public void SetSpActPriority(BTL_POKEPARAM poke, byte priority) { }

        // TODO
        public void Act_ChangeForm(byte pokeID) { }

        // TODO
        public void ChangeForm(byte pokeID, byte formNo, bool dontResetFormByOut) { }

        // TODO
        public void AddWazaDamageRecord(BTL_POKEPARAM defender, BTL_POKEPARAM attacker, BtlPokePos atkPokePos, byte wazaType, WazaDamageType damageType, ushort wazaID, ushort damage) { }

        // TODO
        public void CopyBatonTouchParams(byte userPokeID, byte targetPokeID) { }

        // TODO
        public bool ChangePokeType(byte pokeID, PokeTypePair nextType, BTL_POKEPARAM.ExTypeCause exTypeCause) { return false; }

        // TODO
        public void ExPokeType(byte pokeID, byte exType, BTL_POKEPARAM.ExTypeCause exTypeCause) { }

        // TODO
        public void ChangeTokusei(byte pokeID, TokuseiNo tokusei) { }

        // TODO
        public void SetBaseStatus(byte pokeID, BTL_POKEPARAM.ValueID valueID, ushort value) { }

        // TODO
        public void SetWeight(byte pokeID, ushort weight) { }

        // TODO
        public void ClearForOut(byte pokeID) { }

        // TODO
        public void ClearForDead(byte pokeID) { }

        // TODO
        public void CreateMigawari(byte pokeID, ushort migawariHP) { }

        // TODO
        public void DeleteMigawari(byte pokeID) { }

        // TODO
        public void Relive(byte pokeID, ushort recoverHP) { }

        // TODO
        public void TurnEnd(byte pokeID) { }

        // TODO
        public void TurnCheck_WazaSick(byte pokeID, WazaSick sick, out bool isSickValid, out BTL_SICKCONT pOldContDest, out bool fCured)
        {
            isSickValid = false;
            pOldContDest = default;
            fCured = false;
        }

        // TODO
        public void UpdateWazaProcResult(byte pokeID, BtlPokePos actTargetPos, byte actWazaType, bool isWazaEffective, WazaNo actWaza, WazaNo orgWaza) { }

        // TODO
        public void TokWin_In(byte pokeID) { }

        // TODO
        public void TokWin_In(BTL_POKEPARAM poke) { }

        // TODO
        public void TokWin_Out(byte pokeID) { }

        // TODO
        public void TokWin_Out(BTL_POKEPARAM poke) { }

        // TODO
        public void PublishClientInformation_AppeardPokemon(in BTL_POKEPARAM appeardPoke) { }

        // TODO
        public void PublishClientInformation_HavePokemonItem(BTL_POKEPARAM poke, bool haveItem) { }

        // TODO
        public void WazaEffect(in WazaParam wazaParam, WazaEffectParams wazaEffect, in WazaEffectReservedPos reservedQueuePos) { }

        // TODO
        public void WazaSubEffect(WazaEffectParams wazaEffect, ushort reservedQuePos) { }

        // TODO
        public void HaseiWazaEffect(BTL_POKEPARAM poke, WazaNo waza, BtlPokePos targetPos) { }

        // TODO
        public void WazaDamagePlural(BTL_POKEPARAM attacker, WazaParam wazaParam, uint targetCount, BTL_POKEPARAM[] targets, TypeAffinity.AffinityID[] affinityArray, ushort[] damage) { }

        // TODO
        public void InsertWazaInfo(byte pokeID, bool isTokuseiWindowDisplay, in StrParam message) { }

        // TODO
        public void SetBattleFlag(BattleFlags.Flag flag) { }

        // TODO
        public void RemoveBattleFlag(BattleFlags.Flag flag) { }

        // TODO
        public void IncBattleCount(BattleCounter.UniqueCounter counterID) { }

        // TODO
        public void DecBattleCount(BattleCounter.UniqueCounter counterID) { }

        // TODO
        public void IncBattleCount(BattleCounter.ClientCounter counterID, BTL_CLIENT_ID clientID) { }

        // TODO
        public void IncBattleCount(BattleCounter.SideCounter counterID, BtlSide side) { }

        // TODO
        public void SetActionRecord(byte pokeID, ActionRecorder.ActionID actionID) { }

        // TODO
        public void NotifyPGLRecord(BTL_POKEPARAM defPoke, PGLRecord.RecParam pPGLParam) { }

        // TODO
        public void AddEffort(byte pokeID, byte hp, byte pow, byte def, byte sp_pow, byte sp_def, byte agi) { }

        // TODO
        public void AddEffort_G(byte pokeID, byte value) { }

        // TODO
        public void SwapPokePos(byte clientID, BtlPokePos pos1, BtlPokePos pos2) { }

        public void Act_SwapPokePos(byte clientID, BtlPokePos pos1, BtlPokePos pos2)
        {
        	SCQUE_PUT_ACT_MemberMove(this.m_pQueue);
        }

        // TODO
        public void UpdateWazaNo(byte pokeID, byte wazaIdx, WazaNo wazaNo, byte ppMax, bool fPermanent) { }

        // TODO
        public void IncWazaUsedCount(byte pokeID, byte wazaIdx) { }

        // TODO
        public void IncWazaKillCount(byte pokeID, byte wazaIdx) { }

        // TODO
        public void SetWazaUsedFlag(byte pokeID, byte wazaIdx) { }

        // TODO
        public bool RecoverRank(byte pokeID) { return false; }

        // TODO
        public bool RankUpReset(byte pokeID) { return false; }

        // TODO
        public void RankReset(byte pokeID) { }

        // TODO
        public void RankSet8(byte pokeID, byte atk, byte def, byte sp_atk, byte sp_def, byte agi, byte hit, byte avoid, byte critical) { }

        // TODO
        public bool AddCriticalRank(byte pokeID, byte volume) { return false; }

        // TODO
        public void StartWeather(BtlWeather weather, byte turn, byte turnUpCount, byte causePokeID, ChangeWeatherCause cause) { }

        // TODO
        public void EndWeather() { }

        // TODO
        public void Act_EndWeather(BtlWeather weather) { }

        // TODO
        public BtlWeather TurnCheckWeather() { return BtlWeather.BTL_WEATHER_NONE; }

        // TODO
        public void UpdateIllusion() { }

        // TODO
        public void UpdateIllusion(BTL_CLIENT_ID clientID) { }

        // TODO
        public void FakeDisable(byte pokeID) { }

        // TODO
        public void Act_FakeDisable(byte pokeID) { }

        // TODO
        public void Act_FriendshipEffect(byte pokeID, FriendshipEffect effect) { }

        // TODO
        public void Act_FriendshipEffectWithMsg(byte pokeID, FriendshipEffect effect, BtlStrType msgType, ushort strID, ushort arg1, ushort arg2) { }

        // TODO
        public void RaidBoss_DecReinforceTurn(byte pokeID) { }

        // TODO
        public void RaidBoss_SetReinforceTurn(byte pokeID, byte turn) { }

        // TODO
        public void RaidBoss_IncAngryLevel(byte pokeID) { }

        // TODO
        public void RaidBoss_GWazaUseSchedule_DecTurn(byte pokeID) { }

        // TODO
        public void RaidBoss_GWazaUseSchedule_SetUsed(byte pokeID) { }

        // TODO
        public void RaidBoss_GWazaUseSchedule_Reset(byte pokeID, byte turn) { }

        // TODO
        public void Act_RaidBoss_GWallAppear(byte pokeID) { }

        // TODO
        public void BreakGWall(byte pokeID) { }

        // TODO
        public void AddGWallGauge(byte pokeID, byte value) { }

        // TODO
        public void SubGWallGauge(byte pokeID, byte value) { }

        // TODO
        public void InitGWallGauge(byte pokeID) { }

        // TODO
        public void DecGWallRepairTurnCount(byte pokeID) { }

        // TODO
        public void RepairGWall(byte pokeID) { }

        // TODO
        public void RaidBattleStatus_IncAllDeadCount() { }

        // TODO
        public void RaidBattleStatus_IncTurnCountAfterAllDead(BTL_CLIENT_ID clientID) { }

        // TODO
        public void RaidBattleStatus_ResetTurnCountAfterAllDead(BTL_CLIENT_ID clientID) { }

        public void Act_RaidResult()
        {
        	SCQUE_PUT_ACT_RaidResult(this.m_pQueue);
        }

        // TODO
        public void StartGMode(byte pokeID) { }

        // TODO
        public void EndGMode(byte pokeID) { }

        // TODO
        public void IncGModeTurnCount(byte pokeID) { }

        // TODO
        public void Act_StartGMode(byte pokeID) { }

        // TODO
        public void Act_EndGMode(byte pokeID) { }

        // TODO
        public void IncGGauge(BTL_CLIENT_ID clientID) { }

        // TODO
        public void EmptyGGauge(BTL_CLIENT_ID clientID) { }

        // TODO
        public bool TransferGRights(BtlSide side) { return false; }

        // TODO
        public void IncGRightsTurnCount(BtlSide side) { }

        // TODO
        public void InvalidateGRights(BTL_CLIENT_ID clientID) { }

        // TODO
        public void Act_GrightsGet(BTL_CLIENT_ID clientID, bool canAnotherClientDisplayMessage) { }

        // TODO
        public void Act_TurnStart() { }

        // TODO
        public void Act_Dead(byte pokeID, bool isKillCountEffect) { }

        // TODO
        public void Act_TameWazaHide(byte pokeID, bool hideFlag) { }

        // TODO
        public void Act_CreateMigawari(BtlPokePos pos) { }

        // TODO
        public void Act_HideMessageWindow() { }

        // TODO
        public void Act_ChangeGround(byte ground) { }

        // TODO
        public void Act_IchigekiWaza(byte targetID) { }

        public void Act_WazaDamage(byte targetID, TypeAffinity.AboutAffinityID affAbout, WazaNo wazaID)
        {
        	SCQUE_PUT_ACT_WazaDamage(this.m_pQueue);
        }

        public void Act_WazaEffect(BtlPokePos atPokePos, BtlPokePos defPokePos, WazaNo waza, byte wazaType, byte arg, byte pluralHitIndex, bool bSyncDamageEffect, bool isGShockOccur)
        {
        	SCQUE_PUT_ACT_WazaEffect(this.m_pQueue);
        }

        // TODO
        public void Act_EffectSimple(ushort effectNo) { }

        // TODO
        public void Act_EffectByVector(BtlPokePos pos_from, BtlPokePos pos_to, ushort effectNo) { }

        public void Act_Hensin(byte userID, byte targetID)
        {
        	SCQUE_PUT_ACT_Hensin(this.m_pQueue);
        }

        // TODO
        public void Op_Hensin(byte userID, byte targetID) { }

        public void Act_MemberIn(byte clientID, byte posIdx, byte memberIdx, bool fPutMsg)
        {
        	SCQUE_PUT_ACT_MemberIn(this.m_pQueue);
        }

        public void Act_MemberOut(BtlPokePos pos, ushort effectNo)
        {
        	SCQUE_PUT_ACT_MemberOut(this.m_pQueue);
        }

        // TODO
        public void Act_MigawariDamage(byte defPokeID, TypeAffinity.AffinityID affine, WazaNo waza) { }

        // TODO
        public void Act_MigawariDelete(BtlPokePos pos) { }

        public void Act_BallThrow(BtlPokePos userPos, BtlPokePos targetPos, byte yureCnt, bool fSuccess, bool fZukanRegister, bool fCritical, ushort ballItemID)
        {
        	SCQUE_PUT_ACT_BallThrow(this.m_pQueue);
        }

        // TODO
        public void Act_BallThrow_Forbidden(BtlPokePos targetPos, ushort ballItemID, BallThrowForbiddenCause cause) { }

        // TODO
        public void Act_BallThrow_AfterCaptured(in POKE_CAPTURED_CONTEXT context) { }

        // TODO
        public void Act_PlayWinBGM(uint BGMNo) { }

        public void ActOp_SkillSwap(byte pokeID_1, byte pokeID_2, TokuseiNo tokID_1, TokuseiNo tokID_2)
        {
        	SCQUE_PUT_ACTOP_SkillSwap(this.m_pQueue);
        }

        // TODO
        public void ActOp_ChangeTokusei(byte pokeID, TokuseiNo tokuseiNo) { }

        // TODO
        public void Act_AddExp_InitParam() { }

        // TODO
        public void Act_AddExp_AddParam(byte pokeID, uint exp, uint effort_hp, uint effort_pow, uint effort_def, uint effort_sp_pow, uint effort_sp_def, uint effort_agi) { }

        public void Act_AddExp()
        {
        	SCQUE_PUT_ACT_AddExp(this.m_pQueue);
        }

        // TODO
        public void Op_AddExp(byte pokeID, uint exp) { }

        // TODO
        public void AddEscapeInfo(BTL_CLIENT_ID clientID) { }

        // TODO
        public void ReserveUseItemCommands(UseItemCommandParam pParam) { }

        // TODO
        public void PutUseItemCommands(in UseItemCommandParam param) { }

        // TODO
        public bool AddWazaHandler(byte pokeID, WazaNo waza, uint subPri) { return false; }

        // TODO
        public void RemoveWazaHandler(byte pokeID, WazaNo waza) { }

        // TODO
        public void RemoveForceWazaHandler(byte pokeID, WazaNo waza) { }

        // TODO
        public void RemoveForceAllWazaHandler(byte pokeID) { }

        // TODO
        public void AddTokuseiHandler(byte pokeID) { }

        // TODO
        public void RemoveTokuseiHandler(byte pokeID) { }

        // TODO
        public void SwapTokuseiHandler(byte pokeID1, byte pokeID2) { }

        // TODO
        public void AddItemHandler(byte pokeID) { }

        // TODO
        public void RemoveItemHandler(byte pokeID) { }

        // TODO
        public void AddPosHandler(BtlPosEffect effect, BtlPokePos pos, byte pokeID, int[] param, byte param_cnt) { }

        // TODO
        public void RemovePosHandler(BtlPosEffect effect, BtlPokePos pos) { }

        // TODO
        public void AddSideHandler(BtlSide side, BtlSideEffect sideEffect, in BTL_SICKCONT contParam) { }

        // TODO
        public void RemoveSideHandler(BtlSide side, BtlSideEffect sideEffect) { }

        // TODO
        public bool SleepSideHandler(BtlSide side, BtlSideEffect sideEffect) { return false; }

        // TODO
        public bool WakeSideHandler(BtlSide side, BtlSideEffect sideEffect) { return false; }

        // TODO
        public bool AddFieldHandler(EffectType effect, byte sub_param) { return false; }

        // TODO
        public void RemoveFieldHandler(EffectType effect) { }

        // TODO
        public void AddDefaultPowerUpHandler(byte pokeID) { }

        // TODO
        public void RemoveDefaultPowerUpHandler(byte pokeID) { }

        // TODO
        public void AddRaidBossHandler(byte pokeID, RaidBossHandlerType handlerType) { }

        // TODO
        public void RemoveRaidBossHandler(byte pokeID, RaidBossHandlerType handlerType) { }

        public void SafariAct(byte pokeID, byte param0, byte param1)
        {
        	SCQUE_PUT_ACT_Safari(this.m_pQueue);
        }

        public class SetupParam
        {
            public MainModule pMainModule;
            public BattleEnv pBattleEnv;
            public ServerCommandQueue pQueue;
            public ServerCommandExecutor pServerCmdExecutor;
        }

        public class UseItemCommandParam
        {
            public ushort pokeID;
            public ushort itemno;
            public bool needTokuseiWindowDisplay;
            public ushort cmdQueuePos_TokuseiWindowIn = ServerCommandQueue.INVALID_PTR_VALUE;
            public ushort cmdQueuePos_ItemUseAction = ServerCommandQueue.INVALID_PTR_VALUE;
            public ushort cmdQueuePos_TokuseiWindowOut = ServerCommandQueue.INVALID_PTR_VALUE;
        }
    }
}