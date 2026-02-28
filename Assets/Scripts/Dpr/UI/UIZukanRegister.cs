using Pml.PokePara;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class UIZukanRegister : UIWindow
	{
		private const string RegisterNewMessageLabel = "SS_pokedex_049";
		private const string QuestionInputNickNameMessageLabel = "SS_pokedex_053";
		private const string QuestionSendToMessageLabel = "SS_pokedex_057";
		private const string QuestionSwapMemberMessageLabel = "SS_pokedex_060";
		private const string ResultAddMemberMessageLabel = "SS_pokedex_062";
		private const string ResultTradeMemberMessageLabel = "SS_pokedex_063";
		private const string ResultSendToBoxMessageLabel = "SS_pokedex_064";
		private const string CantTradePokemonMessageLabel = "SS_pokedex_124";

		private readonly int _animStateIn = Animator.StringToHash("in");
		private readonly int _animStateOut = Animator.StringToHash("out");

        [SerializeField]
		private ZukanDescriptionPanel descriptionPanel;
		[SerializeField]
		private RectTransform descriptionHideModelViewPositionRectTransform;
		[SerializeField]
		private RectTransform contextMenuPositionRectTransform;

		private UIMsgWindowController msgWindowController;
		private BootType bootType;
		private bool isWaitUpdate;
		private bool isRegisterNew;
		private bool isNotAddMember;
		private bool isSkipAddMemberProc;
		private PokemonParam pokemonParam;
		private AddMemberResult addMemberResult = AddMemberResult.Cancel;

		public event Action<AddMemberResult> OnComplete;
		
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
		public void Open(PokemonParam pokemonParam, bool isSkipAddMemberProc = false, UIWindowID prevWindowId = WINDOWID_PARENT) { }
		
		// TODO
		public void OpenRegisterOnly(PokemonParam pokemonParam, UIWindowID prevWindowId = WINDOWID_PARENT) { }
		
		// TODO
		public void OpenAddMemberOnly(PokemonParam pokemonParam, bool isNotAddMember = false, UIWindowID prevWindowId = WINDOWID_PARENT) { }
		
		// TODO
		public void OpenInputNickName(PokemonParam pokemonParam, bool isNotAddMember = false, UIWindowID prevWindowId = WINDOWID_PARENT) { }
		
		// TODO
		public IEnumerator OpOpen(UIWindowID prevWindowId) { return default; }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void OnUpdateDefault() { }
		
		// TODO
		private void OnUpdateDescriptionPanel() { }
		
		// TODO
		private void Initialize() { }
		
		// TODO
		private void ShowRegisterNewMessage() { }
		
		// TODO
		private void ShowInputNickNameMessage() { }
		
		// TODO
		private void AddMemberProc() { }
		
		// TODO
		private void ShowSelectPokemonProcContextMenu() { }
		
		// TODO
		private void End() { }
		
		// TODO
		private void OpenPokemonStatusWindow(PokemonStatusWindow.Param param, Action onClosedAction) { }
		
		// TODO
		private void BeforeSendBoxProc(PokemonParam pokemonParam, Action onComplete) { }

		private enum BootType : int
		{
			Default = 0,
			RegisterOnly = 1,
			AddMemberOnly = 2,
			InputNickName = 3,
		}

		public enum AddMemberResult : int
		{
			Party = 0,
			Box = 1,
			Cancel = 2,
		}

		public enum PartyTradeResult : int
		{
			Success = 0,
			Cancel = 1,
			CantTrade = 2,
		}
	}
}