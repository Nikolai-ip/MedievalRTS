using System;
using UnityEngine;

namespace _Game.Source.Infrastructure.Input
{
    public interface IInputService
    {
        public Vector2 MousePosition { get; }
        event Action OnLeftMouseButtonClicked;
        bool IsPointerOverUI();
    }
}