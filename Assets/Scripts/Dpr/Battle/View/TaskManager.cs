using System;

namespace Dpr.Battle.View
{
	public sealed class TaskManager : IDisposable
	{
		public const int DEFAULT_TASK_MAX_NUM = 24;
		public const int TASK_PRIORITY_DEFAULT = 64;
		public const int TASK_PRIORITY_LOW = 96;

		private bool _suicideFlag;
		private int _taskNum;
		private Task _iPtrTaskFirst;
		private Task _iPtrNowChain;
		
		public bool IsAllFinished { get => _taskNum == 0; }
		
		public TaskManager(int taskCnt = DEFAULT_TASK_MAX_NUM)
		{
			_iPtrTaskFirst = new Task();
			_iPtrTaskFirst.Clear(_iPtrTaskFirst);
			_iPtrTaskFirst.Parent = this;
			_suicideFlag = false;
		}
		
		// TODO
		public void Dispose() { }
		
		// TODO
		public void RegisterTask(Task task, bool isForward = true) { }
		
		// TODO
		public void Delete(Task iPtrTask) { }
		
		public int GetTaskNum() {
		    return _taskNum;
		}
		
		// TODO
		public void DeleteTaskFunc(Task iPtrTask) { }
		
		// TODO
		public void OnUpdate(float deltaTime, float currentSequenceTime, int step = 1) { }
		
		// TODO
		public void ForceAllFinished() { }
	}
}