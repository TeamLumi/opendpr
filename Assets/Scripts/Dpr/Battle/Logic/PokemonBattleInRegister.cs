namespace Dpr.Battle.Logic
{
	public sealed class PokemonBattleInRegister
	{
		private bool[] m_isPokemonBattleIn = new bool[PokeID.NUM];
		
		public PokemonBattleInRegister()
		{
			Clear();
		}
		
		public void Register(byte pokeId)
		{
			m_isPokemonBattleIn[pokeId] = true;
		}

		public bool Check(byte pokeId)
		{
			return m_isPokemonBattleIn[pokeId];
		}

		public void Clear()
		{
			for (int i = 0; i < m_isPokemonBattleIn.Length; i++)
				m_isPokemonBattleIn[i] = false;
		}
	}
}