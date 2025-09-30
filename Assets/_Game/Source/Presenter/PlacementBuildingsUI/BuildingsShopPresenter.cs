using System;
using System.Collections.Generic;
using _Game.Source.Application.PlacementSystem.Factories;
using _Game.Source.Domain;
using _Game.Source.Domain.Building;
using _Game.Source.Domain.GameData;
using _Game.Source.Presenter.PlacementBuildingsUI.View;
using UniRx;
using Zenject;

namespace _Game.Source.Presenter.PlacementBuildingsUI
{
    public class BuildingsShopPresenter: IInitializable, IDisposable
    {
        private readonly IViewEnableable<BuildingsShopViewData> _view;
        private readonly IViewInteractable<BuildingPurchasedCallback> _viewCallbackInvoker;
        private readonly CurrencyHolder _currencyHolder;
        private readonly BuildingsShopCatalog _shopCatalog;
        private IDisposable _currencyChangedSubscription;
        private readonly IBuildingSpawner _buildingSpawner; 
        
        
        public BuildingsShopPresenter(IViewEnableable<BuildingsShopViewData> view, IViewInteractable<BuildingPurchasedCallback> viewCallbackInvoker,
            CurrencyHolder currencyHolder, BuildingsShopCatalog shopCatalog, IBuildingSpawner buildingSpawner)
        {
            _view = view;
            _viewCallbackInvoker = viewCallbackInvoker;
            _currencyHolder = currencyHolder;
            _shopCatalog = shopCatalog;
            _buildingSpawner = buildingSpawner;
        }

        public void Initialize()
        {
            _currencyChangedSubscription = _currencyHolder.CurrencyProperty.Subscribe(OnCurrencyChanged);
            _viewCallbackInvoker.callback += HandleViewCallback;
            UpdateView();
        }

        private void HandleViewCallback(BuildingPurchasedCallback purchasedCallback)
        {
            if (_shopCatalog.BuildingCosts.TryGetValue(purchasedCallback.BuildingType, out Currency cost))
            {
                _buildingSpawner.Spawn(purchasedCallback.BuildingType);
                _currencyHolder.SubCurrency(cost);
            }
        }


        private void OnCurrencyChanged(Currency currency) => UpdateView();

        private void UpdateView()
        {
            Dictionary<BuildingType, bool> availableBuildings = new();
            foreach (var kvp in _shopCatalog.BuildingCosts)
            {
                availableBuildings.Add(kvp.Key, _currencyHolder.IsEnough(kvp.Value));
            }
            _view.SetData(new BuildingsShopViewData(availableBuildings));
        }

        public void Dispose()
        {
            _viewCallbackInvoker.callback -= HandleViewCallback;
            _currencyChangedSubscription.Dispose();
        }
    }
    
}