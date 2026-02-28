namespace Dpr.Battle.Logic
{
    public sealed class DeadRec
    {
        private const int TURN_MAX = 4;
        private const int DEAD_COUNT_MAX = 100;

        private Data m_data = new Data();

        // TODO
        public void CopyFrom(in DeadRec src) { }

        // TODO
        public void Init(POKECON pokeCon) { }

        // TODO
        public void StartTurn() { }

        // TODO
        public void Add(byte pokeID) { }

        // TODO
        public void Relive(byte pokeID) { }

        public bool IsDeadNow(byte pokeID)
        {
        	if (0x1d < pokeID) {
        	  return false;
        	}
        	if ((uint)pokeID < this.m_data.currentDeadFlag.Length) {
        	  return this.m_data.currentDeadFlag + (ulong)pokeID[0] != 0;
        	}
        }

        // TODO
        public uint GetDeadCountByClientID(byte clientID) { return 0; }

        // TODO
        public void SetExpCheckedFlag(byte turn, byte idx) { }

        // TODO
        public byte GetCount(byte turn) { return 0; }

        // TODO
        public byte GetPokeID(byte turn, byte idx) { return 0; }

        // TODO
        public bool GetExpCheckedFlag(byte turn, byte idx) { return false; }

        // TODO
        public byte GetLastDeadPokeID() { return 0; }

        // TODO
        public bool IsRelivedPokePuttableEmptyPos(in PosPoke posPoke) { return false; }

        // TODO
        private void clearTurnRecord(Unit unit) { }

        // TODO
        private void clearReliveRecord() { }

        // TODO
        private bool isRelivedThisTurn(byte pokeID) { return false; }

        private class Unit
        {
            public byte cnt;
            public bool[] fExpChecked = new bool[PokeID.NUM];
            public byte[] deadPokeID = new byte[PokeID.NUM];

            public void CopyFrom(Unit src)
            {
                cnt = src.cnt;

                for (int i=0; i<fExpChecked.Length; i++)
                    fExpChecked[i] = src.fExpChecked[i];

                for (int i=0; i<deadPokeID.Length; i++)
                    deadPokeID[i] = src.deadPokeID[i];
            }
        }

        private class Data
        {
            public Unit[] turnRecord = Arrays.InitializeWithDefaultInstances<Unit>(TURN_MAX);
            public bool[] currentDeadFlag = new bool[PokeID.NUM];
            public byte[] deadCount = new byte[PokeID.NUM];
            public byte[] relivePokeID = new byte[PokeID.NUM];
            public byte relivePokeCount;

            public void CopyFrom(Data src)
            {
                for (int i=0; i<turnRecord.Length; i++)
                    turnRecord[i].CopyFrom(src.turnRecord[i]);

                for (int i=0; i<currentDeadFlag.Length; i++)
                    currentDeadFlag[i] = src.currentDeadFlag[i];

                for (int i=0; i<deadCount.Length; i++)
                    deadCount[i] = src.deadCount[i];

                for (int i=0; i<relivePokeID.Length; i++)
                    relivePokeID[i] = src.relivePokeID[i];

                relivePokeCount = src.relivePokeCount;
            }
        }
    }
}