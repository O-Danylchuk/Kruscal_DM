using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph.BasicGraphs
{
    public abstract class BaseGraph<T>
    {
        protected int[,] adjacencyMatrix;
        protected List<List<T>> adjacencyList;

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
        public abstract void RemoveVertex(int vertex);

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

        // Method to print the adjacency list
        public void PrintAdjacencyList()
        {
            Console.WriteLine("Adjacency List:");
            for (int i = 0; i < adjacencyList.Count; i++)
            {
                Console.Write($"{i}: ");
                foreach (var item in adjacencyList[i])
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
        }
    }
}

