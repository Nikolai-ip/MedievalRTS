using _Game.Source.Infrastructure.DI;
using _Game.Source.Infrastructure.Input;
using Zenject;

namespace _Game.Source.Infrastructure.DIInstallers.InputInstallers
{
    public class InputInstaller: SubInstaller
    {
        public override void InstallBindings(DiContainer container)
        {
            container
                .BindInterfacesTo<InputService>().AsSingle();
        }
    }
}