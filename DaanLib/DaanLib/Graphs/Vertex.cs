using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Graphs {
    /// <summary>
    /// A vertex in a Graph System
    /// </summary>
    public sealed class Vertex : IEquatable<Vertex> {
        /// <summary>
        /// Sets the ID of this vertex
        /// </summary>
        private static readonly IDSetter idSetter = new IDSetter();

        /// <summary>
        /// The unique ID of this vertex
        /// </summary>
        private readonly int ID;

        /// <summary>
        /// The name of this Vertex
        /// </summary>
        public string name;
        /// <summary>
        /// The list of adjacent Edges
        /// </summary>
        public List<Edge> edgeList;

        /// <summary>
        /// Instantiates a new Vertex
        /// </summary>
        public Vertex(string name) {
            ID = idSetter.getNextValidId;

            this.name = name;
            edgeList = new List<Edge>();
        }

        /// <summary>
        /// Adds an edge to this vertex
        /// </summary>
        /// <param name="edge">The edge to add</param>
        /// <returns>False if the edge points to this vertex, else true</returns>
        public bool AddEdge(Edge edge) {
            if (edge.destination == this)
                return false;

            edgeList.Add(edge);

            return true;
        }

        public override bool Equals(object obj) => Equals(obj as Vertex);
        public bool Equals(Vertex other) => other != null && ID == other.ID && name == other.name;

        public override int GetHashCode() {
            var hashCode = -712093626;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            return hashCode;
        }

        public static bool operator ==(Vertex left, Vertex right) => EqualityComparer<Vertex>.Default.Equals(left, right);
        public static bool operator !=(Vertex left, Vertex right) => !(left == right);
    }
}