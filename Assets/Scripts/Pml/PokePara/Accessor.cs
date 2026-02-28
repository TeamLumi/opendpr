using System;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;
using Dpr.Message;
using Pml;
using Pml.Personal;

namespace Pml.PokePara
{
    public class Accessor
    {
        private const uint CORE_DATA_SIZE = 328;
        private const uint CALC_DATA_SIZE = 16;
        public const uint FULL_SERIALIZE_DATA_SIZE = 344;
        public const uint CORE_SERIALIZE_DATA_SIZE = 328;
        private const uint MAX_RIBBON_NUM_ON_RIBBON_FIELD_1 = 32;
        private const uint MAX_RIBBON_NUM_ON_RIBBON_FIELD_2 = 32;
        private const uint MAX_RIBBON_NUM_ON_RIBBON_FIELD_3 = 32;
        private const uint MAX_RIBBON_NUM_ON_RIBBON_FIELD_4 = 32;
        private const uint MIN_RIBBON_NO_ON_RIBBON_FIELD_1 = 0;
        private const uint MIN_RIBBON_NO_ON_RIBBON_FIELD_2 = 32;
        private const uint MIN_RIBBON_NO_ON_RIBBON_FIELD_3 = 64;
        private const uint MIN_RIBBON_NO_ON_RIBBON_FIELD_4 = 96;
        private const uint MAX_RIBBON_NO_ON_RIBBON_FIELD_1 = 31;
        private const uint MAX_RIBBON_NO_ON_RIBBON_FIELD_2 = 63;
        private const uint MAX_RIBBON_NO_ON_RIBBON_FIELD_3 = 95;
        private const uint MAX_RIBBON_NO_ON_RIBBON_FIELD_4 = 127;
        private static unsafe byte* IllegalCoreData = null;
        private static unsafe byte* DummyWriteCoreData = null;
        private static unsafe byte* IllegalCalcData = null;
        private static unsafe byte* DummyWriteCalcData = null;
        private byte[] m_pCalcData;
        private byte[] m_pCoreData;
        private AccessState m_accessState;
        private const byte POS1 = 0;
        private const byte POS2 = 1;
        private const byte POS3 = 2;
        private const byte POS4 = 3;
        private static readonly byte[][] BLOCK_POS_TABLE = new byte[][]
        {
            new byte[] { POS1, POS2, POS3, POS4 },
            new byte[] { POS1, POS2, POS4, POS3 },
            new byte[] { POS1, POS3, POS2, POS4 },
            new byte[] { POS1, POS4, POS2, POS3 },
            new byte[] { POS1, POS3, POS4, POS2 },
            new byte[] { POS1, POS4, POS3, POS2 },
            new byte[] { POS2, POS1, POS3, POS4 },
            new byte[] { POS2, POS1, POS4, POS3 },
            new byte[] { POS3, POS1, POS2, POS4 },
            new byte[] { POS4, POS1, POS2, POS3 },
            new byte[] { POS3, POS1, POS4, POS2 },
            new byte[] { POS4, POS1, POS3, POS2 },
            new byte[] { POS2, POS3, POS1, POS4 },
            new byte[] { POS2, POS4, POS1, POS3 },
            new byte[] { POS3, POS2, POS1, POS4 },
            new byte[] { POS4, POS2, POS1, POS3 },
            new byte[] { POS3, POS4, POS1, POS2 },
            new byte[] { POS4, POS3, POS1, POS2 },
            new byte[] { POS2, POS3, POS4, POS1 },
            new byte[] { POS2, POS4, POS3, POS1 },
            new byte[] { POS3, POS2, POS4, POS1 },
            new byte[] { POS4, POS2, POS3, POS1 },
            new byte[] { POS3, POS4, POS2, POS1 },
            new byte[] { POS4, POS3, POS2, POS1 },
            new byte[] { POS1, POS2, POS3, POS4 },
            new byte[] { POS1, POS2, POS4, POS3 },
            new byte[] { POS1, POS3, POS2, POS4 },
            new byte[] { POS1, POS4, POS2, POS3 },
            new byte[] { POS1, POS3, POS4, POS2 },
            new byte[] { POS1, POS4, POS3, POS2 },
            new byte[] { POS2, POS1, POS3, POS4 },
            new byte[] { POS2, POS1, POS4, POS3 },
        };

        public static void Initialize() { }

        public void AttachDecodedData(byte[] coreData, byte[] calcData)
        {
            m_pCoreData = coreData;
            m_pCalcData = calcData;
            m_accessState.isEncoded = false;
            m_accessState.isFastMode = false;
            UpdateChecksumAndEncode();
        }

        public void AttachEncodedData(byte[] coreData, byte[] calcData)
        {
            m_pCoreData = coreData;
            m_pCalcData = calcData;
            m_accessState.isEncoded = true;
            m_accessState.isFastMode = false;
        }

        public bool HaveCalcData()
        {
            return m_pCalcData != null;
        }

        public void ClearData()
        {
            if (m_pCoreData != null)
                Array.Clear(m_pCoreData, 0, m_pCoreData.Length);

            if (m_pCalcData != null)
                Array.Clear(m_pCalcData, 0, m_pCalcData.Length);

            m_accessState.isEncoded = false;
            m_accessState.isFastMode = false;
            UpdateChecksumAndEncode();
        }

        public void ClearCalcData()
        {
            if (m_pCalcData == null)
                return;
            if (IsFastMode())
            {
                Array.Clear(m_pCalcData, 0, m_pCalcData.Length);
            }
            else
            {
                StartFastMode();
                Array.Clear(m_pCalcData, 0, m_pCalcData.Length);
                EndFastMode();
            }
        }

        public void StartFastMode()
        {
            DecodeAndCheckIllegalWrite();
            m_accessState.isFastMode = true;
            GFL.ASSERT(!IsEncoded());
        }

        public void EndFastMode()
        {
            m_accessState.isFastMode = false;
            UpdateChecksumAndEncode();
            if (IsFastMode())
                GFL.ASSERT(false);
            else
                GFL.ASSERT(IsEncoded());
        }

        public bool IsFastMode()
        {
            return m_accessState.isFastMode;
        }

        public bool IsEncoded()
        {
            return m_accessState.isEncoded;
        }

        public void Serialize_FullData(byte[] buffer)
        {
            GFL.ASSERT(buffer.Length >= FULL_SERIALIZE_DATA_SIZE);
            unsafe { fixed (byte* dst = buffer) Serialize_FullData(dst); }
        }

        public void Serialize_CoreData(byte[] buffer)
        {
            GFL.ASSERT(buffer.Length >= CORE_SERIALIZE_DATA_SIZE);
            unsafe { fixed (byte* dst = buffer) Serialize_CoreData(dst); }
        }

        public void Deserialize_FullData(byte[] serializedData)
        {
            GFL.ASSERT(serializedData.Length >= FULL_SERIALIZE_DATA_SIZE);
            unsafe { fixed (byte* src = serializedData) Deserialize_FullData(src); }
        }

        public void Deserialize_CoreData(byte[] serializedData)
        {
            GFL.ASSERT(serializedData.Length >= CORE_SERIALIZE_DATA_SIZE);
            unsafe { fixed (byte* src = serializedData) Deserialize_CoreData(src); }
        }

        public unsafe void Serialize_FullData(void* buffer)
        {
            Serialize(buffer, (byte*)buffer + CORE_SERIALIZE_DATA_SIZE);
        }

        public unsafe void Serialize_CoreData(void* buffer)
        {
            Serialize(buffer, null);
        }

        public unsafe void Deserialize_FullData(void* serializedData)
        {
            Deserialize(serializedData, (byte*)serializedData + CORE_SERIALIZE_DATA_SIZE);
        }

        public unsafe void Deserialize_CoreData(void* serializedData)
        {
            Deserialize(serializedData, null);
        }

        // =============================================
        // Getters - Header
        // =============================================

        public uint GetPersonalRnd()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var header = GetCoreDataHeader(addr);
                    var value = header->personalRnd;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetCheckSum()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var header = GetCoreDataHeader(addr);
                    var value = header->checksum;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public bool IsFuseiTamago()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var header = GetCoreDataHeader(addr);
                    var value = header->fuseiTamagoFlag;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        // =============================================
        // Getters - BlockA
        // =============================================

        public MonsNo GetMonsNo()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = (MonsNo)block->monsno;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetItemNo()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = (uint)block->itemno;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetID()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = block->id;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetExp()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = block->exp;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public TokuseiNo GetTokuseiNo()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = (TokuseiNo)block->tokuseino;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public ushort GetBoxMark()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = block->boxMark;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetColorRnd()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = block->colorRnd;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetSeikaku()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = (uint)block->seikaku;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetSeikakuHosei()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = (uint)block->seikakuHosei;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public ushort GetFormNo()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = block->formNo;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetEffortHp()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = (uint)block->effortHp;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetEffortAtk()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = (uint)block->effortAtk;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetEffortDef()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = (uint)block->effortDef;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetEffortAgi()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = (uint)block->effortAgi;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetEffortSpAtk()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = (uint)block->effortSpatk;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetEffortSpDef()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = (uint)block->effortSpdef;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetStyle()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = block->style;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetBeautiful()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = block->beautiful;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetCute()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = block->cute;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetClever()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = block->clever;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetStrong()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = block->strong;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetFur()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = block->fur;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetPokerus()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = (uint)block->pokerus;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public bool IsTokusei1()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = block->tokusei1Flag;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public bool IsTokusei2()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = block->tokusei2Flag;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public bool IsTokusei3()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = block->tokusei3Flag;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public bool IsFavorite()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = block->favoriteFlag;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public bool IsSpecialGEnable()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = block->special_g_flag;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public bool IsEventPokemon()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = block->eventGetFlag;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public bool GetOfficialBattleEnableFlag()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = block->officialBattleEnableFlag;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public Sex GetSex()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = (Sex)block->sex;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetCampFriendship()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = (byte)block->camp_friendship;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public bool GetDprIllegalFlag()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    var value = block->dpr_illegal_flag;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetTalentHeight()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = block->talentHeight;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetTalentWeight()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    var value = block->talentWeight;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public bool HaveRibbon(uint ribbonNo)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    bool value;
                    if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_1)
                        value = (block->ribbonA & (1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_1))) != 0;
                    else if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_2)
                        value = (block->ribbonB & (1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_2))) != 0;
                    else if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_3)
                        value = (block->ribbonC & (1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_3))) != 0;
                    else if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_4)
                        value = (block->ribbonD & (1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_4))) != 0;
                    else
                        value = false;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetLumpingRibbon(LumpingRibbon ribbonId)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, false);
                    uint value;
                    switch (ribbonId)
                    {
                        case LumpingRibbon.A:
                            value = block->lumpingRibbonA;
                            break;
                        case LumpingRibbon.B:
                            value = block->lumpingRibbonB;
                            break;
                        default:
                            GFL.ASSERT(false);
                            value = 0;
                            break;
                    }
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        // =============================================
        // Getters - BlockB
        // =============================================

        public uint GetSick()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, false);
                    var value = block->sick;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public WazaNo GetWazaNo(byte wazaIndex)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, false);
                    WazaNo value;
                    if (wazaIndex < PmlConstants.MAX_WAZA_NUM)
                        value = (WazaNo)block->waza[wazaIndex];
                    else
                    {
                        GFL.ASSERT(false);
                        value = WazaNo.NULL;
                    }
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetPP(byte wazaIndex)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, false);
                    byte value;
                    if (wazaIndex < PmlConstants.MAX_WAZA_NUM)
                        value = block->pp[wazaIndex];
                    else
                    {
                        GFL.ASSERT(false);
                        value = 0;
                    }
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetWazaPPUpCount(byte wazaIndex)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, false);
                    byte value;
                    if (wazaIndex < PmlConstants.MAX_WAZA_NUM)
                        value = block->pointupUsedCount[wazaIndex];
                    else
                    {
                        GFL.ASSERT(false);
                        value = 0;
                    }
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public WazaNo GetTamagoWazaNo(byte index)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, false);
                    WazaNo value;
                    if (index < PmlConstants.MAX_WAZA_NUM)
                        value = (WazaNo)block->tamagoWaza[index];
                    else
                    {
                        GFL.ASSERT(false);
                        value = WazaNo.NULL;
                    }
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetHp()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, false);
                    var value = (uint)block->hp;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetTalentHp()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, false);
                    var value = block->talentHp;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetTalentAtk()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, false);
                    var value = block->talentAtk;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetTalentDef()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, false);
                    var value = block->talentDef;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetTalentSpAtk()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, false);
                    var value = block->talentSpatk;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetTalentSpDef()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, false);
                    var value = block->talentSpdef;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetTalentAgi()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, false);
                    var value = block->talentAgi;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetEffortG()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, false);
                    var value = (uint)block->effortG;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public bool IsTamago()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, false);
                    var value = block->tamagoFlag;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public bool HaveNickName()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, false);
                    var value = block->nicknameFlag;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public string GetNickName()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var header = GetCoreDataHeader(addr);
                    if (header->fuseiTamagoFlag)
                    {
                        DecodeAndCheckIllegalWrite();
                        var blockC = GetCoreDataBlockC(addr, false);
                        byte langId = blockC->langId;
                        UpdateChecksumAndEncode();
                        if (langId == 0)
                        {
                            langId = 1;
                        }
                        return PersonalSystem.GetMonsName(MonsNo.TAMAGO, (MessageEnumData.MsgLangId)langId);
                    }

                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, false);
                    var value = new string(block->nickname);
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetPalma()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, false);
                    var value = block->palma;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        // =============================================
        // Getters - BlockC
        // =============================================

        public string GetPastParentsName()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, false);
                    var value = new string(block->pastParentsName);
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public Sex GetPastParentsSex()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, false);
                    var value = (Sex)block->pastParentsSex;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetPastParentsLangID()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, false);
                    var value = block->pastParentLangID;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public bool GetOwnedOthersFlag()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, false);
                    var value = block->ownedByOthers != 0;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public ushort GetOthersFriendshipTrainerID()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, false);
                    var value = block->othersFriendshipTrainerId;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetOthersFriendship()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, false);
                    var value = block->othersFriendship;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetOthersMemoriesLevel()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, false);
                    var value = block->othersMemoriesLevel;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetOthersMemoriesCode()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, false);
                    var value = block->othersMemoriesCode;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public ushort GetOthersMemoriesData()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, false);
                    var value = block->othersMemoriesData;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetOthersMemoriesFeel()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, false);
                    var value = block->othersMemoriesFeel;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public bool GetPokeJobFlag(byte jobIndex)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, false);
                    CalcPokeJobBitPos(out byte arrayIndex, out byte bitFlag, jobIndex);
                    bool value;
                    if (arrayIndex < CoreDataBlockC.POKEJOB_LEN)
                        value = (block->pokejob[arrayIndex] & bitFlag) != 0;
                    else
                    {
                        GFL.ASSERT(false);
                        value = false;
                    }
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetEnjoy()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, false);
                    var value = block->enjoy;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetNadenadeValue()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, false);
                    var value = block->nadeNadeValue;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetCassetteVersion()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, false);
                    var value = (uint)block->getCassette;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetBattleRomMark()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, false);
                    var value = block->battleRomMark;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetLangId()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, false);
                    var value = (uint)block->langId;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetMultiPurposeWork()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, false);
                    var value = block->multiWork;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetEquipRibbonNo()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, false);
                    var value = block->equipRibbon;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        // =============================================
        // Getters - BlockD
        // =============================================

        public string GetOyaName()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, false);
                    var value = new string(block->parentsName);
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetFriendship()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var blockC = GetCoreDataBlockC(addr, false);
                    uint value;
                    if (blockC->ownedByOthers != 0)
                    {
                        value = blockC->othersFriendship;
                    }
                    else
                    {
                        var block = GetCoreDataBlockD(addr, false);
                        value = block->friendship;
                    }
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetOriginalFriendship()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, false);
                    var value = block->friendship;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetMemoriesLevel()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, false);
                    var value = block->memories_level;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetMemoriesCode()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, false);
                    var value = block->memories_code;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public ushort GetMemoriesData()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, false);
                    var value = block->memories_data;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetMemoriesFeel()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, false);
                    var value = block->memories_feel;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetTamagoGetYear()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, false);
                    var value = (uint)block->eggGetYear;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetTamagoGetMonth()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, false);
                    var value = (uint)block->eggGetMonth;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetTamagoGetDay()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, false);
                    var value = (uint)block->eggGetDay;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetBirthYear()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, false);
                    var value = (uint)block->firstContactYear;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetBirthMonth()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, false);
                    var value = (uint)block->firstContactMonth;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetBirthDay()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, false);
                    var value = (uint)block->firstContactDay;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetGetPlace()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, false);
                    var value = (uint)block->getPlace;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetBirthPlace()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, false);
                    var value = (uint)block->birthPlace;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetGetBall()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, false);
                    var value = (uint)block->getBall;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetGetLevel()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, false);
                    var value = (uint)block->getLevel;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public Sex GetOyasex()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, false);
                    var value = (Sex)block->parentsSex;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public byte GetTrainingFlag()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, false);
                    var value = block->trainingFlag;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public bool GetWazaRecordFlag(byte recordIndex)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, false);
                    CalcWazaRecordBitPos(out byte arrayIndex, out byte bitFlag, recordIndex);
                    bool value;
                    if (arrayIndex < CoreDataBlockD.WAZA_RECORD_FLAG_LEN)
                        value = (block->wazaRecordFlag[arrayIndex] & bitFlag) != 0;
                    else
                    {
                        GFL.ASSERT(false);
                        value = false;
                    }
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public ulong GetBankUniqueID()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, false);
                    var value = *(ulong*)block->bankUniqueID;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public bool CompareOyaName(string cmpName)
        {
            return cmpName.Equals(GetOyaName());
        }

        // =============================================
        // Getters - CalcData
        // =============================================

        public uint GetLevel()
        {
            if (m_pCalcData == null) return 0;
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    DecodeAndCheckIllegalWrite();
                    var calc = GetCalcData(addr, false);
                    var value = (uint)calc->level;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetMaxHp()
        {
            if (m_pCalcData == null) return 0;
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    DecodeAndCheckIllegalWrite();
                    var calc = GetCalcData(addr, false);
                    var value = (uint)calc->maxHp;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetAtk()
        {
            if (m_pCalcData == null) return 0;
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    DecodeAndCheckIllegalWrite();
                    var calc = GetCalcData(addr, false);
                    var value = (uint)calc->atk;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetDef()
        {
            if (m_pCalcData == null) return 0;
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    DecodeAndCheckIllegalWrite();
                    var calc = GetCalcData(addr, false);
                    var value = (uint)calc->def;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetSpAtk()
        {
            if (m_pCalcData == null) return 0;
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    DecodeAndCheckIllegalWrite();
                    var calc = GetCalcData(addr, false);
                    var value = (uint)calc->spatk;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetSpDef()
        {
            if (m_pCalcData == null) return 0;
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    DecodeAndCheckIllegalWrite();
                    var calc = GetCalcData(addr, false);
                    var value = (uint)calc->spdef;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public uint GetAgi()
        {
            if (m_pCalcData == null) return 0;
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    DecodeAndCheckIllegalWrite();
                    var calc = GetCalcData(addr, false);
                    var value = (uint)calc->agi;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        public GState GetGState()
        {
            if (m_pCalcData == null) return GState.NONE;
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    DecodeAndCheckIllegalWrite();
                    var calc = GetCalcData(addr, false);
                    var value = (GState)calc->gState;
                    UpdateChecksumAndEncode();
                    return value;
                }
            }
        }

        // =============================================
        // Setters - Header
        // =============================================

        public void SetPersonalRnd(uint rnd)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var header = GetCoreDataHeader(addr);
                    header->personalRnd = rnd;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetCheckSum(ushort checksum)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var header = GetCoreDataHeader(addr);
                    header->checksum = checksum;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetFuseiTamagoFlag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var header = GetCoreDataHeader(addr);
                    header->fuseiTamagoFlag = flag;
                    UpdateChecksumAndEncode();
                }
            }
        }

        // =============================================
        // Setters - BlockA
        // =============================================

        public void SetMonsNo(uint monsno)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->monsno = (ushort)monsno;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetItemNo(ushort itemno)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->itemno = itemno;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetID(uint id)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->id = id;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetExp(uint exp)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->exp = exp;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetTokuseiNo(uint tokusei)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->tokuseino = (ushort)tokusei;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetBoxMark(ushort mark)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->boxMark = mark;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetColorRnd(uint rnd)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->colorRnd = rnd;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetSeikaku(uint seikaku)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->seikaku = (byte)seikaku;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetSeikakuHosei(uint seikaku)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->seikakuHosei = (byte)seikaku;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetFormNo(ushort formno)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->formNo = formno;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetEffortHp(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->effortHp = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetEffortAtk(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->effortAtk = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetEffortDef(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->effortDef = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetEffortAgi(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->effortAgi = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetEffortSpAtk(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->effortSpatk = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetEffortSpDef(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->effortSpdef = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetStyle(byte style)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->style = style;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetBeautiful(byte beautiful)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->beautiful = beautiful;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetCute(byte cute)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->cute = cute;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetClever(byte clever)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->clever = clever;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetStrong(byte strong)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->strong = strong;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetFur(byte fur)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->fur = fur;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetPokerus(byte pokerus)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->pokerus = pokerus;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetRibbon(uint ribbonNo)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_1)
                        block->ribbonA |= (1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_1));
                    else if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_2)
                        block->ribbonB |= (1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_2));
                    else if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_3)
                        block->ribbonC |= (1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_3));
                    else if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_4)
                        block->ribbonD |= (1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_4));
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void RemoveRibbon(uint ribbonNo)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_1)
                        block->ribbonA &= ~(1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_1));
                    else if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_2)
                        block->ribbonB &= ~(1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_2));
                    else if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_3)
                        block->ribbonC &= ~(1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_3));
                    else if (ribbonNo <= MAX_RIBBON_NO_ON_RIBBON_FIELD_4)
                        block->ribbonD &= ~(1u << (int)(ribbonNo - MIN_RIBBON_NO_ON_RIBBON_FIELD_4));
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void RemoveAllRibbon()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->ribbonA = 0;
                    block->ribbonB = 0;
                    block->ribbonC = 0;
                    block->ribbonD = 0;
                    block->lumpingRibbonA = 0;
                    block->lumpingRibbonB = 0;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetLumpingRibbon(LumpingRibbon ribbonId, uint num)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    switch (ribbonId)
                    {
                        case LumpingRibbon.A:
                            block->lumpingRibbonA = (byte)num;
                            break;
                        case LumpingRibbon.B:
                            block->lumpingRibbonB = (byte)num;
                            break;
                    }
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetTokusei1Flag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->tokusei1Flag = flag;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetTokusei2Flag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->tokusei2Flag = flag;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetTokusei3Flag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->tokusei3Flag = flag;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetFavoriteFlag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->favoriteFlag = flag;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetSpecialGFlag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->special_g_flag = flag;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetEventPokemonFlag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->eventGetFlag = flag;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetOfficialBattleEnableFlag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->officialBattleEnableFlag = flag;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetSex(Sex sex)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->sex = (byte)sex;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetCampFriendship(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->camp_friendship = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetDprIllegalFlag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->dpr_illegal_flag = flag;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetTalentHeight(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->talentHeight = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetTalentWeight(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockA(addr, true);
                    block->talentWeight = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        // =============================================
        // Setters - BlockB
        // =============================================

        public void SetSick(uint sick)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, true);
                    block->sick = sick;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetWazaNo(byte wazaIndex, uint wazano)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, true);
                    if (wazaIndex < PmlConstants.MAX_WAZA_NUM)
                        block->waza[wazaIndex] = (ushort)wazano;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetPP(byte wazaIndex, byte pp)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, true);
                    if (wazaIndex < PmlConstants.MAX_WAZA_NUM)
                        block->pp[wazaIndex] = pp;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetWazaPPUpCount(byte wazaIndex, byte count)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, true);
                    if (wazaIndex < PmlConstants.MAX_WAZA_NUM)
                        block->pointupUsedCount[wazaIndex] = count;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetTamagoWazaNo(byte index, uint wazano)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, true);
                    if (index < PmlConstants.MAX_WAZA_NUM)
                        block->tamagoWaza[index] = (ushort)wazano;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetHp(ushort hp)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, true);
                    block->hp = hp;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetTalentHp(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, true);
                    block->talentHp = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetTalentAtk(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, true);
                    block->talentAtk = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetTalentDef(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, true);
                    block->talentDef = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetTalentSpAtk(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, true);
                    block->talentSpatk = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetTalentSpDef(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, true);
                    block->talentSpdef = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetTalentAgi(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, true);
                    block->talentAgi = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetEffortG(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, true);
                    block->effortG = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetTamagoFlag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, true);
                    block->tamagoFlag = flag;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetNickNameFlag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, true);
                    block->nicknameFlag = flag;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetNickName(string nickName)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, true);
                    copyString(block->nickname, nickName, PmlConstants.MONS_NAME_BUFFER_SIZE);
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetPalma(uint value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockB(addr, true);
                    block->palma = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        // =============================================
        // Setters - BlockC
        // =============================================

        public void SetPastParentsName(string name)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, true);
                    copyString(block->pastParentsName, name, PmlConstants.PERSON_NAME_BUFFER_SIZE);
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetPastParentsSex(Sex sex)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, true);
                    block->pastParentsSex = (byte)sex;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetPastParentsLangID(byte langID)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, true);
                    block->pastParentLangID = langID;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetOwnedOthersFlag(bool flag)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, true);
                    block->ownedByOthers = (byte)(flag ? 1 : 0);
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetOthersFriendshipTrainerID(ushort trainerId)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, true);
                    block->othersFriendshipTrainerId = trainerId;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetOthersFriendship(byte friendship)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, true);
                    block->othersFriendship = friendship;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetOthersMemoriesLevel(byte level)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, true);
                    block->othersMemoriesLevel = level;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetOthersMemoriesCode(byte code)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, true);
                    block->othersMemoriesCode = code;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetOthersMemoriesData(ushort data)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, true);
                    block->othersMemoriesData = data;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetOthersMemoriesFeel(byte feel)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, true);
                    block->othersMemoriesFeel = feel;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetPokeJobFlag(byte jobIndex, bool set)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, true);
                    CalcPokeJobBitPos(out byte arrayIndex, out byte bitFlag, jobIndex);
                    if (arrayIndex < CoreDataBlockC.POKEJOB_LEN)
                    {
                        if (set)
                            block->pokejob[arrayIndex] |= bitFlag;
                        else
                            block->pokejob[arrayIndex] &= (byte)~bitFlag;
                    }
                    else
                    {
                        GFL.ASSERT(false);
                    }
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void ClearPokeJobFlag()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, true);
                    for (int i = 0; i < CoreDataBlockC.POKEJOB_LEN; i++)
                        block->pokejob[i] = 0;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetEnjoy(byte enjoy)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, true);
                    block->enjoy = enjoy;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetNadenadeValue(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, true);
                    block->nadeNadeValue = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetCassetteVersion(uint version)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, true);
                    block->getCassette = (byte)version;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetBattleRomMark(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, true);
                    block->battleRomMark = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetLangId(byte langId)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, true);
                    block->langId = langId;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetMultiPurposeWork(uint value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, true);
                    block->multiWork = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetEquipRibbonNo(byte ribbonNo)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockC(addr, true);
                    block->equipRibbon = ribbonNo;
                    UpdateChecksumAndEncode();
                }
            }
        }

        // =============================================
        // Setters - BlockD
        // =============================================

        public void SetOyaName(string oyaName)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    copyString(block->parentsName, oyaName, PmlConstants.PERSON_NAME_BUFFER_SIZE);
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetFriendship(byte friendship)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var blockC = GetCoreDataBlockC(addr, false);
                    if (blockC->ownedByOthers != 0)
                    {
                        var blockCW = GetCoreDataBlockC(addr, true);
                        blockCW->othersFriendship = friendship;
                    }
                    else
                    {
                        var block = GetCoreDataBlockD(addr, true);
                        block->friendship = friendship;
                    }
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetOriginalFriendship(byte friendship)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    block->friendship = friendship;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetMemoriesLevel(byte level)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    block->memories_level = level;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetMemoriesCode(byte code)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    block->memories_code = code;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetMemoriesData(ushort data)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    block->memories_data = data;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetMemoriesFeel(byte feel)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    block->memories_feel = feel;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetTamagoGetYear(byte year)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    block->eggGetYear = year;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetTamagoGetMonth(byte month)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    block->eggGetMonth = month;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetTamagoGetDay(byte day)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    block->eggGetDay = day;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetBirthYear(byte year)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    block->firstContactYear = year;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetBirthMonth(byte month)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    block->firstContactMonth = month;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetBirthDay(byte day)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    block->firstContactDay = day;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetGetPlace(ushort place)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    block->getPlace = place;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetBirthPlace(ushort place)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    block->birthPlace = place;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetGetBall(byte ball)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    block->getBall = ball;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetGetLevel(byte level)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    block->getLevel = level;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetOyasex(Sex sex)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    block->parentsSex = (byte)sex;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetTrainingFlag(byte value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    block->trainingFlag = value;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetWazaRecordFlag(byte recordIndex, bool set)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    CalcWazaRecordBitPos(out byte arrayIndex, out byte bitFlag, recordIndex);
                    if (arrayIndex < CoreDataBlockD.WAZA_RECORD_FLAG_LEN)
                    {
                        if (set)
                            block->wazaRecordFlag[arrayIndex] |= bitFlag;
                        else
                            block->wazaRecordFlag[arrayIndex] &= (byte)~bitFlag;
                    }
                    else
                    {
                        GFL.ASSERT(false);
                    }
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void ClearWazaRecordFlag()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    for (int i = 0; i < CoreDataBlockD.WAZA_RECORD_FLAG_LEN; i++)
                        block->wazaRecordFlag[i] = 0;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetBankUniqueID(ulong value)
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    for (int i = 0; i < CoreDataBlockD.BANK_UNIQUE_ID_LEN; i++)
                        block->bankUniqueID[i] = (byte)(value >> (i * 8));
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void ClearBankUniqueID()
        {
            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    DecodeAndCheckIllegalWrite();
                    var block = GetCoreDataBlockD(addr, true);
                    for (int i = 0; i < CoreDataBlockD.BANK_UNIQUE_ID_LEN; i++)
                        block->bankUniqueID[i] = 0;
                    UpdateChecksumAndEncode();
                }
            }
        }

        // =============================================
        // Setters - CalcData
        // =============================================

        public void SetLevel(byte level)
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    DecodeAndCheckIllegalWrite();
                    var calc = GetCalcData(addr, true);
                    calc->level = level;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetMaxHp(ushort maxHp)
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    DecodeAndCheckIllegalWrite();
                    var calc = GetCalcData(addr, true);
                    calc->maxHp = maxHp;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetAtk(ushort atk)
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    DecodeAndCheckIllegalWrite();
                    var calc = GetCalcData(addr, true);
                    calc->atk = atk;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetDef(ushort def)
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    DecodeAndCheckIllegalWrite();
                    var calc = GetCalcData(addr, true);
                    calc->def = def;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetSpAtk(ushort spatk)
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    DecodeAndCheckIllegalWrite();
                    var calc = GetCalcData(addr, true);
                    calc->spatk = spatk;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetSpDef(ushort spdef)
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    DecodeAndCheckIllegalWrite();
                    var calc = GetCalcData(addr, true);
                    calc->spdef = spdef;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetAgi(ushort agi)
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    DecodeAndCheckIllegalWrite();
                    var calc = GetCalcData(addr, true);
                    calc->agi = agi;
                    UpdateChecksumAndEncode();
                }
            }
        }

        public void SetGState(GState state)
        {
            unsafe
            {
                fixed (byte* addr = m_pCalcData)
                {
                    DecodeAndCheckIllegalWrite();
                    var calc = GetCalcData(addr, true);
                    calc->gState = (byte)state;
                    UpdateChecksumAndEncode();
                }
            }
        }

        // =============================================
        // Infrastructure
        // =============================================

        private unsafe CalcData* GetCalcData(byte* _addr, bool forWrite)
        {
            return (CalcData*)_addr;
        }

        private unsafe CoreDataBlockA* GetCoreDataBlockA(byte* _addr, bool forWrite)
        {
            var header = GetCoreDataHeader(_addr);
            byte pos = GetCoreDataBlockPos(header->personalRnd, CoreDataBlockId.A);
            byte* blockStart = _addr + CoreDataHeader.SIZE + pos * CoreData.CORE_DATA_BLOCK_SIZE;

            return (CoreDataBlockA*)blockStart;
        }

        private unsafe CoreDataBlockB* GetCoreDataBlockB(byte* _addr, bool forWrite)
        {
            var header = GetCoreDataHeader(_addr);
            byte pos = GetCoreDataBlockPos(header->personalRnd, CoreDataBlockId.B);
            byte* blockStart = _addr + CoreDataHeader.SIZE + pos * CoreData.CORE_DATA_BLOCK_SIZE;

            return (CoreDataBlockB*)blockStart;
        }

        private unsafe CoreDataBlockC* GetCoreDataBlockC(byte* _addr, bool forWrite)
        {
            var header = GetCoreDataHeader(_addr);
            byte pos = GetCoreDataBlockPos(header->personalRnd, CoreDataBlockId.C);
            byte* blockStart = _addr + CoreDataHeader.SIZE + pos * CoreData.CORE_DATA_BLOCK_SIZE;

            return (CoreDataBlockC*)blockStart;
        }

        private unsafe CoreDataBlockD* GetCoreDataBlockD(byte* _addr, bool forWrite)
        {
            var header = GetCoreDataHeader(_addr);
            byte pos = GetCoreDataBlockPos(header->personalRnd, CoreDataBlockId.D);
            byte* blockStart = _addr + CoreDataHeader.SIZE + pos * CoreData.CORE_DATA_BLOCK_SIZE;

            return (CoreDataBlockD*)blockStart;
        }

        protected unsafe static CoreDataHeader* GetCoreDataHeader(byte* addr)
        {
            return (CoreDataHeader*)addr;
        }

        private unsafe static byte GetCoreDataBlockPos(uint key, CoreDataBlockId blockId)
        {
            uint index = (key >> 13) & 0x1F;
            return BLOCK_POS_TABLE[index][(int)blockId];
        }

        private void UpdateChecksumAndEncode()
        {
            if (m_accessState.isEncoded || m_accessState.isFastMode)
                return;

            updateChecksumAndEncode_Core(m_pCoreData);

            if (m_pCalcData != null)
                updateChecksumAndEncode_Calc(m_pCoreData, m_pCalcData);

            m_accessState.isEncoded = true;
        }

        public static void updateChecksumAndEncode_Core(byte[] pCoreData)
        {
            unsafe
            {
                fixed (byte* addr = pCoreData)
                {
                    var header = GetCoreDataHeader(addr);
                    uint personalRnd = header->personalRnd;

                    byte* blocksStart = addr + CoreDataHeader.SIZE;
                    uint blocksSize = CORE_DATA_SIZE - CoreDataHeader.SIZE;

                    header->checksum = Encoder.CalcChecksum(blocksStart, blocksSize);

                    Encoder.Encode(blocksStart, blocksSize, personalRnd);
                }
            }
        }

        private static void updateChecksumAndEncode_Calc(byte[] pCoreData, byte[] pCalcData)
        {
            unsafe
            {
                fixed (byte* coreAddr = pCoreData)
                fixed (byte* calcAddr = pCalcData)
                {
                    var header = GetCoreDataHeader(coreAddr);
                    uint personalRnd = header->personalRnd;

                    Encoder.Encode(calcAddr, CALC_DATA_SIZE, personalRnd);
                }
            }
        }

        private void DecodeAndCheckIllegalWrite()
        {
            if (!m_accessState.isEncoded)
                return;

            unsafe
            {
                fixed (byte* addr = m_pCoreData)
                {
                    var header = GetCoreDataHeader(addr);
                    uint personalRnd = header->personalRnd;

                    byte* blocksStart = addr + CoreDataHeader.SIZE;
                    uint blocksSize = CORE_DATA_SIZE - CoreDataHeader.SIZE;

                    Encoder.Decode(blocksStart, blocksSize, personalRnd);
                }

                if (m_pCalcData != null)
                {
                    fixed (byte* calcAddr = m_pCalcData)
                    {
                        fixed (byte* coreAddr = m_pCoreData)
                        {
                            var header = GetCoreDataHeader(coreAddr);
                            Encoder.Decode(calcAddr, CALC_DATA_SIZE, header->personalRnd);
                        }
                    }
                }
            }

            m_accessState.isEncoded = false;
        }

        private unsafe void Serialize(void* bufferForCore, void* bufferForCalc)
        {
            var fastMode = IsFastMode();
            if (fastMode) EndFastMode();
            if (bufferForCore != null)
            {
                fixed (byte* src = m_pCoreData)
                    UnsafeUtility.MemCpy(bufferForCore, src, CORE_DATA_SIZE);
            }
            if (bufferForCalc != null)
            {
                fixed (byte* src = m_pCalcData)
                    UnsafeUtility.MemCpy(bufferForCalc, src, CALC_DATA_SIZE);
            }
            if (fastMode) StartFastMode();
        }

        private unsafe void Deserialize(void* serializedCoreData, void* serializedCalcData)
        {
            if (serializedCoreData != null)
            {
                GFL.ASSERT(m_pCoreData != null);
                fixed (byte* dst = m_pCoreData)
                    UnsafeUtility.MemCpy(dst, serializedCoreData, CORE_DATA_SIZE);
            }
            if (serializedCalcData != null)
            {
                GFL.ASSERT(m_pCalcData != null);
                fixed (byte* dst = m_pCalcData)
                    UnsafeUtility.MemCpy(dst, serializedCalcData, CALC_DATA_SIZE);
            }
            m_accessState.isEncoded = true;
            m_accessState.isFastMode = false;
            DecodeAndCheckIllegalWrite();
            UpdateChecksumAndEncode();
        }

        private unsafe void copyString(char* dst, string _src, int dst_len)
        {
            int len = Math.Min(_src.Length, dst_len - 1);
            for (int i = 0; i < len; i++)
                dst[i] = _src[i];
            for (int i = len; i < dst_len; i++)
                dst[i] = '\0';
        }

        private static void CalcWazaRecordBitPos(out byte arrayIndex, out byte bitFlag, byte recordIndex)
        {
            arrayIndex = (byte)(recordIndex / 8);
            bitFlag = (byte)(1 << (recordIndex % 8));
        }

        private static void CalcPokeJobBitPos(out byte arrayIndex, out byte bitFlag, byte jobIndex)
        {
            arrayIndex = (byte)(jobIndex / 8);
            bitFlag = (byte)(1 << (jobIndex % 8));
        }

        private struct AccessState
        {
            public bool isEncoded;
            public bool isFastMode;
        }
    }
}
