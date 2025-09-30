using UnityEngine;

namespace _Game.Source.Domain.Grid
{
    public class Node
    {
        public Vector2 Position { get; }

        public Node(Vector2 position)
        {
            Position = position;
        }

        public bool IsBlocked { get; set; }
        
        public override bool Equals(object obj)
        {
            if (obj is Node node)
            {
                return Position.Equals(node.Position);
            }
            return false;
        }
        public override int GetHashCode()
        {
            var hashCode = Position.GetHashCode();
            return hashCode;
        }
    }
}