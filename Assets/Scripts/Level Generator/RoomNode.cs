using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.LevelGeneration
{
    public class RoomNode
    {
        [SerializeField] private int positionX;
        [SerializeField] private int positionY;
        [SerializeField] private Vector3 worldPosition;

        public int gCost;
        public int hCost;
        public int fCost;

        public RoomNode cameFromNode;

        public int PositionX
        { 
            get { return positionX; }
            private set { positionX = value; }
        }

        public int PositionY
        { 
            get { return positionY; }
            private set { positionY = value; }
        }

        public Vector3 WorldPosition
        { 
            get { return worldPosition; }
            set { worldPosition = value; }
        }
        
        public RoomNode(int positionX, int positionY,  Vector3 worldPosition)
        {
            PositionX = positionX;
            PositionY = positionY;
            WorldPosition = worldPosition;
        }
    }
}