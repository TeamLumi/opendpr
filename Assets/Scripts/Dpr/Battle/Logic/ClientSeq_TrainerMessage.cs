namespace Dpr.Battle.Logic
{
    public sealed class ClientSeq_TrainerMessage
    {
        private MainModule m_pMainModule;
        private BattleViewBase m_pViewSystem;
        private TrainerMessageManager m_pMessageManager;
        private int m_seq;
        private bool m_isFinished;
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
            m_clientId = clientId;
            m_messageId = messageId;
            m_isFinished = false;
            m_seq = 0;
        }

        public void Update()
        {
            switch (m_seq)
            {
                case 0:
                    StartView();
                    m_seq = 1;
                    break;

                case 1:
                    if (WaitView())
                    {
                        m_pMessageManager.Done(m_clientId, m_messageId);
                        m_isFinished = true;
                    }
                    break;
            }
        }

        private void StartView()
        {
            var strParam = new BTLV_STRPARAM();
            string msgLabel = m_pMainModule.GetClientTrainerMsg(m_clientId, m_messageId);
            if (msgLabel != null)
            {
                BTLV_STRPARAM.Setup(strParam, BtlStrType.BTL_STRTYPE_STD, 0);
            }
            m_pViewSystem.CMD_StartMsg(strParam);
        }

        private bool WaitView()
        {
            return m_pViewSystem.CMD_WaitMsg();
        }

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