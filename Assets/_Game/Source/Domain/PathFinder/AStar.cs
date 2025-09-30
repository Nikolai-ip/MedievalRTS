using System.Collections.Generic;
using _Game.Source.Domain.Grid;

namespace _Game.Source.Domain.PathFinder
{
  public class AStar
  {
        // public bool TryFindPath(Node startNode, Node endNode, out List<Node> path)
        // {
        //     var openList = new List<NodeAStarWrap>();
        //     var closedList = new List<NodeAStarWrap>();
        //     Dictionary<Node, NodeAStarWrap> wrapsAccum = new Dictionary<Node, NodeAStarWrap>();
        //     openList.Add(new NodeAStarWrap(startNode)
        //     {
        //         G = 0,
        //         H = GetHeuristicValue(startNode, endNode)
        //     });
        //     FindNodesPathSequence(openList, closedList, endNode, wrapsAccum);
        //     var endWrapNode = closedList.FirstOrDefault(nodeWrap => ReferenceEquals(nodeWrap.Node, endNode));
        //     if (endWrapNode == null)
        //     {
        //         path = new List<Node>();
        //         return false;
        //     }
        //     path = GetPath(startNode, endWrapNode);
        //     return true;
        // }
        // private float GetHeuristicValue(Node startNode, Node endNode)
        // {
        //     return Vector3.Distance(startNode.Position,  endNode.Position);
        // }
        // private void FindNodesPathSequence(List<NodeAStarWrap> openList,
        //     List<NodeAStarWrap> closedList, Node targetNode, Dictionary<Node, NodeAStarWrap> wrapsAccum)
        // {
        //     if (openList.Count == 0)
        //         return; 
        //     openList = openList.OrderBy(node => node.F).ToList();
        //     var current = openList.First(elem=> !elem.Node.IsBlocked);
        //     openList.Remove(current);
        //     closedList.Add(current);
        //     if (ReferenceEquals(current.Node, targetNode))
        //     {
        //         return;
        //     }
        //     AddNeighbors(current, closedList, wrapsAccum);
        //     foreach (var neighbor in current.Neighbors)
        //     {
        //         float g = current.G + Vector3.Distance(current.Node.Position, neighbor.Node.Position) + neighbor.Node.Cost;
        //         if (neighbor.G > g)
        //         {
        //             neighbor.G = g;
        //         }
        //         neighbor.H = Vector3.Distance(neighbor.Node.Position, targetNode.Position);
        //         if (!openList.Contains(neighbor))
        //         {
        //             openList.Add(neighbor);
        //             neighbor.Parent = current;
        //         }
        //     }
        //     FindNodesPathSequence(openList, closedList, targetNode, wrapsAccum);
        // }
        //
        //
        // private static void AddNeighbors(NodeAStarWrap nodeWrap, List<NodeAStarWrap> closedList,
        //     Dictionary<Node, NodeAStarWrap> wrapsAccum)
        // {
        //     foreach (var nodeNeighbor in nodeWrap.Node.Neighbors)
        //     {
        //         if (!wrapsAccum.TryGetValue(nodeNeighbor, out var neighborWrapNode))
        //         {
        //             if (nodeNeighbor.IsBlocked) continue;
        //             neighborWrapNode = new NodeAStarWrap(nodeNeighbor);
        //             wrapsAccum[nodeNeighbor] = neighborWrapNode;
        //         }
        //         if (closedList.Contains(neighborWrapNode))
        //         {
        //             continue;
        //         }
        //         if (nodeWrap.Parent != null && ReferenceEquals(nodeWrap.Parent, neighborWrapNode))
        //         {
        //             continue;
        //         }
        //         nodeWrap.Neighbors.Add(neighborWrapNode);
        //     }
        // }
        //
        //
        // private List<Node> GetPath(Node start, NodeAStarWrap endNode)
        // {
        //     var path = new List<Node>();
        //     var current = endNode;
        //     while (!ReferenceEquals(current.Node, start))
        //     {
        //         path.Add(current.Node);
        //         current = current.Parent;
        //     }
        //     path.Add(start);
        //     path.Reverse();
        //     return path;
        // }
        public class NodeAStarWrap
        {
            public Node Node { get; }
            public List<NodeAStarWrap> Neighbors { get; } = new List<NodeAStarWrap>();
            public float G { get; set; } = float.MaxValue;
            public float H { get; set; } = float.MaxValue;
            public double F => G + H;
            public NodeAStarWrap Parent { get; set; }

            public NodeAStarWrap(Node node)
            {
                Node = node;
            }

            public override bool Equals(object obj)
            {
                if (obj is NodeAStarWrap wrap)
                {
                    return wrap.Node.Equals(Node);
                }

                return false;
            }

            protected bool Equals(NodeAStarWrap other)
            {
                return Equals(Node, other.Node) && Equals(Neighbors, other.Neighbors) && G.Equals(other.G) && H.Equals(other.H);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = (Node != null ? Node.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }
    }
}