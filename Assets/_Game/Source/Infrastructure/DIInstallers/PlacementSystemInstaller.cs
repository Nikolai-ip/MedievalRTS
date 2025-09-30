using _Game.Source.Infrastructure.DI;
using UnityEngine;
using Zenject;

namespace _Game.Source.Infrastructure.DIInstallers
{
    public class PlacementSystemInstaller : SubInstaller
    {
      //  [SerializeField] private BuildingDataBase_SO _buildingDataBase;
        [SerializeField] private Transform _buildingContainer;

        public override void InstallBindings(DiContainer container)
        {
            //todo
            
            // container.BindInterfacesTo<GridData>().AsSingle();
            // container.Bind<GridPointerPosition>().AsTransient();
            //
            // container.Bind<BuildingDataBase>().FromInstance(_buildingDataBase.GetDataBase()).AsSingle();
            //
            // container.Bind<IFactory<BuildingDataComponent, BuildingParams>>()
            //     .WithId(BuildingFactoryKey.Runtime)
            //     .To<BuildingFactoryBase>()
            //     .AsSingle()
            //     .WithArguments(BuildingState.Edit, _buildingContainer);
            //
            // container.Bind<IFactory<BuildingDataComponent, BuildingParams>>()
            //     .WithId(BuildingFactoryKey.Restore)
            //     .To<BuildingFactoryBase>()
            //     .AsSingle()
            //     .WithArguments(BuildingState.Idle, _buildingContainer);
            //
            // container.Bind<IBuildingContainer>().To<BuildingContainer>().AsSingle();
            // container.BindInterfacesTo<BuildingRuntimeSpawner>().AsSingle();
            // container.BindInterfacesTo<BuildingContainerUpdater>().AsSingle();
        }
    }
}