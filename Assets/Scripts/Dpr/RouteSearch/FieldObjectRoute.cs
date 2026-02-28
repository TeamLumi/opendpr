using UnityEngine;

namespace Dpr.RouteSearch
{
    public static class FieldObjectRoute
    {
        private static readonly int OneBlockGridCount = 32;
        private static readonly Vector2Int[] MoveVec = new Vector2Int[8]
        {
            Vector2Int.up,    new Vector2Int(1, 1),
            Vector2Int.right, new Vector2Int(1, -1),
            Vector2Int.down,  new Vector2Int(-1, -1),
            Vector2Int.left,  new Vector2Int(-1, 1),
        };
        private static readonly float StraightCost = 1.0f;
        private static readonly float DiagonalCost = 1.1414214f;
        private static readonly int DefaultNodeWidth = OneBlockGridCount;
        private static readonly int DefaultNodeHeight = OneBlockGridCount;

        // TODO
        public static Vector3[] Search(ObjectType characterType, in Vector3 start, in Vector3 goal, AttributeMatrix matrix) { return null; }

        // TODO
        public static Vector3[] Search(ObjectType characterType, in Vector3 start, in Vector3 goal, AttributeMatrix matrix, NodeData nodeData) { return null; }

        public static NodeData CreateNodeData(int width, int height)
        {
        	var uVar1 = new RouteSearch_NodeData();
        	uVar1.Initialize(width,height);
        	return uVar1;
        }

        // TODO
        private static Vector3[] SearchCore(ObjectType characterType, in Vector3 startPos, in Vector3 goalPos, AttributeMatrix matrix, NodeData nodeData) { return null; }

        // TODO
        private static void OpenNodes(Node currentNode, AttributeMatrix matrix, NodeData nodeData) { }

        // TODO
        private static void SetupAttribute(Node node, AttributeMatrix matrix, NodeData nodeData) { }

        // TODO
        private static Node GetBestScoreOpenNode(NodeData nodeData) { return null; }

        // TODO
        private static Vector3[] BuildRoute(Node startNode, Node goalNode, NodeData nodeData) { return null; }
    }
}