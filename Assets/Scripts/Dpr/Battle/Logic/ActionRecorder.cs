namespace Dpr.Battle.Logic
{
    public sealed class ActionRecorder
    {
        public const uint RECORD_TURN_NUM = 2;
        private TurnData[] m_turnData = Arrays.InitializeWithDefaultInstances<TurnData>((int)RECORD_TURN_NUM);

        public ActionRecorder()
        {
            Clear();
        }

        public void CopyFrom(in ActionRecorder src)
        {
            for (int i=0; i<m_turnData.Length; i++)
                m_turnData[i].CopyFrom(src.m_turnData[i]);
        }

        public void Clear()
        {
            ClearTurnData(m_turnData[0]);
            ClearTurnData(m_turnData[1]);
        }

        private void ClearTurnData(TurnData turnData)
        {
            for (int i = 0; i < turnData.pokeData.Length; i++)
                turnData.pokeData[i].actionFlag = 0;
        }

        public void StartTurn()
        {
            for (int i = (int)(RECORD_TURN_NUM - 1); i > 0; i--)
                m_turnData[i].CopyFrom(m_turnData[i - 1]);

            ClearTurnData(m_turnData[0]);
        }

        public bool CheckAction(byte pokeId, byte backTurnCount, ActionID actionId)
        {
            if (backTurnCount >= RECORD_TURN_NUM)
                return false;

            return (m_turnData[backTurnCount].pokeData[pokeId].actionFlag & (1u << (int)actionId)) != 0;
        }

        public void SetAction(byte pokeId, ActionID actionId)
        {
            m_turnData[0].pokeData[pokeId].actionFlag |= (1u << (int)actionId);
        }

        public enum ActionID : byte
        {
            FAILED_MASTER = 0,
            FAILED_HIT_PERCENTAGE = 1,
            FAILED_TOKUSEI = 2,
            FAILED_TYPE = 3,
            FAILED_GUARD_WAZA = 4,
            NUM = 5,
        }

        private class PokeData
        {
            public uint actionFlag;
        }

        private class TurnData
        {
            public PokeData[] pokeData = Arrays.InitializeWithDefaultInstances<PokeData>(30);

            public void CopyFrom(TurnData src)
            {
                for (int i=0; i<pokeData.Length; i++)
                    pokeData[i].actionFlag = src.pokeData[i].actionFlag;
            }
        }
    }
}