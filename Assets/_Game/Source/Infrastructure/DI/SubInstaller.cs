using UnityEngine;
using Zenject;

namespace _Game.Source.Infrastructure.DI
{
    public abstract class SubInstaller:MonoBehaviour
    {
        public abstract void InstallBindings(DiContainer container);
    }
}