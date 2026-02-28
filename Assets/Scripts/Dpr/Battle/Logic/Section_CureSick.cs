using Pml;
using Pml.WazaData;

namespace Dpr.Battle.Logic
{
	public sealed class Section_CureSick : Section
	{
		public Section_CureSick(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result result, in Description desc) { }
		
		// TODO
		private WazaSick transCureSick(BTL_POKEPARAM poke, ref WazaSickEx exCode) { return default; }
		
		// TODO
		private bool checkKodawariSick(BTL_POKEPARAM poke, WazaSick sick) { return default; }
		
		private void putSpecialMessage(in StrParam strParam)
		{
			var uVar1 = strParam.IsEnable();
			if ((uVar1 & 1) != 0) {
			  this.m_pServerCmdPutter.Message(strParam);
			}
		}
		
		// TODO
		private void putStandardMessage(WazaSick sick, in BTL_SICKCONT sickCont, BTL_POKEPARAM poke, ushort itemID) { }
		
		// TODO
		private void checkItemReaction(BTL_POKEPARAM poke) { }

		public class Description
		{
			public byte pokeID;
			public WazaSickEx sick;
			public byte[] targetPokeID;
			public byte targetPokeCount;
			public ushort itemID;
			public bool isDisplayTokuseiWindow;
			public bool isStandardMessageDisable;
			public StrParam successSpMessage;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				sick = WazaSickEx.POKEFULL;
				targetPokeCount = 0;
				itemID = (ushort)ItemNo.DUMMY_DATA;
				isDisplayTokuseiWindow = false;
				isStandardMessageDisable = false;
			}
		}

		public class Result
		{
			public bool isCured;
			public bool[] isPokeCured = new bool[DefineConstants.BTL_PARTY_MEMBER_MAX * (int)BtlSide.BTL_SIDE_NUM]; // TODO: Are these the right constants?
		}
	}
}