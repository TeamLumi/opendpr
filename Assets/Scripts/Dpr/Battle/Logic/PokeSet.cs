namespace Dpr.Battle.Logic
{
    public class PokeSet
    {
        private BTL_POKEPARAM[] m_bpp;
        private ushort[] m_damage;
        private ushort[] m_migawariDamage;
        private byte[] m_damageType;
        private ushort[] m_sortWork;
        private byte m_count;
        private byte m_countMax;
        private byte m_getIdx;
        private byte m_targetPosCount;

        // TODO
        public PokeSet() { }

        // TODO
        public void Clear() { }

        // TODO
        public void Add(BTL_POKEPARAM bpp) { }

        // TODO
        public void AddWithDamage(BTL_POKEPARAM bpp, ushort damage, bool fMigawariDamage) { }

        // TODO
        public void Remove(BTL_POKEPARAM bpp) { }

        // TODO
        public BTL_POKEPARAM Get(uint idx) { return null; }

        // TODO
        public void SeekStart() { }

        // TODO
        public BTL_POKEPARAM SeekNext() { return null; }

        // TODO
        public bool GetDamage(BTL_POKEPARAM bpp, out uint damage)
        {
            damage = 0;
            return false;
        }

        // TODO
        public bool GetDamageReal(BTL_POKEPARAM bpp, out uint damage)
        {
            damage = 0;
            return false;
        }

        // TODO
        public DamageType GetDamageType(BTL_POKEPARAM bpp) { return DamageType.DMGTYPE_NONE; }

        public uint GetCount() {
            return m_count;
        }

        public uint GetCountMax() {
            return m_countMax;
        }

        // TODO
        public uint GetAliveCount() { return 0; }

        public void SetDefaultTargetCount(byte cnt) {
            this.m_targetPosCount = cnt;
        }

        // TODO
        public bool IsRemovedAll() { return false; }

        // TODO
        public uint CopyAlive(PokeSet dst) { return 0; }

        // TODO
        public uint CopyFriends(in MainModule mainModule, BTL_POKEPARAM bpp, PokeSet dst) { return 0; }

        // TODO
        public uint CopyEnemys(in MainModule mainModule, BTL_POKEPARAM bpp, PokeSet dst) { return 0; }

        // TODO
        public void RemoveDisablePoke(in PosPoke posPoke) { }

        // TODO
        public void Swap(byte index1, byte index2) { }

        // TODO
        public void CopyFrom(in PokeSet src) { }

        public enum DamageType : int
        {
            DMGTYPE_NONE = 0,
            DMGTYPE_REAL = 1,
            DMGTYPE_MIGAWARI = 2,
        }
    }
}