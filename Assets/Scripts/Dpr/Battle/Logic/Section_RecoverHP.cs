using Pml;

namespace Dpr.Battle.Logic
{
	public sealed class Section_RecoverHP : Section
	{
		public Section_RecoverHP(in CommonParam commonParam) : base(commonParam) { }
		
		public void Execute(Result result, in Description description)
		{
			result.isRecovered = false;

			BTL_POKEPARAM targetPoke = GetPokeParam(description.targetPokeID);
			if (targetPoke == null || targetPoke.IsDead())
			{
				return;
			}

			if (checkFailBase(targetPoke))
			{
				if (description.isDisplayFailMessage_HPFull)
				{
					StrParam str = new StrParam();
					str.Setup(BtlStrType.BTL_STRTYPE_SET, (ushort)BTL_STRID_SET.HPFull);
					str.AddArg(description.targetPokeID);
					GetServerCommandPutter().Message(in str);
				}
				return;
			}

			if (!description.isSkipFailCheckSP && checkFailSP(targetPoke, description.isDisplayFailMessage_SP))
			{
				return;
			}

			if (description.isDisplayTokuseiWindow)
			{
				GetServerCommandPutter().TokWin_In(description.userPokeID);
			}

			if (description.successMessage.IsEnable())
			{
				GetServerCommandPutter().Message(in description.successMessage);
			}

			recover(targetPoke, description.recoverHP, description.isDisplayRecoverEffect);

			if (description.isDisplayTokuseiWindow)
			{
				GetServerCommandPutter().TokWin_Out(description.userPokeID);
			}

			result.isRecovered = true;
		}

		private bool checkFailBase(BTL_POKEPARAM poke)
		{
			return poke.IsHPFull();
		}

		private bool checkFailSP(BTL_POKEPARAM poke, bool isFailMessageDisplay)
		{
			if (poke.CheckSick(Pml.WazaData.WazaSick.WAZASICK_KAIHUKUHUUJI))
			{
				if (isFailMessageDisplay)
				{
					GetServerCommandPutter().Message_Set(poke, (ushort)BTL_STRID_SET.KaifukuFujiWarn);
				}
				return true;
			}
			return false;
		}

		private void recover(BTL_POKEPARAM poke, ushort recoverHP, bool isEffectEnable)
		{
			if (recoverHP > 0)
			{
				GetServerCommandPutter().SimpleHp(poke, (int)recoverHP, DamageCause.OTHER, PokeID.INVALID, isEffectEnable);
			}
		}

		public class Description
		{
			public byte userPokeID;
			public byte targetPokeID;
			public ushort recoverHP;
			public ushort itemID;
			public bool isDisplayTokuseiWindow;
			public bool isDisplayFailMessage_HPFull;
			public bool isDisplayFailMessage_SP;
			public bool isDisplayRecoverEffect;
			public bool isSkipFailCheckSP;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				userPokeID = PokeID.INVALID;
				targetPokeID = PokeID.INVALID;
				recoverHP = 0;
				itemID = (ushort)ItemNo.DUMMY_DATA;
				isDisplayTokuseiWindow = false;
				isDisplayFailMessage_HPFull = false;
				isDisplayFailMessage_SP = true;
				isDisplayRecoverEffect = true;
				isSkipFailCheckSP = false;
			}
		}

		public class Result
		{
			public bool isRecovered;
		}
	}
}