namespace Dpr.Battle.Logic
{
    public sealed class GRights
    {
        private readonly MainModule m_pMainModule;
        private readonly BattleEnv m_pBattleEnv;
        private ClientInfo[] m_clientInfo = Arrays.InitializeWithDefaultInstances<ClientInfo>((int)BTL_CLIENT_ID.BTL_CLIENT_NUM);
        private byte m_clientNum;
        private byte m_assignedClientIdx;
        private uint m_passedTurnCount;

        public GRights(MainModule pMainModule, BattleEnv pBattleEnv)
        {
            m_pMainModule = pMainModule;
            m_pBattleEnv = pBattleEnv;

            for (int i=0; i<m_clientInfo.Length; i++)
            {
                m_clientInfo[i].clientID = BTL_CLIENT_ID.BTL_CLIENT_NULL;
                m_clientInfo[i].isInvalid = false;
            }

            m_clientNum = 0;
            m_assignedClientIdx = 0;
            m_passedTurnCount = 0;
        }

        // TODO
        public void Initialize() { }

        // TODO
        public void CopyFrom(in GRights src) { }

        public bool IsGRightsRegulationExist()
        {
        	return 1 < this.m_clientNum;
        }

        // TODO
        public void AddClient(BTL_CLIENT_ID clientID) { }

        // TODO
        public void InvalidateClient(BTL_CLIENT_ID clientID) { }

        public byte GetClientNum()
        {
        	return (byte)(this.m_clientNum);
        }

        // TODO
        public int GetClientOrder(BTL_CLIENT_ID clientID) { return 0; }

        // TODO
        public BTL_CLIENT_ID GetClientByOrder(byte order) { return BTL_CLIENT_ID.BTL_CLIENT_PLAYER; }

        public unsafe BTL_CLIENT_ID GetAssignedClient()
        {
        	if (this.m_clientNum == 0) {
        	  return (BTL_CLIENT_ID)5;
        	}
        	if ((uint)this.m_assignedClientIdx < this.m_clientInfo.Length) {
        	  return *(uint *)
        	          (this.m_clientInfo + (ulong)this.m_assignedClientIdx * 8[0] +
        	          0x10);
        	}
        	return (BTL_CLIENT_ID)0;
        }

        public bool TransferRights()
        {
        	if (this.m_clientNum < 2) {
        	  return false;
        	}
        	var uVar3 = 0;
        	if (this.m_clientNum != 0) {
        	  uVar3 = this.m_assignedClientIdx + 1 / this.m_clientNum;
        	}
        	this.m_assignedClientIdx + 1 = this.m_assignedClientIdx + 1 - uVar3 * this.m_clientNum;
        	if (this.m_assignedClientIdx + 1 < this.m_clientInfo.Length) {
        	  this.m_assignedClientIdx = (byte)((char)this.m_assignedClientIdx + 1);
        	  this.m_passedTurnCount = 0;
        	  return true;
        	}
        }

        private byte getNextAssignTarget(byte currentIdx)
        {
        	if (this.m_clientNum != 0) {
        	  currentIdx = (byte)((currentIdx & 0xff) + 1);
        	  var uVar2 = 0;
        	  if (this.m_clientNum != 0) {
        	    uVar2 = currentIdx / this.m_clientNum;
        	  }
        	  currentIdx = (byte)(currentIdx - uVar2 * this.m_clientNum);
        	  if (this.m_clientInfo.Length <= currentIdx) {
        	  }
        	}
        	return (byte)(currentIdx);
        }

        private bool isAssignEnable(in ClientInfo clientInfo)
        {
        	return true;
        }

        public uint GetPassedTurnCount()
        {
        	return this.m_passedTurnCount;
        }

        public void IncPassedTurnCount()
        {
        	if (this.m_passedTurnCount < 9999) {
        	  this.m_passedTurnCount = this.m_passedTurnCount + 1;
        	}
        }

        private class ClientInfo
        {
            public BTL_CLIENT_ID clientID;
            public bool isInvalid;

            public void CopyFrom(ClientInfo src)
            {
                clientID = src.clientID;
                isInvalid = src.isInvalid;
            }
        }
    }
}