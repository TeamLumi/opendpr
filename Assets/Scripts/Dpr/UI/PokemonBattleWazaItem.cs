using Dpr.Battle.Logic;
using UnityEngine;

namespace Dpr.UI
{
	public class PokemonBattleWazaItem : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _efficacyRoot;
		[SerializeField]
		private UIText _efficacyText;
		[SerializeField]
		private PokemonStatusWazaItem _item;
		
		// TODO
		public void Setup(BTL_POKEPARAM battlePokemonParam, int wazaIndex) { }
		
		public void Select(bool enabled)
		{
			this._item.Select((enabled ? 1 : 0) & 1);
		}
	}
}