using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph.Edges
{
    internal class WeightedEdge
    {
        public int Vertex { get; }
        public int Weight { get; }

        public WeightedEdge(int vertex, int weight)
        {
            Vertex = vertex;
            Weight = weight;
        }
    }
}
