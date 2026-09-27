using AK;
using Audio;
using UnityEngine;

namespace Dpr.UI
{
	public class GiftMainMenuWindow : GiftSubWindow
	{
		[SerializeField]
		private Cursor cursor;
		[SerializeField]
		private GiftMenuItem[] menuItems;
		private IndexSelector indexSelector;
		
		public MenuType SelectedMenuType { get; private set; }
		
		protected override void OnInitialize()
		{
			indexSelector = new IndexSelector(true, true, true);
		}
		
		public override void OnUpdate(float deltaTime)
		{
			if (!_input.inputEnabled)
				return;

			if (_input.IsRepeatButton(UIManager.StickLUp))
			{
				var prevIndex = indexSelector.CurrentIndex;

				if (indexSelector.Move(-1))
				{
					var menuItem = menuItems[indexSelector.CurrentIndex];

					cursor.transform.SetParent(menuItem.transform, false);

					menuItems[prevIndex].Unselect();
                    menuItem.Select();

					AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_SELECT, null);
                }
			}
			else if (_input.IsRepeatButton(UIManager.StickLDown))
            {
                var prevIndex = indexSelector.CurrentIndex;

                if (indexSelector.Move(1))
                {
                    var menuItem = menuItems[indexSelector.CurrentIndex];

                    cursor.transform.SetParent(menuItem.transform, false);

                    menuItems[prevIndex].Unselect();
                    menuItem.Select();

                    AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_SELECT, null);
                }
            }
            else if (_input.IsReleaseButton(UIManager.StickLUp) ||
					 _input.IsReleaseButton(UIManager.StickLDown))
            {
				indexSelector.ResumeMoveState();
            }

			if (_input.IsPushButton(UIManager.ButtonA))
			{
				SelectedMenuType = menuItems[indexSelector.CurrentIndex].ItemMenuType;
				onClosed?.Invoke(this);

                AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_DECIDE, null);
            }
			else if (_input.IsPushButton(UIManager.ButtonB))
			{
				SelectedMenuType = MenuType.None;
				onClosed?.Invoke(this);

                AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_CANCEL, null);
            }
        }
		
		public override void Show()
		{
			base.Show();

			var maxItems = menuItems.Length;

			for (int i=0; i<menuItems.Length; i++)
			{
				menuItems[i].Unselect();

				if (menuItems[i].ItemMenuType == MenuType.ShowHistory)
				{
					var received = MysteryGiftWork.IsExistRecvData();
					UIManager.Instance.Grayscale(menuItems[i].transform, received ? 0.0f : 1.0f);

					if (received)
						maxItems--;

					break;
                }
			}

			var prevIndex = indexSelector.CurrentIndex;
            indexSelector.Setup(0, maxItems - 1);
			indexSelector.SetCurrentIndex(prevIndex);

			menuItems[prevIndex].Select();

			SetupKeyguide(new KeyguideID[] { KeyguideID.GIFT_DECIDE, KeyguideID.GIFT_CANCEL });
		}

		public enum MenuType : int
		{
            None = -1,
            ReceiveInternet = 0,
			ReceiveSerialCode = 1,
			ShowHistory = 2,
		}
	}
}