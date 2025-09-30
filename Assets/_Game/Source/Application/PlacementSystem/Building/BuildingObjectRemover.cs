using System;
using _Game.Source.Application.PlacementSystem.Building.PlaceFeature;
using _Game.Source.Application.PlacementSystem.Building.StateMachine;
using UniRx;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace _Game.Source.Application.PlacementSystem.Building
{
    public class BuildingObjectRemover: IInitializable, IDisposable
    {
        private readonly BuildingFSM _fsm;
        private readonly GameObject _buildingGameObject;
        private readonly IBuildingRemover _buildingRemover;
        private IDisposable _sub;

        public BuildingObjectRemover(BuildingFSM fsm, GameObject buildingGameObject, IBuildingRemover buildingRemover)
        {
            _fsm = fsm;
            _buildingGameObject = buildingGameObject;
            _buildingRemover = buildingRemover;
        }

        public void Initialize()
        {
            _sub = _fsm.State.Subscribe(OnStateChanged);
        }

        private void OnStateChanged(BuildingState state)
        {
            if (state == BuildingState.Remove)
            {
                _buildingRemover.RemoveObject();
                Object.Destroy(_buildingGameObject);
            }
        }

        public void Dispose()
        {
            _sub.Dispose();
        }
    }
}