using System.Diagnostics;
using System.Text;

namespace Dpr.Battle.Logic
{
	public static class BTL
	{
		private const string CONDITION = "DMY";
		public static int s_printBit = 227;
		private static StringBuilder sb = new StringBuilder();
		
		// TODO
		public static StringBuilder GetStringBuilder(bool isClear = true) { return default; }
		
		// TODO
		[Conditional(CONDITION)]
		public static void PRINT(BtlLog logType, string s) { }

        // TODO
        [Conditional(CONDITION)]
        public static void PRINT(string s) { }

        // TODO
        [Conditional(CONDITION)]
        public static void ASSERT(bool condition) { }

        // TODO
        [Conditional(CONDITION)]
        public static void ASSERT(bool condition, string s) { }
		
		// TODO
		public static void SetEnableLog(BtlLog logType, bool isOn) { }
		
		public static bool IsEnableLog(BtlLog logType) {
		    return false;
		}

        // TODO
        [Conditional(CONDITION)]
        public static void N_Printf(BtlDebugStrID strID, object[] args) { }

        // TODO
        [Conditional(CONDITION)]
        public static void DEBUGPRINT_Ctrl() { }

        // TODO
        [Conditional(CONDITION)]
        public static void N_PrintfSimple(BtlDebugStrID strID, object[] args) { }

        // TODO
        [Conditional(CONDITION)]
        public static void UTIL_SetPrintType(BtlPrintType type) { }
	}
}