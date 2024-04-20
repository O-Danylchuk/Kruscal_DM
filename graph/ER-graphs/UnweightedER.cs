using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs;

namespace ER_graphs
{
    internal class UnweightedER : UnweightedGraph
    {
        Random random = new Random();
        public int Vertices => adjacencyMatrix.GetLength(0);
        public UnweightedER(int vertices) : base(vertices)
        {
        }

        public static UnweightedER GenerateUnweightedERGraph(double edgeProbability, int size)
        {
            UnweightedER unwer = new UnweightedER(size);
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
                        unwer.AddEdge(i, j);
                    }
                }
            }
            return unwer;
        }
    }
}
