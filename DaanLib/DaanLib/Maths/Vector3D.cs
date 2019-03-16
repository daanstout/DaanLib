using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Maths {
    /// <summary>
    /// A 3D Vector with an x, a Y and a Z
    /// </summary>
    public struct Vector3D : IEquatable<Vector3D> {
        #region Variables
        /// <summary>
        /// The X value
        /// </summary>
        public float x;
        /// <summary>
        /// The Y value
        /// </summary>
        public float y;
        /// <summary>
        /// The z value
        /// </summary>
        public float z;

        /// <summary>
        /// A Vector3D that points up
        /// </summary>
        public static Vector3D up => new Vector3D(0, 1, 0);
        /// <summary>
        /// A Vector3D that points down
        /// </summary>
        public static Vector3D down => new Vector3D(0, -1, 0);
        /// <summary>
        /// A Vector3D that points left
        /// </summary>
        public static Vector3D left => new Vector3D(-1, 0, 0);
        /// <summary>
        /// A Vector3D that points right
        /// </summary>
        public static Vector3D right => new Vector3D(1, 0, 0);
        /// <summary>
        /// A Vector3D that points forward
        /// </summary>
        public static Vector3D forward => new Vector3D(0, 0, 1);
        /// <summary>
        /// A Vector3D that points backwards
        /// </summary>
        public static Vector3D backward => new Vector3D(0, 0, -1);
        /// <summary>
        /// A Zero-based Vector3D
        /// </summary>
        public static Vector3D zero => new Vector3D(0, 0, 0);
        #endregion
        #region Constructors
        //public Vector3D() => x = y = z = 0;

        /// <summary>
        /// Instantiates a new Vector3D based on a Vector2D
        /// </summary>
        /// <param name="vec">The Vector2D this Vector is based on</param>
        public Vector3D(Vector2D vec) {
            x = vec.x;
            y = vec.y;
            z = 0;
        }

        /// <summary>
        /// Instantiates a new Vector3D based on another Vector3D
        /// </summary>
        /// <param name="vec">The Vector3D to base this vector on</param>
        public Vector3D(Vector3D vec) {
            x = vec.x;
            y = vec.y;
            z = vec.z;
        }

        /// <summary>
        /// Instantiates a new Vector3D based on the string representation of a Vector3D.ToString()
        /// <para>If this constructor throws an error, that means the string is not a correct string</para>
        /// </summary>
        /// <param name="vec">The string representation of a Vector</param>
        public Vector3D(string vec) {
            try {
                string sub = vec.Substring(1, vec.Length - 2);
                string[] split = sub.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                if (split.Length >= 1)
                    x = (float)Convert.ToDouble(split[0]);
                else {
                    x = y = z = 0;
                    return;
                }

                if (split.Length >= 2)
                    y = (float)Convert.ToDouble(split[1]);
                else {
                    y = z = 0;
                    return;
                }

                if (split.Length >= 3)
                    z = (float)Convert.ToDouble(split[2]);
                else
                    z = 0;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Instantiates a new Vector3D with an X value
        /// </summary>
        /// <param name="x">The x value of the Vector3D</param>
        public Vector3D(float x) {
            this.x = x;
            y = z = 0;
        }

        /// <summary>
        /// Instantiates a new Vector3D with an X and a Y value
        /// </summary>
        /// <param name="x">The X value of the Vector3D</param>
        /// <param name="y">The Y value of the Vector3D</param>
        public Vector3D(float x, float y) {
            this.x = x;
            this.y = y;
            z = 0;
        }

        /// <summary>
        /// Instantiates a new Vector3D with an X, a Y and a Z value
        /// </summary>
        /// <param name="x">The X value of the Vector3D</param>
        /// <param name="y">The Y value of the Vector3D</param>
        /// <param name="z">The Z value of the Vector3D</param>
        public Vector3D(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        #endregion
        #region Operator Overloads
        public static Vector3D operator +(Vector3D v1, Vector3D v2) => new Vector3D(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        public static Vector3D operator +(Vector3D v1, Vector2D v2) => new Vector3D(v1.x + v2.x, v1.y + v2.y, v1.z);
        public static Vector3D operator +(Vector2D v1, Vector3D v2) => new Vector3D(v1.x + v2.x, v1.y + v2.y, v2.z);

        public static Vector3D operator -(Vector3D v1, Vector3D v2) => new Vector3D(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        public static Vector3D operator -(Vector3D v1, Vector2D v2) => new Vector3D(v1.x - v2.x, v1.y - v2.y, v1.z);
        public static Vector3D operator -(Vector2D v1, Vector3D v2) => new Vector3D(v1.x - v2.x, v1.y - v2.y, v2.z);

        public static Vector3D operator *(Vector3D v, float f) => new Vector3D(v.x * f, v.y * f, v.z * f);
        public static Vector3D operator *(Vector3D v, int i) => new Vector3D(v.x * i, v.y * i, v.z * i);
        public static Vector3D operator *(float f, Vector3D v) => new Vector3D(v.x * f, v.y * f, v.z * f);
        public static Vector3D operator *(int i, Vector3D v) => new Vector3D(v.x * i, v.y * i, v.z * i);
        public static Vector3D operator *(Vector3D v1, Vector3D v2) => new Vector3D(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);

        public static Vector3D operator /(Vector3D v, float f) => new Vector3D(v.x / f, v.y / f, v.z / f);
        public static Vector3D operator /(Vector3D v, int i) => new Vector3D(v.x / i, v.y / i, v.z / i);
        public static Vector3D operator /(float f, Vector3D v) => new Vector3D(v.x / f, v.y / f, v.z / f);
        public static Vector3D operator /(int i, Vector3D v) => new Vector3D(v.x / i, v.y / i, v.z / i);
        public static Vector3D operator /(Vector3D v1, Vector3D v2) => new Vector3D(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);

        public static Vector3D operator %(Vector3D v1, Vector3D v2) => new Vector3D(v1.x % v2.x, v1.y % v2.y, v1.z % v2.z);
        public static Vector3D operator %(Vector3D v, int i) => new Vector3D(v.x % i, v.y % i, v.z % i);

        public static bool operator ==(Vector3D v1, Vector3D v2) => v1.x == v2.x && v1.y == v2.y && v1.z == v2.z;
        public static bool operator !=(Vector3D v1, Vector3D v2) => v1.x != v2.z || v1.y != v2.y || v1.z != v2.z;
        #endregion
        #region Explicit Conversions
        public static explicit operator Vector3D(Vector2D v) => new Vector3D(v);
        #endregion
        #region Functions
        /// <summary>
        /// Sets all values to zero
        /// </summary>
        public void SetZero() => x = y = z = 0.0f;

        /// <summary>
        /// Checks if all values are zero
        /// </summary>
        /// <returns>True if all values are zero</returns>
        public bool IsZero() => x == 0 && y == 0 && z == 0;

        /// <summary>
        /// Gets the length of the Vector3D
        /// </summary>
        /// <returns>The length of the Vector3D</returns>
        public float Length() => (float)Math.Sqrt(x * x + y * y + z * z);

        /// <summary>
        /// Gets the unsquared length of the Vector3D
        /// </summary>
        /// <returns>The unsquared length of the Vector3D</returns>
        public float LengthSq() => x * x + y * y + z * z;

        /// <summary>
        /// Calculates this Vector's Dot product against another Vector3D
        /// </summary>
        /// <param name="other">The other Vector3D</param>
        /// <returns>The Dot product of the two Vector3Ds</returns>
        public float Dot(Vector3D other) => x * other.x + y * other.y + z * other.z;

        /// <summary>
        /// Gets the Vector that is perpendicular to this Vector on the X-axis
        /// <para>This is a WIP function and may not function correctly</para>
        /// </summary>
        /// <returns>A Vector that is perpendicular on the X-axis</returns>
        public Vector3D PerpX() => new Vector3D(x, -z, y);

        /// <summary>
        /// Gets the Vector that is perpendicular to this Vector on the Y-axis
        /// <para>This is a WIP function and may not function correctly</para>
        /// </summary>
        /// <returns>A Vector that is perpendicular on the Y-axis</returns>
        public Vector3D PerpY() => new Vector3D(-z, y, x);

        /// <summary>
        /// Gets the Vector that is perpendicular to this Vector on the Z-axis
        /// <para>This is a WIP function and may not function correctly</para>
        /// </summary>
        /// <returns>A Vector that is perpendicular on the Z-axis</returns>
        public Vector3D PerpZ() => new Vector3D(-y, x, z);

        /// <summary>
        /// Get the reverse of this Vector
        /// </summary>
        /// <returns>A reverse of this Vector</returns>
        public Vector3D GetReverse() => new Vector3D(-x, -y, -z);

        /// <summary>
        /// Gets the Manhattan distance to another Vector
        /// <para>The Manhattan distance is the ΔX + ΔY + ΔZ</para>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public float GetManhattan(Vector3D other) => Math.Abs(x - other.x) + Math.Abs(y - other.y) + Math.Abs(z - other.z);

        /// <summary>
        /// Normalizes this Vector
        /// </summary>
        public void Normalize() {
            float vectorLength = Length();
            this /= vectorLength;
            //x /= vectorLength;
            //y /= vectorLength;
            //z /= vectorLength;
        }

        /// <summary>
        /// Truncates the Vector to a max value
        /// </summary>
        /// <param name="max"></param>
        public void Truncate(float max) {
            if (Length() <= max)
                return;

            //if (Length() > max) {
            Normalize();

            this *= max;
            //x *= max;
            //y *= max;
            //z *= max;
            //}
        }

        /// <summary>
        /// Gets the distance to another Vector3D
        /// </summary>
        /// <param name="other">The other Vector</param>
        /// <returns>The distance to the vector</returns>
        public float Distance(Vector3D other) {
            float dx = other.x - x;
            float dy = other.y - y;
            float dz = other.z - z;

            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        /// <summary>
        /// Gets the unsquared distance to another Vector3D
        /// </summary>
        /// <param name="other">The other Vector3D</param>
        /// <returns>The unsquared distance to another Vector3D</returns>
        public float DistanceSq(Vector3D other) {
            float dx = other.x - x;
            float dy = other.y - y;
            float dz = other.z - z;

            return dx * dx + dy * dy + dz * dz;
        }

        /// <summary>
        /// Reflects the Vector as if it was bouncing of a wall
        /// </summary>
        /// <param name="norm">A normalized Vector</param>
        public void Reflect(Vector3D norm) {
            Vector3D result = new Vector3D(this);
            result += 2 * Dot(norm) * norm.GetReverse();

            this = result;

            //x = result.x;
            //y = result.y;
            //z = result.z;
        }

        /// <summary>
        /// Wraps the Vector around a screen
        /// </summary>
        /// <param name="maxX">The max X value</param>
        /// <param name="maxY">The max Y value</param>
        /// <param name="maxZ">The max Z value</param>
        public void WrapAround(int maxX, int maxY, int maxZ) {
            if (x > maxX)
                x = 0;
            if (x < 0)
                x = maxX;

            if (y > maxY)
                y = 0;
            if (y < 0)
                y = maxY;

            if (z > maxZ)
                z = 0;
            if (z < 0)
                z = maxZ;
        }

        /// <summary>
        /// Checks whether the Vector is not within a given Cube
        /// </summary>
        /// <param name="top_left">The top left corner</param>
        /// <param name="bottom_right">The bottom right corner</param>
        /// <returns>True if it is NOT in the cube</returns>
        public bool NotInsideRegion(Vector3D top_left, Vector3D bottom_right) => x < top_left.x || x > bottom_right.x || y < top_left.x || y > bottom_right.x || z < top_left.z || z > bottom_right.z;

        /// <summary>
        /// Checks whether the Vector is within a given cube
        /// </summary>
        /// <param name="top_left">The top left corner</param>
        /// <param name="bottom_right">The bottom right corner</param>
        /// <returns>True if it IS in the cube</returns>
        public bool InsideRegion(Vector3D top_left, Vector3D bottom_right) => !(x < top_left.x || x > bottom_right.x || y < top_left.x || y > bottom_right.x || z < top_left.z || z > bottom_right.z);

        /// <summary>
        /// Checks whether the Vector is in field of view of the second
        /// </summary>
        /// <param name="posFirst">The position of the first Vector</param>
        /// <param name="facingFirst">The heading of the first Vector</param>
        /// <param name="posSecond">The position of the second Vector</param>
        /// <param name="fov">The field of view of the First Vector</param>
        /// <returns>True if the second Vector is in field of view of the first Vector</returns>
        public bool IsSecondInFOVOfFirst(Vector3D posFirst, Vector3D facingFirst, Vector3D posSecond, float fov) {
            Vector3D toTarget = posSecond - posFirst;
            toTarget.Normalize();

            return facingFirst.Dot(toTarget) >= Math.Cos(fov / 2);
        }

        /// <summary>
        /// Checks the equality of this Vector to another object
        /// </summary>
        /// <param name="obj">The other object</param>
        /// <returns>True if the Vectors are equal</returns>
        public override bool Equals(object obj) {
            return obj is Vector3D && Equals((Vector3D)obj);
        }

        /// <summary>
        /// Checks the equality of this Vector to another Vector
        /// </summary>
        /// <param name="other">The other Vector</param>
        /// <returns>True if the Vectors are equal</returns>
        public bool Equals(Vector3D other) {
            return x == other.x &&
                   y == other.y &&
                   z == other.z;
        }

        /// <summary>
        /// Gets the hashcode of this Vector
        /// </summary>
        /// <returns>The hash code of this Vector</returns>
        public override int GetHashCode() {
            int hashCode = 373119288;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            hashCode = hashCode * -1521134295 + z.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Gets a string version of this Vector3D
        /// </summary>
        /// <returns>The string version of this Vector3D</returns>
        public override string ToString() => $"[{x}, {y}, {z}]";
        #endregion
    }
}
