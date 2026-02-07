namespace Dpr.Battle.Logic
{
    public sealed class PokeDesc
    {
        public DefaultPowerUpDesc defaultPowerUpDesc = new DefaultPowerUpDesc();
        public bool isGEnableByNPC;

        public static void Clear(PokeDesc desc)
        {
            DEFAULT_POWERUP_DESC.Clear(desc.defaultPowerUpDesc);
            desc.isGEnableByNPC = false;
        }

        public static void Copy(PokeDesc dest, in PokeDesc src)
        {
            DEFAULT_POWERUP_DESC.Copy(dest.defaultPowerUpDesc, src.defaultPowerUpDesc);
            dest.isGEnableByNPC = src.isGEnableByNPC;
        }
    }
}