using System.Collections.Generic;
using _Game.Source.Infrastructure.SaveLoadService.SaveLoadObjects;

namespace _Game.Source.Infrastructure.SaveLoadService.SaveLoadStrategies
{
    public interface ISaveLoadStrategy
    {
        public void Save(IEnumerable<ISaveLoadObject> objectsToSave);
        public SaveLoadData[] Load();
    }
}