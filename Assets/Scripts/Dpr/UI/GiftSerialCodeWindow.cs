using AK;
using Audio;
using Dpr.Message;
using UnityEngine;

namespace Dpr.UI
{
	public class GiftSerialCodeWindow : GiftSubWindow
	{
		private const int CodeMinLength = 5;
		private const int CodeMaxLength = 16;
		private const int SplitCodeLength = 4;

		[SerializeField]
		private UIText[] codeTexts;
		private bool isShowSoftwareKeyboard;
		private bool isEnableUpdate;
		
		public string InputSerialCode { get; private set; }
		
		protected override void OnInitialize()
		{
			// Empty;
		}
		
		public override void Show()
		{
			base.Show();

			SetupKeyguide(new KeyguideID[] { KeyguideID.GIFT_DECIDE, KeyguideID.GIFT_CANCEL });
			isShowSoftwareKeyboard = true;
			isEnableUpdate = true;
		}
		
		public override void OnUpdate(float deltaTime)
		{
			if (isShowSoftwareKeyboard)
			{
				isShowSoftwareKeyboard = false;
				ShowSoftwareKeyboard();
			}
			else if (isEnableUpdate)
			{
				if (_input.IsPushButton(UIManager.ButtonA))
				{
					ShowSoftwareKeyboard();
					AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_DECIDE, null);
				}
				else if (_input.IsPushButton(UIManager.ButtonB))
                {
					onClosed?.Invoke(null);
                    AudioManager.Instance.PlaySe(EVENTS.UI_COMMON_CANCEL, null);
                }
            }
		}
		
		public void ClearTexts()
		{
			InputSerialCode = "";
			for (int i=0; i<codeTexts.Length; i++)
				codeTexts[i].text = "";
		}
		
		private (bool, string) OnInputCheck(string resultText, SoftwareKeyboard.ErrorState errorState)
		{
			return SoftwareKeyboard.InputCheck(resultText, errorState);
		}
		
		private void SetSerialCodeText(string text)
		{
			InputSerialCode = text;

			for (int i=0; i<codeTexts.Length; i++)
			{
				string subString = "";

				if (i * SplitCodeLength < text.Length)
					subString = text.Substring(i * SplitCodeLength, Mathf.Min(SplitCodeLength, text.Length - (i * SplitCodeLength)));

				codeTexts[i].text = subString;
			}
		}
		
		private void ShowSoftwareKeyboard()
		{
			SoftwareKeyboard.Open(new SoftwareKeyboard.Param()
			{
				text = InputSerialCode,
				headerText = MessageManager.Instance.GetSimpleMessage("ss_strinput", "SS_strinput_015"),
				textMaxLength = CodeMaxLength,
				textMinLength = CodeMinLength,
				invalidCharFlag = SoftwareKeyboard.InvalidChar.OutsideOfDownloadCode,
				disableErrorChecks = (int)(SoftwareKeyboard.ErrorCheck.NgWord | SoftwareKeyboard.ErrorCheck.NumberCount),
            },
			OnInputCheck,
			(isSuccess, resultText) =>
			{
				if (isSuccess)
				{
					isEnableUpdate = false;
					SetSerialCodeText(resultText);
					onClosed?.Invoke(this);
				}
				else
				{
					onClosed?.Invoke(null);
				}
			});
		}
	}
}