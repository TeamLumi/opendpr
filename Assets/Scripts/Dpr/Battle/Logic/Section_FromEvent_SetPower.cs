namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_SetPower : Section
	{
		public Section_FromEvent_SetPower(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			result.isSuccessed = false;
			ServerCommandPutter scp = GetServerCommandPutter();
			if (description.isAttackEnable)
			{
				scp.SetBaseStatus(description.pokeID, BTL_POKEPARAM.ValueID.BPP_ATTACK, description.attack);
				result.isSuccessed = true;
			}
			if (description.isDefenceEnable)
			{
				scp.SetBaseStatus(description.pokeID, BTL_POKEPARAM.ValueID.BPP_DEFENCE, description.defence);
				result.isSuccessed = true;
			}
			if (description.isSpAttackEnable)
			{
				scp.SetBaseStatus(description.pokeID, BTL_POKEPARAM.ValueID.BPP_SP_ATTACK, description.spAttack);
				result.isSuccessed = true;
			}
			if (description.isSpDefenceEnable)
			{
				scp.SetBaseStatus(description.pokeID, BTL_POKEPARAM.ValueID.BPP_SP_DEFENCE, description.spDefence);
				result.isSuccessed = true;
			}
			if (description.isAgilityEnable)
			{
				scp.SetBaseStatus(description.pokeID, BTL_POKEPARAM.ValueID.BPP_AGILITY, description.agility);
				result.isSuccessed = true;
			}
			if (result.isSuccessed)
			{
				scp.Message(in description.successMessage);
			}
		}

		public class Description
		{
			public byte pokeID;
			public ushort attack;
			public ushort defence;
			public ushort spAttack;
			public ushort spDefence;
			public ushort agility;
			public bool isAttackEnable;
			public bool isDefenceEnable;
			public bool isSpAttackEnable;
			public bool isSpDefenceEnable;
			public bool isAgilityEnable;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				attack = 0;
				defence = 0;
				spAttack = 0;
				spDefence = 0;
				agility = 0;
				isAttackEnable = false;
				isDefenceEnable = false;
				isSpAttackEnable = false;
				isSpDefenceEnable = false;
				isAgilityEnable = false;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}