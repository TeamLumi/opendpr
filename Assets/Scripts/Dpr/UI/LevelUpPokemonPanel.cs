using Pml;
using Pml.PokePara;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class LevelUpPokemonPanel : MonoBehaviour
	{
		private const string MessageFileName = "ss_level_up";
		private const string LevelMessageLabel = "SS_level_up_00_01";
		private const string AddExpMessageLabel = "SS_level_up_01_02";

		private const float BoostExpBarTweenDuration = 0.5f;

		[SerializeField]
		private PokemonIcon pokemonIcon;
		[SerializeField]
		private TextMeshProUGUI nameText;
		[SerializeField]
		private Image genderIconImage;
		[SerializeField]
		private TextMeshProUGUI levelText;
		[SerializeField]
		private TextMeshProUGUI addExpText;
		[SerializeField]
		private Slider expBar;
		[SerializeField]
		private CanvasGroup levelUpImageCanvasGroup;

		private bool isAnimationGauge;
		private bool isSkipAnimation;
		private bool isExpBarTweenBoost;
		private uint minExp;
		private uint maxExp;
		private float expBarTweenDuration;
		private List<LearnWazaResult> newLearnWazaResultList = new List<LearnWazaResult>();

		public PokemonParam PokemonParam { get; set; }
		public UILevelUp.PokemonStatus CurrentPokemonStatus { get; private set; }
		public UILevelUp.PokemonStatus BeforePokemonStatus { get; private set; }
		public Action OnGaugeUp { get; set; }
		public Action OnLevelUp { get; set; }
		public bool IsLevelUp { get; private set; }
		public bool IsLearnWaza { get => newLearnWazaResultList.Count > 0; }
		public bool IsAnimation { get; private set; }
		public bool IsActive { get; private set; }
		
		// TODO
		public void SetActive(bool isActive) { }
		
		// TODO
		public void Set(PokemonParam param, int index) { }
		
		public void SkipAnimation()
		{
			this.isSkipAnimation = true;
		}
		
		// TODO
		public bool AddExp(uint exp) { return default; }
		
		// TODO
		public void LevelUp(int count) { }
		
		// TODO
		public float CalcExpBarTweenDuration(uint addExp) { return default; }
		
		// TODO
		public void SetExpBarTweenDuration(float duration) { }
		
		// TODO
		public void HandledLevelUp() { }
		
		// TODO
		public LearnWazaResult GetCurrentNewLearnWazaResult() { return default; }
		
		// TODO
		public void HandledNewLearnWazaResult() { }
		
		// TODO
		private IEnumerator OpLoadIcon(CoreParam param, Image image) { return default; }
		
		// TODO
		private IEnumerator AddExpCoroutine(long exp) { return default; }
		
		// TODO
		private void SetupExpBar(uint min, uint max, uint current) { }
		
		// TODO
		private void SetExpBarValue(uint value) { }
		
		// TODO
		private void FadeInLevelUpImage() { }
		
		// TODO
		private string GetLevelText(CoreParam param) { return default; }
		
		// TODO
		private string GetAddExpText(long exp) { return default; }
		
		// TODO
		private uint GetLevelMinExp(MonsNo monsNo, ushort formNo, byte level) { return default; }

		public struct LearnWazaResult
		{
			public WazaNo WazaNo;
			public WazaLearningResult Result;
		}
	}
}