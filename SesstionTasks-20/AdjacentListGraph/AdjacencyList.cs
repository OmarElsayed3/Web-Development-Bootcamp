
using System.Text;

namespace AdjacentListGraph
{
    public class AdjacencyList
    {
        private Dictionary<int, List<int>> adjList;
        private bool directed;

        public AdjacencyList(bool directed = false)
        {
            this.directed = directed;
            adjList = new Dictionary<int, List<int>>();
        }

        public void AddNode(int value)
        {
            if (!adjList.ContainsKey(value))
                adjList[value] = new List<int>();
        }

        public void AddEdge(int from, int to)
        {
            adjList[from].Add(to);
            if (!directed)
                adjList[to].Add(from);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var kvp in adjList)
            {
                sb.AppendLine($"{kvp.Key} --> [{string.Join(", ", kvp.Value)}]");
            }
            return sb.ToString();
        }

    }
}