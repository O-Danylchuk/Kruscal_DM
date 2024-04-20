using System;
using System.Collections.Generic;

namespace Graph
{
    public abstract class Graph
    {
        private int[,] adjacencyMatrix;
        private List<List<int>> adjacencyList;

        public Graph(int vertices)
        {
            adjacencyMatrix = new int[vertices, vertices];
            adjacencyList = new List<List<int>>();
            for (int i = 0; i < vertices; i++)
            {
                adjacencyList.Add(new List<int>());
            }
        }

        public abstract void AddEdge(int startVertex, int endVertex);
        public abstract void RemoveEdge(int startVertex, int endVertex);

        public abstract void AddVertex();
        public abstract void RemoveVertex();

    }
}