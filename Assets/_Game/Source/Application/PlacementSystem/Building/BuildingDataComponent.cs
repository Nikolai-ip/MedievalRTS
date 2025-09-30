using System;
using _Game.Source.Application.PlacementSystem.Building.PlaceFeature;
using _Game.Source.Application.PlacementSystem.Building.StateMachine;
using _Game.Source.Domain.Building;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Game.Source.Application.PlacementSystem.Building
{
    public class BuildingDataComponent: MonoBehaviour
    {
        [SerializeField] private Vector2Int _size;
        [SerializeField] private BuildingType _type;
        private readonly BuildingParams _buildingParams = new();

        public BuildingParams BuildingParams => _buildingParams;

        private BuildingFSM _buildingFsm;
        private IBuildingPlacer _buildingPlacer;
        
        [Inject]
        public void Construct(BuildingFSM buildingFsm, IBuildingPlacer buildingPlacer)
        {
            _buildingFsm = buildingFsm;
            _buildingPlacer = buildingPlacer;
        }
        public void SetBuildingData(BuildingParams @params, BuildingState state)
        {
            _buildingParams.Id = @params.Id;
            _buildingParams.CellPosition = @params.CellPosition;
            _buildingParams.Level = @params.Level;
            if (state == BuildingState.Idle) 
                _buildingPlacer.PlaceObject();
            _buildingFsm.SetState(state);
        }
    }
}