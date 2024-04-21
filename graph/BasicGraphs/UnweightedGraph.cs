using System;
using System.Collections.Generic;
using graph.BasicGraph;


namespace Graphs
{
    internal class UnweightedGraph : BaseGraph<int>
    {
        public UnweightedGraph(int vertices) : base(vertices)
        {
        }

        public override void AddEdge(int startVertex, int endVertex, int weight = 1)
        {
            adjacencyList[startVertex].Add(endVertex);
            adjacencyList[endVertex].Add(startVertex);

            adjacencyMatrix[startVertex, endVertex] = 1;
            adjacencyMatrix[endVertex, startVertex] = 1;
        }
        public override void RemoveEdge(int startVertex, int endVertex)
        {
            adjacencyList[startVertex].Remove(endVertex);
            adjacencyList[endVertex].Remove(startVertex);

            adjacencyMatrix[startVertex, endVertex] = 0;
            adjacencyMatrix[endVertex, startVertex] = 0;
        }

        public override void AddVertex()
        {
            int vertices = adjacencyMatrix.GetLength(0) + 1;
            int[,] newMatrix = new int[vertices, vertices];

            Array.Copy(adjacencyMatrix, newMatrix, adjacencyMatrix.Length);
            adjacencyMatrix = newMatrix;

            adjacencyList.Add(new List<int>());
        }

        public void PrintAdjacencyList()
        {
            Console.WriteLine("Adjacency List:");
            for (int i = 0; i < adjacencyList.Count; i++)
            {
                Console.Write($"{i}: ");
                foreach (var item in adjacencyList[i])
                {
                    Console.Write($"{item}, ");
                }
                Console.WriteLine();
            }
        }
    }
}
