using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class FieldStatus
    {
        private const int TURN_MAX = 16;
        private const int DEPEND_POKE_NUM_MAX = 5;
        private Data m_data = new Data();

        public FieldStatus()
        {
            Init();
        }

        public void Init()
        {
            initWork();
        }

        private void initWork()
        {
            clearFactorWork(EffectType.EFF_WEATHER);
            clearFactorWork(EffectType.EFF_TRICKROOM);
            clearFactorWork(EffectType.EFF_JURYOKU);
            clearFactorWork(EffectType.EFF_FUIN);
            clearFactorWork(EffectType.EFF_WONDERROOM);
            clearFactorWork(EffectType.EFF_MAGICROOM);
            clearFactorWork(EffectType.EFF_PLASMASHOWER);
            clearFactorWork(EffectType.EFF_FAIRY_LOCK);
            clearFactorWork(EffectType.EFF_GROUND);
            clearFactorWork(EffectType.EFF_KAGAKUHENKAGAS);

            m_data.weather = BtlWeather.BTL_WEATHER_NONE;
            m_data.weatherTurn = 0;
            m_data.weatherTurnCount = 0;
            m_data.weatherCausePokeID = 0;
        }

        // TODO
        public void CopyFrom(in FieldStatus src) { }

        public BtlWeather GetWeather()
        {
        	return this.m_data.weather;
        }

        public uint GetWeatherPassedTurn()
        {
        	return this.m_data.weatherTurnCount;
        }

        // TODO
        public uint GetWeatherRemainingTurn() { return 0; }

        public byte GetWeatherCausePokeID()
        {
        	return (byte)(this.m_data.weatherCausePokeID);
        }

        public uint GetWeatherWholeTurn()
        {
        	var iVar1 = this.m_data.weatherTurnCount;
        	if (this.m_data.weather != 0) {
        	  var iVar2 = this.m_data.weatherTurn;
        	  if (iVar2 != 0xff) {
        	    iVar2 = iVar2 - iVar1;
        	  }
        	  return iVar2 + iVar1;
        	}
        	return iVar1;
        }

        public uint GetWeatherTurnUpCount()
        {
        	return this.m_data.weatherTurnUpCount;
        }

        public void SetWeather(BtlWeather weather, ushort turn, ushort turnUpCount, byte causePokeID)
        {
        	this.m_data.weather = weather;
        	this.m_data.weatherTurn = turn & 0xffff;
        	this.m_data.weatherTurnUpCount = turnUpCount & 0xffff;
        	this.m_data.weatherTurnCount = 0;
        	this.m_data.weatherCausePokeID = causePokeID;
        }

        public void EndWeather()
        {
        	this.m_data.weather = 0;
        	this.m_data.weatherTurn = 0;
        	this.m_data.weatherTurnCount = 0;
        	this.m_data.weatherCausePokeID = 0x1f;
        }

        public BtlWeather TurnCheckWeather()
        {
        	if ((this.m_data.weather != 0) && (this.m_data.weatherTurn != 0xff)) {
        	  this.m_data.weatherTurnCount = this.m_data.weatherTurnCount + 1;
        	  if (this.m_data.weatherTurn <= this.m_data.weatherTurnCount) {
        	    var uVar1 = this.m_data.weather;
        	    this.m_data.weather = 0;
        	    this.m_data.weatherCausePokeID = 0x1f;
        	    return uVar1;
        	  }
        	}
        	return (BtlWeather)0;
        }

        public bool AddEffect(EffectType effect, in BTL_SICKCONT cont)
        {
        	addEffectCore();
        	return false;
        }

        // TODO
        private bool addEffectCore(EffectType effect, in BTL_SICKCONT cont, ushort sub_param) { return false; }

        public bool RemoveEffect(EffectType effect)
        {
        	if ((int)(int)effect < 10) {
        	  if (this.m_data.enableFlag.Length <= effect) {
        	  }
        	  if (this.m_data.enableFlag + (int)effect[0] != 0) {
        	    clearFactorWork();
        	    return true;
        	  }
        	}
        	return false;
        }

        // TODO
        public bool AddDependPoke(EffectType effect, byte pokeID) { return false; }

        // TODO
        public bool RemoveDependPoke(EffectType effect, byte pokeID) { return false; }

        // TODO
        public bool IsDependPoke(EffectType effect, byte pokeID) { return false; }

        // TODO
        public bool CheckFuin(in MainModule mainModule, POKECON pokeCon, BTL_POKEPARAM attacker, WazaNo waza) { return false; }

        // TODO
        public bool IncTurnCount(EffectType effect) { return false; }

        // TODO
        public bool CheckEffect(EffectType effect) { return false; }

        // TODO
        public bool CheckEffect(EffectType effect, ushort subParam) { return false; }

        // TODO
        public uint CheckRemainingTurn(EffectType effect) { return 0; }

        // TODO
        public uint GetPassedTurn(EffectType effect) { return 0; }

        // TODO
        public uint GetWholeTurn(EffectType effect) { return 0; }

        // TODO
        public byte GetDependPokeID(EffectType effect) { return 0; }

        // TODO
        private void clearFactorWork(EffectType effect) { }

        // TODO
        public uint GetDependPokeCount(EffectType effect) { return 0; }

        // TODO
        public bool IsKagakuhenkaGasEffective() { return false; }

        // TODO
        public bool CheckTokuseiEffectiveOnKagakuhenkaGas(TokuseiNo tokusei) { return false; }

        // TODO
        public bool ChangeGround(byte ground, BTL_SICKCONT cont) { return false; }

        public byte GetGround()
        {
        	return (byte)(this.m_data.currentGround);
        }

        // TODO
        public uint GetGroundPassedTurn() { return 0; }

        // TODO
        public uint GetGroundRemainingTurn() { return 0; }

        // TODO
        public uint GetGroundWholeTurn() { return 0; }

        // TODO
        public uint GetGroundTurnUpCount() { return 0; }

        // TODO
        public byte GetGroundCausePokeID() { return 0; }

        public delegate void TurnCheckCallback(EffectType UnnamedParameter, object UnnamedParameter2);

        private class Data
        {
            public BtlWeather weather;
            public uint weatherTurn;
            public uint weatherTurnUpCount;
            public uint weatherTurnCount;
            public byte weatherCausePokeID;
            public BtlGround currentGround;
            public BTL_SICKCONT[] cont = Arrays.InitializeWithDefaultInstances<BTL_SICKCONT>((int)EffectType.EFF_MAX);
            public uint[] turnCount = new uint[(int)EffectType.EFF_MAX];
            public uint[][] dependPokeID = RectangularArrays.RectangularDefaultArray<uint>((int)EffectType.EFF_MAX, DEPEND_POKE_NUM_MAX);
            public uint[] dependPokeCount = new uint[(int)EffectType.EFF_MAX];
            public bool[] enableFlag = new bool[(int)EffectType.EFF_MAX];
            public ushort[] subParam = new ushort[(int)EffectType.EFF_MAX];

            // TODO
            public void CopyFrom(Data src) { }
        }
    }
}