namespace Dpr.Battle.Logic
{
    public sealed class BTL_PARTY
    {
        private BTL_POKEPARAM[] m_pMember = new BTL_POKEPARAM[DefineConstants.BTL_PARTY_MEMBER_MAX];
        private byte m_memberCount;

        public BTL_PARTY()
        {
            m_memberCount = 0;
            for (int i=0; i<m_pMember.Length; i++)
                m_pMember[i] = null;
        }

        // TODO
        public void Dispose() { }

        // TODO
        public void Initialize() { }

        // TODO
        public void CopyFrom(in BTL_PARTY src) { }

        // TODO
        public void AddMember(BTL_POKEPARAM member) { }

        // TODO
        public void MoveAlivePokeToFirst() { }

        // TODO
        public void MoveLastMember(byte idx) { }

        public byte GetMemberCount()
        {
        	return (byte)(this.m_memberCount);
        }

        // TODO
        public byte GetAliveMemberCount() { return 0; }

        // TODO
        public byte GetAliveMemberCountRear(byte startIdx) { return 0; }

        // TODO
        public byte GetDeadMemberCount() { return 0; }

        public bool IsFull()
        {
        	return 5 < this.m_memberCount;
        }

        // TODO
        public BTL_POKEPARAM GetMemberData(byte idx) { return null; }

        // TODO
        public BTL_POKEPARAM GetMemberDataConst(byte idx) { return null; }

        // TODO
        public void SwapMembers(byte idx1, byte idx2) { }

        // TODO
        public int FindMember(BTL_POKEPARAM param) { return 0; }

        // TODO
        public int FindMemberByPokeID(byte pokeID) { return 0; }

        // TODO
        public BTL_POKEPARAM GetAliveTopMember() { return null; }

        // TODO
        public byte GetMemberIndex(byte pokeID) { return 0; }

        // TODO
        public byte GetIllusionTargetMemberIndex() { return 0; }

        // TODO
        public byte GetTotalKillCount() { return 0; }
    }
}
