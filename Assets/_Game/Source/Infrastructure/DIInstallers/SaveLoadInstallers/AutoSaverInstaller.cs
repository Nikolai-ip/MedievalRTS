using _Game.Source.Infrastructure.DI;
using UnityEngine;
using Zenject;

namespace _Game.Source.Infrastructure.DIInstallers.SaveLoadInstallers
{
    public class AutoSaverInstaller : SubInstaller
    {
        [SerializeField] private float _saveIntervalSeconds;

        public override void InstallBindings(DiContainer container)
        {
            //todo:
            
            // container.BindInterfacesTo<AutoSaver>()
            //     .AsSingle()
            //     .WithArguments(_saveIntervalSeconds);
        }
    }
}