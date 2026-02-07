namespace Dpr.Battle.Logic
{
	public sealed class Section_Kill : Section
	{
		public Section_Kill(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM target = description.target;

			target.SetDeadCause(description.deadCause, description.attackerID);

			GetServerCommandPutter().KillPokemon(target, description.attackerID, description.deadCause, 0);

			if (description.doDeadProcess)
			{
				deadProcess(target, description.pPglParam);
			}
		}

		private void deadProcess(BTL_POKEPARAM target, PGLRecord.RecParam pPglParam)
		{
			byte pokeID = target.GetID();

			GetEventLauncher().Event_BeforeDead(target);

			GetServerCommandPutter().ClearForDead(pokeID);

			GetServerCommandPutter().Act_Dead(pokeID, false);

			GetBattleEnv().GetDeadRec().Add(pokeID);

			GetEventLauncher().Event_PokeDeadAfter(pokeID);
		}

		public class Description
		{
			public BTL_POKEPARAM target;
			public byte attackerID;
			public DamageCause deadCause;
			public PGLRecord.RecParam pPglParam;
			public bool doDeadProcess;

			public Description()
			{
				target = null;
				pPglParam = null;
				attackerID = PokeID.INVALID;
				deadCause = DamageCause.OTHER;
				doDeadProcess = false;
			}
		}

		public class Result { }
	}
}
