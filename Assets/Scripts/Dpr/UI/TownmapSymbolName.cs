using UnityEngine;
using XLSXContent;

namespace Dpr.UI
{
	public class TownmapSymbolName : MonoBehaviour
	{
		[SerializeField]
		private UIText _text;
		private bool _isActived;
		private TownMapTable.SheetData _data;
		
		public void SetActive(bool isActive)
		{
			this._isActived = (isActive ? 1 : 0) & 1;
			var uVar1 = this.gameObject;
			if (this._isActived) {
			  uVar1.SetActive(this._data != null);
			}
			uVar1.SetActive(0);
		}
		
		// TODO
		public void Setup(Townmap.Cell cell, Vector3 pos) { }
	}
}