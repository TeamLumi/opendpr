using Dpr.MsgWindow;
using System;
using System.Collections.Generic;

public class UnionBaseMsgWindow
{
	protected List<MsgWindowParam> Messages = new List<MsgWindowParam>();
	protected Dictionary<int, MsgWindowParam> DefMessages = new Dictionary<int, MsgWindowParam>();
	protected MsgWindow _messageWindow;
	protected int nowMessageNo;
	protected MsgWindowParam openDefMessage;
	public int sexId;
	
	// TODO
	protected bool isMessageFinished { get; }
	
	// TODO
	protected MsgWindowParam nowMSG { get; }
	
	// TODO
	protected bool isEnableInput { get; }
	
	// TODO
	public virtual void Init() { }
	
	// TODO
	public void ClearParam() { }
	
	// TODO
	public void SetTargetDataMessage(int targetStaitonIndex, int targetSexId, int setTagIndex) { }
	
	// TODO
	protected void SetDefMessages() { }
	
	// TODO
	public void SetGreetAfterMessage(int id) { }
	
	// TODO
	public void SetMessagesData(List<UnionTextData.MsgStringParamData> msgStringParamDatas, bool isNetMode = false, bool isLoadIcon = false) { }
	
	// TODO
	public void SetMessagesData(string msgFileName, string labelName, bool isNetMode = false, bool isLoadIcon = false) { }
	
	// TODO
	protected MsgWindowParam CreateMsgWindowParam(string msgFileName, string labelName, bool isNetMode = false, bool isLoadIcon = false) { return default; }
	
	// TODO
	public bool IsOpen() { return default; }
	
	// TODO
	public void OpenMsgWindow(int index, UnionTextData.SpeakerID speakerID = UnionTextData.SpeakerID.SYSTEM) { }
	
	// TODO
	public void CloseWindow() { }
	
	// TODO
	public MsgWindowParam GetNowMessage() { return default; }
	
	public int GetNowMessageNo() {
	    return nowMessageNo;
	}
	
	// TODO
	public void SetOnCloseCallBack(Action closeEndFunc) { }
	
	// TODO
	public void SetOnFinishMsgCallBack(Action finishFunc) { }
	
	// TODO
	protected string GetSpeakerName(UnionTextData.SpeakerID speakerID) { return default; }

	public enum TagIndexType : int
	{
		OTHER_NICKNAME_TAG_INDEX = 0,
		BATTLE_NICKNAME_TAG_INDEX = 1,
	}
}