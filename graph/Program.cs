using System;
using System.Collections.Generic;
using System.Threading.Channels;
using Edges;
using Graphs;
using ER_graphs;
using System.Diagnostics;

namespace GraphExperiment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Розміри графів для експерименту (від 20 до 200 вершин)
            int[] graphSizes = { 20, 50, 100, 150, 200 };

            // Щільність графу (кількість ребер у відсотках)
            double[] densities = { 0.5, 0.6, 0.7, 0.8, 0.9, 1 };

            foreach (int size in graphSizes)
            {
                foreach (double density in densities)
                {
                    // Кількість експериментів для кожної пари "розмір, щільність"
                    int experimentsCount = 1000;

                    // Total 
                    TimeSpan totalExecutionTime = TimeSpan.Zero;

                    for (int i = 0; i < experimentsCount; i++)
                    {
                        // Генеруємо граф з вказаним розміром та щільністю
                        WeightedER graph = WeightedER.GenerateWeightedERGraph(density, size);

                        // Вимірюємо час виконання алгоритму Крускала
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        WeightedGraph MST = graph.Kruskal();
                        stopwatch.Stop();
                        totalExecutionTime += stopwatch.Elapsed;
                    }

                    TimeSpan averageExecutionTime = TimeSpan.FromTicks(totalExecutionTime.Ticks / experimentsCount);

                    Console.WriteLine($"Graph size: {size}, Density: {density}, AVG timespan: {averageExecutionTime}, total timespan: {totalExecutionTime}");
                }
            }
        }
    }
}