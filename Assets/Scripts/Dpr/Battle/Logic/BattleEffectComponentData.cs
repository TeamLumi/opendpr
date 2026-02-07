using System.Runtime.InteropServices;
using XLSXContent;

namespace Dpr.Battle.Logic
{
    public sealed class BattleEffectComponentData
    {
        private string overwrappedBattleBGM;
        private string overwrappedWinBGM;
        private BattleDataTable.SheetBattleSetupEffectData data;
        private EffectBattleID _effectBattleID = EffectBattleID.NONE;
        private string _soundEventName;
        public string cmdSeqName;

        public EffectBattleID effectBattleID { get => _effectBattleID; set => _effectBattleID = value; }
        public string soundEventName { get => _soundEventName; set => _soundEventName = value; }
        public string battleBgm
        {
            get
            {
                if (!string.IsNullOrEmpty(overwrappedBattleBGM))
                    return overwrappedBattleBGM;

                return data?.BattleBGM ?? null;
            }
            set => overwrappedBattleBGM = value;
        }
        public string winBgm
        {
            get
            {
                if (!string.IsNullOrEmpty(overwrappedWinBGM))
                    return overwrappedWinBGM;

                return data?.WinBGM ?? null;
            }
            set => overwrappedWinBGM = value;
        }
        public int fadeType { get => data?.FadeType ?? -1; }

        private string ChooseCmdSeq(int index)
        {
            if (data?.CmdSeqName == null || data.CmdSeqName.Length == 0)
                return null;

            if (index < 0 || index >= data.CmdSeqName.Length)
                return data.CmdSeqName[0];

            return data.CmdSeqName[index];
        }

        public void SetUpBattleEffectComponentData(BattleSetupEffectId setupEffectId, [Optional, DefaultParameterValue(EffectBattleID.NONE)] EffectBattleID effectBattleId, [Optional, DefaultParameterValue(0)] int cmdSeqIndex, [Optional] string soundEventName)
        {
            var battleDataTable = BattleDataTableManager.Instance.BattleDataTable;
            if (battleDataTable != null && (int)setupEffectId >= 0 && (int)setupEffectId < battleDataTable.BattleSetupEffectData.Length)
                data = battleDataTable.BattleSetupEffectData[(int)setupEffectId];
            else
                data = null;

            cmdSeqName = ChooseCmdSeq(cmdSeqIndex);
            _effectBattleID = effectBattleId;
            _soundEventName = soundEventName;
        }

        public void SetUpBattleEffectComponentData_Tutorial()
        {
            SetUpBattleEffectComponentData(BattleSetupEffectId.WILD_SINGLE_TUTORIAL);
        }
    }
}