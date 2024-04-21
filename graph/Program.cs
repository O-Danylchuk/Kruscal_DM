using System;
using System.Collections.Generic;
using System.Threading.Channels;
using Edges;
using Graphs;
using ER_graphs;

namespace Graph
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WeightedGraph graph1 = new WeightedGraph(5);
            graph1.AddEdge(1, 2, 1);
            graph1.AddEdge(3, 4, 2);
            graph1.AddEdge(2, 3, 1);

            WeightedER randomW = WeightedER.GenerateWeightedERGraph(0.3, 5);
            graph1.PrintAdjacencyList();
            graph1.PrintAdjacencyMatrix();

            //UnweightedER randomU = UnweightedER.GenerateUnweightedERGraph(0.3, 5);
            //randomU.PrintAdjacencyList();
            //randomU.PrintAdjacencyMatrix();

            WeightedGraph wr = graph1.Kruskal();
            wr.PrintAdjacencyMatrix();
            wr.PrintAdjacencyList();
        }
    }
}