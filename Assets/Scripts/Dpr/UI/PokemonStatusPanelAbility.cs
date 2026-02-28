using Effect;
using Pml.PokePara;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PokemonStatusPanelAbility : PokemonStatusPanel
	{
		[SerializeField]
		private ChartItem[] _chartItems;
		[SerializeField]
		private UIText _tokuseiName;
		[SerializeField]
		private UIText _tokuseiDescription;
		[SerializeField]
		private Color[] _raderColors;
		[SerializeField]
		private RectTransform _raderChartRoot;
		[SerializeField]
		private RaderChart[] _raders;
		[SerializeField]
		private Sprite[] _spriteUpDowns;
		[SerializeField]
		private Color[] _colorUpDowns;
		[SerializeField]
		private AnimationCurve _curveAbility = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0.0f,   0.0f,   0.0f,      2.309923f),
			new Keyframe(40.0f,  60.0f,  1.186237f, 1.186237f),
			new Keyframe(70.0f,  90.0f,  0.782187f, 0.782187f),
			new Keyframe(100.0f, 100.0f, 0.036548f, 0.0f),
		});
		private int _selectRaderChartIndex;
		private List<EffectInstance> _effects = new List<EffectInstance>();
		private PowerID[] _powerIdMap = new PowerID[]
		{
			PowerID.HP,  PowerID.ATK,   PowerID.DEF,
			PowerID.AGI, PowerID.SPDEF, PowerID.SPATK,
        };

		private const float _minLength = 0.15f;
		
		// TODO
		private void Awake() { }
		
		// TODO
		private void OnDisable() { }
		
		// TODO
		public override void Setup(PokemonParam pokemonParam) { }
		
		// TODO
		private void SetupUpDownState(ChartItem chartItem, PowerID powerId) { }
		
		private float GetAbilityRaderValue(uint value)
		{
			if ((float)value / 400.0 <= 1.0) {
			  var fVar1 = (float)UnityEngine_AnimationCurve__Evaluate
			                           (((float)value / 400.0) * 100.0,this._curveAbility,0);
			  return fVar1 / 100.0;
			}
			return 1.1;
		}
		
		// TODO
		private float GetAbilitySplinedValue(float rate) { return default; }
		
		// TODO
		public float GetBasicAndTalentRaderValue(uint value) { return default; }
		
		// TODO
		public float GetEfforttRaderValue(uint value) { return default; }
		
		// TODO
		private void SelectRaderChartIndex(int selectIndex, bool isInitialized = false) { }
		
		// TODO
		private void StopEffects() { }
		
		// TODO
		private void PlayEffortEffects(PokemonParam pokemonParam) { }
		
		// TODO
		public override bool OnUpdate(float deltaTime) { return default; }

		[Serializable]
		private class ChartItem
		{
			public UIText name;
			public UIText text;
			public Image icon;
			public RectTransform effectRoot;
		}

		private enum RaderType : int
		{
			Ability = 0,
			BasicAndTalent = 1,
			Effort = 2,
		}
	}
}