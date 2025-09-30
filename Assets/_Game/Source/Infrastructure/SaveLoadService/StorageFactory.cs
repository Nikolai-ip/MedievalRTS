using System;
using System.Collections.Generic;
using _Game.Source.Infrastructure.SaveLoadService.SaveLoadObjects;

namespace _Game.Source.Infrastructure.SaveLoadService
{
    public abstract class StorageFactory
    {
        public abstract Dictionary<Type, ISaveLoadObject> GetDataStorages();
    }
}