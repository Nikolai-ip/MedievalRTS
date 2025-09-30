using System;
using UnityEngine;

namespace _Game.Source.Domain.Building
{
    public class BuildingParams
    {
        public Guid Id { get; set; }
        public Vector2Int CellPosition { get; set; }
        public int Level { get; set; }
        public Vector2Int Size { get; set; }
        public BuildingType BuildingType { get; set; }

        public BuildingParams(Guid id, Vector2Int cellPosition, int level, Vector2Int size, BuildingType buildingType)
        {
            Id = id;
            CellPosition = cellPosition;
            Level = level;
            Size = size;
            BuildingType = buildingType;
        }

        public BuildingParams() { }
    }
    
}