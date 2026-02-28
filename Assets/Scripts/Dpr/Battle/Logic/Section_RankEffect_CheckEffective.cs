using Pml;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_RankEffect_CheckEffective : Section
	{
		public Section_RankEffect_CheckEffective(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool checkFail_GWall(BTL_POKEPARAM attacker, BTL_POKEPARAM target) { return default; }
		
		// TODO
		private bool isInvalidByLimit(BTL_POKEPARAM target, WazaRankEffect effect, int volume) { return default; }
		
		private void putFailMessage_GWall(BTL_POKEPARAM target)
		{
			var uVar1 = target.GetID();
			this.m_pServerCmdPutter.Message_Std(0x17b,uVar1);
		}
		
		// TODO
		private void putFailMessage_Limit(BTL_POKEPARAM target, WazaRankEffect effect, int volume) { }
		
		private void putFailMessage_Migawari(BTL_POKEPARAM target)
		{
			this.m_pServerCmdPutter.Message_Set(target,0x120)
			;
		}

		public class Description
		{
			public byte attackerID;
			public byte targetID;
			public WazaRankEffect effect;
			public int volume;
			public RankEffectCause cause;
			public ushort itemID;
			public uint rankEffSerial;
			public bool canPutFailMessage;
			public bool canMigawariThrew;
			public SimpleEffectFailManager pSimpleEffectFailManager;
			
			public Description()
			{
				pSimpleEffectFailManager = null;
				attackerID = PokeID.INVALID;
				targetID = PokeID.INVALID;
				effect = WazaRankEffect.NONE;
				volume = 0;
				cause = RankEffectCause.OTHER;
				itemID = (ushort)ItemNo.DUMMY_DATA;
				rankEffSerial = 0;
				canPutFailMessage = false;
				canMigawariThrew = false;
			}
		}

		public class Result
		{
			public bool isValid;
		}
	}
}