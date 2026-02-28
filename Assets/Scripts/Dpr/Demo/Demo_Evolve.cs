using Pml.PokePara;
using Pml;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Dpr.SubContents;

namespace Dpr.Demo
{
    public class Demo_Evolve : DemoBase
    {
        public UnityAction<Result> OnResult;
        private TimeLineBinder timeLine;
        private Result _result;
        private EvoState nowState;
        private Param _param;
        private float EvolvedDistance;
        private GameObject Poke3D;
        private GameObject NextPoke3D;
        public bool IsTradeAffter;
        public bool IsGetEvolveMonsNo;
        public bool IsGetPokemon;
        public UnionTradeManager.BoxPokeData TradeAfter_RealPokeParam;
        private MarkerReceiver receiver;
        private bool isAutoInput;
        private float messageElapsed;

        public Demo_Evolve(Param param)
        {
            StartEnterFadeDuration = 0.2f;
            StartExitFadeDuration = 0.2f;
            EndEnterFadeDuration = 0.5f;
            EndExitFadeDuration = 0.5f;
            _param = param;
            FadeColor = Color.black;
            PlayerWork.isEvolveDemo = true;
            UseCamera = true;
            DisableEnvironmentController = false;
            isDisablePostProcess = true;
            isDisableMainCamera = true;
        }

        public Demo_Evolve()
        {
            StartEnterFadeDuration = 0.2f;
            StartExitFadeDuration = 0.2f;
            EndEnterFadeDuration = 0.5f;
            EndExitFadeDuration = 0.5f;
            FadeColor = Color.black;
            _param = new Param();
            _param.pokemonParam = PlayerWork.playerParty.GetMemberPointer(0);
            _param.useCancel = true;
            _param.nextMonsNo = _param.pokemonParam.GetMonsNo() + 1;
            UseCamera = true;
            DisableEnvironmentController = false;
            isDisablePostProcess = true;
            isDisableMainCamera = true;
        }

        public override void Destroy()
        {
        	this.pokemonParam = null;
        }

        // TODO
        public override void Init() { }

        // TODO
        public override IEnumerator Enter() { return null; }

        // TODO
        public override IEnumerator Main() { return null; }

        // TODO
        private IEnumerator WazaOboe(WazaLearningResult result, WazaNo wazaNo, PokemonParam pokeParam) { return null; }

        // TODO
        public bool AddNukenin() { return false; }

        // TODO
        public override IEnumerator Exit() { return null; }

        // TODO
        private IEnumerator Evolve() { return null; }

        // TODO
        private void AnimationUpdate(float deltaTime) { }

        // TODO
        private void GoNextState() { }

        public class Param
        {
            public PokemonParam pokemonParam;
            public MonsNo nextMonsNo;
            public bool useCancel;
            public uint evoRoute;

            public void Evolve()
            {
                pokemonParam.Evolve(nextMonsNo, evoRoute);
            }

            public void Destroy()
            {
                pokemonParam = null;
            }
        }

        public enum Result : int
        {
            None = 0,
            Cancel = 1,
            Complete = 2,
        }

        private enum EvoState : int
        {
            Start = 0,
            Evo1 = 1,
            Evo2 = 2,
            Stop = 3,
            EvoEnd = 4,
        }
    }
}
