using System.Collections.Generic;
using _Game.Source.Domain.Building;
using _Game.Source.Infrastructure.SaveLoadService;
using _Game.Source.Infrastructure.SaveLoadService.SaveLoadObjects;

namespace _Game.Source.Application.SaveUseCase.BuildingSaveSystem
{
    public class BuildingSaveLoadDataStorage: SaveLoadDataStorage
    {
        public List<BuildingParams> GetSavedBuildingsParams => GetSavedData<List<BuildingParams>>();
        
        public BuildingSaveLoadDataStorage(SaveLoadData saveLoadData) : base(saveLoadData) { }
        public override void RestoreValues(SaveLoadData saveLoadData)
        {
            RestoreValue<List<BuildingParams>>(saveLoadData);
        }

        public void UpdateData(List<BuildingParams> buildings)
        {
            GetSavedBuildingsParams.Clear();
            GetSavedBuildingsParams.AddRange(buildings);
        }

        public List<BuildingParams> CopyData()
        {
            var copiedData = new  List<BuildingParams>();
            foreach (var buildingParam in GetSavedBuildingsParams)
                copiedData.Add(buildingParam);
            

            return copiedData;
        }
    }
}