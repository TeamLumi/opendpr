using System;
using UnityEngine;

namespace Pml.PokePara
{
    [Serializable]
    public struct SavePokeParty
    {
        [SerializeField]
        private SerializedPokemonFull[] members;
        [SerializeField]
        private byte memberCount;
        [SerializeField]
        private byte markingIndex;

        public void Serialize_Full(PokeParty party)
        {
            CreateWorkIfNeed();
            for (int i = 0; i < PokeParty.MAX_MEMBERS; i++)
            {
                var member = party.GetMemberPointer((uint)i);
                member.Serialize_Full(ref members[i]);
            }
            memberCount = (byte)party.GetMemberCount();
            markingIndex = (byte)party.GetMarkingIndex();
        }

        public void Deserialize_Full(PokeParty party)
        {
            CreateWorkIfNeed();
            for (int i = 0; i < PokeParty.MAX_MEMBERS; i++)
            {
                var pp = party.GetMemberPointer((uint)i);
                pp.Deserialize_Full(members[i]);
            }
            party.SetMemberCount(memberCount);
            party.SetMarkingIndex(markingIndex);
        }

        public void CreateWorkIfNeed()
        {
            if (members == null)
                members = new SerializedPokemonFull[PokeParty.MAX_MEMBERS];
            for (int i = 0; i < members.Length; i++)
                members[i].CreateWorkIfNeed();
        }

        public void Clear()
        {
            members = null;
            memberCount = 0;
            markingIndex = 0;
            CreateWorkIfNeed();
        }
    }
}