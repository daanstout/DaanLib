using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Graphs {
    /// <summary>
    /// A graph that stores Verteces
    /// </summary>
    /// <typeparam name="TKey">The type of the Key</typeparam>
    public class Graph<TKey> {
        /// <summary>
        /// The maximum float value
        /// </summary>
        public static readonly float INFINITY = float.MaxValue;

        /// <summary>
        /// A dictionary of all the verteces based on a certain class type
        /// </summary>
        protected Dictionary<TKey, Vertex> verteces = new Dictionary<TKey, Vertex>();

        /// <summary>
        /// Instantiates a new Graph
        /// </summary>
        public Graph() { }

        /// <summary>
        /// A list of all verteces in the Graph
        /// </summary>
        public Vertex[] GetVertexArray() => verteces.Values.ToArray();

        /// <summary>
        /// Registeres a new Vertex from a Key
        /// </summary>
        /// <param name="key">The key of the vertex</param>
        /// <exception cref="ArgumentNullException">Throws an Argument Null Exception if the key given is null</exception>
        /// <returns>True if all goes well, false if the key already has a vertex</returns>
        public virtual bool RegisterVertex(TKey key) {
            if (key == null)
                throw new ArgumentNullException(string.Format("Key of type {0} was null", typeof(TKey)));

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
        public virtual bool ReplaceVertex(TKey key) {
            if (key == null)
                throw new ArgumentNullException(string.Format("Key of type {0} was null", typeof(TKey)));

            if (!verteces.ContainsKey(key))
                return false;

            verteces[key] = new Vertex(key.ToString());

            return true;
        }

        /// <summary>
        /// Gets the vertex based on a key
        /// </summary>
        /// <param name="key">The key for the vertex</param>
        /// <exception cref="ArgumentNullException">Throws an Argument Null Exception if the key given is null</exception>
        /// <returns>The vertex of the key</returns>
        public virtual Vertex GetVertex(TKey key) {
            if(key == null)
                throw new ArgumentNullException(string.Format("Key of type {0} was null", typeof(TKey)));

            if (!verteces.ContainsKey(key))
                return null;

            return verteces[key];
        }

        /// <summary>
        /// Gets the Key based on a Vertex
        /// <para>Warning! This can be quite slow in larger Graphs!</para>
        /// </summary>
        /// <param name="v">The Vertex of the key</param>
        /// <returns>The key of the Vertex</returns>
        public virtual TKey GetKey(Vertex v) {
            if(v == null)
                throw new ArgumentNullException(string.Format("Key of type {0} was null", typeof(TKey)));

            if (!verteces.ContainsValue(v))
                return default;

            return verteces.FirstOrDefault(x => x.Value == v).Key;
        }

        /// <summary>
        /// Checks whether a key exists in the Graph
        /// </summary>
        /// <param name="key">The key to check for</param>
        /// <exception cref="ArgumentNullException">Throws an Argument Null Exception if the key given is null</exception>
        /// <returns>True if the key is registered</returns>
        public virtual bool ContainsKey(TKey key) {
            if (key == null)
                throw new ArgumentNullException(string.Format("Key of type {0} was null", typeof(TKey)));

            return verteces.ContainsKey(key);
        }

        /// <summary>
        /// Registers an Edge between two Verteces
        /// </summary>
        /// <param name="from">The starting Vertex</param>
        /// <param name="to">The ending Vertex</param>
        /// <exception cref="ArgumentNullException">Throws an Argument Null Exception if either keys is null</exception>
        /// <returns>True if all goes well, false if either keys doesn't have a Vertex</returns>
        public virtual bool RegisterEdge(TKey from, TKey to) {
            if (from == null || to == null)
                throw new ArgumentNullException(string.Format("Key of type {0} was null", typeof(TKey)));

            if (!verteces.ContainsKey(from) || !verteces.ContainsKey(to))
                return false;

            verteces[from].AddEdge(new Edge(verteces[to]));

            return true;
        }
    }
}
