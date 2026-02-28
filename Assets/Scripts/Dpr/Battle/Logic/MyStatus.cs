using DPData;
using Dpr.Message;
using Pml;
using Pml.PokePara;

namespace Dpr.Battle.Logic
{
    public class MyStatus
    {
        public string name;
        public bool sex;
        public MessageEnumData.MsgLangId lang;
        public uint id;
        public byte fashion;
        public byte body_type;
        public byte hat;
        public byte shoes;

        // TODO
        public void Deserialize(in MYSTATUS status) { }

        // TODO
        public void Deserialize(in MYSTATUS_COMM status) { }

        // TODO
        public void CopyFrom(MyStatus src) { }

        public string GetNameString()
        {
        	return this.name;
        }

        public Sex GetSex()
        {
        	return this.sex ^ 1;
        }

        public int GetHatVariation()
        {
        	return this.hat;
        }

        public int GetShoesVariation()
        {
        	return this.shoes;
        }

        public MessageEnumData.MsgLangId GetPokeLanguageId()
        {
        	return this.lang;
        }

        public bool IsMyPokemon(CoreParam poke)
        {
        	uint uVar6;
        	byte bVar2 = default;
        	byte bVar3 = default;
        	var uVar4 = poke.StartFastMode();
        	var iVar5 = poke.GetID();
        	if ((this.id == iVar5) &&
        	   (bVar2 = this.sex, bVar3 = poke.GetParentSex(),
        	   (bVar2 ^ 1) == bVar3)) {
        	  var uVar7 = poke.GetParentName();
        	  uVar6 = String.op_Equality(this.name,uVar7);
        	}
        	else {
        	  uVar6 = 0;
        	}
        	poke.EndFastMode(uVar4 & 1);
        	return uVar6 & 1;
        }

        // TODO
        public string GetModelID() { return string.Empty; }

        public int GetColorID()
        {
        	return this.body_type;
        }

        private Sex _sex { get => sex ? Sex.MALE : Sex.FEMALE; }

        public bool HasGBand()
        {
        	return false;
        }

        public void SetCyclingRoad()
        {
        	var uVar1 = 0xd;
        	if (this.sex != '\x01') {
        	  uVar1 = 0x71;
        	}
        	this.fashion = (byte)(uVar1);
        }

        public static void GetParamFromSysFlag(out byte hat, out byte shoes)
        {
        	var bVar1 = FlagWork.GetSysFlag(0x30b);
        	var bVar2 = FlagWork.GetFlag(0x4a);
        	hat = (byte)(~bVar1 & 1);
        	shoes = (byte)(~bVar2 & 1);
        }
    }
}
