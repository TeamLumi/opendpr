using Dpr.Battle.Logic;
using Pml;
using Pml.PokePara;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class UILevelUp : UIWindow
	{
		private const string GetExpMessageLabel = "SS_level_up_02_01";
		private const string GetExpSingleMessageLabel = "SS_level_up_02_08";
		private const string LevelUpMessageLabel = "SS_level_up_02_02";
		private const string ResultLearnWazaMessageLabel = "SS_level_up_02_03";
		private const string ResultLearnWazaMessageLabel_Evolve = "SS_shinka_demo_04_01";
		private const string QuestionSwapWazaMessageLabel = "SS_level_up_02_04";
		private const string ResultSwapWazaMessageLabel = "SS_level_up_02_05";
		private const string ResultNotLearnWazaMessageLabel = "SS_level_up_02_06";

		private static readonly string[] QuestionSwapWazaContextMenuMessageLabels = new string[]
		{
            "SS_level_up_03_01", "SS_level_up_03_02",
        };
		private static readonly string[] QuestionSwapWazaContextMenuMessageLabels_Evolve = new string[]
        {
            "SS_shinka_demo_10_01", "SS_shinka_demo_10_02",
        };

        private readonly int _animStateIn = Animator.StringToHash("in");
		private readonly int _animStateOut = Animator.StringToHash("out");

        [SerializeField]
		private LevelUpPokemonPanel[] levelUpPokemonPanels;
		[SerializeField]
		private LevelUpStatusPanel statusPanel;

		private Param param;
		private UIMsgWindowController msgWindowController;
		private bool isAnimateGauge;
		private bool isPlayGaugeUpSe;
		private bool isPlayLevelUpSe;
		private bool isWaitExit;
		
		public override void OnCreate()
		{
			UIWindow.OnCreate();
			var uVar1 = UnityEngine_Component__GetComponentInChildren<object>
			                  (this);
			this._animator = uVar1;
			uVar1 = new UIMsgWindowController();
			uVar1 = new UIMsgWindowController();
			this.msgWindowController = uVar1;
		}
		
		// TODO
		public void Open(Param param, UIWindowID prevWindowId = WINDOWID_PARENT) { }
		
		// TODO
		public IEnumerator OpOpen(UIWindowID prevWindowId) { return default; }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		public static void WazaOboeSequence(UIMsgWindowController msgWindowController, WazaNo wazaNo, WazaLearningResult WazaResult, PokemonParam param, bool isEvolve = false) { }
		
		// TODO
		private void SetupPokemonPanels() { }
		
		// TODO
		private void ApplyParam() { }
		
		// TODO
		private void PlayGaugeUpSe() { }
		
		// TODO
		private void PlayLevelUpSe() { }
		
		// TODO
		private static void ShowLearnWazaWindow(PokemonParam pokemonParam, WazaNo wazaNo, UIMsgWindowController msgWindowController) { }

		public struct PokemonStatus
		{
			public uint Level;
			public uint Exp;
			public uint Hp;
			public uint Attack;
			public uint Deffence;
			public uint SpecialAttack;
			public uint SpecialDeffence;
			public uint Agility;
			
			public PokemonStatus(CoreParam coreParam)
			{
				Level = coreParam.GetLevel();
				Exp = coreParam.GetExp();
				Hp = coreParam.GetPower(PowerID.HP);
				Attack = coreParam.GetPower(PowerID.ATK);
                Deffence = coreParam.GetPower(PowerID.DEF);
                SpecialAttack = coreParam.GetPower(PowerID.SPATK);
                SpecialDeffence = coreParam.GetPower(PowerID.SPDEF);
                Agility = coreParam.GetPower(PowerID.AGI);
			}
		}

		public struct Param
		{
			public uint[] AddExpValues;
			public int TargetIndex;
			public int LevelUpCount;
			public PokeParty PokeParty;
			public BattleViewBase.ExpGetResult BattleExpGetResult;
			
			public void Clear()
			{
				AddExpValues = null;
				TargetIndex = -1;
				LevelUpCount = 0;
				PokeParty = null;
				BattleExpGetResult = null;
			}
		}
	}
}