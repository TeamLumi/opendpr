using Dpr.Battle.Logic;
using Dpr.Battle.View.Objects;
using System;
using XLSXContent;

namespace Dpr.Battle.View.Systems
{
	public sealed class BattleStatusEffectObserverSystem : IDisposable
	{
		private const int DISP_TIME = 80;
		private const int WAIT_TIME = 10;

		private BattleViewSystem _viewSystem;
		private Sequence _sequence;
		private BtlvPos[] _orderArr;
		private int _nowOrder;
		private bool _isFinished;
		private int _cnt;
		private BtlvEffectInstance _iPtrParticle;
		private BtlvEffectInstance _iPtrSubParticle;
		private BattleDataTable.SheetBattleStatusEffectObserverData[] _observerDatas;
		private BOPokemon targetPokemon;
		
		public bool IsPlaying { get; private set; }
		public bool IsUnInitialized { get; private set; }
		public bool IsFinish { get => _sequence == Sequence.WAIT; }
		
		public BattleStatusEffectObserverSystem(BattleViewSystem pViewSystem)
		{
			_viewSystem = pViewSystem;
			_orderArr = new BtlvPos[7]; // TODO: Find a good constant for this?
			_sequence = Sequence.WAIT;
			_observerDatas = BattleDataTableManager.Instance.BattleDataTable.BattleStatusEffectObserverData;
			IsPlaying = false;
			IsUnInitialized = true;
		}
		
		// TODO
		public void Dispose() { }
		
		// TODO
		public void Play() { }
		
		// TODO
		public void Stop() { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		public void Finish()
		{
			this._isFinished = true;
		}

		private enum Sequence : int
		{
			WAIT = 0,
			START_LOAD = 1,
			WAIT_LOAD = 2,
			WAIT_EFFECT = 3,
			EMIT = 4,
			WAIT_NEXT = 5,
			NOSICK_WAIT = 6,
			GO_NEXT = 7,
		}
	}
}