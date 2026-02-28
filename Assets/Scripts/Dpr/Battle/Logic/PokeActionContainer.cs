using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class PokeActionContainer
    {
        private const byte MAX_ACT_ORDER_NUM = 30;
        private PokeAction[] m_actions = new PokeAction[MAX_ACT_ORDER_NUM];
        private byte m_count;

        public PokeActionContainer()
        {
            m_count = 0;
        }

        public void Clear()
        {
        	this.m_count = (byte)0;
        }

        public byte GetCount()
        {
        	return (byte)(this.m_count);
        }

        // TODO
        public byte GetIndex(PokeAction action) { return 0; }

        // TODO
        public bool IsAllActDoneByPokeID(byte pokeID) { return false; }

        // TODO
        public void Add(in PokeAction action) { }

        // TODO
        public bool IsAllActionDone() { return false; }

        // TODO
        public PokeAction Next() { return null; }

        // TODO
        public PokeAction Get(byte index) { return null; }

        // TODO
        public void Swap(byte index1, byte index2) { }

        // TODO
        public void ForceDone(byte pokeID) { }

        // TODO
        public PokeAction SearchByPokeID(byte pokeID, bool isSkipGStart, bool isSkipNull = false) { return null; }

        // TODO
        public PokeAction SearchNextByPokeID(PokeAction start, byte pokeID, bool isSkipGStart) { return null; }

        // TODO
        private PokeAction searchByPokeID_Core(byte pokeID, byte startIdx, bool isSkipGStart, bool isSkipNull = false, bool isSkipDone = false, WazaNo wazano = WazaNo.NULL) { return null; }

        // TODO
        public PokeAction SearchByWazaID(WazaNo waza, byte startIndex) { return null; }

        // TODO
        public PokeAction SearchForCombiWaza(MainModule pMainModule, WazaNo waza, byte pokeID, BtlPokePos targetPos) { return null; }

        // TODO
        public bool PostponeAction(byte pokeID) { return false; }

        // TODO
        public void PostponeAction(PokeAction action) { }

        // TODO
        public void InterruptAction(PokeAction action) { }

        // TODO
        public bool ReserveInterruptAction(byte intrPokeID, WazaNo wazano = WazaNo.NULL) { return false; }

        // TODO
        public bool ReserveInterruptActionByWaza(WazaNo waza) { return false; }

        // TODO
        public bool InsertAction(in PokeAction action) { return false; }
    }
}