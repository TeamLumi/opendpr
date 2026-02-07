namespace Dpr.Battle.Logic
{
	public sealed class FrontPokeAccessor
	{
		private readonly MainModule m_pMainModule;
		private readonly BattleEnv m_pBattleEnv;
		private byte m_clientID;
		private byte m_pokeIndex;
		private bool m_endFlag;
		
		public FrontPokeAccessor(MainModule pMainModule, BattleEnv pBattleEnv)
		{
			m_pMainModule = pMainModule;
			m_pBattleEnv = pBattleEnv;
			m_clientID = 0;
			m_pokeIndex = 0;
			m_endFlag = true;
		}
		
		public void Initialize()
		{
			m_clientID = 0;
			m_pokeIndex = 0;
			m_endFlag = false;
		}

		public bool GetNext(out BTL_POKEPARAM bpp)
		{
			bpp = null;

			while (!m_endFlag)
			{
				byte clientNum = m_pMainModule.GetClientNum();
				if (m_clientID >= clientNum)
				{
					m_endFlag = true;
					return false;
				}

				byte frontPosCount = m_pMainModule.GetClientFrontPosCount(m_clientID);
				if (m_pokeIndex < frontPosCount)
				{
					BtlPokePos pos = m_pMainModule.GetClientPokePos(m_clientID, m_pokeIndex);
					m_pokeIndex++;

					BTL_POKEPARAM poke = m_pBattleEnv.GetPokeCon().GetFrontPokeData(pos);
					if (poke != null && isAccessTarget(poke))
					{
						bpp = poke;
						return true;
					}
				}
				else
				{
					m_clientID++;
					m_pokeIndex = 0;
				}
			}

			return false;
		}

		private bool isAccessTarget(BTL_POKEPARAM bpp)
		{
			return bpp.IsFightEnable();
		}
	}
}