
using AdjacentListGraph;

AdjacencyList adjacencyList= new AdjacencyList(directed: false);
adjacencyList.AddNode(5);
adjacencyList.AddNode(2);
adjacencyList.AddNode(-1);
adjacencyList.AddEdge(5, 2);
adjacencyList.AddEdge(2, -1);
adjacencyList.AddEdge(-1, 5);

Console.WriteLine(adjacencyList.ToString());




