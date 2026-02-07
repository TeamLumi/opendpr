using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_DelayWazaDamage : Section
	{
		public Section_FromEvent_DelayWazaDamage(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			result.isSucceeded = false;

			BTL_POKEPARAM attacker = GetPokeParam(description.attackerPokeID);
			BTL_POKEPARAM target = GetPokeParam(description.targetPokeID);

			if (attacker.IsDead())
			{
				return;
			}

			if (target.IsDead())
			{
				return;
			}

			WazaParam wazaParam = new WazaParam();
			GetEventLauncher().Event_GetWazaParam(description.wazaID, description.wazaID, WazaNo.NULL, 0, attacker, wazaParam);

			ActionDesc actionDesc = new ActionDesc();
			ActionDesc.Clear(actionDesc);

			PokeSet targets = new PokeSet();
			targets.Add(target);

			DmgAffRec affinityRecorder = new DmgAffRec();

			if (checkWazaInvalid(affinityRecorder, attacker, wazaParam, actionDesc, targets))
			{
				return;
			}

			damageWaza(attacker, wazaParam, affinityRecorder, targets, actionDesc);
			result.isSucceeded = true;
		}

		private bool checkWazaInvalid(DmgAffRec pAffinityRecorder, BTL_POKEPARAM pAttacker, WazaParam pWazaParam, ActionDesc actionDesc, PokeSet pTaragets)
		{
			Section_CheckTypeAffinity section = new Section_CheckTypeAffinity(GetCommonParam());
			Section_CheckTypeAffinity.Description desc = new Section_CheckTypeAffinity.Description();
			Section_CheckTypeAffinity.Result res = new Section_CheckTypeAffinity.Result();

			desc.attacker = pAttacker;
			desc.wazaParam = pWazaParam;
			desc.targets = pTaragets;
			desc.affinityRecorder = pAffinityRecorder;

			section.Execute(res, desc);

			return pTaragets.GetCount() == 0;
		}

		private void damageWaza(BTL_POKEPARAM attacker, WazaParam wazaParam, DmgAffRec affinityRecorder, PokeSet targets, ActionDesc actionDesc)
		{
			Section_FightDamage_Root section = new Section_FightDamage_Root(GetCommonParam());
			Section_FightDamage_Root.Description desc = new Section_FightDamage_Root.Description();
			Section_FightDamage_Root.Result res = new Section_FightDamage_Root.Result();

			desc.pAttacker = attacker;
			desc.pWazaParam = wazaParam;
			desc.pDmgAffRec = affinityRecorder;
			desc.pTargets = targets;
			desc.pActionDesc = actionDesc;
			desc.isDelayAttack = true;

			section.Execute(res, desc);
		}

		public class Description
		{
			public byte attackerPokeID;
			public byte targetPokeID;
			public BtlPokePos attackerPos;
			public WazaNo wazaID;
			
			public Description()
			{
				attackerPokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
				attackerPos = BtlPokePos.POS_NULL;
				wazaID = WazaNo.NULL;
			}
		}

		public class Result
		{
			public bool isSucceeded;
		}
	}
}