using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Maths {
    /// <summary>
    /// A Matrix with variable size
    /// </summary>
    public sealed class Matrix {
        #region Variables
        /// <summary>
        /// The matrix
        /// </summary>
        private float[,] matrix;

        /// <summary>
        /// The number of columns in the Matrix
        /// </summary>
        public int columns { get; internal set; }
        /// <summary>
        /// The number of rows in the Matrix
        /// </summary>
        public int rows { get; internal set; }

        /// <summary>
        /// The size of the matrix
        /// </summary>
        public Vector2D size => new Vector2D(columns, rows);

        /// <summary>
        /// Gets or sets the value at specified coordinates
        /// </summary>
        /// <param name="column">The column of the matrix</param>
        /// <param name="row">The row of the matrix</param>
        /// <returns>The value stored at the specified location</returns>
        public float this[int column, int row] {
            get {
                if (column < 0 || row < 0 || column >= columns || row >= rows)
                    throw new ArgumentOutOfRangeException();

                return matrix[column, row];
            }
            set {
                if (column < 0 || row < 0 || column >= columns || row >= rows)
                    throw new ArgumentOutOfRangeException();

                matrix[column, row] = value;
            }
        }
        #endregion
        #region Constructors
        /// <summary>
        /// Instantiates a new Matrix as 2 by 2 identity matrix
        /// </summary>
        public Matrix() {
            matrix = Identity().matrix;
            rows = columns = 2;
        }

        /// <summary>
        /// Instantiates a new Matrix based on a Vector2D
        /// </summary>
        /// <param name="v">The vector to store in the Matrix</param>
        public Matrix(Vector2D v) {
            matrix = new float[2, 2];

            columns = 2;
            rows = 2;

            matrix[0, 0] = v.x;
            matrix[1, 0] = v.y;
        }

        /// <summary>
        /// Instantiates a new Matrix based on a Vector3d
        /// </summary>
        /// <param name="v"></param>
        public Matrix(Vector3D v) {
            matrix = new float[3, 3];

            columns = 3;
            rows = 3;

            matrix[0, 0] = v.x;
            matrix[1, 0] = v.y;
            matrix[2, 0] = v.z;
        }

        /// <summary>
        /// Instantiates a Matrix based on a certain number of rows and columns
        /// </summary>
        /// <param name="rows">The number of rows in the Matrix</param>
        /// <param name="columns">The number of columns in the Matrix</param>
        public Matrix(int rows, int columns) {
            matrix = new float[rows, columns];

            this.rows = rows;
            this.columns = columns;
        }
        #endregion
        #region Operator Overloads
        /// <summary>
        /// Adds two Matrices together
        /// </summary>
        /// <param name="a">Matrix a</param>
        /// <param name="b">Matrix b</param>
        /// <returns>The resulting Matrix</returns>
        public static Matrix operator +(Matrix a, Matrix b) {
            if (a.columns != b.columns && a.rows != b.rows)
                return null;

            Matrix m = new Matrix(a.rows, b.columns);
            for (int x = 0; x < m.rows; x++)
                for (int y = 0; y < m.columns; y++)
                    m[x, y] = a[x, y] + b[x, y];

            return m;
        }

        /// <summary>
        /// Subtracts two Matrices from one another
        /// </summary>
        /// <param name="a">The starting Matrix</param>
        /// <param name="b">The Matrix to subtract</param>
        /// <returns>The resulting Matrix</returns>
        public static Matrix operator -(Matrix a, Matrix b) {
            if (a.columns != b.columns && a.rows != b.columns)
                return null;

            Matrix m = new Matrix(a.rows, b.columns);
            for (int x = 0; x < m.rows; x++)
                for (int y = 0; y < m.columns; y++)
                    m[x, y] = a[x, y] - b[x, y];

            return m;
        }

        /// <summary>
        /// Multiplies a Matrix by a value
        /// </summary>
        /// <param name="a">The starting Matrix</param>
        /// <param name="b">The value to multiply by</param>
        /// <returns>The resulting Matrix</returns>
        public static Matrix operator *(Matrix a, float b) {
            Matrix m = new Matrix(a.rows, a.columns);
            for (int x = 0; x < m.rows; x++)
                for (int y = 0; y < m.columns; y++)
                    m[x, y] = a[x, y] * b;

            return m;
        }

        /// <summary>
        /// Multiplies a Matrix by a value
        /// </summary>
        /// <param name="a">The value to multiply by</param>
        /// <param name="b">The starting Matrix</param>
        /// <returns>The resulting Matrix</returns>
        public static Matrix operator *(float b, Matrix a) {
            Matrix m = new Matrix(a.rows, a.columns);
            for (int x = 0; x < m.rows; x++)
                for (int y = 0; y < m.columns; y++)
                    m[x, y] = a[x, y] * b;

            return m;
        }

        /// <summary>
        /// Multiplies a Matrix with a 2D Vector
        /// </summary>
        /// <param name="a">The Matrix to multiply with</param>
        /// <param name="v">The Vector to multiply</param>
        /// <returns>The resulting Vector2D</returns>
        public static Vector2D operator *(Matrix a, Vector2D v) {
            float x, y;

            x = (a[0, 0] * v.x) + (a[0, 1] * v.y);
            y = (a[1, 0] * v.x) + (a[1, 1] * v.y);

            return new Vector2D(x, y);
        }

        public static Vector3D operator *(Matrix a, Vector3D v) {
            float x, y, z;

            x = (a[0, 0] * v.x) + (a[0, 1] * v.y) + (a[0, 2] * v.z);
            y = (a[1, 0] * v.x) + (a[1, 1] * v.y) + (a[1, 2] * v.z);
            z = (a[2, 0] * v.x) + (a[2, 1] * v.y) + (a[2, 2] * v.z);

            return new Vector3D(x, y, z);
        }

        /// <summary>
        /// Multiplies two Matrices together
        /// </summary>
        /// <param name="a">The first Matrix</param>
        /// <param name="b">The second Matrix</param>
        /// <returns>The resulting Matrix</returns>
        public static Matrix operator *(Matrix a, Matrix b) {
            if (a.columns != b.rows)
                return null;

            Matrix m = new Matrix(a.rows, b.columns);

            for (int x = 0; x < m.rows; x++)
                for (int y = 0; y < m.columns; y++)
                    for (int k = 0; k < a.columns; k++)
                        m[x, y] += a[x, k] * b[k, y];

            return m;
        }
        #endregion
        #region Static Functions
        /// <summary>
        /// Creates a 2 by 2 Matrix where the value is 1 if x == y
        /// </summary>
        /// <returns>A 2 by 2 Matrix</returns>
        public static Matrix Identity() {
            Matrix m = new Matrix(2, 2);

            m[0, 0] = 1;
            m[1, 1] = 1;

            return m;
        }

        /// <summary>
        /// Creates an identity Matrix with the specified size, where the value is 1 if x == y
        /// </summary>
        /// <param name="size">The size of the matrix, both for the rows and columns</param>
        /// <returns>The Matrix</returns>
        public static Matrix Identity(int size) {
            Matrix m = new Matrix(size, size);

            for (int i = 0; i < size; i++)
                m[i, i] = 1;

            return m;
        }
        #endregion
        #region Functions
        /// <summary>
        /// Transforms a Vector2D through this Matrix
        /// </summary>
        /// <param name="point">The Vector2D to transform</param>
        /// <returns>The transformed Vector2D</returns>
        public Vector2D TransformVector2D(Vector2D point) => this * point;

        public Vector3D TransformVector3D(Vector3D point) => this * point;

        /// <summary>
        /// Translates this Matrix through a Vector2D
        /// </summary>
        /// <param name="v">The vector2D to translate from</param>
        public void Translate(Vector2D v) {
            Matrix m = Identity(3);
            m[2, 0] = v.x;
            m[2, 1] = v.y;

            matrix = (this * m).matrix;
            rows = columns = 3;
        }

        public void Translate(Vector3D v) {
            Matrix m = Identity(4);
            m[3, 0] = v.x;
            m[3, 1] = v.y;
            m[3, 2] = v.z;

            matrix = (this * m).matrix;
            rows = columns = 4;
        }

        /// <summary>
        /// Scales this Matrix based on a Vector2D
        /// </summary>
        /// <param name="v">The Vector2D to scale with</param>
        public void Scale(Vector2D v) {
            Matrix m = Identity(3);
            m[0, 0] = v.x;
            m[1, 1] = v.y;

            matrix = (this * m).matrix;
            rows = columns = 3;
        }

        public void Scale(Vector3D v) {
            Matrix m = Identity(4);
            m[0, 0] = v.x;
            m[1, 1] = v.y;
            m[2, 2] = v.z;

            matrix = (this * m).matrix;
            rows = columns = 4;
        }

        /// <summary>
        /// Rotates the Matrix around a certain rotation
        /// </summary>
        /// <param name="rotation">the number to rotate with</param>
        public void Rotate(float rotation) {
            Matrix m = Identity(3);

            float sin = (float)Math.Sin(rotation);
            float cos = (float)Math.Cos(rotation);

            m[0, 0] = cos;
            m[0, 1] = sin;
            m[1, 0] = -sin;
            m[1, 1] = cos;

            matrix = (this * m).matrix;
            rows = columns = 3;
        }

        /// <summary>
        /// Creates a string representation of the Matrix
        /// </summary>
        /// <returns>The Matrix as a string</returns>
        public override string ToString() {
            string s = "";

            for (int x = 0; x < columns; x++) {
                s += "[ ";

                for (int y = 0; y < rows; y++)
                    s += $"{matrix[x, y]}, ";

                s += "]\n";
            }

            return s;
        }
        #endregion
    }
}
