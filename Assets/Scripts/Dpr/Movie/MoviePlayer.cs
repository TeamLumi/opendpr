using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Dpr.Movie
{
    public class MoviePlayer : MonoBehaviour
    {
        [SerializeField]
        public Material movieMaterial;
        private VideoPlayer _videoPlayer;
#if SWITCH
        private SwitchVideoPlayer _switchVideoPlayer;
        private SwitchFMVTexture _lumaTex;
        private SwitchFMVTexture _chromaTex;
#endif
        private const int ResX = 1280;
        private const int ResY = 720;
        private RawImage _rendererImage;
        internal bool _isPlaying;
        private bool isUpdateVideoOnThisFrame;

        // TODO
        public void Initialize(GameObject rendererObject) { }

        // TODO
        public void Uninitialize() { }

        public void PlayStreaming(string path, bool loop = false)
        {
        	var uVar1 = String.Concat(path,_StringLiteral_9931);
        	var uVar2 = 0.streamingAssetsPath;
        	uVar1 = String.Concat(uVar2,StringLiteral_457,uVar1);
        	if (this._switchVideoPlayer != null) {
        	  this._switchVideoPlayer.isLooping = (loop ? 1 : 0) & 1;
        	  this._switchVideoPlayer.Play(uVar1);
        	  this._isPlaying = true;
        	}
        }

        public void Stop()
        {
        	if (this._switchVideoPlayer != null) {
        	  this._switchVideoPlayer.Stop();
        	  this._isPlaying = false;
        	}
        }

        public bool IsPlaying()
        {
        	return this._isPlaying;
        }

        // TODO
        public float GetTime() { return 0.0f; }

        // TODO
        public float GetLength() { return 0.0f; }

        public void JumpTo(float sec)
        {
        	if (this._switchVideoPlayer != null) {
        	  this._switchVideoPlayer.JumpTo();
        	}
        }

        public bool IsLoop()
        {
        	if (this._switchVideoPlayer != null) {
        	  this._switchVideoPlayer.isLooping;
        	}
        	return false;
        }

        private void Update()
        {
        	this.isUpdateVideoOnThisFrame = false;
        }

        private void OnRenderObject()
        {
        	ulong uVar2 = default;
        	var fVar4 = 0.0;
        	if ((!this._isPlaying) || (this._switchVideoPlayer == null)) {
        	  var fVar3 = fVar4;
        	}
        	else {
        	  fVar3 = (float)this._switchVideoPlayer.GetVideoLength()
        	  ;
        	  if ((this._isPlaying) && (fVar4 = 0.0, this._switchVideoPlayer != null)) {
        	    fVar4 = (float)UnityEngine_Switch_SwitchVideoPlayer__GetCurrentTime
        	                             (this._switchVideoPlayer,0);
        	  }
        	}
        	if ((((this._switchVideoPlayer == null) ||
        	     (uVar2 = this._switchVideoPlayer.isLooping, (uVar2 & 1) == 0)) &&
        	    (this._isPlaying)) && ((fVar3 != 0.0 && (fVar3 + -0.1 <= fVar4)))) {
        	  this._isPlaying = false;
        	}
        	if (!this.isUpdateVideoOnThisFrame) {
        	  if (this._switchVideoPlayer != null) {
        	    this._switchVideoPlayer.Update();
        	  }
        	  this.isUpdateVideoOnThisFrame = true;
        	}
        }

        // TODO
#if SWITCH
        private void OnMovieEvent(SwitchVideoPlayer.Event FMVevent) { }
#endif

        // TODO
        private void InitializeEditor(RawImage image, VideoPlayer videoPlayer) { }

        // TODO
        private void UninitializeEditor() { }

        // TODO
        private void UpdateEditor() { }

        private void PlayStreamingEditor(string path, bool loop)
        {
        	this._videoPlayer.url = path;
        	this._videoPlayer.isLooping = (loop ? 1 : 0) & 1;
        	this._videoPlayer.Play();
        	this._isPlaying = true;
        }

        private void StopEditor()
        {
        	this._videoPlayer.Stop();
        	this._isPlaying = false;
        }

        // TODO
        private bool IsPlayingEditor() { return false; }

        // TODO
        private float GetTimeEditor() { return 0.0f; }

        // TODO
        private float GetLengthEditor() { return 0.0f; }

        // TODO
        private void JumpToEditor(float sec) { }

        // TODO
        private bool IsLoopEditor() { return false; }

        // TODO
        private void InitializeSwitch(RawImage image) { }

        // TODO
        private void UninitializeSwitch() { }

        private void UpdateSwitch()
        {
        	if (this._switchVideoPlayer != null) {
        	  this._switchVideoPlayer.Update();
        	}
        }

        private void PlayStreamingSwitch(string path, bool loop)
        {
        	if (this._switchVideoPlayer != null) {
        	  this._switchVideoPlayer.isLooping = (loop ? 1 : 0) & 1;
        	  this._switchVideoPlayer.Play(path);
        	  this._isPlaying = true;
        	}
        }

        private void StopSwitch()
        {
        	if (this._switchVideoPlayer != null) {
        	  this._switchVideoPlayer.Stop();
        	  this._isPlaying = false;
        	}
        }

        private bool IsPlayingSwitch()
        {
        	if (this._switchVideoPlayer != null) {
        	  return this._isPlaying;
        	}
        	return false;
        }

        // TODO
        private float GetTimeSwitch() { return 0.0f; }

        // TODO
        private float GetLengthSwitch() { return 0.0f; }

        private void JumpToSwitch(float sec)
        {
        	if (this._switchVideoPlayer != null) {
        	  this._switchVideoPlayer.JumpTo();
        	}
        }

        private bool IsLoopSwitch()
        {
        	if (this._switchVideoPlayer != null) {
        	  this._switchVideoPlayer.isLooping;
        	}
        	return false;
        }
    }
}