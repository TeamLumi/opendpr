using System;
using UnityEngine;

namespace Pml.PokePara
{
	[Serializable]
	public struct SerializedPokemonCore
	{
		[SerializeField]
		public byte[] buffer;
		
		public void CopyFrom(in SerializedPokemonCore src)
		{
			src.buffer.CopyTo(buffer, 0);
		}

		public void CreateWorkIfNeed(bool isRecreate = false)
		{
			if (buffer == null || isRecreate)
				buffer = new byte[CoreParam.DATASIZE];
		}
	}
}