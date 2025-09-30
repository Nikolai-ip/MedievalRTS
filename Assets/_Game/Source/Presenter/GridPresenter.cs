using _Game.Source.Domain.Grid;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Game.Source.Presenter
{
    public class GridPresenter: MonoBehaviour
    {
        private Grid<Node> _grid;

        [SerializeField] private Transform _cellObject;
        [SerializeField] private Transform _container;

        [Inject]
        public void Construct(Grid<Node> grid)
        {
            _grid = grid;
        }
        
        private void Start()
        {
            for (int i = 0; i < _grid.Nodes.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.Nodes.GetLength(1); j++)
                {
                    var cell = Instantiate(_cellObject, _container);
                    cell.position = _grid.Nodes[i, j].Position;
                    cell.GetComponentInChildren<TextMeshProUGUI>().text = $"{i} {j}";
                }
            }
        }
    }
}