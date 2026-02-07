namespace Dpr.Battle.Logic
{
    public static class BattleAiSystem
    {
        public const int BASIC_RAND_RANGE = 256;

        private static bool[] s_isTokuseiOpened = new bool[PokeID.NUM];
        private static ulong s_commonRandValue;

        public static void InitSystem()
        {
            for (int i=0; i<PokeID.NUM; i++)
                s_isTokuseiOpened[i] = false;
        }

        public static void QuitSystem()
        {
            for (int i = 0; i < PokeID.NUM; i++)
                s_isTokuseiOpened[i] = false;
            s_commonRandValue = 0;
        }

        public static void NotifyTokuseiOpen(byte pokeID)
        {
            if (pokeID < PokeID.NUM)
                s_isTokuseiOpened[pokeID] = true;
        }

        public static bool IsTokuseiOpened(byte pokeID)
        {
            if (pokeID < PokeID.NUM)
                return s_isTokuseiOpened[pokeID];
            return false;
        }

        public static void SetCommonRand(ulong randValue)
        {
            s_commonRandValue = randValue;
        }

        public static ulong GetCommonRand()
        {
            return s_commonRandValue;
        }
    }
}
