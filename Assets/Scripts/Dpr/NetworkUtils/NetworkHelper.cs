using INL1;
using System;
using UnityEngine;

namespace Dpr.NetworkUtils
{
    public static class NetworkHelper
    {
        // TODO
        public static void InitNetworkData() { }

        // TODO
        public static void CheckOnlineAccountAsync(Action<bool> onComplete) { }

        // TODO
        public static bool IsFirstConnectInternet() { return false; }

        public static ushort CheckPlayerNum(ushort playerNum)
        {
        	if ((playerNum & 0xffff) < 2) {
        	  return 2;
        	}
        	if (0xf < (playerNum & 0xffff)) {
        	  playerNum = (ushort)0x10;
        	}
        	return (ushort)(playerNum);
        }

        // TODO
        public static ushort CreateContestGameMode(MatchingType matchingType, IlcaNetSessionNetworkType connectType) { return default; }

        public static ushort CreateUnderGroundGameMode(MatchingType matchingType, IlcaNetSessionNetworkType connectType, ushort UgMapGroupID)
        {
        	var uVar1 = (uint)(0x40002000100 >> (((int)matchingType & 3) << 4));
        	if (2 < (uint)matchingType) {
        	  uVar1 = 0;
        	}
        	return (ushort)(uVar1 | UgMapGroupID | 0x3000);
        }

        // TODO
        public static ushort CreateUnionGameMode(MatchingType matchingType, IlcaNetSessionNetworkType connectType) { return default; }

        public static ushort CreateBattleGameMode(MatchingType matchingType, BattleModeID battleModeID, IlcaNetSessionNetworkType connectType)
        {
        	var uVar1 = (uint)(0x240022002100 >> (((int)matchingType & 3) << 4));
        	if (2 < (uint)matchingType) {
        	  uVar1 = 0x2000;
        	}
        	var uVar2 = (uint)(0x4000200010 >> (((ulong)(battleModeID - 1U) & 3) << 4));
        	if (2 < (int)battleModeID - 1U) {
        	  uVar2 = 0;
        	}
        	return (ushort)(uVar1 | uVar2);
        }

        private static ushort GetMatchingBitByType(MatchingType matchingType)
        {
        	if ((int)matchingType < 3) {
        	  return (ushort)(0x40002000100 >> (((ulong)(int)matchingType & 3) << 4));
        	}
        	return 0;
        }

        private static ushort GetBattleModeBitByID(BattleModeID battleModeID)
        {
        	if (battleModeID - 1U < 3) {
        	  return (ushort)(0x4000200010 >> (((ulong)(battleModeID - 1U) & 3) << 4));
        	}
        	return 0;
        }

        // TODO
        private static void EmitGameModeLog(ushort gamemode) { }

        // TODO
        public static SessionErrorType ConvertIlcaNetUtilInternetGoResultToSessionErrorType(IlcaNetUtilInternetGoResult internetGoResult) { return default; }

        // TODO
        public static SessionErrorType ConvertIIlcaNetTransportErrorEnumToSessionErrorType(IlcaNetTransportErrorEnum transportError) { return default; }

        // TODO
        public static void EmitValidateError(IlcaNetServerValidate.CheckResponse checkResponse) { }

        // TODO
        public static void EmitNetworkLog(string log, LogType logType = LogType.Log) { }
    }
}