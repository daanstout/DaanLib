using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib {
    /// <summary>
    /// Allows the user to pair two values together
    /// </summary>
    /// <typeparam name="T">The type of the first value</typeparam>
    /// <typeparam name="U">The type of the second value</typeparam>
    public class Pair<T, U> {
        /// <summary>
        /// The first value
        /// </summary>
        public T first;
        /// <summary>
        /// The second value
        /// </summary>
        public U second;

        /// <summary>
        /// Creates a pair
        /// </summary>
        /// <param name="first">The first value</param>
        /// <param name="second">The second value</param>
        public Pair(T first, U second) {
            this.first = first;
            this.second = second;
        }

        /// <summary>
        /// Deconstructs a pair
        /// </summary>
        /// <param name="first">The first value</param>
        /// <param name="second">The second value</param>
        public void Deconstruct(out T first, out U second) {
            first = this.first;
            second = this.second;
        }
    }
}
