using UnityEngine;

namespace _Game.Source.Domain.Grid.Converters
{
    public interface ICellPosToWorldPosConverter
    {
         Vector2 GridPosToWorld(Vector2Int gridPos);
    }
}