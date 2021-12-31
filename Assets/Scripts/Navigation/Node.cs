using UnityEngine;

namespace RogueLike.Navigation
{
    public class Node : IHeapItem<Node>
    {
        public bool isWalkable;
        public Vector3 worldPosition;

        public int gridX;
        public int gridY;

        public int movementPenalty;

        public int gCost;
        public int hCost;

        public Node parent;

        private int heapIndex;

        public Node(bool isWalkable, Vector3 worldPosition, int gridX, int gridY, int movementPenalty)
        {
            this.isWalkable = isWalkable;
            this.worldPosition = worldPosition;

            this.gridX = gridX;
            this.gridY = gridY;

            this.movementPenalty = movementPenalty;
        }
        public int fCost
        {
            get 
            {
                return gCost + hCost;
            }
        }

        public int HeapIndex
        {
            get
            {
                return heapIndex;
            }
            set
            {
                heapIndex = value;
            }
        }

        public int CompareTo(Node nodeToCompare)
        {
            int compare = fCost.CompareTo(nodeToCompare.fCost);

            if(compare == 0)
            {
                compare = hCost.CompareTo(nodeToCompare.hCost);
            }

            return -compare;
        }
    }
}