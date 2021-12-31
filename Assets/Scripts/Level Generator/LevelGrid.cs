using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.LevelGeneration
{
    public class LevelGrid : GridSystem
    {
        [SerializeField] private RoomNode[,,] grid;

    }
}