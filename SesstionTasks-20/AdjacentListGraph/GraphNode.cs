using System.Collections.Generic;
namespace AdjacentListGraph
{
    // Node class for adjacency list representation
    public class GraphNode
    {
        public int Value { get; set; }
        public List<GraphNode> Neighbors { get; set; }

        public GraphNode(int value)
        {
            Value = value;
            Neighbors = new List<GraphNode>();
        }
    }
} 