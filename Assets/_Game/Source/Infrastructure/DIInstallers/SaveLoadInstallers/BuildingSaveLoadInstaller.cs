using _Game.Source.Infrastructure.DI;
using Zenject;

namespace _Game.Source.Infrastructure.DIInstallers.SaveLoadInstallers
{
    public class BuildingSaveLoadInstaller : SubInstaller
    {
        public override void InstallBindings(DiContainer container)
        {
            //todo:
            
            // container.BindInterfacesTo<BuildingsSaver>().AsSingle();
            // container.BindInterfacesTo<SavedBuildingsRestorer>().AsSingle();
        }
    }
}