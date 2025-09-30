using System.Collections.Generic;
using _Game.Source.Domain.Grid;

namespace _Game.Source.Domain.PathFinder
{
    public interface IPathFinder
    {
        bool TryFindPath(Node startNode, Node endNode, out List<Node> path);
    }
}