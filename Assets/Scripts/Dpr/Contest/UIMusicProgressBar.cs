using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Contest
{
	public class UIMusicProgressBar : MonoBehaviour
	{
		private const float anglePerBeat = 180.0f;

		private Image gaugeImage;
		private RectTransform iconContentRect;
		private RectTransform iconRect;
		private IconAnimState animState;
		private Quaternion quat;
		private Sprite barIconSpr;
		private float limitRotZ;
		private float gaugeWidth;
		private float startPosX;
		private float jumpPower;
		private float jumpDuration;
		private float prevElapsedTime;
		private float angle;
		private float addAngle;
		private float beatSec;
		private int jumpCount;
		private bool moveLock = true;
		private bool bIsActive = true;
		
		public bool IsMoveEnd { get => animState == IconAnimState.End; }
		public bool IsActive { get => bIsActive; }
		
		// TODO
		public void Initialize(DanceSettings danceSettingData) { }
		
		// TODO
		public void SetIconSpr(Sprite iconSpr) { }
		
		// TODO
		public void Setup(float beatSec) { }
		
		// TODO
		public void FinishIconMove() { }
		
		// TODO
		public void ResetParam(float beatSec) { }
		
		// TODO
		public void OnFinalize() { }
		
		private void Show()
		{
			ExtensionMethods.SetActive(1);
			this.bIsActive = true;
		}
		
		public void Hide()
		{
			ExtensionMethods.SetActive(0);
			this.bIsActive = false;
		}
		
		// TODO
		public void OnUpdate(float elapsedTime, float progressRatio) { }
		
		// TODO
		private void SetProgressRatio(float ratio) { }
		
		// TODO
		public void DoIconJump() { }
		
		// TODO
		public void StartMoveAnim(float elapsedTime) { }
		
		// TODO
		private void IconAnimation(float elapsedTime) { }
		
		// TODO
		private void SetRotZ(float z) { }

		private enum IconAnimState : int
		{
			None = 0,
			Move = 1,
			Jump = 2,
			End = 3,
		}
	}
}