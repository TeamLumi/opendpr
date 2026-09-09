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

        // TODO
        public void Clear() { }

        // TODO
        public void Setup(BTL_POKEPARAM attacker, PokeSet targets, in PosPoke posPoke) { }

        public void ChangeAttackerPos(BtlPokePos atkPos) {
            this.attackerPos = atkPos;
        }

        public void ChangeEffectWazaID(WazaNo waza) {
            this.effectWazaID = waza;
        }

        // TODO
        public WazaNo GetEffectWazaID() { return WazaNo.NULL; }

        // TODO
        public void SetEnable() { }

        // TODO
        public void SetEnableDummy() { }

        public bool IsEnable() {
            return fEnable;
        }

        public bool IsDone() {
            return fDone;
        }

        public void SetEffectIndex(byte index) {
            this.effectIndex = index;
        }

        // TODO
        public void AddSubEffectPoke(byte pokeID) { }

        // TODO
        public void ClearSubEffectParams() { }

        // TODO
        public bool IsSubEffectParamsValid() { return false; }

        public bool IsGShockOccur() {
            return isGShockOccur;
        }

        // TODO
        public void SetGShockOccur() { }

        // TODO
        public void SetSyncDamageEffectEnable() { }
    }
}