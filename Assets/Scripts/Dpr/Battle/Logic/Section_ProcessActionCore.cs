namespace Dpr.Battle.Logic
{
	public sealed class Section_ProcessActionCore : Section
	{
		public Section_ProcessActionCore(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void onLegendDemo_legendPokeAction(BTL_POKEPARAM pActPoke) { }
		
		// TODO
		private bool cantActionByFreeFall(PokeAction pokeAction) { return default; }
		
		// TODO
		private void cancelAction(PokeAction pokeAction) { }
		
		// TODO
		private void reinforceRaidBoss(PokeAction pokeAction) { }
		
		// TODO
		private void putInterruptActionInfo(PokeAction pokeAction) { }
		
		private void event_StartAction(PokeAction pokeAction)
		{
			this.m_pEventLauncher.Event_ActProcStart(pokeAction);
		}
		
		// TODO
		private void action(PokeAction pokeAction) { }
		
		// TODO
		private void action_Fight(PokeAction pokeAction) { }
		
		private void action_Change(PokeAction pokeAction)
		{
			var uVar1 = memberChange();
			afterMemberIn(pokeAction,uVar1);
		}
		
		// TODO
		private byte memberChange(PokeAction pokeAction) { return default; }
		
		// TODO
		private void afterMemberIn(byte inPokeID) { }
		
		// TODO
		private void action_CantAction(PokeAction pokeAction) { }
		
		// TODO
		private bool action_Escape(PokeAction pokeAction) { return default; }
		
		// TODO
		private void action_ItemUse(PokeAction action) { }
		
		// TODO
		private void action_GStart(PokeAction pPokeAction) { }
		
		// TODO
		private void action_Cheer(PokeAction pPokeAction) { }
		
		// TODO
		private void action_RaidBossExtraAction(PokeAction pPokeAction) { }
		
		// TODO
		private void event_EndAction(PokeAction pokeAction) { }

		public class Description
		{
			public PokeAction pokeAction;
			
			public Description()
			{
				pokeAction = null;
			}
		}

		public class Result { }
	}
}