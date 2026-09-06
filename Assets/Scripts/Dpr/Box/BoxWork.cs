namespace Dpr.Box
{
    public static class BoxWork
    {
        public const int TRAY_NUM_1ST = 18;
        public const int TRAY_NUM_2ND = 24;
        public const int TRAY_NUM_3RD = 30;
        public const int TRAY_NUM_4TH = 35;
        public const int TRAY_NUM_5TH = 40;
        public const int TRAY_MAX = 40;
        public const int TRAY_NAME_LEN = 16;
        public const int TRAY_NAME_BUFSIZE = 17;
        public const int TRAY_POKE_MAX = 30;
        public const int NORMAL_WALLPAPER_MAX = 32;
        private const int BATTLE_BOX_TRAY_NUMBER = 255;
        public const int TEAM_POKE_NONE = 65535;
        public const int TEAM_MAX = 6;
        public const int TEAM_POKE_MAX = 6;
        public const int TEAM_NAME_LEN = 10;
        public const int TEAM_NAME_BUFSIZE = 11;

        // TODO
        public static SaveBoxData m_boxData { get; }

        // TODO
        public static void SwapTray(int tray1, int tray2) { }

        // TODO
        public static void SetTrayName(string str, int tray) { }

        // TODO
        public static string GetTrayName(int tray) { return ""; }

        // TODO
        public static void ChangePokemon(int tray1, int pos1, int tray2, int pos2) { }

        // TODO
        public static void ChangeTeam(int tray1, int tray2) { }

        // TODO
        public static void SetTeamName(string str, int team) { }

        // TODO
        public static string GetTeamName(int team) { return ""; }

        // TODO
        public static int GetTeamPokeBoxTray(int team, int pos) { return 0; }

        // TODO
        public static int GetTeamPokeBoxPos(int team, int pos) { return 0; }

        // TODO
        public static bool IsTeam(int team) { return false; }

        // TODO
        public static bool IsTeamPos(int team, int pos) { return false; }

        // TODO
        public static bool IsPokeTeam(int tray, int pos) { return false; }

        // TODO
        public static bool IsPokeTeam(int tray, int pos, int team) { return false; }

        // TODO
        public static int GetPokeTeamPos(int tray, int pos, int team) { return 0; }

        // TODO
        public static int GetTeamPokeCount(int team) { return 0; }

        // TODO
        public static void DeleteTeam(int tray, int pos, bool isPack = false) { }

        // TODO
        public static void DeletePackTeam(int team, int pos) { }

        // TODO
        public static void PackTeam(int team) { }

        // TODO
        public static bool IsTeamLock(int team) { return false; }

        // TODO
        public static bool IsPokeLock(int tray, int pos) { return false; }

        // TODO
        public static int SetTeamPokePos(int team, int team_pos, int tray, int tray_pos) { return 0; }

        // TODO
        public static void SetTeamLock(int team, bool is_lock) { }

        // TODO
        public static void SetWallPaper(int tray, int val) { }

        // TODO
        public static int GetWallPaper(int tray) { return 0; }

        // TODO
        public static void SetTrayMax(int max) { }

        // TODO
        public static int GetOpenTrayMax() { return 0; }

        public static int GetTrayMax() {
            return 0x28;
        }

        // TODO
        public static void SetCurrentTray(int tray) { }

        // TODO
        public static int GetCurrentTray() { return 0; }

        // TODO
        public static void SetStatusPut(int mode) { }

        // TODO
        public static int GetStatusPut() { return 0; }
    }
}