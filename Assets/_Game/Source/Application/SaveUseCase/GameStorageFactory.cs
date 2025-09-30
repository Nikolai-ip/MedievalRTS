using System;
using System.Collections.Generic;
using _Game.Source.Application.SaveUseCase.BuildingSaveSystem;
using _Game.Source.Domain.Building;
using _Game.Source.Infrastructure.SaveLoadService;
using _Game.Source.Infrastructure.SaveLoadService.SaveLoadObjects;

namespace _Game.Source.Application.SaveUseCase
{
    public class GameStorageFactory: StorageFactory
    {
        public override Dictionary<Type, ISaveLoadObject> GetDataStorages()
        {
            return new Dictionary<Type, ISaveLoadObject>()
            {
                {
                    typeof(BuildingSaveLoadDataStorage),
                    new BuildingSaveLoadDataStorage(new BuildingSaveLoadData(new List<BuildingParams>()))
                }
            };
        }
    }
}