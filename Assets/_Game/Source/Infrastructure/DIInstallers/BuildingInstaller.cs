using _Game.Source.Application.PlacementSystem.Building;
using _Game.Source.Application.PlacementSystem.Building.Messages;
using _Game.Source.Application.PlacementSystem.Building.PlaceFeature;
using _Game.Source.Application.PlacementSystem.Building.StateMachine;
using _Game.Source.Application.PlacementSystem.Building.UpgradeFeature;
using _Game.Source.Infrastructure.DI;
using UnityEngine;
using Zenject;

namespace _Game.Source.Infrastructure.DIInstallers
{
    public class BuildingInstaller: SubInstaller
    {
        [SerializeField] private Vector3 _buildingMoveOffset;
        public override void InstallBindings(DiContainer container)
        {
            container.Bind<Transform>().FromInstance(transform).AsSingle();
            container.BindInterfacesTo<BuildingPlacer>()
                .AsSingle()
                .WithArguments(_buildingMoveOffset);
            container.BindInterfacesAndSelfTo<BuildingFSM>().AsSingle();
            container.Bind<BuildingDataComponent>().FromInstance(GetComponent<BuildingDataComponent>()).AsSingle();
            container.BindInterfacesTo<BuildingActivePublisher>().AsSingle();
            container.Bind<IBuildingUpgrader>().To<BuildingUpgrader>().AsSingle();
            container.BindInterfacesTo<BuildingActionsProvider>().AsSingle();
            container.BindInterfacesTo<BuildingObjectRemover>()
                .AsSingle()
                .WithArguments(gameObject);
        }
    }
    
}