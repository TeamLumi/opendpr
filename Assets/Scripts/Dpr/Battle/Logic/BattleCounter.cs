using System.Runtime.InteropServices;

namespace Dpr.Battle.Logic
{
    public sealed class BattleCounter
    {
        // BUG: The Client and Side counter arrays are initialized with a size of 5 instead of 1, it's likely they used UniqueCounter.NUM instead of their respective maximums
        private ulong[] m_uniqueCount = Arrays.InitializeWithDefaultInstances<ulong>((int)UniqueCounter.NUM);
        private ulong[][] m_clientCount = RectangularArrays.RectangularDefaultArray<ulong>((int)UniqueCounter.NUM, (int)BTL_CLIENT_ID.BTL_CLIENT_NUM);
        private ulong[][] m_sideCount = RectangularArrays.RectangularDefaultArray<ulong>((int)UniqueCounter.NUM, (int)BtlSide.BTL_SIDE_NUM);

        // TODO: Find good constants to replace the numbers with
        private static readonly CounterDesc[] COUNTER_DESC_UNIQUE = new CounterDesc[(int)UniqueCounter.NUM]
        {
            new CounterDesc(DefineConstants.BTL_TURNCOUNT_MAX),
            new CounterDesc(30),
            new CounterDesc(Safari.SAFARI_COUNT_MAX),
            new CounterDesc(12),
            new CounterDesc(Safari.SAFARI_BALL_MAX),
        };
        private static readonly CounterDesc[] COUNTER_DESC_CLIENT = new CounterDesc[(int)ClientCounter.NUM] { new CounterDesc(0xFF) };
        private static readonly CounterDesc[] COUNTER_DESC_SIDE = new CounterDesc[(int)SideCounter.NUM] { new CounterDesc(0xFF) };

        private static ref CounterDesc GetCounterDesc(UniqueCounter counterID)
        {
            return ref COUNTER_DESC_UNIQUE[(int)counterID];
        }

        private static ref CounterDesc GetCounterDesc(ClientCounter counterID)
        {
            return ref COUNTER_DESC_CLIENT[(int)counterID];
        }

        private static ref CounterDesc GetCounterDesc(SideCounter counterID)
        {
            return ref COUNTER_DESC_SIDE[(int)counterID];
        }

        public BattleCounter()
        {
            Initialize(null);
        }

        public void Initialize([Optional] MainModule mainModule)
        {
            for (int i=0; i<m_uniqueCount.Length; i++)
            {
                if (mainModule == null)
                {
                    switch ((UniqueCounter)i)
                    {
                        case UniqueCounter.BATTLE_TURN_COUNT:   m_uniqueCount[i] = 0; break;
                        case UniqueCounter.ESCAPE_TRIED_COUNT:  m_uniqueCount[i] = 0; break;
                        case UniqueCounter.SAFARI_GET_COUNT:    m_uniqueCount[i] = 6; break;
                        case UniqueCounter.SAFARI_ESCAPE_COUNT: m_uniqueCount[i] = 6; break;
                        case UniqueCounter.SAFARI_BALL_COUNT:   m_uniqueCount[i] = 0; break;
                        default:                                m_uniqueCount[i] = 0; break;
                    }
                }
                else
                {
                    switch ((UniqueCounter)i)
                    {
                        case UniqueCounter.BATTLE_TURN_COUNT:   m_uniqueCount[i] = 0; break;
                        case UniqueCounter.ESCAPE_TRIED_COUNT:  m_uniqueCount[i] = 0; break;
                        case UniqueCounter.SAFARI_GET_COUNT:    m_uniqueCount[i] = 6; break;
                        case UniqueCounter.SAFARI_ESCAPE_COUNT: m_uniqueCount[i] = 6; break;
                        case UniqueCounter.SAFARI_BALL_COUNT:   m_uniqueCount[i] = (ulong)mainModule.GetBattleSetupParam().safariBallNum; break;
                        default:                                m_uniqueCount[i] = 0; break;
                    }
                }
            }

            for (int i=0; i<m_clientCount.Length; i++)
                for (int j=0; j<m_clientCount[i].Length; j++)
                    m_clientCount[i][j] = 0;

            for (int i=0; i<m_sideCount.Length; i++)
                for (int j=0; j<m_sideCount[i].Length; j++)
                    m_sideCount[i][j] = 0;
        }

        public void CopyFrom(BattleCounter src)
        {
            for (int i=0; i<m_uniqueCount.Length; i++)
                m_uniqueCount[i] = src.m_uniqueCount[i];

            for (int i=0; i<m_clientCount.Length; i++)
                for (int j=0; j<m_clientCount[i].Length; j++)
                    m_clientCount[i][j] = src.m_clientCount[i][j];

            for (int i=0; i<m_sideCount.Length; i++)
                for (int j=0; j<m_sideCount[i].Length; j++)
                    m_sideCount[i][j] = src.m_sideCount[i][j];
        }

        public ulong Get(UniqueCounter counterID)
        {
            if (isValidCounter(counterID))
                return m_uniqueCount[(int)counterID];
            else
                return 0;
        }

        public void Inc(UniqueCounter counterID)
        {
            if (isValidCounter(counterID))
            {
                var value = m_uniqueCount[(int)counterID];

                if (value < GetCounterDesc(counterID).max)
                    m_uniqueCount[(int)counterID]++;
            }
        }

        public void Dec(UniqueCounter counterID)
        {
            if (isValidCounter(counterID))
            {
                var value = m_uniqueCount[(int)counterID];

                if (value < GetCounterDesc(counterID).max && value != 0)
                    m_uniqueCount[(int)counterID]--;
            }
        }

        public ulong Get(ClientCounter counterID, BTL_CLIENT_ID clientID)
        {
            if (isValidCounter(counterID, clientID))
                return m_clientCount[(int)counterID][(int)clientID];
            else
                return 0;
        }

        public void Inc(ClientCounter counterID, BTL_CLIENT_ID clientID)
        {
            if (isValidCounter(counterID, clientID))
            {
                var value = m_clientCount[(int)counterID][(int)clientID];

                if (value < GetCounterDesc(counterID).max)
                    m_clientCount[(int)counterID][(int)clientID]++;
            }
        }

        public ulong Get(SideCounter counterID, BtlSide side)
        {
            if (isValidCounter(counterID, side))
                return m_sideCount[(int)counterID][(int)side];
            else
                return 0;
        }

        public void Inc(SideCounter counterID, BtlSide side)
        {
            if (isValidCounter(counterID, side))
            {
                var value = m_sideCount[(int)counterID][(int)side];

                if (value < GetCounterDesc(counterID).max)
                    m_sideCount[(int)counterID][(int)side]++;
            }
        }

        private bool isValidCounter(UniqueCounter counterID)
        {
            return counterID < UniqueCounter.NUM;
        }

        private bool isValidCounter(ClientCounter counterID, BTL_CLIENT_ID clientID)
        {
            return counterID < ClientCounter.NUM && clientID < BTL_CLIENT_ID.BTL_CLIENT_NUM;
        }

        private bool isValidCounter(SideCounter counterID, BtlSide side)
        {
            return counterID < SideCounter.NUM && side < BtlSide.BTL_SIDE_NUM;
        }

        public enum UniqueCounter : byte
        {
            BATTLE_TURN_COUNT = 0,
            ESCAPE_TRIED_COUNT = 1,
            SAFARI_GET_COUNT = 2,
            SAFARI_ESCAPE_COUNT = 3,
            SAFARI_BALL_COUNT = 4,
            NUM = 5,
        }

        public enum ClientCounter : byte
        {
            MEMBER_CHANGE_COUNT = 0,
            NUM = 1,
        }

        public enum SideCounter : byte
        {
            G_USE_COUNT = 0,
            NUM = 1,
        }

        private struct CounterDesc
        {
            public ulong max;

            public CounterDesc(ulong max)
            {
                this.max = max;
            }
        }
    }
}