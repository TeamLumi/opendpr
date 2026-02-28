using Audio;
using Pml;

namespace Dpr.SubContents
{
	public class TimeLineAudio : TimeLineComponent
	{
		public bool isPlayOnStart;
		public uint SoundID;
		public MonsNo monsNo;
		public int formNo;
		public int voiceNo;
		private AudioInstance audioInstance;
		public BindModelSound.SoundType soundType;
		
		// TODO
		private void Start() { }
		
		// TODO
		private void OnEnable() { }
		
		// TODO
		private void OnDisable() { }
		
		private void OnDestroy()
		{
			this.audioInstance = null;
		}
	}
}