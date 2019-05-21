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
        /// A dictionary of all the keys based on the verteces
        /// <para>This should only be used when the keys will always be unique</para>
        /// </summary>
        protected Dictionary<Vertex, TKey> keys = new Dictionary<Vertex, TKey>();

        /// <summary>
        /// Indicates whether the verteces will always be unique
        /// </summary>
        protected readonly bool hasUniqueVerteces;

        /// <summary>
        /// Instantiates a new Graph
        /// </summary>
        public Graph() : this(true) { }

        /// <summary>
        /// Instantiates a new Graph
        /// </summary>
        /// <param name="hasUniqueVerteces">Whether the verteces will be unique (default = true)</param>
        public Graph(bool hasUniqueVerteces = true) => this.hasUniqueVerteces = hasUniqueVerteces;

        /// <summary>
        /// A list of all verteces in the Graph
        /// </summary>
        public Vertex[] GetVertexArray() => verteces.Values.ToArray();

        public TKey[] GetKeyArray() => verteces.Keys.ToArray();

        /// <summary>
        /// Registeres a new Vertex from a Key
        /// </summary>
        /// <param name="key">The key of the vertex</param>
        /// <exception cref="ArgumentNullException">Throws an Argument Null Exception if the key given is null</exception>
        /// <returns>True if all goes well, false if the key already has a vertex</returns>
        public virtual bool RegisterVertex(TKey key) {
            // Null check
            if (key == null)
                throw new ArgumentNullException(string.Format("Key of type {0} was null", typeof(TKey)));

            // Check if we already have it, also check the keys dictionary if we have unique verteces
            if (verteces.ContainsKey(key) || (hasUniqueVerteces && keys.ContainsValue(key)))
                return false;

            // Add the key with a new vertex
            verteces.Add(key, new Vertex(key.ToString()));

            // If we have unique verteces, also add it to the keys dic
            if (hasUniqueVerteces)
                keys.Add(verteces[key], key);

            return true;
        }

        /// <summary>
        /// Replaces a vertex for a Key
        /// </summary>
        /// <param name="key">The key that should get a new Vertex</param>
        /// <exception cref="ArgumentNullException">Throws an Argument Null Exception if the key given is null</exception>
        /// <returns>True if all goes well, false if the key does not have a vertex</returns>
        public virtual bool ReplaceVertex(TKey key) {
            // null check
            if (key == null)
                throw new ArgumentNullException(string.Format("Key of type {0} was null", typeof(TKey)));

            // Check if the key exists, and if we have unique verteces, also check if we have it registered in the keys
            if (!verteces.ContainsKey(key) || (hasUniqueVerteces && !keys.ContainsValue(key)))
                return false;

            // If we have unique values, we will first remove it from there as the verteces we replace was the key
            if (hasUniqueVerteces)
                keys.Remove(verteces[key]);

            // Give the key a new vertex
            verteces[key] = new Vertex(key.ToString());

            // If we have unique values, re-add the vertex-key combination
            if (hasUniqueVerteces)
                keys.Add(verteces[key], key);

            return true;
        }

        /// <summary>
        /// Gets the vertex based on a key
        /// </summary>
        /// <param name="key">The key for the vertex</param>
        /// <exception cref="ArgumentNullException">Throws an Argument Null Exception if the key given is null</exception>
        /// <returns>The vertex of the key</returns>
        public virtual Vertex GetVertex(TKey key) {
            // Null check
            if (key == null)
                throw new ArgumentNullException(string.Format("Key of type {0} was null", typeof(TKey)));

            // Make sure the vertex exists
            if (!verteces.ContainsKey(key))
                return null;

            return verteces[key];
        }

        /// <summary>
        /// Gets the Key based on a Vertex
        /// <para>Warning! This can be quite slow in larger Graphs if the verteces aren't be unique!</para>
        /// </summary>
        /// <param name="v">The Vertex of the key</param>
        /// <exception cref="ArgumentNullException">Throws an exception if the argument is null</exception>
        /// <returns>The key of the Vertex</returns>
        public virtual TKey GetKey(Vertex v) {
            // null check
            if (v == null)
                throw new ArgumentNullException(string.Format("Key of type {0} was null", typeof(TKey)));

            // Make sure the vertex exists, and if we have unique values, make sure it contains a key
            if (!verteces.ContainsValue(v) || (hasUniqueVerteces && !keys.ContainsKey(v)))
                return default;

            // either return the key from the keys dictionary or form the verteces dictionary if the verteces aren't unique
            return hasUniqueVerteces ? keys[v] : verteces.FirstOrDefault(x => x.Value == v).Key;
        }

        /// <summary>
        /// Checks whether a key exists in the Graph
        /// </summary>
        /// <param name="key">The key to check for</param>
        /// <exception cref="ArgumentNullException">Throws an Argument Null Exception if the key given is null</exception>
        /// <returns>True if the key is registered</returns>
        public virtual bool ContainsKey(TKey key) {
            // Null check
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
            // Null check
            if (from == null || to == null)
                throw new ArgumentNullException(string.Format("Key of type {0} was null", typeof(TKey)));

            // Make sure both keys have a vertex
            if (!verteces.ContainsKey(from) || !verteces.ContainsKey(to))
                return false;

            // Create a new edge between the two verteces
            verteces[from].AddEdge(new Edge(verteces[to]));

            return true;
        }

        /// <summary>
        /// Registers an Edge between two Verteces
        /// </summary>
        /// <param name="from">The starting Vertex</param>
        /// <param name="to">The ending Vertex</param>
        /// <param name="cost">The cost of traveling through the Edge</param>
        /// <exception cref="ArgumentNullException">Throws an Argument Null Exception if either keys is null</exception>
        /// <returns>True if all goes well, false if either keys doesn't have a Vertex</returns>
        public virtual bool RegisterEdge(TKey from, TKey to, float cost) {
            // Null check
            if (from == null || to == null)
                throw new ArgumentNullException(string.Format("Key of type {0} was null", typeof(TKey)));

            // Make sure both keys have a vertex
            if (!verteces.ContainsKey(from) || !verteces.ContainsKey(to))
                return false;

            // Create a new edge between the two verteces
            verteces[from].AddEdge(new Edge(verteces[to], cost));

            return true;
        }

        /// <summary>
        /// Registers Edges between two Verteces both ways
        /// </summary>
        /// <param name="first">The first Vertex</param>
        /// <param name="second">The second Vertex</param>
        /// <returns>True if all goes well, false if either keys doesn't have a Vertex</returns>
        public virtual bool RegisterEdges(TKey first, TKey second) => RegisterEdge(first, second) && RegisterEdge(second, first);

        /// <summary>
        /// Registers edges between two Verteces both ways
        /// </summary>
        /// <param name="first">The first Vertex</param>
        /// <param name="second">The second Vertex</param>
        /// <param name="cost">The cost of traveling over the Edge</param>
        /// <returns>True if all goes well, false if either keys doesn't have a Vertex</returns>
        public virtual bool RegisterEdges(TKey first, TKey second, float cost) => RegisterEdge(first, second, cost) && RegisterEdge(second, first, cost);
    }
}
