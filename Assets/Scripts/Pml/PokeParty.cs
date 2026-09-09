using Pml.PokePara;

namespace Pml
{
    public sealed class PokeParty
    {
        public const int MAX_MEMBERS = 6;
        public const int MEMBER_INDEX_ERROR = 6;
        private PokemonParam[] m_member = new PokemonParam[MAX_MEMBERS];
        private uint m_memberCount;
        private byte markingIndex;

        public PokeParty()
        {
            m_member[0] = new PokemonParam(MonsNo.NULL, 1, 0);
            m_member[1] = new PokemonParam(MonsNo.NULL, 1, 0);
            m_member[2] = new PokemonParam(MonsNo.NULL, 1, 0);
            m_member[3] = new PokemonParam(MonsNo.NULL, 1, 0);
            m_member[4] = new PokemonParam(MonsNo.NULL, 1, 0);
            m_member[5] = new PokemonParam(MonsNo.NULL, 1, 0);
        }

        // TODO
        public bool AddMember(PokemonParam pp) { return false; }

        // TODO
        public void ReplaceMember(uint idx, PokemonParam pp) { }

        // TODO
        public void RemoveMember(uint idx) { }

        // TODO
        public void ExchangePosition(byte pos1, byte pos2) { }

        // TODO
        public PokemonParam GetMemberPointer(uint idx) { return null; }

        // TODO
        public PokemonParam GetMemberPointerConst(uint idx) { return null; }

        public uint GetMemberCount()
        {
            return m_memberCount;
        }

        public void SetMemberCount(uint count) {
            m_memberCount = count;
        }

        // TODO
        public uint GetMemberIndex(PokemonParam pokeParam) { return 0; }

        // TODO
        public uint GetMemberCountEx(CountType type) { return 0; }

        // TODO
        public uint GetMemberCountEx(CountType type, byte pass_idx_bit) { return 0; }

        // TODO
        public uint GetMemberTopIndex(SearchType type) { return 0; }

        // TODO
        public bool CheckPokeExist(MonsNo monsno) { return false; }

        // TODO
        public bool IsFull() { return false; }

        // TODO
        public void CopyFrom(PokeParty src) { }

        // TODO
        public void Clear() { }

        // TODO
        public void SerializeFull(ref SavePokeParty save) { }

        // TODO
        public void DeserializeFull(ref SavePokeParty save) { }

        // TODO
        public bool CheckPokerusExist() { return false; }

        // TODO
        public bool PokerusCatchCheck() { return false; }

        // TODO
        public bool PokerusInfectionCheck() { return false; }

        // TODO
        public void DecreasePokerusDayCount(int passed_day_count) { }

        // TODO
        public void RecoverAll() { }

        // TODO
        public void SetMarkingIndex(uint pos) { }

        public uint GetMarkingIndex() {
            return markingIndex;
        }

        // TODO
        public bool CanTrade() { return false; }

        // TODO
        public bool CanTradeMember(uint idx) { return false; }

        // TODO
        private void Dump() { }

        // TODO
        private void scootOver() { }

        // TODO
        private void ClearMarkingIndex() { }

        public enum CountType : int
        {
            ALL = 0,
            BATTLE_ENABLE = 1,
            NOT_EGG = 2,
            ONLY_LEGAL_EGG = 3,
            ONLY_ILLEGAL_EGG = 4,
            BOTH_EGG = 5,
        }

        public enum SearchType : int
        {
            BATTLE_ENABLE = 0,
            NOT_EGG = 1,
        }
    }
}