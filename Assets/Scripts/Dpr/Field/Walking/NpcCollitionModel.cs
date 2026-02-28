namespace Dpr.Field.Walking
{
	public class NpcCollitionModel : WalkingCollisionModelBase
	{
		public NpcCollitionModel(WalkData walkData) : base(walkData)
		{
			entity.IsIgnorePlayerCollision = true;
		}
		
		// TODO
		public override void CollisionUpdate(float deltaTime) { }
		
		public override bool ObjectCollisionUpdate(float deltaTime, bool isIgnoreJump = false)
		{
			deltaTime.ObjectCollisionUpdate((isIgnoreJump ? 1 : 0) & 1);
			return false;
		}
		
		// TODO
		public override void LateUpdate(float deltaTime) { }
	}
}