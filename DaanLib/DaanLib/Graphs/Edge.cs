using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Graphs {
    /// <summary>
    /// A vertex in a Graph System
    /// </summary>
    public class Edge {
        /// <summary>
        /// The destination of this Edge
        /// </summary>
        public Vertex destination;
        /// <summary>
        /// The cost of traversing this Edge
        /// </summary>
        public float cost;

        /// <summary>
        /// Instantiates a new Edge
        /// </summary>
        public Edge(Vertex dest) : this(dest, 1) { }

        /// <summary>
        /// Instantiates a new Edge
        /// </summary>
        public Edge(Vertex dest, float cost) {
            this.destination = dest;
            this.cost = cost;
        }
    }
}