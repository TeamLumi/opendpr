using Pml.Battle;

namespace Dpr.Battle.Logic
{
    public sealed class HITCHECK_PARAM
    {
        public byte countMax;
        public byte count;
        public bool needCheckEveryTime;
        public bool isPluralHitWaza;
        public TypeAffinity.AffinityID pluralHitAffinity;
        public bool isDeadMessageDisplay;
        public bool isAffinityMessageDisplay;

        public bool IsPluralHitWaza(byte max)
        {
        	if (this.isPluralHitWaza) {
        	  return true;
        	}
        	return max == '\x01' && 1 < this.countMax;
        }

        public bool IsPluralHitException()
        {
        	if ((!this.isPluralHitWaza) && (1 < this.countMax)) {
        	  return true;
        	}
        	return false;
        }

        public bool IsFirstTime()
        {
        	return this.count == 0;
        }

        public void SetPluralHitAffinity(TypeAffinity.AffinityID affinity)
        {
        	if ((int)this.pluralHitAffinity == 7) {
        	  this.pluralHitAffinity = (AffinityID)(affinity);
        	}
        }

        // TODO
        public HITCHECK_PARAM() { }
    }
}