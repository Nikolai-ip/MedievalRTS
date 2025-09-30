using System.Collections.Generic;
using _Game.Source.Application.PlacementSystem.Building;
using _Game.Source.Application.PlacementSystem.Building.PlaceFeature;
using _Game.Source.Application.PlacementSystem.Building.StateMachine;
using _Game.Source.Domain.Building;
using _Game.Source.Infrastructure;
using UnityEngine;
using Zenject;

namespace _Game.Source.Application.PlacementSystem.Factories
{
    /// <summary>
    /// Base factory class responsible for creating building instances.
    /// This factory ensures that each created building:
    /// - Is instantiated with the correct prefab for its type.
    /// - Has its lifetime scope built and resolved via the DI container.
    /// - Is initialized with the specified starting <see cref="BuildingState"/>.
    /// </summary>
    public class BuildingFactoryBase : IFactory<BuildingParams, BuildingDataComponent>
    {
        private Dictionary<BuildingType, BuildingDataComponent> _buildingPrefabsDataBase;
        private readonly BuildingState _initialState;
        private readonly Transform _container;
        private readonly IInstantiateProvider _instantiateProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingFactoryBase"/> class.
        /// </summary>
        /// <param name="buildingPrefabsDataBase">A dictionary mapping building types to their prefab data components.</param>
        /// <param name="initialState">The initial state that all created buildings will start in.</param>
        /// <param name="objectResolver">The object resolver used to instantiate buildings and their dependencies.</param>
        /// <param name="container">The parent object for instantiated building game objects</param>
        public BuildingFactoryBase(Dictionary<BuildingType, BuildingDataComponent> buildingPrefabsDataBase, BuildingState initialState,  Transform container, IInstantiateProvider instantiateProvider)
        {
            _buildingPrefabsDataBase = buildingPrefabsDataBase;
            _initialState = initialState;
            _container = container;
            _instantiateProvider = instantiateProvider;
        }
        
        /// <summary>
        /// Creates a new building instance based on the specified parameters.
        /// </summary>
        /// <param name="params">The parameters describing the building to create.</param>
        /// <returns>The instantiated and initialized <see cref="BuildingDataComponent"/>.</returns>
        /// <exception cref="KeyNotFoundException">
        /// Thrown if a prefab for the specified building type is not found in the prefab database.
        /// </exception>
        public BuildingDataComponent Create(BuildingParams @params)
        {
            if (_buildingPrefabsDataBase.TryGetValue(@params.BuildingType, out var prefab))
            {
                var buildingInstance = InstantiatePrefab(@params, prefab);
                return buildingInstance;
            }
            throw new KeyNotFoundException($"Failed to build building prefab with type {@params.BuildingType}");
        }

        private BuildingDataComponent InstantiatePrefab(BuildingParams @params, BuildingDataComponent prefab)
        {
            var instance = _instantiateProvider.Instantiate(prefab, _container);
            instance.SetBuildingData(@params, _initialState);
            return instance;
        }
        
    }
}