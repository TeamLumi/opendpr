using AK;
using Audio;
using DPData.MysteryGift;
using Dpr.Box;
using Dpr.Demo;
using Dpr.Message;
using Dpr.MsgWindow;
using Dpr.NetworkUtils;
using GameData;
using Pml;
using Pml.PokePara;
using poketool.poke_memo;
using SmartPoint.AssetAssistant;
using SmartPoint.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.UI
{
	public class GiftListWindow : GiftSubWindow
	{
		private static readonly Vector2 MsgWindowAnchorPos = new Vector2(0.0f, 100.0f);

		[SerializeField]
		private UIScrollView scrollView;
		[SerializeField]
		private Cursor cursor;
		private List<GiftListItemInfo> giftListItemInfoList;
		private GiftCompleteWindow completeWindow;
		private GiftErrorWindow errorWindow;
		private int selectIndex;
		private bool isShowComplete;
		private bool isShowError;
		private bool isSerialUsed;
		private GiftNetworkController networkController;
		
		public bool IsNoItem { get; private set; }
		
		protected override void OnAddContextMenuYesNoItemParams(List<ContextMenuItem.Param> contextMenuItemParams)
		{
			contextMenuItemParams.Add(new ContextMenuItem.Param() { menuId = ContextMenuID.GIFT_YES });
			contextMenuItemParams.Add(new ContextMenuItem.Param() { menuId = ContextMenuID.GIFT_NO });
		}
		
		protected override void OnDestroy()
		{
			base.OnDestroy();

			if (giftListItemInfoList != null)
			{
				giftListItemInfoList.Clear();
				giftListItemInfoList = null;
			}
		}
		
		protected override void OnInitialize()
		{
			scrollView.Initialize(OnRequiredItemData, OnSelectItemScrollViewItem, OnUnSelectItemScrollViewItem);
		}
		
		public override void OnUpdate(float deltaTime)
		{
			if (isShowComplete)
			{
				completeWindow.OnUpdate(deltaTime);
				return;
			}
			else if (isShowError)
			{
				errorWindow.OnUpdate(deltaTime);
				return;
			}

			if (_input.IsRepeatButton(UIManager.StickLUp))
			{
				if (scrollView.MoveSelect(-1))
				{
					AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_SELECT, null);
				}
			}
			else if (_input.IsRepeatButton(UIManager.StickLDown))
            {
                if (scrollView.MoveSelect(1))
                {
                    AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_SELECT, null);
                }
            }
			else
			{
                if (_input.IsReleaseButton(UIManager.StickLUp))
                {
                    scrollView.ResumeMoveSelect();
                }
                else if (_input.IsRepeatButton(UIManager.StickLDown))
                {
                    scrollView.ResumeMoveSelect();
                }

                if (_input.IsPushButton(UIManager.ButtonA))
                {
					CloseMessageWindow();
					Sequencer.Start(ReceiveGift(selectIndex));
                    AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_DECIDE, null);
                }
                else if (_input.IsPushButton(UIManager.ButtonB))
                {
					CloseWindow();
                    AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_CANCEL, null);
                }
            }
        }
		
		public override void Show()
		{
			completeWindow.Hide();
			isShowComplete = false;
			errorWindow.Hide();
			isShowError = false;
			IsNoItem = giftListItemInfoList.Count == 0;

			if (giftListItemInfoList.Count != 0)
			{
				gameObject.SetActive(true);
				ShowListMessage();
				SetupKeyguide(new KeyguideID[] { KeyguideID.GIFT_DECIDE, KeyguideID.GIFT_CANCEL });
			}
			else
			{
				onClosed?.Invoke(this);
			}
		}
		
		public void Setup(GiftListItemInfo[] giftListItemInfos, GiftNetworkController networkController, GiftCompleteWindow completeWindow, GiftErrorWindow errorWindow, bool isSerialUsed)
		{
			this.networkController = networkController;
			this.completeWindow = completeWindow;
			this.errorWindow = errorWindow;
			this.isSerialUsed = isSerialUsed;

			giftListItemInfoList = new List<GiftListItemInfo>();

			if (giftListItemInfos != null)
				giftListItemInfoList.AddRange(giftListItemInfos);

			selectIndex = 0;

			RefreshScrollView();
		}
		
		private void OnRequiredItemData(IUIButton button)
		{
			var giftButton = button as GiftListItemButton;

			if (giftButton == null)
				return;

			giftButton.Set(giftListItemInfoList[giftButton.GetIndex()].RecvData);
		}
		
		private void OnSelectItemScrollViewItem(IUIButton button)
		{
			button.Select();
			selectIndex = button.GetIndex();
			cursor.transform.SetParent(button.GetRectTransform(), false);
        }
		
		private void OnUnSelectItemScrollViewItem(IUIButton button)
		{
			button.UnSelect();
		}
		
		private void RefreshScrollView()
		{
			for (int i=giftListItemInfoList.Count-1; i>=0; i--)
			{
				if (giftListItemInfoList[i].CanReceive() == CanReceiveResult.NG)
					giftListItemInfoList.RemoveAt(i);
            }

			IsNoItem = giftListItemInfoList.Count == 0;
			if (IsNoItem)
				return;

			scrollView.Setup(giftListItemInfoList.Count, selectIndex);
        }
		
		private void ShowListMessage()
		{
			OpenMessageWindow(new MsgWindowParam()
			{
				useMsgFile = MessageManager.Instance.GetMsgFile(NetworkConstants.NET_COMM_MSBT_NAME),
				labelName = "SS_net_mystery_014",
				inputCloseEnabled = false,
				wndAnchorPos = MsgWindowAnchorPos,
            });
		}
		
		private void CloseWindow()
		{
			_input.inputEnabled = false;

            OpenMessageWindow(new MsgWindowParam()
            {
                useMsgFile = MessageManager.Instance.GetMsgFile(NetworkConstants.NET_COMM_MSBT_NAME),
                labelName = "SS_net_mystery_015",
                inputCloseEnabled = false,
                wndAnchorPos = MsgWindowAnchorPos,
				onFinishedShowAllMessage = () => CreateContextMenuYesNo(contextMenuItem =>
				{
					CloseMessageWindow();

					if (contextMenuItem.param.menuId == ContextMenuID.GIFT_YES)
						onClosed?.Invoke(null);
					else
						ShowListMessage();

					_input.inputEnabled = true;
					return true;
				}, 0),
            });
        }
		
		private void ShowErrorWindow(string labelName)
		{
			errorWindow.Setup(labelName);
			onClosed = __ => Show();
			errorWindow.Show();
			isShowError = true;
		}
		
		private IEnumerator ReceiveGift(int selectIndex)
		{
			var isWait = true;
			var info = giftListItemInfoList[selectIndex];

			switch (info.CanReceive())
			{
				case CanReceiveResult.NG:
					ShowErrorWindow("SS_net_mystery_016");
					yield break;

                case CanReceiveResult.NG_Today:
                    ShowErrorWindow("SS_net_mystery_038");
                    yield break;

                case CanReceiveResult.NG_TodayFull:
                    ShowErrorWindow("SS_net_mystery_039");
                    yield break;
            }

			var giftData = info.GiftData;
			var giftDataType = (DPData.MysteryGift.DataType)giftData.commonData.dataType;

			if (giftDataType == DPData.MysteryGift.DataType.Monster && PlayerWork.playerParty.IsFull() && BoxPokemonWork.GetSpaceCountAll() == 0)
			{
                ShowErrorWindow("SS_net_mystery_017");
                yield break;
            }

			_input.inputEnabled = false;

			OpenMessageWindow(new MsgWindowParam()
            {
                useMsgFile = MessageManager.Instance.GetMsgFile(NetworkConstants.NET_COMM_MSBT_NAME),
                labelName = "SS_net_mystery_018",
                inputCloseEnabled = false,
                wndAnchorPos = MsgWindowAnchorPos,
            });

			yield return null;

			if (isSerialUsed)
			{
				isWait = true;
				var isSuccessUpdate = false;

				networkController.UpdateSerialCodeUsed(isSuccess =>
				{
					isWait = false;
					isSuccessUpdate = isSuccess;
				});

				while (isWait)
					yield return null;

				if (!isSuccessUpdate)
				{
					Show();
					_input.inputEnabled = true;
					yield break;
				}
			}

            string msgLabelName = null;
            var demoModel = new Demo_MysteryGift();
			uint money = 0;
			uint itemCount = 0;
			ushort itemID = 0;
			uint dressID = 0;
			ushort ugItemID = 0;

            switch (giftDataType)
            {
				case DPData.MysteryGift.DataType.Monster:
					var mon = MysteryGiftWork.CreatePokemonParam(giftData.pokemonData);
					var catalog = DataManager.GetPokemonCatalog(mon.GetMonsNo(), mon.GetFormNo(), mon.GetSex(), mon.IsRare(), mon.IsEgg(EggCheckType.BOTH_EGG));
					if (catalog == null)
                    {
                        _input.inputEnabled = true;
						CloseMessageWindow();
						RefreshScrollView();
						ShowErrorWindow("SS_net_mystery_011");
                        yield break;
                    }

					if (mon.IsEgg(EggCheckType.BOTH_EGG))
						poketool_poke_memo.SetFromEggTaken(mon, PlayerWork.playerStatus, mon.GetMemories(Memories.FIRST_CONTACT_PLACE));
					else
						poketool_poke_memo.SetFromDistribution(mon, mon.GetMemories(Memories.FIRST_CONTACT_PLACE), (uint)(GameManager.nowTime.Year % 100), (uint)GameManager.nowTime.Month, (uint)GameManager.nowTime.Day);

					demoModel.isGetMons = ZukanWork.IsGet((uint)mon.GetMonsNo());

                    if (!mon.IsEgg(EggCheckType.BOTH_EGG))
					{
						ZukanWork.SetPoke(mon, DPData.GET_STATUS.GET);
						FieldPoketch.AddPokemonHistory(mon);
					}

					if (PlayerWork.playerParty.IsFull())
					{
						int tray = 0;
						BoxPokemonWork.PutPokemonEmptyTrayAll(mon, ref tray, out _);
						msgLabelName = "SS_net_mystery_024";
                    }
					else
					{
						PlayerWork.playerParty.AddMember(mon);
                        msgLabelName = "SS_net_mystery_025";
                    }

					demoModel.gift_Pokemon = mon;
					break;

				case DPData.MysteryGift.DataType.Items:
					for (int i=0; i<giftData.itemData.itemInfos.Length; i++)
					{
						var itemInfo = giftData.itemData.itemInfos[i];
                        if (itemInfo.itemNo != (ushort)ItemNo.DUMMY_DATA)
						{
							ItemWork.AddItem(itemInfo.itemNo, itemInfo.num);
							itemCount++;
							MysteryGiftWork.ReceiveItemGift(itemInfo.itemNo);
						}
					}
					itemID = giftData.itemData.itemInfos[0].itemNo;
                    break;

				case DPData.MysteryGift.DataType.DressUp:
					var dressIDs = PlayerWork.playerSex ? giftData.dressUpData.maleDressIds : giftData.dressUpData.femaleDressIds;
					for (int i=0; i<dressIDs.Length; i++)
						MysteryGiftWork.ReceiveDressUpItemGift(dressIDs[i]);
					dressID = dressIDs[0];
                    break;

				case DPData.MysteryGift.DataType.Money:
					MoneyWork.Add((int)giftData.moneyData);
					money = giftData.moneyData;
                    break;

				case DPData.MysteryGift.DataType.UnderGroundItem:
					for (int i=0; i<giftData.underGroundItemData.itemInfos.Length; i++)
					{
						var ugItemInfo = giftData.underGroundItemData.itemInfos[i];
                        if (ugItemInfo.itemNo != 0)
							UgItemWork.AddUgItem(ugItemInfo.itemNo, ugItemInfo.num);
					}
					ugItemID = giftData.underGroundItemData.itemInfos[0].itemNo;
                    break;

				default:
					_input.inputEnabled = true;
					CloseMessageWindow();
					RefreshScrollView();
					ShowErrorWindow("SS_net_mystery_011");
					yield break;
            }

			var recvData = info.RecvData;

			MysteryGiftWork.GetGameServerTime(out giftData.commonData.timestamp);
			recvData.timestamp = giftData.commonData.timestamp;

			MysteryGiftWork.SetReceiveFlag(giftData);
			MysteryGiftWork.AddRecvData(recvData);

			if (isSerialUsed)
				PlayReportManager.SaveReportLog_FushigiSerial(recvData.deliveryId, recvData.monsData.no, recvData.monsData.form, itemID, itemCount, dressID, ugItemID, 0, money, 0);
			else
				PlayReportManager.SaveReportLog_FushigiNet(recvData.deliveryId, recvData.monsData.no, recvData.monsData.form, itemID, itemCount, dressID, ugItemID, 0, money, 0);

			PlayerWork.SaveAsync(true, true);

			while (PlayerWork.IsSaveSystemBusy())
				yield return null;

			CloseMessageWindow();
			Hide();
			Fader.FadeOut();

			while (Fader.fadeOutProgress < 1.0f)
				yield return null;

			isWait = true;

			demoModel.OnEndDemo = () => isWait = false;
			FieldCanvas.PlayDemoOrStock(demoModel);

			while (isWait)
				yield return null;

			AudioManager.Instance.PostEvent(EVENTS.B_OTH007);

			completeWindow.Setup(recvData);
			completeWindow.onClosed = __ =>
			{
				_input.inputEnabled = true;
				RefreshScrollView();
				if (IsNoItem)
					onClosed.Invoke(null);
				else
					Show();
			};

			completeWindow.SetInputEnable(false);
			completeWindow.Show();

			isShowComplete = true;

			Fader.FadeIn();

            while (Fader.fadeInProgress < 1.0f)
                yield return null;

			yield return null;

			if (!string.IsNullOrEmpty(msgLabelName))
				completeWindow.ShowMessage(msgLabelName);

			completeWindow.SetInputEnable(true);
        }
	}
}