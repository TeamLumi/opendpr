using Pml.Personal;
using Pml.WazaData;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Pml.PokePara
{
    public class CoreParam
    {
        public const int DATASIZE = 328;
        private static byte[] sCoreSerializeBuffer = new byte[DATASIZE];
        private const byte TOKUSEI_INDEX_ERROR = 255;
        public const byte BIRTH_FRIENDSHIP = 100;
        protected byte[] m_coreData;
        protected byte[] m_calcData;
        protected Accessor m_accessor;

        public byte[] GetCoreData()
        {
            return m_coreData;
        }

        public byte[] GetCalcData()
        {
            return m_calcData;
        }

        public Accessor GetAccessor()
        {
            return m_accessor;
        }

        public static sbyte GetPowerTransformBySeikaku(ushort seikaku, PowerID powerId)
        {
            return CalcTool.GetPowerTransformBySeikaku(seikaku, powerId);
        }

        public static void CheckPublicDataSize()
        {
            GFL.ASSERT(true);
        }

        public static bool IsRareFromValue(uint id, uint colorRnd)
        {
            return CalcTool.IsRareColor(id, colorRnd);
        }

        public uint GetPower(PowerID powerId)
        {
            switch (powerId)
            {
                case PowerID.HP:
                    return GetMaxHp();

                case PowerID.ATK:
                    return GetAtk();

                case PowerID.DEF:
                    return GetDef();

                case PowerID.SPATK:
                    return GetSpAtk();

                case PowerID.SPDEF:
                    return GetSpDef();

                case PowerID.AGI:
                    return GetAgi();

                default:
                    GFL.ASSERT(false);
                    return 0;
            }
        }

        public uint GetMaxHp()
        {
            if (HaveCalcParam())
                return m_accessor.GetMaxHp();

            return CalcMaxHp_NotG();
        }

        public uint GetHp()
        {
            if (HaveCalcParam())
                return m_accessor.GetHp();

            return CalcMaxHp_NotG();
        }

        public void SetHp(uint value)
        {
            var max = m_accessor.GetMaxHp();
            var newhp = (ushort)(value <= max ? value : max);
            m_accessor.SetHp(newhp);
        }

        public void ReduceHp(uint value)
        {
            var max = m_accessor.GetMaxHp();
            var newhp = (ushort)((value > max || max - value == 0) ? 0 : (max - value));
            m_accessor.SetHp(newhp);
        }

        public void ReduceNowHp(uint value)
        {
            uint result = m_accessor.GetMaxHp();
            uint curr = m_accessor.GetHp();

            if (curr - value <= result)
                result = curr - value;
            if (curr <= value)
                result = 0;

            m_accessor.SetHp((ushort)result);
        }

        public void RecoverHp(uint value)
        {
            uint result = m_accessor.GetMaxHp();
            uint curr = m_accessor.GetHp();

            if ((uint)(curr + value) <= result)
                result = curr + value;

            m_accessor.SetHp((ushort)result);
        }

        public void RecoverHpFull()
        {
            m_accessor.SetHp((ushort)m_accessor.GetMaxHp());
        }

        public bool IsHpFull()
        {
            if (HaveCalcParam())
                return m_accessor.GetHp() == m_accessor.GetMaxHp();
            else
                return true;
        }

        public bool IsHpZero()
        {
            if (HaveCalcParam())
                return m_accessor.GetHp() == 0;

            return false;
        }

        public void RecoverAll()
        {
            RecoverHpFull();
            RecoverSick();
            RecoverWazaPPAll();
        }

        public void SetMaxHp(uint value)
        {
            m_accessor.SetMaxHp((ushort)value);
        }

        protected void SetAtk(ushort value)
        {
            m_accessor.SetAtk(value);
        }

        protected void SetDef(ushort value)
        {
            m_accessor.SetDef(value);
        }

        protected void SetSpAtk(ushort value)
        {
            m_accessor.SetSpAtk(value);
        }

        protected void SetSpDef(ushort value)
        {
            m_accessor.SetSpDef(value);
        }

        protected void SetAgi(ushort value)
        {
            m_accessor.SetAgi(value);
        }

        public bool HaveSick()
        {
            return GetSick() != Sick.NONE;
        }

        public Sick GetSick()
        {
            return (Sick)m_accessor.GetSick();
        }

        public void SetSick(Sick sick)
        {
            m_accessor.SetSick((uint)sick);
        }

        public void RecoverSick()
        {
            m_accessor.SetSick(0);
        }

        public uint GetLevel()
        {
            if (HaveCalcParam())
                return m_accessor.GetLevel();

            return CalcLevel();
        }

        public uint GetExp()
        {
            return m_accessor.GetExp();
        }

        public void SetExp(uint value)
        {
            PersonalSystem.LoadGrowTable(GetMonsNo(), GetFormNo());
            var maxExp = PersonalSystem.GetMinExp(PmlConstants.MAX_POKE_LEVEL);
            if (value > maxExp)
                value = maxExp;
            m_accessor.SetExp(value);
            if (HaveCalcParam())
                UpdateCalcDatas();
        }

        public void AddExp(uint value)
        {
            SetExp(GetExp() + value);
        }

        public uint GetExpForCurrentLevel()
        {
            PersonalSystem.LoadGrowTable(GetMonsNo(), GetFormNo());
            return PersonalSystem.GetMinExp((byte)GetLevel());
        }

        public uint GetExpForNextLevel()
        {
            var level = GetLevel();
            if (level >= PmlConstants.MAX_POKE_LEVEL)
                return GetExp();

            PersonalSystem.LoadGrowTable(GetMonsNo(), GetFormNo());
            return PersonalSystem.GetMinExp((byte)(level + 1));
        }

        public void LevelUp(byte upVal)
        {
            var level = GetLevel();
            var newLevel = level + upVal;
            if (newLevel > PmlConstants.MAX_POKE_LEVEL)
                newLevel = PmlConstants.MAX_POKE_LEVEL;

            PersonalSystem.LoadGrowTable(GetMonsNo(), GetFormNo());
            SetExp(PersonalSystem.GetMinExp((byte)newLevel));
        }

        public uint GetBasicPower(PowerID powerID)
        {
            PersonalSystem.LoadPersonalData(GetMonsNo(), GetFormNo());
            switch (powerID)
            {
                case PowerID.HP:
                    return PersonalSystem.GetPersonalParam(ParamID.BASIC_HP);
                case PowerID.ATK:
                    return PersonalSystem.GetPersonalParam(ParamID.BASIC_ATK);
                case PowerID.DEF:
                    return PersonalSystem.GetPersonalParam(ParamID.BASIC_DEF);
                case PowerID.SPATK:
                    return PersonalSystem.GetPersonalParam(ParamID.BASIC_SPATK);
                case PowerID.SPDEF:
                    return PersonalSystem.GetPersonalParam(ParamID.BASIC_SPDEF);
                case PowerID.AGI:
                    return PersonalSystem.GetPersonalParam(ParamID.BASIC_AGI);
                default:
                    GFL.ASSERT(false);
                    return 0;
            }
        }

        public uint GetNativeTalentPower(PowerID powerId)
        {
            switch (powerId)
            {
                case PowerID.HP:
                    return m_accessor.GetTalentHp();
                case PowerID.ATK:
                    return m_accessor.GetTalentAtk();
                case PowerID.DEF:
                    return m_accessor.GetTalentDef();
                case PowerID.SPATK:
                    return m_accessor.GetTalentSpAtk();
                case PowerID.SPDEF:
                    return m_accessor.GetTalentSpDef();
                case PowerID.AGI:
                    return m_accessor.GetTalentAgi();
                default:
                    GFL.ASSERT(false);
                    return 0;
            }
        }

        public uint GetTalentPower(PowerID powerId)
        {
            if ((int)powerId < 6)
            {
                byte flag = m_accessor.GetTrainingFlag();
                if ((flag & (1 << ((int)powerId & 0x1f))) != 0)
                    return PmlConstants.MAX_TALENT_POWER;
            }
            return GetNativeTalentPower(powerId);
        }

        public void ChangeTalentPower(PowerID powerId, uint value)
        {
            if (value > PmlConstants.MAX_TALENT_POWER)
                value = PmlConstants.MAX_TALENT_POWER;

            switch (powerId)
            {
                case PowerID.HP:
                    m_accessor.SetTalentHp((byte)value);
                    break;
                case PowerID.ATK:
                    m_accessor.SetTalentAtk((byte)value);
                    break;
                case PowerID.DEF:
                    m_accessor.SetTalentDef((byte)value);
                    break;
                case PowerID.SPATK:
                    m_accessor.SetTalentSpAtk((byte)value);
                    break;
                case PowerID.SPDEF:
                    m_accessor.SetTalentSpDef((byte)value);
                    break;
                case PowerID.AGI:
                    m_accessor.SetTalentAgi((byte)value);
                    break;
                default:
                    GFL.ASSERT(false);
                    break;
            }

            if (HaveCalcParam())
                UpdateCalcDatas();
        }

        public uint GetTalentPowerMaxNum()
        {
            uint count = 0;
            for (int i = 0; i < (int)PowerID.NUM; i++)
            {
                if (GetTalentPower((PowerID)i) >= PmlConstants.MAX_TALENT_POWER)
                    count++;
            }
            return count;
        }

        public bool IsTrainingDone(PowerID powerId)
        {
            byte flag = m_accessor.GetTrainingFlag();
            return (flag & (1 << (int)powerId)) != 0;
        }

        public void SetTrainingDone(PowerID powerId)
        {
            if ((int)powerId < 6)
            {
                byte flag = m_accessor.GetTrainingFlag();
                flag |= (byte)(1 << (int)powerId);
                m_accessor.SetTrainingFlag(flag);
                UpdateCalcDatas(true);
            }
            else
            {
                GFL.ASSERT(false);
            }
        }

        public uint GetEffortPower(PowerID powerId)
        {
            switch (powerId)
            {
                case PowerID.HP:
                    return m_accessor.GetEffortHp();
                case PowerID.ATK:
                    return m_accessor.GetEffortAtk();
                case PowerID.DEF:
                    return m_accessor.GetEffortDef();
                case PowerID.SPATK:
                    return m_accessor.GetEffortSpAtk();
                case PowerID.SPDEF:
                    return m_accessor.GetEffortSpDef();
                case PowerID.AGI:
                    return m_accessor.GetEffortAgi();
                default:
                    GFL.ASSERT(false);
                    return 0;
            }
        }

        public uint GetTotalEffortPower()
        {
            return m_accessor.GetEffortHp() +
                m_accessor.GetEffortAtk() +
                m_accessor.GetEffortDef() +
                m_accessor.GetEffortSpAtk() +
                m_accessor.GetEffortSpDef() +
                m_accessor.GetEffortAgi();
        }

        public void ChangeEffortPower(PowerID powerId, uint value)
        {
            value = AdjustEffortPower(GetEffortPower(powerId), value);

            switch (powerId)
            {
                case PowerID.HP:
                    m_accessor.SetEffortHp((byte)value);
                    break;
                case PowerID.ATK:
                    m_accessor.SetEffortAtk((byte)value);
                    break;
                case PowerID.DEF:
                    m_accessor.SetEffortDef((byte)value);
                    break;
                case PowerID.SPATK:
                    m_accessor.SetEffortSpAtk((byte)value);
                    break;
                case PowerID.SPDEF:
                    m_accessor.SetEffortSpDef((byte)value);
                    break;
                case PowerID.AGI:
                    m_accessor.SetEffortAgi((byte)value);
                    break;
                default:
                    GFL.ASSERT(false);
                    break;
            }

            if (HaveCalcParam())
                UpdateCalcDatas();
        }

        public void AddEffortPower(PowerID powerId, uint value)
        {
            ChangeEffortPower(powerId, GetEffortPower(powerId) + value);
        }

        public void SubEffortPower(PowerID powerId, uint value)
        {
            var current = GetEffortPower(powerId);
            ChangeEffortPower(powerId, current >= value ? current - value : 0);
        }

        public GState GetGState()
        {
            if (HaveCalcParam())
                return m_accessor.GetGState();

            return GState.NONE;
        }

        public void SetGState(GState state)
        {
            if (HaveCalcParam())
            {
                m_accessor.SetGState(state);
                UpdateCalcDatas();
            }
        }

        public bool IsG()
        {
            if (HaveCalcParam())
            {
                var state = GetGState();
                return state == GState.G_GENERAL || state == GState.G_SPECIAL;
            }

            return false;
        }

        public void ChangeEffortG(byte value)
        {
            if (value > PmlConstants.MAX_EFFORT_G)
                value = PmlConstants.MAX_EFFORT_G;
            m_accessor.SetEffortG(value);
        }

        public byte GetEffortG()
        {
            return (byte)m_accessor.GetEffortG();
        }

        public void AddEffortG(uint value)
        {
            var current = m_accessor.GetEffortG();
            var newval = current + value;
            if (newval > PmlConstants.MAX_EFFORT_G)
                newval = PmlConstants.MAX_EFFORT_G;
            m_accessor.SetEffortG((byte)newval);
        }

        public void SubEffortG(uint value)
        {
            var current = m_accessor.GetEffortG();
            m_accessor.SetEffortG((byte)(current >= value ? current - value : 0));
        }

        public uint GetPower_G(PowerID powerID)
        {
            // Gigantamax power calculation not implemented for BDSP
            return GetPower(powerID);
        }

        public uint GetPower_NotG(PowerID powerID)
        {
            return GetPower(powerID);
        }

        public bool IsSpecialGEnable()
        {
            return m_accessor.IsSpecialGEnable();
        }

        public void SetSpecialGEnable()
        {
            m_accessor.SetSpecialGFlag(true);
        }

        public void SetSpecialGDisable()
        {
            m_accessor.SetSpecialGFlag(false);
        }

        public MonsNo GetMonsNo()
        {
            return m_accessor.GetMonsNo();
        }

        public ushort GetFormNo()
        {
            return m_accessor.GetFormNo();
        }

        public void ChangeMonsNo(MonsNo newMonsno, ushort newFormno)
        {
            // TODO: Ghidra shows: early return if monsNo unchanged, sets MonsNo/FormNo,
            // recalculates tokusei index (IsTokusei2/3 flags -> CalcTool.GetTokuseiNo),
            // corrects sex via CalcTool.GetCorrectSexInPersonalData,
            // if no nickname set calls SetDefaultNickName, calls UpdateCalcDatas(keepDead=true)
            m_accessor.SetMonsNo((uint)newMonsno);
            m_accessor.SetFormNo(newFormno);
            if (HaveCalcParam())
                UpdateCalcDatas();
        }

        public WazaNo GetWazaNo(byte index)
        {
            return m_accessor.GetWazaNo(index);
        }

        public byte GetWazaCount()
        {
            byte count = 0;

            if (GetWazaNo(0) != WazaNo.NULL)
                count++;
            if (GetWazaNo(1) != WazaNo.NULL)
                count++;
            if (GetWazaNo(2) != WazaNo.NULL)
                count++;
            if (GetWazaNo(3) != WazaNo.NULL)
                count++;

            return count;
        }

        public bool HaveWaza(WazaNo wazano)
        {
            return GetWazaIndex(wazano) != 4;
        }

        public byte GetWazaIndex(WazaNo wazano)
        {
            if (GetWazaNo(0) == wazano)
                return 0;
            else if (GetWazaNo(1) == wazano)
                return 1;
            else if (GetWazaNo(2) == wazano)
                return 2;
            else if (GetWazaNo(3) == wazano)
                return 3;
            else
                return 4;
        }

        public void SetDefaultWaza()
        {
            PersonalSystem.LoadWazaOboeData(GetMonsNo(), GetFormNo());
            var oboeNum = PersonalSystem.GetWazaOboeNum();

            for (byte i = 0; i < PmlConstants.MAX_WAZA_NUM; i++)
            {
                m_accessor.SetWazaNo(i, (uint)WazaNo.NULL);
                m_accessor.SetPP(i, 0);
                m_accessor.SetWazaPPUpCount(i, 0);
            }

            for (ushort i = 0; i < oboeNum; i++)
            {
                var level = PersonalSystem.GetWazaOboeLevel(i);
                if (level > GetLevel())
                    break;

                var wazano = (WazaNo)PersonalSystem.GetWazaOboeWazaNo(i);
                var kind = PersonalSystem.GetWazaOboeKind(i);
                if (kind == OboeWazaKind.LEVEL || kind == OboeWazaKind.BASE)
                    PushWaza(wazano);
            }
        }

        public void PushWaza(WazaNo wazano)
        {
            if (HaveWaza(wazano))
                return;

            var count = GetWazaCount();
            if (count == PmlConstants.MAX_WAZA_NUM)
            {
                m_accessor.SetWazaNo(0, (uint)m_accessor.GetWazaNo(1));
                m_accessor.SetPP(0, m_accessor.GetPP(1));
                m_accessor.SetWazaPPUpCount(0, m_accessor.GetWazaPPUpCount(1));

                m_accessor.SetWazaNo(1, (uint)m_accessor.GetWazaNo(2));
                m_accessor.SetPP(1, m_accessor.GetPP(2));
                m_accessor.SetWazaPPUpCount(1, m_accessor.GetWazaPPUpCount(2));

                m_accessor.SetWazaNo(2, (uint)m_accessor.GetWazaNo(3));
                m_accessor.SetPP(2, m_accessor.GetPP(3));
                m_accessor.SetWazaPPUpCount(2, m_accessor.GetWazaPPUpCount(3));

                count = 3;
            }

            SetWaza(count, wazano);
        }

        public void SetWaza(byte wazaIndex, WazaNo wazano)
        {
            if (wazaIndex < PmlConstants.MAX_WAZA_NUM)
            {
                var pp = WazaDataSystem.s_wazaTable[(int)wazano].basePP;
                m_accessor.SetWazaNo(wazaIndex, (uint)wazano);
                m_accessor.SetWazaPPUpCount(wazaIndex, 0);
                m_accessor.SetPP(wazaIndex, pp);
            }
            else
            {
                GFL.ASSERT(false);
            }
        }

        public void RemoveWaza(byte wazaIndex)
        {
            if (wazaIndex < PmlConstants.MAX_WAZA_NUM)
            {
                m_accessor.SetWazaNo(wazaIndex, (uint)WazaNo.NULL);
                m_accessor.SetPP(wazaIndex, 0);
                m_accessor.SetWazaPPUpCount(wazaIndex, 0);
            }
        }

        public void RemoveDuplicatedWaza()
        {
            for (byte i = 0; i < PmlConstants.MAX_WAZA_NUM; i++)
            {
                var waza = GetWazaNo(i);
                if (waza == WazaNo.NULL)
                    continue;

                for (byte j = (byte)(i + 1); j < PmlConstants.MAX_WAZA_NUM; j++)
                {
                    if (GetWazaNo(j) == waza)
                        RemoveWaza(j);
                }
            }
        }

        public void ExchangeWazaPos(byte pos1, byte pos2)
        {
            if (pos1 >= PmlConstants.MAX_WAZA_NUM || pos2 >= PmlConstants.MAX_WAZA_NUM)
                return;

            var waza1 = m_accessor.GetWazaNo(pos1);
            var pp1 = m_accessor.GetPP(pos1);
            var upcount1 = m_accessor.GetWazaPPUpCount(pos1);

            m_accessor.SetWazaNo(pos1, (uint)m_accessor.GetWazaNo(pos2));
            m_accessor.SetPP(pos1, m_accessor.GetPP(pos2));
            m_accessor.SetWazaPPUpCount(pos1, m_accessor.GetWazaPPUpCount(pos2));

            m_accessor.SetWazaNo(pos2, (uint)waza1);
            m_accessor.SetPP(pos2, pp1);
            m_accessor.SetWazaPPUpCount(pos2, upcount1);
        }

        public void CloseUpWazaPos()
        {
            byte writePos = 0;
            for (byte readPos = 0; readPos < PmlConstants.MAX_WAZA_NUM; readPos++)
            {
                if (GetWazaNo(readPos) != WazaNo.NULL)
                {
                    if (writePos != readPos)
                    {
                        m_accessor.SetWazaNo(writePos, (uint)m_accessor.GetWazaNo(readPos));
                        m_accessor.SetPP(writePos, m_accessor.GetPP(readPos));
                        m_accessor.SetWazaPPUpCount(writePos, m_accessor.GetWazaPPUpCount(readPos));

                        m_accessor.SetWazaNo(readPos, (uint)WazaNo.NULL);
                        m_accessor.SetPP(readPos, 0);
                        m_accessor.SetWazaPPUpCount(readPos, 0);
                    }
                    writePos++;
                }
            }
        }

        public bool CheckWazaMachine(uint machineNo)
        {
            PersonalSystem.LoadPersonalData(GetMonsNo(), GetFormNo());
            return PersonalSystem.CheckPersonalWazaMachine((ushort)machineNo);
        }

        public bool CheckWazaRecord(uint recordNo)
        {
            PersonalSystem.LoadPersonalData(GetMonsNo(), GetFormNo());
            return PersonalSystem.CheckPersonalWazaRecord((ushort)recordNo);
        }

        public bool CheckWazaOshie(uint oshieNo)
        {
            PersonalSystem.LoadPersonalData(GetMonsNo(), GetFormNo());
            return PersonalSystem.CheckPersonalWazaOshie((ushort)oshieNo);
        }

        public bool CheckWazaOshie(WazaNo wazano)
        {
            for (int i = 0; i < PersonalSystem.GetOshieWazaNum(); i++)
            {
                if (PersonalSystem.GetOshieWazaNo(i) == wazano)
                    return CheckWazaOshie((uint)i);
            }
            return false;
        }

        public WazaNo GetTamagoWazaNo(byte index)
        {
            return m_accessor.GetTamagoWazaNo(index);
        }

        public void SetTamagoWazaNo(byte index, WazaNo wazano)
        {
            if (index < PmlConstants.MAX_WAZA_NUM)
                m_accessor.SetTamagoWazaNo(index, (uint)wazano);
            else
                GFL.ASSERT(false);
        }

        public void ClearTamagoWaza()
        {
            for (byte i = 0; i < PmlConstants.MAX_WAZA_NUM; i++)
                m_accessor.SetTamagoWazaNo(i, (uint)WazaNo.NULL);
        }

        public void InheriteTamagoWaza(CoreParam teacher)
        {
            // TODO: Ghidra shows completely different logic — checks if both Pokemon are same species,
            // creates EggWazaData, loads personal egg waza data, iterates teacher's REGULAR waza
            // (not tamago waza), checks each against egg waza data set, calls AddWazaIfEmptyExist
            // on the child for matching waza. Current implementation incorrectly copies tamago slots.
        }

        public WazaLearningResult AddWazaIfEmptyExist(WazaNo wazano)
        {
            if (HaveWaza(wazano))
                return WazaLearningResult.FAILED_SAME;

            var count = GetWazaCount();
            if (count >= PmlConstants.MAX_WAZA_NUM)
                return WazaLearningResult.FAILED_FULL;

            SetWaza(count, wazano);
            return WazaLearningResult.SUCCEEDED;
        }

        public WazaLearningResult LearnNewWazaOnCurrentLevel(ref uint sameLevelIndex, ref WazaNo newWazano, [Optional] WazaLearnWork work)
        {
            return LearnNewWazaOnLevel((byte)GetLevel(), ref sameLevelIndex, ref newWazano, work);
        }

        public WazaLearningResult LearnNewWazaOnLevel(byte level, ref uint sameLevelIndex, ref WazaNo newWazano, [Optional] WazaLearnWork work)
        {
            PersonalSystem.LoadWazaOboeData(GetMonsNo(), GetFormNo());
            var oboeNum = PersonalSystem.GetWazaOboeNum();

            uint matchCount = 0;
            for (ushort i = 0; i < oboeNum; i++)
            {
                var oboeLevel = PersonalSystem.GetWazaOboeLevel(i);
                if (oboeLevel != level)
                    continue;

                if (matchCount < sameLevelIndex)
                {
                    matchCount++;
                    continue;
                }

                var wazano = (WazaNo)PersonalSystem.GetWazaOboeWazaNo(i);

                if (work != null && work.IsCheckedWaza(wazano))
                    continue;

                if (work != null)
                    work.AddCheckedWaza(wazano);

                newWazano = wazano;
                sameLevelIndex = matchCount + 1;

                return AddWazaIfEmptyExist(wazano);
            }

            return WazaLearningResult.FAILED_NOT_EXIST;
        }

        public WazaLearningResult LearnNewWazaOnEvolution(ref uint learnIndex, ref WazaNo newWazano, [Optional] WazaLearnWork work)
        {
            PersonalSystem.LoadWazaOboeData(GetMonsNo(), GetFormNo());
            var oboeNum = PersonalSystem.GetWazaOboeNum();

            uint matchCount = 0;
            for (ushort i = 0; i < oboeNum; i++)
            {
                var kind = PersonalSystem.GetWazaOboeKind(i);
                if (kind != OboeWazaKind.EVOLVE)
                    continue;

                if (matchCount < learnIndex)
                {
                    matchCount++;
                    continue;
                }

                var wazano = (WazaNo)PersonalSystem.GetWazaOboeWazaNo(i);

                if (work != null && work.IsCheckedWaza(wazano))
                    continue;

                if (work != null)
                    work.AddCheckedWaza(wazano);

                newWazano = wazano;
                learnIndex = matchCount + 1;

                return AddWazaIfEmptyExist(wazano);
            }

            return WazaLearningResult.FAILED_NOT_EXIST;
        }

        public HashSet<WazaNo> CollectRemindableWaza()
        {
            // TODO: Ghidra shows: first adds 4 tamago waza, then iterates waza record flags
            // (0-98) — if a record flag is set, gets the corresponding waza from ItemManager
            // and adds it. Then three separate passes through waza oboe by kind (LEVEL, BASE,
            // EVOLVE) up to current level. Current implementation is missing waza record flag
            // iteration entirely and doesn't separate by OboeWazaKind.
            void CheckAndAddWazaNo(HashSet<WazaNo> list, WazaNo wazaNo)
            {
                if (wazaNo != WazaNo.NULL)
                    list.Add(wazaNo);
            }

            var result = new HashSet<WazaNo>();

            for (byte i = 0; i < PmlConstants.MAX_WAZA_NUM; i++)
                CheckAndAddWazaNo(result, GetTamagoWazaNo(i));

            PersonalSystem.LoadWazaOboeData(GetMonsNo(), GetFormNo());
            var oboeNum = PersonalSystem.GetWazaOboeNum();

            for (ushort i = 0; i < oboeNum; i++)
            {
                var level = PersonalSystem.GetWazaOboeLevel(i);
                if (level > GetLevel())
                    break;

                var wazano = (WazaNo)PersonalSystem.GetWazaOboeWazaNo(i);
                CheckAndAddWazaNo(result, wazano);
            }

            return result;
        }

        public uint GetWazaPP(byte wazaIndex)
        {
            return m_accessor.GetPP(wazaIndex);
        }

        public uint GetWazaMaxPP(byte index)
        {
            return WazaDataSystem.GetMaxPP(GetWazaNo(index), GetWazaPPUpCount(index));
        }

        public void SetWazaPP(byte wazaIndex, byte value)
        {
            var max = GetWazaMaxPP(wazaIndex);
            m_accessor.SetPP(wazaIndex, (byte)((value <= max) ? value : max));
        }

        public void ReduceWazaPP(byte wazaIndex, byte value)
        {
            var curr = GetWazaPP(wazaIndex);
            SetWazaPP(wazaIndex, (byte)(curr >= value ? curr - value : 0));
        }

        public void RecoverWazaPP(byte wazaIndex)
        {
            RecoverWazaPP(wazaIndex, (byte)GetWazaMaxPP(wazaIndex));
        }

        public void RecoverWazaPP(byte wazaIndex, byte recvValue)
        {
            if (m_accessor.GetWazaNo(wazaIndex) == WazaNo.NULL)
                return;

            var val = Math.Min(GetWazaPP(wazaIndex) + recvValue, GetWazaMaxPP(wazaIndex));
            SetWazaPP(wazaIndex, (byte)val);
        }

        public void RecoverWazaPPAll()
        {
            RecoverWazaPP(0);
            RecoverWazaPP(1);
            RecoverWazaPP(2);
            RecoverWazaPP(3);
        }

        public bool CanUsePointUp(byte wazaIndex)
        {
            if (GetWazaNo(wazaIndex) == WazaNo.NULL)
                return false;

            return GetWazaPPUpCount(wazaIndex) < PmlConstants.MAX_WAZAPP_UPCOUNT;
        }

        public void UsePointUp(byte wazaIndex)
        {
            if (!CanUsePointUp(wazaIndex))
                return;

            var count = (byte)(GetWazaPPUpCount(wazaIndex) + 1);
            m_accessor.SetWazaPPUpCount(wazaIndex, count);
            RecoverWazaPP(wazaIndex);
        }

        public uint GetWazaPPUpCount(byte wazaIndex)
        {
            return m_accessor.GetWazaPPUpCount(wazaIndex);
        }

        public void SetWazaPPUpCount(byte wazaIndex, byte value)
        {
            if (value > PmlConstants.MAX_WAZAPP_UPCOUNT)
                value = PmlConstants.MAX_WAZAPP_UPCOUNT;
            m_accessor.SetWazaPPUpCount(wazaIndex, value);
        }

        public void IncWazaPPUpCount(byte wazaIndex)
        {
            var count = GetWazaPPUpCount(wazaIndex);
            if (count < PmlConstants.MAX_WAZAPP_UPCOUNT)
                m_accessor.SetWazaPPUpCount(wazaIndex, (byte)(count + 1));
        }

        public bool GetWazaRecordFlag(byte recordIndex)
        {
            return m_accessor.GetWazaRecordFlag(recordIndex);
        }

        public void SetWazaRecordFlag(byte recordIndex)
        {
            m_accessor.SetWazaRecordFlag(recordIndex, true);
        }

        public void RemoveWazaRecordFlag(byte recordIndex)
        {
            m_accessor.SetWazaRecordFlag(recordIndex, false);
        }

        public void ClearWazaRecordFlag()
        {
            m_accessor.ClearWazaRecordFlag();
        }

        public void ClearBankUniqueID()
        {
            m_accessor.ClearBankUniqueID();
        }

        public ulong GetBankUniqueID()
        {
            return m_accessor.GetBankUniqueID();
        }

        public void SetBankUniqueID(ulong value)
        {
            m_accessor.SetBankUniqueID(value);
        }

        public Sex GetSex()
        {
            return m_accessor.GetSex();
        }

        public byte GetSexVector()
        {
            PersonalSystem.LoadPersonalData(GetMonsNo(), GetFormNo());
            return (byte)PersonalSystem.GetPersonalParam(ParamID.SEX);
        }

        public SexType GetSexType()
        {
            PersonalSystem.LoadPersonalData(GetMonsNo(), GetFormNo());
            return PersonalSystem.GetPersonalSexType();
        }

        public void ChangeSex(Sex newSex)
        {
            m_accessor.SetSex(newSex);
        }

        public Seikaku GetSeikaku()
        {
            return (Seikaku)m_accessor.GetSeikaku();
        }

        public void ChangeSeikaku(Seikaku seikaku)
        {
            m_accessor.SetSeikaku((uint)seikaku);
        }

        public bool IsSeikakuHigh()
        {
            return CalcTool.IsSeikakuHigh(GetSeikaku());
        }

        public bool IsSeikakuLow()
        {
            return CalcTool.IsSeikakuLow(GetSeikaku());
        }

        public Seikaku GetSeikakuHosei()
        {
            return (Seikaku)m_accessor.GetSeikakuHosei();
        }

        public void ChangeSeikakuHosei(Seikaku seikaku)
        {
            m_accessor.SetSeikakuHosei((uint)seikaku);
            if (HaveCalcParam())
                UpdateCalcDatas();
        }

        public TokuseiNo GetTokuseiNo()
        {
            return m_accessor.GetTokuseiNo();
        }

        public byte GetTokuseiIndex()
        {
            if (m_accessor.IsTokusei3())
                return 2;
            if (m_accessor.IsTokusei2())
                return 1;
            if (m_accessor.IsTokusei1())
                return 0;

            return TOKUSEI_INDEX_ERROR;
        }

        public byte GetTokuseiIndexStrict()
        {
            var tokuseiNo = (ushort)m_accessor.GetTokuseiNo();
            PersonalSystem.LoadPersonalData(GetMonsNo(), GetFormNo());

            if (tokuseiNo == PersonalSystem.GetPersonalParam(ParamID.TOKUSEI1))
                return 0;
            if (tokuseiNo == PersonalSystem.GetPersonalParam(ParamID.TOKUSEI2))
                return 1;
            if (tokuseiNo == PersonalSystem.GetPersonalParam(ParamID.TOKUSEI3))
                return 2;

            return TOKUSEI_INDEX_ERROR;
        }

        public void FlipTokuseiIndex()
        {
            var index = GetTokuseiIndex();
            if (index == 2)
                return;

            byte newIndex = (byte)(index == 0 ? 1 : 0);
            SetTokuseiIndex(newIndex);
        }

        public void SetTokusei3rd()
        {
            SetTokuseiIndex(2);
        }

        public void SetTokuseiIndex(byte tokuseiIndex)
        {
            PersonalSystem.LoadPersonalData(GetMonsNo(), GetFormNo());

            m_accessor.SetTokusei1Flag(tokuseiIndex == 0);
            m_accessor.SetTokusei2Flag(tokuseiIndex == 1);
            m_accessor.SetTokusei3Flag(tokuseiIndex == 2);

            var tokusei = CalcTool.GetTokuseiNo(GetMonsNo(), GetFormNo(), tokuseiIndex);
            m_accessor.SetTokuseiNo(tokusei);
        }

        public void SetFavoriteFlag(bool flag)
        {
            m_accessor.SetFavoriteFlag(flag);
        }

        public bool GetFavoriteFlag()
        {
            return m_accessor.IsFavorite();
        }

        public bool CompareOwnerInfo(OwnerInfo ownerInfo)
        {
            return (byte)m_accessor.GetOyasex() == ownerInfo.sex &&
                   m_accessor.GetID() == ownerInfo.trainerId &&
                   m_accessor.CompareOyaName(ownerInfo.name);
        }

        public bool UpdateOwnerInfo(OwnerInfo ownerInfo)
        {
            // TODO: Ghidra shows: if same owner -> SetOwnedOthersFlag(false), return true.
            // If different owner -> SetOwnedOthersFlag(true), copy PastParentsName/Sex/LangID,
            // reset OthersMemories (Level/Code/Data/Feel to 0), load personal data,
            // set OthersFriendship to base friendship from personal, return false.
            // Return value semantics are inverted vs current implementation.
            if (CompareOwnerInfo(ownerInfo))
                return false;

            m_accessor.SetOwnedOthersFlag(true);
            m_accessor.SetOthersFriendshipTrainerID((ushort)(ownerInfo.trainerId & 0xFFFF));
            return true;
        }

        public bool IsOwnedOriginalParent()
        {
            return !m_accessor.GetOwnedOthersFlag();
        }

        public bool HaveNickName()
        {
            return m_accessor.HaveNickName();
        }

        public string GetNickName()
        {
            return m_accessor.GetNickName();
        }

        public void SetNickName(string nickName)
        {
            m_accessor.SetNickName(nickName);
            m_accessor.SetNickNameFlag(true);
        }

        public void SetDefaultNickName()
        {
            var monsno = GetMonsNo();
            if (monsno != MonsNo.NULL)
            {
                var name = PersonalSystem.GetMonsName(monsno);
                m_accessor.SetNickName(name);
                m_accessor.SetNickNameFlag(false);
            }
        }

        public bool IsDefaultNickName()
        {
            return !m_accessor.HaveNickName();
        }

        public uint GetFriendship()
        {
            return m_accessor.GetFriendship();
        }

        public void SetFriendship(uint value)
        {
            if (value > PmlConstants.MAX_FRIENDSHIP)
                value = PmlConstants.MAX_FRIENDSHIP;
            m_accessor.SetFriendship((byte)value);
        }

        public void AddFriendship(uint value)
        {
            SetFriendship(GetFriendship() + value);
        }

        public void SubFriendship(uint value)
        {
            var curr = GetFriendship();
            SetFriendship(curr >= value ? curr - value : 0);
        }

        public uint GetOriginalFriendship()
        {
            return m_accessor.GetOriginalFriendship();
        }

        public void SetOriginalFriendship(uint value)
        {
            if (value > PmlConstants.MAX_FRIENDSHIP)
                value = PmlConstants.MAX_FRIENDSHIP;
            m_accessor.SetOriginalFriendship((byte)value);
        }

        public void AddOriginalFriendship(uint value)
        {
            SetOriginalFriendship(GetOriginalFriendship() + value);
        }

        public void SubOriginalFriendship(uint value)
        {
            var curr = GetOriginalFriendship();
            SetOriginalFriendship(curr >= value ? curr - value : 0);
        }

        public ushort GetOthersFriendshipTrainerID()
        {
            return m_accessor.GetOthersFriendshipTrainerID();
        }

        public uint GetOthersFriendship()
        {
            return m_accessor.GetOthersFriendship();
        }

        public void SetOthersFriendship(uint value)
        {
            if (value > PmlConstants.MAX_FRIENDSHIP)
                value = PmlConstants.MAX_FRIENDSHIP;
            m_accessor.SetOthersFriendship((byte)value);
        }

        public void AddOthersFriendship(uint value)
        {
            SetOthersFriendship(GetOthersFriendship() + value);
        }

        public void SubOthersFriendship(uint value)
        {
            var curr = GetOthersFriendship();
            SetOthersFriendship(curr >= value ? curr - value : 0);
        }

        public bool IsEgg(EggCheckType type)
        {
            bool egg = m_accessor.IsTamago();
            bool badEgg = m_accessor.IsFuseiTamago();

            switch (type)
            {
                case EggCheckType.ONLY_LEGAL_EGG:
                    return egg && !badEgg;
                case EggCheckType.ONLY_ILLEGAL_EGG:
                    return badEgg;
                case EggCheckType.BOTH_EGG:
                    return egg || badEgg;
                default:
                    GFL.ASSERT(false);
                    return false;
            }
        }

        public void SetEggFlag()
        {
            bool egg = m_accessor.IsTamago();
            bool badEgg = m_accessor.IsFuseiTamago();

            if (!badEgg)
                m_accessor.SetTamagoFlag(true);
        }

        public void ChangeEgg()
        {
            // TODO: Ghidra shows: checks IsFuseiTamago (returns if bad egg), sets TamagoFlag,
            // gets language ID and calls GetMonsName(0x1ee, langId) to set egg nickname,
            // sets NickNameFlag=false, loads personal data to get FRIENDSHIP_BIRTH param
            // and sets OriginalFriendship to that value (NOT SetFriendship)
            m_accessor.SetTamagoFlag(true);
            m_accessor.SetNickNameFlag(false);
            SetFriendship(BIRTH_FRIENDSHIP);
        }

        public void Birth()
        {
            // TODO: Ghidra shows: asserts IsTamago, sets TamagoFlag=false,
            // sets OriginalFriendship=120, sets LangId from PmlUse.Instance.LangId,
            // calls SetDefaultNickName, sets OwnedOthersFlag=false
            m_accessor.SetTamagoFlag(false);
            SetDefaultNickName();
        }

        public ushort GetItem()
        {
            return (ushort)m_accessor.GetItemNo();
        }

        public void SetItem(ushort itemno)
        {
            m_accessor.SetItemNo(itemno);
        }

        public void RemoveItem()
        {
            m_accessor.SetItemNo((ushort)ItemNo.DUMMY_DATA);
        }

        public void Evolve(MonsNo nextMonsno, uint routeIndex)
        {
            // TODO: Ghidra shows: loads evolution table, asserts evolved mons matches nextMonsno,
            // checks form specification, calls ChangeMonsNo (which itself needs fixing),
            // then checks evolution condition — if it matches item-consuming types
            // (conditions 6, 18, 33, 45), removes the held item via SetItemNo(0).
            // Tokusei recalculation is handled inside ChangeMonsNo in the binary.
            PersonalSystem.LoadEvolutionTable(GetMonsNo(), GetFormNo());
            var formno = PersonalSystem.GetEvolvedFormNo((byte)routeIndex);
            if (!PersonalSystem.IsEvolvedFormNoSpecified((byte)routeIndex))
                formno = GetFormNo();

            ChangeMonsNo(nextMonsno, formno);

            PersonalSystem.LoadPersonalData(nextMonsno, formno);
            var tokuseiIndex = GetTokuseiIndex();
            if (tokuseiIndex != 2)
            {
                var tokusei = CalcTool.GetTokuseiNo(nextMonsno, formno, tokuseiIndex);
                m_accessor.SetTokuseiNo(tokusei);
            }
            else
            {
                var tokusei = CalcTool.GetTokuseiNo(nextMonsno, formno, 2);
                m_accessor.SetTokuseiNo(tokusei);
            }
        }

        public bool CanEvolve(EvolveSituation situation, PokeParty party, ref MonsNo nextMonsno, ref uint rootNum)
        {
            // Evolution checking is complex and depends on EvolveManager
            // Stub for now - full implementation requires EvolveManager
            return false;
        }

        public bool CanEvolveByItem(EvolveSituation situation, ushort itemno, ref MonsNo nextMonsno, ref uint rootNum)
        {
            return false;
        }

        public bool CanEvolveByTrade(CoreParam pairPoke, ref MonsNo nextMonsno, ref uint rootNum)
        {
            return false;
        }

        public bool CanEvolveByEvent(EvolveSituation situation, PokeParty party, ref MonsNo nextMonsno, ref uint rootNum)
        {
            return false;
        }

        public bool HaveEvolutionRoot()
        {
            PersonalSystem.LoadEvolutionTable(GetMonsNo(), GetFormNo());
            return PersonalSystem.GetEvolutionRouteNum() > 0;
        }

        public void ChangeFormNo(ushort nextFormno, [Optional] FormChangeResult pResult)
        {
            m_accessor.SetFormNo(nextFormno);

            PersonalSystem.LoadPersonalData(GetMonsNo(), nextFormno);
            var tokuseiIndex = GetTokuseiIndex();
            var tokusei = CalcTool.GetTokuseiNo(GetMonsNo(), nextFormno, tokuseiIndex);
            m_accessor.SetTokuseiNo(tokusei);

            changeWazaByFormChange(nextFormno, pResult);

            if (HaveCalcParam())
                UpdateCalcDatas();
        }

        public ushort GetNextFormNoFromHoldItem(ushort holdItemno)
        {
            if (CalcTool.DecideFormNoFromHoldItem(GetMonsNo(), holdItemno, out ushort formno))
                return formno;
            return GetFormNo();
        }

        public bool RegulateFormParams()
        {
            var formno = GetFormNo();
            PersonalSystem.LoadPersonalData(GetMonsNo(), formno);
            var maxForm = PersonalSystem.GetPersonalParam(ParamID.FORM_MAX);
            if (formno >= maxForm && maxForm > 0)
            {
                m_accessor.SetFormNo(0);
                return true;
            }
            return false;
        }

        public bool IsRare()
        {
            return CalcTool.IsRareColor(m_accessor.GetID(), m_accessor.GetColorRnd());
        }

        public uint GetRareRnd()
        {
            return m_accessor.GetColorRnd();
        }

        public RareType GetRareType()
        {
            return CalcTool.CalcRareColorType(m_accessor.GetID(), m_accessor.GetColorRnd(),
                m_accessor.GetCassetteVersion(), m_accessor.IsEventPokemon());
        }

        public uint GetID()
        {
            return m_accessor.GetID();
        }

        public uint GetPersonalRnd()
        {
            return m_accessor.GetPersonalRnd();
        }

        public uint GetCheckSum()
        {
            return m_accessor.GetCheckSum();
        }

        public void SetID(uint id)
        {
            m_accessor.SetID(id);
        }

        public void SetRare()
        {
            var rnd = CalcTool.CorrectColorRndForRare(m_accessor.GetID(), m_accessor.GetColorRnd());
            m_accessor.SetColorRnd(rnd);
        }

        public void SetNotRare()
        {
            var rnd = CalcTool.CorrectColorRndForNormal(m_accessor.GetID(), m_accessor.GetColorRnd());
            m_accessor.SetColorRnd(rnd);
        }

        public void SetRareType(RareType type)
        {
            var rnd = CalcTool.CorrectColorRndForRareType(m_accessor.GetID(), m_accessor.GetColorRnd(), type);
            m_accessor.SetColorRnd(rnd);
        }

        public PokeType GetType1()
        {
            PersonalSystem.LoadPersonalData(GetMonsNo(), GetFormNo());
            return (PokeType)PersonalSystem.GetPersonalParam(ParamID.TYPE1);
        }

        public PokeType GetType2()
        {
            PersonalSystem.LoadPersonalData(GetMonsNo(), GetFormNo());
            return (PokeType)PersonalSystem.GetPersonalParam(ParamID.TYPE2);
        }

        public string GetParentName()
        {
            return m_accessor.GetOyaName();
        }

        public void SetParentName(string name)
        {
            m_accessor.SetOyaName(name);
        }

        public Sex GetParentSex()
        {
            return m_accessor.GetOyasex();
        }

        public void SetParentSex(Sex sex)
        {
            m_accessor.SetOyasex(sex);
        }

        public uint GetMemories(Memories memoriesKind)
        {
            switch (memoriesKind)
            {
                case Memories.EGG_TAKEN_YEAR:
                    return m_accessor.GetTamagoGetYear();
                case Memories.EGG_TAKEN_MONTH:
                    return m_accessor.GetTamagoGetMonth();
                case Memories.EGG_TAKEN_DAY:
                    return m_accessor.GetTamagoGetDay();
                case Memories.FIRST_CONTACT_YEAR:
                    return m_accessor.GetBirthYear();
                case Memories.FIRST_CONTACT_MONTH:
                    return m_accessor.GetBirthMonth();
                case Memories.FIRST_CONTACT_DAY:
                    return m_accessor.GetBirthDay();
                case Memories.EGG_TAKEN_PLACE:
                    return m_accessor.GetBirthPlace();
                case Memories.FIRST_CONTACT_PLACE:
                    return m_accessor.GetGetPlace();
                case Memories.CAPTURED_BALL:
                    return m_accessor.GetGetBall();
                case Memories.CAPTURED_LEVEL:
                    return m_accessor.GetGetLevel();
                case Memories.LEVEL_WITH_PARENT:
                    return m_accessor.GetMemoriesLevel();
                case Memories.CODE_WITH_PARENT:
                    return m_accessor.GetMemoriesCode();
                case Memories.DATA_WITH_PARENT:
                    return m_accessor.GetMemoriesData();
                case Memories.FEEL_WITH_PARENT:
                    return m_accessor.GetMemoriesFeel();
                case Memories.LEVEL_WITH_OTHERS:
                    return m_accessor.GetOthersMemoriesLevel();
                case Memories.CODE_WITH_OTHERS:
                    return m_accessor.GetOthersMemoriesCode();
                case Memories.DATA_WITH_OTHERS:
                    return m_accessor.GetOthersMemoriesData();
                case Memories.FEEL_WITH_OTHERS:
                    return m_accessor.GetOthersMemoriesFeel();
                default:
                    GFL.ASSERT(false);
                    return 0;
            }
        }

        public void SetMemories(Memories memoriesKind, uint value)
        {
            switch (memoriesKind)
            {
                case Memories.EGG_TAKEN_YEAR:
                    m_accessor.SetTamagoGetYear((byte)value);
                    break;
                case Memories.EGG_TAKEN_MONTH:
                    m_accessor.SetTamagoGetMonth((byte)value);
                    break;
                case Memories.EGG_TAKEN_DAY:
                    m_accessor.SetTamagoGetDay((byte)value);
                    break;
                case Memories.FIRST_CONTACT_YEAR:
                    m_accessor.SetBirthYear((byte)value);
                    break;
                case Memories.FIRST_CONTACT_MONTH:
                    m_accessor.SetBirthMonth((byte)value);
                    break;
                case Memories.FIRST_CONTACT_DAY:
                    m_accessor.SetBirthDay((byte)value);
                    break;
                case Memories.EGG_TAKEN_PLACE:
                    m_accessor.SetBirthPlace((ushort)value);
                    break;
                case Memories.FIRST_CONTACT_PLACE:
                    m_accessor.SetGetPlace((ushort)value);
                    break;
                case Memories.CAPTURED_BALL:
                    m_accessor.SetGetBall((byte)value);
                    break;
                case Memories.CAPTURED_LEVEL:
                    m_accessor.SetGetLevel((byte)value);
                    break;
                case Memories.LEVEL_WITH_PARENT:
                    m_accessor.SetMemoriesLevel((byte)value);
                    break;
                case Memories.CODE_WITH_PARENT:
                    m_accessor.SetMemoriesCode((byte)value);
                    break;
                case Memories.DATA_WITH_PARENT:
                    m_accessor.SetMemoriesData((ushort)value);
                    break;
                case Memories.FEEL_WITH_PARENT:
                    m_accessor.SetMemoriesFeel((byte)value);
                    break;
                case Memories.LEVEL_WITH_OTHERS:
                    m_accessor.SetOthersMemoriesLevel((byte)value);
                    break;
                case Memories.CODE_WITH_OTHERS:
                    m_accessor.SetOthersMemoriesCode((byte)value);
                    break;
                case Memories.DATA_WITH_OTHERS:
                    m_accessor.SetOthersMemoriesData((ushort)value);
                    break;
                case Memories.FEEL_WITH_OTHERS:
                    m_accessor.SetOthersMemoriesFeel((byte)value);
                    break;
                default:
                    GFL.ASSERT(false);
                    break;
            }
        }

        public string GetPastParentsName()
        {
            return m_accessor.GetPastParentsName();
        }

        public void SetPastParentsName(string name)
        {
            m_accessor.SetPastParentsName(name);
        }

        public Sex GetPastParentsSex()
        {
            return m_accessor.GetPastParentsSex();
        }

        public void SetPastParentsSex(Sex sex)
        {
            m_accessor.SetPastParentsSex(sex);
        }

        public byte GetPastParentsLangID()
        {
            return m_accessor.GetPastParentsLangID();
        }

        public void SetPastParentsLangID(byte langID)
        {
            m_accessor.SetPastParentsLangID(langID);
        }

        public byte GetCondition(Condition cond)
        {
            switch (cond)
            {
                case Condition.STYLE:
                    return m_accessor.GetStyle();
                case Condition.BEAUTIFUL:
                    return m_accessor.GetBeautiful();
                case Condition.CUTE:
                    return m_accessor.GetCute();
                case Condition.CLEVER:
                    return m_accessor.GetClever();
                case Condition.STRONG:
                    return m_accessor.GetStrong();
                case Condition.FUR:
                    return m_accessor.GetFur();
                default:
                    GFL.ASSERT(false);
                    return 0;
            }
        }

        public void SetCondition(Condition cond, byte value)
        {
            switch (cond)
            {
                case Condition.STYLE:
                    m_accessor.SetStyle(value);
                    break;
                case Condition.BEAUTIFUL:
                    m_accessor.SetBeautiful(value);
                    break;
                case Condition.CUTE:
                    m_accessor.SetCute(value);
                    break;
                case Condition.CLEVER:
                    m_accessor.SetClever(value);
                    break;
                case Condition.STRONG:
                    m_accessor.SetStrong(value);
                    break;
                case Condition.FUR:
                    m_accessor.SetFur(value);
                    break;
                default:
                    GFL.ASSERT(false);
                    break;
            }
        }

        public bool IsBoxMarkSet()
        {
            return m_accessor.GetBoxMark() != 0;
        }

        public bool IsBoxMarkSet(BoxMark mark)
        {
            return GetBoxMark(mark) != BoxMarkColor.NONE;
        }

        public void SetBoxMark(BoxMark mark, BoxMarkColor color)
        {
            var bits = m_accessor.GetBoxMark();
            int shift = (int)mark * 2;
            bits = (ushort)((bits & ~(3 << shift)) | ((int)color << shift));
            m_accessor.SetBoxMark(bits);
        }

        public void RemoveBoxMark(BoxMark mark)
        {
            SetBoxMark(mark, BoxMarkColor.NONE);
        }

        public BoxMarkColor GetBoxMark(BoxMark mark)
        {
            var bits = m_accessor.GetBoxMark();
            int shift = (int)mark * 2;
            return (BoxMarkColor)((bits >> shift) & 3);
        }

        public void RemoveAllBoxMark()
        {
            m_accessor.SetBoxMark(0);
        }

        public void SetAllBoxMark(BoxMarkContainer markContainer)
        {
            for (int i = 0; i < (int)BoxMark.MARK_NUM; i++)
                SetBoxMark((BoxMark)i, markContainer.markColor[i]);
        }

        public void GetAllBoxMark(BoxMarkContainer markContainer)
        {
            for (int i = 0; i < (int)BoxMark.MARK_NUM; i++)
                markContainer.markColor[i] = GetBoxMark((BoxMark)i);
        }

        public uint GetLangId()
        {
            return m_accessor.GetLangId();
        }

        public void SetLangId(uint langId)
        {
            m_accessor.SetLangId((byte)langId);
        }

        public uint GetCassetteVersion()
        {
            return m_accessor.GetCassetteVersion();
        }

        public void SetCassetteVersion(uint version)
        {
            m_accessor.SetCassetteVersion(version);
        }

        public uint GetGetBall()
        {
            return m_accessor.GetGetBall();
        }

        public void SetGetBall(uint value)
        {
            m_accessor.SetGetBall((byte)value);
        }

        public byte GetBattleRomMark()
        {
            return m_accessor.GetBattleRomMark();
        }

        public void SetBattleRomMark(byte battleRomMark)
        {
            m_accessor.SetBattleRomMark(battleRomMark);
        }

        public byte GetNadenadeValue()
        {
            return m_accessor.GetNadenadeValue();
        }

        public void SetNadenadeValue(byte value)
        {
            if (value > PmlConstants.MAX_NADENADE_VALUE)
                value = PmlConstants.MAX_NADENADE_VALUE;
            m_accessor.SetNadenadeValue(value);
        }

        public void AddNadenadeValue(byte value)
        {
            var curr = GetNadenadeValue();
            var newval = curr + value;
            SetNadenadeValue((byte)(newval > PmlConstants.MAX_NADENADE_VALUE ? PmlConstants.MAX_NADENADE_VALUE : newval));
        }

        public void SubNadenadeValue(byte value)
        {
            var curr = GetNadenadeValue();
            SetNadenadeValue((byte)(curr >= value ? curr - value : 0));
        }

        public PokeType GetMezapaType()
        {
            return CalcTool.CalcMezamerupawaaType(
                (byte)m_accessor.GetTalentHp(),
                (byte)m_accessor.GetTalentAtk(),
                (byte)m_accessor.GetTalentDef(),
                (byte)m_accessor.GetTalentAgi(),
                (byte)m_accessor.GetTalentSpAtk(),
                (byte)m_accessor.GetTalentSpDef());
        }

        public uint GetMezapaPower()
        {
            return CalcTool.CalcMezamerupawaaPower(
                (byte)m_accessor.GetTalentHp(),
                (byte)m_accessor.GetTalentAtk(),
                (byte)m_accessor.GetTalentDef(),
                (byte)m_accessor.GetTalentAgi(),
                (byte)m_accessor.GetTalentSpAtk(),
                (byte)m_accessor.GetTalentSpDef());
        }

        public TasteJudge JudgeTaste(Taste taste)
        {
            return CalcTool.JudgeTaste(GetSeikakuHosei(), taste);
        }

        public bool HaveRibbon(uint ribbonNo)
        {
            return m_accessor.HaveRibbon(ribbonNo);
        }

        public void SetRibbon(uint ribbonNo)
        {
            m_accessor.SetRibbon(ribbonNo);
        }

        public void RemoveRibbon(uint ribbonNo)
        {
            m_accessor.RemoveRibbon(ribbonNo);
        }

        public void RemoveAllRibbon()
        {
            m_accessor.RemoveAllRibbon();
        }

        public void SetLumpingRibbon(LumpingRibbon ribbonId, uint num)
        {
            m_accessor.SetLumpingRibbon(ribbonId, num);
        }

        public void SetLumpingRibbon(uint ribbonNo, uint num)
        {
            // Map ribbon number to lumping ribbon ID based on ribbon ranges
            if (ribbonNo < (uint)LumpingRibbon.NUM)
                m_accessor.SetLumpingRibbon((LumpingRibbon)ribbonNo, num);
        }

        public uint GetLumpingRibbon(LumpingRibbon ribbonId)
        {
            return m_accessor.GetLumpingRibbon(ribbonId);
        }

        public uint GetLumpingRibbon(uint ribbonNo)
        {
            if (ribbonNo < (uint)LumpingRibbon.NUM)
                return m_accessor.GetLumpingRibbon((LumpingRibbon)ribbonNo);
            return 0;
        }

        public bool IsEquipRibbonExist()
        {
            return m_accessor.GetEquipRibbonNo() != PmlConstants.EQUIP_RIBBON_NULL;
        }

        public byte GetEquipRibbonNo()
        {
            return m_accessor.GetEquipRibbonNo();
        }

        public void SetEquipRibbonNo(byte ribbonNo)
        {
            m_accessor.SetEquipRibbonNo(ribbonNo);
        }

        public bool HavePokerusJustNow()
        {
            return (m_accessor.GetPokerus() & 0xF) != 0;
        }

        public bool HavePokerusUntilNow()
        {
            return (m_accessor.GetPokerus() & 0xFF) != 0;
        }

        public bool HavePokerusPast()
        {
            return !HavePokerusJustNow() && ((m_accessor.GetPokerus() >> 4) & 0xF) != 0;
        }

        public void CatchPokerus()
        {
            // Random pokerus strain and duration
            var strain = (byte)((Local.Random.GetValue(4) + 1) << 4);
            var duration = (byte)((strain >> 4) % 4 + 1);
            m_accessor.SetPokerus((byte)(strain | duration));
        }

        public void InfectPokerusWith(CoreParam target)
        {
            target.SetPokerus(GetPokerus());
        }

        public void DecreasePokerusDayCount(int passedDayCount)
        {
            var pokerus = m_accessor.GetPokerus();
            var duration = (int)(pokerus & 0xF);
            duration -= passedDayCount;
            if (duration < 0)
                duration = 0;
            m_accessor.SetPokerus((byte)((pokerus & 0xF0) | duration));
        }

        public uint GetPokerus()
        {
            return m_accessor.GetPokerus();
        }

        public void SetPokerus(uint pokerus)
        {
            m_accessor.SetPokerus((byte)pokerus);
        }

        public bool GetEventPokeFlag()
        {
            return m_accessor.IsEventPokemon();
        }

        public void SetEventPokeFlag(bool flag)
        {
            m_accessor.SetEventPokemonFlag(flag);
        }

        public bool HaveOfficialBattleRights()
        {
            return m_accessor.GetOfficialBattleEnableFlag();
        }

        public void GrantOfficialBattleRights()
        {
            SetDefaultWaza();
            m_accessor.SetTamagoWazaNo(0, (uint)WazaNo.NULL);
            m_accessor.SetTamagoWazaNo(1, (uint)WazaNo.NULL);
            m_accessor.SetTamagoWazaNo(2, (uint)WazaNo.NULL);
            m_accessor.SetTamagoWazaNo(3, (uint)WazaNo.NULL);
            m_accessor.SetOfficialBattleEnableFlag(true);
        }

        public void RemoveAllRotomWaza()
        {
            var rotomWaza = CalcTool.GetRotomuWazaNo(GetFormNo());
            if (rotomWaza != WazaNo.NULL)
            {
                var idx = GetWazaIndex(rotomWaza);
                if (idx < PmlConstants.MAX_WAZA_NUM)
                    RemoveWaza(idx);
            }
        }

        public void SetRotomWaza(byte wazaIndex)
        {
            var formno = GetFormNo();
            var rotomWaza = CalcTool.GetRotomuWazaNo(formno);
            if (rotomWaza != WazaNo.NULL && wazaIndex < PmlConstants.MAX_WAZA_NUM)
                SetWaza(wazaIndex, rotomWaza);
        }

        public LoveLevel CheckLoveLevel(CoreParam partner)
        {
            return CalcTool.CalcLoveLevel(GetMonsNo(), GetID(), partner.GetMonsNo(), partner.GetID());
        }

        public bool GetPokeJobFlag(byte jobIndex)
        {
            return m_accessor.GetPokeJobFlag(jobIndex);
        }

        public void SetPokeJobFlag(byte jobIndex)
        {
            m_accessor.SetPokeJobFlag(jobIndex, true);
        }

        public void RemovePokeJobFlag(byte jobIndex)
        {
            m_accessor.SetPokeJobFlag(jobIndex, false);
        }

        public void ClearPokeJobFlag()
        {
            m_accessor.ClearPokeJobFlag();
        }

        public byte GetCampFriendship()
        {
            return m_accessor.GetCampFriendship();
        }

        public void SetCampFriendship(uint value)
        {
            value = (value >= PmlConstants.MAX_CAMP_FRIENDSHIP) ? PmlConstants.MAX_CAMP_FRIENDSHIP : value;
            m_accessor.SetCampFriendship((byte)value);
        }

        public void AddCampFriendship(uint value)
        {
            SetCampFriendship(GetCampFriendship() + value);
        }

        public void SubCampFriendship(uint value)
        {
            var camp = GetCampFriendship();

            var newval = (camp < value) ? 0 : (camp - value);
            SetCampFriendship(newval);
        }

        public byte GetEnjoy()
        {
            return m_accessor.GetEnjoy();
        }

        public void SetEnjoy(uint value)
        {
            value = (value >= PmlConstants.MAX_ENJOY) ? PmlConstants.MAX_ENJOY : value;
            m_accessor.SetEnjoy((byte)value);
        }

        public void AddEnjoy(byte value)
        {
            SetEnjoy((byte)(GetEnjoy() + value));
        }

        public void SubEnjoy(byte value)
        {
            var enjoy = GetEnjoy();
            if (enjoy < value)
                m_accessor.SetEnjoy(0);
            else
                SetEnjoy((byte)(enjoy - value));
        }

        public uint GetPalma()
        {
            return m_accessor.GetPalma();
        }

        public void SetPalma(uint value)
        {
            m_accessor.SetPalma(value);
        }

        public bool GetDprIllegalFlag()
        {
            return m_accessor.GetDprIllegalFlag();
        }

        public void SetDprIllegalFlag(bool flag)
        {
            m_accessor.SetDprIllegalFlag(flag);
        }

        public bool StartFastMode()
        {
            if (IsFastMode())
                return false;

            m_accessor.StartFastMode();
            return true;
        }

        public bool EndFastMode(bool validFlag)
        {
            if (!IsFastMode() || !validFlag)
                return false;

            m_accessor.EndFastMode();
            return true;
        }

        public bool IsFastMode()
        {
            return m_accessor.IsFastMode();
        }

        public void Clear()
        {
            m_accessor.ClearData();
        }

        public bool IsNull()
        {
            return m_accessor.GetMonsNo() == MonsNo.NULL;
        }

        public bool HaveCalcParam()
        {
            return m_accessor.HaveCalcData();
        }

        public void CopyFrom(CoreParam pSrcParam)
        {
            pSrcParam.Serialize_Core(sCoreSerializeBuffer);
            Deserialize_Core(sCoreSerializeBuffer);
        }

        public void RecalculateCalcData()
        {
            UpdateCalcDatas();
        }

        public virtual unsafe void Serialize_Core(void* buffer)
        {
            m_accessor.Serialize_CoreData(buffer);
        }

        public virtual void Serialize_Core(byte[] buffer)
        {
            m_accessor.Serialize_CoreData(buffer);
        }

        public virtual unsafe void Deserialize_Core(void* serializedData)
        {
            m_accessor.Deserialize_FullData(serializedData);
        }

        public virtual void Deserialize_Core(byte[] serializedData)
        {
            m_accessor.Deserialize_FullData(serializedData);
        }

        public CoreParam()
        {
            m_coreData = Factory.CreateCoreData();
            m_accessor = new Accessor();
            m_accessor.AttachEncodedData(m_coreData, null);
        }

        public CoreParam(MonsNo monsno, ushort level, ulong id)
        {
            m_coreData = Factory.CreateCoreData(monsno, level, id);
            m_accessor = new Accessor();
            m_accessor.AttachEncodedData(m_coreData, null);
            InitCoreData();
            CheckIllegalParam();
        }

        public CoreParam(InitialSpec spec)
        {
            m_coreData = Factory.CreateCoreData(spec);
            m_accessor = new Accessor();
            m_accessor.AttachEncodedData(m_coreData, null);
            InitCoreData();
            CheckIllegalParam();
        }

        protected void InitCoreData()
        {
            SetLangId((uint)PmlUse.Instance.LangId);
            SetDefaultWaza();
            SetDefaultNickName();
            RecoverAll();
        }

        protected void SetIllegalParam()
        {
            m_accessor.SetFuseiTamagoFlag(true);
        }

        protected void CheckIllegalParam()
        {
            var monsno = GetMonsNo();
            var formno = GetFormNo();

            if (monsno == MonsNo.NULL)
                return;

            if (!PersonalSystem.CheckPokeExist(monsno, formno))
                SetIllegalParam();
        }

        protected void UpdateCalcDatas(bool keepDead = true)
        {
            bool validFlag = StartFastMode();

            UpdateLevel();
            UpdateMaxHpAndCorrectHp(keepDead);
            UpdateAtk();
            UpdateDef();
            UpdateSpAtk();
            UpdateSpDef();
            UpdateAgi();

            EndFastMode(validFlag);
        }

        protected void UpdateLevel()
        {
            m_accessor.SetLevel(CalcLevel());
        }

        protected void UpdateMaxHP()
        {
            SetMaxHp(CalcMaxHp());
        }

        protected void UpdateMaxHpAndCorrectHp(bool keepDead = true)
        {
            var max = GetMaxHp();
            var curr = GetHp();

            UpdateMaxHP();

            if (curr == 0 && keepDead)
                return;

            var newmax = GetMaxHp();
            var newhp = (ushort)((curr <= newmax) ? curr : newmax);
            newhp = (ushort)((max <= newmax) ? (curr - max + newmax) : newhp);

            m_accessor.SetHp(newhp);
        }

        protected void UpdateAtk()
        {
            SetAtk(CalcAtk());
        }

        protected void UpdateDef()
        {
            SetDef(CalcDef());
        }

        protected void UpdateSpAtk()
        {
            SetSpAtk(CalcSpAtk());
        }

        protected void UpdateSpDef()
        {
            SetSpDef(CalcSpDef());
        }

        protected void UpdateAgi()
        {
            SetAgi(CalcAgi());
        }

        protected uint GetAtk()
        {
            if (HaveCalcParam())
                return m_accessor.GetAtk();

            return CalcAtk_NotG();
        }

        protected uint GetDef()
        {
            if (HaveCalcParam())
                return m_accessor.GetDef();

            return CalcDef_NotG();
        }

        protected uint GetSpAtk()
        {
            if (HaveCalcParam())
                return m_accessor.GetSpAtk();

            return CalcSpAtk_NotG();
        }

        protected uint GetSpDef()
        {
            if (HaveCalcParam())
                return m_accessor.GetSpDef();

            return CalcSpDef_NotG();
        }

        protected uint GetAgi()
        {
            if (HaveCalcParam())
                return m_accessor.GetAgi();

            return CalcAgi_NotG();
        }

        protected byte CalcLevel()
        {
            return CalcTool.CalcLevel(GetMonsNo(), GetFormNo(), GetExp());
        }

        protected ushort CalcMaxHp()
        {
            if (HaveCalcParam())
            {
                _ = GetGState();
            }

            return CalcMaxHp_NotG();
        }

        protected ushort CalcAtk()
        {
            if (HaveCalcParam())
            {
                _ = GetGState();
            }

            return CalcAtk_NotG();
        }

        protected ushort CalcDef()
        {
            if (HaveCalcParam())
            {
                _ = GetGState();
            }

            return CalcDef_NotG();
        }

        protected ushort CalcSpAtk()
        {
            if (HaveCalcParam())
            {
                _ = GetGState();
            }

            return CalcSpAtk_NotG();
        }

        protected ushort CalcSpDef()
        {
            if (HaveCalcParam())
            {
                _ = GetGState();
            }

            return CalcSpDef_NotG();
        }

        protected ushort CalcAgi()
        {
            if (HaveCalcParam())
            {
                _ = GetGState();
            }

            return CalcAgi_NotG();
        }

        protected ushort CalcMaxHp_G()
        {
            return CalcMaxHp_NotG();
        }

        protected ushort CalcAtk_G()
        {
            return CalcAtk_NotG();
        }

        protected ushort CalcDef_G()
        {
            return CalcDef_NotG();
        }

        protected ushort CalcSpAtk_G()
        {
            return CalcSpAtk_NotG();
        }

        protected ushort CalcSpDef_G()
        {
            return CalcSpDef_NotG();
        }

        protected ushort CalcAgi_G()
        {
            return CalcAgi_NotG();
        }

        protected ushort CalcMaxHp_NotG()
        {
            PersonalSystem.LoadPersonalData(GetMonsNo(), GetFormNo());
            var basev = (ushort)PersonalSystem.GetPersonalParam(ParamID.BASIC_HP);
            byte flag = m_accessor.GetTrainingFlag();
            ushort talent = (flag & (1 << (int)PowerID.HP)) != 0 ? PmlConstants.MAX_TALENT_POWER : (ushort)m_accessor.GetTalentHp();
            return CalcTool.CalcMaxHp(GetMonsNo(), CalcLevel(), basev, talent, (ushort)m_accessor.GetEffortHp());
        }

        protected ushort CalcAtk_NotG()
        {
            PersonalSystem.LoadPersonalData(GetMonsNo(), GetFormNo());
            var basev = (ushort)PersonalSystem.GetPersonalParam(ParamID.BASIC_ATK);
            byte flag = m_accessor.GetTrainingFlag();
            ushort talent = (flag & (1 << (int)PowerID.ATK)) != 0 ? PmlConstants.MAX_TALENT_POWER : (ushort)m_accessor.GetTalentAtk();
            return CalcTool.CalcAtk(CalcLevel(), basev, talent, (ushort)m_accessor.GetEffortAtk(), GetSeikakuHosei());
        }

        protected ushort CalcDef_NotG()
        {
            PersonalSystem.LoadPersonalData(GetMonsNo(), GetFormNo());
            var basev = (ushort)PersonalSystem.GetPersonalParam(ParamID.BASIC_DEF);
            byte flag = m_accessor.GetTrainingFlag();
            ushort talent = (flag & (1 << (int)PowerID.DEF)) != 0 ? PmlConstants.MAX_TALENT_POWER : (ushort)m_accessor.GetTalentDef();
            return CalcTool.CalcDef(CalcLevel(), basev, talent, (ushort)m_accessor.GetEffortDef(), GetSeikakuHosei());
        }

        protected ushort CalcSpAtk_NotG()
        {
            PersonalSystem.LoadPersonalData(GetMonsNo(), GetFormNo());
            var basev = (ushort)PersonalSystem.GetPersonalParam(ParamID.BASIC_SPATK);
            byte flag = m_accessor.GetTrainingFlag();
            ushort talent = (flag & (1 << (int)PowerID.SPATK)) != 0 ? PmlConstants.MAX_TALENT_POWER : (ushort)m_accessor.GetTalentSpAtk();
            return CalcTool.CalcSpAtk(CalcLevel(), basev, talent, (ushort)m_accessor.GetEffortSpAtk(), GetSeikakuHosei());
        }

        protected ushort CalcSpDef_NotG()
        {
            PersonalSystem.LoadPersonalData(GetMonsNo(), GetFormNo());
            var basev = (ushort)PersonalSystem.GetPersonalParam(ParamID.BASIC_SPDEF);
            byte flag = m_accessor.GetTrainingFlag();
            ushort talent = (flag & (1 << (int)PowerID.SPDEF)) != 0 ? PmlConstants.MAX_TALENT_POWER : (ushort)m_accessor.GetTalentSpDef();
            return CalcTool.CalcSpDef(CalcLevel(), basev, talent, (ushort)m_accessor.GetEffortSpDef(), GetSeikakuHosei());
        }

        protected ushort CalcAgi_NotG()
        {
            PersonalSystem.LoadPersonalData(GetMonsNo(), GetFormNo());
            var basev = (ushort)PersonalSystem.GetPersonalParam(ParamID.BASIC_AGI);
            byte flag = m_accessor.GetTrainingFlag();
            ushort talent = (flag & (1 << (int)PowerID.AGI)) != 0 ? PmlConstants.MAX_TALENT_POWER : (ushort)m_accessor.GetTalentAgi();
            return CalcTool.CalcAgi(CalcLevel(), basev, talent, (ushort)m_accessor.GetEffortAgi(), GetSeikakuHosei());
        }

        protected void changeWazaByFormChange(ushort nextFormno, [Optional] FormChangeResult pResult)
        {
            _ = GetMonsNo();

            RemoveDuplicatedWaza();
            CloseUpWazaPos();
        }

        protected void changeWazaByFormChange_Learn(WazaNo learnWaza, [Optional] FormChangeResult pResult)
        {
            var learnResult = AddWazaIfEmptyExist(learnWaza);

            if (pResult == null)
                return;

            switch (learnResult)
            {
                case WazaLearningResult.SUCCEEDED:
                    pResult.SetAddedWaza(learnWaza);
                    break;

                case WazaLearningResult.FAILED_FULL:
                    pResult.SetAddFailedWaza(learnWaza);
                    break;
            }
        }

        protected void changeWazaByFormChange_Forget(WazaNo forgetWaza, WazaNo supplyWaza, [Optional] FormChangeResult pResult)
        {
            var idx = GetWazaIndex(forgetWaza);
            if (idx < PmlConstants.MAX_WAZA_NUM)
            {
                RemoveWaza(idx);
                if (pResult != null)
                    pResult.SetRemovedWaza(forgetWaza);

                if (supplyWaza != WazaNo.NULL)
                    changeWazaByFormChange_Learn(supplyWaza, pResult);

                CloseUpWazaPos();
            }
        }

        protected void changeWazaByFormChange_Replace(WazaNo forgetWaza, WazaNo learnWaza, [Optional] FormChangeResult pResult)
        {
            var idx = GetWazaIndex(forgetWaza);
            if (idx < PmlConstants.MAX_WAZA_NUM)
            {
                SetWaza(idx, learnWaza);
                if (pResult != null)
                {
                    pResult.SetRemovedWaza(forgetWaza);
                    pResult.SetAddedWaza(learnWaza);
                }
            }
            else
            {
                changeWazaByFormChange_Learn(learnWaza, pResult);
            }
        }

        protected uint AdjustEffortPower(uint beforeValue, uint afterValue)
        {
            if (afterValue >= PmlConstants.MAX_EFFORT_POWER)
                afterValue = PmlConstants.MAX_EFFORT_POWER;

            if (beforeValue <= afterValue && afterValue - beforeValue != 0)
            {
                var nextTotal = GetTotalEffortPower() + afterValue - beforeValue;
                if (nextTotal > PmlConstants.MAX_TOTAL_EFFORT_POWER)
                    afterValue = afterValue - nextTotal + PmlConstants.MAX_TOTAL_EFFORT_POWER;
            }

            return afterValue;
        }

        public class WazaLearnWork
        {
            private WazaNo[] m_checkedWazaArray = new WazaNo[PersonalConstants.MAX_WAZAOBOE_CODE_NUM];
            private uint m_checkedWazaNum;

            public WazaLearnWork()
            {
                Clear();
            }

            public void Clear()
            {
                m_checkedWazaNum = 0;
                for (int i=0; i<m_checkedWazaArray.Length; i++)
                    m_checkedWazaArray[i] = WazaNo.NULL;
            }

            public void AddCheckedWaza(WazaNo waza)
            {
                if (IsCheckedWaza(waza))
                    return;

                if (m_checkedWazaNum < m_checkedWazaArray.Length)
                {
                    m_checkedWazaArray[m_checkedWazaNum] = waza;
                    m_checkedWazaNum++;
                }
                else
                {
                    GFL.ASSERT(false);
                }
            }

            public bool IsCheckedWaza(WazaNo waza)
            {
                for (int i=0; i<m_checkedWazaArray.Length; i++)
                {
                    if (m_checkedWazaArray[i] == waza)
                        return true;
                }

                return false;
            }
        }

        public class FormChangeResult
        {
            private WazaNo[] m_addedWaza = new WazaNo[4];
            private WazaNo[] m_removedWaza = new WazaNo[4];
            private WazaNo[] m_addFailedWaza = new WazaNo[4];

            public FormChangeResult()
            {
                Clear();
            }

            public byte GetAddedWazaNum()
            {
                return getCount(m_addedWaza);
            }

            public WazaNo GetAddedWaza(byte idx)
            {
                return get(m_addedWaza, idx);
            }

            public byte GetRemovedWazaNum()
            {
                return getCount(m_removedWaza);
            }

            public WazaNo GetRemovedWaza(byte idx)
            {
                return get(m_removedWaza, idx);
            }

            public byte GetAddFailedWazaNum()
            {
                return getCount(m_addFailedWaza);
            }

            public WazaNo GetAddFaildedWaza(byte idx)
            {
                return get(m_addFailedWaza, idx);
            }

            public void Clear()
            {
                m_addedWaza[0] = WazaNo.NULL;
                m_removedWaza[0] = WazaNo.NULL;
                m_addFailedWaza[0] = WazaNo.NULL;

                m_addedWaza[1] = WazaNo.NULL;
                m_removedWaza[1] = WazaNo.NULL;
                m_addFailedWaza[1] = WazaNo.NULL;

                m_addedWaza[2] = WazaNo.NULL;
                m_removedWaza[2] = WazaNo.NULL;
                m_addFailedWaza[2] = WazaNo.NULL;

                m_addedWaza[3] = WazaNo.NULL;
                m_removedWaza[3] = WazaNo.NULL;
                m_addFailedWaza[3] = WazaNo.NULL;
            }

            public void SetAddedWaza(WazaNo wazano)
            {
                set(m_addedWaza, wazano);
            }

            public void SetRemovedWaza(WazaNo wazano)
            {
                set(m_removedWaza, wazano);
            }

            public void SetAddFailedWaza(WazaNo wazano)
            {
                set(m_addFailedWaza, wazano);
            }

            private void add(WazaNo[] pArray, WazaNo wazano)
            {
                for (int i=0; i<pArray.Length; i++)
                {
                    if (pArray[i] == WazaNo.NULL)
                        pArray[i] = wazano;
                }
            }

            private void set(WazaNo[] pArray, WazaNo wazano)
            {
                add(pArray, wazano);
            }

            private WazaNo get(WazaNo[] pArray, byte idx)
            {
                if (idx < pArray.Length)
                {
                    return pArray[idx];
                }
                else
                {
                    GFL.ASSERT(false);
                    return WazaNo.NULL;
                }
            }

            private byte getCount(WazaNo[] pArray)
            {
                byte count = 0;
                for (; count<pArray.Length; count++)
                {
                    if (pArray[count] == WazaNo.NULL)
                        break;
                }

                return count;
            }
        }
    }
}
