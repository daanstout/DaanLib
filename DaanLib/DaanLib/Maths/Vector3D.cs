using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Maths {
    /// <summary>
    /// A 3D Vector with an x, a Y and a Z
    /// </summary>
    public sealed class Vector3D {
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
        public Vector3D() => x = y = z = 0;

        public Vector3D(Vector2D vec) {
            x = vec.x;
            y = vec.y;
            z = 0;
        }

        public Vector3D(Vector3D vec) {
            x = vec.x;
            y = vec.y;
            z = vec.z;
        }

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
        public void SetZero() => x = y = z = 0.0f;

        public bool IsZero() => x == 0 && y == 0 && z == 0;

        public float Length() => (float)Math.Sqrt(x * x + y * y + z * z);

        public float LengthSq() => x * x + y * y + z * z;

        public float Dot(Vector3D other) => x * other.x + y * other.y + z * other.z;

        public Vector3D Perp() => throw new NotImplementedException();

        public Vector3D GetReverse() => new Vector3D(-x, -y, -z);

        public void Normalize() {
            float vectorLength = Length();
            x /= vectorLength;
            y /= vectorLength;
            z /= vectorLength;
        }

        public void Truncate(float max) {
            if (Length() > max) {
                Normalize();

                x *= max;
                y *= max;
                z *= max;
            }
        }

        public float Distance(Vector3D other) {
            float dx = other.x - x;
            float dy = other.y - y;
            float dz = other.z - z;

            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public float DistanceSq(Vector3D other) {
            float dx = other.x - x;
            float dy = other.y - y;
            float dz = other.z - z;

            return dx * dx + dy * dy + dz * dz;
        }

        public void Reflect(Vector3D norm) {
            Vector3D result = new Vector3D(this);
            result += 2 * Dot(norm) * norm.GetReverse();

            x = result.x;
            y = result.y;
            z = result.z;
        }

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

        public bool NotInsideRegion(Vector3D top_left, Vector3D bottom_right) => x < top_left.x || x > bottom_right.x || y < top_left.x || y > bottom_right.x || z < top_left.z || z > bottom_right.z;

        public bool InsideRegion(Vector3D top_left, Vector3D bottom_right) => !(x < top_left.x || x > bottom_right.x || y < top_left.x || y > bottom_right.x || z < top_left.z || z > bottom_right.z);

        public bool IsSecondInFOVOfFirst(Vector3D posFirst, Vector3D facingFirst, Vector3D posSecond, float fov) {
            Vector3D toTarget = posSecond - posFirst;
            toTarget.Normalize();

            return facingFirst.Dot(toTarget) >= Math.Cos(fov / 2);
        }

        public override bool Equals(object obj) {
            if (obj == null)
                return false;
            if (obj is Vector3D v)
                return this == v;
            return false;
        }

        public override int GetHashCode() {
            int hashCode = 1502939027;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            hashCode = hashCode * -1521134295 + z.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"[{x}, {y}, {z}]";
        #endregion
    }
}
