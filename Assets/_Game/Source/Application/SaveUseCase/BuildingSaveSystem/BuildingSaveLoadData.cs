using System.Collections.Generic;
using _Game.Source.Domain.Building;
using _Game.Source.Infrastructure.SaveLoadService.SaveLoadObjects;

namespace _Game.Source.Application.SaveUseCase.BuildingSaveSystem
{
    public class BuildingSaveLoadData: SaveLoadData
    {
        public BuildingSaveLoadData(List<BuildingParams> buildingParams) : base(new object[]{buildingParams}, nameof(BuildingSaveLoadData))
        {
        }
    }
}