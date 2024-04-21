using System;
using System.Collections.Generic;
using System.Linq;
using Edges;
using graph.BasicGraph;
using disjointSet;
using System.Runtime.CompilerServices;

namespace Graphs
{
    internal class WeightedGraph : BaseGraph<WeightedEdge>
    {
        public WeightedGraph(int vertices) : base(vertices)
        {
        }

        public override void AddEdge(int startVertex, int endVertex, int weight)
        {
            if (startVertex < 0 || startVertex >= adjacencyList.Count ||
                endVertex < 0 || endVertex >= adjacencyList.Count)
            {
                throw new ArgumentOutOfRangeException("Vertices are out of range.");
            }

            WeightedEdge newEdge = new WeightedEdge(startVertex, endVertex, weight);
            adjacencyList[startVertex].Add(newEdge);
            adjacencyList[endVertex].Add(newEdge);

            adjacencyMatrix[startVertex, endVertex] = weight;
            adjacencyMatrix[endVertex, startVertex] = weight;
        }


        public override void RemoveEdge(int startVertex, int endVertex)
        {
            WeightedEdge edgeToRemove = adjacencyList[startVertex].Find(edge => edge.EndVertex == endVertex);
            adjacencyList[startVertex].Remove(edgeToRemove);
            adjacencyList[endVertex].Remove(edgeToRemove);

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
                foreach (var edge in adjacencyList[i])
                {
                    Console.Write(edge.ToString() + " ");
                }
                Console.WriteLine(); // Move to a new line after printing all edges for a vertex
            }
        }

        public WeightedGraph Kruskal()
        {
            //sort edges
            List<WeightedEdge> sortedEdges = GetSortedEdges();

            // Initialize a list to store the resulting MST
            List<WeightedEdge> minimumSpanningTree = new List<WeightedEdge>();

            // Create a disjoint set to track connected components
            DisjointSet disjointSet = new DisjointSet(adjacencyList.Count);

            // Step 2: Pick the smallest edge and check if it forms a cycle
            foreach (WeightedEdge edge in sortedEdges)
            {
                int root1 = disjointSet.Find(edge.StartVertex);
                int root2 = disjointSet.Find(edge.EndVertex);

                // If including the edge doesn't form a cycle, add it to the MST
                if (root1 != root2)
                {
                    minimumSpanningTree.Add(edge);
                    disjointSet.Union(root1, root2);
                }

                // If the number of edges in MST equals (V-1), exit the loop
                if (minimumSpanningTree.Count == adjacencyList.Count - 1)
                    break;
            }
            // Create a new graph object for the minimum spanning tree
            WeightedGraph MSTgraph = new WeightedGraph(adjacencyList.Count); // Initialize new graph with the same number of vertices as the original graph
            Dictionary<int, int> vertexMapping = new Dictionary<int, int>(); // Map old vertex indices to new ones

            // Add each edge from the minimumSpanningTree list to the new graph
            int newVertexIndex = 0;
            foreach (var edge in minimumSpanningTree)
            {
                // Add new vertex mappings for start and end vertices if they don't exist
                if (!vertexMapping.ContainsKey(edge.StartVertex))
                {
                    vertexMapping[edge.StartVertex] = newVertexIndex;
                    newVertexIndex++;
                }
                if (!vertexMapping.ContainsKey(edge.EndVertex))
                {
                    vertexMapping[edge.EndVertex] = newVertexIndex;
                    newVertexIndex++;
                }

                // Add edge to the new graph using the new vertex indices
                int newStartVertex = vertexMapping[edge.StartVertex];
                int newEndVertex = vertexMapping[edge.EndVertex];
                MSTgraph.AddEdge(newStartVertex, newEndVertex, edge.Weight);
            }

            return MSTgraph;

        }

        private List<WeightedEdge> GetSortedEdges()
        {
            List<WeightedEdge> allEdges = new List<WeightedEdge>();

            // Iterate through the adjacency list and add edges to the list
            for (int i = 0; i < adjacencyList.Count; i++)
            {
                foreach (var edge in adjacencyList[i])
                {
                    // To avoid duplicates, only add edges where the start vertex is less than the end vertex
                    if (i < edge.EndVertex)
                    {
                        allEdges.Add(new WeightedEdge(i, edge.EndVertex, edge.Weight));
                    }
                }
            }

            // Sort the list of edges based on their weight
            allEdges.Sort((e1, e2) => e1.Weight.CompareTo(e2.Weight));

            return allEdges;
        }
    }
}
