using _Game.Source.Domain.Building;

namespace _Game.Source.Presenter.PlacementBuildingsUI.View
{
    public struct BuildingPurchasedCallback
    {
        public BuildingType BuildingType { get; private set; }

        public BuildingPurchasedCallback(BuildingType buildingType)
        {
            BuildingType = buildingType;
        }
    }
}