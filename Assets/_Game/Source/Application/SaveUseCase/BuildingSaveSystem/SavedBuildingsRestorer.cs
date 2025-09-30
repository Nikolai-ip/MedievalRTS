using _Game.Source.Application.PlacementSystem.Building;
using _Game.Source.Application.PlacementSystem.Factories;
using _Game.Source.Domain.Building;
using Zenject;

namespace _Game.Source.Application.SaveUseCase.BuildingSaveSystem
{
    /// <summary>
    /// Restores saved building instances from persistent storage during initialization.
    /// Uses a dedicated restoration factory to recreate each building from saved parameters.
    /// </summary>
    public class SavedBuildingsRestorer: IInitializable
    {
        private readonly BuildingSaveLoadDataStorage _dataStorage;
        private readonly IFactory<BuildingParams, BuildingDataComponent> _buildingFactory;

        public SavedBuildingsRestorer(BuildingSaveLoadDataStorage dataStorage, [Inject(Id = BuildingFactoryKey.Restore)]IFactory<BuildingParams, BuildingDataComponent> buildingFactory)
        {
            _dataStorage = dataStorage;
            _buildingFactory = buildingFactory;
        }

        public void Initialize()
        {
            foreach (var savedBuildingsParam in _dataStorage.CopyData())
            {
                _buildingFactory.Create(savedBuildingsParam);
            }
        }
    }
}