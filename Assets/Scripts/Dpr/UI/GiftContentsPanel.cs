using DPData.MysteryGift;
using Dpr.Message;
using GameData;
using Pml;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using UnityEngine;

namespace Dpr.UI
{
	public class GiftContentsPanel : MonoBehaviour
	{
		private const int TextLineMargin = 26;
		private const string MessageFileName = "ss_net_mystery";

		private static readonly string[] ItemLabelNames = new string[]
		{
            "SS_net_mystery_099", "SS_net_mystery_100", "SS_net_mystery_101", "SS_net_mystery_102",
            "SS_net_mystery_103", "SS_net_mystery_100", "SS_net_mystery_105", "SS_net_mystery_324",
        };
		private static readonly string[] DressUpLabelNames = new string[]
        {
            "",                   "SS_net_mystery_107", "SS_net_mystery_108", "SS_net_mystery_109",
            "SS_net_mystery_110", "SS_net_mystery_111", "SS_net_mystery_112", "SS_net_mystery_326",
        };
        private static readonly string[] UnderGroundItemLabelNames = new string[]
        {
            "SS_net_mystery_314", "SS_net_mystery_315", "SS_net_mystery_316", "SS_net_mystery_317",
            "SS_net_mystery_318", "SS_net_mystery_319", "SS_net_mystery_320", "SS_net_mystery_325",
        };

        [SerializeField]
		private UIText titleText;
		[SerializeField]
		private UIText receiveDateText;
		[SerializeField]
		private UIText contentsText;
		
		public void Setup(RecvData data)
		{
			GiftMessageUtility.SetTitleText(data, new UIText[] { titleText });
			SetReceiveDateText(data.timestamp);

			contentsText.text = null;

			Sequencer.Start(DelaySetup());

            IEnumerator DelaySetup()
			{
				yield return null;

				SetupContentTextLineSpacing();
				SetContentsText(data);
			}
        }
		
		private void SetupContentTextLineSpacing()
		{
			var faceInfo = contentsText.font.faceInfo;

			contentsText.lineSpacing = faceInfo.lineHeight <= faceInfo.pointSize ?
				0.0f :
				TextLineMargin - (faceInfo.lineHeight + (faceInfo.lineHeight - faceInfo.pointSize));
        }
		
		private void SetReceiveDateText(long timestamp)
		{
			if (timestamp == 0)
			{
                receiveDateText.text = null;
				return;
            }

			DateTimeOffset dt;
			TimeSpan offset;

            if (DateTimeOffset.MinValue.ToUnixTimeSeconds() <= timestamp && timestamp <= DateTimeOffset.MaxValue.ToUnixTimeSeconds())
			{
				dt = DateTimeOffset.FromUnixTimeSeconds(timestamp);
				offset = DateTimeOffset.Now.Offset;
				dt = dt.Add(offset);
            }
			else
			{
				dt = DateTimeOffset.FromFileTime(timestamp);
				offset = dt.Offset;
			}

			string label;

			if (offset.Hours == 0)
			{
				label = "SS_net_mystery_093";
            }
			else if (offset.Hours < 1)
			{
				if (offset.Minutes == 0)
					label = "SS_net_mystery_095";
                else
                    label = "SS_net_mystery_092";
            }
			else
			{
                if (offset.Minutes == 0)
                    label = "SS_net_mystery_094";
                else
                    label = "SS_net_mystery_091";
            }

			receiveDateText.SetFormattedText(() =>
			{
				MessageWordSetHelper.SetDigitWord(0, (dt.Year % 100).ToString("D2"));
				MessageWordSetHelper.SetDigitWord(1, dt.Month.ToString("D2"));
				MessageWordSetHelper.SetDigitWord(2, dt.Day.ToString("D2"));
				MessageWordSetHelper.SetDigitWord(3, dt.Hour.ToString("D2"));
				MessageWordSetHelper.SetDigitWord(4, dt.Minute.ToString("D2"));

				var hours = offset.Hours;
				MessageWordSetHelper.SetDigitWord(5, (hours > -1) ? hours : -hours);

                var minutes = offset.Minutes;
                MessageWordSetHelper.SetDigitWord(6, (minutes > -1) ? minutes : -minutes);
			}, MessageFileName, label);
		}
		
		private void SetContentsText(RecvData data)
		{
			switch ((DataType)data.dataType)
			{
				case DataType.Monster:
					if (data.monsData.isEgg != 0)
					{
						contentsText.SetFormattedText(() => { /* Empty */ }, MessageFileName,
							((MonsNo)data.monsData.no == MonsNo.MANAFI) ? "SS_net_mystery_321" : "SS_net_mystery_115");
					}
					else
					{
						MessageWordSetHelper.SetMonsNameWord(5, (MonsNo)data.monsData.no);
						contentsText.SetFormattedText(() => { /* Empty */ }, MessageFileName, "SS_net_mystery_098");
                    }
					break;

				case DataType.Items:
                    bool lastSingularItem = false;
					int totalItems = 0;
                    for (int i=0; i<data.itemDatas.Length; i++)
					{
						var item = data.itemDatas[i];
						if (item.itemNo != (ushort)ItemNo.DUMMY_DATA)
						{
                            lastSingularItem = item.num == 1;
                            MessageWordSetHelper.SetItemWord(5 + i, item.itemNo, item.num);
                            MessageWordSetHelper.SetDigitWord(6 + i, item.num);
							totalItems++;
                        }
					}

					if (totalItems == 1)
					{
                        if (lastSingularItem)
                            contentsText.SetFormattedText(() => { /* Empty */ }, MessageFileName, ItemLabelNames[0]);
                        else
                            contentsText.SetFormattedText(() => { /* Empty */ }, MessageFileName, ItemLabelNames[1]);
                    }
					else if (totalItems >= 2)
					{
						if (totalItems < ItemLabelNames.Length)
                            contentsText.SetFormattedText(() => { /* Empty */ }, MessageFileName, ItemLabelNames[totalItems]);
                    }
					break;

				case DataType.DressUp:
                    int totalDress = 0;
                    for (int i=0; i<data.dressIds.Length; i++)
					{
						var dress = data.dressIds[i];
						if (dress != 0)
						{
							var dressData = DataManager.GetCharacterDressData((int)dress);
                            if (dressData != null)
							{
								MessageWordSetHelper.SetDressupItemNameWord(5 + i, dressData.MSLabel);
                                totalDress++;
                            }
						}
					}

					if (totalDress >= 1)
                    {
                        if (totalDress < ItemLabelNames.Length) // BUG: Wrongly checks the item array instead of dress up
                            contentsText.SetFormattedText(() => { /* Empty */ }, MessageFileName, DressUpLabelNames[totalDress]);
                    }
					break;

				case DataType.Money:
                    MessageWordSetHelper.SetDigitWord(5, (int)data.moneyData);
                    contentsText.SetFormattedText(() => { /* Empty */ }, MessageFileName, "SS_net_mystery_114");
                    break;

				case DataType.UnderGroundItem:
					bool lastSingularUg = false;
					int totalUgItems = 0;
                    for (int i=0; i<data.itemDatas.Length; i++)
					{
						var item = data.itemDatas[i];
						if (item.itemNo != (ushort)ItemNo.DUMMY_DATA)
						{
                            lastSingularUg = item.num == 1;
                            MessageWordSetHelper.SetUgItemNameWord(5 + i, item.itemNo, item.num);
                            MessageWordSetHelper.SetDigitWord(6 + i, item.num);
                            totalUgItems++;
                        }
					}

					if (totalUgItems == 1)
					{
                        if (lastSingularUg)
                            contentsText.SetFormattedText(() => { /* Empty */ }, MessageFileName, UnderGroundItemLabelNames[0]);
                        else
                            contentsText.SetFormattedText(() => { /* Empty */ }, MessageFileName, UnderGroundItemLabelNames[1]);
                    }
					else if (totalUgItems >= 2)
					{
						if (totalUgItems < ItemLabelNames.Length) // BUG: Wrongly checks the item array instead of underground
                            contentsText.SetFormattedText(() => { /* Empty */ }, MessageFileName, UnderGroundItemLabelNames[totalUgItems]);
                    }
					break;
			}
		}
	}
}