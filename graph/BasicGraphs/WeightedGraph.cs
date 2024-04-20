using System;
using System.Collections.Generic;
using System.Linq;
using graph.Edges;
using graph.BasicGraph;

namespace Graphs
{
    internal class WeightedGraph : BaseGraph<WeightedEdge>
    {
        public WeightedGraph(int vertices) : base(vertices)
        {
        }

        public override void AddEdge(int startVertex, int endVertex, int weight)
        {
            adjacencyList[startVertex].Add(new WeightedEdge(endVertex, weight));
            adjacencyList[endVertex].Add(new WeightedEdge(startVertex, weight));

            adjacencyMatrix[startVertex, endVertex] = weight;
            adjacencyMatrix[endVertex, startVertex] = weight;
        }

        public override void RemoveEdge(int startVertex, int endVertex)
        {
            adjacencyList[startVertex].Remove(adjacencyList[startVertex].Find(edge => edge.Vertex == endVertex));
            adjacencyList[endVertex].Remove(adjacencyList[endVertex].Find(edge => edge.Vertex == startVertex));

            adjacencyMatrix[startVertex, endVertex] = 0;
            adjacencyMatrix[endVertex, startVertex] = 0;
        }

        public override void AddVertex()
        {
            int vertices = adjacencyMatrix.GetLength(0) + 1;
            int[,] newMatrix = new int[vertices, vertices];

            Array.Copy(adjacencyMatrix, newMatrix, adjacencyMatrix.Length);

            adjacencyMatrix = newMatrix;
            adjacencyList.Add(new List<WeightedEdge>());
        }

        public void PrintAdjacencyList()
        {
            Console.WriteLine("Adjacency List:");
            for (int i = 0; i < adjacencyList.Count; i++)
            {
                Console.Write($"{i}: ");
                foreach (var item in adjacencyList[i])
                {
                    Console.Write($"(Vertex: {item.Vertex}, Weight: {item.Weight}) ");
                }
                Console.WriteLine();
            }
        }
    }
}
