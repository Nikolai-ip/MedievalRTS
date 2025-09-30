using _Game.Source.Infrastructure.DI;
using _Game.Source.Presentation.CurrencyUI;
using _Game.Source.Presenter;
using UnityEngine;
using Zenject;

namespace _Game.Source.Installers.UIInstallers
{
    public class CurrencyPresenterInstaller : SubInstaller
    {
        [SerializeField] private CurrencyView _view;

        public override void InstallBindings(DiContainer container)
        {
            container
                .Bind<IView<CurrencyViewData>>()
                .FromInstance(_view)
                .AsSingle();
        
            container
                .BindInterfacesTo<CurrencyPresenter>()
                .AsCached();
        }
    }
}