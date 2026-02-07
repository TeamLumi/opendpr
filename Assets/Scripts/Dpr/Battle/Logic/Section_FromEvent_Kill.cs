using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_Kill : Section
	{
		public Section_FromEvent_Kill(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			result.isKilled = false;

			BTL_POKEPARAM target = GetPokeParam(description.targetPokeID);

			if (!description.isDeadPokeEnable && target.IsDead())
			{
				return;
			}

			if (description.message.IsEnable())
			{
				GetServerCommandPutter().Message(description.message);
			}

			PGLRecord.RecParam pglParam = null;
			if (description.userPokeID != PokeID.INVALID)
			{
				BTL_POKEPARAM attacker = GetPokeParam(description.userPokeID);
				pglParam = new PGLRecord.RecParam(attacker, description.recordWazaID);
			}

			bool doDeadProcess = !description.isDisableDeadProcess;
			kill(target, description.userPokeID, description.deadCause, pglParam, doDeadProcess);
			result.isKilled = true;
		}

		private void kill(BTL_POKEPARAM target, byte attackerID, DamageCause deadCause, PGLRecord.RecParam pPglParam, bool doDeadProcess)
		{
			GetServerCommandPutter().HpZero(target);

			if (doDeadProcess)
			{
				Section_CheckPokeDead section = new Section_CheckPokeDead(GetCommonParam());
				Section_CheckPokeDead.Description desc = new Section_CheckPokeDead.Description();
				Section_CheckPokeDead.Result res = new Section_CheckPokeDead.Result();

				desc.poke = target;
				desc.pPglParam = pPglParam;
				desc.isDeadMessageDisplay = true;

				section.Execute(res, desc);
			}
		}

		public class Description
		{
			public byte userPokeID;
			public byte targetPokeID;
			public bool isDeadPokeEnable;
			public bool isDisableDeadProcess;
			public WazaNo recordWazaID;
			public DamageCause deadCause;
			public StrParam message = new StrParam();
			
			public Description()
			{
				userPokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
				isDeadPokeEnable = false;
				isDisableDeadProcess = false;
				recordWazaID = WazaNo.NULL;
				deadCause = DamageCause.OTHER;
			}
		}

		public class Result
		{
			public bool isKilled;
		}
	}
}