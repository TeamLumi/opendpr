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

        public bool AddMember(PokemonParam pp)
        {
            if (pp.GetMonsNo() == MonsNo.NULL)
                return false;
            if (IsFull())
                return false;
            m_member[m_memberCount].CopyFrom(pp);
            m_memberCount++;
            return true;
        }

        public void ReplaceMember(uint idx, PokemonParam pp)
        {
            // TODO: Ghidra shows complex logic — checks source/dest MonsNo, Serialize/Deserialize,
            // increments memberCount if replacing NULL with non-NULL, updates markingIndex via
            // ClearMarkingIndex-like logic when markingIndex == idx
        }

        public void RemoveMember(uint idx)
        {
            // TODO: Ghidra shows complex logic — checks MonsNo, calls FieldWalkingManager.CheckPartnerPokeChange,
            // gets ID/PersonalRnd for BallDecoWork.GetAttachCapsuleId/SetAttachCapsule, calls ClearData,
            // scootOver, decrements memberCount, BallDecoWork.ScootOverCapsuleExtraData, markingIndex adjustment
        }

        public void ExchangePosition(byte pos1, byte pos2)
        {
            // TODO: Ghidra shows complex logic — sorts positions, swaps array references directly,
            // calls scootOver, swaps markingIndex if either position matches,
            // calls BallDecoWork.SwapCapsuleExtraData
        }

        public PokemonParam GetMemberPointer(uint idx)
        {
            return m_member[idx];
        }

        public PokemonParam GetMemberPointerConst(uint idx)
        {
            return m_member[idx];
        }

        public uint GetMemberCount()
        {
            return m_memberCount;
        }

        public void SetMemberCount(uint count)
        {
            m_memberCount = count;
        }

        public uint GetMemberIndex(PokemonParam pokeParam)
        {
            for (uint i = 0; i < m_memberCount; i++)
            {
                if (m_member[i] == pokeParam)
                    return i;
            }
            return MEMBER_INDEX_ERROR;
        }

        public uint GetMemberCountEx(CountType type)
        {
            return GetMemberCountEx(type, 0);
        }

        public uint GetMemberCountEx(CountType type, byte pass_idx_bit)
        {
            uint count = 0;
            for (uint i = 0; i < m_memberCount; i++)
            {
                if ((pass_idx_bit & (1 << (int)i)) != 0)
                    continue;

                var member = m_member[i];
                if (member.GetMonsNo() == MonsNo.NULL)
                    continue;

                switch (type)
                {
                    case CountType.ALL:
                        count++;
                        break;
                    case CountType.BATTLE_ENABLE:
                        if (!member.IsEgg(EggCheckType.BOTH_EGG) && (!member.HaveCalcParam() || member.GetHp() > 0))
                            count++;
                        break;
                    case CountType.NOT_EGG:
                        if (!member.IsEgg(EggCheckType.BOTH_EGG))
                            count++;
                        break;
                    case CountType.ONLY_LEGAL_EGG:
                        if (member.IsEgg(EggCheckType.ONLY_LEGAL_EGG))
                            count++;
                        break;
                    case CountType.ONLY_ILLEGAL_EGG:
                        if (member.IsEgg(EggCheckType.ONLY_ILLEGAL_EGG))
                            count++;
                        break;
                    case CountType.BOTH_EGG:
                        if (member.IsEgg(EggCheckType.BOTH_EGG))
                            count++;
                        break;
                }
            }
            return count;
        }

        public uint GetMemberTopIndex(SearchType type)
        {
            for (uint i = 0; i < m_memberCount; i++)
            {
                var member = m_member[i];
                if (member.GetMonsNo() == MonsNo.NULL)
                    continue;

                switch (type)
                {
                    case SearchType.BATTLE_ENABLE:
                        if (!member.IsEgg(EggCheckType.BOTH_EGG) && (!member.HaveCalcParam() || member.GetHp() > 0))
                            return i;
                        break;
                    case SearchType.NOT_EGG:
                        if (!member.IsEgg(EggCheckType.BOTH_EGG))
                            return i;
                        break;
                }
            }
            return MEMBER_INDEX_ERROR;
        }

        public bool CheckPokeExist(MonsNo monsno)
        {
            for (uint i = 0; i < m_memberCount; i++)
            {
                if (m_member[i].IsEgg(EggCheckType.BOTH_EGG))
                    continue;
                if (m_member[i].GetMonsNo() == monsno)
                    return true;
            }
            return false;
        }

        public bool IsFull()
        {
            return m_memberCount >= MAX_MEMBERS;
        }

        public void CopyFrom(PokeParty src)
        {
            for (int i = 0; i < MAX_MEMBERS; i++)
            {
                m_member[i].CopyFrom(src.m_member[i]);
            }
            m_memberCount = src.m_memberCount;
        }

        public void Clear()
        {
            for (int i = 0; i < MAX_MEMBERS; i++)
            {
                m_member[i].Clear();
            }
            m_memberCount = 0;
            ClearMarkingIndex();
        }

        public void SerializeFull(ref SavePokeParty save)
        {
            save.Serialize_Full(this);
        }

        public void DeserializeFull(ref SavePokeParty save)
        {
            save.Deserialize_Full(this);
        }

        public bool CheckPokerusExist()
        {
            for (uint i = 0; i < m_memberCount; i++)
            {
                if (m_member[i].GetPokerus() != 0)
                    return true;
            }
            return false;
        }

        public bool PokerusCatchCheck()
        {
            // TODO: Ghidra shows completely different algorithm — uses Pml.Local.Random.GetValue,
            // checks for specific values (0x4000, 0xc000, 0x8000 from range 0x10000),
            // loops to find non-legal-egg with MonsNo != 0, different strain/days calculation
            return false;
        }

        public bool PokerusInfectionCheck()
        {
            // TODO: Ghidra shows different algorithm — uses Pml.Local.Random.GetValue(3) for 1/3 chance,
            // copies full pokerus value (not recalculated strain/days) to adjacent members,
            // extra index increment when infecting forward neighbor, checks (pokerus & 0xf) != 0
            return false;
        }

        public void DecreasePokerusDayCount(int passed_day_count)
        {
            // TODO: Ghidra shows two separate paths — if passed_day_count < 5: subtract days with
            // clamping, preserve strain (or set to 0x10 if strain was 0), assert result != 0;
            // if passed_day_count >= 5: zero out days completely, keep strain, assert strain != 0
        }

        public void RecoverAll()
        {
            for (uint i = 0; i < m_memberCount; i++)
            {
                m_member[i].RecoverAll();
            }
        }

        public void SetMarkingIndex(uint pos)
        {
            markingIndex = (byte)pos;
        }

        public uint GetMarkingIndex()
        {
            return markingIndex;
        }

        public bool CanTrade()
        {
            if (GetMemberCountEx(CountType.ONLY_ILLEGAL_EGG) != 0)
                return false;
            uint eggCount = GetMemberCountEx(CountType.BOTH_EGG);
            return (uint)(m_memberCount - eggCount) > 1;
        }

        public bool CanTradeMember(uint idx)
        {
            return GetMemberCountEx(CountType.BATTLE_ENABLE, (byte)(1 << (int)(idx & 0x1f))) != 0;
        }

        private void Dump()
        {
        }

        private void scootOver()
        {
            // TODO: Ghidra shows reverse iteration pattern (from index 4 down to 0), finds NULL entries
            // and shifts non-NULL entries from end to fill gaps, with array reference swapping
        }

        private void ClearMarkingIndex()
        {
            for (uint i = 0; i < m_memberCount; i++)
            {
                if (!m_member[i].IsEgg(EggCheckType.BOTH_EGG))
                {
                    markingIndex = (byte)i;
                    return;
                }
            }
            markingIndex = 0;
        }

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
