using Pml.PokePara;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIBattleMatchingPokemonItem : MonoBehaviour
	{
		[SerializeField]
		private GameObject _objNo;
		[SerializeField]
		private UIText _textNo;
		[SerializeField]
		private GameObject _objItem;
		[SerializeField]
		private UIText _textItem;
		[SerializeField]
		private Image _imageItem;

		private readonly string NO_MSBT = "ss_btl_pokeselect";
		private readonly string[] NO_LABELS = new string[]
		{
            "msg_ui_btl_pokeselect_top_no_00", "msg_ui_btl_pokeselect_top_no_01",
            "msg_ui_btl_pokeselect_top_no_02", "msg_ui_btl_pokeselect_top_no_03",
            "msg_ui_btl_pokeselect_top_no_04", "msg_ui_btl_pokeselect_top_no_05",
        };
		
		// TODO
		public void Setup(PokemonParam param) { }
		
		// TODO
		public void SetEnableNumber(int index) { }
		
		public void SetDisableNumber()
		{
			this._objNo.SetActive(0);
		}
	}
}