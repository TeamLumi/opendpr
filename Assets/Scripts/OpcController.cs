using Dpr.NetworkUtils;
using System.Collections.Generic;
using UnityEngine;

public abstract class OpcController : OnlinePlayerCharacter
{
	protected const int POS_LIST_LENGTH = 20;
	protected const int ANIM_INDEX_IDLE = 0;
	protected const int ANIM_INDEX_WALK = 1;
	protected const int ANIM_INDEX_RUN = 2;
	protected const float MOVE_THRESHOLD = 0.1f;

	protected FieldObjectEntity _Entity;
	protected List<Vector2> _PosList = new List<Vector2>(POS_LIST_LENGTH);
	protected List<float> _RotList = new List<float>(POS_LIST_LENGTH);
	protected OpcCharacterMove _CharacterMove;
	protected AnimationPlayer _AnimationPlayer;
	protected float _RotY;
	protected bool _IsAnimStop;
	public OpcManager.CharaData _CharaData;
	public bool isUseDashAnimation;
	private bool _isInitialized;
	private float _moveThreshold;
	[SerializeField]
	private string _TalkLabel;
	[SerializeField]
	private Vector2 _ContactSize;
	[SerializeField]
	private float _Speed = 4.0f;
	[SerializeField]
	private float _RotSpeed = 10.0f;
	[SerializeField]
	private float _TargetDistance = 1.5f;
	[SerializeField]
	private float _MinSpeed;
	[SerializeField]
	private float _MaxSpeed = 4.0f;
	[SerializeField]
	private float _AddSpeedRate = 0.125f;
	private float _CurrentSpeed;
	private float _CurrentDistance;
	private float _IdleTransutuonTime = 0.1f;
	
	public float moveThreshold { get => _moveThreshold; set => _moveThreshold = value; }
	
	// TODO
	protected override void Start() { }
	
	// TODO
	public void AddNextPosition(Vector2 pos, float rotY) { }
	
	public void SetRotationY(float rotY) {
	    _RotY = rotY;
	}
	
	// TODO
	public void ClearPos() { }
	
	// TODO
	public void SetCharaData(OpcManager.CharaData data) { }
	
	// TODO
	public bool IsArriveTargetPosition(Vector3 pos) { return default; }
	
	// TODO
	public void TalkLog() { }
	
	// TODO
	public void Log() { }
	
	// TODO
	protected override void MyUpdate(float deltaTime) { }
	
	// TODO
	public virtual void SetNetData(INetData netData) { }
	
	public FieldObjectEntity GetEntity() {
	    return _Entity;
	}
	
	// TODO
	protected override void OnDestroy() { }
	
	// TODO
	private void SetNPCParamater() { }
	
	// TODO
	private void PlayAnimMove() { }
}