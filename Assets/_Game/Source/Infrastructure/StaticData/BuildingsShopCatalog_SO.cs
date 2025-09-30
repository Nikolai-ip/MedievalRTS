using _Game.Source.Domain;
using _Game.Source.Domain.Building;
using _Game.Source.Domain.GameData;
using _Game.Source.Tools;
using UnityEngine;

namespace _Game.Source.Infrastructure.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Buildigs/BuildingsShopCatalog", fileName = "BuildingsShopCatalog")]

    public class BuildingsShopCatalog_SO: ScriptableObject
    {
        [SerializeField] private DictionaryInspector<BuildingType, Currency> _buildingsCatalog;
            
        public BuildingsShopCatalog GetCatalogue()
        {
            return new BuildingsShopCatalog(_buildingsCatalog.GetDictionary());
        }
    }
}