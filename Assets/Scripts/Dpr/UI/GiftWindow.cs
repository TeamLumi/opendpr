using DPData;
using Dpr.Box;
using Dpr.MsgWindow;
using Dpr.NetworkUtils;
using INL1;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class GiftWindow : UIWindow
	{
		private static readonly Vector2 MsgWindowAnchorPos = new Vector2(0.0f, 100.0f);

		[SerializeField]
		private GiftNetworkController networkController;
		[SerializeField]
		private GiftMainMenuWindow mainMenuWindow;
		[SerializeField]
		private GiftSerialCodeWindow serialCodeWindow;
		[SerializeField]
		private GiftDownloadWindow downloadWindow;
		[SerializeField]
		private GiftListWindow listWindow;
		[SerializeField]
		private GiftCompleteWindow completeWindow;
		[SerializeField]
		private GiftHistoryWindow historyWindow;
		[SerializeField]
		private GiftErrorWindow errorWindow;

		private UIMsgWindowController msgWindowController;
		private GiftSubWindow beforeSubWindow;
		private GiftSubWindow currentSubWindow;
		private bool isFirstShowSerialCode;
		private bool isSuccessInternetGo;
		
		public override void OnCreate()
		{
			base.OnCreate();

			_animator = GetComponentInChildren<Animator>(true);

			msgWindowController = new UIMsgWindowController();
            msgWindowController.SetAnchorPosition(MsgWindowAnchorPos);
        }
		
		protected override void OnAddContextMenuYesNoItemParams(List<ContextMenuItem.Param> contextMenuItemParams)
		{
			contextMenuItemParams.Add(new ContextMenuItem.Param() { menuId = ContextMenuID.GIFT_YES });
			contextMenuItemParams.Add(new ContextMenuItem.Param() { menuId = ContextMenuID.GIFT_NO });
		}
		
		public void Open(UIWindowID prevWindowId)
		{
			Sequencer.Start(OpOpen(prevWindowId));
		}
		
		// TODO
		public IEnumerator OpOpen(UIWindowID prevWindowId) { return default; }
		
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId)
		{
            Sequencer.Start(OpClose(onClosed_, prevWindowId));
        }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		private void OnUpdate(float deltaTime)
		{
			if (UIManager.Instance.GetCurrentUIWindow<UIWindow>() != this)
				return;

			if (msgWindowController.isOpen)
			{
				msgWindowController.OnUpdate(deltaTime);
				return;
			}

			if (currentSubWindow == null)
				return;

			if (beforeSubWindow != currentSubWindow)
			{
				beforeSubWindow = currentSubWindow;
                return;
			}

			currentSubWindow.OnUpdate(deltaTime);
        }
		
		private void HideAllSubWindows()
		{
            mainMenuWindow.Hide();
            serialCodeWindow.Hide();
            downloadWindow.Hide();
            listWindow.Hide();
            completeWindow.Hide();
            historyWindow.Hide();
            errorWindow.Hide();
        }
		
		private void ShowMainMenuWindow()
		{
			HideAllSubWindows();
            mainMenuWindow.Hide();

            currentSubWindow = mainMenuWindow;
            mainMenuWindow.Show();
        }
		
		private void ShowSerialCodeWindow(bool isClear)
		{
			if (MysteryGiftWork.IsNgFlagOn())
			{
				ShowErrorWindow("SS_net_mystery_005", __ => ShowMainMenuWindow());
            }
			else
			{
				if (isClear)
					serialCodeWindow.ClearTexts();

                currentSubWindow = serialCodeWindow;
                serialCodeWindow.Show();
            }
		}
		
		// TODO
		private void ShowDownloadWindow(int min, int max) { }
		
		// TODO
		private void ShowListWindow(GiftListItemInfo[] giftListItemInfos, bool isSerial) { }
		
		// TODO
		private void ShowCompleteWindow() { }
		
		// TODO
		private void ShowHistoryWindow() { }
		
		private void ShowErrorWindow(string labelName, UnityAction<UIWindow> onCloseCallback)
		{
			errorWindow.onClosed = onCloseCallback;
            errorWindow.Setup(labelName);
            currentSubWindow = errorWindow;
            errorWindow.Show();
        }
		
		private void OnCloseMainMenuWindow(UIWindow subWindow)
		{
			if (currentSubWindow != null)
			{
				currentSubWindow.Hide();
				currentSubWindow = null;
			}

			var window = subWindow as GiftMainMenuWindow;
			switch (window.SelectedMenuType)
			{
				case GiftMainMenuWindow.MenuType.ReceiveInternet:
					Sequencer.Start(StartReceiveInternet());
					break;

				case GiftMainMenuWindow.MenuType.ReceiveSerialCode:
                    Sequencer.Start(StartReceiveSerialCode());
                    break;

                case GiftMainMenuWindow.MenuType.ShowHistory:
					historyWindow.Setup(MysteryGiftWork.GetRecvDatas());
					currentSubWindow = historyWindow;
					currentSubWindow.Show();
					break;

				default:
					Close(onClosed, _prevWindowId);
					break;
            }
		}
		
		private void OnCloseSerialCodeWindow(UIWindow subWindow)
		{
			if (subWindow == null)
			{
				ShowMainMenuWindow();
				return;
			}

			var serialWindow = subWindow as GiftSerialCodeWindow;
			if (string.IsNullOrEmpty(serialWindow.InputSerialCode))
				return;

			Sequencer.Start(StartAuthenticateSerialCode(serialWindow.InputSerialCode));
		}
		
		// TODO
		private void OnCloseListWindow(UIWindow subWindow) { }
		
		// TODO
		private void OnCloseHistoryWindow(UIWindow subWindow) { }
		
		// TODO
		private IEnumerator StartReceiveInternet() { return default; }
		
		private IEnumerator StartReceiveSerialCode()
		{
			yield return ConnectInternet(isFirstShowSerialCode);

			isFirstShowSerialCode = false;

			if (isSuccessInternetGo)
			{
                yield return null;

				ShowSerialCodeWindow(true);
            }
        }
		
		private IEnumerator ConnectInternet(bool isShowWarningSerialCode)
		{
			var isEnd = false;
			var isWait = false;
			isSuccessInternetGo = false;

			if (PlayerWork.playerParty.IsFull() && BoxPokemonWork.GetSpaceCountAll() == 0)
			{
				isWait = true;
				msgWindowController.OpenMsgWindow(UIMsgWindowController.MessageFileType.MysteryGift, "SS_net_mystery_002", isWait, false, () =>
				{
					MsgWindowManager.OpenYesNoMenu(selectChoice =>
					{
						msgWindowController.CloseMsgWindow();
						isWait = false;

						if (selectChoice != 0)
						{
							ShowMainMenuWindow();
							isEnd = true;
						}
					}, onClosed: null);
				}, null);
			}

			while (isWait)
				yield return null;

			if (isEnd)
				yield break;
			
			if (IlcaNetServer.IsFinalAsyncNeed() != IlcaNetServer.IlcaNetServerFinalAsyncNeedEnum.NeedLogout && isShowWarningSerialCode)
			{
				isWait = true;
				ShowErrorWindow("SS_net_mystery_003", __ => isWait = false);

				while (isWait)
					yield return null;

				currentSubWindow = null;
			}

            while (isWait)
                yield return null;

            if (isEnd)
                yield break;

			isWait = true;

			networkController.CallInternetGo((isSuccess, result) =>
			{
				isWait = false;
				if (!isSuccess)
				{
                    ShowMainMenuWindow();
                    isEnd = true;
                }
			});

			while (isWait)
				yield return null;

            if (isEnd)
                yield break;

			isSuccessInternetGo = true;
		}
		
		private IEnumerator StartAuthenticateSerialCode(string inputCode)
		{
			var isWait = false;
			var isSuccessCheckSerialCode = false;

			msgWindowController.OpenMsgWindow(UIMsgWindowController.MessageFileType.MysteryGift, "SS_net_mystery_007", false, false, null, null);

			isWait = true;

			_input.inputEnabled = false;

			string errorMsgLabelName = null;
			var isReturnTopMenu = false;
			ushort serialDataNo = 0;

			networkController.CheckSerialRequest(inputCode, (resultStatus, dataNo) =>
			{
				msgWindowController.CloseMsgWindow();

				switch (resultStatus)
				{
					case -1:
						isReturnTopMenu = true;
						break;

					case 0:
						serialDataNo = dataNo;
						isSuccessCheckSerialCode = true;
						MysteryGiftWork.ResetNgCount();
						PlayerWork.SaveAsync(true, true);
						break;

					case 11:
						errorMsgLabelName = "SS_net_mystery_044";
						MysteryGiftWork.IncNgCount();
                        PlayerWork.SaveAsync(true, true);
                        break;

					case 12:
						errorMsgLabelName = "SS_net_mystery_046";
                        break;

					case 13:
						errorMsgLabelName = "SS_net_mystery_048";
                        break;

					case 14:
						errorMsgLabelName = "SS_net_mystery_050";
                        break;

					case 15:
						errorMsgLabelName = "SS_net_mystery_052";
                        break;

					case 16:
						errorMsgLabelName = "SS_net_mystery_054";
                        break;

					case 17:
						errorMsgLabelName = "SS_net_mystery_056";
                        break;

					case 18:
						errorMsgLabelName = "SS_net_mystery_058";
                        break;

					case 22:
						errorMsgLabelName = "SS_net_mystery_060";
                        isReturnTopMenu = true;
                        break;

					case 31:
                        isReturnTopMenu = true;
                        NetworkManager.ShowApplicationErrorDialog(ErrorCodeID.ErrorNSATokenAuth, null);
                        break;

                    case 91:
                        isReturnTopMenu = true;
                        NetworkManager.ShowApplicationErrorDialog(ErrorCodeID.ErrorSerialServerMaintenance, null);
                        break;

                    case 92:
                        isReturnTopMenu = true;
                        NetworkManager.ShowApplicationErrorDialog(ErrorCodeID.ErrorSerialServiceEnd, null);
                        break;

                    case 98:
                        isReturnTopMenu = true;
                        NetworkManager.ShowApplicationErrorDialog(ErrorCodeID.ErrorSerialInvalidParameter, null);
                        break;

                    case 99:
                        isReturnTopMenu = true;
                        NetworkManager.ShowApplicationErrorDialog(ErrorCodeID.ErrorSerialUnexpected, null);
                        break;

                    default:
						isReturnTopMenu = true;
						NetworkManager.ShowApplicationErrorDialog(ErrorCodeID.ErrorSerialIntgernal, null);
                        break;
				}

                isWait = false;
            });

			while (isWait)
				yield return null;

			while (PlayerWork.IsSaveSystemBusy())
				yield return null;

			_input.inputEnabled = true;

			if (!isSuccessCheckSerialCode)
			{
				if (!string.IsNullOrEmpty(errorMsgLabelName))
				{
					ShowErrorWindow(errorMsgLabelName, __ =>
					{
						if (isReturnTopMenu)
						{
							ShowMainMenuWindow();
						}
						else
						{
							msgWindowController.OpenMsgWindow(UIMsgWindowController.MessageFileType.MysteryGift, "SS_net_mystery_009", true, false, () =>
							{
                                MsgWindowManager.OpenYesNoMenu(selectChoice =>
								{
									msgWindowController.CloseMsgWindow();
									if (selectChoice != 0)
										ShowMainMenuWindow();
									else
										ShowSerialCodeWindow(false);
								}, onClosed: null);
                            }, null);
						}
					});
				}
				else if (isReturnTopMenu)
                {
					ShowMainMenuWindow();
				}
			}

			if (!isSuccessCheckSerialCode)
				yield break;

			serialCodeWindow.Hide();

			yield return null;

			yield return DownloadList(serialDataNo, true);
        }
		
		private IEnumerator DownloadList(ushort dataNo, bool isSerial)
		{
			msgWindowController.OpenMsgWindow(UIMsgWindowController.MessageFileType.MysteryGift, "SS_net_mystery_010", false, false, null, null);

			var giftItemInfoList = new List<GiftListItemInfo>();
			var progressMaxValue = 100;
			var firstProgressMaxValue = 50;

			downloadWindow.Setup(0, 100);

			currentSubWindow = downloadWindow;
			currentSubWindow.Show();

			yield return null;

			var coroutine = Sequencer.Start(StartProgress(firstProgressMaxValue));
			var isWait = true;
			byte[][] fileDataBytes = null;

			networkController.GetGiftListItemInfos(new ushort[] { dataNo }, datas =>
			{
				fileDataBytes = datas;
				isWait = false;
			});

			while (isWait)
				yield return null;

			Sequencer.Stop(coroutine);
			downloadWindow.SetProgressValue(firstProgressMaxValue);

			yield return null;

			if (fileDataBytes != null && fileDataBytes.Length != 0)
			{
				int step = (fileDataBytes.Length != 0) ? ((progressMaxValue - firstProgressMaxValue) / fileDataBytes.Length) : 0;
				for (int i=0; i<fileDataBytes.Length; i++)
				{
					downloadWindow.Step(step);

					yield return null;

					giftItemInfoList.AddRange(ConvertGiftDatas(fileDataBytes[i]));
				}
			}

			downloadWindow.SetProgressValue(progressMaxValue);

			yield return null;

			downloadWindow.Hide();
			msgWindowController.CloseMsgWindow();
			listWindow.Setup(giftItemInfoList.ToArray(), networkController, completeWindow, errorWindow, isSerial);
			currentSubWindow = listWindow;
			listWindow.Show();
		}
		
		private List<GiftListItemInfo> ConvertGiftDatas(byte[] data)
		{
			var finalList = new List<GiftListItemInfo>();
			var set = new HashSet<uint>();

			var version = PlayerWork.playerStatus.rom_code;
			var newData = new byte[MysteryGiftData.DataSize];

			int sourceIndex = 0;
			while (sourceIndex < data.Length)
			{
				Array.Copy(data, sourceIndex, newData, 0, newData.Length);
                sourceIndex += newData.Length;

				var info = new GiftListItemInfo(newData);
				if (info.ConvertResult == DPData.MysteryGift.ConvertResult.SUCCESS)
				{
					if (GiftMessageUtility.IsValidMessageLabel(info.RecvData))
					{
						if (set.Contains(info.GiftData.commonData.deliveryID))
						{
                            finalList.RemoveAll(x => x.GiftData.commonData.deliveryID == info.GiftData.commonData.deliveryID);
						}
						else
						{
							if ((info.GiftData.commonData.romVersion & (1 << version)) != 0)
                                finalList.Add(info);

							set.Add(info.GiftData.commonData.deliveryID);
						}
					}
				}
			}

			return finalList;
		}
		
		private IEnumerator StartProgress(int max)
		{
			for (int count=0; count<max; count++)
			{
				for (int i=0; i<3; i++)
				{
					yield return null;
				}

				downloadWindow.Step(1);
			}
		}
	}
}