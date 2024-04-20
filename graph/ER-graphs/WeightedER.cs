using Graphs;
using graph.Edges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ER_graphs
{
    internal class WeightedER : WeightedGraph
    {
        const int MINWEIGHT = 1;
        const int MAXWEIGHT = 11;

        public int Vertices => adjacencyMatrix.GetLength(0);
        public WeightedER(int vertices) : base(vertices)
        {
        }

        public static WeightedER GenerateWeightedERGraph(double edgeProbability, int size)
        {
            WeightedER wer = new WeightedER(size);
            Random randomInstance = new Random();

            if (edgeProbability < 0 || edgeProbability > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(edgeProbability), "Edge probability must be between 0 and 1.");
            }

            for (int i = 0; i < size - 1; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    double random = randomInstance.NextDouble();
                    if (random <= edgeProbability)
                    {
                        int weight = randomInstance.Next(MINWEIGHT, MAXWEIGHT);
                        wer.AddEdge(i, j, weight);
                    }
                }
            }
            return wer;
        }
    }
}
