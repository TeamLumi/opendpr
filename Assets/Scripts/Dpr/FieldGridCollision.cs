using Dpr.EvScript;
using UnityEngine;

namespace Dpr
{
    public static class FieldGridCollision
    {
        // TODO
        public static EvDataManager.EntityParam CheckGridEventMoveEntity(out Vector3 outWorldPos, FieldObjectEntity entity)
        {
            // TODO
            void CalcStopPos(out Vector3 inner_outWorldPos, in Vector2Int inner_grid)
            {
                inner_outWorldPos = Vector3.zero;
            }

            outWorldPos = Vector3.zero;
            return null;
        }

        // TODO
        public static GridCollisionType CheckGriCollisionMoveEntity(out Vector3 outVelocity, Vector3 worldPosition, Vector3 worldVelocity, float entityRadius, ICheckGridFunc checkGridFunc, GridCollisionIgnoreDir ignoreDir = GridCollisionIgnoreDir.None)
        {
            outVelocity = Vector3.zero;
            return GridCollisionType.None;
        }

        // TODO
        public static GridCollisionType CheckGriCollisionMoveEntity(out Vector3 outVelocity, out Vector3 outHitNormal, out float outHitAngle, Vector3 worldPosition, Vector3 worldVelocity, float entityRadius, ICheckGridFunc checkGridFunc, GridCollisionIgnoreDir ignoreDir = GridCollisionIgnoreDir.None)
        {
            // TODO
            bool CheckHitGrid(Vector2 basePos, Vector2 velocity, out GridCollisionType outAttr, out float outTime, out Vector2 outNormal, out Vector2Int outGrid)
            {
                outAttr = GridCollisionType.None;
                outTime = 0.0f;
                outNormal = Vector2.zero;
                outGrid = Vector2Int.zero;
                return false;
            }

            outVelocity = Vector3.zero;
            outHitNormal = Vector3.zero;
            outHitAngle = 0.0f;
            return GridCollisionType.None;
        }

        private static float Vector2Cross(in Vector2 lhs, in Vector2 rhs)
        {
        	return lhs * rhs[1] - lhs[1] * rhs;
        }

        // TODO
        private static Vector2 Vector2Project(in Vector2 vector, in Vector2 normal) { return Vector2.zero; }

        // TODO
        private static void PointPerpendicularLineOnLineSegment(out Vector2 outPoint, out float outTime, Vector2 point, Vector2 start, Vector2 end)
        {
            outPoint = Vector2.zero;
            outTime = 0.0f;
        }

        // TODO
        private static bool CheckCirclePoint(out float outTime, Vector2 centerA, float radiusA, Vector2 velocityA, Vector2 pointB)
        {
            outTime = 0.0f;
            return false;
        }

        // TODO
        private static bool CheckCircleLineSegment(out float outTime, Vector2 centerA, float radiusA, Vector2 velocityA, Vector2 startB, Vector2 endB)
        {
            outTime = 0.0f;
            return false;
        }

        public enum GridCollisionType : int
        {
            None = 0,
            NoEntry = 1,
            Water = 2,
            Npc = 3,
        }

        public enum GridCollisionIgnoreDir : int
        {
            None = 0,
            Side = 1,
            Vert = 2,
        }

        public interface ICheckGridFunc
        {
            GridCollisionType Check(Vector2Int grid);
        }
    }
}