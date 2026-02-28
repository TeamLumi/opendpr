namespace Dpr.Battle.Logic
{
    public sealed class ClientSeq_TrainerMessage
    {
        private MainModule m_pMainModule;
        private BattleViewBase m_pViewSystem;
        private TrainerMessageManager m_pMessageManager;
        private int m_seq;
        internal bool m_isFinished;
        private byte m_clientId;
        private TrainerMessageID m_messageId;

        public ClientSeq_TrainerMessage()
        {
            m_pMainModule = null;
            m_pViewSystem = null;
            m_pMessageManager = null;

            m_isFinished = true;
            m_clientId = (byte)BTL_CLIENT_ID.BTL_CLIENT_PLAYER;
            m_seq = 0;
            m_messageId = TrainerMessageID.MESSAGE_NUM;
        }

        public void Setup(in SetupParam setupParam)
        {
            m_pMainModule = setupParam.pMainModule;
            m_pViewSystem = setupParam.pViewSystem;
            m_pMessageManager = setupParam.pMessageManager;
        }

        public void Start(byte clientId, TrainerMessageID messageId)
        {
        	this.m_seq = 0;
        	this.m_isFinished = false;
        	this.m_clientId = (byte)(clientId);
        	this.m_messageId = (TrainerMessageID)(messageId);
        }

        // TODO
        public void Update() { }

        // TODO
        private void StartView() { }

        // TODO
        private bool WaitView() { return false; }

        public bool IsFinished()
        {
            return m_isFinished;
        }

        public class SetupParam
        {
            public MainModule pMainModule;
            public BattleViewBase pViewSystem;
            public TrainerMessageManager pMessageManager;
        }
    }
}