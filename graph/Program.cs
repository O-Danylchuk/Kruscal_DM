using ER_graphs;
using System.Diagnostics;


namespace GraphExperiment
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] graphSizes = [20, 50, 100, 150, 200];

            double[] densities = [0.5, 0.6, 0.7, 0.8, 0.9, 1];

            foreach (int size in graphSizes)
            {
                foreach (double density in densities)
                {
                    // change it if your system runs code for a long time
                    int experimentsCount = 1000;

                    // Total time for group of graphs
                    TimeSpan totalExecutionTime = TimeSpan.Zero;

                    for (int i = 0; i < experimentsCount; i++)
                    {
                        // Generate Graph
                        WeightedER graph = WeightedER.GenerateWeightedERGraph(density, size);

                        // Get execution time of Kruskal alghoritm
                        Stopwatch stopwatch = new();
                        stopwatch.Start();
                        graph.Kruskal();
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