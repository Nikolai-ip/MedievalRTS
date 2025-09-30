using System;
using UnityEngine;

namespace _Game.Source.Infrastructure.DIInstallers
{
    [Serializable]
    public class GridParams
    {
        [SerializeField] private Vector2 _startPosition;
        [SerializeField] private int _rows;
        [SerializeField] private int _columns;
        [SerializeField] private Vector2 _cellSize;

        public Vector2 StartPosition => _startPosition;

        public int Rows => _rows;

        public int Columns => _columns;

        public Vector2 CellSize => _cellSize;
    }
}