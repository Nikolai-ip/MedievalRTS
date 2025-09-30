using System.Collections.Generic;
using _Game.Source.Domain.GameData;
using _Game.Source.Infrastructure.DI;
using _Game.Source.Infrastructure.StaticData;
using _Game.Source.Presenter;
using _Game.Source.Presenter.PlacementBuildingsUI;
using _Game.Source.Presenter.PlacementBuildingsUI.View;
using UnityEngine;
using Zenject;

namespace _Game.Source.Installers.UIInstallers
{
    public class BuildingShopInstaller : SubInstaller
    {
        [SerializeField] private BuildingsShopView _view;
        [SerializeField] private List<BuyBuildingButton> _buyButtons;
        [SerializeField] private BuildingsShopCatalog_SO _catalog;

        public override void InstallBindings(DiContainer container)
        {
            _view.Init(_buyButtons);

            container
                .Bind<IView<BuildingsShopViewData>>()
                .FromInstance(_view)
                .AsSingle();
        
            container
                .Bind<IViewInteractable<BuildingPurchasedCallback>>()
                .FromInstance(_view)
                .AsSingle();
        
            container
                .Bind<BuildingsShopCatalog>()
                .FromInstance(_catalog.GetCatalogue())
                .AsSingle();
        
            container
                .BindInterfacesTo<BuildingsShopPresenter>()
                .AsCached();
        }
    }
}