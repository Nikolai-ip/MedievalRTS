using _Game.Source.Domain.Grid;
using _Game.Source.Domain.Grid.Converters;
using UnityEngine;
using Zenject;

namespace _Game.Source.Test
{
    public class GridTranslationTest: MonoBehaviour
    {
        [SerializeField] private Transform _point;
        private IWorldToCellPosConverter _converter;
        private Grid<Node> _grid;

        [Inject]
        public void Construct(IWorldToCellPosConverter converter,  Grid<Node> grid)
        {
            _converter = converter;
            _grid = grid;
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2Int cellPos = _converter.WorldToCell(mousePos);
                var node = _grid.Nodes[cellPos.y, cellPos.x];
                _point.position =  node.Position;
            }
        }
    }
}