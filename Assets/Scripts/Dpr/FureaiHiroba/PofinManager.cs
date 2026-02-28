using Audio;
using DG.Tweening;
using Dpr.Item;
using Dpr.SubContents;
using Dpr.UI;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.FureaiHiroba
{
	public class PofinManager : SequenceMonoBehaviour
	{
		[SerializeField]
		private Transform PofinMachineParent;
		private Transform PofinKiji;
		[SerializeField]
		private Text DebugText;
		[SerializeField]
		private List<Transform> PosList;
		[SerializeField]
		private Camera cam;
		[SerializeField]
		private Transform CamPos01;
		[SerializeField]
		private Transform CamPos02;
		private UIPofinResult uiPofinResult;
		private UIPofinPlaying PofinUI;
		private PofinPlayingPokeManager pokeManager;
		private List<ItemInfo> kinomiList;
		[SerializeField]
		private float PofinHeightMin = 0.9f;
		[SerializeField]
		private float PofinHeightMax = 0.95f;
		[SerializeField]
		private float PofinScaleMin = 0.9f;
		[SerializeField]
		private float PofinScaleMax = 1.1f;
		private float BlendValue;
		private Material pofinMat;
		private Material LEDMat;
		private Color nowLEDColor;
		private AudioInstance kakimazeSE;

		private static readonly Color[] LEDColors = new Color[]
		{
			Color.gray, Color.red, Color.yellow, Color.blue,
		};

		[SerializeField]
		private PofinGameCalc calc = new PofinGameCalc();
		public Action OnEndPofinPlaying;
		private bool isEnableUpdate;
		[SerializeField]
		private float duration;
		[SerializeField]
		private Ease ease;
		private PofinEffectManager effectMng;
		private float KakimazeSE_Interval = 1.0f;
		public float DebugTime = 40.0f;
		private bool isSEPlaying;

		[Button("CameraMove", "CameraMove", new object[0])]
		public int Button03;
		[Button("CameraReset", "CameraReset", new object[0])]
		public int Button04;
		[Button("DebugCreatePofin", "DebugCreatePofin", new object[0])]
		public int Button05;
		
		// TODO
		public IEnumerator Start() { return default; }
		
		// TODO
		protected override void OnUpdate(float deltaTime) { }
		
		// TODO
		private void _UpdateDebugText() { }
		
		// TODO
		private void BatterUpdate(float deltaTime) { }
		
		// TODO
		private void LED_Update(float deltaTime) { }
		
		// TODO
		private void EndCooking() { }
		
		public void SetKinomi(List<ItemInfo> kinomiList)
		{
			this.kinomiList = kinomiList;
		}
		
		// TODO
		public Tweener CameraMove() { return default; }
		
		// TODO
		public void CameraReset() { }
		
		// TODO
		private void GotoPofinResult(PofinCookModel model) { }
		
		// TODO
		private void EndPofinResult() { }
		
		public void SetFureaiPoke(List<FureaiPokeModel> fureaiPokes)
		{
			var uVar1 = new PofinPlayingPokeManager(fureaiPokes,this.PosList,this.PofinMachineParent,0);
			this.pokeManager = uVar1;
			this.calc.SetPokeModel(fureaiPokes);
		}
		
		// TODO
		public void DebugCreatePofin() { }
		
		// TODO
		public static ItemInfo[] GetRandomKinomis(int num) { return default; }
	}
}