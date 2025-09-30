using System;
using _Game.Source.Application.PlacementSystem.Building;
using _Game.Source.Domain.Building;
using UnityEngine;
using Zenject;

namespace _Game.Source.Application.PlacementSystem.Factories
{
    public class BuildingRuntimeSpawner: IBuildingSpawner
    {
        private IFactory<BuildingParams, BuildingDataComponent> _factory;

        public BuildingRuntimeSpawner([Inject(Id = BuildingFactoryKey.Runtime)] IFactory<BuildingParams, BuildingDataComponent> factory)
        {
            _factory = factory;
        }
        
        /// <summary>
        /// Spawns a new building of the specified type at the default runtime position.
        /// </summary>
        /// <param name="buildingType">The type of building to spawn.</param>
        /// <returns>The instantiated <see cref="BuildingDataComponent"/>.</returns>
        public BuildingDataComponent Spawn(BuildingType buildingType)
        {
            return _factory.Create(new BuildingParams(
                Guid.NewGuid(),
                Vector2Int.zero,
                0,
                -Vector2Int.one,
                buildingType));
        }
    }

    /// <summary>
    /// Defines a contract for spawning building instances.
    /// </summary>
    public interface IBuildingSpawner
    {
        /// <summary>
        /// Spawns a new building of the specified type.
        /// </summary>
        /// <param name="buildingType">The type of building to spawn.</param>
        /// <returns>The instantiated <see cref="BuildingDataComponent"/>.</returns>
        BuildingDataComponent Spawn(BuildingType buildingType);
    }
}