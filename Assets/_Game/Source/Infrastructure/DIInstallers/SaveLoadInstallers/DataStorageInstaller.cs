using _Game.Source.Infrastructure.DI;
using Zenject;

namespace _Game.Source.Infrastructure.DIInstallers.SaveLoadInstallers
{
    public class DataStorageInstaller : SubInstaller
    {
        public override void InstallBindings(DiContainer container)
        {
            //todo
            
            // var saveLoadSystem = new SaveLoadSystem();
            // container.Bind<ISaveLoadService>().FromInstance(saveLoadSystem).AsSingle();
            //
            // BindGameDataStorage(saveLoadSystem, container);
            // saveLoadSystem.LoadGame();
            // saveLoadSystem.SaveGame();
        }

        // private void BindGameDataStorage(ISaveLoadService saveLoadSystem, DiContainer container)
        // {
        //     var dataStorages = new GameStorageFactory().GetDataStorages();
        //     foreach (var dataStorage in dataStorages)
        //     {
        //         container.Bind(dataStorage.Key).FromInstance(dataStorage.Value).AsSingle();
        //     }
        //     var gameDataStorage = new GameDataStorage(saveLoadSystem, dataStorages);
        // }
    }
}