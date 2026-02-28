namespace Pml
{
	public static class DebugViewTable
	{
		private static readonly string[] dmyItemName;
		private static readonly string[] dmyMonsName;
		public static readonly string[] dmyStrSetArr;
		public static readonly string[] dmyStrStdArr;
		private static readonly string[] dmyTokuseiName;
		private static readonly string[] dmyWazaName;
		
		// TODO
		public static string GetMonsName(MonsNo monsNo) { return default; }
		
		// TODO
		public static string GetWazaName(WazaNo wazaNo) { return default; }
		
		// TODO
		public static string GetTokuseiName(TokuseiNo tokuseiNo) { return default; }
		
		// TODO
		public static string GetItemName(ItemNo itemNo) { return default; }
		
		// TODO
		public static MonsNo GetMonsNo(string monsName) { return default; }
		
		// TODO
		public static WazaNo GetWazaNo(string wazaName) { return default; }
		
		// TODO
		public static TokuseiNo GetTokuseiNo(string tokuseiName) { return default; }
		
		// TODO
		public static ItemNo GetItemNo(string itemName) { return default; }
		
		// TODO
		private static string GetStringFromTable(string[] table, int index) { return default; }
		
		private static int GetIndexFromTable(string[] table, string s)
		{
			System_Array__IndexOf<string>(table,s);
			return 0;
		}
		
		// TODO: cctor
	}
}