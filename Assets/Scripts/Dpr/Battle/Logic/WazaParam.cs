using Pml.WazaData;
using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class WazaParam
    {
        public WazaNo wazaID;
        public WazaNo orgWazaID;
        public WazaNo gSrcWazaID;
        public PokeTypePair userType;
        public byte wazaType;
        public WazaDamageType damageType;
        public bool touchFlag;
        public WazaTarget targetType;
        public int wazaPri;
        public ushort wazaPower;
        public bool fMagicCoat;
        public bool fYokodori;
        public bool fItazuraGokoro;
        public bool fInvalidMessageDisable;

        public void ClearFlags()
        {
        	this.fMagicCoat = false;
        }

        public bool canInvalidMessageDisplay(uint count)
        {
        	return !this.fInvalidMessageDisable || count < 2;
        }

        // TODO
        public void CopyFrom(WazaParam src) { }

        // TODO
        public static void Init(WazaParam pParam) { }

        // TODO
        public static void Copy(WazaParam pDest, in WazaParam src) { }

        // TODO
        public WazaParam() { }
    }
}