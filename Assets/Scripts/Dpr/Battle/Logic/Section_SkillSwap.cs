using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_SkillSwap : Section
	{
		public Section_SkillSwap(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description desc)
		{
			BTL_POKEPARAM attacker = desc.attacker;
			PokeSet targets = desc.targets;

			uint count = targets.GetCount();
			for (int i = 0; i < (int)count; i++)
			{
				BTL_POKEPARAM target = targets.Get((uint)i);

				if (checkFail(attacker, target, desc.cause))
				{
					if (desc.needFailMessageDisplay)
					{
						GetServerCommandPutter().Message_WazaFailed();
					}
					continue;
				}

				TokuseiNo atkTokusei = (TokuseiNo)attacker.GetValue(BTL_POKEPARAM.ValueID.BPP_TOKUSEI);
				TokuseiNo tgtTokusei = (TokuseiNo)target.GetValue(BTL_POKEPARAM.ValueID.BPP_TOKUSEI);

				GetServerCommandPutter().ActOp_SkillSwap(attacker.GetID(), target.GetID(), atkTokusei, tgtTokusei);

				StrParam str = new StrParam();
				str.Setup(BtlStrType.BTL_STRTYPE_SET, (ushort)BTL_STRID_SET.SkillSwap);
				str.AddArg(attacker.GetID());
				str.AddArg(target.GetID());
				GetServerCommandPutter().Message(in str);

				afterTokuseiChanged_Event(attacker);
				afterTokuseiChanged_Event(target);
				afterTokuseiChanged_Item(attacker, atkTokusei, tgtTokusei);
				afterTokuseiChanged_Item(target, tgtTokusei, atkTokusei);
			}
		}

		private bool checkFail(BTL_POKEPARAM pAttacker, BTL_POKEPARAM pTarget, TokuseiChangeCause cause)
		{
			TokuseiNo atkTokusei = (TokuseiNo)pAttacker.GetValue(BTL_POKEPARAM.ValueID.BPP_TOKUSEI);
			TokuseiNo tgtTokusei = (TokuseiNo)pTarget.GetValue(BTL_POKEPARAM.ValueID.BPP_TOKUSEI);

			if (tables.CheckSkillSwapFailTokusei(atkTokusei))
				return true;

			if (tables.CheckSkillSwapFailTokusei(tgtTokusei))
				return true;

			return false;
		}

		private void afterTokuseiChanged_Event(BTL_POKEPARAM poke)
		{
			var desc = new Section_AfterTokuseiChanged_Event.Description();
			desc.poke = poke;

			var result = new Section_AfterTokuseiChanged_Event.Result();
			var section = new Section_AfterTokuseiChanged_Event(GetCommonParam());
			section.Execute(result, in desc);
		}

		private void afterTokuseiChanged_Item(BTL_POKEPARAM poke, TokuseiNo prevTokusei, TokuseiNo nextTokusei)
		{
			var desc = new Section_AfterTokuseiChanged_Item.Description();
			desc.poke = poke;
			desc.prevTokusei = prevTokusei;
			desc.nextTokusei = nextTokusei;

			var result = new Section_AfterTokuseiChanged_Item.Result();
			var section = new Section_AfterTokuseiChanged_Item(GetCommonParam());
			section.Execute(result, in desc);
		}

		public class Description
		{
			public BTL_POKEPARAM attacker;
			public PokeSet targets;
			public bool needFailMessageDisplay = true;
			public TokuseiChangeCause cause;
		}

		public class Result { }
	}
}
