using System.Collections.Generic;
using _Game.Source.Domain.Building;

namespace _Game.Source.Domain.GameData
{
    public class BuildingsShopCatalog
    {
        public Dictionary<BuildingType, Currency> BuildingCosts { get; private set; }

        public BuildingsShopCatalog(Dictionary<BuildingType, Currency> buildingCosts)
        {
            BuildingCosts = buildingCosts;
        }
        
    }
}