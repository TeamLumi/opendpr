using Pml.PokePara;

namespace Dpr.Box
{
    public static class BoxPokemonWork
    {
        public const int TRAY_H_LINE = 5;
        public const int TRAY_W_LINE = 6;
        public const int TRAY_POKE_MAX = 30;
        public const int TRAY_MAX = 40;

        // TODO
        public static void GetPokemon(PokemonParam pp, int tray, int pos) { }

        // TODO
        public static PokemonParam GetPokemon(int tray, int pos) { return null; }

        // TODO
        public static bool CheckPokemon(int tray, int pos, PokemonParam tmp_pp, bool is_egg = true) { return false; }

        // TODO
        public static bool CheckPokemon(int tray, int pos, bool is_egg = true) { return false; }

        // TODO
        public static bool GetPokemonNullPos(int tray, out int pos, PokemonParam tmp_pp)
        {
            pos = 0;
            return false;
        }

        // TODO
        public static bool PutPokemonEmptyTrayAll(PokemonParam pp, PokemonParam tmp_pp, ref int tray, out int pos)
        {
            pos = 0;
            return false;
        }

        // TODO
        public static bool PutPokemonEmptyTrayAll(PokemonParam pp, ref int tray, out int pos)
        {
            pos = 0;
            return false;
        }

        // TODO
        public static bool PutPokemonEmptyTray(PokemonParam pp, PokemonParam tmp_pp, int tray, out int pos)
        {
            pos = 0;
            return false;
        }

        // TODO
        public static bool PutPokemonEmptyTray(PokemonParam pp, int tray, out int pos)
        {
            pos = 0;
            return false;
        }

        // TODO
        public static bool PutPokemon(PokemonParam pp, PokemonParam tmp_pp, int tray, int pos) { return false; }

        // TODO
        public static bool PutPokemon(PokemonParam pp, int tray, int pos) { return false; }

        // TODO
        private static bool PutPokemonImpl(PokemonParam pp, PokemonParam tmp_pp, int tray, int pos, bool isLogError = false) { return false; }

        // TODO
        public static void SwapPokemon(int tray1, int pos1, int tray2, int pos2) { }

        // TODO
        public static void SwapTray(int tray1, int tray2) { }

        // TODO
        public static void MovePokemon(int tray1, int pos1, int tray2, int pos2, int width, int height, PokemonParam tmp_pp) { }

        // TODO
        public static void UpdatePokemon(PokemonParam pp, int tray, int pos) { }

        // TODO
        public static void ClearPokemon(int tray, int pos, PokemonParam tmp_pp) { }

        // TODO
        public static void ClearPokemon(int tray, int pos) { }

        // TODO
        public static int GetPokemonCountAll(PokemonParam tmp_pp, bool is_egg = true) { return 0; }

        // TODO
        public static int GetPokemonCountAll(bool is_egg = true) { return 0; }

        // TODO
        public static int GetPokemonCount(int tray, PokemonParam tmp_pp, bool is_egg = true) { return 0; }

        // TODO
        public static int GetPokemonCount(int tray, bool is_egg = true) { return 0; }

        // TODO
        public static int GetSpaceCountAll(PokemonParam tmp_pp) { return 0; }

        // TODO
        public static int GetSpaceCountAll() { return 0; }

        // TODO
        public static int GetSpaceCount(int tray, PokemonParam tmp_pp) { return 0; }

        // TODO
        public static int GetSpaceCount(int tray) { return 0; }

        // TODO
        public static bool GetSpacePos(ref int tray, ref int pos, PokemonParam tmp_pp) { return false; }

        // TODO
        public static bool GetSpacePos(ref int tray, ref int pos) { return false; }

        // TODO
        public static int UpdateTrayMax(PokemonParam tmp_pp) { return 0; }

        // TODO
        public static int UpdateTrayMax() { return 0; }

        public static void RecoverAll()
        {
        	var uVar1 = new PokemonParam();
        	var iVar3 = 0;
        	var iVar4 = 0;
        	while( true ) {
        	  do {
        	    GetPokemon(uVar1,iVar3,iVar4);
        	    var uVar2 = uVar1.IsNull();
        	    if (((uVar2 & 1) == 0) && (uVar2 = uVar1.IsEgg(2), (uVar2 & 1) == 0)
        	       ) {
        	      uVar1.RecoverAll();
        	      UpdatePokemon(uVar1,iVar3,iVar4);
        	    }
        	    iVar4 = iVar4 + 1;
        	  } while (iVar4 != 0x1e);
        	  iVar3 = iVar3 + 1;
        	  if (iVar3 == 0x28) break;
        	  iVar4 = 0;
        	}
        }
    }
}