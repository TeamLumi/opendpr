namespace Dpr.Battle.Logic
{
	public sealed class Section_RecordWazaDamage : Section
	{
		public Section_RecordWazaDamage(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result pResult, in Description description)
		{
			for (byte i = 0; i < description.damageTargetNum; i++)
			{
				BTL_POKEPARAM defender = description.damageProcParams.bpp[i];
				if (defender == null)
					continue;

				ushort damage = description.damageProcParams.dmg[i];
				addWazaDamageRecord(description.attackerPos, description.attacker, defender, description.wazaParam, damage);
			}
		}

		private void addWazaDamageRecord(BtlPokePos attackerPos, BTL_POKEPARAM attacker, BTL_POKEPARAM defender, WazaParam wazaParam, ushort damage)
		{
			BTL_POKEPARAM.WAZADMG_REC rec = new BTL_POKEPARAM.WAZADMG_REC();
			rec.wazaID = (ushort)wazaParam.wazaID;
			rec.damage = damage;
			rec.damageType = wazaParam.damageType;
			rec.wazaType = wazaParam.wazaType;
			rec.pokeID = attacker.GetID();
			rec.pokePos = attackerPos;
			defender.WAZADMGREC_Add(rec);

			GetServerCommandPutter().AddWazaDamageRecord(
				defender, attacker,
				attackerPos,
				wazaParam.wazaType,
				wazaParam.damageType,
				(ushort)wazaParam.wazaID,
				damage);
		}

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public BtlPokePos attackerPos;
			public WazaParam wazaParam;
			public byte damageTargetNum;
			public DamageProcParams damageProcParams;
			public PokeSet damagedPokeSet;
			
			public Description()
			{
				attacker = null;
				attackerPos = BtlPokePos.POS_NULL;
				wazaParam = null;
				damageTargetNum = 0;
				damageProcParams = null;
				damagedPokeSet = null;
			}
		}

		public class Result { }
	}
}