using Pml.PokePara;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIPokeStatusSelectPanel : MonoBehaviour
	{
		[SerializeField]
		private UIText _name;
		[SerializeField]
		private UIText _level;
		[SerializeField]
		private Image _imageMonsterBall;
		[SerializeField]
		private Image _sex;
		[SerializeField]
		private Image _language;
		[SerializeField]
		private GameObject _selectArrowRoot;
		[SerializeField]
		private GameObject _infoStatusRoot;
		[SerializeField]
		private Image[] _arrows;
		[SerializeField]
		private PokemonSick _sick;
		
		// TODO
		public void Setup(PokemonParam pokemonParam) { }
		
		private void SetInfoStatusRootActive(bool active)
		{
			if (((this._infoStatusRoot.activeSelf ^ active) & 1) != 0) {
			  this._infoStatusRoot.SetActive((active ? 1 : 0) & 1);
			}
		}
		
		public void SetArrowAcitve(bool active)
		{
			if (((this._selectArrowRoot.activeSelf ^ active) & 1) != 0) {
			  this._selectArrowRoot.SetActive((active ? 1 : 0) & 1);
			}
		}
		
		// TODO
		public void PlayAnimArrow(int move) { }
	}
}