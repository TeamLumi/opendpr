using AK;
using Audio;
using DPData.MysteryGift;
using Dpr.Message;
using Dpr.NetworkUtils;
using UnityEngine;

namespace Dpr.UI
{
	public class GiftCompleteWindow : GiftSubWindow
	{
		private static readonly Vector2 MsgWindowAnchorPos = new Vector2(0.0f, 100.0f);

		[SerializeField]
		private GiftContentsPanel contentsPanel;
		
		protected override void OnInitialize()
		{
			// Empty
		}
		
		public override void OnUpdate(float deltaTime)
		{
			if (_input.IsPushButton(UIManager.ButtonA) || _input.IsPushButton(UIManager.ButtonB))
			{
				CloseMessageWindow();
				onClosed?.Invoke(null);
				AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_CANCEL, null);
			}
		}
		
		public override void Show()
		{
			base.Show();

			SetupKeyguide(new KeyguideID[] { KeyguideID.GIFT_DECIDE, KeyguideID.GIFT_CANCEL });
		}
		
		public void Setup(RecvData data)
		{
			contentsPanel.Setup(data);
		}
		
		public void SetInputEnable(bool isEnable)
		{
			_input.inputEnabled = isEnable;
		}
		
		public void ShowMessage(string labelName)
		{
			OpenMessageWindow(new MsgWindow.MsgWindowParam()
			{
				useMsgFile = MessageManager.Instance.GetMsgFile(NetworkConstants.NET_COMM_MSBT_NAME),
				labelName = labelName,
				inputCloseEnabled = false,
				wndAnchorPos = MsgWindowAnchorPos,
			});
		}
	}
}