using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Graphs {
    /// <summary>
    /// A graph that stores Verteces
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Graph<T> {
        /// <summary>
        /// The maximum float value
        /// </summary>
        public static readonly float INFINITY = float.MaxValue;

        /// <summary>
        /// A dictionary of all the verteces based on a certain class type
        /// </summary>
        protected Dictionary<T, Vertex> verteces = new Dictionary<T, Vertex>();

        /// <summary>
        /// A list of all verteces in the Graph
        /// </summary>
        public Vertex[] GetvertexArray() => (Vertex[])verteces.Values.ToArray();

        /// <summary>
        /// Instantiates a new Graph
        /// </summary>
        public Graph() { }

        /// <summary>
        /// Registeres a new Vertex from a Key
        /// </summary>
        /// <param name="key">The key of the vertex</param>
        /// <exception cref="ArgumentNullException">Throws an Argument Null Exception if the key given is null</exception>
        /// <returns>True if all goes well, false if the key already has a vertex</returns>
        public virtual bool RegisterVertex(T key) {
            if (key == null)
                throw new ArgumentNullException(string.Format("Key of type {0} was null", typeof(T)));

            if (verteces.ContainsKey(key))
                return false;

            verteces.Add(key, new Vertex(key.ToString()));

            return true;
        }

        /// <summary>
        /// Replaces a vertex for a Key
        /// </summary>
        /// <param name="key">The key that should get a new Vertex</param>
        /// <exception cref="ArgumentNullException">Throws an Argument Null Exception if the key given is null</exception>
        /// <returns>True if all goes well, false if the key does not have a vertex</returns>
        public virtual bool ReplaceVertex(T key) {
            if (key == null)
                throw new ArgumentNullException(string.Format("Key of type {0} was null", typeof(T)));

            if (!verteces.ContainsKey(key))
                return false;

            verteces[key] = new Vertex(key.ToString());

            return true;
        }

        /// <summary>
        /// Registers an Edge between two Verteces
        /// </summary>
        /// <param name="from">The starting Vertex</param>
        /// <param name="to">The ending Vertex</param>
        /// <exception cref="ArgumentNullException">Throws an Argument Null Exception if either keys is null</exception>
        /// <returns>True if all goes well, false if either keys doesn't have a Vertex</returns>
        public bool RegisterEdge(T from, T to) {
            if (from == null || to == null)
                throw new ArgumentNullException(string.Format("Key of type {0} was null", typeof(T)));

            if (!verteces.ContainsKey(from) || !verteces.ContainsKey(to))
                return false;

            verteces[from].AddEdge(new Edge(verteces[to]));

            return true;
        }
    }
}
