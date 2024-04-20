using System;
using System.Collections.Generic;
using System.Threading.Channels;
using graph.Edges;
using Graphs;
using ER_graphs;

namespace Graph
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            UnweightedGraph graph0 = new UnweightedGraph(5);
            WeightedGraph graph1 = new WeightedGraph(5);

            WeightedER randomW = WeightedER.GenerateWeightedERGraph(0.3, 5);
            randomW.PrintAdjacencyList();
            randomW.PrintAdjacencyMatrix();

            UnweightedER randomU = UnweightedER.GenerateUnweightedERGraph(0.3, 5);
            randomU.PrintAdjacencyList();
            randomU.PrintAdjacencyMatrix();
        }
    }
}