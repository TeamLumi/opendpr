using DG.Tweening;
using Dpr.Message;
using Dpr.UI;
using SmartPoint.AssetAssistant;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AreaNameWindow : MonoBehaviour
{
    private const string FRAME_SPR_NAME = "cmn_wd_areaname_01";
    private const int CAPACITY = 32;

    [SerializeField]
    private float showTime = 1.0f;
    [SerializeField]
    private TextMeshProUGUI nameText;
    private DOTweenAnimation moveTween;
    private MessageManager msgManagerPtr;
    private MessageMsgFile useMsgFile;
    private StringBuilder showingLabelName = new StringBuilder(CAPACITY);
    private StringBuilder reservLabelName = new StringBuilder(CAPACITY);
    private MessageEnumData.MsgLangId prevLangID = MessageEnumData.MsgLangId.JPN;
    private bool isKanji;
    private float timer;
    private int showLabelHash;
    private int lastShowLabelHash;
    private bool showing;

    public void Initialize()
    {
        var frame = this.FindDeep("Frame", true).GetComponent<Image>();
        frame.sprite = UIManager.Instance.GetAtlasSprite(SpriteAtlasID.SHAREDUI, FRAME_SPR_NAME);
        moveTween = this.FindDeep("Content", true).GetComponent<DOTweenAnimation>();
        transform.SetSiblingIndex(transform.parent.childCount - 1);

        msgManagerPtr = MessageManager.Instance;
        prevLangID = msgManagerPtr.UserLanguageID;
        isKanji = msgManagerPtr.IsKanji;

        nameText.font = FontManager.Instance.GetFontAsset();
        nameText.UpdateFontAsset();

        SetActive(false);
    }

    private void SetActive(bool active)
    {
        if (gameObject.activeSelf != active)
            gameObject.SetActive(active);
    }

    private void OnDestroy()
    {
        Destroy(this.FindDeep("Frame", true).GetComponent<Image>().sprite);
    }

    public void OnEnableFieldCanvas()
    {
        if (msgManagerPtr == null)
            return;

        useMsgFile = msgManagerPtr.GetMsgFile(MessageDataConstants.AREANAME_DISPLAY_FILE_NAME);
    }

    public void OnDisableFieldCanvas()
    {
        useMsgFile = null;
    }

    public void ResetParam()
    {
        showLabelHash = 0;
        lastShowLabelHash = 0;
        showingLabelName.Clear();
        reservLabelName.Clear();
    }

    public void Open(string labelName)
    {
        if (showing)
        {
            if (IsSameShowingLabel(labelName))
            {
                reservLabelName.Clear();
                return;
            }

            if (reservLabelName.Length <= 0)
                reservLabelName.Append(labelName);
        }
        else if (!IsSameLastShowingLabel(labelName))
        {
            SetActive(true);
            PerformShowAreaName(labelName);
        }
    }

    public void ImmidiateClose()
    {
        if (!showing)
            return;

        ResetParam();
        Sequencer.update -= OnUpdate;
        moveTween.DORewind();
    }

    private bool IsSameShowingLabel(string nextLabelName)
    {
        if (showingLabelName.Length > 0)
            return nextLabelName.GetHashCode() == showLabelHash;

        return false;
    }

    private bool IsSameLastShowingLabel(string nextLabelName)
    {
        if (lastShowLabelHash != 0)
            return nextLabelName.GetHashCode() == lastShowLabelHash;

        return false;
    }

    private void PerformShowAreaName(string labelName)
    {
        if (useMsgFile == null || !useMsgFile.IsValidData())
        {
            useMsgFile = msgManagerPtr.GetMsgFile(MessageDataConstants.AREANAME_DISPLAY_FILE_NAME);
            if (useMsgFile == null)
                return;
        }

        timer = 0.0f;
        showing = true;
        SetNameText(labelName);
        DoMoveWindow();
    }

    private void SetNameText(string labelName)
    {
        CheckUseMsgFile();
        showingLabelName.Clear();
        showingLabelName.Append(labelName);

        showLabelHash = labelName.GetHashCode();
        lastShowLabelHash = showLabelHash;

        if (string.IsNullOrEmpty(labelName))
        {
            var array = useMsgFile.GetAllLabelDataArray();
            if (array.Length == 0)
                nameText.text = string.Empty;
            else
                nameText.text = useMsgFile.GetNameStr(array[0].labelName);
        }
        else
        {
            nameText.text = useMsgFile.GetNameStr(labelName);
        }
    }

    private void CheckUseMsgFile()
    {
        if (prevLangID == msgManagerPtr.UserLanguageID &&
            (msgManagerPtr.UserLanguageID != MessageEnumData.MsgLangId.JPN || isKanji == msgManagerPtr.IsKanji))
            return;

        prevLangID = msgManagerPtr.UserLanguageID;
        isKanji = msgManagerPtr.IsKanji;
        useMsgFile = msgManagerPtr.GetMsgFile(MessageDataConstants.AREANAME_DISPLAY_FILE_NAME);

        nameText.font = FontManager.Instance.GetFontAsset();
        nameText.UpdateFontAsset();
    }

    private void DoMoveWindow()
    {
        moveTween.DOPlayForward();
    }

    public void OnComplete()
    {
        Sequencer.update -= OnUpdate;
        Sequencer.update += OnUpdate;
    }

    public void OnRewind()
    {
        if (reservLabelName.Length > 0)
        {
            PerformShowAreaName(reservLabelName.ToString());
            reservLabelName.Clear();
        }
        else
        {
            showLabelHash = 0;
            showingLabelName.Clear();
            showing = false;
            SetActive(false);
        }
    }

    private void OnUpdate(float deltaTime)
    {
        timer += deltaTime;
        if (showTime > timer)
            return;

        Sequencer.update -= OnUpdate;
        moveTween.DOPlayBackwards();
    }
}