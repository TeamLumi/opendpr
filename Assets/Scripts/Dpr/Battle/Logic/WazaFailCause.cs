﻿namespace Dpr.Battle.Logic
{
    public enum WazaFailCause : byte
    {
        NONE = 0,
        PP_ZERO = 1,
        NEMURI = 2,
        MAHI = 3,
        KOORI = 4,
        KONRAN = 5,
        SHRINK = 6,
        KIAI_SHRINK = 7,
        MEROMERO = 8,
        KANASIBARI = 9,
        TYOUHATSU = 10,
        ICHAMON = 11,
        FUUIN = 12,
        KAIHUKUHUUJI = 13,
        HPFULL = 14,
        FUMIN = 15,
        NAMAKE = 16,
        WAZALOCK = 17,
        ENCORE = 18,
        TOKUSEI = 19,
        JURYOKU = 20,
        TO_RECOVER = 21,
        SABOTAGE = 22,
        SABOTAGE_GO_SLEEP = 23,
        SABOTAGE_SLEEPING = 24,
        NO_REACTION = 25,
        SKYBATTLE = 26,
        OOAME = 27,
        OOHIDERI = 28,
        IJIGEN_FOOPA = 29,
        IJIGEN_OTHER = 30,
        DARKHOLE_OTHER = 31,
        OORAGURUMA_OTHER = 32,
        ZIGOKUDUKI = 33,
        TRAPSHELL = 34,
        TARGET_IS_G = 35,
        TARGET_IS_RAIDBOSS = 36,
        USER_IS_RAIDBOSS = 37,
        UNEXPECTED_ERROR = 38,
        OTHER = 39,
        VS_JOKER2_PLAYER = 40,
        VS_JOKER2_JOKER = 41,
    }
}