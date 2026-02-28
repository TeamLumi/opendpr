using Pml.WazaData;
using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class ServerCommandExecutor
    {
        private readonly MainModule m_pMainModule;
        private BattleEnv m_pBattleEnv;
        private EventSystem m_pEventSystem;

        public ServerCommandExecutor(ref SetupParam param)
        {
            m_pMainModule = param.pMainModule;
            m_pBattleEnv = param.pBattleEnv;
            m_pEventSystem = param.pEventSystem;
        }

        // TODO
        private BTL_POKEPARAM getPokeParam(byte pokeID) { return null; }

        // TODO
        public void SetTurnFlag(byte pokeID, BTL_POKEPARAM.TurnFlag flag) { }

        // TODO
        public void ResetTurnFlag(byte pokeID, BTL_POKEPARAM.TurnFlag flag) { }

        // TODO
        public void SetContFlag(byte pokeID, ContFlag flag) { }

        // TODO
        public void ResetContFlag(byte pokeID, ContFlag flag) { }

        // TODO
        public void SetPermFlag(byte pokeID, BTL_POKEPARAM.PermFlag flag) { }

        // TODO
        public void SetBppCounter(byte pokeID, BTL_POKEPARAM.Counter counterID, byte value) { }

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
        public void HPMinus(byte pokeID, uint value, DamageCause damageCause, byte damageCausePokeID) { }

        // TODO
        public void HpZero(byte pokeID) { }

        // TODO
        public void DecrementPP(byte pokeID, byte wazaIdx, byte volume) { }

        // TODO
        public void SetWazaUsedFlag(byte pokeID, byte wazaIdx) { }

        // TODO
        public void IncWazaUsedCount(byte pokeID, byte wazaIdx) { }

        // TODO
        public void IncWazaKillCount(byte pokeID, byte wazaIdx) { }

        // TODO
        public void SetItem(byte pokeID, ushort itemID) { }

        // TODO
        public void ConsumeItem(byte pokeID, ushort itemID) { }

        // TODO
        public void ClearConsumedItem(byte pokeID) { }

        // TODO
        public void CurePokeSick(byte pokeID) { }

        // TODO
        public void CureWazaSick(byte pokeID, WazaSick sick) { }

        // TODO
        public void CureDependPokeSick(byte pokeID, byte causePokeID) { }

        // TODO
        public void SetActionRecord(byte pokeID, ActionRecorder.ActionID actionID) { }

        // TODO
        public void AddWazaDamageRecord(byte defPokeID, byte atkPokeID, BtlPokePos atkPokePos, byte wazaType, WazaDamageType damageType, ushort wazaID, ushort damage) { }

        // TODO
        public void MemberIn(byte clientID, byte posIdx, byte nextPokeIdx, uint turnCount) { }

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
        public bool RemoveFieldEffect_DependPoke(byte causedPokeID, EffectType fieldEffect) { return false; }

        // TODO
        public bool SwapSideEffect(BtlSide side1, BtlSide side2, BtlSideEffect effect) { return false; }

        // TODO
        public void AddExp(byte pokeID, uint exp) { }

        // TODO
        public void AddEffort(byte pokeID, byte hp, byte pow, byte def, byte sp_pow, byte sp_def, byte agi) { }

        // TODO
        public void AddEffort_G(byte pokeID, byte value) { }

        // TODO
        public void CopyBatonTouchParams(byte userPokeID, byte targetPokeID) { }

        // TODO
        public bool ChangePokeType(byte pokeID, PokeTypePair nextType, BTL_POKEPARAM.ExTypeCause exTypeCause) { return false; }

        // TODO
        public void ExPokeType(byte pokeID, byte exType, BTL_POKEPARAM.ExTypeCause exTypeCause) { }

        // TODO
        public void ChangeTokusei(byte pokeID, TokuseiNo tokusei) { }

        // TODO
        public void ChangeForm(byte pokeID, byte formNo, bool dontResetFormByOut) { }

        // TODO
        public void Hensin(byte userID, byte targetID) { }

        // TODO
        public void SetBaseStatus(byte pokeID, BTL_POKEPARAM.ValueID valueID, ushort value) { }

        // TODO
        public void SetWeight(byte pokeID, ushort weight) { }

        // TODO
        public void SwapPokePos(byte clientID, BtlPokePos pos1, BtlPokePos pos2) { }

        // TODO
        public void UpdateWazaNo(byte pokeID, byte wazaIdx, WazaNo wazaNo, byte ppMax, bool fPermanent) { }

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
        public void SetSpActPriority(byte pokeID, byte priority) { }

        // TODO
        public void StartWeather(BtlWeather weather, byte turn, byte turnUpCount, byte causePokeID) { }

        public void EndWeather()
        {
        	this.m_pBattleEnv.m_fieldStatus.EndWeather();
        }

        // TODO
        public BtlWeather TurnCheckWeather() { return BtlWeather.BTL_WEATHER_TURBULENCE; }

        public void SetBattleFlag(BattleFlags.Flag flag)
        {
        	this.m_pBattleEnv.m_flags.Set(flag);
        }

        public void RemoveBattleFlag(BattleFlags.Flag flag)
        {
        	this.m_pBattleEnv.m_flags.Set(flag);
        }

        // TODO
        public void IncBattleCount(BattleCounter.UniqueCounter counterID) { }

        public void DecBattleCount(BattleCounter.UniqueCounter counterID)
        {
        	this.m_pBattleEnv.m_counter.Dec(counterID);
        }

        // TODO
        public void IncBattleCount(BattleCounter.ClientCounter counterID, BTL_CLIENT_ID clientID) { }

        // TODO
        public void IncBattleCount(BattleCounter.SideCounter counterID, BtlSide side) { }

        // TODO
        public void UpdateIllusion(BTL_CLIENT_ID clientID) { }

        // TODO
        public void FakeDisable(byte pokeID) { }

        // TODO
        public void RaidBattleStatus_IncAllDeadCount() { }

        // TODO
        public void RaidBattleStatus_IncTurnCountAfterAllDead(BTL_CLIENT_ID clientID) { }

        // TODO
        public void RaidBattleStatus_ResetTurnCountAfterAllDead(BTL_CLIENT_ID clientID) { }

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
        public void StartGMode(byte pokeID) { }

        // TODO
        public void EndGMode(byte pokeID) { }

        // TODO
        public void IncGModeTurnCount(byte pokeID) { }

        public void IncGGauge(BTL_CLIENT_ID clientID)
        {
        	GGauge.IncValue(this.m_pBattleEnv.GetGGauge(clientID),0);
        }

        public void EmptyGGauge(BTL_CLIENT_ID clientID)
        {
        	GGauge.SetEmpty(this.m_pBattleEnv.GetGGauge(clientID),0);
        }

        // TODO
        public bool TransferGRights(BtlSide side) { return false; }

        // TODO
        public void IncGRightsTurnCount(BtlSide side) { }

        // TODO
        public void InvalidateGRights(BTL_CLIENT_ID clientID) { }

        // TODO
        public void PlayedTalkEvent(byte talkID) { }

        public void AddEscapeInfo(BTL_CLIENT_ID clientID)
        {
        	this.m_pBattleEnv.m_escapeInfo.Add(clientID);
        }

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

        public struct SetupParam
        {
            public MainModule pMainModule;
            public BattleEnv pBattleEnv;
            public EventSystem pEventSystem;
        }
    }
}