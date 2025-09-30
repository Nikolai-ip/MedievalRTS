using System.Collections.Generic;
using UnityEngine;

namespace _Game.Source.Domain.Grid
{
    public class Grid<T>
    {
        public T[,] Nodes { get; }
        public Vector2 CellSize { get; }

        public Grid(T[,] nodes, Vector2 cellSize)
        {
            this.Nodes = nodes;
            CellSize = cellSize;
        }
        public List<T> GetNeighbors(int i, int j)
        {
            var neighbors = new List<T>();
            int rows = Nodes.GetLength(0);
            int cols = Nodes.GetLength(1);

            int[,] directions =
            {
                { 1, 0 }, { -1, 0 },
                { 0, 1 }, { 0, -1 },
                { 1, 1 }, { -1, 1 },
                { 1, -1 }, { -1, -1 }
            };

            for (int d = 0; d < directions.GetLength(0); d++)
            {
                int ni = i + directions[d, 0];
                int nj = j + directions[d, 1];

                if (ni >= 0 && ni < rows && nj >= 0 && nj < cols)
                {
                    neighbors.Add(Nodes[ni, nj]);
                }
            }

            return neighbors;
        }
    }
}