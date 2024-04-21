using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edges
{
    internal class WeightedEdge : IComparable<WeightedEdge>
    {
        public int StartVertex { get; }
        public int EndVertex { get; }
        public int Weight { get; }

        public WeightedEdge(int startVertex, int endVertex, int weight)
        {
            StartVertex = startVertex;
            EndVertex = endVertex;
            Weight = weight;
        }

        // compares edges by weight
        public int CompareTo(WeightedEdge other)
        {
            return this.Weight - other.Weight;
        }
        public override string ToString()
        {
            return $"(({StartVertex}, {EndVertex}), Weight: {Weight})";
        }
    }
}
