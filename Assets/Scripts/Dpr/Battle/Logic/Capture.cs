using Pml;

namespace Dpr.Battle.Logic
{
	public static class Capture
	{
		public const uint FRIENDBALL_FRIENDSHIP = 150;
		
		// TODO
		public static void JudgeCapture(JudgeResult result, in JudgeParam param) { }
		
		private static bool isMustCapureSuccess(MainModule mainModule, ushort itemID)
		{
			var iVar1 = mainModule.GetCompetitor(0);
			if ((itemID != 1) && (iVar1 != 4)) {
			  var uVar2 = mainModule.IsMustCaptureMode();
			  return uVar2;
			}
			return true;
		}
		
		// TODO
		private static int calcCaptureIndicator(MainModule mainModule, BattleEnv battleEnv, BTL_POKEPARAM userPoke, BTL_POKEPARAM targetPoke, ushort itemID, int captureValueCoef) { return default; }
		
		// TODO
		private static int getZukanCaptureRatio(MainModule mainModule) { return default; }
		
		// TODO
		private static int calcBallCaptureRatio(MainModule mainModule, BattleEnv battleEnv, BTL_POKEPARAM userPoke, BTL_POKEPARAM targetPoke, ushort itemID) { return default; }
		
		// TODO
		private static int getBallCaptureRatio(MainModule mainModule, BattleEnv battleEnv, BTL_POKEPARAM userPoke, BTL_POKEPARAM targetPoke, ushort itemID) { return default; }
		
		// TODO
		private static bool checkCaptureCritical(MainModule mainModule, int captureIndicator) { return default; }
		
		private static int calcCaptureValue(int capture_value)
		{
			var uVar1 = FX32.Div(0xff000,capture_value);
			var uVar2 = FX32.CONST(0x3e401ebd);
			uVar1 = FX32.POW(uVar1,uVar2);
			var uVar3 = FX32.Div(0x10000000,uVar1);
			FX32.Whole(uVar3);
			return 0;
		}
		
		// TODO
		private static void checkCapureSuccessByRandom(out bool pIsCaptured, out byte pYureCount, int captureValue, bool isCritical)
		{
			pIsCaptured = default;
			pYureCount = default;
		}
		
		// TODO
		private static short getHeavyBallCaptureCorrectValue(ushort weight) { return default; }
		
		// TODO
		private static bool checkMoonBallEffective(MonsNo monsno, ushort formno) { return default; }
		
		// TODO
		private static int getLevelBallCaptureRatio(byte myLevel, byte targetLevel) { return default; }
		
		// TODO
		private static bool IsEnableDarkBallOnEventTimeZone() { return default; }

		public class JudgeParam
		{
			public MainModule mainModule;
			public BattleEnv battleEnv;
			public BTL_POKEPARAM userPoke;
			public BTL_POKEPARAM targetPoke;
			public ushort itemID;
			public int captureValueCoef;
			public bool isMustSuccess;
			public bool isCriticalEnable;
			
			public JudgeParam()
			{
				mainModule = null;
				battleEnv = null;
				userPoke = null;
				targetPoke = null;
				itemID = (ushort)ItemNo.DUMMY_DATA;
				isMustSuccess = false;
				isCriticalEnable = false;
				captureValueCoef = FX32.CONST_1_0;
			}
		}

		public class JudgeResult
		{
			public bool isCaptured;
			public bool isCritical;
			public byte yureCount;
		}
	}
}