using Pml.Battle;

namespace Dpr.Battle.Logic
{
    public sealed class DmgAffRec
    {
        private AffinityData[] m_affinityData;

        // TODO
        public DmgAffRec() { }

        // TODO
        public void Init() { }

        // TODO
        public void Add(byte pokeID, TypeAffinity.AffinityID aff, bool isNoEffectByFloatingStatus) { }

        public unsafe TypeAffinity.AffinityID Get(byte pokeID)
        {
        	var uVar1 = (uint)pokeID & 0xff;
        	if ((int)this.m_affinityData.Length <= (int)uVar1) {
        	  return (AffinityID)7;
        	}
        	if (uVar1 < this.m_affinityData.Length) {
        	  return *(uint *)
        	          (this.m_affinityData + (pokeID & 0xff) * 8[0] + 0x10);
        	}
        	return (AffinityID)0;
        }

        public unsafe TypeAffinity.AffinityID GetIfEnable(byte pokeID)
        {
        	var uVar1 = (uint)pokeID & 0xff;
        	if ((int)this.m_affinityData.Length <= (int)uVar1) {
        	  return (AffinityID)0xe;
        	}
        	if (uVar1 < this.m_affinityData.Length) {
        	  return *(uint *)
        	          (this.m_affinityData + (pokeID & 0xff) * 8[0] + 0x10);
        	}
        	return (AffinityID)0;
        }

        // TODO
        public bool IsNoEffectByFloatingStatus(byte pokeID) { return false; }

        private class AffinityData
        {
            public TypeAffinity.AffinityID typeAffinity;
            public bool isNoEffectByFloatingStatus;

            // TODO
            public AffinityData() { }
        }
    }
}