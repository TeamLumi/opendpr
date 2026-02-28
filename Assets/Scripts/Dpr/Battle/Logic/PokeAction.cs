using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class PokeAction
    {
        public BTL_POKEPARAM bpp;
        public PokeActionCategory actionCategory;
        public PokeActionParam_Fight actionParam_Fight = new PokeActionParam_Fight();
        public PokeActionParam_Item actionParam_Item = new PokeActionParam_Item();
        public PokeActionParam_PokeChange actionParam_PokeChange = new PokeActionParam_PokeChange();
        public ActionDesc actionDesc = new ActionDesc();
        public uint priority;
        public byte clientID;
        public bool fDone;
        public bool fIntrCheck;
        public bool fRecalcPriority;

        // TODO
        public void CopyFrom(PokeAction src) { }

        // TODO
        public void Clear() { }

        // TODO
        public static void Copy(PokeAction dest, in PokeAction src) { }

        // TODO
        public static void Swap(PokeAction action1, PokeAction action2) { }

        // TODO
        public static void Clear(PokeAction action) { }

        public static WazaNo GetWazaID(PokeAction action)
        {
        	if ((int)action.actionCategory == 1) {
        	  if ((this.actionParam_Fight.forbidGWaza == 0) &&
        	     (((uVar1 = action.bpp.IsGMode(),
        	       (uVar1 & 1) != 0 || (this.actionParam_Fight.gFlag != 0)) ||
        	      (this.actionParam_Fight.forceGWaza != 0)))) {
        	    var uVar1 = GWaza.GetGWaza(this.actionParam_Fight.waza);
        	    return uVar1;
        	  }
        	}
        	else {
        	  this.actionParam_Fight.waza = 0;
        	}
        	return (ulong)this.actionParam_Fight.waza;
        }

        public static bool IsGWazaFight(PokeAction action)
        {
        	if (((int)action.actionCategory != 1) || (this.actionParam_Fight.forbidGWaza != 0)) {
        	  return false;
        	}
        	if (((action.bpp.IsGMode() & 1) == 0) && (this.actionParam_Fight.gFlag == 0)) {
        	  return this.actionParam_Fight.forceGWaza;
        	}
        	return true;
        }

        public static bool IsRaidBossFight(PokeAction action)
        {
        	ulong uVar1 = default;
        	if (((action.bpp != null) &&
        	    (uVar1 = action.bpp.IsRaidBoss(),
        	    (uVar1 & 1) != 0)) && ((int)action.actionCategory == 1)) {
        	  return true;
        	}
        	return false;
        }

        public static bool IsRaidBossGWaza(PokeAction action)
        {
        	if (action.bpp != null) {
        	  var uVar2 = action.bpp.IsRaidBoss();
        	  if ((((uVar2 & 1) != 0) && ((int)action.actionCategory == 1)) &&
        	     (this.actionParam_Fight.forbidGWaza == 0)) {
        	    if ((action.bpp.IsGMode() & 1) != 0) {
        	      return true;
        	    }
        	    if (this.actionParam_Fight.gFlag != 0) {
        	      return true;
        	    }
        	    if (this.actionParam_Fight.forceGWaza != 0) {
        	      return true;
        	    }
        	  }
        	  action.bpp = null;
        	}
        	return action.bpp;
        }
    }
}