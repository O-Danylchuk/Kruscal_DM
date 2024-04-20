using System;
using System.Collections.Generic;
using graph.Edges;
using Graphs;

namespace Graph
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            UnweightedGraph graph = new UnweightedGraph(5);
            WeightedGraph graph1 = new WeightedGraph(5);
            graph1.AddEdge(1, 2, 3);
            graph.AddEdge(1, 2);
            graph1.PrintAdjacencyList();
        }
    }
}