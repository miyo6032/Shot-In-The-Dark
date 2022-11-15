using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathing
{
    public class NPatrolPath : MonoBehaviour
    {
        public float paceSpeed;
        public List<PatrolNode> nodes;
    }

    public class NMover
    {
        private NPatrolPath path;
        private int node;

        public NMover(NPatrolPath path)
        {
            this.path = path;
            Position = path.transform.TransformPoint(path.nodes[node].position);
            node = -1;
            LerpToNextNode();
        }

        private void LerpToNextNode()
        {
            IsMoving = false;
            node = GetNextNode();
            PatrolNode currentNode = path.nodes[node];
            PatrolNode nextNode = path.nodes[GetNextNode()];
            float time = (currentNode.position - nextNode.position).magnitude / path.paceSpeed;
            LeanTween.value(path.gameObject, SetPosition, 0f, 1f, time).setDelay(path.nodes[node].pause).setOnComplete(LerpToNextNode);
        }

        private void SetPosition(float progress)
        {
            IsMoving = true;
            PatrolNode currentNode = path.nodes[node];
            PatrolNode nextNode = path.nodes[GetNextNode()];
            Direction = nextNode.position - currentNode.position;
            Position = path.transform.TransformPoint(Vector2.Lerp(currentNode.position, nextNode.position, progress));
        }

        private int GetNextNode()
        {
            if (node == path.nodes.Count - 1)
            {
                return 0;
            }

            return node + 1;
        }

        public Vector2 Position { get; private set; }
        public Vector2 Direction { get; private set; }
        public bool IsMoving { get; private set; }
    }

    [Serializable]
    public class PatrolNode
    {
        public Vector2 position;
        public Vector2 restingDirection;
        public float pause;
    }
}