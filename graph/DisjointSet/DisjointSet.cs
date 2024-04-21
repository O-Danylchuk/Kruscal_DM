using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disjointSet
{
    public class DisjointSet
    {
        private int[] parent;
        private int[] rank;

        public DisjointSet(int size)
        {
            parent = new int[size];
            rank = new int[size];

            // Initialize each element as its own parent and with rank 0
            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        // Find the root of the set containing element x
        public int Find(int x)
        {
            // If x is not the parent of itself, then x is not the root
            if (parent[x] != x)
            {
                // Recursively find the root of x's parent and set x's parent to the root
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }

        // Union the sets containing elements x and y
        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            // If x and y are already in the same set, do nothing
            if (rootX == rootY)
                return;

            // Merge the smaller rank tree into the larger rank tree
            if (rank[rootX] < rank[rootY])
            {
                parent[rootX] = rootY;
            }
            else if (rank[rootX] > rank[rootY])
            {
                parent[rootY] = rootX;
            }
            else
            {
                parent[rootY] = rootX;
                rank[rootX]++;
            }
        }
    }

}
