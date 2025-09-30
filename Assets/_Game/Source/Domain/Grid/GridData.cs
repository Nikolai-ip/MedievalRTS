using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Source.Domain.Grid
{
    public class GridData : IGridObjectAdder, IGridObjectValidator, IGridObjectRemover
    {
        private readonly Dictionary<Vector2Int, PlacementData> _placementObjects = new();

        public void AddObjectAt(Vector2Int gridPosition, Vector2Int objectSize, Guid id)
        {
            List<Vector2Int> positionToOccupy = CalculatePositions(gridPosition, objectSize);
            PlacementData data = new PlacementData(positionToOccupy, id);
            foreach (var pos in positionToOccupy)
            {
                if (_placementObjects.ContainsKey(pos))
                {
                    throw new Exception($"Dictionary already contains the cell pos {pos}");
                }
                _placementObjects[pos] = data;
            }
        }

        public void RemoveObjectAt(Vector2Int gridPosition, Vector2Int objectSize)
        {
            List<Vector2Int> positionToOccupy = CalculatePositions(gridPosition, objectSize);
            foreach (var pos in positionToOccupy)
            {
                _placementObjects.Remove(pos);
            }

        }

        private List<Vector2Int> CalculatePositions(Vector2Int gridPosition, Vector2Int objectSize)
        {
            var result = new List<Vector2Int>();
            for (int x = 0; x < objectSize.x; x++)
            {
                for (int y = 0; y < objectSize.y; y++)
                {
                    result.Add(gridPosition + new Vector2Int(x, y));
                }
            }

            return result;
        }

        public bool CanPlaceObjectAt(Vector2Int objectPos, Vector2Int objectSize)
        {
            List<Vector2Int> positionToOccupy = CalculatePositions(objectPos, objectSize);
            foreach (var pos in positionToOccupy)
            {
                if (_placementObjects.ContainsKey(pos))
                    return false;
            }

            return true;
        }
    }
}