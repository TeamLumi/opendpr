using Pml.PokePara;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.UI
{
	public class ConditionFur : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _furContents;
		[SerializeField]
		private PokemonStatusConditionFurItem _furItemPrefab;
		[SerializeField]
		private FurAnimParam _furParam;

		private readonly int _animStateKeduya01 = Animator.StringToHash("Keduya_01");

		private List<PokemonStatusConditionFurItem> _items = new List<PokemonStatusConditionFurItem>();
		private Coroutine _opFurAnim;

		private const int _furIconMax = 12;
		
		// TODO
		private void Awake() { }
		
		// TODO
		public void Setup(PokemonParam pokemonParam) { }
		
		// TODO
		private void OnEnable() { }
		
		private void OnDisable()
		{
			if (this._opFurAnim != null) {
			  this._opFurAnim.StopCoroutine();
			  this._opFurAnim = null;
			}
		}
		
		private void StopAnimKezuya()
		{
			if (this._opFurAnim != null) {
			  this._opFurAnim.StopCoroutine();
			  this._opFurAnim = null;
			}
		}
		
		// TODO
		private IEnumerator OpAnimKezuya() { return default; }

		[Serializable]
		private class FurAnimParam
		{
			public float nextSeconds = 0.3f;
			public float waitAllPlaySeconds = 0.3f;
		}
	}
}