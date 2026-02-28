using Pml.Battle;
using Pml;

namespace Dpr.Battle.Logic
{
    public static class BattleAiCommand
    {
        private const long CELL_FALSE = 0;
        private const long CELL_TRUE = 1;

        private static AiScriptCommandHandler[] s_pCommandHandler = new AiScriptCommandHandler[5]; // TODO: Is this client count?
        private static readonly BTL_AICMD_FUNC[] BTL_AICMD_FUNC_TABLE = new BTL_AICMD_FUNC[]
        {
            CMDFUNC_IF_RND_UNDER,
            CMDFUNC_IF_RND_OVER,
            CMDFUNC_IF_RND_EQUAL,
            CMDFUNC_IFN_RND_EQUAL,
            CMDFUNC_IF_HP_UNDER,
            CMDFUNC_IF_HP_OVER,
            CMDFUNC_IF_HP_EQUAL,
            CMDFUNC_IFN_HP_EQUAL,
            CMDFUNC_IF_POKESICK,
            CMDFUNC_IFN_POKESICK,
            CMDFUNC_IF_WAZASICK,
            CMDFUNC_IFN_WAZASICK,
            CMDFUNC_IF_DOKUDOKU,
            CMDFUNC_IFN_DOKUDOKU,
            CMDFUNC_IF_CONTFLG,
            CMDFUNC_IFN_CONTFLG,
            CMDFUNC_IF_SIDEEFF,
            CMDFUNC_IFN_SIDEEFF,
            CMDFUNC_GET_HOROBINOUTA_TURN_MAX,
            CMDFUNC_GET_HOROBINOUTA_TURN_NOW,
            CMDFUNC_GET_KODAWARI_WAZA,
            CMDFUNC_IF_HAVE_DAMAGE_WAZA,
            CMDFUNC_IFN_HAVE_DAMAGE_WAZA,
            CMDFUNC_CHECK_TURN,
            CMDFUNC_CHECK_TYPE,
            CMDFUNC_CHECK_WAZA_USABLE,
            CMDFUNC_CHECK_DAMAGE_WAZA,
            CMDFUNC_CHECK_IRYOKU,
            CMDFUNC_COMP_POWER,
            CMDFUNC_CHECK_LAST_WAZA,
            CMDFUNC_IF_FIRST,
            CMDFUNC_CHECK_BENCH_COUNT,
            CMDFUNC_CHECK_WAZASEQNO,
            CMDFUNC_CHECK_TOKUSEI,
            CMDFUNC_CHECK_WAZA_AISYOU,
            CMDFUNC_GET_WAZA_AISYOU,
            CMDFUNC_IF_HAVE_WAZA_AISYOU_OVER,
            CMDFUNC_IF_HAVE_WAZA_AISYOU_EQUAL,
            CMDFUNC_IF_BENCH_COND,
            CMDFUNC_IFN_BENCH_COND,
            CMDFUNC_CHECK_WEATHER,
            CMDFUNC_IF_PARA_UNDER,
            CMDFUNC_IF_PARA_OVER,
            CMDFUNC_IF_PARA_EQUAL,
            CMDFUNC_IFN_PARA_EQUAL,
            CMDFUNC_IF_WAZA_HINSHI,
            CMDFUNC_IFN_WAZA_HINSHI,
            CMDFUNC_IF_HAVE_WAZA,
            CMDFUNC_IFN_HAVE_WAZA,
            CMDFUNC_IF_HAVE_WAZA_SEQNO,
            CMDFUNC_IFN_HAVE_WAZA_SEQNO,
            CMDFUNC_ESCAPE,
            CMDFUNC_CHECK_SOUBI_ITEM,
            CMDFUNC_CHECK_SOUBI_EQUIP,
            CMDFUNC_CHECK_POKESEX,
            CMDFUNC_CHECK_NEKODAMASI,
            CMDFUNC_CHECK_TAKUWAERU,
            CMDFUNC_CHECK_BTL_RULE,
            CMDFUNC_CHECK_BTL_COMPETITOR,
            CMDFUNC_CHECK_RECYCLE_ITEM,
            CMDFUNC_CHECK_WORKWAZA_TYPE,
            CMDFUNC_CHECK_WORKWAZA_POW,
            CMDFUNC_CHECK_WORKWAZA_SEQNO,
            CMDFUNC_CHECK_MAMORU_COUNT,
            CMDFUNC_IF_LEVEL,
            CMDFUNC_IF_CHOUHATSU,
            CMDFUNC_IFN_CHOUHATSU,
            CMDFUNC_IF_MIKATA_ATTACK,
            CMDFUNC_CHECK_HAVE_TYPE,
            CMDFUNC_CHECK_HAVE_TOKUSEI,
            CMDFUNC_IF_ALREADY_MORAIBI,
            CMDFUNC_IF_HAVE_ITEM,
            CMDFUNC_FLDEFF_CHECK,
            CMDFUNC_CHECK_SIDEEFF_COUNT,
            CMDFUNC_IF_BENCH_HPDEC,
            CMDFUNC_IF_BENCH_PPDEC,
            CMDFUNC_CHECK_NAGETSUKERU_IRYOKU,
            CMDFUNC_CHECK_PP_REMAIN,
            CMDFUNC_IF_TOTTEOKI,
            CMDFUNC_CHECK_WAZA_KIND,
            CMDFUNC_CHECK_LAST_WAZA_KIND,
            CMDFUNC_CHECK_AGI_RANK,
            CMDFUNC_CHECK_SLOWSTART_TURN,
            CMDFUNC_IF_BENCH_DAMAGE_MAX,
            CMDFUNC_IF_HAVE_BATSUGUN,
            CMDFUNC_IF_LAST_WAZA_DAMAGE_CHECK,
            CMDFUNC_CHECK_STATUS_UP,
            CMDFUNC_CHECK_STATUS_DIFF,
            CMDFUNC_CHECK_STATUS,
            CMDFUNC_COMP_POWER_WITH_PARTNER,
            CMDFUNC_IF_HINSHI,
            CMDFUNC_IFN_HINSHI,
            CMDFUNC_GET_TOKUSEI,
            CMDFUNC_IF_MIGAWARI,
            CMDFUNC_CHECK_MONSNO,
            CMDFUNC_CHECK_FORMNO,
            CMDFUNC_IF_COMMONRND_UNDER,
            CMDFUNC_IF_COMMONRND_OVER,
            CMDFUNC_IF_COMMONRND_EQUAL,
            CMDFUNC_IFN_COMMONRND_EQUAL,
            CMDFUNC_IF_MIRAIYOCHI,
            CMDFUNC_IF_DMG_PHYSIC_UNDER,
            CMDFUNC_IF_DMG_PHYSIC_OVER,
            CMDFUNC_IF_DMG_PHYSIC_EQUAL,
            CMDFUNC_IF_ATE_KINOMI,
            CMDFUNC_IF_TYPE_EX,
            CMDFUNC_IF_EXIST_GROUND,
            CMDFUNC_GET_WEIGHT,
            CMDFUNC_IF_MULTI,
            CMDFUNC_IF_MEGAEVOLVED,
            CMDFUNC_IF_CAN_MEGAEVOLVE,
            CMDFUNC_IF_WAZAHIDE,
            CMDFUNC_GET_MEZAPA_TYPE,
            CMDFUNC_IF_I_AM_SENARIO_TRAINER,
            CMDFUNC_GET_MAX_WAZA_POWER_INCLUDE_AFFINITY,
            CMDFUNC_CHECK_WAZA_NO_EFFECT_BY_TOKUSEI,
            CMDFUNC_GET_LAST_DAMAGED_WAZA_AT_PREV_TURN,
            CMDFUNC_GET_CURRENT_WAZANO,
            CMDFUNC_GET_CURRENT_ITEMNO,
            CMDFUNC_IF_ZIDANDA_POWERUP,
            CMDFUNC_GET_CLIENT_KILL_COUNT,
            CMDFUNC_GET_WAZA_TARGET,
            CMDFUNC_IF_HAVE_BATSUGUN_CAN_BENCH,
            CMDFUNC_IF_G,
            CMDFUNC_IF_HAVE_KINOMI,
            CMDFUNC_IF_GWALL_EXIST,
            CMDFUNC_IF_JK3_LEGEND,
            CMDFUNC_IF_CAN_G,
            CMDFUNC_IF_GWAZA_USE_TURN,
            CMDFUNC_IF_CAN_CHANGE_POKE,
        };

        private const int CHECK_TOK_MAX = 4;

        private static readonly CMDFUNC_CHECK_WAZA_NO_EFFECT_BY_TOKUSEI_TABLE_ELEM[] CMDFUNC_CHECK_WAZA_NO_EFFECT_BY_TOKUSEI_TABLE = new CMDFUNC_CHECK_WAZA_NO_EFFECT_BY_TOKUSEI_TABLE_ELEM[]
        {
            new CMDFUNC_CHECK_WAZA_NO_EFFECT_BY_TOKUSEI_TABLE_ELEM(PokeType.MIZU, new TokuseiNo[CHECK_TOK_MAX]
            {
                TokuseiNo.TYOSUI, TokuseiNo.YOBIMIZU, TokuseiNo.KANSOUHADA, TokuseiNo.NULL,
            }),
            new CMDFUNC_CHECK_WAZA_NO_EFFECT_BY_TOKUSEI_TABLE_ELEM(PokeType.DENKI, new TokuseiNo[CHECK_TOK_MAX]
            {
                TokuseiNo.TIKUDEN, TokuseiNo.DENKIENZIN, TokuseiNo.HIRAISIN, TokuseiNo.NULL,
            }),
            new CMDFUNC_CHECK_WAZA_NO_EFFECT_BY_TOKUSEI_TABLE_ELEM(PokeType.KUSA, new TokuseiNo[CHECK_TOK_MAX]
            {
                TokuseiNo.SOUSYOKU, TokuseiNo.NULL, TokuseiNo.NULL, TokuseiNo.NULL,
            }),
            new CMDFUNC_CHECK_WAZA_NO_EFFECT_BY_TOKUSEI_TABLE_ELEM(PokeType.HONOO, new TokuseiNo[CHECK_TOK_MAX]
            {
                TokuseiNo.MORAIBI, TokuseiNo.NULL, TokuseiNo.NULL, TokuseiNo.NULL,
            }),
            new CMDFUNC_CHECK_WAZA_NO_EFFECT_BY_TOKUSEI_TABLE_ELEM(PokeType.JIMEN, new TokuseiNo[CHECK_TOK_MAX]
            {
                TokuseiNo.HUYUU, TokuseiNo.NULL, TokuseiNo.NULL, TokuseiNo.NULL,
            }),
        };

        // TODO
        public static void SetCommandHandler(byte clientID, AiScriptCommandHandler pCommandHandler) { }

        // TODO
        public static void ClearCommandHandlers() { }

        // TODO
        public static long AI_CMD(byte clientID, AICmd cmd, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_RND_UNDER(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_RND_OVER(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_RND_EQUAL(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IFN_RND_EQUAL(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_HP_UNDER(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_HP_OVER(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_HP_EQUAL(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IFN_HP_EQUAL(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_POKESICK(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IFN_POKESICK(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_WAZASICK(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IFN_WAZASICK(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_DOKUDOKU(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IFN_DOKUDOKU(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_GET_HOROBINOUTA_TURN_MAX(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_GET_HOROBINOUTA_TURN_NOW(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_GET_KODAWARI_WAZA(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_CONTFLG(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IFN_CONTFLG(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_WEATHER(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_SIDEEFF(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IFN_SIDEEFF(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static bool check_have_damage_waza(AiScriptCommandHandler handle, BTL_POKEPARAM bpp) { return false; }

        // TODO
        private static long CMDFUNC_IF_HAVE_DAMAGE_WAZA(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IFN_HAVE_DAMAGE_WAZA(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_TURN(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_TYPE(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_WAZA_USABLE(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static bool IsWazaUsable(BTL_CLIENT attackClient, BTL_POKEPARAM attackPoke, WazaNo wazano) { return false; }

        private static long CMDFUNC_CHECK_DAMAGE_WAZA(AiScriptCommandHandler handle, long[] args)
        {
        	if (args.Length != 0) {
        	  var uVar1 = WAZADATA.IsDamage(args[0]);
        	  return uVar1 & 1;
        	}
        }

        private static long CMDFUNC_CHECK_IRYOKU(AiScriptCommandHandler handle, long[] args)
        {
        	var uVar2 = handle.GetCurrentWazaNo();
        	var uVar1 = WAZADATA.GetPower(uVar2);
        	return uVar1;
        }

        // TODO
        private static long CMDFUNC_COMP_POWER(AiScriptCommandHandler handle, long[] args) { return 0; }

        private static long CMDFUNC_GET_CURRENT_WAZANO(AiScriptCommandHandler handle, long[] args)
        {
        	var iVar1 = handle.GetCurrentWazaNo();
        	return (long)iVar1;
        }

        private static long CMDFUNC_CHECK_WAZASEQNO(AiScriptCommandHandler handle, long[] args)
        {
        	var uVar2 = handle.GetCurrentWazaNo();
        	var iVar1 = WAZADATA.GetAISeqNo(uVar2);
        	return (long)iVar1;
        }

        // TODO
        private static long CMDFUNC_CHECK_WAZA_AISYOU(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_GET_WAZA_AISYOU(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_HAVE_WAZA_AISYOU_OVER(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_HAVE_WAZA_AISYOU_EQUAL(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static TypeAffinity.AffinityID CalcTypeAffinity(in BattleEnv battleEnv, BattleSimulator pSimulator, BTL_POKEPARAM attackPoke, BTL_POKEPARAM defensePoke, WazaNo wazano) { return TypeAffinity.AffinityID.TYPEAFF_0; }

        // TODO
        private static TypeAffinity.AffinityID CalcTypeAffinityCanBench(in BattleEnv battleEnv, BattleSimulator pSimulator, BTL_POKEPARAM attackPoke, BTL_POKEPARAM defensePoke, WazaNo wazano) { return TypeAffinity.AffinityID.TYPEAFF_0; }

        // TODO
        private static long CMDFUNC_CHECK_WAZA_NO_EFFECT_BY_TOKUSEI(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static TokuseiNo CheckPokeTokusei(in MainModule mainModule, byte myClientId, BTL_POKEPARAM targetPoke) { return TokuseiNo.NULL; }

        // TODO
        private static bool check_current_waza_hinsi(AiScriptCommandHandler handle, int loss_flag) { return false; }

        // TODO
        private static long CMDFUNC_IF_WAZA_HINSHI(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IFN_WAZA_HINSHI(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_LAST_WAZA(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_TOKUSEI(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static bool check_have_waza(AiScriptCommandHandler handle, int ai_side, WazaNo waza_no) { return false; }

        // TODO
        private static long CMDFUNC_IF_HAVE_WAZA(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IFN_HAVE_WAZA(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_GET_LAST_DAMAGED_WAZA_AT_PREV_TURN(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_FIRST(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_BENCH_COUNT(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static bool check_pokesick_in_bench(AiScriptCommandHandler handle, int ai_side) { return false; }

        // TODO
        private static long CMDFUNC_IF_BENCH_COND(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IFN_BENCH_COND(AiScriptCommandHandler handle, long[] args) { return 0; }

        private static int get_poke_param(AiScriptCommandHandler handle, int ai_side, BTL_POKEPARAM.ValueID valueID)
        {
        	var uVar1 = handle.GetBppByAISide(ai_side);
        	uVar1.GetValue(valueID);
        	return 0;
        }

        // TODO
        private static long CMDFUNC_IF_PARA_UNDER(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_PARA_OVER(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_PARA_EQUAL(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IFN_PARA_EQUAL(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static bool check_have_waza_seqno(AiScriptCommandHandler handle, int ai_side, int seq_no) { return false; }

        // TODO
        private static long CMDFUNC_IF_HAVE_WAZA_SEQNO(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IFN_HAVE_WAZA_SEQNO(AiScriptCommandHandler handle, long[] args) { return 0; }

        private static long CMDFUNC_ESCAPE(AiScriptCommandHandler handle, long[] args)
        {
        	handle.NotifyEscapeByAI();
        	return 0;
        }

        // TODO
        private static long CMDFUNC_CHECK_SOUBI_ITEM(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_SOUBI_EQUIP(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_POKESEX(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_NEKODAMASI(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_TAKUWAERU(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_BTL_RULE(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_BTL_COMPETITOR(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_RECYCLE_ITEM(AiScriptCommandHandler handle, long[] args) { return 0; }

        private static long CMDFUNC_CHECK_WORKWAZA_TYPE(AiScriptCommandHandler handle, long[] args)
        {
        	var uVar2 = handle.GetCurrentWazaNo();
        	var uVar1 = WAZADATA.GetType(uVar2);
        	return uVar1;
        }

        private static long CMDFUNC_CHECK_WORKWAZA_POW(AiScriptCommandHandler handle, long[] args)
        {
        	var uVar2 = handle.GetCurrentWazaNo();
        	var uVar1 = WAZADATA.GetPower(uVar2);
        	return uVar1;
        }

        private static long CMDFUNC_CHECK_WORKWAZA_SEQNO(AiScriptCommandHandler handle, long[] args)
        {
        	var uVar2 = handle.GetCurrentWazaNo();
        	var iVar1 = WAZADATA.GetAISeqNo(uVar2);
        	return (long)iVar1;
        }

        // TODO
        private static long CMDFUNC_CHECK_MAMORU_COUNT(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_LEVEL(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_CHOUHATSU(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IFN_CHOUHATSU(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_MIKATA_ATTACK(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_HAVE_TYPE(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_HAVE_TOKUSEI(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_ALREADY_MORAIBI(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_HAVE_ITEM(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_FLDEFF_CHECK(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_SIDEEFF_COUNT(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_BENCH_HPDEC(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_BENCH_PPDEC(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_NAGETSUKERU_IRYOKU(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_PP_REMAIN(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_TOTTEOKI(AiScriptCommandHandler handle, long[] args) { return 0; }

        private static long CMDFUNC_CHECK_WAZA_KIND(AiScriptCommandHandler handle, long[] args)
        {
        	var uVar2 = handle.GetCurrentWazaNo();
        	var iVar1 = WAZADATA.GetDamageType(uVar2);
        	return (long)iVar1;
        }

        // TODO
        private static long CMDFUNC_CHECK_LAST_WAZA_KIND(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_AGI_RANK(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_SLOWSTART_TURN(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_BENCH_DAMAGE_MAX(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_HAVE_BATSUGUN(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_LAST_WAZA_DAMAGE_CHECK(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_STATUS_UP(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_STATUS_DIFF(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_STATUS(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_COMP_POWER_WITH_PARTNER(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_HINSHI(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IFN_HINSHI(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_GET_TOKUSEI(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_MIGAWARI(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_MONSNO(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_CHECK_FORMNO(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_COMMONRND_UNDER(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_COMMONRND_OVER(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_COMMONRND_EQUAL(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IFN_COMMONRND_EQUAL(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_MIRAIYOCHI(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_DMG_PHYSIC_UNDER(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_DMG_PHYSIC_OVER(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_DMG_PHYSIC_EQUAL(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_ATE_KINOMI(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_HAVE_KINOMI(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_TYPE_EX(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_EXIST_GROUND(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_GET_WEIGHT(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_MULTI(AiScriptCommandHandler handle, long[] args) { return 0; }

        private static long CMDFUNC_IF_MEGAEVOLVED(AiScriptCommandHandler handle, long[] args)
        {
        	return 0;
        }

        private static long CMDFUNC_IF_CAN_MEGAEVOLVE(AiScriptCommandHandler handle, long[] args)
        {
        	return 0;
        }

        // TODO
        private static long CMDFUNC_IF_WAZAHIDE(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_GET_MEZAPA_TYPE(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_I_AM_SENARIO_TRAINER(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_GET_MAX_WAZA_POWER_INCLUDE_AFFINITY(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static uint GetMaxWazaPowerIncludeAffinity(in BattleEnv battleEnv, BattleSimulator pSimulator, BTL_POKEPARAM attackPoke, BTL_POKEPARAM defensePoke) { return 0; }

        private static long CMDFUNC_GET_CURRENT_ITEMNO(AiScriptCommandHandler handle, long[] args)
        {
        	var uVar1 = handle.GetCurrentItemNo();
        	return uVar1;
        }

        // TODO
        private static long CMDFUNC_IF_ZIDANDA_POWERUP(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_GET_CLIENT_KILL_COUNT(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_GET_WAZA_TARGET(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_HAVE_BATSUGUN_CAN_BENCH(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_G(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_GWALL_EXIST(AiScriptCommandHandler handle, long[] args) { return 0; }

        private static long CMDFUNC_IF_JK3_LEGEND(AiScriptCommandHandler handle, long[] args)
        {
        	return 0;
        }

        // TODO
        private static long CMDFUNC_IF_CAN_G(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_GWAZA_USE_TURN(AiScriptCommandHandler handle, long[] args) { return 0; }

        // TODO
        private static long CMDFUNC_IF_CAN_CHANGE_POKE(AiScriptCommandHandler handle, long[] args) { return 0; }

        public delegate long BTL_AICMD_FUNC(AiScriptCommandHandler handle, long[] args);

        private struct CMDFUNC_CHECK_WAZA_NO_EFFECT_BY_TOKUSEI_TABLE_ELEM
        {
            public PokeType wazaType;
            public TokuseiNo[] tokusei;

            public CMDFUNC_CHECK_WAZA_NO_EFFECT_BY_TOKUSEI_TABLE_ELEM(PokeType wazaType, TokuseiNo[] tokusei)
            {
                this.wazaType = wazaType;
                this.tokusei = tokusei;
            }
        }
    }
}