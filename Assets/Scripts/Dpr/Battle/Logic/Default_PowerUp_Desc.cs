namespace Dpr.Battle.Logic
{
    public static class DEFAULT_POWERUP_DESC
    {
        public static void Clear(DefaultPowerUpDesc desc)
        {
            desc.reason = DefaultPowerUpReason.DEFAULT_POWERUP_REASON_NONE;
            desc.rankUp_Attack = 0;
            desc.rankUp_Defense = 0;
            desc.rankUp_SpAttack = 0;
            desc.rankUp_SpDefense = 0;
            desc.rankUp_Agility = 0;
            desc.aura_color = UnityEngine.Vector4.zero;
        }

        public static void Copy(DefaultPowerUpDesc dest, in DefaultPowerUpDesc src)
        {
            dest.reason = src.reason;
            dest.rankUp_Attack = src.rankUp_Attack;
            dest.rankUp_Defense = src.rankUp_Defense;
            dest.rankUp_SpAttack = src.rankUp_SpAttack;
            dest.rankUp_SpDefense = src.rankUp_SpDefense;
            dest.rankUp_Agility = src.rankUp_Agility;
            dest.aura_color = src.aura_color;
        }

        public static uint GetRankUpParamCount(in DefaultPowerUpDesc desc)
        {
            uint count = 0;
            if (desc.rankUp_Attack > 0) count++;
            if (desc.rankUp_Defense > 0) count++;
            if (desc.rankUp_SpAttack > 0) count++;
            if (desc.rankUp_SpDefense > 0) count++;
            if (desc.rankUp_Agility > 0) count++;
            return count;
        }

        public static byte GetMaxRankUpValue(in DefaultPowerUpDesc desc)
        {
            byte max = desc.rankUp_Attack;
            if (desc.rankUp_Defense > max) max = desc.rankUp_Defense;
            if (desc.rankUp_SpAttack > max) max = desc.rankUp_SpAttack;
            if (desc.rankUp_SpDefense > max) max = desc.rankUp_SpDefense;
            if (desc.rankUp_Agility > max) max = desc.rankUp_Agility;
            return max;
        }
    }
}