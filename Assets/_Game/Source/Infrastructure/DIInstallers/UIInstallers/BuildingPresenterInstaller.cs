using System.Collections.Generic;
using _Game.Source.Infrastructure.DI;
using _Game.Source.Presenter;
using _Game.Source.Presenter.Building.BuildingPlacePresentation;
using UnityEngine;
using Zenject;

namespace _Game.Source.Installers.UIInstallers
{
    public class BuildingPresenterInstaller: SubInstaller
    {
        [SerializeField] private BuildingModelToggler _modelTogglerView;
        
        public override void InstallBindings(DiContainer container)
        {
            container
                .Bind<IView<BuildingModelTogglerData>>().FromInstance(_modelTogglerView).AsSingle();
            container
                .BindInterfacesTo<BuildingPlacementValidPresenter>()
                .AsCached();
        }
    }
}