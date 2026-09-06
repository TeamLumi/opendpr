namespace Dpr.Battle.Logic
{
    public sealed class SectionContainer
    {
        private Section_AddSick_Core m_section_AddSick_Core;
        private Section_AddSickCheckFail m_section_AddSickCheckFail;
        private Section_AddWazaDamageRecord m_section_AddWazaDamageRecord;
        private Section_AfterItemEquip m_section_AfterItemEquip;
        private Section_AfterMemberIn m_section_AfterMemberIn;
        private Section_AfterTokuseiChanged_Event m_section_AfterTokuseiChanged_Event;
        private Section_AfterTokuseiChanged_Item m_section_AfterTokuseiChanged_Item;
        private Section_AppearFreeFallTarget m_section_AppearFreeFallTarget;
        private Section_CalcActionPriority m_section_CalcActionPriority;
        private Section_CalcDamage m_section_CalcDamage;
        private Section_CantAction m_section_CantAction;
        private Section_ChangeGround m_section_ChangeGround;
        private Section_ChangeItem m_section_ChangeItem;
        private Section_ChangeWeather m_section_ChangeWeather;
        private Section_ChangeWeather_After m_section_ChangeWeather_After;
        private Section_ChangeWeather_Check m_section_ChangeWeather_Check;
        private Section_ChangeWeather_Core m_section_ChangeWeather_Core;
        private Section_CheckAllTargetRemoved m_section_CheckAllTargetRemoved;
        private Section_CheckAttackerDead m_section_CheckAttackerDead;
        private Section_CheckDeadAfterWazaDamage m_section_CheckDeadAfterWazaDamage;
        private Section_CheckExpGet m_section_CheckExpGet;
        private Section_CheckFloating m_section_CheckFloating;
        private Section_CheckItemReaction m_section_CheckItemReaction;
        private Section_CheckNoEffect_Core m_section_CheckNoEffect_Core;
        private Section_CheckNoEffect_SimpleEffect m_section_CheckNoEffect_SimpleEffect;
        private Section_CheckNoEffect_SimpleSick m_section_CheckNoEffect_SimpleSick;
        private Section_CheckNoEffect_Sub m_section_CheckNoEffect_Sub;
        private Section_CheckNoEffect_TypeAffinity m_section_CheckNoEffect_TypeAffinity;
        private Section_CheckNotEffect_Affinity m_section_CheckNotEffect_Affinity;
        private Section_CheckNotEffect_Guard m_section_CheckNotEffect_Guard;
        private Section_CheckNotEffect_Tokusei m_section_CheckNotEffect_Tokusei;
        private Section_CheckPokeDead m_section_CheckPokeDead;
        private Section_CheckRealHitPoke m_section_CheckRealHitPoke;
        private Section_CheckTypeAffinity m_section_CheckTypeAffinity;
        private Section_CheckWazaAvoid m_section_CheckWazaAvoid;
        private Section_CheckWazaAvoid_ByHide m_section_CheckWazaAvoid_ByHide;
        private Section_CheckWazaDamageAffinity m_section_CheckWazaDamageAffinity;
        private Section_Cheer m_section_Cheer;
        private Section_ClearPokeDependEffect m_section_ClearPokeDependEffect;
        private Section_ConfDamage m_section_ConfDamage;
        private Section_CoverCheck m_section_CoverCheck;
        private Section_CriticalMsg m_section_CriticalMsg;
        private Section_DamageDetermine m_section_DamageDetermine;
        private Section_DamageDrain m_section_DamageDrain;
        private Section_DamageDrain_Core m_section_DamageDrain_Core;
        private Section_DecrementPP m_section_DecrementPP;
        private Section_Escape_CheckForceSucceed m_section_Escape_CheckForceSucceed;
        private Section_Escape_Core m_section_Escape_Core;
        private Section_Escape m_section_Escape;
        private Section_Escape_Sub m_section_Escape_Sub;
        private Section_GetExp m_section_GetExp;
        private Section_GShockWave m_section_GShockWave;
        private Section_FieldEffect_End m_section_FieldEffect_End;
        private Section_Fight m_section_Fight;
        private Section_WazaAdditionalEffect_RankEffect m_section_WazaAdditionalEffect_RankEffect;
        private Section_WazaExec_Category_EffectSick m_section_WazaExec_Category_EffectSick;
        private Section_WazaExec_Category_FieldEffect m_section_WazaExec_Category_FieldEffect;
        private Section_WazaExec_Category_PushOut m_section_WazaExec_Category_PushOut;
        private Section_PushOut m_section_PushOut;
        private Section_WazaExec_Category_SimpleEffect m_section_WazaExec_Category_SimpleEffect;
        private Section_WazaExec_Category_SimpleRecover m_section_WazaExec_Category_SimpleRecover;
        private Section_WazaExec_Category_SimpleSick m_section_WazaExec_Category_SimpleSick;
        private Section_WazaExec_Category_Uncategory m_section_WazaExec_Category_Uncategory;
        private Section_SetSpActPriority m_section_SetSpActPriority;
        private Section_SkillSwap m_section_SkillSwap;
        private Section_WazaSick m_section_WazaSick;
        private Section_FightDamage_ToRecover m_section_FightDamage_ToRecover;
        private Section_FightDamage_Ichigeki m_section_FightDamage_Ichigeki;
        private Section_FightDamage_PluralCount m_section_FightDamage_PluralCount;
        private Section_FightDamage_ProcEnd m_section_FightDamage_ProcEnd;
        private Section_FightDamage_Root m_section_FightDamage_Root;
        private Section_FightDamageSide m_section_FightDamageSide;
        private Section_FightDamageSide_MigawariDamage m_section_FightDamageSide_MigawariDamage;
        private Section_FightDamage_SingleCount m_section_FightDamage_SingleCount;
        private Section_FightDamage_Kickback m_section_FightDamage_Kickback;
        private Section_FirstPokeIn_End m_section_FirstPokeIn_End;
        private Section_FreeFall_Release m_section_FreeFall_Release;
        private Section_AddSick m_section_AddSick;
        private Section_FromEvent_AddViewEffect m_section_FromEvent_AddViewEffect;
        private Section_FromEvent_BattonTouch m_section_FromEvent_BattonTouch;
        private Section_FromEvent_BreakIllusion m_section_FromEvent_BreakIllusion;
        private Section_FromEvent_CalcAgility m_section_FromEvent_CalcAgility;
        private Section_FromEvent_CalcAgilityOrder m_section_FromEvent_CalcAgilityOrder;
        private Section_FromEvent_ChangePokeType m_section_FromEvent_ChangePokeType;
        private Section_FromEvent_ChangeTokusei m_section_FromEvent_ChangeTokusei;
        private Section_FromEvent_ChangeWeather m_section_FromEvent_ChangeWeather;
        private Section_FromEvent_CheckJuryoku m_section_FromEvent_CheckJuryoku;
        private Section_FromEvent_CheckSpecialWazaAdditionalEffectOccur m_section_FromEvent_CheckSpecialWazaAdditionalEffectOccur;
        private Section_FromEvent_ConsumeItem m_section_FromEvent_ConsumeItem;
        private Section_CureSick m_section_CureSick;
        private Section_FromEvent_Damage m_section_FromEvent_Damage;
        private Section_FromEvent_DeadCheck m_section_FromEvent_DeadCheck;
        private Section_FromEvent_DecideWazaTargetAuto m_section_FromEvent_DecideWazaTargetAuto;
        private Section_FromEvent_DecrementPP m_section_FromEvent_DecrementPP;
        private Section_FromEvent_DelayWazaDamage m_section_FromEvent_DelayWazaDamage;
        private Section_FromEvent_DrainHP m_section_FromEvent_DrainHP;
        private Section_FromEvent_ExtendPokeType m_section_FromEvent_ExtendPokeType;
        private Section_FieldEffect_Add m_section_FieldEffect_Add;
        private Section_FromEvent_FieldEffect_Remove m_section_FromEvent_FieldEffect_Remove;
        private Section_FromEvent_FormChange m_section_FromEvent_FormChange;
        private Section_FromEvent_FreeFallStart m_section_FromEvent_FreeFallStart;
        private Section_FromEvent_FriendshipEffect m_section_FromEvent_FriendshipEffect;
        private Section_FromEvent_GetWeather m_section_FromEvent_GetWeather;
        private Section_FromEvent_GetWeight m_section_FromEvent_GetWeight;
        private Section_FromEvent_Hensin m_section_FromEvent_Hensin;
        private Section_FromEvent_InsertWazaAction m_section_FromEvent_InsertWazaAction;
        private Section_FromEvent_InterruptAction m_section_FromEvent_InterruptAction;
        private Section_FromEvent_InterruptAction_ByWaza m_section_FromEvent_InterruptAction_ByWaza;
        private Section_FromEvent_Kill m_section_FromEvent_Kill;
        private Section_FromEvent_MemberChange m_section_FromEvent_MemberChange;
        private Section_FromEvent_Message m_section_FromEvent_Message;
        private Section_FromEvent_PlayWazaEffect m_section_FromEvent_PlayWazaEffect;
        private Section_FromEvent_PosEffect_Add m_section_FromEvent_PosEffect_Add;
        private Section_FromEvent_PostponeAction m_section_FromEvent_PostponeAction;
        private Section_FromEvent_QuitBattle m_section_FromEvent_QuitBattle;
        private Section_FromEvent_RankEffect m_section_FromEvent_RankEffect;
        private Section_RankFlat_Recover m_section_RankFlat_Recover;
        private Section_FromEvent_RankFlat_Weaken m_section_FromEvent_RankFlat_Weaken;
        private Section_FromEvent_RankReset m_section_FromEvent_RankReset;
        private Section_FromEvent_RankSet m_section_FromEvent_RankSet;
        private Section_FromEvent_RecoverPP m_section_FromEvent_RecoverPP;
        private Section_Relive m_section_Relive;
        private Section_FromEvent_RemovePosEffect m_section_FromEvent_RemovePosEffect;
        private Section_FromEvent_ResetContFlag m_section_FromEvent_ResetContFlag;
        private Section_FromEvent_ResetTurnFlag m_section_FromEvent_ResetTurnFlag;
        private Section_FromEvent_SetContFlag m_section_FromEvent_SetContFlag;
        private Section_FromEvent_SetCounter m_section_FromEvent_SetCounter;
        private Section_FromEvent_SetItem m_section_FromEvent_SetItem;
        private Section_FromEvent_SetPermFlag m_section_FromEvent_SetPermFlag;
        private Section_FromEvent_SetPower m_section_FromEvent_SetPower;
        private Section_FromEvent_SetTurnFlag m_section_FromEvent_SetTurnFlag;
        private Section_FromEvent_SetWazaEffectEnable m_section_FromEvent_SetWazaEffectEnable;
        private Section_FromEvent_SetWazaEffectIndex m_section_FromEvent_SetWazaEffectIndex;
        private Section_FromEvent_SetWeight m_section_FromEvent_SetWeight;
        private Section_FromEvent_ShiftHP m_section_FromEvent_ShiftHP;
        private Section_FromEvent_Shrink m_section_FromEvent_Shrink;
        private Section_SideEffect_Add m_section_SideEffect_Add;
        private Section_SideEffect_Remove m_section_SideEffect_Remove;
        private Section_SideEffect_Sleep m_section_SideEffect_Sleep;
        private Section_SideEffect_Swap m_section_SideEffect_Swap;
        private Section_FromEvent_SwapItem m_section_FromEvent_SwapItem;
        private Section_FromEvent_SwapPoke m_section_FromEvent_SwapPoke;
        private Section_FromEvent_TameHideCancel m_section_FromEvent_TameHideCancel;
        private Section_FromEvent_TokuseiWindow_In m_section_FromEvent_TokuseiWindow_In;
        private Section_FromEvent_TokuseiWindow_Out m_section_FromEvent_TokuseiWindow_Out;
        private Section_FromEvent_UpdatePosEffectParam m_section_FromEvent_UpdatePosEffectParam;
        private Section_FromEvent_UpdateWaza m_section_FromEvent_UpdateWaza;
        private Section_FromEvent_UseItem_Force m_section_FromEvent_UseItem_Force;
        private Section_FromEvent_VanishMessageWindow m_section_FromEvent_VanishMessageWindow;
        private Section_GetFrontPokeSetByAgilityOrder m_section_GetFrontPokeSetByAgilityOrder;
        private Section_G_Start m_section_G_Start;
        private Section_InterruptAction m_section_InterruptAction;
        private Section_UseItem m_section_UseItem;
        private Section_UseItem_Core m_section_UseItem_Core;
        private Section_Kill m_section_Kill;
        private Section_KintyoukanMoved m_section_KintyoukanMoved;
        private Section_Koraeru m_section_Koraeru;
        private Section_MagicCoat m_section_MagicCoat;
        private Section_MamoruSuccess m_section_MamoruSuccess;
        private Section_MemberChange m_section_MemberChange;
        private Section_MemberIn m_section_MemberIn;
        private Section_MemberInCore m_section_MemberInCore;
        private Section_MemberOut m_section_MemberOut;
        private Section_MemberOutCore m_section_MemberOutCore;
        private Section_Migawari_Create m_section_Migawari_Create;
        private Section_Migawari_Damage m_section_Migawari_Damage;
        private Section_Migawari_Delete m_section_Migawari_Delete;
        private Section_MsgAfterWazaDamage m_section_MsgAfterWazaDamage;
        private Section_ProcessAction m_section_ProcessAction;
        private Section_ProcessActionCore m_section_ProcessActionCore;
        private Section_ProcessCoverAction m_section_ProcessCoverAction;
        private Section_ProcessInterruptPokeChangeAction m_section_ProcessInterruptPokeChangeAction;
        private Section_ProcessUnfinishedAction m_section_ProcessUnfinishedAction;
        private Section_RaidBoss_Angry m_section_RaidBoss_Angry;
        private Section_RaidBoss_Angry_AddWazaAction m_section_RaidBoss_Angry_AddWazaAction;
        private Section_RaidBoss_BreakGWall m_section_RaidBoss_BreakGWall;
        private Section_RaidBoss_ExtraAction m_section_RaidBoss_ExtraAction;
        private Section_RaidBoss_ExtraAction_Add m_section_RaidBoss_ExtraAction_Add;
        private Section_RaidBoss_Reinforce m_section_RaidBoss_Reinforce;
        private Section_RaidBoss_UpdateGWall m_section_RaidBoss_UpdateGWall;
        private Section_RankEffect m_section_RankEffect;
        private Section_RankEffect_CheckEffective m_section_RankEffect_CheckEffective;
        private Section_RecordWazaDamage m_section_RecordWazaDamage;
        private Section_RecoverHP m_section_RecoverHP;
        private Section_RecoverHP_CheckFailBase m_section_RecoverHP_CheckFailBase;
        private Section_RecoverHP_CheckFailSP m_section_RecoverHP_CheckFailSP;
        private Section_RecoverHP_Core m_section_RecoverHP_Core;
        private Section_RegisterWazaTargets m_section_RegisterWazaTargets;
        private Section_Root_Cover m_section_Root_Cover;
        private Section_Root_Escape m_section_Root_Escape;
        private Section_Root_FirstPokeIn m_section_Root_FirstPokeIn;
        private Section_Root_InterruptPokeChange m_section_Root_InterruptPokeChange;
        private Section_Root_PokeChangeAfterFirstPokeIn m_section_Root_PokeChangeAfterFirstPokeIn;
        private Section_Root_ProcessActions m_section_Root_ProcessActions;
        private Section_Root_ProcessActions_Safari m_section_Root_ProcessActions_Safari;
        private Section_Root_RaidResult m_section_Root_RaidResult;
        private Section_Shrink m_section_Shrink;
        private Section_SimpleDamage_CheckEnable m_section_SimpleDamage_CheckEnable;
        private Section_SimpleDamage m_section_SimpleDamage;
        private Section_SortByAgility m_section_SortByAgility;
        private Section_SortActionOrder m_section_SortActionOrder;
        private Section_StoreActions m_section_StoreActions;
        private Section_TameHideCancel m_section_TameHideCancel;
        private Section_TameLockClear m_section_TameLockClear;
        private Section_TokuseiDisabled m_section_TokuseiDisabled;
        private Section_TurnCheck m_section_TurnCheck;
        private Section_TurnCheck_Event m_section_TurnCheck_Event;
        private Section_TurnCheck_Field m_section_TurnCheck_Field;
        private Section_TurnCheck_FriendshipCure m_section_TurnCheck_FriendshipCure;
        private Section_TurnCheck_Sick m_section_TurnCheck_Sick;
        private Section_TurnCheck_Side m_section_TurnCheck_Side;
        private Section_TurnCheck_Weather m_section_TurnCheck_Weather;
        private Section_TurnEnd m_section_TurnEnd;
        private Section_TurnStart m_section_TurnStart;
        private Section_UseItemEquip m_section_UseItemEquip;
        private Section_ViewEffect m_section_ViewEffect;
        private Section_WazaAdditionalEffect_Target m_section_WazaAdditionalEffect_Target;
        private Section_WazaAdditionalEffect_User m_section_WazaAdditionalEffect_User;
        private Section_WazaAdditionalEffect m_section_WazaAdditionalEffect;
        private Section_WazaDamageReaction m_section_WazaDamageReaction;
        private Section_WazaExec m_section_WazaExec;
        private Section_WazaExec_CheckFail_1st m_section_WazaExec_CheckFail_1st;
        private Section_WazaExec_CheckFail_2nd m_section_WazaExec_CheckFail_2nd;
        private Section_WazaExec_CheckFail_3rd m_section_WazaExec_CheckFail_3rd;
        private Section_WazaExec_CheckFail_Funjin m_section_WazaExec_CheckFail_Funjin;
        private Section_WazaExec_CheckWazaInvalid m_section_WazaExec_CheckWazaInvalid;
        private Section_WazaExec_CombiWazaReady m_section_WazaExec_CombiWazaReady;
        private Section_WazaExec_DelayWazaReady m_section_WazaExec_DelayWazaReady;
        private Section_WazaExec_Failed m_section_WazaExec_Failed;
        private Section_WazaExec_NotEffective m_section_WazaExec_NotEffective;
        private Section_WazaExec_TameWaza m_section_WazaExec_TameWaza;
        private Section_WazaExec_Category m_section_WazaExec_Category;
        private Section_WazaExec_Effect m_section_WazaExec_Effect;
        private Section_WazaExecEnd m_section_WazaExecEnd;
        private Section_WazaExecStart m_section_WazaExecStart;
        private Section_WazaRankEffect m_section_WazaRankEffect;
        private Section_WazaRankEffect_CheckEffective m_section_WazaRankEffect_CheckEffective;
        private Section_WazaRob m_section_WazaRob;
        private Section_Simulation_TypeAffinity m_section_Simulation_TypeAffinity;
        private Section_Simulation_Damage m_section_Simulation_Damage;

        // TODO
        public void CreateSections(in Section.CommonParam commonParam) { }

        public Section_AddSick_Core GetSection_AddSick_Core() {
            return m_section_AddSick_Core;
        }

        public Section_AddSickCheckFail GetSection_AddSickCheckFail() {
            return m_section_AddSickCheckFail;
        }

        public Section_AddWazaDamageRecord GetSection_AddWazaDamageRecord() {
            return m_section_AddWazaDamageRecord;
        }

        public Section_AfterItemEquip GetSection_AfterItemEquip() {
            return m_section_AfterItemEquip;
        }

        public Section_AfterMemberIn GetSection_AfterMemberIn() {
            return m_section_AfterMemberIn;
        }

        public Section_AfterTokuseiChanged_Event GetSection_AfterTokuseiChanged_Event() {
            return m_section_AfterTokuseiChanged_Event;
        }

        public Section_AfterTokuseiChanged_Item GetSection_AfterTokuseiChanged_Item() {
            return m_section_AfterTokuseiChanged_Item;
        }

        public Section_AppearFreeFallTarget GetSection_AppearFreeFallTarget() {
            return m_section_AppearFreeFallTarget;
        }

        public Section_CalcActionPriority GetSection_CalcActionPriority() {
            return m_section_CalcActionPriority;
        }

        public Section_CalcDamage GetSection_CalcDamage() {
            return m_section_CalcDamage;
        }

        public Section_CantAction GetSection_CantAction() {
            return m_section_CantAction;
        }

        public Section_ChangeGround GetSection_ChangeGround() {
            return m_section_ChangeGround;
        }

        public Section_ChangeItem GetSection_ChangeItem() {
            return m_section_ChangeItem;
        }

        public Section_ChangeWeather GetSection_ChangeWeather() {
            return m_section_ChangeWeather;
        }

        public Section_ChangeWeather_After GetSection_ChangeWeather_After() {
            return m_section_ChangeWeather_After;
        }

        public Section_ChangeWeather_Check GetSection_ChangeWeather_Check() {
            return m_section_ChangeWeather_Check;
        }

        public Section_ChangeWeather_Core GetSection_ChangeWeather_Core() {
            return m_section_ChangeWeather_Core;
        }

        public Section_CheckAllTargetRemoved GetSection_CheckAllTargetRemoved() {
            return m_section_CheckAllTargetRemoved;
        }

        public Section_CheckAttackerDead GetSection_CheckAttackerDead() {
            return m_section_CheckAttackerDead;
        }

        public Section_CheckDeadAfterWazaDamage GetSection_CheckDeadAfterWazaDamage() {
            return m_section_CheckDeadAfterWazaDamage;
        }

        public Section_CheckExpGet GetSection_CheckExpGet() {
            return m_section_CheckExpGet;
        }

        public Section_CheckFloating GetSection_CheckFloating() {
            return m_section_CheckFloating;
        }

        public Section_CheckItemReaction GetSection_CheckItemReaction() {
            return m_section_CheckItemReaction;
        }

        public Section_CheckNoEffect_Core GetSection_CheckNoEffect_Core() {
            return m_section_CheckNoEffect_Core;
        }

        public Section_CheckNoEffect_SimpleEffect GetSection_CheckNoEffect_SimpleEffect() {
            return m_section_CheckNoEffect_SimpleEffect;
        }

        public Section_CheckNoEffect_SimpleSick GetSection_CheckNoEffect_SimpleSick() {
            return m_section_CheckNoEffect_SimpleSick;
        }

        public Section_CheckNoEffect_Sub GetSection_CheckNoEffect_Sub() {
            return m_section_CheckNoEffect_Sub;
        }

        public Section_CheckNoEffect_TypeAffinity GetSection_CheckNoEffect_TypeAffinity() {
            return m_section_CheckNoEffect_TypeAffinity;
        }

        public Section_CheckNotEffect_Affinity GetSection_CheckNotEffect_Affinity() {
            return m_section_CheckNotEffect_Affinity;
        }

        public Section_CheckNotEffect_Guard GetSection_CheckNotEffect_Guard() {
            return m_section_CheckNotEffect_Guard;
        }

        public Section_CheckNotEffect_Tokusei GetSection_CheckNotEffect_Tokusei() {
            return m_section_CheckNotEffect_Tokusei;
        }

        public Section_CheckPokeDead GetSection_CheckPokeDead() {
            return m_section_CheckPokeDead;
        }

        public Section_CheckRealHitPoke GetSection_CheckRealHitPoke() {
            return m_section_CheckRealHitPoke;
        }

        public Section_CheckTypeAffinity GetSection_CheckTypeAffinity() {
            return m_section_CheckTypeAffinity;
        }

        public Section_CheckWazaAvoid GetSection_CheckWazaAvoid() {
            return m_section_CheckWazaAvoid;
        }

        public Section_CheckWazaAvoid_ByHide GetSection_CheckWazaAvoid_ByHide() {
            return m_section_CheckWazaAvoid_ByHide;
        }

        public Section_CheckWazaDamageAffinity GetSection_CheckWazaDamageAffinity() {
            return m_section_CheckWazaDamageAffinity;
        }

        public Section_Cheer GetSection_Cheer() {
            return m_section_Cheer;
        }

        public Section_WazaExec_CheckWazaInvalid GetSection_WazaExec_CheckWazaInvalid() {
            return m_section_WazaExec_CheckWazaInvalid;
        }

        public Section_ClearPokeDependEffect GetSection_ClearPokeDependEffect() {
            return m_section_ClearPokeDependEffect;
        }

        public Section_ConfDamage GetSection_ConfDamage() {
            return m_section_ConfDamage;
        }

        public Section_CoverCheck GetSection_CoverCheck() {
            return m_section_CoverCheck;
        }

        public Section_CriticalMsg GetSection_CriticalMsg() {
            return m_section_CriticalMsg;
        }

        public Section_DamageDetermine GetSection_DamageDetermine() {
            return m_section_DamageDetermine;
        }

        public Section_DamageDrain GetSection_DamageDrain() {
            return m_section_DamageDrain;
        }

        public Section_DamageDrain_Core GetSection_DamageDrain_Core() {
            return m_section_DamageDrain_Core;
        }

        public Section_DecrementPP GetSection_DecrementPP() {
            return m_section_DecrementPP;
        }

        public Section_Escape_CheckForceSucceed GetSection_Escape_CheckForceSucceed() {
            return m_section_Escape_CheckForceSucceed;
        }

        public Section_Escape_Core GetSection_Escape_Core() {
            return m_section_Escape_Core;
        }

        public Section_Escape GetSection_Escape() {
            return m_section_Escape;
        }

        public Section_Escape_Sub GetSection_Escape_Sub() {
            return m_section_Escape_Sub;
        }

        public Section_GetExp GetSection_GetExp() {
            return m_section_GetExp;
        }

        public Section_GShockWave GetSection_GShockWave() {
            return m_section_GShockWave;
        }

        public Section_FieldEffect_End GetSection_FieldEffect_End() {
            return m_section_FieldEffect_End;
        }

        public Section_Fight GetSection_Fight() {
            return m_section_Fight;
        }

        public Section_WazaAdditionalEffect_RankEffect GetSection_WazaAdditionalEffect_RankEffect() {
            return m_section_WazaAdditionalEffect_RankEffect;
        }

        public Section_WazaExec_Category_EffectSick GetSection_WazaExec_Category_EffectSick() {
            return m_section_WazaExec_Category_EffectSick;
        }

        public Section_WazaExec_Category_FieldEffect GetSection_WazaExec_Category_FieldEffect() {
            return m_section_WazaExec_Category_FieldEffect;
        }

        public Section_WazaExec_Category_PushOut GetSection_WazaExec_Category_PushOut() {
            return m_section_WazaExec_Category_PushOut;
        }

        public Section_PushOut GetSection_PushOut() {
            return m_section_PushOut;
        }

        public Section_WazaExec_Category_SimpleEffect GetSection_WazaExec_Category_SimpleEffect() {
            return m_section_WazaExec_Category_SimpleEffect;
        }

        public Section_WazaExec_Category_SimpleRecover GetSection_WazaExec_Category_SimpleRecover() {
            return m_section_WazaExec_Category_SimpleRecover;
        }

        public Section_WazaExec_Category_SimpleSick GetSection_WazaExec_Category_SimpleSick() {
            return m_section_WazaExec_Category_SimpleSick;
        }

        public Section_WazaExec_Category_Uncategory GetSection_WazaExec_Category_Uncategory() {
            return m_section_WazaExec_Category_Uncategory;
        }

        public Section_SetSpActPriority GetSection_SetSpActPriority() {
            return m_section_SetSpActPriority;
        }

        public Section_SkillSwap GetSection_SkillSwap() {
            return m_section_SkillSwap;
        }

        public Section_WazaSick GetSection_WazaSick() {
            return m_section_WazaSick;
        }

        public Section_FightDamage_ToRecover GetSection_FightDamage_ToRecover() {
            return m_section_FightDamage_ToRecover;
        }

        public Section_FightDamage_Ichigeki GetSection_FightDamage_Ichigeki() {
            return m_section_FightDamage_Ichigeki;
        }

        public Section_FightDamage_PluralCount GetSection_FightDamage_PluralCount() {
            return m_section_FightDamage_PluralCount;
        }

        public Section_FightDamage_ProcEnd GetSection_FightDamage_ProcEnd() {
            return m_section_FightDamage_ProcEnd;
        }

        public Section_FightDamage_Root GetSection_FightDamage_Root() {
            return m_section_FightDamage_Root;
        }

        public Section_FightDamageSide GetSection_FightDamageSide() {
            return m_section_FightDamageSide;
        }

        public Section_FightDamageSide_MigawariDamage GetSection_FightDamageSide_MigawariDamage() {
            return m_section_FightDamageSide_MigawariDamage;
        }

        public Section_FightDamage_SingleCount GetSection_FightDamage_SingleCount() {
            return m_section_FightDamage_SingleCount;
        }

        public Section_FightDamage_Kickback GetSection_FightDamage_Kickback() {
            return m_section_FightDamage_Kickback;
        }

        public Section_FirstPokeIn_End GetSection_FirstPokeIn_End() {
            return m_section_FirstPokeIn_End;
        }

        public Section_FreeFall_Release GetSection_FreeFall_Release() {
            return m_section_FreeFall_Release;
        }

        public Section_AddSick GetSection_AddSick() {
            return m_section_AddSick;
        }

        public Section_FromEvent_AddViewEffect GetSection_FromEvent_AddViewEffect() {
            return m_section_FromEvent_AddViewEffect;
        }

        public Section_FromEvent_BattonTouch GetSection_FromEvent_BattonTouch() {
            return m_section_FromEvent_BattonTouch;
        }

        public Section_FromEvent_BreakIllusion GetSection_FromEvent_BreakIllusion() {
            return m_section_FromEvent_BreakIllusion;
        }

        public Section_FromEvent_CalcAgility GetSection_FromEvent_CalcAgility() {
            return m_section_FromEvent_CalcAgility;
        }

        public Section_FromEvent_CalcAgilityOrder GetSection_FromEvent_CalcAgilityOrder() {
            return m_section_FromEvent_CalcAgilityOrder;
        }

        public Section_FromEvent_ChangePokeType GetSection_FromEvent_ChangePokeType() {
            return m_section_FromEvent_ChangePokeType;
        }

        public Section_FromEvent_ChangeTokusei GetSection_FromEvent_ChangeTokusei() {
            return m_section_FromEvent_ChangeTokusei;
        }

        public Section_FromEvent_ChangeWeather GetSection_FromEvent_ChangeWeather() {
            return m_section_FromEvent_ChangeWeather;
        }

        public Section_FromEvent_CheckJuryoku GetSection_FromEvent_CheckJuryoku() {
            return m_section_FromEvent_CheckJuryoku;
        }

        public Section_FromEvent_CheckSpecialWazaAdditionalEffectOccur GetSection_FromEvent_CheckSpecialWazaAdditionalEffectOccur() {
            return m_section_FromEvent_CheckSpecialWazaAdditionalEffectOccur;
        }

        public Section_FromEvent_ConsumeItem GetSection_FromEvent_ConsumeItem() {
            return m_section_FromEvent_ConsumeItem;
        }

        public Section_CureSick GetSection_CureSick() {
            return m_section_CureSick;
        }

        public Section_FromEvent_Damage GetSection_FromEvent_Damage() {
            return m_section_FromEvent_Damage;
        }

        public Section_FromEvent_DeadCheck GetSection_FromEvent_DeadCheck() {
            return m_section_FromEvent_DeadCheck;
        }

        public Section_FromEvent_DecideWazaTargetAuto GetSection_FromEvent_DecideWazaTargetAuto() {
            return m_section_FromEvent_DecideWazaTargetAuto;
        }

        public Section_FromEvent_DecrementPP GetSection_FromEvent_DecrementPP() {
            return m_section_FromEvent_DecrementPP;
        }

        public Section_FromEvent_DelayWazaDamage GetSection_FromEvent_DelayWazaDamage() {
            return m_section_FromEvent_DelayWazaDamage;
        }

        public Section_FromEvent_DrainHP GetSection_FromEvent_DrainHP() {
            return m_section_FromEvent_DrainHP;
        }

        public Section_FromEvent_ExtendPokeType GetSection_FromEvent_ExtendPokeType() {
            return m_section_FromEvent_ExtendPokeType;
        }

        public Section_FieldEffect_Add GetSection_FieldEffect_Add() {
            return m_section_FieldEffect_Add;
        }

        public Section_FromEvent_FieldEffect_Remove GetSection_FromEvent_FieldEffect_Remove() {
            return m_section_FromEvent_FieldEffect_Remove;
        }

        public Section_FromEvent_FormChange GetSection_FromEvent_FormChange() {
            return m_section_FromEvent_FormChange;
        }

        public Section_FromEvent_FreeFallStart GetSection_FromEvent_FreeFallStart() {
            return m_section_FromEvent_FreeFallStart;
        }

        public Section_FromEvent_FriendshipEffect GetSection_FromEvent_FriendshipEffect() {
            return m_section_FromEvent_FriendshipEffect;
        }

        public Section_FromEvent_GetWeather GetSection_FromEvent_GetWeather() {
            return m_section_FromEvent_GetWeather;
        }

        public Section_FromEvent_GetWeight GetSection_FromEvent_GetWeight() {
            return m_section_FromEvent_GetWeight;
        }

        public Section_FromEvent_Hensin GetSection_FromEvent_Hensin() {
            return m_section_FromEvent_Hensin;
        }

        public Section_FromEvent_InsertWazaAction GetSection_FromEvent_InsertWazaAction() {
            return m_section_FromEvent_InsertWazaAction;
        }

        public Section_FromEvent_InterruptAction GetSection_FromEvent_InterruptAction() {
            return m_section_FromEvent_InterruptAction;
        }

        public Section_FromEvent_InterruptAction_ByWaza GetSection_FromEvent_InterruptAction_ByWaza() {
            return m_section_FromEvent_InterruptAction_ByWaza;
        }

        public Section_FromEvent_Kill GetSection_FromEvent_Kill() {
            return m_section_FromEvent_Kill;
        }

        public Section_FromEvent_MemberChange GetSection_FromEvent_MemberChange() {
            return m_section_FromEvent_MemberChange;
        }

        public Section_FromEvent_Message GetSection_FromEvent_Message() {
            return m_section_FromEvent_Message;
        }

        public Section_FromEvent_PlayWazaEffect GetSection_FromEvent_PlayWazaEffect() {
            return m_section_FromEvent_PlayWazaEffect;
        }

        public Section_FromEvent_PosEffect_Add GetSection_FromEvent_PosEffect_Add() {
            return m_section_FromEvent_PosEffect_Add;
        }

        public Section_FromEvent_PostponeAction GetSection_FromEvent_PostponeAction() {
            return m_section_FromEvent_PostponeAction;
        }

        public Section_FromEvent_QuitBattle GetSection_FromEvent_QuitBattle() {
            return m_section_FromEvent_QuitBattle;
        }

        public Section_FromEvent_RankEffect GetSection_FromEvent_RankEffect() {
            return m_section_FromEvent_RankEffect;
        }

        public Section_RankFlat_Recover GetSection_RankFlat_Recover() {
            return m_section_RankFlat_Recover;
        }

        public Section_FromEvent_RankFlat_Weaken GetSection_FromEvent_RankFlat_Weaken() {
            return m_section_FromEvent_RankFlat_Weaken;
        }

        public Section_FromEvent_RankReset GetSection_FromEvent_RankReset() {
            return m_section_FromEvent_RankReset;
        }

        public Section_FromEvent_RankSet GetSection_FromEvent_RankSet() {
            return m_section_FromEvent_RankSet;
        }

        public Section_FromEvent_RecoverPP GetSection_FromEvent_RecoverPP() {
            return m_section_FromEvent_RecoverPP;
        }

        public Section_Relive GetSection_Relive() {
            return m_section_Relive;
        }

        public Section_FromEvent_RemovePosEffect GetSection_FromEvent_RemovePosEffect() {
            return m_section_FromEvent_RemovePosEffect;
        }

        public Section_FromEvent_ResetContFlag GetSection_FromEvent_ResetContFlag() {
            return m_section_FromEvent_ResetContFlag;
        }

        public Section_FromEvent_ResetTurnFlag GetSection_FromEvent_ResetTurnFlag() {
            return m_section_FromEvent_ResetTurnFlag;
        }

        public Section_FromEvent_SetContFlag GetSection_FromEvent_SetContFlag() {
            return m_section_FromEvent_SetContFlag;
        }

        public Section_FromEvent_SetCounter GetSection_FromEvent_SetCounter() {
            return m_section_FromEvent_SetCounter;
        }

        public Section_FromEvent_SetItem GetSection_FromEvent_SetItem() {
            return m_section_FromEvent_SetItem;
        }

        public Section_FromEvent_SetPermFlag GetSection_FromEvent_SetPermFlag() {
            return m_section_FromEvent_SetPermFlag;
        }

        public Section_FromEvent_SetPower GetSection_FromEvent_SetPower() {
            return m_section_FromEvent_SetPower;
        }

        public Section_FromEvent_SetTurnFlag GetSection_FromEvent_SetTurnFlag() {
            return m_section_FromEvent_SetTurnFlag;
        }

        public Section_FromEvent_SetWazaEffectEnable GetSection_FromEvent_SetWazaEffectEnable() {
            return m_section_FromEvent_SetWazaEffectEnable;
        }

        public Section_FromEvent_SetWazaEffectIndex GetSection_FromEvent_SetWazaEffectIndex() {
            return m_section_FromEvent_SetWazaEffectIndex;
        }

        public Section_FromEvent_SetWeight GetSection_FromEvent_SetWeight() {
            return m_section_FromEvent_SetWeight;
        }

        public Section_FromEvent_ShiftHP GetSection_FromEvent_ShiftHP() {
            return m_section_FromEvent_ShiftHP;
        }

        public Section_FromEvent_Shrink GetSection_FromEvent_Shrink() {
            return m_section_FromEvent_Shrink;
        }

        public Section_SideEffect_Add GetSection_SideEffect_Add() {
            return m_section_SideEffect_Add;
        }

        public Section_SideEffect_Remove GetSection_SideEffect_Remove() {
            return m_section_SideEffect_Remove;
        }

        public Section_SideEffect_Sleep GetSection_SideEffect_Sleep() {
            return m_section_SideEffect_Sleep;
        }

        public Section_SideEffect_Swap GetSection_SideEffect_Swap() {
            return m_section_SideEffect_Swap;
        }

        public Section_FromEvent_SwapItem GetSection_FromEvent_SwapItem() {
            return m_section_FromEvent_SwapItem;
        }

        public Section_FromEvent_SwapPoke GetSection_FromEvent_SwapPoke() {
            return m_section_FromEvent_SwapPoke;
        }

        public Section_FromEvent_TameHideCancel GetSection_FromEvent_TameHideCancel() {
            return m_section_FromEvent_TameHideCancel;
        }

        public Section_FromEvent_TokuseiWindow_In GetSection_FromEvent_TokuseiWindow_In() {
            return m_section_FromEvent_TokuseiWindow_In;
        }

        public Section_FromEvent_TokuseiWindow_Out GetSection_FromEvent_TokuseiWindow_Out() {
            return m_section_FromEvent_TokuseiWindow_Out;
        }

        public Section_FromEvent_UpdatePosEffectParam GetSection_FromEvent_UpdatePosEffectParam() {
            return m_section_FromEvent_UpdatePosEffectParam;
        }

        public Section_FromEvent_UpdateWaza GetSection_FromEvent_UpdateWaza() {
            return m_section_FromEvent_UpdateWaza;
        }

        public Section_FromEvent_UseItem_Force GetSection_FromEvent_UseItem_Force() {
            return m_section_FromEvent_UseItem_Force;
        }

        public Section_FromEvent_VanishMessageWindow GetSection_FromEvent_VanishMessageWindow() {
            return m_section_FromEvent_VanishMessageWindow;
        }

        public Section_GetFrontPokeSetByAgilityOrder GetSection_GetFrontPokeSetByAgilityOrder() {
            return m_section_GetFrontPokeSetByAgilityOrder;
        }

        public Section_G_Start GetSection_G_Start() {
            return m_section_G_Start;
        }

        public Section_InterruptAction GetSection_InterruptAction() {
            return m_section_InterruptAction;
        }

        public Section_UseItem GetSection_UseItem() {
            return m_section_UseItem;
        }

        public Section_UseItem_Core GetSection_UseItem_Core() {
            return m_section_UseItem_Core;
        }

        public Section_Kill GetSection_Kill() {
            return m_section_Kill;
        }

        public Section_KintyoukanMoved GetSection_KintyoukanMoved() {
            return m_section_KintyoukanMoved;
        }

        public Section_Koraeru GetSection_Koraeru() {
            return m_section_Koraeru;
        }

        public Section_MagicCoat GetSection_MagicCoat() {
            return m_section_MagicCoat;
        }

        public Section_MamoruSuccess GetSection_MamoruSuccess() {
            return m_section_MamoruSuccess;
        }

        public Section_MemberChange GetSection_MemberChange() {
            return m_section_MemberChange;
        }

        public Section_MemberIn GetSection_MemberIn() {
            return m_section_MemberIn;
        }

        public Section_MemberInCore GetSection_MemberInCore() {
            return m_section_MemberInCore;
        }

        public Section_MemberOut GetSection_MemberOut() {
            return m_section_MemberOut;
        }

        public Section_MemberOutCore GetSection_MemberOutCore() {
            return m_section_MemberOutCore;
        }

        public Section_Migawari_Create GetSection_Migawari_Create() {
            return m_section_Migawari_Create;
        }

        public Section_Migawari_Damage GetSection_Migawari_Damage() {
            return m_section_Migawari_Damage;
        }

        public Section_Migawari_Delete GetSection_Migawari_Delete() {
            return m_section_Migawari_Delete;
        }

        public Section_MsgAfterWazaDamage GetSection_MsgAfterWazaDamage() {
            return m_section_MsgAfterWazaDamage;
        }

        public Section_ProcessAction GetSection_ProcessAction() {
            return m_section_ProcessAction;
        }

        public Section_ProcessActionCore GetSection_ProcessActionCore() {
            return m_section_ProcessActionCore;
        }

        public Section_ProcessCoverAction GetSection_ProcessCoverAction() {
            return m_section_ProcessCoverAction;
        }

        public Section_ProcessInterruptPokeChangeAction GetSection_ProcessInterruptPokeChangeAction() {
            return m_section_ProcessInterruptPokeChangeAction;
        }

        public Section_ProcessUnfinishedAction GetSection_ProcessUnfinishedAction() {
            return m_section_ProcessUnfinishedAction;
        }

        public Section_RaidBoss_Angry GetSection_RaidBoss_Angry() {
            return m_section_RaidBoss_Angry;
        }

        public Section_RaidBoss_Angry_AddWazaAction GetSection_RaidBoss_Angry_AddWazaAction() {
            return m_section_RaidBoss_Angry_AddWazaAction;
        }

        public Section_RaidBoss_BreakGWall GetSection_RaidBoss_BreakGWall() {
            return m_section_RaidBoss_BreakGWall;
        }

        public Section_RaidBoss_ExtraAction GetSection_RaidBoss_ExtraAction() {
            return m_section_RaidBoss_ExtraAction;
        }

        public Section_RaidBoss_ExtraAction_Add GetSection_RaidBoss_ExtraAction_Add() {
            return m_section_RaidBoss_ExtraAction_Add;
        }

        public Section_RaidBoss_Reinforce GetSection_RaidBoss_Reinforce() {
            return m_section_RaidBoss_Reinforce;
        }

        public Section_RaidBoss_UpdateGWall GetSection_RaidBoss_UpdateGWall() {
            return m_section_RaidBoss_UpdateGWall;
        }

        public Section_RankEffect GetSection_RankEffect() {
            return m_section_RankEffect;
        }

        public Section_RankEffect_CheckEffective GetSection_RankEffect_CheckEffective() {
            return m_section_RankEffect_CheckEffective;
        }

        public Section_RecordWazaDamage GetSection_RecordWazaDamage() {
            return m_section_RecordWazaDamage;
        }

        public Section_RecoverHP GetSection_RecoverHP() {
            return m_section_RecoverHP;
        }

        public Section_RecoverHP_CheckFailBase GetSection_RecoverHP_CheckFailBase() {
            return m_section_RecoverHP_CheckFailBase;
        }

        public Section_RecoverHP_CheckFailSP GetSection_RecoverHP_CheckFailSP() {
            return m_section_RecoverHP_CheckFailSP;
        }

        public Section_RecoverHP_Core GetSection_RecoverHP_Core() {
            return m_section_RecoverHP_Core;
        }

        public Section_RegisterWazaTargets GetSection_RegisterWazaTargets() {
            return m_section_RegisterWazaTargets;
        }

        public Section_Root_Cover GetSection_Root_Cover() {
            return m_section_Root_Cover;
        }

        public Section_Root_Escape GetSection_Root_Escape() {
            return m_section_Root_Escape;
        }

        public Section_Root_FirstPokeIn GetSection_Root_FirstPokeIn() {
            return m_section_Root_FirstPokeIn;
        }

        public Section_Root_InterruptPokeChange GetSection_Root_InterruptPokeChange() {
            return m_section_Root_InterruptPokeChange;
        }

        public Section_Root_PokeChangeAfterFirstPokeIn GetSection_Root_PokeChangeAfterFirstPokeIn() {
            return m_section_Root_PokeChangeAfterFirstPokeIn;
        }

        public Section_Root_ProcessActions GetSection_Root_ProcessActions() {
            return m_section_Root_ProcessActions;
        }

        public Section_Root_ProcessActions_Safari GetSection_Root_ProcessActions_Safari() {
            return m_section_Root_ProcessActions_Safari;
        }

        public Section_Root_RaidResult GetSection_Root_RaidResult() {
            return m_section_Root_RaidResult;
        }

        public Section_Shrink GetSection_Shrink() {
            return m_section_Shrink;
        }

        public Section_SimpleDamage_CheckEnable GetSection_SimpleDamage_CheckEnable() {
            return m_section_SimpleDamage_CheckEnable;
        }

        public Section_SimpleDamage GetSection_SimpleDamage() {
            return m_section_SimpleDamage;
        }

        public Section_SortByAgility GetSection_SortByAgility() {
            return m_section_SortByAgility;
        }

        public Section_SortActionOrder GetSection_SortActionOrder() {
            return m_section_SortActionOrder;
        }

        public Section_StoreActions GetSection_StoreActions() {
            return m_section_StoreActions;
        }

        public Section_TameHideCancel GetSection_TameHideCancel() {
            return m_section_TameHideCancel;
        }

        public Section_TameLockClear GetSection_TameLockClear() {
            return m_section_TameLockClear;
        }

        public Section_TokuseiDisabled GetSection_TokuseiDisabled() {
            return m_section_TokuseiDisabled;
        }

        public Section_TurnCheck GetSection_TurnCheck() {
            return m_section_TurnCheck;
        }

        public Section_TurnCheck_Event GetSection_TurnCheck_Event() {
            return m_section_TurnCheck_Event;
        }

        public Section_TurnCheck_Field GetSection_TurnCheck_Field() {
            return m_section_TurnCheck_Field;
        }

        public Section_TurnCheck_FriendshipCure GetSection_TurnCheck_FriendshipCure() {
            return m_section_TurnCheck_FriendshipCure;
        }

        public Section_TurnCheck_Sick GetSection_TurnCheck_Sick() {
            return m_section_TurnCheck_Sick;
        }

        public Section_TurnCheck_Side GetSection_TurnCheck_Side() {
            return m_section_TurnCheck_Side;
        }

        public Section_TurnCheck_Weather GetSection_TurnCheck_Weather() {
            return m_section_TurnCheck_Weather;
        }

        public Section_TurnEnd GetSection_TurnEnd() {
            return m_section_TurnEnd;
        }

        public Section_TurnStart GetSection_TurnStart() {
            return m_section_TurnStart;
        }

        public Section_UseItemEquip GetSection_UseItemEquip() {
            return m_section_UseItemEquip;
        }

        public Section_ViewEffect GetSection_ViewEffect() {
            return m_section_ViewEffect;
        }

        public Section_WazaAdditionalEffect_Target GetSection_WazaAdditionalEffect_Target() {
            return m_section_WazaAdditionalEffect_Target;
        }

        public Section_WazaAdditionalEffect_User GetSection_WazaAdditionalEffect_User() {
            return m_section_WazaAdditionalEffect_User;
        }

        public Section_WazaAdditionalEffect GetSection_WazaAdditionalEffect() {
            return m_section_WazaAdditionalEffect;
        }

        public Section_WazaDamageReaction GetSection_WazaDamageReaction() {
            return m_section_WazaDamageReaction;
        }

        public Section_WazaExec GetSection_WazaExec() {
            return m_section_WazaExec;
        }

        public Section_WazaExec_CheckFail_1st GetSection_WazaExec_CheckFail_1st() {
            return m_section_WazaExec_CheckFail_1st;
        }

        public Section_WazaExec_CheckFail_2nd GetSection_WazaExec_CheckFail_2nd() {
            return m_section_WazaExec_CheckFail_2nd;
        }

        public Section_WazaExec_CheckFail_3rd GetSection_WazaExec_CheckFail_3rd() {
            return m_section_WazaExec_CheckFail_3rd;
        }

        public Section_WazaExec_CheckFail_Funjin GetSection_WazaExec_CheckFail_Funjin() {
            return m_section_WazaExec_CheckFail_Funjin;
        }

        public Section_WazaExec_CombiWazaReady GetSection_WazaExec_CombiWazaReady() {
            return m_section_WazaExec_CombiWazaReady;
        }

        public Section_WazaExec_DelayWazaReady GetSection_WazaExec_DelayWazaReady() {
            return m_section_WazaExec_DelayWazaReady;
        }

        public Section_WazaExec_Failed GetSection_WazaExec_Failed() {
            return m_section_WazaExec_Failed;
        }

        public Section_WazaExec_NotEffective GetSection_WazaExec_NotEffective() {
            return m_section_WazaExec_NotEffective;
        }

        public Section_WazaExec_TameWaza GetSection_WazaExec_TameWaza() {
            return m_section_WazaExec_TameWaza;
        }

        public Section_WazaExec_Category GetSection_WazaExec_Category() {
            return m_section_WazaExec_Category;
        }

        public Section_WazaExec_Effect GetSection_WazaExec_Effect() {
            return m_section_WazaExec_Effect;
        }

        public Section_WazaExecEnd GetSection_WazaExecEnd() {
            return m_section_WazaExecEnd;
        }

        public Section_WazaExecStart GetSection_WazaExecStart() {
            return m_section_WazaExecStart;
        }

        public Section_WazaRankEffect GetSection_WazaRankEffect() {
            return m_section_WazaRankEffect;
        }

        public Section_WazaRankEffect_CheckEffective GetSection_WazaRankEffect_CheckEffective() {
            return m_section_WazaRankEffect_CheckEffective;
        }

        public Section_WazaRob GetSection_WazaRob() {
            return m_section_WazaRob;
        }

        public Section_Simulation_TypeAffinity GetSection_Simulation_TypeAffinity() {
            return m_section_Simulation_TypeAffinity;
        }

        public Section_Simulation_Damage GetSection_Simulation_Damage() {
            return m_section_Simulation_Damage;
        }
    }
}