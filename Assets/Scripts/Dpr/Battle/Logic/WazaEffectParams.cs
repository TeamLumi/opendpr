using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class WazaEffectParams
    {
        public WazaNo effectWazaID;
        public BtlPokePos attackerPos;
        public BtlPokePos targetPos;
        public byte effectIndex;
        public byte pluralHitIndex;
        public bool isGShockOccur;
        public bool fEnable;
        public bool fDone;
        public ushort commandQueuePos;
        public bool isSyncDamageEffect;
        public byte subEff_pokeCnt;
        public byte subEff_pokeID_1;
        public byte subEff_pokeID_2;
        public byte subEff_pokeID_3;
        public byte subEff_pokeID_4;
        public byte subEff_pokeID_5;

        // TODO
        public void CopyFrom(WazaEffectParams src) { }

        public void Clear()
        {
        	this.attackerPos = (BtlPokePos)0x505;
        	this.effectWazaID = (WazaNo)0;
        	this.effectIndex = (byte)0;
        	this.fDone = false;
        	this.commandQueuePos = (ushort)0xffff;
        	this.isSyncDamageEffect = false;
        	this.subEff_pokeID_2 = (byte)0;
        }

        // TODO
        public void Setup(BTL_POKEPARAM attacker, PokeSet targets, in PosPoke posPoke) { }

        public void ChangeAttackerPos(BtlPokePos atkPos)
        {
        	this.attackerPos = (BtlPokePos)(atkPos);
        }

        public void ChangeEffectWazaID(WazaNo waza)
        {
        	this.effectWazaID = (WazaNo)(waza);
        }

        public WazaNo GetEffectWazaID()
        {
        	return this.effectWazaID;
        }

        public void SetEnable()
        {
        	this.fEnable = true;
        }

        public void SetEnableDummy()
        {
        	if (this.fEnable) {
        	}
        	this.fEnable = 0x101;
        }

        public bool IsEnable()
        {
        	return this.fEnable;
        }

        public bool IsDone()
        {
        	return this.fDone;
        }

        public void SetEffectIndex(byte index)
        {
        	this.effectIndex = (byte)(index);
        }

        // TODO
        public void AddSubEffectPoke(byte pokeID) { }

        public void ClearSubEffectParams()
        {
        	this.subEff_pokeID_4 = (byte)0;
        	this.subEff_pokeCnt = (byte)0;
        }

        public bool IsSubEffectParamsValid()
        {
        	return this.subEff_pokeCnt != 0;
        }

        public bool IsGShockOccur()
        {
        	return this.isGShockOccur;
        }

        public void SetGShockOccur()
        {
        	this.isGShockOccur = true;
        }

        public void SetSyncDamageEffectEnable()
        {
        	this.isSyncDamageEffect = true;
        }
    }
}