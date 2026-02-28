namespace Dpr.Battle.Logic
{
	public class PokeIDRegister
	{
		private byte m_count;
		private byte[] m_pokeID = new byte[PokeID.NUM];
		
		public PokeIDRegister()
		{
			Clear();
		}
		
		public void Clear()
		{
			m_count = 0;
		}
		
		public byte GetCount()
		{
			return (byte)(this.m_count);
		}
		
		// TODO
		public byte GetID(byte index) { return default; }
		
		public byte this[uint index]
		{
			get
			{
				if (index < m_count)
					return m_pokeID[index];
				else
					return m_pokeID[0];
			}
			set
			{
				m_pokeID[index] = value;
            }
		}
		
		// TODO
		public bool IsRegistered(byte pokeID) { return default; }
		
		// TODO
		public void Register(byte pokeID) { }
		
		// TODO
		public void Merge(in PokeIDRegister src) { }
	}
}