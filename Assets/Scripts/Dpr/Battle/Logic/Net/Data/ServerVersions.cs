namespace Dpr.Battle.Logic.Net.Data
{
	public class ServerVersions
	{
		public const int ELEM_MAX = 4;
		public const int StationIndexInvalid = -1;

		private ServerVersionData[] m_element = new ServerVersionData[ELEM_MAX];
		private byte m_maxVersion;
		private byte m_serverClientID;
		
		public ServerVersions()
		{
			Initialize();
		}
		
		// TODO
		public void Initialize()
		{
			m_maxVersion = 0;
			m_serverClientID = (byte)BTL_CLIENT_ID.BTL_CLIENT_NULL;

			for (int i=0; i<m_element.Length; i++)
			{
                m_element[i].stationIndex = 0;
                m_element[i].version = 0;
                m_element[i].recvedFlag = false;
            }
		}
		
		// TODO
		public void SetServerVersion(int clientID, in ServerVersionData data) { }
		
		// TODO
		public int GetRecievedBits() { return default; }
		
		// TODO
		public void DetermineServerVersion() { }
		
		// TODO
		public bool RemoveByStationIndex(int stationIndex) { return default; }
		
		// TODO
		public bool ExistsByStationIndex(int stationIndex) { return default; }
		
		public byte MaxVersion()
		{
			return (byte)(this.m_maxVersion);
		}
		
		public byte GetServerClientID()
		{
			return (byte)(this.m_serverClientID);
		}
		
		public void SetServerClientID(byte clientId)
		{
			this.m_serverClientID = (byte)(clientId);
		}
		
		public bool IsDeterminedServer()
		{
			return this.m_serverClientID != '\x05';
		}
		
		// TODO
		public int GetStationIndex(BTL_CLIENT_ID clientID) { return default; }
		
		// TODO
		public BTL_CLIENT_ID GetClientID(int stationIndex) { return default; }
	}
}