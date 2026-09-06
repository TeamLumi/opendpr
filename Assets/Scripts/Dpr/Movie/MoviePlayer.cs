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
        private bool _isPlaying;
        private bool isUpdateVideoOnThisFrame;

        // TODO
        public void Initialize(GameObject rendererObject) { }

        // TODO
        public void Uninitialize() { }

        // TODO
        public void PlayStreaming(string path, bool loop = false) { }

        // TODO
        public void Stop() { }

        public bool IsPlaying() {
            return _isPlaying;
        }

        // TODO
        public float GetTime() { return 0.0f; }

        // TODO
        public float GetLength() { return 0.0f; }

        // TODO
        public void JumpTo(float sec) { }

        // TODO
        public bool IsLoop() { return false; }

        // TODO
        private void Update() { }

        // TODO
        private void OnRenderObject() { }

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

        // TODO
        private void PlayStreamingEditor(string path, bool loop) { }

        // TODO
        private void StopEditor() { }

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

        // TODO
        private void UpdateSwitch() { }

        // TODO
        private void PlayStreamingSwitch(string path, bool loop) { }

        // TODO
        private void StopSwitch() { }

        // TODO
        private bool IsPlayingSwitch() { return false; }

        // TODO
        private float GetTimeSwitch() { return 0.0f; }

        // TODO
        private float GetLengthSwitch() { return 0.0f; }

        // TODO
        private void JumpToSwitch(float sec) { }

        // TODO
        private bool IsLoopSwitch() { return false; }
    }
}