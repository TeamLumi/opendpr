using DPData;
using Pml.PokePara;
using Pml.WazaData;
using Pml;
using Dpr.Message;
using System.Runtime.InteropServices;
using Pml.Battle;

namespace Dpr.Battle.Logic
{
    public class BattleViewBase
    {
        public const uint BTLV_GAUGE_HP_DOTTOMAX = 48;
        public const uint BTLV_MSGWAIT_NONE = 0;
        public const uint BTLV_MSGWAIT_AUTO_HIDE = 12;
        public const uint BTLV_RAIDREWARD_RANK_MIN = 0;
        public const uint BTLV_RAIDREWARD_RANK_MAX = 5;

        private MainModule m_pMainModule;
        private BTL_CLIENT m_iPtrClient;
        private BattleEnv m_pBattleEnv;
        private BtlBagMode m_bagMode;
        private MSGSPEED m_msgSpeed;
        private BattleSimulator m_battleSimulator;

        // TODO
        public BattleViewBase(BTLV_INIT_PARAM initParam) { }

        // TODO
        private void createSimulator() { }

        public MainModule GetMainModule()
        {
            return m_pMainModule;
        }

        public virtual BattleEnv GetBattleEnv() {
            return m_pBattleEnv;
        }

        // TODO
        public virtual POKECON GetBattleContainer() { return null; }

        // TODO
        public virtual BTL_POKEPARAM GetBattlePokeParam(BtlvPos pos) { return null; }

        // TODO
        public virtual bool GetBattlePokeParam_forUI(BTL_POKEPARAM pDest, BtlvPos vpos) { return false; }

        // TODO
        public virtual PokemonParam GetViewSrcData(BtlvPos vpos) { return null; }

        // TODO
        public virtual BTL_PARTY GetBattleParty_Self() { return null; }

        // TODO
        public virtual BTL_PARTY GetBattleParty_Friend() { return null; }

        // TODO
        public virtual BTL_PARTY GetBattleParty_Enemy(int idx = 0) { return null; }

        // TODO
        public virtual BTL_PARTY GetBattleParty(byte clientID) { return null; }

        public virtual BTL_CLIENT GetClient() {
            return m_iPtrClient;
        }

        // TODO
        public virtual FieldStatus GetFieldStatus() { return null; }

        // TODO
        public virtual SideEffectStatus GetSideEffectStatus(BtlSide side, BtlSideEffect effect) { return default; }

        // TODO
        public virtual PosEffectStatus GetPosEffectStatus(BtlPokePos pos, BtlPosEffect effect) { return default; }

        // TODO
        public virtual BtlCompetitor GetBattleCompetitor() { return default; }

        // TODO
        public virtual BtlRule GetBattleRule() { return BtlRule.BTL_RULE_SINGLE; }

        // TODO
        public virtual BtlCommMode GetCommMode() { return default; }

        // TODO
        public virtual bool IsCommMode() { return false; }

        // TODO
        public virtual bool IsCommChild() { return false; }

        // TODO
        public virtual bool IsMultiMode() { return false; }

        // TODO
        public virtual bool IsPokeExist(BtlvPos pos) { return false; }

        // TODO
        public virtual bool IsFriendExist() { return false; }

        // TODO
        public virtual bool IsClientTrainerExist(byte clientID) { return false; }

        // TODO
        public virtual bool IsWatchMode() { return false; }

        // TODO
        public virtual byte GetClientID() { return 0; }

        // TODO
        public virtual byte GetFriendCleintID() { return 0; }

        // TODO
        public virtual byte GetEnemyClientID(byte idx) { return 0; }

        // TODO
        public virtual byte GetEnemyClientNum(byte clientID) { return 0; }

        // TODO
        public virtual bool IsClientNpc(byte idx) { return false; }

        // TODO
        public virtual BtlvPos GetClientIdToBtlvPos(byte clientId, byte pokeIdx = 0) { return BtlvPos.BTL_VPOS_NEAR_1; }

        // TODO
        public virtual byte GetBtlvPosToClientId(BtlvPos vpos) { return 0; }

        // TODO
        public virtual byte GetBtlvPosToPosIdx(BtlvPos vpos) { return 0; }

        // TODO
        public virtual byte GetBtlvPosToTrainerIdx(BtlvPos vpos) { return 0; }

        // TODO
        public virtual ushort GetTrainerID(byte clientID) { return 0; }

        // TODO
        public virtual ushort GetTrainerType(byte clientID) { return 0; }

        // TODO
        public virtual string GetTrainerModelID(byte clientID) { return null; }

        // TODO
        public virtual int GetTrainerColorID(byte clientID) { return 0; }

        // TODO
        public virtual string GetTrainerWinEffect(byte clientID) { return null; }

        // TODO
        public virtual string GetTrainerName(byte clientID) { return null; }

        // TODO
        public virtual string GetTrainerNameLabel(byte clientID) { return null; }

        // TODO
        public virtual Sex GetTrainerSex(byte clientID) { return Sex.MALE; }

        // TODO
        public virtual bool IsClientRatingDisplay() { return false; }

        // TODO
        public virtual ushort GetClientRating(byte clientID) { return 0; }

        // TODO
        public virtual MSGSPEED GetMessageSpeed() { return MSGSPEED.MSGSPEED_SLOW; }

        // TODO
        public virtual bool IsClientCheerMode(byte clientID) { return false; }

        // TODO
        public virtual byte GetFrontPosCount_Self() { return 0; }

        // TODO
        public virtual byte GetFrontPosCount_Friend() { return 0; }

        // TODO
        public virtual byte GetBenchPosIndex_Self() { return 0; }

        // TODO
        public virtual byte GetBenchPosIndex_Friend() { return 0; }

        // TODO
        public virtual bool IsSkyBattle() { return false; }

        // TODO
        public virtual bool IsZukanRegistered(BTL_POKEPARAM bpp) { return false; }

        // TODO
        public virtual bool IsEnableWazaEffect() { return false; }

        // TODO
        public virtual bool IsItemEnable() { return false; }

        // TODO
        public virtual bool GetSetupStatusFlag(BTL_STATUS_FLAG flag) { return default; }

        // TODO
        public virtual bool GetEnableTimeStop() { return false; }

        // TODO
        public virtual bool GetEnableVoiceChat() { return false; }

        // TODO
        public virtual bool IsRecordPlayMode() { return false; }

        // TODO
        public virtual BtlEscapeMode GetEscapeMode() { return default; }

        // TODO
        public virtual bool CanUseEscapeItem() { return false; }

        // TODO
        public virtual MiseaiData GetMiseaiData(byte clientID) { return default; }

        // TODO
        public virtual uint GetTurnCount() { return 0; }

        // TODO
        public virtual bool IsWazaEffectEnable() { return false; }

        // TODO
        public virtual bool IsPlayerInLeftSide() { return false; }

        // TODO
        public virtual BtlvPos BtlPosToViewPos(BtlPokePos pos) { return BtlvPos.BTL_VPOS_NEAR_1; }

        // TODO
        public virtual BtlPokePos ViewPosToBtlPos(BtlvPos pos) { return BtlPokePos.POS_1ST_0; }

        // TODO
        public virtual BtlSide ViewPosToBtlSide(BtlvPos viewPos) {return default; }

        // TODO
        public virtual BtlvPos PokeIDToViewPos(int pos) { return BtlvPos.BTL_VPOS_NEAR_1; }

        // TODO
        public virtual bool IsPlayerSide(BtlvPos pos) { return false; }

        // TODO
        public virtual uint GetGameTime() { return 0; }

        // TODO
        public virtual uint GetCommandTime() { return 0; }

        // TODO
        public virtual uint GetClientTime(BTL_CLIENT_ID clientID) {return default; }

        // TODO
        public virtual void GetUiDisplay_Turn_Weather(out uint numerator, out uint denominator)
        {
            numerator = 0;
            denominator = 0;
        }

        // TODO
        public virtual void GetUiDisplay_Turn_Ground(out uint numerator, out uint denominator)
        {
            numerator = 0;
            denominator = 0;
        }

        // TODO
        public virtual void GetUiDisplay_Turn_Hikarinokabe(out uint numerator, out uint denominator, BtlSide side)
        {
            numerator = 0;
            denominator = 0;
        }

        // TODO
        public virtual void GetUiDisplay_Turn_Reflector(out uint numerator, out uint denominator, BtlSide side)
        {
            numerator = 0;
            denominator = 0;
        }

        // TODO
        public virtual void GetUiDisplay_Turn_AuroraVeil(out uint numerator, out uint denominator, BtlSide side)
        {
            numerator = 0;
            denominator = 0;
        }

        // TODO
        public virtual void GetUiDisplay_Turn_SideEffect(out uint numerator, out uint denominator, BtlSide side, BtlSideEffect sideEffect)
        {
            numerator = 0;
            denominator = 0;
        }

        // TODO
        public virtual void GetUiDisplay_Turn(out uint numerator, out uint denominator, byte myClientID, byte causePokeID, uint totalTurn, uint upTurn, uint remainTurn, uint passedTurn)
        {
            numerator = 0;
            denominator = 0;
        }

        // TODO
        public virtual void GetUiDisplay_PokeType(out byte type1, out byte type2, in BTL_POKEPARAM poke)
        {
            type1 = 0;
            type2 = 0;
        }

        // TODO
        public void GetUiDisplay_WazaName(out WazaNo pDispWazaNo, out int pSpWazaNameIndex, MonsNo monsno, ushort formno, bool isG, bool isSpGEnable, WazaNo wazano)
        {
            pDispWazaNo = WazaNo.NULL;
            pSpWazaNameIndex = 0;
        }

        // TODO
        public void GetUiDisplay_WazaName(out WazaNo pDispWazaNo, out int pSpWazaNameIndex, BTL_POKEPARAM pAttacker, WazaNo wazano)
        {
            pDispWazaNo = WazaNo.NULL;
            pSpWazaNameIndex = 0;
        }

        // TODO
        public virtual byte GetUiDisplay_WazaType(WazaNo waza, [Optional] BTL_POKEPARAM pAttacker) { return 0; }

        // TODO
        public virtual ushort GetUiDisplay_WazaPower(WazaNo waza) { return 0; }

        // TODO
        public virtual ushort GetUiDisplay_WazaHitPer(WazaNo waza) { return 0; }

        // TODO
        public virtual WazaDamageType GetUiDisplay_WazaDamageType(WazaNo waza) { return WazaDamageType.NONE; }

        // TODO
        public virtual bool GetUiDisplay_IsPokemonAppearedOnBattleField(in byte clientID, in byte memberIndex) { return false; }

        // TODO
        public virtual ClientPublicInformation GetUiDisplay_GetClientPublicInfomation(in byte clientID) { return default; }

        // TODO
        public virtual bool GetUiDisplay_IsCheerMode(in byte clientID) { return false; }

        // TODO
        public virtual BtlMultiMode GetUIDisplay_GetMultiMode() { return default; }

        // TODO
        public virtual void GetUiDisplay_GetPlayerName(UiDisplayPlayerNameInfo pInfo, in byte clientID) { }

        // TODO
        public virtual bool IsWazaAffinityDisplayEnable(byte defPokeID) { return false; }

        // TODO
        public virtual TypeAffinity.AboutAffinityID CalcWazaAffinityAbout(byte atkPokeID, byte defPokeID, WazaNo waza, out bool isDisplayEnable)
        {
            isDisplayEnable = default;
            return default;
        }

        // TODO
        public virtual RaidActionIconID GetRaidActionIconID(BTL_CLIENT_ID clientID) { return default; }

        // TODO
        public virtual bool IsGWallGaugeDisplay() { return false; }

        // TODO
        public virtual byte GetGWallGaugeMax() { return 0; }

        // TODO
        public virtual byte GetGWallGaugeNow() { return 0; }

        // TODO
        private GWall GetGWall() { return null; }

        // TODO
        public virtual bool CheckTrainerActionRequest(BTL_CLIENT_ID clientID) { return default; }

        // TODO
        public virtual void SetTrainerActionRequest() { }

        // TODO
        public virtual void ClearTrainerActionRequest() { }

        // TODO
        public virtual bool IsTutorial() { return false; }

        // TODO
        public virtual int GetSafariBallNum() { return 0; }

        public virtual bool Initialize() {
            return true;
        }

        public virtual bool FinalizeApp() {
            return true;
        }

        public virtual bool FinalizeAppForce() {
            return true;
        }

        // TODO
        public virtual void CMD_StartSetup() { }

        public virtual bool CMD_WaitSetup() {
            return true;
        }

        // TODO
        public virtual void CMD_StartCleanUp() { }

        public virtual bool CMD_WaitCleanUp() {
            return true;
        }

        public virtual bool CMD_InitStartWaitCameraEffect() {
            return true;
        }

        public virtual bool CMD_WaitStartWaitCameraEffect() {
            return true;
        }

        // TODO
        public virtual void CMD_InitFinishWaitCameraEffect() { }

        public virtual bool CMD_WaitFinishWaitCameraEffect() {
            return true;
        }

        // TODO
        public virtual void CMD_UI_OnFirstSelectActionStart() { }

        // TODO
        public virtual void CMD_UI_SelectAction_Start(in SelectActionParam param, BTL_ACTION_PARAM_OBJ dest) { }

        // TODO
        public virtual BtlAction CMD_UI_SelectAction_Wait() { return default; }

        // TODO
        public virtual void CMD_UI_SelectAction_ForceQuit() { }

        // TODO
        public virtual void CMD_UI_SelectAction_AllFinished() { }

        public virtual bool CMD_UI_SelectAction_AllFinished_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_UI_SelectWaza_Start(BTL_POKEPARAM bpp, byte pokeIndex, BTL_ACTION_PARAM_OBJ dest) { }

        // TODO
        public virtual void CMD_UI_SelectWaza_Restart(byte pokeIndex) { }

        public virtual bool CMD_UI_SelectWaza_Wait() {
            return true;
        }

        public virtual bool CMD_UI_SelectWaza_End() {
            return true;
        }

        // TODO
        public virtual void CMD_UI_SelectWaza_ForceQuit() { }

        // TODO
        public virtual void CMD_UI_SelectTarget_Start(byte poke_index, BTL_POKEPARAM bpp, BTL_ACTION_PARAM_OBJ dest) { }

        // TODO
        public virtual BtlvResult CMD_UI_SelectTarget_Wait() { return default; }

        // TODO
        public virtual void CMD_UI_SelectTarget_ForceQuit() { }

        // TODO
        public virtual void CMD_UI_RestartIfNotStandBy() { }

        // TODO
        public virtual void CMD_UI_Restart() { }

        public virtual bool CMD_UI_WaitRestart() {
            return true;
        }

        // TODO
        public virtual void CMD_StartMemberChangeAct(BtlPokePos pos, byte clientID, byte memberIdx) { }

        public virtual bool CMD_WaitMemberChangeAct() {
            return true;
        }

        // TODO
        public virtual void CMD_StartMsgInBuffer(bool isKeyWait = false) { }

        // TODO
        public virtual void CMD_StartPokeList(PokeSelParam param, BTL_POKEPARAM outMemberParam, uint outMemberIndex, bool fCantEsc, PokeSelResult result) { }

        public virtual bool CMD_WaitPokeList() {
            return true;
        }

        // TODO
        public virtual void CMD_ForceQuitPokeList() { }

        public virtual bool CMD_WaitForceQuitPokeList() {
            return true;
        }

        // TODO
        public virtual void CMD_StartPokeSelect(PokeSelParam param, uint outMemberIndex, bool bCancelable, PokeSelResult result) { }

        public virtual bool CMD_WaitPokeSelect() {
            return true;
        }

        // TODO
        public virtual void CMD_ForceQuitPokeSelect() { }

        public virtual bool CMD_WaitForceQuitPokeSelect() {
            return true;
        }

        // TODO
        public virtual void CMD_StartMsg(BTLV_STRPARAM param) { }

        // TODO
        public virtual void CMD_StartMsgWaza(byte pokeID, WazaNo waza, BtlPokePos attackerPos, BtlPokePos defenderPos, WazaTarget wazaRange, bool needMessageDisplay) { }

        // TODO
        public virtual void CMD_StartMsgStd(ushort strID, int[] args) { }

        // TODO
        public virtual void CMD_StartMsgSet(ushort strID, int[] args) { }

        public virtual bool CMD_StartMsgTrainer(byte clientID, uint param, bool isKeyWait = false) {
            return true;
        }

        public virtual bool CMD_WaitMsg() {
            return true;
        }

        public virtual bool CMD_WaitMsg_WithoutHide() {
            return true;
        }

        // TODO
        public virtual void CMD_HideMsg() { }

        // TODO
        public virtual void CMD_ACT_WazaEffect_Start(BtlPokePos atPokePos, BtlPokePos defPokePos, WazaNo waza, byte wazaType, WazaTarget wazaRange, BtlvWazaEffect_TurnType turnType, byte continueCount, bool syncDamageEffect, bool isGShockOccur) { }

        public virtual bool CMD_ACT_WazaEffect_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_ACT_WazaEffect_NotView(WazaNo wazano) { }

        // TODO
        public virtual void CMD_ACT_DamageEffectSingle_Start(WazaNo wazaID, BtlPokePos defPokePos, TypeAffinity.AboutAffinityID affAbout) { }

        public virtual bool CMD_ACT_DamageEffectSingle_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_ACT_DamageEffectPlural_Start(uint pokeCnt, TypeAffinity.AboutAffinityID affAbout, byte[] pokeID, TypeAffinity.AffinityID[] pokeAffinity, WazaNo waza) { }

        public virtual bool CMD_ACT_DamageEffectPlural_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_ACT_MigawariDamageEffect_Start(WazaNo wazaID, BtlPokePos migawariPos, TypeAffinity.AboutAffinityID affAbout) { }

        public virtual bool CMD_ACT_MigawariDamageEffect_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_StartDeadAct(BtlPokePos pokePos, bool isKillCountEffectExist) { }

        public virtual bool CMD_WaitDeadAct() {
            return true;
        }

        // TODO
        public virtual void CMD_StartReliveAct(BtlPokePos pos) { }

        public virtual bool CMD_WaitReliveAct() {
            return true;
        }

        // TODO
        public virtual void CMD_ACT_MemberOut_Start(BtlvPos vpos, BtlEff effectNo) { }

        public virtual bool CMD_ACT_MemberOut_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_ACT_TameWazaHide(BtlvPos vpos, BTLV_VANISH_FLAG vanishFlag) { }

        // TODO
        public virtual void CMD_ACT_SimpleHPEffect_Start(BtlPokePos pokePos) { }

        public virtual bool CMD_ACT_SimpleHPEffect_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_AddEffect(BtlEff effectNo) { }

        public virtual bool CMD_WaitEffect() {
            return true;
        }

        // TODO
        public virtual void CMD_AddEffectByPos(BtlvPos vpos, BtlEff effectNo) { }

        public virtual bool CMD_WaitEffectByPos() {
            return true;
        }

        // TODO
        public virtual void CMD_AddEffectByDir(BtlvPos vpos_from, BtlvPos vpos_to, BtlEff effectNo) { }

        public virtual bool CMD_WaitEffectByDir() {
            return true;
        }

        // TODO
        public virtual void CMD_AddEffectBySide(BtlvPos vpos_from, BtlvPos vpos_to, BtlEff effectNo) { }

        public virtual bool CMD_WaitEffectBySide() {
            return true;
        }

        // TODO
        public virtual void CMD_TokWin_DispStart(BtlPokePos pos, bool fFlash) { }

        public virtual bool CMD_TokWin_DispWait(BtlPokePos pos) {
            return true;
        }

        // TODO
        public virtual void CMD_QuitTokWin(BtlPokePos pos) { }

        public virtual bool CMD_QuitTokWinWait(BtlPokePos pos) {
            return true;
        }

        // TODO
        public virtual void CMD_TokWin_Renew_Start(BtlPokePos pos) { }

        public virtual bool CMD_TokWin_Renew_Wait(BtlPokePos pos) {
            return true;
        }

        // TODO
        public virtual void CMD_StartRankDownEffect(BtlvPos vpos, byte rankDownVolume, RankEffectViewType viewType) { }

        // TODO
        public virtual void CMD_StartRankUpEffect(BtlvPos vpos, byte rankUpVolume, RankEffectViewType UnnamedParameter) { }

        public virtual bool CMD_WaitRankEffect(BtlvPos vpos) {
            return true;
        }

        // TODO
        public virtual void CMD_StartCommWait() { }

        public virtual bool CMD_WaitCommWait() {
            return true;
        }

        // TODO
        public virtual void CMD_ResetCommWaitInfo() { }

        // TODO
        public virtual void CMD_ItemAct_Start(BtlPokePos pos) { }

        public virtual bool CMD_ItemAct_Wait(BtlPokePos pos) {
            return true;
        }

        // TODO
        public virtual void CMD_KinomiAct_Start(BtlPokePos pos) { }

        public virtual bool CMD_KinomiAct_Wait(BtlPokePos pos) {
            return true;
        }

        // TODO
        public virtual void CMD_FakeDisable_Start(BtlPokePos pos, bool fSkipMode) { }

        public virtual bool CMD_FakeDisable_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_ChangeForm_Start(BtlvPos vpos) { }

        public virtual bool CMD_ChangeForm_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_Hensin_Start(BtlvPos atkVpos, BtlvPos tgtVpos) { }

        public virtual bool CMD_Hensin_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_ACT_MoveMember_Start(byte clientID, BtlvPos vpos1, BtlvPos vpos2, byte posIdx1, byte posIdx2) { }

        public virtual bool CMD_ACT_MoveMember_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_ITEMSELECT_Start(byte bagMode, byte energy, byte reserved_energy, bool fFirstPokemon, bool fBallTargetHide, bool canUseReliveItem) { }

        public virtual bool CMD_ITEMSELECT_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_ITEMSELECT_ForceQuit() { }

        // TODO
        public virtual ItemNo CMD_ITEMSELECT_GetItemID() { return ItemNo.DUMMY_DATA; }

        public virtual byte CMD_ITEMSELECT_GetTargetIdx() {
            return 0;
        }

        public virtual byte CMD_ITEMSELECT_GetWazaIdx() {
            return 0;
        }

        // TODO
        public virtual void CMD_ITEMSELECT_ReflectUsedItem() { }

        // TODO
        public virtual void CMD_YESNO_Start(bool b_cancel, YesNoMode yesno_mode) { }

        // TODO
        public virtual bool CMD_YESNO_Wait(out BtlYesNo result)
        {
            result = default;
            return default;
        }

        // TODO
        public virtual void CMD_YESNO_ForceQuit() { }

        // TODO
        public virtual void CMD_YESNO_Delete() { }

        // TODO
        public virtual void CMD_ExpGet_Start(ExpGetDesc desc, ExpGetResult pResult) { }

        public virtual bool CMD_ExpGet_Wait(ExpGetResult pResult) {
            return true;
        }

        // TODO
        public virtual void CMD_RecPlayFadeOut_Start() { }

        public virtual bool CMD_RecPlayFadeOut_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_RecPlayFadeIn_Start() { }

        public virtual bool CMD_RecPlayFadeIn_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_RecDispTurnGauge_Start() { }

        public virtual bool CMD_RecDispTurnGauge_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_Naderu_Start(BtlvPos vpos) { }

        public virtual bool CMD_Naderu_Wait(BtlvPos vpos) {
            return true;
        }

        // TODO
        public virtual void CMD_VsNusiWinEffect_Start() { }

        public virtual bool CMD_VsNusiWinEffect_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_GRightsGet_Start(byte clientID) { }

        public virtual bool CMD_GRightsGet_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_MsgWinHide_Start() { }

        public virtual bool CMD_MsgWinHide_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_ForceQuitInput_Notify() { }

        public virtual bool CMD_ForceQuitInput_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_RecPlayer_Init(ushort max_chapter) { }

        // TODO
        public virtual RecPlayerInput CMD_CheckRecPlayerInput() { return default; }

        // TODO
        public virtual void CMD_UpdateRecPlayerInput(ushort currentChapter, ushort ctrlChapter) { }

        // TODO
        public virtual void CMD_RecPlayer_StartSkip() { }

        // TODO
        public virtual void CMD_RecPlayer_StartSkipDisplay(ushort nextChapter) { }

        // TODO
        public virtual void CMD_RecPlayer_StartQuit(ushort chapter, RecPlayStopFlag stop_flag) { }

        // TODO
        public virtual void CMD_TrainerIn_Win(BtlvPos position) { }

        // TODO
        public virtual void CMD_TrainerIn_Lose(BtlvPos position) { }

        // TODO
        public virtual void CMD_TrainerIn_Event(BtlvPos position) { }

        public virtual bool CMD_WaitTrainerIn() {
            return true;
        }

        // TODO
        public virtual void CMD_EFFECT_SetGaugeStatus(Sick sick, BtlvPos pos) { }

        // TODO
        public virtual void CMD_EFFECT_BallThrow(BtlvPos userPos, BtlvPos position, ItemNo item_no, byte yure_cnt, bool f_success, bool f_critical) { }

        // TODO
        public virtual void CMD_EFFECT_BallThrowTrainer(BtlvPos vpos, ItemNo item_no) { }

        public virtual bool CMD_EFFECT_WaitBallThrow() {
            return true;
        }

        public virtual bool CMD_EFFECT_WaitBallThrowTrainer() {
            return true;
        }

        // TODO
        public virtual void CMD_EFFECT_DrawEnableTimer(GameTimer.TimerType type, bool enable) { }

        // TODO
        public virtual void CMD_ChangeWheather(BtlWeather weather) { }

        public virtual bool CMD_ChangeWheather_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_ChangeGround(BtlGround type) { }

        public virtual bool CMD_ChangeGround_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_FadeOutBGM(uint frames) { }

        // TODO
        public virtual void CMD_FadeInBGM(uint frames) { }

        public virtual bool CMD_CheckFadeOnBGM() {
            return false;
        }

        // TODO
        public virtual void CMD_StopBGM() { }

        // TODO
        public virtual void CMD_PlayWinBGM() { }

        // TODO
        public virtual void CMD_PlaySE(SoundType SENo) { }

        public virtual bool CMD_IsSEFinished(SoundType SENo) {
            return true;
        }

        // TODO
        public virtual void CMD_StopAllSE() { }

        // TODO
        public virtual void CMD_StartGMode(BtlPokePos pos) { }

        public virtual bool CMD_StartGMode_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_EndGMode(BtlPokePos pos) { }

        public virtual bool CMD_EndGMode_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_SummarizedGShockEffect(in SummarizedGShockEffectParam param) { }

        public virtual bool CMD_SummarizedGShockEffect_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_Raid_StartCoopCapture(BtlPokePos bossPos, uint seqNo) { }

        public virtual bool CMD_Raid_StartCoopCapture_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_Raid_SelectBall(in Raid_SelectBall_Param param) { }

        public virtual bool CMD_Raid_SelectBall_Wait(Raid_SelectBall_Result pResult) {
            return true;
        }

        // TODO
        public virtual void CMD_Raid_SelectBall_ForceQuit() { }

        // TODO
        public virtual void CMD_Raid_Capture(in RaidCaptureParam param) { }

        public virtual bool CMD_Raid_Capture_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_Raid_Capture_vsJoker(in RaidCaptureParam param) { }

        public virtual bool CMD_Raid_Capture_vsJoker_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_Raid_Win() { }

        public virtual bool CMD_Raid_Win_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_Raid_Result() { }

        public virtual bool CMD_Raid_Result_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_Raid_Lose() { }

        public virtual bool CMD_Raid_Lose_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_FinalizeFadeSkip() { }

        // TODO
        public virtual void CMD_Tips_G() { }

        public virtual bool CMD_Tips_G_Wait() {
            return true;
        }

        // TODO
        public virtual void CMD_DemoCapture_Start() { }

        public virtual bool CMD_DemoCapture_Wait() {
            return true;
        }

        public virtual BtlBagMode GetBagMode() {
            return m_bagMode;
        }

        // TODO
        public virtual void RaidReward_Start(in RaidRewardParam rewardParam) { }

        public virtual bool RaidReward_Wait() {
            return true;
        }

        // TODO
        public virtual void SetUIControlEnableForLiveCup(in bool bEnable) { }

        // TODO
        public virtual void CMD_ACT_Safari_Start(BtlPokePos pokePos, SafariCmd safariCmd, int param) { }

        public virtual bool CMD_ACT_Safari_Wait() {
            return true;
        }

        // TODO
        protected static void DBG_PrintFuncName() { }

        // TODO
        protected static void DBG_LogFuncNames() { }

        public enum BtlvMode : byte
        {
            BATTLE = 0,
            CAPTURE = 1,
            EFFECT_VIEWER = 2,
        }

        public enum SelectActMode : int
        {
            NORMAL = 0,
            FORBID_BAG = 1,
            CHEER = 2,
        }

        public enum ButtonMode : int
        {
            ACTIVE = 0,
            PASSIVE = 1,
            INVISIBLE = 2,
        }

        public class SelectActionParam
        {
            public BTL_POKEPARAM pActPoke;
            public byte pokeIndex;
            public bool fReturnable;
            public bool bGEnable;
            public bool isBallShortcutEnable;
            public bool isInfoEnable;
            public ButtonMode buttonMode_Fight;
            public ButtonMode buttonMode_Bag;
            public ButtonMode buttonMode_Pokemon;
            public ButtonMode buttonMode_Escape;
            public ButtonMode buttonMode_Cheer;

            // TODO
            public SelectActionParam() { }
        }

        public enum BtlvResult : byte
        {
            NONE = 0,
            DONE = 1,
            CANCEL = 2,
        }

        public class ExpGetDescByPoke
        {
            public uint exp;
            public uint effort_hp;
            public uint effort_pow;
            public uint effort_def;
            public uint effort_sp_pow;
            public uint effort_sp_def;
            public uint effort_agi;

            // TODO
            public void Clear() { }

            // TODO
            public ExpGetDescByPoke() { }
        }

        public class ExpGetDesc
        {
            public PokeParty iPtrParty;
            public ExpGetDescByPoke[] pokeDesc = Arrays.InitializeWithDefaultInstances<ExpGetDescByPoke>(DefineConstants.BTL_PARTY_MEMBER_MAX);

            // TODO
            public void Clear() { }
        }

        public class ExpGetResult
        {
            public bool isDeviceUpDown;
            public bool[] isLevelUpOccurred;

            // TODO
            public void Clear() { }

            // TODO
            public ExpGetResult() { }
        }

        public enum RecPlayerInput : byte
        {
            NONE = 0,
            REW = 1,
            FF = 2,
            STOP = 3,
        }

        public enum RecPlayStopFlag : byte
        {
            NONE = 0,
            KEY = 1,
            BREAK = 2,
            SKIP = 3,
        }

        public class SummarizedGShockEffectParam
        {
            public ushort[] effectNo;
            public GShock.Effect gShockEffect;

            // TODO
            public SummarizedGShockEffectParam() { }
        }

        public class Raid_SelectBall_Param
        {
            public bool isFlashAnimationEnable;
            public bool isCancelButtonPassive;

            // TODO
            public Raid_SelectBall_Param() { }
        }

        public class Raid_SelectBall_Result
        {
            public bool isThrow;
            public ItemNo itemno;

            // TODO
            public Raid_SelectBall_Result() { }
        }

        public class RaidCaptureParam
        {
            public ItemNo itemno;
            public bool isCaptured;
            public ushort yureCount;

            // TODO
            public RaidCaptureParam() { }
        }

        public class UiDisplayPlayerNameInfo
        {
            public MyStatus pMyStatus;
            public string ipName;
            public string ipNameLabel;
            public Sex gender;
            public MessageEnumData.MsgLangId pokeLanguageID;

            // TODO
            public void Reset() { }

            // TODO
            public UiDisplayPlayerNameInfo() { }
        }

        public class RaidRewardParam
        {
            public BTL_POKEPARAM pBPP;
            public uint rank;
            public bool bCaptured;
            public bool bRare;
            public ItemInfo[] itemInfo;

            // TODO
            public void SetItem(in uint index, in ItemNo itemNo, in uint amount) { }

            // TODO
            public void ResetItem(in uint index) { }

            // TODO
            public void Reset() { }

            // TODO
            public RaidRewardParam() { }

            public class ItemInfo
            {
                public ItemNo no;
                public uint amount;

                // TODO
                public void Set(in ItemNo itemNo, in uint _amount) { }

                // TODO
                public void Reset() { }

                // TODO
                public bool IsAvailable() { return false; }

                // TODO
                public ItemInfo() { }
            }
        }

        public enum SafariCmd : int
        {
            Esa = 0,
            Doro = 1,
            Yousumi = 2,
        }
    }
}