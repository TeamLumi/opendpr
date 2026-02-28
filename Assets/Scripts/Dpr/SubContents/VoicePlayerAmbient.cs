using Audio;
using Pml;
using UnityEngine;

namespace Dpr.SubContents
{
    public class VoicePlayerAmbient : MonoBehaviour
    {
        public Vector3 pos;
        private AudioInstance instance;
        public int TestVoiceNo;
        [Button("TestPlayPIKA", "TestPlayPIKA", new object[0])]
        public int Button01;
        [Button("TestPlayEV", "TestPlayEV", new object[0])]
        public int Button02;
        [Button("TestPlay", "TestPlay", new object[0])]
        public int Button03;
        [Button("TestSE", "TestSE", new object[0])]
        public int Button04;
        [Button("StopVoice", "StopVoice", new object[0])]
        public int Button05;

        // TODO
        public AudioInstance PlayVoice(MonsNo monsNo, int formNo, int voiceNo) { return null; }

        // TODO
        public void PlayInstance(MonsNo monsNo, int formNo, int voiceNo, Transform t) { }

        // TODO
        public void TestPlayPIKA() { }

        // TODO
        public void TestPlayEV() { }

        // TODO
        public void TestPlay() { }

        // TODO
        public void TestSE() { }

        public void StopVoice()
        {
        	if (this.instance != null) {
        	  this.instance.Stop();
        	}
        }

        // TODO
        private void OnDestroy() { }
    }
}