using DPData.MysteryGift;
using Dpr.Message;
using GameData;
using Pml;
using UnityEngine.Events;

namespace Dpr.UI
{
	public static class GiftMessageUtility
	{
		private const string MessageFileName = "ss_net_mystery_card";
		private const string PokemonTypeMessageFileName = "ss_zkn_type";
		private const string PokemonFormMessageFileName = "ss_zkn_form";

		private const int MonsNameTagIndex = 0;
		private const int PokemonTypeTagIndex = 1;
		private const int FormNameTagIndex = 2;
		private const int ParentNameTagIndex = 3;
		private const int Waza1TagIndex = 4;
		private const int Waza2TagIndex = 5;
		private const int Waza3TagIndex = 6;
		private const int Waza4TagIndex = 7;
		private const int ItemTagIndex = 8;
		private const int PokemonHaveItemTagIndex = 9;
		private const int SeasonTagIndex = 10;
		private const int AnotherNameAndPokemonTypeTagIndex = 11;
		private const int MoneyTagIndex = 12;
		private const int UnderGroundItemTagIndex = 13;
		
		public static bool IsValidMessageLabel(RecvData recvData)
		{
			var label = string.Format("SS_net_mystery_card_{0:D2}", recvData.textId + 1);

			return MessageManager.Instance.GetMsgFile(MessageFileName, MessageManager.Instance.UserLanguageID).GetLabelIndex(label) != -1;
		}
		
		public static void SetTitleText(RecvData recvData, UIText[] uiTexts)
        {
            var label = string.Format("SS_net_mystery_card_{0:D2}", recvData.textId + 1);

			UnityAction onSet = () => { /* Empty */ };

			switch ((DataType)recvData.dataType)
			{
				case DataType.Monster:
					onSet = () =>
					{
						MessageWordSetHelper.SetMonsNameWord(MonsNameTagIndex, recvData.monsData.no);
						MessageWordSetHelper.SetStringWord(PokemonTypeTagIndex, MessageManager.Instance.GetSimpleMessage(PokemonTypeMessageFileName, recvData.monsData.no));
						MessageWordSetHelper.SetStringWord(FormNameTagIndex, MessageManager.Instance.GetSimpleMessage(PokemonFormMessageFileName, string.Format("ZKN_FORM_{0:D3}_{1:D3}", recvData.monsData.no, recvData.monsData.form)));
                        MessageWordSetHelper.SetStringWord(ParentNameTagIndex, recvData.monsData.parentName);
                        MessageWordSetHelper.SetWazaNameWord(Waza1TagIndex, (WazaNo)recvData.monsData.wazaNos[0]);
                        MessageWordSetHelper.SetWazaNameWord(Waza2TagIndex, (WazaNo)recvData.monsData.wazaNos[1]);
                        MessageWordSetHelper.SetWazaNameWord(Waza3TagIndex, (WazaNo)recvData.monsData.wazaNos[2]);
                        MessageWordSetHelper.SetWazaNameWord(Waza4TagIndex, (WazaNo)recvData.monsData.wazaNos[3]);
                        MessageWordSetHelper.SetItemWord(PokemonHaveItemTagIndex, recvData.monsData.itemId, 1);
                    };
					break;

                case DataType.Items:
					onSet = () =>
                    {
                        MessageWordSetHelper.SetItemWord(ItemTagIndex, recvData.itemDatas[0].itemNo, recvData.itemDatas[0].num);
                    };
                    break;

                case DataType.DressUp:
					onSet = () =>
					{
                        MessageWordSetHelper.SetDressupItemNameWord(12, DataManager.GetCharacterDressData((int)recvData.dressIds[0]).MSLabel);
                    };
                    break;

                case DataType.Money:
					onSet = () =>
					{
                        MessageWordSetHelper.SetDigitWord(MoneyTagIndex, (int)recvData.moneyData);
                    };
                    break;

				case DataType.UnderGroundItem:
					onSet = () =>
					{
						MessageWordSetHelper.SetUgItemNameWord(UnderGroundItemTagIndex, recvData.itemDatas[0].itemNo, recvData.itemDatas[0].num);
					};
					break;

				default:
					return;
            }

			for (int i=0; i<uiTexts.Length; i++)
				uiTexts[i].SetFormattedText(onSet, MessageFileName, label);
        }
	}
}