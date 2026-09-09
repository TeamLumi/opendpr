using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class PokemonTraGroup : MonoBehaviour
{
	[SerializeField]
	private int baseRenderQueue = 3000;
	[SerializeField]
	private TraGrope[] traGropes;
	[SerializeField]
	private bool needSort;
	private SkinnedMeshRenderer[] _skinnedMeshRenderers;
	
	public TraGrope[] GetGropes() {
	    return traGropes;
	}
	
	// TODO
	private void OnEnable() { }
	
	// TODO
	private void OnDisable() { }
	
	// TODO
	public int SetBaseRenderQueue(int value, [Optional] Camera camera) { return default; }
	
	// TODO
	private void Start() { }

	[Serializable]
	public class TraGrope
	{
		public MaterialUsing[] materialUsings;
		public int[] prioritys;
		public GameObject node;
	}
}