using System;
using UnityEngine;

namespace Pml.PokePara
{
    [Serializable]
    public struct SerializedPokemonFull
    {
        [SerializeField]
        public byte[] buffer;

        // TODO
        public void CopyFrom(in SerializedPokemonFull src) { }

        public static void Swap(ref SerializedPokemonFull lhs, ref SerializedPokemonFull rhs)
        {
        	var uVar1 = new byte[0x158];
        	lhs.CopyTo(uVar1,0);
        	rhs.CopyTo(lhs,0);
        	uVar1.CopyTo(rhs,0);
        }

        // TODO
        public void CreateWorkIfNeed() { }
    }
}