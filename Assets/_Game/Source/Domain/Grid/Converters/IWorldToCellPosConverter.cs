using UnityEngine;

namespace _Game.Source.Domain.Grid.Converters
{
    public interface IWorldToCellPosConverter
    {
        Vector2Int WorldToCell(Vector2 worldPosition);
    }
}