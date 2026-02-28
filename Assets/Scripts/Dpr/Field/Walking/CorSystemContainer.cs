using Dpr.FureaiHiroba;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Field.Walking
{
	public class CorSystemContainer : ICorSystem
	{
		private CorSystem corSys;
		private CorSystem TimeCorSys;
		private List<CorSystem> SubList = new List<CorSystem>();
		public int nowSubNo;
		public float duration;
		public float elapsedTime;
		private Text text;
		private int count;
		
		public bool isFinished { get => corSys.isFinished; }
		public bool isPlaying { get => corSys.isPlaying; }
		public float Rate { get => elapsedTime / duration; }
		
		public CorSystemContainer(string name = "")
		{
			corSys = new CorSystem(name);
			text = FureaiDebugManager.CreateText("");
		}
		
		public void Cancel()
		{
			this.corSys.Cancel();
		}
		
		// TODO
		public void SubCancel(string s) { }
		
		// TODO
		public void SubCancel(CorSystem corSys) { }
		
		// TODO
		public void SubCancel(int no) { }
		
		public void Pause()
		{
			this.corSys.Pause();
		}
		
		public Coroutine Restart()
		{
			if (this.corSys.isPause != 0) {
			  var uVar1 = CorSystem.Restart();
			  return uVar1;
			}
			return 0;
		}
		
		// TODO
		public CorSystem AddSub(float duration, corDelegate ienum, string name = "") { return default; }
		
		// TODO
		public CorSystem AddSub(float duration, IEnumerator ienum, string name = "") { return default; }
		
		// TODO
		private void AddSubList(CorSystem sub, IEnumerator ienum) { }
		
		// TODO
		public CorSystem AddWait(float duration, Action<CorSystem> OnUpdate, string Name) { return default; }
		
		// TODO
		public void Play() { }
		
		// TODO
		private IEnumerator TimeCount() { return default; }
		
		// TODO
		private IEnumerator Main() { return default; }

		public delegate IEnumerator corDelegate(CorSystem corSystem);
	}
}