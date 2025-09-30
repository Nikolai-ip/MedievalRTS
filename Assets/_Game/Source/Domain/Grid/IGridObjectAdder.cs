using System;
using UnityEngine;

namespace _Game.Source.Domain.Grid
{
    /// <summary>
    /// Defines a contract for adding objects to a grid at specific positions.
    /// </summary>
    public interface IGridObjectAdder
    {
        /// <summary>
        /// Adds an object to the grid at the specified position and with the specified size.
        /// </summary>
        /// <param name="gridPosition">The starting grid position where the object should be placed.</param>
        /// <param name="objectSize">The size of the object in grid cells.</param>
        /// <param name="id">The unique identifier of the object to add.</param>
        void AddObjectAt(Vector2Int gridPosition, Vector2Int objectSize, Guid id);
    }
}