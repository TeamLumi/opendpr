using Pml.Battle;

namespace Dpr.Battle.Logic
{
	public sealed class DamageCalcResult
	{
		public byte realHitCount;
		public byte migawariHitCount;
		public RECORD[] record = Arrays.InitializeWithDefaultInstances<RECORD>(DefineConstants.BTL_PARTY_MEMBER_MAX);
		
		public DamageCalcResult()
		{
			realHitCount = 0;
			migawariHitCount = 0;

			for (int i=0; i<record.Length; i++)
				record[i].Clear();
		}
		
		public void CopyFrom(in DamageCalcResult src)
		{
            realHitCount = src.realHitCount;
            migawariHitCount = src.migawariHitCount;

            for (int i=0; i<record.Length; i++)
				record[i].CopyFrom(src.record[i]);
        }
		
		// TODO
		public void Merge(in DamageCalcResult src) { }
		
		public uint GetTargetCount()
		{
			return (uint)this.migawariHitCount + (uint)this.realHitCount;
		}
		
		// TODO
		public uint GetDamageSum() { return default; }

		public class RECORD
		{
			public ushort damage;
			public byte pokeID;
			public TypeAffinity.AffinityID affinity;
			public KoraeruCause koraeruCause;
			public bool isCritical;
			public bool isCriticalByFriendship;
			public bool isFixDamage;
			public bool isMigawari;
			
			public void Clear()
			{
                damage = 0;
                pokeID = 0;
                affinity = TypeAffinity.AffinityID.TYPEAFF_0;
                koraeruCause = KoraeruCause.NONE;
                isCritical = false;
                isCriticalByFriendship = false;
                isFixDamage = false;
                isMigawari = false;
            }
			
			public void CopyFrom(RECORD src)
			{
				damage = src.damage;
				pokeID = src.pokeID;
				affinity = src.affinity;
				koraeruCause = src.koraeruCause;
				isCritical = src.isCritical;
				isCriticalByFriendship = src.isCriticalByFriendship;
				isFixDamage = src.isFixDamage;
				isMigawari = src.isMigawari;
			}
		}
	}
}