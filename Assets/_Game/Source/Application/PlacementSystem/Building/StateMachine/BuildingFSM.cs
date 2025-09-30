using System;
using _Game.Source.Application.PlacementSystem.Building.PlaceFeature;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Game.Source.Application.PlacementSystem.Building.StateMachine
{
    public class BuildingFSM: IInitializable, IDisposable
    {
        private BuildingState _currentState;
        public ReactiveProperty<BuildingState> State { get; private set; }

        private readonly IBuildingPlacer _buildingPlacer;
        private IDisposable _subscriber;

        public BuildingFSM(IBuildingPlacer buildingPlacer)
        {
            State = new ReactiveProperty<BuildingState>(BuildingState.None);
            _buildingPlacer = buildingPlacer;
        }

        public void SetState(BuildingState state) => State.Value = state;

        private void HandleStateTransition(BuildingState state)
        {
            if (state == BuildingState.Edit)
            {
                _buildingPlacer.StartPlace();
            }
        }

        public void Initialize()
        {
            _buildingPlacer.OnBuildingPlaced += SwitchToIdleState;
            _subscriber = State.Subscribe(HandleStateTransition);
        }

        private void SwitchToIdleState(Vector2Int pos) => State.Value = BuildingState.Idle;

        public void Dispose()
        {
            _buildingPlacer.OnBuildingPlaced -= SwitchToIdleState;
            _subscriber.Dispose();
        }
    }
}