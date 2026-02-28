using System.Diagnostics;

namespace Dpr.Battle.Logic
{
    public sealed class GameTimer
    {
        private Stopwatch[] m_timeCount = Arrays.InitializeWithDefaultInstances<Stopwatch>((int)TimerType.NUM);
        private ushort[] m_limitTime = new ushort[(int)TimerType.NUM];
        private bool[][] m_isPause = RectangularArrays.RectangularDefaultArray<bool>((int)TimerType.NUM, (int)TimerControlLevel.NUM);

        public void Initialize()
        {
            // Empty
        }

        // TODO
        public uint GetTime(TimerType type) { return 0; }

        // TODO
        public void SetTime(TimerType type, uint time) { }

        // TODO
        public void StartCountDown(TimerType type, TimerControlLevel level) { }

        // TODO
        public void Pause(TimerType type, TimerControlLevel level) { }

        public bool IsFinish(TimerType type)
        {
        	if (2 < (int)type) {
        	  return true;
        	}
        	if (type < this.m_timeCount.Length) {
        	  var iVar1 = GetTime();
        	  return iVar1 == 0;
        	}
        }

        // TODO
        private void setPauseFlag(TimerType type, TimerControlLevel level, bool flag) { }

        // TODO
        private bool isPause(TimerType type) { return false; }

        // TODO
        private void clearPauseFlag(TimerType type) { }

        public enum TimerType : int
        {
            GAME = 0,
            CLIENT = 1,
            COMMAND = 2,
            NUM = 3,
        }
    }
}