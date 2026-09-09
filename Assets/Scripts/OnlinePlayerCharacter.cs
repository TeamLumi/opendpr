using Dpr.FureaiHiroba;
using System;
using UnityEngine;

public class OnlinePlayerCharacter : MonoBehaviour
{
	private const int EMOTICON_ID_BATTLE = 15;
	private const int EMOTICON_ID_TRADE = 16;
	private const int EMOTICON_ID_RECODE = 17;
	private const int EMOTICON_ID_TRAINER = 21;
	private const int EMOTICON_ID_BALL_DECO = 18;
	private const int EMOTICON_ID_TALK = 9;
	private const int EMOTICON_ID_LIKES = 28;
	private const int EMOTICON_ID_CROSS = 20;
	private const int EMOTICON_ID_EXCLAMATION = 29;
	private const int EMOTICON_ID_PICKEL = 24;
	private const int EMOTICON_ID_TOGETHER = 27;
	private const int EMOTICON_ID_GET = 25;

	public OpcState opcState;
	public Balloon balloon;
	public Emoticon emoticon;
	public Action<int> _ShowWindow;
	public float talkDistance = 1.0f;
	public bool isMenuOpen;
	public AnimationPlayer _myAnimationPlayer;
	public int stationIndex;
	private float _IdleTransutuonTime = 0.1f;
	private bool _IsTransitionIdle;
	private int emoticonType;
	public bool isRecruiment;
	public bool isTransitionAfter;
	public bool isMyPlyaer;
	
	// TODO
	protected virtual void Start() { }
	
	// TODO
	protected virtual void MyUpdate(float deltaTime) { }
	
	// TODO
	public bool IsGetOpcState() { return default; }
	
	// TODO
	public void ShowEmoticon(OpcState.OnlineState state) { }
	
	// TODO
	public void DeleteEmoticon() { }
	
	// TODO
	public void SetEmoticonHost() { }
	
	// TODO
	public void SetEmoticonNormal() { }
	
	// TODO
	public bool IsCanTalkState() { return default; }
	
	// TODO
	public virtual void SetOpcOnlineState(OpcState.OnlineState state) { }
	
	// TODO
	public OpcState.OnlineState GetOpcOnlineState() { return default; }
	
	public void SetMenuOpen(bool isOpen) {
	    this.isMenuOpen = isOpen;
	}
	
	public bool GetIsMenuOpen() {
	    return isMenuOpen;
	}
	
	public Balloon GetBallon() {
	    return balloon;
	}
	
	public Emoticon GetEmoticon() {
	    return emoticon;
	}
	
	// TODO
	public void PlayerInputActiveEnabled() { }
	
	// TODO
	public void PlayerInputActiveDisabled() { }
	
	// TODO
	public void SetAnimationPlayer(AnimationPlayer animationPlayer) { }
	
	public AnimationPlayer GetAnimationPlayer() {
	    return _myAnimationPlayer;
	}
	
	public void SetIsTransutuonIdle(bool isTransitionIdle) {
	    this._IsTransitionIdle = isTransitionIdle;
	}
	
	// TODO
	private int GetEmoticonType(OpcState.OnlineState state) { return default; }
	
	// TODO
	protected virtual void OnDestroy() { }
}