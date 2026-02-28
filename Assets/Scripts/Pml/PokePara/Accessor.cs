namespace Pml.PokePara
{
    public class Accessor
    {
        // TODO: cctor

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
        private static unsafe byte* IllegalCoreData;
        private static unsafe byte* DummyWriteCoreData;
        private static unsafe byte* IllegalCalcData;
        private static unsafe byte* DummyWriteCalcData;
        private byte[] m_pCalcData;
        private byte[] m_pCoreData;
        private AccessState m_accessState;
        private const byte POS1 = 0;
        private const byte POS2 = 1;
        private const byte POS3 = 2;
        private const byte POS4 = 3;
        private static readonly byte[][] BLOCK_POS_TABLE;

        // TODO
        public static void Initialize() { }

        public void AttachDecodedData(byte[] coreData, byte[] calcData)
        {
        	this.m_pCoreData = coreData;
        	this.m_pCalcData = calcData;
        	this.m_accessState = null;
        	UpdateChecksumAndEncode();
        }

        public void AttachEncodedData(byte[] coreData, byte[] calcData)
        {
        	this.m_pCoreData = coreData;
        	this.m_pCalcData = calcData;
        	this.m_accessState = 1;
        }

        public bool HaveCalcData()
        {
        	return this.m_pCalcData != null;
        }

        // TODO
        public void ClearData() { }

        // TODO
        public void ClearCalcData() { }

        // TODO
        public void StartFastMode() { }

        // TODO
        public void EndFastMode() { }

        // TODO
        public bool IsFastMode() { return false; }

        public bool IsEncoded()
        {
        	return this.m_accessState;
        }

        // TODO
        public void Serialize_FullData(byte[] buffer) { }

        // TODO
        public void Serialize_CoreData(byte[] buffer) { }

        // TODO
        public void Deserialize_FullData(byte[] serializedData) { }

        // TODO
        public void Deserialize_CoreData(byte[] serializedData) { }

        public unsafe void Serialize_FullData(void* buffer)
        {
            Serialize(buffer, (void*)((long)buffer + CORE_SERIALIZE_DATA_SIZE));
        }

        public unsafe void Serialize_CoreData(void* buffer)
        {
            Serialize(buffer, null);
        }

        public unsafe void Deserialize_FullData(void* serializedData)
        {
            Deserialize(serializedData, (void*)((long)serializedData + CORE_SERIALIZE_DATA_SIZE));
        }

        public unsafe void Deserialize_CoreData(void* serializedData)
        {
            Deserialize(serializedData, null);
        }

        // TODO
        public uint GetPersonalRnd() { return 0; }

        // TODO
        public uint GetColorRnd() { return 0; }

        // TODO
        public uint GetCheckSum() { return 0; }

        // TODO
        public bool IsFuseiTamago() { return false; }

        // TODO
        public uint GetSick() { return 0; }

        // TODO
        public MonsNo GetMonsNo() { return MonsNo.NULL; }

        // TODO
        public uint GetItemNo() { return 0; }

        // TODO
        public uint GetID() { return 0; }

        // TODO
        public uint GetExp() { return 0; }

        // TODO
        public uint GetFriendship() { return 0; }

        // TODO
        public TokuseiNo GetTokuseiNo() { return TokuseiNo.NULL; }

        // TODO
        public ushort GetBoxMark() { return 0; }

        // TODO
        public uint GetLangId() { return 0; }

        // TODO
        public uint GetEffortHp() { return 0; }

        // TODO
        public uint GetEffortAtk() { return 0; }

        public uint GetEffortDef()
        {
        	long lVar3;
        	if (this.m_pCoreData == null) {
        	  lVar3 = 0;
        	}
        	else {
        	  lVar3 = 0;
        	  if (this.m_pCoreData.Length != 0) {
        	    lVar3 = this.m_pCoreData + 0x20;
        	  }
        	}
        	DecodeAndCheckIllegalWrite();
        	this.m_pCoreData = GetCoreDataBlockA(lVar3);
        	var uVar1 = this.m_pCoreData[0];
        	UpdateChecksumAndEncode();
        	return uVar1;
        }

        // TODO
        public uint GetEffortSpAtk() { return 0; }

        // TODO
        public uint GetEffortSpDef() { return 0; }

        // TODO
        public uint GetEffortAgi() { return 0; }

        // TODO
        public byte GetStyle() { return 0; }

        // TODO
        public byte GetBeautiful() { return 0; }

        // TODO
        public byte GetCute() { return 0; }

        // TODO
        public byte GetClever() { return 0; }

        // TODO
        public byte GetStrong() { return 0; }

        // TODO
        public byte GetFur() { return 0; }

        // TODO
        public bool HaveRibbon(uint ribbonNo) { return false; }

        // TODO
        public uint GetLumpingRibbon(LumpingRibbon ribbonId) { return default; }

        // TODO
        public byte GetEquipRibbonNo() { return 0; }

        // TODO
        public WazaNo GetWazaNo(byte wazaIndex) { return WazaNo.NULL; }

        // TODO
        public byte GetPP(byte wazaIndex) { return 0; }

        // TODO
        public byte GetWazaPPUpCount(byte wazaIndex) { return 0; }

        // TODO
        public WazaNo GetTamagoWazaNo(byte index) { return WazaNo.NULL; }

        // TODO
        public uint GetTalentHp() { return 0; }

        // TODO
        public uint GetTalentAtk() { return 0; }

        // TODO
        public uint GetTalentDef() { return 0; }

        // TODO
        public uint GetTalentSpAtk() { return 0; }

        // TODO
        public uint GetTalentSpDef() { return 0; }

        // TODO
        public uint GetTalentAgi() { return 0; }

        // TODO
        public uint GetEffortG() { return 0; }

        // TODO
        public bool IsEventPokemon() { return false; }

        // TODO
        public bool GetOfficialBattleEnableFlag() { return false; }

        // TODO
        public Sex GetSex() { return Sex.MALE; }

        // TODO
        public ushort GetFormNo() { return 0; }

        public uint GetSeikaku()
        {
        	long lVar3;
        	if (this.m_pCoreData == null) {
        	  lVar3 = 0;
        	}
        	else {
        	  lVar3 = 0;
        	  if (this.m_pCoreData.Length != 0) {
        	    lVar3 = this.m_pCoreData + 0x20;
        	  }
        	}
        	DecodeAndCheckIllegalWrite();
        	this.m_pCoreData = GetCoreDataBlockA(lVar3);
        	var uVar1 = this.m_pCoreData.Length;
        	UpdateChecksumAndEncode();
        	return uVar1;
        }

        // TODO
        public uint GetSeikakuHosei() { return 0; }

        // TODO
        public bool IsTokusei1() { return false; }

        // TODO
        public bool IsTokusei2() { return false; }

        // TODO
        public bool IsTokusei3() { return false; }

        // TODO
        public bool IsFavorite() { return false; }

        // TODO
        public bool IsSpecialGEnable() { return false; }

        // TODO
        public bool IsTamago() { return false; }

        // TODO
        public bool HaveNickName() { return false; }

        // TODO
        public string GetNickName() { return ""; }

        // TODO
        public uint GetCassetteVersion() { return 0; }

        public string GetOyaName()
        {
        	if (this.m_pCoreData == null) {
        	  var lVar3 = 0;
        	}
        	else {
        	  lVar3 = 0;
        	  if (this.m_pCoreData.Length != 0) {
        	    lVar3 = this.m_pCoreData + 0x20;
        	  }
        	}
        	DecodeAndCheckIllegalWrite();
        	var uVar1 = GetCoreDataBlockD(lVar3);
        	uVar1 = 0.CreateString(uVar1);
        	UpdateChecksumAndEncode();
        	return uVar1;
        }

        // TODO
        public uint GetTamagoGetYear() { return 0; }

        // TODO
        public uint GetTamagoGetMonth() { return 0; }

        // TODO
        public uint GetTamagoGetDay() { return 0; }

        // TODO
        public uint GetBirthYear() { return 0; }

        // TODO
        public uint GetBirthMonth() { return 0; }

        // TODO
        public uint GetBirthDay() { return 0; }

        // TODO
        public uint GetGetPlace() { return 0; }

        // TODO
        public uint GetBirthPlace() { return 0; }

        // TODO
        public uint GetPokerus() { return 0; }

        // TODO
        public uint GetGetBall() { return 0; }

        // TODO
        public uint GetGetLevel() { return 0; }

        // TODO
        public Sex GetOyasex() { return Sex.MALE; }

        // TODO
        public uint GetLevel() { return 0; }

        // TODO
        public uint GetHp() { return 0; }

        // TODO
        public uint GetMaxHp() { return 0; }

        // TODO
        public uint GetAtk() { return 0; }

        // TODO
        public uint GetDef() { return 0; }

        // TODO
        public uint GetSpAtk() { return 0; }

        // TODO
        public uint GetSpDef() { return 0; }

        // TODO
        public uint GetAgi() { return 0; }

        // TODO
        public GState GetGState() { return GState.NONE; }

        // TODO
        public byte GetEnjoy() { return 0; }

        // TODO
        public byte GetNadenadeValue() { return 0; }

        // TODO
        public ushort GetOthersFriendshipTrainerID() { return 0; }

        // TODO
        public bool GetOwnedOthersFlag() { return false; }

        // TODO
        public byte GetOriginalFriendship() { return 0; }

        public byte GetOthersFriendship()
        {
        	long lVar3;
        	if (this.m_pCoreData == null) {
        	  lVar3 = 0;
        	}
        	else {
        	  lVar3 = 0;
        	  if (this.m_pCoreData.Length != 0) {
        	    lVar3 = this.m_pCoreData + 0x20;
        	  }
        	}
        	DecodeAndCheckIllegalWrite();
        	this.m_pCoreData = GetCoreDataBlockC(lVar3);
        	var uVar1 = this.m_pCoreData[0];
        	UpdateChecksumAndEncode();
        	return (byte)(uVar1);
        }

        // TODO
        public byte GetMemoriesLevel() { return 0; }

        // TODO
        public byte GetMemoriesCode() { return 0; }

        // TODO
        public ushort GetMemoriesData() { return 0; }

        public byte GetMemoriesFeel()
        {
        	long lVar3;
        	if (this.m_pCoreData == null) {
        	  lVar3 = 0;
        	}
        	else {
        	  lVar3 = 0;
        	  if (this.m_pCoreData.Length != 0) {
        	    lVar3 = this.m_pCoreData + 0x20;
        	  }
        	}
        	DecodeAndCheckIllegalWrite();
        	this.m_pCoreData = GetCoreDataBlockD(lVar3);
        	var uVar1 = this.m_pCoreData[0];
        	UpdateChecksumAndEncode();
        	return (byte)(uVar1);
        }

        // TODO
        public byte GetOthersMemoriesLevel() { return 0; }

        // TODO
        public byte GetOthersMemoriesCode() { return 0; }

        // TODO
        public ushort GetOthersMemoriesData() { return 0; }

        // TODO
        public byte GetOthersMemoriesFeel() { return 0; }

        public string GetPastParentsName()
        {
        	if (this.m_pCoreData == null) {
        	  var lVar3 = 0;
        	}
        	else {
        	  lVar3 = 0;
        	  if (this.m_pCoreData.Length != 0) {
        	    lVar3 = this.m_pCoreData + 0x20;
        	  }
        	}
        	DecodeAndCheckIllegalWrite();
        	var uVar1 = GetCoreDataBlockC(lVar3);
        	uVar1 = 0.CreateString(uVar1);
        	UpdateChecksumAndEncode();
        	return uVar1;
        }

        // TODO
        public Sex GetPastParentsSex() { return Sex.NUM; }

        // TODO
        public byte GetPastParentsLangID() { return 0; }

        public bool CompareOyaName(string cmpName)
        {
        	if (this.m_pCoreData == null) {
        	  var lVar3 = 0;
        	}
        	else {
        	  lVar3 = 0;
        	  if (this.m_pCoreData.Length != 0) {
        	    lVar3 = this.m_pCoreData + 0x20;
        	  }
        	}
        	DecodeAndCheckIllegalWrite();
        	var uVar1 = GetCoreDataBlockD(lVar3);
        	uVar1 = 0.CreateString(uVar1);
        	UpdateChecksumAndEncode();
        	cmpName.Equals(uVar1);
        	return false;
        }

        // TODO
        public uint GetMultiPurposeWork() { return 0; }

        // TODO
        public byte GetTrainingFlag() { return 0; }

        // TODO
        public bool GetWazaRecordFlag(byte recordIndex) { return false; }

        // TODO
        public bool GetPokeJobFlag(byte jobIndex) { return false; }

        // TODO
        public byte GetCampFriendship() { return 0; }

        // TODO
        public uint GetPalma() { return 0; }

        // TODO
        public byte GetTalentHeight() { return 0; }

        // TODO
        public byte GetTalentWeight() { return 0; }

        // TODO
        public byte GetBattleRomMark() { return 0; }

        // TODO
        public void SetDprIllegalFlag(bool flag) { }

        // TODO
        public bool GetDprIllegalFlag() { return false; }

        // TODO
        public void SetPersonalRnd(uint rnd) { }

        // TODO
        public void SetColorRnd(uint rnd) { }

        // TODO
        public void SetSick(uint sick) { }

        // TODO
        public void SetFuseiTamagoFlag(bool flag) { }

        // TODO
        public void SetCheckSum(ushort checksum) { }

        // TODO
        public void SetMonsNo(uint monsno) { }

        // TODO
        public void SetItemNo(ushort itemno) { }

        // TODO
        public void SetID(uint id) { }

        // TODO
        public void SetExp(uint exp) { }

        // TODO
        public void SetFriendship(byte friendship) { }

        // TODO
        public void SetTokuseiNo(uint tokusei) { }

        // TODO
        public void SetBoxMark(ushort mark) { }

        // TODO
        public void SetLangId(byte langId) { }

        // TODO
        public void SetEffortHp(byte value) { }

        // TODO
        public void SetEffortAtk(byte value) { }

        public void SetEffortDef(byte value)
        {
        	long lVar2;
        	if (this.m_pCoreData == null) {
        	  lVar2 = 0;
        	}
        	else {
        	  lVar2 = 0;
        	  if (this.m_pCoreData.Length != 0) {
        	    lVar2 = this.m_pCoreData + 0x20;
        	  }
        	}
        	DecodeAndCheckIllegalWrite();
        	this.m_pCoreData = GetCoreDataBlockA(lVar2,1);
        	this.m_pCoreData[0] = value;
        	UpdateChecksumAndEncode();
        }

        // TODO
        public void SetEffortSpAtk(byte value) { }

        // TODO
        public void SetEffortSpDef(byte value) { }

        // TODO
        public void SetEffortAgi(byte value) { }

        // TODO
        public void SetStyle(byte style) { }

        // TODO
        public void SetBeautiful(byte beautiful) { }

        // TODO
        public void SetCute(byte cute) { }

        // TODO
        public void SetClever(byte clever) { }

        // TODO
        public void SetStrong(byte strong) { }

        // TODO
        public void SetFur(byte fur) { }

        // TODO
        public void SetRibbon(uint ribbonNo) { }

        // TODO
        public void RemoveRibbon(uint ribbonNo) { }

        // TODO
        public void SetLumpingRibbon(LumpingRibbon ribbonId, uint num) { }

        // TODO
        public void SetEquipRibbonNo(byte ribbonNo) { }

        // TODO
        public void SetWazaNo(byte wazaIndex, uint wazano) { }

        // TODO
        public void SetPP(byte wazaIndex, byte pp) { }

        // TODO
        public void SetWazaPPUpCount(byte wazaIndex, byte count) { }

        // TODO
        public void SetTamagoWazaNo(byte index, uint wazano) { }

        // TODO
        public void SetTalentHp(byte value) { }

        // TODO
        public void SetTalentAtk(byte value) { }

        // TODO
        public void SetTalentDef(byte value) { }

        // TODO
        public void SetTalentSpAtk(byte value) { }

        // TODO
        public void SetTalentSpDef(byte value) { }

        // TODO
        public void SetTalentAgi(byte value) { }

        // TODO
        public void SetEffortG(byte value) { }

        // TODO
        public void SetEventPokemonFlag(bool flag) { }

        // TODO
        public void SetOfficialBattleEnableFlag(bool flag) { }

        // TODO
        public void SetSex(Sex sex) { }

        // TODO
        public void SetFormNo(ushort formno) { }

        public void SetSeikaku(uint seikaku)
        {
        	long lVar2;
        	if (this.m_pCoreData == null) {
        	  lVar2 = 0;
        	}
        	else {
        	  lVar2 = 0;
        	  if (this.m_pCoreData.Length != 0) {
        	    lVar2 = this.m_pCoreData + 0x20;
        	  }
        	}
        	DecodeAndCheckIllegalWrite();
        	this.m_pCoreData = GetCoreDataBlockA(lVar2,1);
        	this.m_pCoreData.Length = seikaku;
        	UpdateChecksumAndEncode();
        }

        // TODO
        public void SetSeikakuHosei(uint seikaku) { }

        // TODO
        public void SetTamagoFlag(bool flag) { }

        // TODO
        public void SetTokusei1Flag(bool flag) { }

        // TODO
        public void SetTokusei2Flag(bool flag) { }

        // TODO
        public void SetTokusei3Flag(bool flag) { }

        // TODO
        public void SetFavoriteFlag(bool flag) { }

        // TODO
        public void SetSpecialGFlag(bool flag) { }

        // TODO
        private unsafe void copyString(char* dst, string _src, int dst_len) { }

        // TODO
        public void SetNickName(string nickName) { }

        // TODO
        public void SetNickNameFlag(bool flag) { }

        // TODO
        public void SetCassetteVersion(uint version) { }

        // TODO
        public void SetOyaName(string oyaName) { }

        // TODO
        public void SetTamagoGetYear(byte year) { }

        // TODO
        public void SetTamagoGetMonth(byte month) { }

        // TODO
        public void SetTamagoGetDay(byte day) { }

        // TODO
        public void SetBirthYear(byte year) { }

        // TODO
        public void SetBirthMonth(byte month) { }

        // TODO
        public void SetBirthDay(byte day) { }

        // TODO
        public void SetGetPlace(ushort place) { }

        // TODO
        public void SetBirthPlace(ushort place) { }

        // TODO
        public void SetPokerus(byte pokerus) { }

        // TODO
        public void SetGetBall(byte ball) { }

        // TODO
        public void SetGetLevel(byte level) { }

        // TODO
        public void SetOyasex(Sex sex) { }

        // TODO
        public void SetLevel(byte level) { }

        // TODO
        public void SetMaxHp(ushort maxHp) { }

        // TODO
        public void SetHp(ushort hp) { }

        // TODO
        public void SetAtk(ushort atk) { }

        // TODO
        public void SetDef(ushort def) { }

        // TODO
        public void SetSpAtk(ushort spatk) { }

        // TODO
        public void SetSpDef(ushort spdef) { }

        // TODO
        public void SetAgi(ushort agi) { }

        // TODO
        public void SetGState(GState state) { }

        // TODO
        public void SetEnjoy(byte enjoy) { }

        // TODO
        public void SetNadenadeValue(byte value) { }

        // TODO
        public void SetOthersFriendshipTrainerID(ushort trainerId) { }

        // TODO
        public void SetOwnedOthersFlag(bool flag) { }

        // TODO
        public void SetOriginalFriendship(byte friendship) { }

        public void SetOthersFriendship(byte friendship)
        {
        	long lVar2;
        	if (this.m_pCoreData == null) {
        	  lVar2 = 0;
        	}
        	else {
        	  lVar2 = 0;
        	  if (this.m_pCoreData.Length != 0) {
        	    lVar2 = this.m_pCoreData + 0x20;
        	  }
        	}
        	DecodeAndCheckIllegalWrite();
        	this.m_pCoreData = GetCoreDataBlockC(lVar2,1);
        	this.m_pCoreData[0] = friendship;
        	UpdateChecksumAndEncode();
        }

        // TODO
        public void SetMemoriesLevel(byte level) { }

        // TODO
        public void SetMemoriesCode(byte code) { }

        // TODO
        public void SetMemoriesData(ushort data) { }

        public void SetMemoriesFeel(byte feel)
        {
        	long lVar2;
        	if (this.m_pCoreData == null) {
        	  lVar2 = 0;
        	}
        	else {
        	  lVar2 = 0;
        	  if (this.m_pCoreData.Length != 0) {
        	    lVar2 = this.m_pCoreData + 0x20;
        	  }
        	}
        	DecodeAndCheckIllegalWrite();
        	this.m_pCoreData = GetCoreDataBlockD(lVar2,1);
        	this.m_pCoreData[0] = feel;
        	UpdateChecksumAndEncode();
        }

        // TODO
        public void SetOthersMemoriesLevel(byte level) { }

        // TODO
        public void SetOthersMemoriesCode(byte code) { }

        // TODO
        public void SetOthersMemoriesData(ushort data) { }

        // TODO
        public void SetOthersMemoriesFeel(byte feel) { }

        // TODO
        public void SetPastParentsName(string name) { }

        // TODO
        public void SetPastParentsSex(Sex sex) { }

        // TODO
        public void SetPastParentsLangID(byte langID) { }

        // TODO
        public void SetMultiPurposeWork(uint value) { }

        // TODO
        public void SetTrainingFlag(byte value) { }

        // TODO
        public void SetWazaRecordFlag(byte recordIndex, bool set) { }

        public void ClearWazaRecordFlag()
        {
        	long lVar2;
        	if (this.m_pCoreData == null) {
        	  lVar2 = 0;
        	}
        	else {
        	  lVar2 = 0;
        	  if (this.m_pCoreData.Length != 0) {
        	    lVar2 = this.m_pCoreData + 0x20;
        	  }
        	}
        	DecodeAndCheckIllegalWrite();
        	this.m_pCoreData = GetCoreDataBlockD(lVar2,1);
        	UnsafeUtility.MemClear(this.m_pCoreData + 0x2f,0xe);
        	UpdateChecksumAndEncode();
        }

        // TODO
        public ulong GetBankUniqueID() { return 0; }

        // TODO
        public void SetBankUniqueID(ulong value) { }

        public void ClearBankUniqueID()
        {
        	long lVar2;
        	if (this.m_pCoreData == null) {
        	  lVar2 = 0;
        	}
        	else {
        	  lVar2 = 0;
        	  if (this.m_pCoreData.Length != 0) {
        	    lVar2 = this.m_pCoreData + 0x20;
        	  }
        	}
        	DecodeAndCheckIllegalWrite();
        	this.m_pCoreData = GetCoreDataBlockD(lVar2,1);
        	UnsafeUtility.MemClear(this.m_pCoreData + 0x3d,8);
        	UpdateChecksumAndEncode();
        }

        // TODO
        public void SetPokeJobFlag(byte jobIndex, bool set) { }

        public void ClearPokeJobFlag()
        {
        	long lVar2;
        	if (this.m_pCoreData == null) {
        	  lVar2 = 0;
        	}
        	else {
        	  lVar2 = 0;
        	  if (this.m_pCoreData.Length != 0) {
        	    lVar2 = this.m_pCoreData + 0x20;
        	  }
        	}
        	DecodeAndCheckIllegalWrite();
        	this.m_pCoreData = GetCoreDataBlockC(lVar2,1);
        	UnsafeUtility.MemClear(this.m_pCoreData + 0x26,0xe);
        	UpdateChecksumAndEncode();
        }

        // TODO
        public void SetCampFriendship(byte value) { }

        // TODO
        public void SetPalma(uint value) { }

        // TODO
        public void SetTalentHeight(byte value) { }

        // TODO
        public void SetTalentWeight(byte value) { }

        // TODO
        public void SetBattleRomMark(byte value) { }

        // TODO
        public void RemoveAllRibbon() { }

        // TODO
        private unsafe CalcData* GetCalcData(byte* _addr, bool forWrite) { return default; }

        // TODO
        private unsafe CoreDataBlockA* GetCoreDataBlockA(byte* _addr, bool forWrite) { return default; }

        // TODO
        private unsafe CoreDataBlockB* GetCoreDataBlockB(byte* _addr, bool forWrite) { return default; }

        // TODO
        private unsafe CoreDataBlockC* GetCoreDataBlockC(byte* _addr, bool forWrite) { return default; }

        // TODO
        private unsafe CoreDataBlockD* GetCoreDataBlockD(byte* _addr, bool forWrite) { return default; }

        // TODO
        protected unsafe static CoreDataHeader* GetCoreDataHeader(byte* addr) { return null; }

        // TODO
        private unsafe static byte GetCoreDataBlockPos(uint key, CoreDataBlockId blockId) { return default; }

        // TODO
        private void UpdateChecksumAndEncode() { }

        // TODO
        public static void updateChecksumAndEncode_Core(byte[] pCoreData) { }

        // TODO
        private static void updateChecksumAndEncode_Calc(byte[] pCoreData, byte[] pCalcData) { }

        // TODO
        private void DecodeAndCheckIllegalWrite() { }

        // TODO
        private unsafe void Serialize(void* bufferForCore, void* bufferForCalc) { }

        private unsafe void Deserialize(void* serializedCoreData, void* serializedCalcData)
        {
        	long lVar1;
        	if (serializedCoreData != 0) {
        	  GFL.ASSERT(this.m_pCoreData != null);
        	  if (this.m_pCoreData == null) {
        	    lVar1 = 0;
        	  }
        	  else {
        	    lVar1 = 0;
        	    if (this.m_pCoreData.Length != 0) {
        	      lVar1 = this.m_pCoreData + 0x20;
        	    }
        	  }
        	  UnsafeUtility.MemCpy(lVar1,serializedCoreData,0x148);
        	}
        	if (serializedCalcData != 0) {
        	  GFL.ASSERT(this.m_pCalcData != null);
        	  if (this.m_pCalcData == null) {
        	    lVar1 = 0;
        	  }
        	  else {
        	    lVar1 = 0;
        	    if (this.m_pCalcData.Length != 0) {
        	      lVar1 = this.m_pCalcData + 0x20;
        	    }
        	  }
        	  UnsafeUtility.MemCpy(lVar1,serializedCalcData,0x10);
        	}
        	this.m_accessState = 1;
        	DecodeAndCheckIllegalWrite();
        	UpdateChecksumAndEncode();
        }

        private static void CalcWazaRecordBitPos(out byte arrayIndex, out byte bitFlag, byte recordIndex)
        {
        	arrayIndex = (byte)(recordIndex >> 3) & 0x1f;
        	bitFlag = (byte)((char)(1 << ((ulong)recordIndex & 7)));
        }

        private static void CalcPokeJobBitPos(out byte arrayIndex, out byte bitFlag, byte jobIndex)
        {
        	arrayIndex = (byte)(jobIndex >> 3) & 0x1f;
        	bitFlag = (byte)((char)(1 << ((ulong)jobIndex & 7)));
        }

        private struct AccessState
        {
	        public bool isEncoded;
            public bool isFastMode;
        }
    }
}
