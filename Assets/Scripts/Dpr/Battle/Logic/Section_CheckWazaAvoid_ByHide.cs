using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_CheckWazaAvoid_ByHide : Section
	{
		public Section_CheckWazaAvoid_ByHide(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result pResult, in Description description)
        {
            PokeSet targets = description.targets;
            BTL_POKEPARAM attacker = description.attacker;
            WazaNo waza = description.wazaParam.wazaID;

            uint count = targets.GetCount();
            for (uint i = 0; i < count; i++)
            {
                BTL_POKEPARAM target = targets.Get(i);
                if (target.IsDead())
                    continue;
                if (!target.IsWazaHide())
                    continue;

                bool bEnableAvoidMsg = true;
                bool isAvoided = GetEventLauncher().Event_CheckPokeHideAvoid(attacker, target, waza, ref bEnableAvoidMsg);
                if (isAvoided)
                {
                    targets.Remove(target);
                    i--;
                    count--;
                }
            }
        }

		public class Description
		{
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			public PokeSet targets;
			
			public Description()
			{
				wazaParam = null;
				attacker = null;
				targets = null;
			}
		}

		public class Result { }
	}
}