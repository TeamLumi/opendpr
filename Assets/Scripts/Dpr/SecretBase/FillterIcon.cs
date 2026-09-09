using UnityEngine;
using UnityEngine.UI;

namespace Dpr.SecretBase
{
	public class FillterIcon : SelectItemBase<string>
	{
		[SerializeField]
		private Text label;
		[SerializeField]
		private Text value;

		private int index;
		
		// TODO
		public override void SetData(string value) { }
		
		// TODO
		public void SetValueText(string value, int index) { }
		
		public int GetIndex() {
		    return index;
		}
	}
}