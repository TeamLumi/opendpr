using System.Globalization;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PoketchAppCalc : PoketchAppBase
	{
		private const int _maxDigit = 10;
		private const string _defaultDisp = "0";

		private static readonly (float x, float y) _cursorOffset = (8.0f, -12.0f);
		private const NumberStyles ULongNumberStyles = NumberStyles.Integer;
		private const NumberStyles DecimalNumberStyles = NumberStyles.Number;
		private static readonly CultureInfo TargetCulture = new CultureInfo("en-US");

		[SerializeField]
		[Tooltip("CalcCode順(Buttonsも同様)")]
		private Sprite[] _numSprite;
		[SerializeField]
		[Tooltip("一の桁から順に")]
		private Image[] _numImage;
		[SerializeField]
		private Image _symbol;
		[SerializeField]
		private Image _cursor;

		private string _dispNumString;
		private decimal _currentNum;
		private decimal _targetNum;
		private CalcCode _calcCode;
		private CalcCode _preCalcCode;
		private CalcCode _lastInputCode;
		private bool _isError;
		private bool _isVoisePlayed;
		private int _cursorX;
		private int _cursorY;
		private int _currentIndex;
		private static readonly CalcCode[,] _buttonMap = new CalcCode[,]
		{
			{ CalcCode.Num_7, CalcCode.Num_8,         CalcCode.Num_9,     CalcCode.Act_Clear, CalcCode.CalcCode_Null },
			{ CalcCode.Num_4, CalcCode.Num_5,         CalcCode.Num_6,     CalcCode.Act_Plus,  CalcCode.Act_Minus },
			{ CalcCode.Num_1, CalcCode.Num_2,         CalcCode.Num_3,     CalcCode.Act_Mul,   CalcCode.Act_Div },
			{ CalcCode.Num_0, CalcCode.CalcCode_Null, CalcCode.Num_Point, CalcCode.Act_Equrl, CalcCode.CalcCode_Null },            
        };
		private static readonly int _btmMapWidth = _buttonMap.GetLength(1);
		private static readonly int _btnMapHeight = _buttonMap.GetLength(0);

        // TODO
        protected override void OnInitialize() { }
		
		protected override void OnOpen()
		{
			InputClear();
			ExtensionMethods.SetActive(this._cursor,0);
		}
		
		// TODO
		protected override void OnClose() { }
		
		// TODO
		protected override void OnUpdateDraw() { }
		
		// TODO
		protected override void OnUpdateControl([Optional] [DefaultParameterValue(false)] bool isAppControlEnable, [Optional] PoketchButton targetButton, PoketchWindow.TouchState state = PoketchWindow.TouchState.None) { }
		
		// TODO
		private void InputClear() { }
		
		// TODO
		private void InputNumeric(int num) { }
		
		// TODO
		private void InputDigitPoint() { }
		
		// TODO
		private void InputAction(CalcCode action) { }
		
		// TODO
		private void InputEqual() { }
		
		// TODO
		private void ExecuteCalc(decimal num, CalcCode code) { }
		
		// TODO
		private bool UpdateNumberImage() { return default; }
		
		// TODO
		private void ClearNumDisp() { }
		
		// TODO
		private void SetErrorDisp() { }
		
		// TODO
		private void ResetNumber() { }
		
		// TODO
		private void UpdateSymbolImage() { }
		
		// TODO
		private void PlayPokemonVoice(decimal number) { }

		private enum CalcCode : int
		{
			Num_0 = 0,
			Num_1 = 1,
			Num_2 = 2,
			Num_3 = 3,
			Num_4 = 4,
			Num_5 = 5,
			Num_6 = 6,
			Num_7 = 7,
			Num_8 = 8,
			Num_9 = 9,
			Num_Point = 10,
			Act_Plus = 11,
			Act_Minus = 12,
			Act_Mul = 13,
			Act_Div = 14,
			Act_Equrl = 15,
			Act_Clear = 16,
			Symbol_Asterisk = 17,
			Symbol_Question = 18,
			CalcCode_Null = 19,
		}
	}
}