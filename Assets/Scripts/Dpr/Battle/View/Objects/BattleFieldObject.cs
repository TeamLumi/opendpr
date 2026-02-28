using SmartPoint.AssetAssistant.UnityExtensions;
using UnityEngine;

namespace Dpr.Battle.View.Objects
{
	public class BattleFieldObject : BtlvBehaviour
	{
		[SerializeField]
		private GameObject[] _cellingObjects = ArrayHelper.Empty<GameObject>();
		[SerializeField]
		[Header("プレイヤー、相手の順で登録")]
		private GameObject[] _singleBattleHideObjects = ArrayHelper.Empty<GameObject>();
        [SerializeField]
		[Header("プレイヤー、相手の順で登録")]
		private GameObject[] _doubleBattleHideObjects = ArrayHelper.Empty<GameObject>();
        [SerializeField]
		[Header("2vs2用")]
		private GameObject[] _tagBattleHideObject;
		private MirrorPlane[] mirrarPlanes;
		
		public GameObject[] CeilingObjects { get => _cellingObjects; }
		public GameObject[] SingleBattleHideObjects { get => _singleBattleHideObjects; }
		public GameObject[] DoubleBattleHideObjects { get => _doubleBattleHideObjects; }
		public GameObject[] TagBattleHideObjects { get => _tagBattleHideObject; }
		
		protected void Awake()
		{
			var uVar1 = UnityEngine_Component__GetComponentsInChildren<object>
			                  (this);
			this.mirrarPlanes = uVar1;
		}
		
		// TODO
		public void SetMirrarCharacterLayerEnable(bool isEnable) { }
		
		// TODO
		public void SetSkirtHideObjectActive(bool isHidePlayer, bool isPlayerSingle, bool isHideTrainer, bool isTrainerSingle) { }
		
		// TODO
		private void SetPlayerSkirtHideObjectActive(bool isHidePlayer, bool isSingle) { }
		
		// TODO
		private void SetTrainerSkirtHideObjectActive(bool isHideTrainer, bool isSingle) { }
		
		// TODO
		private void SetAllTrainerSkirtHideObjectActive(bool isHide, bool isSingle) { }
		
		private void OnDestroy()
		{
			this._cellingObjects = null;
		}
		
		// TODO
		public BattleFieldObject() { }

		private enum HideObjectIndex : int
		{
			Player = 0,
			Trainer = 1,
		}

		private enum AllHideObjectIndex : int
		{
			Tag = 0,
			Single = 1,
		}
	}
}