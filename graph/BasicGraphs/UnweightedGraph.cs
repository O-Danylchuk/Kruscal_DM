using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph.BasicGraph
{
    internal class UnweightedGraph
    {
        private int[,] adjacencyMatrix;
        private List<List<int>> adjacencyList;

        public UnweightedGraph(int vertices)
        {
            adjacencyMatrix = new int[vertices, vertices];
            adjacencyList = new List<List<int>>();
            for (int i = 0; i < vertices; i++)
            {
                adjacencyList.Add(new List<int>());
            }
        }

        public void AddEdge(int startVertex, int endVertex)
        {
            adjacencyList[startVertex].Add(endVertex);
            adjacencyList[endVertex].Add(startVertex);

            adjacencyMatrix[startVertex, endVertex] = 1;
            adjacencyMatrix[endVertex, startVertex] = 1;
        }
        public void RemoveEdge(int startVertex, int endVertex)
        {
            adjacencyList[startVertex].Remove(endVertex);
            adjacencyList[endVertex].Remove(startVertex);

            adjacencyMatrix[startVertex, endVertex] = 0;
            adjacencyMatrix[endVertex, startVertex] = 0;
        }

        public void AddVertex()
        {
            int vertices = adjacencyMatrix.GetLength(0) + 1;
            int[,] newMatrix = new int[vertices, vertices];
            Array.Copy(adjacencyMatrix, newMatrix, adjacencyMatrix.Length);
            adjacencyMatrix = newMatrix;

            adjacencyList.Add(new List<int>());
        }
        public void RemoveVertex(int vertex)
        {
            int vertices = adjacencyMatrix.GetLength(0) - 1;
            int[,] newMatrix = new int[vertices, vertices];

            int row = 0, col = 0;
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                if (i != vertex)
                {
                    for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                    {
                        if (j != vertex)
                        {
                            newMatrix[row, col] = adjacencyMatrix[i, j];
                            col++;
                        }
                    }
                }
            }
            adjacencyMatrix = newMatrix;

            adjacencyList.RemoveAt(vertex);
            foreach (List<int> list in adjacencyList)
            {
                list.Remove(vertex);
            }
        }
    }
}
