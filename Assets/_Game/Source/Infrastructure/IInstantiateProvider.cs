using UnityEngine;

namespace _Game.Source.Infrastructure
{
    public interface IInstantiateProvider
    {
        T Instantiate<T>(T prefab, Transform parent) where T : Component;
    }
}