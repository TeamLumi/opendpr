namespace Dpr.Battle.Logic
{
	public sealed class Section_SideEffect_Swap : Section
	{
		public Section_SideEffect_Swap(in CommonParam commonParam) : base(commonParam) { }

        public void Execute(Result result, in Description description)
        {
            result.isChanged = false;
            for (int i = (int)BtlSideEffect.BTL_SIDEEFF_START; i < (int)BtlSideEffect.BTL_SIDEEFF_MAX; i++)
            {
                BtlSideEffect effect = (BtlSideEffect)i;
                if (description.checkFunc != null && !description.checkFunc(effect))
                {
                    continue;
                }
                if (GetServerCommandPutter().SideEffect_Swap(description.side1, description.side2, effect))
                {
                    result.isChanged = true;
                }
            }
        }

		public delegate bool SidefEffectSwapCheck(BtlSideEffect effect);

		public class Description
		{
			public BtlSide side1;
			public BtlSide side2;
			public SidefEffectSwapCheck checkFunc;
			
			public Description()
			{
				checkFunc = null;
				side1 = BtlSide.BTL_SIDE_NUM;
				side2 = BtlSide.BTL_SIDE_NUM;
			}
		}

		public class Result
		{
			public bool isChanged;
		}
	}
}