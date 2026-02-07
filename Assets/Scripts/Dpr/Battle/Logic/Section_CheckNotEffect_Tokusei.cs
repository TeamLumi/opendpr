namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckNotEffect_Tokusei : Section
	{
		public Section_CheckNotEffect_Tokusei(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result pResult, in Description description)
		{
			checkNoEffect_Tokusei(description.attacker, description.wazaParam, description.affinityRecorder, description.targets);
		}

		private void checkNoEffect_Tokusei(BTL_POKEPARAM attacker, WazaParam wazaParam, DmgAffRec affinityRecorder, PokeSet targets)
		{
			Section_CheckNoEffect_Core.Description desc = new Section_CheckNoEffect_Core.Description();
			Section_CheckNoEffect_Core.Result result = new Section_CheckNoEffect_Core.Result();

			desc.wazaParam = wazaParam;
			desc.attacker = attacker;
			desc.affinityRecorder = affinityRecorder;
			desc.eventID = EventID.NOEFFECT_CHECK_TOKUSEI;
			desc.fEnableMessage = true;

			uint count = targets.GetCount();
			for (int i = 0; i < (int)count; i++)
			{
				BTL_POKEPARAM target = targets.Get((byte)i);
				desc.target = target;
				result.isNoEffect = false;

				Section_CheckNoEffect_Core section = new Section_CheckNoEffect_Core(GetCommonParam());
				section.Execute(result, desc);

				if (result.isNoEffect)
				{
					targets.Remove(target);
					i--;
					count--;
				}
			}
		}

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public WazaParam wazaParam;
			public DmgAffRec affinityRecorder;
			public PokeSet targets;
			public ActionRecorder actionRecorder;
			
			public Description()
			{
				attacker = null;
				wazaParam = null;
				affinityRecorder = null;
				targets = null;
				actionRecorder = null;
			}
		}

		public class Result { }
	}
}