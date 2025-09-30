using _Game.Source.Domain;
using _Game.Source.Domain.Grid;
using _Game.Source.Domain.Grid.Converters;
using _Game.Source.Infrastructure.Configs;
using _Game.Source.Infrastructure.DI;
using UnityEngine;
using Zenject;

namespace _Game.Source.Infrastructure.DIInstallers
{
    public class GridInstaller: SubInstaller
    {
        [SerializeField] private GridParams_SO _gridParamsSo;

        public override void InstallBindings(DiContainer container)
        {
            IsometricCoordsConverter converter = new(_gridParamsSo.GridParams.CellSize, _gridParamsSo.GridParams.StartPosition);
            container.BindInterfacesTo<IsometricCoordsConverter>().FromInstance(converter).AsSingle();
            container.Bind<Grid<Node>>()
                .FromInstance(new GridFactory(_gridParamsSo.GridParams.Rows, _gridParamsSo.GridParams.Columns, _gridParamsSo.GridParams.CellSize, converter).Create())
                .AsSingle();
           
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_gridParamsSo.GridParams.StartPosition, 0.1f);
        }
    }
}