using System;
using UnityEngine;

namespace Pml.PokePara
{
    [Serializable]
    public struct SerializedPokemonFull
    {
        [SerializeField]
        public byte[] buffer;

        public void CopyFrom(in SerializedPokemonFull src)
        {
            src.buffer.CopyTo(buffer, 0);
        }

        public static void Swap(ref SerializedPokemonFull lhs, ref SerializedPokemonFull rhs)
        {
            var temp = new byte[PokemonParam.DATASIZE];
            lhs.buffer.CopyTo(temp, 0);
            rhs.buffer.CopyTo(lhs.buffer, 0);
            temp.CopyTo(rhs.buffer, 0);
        }

        public void CreateWorkIfNeed()
        {
            if (buffer == null)
            {
                buffer = new byte[PokemonParam.DATASIZE];
                Accessor.updateChecksumAndEncode_Core(buffer);
            }
        }
    }
}