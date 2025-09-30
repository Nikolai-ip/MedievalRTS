using System;
using System.Collections.Generic;
using _Game.Source.Domain.Building;
using UnityEngine;

namespace _Game.Source.Presenter.PlacementBuildingsUI.View
{
    public class BuildingsShopView: MonoBehaviour, IViewEnableable<BuildingsShopViewData>, IViewInteractable<BuildingPurchasedCallback>
    {
        private List<BuyBuildingButton> _buyBuildingButtons;
        public event Action<BuildingPurchasedCallback> callback;

        public void Init(List<BuyBuildingButton> buyBuildingButtons)
        {
            _buyBuildingButtons = buyBuildingButtons;
            _buyBuildingButtons.ForEach(button => button.callback += OnBuildingBuyButtonClicked);
        }
        private void OnDisable() => _buyBuildingButtons.ForEach(button=>button.callback -= OnBuildingBuyButtonClicked);

        private void OnBuildingBuyButtonClicked(BuildingPurchasedCallback callbackData)
        {
            callback?.Invoke(callbackData);
        }

        public void SetData(BuildingsShopViewData data)
        {
            foreach (var buildingButton in _buyBuildingButtons)
            {
                if (data.AvailableBuildings.TryGetValue(buildingButton.BuildingType, out bool buildingPurchaseIsAvailable))
                    buildingButton.SetData(new ButtonViewData(buildingPurchaseIsAvailable));
                
            }
        }

        public void Show()
        {
            //todo: Show shop animation
        }

        public void Hide()
        {
            //todo: Hide shop animation
        }
    }

    public struct BuildingsShopViewData
    {
        public Dictionary<BuildingType, bool> AvailableBuildings { get; }


        public BuildingsShopViewData(Dictionary<BuildingType, bool> availableBuildings)
        {
            AvailableBuildings = availableBuildings;
        }
    }
}