using Dpr.MsgWindow;
using Pml.PokePara;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
    public class PokemonStatusPanel : MonoBehaviour
    {
        protected PokemonParam _pokemonParam;
        protected GameObject _aButtonGuide;
        public UIInputController input;
        public PokemonStatusWindow.Param statusParam;
        public UnityAction<bool> onChangeMemberSelectArrow;
        public UnityAction<bool, string, string> onChangeAbuttonGuide;
        public UnityAction onOpenBag;
        public UnityAction<bool> onOpenBagOfWazaMachine;
        public UnityAction onOpenPofinCase;
        public UnityAction<MsgWindowParam> onOpenMessageWindow;
        public UnityAction onForceClosed;

        public PokemonParam pokemonParam { get => _pokemonParam; }
        private bool isFromBattle { get => statusParam.limitType == PokemonStatusWindow.Param.LimitType.Battle; }
        private bool isFromBoxOtherStatus { get => statusParam.limitType == PokemonStatusWindow.Param.LimitType.BoxOtherStatus; }
        private bool isFromBoxSelect { get => statusParam.limitType == PokemonStatusWindow.Param.LimitType.BoxSelect; }
        private bool isFromZukanRegister { get => statusParam.limitType == PokemonStatusWindow.Param.LimitType.ZukanRegister; }
        private bool isFromFureai { get => UIManager.Instance.IsFureaiLimit(); }
        protected bool isLimitBag { get => isFromBattle || isFromBoxOtherStatus || isFromBoxSelect || isFromZukanRegister || isFromFureai; }
        protected bool isLimitMarking { get => isFromBattle || isFromBoxOtherStatus || isFromZukanRegister; }
        protected bool isLimitWazaSwap { get => isFromBattle || isFromBoxOtherStatus || isFromZukanRegister; }
        protected bool isLimitWazaMachine { get => isFromBattle || isFromBoxOtherStatus || isFromBoxSelect || isFromZukanRegister || isFromFureai; }
        protected bool isLimitPofin { get => isFromBoxOtherStatus || isFromBoxSelect || isFromZukanRegister || isFromFureai || !FlagWork.GetFlag(EvScript.EvWork.FLAG_INDEX.FE_C05R0201_ITEM_GET); }
        protected bool isLimitRibon { get => isFromZukanRegister; }

        public virtual void Clear()
        {
        	this._pokemonParam = null;
        }

        public virtual void Setup(PokemonParam pokemonParam)
        {
        	this._pokemonParam = pokemonParam;
        }

        // TODO
        public virtual void Select(bool enabled) { }

        public virtual bool OnUpdate(float deltaTime)
        {
        	return false;
        }
    }
}