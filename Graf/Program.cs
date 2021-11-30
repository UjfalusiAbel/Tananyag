using System;

namespace Graf
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(5);
            graph.AddEdge(0,1);
            graph.AddEdge(0,4);
            graph.AddEdge(2,3);
            graph.AddEdge(1,3);
            graph.DepthFirstSearch(4,3);
            graph.BreadFirstSearch(4,3);
        }
    }
}
