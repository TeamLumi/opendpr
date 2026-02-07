namespace Dpr.Battle.Logic
{
    public sealed class ClientSeq_WinWild
    {
        private MainModule m_mainModule;
        private BTL_CLIENT m_client;
        private POKECON m_pokecon;
        private BattleViewBase m_viewSystem;
        private int m_seq;
        private bool m_isFinished;
        private BTLV_STRPARAM m_strParam = new BTLV_STRPARAM();

        public ClientSeq_WinWild()
        {
            m_mainModule = null;
            m_client = null;
            m_pokecon = null;
            m_viewSystem = null;

            Start();
        }

        public void Setup(in SetupParam setupParam)
        {
            m_mainModule = setupParam.mainModule;
            m_client = setupParam.client;
            m_pokecon = setupParam.pokecon;
            m_viewSystem = setupParam.viewSystem;
        }

        public void Start()
        {
            m_seq = 0;
            m_isFinished = false;
        }

        public bool IsFinished()
        {
            return m_isFinished;
        }

        public void Update()
        {
            switch ((Sequence)m_seq)
            {
                case Sequence.SEQ_MONEY_MESSAGE_START:
                {
                    BATTLE_SETUP_PARAM sp = m_mainModule.GetBattleSetupParam();
                    uint money = calc.CalcWinMoney(sp);
                    BTLV_STRPARAM.Setup(m_strParam, BtlStrType.BTL_STRTYPE_STD, (ushort)BTL_STRID_STD.GetMoney);
                    BTLV_STRPARAM.AddArg(m_strParam, (int)money);
                    m_viewSystem.CMD_StartMsg(m_strParam);
                    m_seq = (int)Sequence.SEQ_MONEY_MESSAGE_WAIT;
                    break;
                }
                case Sequence.SEQ_MONEY_MESSAGE_WAIT:
                {
                    if (m_viewSystem.CMD_WaitMsg())
                    {
                        if (IsNusiWinEffectEnable())
                        {
                            m_seq = (int)Sequence.SEQ_WIN_VS_NUSI_EFFECT_START;
                        }
                        else
                        {
                            m_seq = (int)Sequence.SEQ_EXIT;
                        }
                    }
                    break;
                }
                case Sequence.SEQ_WIN_VS_NUSI_EFFECT_START:
                {
                    m_viewSystem.CMD_VsNusiWinEffect_Start();
                    m_seq = (int)Sequence.SEQ_WIN_VS_NUSI_EFFECT_WAIT;
                    break;
                }
                case Sequence.SEQ_WIN_VS_NUSI_EFFECT_WAIT:
                {
                    if (m_viewSystem.CMD_VsNusiWinEffect_Wait())
                    {
                        m_seq = (int)Sequence.SEQ_WIN_VS_NUSI_MESSAGE_START;
                    }
                    break;
                }
                case Sequence.SEQ_WIN_VS_NUSI_MESSAGE_START:
                {
                    BTLV_STRPARAM.Setup(m_strParam, BtlStrType.BTL_STRTYPE_STD, (ushort)BTL_STRID_STD.WinNusi);
                    m_viewSystem.CMD_StartMsg(m_strParam);
                    m_seq = (int)Sequence.SEQ_WIN_VS_NUSI_MESSAGE_WAIT;
                    break;
                }
                case Sequence.SEQ_WIN_VS_NUSI_MESSAGE_WAIT:
                {
                    if (m_viewSystem.CMD_WaitMsg())
                    {
                        m_seq = (int)Sequence.SEQ_EXIT;
                    }
                    break;
                }
                case Sequence.SEQ_EXIT:
                {
                    m_isFinished = true;
                    break;
                }
            }
        }

        private bool IsNusiWinEffectEnable()
        {
            BATTLE_SETUP_PARAM sp = m_mainModule.GetBattleSetupParam();
            if (sp == null)
            {
                return false;
            }
            for (int i = 0; i < sp.partyDesc.Length; i++)
            {
                PartyDesc partyDesc = sp.partyDesc[i];
                if (partyDesc == null) continue;
                for (int j = 0; j < partyDesc.pokeDesc.Length; j++)
                {
                    if (partyDesc.pokeDesc[j].defaultPowerUpDesc.reason == DefaultPowerUpReason.DEFAULT_POWERUP_REASON_NUSI)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public class SetupParam
        {
            public MainModule mainModule;
            public BTL_CLIENT client;
            public POKECON pokecon;
            public BattleViewBase viewSystem;
        }

        public enum Sequence : int
        {
            SEQ_MONEY_MESSAGE_START = 0,
            SEQ_MONEY_MESSAGE_WAIT = 1,
            SEQ_WIN_VS_NUSI_EFFECT_START = 2,
            SEQ_WIN_VS_NUSI_EFFECT_WAIT = 3,
            SEQ_WIN_VS_NUSI_MESSAGE_START = 4,
            SEQ_WIN_VS_NUSI_MESSAGE_WAIT = 5,
            SEQ_EXIT = 6,
        }
    }
}