using Dpr.Battle.Logic;
using Dpr.Battle.View.Objects;
using Dpr.SequenceEditor;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.Battle.View.Systems
{
	public sealed class BattleGroundEffectSystem
	{
		private BattleViewSystem _pViewSystem;
		private BtlGround _currentGroundType;
		private BtlvEffectInstance _iPtrGroundEffectMain;
		private BtlvEffectInstance _iPtrGroundEffectCamera;
		private BattleGroundData _groundDatas;
		private Vector3 _cameraEffectOffset;
		private Coroutine _changeGroundCol;
		private Action<BtlGround, BtlGround> _onChanged;
		
		public BattleGroundEffectSystem(BattleViewSystem pViewSystem)
		{
			_currentGroundType = BtlGround.BTL_GROUND_NONE;
			_pViewSystem = pViewSystem;
			_groundDatas = new BattleGroundData();

			var ground = (BtlGround)pViewSystem.GetMainModule().GetDefaultGround();
            LoadData(ground);
			_changeGroundCol = Sequencer.Start(ChangeBattleGround(ground));
		}
		
		// TODO
		public void Request(BtlGround ground, Vector3 offset, [Optional] Action<BtlGround, BtlGround> onChanged) { }
		
		// TODO
		private IEnumerator ChangeBattleGround(BtlGround ground) { return default; }
		
		// TODO
		private IEnumerator PlayGroundEffect() { return default; }
		
		private bool CheckAlreadyChanged()
		{
			if (this._iPtrGroundEffectMain != null) {
			  return true;
			}
			return this._iPtrGroundEffectCamera != null;
		}
		
		// TODO
		private void Stop() { }
		
		// TODO
		private void LoadData(BtlGround groundType) { }
		
		// TODO
		public string[] GetFileNames(BtlGround groundType) { return default; }
		
		// TODO
		private IEnumerator LoadEffect(string file, Action<BtlvEffectInstance> setter, SEQ_DEF_EFF_DRAWTYPE drawType = SEQ_DEF_EFF_DRAWTYPE.SEQ_DEF_EFF_DRAWTYPE_NORAML) { return default; }
		
		// TODO
		public void SetGroundVisibility(bool visible) { }

		private class BattleGroundData
		{
			public string mainEffectFileName;
			public string cameraEffectFileName;
			public Vector3 mainScale;
			public Vector3 cameraScale;
		}
	}
}