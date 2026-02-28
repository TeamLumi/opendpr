using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class TownmapInfo : MonoBehaviour
	{
		[SerializeField]
		private Image[] _images;
		private Townmap.NoticeType _selectType;
		private UnityAction<Townmap.NoticeType> _onSelectChanged;
		
		public void Setup(UnityAction<Townmap.NoticeType> onSelectChanged)
		{
			this._onSelectChanged = onSelectChanged;
			Select(0xffffffff,1);
		}
		
		// TODO
		public void Select(Townmap.NoticeType type, bool isInitialized) { }
		
		// TODO
		public bool OnUpdate(float deltaTime, UIInputController input) { return default; }
	}
}