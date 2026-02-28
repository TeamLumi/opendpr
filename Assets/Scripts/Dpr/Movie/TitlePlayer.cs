using Dpr.Message;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.Movie
{
    public class TitlePlayer : MonoBehaviour
    {
        [SerializeField]
        public GameObject _titleUiCanvas;
        [SerializeField]
        public Image _logoImage;
        [SerializeField]
        public Image _pushImage;
        [SerializeField]
        public TitleSettings _settings;
        private int _settingIndex;
        private RawImage _fadeImage;
        private Action<int> _endCallback;
        private TitleState _state;
        private bool _repeat;
        private bool _isPressedBackupCommand;
        private float _timeCounter;
        private const float _waitInputTime = 25;
        private bool _isDisplayTitleUI;
        private float _pushMessageTimeCounter;
        private const float _pushMessageBlinkTime = 2;
#if PEARL
        private bool _diaVersion = false;
#else
        private bool _diaVersion = true;
#endif
        private MessageEnumData.MsgLangId _lang = MessageEnumData.MsgLangId.JPN;
        private bool _isLoadedAssets;
        private MoviePlayer _moviePlayer;
        private string[] _moviePath = new string[2];
        private string[] _logoPath = new string[2];
        private string[] _pushTextPath = new string[2];
        private WaitForSeconds _wait02sec = new WaitForSeconds(0.2f);
        private WaitForSeconds _wait1sec = new WaitForSeconds(1.0f);
        private WaitForSeconds _wait2sec = new WaitForSeconds(2.0f);

        // TODO
        public void Initialize(MoviePlayer moviePlayer, bool diaVersion, MessageEnumData.MsgLangId lang, RawImage fadeImage, Action<int> endCallback) { }

        // TODO
        public IEnumerator LoadAsset() { return null; }

        // TODO
        private void UnloadAsset() { }

        // TODO
        public void Play() { }

        // TODO
        private void OnUpdate(float deltaTime) { }

        // TODO
        private IEnumerator PlayOpening() { return null; }

        // TODO
        private IEnumerator EndOpening() { return null; }

        // TODO
        private IEnumerator PlayTitle(bool fadeIn) { return null; }

        // TODO
        private IEnumerator EndTitle() { return null; }

        // TODO
        private void PlayMovie(MovieType type, bool loop) { }

        private void EndMovie()
        {
        	var lVar1 = this._moviePlayer._switchVideoPlayer;
        	if (lVar1 != null) {
        	  lVar1.Stop();
        	  this._moviePlayer._isPlaying = 0;
        	}
        }

        private bool IsPlayingMovie()
        {
        	return this._moviePlayer._isPlaying;
        }

        // TODO
        private void PlayOpeningBGM() { }

        // TODO
        private void PlayTitleBGM() { }

        // TODO
        private void StopBGM() { }

        // TODO
        private void PlaySE() { }

        // TODO
        private string GetOpeningMoviePath() { return ""; }

        // TODO
        private string GetTitleMoviePath() { return ""; }

        // TODO
        private void GetLogoPath(out string path, out string name)
        {
            path = "";
            name = "";
        }

        // TODO
        private void GetPushTextImagePath(out string path, out string name)
        {
            path = "";
            name = "";
        }

        private enum TitleState : int
        {
            None = 0,
            PlayingMovie = 1,
            WaitEndMovie = 2,
            WaitDisplayTitle = 3,
            DisplayTitle = 4,
            WaitEndTitle = 5,
            End = 6,
        }

        private enum MovieType : int
        {
            Opening = 0,
            Title = 1,
            Max = 2,
        }
    }
}