# Kruskal Algorithm for Minimum Spanning Tree

This repository contains an implementation of Kruskal's algorithm for finding the Minimum Spanning Tree (MST) of a weighted undirected graph in C#.

## Introduction

Kruskal's algorithm is a greedy algorithm used to find the MST of a graph. It works on weighted undirected graphs by selecting edges in increasing order of weight and adding them to the MST if they do not form a cycle.

## Implementation

The implementation in this repository is written in C# and works on weighted undirected graphs. It includes the following components:

- `WeightedGraph` class: Represents a weighted undirected graph.
- `WeightedEdge` class: Represents an edge between two vertices, including its weight.
- `KruskalAlgorithm` class: Contains the implementation of Kruskal's algorithm to find the MST of a graph.

## Usage

To use the implementation:

1. Clone or download this repository to your local machine.
2. Open the solution in Visual Studio or your preferred C# IDE.
3. Build the solution to ensure all dependencies are resolved.
4. Use the `WeightedGraph` class to find the MST of a graph by passing the graph as input.
5. Run program.cs file
