using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph.BasicGraph
{
    public abstract class BaseGraph<T>
    {
        protected int[,] adjacencyMatrix;
        protected List<List<T>> adjacencyList;
        public int Size => adjacencyMatrix.GetLength(0);

        protected BaseGraph(int vertices)
        {
            adjacencyMatrix = new int[vertices, vertices];
            adjacencyList = new List<List<T>>();
            for (int i = 0; i < vertices; i++)
            {
                adjacencyList.Add(new List<T>());
            }
        }

        public abstract void AddEdge(int startVertex, int endVertex, int weight = 1);
        public abstract void RemoveEdge(int startVertex, int endVertex);
        public abstract void AddVertex();

        // Method to print the adjacency matrix
        public void PrintAdjacencyMatrix()
        {
            Console.WriteLine("Adjacency Matrix:");
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    Console.Write(adjacencyMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

