using _Game.Source.Infrastructure.DI;
using _Game.Source.Presentation.SaveButton;
using _Game.Source.Presenter;
using UnityEngine;
using Zenject;

namespace _Game.Source.Installers.UIInstallers
{
    public class SaveButtonPresenterInstaller : SubInstaller
    {
        [SerializeField] private ButtonView<SaveLoadButton> _buttonView;

        public override void InstallBindings(DiContainer container)
        {
            container
                .Bind<IViewInteractable<SaveLoadButton>>()
                .FromInstance(_buttonView)
                .AsSingle();
        
            container
                .BindInterfacesTo<SaveButtonPresenter>()
                .AsCached();
        }
    }
}