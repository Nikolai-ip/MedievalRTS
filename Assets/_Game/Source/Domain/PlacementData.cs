using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Source.Domain
{
    internal class PlacementData
    {
        public List<Vector2Int> OccupiedPositions { get; }
        public Guid ID { get; private set; }

        public PlacementData(List<Vector2Int> occupiedPositions, Guid id)
        {
            ID = id;
            OccupiedPositions = occupiedPositions;
        }
    }
}