using System;
using System.Collections.Generic;
using graph.BasicGraphs;


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
        public override void RemoveVertex(int vertex)
        {
            int vertices = adjacencyMatrix.GetLength(0) - 1;
            int[,] newMatrix = new int[vertices, vertices];

            int newRow = 0, newCol = 0;
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                if (i != vertex)
                {
                    newCol = 0;
                    for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                    {
                        if (j != vertex)
                        {
                            newMatrix[newRow, newCol] = adjacencyMatrix[i, j];
                            newCol++;
                        }
                    }
                    newRow++;
                }
            }

            adjacencyMatrix = newMatrix;

            adjacencyList.RemoveAt(vertex);
            foreach (List<int> list in adjacencyList)
            {
                list.RemoveAll(adjacentVertex => adjacentVertex == vertex);
            }
        }
    }
}
