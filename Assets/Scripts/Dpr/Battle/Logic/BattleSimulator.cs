using Pml.Battle;
using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class BattleSimulator
    {
        private readonly BattleEnv m_pSrcBattleEnv;
        private BattleEnv m_battleEnv;
        private BattleDriver m_battleDriver;

        public BattleSimulator(in SetupParam param)
        {
            m_pSrcBattleEnv = param.pSrcEnv;
            m_battleEnv = null;
            m_battleDriver = null;

            createBattleEnv(param.pMainModule);
            createBattleDriver(param.pMainModule);
        }

        // TODO
        public void createBattleEnv(MainModule pMainModule) { }

        // TODO
        public void createBattleDriver(MainModule pMainModule) { }

        // TODO
        public BtlWeather GetWeather() { return BtlWeather.BTL_WEATHER_NONE; }

        // TODO
        public ushort CalcAgility(BTL_POKEPARAM poke, bool isTrickRoomApply) { return 0; }

        // TODO
        public ushort CalcAgilityOrder(BTL_POKEPARAM poke, bool isTrickRoomApply) { return 0; }

        // TODO
        public bool IsPosEffectExist(BtlPokePos pos, BtlPosEffect effect) { return false; }

        // TODO
        public ushort CalcDamage(byte atkPokeID, byte defPokeID, WazaNo waza, bool isAffinityEnable, bool isRandomEnable) { return 0; }

        // TODO
        public TypeAffinity.AffinityID CalcTypeAffinity(byte atkPokeID, byte defPokeID, WazaNo waza, bool onlyAttacker) { return TypeAffinity.AffinityID.TYPEAFF_0; }

        private void copyBattleEnv()
        {
        	this.m_battleEnv.CopyFrom(ref this.m_pSrcBattleEnv);
        }

        // TODO
        private void clearServerCommandQueue() { }

        public class SetupParam
        {
            public MainModule pMainModule;
            public BattleEnv pSrcEnv;
        }
    }
}