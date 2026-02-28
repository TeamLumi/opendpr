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
			if (pokeId < 0x1e) {
			  if (this.m_isPokemonBattleIn.Length <= (uint)pokeId) {
			  }
			  this.m_isPokemonBattleIn + (ulong)pokeId[0] = 1;
			}
		}
		
		public bool Check(byte pokeId)
		{
			if (0x1d < pokeId) {
			  return false;
			}
			if ((uint)pokeId < this.m_isPokemonBattleIn.Length) {
			  return this.m_isPokemonBattleIn + (ulong)pokeId[0] != 0;
			}
		}
		
		// TODO
		public void Clear() { }
	}
}