using UnityEngine;

namespace _Game.Source.Domain.Grid.Converters
{
    public class IsometricCoordsConverter: ICellPosToWorldPosConverter, IWorldToCellPosConverter
    {
        private readonly Vector2 _cellSize;
        private readonly Vector2 _startGridPos;

        public IsometricCoordsConverter(Vector2 cellSize, Vector2 startGridPos)
        {
            _cellSize = cellSize;
            _startGridPos = startGridPos;
        }

        public Vector2 GridPosToWorld(Vector2Int gridPos)
        {
            float x = gridPos.x * _cellSize.x/2 - gridPos.y * _cellSize.x/2; 
            float y = -gridPos.x * _cellSize.y/2 - gridPos.y * _cellSize.y/2;
            return new Vector2(x, y) + _startGridPos;
        }

        public Vector2Int WorldToCell(Vector2 worldPosition)
        {
            Vector2 local =  worldPosition - _startGridPos;
            float i = - local.x / _cellSize.x - local.y/ _cellSize.y;
            float j =  local.x / _cellSize.x - local.y/ _cellSize.y;
            int iInt = Mathf.RoundToInt(i);
            int jInt = Mathf.RoundToInt(j);
            return new Vector2Int(jInt, iInt);
        }
    }
}