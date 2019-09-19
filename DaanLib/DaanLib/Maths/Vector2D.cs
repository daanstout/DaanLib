using System;
using System.Drawing;

namespace DaanLib.Maths {
    /// <summary>
    /// A 2D vector with an X and a Y
    /// </summary>
    public struct Vector2D : IEquatable<Vector2D> {
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
        /// A Vector2D that points up
        /// </summary>
        public static Vector2D Up => new Vector2D(0, 1);
        /// <summary>
        /// A Vector2D that points right
        /// </summary>
        public static Vector2D Right => new Vector2D(1, 0);
        /// <summary>
        /// A Vector2D that points down
        /// </summary>
        public static Vector2D Down => new Vector2D(0, -1);
        /// <summary>
        /// A Vector2D that points left
        /// </summary>
        public static Vector2D Left => new Vector2D(-1, 0);
        /// <summary>
        /// A zero-based Vector2D
        /// </summary>
        public static Vector2D Zero => new Vector2D(0, 0);
        /// <summary>
        /// A one-based Vector2D
        /// </summary>
        public static Vector2D One => new Vector2D(1, 1);
        /// <summary>
        /// A negative one-based Vector2D
        /// </summary>
        public static Vector2D NegOne => new Vector2D(-1, -1);
        #endregion
        #region Constructors
        /// <summary>
        /// Instantiates a new Vector2D based on another Vector2D
        /// </summary>
        /// <param name="vec">The vector to copy</param>
        public Vector2D(Vector2D vec) {
            x = vec.x;
            y = vec.y;
        }

        /// <summary>
        /// Instantiates a new Vector2D based on a Vector3D
        /// </summary>
        /// <param name="vec"></param>
        public Vector2D(Vector3D vec) {
            x = vec.x;
            y = vec.y;
        }

        /// <summary>
        /// Instantiates a new Vector2D based on the string representation of a Vector2D.ToString()
        /// <para>If this constructor throws an error, that means the string is not a correct string</para>
        /// </summary>
        /// <param name="vec">The string representation of a Vector</param>
        public Vector2D(string vec) {
            try {
                string sub = vec.Substring(1, vec.Length - 2);
                string[] split = sub.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                if (split.Length >= 1)
                    x = (float)Convert.ToDouble(split[0]);
                else {
                    x = y = 0;
                    return;
                }

                if (split.Length >= 2)
                    y = (float)Convert.ToDouble(split[1]);
                else {
                    y = 0;
                    return;
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Instantiates a new Vector3D based on a float
        /// </summary>
        /// <param name="x"></param>
        public Vector2D(float x) {
            this.x = x;
            y = 0;
        }

        /// <summary>
        /// Instantiates a new Vector2D based on a X and a Y
        /// </summary>
        /// <param name="x">The X value</param>
        /// <param name="y">The Y Value</param>
        public Vector2D(float x, float y) {
            this.x = x;
            this.y = y;
        }
        #endregion
        #region Operator Overloads
        public static Vector2D operator +(Vector2D a, Vector2D b) => new Vector2D(a.x + b.x, a.y + b.y);

        public static Vector2D operator -(Vector2D a, Vector2D b) => new Vector2D(a.x - b.x, a.y - b.y);

        public static Vector2D operator *(Vector2D v, float f) => new Vector2D(v.x * f, v.y * f);
        public static Vector2D operator *(Vector2D v, int i) => new Vector2D(v.x * i, v.y * i);
        public static Vector2D operator *(float f, Vector2D v) => new Vector2D(v.x * f, v.y * f);
        public static Vector2D operator *(int i, Vector2D v) => new Vector2D(v.x * i, v.y * i);
        public static Vector2D operator *(Vector2D v1, Vector2D v2) => new Vector2D(v1.x * v2.x, v1.y * v2.y);

        public static Vector2D operator /(Vector2D v, float f) => new Vector2D(v.x / f, v.y / f);
        public static Vector2D operator /(Vector2D v, int i) => new Vector2D(v.x / i, v.y / i);
        public static Vector2D operator /(float f, Vector2D v) => new Vector2D(v.x / f, v.y / f);
        public static Vector2D operator /(int i, Vector2D v) => new Vector2D(v.x / i, v.y / i);
        public static Vector2D operator /(Vector2D v1, Vector2D v2) => new Vector2D(v1.x / v2.x, v1.y / v2.y);

        public static Vector2D operator %(Vector2D v1, Vector2D v2) => new Vector2D(v1.x % v2.x, v1.y % v2.y);
        public static Vector2D operator %(Vector2D v, int i) => new Vector2D(v.x % i, v.y % i);

        public static bool operator ==(Vector2D v1, Vector2D v2) => v1.x == v2.x && v1.y == v2.y;
        public static bool operator !=(Vector2D v1, Vector2D v2) => v1.x != v2.x || v1.y != v2.y;
        #endregion
        #region Conversions
        #region Implicit Conversions
        public static implicit operator Point(Vector2D v) => new Point((int)v.x, (int)v.y);
        public static implicit operator Vector2D(Point p) => new Vector2D(p.X, p.Y);
        public static implicit operator PointF(Vector2D v) => new PointF(v.x, v.y);
        public static implicit operator Vector2D(PointF p) => new Vector2D(p.X, p.Y);

        public static implicit operator Vector2D(ValueTuple<int, int> t) => new Vector2D(t.Item1, t.Item2);
        public static implicit operator Vector2D(ValueTuple<float, float> t) => new Vector2D(t.Item1, t.Item2);
        public static implicit operator ValueTuple<float, float>(Vector2D v) => (v.x, v.y);

        public static implicit operator Size(Vector2D v) => new Size((int)v.x, (int)v.y);
        public static implicit operator Vector2D(Size s) => new Vector2D(s.Width, s.Height);
        public static implicit operator SizeF(Vector2D v) => new SizeF(v.x, v.y);
        public static implicit operator Vector2D(SizeF s) => new Vector2D(s.Width, s.Height);
        #endregion
        #region Explicit Conversions
        public static explicit operator Vector2D(Vector3D v) => new Vector2D(v);
        #endregion
        #endregion
        #region Functions
        /// <summary>
        /// Sets both values to 0;
        /// </summary>
        public void SetZero() => x = y = 0.0f;

        /// <summary>
        /// Checks whether both values are 0
        /// </summary>
        /// <returns>True if both values are 0, false otherwhys</returns>
        public bool isZero() => x == 0 && y == 0;

        /// <summary>
        /// Gives the length of the vector
        /// </summary>
        /// <returns>The length of the vector</returns>
        public float Length() => (float)Math.Sqrt(x * x + y * y);

        /// <summary>
        /// Gives the unsquared length of the vector
        /// </summary>
        /// <returns>The unsquared length of the vector</returns>
        public float LengthSq() => (x * x + y * y);

        /// <summary>
        /// Calculates the dot between 2 vectors
        /// </summary>
        /// <param name="other"></param>
        /// <returns>For normalized vectors Dot returns 1 if they point in exactly the same direction; -1 if they point in completely opposite directions; and a number in between for other cases (e.g. Dot returns zero if vectors are perpendicular)</returns>
        public float Dot(Vector2D other) => x * other.x + y * other.y;

        /// <summary>
        /// Normalizes the vector, putting both values between -1 and 1
        /// </summary>
        public void Normalize() {
            float vectorLength = Length();
            this /= vectorLength;
            //x /= vectorLength;
            //y /= vectorLength;
        }

        /// <summary>
        /// checks on what side the other vector is
        /// </summary>
        /// <param name="other">The other vector</param>
        /// <returns>returns -1 if other is anti-clockwise of the vector and 1 if clockwise</returns>
        public int Sign(Vector2D other) => y * other.x > x * other.y ? -1 : 1;

        /// <summary>
        /// Gets the manhattan distance to another Vector2D
        /// <para>The manhattan distance is the ΔX + ΔY</para>
        /// </summary>
        /// <param name="other">The Vector2D to calculate to</param>
        /// <returns>The distance to the other Vector</returns>
        public float GetManhattan(Vector2D other) => Math.Abs(x - other.x) + Math.Abs(y - other.y);

        /// <summary>
        /// Creates a new vector that is perpandicular of this vector
        /// </summary>
        /// <returns>A perpandicular vector</returns>
        public Vector2D Perp() => new Vector2D(-y, x);

        /// <summary>
        /// Truncates the vector to the max value if it goes over it
        /// </summary>
        /// <param name="max">The max value</param>
        public void Truncate(float max) {
            if (Length() <= max)
                return;

            Normalize();

            this *= max;
            //if (Length() > max) {
            //    Normalize();

            //    x *= max;
            //    y *= max;
            //}
        }

        /// <summary>
        /// Calculates the distance between 2 vectors
        /// </summary>
        /// <param name="other">The other vector</param>
        /// <returns>The distance between the 2 vectors</returns>
        public float Distance(Vector2D other) {
            float dx = other.x - x;
            float dy = other.y - y;

            return (float)Math.Sqrt(dy * dy + dx * dx);
        }

        /// <summary>
        /// Calculates the unsquared distance between 2 vectors
        /// </summary>
        /// <param name="other">The other vector</param>
        /// <returns>The unsquared distance between the 2 vectors</returns>
        public float DistanceSq(Vector2D other) {
            float dx = other.x - x;
            float dy = other.y - y;

            return (dy * dy + dx * dx);
        }

        /// <summary>
        /// Reflects the vector as if it was bouncing of a wall
        /// </summary>
        /// <param name="norm">A normalized vector</param>
        public void Reflect(Vector2D norm) {
            Vector2D result = new Vector2D(this);
            result += 2 * Dot(norm) * norm.GetReverse();
            this = result;
            //x = result.x;
            //y = result.y;
        }

        /// <summary>
        /// Reverses the vector
        /// </summary>
        /// <returns>The reversed vector</returns>
        public Vector2D GetReverse() => new Vector2D(-x, -y);

        /// <summary>
        /// Wraps the vector around a screen
        /// </summary>
        /// <param name="maxX">The max X value</param>
        /// <param name="maxY">The max Y value</param>
        public void WrapAround(int maxX, int maxY) {
            if (x > maxX)
                x = 0;
            if (x < 0)
                x = maxX;

            if (y > maxY)
                y = 0;
            if (y < 0)
                y = maxY;
        }

        /// <summary>
        /// Checks whether the vector is not within a given rectangle
        /// </summary>
        /// <param name="top_left">The top left corner</param>
        /// <param name="bot_rgt">The bottom right corner</param>
        /// <returns>True if it is NOT in the rectangle</returns>
        public bool NotInsideRegion(Vector2D top_left, Vector2D bot_rgt) => (x < top_left.x) || (x > bot_rgt.x) || (y < top_left.y) || (y > bot_rgt.y);

        /// <summary>
        /// Checks whether the vector is within a given rectangle
        /// </summary>
        /// <param name="top_left">The top left corner</param>
        /// <param name="bot_rgt">The bottom right corner</param>
        /// <returns>True if it IS in the rectangle</returns>
        public bool InsideRegion(Vector2D top_left, Vector2D bot_rgt) => !((x < top_left.x) || (x > bot_rgt.x) || (y < top_left.y) || (y > bot_rgt.y));

        /// <summary>
        /// Checks whether the first is within view of the second
        /// </summary>
        /// <param name="posFirst">Position of the first vector</param>
        /// <param name="facingFirst">Heading of the first vector</param>
        /// <param name="posSecond">Position of the second vector</param>
        /// <param name="fov">FOV of the first vector</param>
        /// <returns></returns>
        public static bool isSecondInFOVOfFirst(Vector2D posFirst, Vector2D facingFirst, Vector2D posSecond, float fov) {
            Vector2D toTarget = Vec2DNormalize(posSecond - posFirst);

            return facingFirst.Dot(toTarget) >= Math.Cos(fov / 2);
        }

        /// <summary>
        /// Normalizes a vector
        /// </summary>
        /// <param name="v">The vector to be normalized</param>
        /// <returns>A normalized vector</returns>
        public static Vector2D Vec2DNormalize(Vector2D v) {
            Vector2D vec = v;

            float vector_length = vec.Length();

            vec /= vector_length;

            //vec.x /= vector_length;
            //vec.y /= vector_length;

            return vec;
        }

        /// <summary>
        /// Gets the distance between 2 vectors
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vectro2 </param>
        /// <returns>The distance between the 2 vectors</returns>
        public static float Vec2DDistance(Vector2D v1, Vector2D v2) {
            float ySep = v2.y - v1.y;
            float xSep = v2.x - v1.x;

            return (float)Math.Sqrt(ySep * ySep + xSep * xSep);
        }

        /// <summary>
        /// Gets the unsquared distance between 2 vectors
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2</param>
        /// <returns>The unsquared distance between the 2 vectors</returns>
        public static float Vec2DDistanceSq(Vector2D v1, Vector2D v2) {
            float ySep = v2.y - v1.y;
            float xSep = v2.x - v1.x;

            return ySep * ySep + xSep * xSep;
        }

        /// <summary>
        /// Gets the length of the vector
        /// </summary>
        /// <param name="v">The vector</param>
        /// <returns>The length of the vector</returns>
        public static float Vec2DLength(Vector2D v) => (float)Math.Sqrt(v.x * v.x + v.y * v.y);

        /// <summary>
        /// Gets the unsquared length of the vector
        /// </summary>
        /// <param name="v">The vector</param>
        /// <returns>The unsquared length of the vector</returns>
        public static float Vec2DLengthSq(Vector2D v) => v.x * v.x + v.y * v.y;

        /// <summary>
        /// Lerps a Vector3D between a starting and end point based on a delta
        /// <para>A delta of 0 returns the start Vector and a delta of 1 returns the end vector</para>
        /// <para>A delta below 0 or above 1 returns a Vector3D that is not between the start and end vector</para>
        /// </summary>
        /// <param name="start">The start Vector3D</param>
        /// <param name="end">The end Vector3D</param>
        /// <param name="delta">The place between the lines</param>
        /// <returns>The Vector3D between the start and end vector at the delta point</returns>
        public static Vector2D Lerp(Vector2D start, Vector2D end, float delta) {
            Vector2D v = new Vector2D();

            v.x = start.x * (1.0f - delta) + end.x * delta;
            v.y = start.y * (1.0f - delta) + end.x * delta;

            return v;
        }

        ///// <summary>
        ///// Checks whether the 2 vectors are equal
        ///// </summary>
        ///// <param name="obj">The other vector</param>
        ///// <returns>true if the vectors are equal</returns>
        //public override bool Equals(object obj) {
        //    if (obj == null)
        //        return false;
        //    else if (obj is Vector2D v)
        //        return this == v;
        //    else
        //        return false;
        //}

        /// <summary>
        /// Checks whether the 2 vectors are equal
        /// </summary>
        /// <param name="obj">The other object</param>
        /// <returns>true if the vectors are equal</returns>
        public override bool Equals(object obj) => obj is Vector2D && Equals((Vector2D)obj);

        /// <summary>
        /// Checks whether the 2 vectors are equal
        /// </summary>
        /// <param name="other">The other vector</param>
        /// <returns>true if the vectors are equal</returns>
        public bool Equals(Vector2D other) {
            return x == other.x &&
                   y == other.y;
        }

        /// <summary>
        /// Gets the hashcode of the vector
        /// </summary>
        /// <returns>The hashcode</returns>
        public override int GetHashCode() {
            int hashCode = 1502939027;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Returns a string of the 2 vectors
        /// </summary>
        /// <returns>A string as followed: "[x, y]"</returns>
        public override string ToString() => $"[{x}, {y}]";
        #endregion
    }
}
