using UnityEngine;

public class UnionCharacterData : MonoBehaviour
{
	[SerializeField]
	private string charaAssetName;
	[SerializeField]
	private int colorVariationID;
	
	// TODO
	public void SetCharaAssetName(string name) { }
	
	public string GetCharaAssetName() {
	    return charaAssetName;
	}
	
	public void SetColorVariationID(int id) {
	    this.colorVariationID = id;
	}
	
	public int GetColorVariationID() {
	    return colorVariationID;
	}
}