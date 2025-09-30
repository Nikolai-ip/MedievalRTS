using _Game.Source.Domain.Grid;
using _Game.Source.Domain.Grid.Converters;
using UnityEngine;

namespace _Game.Source.Domain
{
    public class GridFactory
    {
        private readonly int _rows;
        private readonly int _columns;
        private readonly Vector2 _cellSize;
        private readonly ICellPosToWorldPosConverter _cellPosToWorldPosConverter;

        public GridFactory(int rows, int columns, Vector2 cellSize, ICellPosToWorldPosConverter cellPosToWorldPosConverter)
        {
            _rows = rows;
            _columns = columns;
            _cellSize = cellSize;

            _cellPosToWorldPosConverter = cellPosToWorldPosConverter;
        }

        public Grid<Node> Create()
        {
            Node[,] nodes = new Node[_rows, _columns];
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    var positon = _cellPosToWorldPosConverter.GridPosToWorld(new Vector2Int(j, i));
                    nodes[i, j] = new Node(positon);
                }
            }

            return new Grid<Node>(nodes, _cellSize);
        }
        
       
    }
}