using Pml;
using Ug;
using XLSXContent;

public class UgEncountProc
{
	// TODO
	public static LotResult EncountLot(LotReuest lot) { return default; }
	
	// TODO
	private static PokeType LotType(UgRandMark.Sheettable tbl) { return default; }
	
	// TODO
	private static MonsSize[] LotSize(UgRandMark.Sheettable tbl, int lotcount) { return default; }
	
	private static int LotMonster(UgRandMark.Sheettable tbl, MonsSize size, PokeType type) {
	    return -1;
	}

	public enum ResultCode : int
	{
		Success = 0,
		Fail = 1,
	}

	public struct LotReuest
	{
		public int RandMarkID;
	}

	public struct LotResult
	{
		public ResultCode ResultCode;
		public int[] UgEncountIndex;
	}
}