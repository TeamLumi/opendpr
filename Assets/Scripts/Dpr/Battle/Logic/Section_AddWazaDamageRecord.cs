namespace Dpr.Battle.Logic
{
	public sealed class Section_AddWazaDamageRecord : Section
	{
		public Section_AddWazaDamageRecord(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM.WAZADMG_REC rec = new BTL_POKEPARAM.WAZADMG_REC();
			rec.wazaID = (ushort)description.wazaParam.wazaID;
			rec.damage = description.damage;
			rec.damageType = description.wazaParam.damageType;
			rec.wazaType = description.wazaParam.wazaType;
			rec.pokeID = description.attacker.GetID();
			rec.pokePos = description.attackerPos;
			description.defender.WAZADMGREC_Add(rec);

			GetServerCommandPutter().AddWazaDamageRecord(
				description.defender, description.attacker,
				description.attackerPos,
				description.wazaParam.wazaType,
				description.wazaParam.damageType,
				(ushort)description.wazaParam.wazaID,
				description.damage);
		}

		public class Description
		{
			public BTL_POKEPARAM defender;
			public BTL_POKEPARAM attacker;
			public BtlPokePos attackerPos;
			public WazaParam wazaParam;
			public ushort damage;
			
			public Description()
			{
				defender = null;
				attacker = null;
				wazaParam = null;
				attackerPos = BtlPokePos.POS_NULL;
				damage = 0;
			}
		}

		public class Result { }
	}
}