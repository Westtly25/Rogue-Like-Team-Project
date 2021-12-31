using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.LevelGeneration
{
    public class GridSystem : MonoBehaviour
    {
        [SerializeField] private int gridWidth;
        [SerializeField] private int gridHeight;
        [SerializeField] private int cellSize;

        [SerializeField] private Grid grid;

        [SerializeField] private int minPath;
        [SerializeField] private int maxPath;

        [ContextMenu("Build Grid")]
        private void Awake()
        {
            //grid = new Grid(gridWidth, gridHeight, cellSize, transform.position);

            minPath = gridWidth + gridHeight;
            maxPath = gridWidth * gridHeight;
        }
    }

    public class GridObject
    {
        [SerializeField] private Grid grid;
        [SerializeField] private int sizeX;
        [SerializeField] private int sizeY;

        public GridObject(Grid grid, int x, int y)
        {
            this.grid = grid;
            sizeX = x;
            sizeY = y;
        }
    }
}