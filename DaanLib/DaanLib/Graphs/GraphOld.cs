using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Graphs {
    /// <summary>
    /// A class that is used to manage Verteces
    /// </summary>
    public class GraphOld {
        /// <summary>
        /// A list of all the verteces present
        /// </summary>
        private Dictionary<int, Vertex> verteces = new Dictionary<int, Vertex>();

        /// <summary>
        /// Adds an Edge from a vertex to another vertex
        /// </summary>
        public static bool AddEdgeTo(Vertex from, Vertex to) => AddEdgeTo(from, to, 1);

        public static bool AddEdgeTo(Vertex from, Vertex to, float cost) {
            if (from == null || to == null)
                return false;

            return from.AddEdge(new Edge(to, cost));
        }

        public bool AddEdgeTo(int from, int to) {
            try {
                return AddEdgeTo(from, to, 1);
            } catch {
                throw;
            }
        }

        public bool AddEdgeTo(int from, int to, float cost) {
            try {
                verteces.TryGetValue(from, out Vertex a);
                verteces.TryGetValue(to, out Vertex b);

                return AddEdgeTo(a, b, cost);
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Adds an Edge between two verteces
        /// </summary>
        public static bool AddEdgeBetween(Vertex a, Vertex b) {
            // If either Verteces is null, return false
            if (a == null || b == null)
                return false;

            // Add an edge to Vertex a, if we can't, return false, if we can, continue
            if (!a.AddEdge(new Edge(b, 1)))
                return false;

            // Add an edge to vertex b and return that value as our own
            return b.AddEdge(new Edge(a, 1));
        }

    }
}