using System;
using System.Threading;
using _Game.Source.Domain.Building;
using _Game.Source.Domain.Grid;
using _Game.Source.Domain.Grid.Converters;
using _Game.Source.Infrastructure.Input;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace _Game.Source.Application.PlacementSystem.Building.PlaceFeature
{
    public class BuildingPlacer: IDisposable, IBuildingPlacer, IBuildingRemover
    {
        private readonly Transform _buildingTr;
        private readonly ICellPosToWorldPosConverter _cellToWorldConverter;
        private readonly IWorldToCellPosConverter _worldToCellConverter;
        private readonly IInputService _inputService;
        private readonly IGridObjectAdder _gridObjectAdder;
        private readonly IGridObjectValidator _gridObjectValidator;
        private readonly IGridObjectRemover _gridObjectRemover;

        private readonly Vector2 _offset;
        private CancellationTokenSource _cts;
        public event Action<Vector2Int> OnBuildingPlaced;
    //    public Vector2Int CachedBuildingCellPos;
        public ReactiveProperty<bool> CanBePlaced { get; }
        private BuildingParams _buildingParams;

        public BuildingPlacer(BuildingParams buildingParams, Transform buildingTr, ICellPosToWorldPosConverter cellToWorldConverter, IInputService inputService, Vector2 offset,
            IGridObjectAdder gridObjectAdder, IGridObjectValidator gridObjectValidator, IGridObjectRemover gridObjectRemover)
        {
            _buildingParams = buildingParams;
            _buildingTr = buildingTr;
            _cellToWorldConverter = cellToWorldConverter;
            _inputService = inputService;
            _offset = offset;
            _gridObjectAdder = gridObjectAdder;
            _gridObjectValidator = gridObjectValidator;
            _gridObjectRemover = gridObjectRemover;
            CanBePlaced = new();
        }

        public void StartPlace()
        {
            _inputService.OnLeftMouseButtonClicked += TryStopPlace;
            _cts = new();
            MoveBuilding().Forget();
        }

        public void PlaceObject()
        {
            _gridObjectAdder.AddObjectAt(_buildingParams.CellPosition, _buildingParams.Size, _buildingParams.Id);
            _buildingTr.position  = _cellToWorldConverter.GridPosToWorld(_buildingParams.CellPosition) + _offset;
        }

        private async UniTask MoveBuilding()
        {
            try
            {
                while(_cts != null && !_cts.Token.IsCancellationRequested)
                {
                    _buildingParams.CellPosition = _worldToCellConverter.WorldToCell(_inputService.MousePosition);
                    Vector2 buildingWorldPos = _cellToWorldConverter.GridPosToWorld(_buildingParams.CellPosition);
                    _buildingTr.position = buildingWorldPos + _offset;
                    CanBePlaced.Value = _gridObjectValidator.CanPlaceObjectAt(_buildingParams.CellPosition, _buildingParams.Size);
                    await UniTask.Yield();
                }
            }
            catch (OperationCanceledException)
            { }
        }
        
        private void TryStopPlace()
        {
            if (_inputService.IsPointerOverUI()) return;
            if (!CanBePlaced.Value) return;
            StopPlace();
        }

        private void StopPlace()
        {
            _gridObjectAdder.AddObjectAt(_buildingParams.CellPosition, _buildingParams.Size, _buildingParams.Id);
            _inputService.OnLeftMouseButtonClicked -= TryStopPlace;
            DisposeCts();
            OnBuildingPlaced?.Invoke(_buildingParams.CellPosition);
        }

        public void RemoveObject()
        {
            _gridObjectRemover.RemoveObjectAt(_buildingParams.CellPosition, _buildingParams.Size);
        }

        public void Dispose() => DisposeCts();

        private void DisposeCts()
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = null;
        }
    }
}