using Dpr.FureaiHiroba;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Field.Walking
{
    public abstract class WalkingCollisionModelBase
    {
        protected WalkData walkData;
        public bool isIgnoreCollision;
        public bool isCollidedAdd;

        protected WalkingCollisionModelBase(WalkData walkData)
        {
            this.walkData = walkData;
            entity.IsIgnorePlayerCollision = true;
        }

        protected float bodySize { get => walkData.bodySize; set => walkData.bodySize = value; }
        protected FieldObjectEntity entity { get => walkData.entity; }
        protected int CollidedCount { get => walkData.CollidedCount; set => walkData.CollidedCount = value; }
        protected Transform transform { get => walkData.transform; }

        // TODO
        public virtual void CollisionUpdate(float deltaTime) { }

        // TODO
        public virtual void ExCollisionUpdate(float deltaTime, List<FureaiPokeModel> characters) { }

        // TODO
        public virtual bool ObjectCollisionUpdate(float deltaTime, bool isIgnoreJump = false) { return false; }

        public void UpdateCollisionCount()
        {
        	if (this.isCollidedAdd) {
        	}
        	this.walkData.CollidedCount = this.walkData.CollidedCount + 1;
        }

        // TODO
        public bool CheckCollision(FieldObjectEntity target, float radius, float speed, bool CheckWeight = false, bool isCheckOnly = false, int targetPriority = 999, bool isCheckHeight = false) { return false; }

        // TODO
        public virtual void LateUpdate(float deltaTime) { }
    }
}