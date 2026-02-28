using DG.Tweening;
using UnityEngine;

namespace Dpr.Contest
{
	public class UILaunchSkillLog : MonoBehaviour
	{
		[SerializeField]
		private Vector2 itemSize = Vector2.zero;
		private readonly Vector2 HIDE_POS = new Vector2(-500.0f, 0.0f);

		private DOTweenAnimation moveTween;
		private DOTweenAnimation fadeTween;
		private RectTransform rect;
		private RectTransform contentRect;
		private GameObject appealObj;
		private Vector2 frameSize;
		private float timer;
		private float showDuration;
		private int orderCount;
		private bool bIsSameType;
		private bool bShow;
		
		public bool Showing { get => bShow; }
		
		// TODO
		public void Create(bool isPlayer, string playerName, Sprite frameSpr, Sprite wazaTypeIconSpr) { }
		
		public void ResetParam()
		{
			this.timer = 0;
			this.bShow = false;
			this.appealObj.SetActive(0);
			Hide();
		}
		
		// TODO
		public void ShowSkillLog(bool isSameType, float showTime) { }
		
		// TODO
		public void MovePosition() { }
		
		// TODO
		public void Hide() { }
		
		// TODO
		private void HideAppealObj() { }
		
		// TODO
		public void UpdateShowLogTime(float deltaTime) { }
		
		// TODO
		public void OnCompleteTween() { }
	}
}