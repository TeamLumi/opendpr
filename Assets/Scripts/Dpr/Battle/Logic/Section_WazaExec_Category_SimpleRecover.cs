using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_Category_SimpleRecover : Section
	{
		public Section_WazaExec_Category_SimpleRecover(in CommonParam commonParam) : base(commonParam) { }

		public void Execute(Result pResult, in Description description)
		{
			BTL_POKEPARAM attacker = description.attacker;
			WazaParam wazaParam = description.wazaParam;
			PokeSet targets = description.targets;
			WazaNo wazano = wazaParam.wazaID;

			uint count = targets.GetCount();
			for (int i = 0; i < (int)count; i++)
			{
				BTL_POKEPARAM target = targets.Get((uint)i);

				if (target.IsDead())
					continue;

				uint volume = calcRecoverVolume(attacker, target, wazano);
				if (volume == 0)
					continue;

				StrParam recoverMsg = new StrParam();
				getRecoverMessage(recoverMsg, attacker, target, wazano);

				recoverHP(target, (ushort)volume, in recoverMsg);
			}
		}

		private uint calcRecoverVolume(BTL_POKEPARAM attacker, BTL_POKEPARAM target, WazaNo wazano)
		{
			uint ratio = WAZADATA.GetHPRecoverRatio(wazano);
			if (ratio == 0)
				return 0;

			uint maxHP = (uint)target.GetValue(BTL_POKEPARAM.ValueID.BPP_MAX_HP);
			uint volume = maxHP * ratio / 100;
			if (volume == 0)
				volume = 1;

			return volume;
		}

		private void getRecoverMessage(StrParam pMessage, BTL_POKEPARAM pAttacker, BTL_POKEPARAM pTarget, WazaNo wazano)
		{
			// Simple recovery moves don't have a specific recovery message —
			// the Section_RecoverHP will handle the default recovery display
		}

		private bool recoverHP(BTL_POKEPARAM target, ushort recoverHP, in StrParam recoverMsg)
		{
			var desc = new Section_RecoverHP.Description();
			desc.userPokeID = target.GetID();
			desc.targetPokeID = target.GetID();
			desc.recoverHP = recoverHP;
			desc.isDisplayRecoverEffect = true;
			desc.isDisplayFailMessage_HPFull = true;
			desc.isDisplayFailMessage_SP = true;

			if (recoverMsg.IsEnable())
			{
				desc.successMessage = recoverMsg;
			}

			var result = new Section_RecoverHP.Result();
			var section = new Section_RecoverHP(GetCommonParam());
			section.Execute(result, in desc);

			return result.isRecovered;
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
