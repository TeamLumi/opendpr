using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PoketchAppHiden : PoketchAppBase
	{
		[SerializeField]
		private Image _titleImage;
		[SerializeField]
		private Image[] _wazaNameImage;
		[SerializeField]
		private Transform[] _cursorRoots;
		[SerializeField]
		private GameObject _cursor;

		private int _currentIndex = -1;
		private int _preIndex = -1;

		private static readonly (FieldPoketch.HidenWazaType type, int index)[] _hidenTypes = new (FieldPoketch.HidenWazaType, int)[]
		{
			(FieldPoketch.HidenWazaType.Iwakudaki, 1), (FieldPoketch.HidenWazaType.Iaigiri,    5),
			(FieldPoketch.HidenWazaType.Kairiki,   2), (FieldPoketch.HidenWazaType.Sorawotobu, 6),
			(FieldPoketch.HidenWazaType.Kiribarai, 3), (FieldPoketch.HidenWazaType.Naminori,   7),
			(FieldPoketch.HidenWazaType.Rockclimb, 4), (FieldPoketch.HidenWazaType.Takinobori, 8),
        };
		
		// TODO
		protected override void OnInitialize() { }
		
		protected override void OnOpen()
		{
			CheckOpenHiden();
			this._cursor.SetActive(0);
			SetCursor(this._currentIndex);
		}
		
		// TODO
		protected override void OnClose() { }
		
		// TODO
		protected override void OnUpdateDraw() { }
		
		// TODO
		protected override void OnUpdateControl([Optional] [DefaultParameterValue(false)] bool isAppControlEnable, [Optional] PoketchButton targetButton, PoketchWindow.TouchState state = PoketchWindow.TouchState.None) { }
		
		// TODO
		private int MoveHorizontal(int index) { return default; }
		
		// TODO
		private int MoveUp(int index) { return default; }
		
		// TODO
		private int MoveDown(int index) { return default; }
		
		// TODO
		private void SetCursor(int index) { }
		
		// TODO
		private void CheckOpenHiden() { }
	}
}