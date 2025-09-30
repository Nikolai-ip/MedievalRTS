using _Game.Source.Infrastructure.DI;
using MessagePipe;
using Zenject;

namespace _Game.Source.Infrastructure.DIInstallers
{
    public class MessagePipeInstaller : SubInstaller
    {
        public override void InstallBindings(DiContainer container)
        {
            container.BindMessagePipe();
        }
    }
}