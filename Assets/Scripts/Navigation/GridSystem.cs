using UnityEngine;

namespace RogueLike.Navigation
{
    public class GridSystem
    {
        [SerializeField] private int width;
        [SerializeField] private int height;
        [SerializeField] private int cellSize;
        [SerializeField] Vector3 originPosition;
        [SerializeField] private int[,] gridArray;

        public int[,] GridArray()
        {
            return gridArray;
        }
        

        public GridSystem(int width, int height, int cellSize, Vector3 originPosition)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;
            this.originPosition = originPosition;

            gridArray = new int[width, height];

            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
                }
            }

            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
        }

        private Vector3 GetWorldPosition(int x, int y)
        {
            return new Vector3(x, 0, y) * cellSize + originPosition;
        }

        private void ConvertWorldPosToGrid(Vector3 worldPost, out int x, out int y)
        {
            x = Mathf.FloorToInt((worldPost - originPosition).x / cellSize);
            y = Mathf.FloorToInt((worldPost - originPosition).y / cellSize);
        }
    }
}