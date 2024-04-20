using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph.Edges
{
    // idk if we need to use this, probably it does nothing but coplicates code
    internal class UnweightedEdge
    {
        public int Vertex { get; }

        public UnweightedEdge(int vertex)
        {
            Vertex = vertex;
        }
    }
}
