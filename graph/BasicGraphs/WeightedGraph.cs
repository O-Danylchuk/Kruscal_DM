using System;
using System.Collections.Generic;
using System.Linq;
using graph.Edges;
using graph.BasicGraphs;

namespace Graphs
{
    internal class WeightedGraph : BaseGraph<WeightedEdge>
    {
        public WeightedGraph(int vertices) : base(vertices)
        {
        }

        public override void AddEdge(int startVertex, int endVertex, int weight = 1)
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

        public override void RemoveVertex(int vertex)
        {
            int vertices = adjacencyMatrix.GetLength(0) - 1;
            int[,] newMatrix = new int[vertices, vertices];

            int newRow = 0, newCol = 0;
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                if (i != vertex)
                {
                    newCol = 0; // Reset column for each row
                    for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                    {
                        if (j != vertex)
                        {
                            newMatrix[newRow, newCol] = adjacencyMatrix[i, j];
                            newCol++;
                        }
                    }
                    newRow++; // Move to the next row in the new matrix
                }
            }

            adjacencyMatrix = newMatrix;

            // Remove the vertex from adjacencyList and remove all incident edges
            adjacencyList.RemoveAt(vertex);
            foreach (List<WeightedEdge> list in adjacencyList)
            {
                list.RemoveAll(edge => edge.Vertex == vertex);
            }
        }
    }
}
