using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class PartyDesc
    {
        public PokeDesc[] pokeDesc = Arrays.InitializeWithDefaultInstances<PokeDesc>(PokeParty.MAX_MEMBERS);

        public static void Clear(PartyDesc desc)
        {
            for (int i = 0; i < desc.pokeDesc.Length; i++)
            {
                PokeDesc.Clear(desc.pokeDesc[i]);
            }
        }

        public static void Copy(PartyDesc dest, in PartyDesc src)
        {
            for (int i = 0; i < dest.pokeDesc.Length; i++)
            {
                PokeDesc.Copy(dest.pokeDesc[i], src.pokeDesc[i]);
            }
        }
    }
}
