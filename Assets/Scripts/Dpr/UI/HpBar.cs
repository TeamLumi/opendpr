using System;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class HpBar : MonoBehaviour
	{
		private const float TweenDuration = 1.0f;

		[SerializeField]
		private Slider barSlider;
		[SerializeField]
		private Image bodyImage;
		[SerializeField]
		private Sprite[] bodySprites;
		[SerializeField]
		private float[] switchSpriteRatioValues;

		private TextMeshProUGUI hpText;
		private int spriteIndex;
		private int min;
		private int max;
		private float duration;
		private float afterDuration;
		
		public bool IsAnimation { get; private set; }
		
		public void SetHpText(TextMeshProUGUI text)
		{
			this.hpText = text;
		}
		
		// TODO
		public void Setup(int min, int max, int value, float duration = 1.0f, float afterDuration = 0.0f) { }
		
		// TODO
		public void SetHpImmidiate(int value) { }
		
		public void UpdateMaxHP(uint maxHp)
		{
			this.max = maxHp;
		}
		
		// TODO
		public void SetDuration(float duration) { }
		
		// TODO
		public void SetHp(int hp, [Optional] Action onComplete, [Optional] Action<int> onUpdate) { }
		
		// TODO
		private void UpdateHp([Optional] Action<int> onUpdate) { }
		
		// TODO
		public HpStatus GetHpStatus(uint currentHP, uint maxHP) { return default; }
	}
}