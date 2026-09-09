using UnityEngine;

public class OpcCharacterMove
{
	private FieldObjectEntity _MoveEntity;
	public AnimationPlayer _MoveAnimationPlayer;
	private float _Speed;
	private float _RotSpeed;
	[SerializeField]
	private float _DurationSpeed = 1.0f;
	
	// TODO
	public void SetEntity(FieldObjectEntity entity) { }
	
	// TODO
	public void SetAnimationPlayer(AnimationPlayer animationPlayer) { }
	
	public void SetSpeed(float speed) {
	    _Speed = speed;
	}
	
	public void SetRotationSpeed(float speed) {
	    _RotSpeed = speed;
	}
	
	// TODO
	public void Move(float deltaTime, Vector2 pos) { }
	
	// TODO
	public void Stop() { }
	
	// TODO
	public void SetRotY(float rotY) { }
}