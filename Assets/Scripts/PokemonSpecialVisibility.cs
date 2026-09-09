using System;
using UnityEngine;

public class PokemonSpecialVisibility : MonoBehaviour
{
	[SerializeField]
	private RendererVisibility[] rendererVisibilities;
	[SerializeField]
	private int dispNo;
	
	// TODO
	public void SetDispNo(int no) { }
	
	public int DispNo { get => dispNo; }
	
	// TODO
	public int DispNoNum { get; }
	
	// TODO
	private void Start() { }
	
	// TODO
	private void Update() { }

	[Serializable]
	public class RendererVisibility
	{
		public GameObject[] dispMeshes;
	}
}