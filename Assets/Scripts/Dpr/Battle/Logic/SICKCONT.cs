namespace Dpr.Battle.Logic
{
	public static class SICKCONT
	{
		// TODO
		public static BTL_SICKCONT MakeNull() { return default; }
		
		// TODO
		public static bool IsNull(in BTL_SICKCONT cont) { return default; }
		
		// TODO
		public static BTL_SICKCONT MakeTurn(byte causePokeID, byte turns) { return default; }
		
		// TODO
		public static BTL_SICKCONT MakeTurnParam(byte causePokeID, byte turns, ushort param) { return default; }
		
		// TODO
		public static BTL_SICKCONT MakePoke(byte causePokeID, byte pokeID) { return default; }
		
		// TODO
		public static BTL_SICKCONT MakePermanent(byte causePokeID) { return default; }
		
		// TODO
		public static BTL_SICKCONT MakePermanentInc(byte causePokeID, byte count_max) { return default; }
		
		// TODO
		public static BTL_SICKCONT MakePermanentParam(byte causePokeID, ushort param) { return default; }
		
		// TODO
		public static BTL_SICKCONT MakePermanentIncParam(byte causePokeID, byte count_max, ushort param) { return default; }
		
		// TODO
		public static BTL_SICKCONT MakePokeTurn(byte causePokeID, byte pokeID, byte turns) { return default; }
		
		// TODO
		public static BTL_SICKCONT MakePokeTurnParam(byte causePokeID, byte pokeID, byte turns, ushort param) { return default; }
		
		// TODO
		public static BTL_SICKCONT MakeMoudokuCont(byte causePokeID) { return default; }
		
		// TODO
		public static bool IsMoudokuCont(in BTL_SICKCONT cont) { return default; }
		
		// TODO
		public static byte GetPokeID(in BTL_SICKCONT cont) { return default; }
		
		public static void SetPokeID(ref BTL_SICKCONT cont, byte pokeID)
		{
			var cVar1 = cont.type;
			if (cVar1 == '\x03') {
			  cont.poke_ID = pokeID;
			}
			cVar1 = cont.type;
			if (cVar1 == '\x04') {
			  cont.poketurn_pokeID = pokeID;
			}
		}
		
		// TODO
		public static byte GetTurnMax(in BTL_SICKCONT cont) { return default; }
		
		public static void AddParam(ref BTL_SICKCONT cont, ushort param)
		{
			var cVar1 = cont.type;
			if (cVar1 == '\x01') {
			  cont.permanent_param = param;
			}
			cVar1 = cont.type;
			if (cVar1 == '\x03') {
			  cont.poke_param = param;
			}
			cVar1 = cont.type;
			if (cVar1 == '\x04') {
			  cont.poketurn_param = param;
			}
			cVar1 = cont.type;
			if (cVar1 == '\x02') {
			  cont.turn_param = param;
			}
		}
		
		// TODO
		public static ushort GetParam(in BTL_SICKCONT cont) { return default; }
		
		public static void SetFlag(ref BTL_SICKCONT cont, bool flag)
		{
			var cVar1 = cont.type;
			if (cVar1 == '\x01') {
			  cont.permanent_flag = (flag ? 1 : 0) & 1;
			}
			cVar1 = cont.type;
			if (cVar1 == '\x03') {
			  cont.poke_flag = (flag ? 1 : 0) & 1;
			}
			cVar1 = cont.type;
			if (cVar1 == '\x04') {
			  cont.poketurn_flag = (flag ? 1 : 0) & 1;
			}
			cVar1 = cont.type;
			if (cVar1 == '\x02') {
			  cont.turn_flag = (flag ? 1 : 0) & 1;
			}
		}
		
		// TODO
		public static bool GetFlag(in BTL_SICKCONT cont) { return default; }
		
		public static void IncTurn(ref BTL_SICKCONT cont, byte inc)
		{
			var cVar1 = cont.type;
			if (cVar1 == '\x02') {
			  var bVar2 = cont.turn_count;
			  if (bVar2 < 8) {
			    var iVar3 = cont.turn_count;
			    cont.turn_count = iVar3 + inc;
			  }
			}
			cVar1 = cont.type;
			if (cVar1 == '\x04') {
			  bVar2 = (byte)(cont.poketurn_count);
			  if (bVar2 < 8) {
			    iVar3 = cont.poketurn_count;
			    cont.poketurn_count = iVar3 + inc;
			  }
			}
		}
		
		public static void SetTurn(ref BTL_SICKCONT cont, byte turn)
		{
			var cVar1 = cont.type;
			if (cVar1 == '\x02') {
			  var bVar2 = cont.turn_count;
			  if (bVar2 < 8) {
			    cont.turn_count = turn;
			  }
			}
			cVar1 = cont.type;
			if (cVar1 == '\x04') {
			  bVar2 = (byte)(cont.poketurn_count);
			  if (bVar2 < 8) {
			    cont.poketurn_count = turn;
			  }
			}
		}
		
		// TODO
		public static byte GetCausePokeID(in BTL_SICKCONT cont) { return default; }
		
		public static void SetCausePokeID(ref BTL_SICKCONT cont, byte pokeID)
		{
			cont.causePokeID = pokeID;
		}
		
		// TODO
		public static void Split32bit(in BTL_SICKCONT cont, out uint high, out uint low)
		{
			high = default;
			low = default;
		}
		
		public static void Unite32bit(out BTL_SICKCONT cont, uint high, uint low)
		{
			cont = (ulong)low | high << 0x20;
		}
	}
}