#region Liscense
/*

The MIT License (MIT)

Copyright (c) 2016 Udsahn

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/
#endregion

// Fully Functional Vector2 ---
//
// Includes all but transform functionality.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;

namespace Udsahn.Framework
{
    public struct Vector2 : IEquatable<Vector2>
    {
        static Vector2 _zero = new Vector2();
        static Vector2 _one = new Vector2(1f, 1f);
        static Vector2 _unitX = new Vector2(1f, 0f);
        static Vector2 _unitY = new Vector2(0f, 1f);

        public static Vector2 Zero { get { return _zero; } }
        public static Vector2 One { get { return _one; } }
        public static Vector2 UnitX { get { return _unitX; } }
        public static Vector2 UnitY { get { return _unitY; } }

        public float X;
        public float Y;

        /// <summary>
        /// Initializes a new instance of Vector2.
        /// </summary>
        /// <param name="x">X value.</param><param name="y">Y value.</param>
        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector2(float value) : this(value, value) { }

        #region Operators

        public static bool operator ==(Vector2 value1, Vector2 value2)
        {
            if ((double)value1.X == (double)value2.X)
                return (double)value1.Y == (double)value2.Y;
            else
                return false;
        }

        public static bool operator !=(Vector2 value1, Vector2 value2)
        {
            if ((double)value1.X == (double)value2.X)
                return (double)value1.Y != (double)value2.Y;
            else
                return true;
        }

        public static Vector2 operator -(Vector2 value)
        {
            Vector2 vector2;
            vector2.X = -value.X;
            vector2.Y = -value.Y;
            return vector2;
        }

        public static Vector2 operator -(Vector2 value1, Vector2 value2)
        {
            Vector2 result;
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
            return result;
        }

        public static Vector2 operator +(Vector2 value1, Vector2 value2)
        {
            Vector2 result;
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
            return result;
        }

        public static Vector2 operator *(Vector2 value1, Vector2 value2)
        {
            Vector2 result;
            result.X = value1.X * value2.X;
            result.Y = value1.Y * value2.Y;
            return result;
        }

        public static Vector2 operator *(Vector2 value, float scaleFactor)
        {
            Vector2 result;
            result.X = value.X * scaleFactor;
            result.Y = value.Y * scaleFactor;
            return result;
        }

        public static Vector2 operator *(float scaleFactor, Vector2 value)
        {
            return value * scaleFactor;
        }

        public static Vector2 operator /(Vector2 value1, Vector2 value2)
        {
            Vector2 result;
            result.X = value1.X / value2.X;
            result.Y = value1.Y / value2.Y;
            return result;
        }

        public static Vector2 operator /(Vector2 value, float divider)
        {
            float num = 1f / divider;

            Vector2 result;
            result.X = value.X * num;
            result.Y = value.Y * num;
            return result;
        }

        #endregion

        #region Overrides & Equals method.

        public bool Equals(Vector2 other)
        {
            if ((double)this.X == (double)other.X)
                return (double)this.Y == (double)other.Y;
            else
                return false;
        }

        public override bool Equals(object obj)
        {
            bool flag = false;

            if (obj is Vector2)
                flag = this.Equals((Vector2)obj);

            return flag;
        }

        public override int GetHashCode()
        {
            return this.X.GetHashCode() + this.Y.GetHashCode();
        }

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;

            return string.Format((IFormatProvider)currentCulture, "[ X:{0}, Y:{1} ]", new object[2]
                {
                    (object) this.X.ToString((IFormatProvider)currentCulture),
                    (object) this.Y.ToString((IFormatProvider)currentCulture)
                });
        }

        #endregion

        #region Simple Maths

        /// <summary>
        /// Returns a vector pointing in the opposite direction.
        /// </summary>
        public static Vector2 Negate(Vector2 value)
        {
            Vector2 result;
            result.X = -value.X;
            result.Y = -value.Y;
            return result;
        }

        /// <summary>
        /// Returns a vector pointing in the opposite direction.
        /// </summary>
        public static void Negate(ref Vector2 value, out Vector2 result)
        {
            result = Vector2.Negate(value);
        }

        /// <summary>
        /// Adds two vectors together.
        /// </summary>
        public static Vector2 Add(Vector2 value1, Vector2 value2)
        {
            Vector2 result;
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
            return result;
        }

        /// <summary>
        /// Adds two vectors together.
        /// </summary>
        public static void Add(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result = Vector2.Add(value1, value2);
        }

        /// <summary>
        /// Subtracts two vectors.
        /// </summary>
        public static Vector2 Subtract(Vector2 value1, Vector2 value2)
        {
            Vector2 result;
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
            return result;
        }

        /// <summary>
        /// Subtracts two vectors.
        /// </summary>
        public static void Subtract(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result = Vector2.Subtract(value1, value2);
        }

        /// <summary>
        /// Multiplies two vectors.
        /// </summary>
        public static Vector2 Multiply(Vector2 value1, Vector2 value2)
        {
            Vector2 result;
            result.X = value1.X * value2.X;
            result.Y = value1.Y * value2.Y;
            return result;
        }

        /// <summary>
        /// Multiplies two vectors.
        /// </summary>
        public static void Multiply(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result = Vector2.Multiply(value1, value2);
        }

        /// <summary>
        /// Multiplies a vector by a scalar value.
        /// </summary>
        public static Vector2 Multiply(Vector2 value, float scaleFactor)
        {
            Vector2 result;
            result.X = value.X * scaleFactor;
            result.Y = value.Y * scaleFactor;
            return result;
        }

        /// <summary>
        /// Multiplies a vector by a scalar value.
        /// </summary>
        public static void Multiply(ref Vector2 value, float scaleFactor, out Vector2 result)
        {
            result = Vector2.Multiply(value, scaleFactor);
        }

        /// <summary>
        /// Divides two vectors.
        /// </summary>
        public static Vector2 Divide(Vector2 value1, Vector2 value2)
        {
            Vector2 result;
            result = value1 / value2;
            return result;
        }

        /// <summary>
        /// Divides two vectors.
        /// </summary>
        public static void Divide(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result = Vector2.Divide(value1, value2);
        }

        /// <summary>
        /// Divides a vector by a scalar value.
        /// </summary>
        public static Vector2 Divide(Vector2 value, float scaleFactor)
        {
            Vector2 result;
            result = value / scaleFactor;
            return result;
        }

        /// <summary>
        /// Divides a vector by a scalar value.
        /// </summary>
        public static void Divide(ref Vector2 value, float scaleFactor, out Vector2 result)
        {
            result = Vector2.Divide(value, scaleFactor);
        }

        #endregion

        #region Math Methods

        /// <summary>
        /// Calculates the length of the vector using the Pythagorean Formula.
        /// </summary>
        public float Length()
        {
            return (float)Math.Sqrt(Math.Pow((double)this.X, 2) + Math.Pow((double)this.Y, 2));
        }

        /// <summary>
        /// Calculates the length of the vector squared.
        /// </summary>
        public float LengthSquared()
        {
            return (float)(Math.Pow((double)this.X, 2) + Math.Pow((double)this.Y, 2));
        }

        /// <summary>
        /// Calculates the distance between two vectors.
        /// </summary>
        public static float Distance(Vector2 value1, Vector2 value2)
        {
            var numX = value1.X - value2.X;
            var numY = value1.Y - value2.Y;

            return (float)Math.Sqrt(Math.Pow((double)numX, 2) + Math.Pow((double)numY, 2));
        }

        /// <summary>
        /// Calculates the distance between two vectors.
        /// </summary>
        public static void Distance(ref Vector2 value1, ref Vector2 value2, out float result)
        {
            result = Vector2.Distance(value1, value2);
        }

        /// <summary>
        /// Calculates the distance between two vectors squared.
        /// </summary>
        public static float DistanceSquared(Vector2 value1, Vector2 value2)
        {
            var numX = value1.X - value2.X;
            var numY = value1.Y - value2.Y;

            return (float)(Math.Pow((double)numX, 2) + Math.Pow((double)numY, 2));
        }

        /// <summary>
        /// Calculates the distance between two vectors squared.
        /// </summary>
        public static void DistanceSquared(ref Vector2 value1, ref Vector2 value2, out float result)
        {
            result = Vector2.DistanceSquared(value1, value2);
        }

        /// <summary>
        /// Calculates the dot product of two vectors. If the two vectors are unit vectors, the dot product returns a floating point value between -1 and 1 that can be used to determine some properties of the angle between two vectors. For example, it can show whether the vectors are orthogonal, parallel, or have an acute or obtuse angle between them.
        /// </summary>
        public static float Dot(Vector2 value1, Vector2 value2)
        {
            // X(sub 1) * X(sub 2)
            var numX = (double)value1.X * (double)value2.X;

            // Y(sub 1) * Y(sub 2)
            var NumY = (double)value1.Y * (double)value2.Y;

            // X1*X2 + Y1+Y2
            return (float)((double)numX + (double)NumY);
        }

        /// <summary>
        /// Calculates the dot product of two vectors and writes the result to a user-specified variable. If the two vectors are unit vectors, the dot product returns a floating point value between -1 and 1 that can be used to determine some properties of the angle between two vectors. For example, it can show whether the vectors are orthogonal, parallel, or have an acute or obtuse angle between them.
        /// </summary>
        public static void Dot(ref Vector2 value1, ref Vector2 value2, out float result)
        {
            // Returns X1*X2 + Y1*Y2.
            result =  (Vector2.Dot(value1, value2));
        }

        /// <summary>
        /// Turns the current vector into a unit vector. The result is a vector one unit in length pointing in the same direction as the original vector.
        /// </summary>
        public void Normalize()
        {
            float value = 1f / this.Length();

            this.X *= value;
            this.Y *= value;
        }

        /// <summary>
        /// Creates a unit vector from the specified vector. The result is a vector one unit in length pointing in the same direction as the original vector.
        /// </summary>
        public static Vector2 Normalize(Vector2 vector)
        {
            float value = vector.Length();

            Vector2 result;
            result.X = vector.X * value;
            result.Y = vector.Y * value;
            return result;
        }

        /// <summary>
        /// Creates a unit vector from the specified vector, writing the result to a user-specified variable. The result is a vector one unit in length pointing in the same direction as the original vector.
        /// </summary>
        public static void Normalize(ref Vector2 vector, out Vector2 result)
        {
            result = Vector2.Normalize(vector);
        }

        /// <summary>
        /// Determines the reflect vector of the given vector and normal.
        /// </summary>
        public static Vector2 Reflect(Vector2 vector, Vector2 normal)
        {
            // Calculate Dot Product.
            var value = Vector2.Dot(vector, normal);

            Vector2 result;
            result.X = vector.X - 2f * (value * normal.X);
            result.Y = vector.Y - 2f * (value * normal.Y);

            return result;
        }

        /// <summary>
        /// Determines the reflect vector of the given vector and normal.
        /// </summary>
        public static void Reflect(ref Vector2 vector, ref Vector2 normal, out Vector2 result)
        {
            result = Vector2.Reflect(vector, normal);
        }

        /// <summary>
        /// Returns a vector that contains the lowest value from each matching pair of components.
        /// </summary>
        public static Vector2 Min(Vector2 value1, Vector2 value2)
        {
            Vector2 result;

            // If val1 < val2 ~~ return val1, else val2.
            result.X = (double)value1.X < (double)value2.X ? value1.X : value2.X;
            result.Y = (double)value1.Y < (double)value2.Y ? value1.Y : value2.Y;

            return result;
        }

        /// <summary>
        /// Returns a vector that contains the lowest value from each matching pair of components.
        /// </summary>
        public static void Min(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result = Vector2.Min(value1, value2);
        }

        /// <summary>
        /// Returns a vector that contains the highest value from each matching pair of components.
        /// </summary>
        public static Vector2 Max(Vector2 value1, Vector2 value2)
        {
            Vector2 result;

            result.X = (double)value1.X > (double)value2.X ? value1.X : value2.X;
            result.Y = (double)value1.Y > (double)value2.Y ? value1.Y : value2.Y;

            return result;
        }

        /// <summary>
        /// Returns a vector that contains the highest value from each matching pair of components.
        /// </summary>
        public static void Max(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result = Vector2.Max(value1, value2);
        }

        /// <summary>
        /// Restricts a value to be within a specified range.
        /// </summary>
        public static Vector2 Clamp(Vector2 vector, Vector2 max, Vector2 min)
        {
            var numX = vector.X;

            var xMax = (double)numX > (double)max.X ? max.X : numX;
            var xValue = (double)xMax < (double)min.X ? min.X : xMax;

            var numY = vector.Y;

            var yMax = (double)numY > (double)max.Y ? max.Y : numY;
            var yValue = (double)yMax < (double)min.Y ? min.Y : yMax;

            // Make a new vector with the clamped values.
            Vector2 result = new Vector2(xValue, yValue);
            return result;
        }

        /// <summary>
        /// Restricts a value to be within a specified range.
        /// </summary>
        public static void Clamp(ref Vector2 vector, ref Vector2 max, ref Vector2 min, out Vector2 result)
        {
            result = Vector2.Clamp(vector, max, min);
        }

        /// <summary>
        /// Performs a linear interpolation between two vectors.
        /// </summary>
        public static Vector2 Lerp(Vector2 value1, Vector2 value2, float amount)
        {
            Vector2 result;

            // Calculates the percentage between two points to linear interpolate.
            result.X = value1.X + (value2.X - value1.X) * amount;
            result.Y = value1.Y + (value2.Y - value1.Y) * amount;

            return result;
        }

        /// <summary>
        /// Performs a linear interpolation between two vectors.
        /// </summary>
        public static void Lerp(ref Vector2 value1, ref Vector2 value2, float amount, out Vector2 result)
        {
            result = Vector2.Lerp(value1, value2, amount);
        }

        /// <summary>
        /// Returns a Vector2 containing the 2D Cartesian coordinates of a point specified in barycentric (areal) coordinates relative to a 2D triangle.
        /// </summary>
        public static Vector2 Barycentric(Vector2 value1, Vector2 value2, Vector2 value3, float amount1, float amount2)
        {
            Vector2 result;
            result.X = (float)((double)value1.X +
                               (double)amount1 * ((double)value2.X - (double)value1.X) +
                               (double)amount2 * ((double)value3.X - (double)value1.X));
            result.Y = (float)((double)value1.Y +
                               (double)amount1 * ((double)value2.Y - (double)value1.Y) +
                               (double)amount2 * ((double)value3.Y - (double)value1.Y));

            return result;
        }

        /// <summary>
        /// Returns a Vector2 containing the 2D Cartesian coordinates of a point specified in barycentric (areal) coordinates relative to a 2D triangle.
        /// </summary>
        public static void Barycentric(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, float amount1, float amount2, out Vector2 result)
        {
            result = Vector2.Barycentric(value1, value2, value3, amount1, amount2);
        }

        /// <summary>
        /// Interpolates between two values using a cubic equation.
        /// </summary>
        public static Vector2 SmoothStep(Vector2 value1, Vector2 value2, float amount)
        {
            // Clamp the amount to between 0 and 1.
            amount = (double)amount > 1.0 ? 1f : ((double)amount < 0 ? 0f : amount);

            amount = (float)((double)amount * (double)amount * (3.0 - 2.0 * (double)amount));

            return Vector2.Lerp(value1, value2, amount);
        }

        /// <summary>
        /// Interpolates between two values using a cubic equation.
        /// </summary>
        public static void SmoothStep(ref Vector2 value1, ref Vector2 value2, float amount, out Vector2 result)
        {
            result = Vector2.SmoothStep(value1, value2, amount);
        }

        /// <summary>
        /// Performs a Catmull-Rom interpolation using the specified positions.
        /// </summary>
        /// <param name="value1">The first position in the interpolation.</param><param name="value2">The second position in the interpolation.</param><param name="value3">The third position in the interpolation.</param><param name="value4">The fourth position in the interpolation.</param><param name="amount">Weighting factor.</param><param name="result">[OutAttribute] A vector that is the result of the Catmull-Rom interpolation.</param>
        public static Vector2 CatmullRom(Vector2 value1, Vector2 value2, Vector2 value3, Vector2 value4, float amount)
        {
            float amountSquare = (float)Math.Pow(amount, 2);
            float amountCube = (float)Math.Pow(amount, 3);

            Vector2 result;

            // Equation found: http://www.mvps.org/directx/articles/catmull/
            // Catmull-Rom spline.
            result.X = (float)(0.5 * (2.0 * (double)value2.X + 
                              (-(double)value1.X + (double)value3.X) * (double)amount + 
                              (2.0 * (double)value1.X - 5.0 * (double)value2.X + 4.0 * (double)value3.X - (double)value4.X) * (double)amountSquare +
                              (-(double)value1.X + 3.0 * (double)value2.X - 3.0 * (double)value3.X + (double)value4.X) * (double)amountCube));

            result.Y = (float)(0.5 * (2.0 * (double)value2.Y) +
                              (-(double)value1.Y + (double)value3.Y) * (double)amount +
                              (2.0 * (double)value1.Y - 5.0 * (double)value2.Y + 4.0 * (double)value3.Y - (double)value4.Y) * (double)amountSquare +
                              (-(double)value1.Y + 3.0 * (double)value2.Y - 3.0 * (double)value3.Y + (double)value4.Y) * (double)amountCube);

            return result;
        }

        /// <summary>
        /// Performs a Catmull-Rom interpolation using the specified positions.
        /// </summary>
        /// <param name="value1">The first position in the interpolation.</param><param name="value2">The second position in the interpolation.</param><param name="value3">The third position in the interpolation.</param><param name="value4">The fourth position in the interpolation.</param><param name="amount">Weighting factor.</param><param name="result">[OutAttribute] A vector that is the result of the Catmull-Rom interpolation.</param>
        public static void CatmullRom(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, ref Vector2 value4, float amount, out Vector2 result)
        {
            // Equation found: http://www.mvps.org/directx/articles/catmull/
            // Catmull-Rom spline.
            result = Vector2.CatmullRom(value1, value2, value3, value4, amount);
        }

        /// <summary>
        /// Performs a Hermite spline interpolation.
        /// </summary>
        /// <param name="p1">Point 1</param>
        /// <param name="t1">Tangent for point 1</param>
        /// <param name="p2">Point 2</param>
        /// <param name="t2">Tangent for point 2</param>
        /// <param name="scale">Weighting factor.</param>
        public static Vector2 Hermite(Vector2 p1, Vector2 t1, Vector2 p2, Vector2 t2, float scale)
        {
            // Equation :: http://cubic.org/docs/hermite.htm
            // Hermite spline interpolation!

            // Matrix form of the equation:
            //
            // Vector S: The interpolation-point and it's powers up to 3:
            // Vector C: The parameters of our hermite curve:
            // Matrix h: The matrix form of the 4 hermite polynomials:
            //
            //                                                 h1  h2  h3  h4
            //                                              ___|___|___|___|___
            //      | s ^ 3 |            | P1 |             |  2  -2   1   1  |
            // S =  | s ^ 2 |       C =  | P2 |        h =  | -3   3  -2  -1  |
            //      | s ^ 1 |            | T1 |             |  0   0   1   0  |
            //      | 1     |            | T2 |             |  1   0   0   0  |

            float s = scale;
            float sSquared = (float)Math.Pow(s, 2);
            float sCubed = (float)Math.Pow(s, 3);

            float h1 = (float)(2.0 * (double)sCubed - 3.0 * (double)sSquared + 1.0);
            float h2 = (float)(-2.0 * (double)sCubed + 3.0 * (double)sSquared);
            float h3 = (float)((double)sCubed - 2.0 * (double)sSquared + (double)s);
            float h4 = (float)((double)sCubed - (double)sSquared);

            Vector2 result;

            // Equation following the matrix above.
            result.X = (float)(h1 * (double)p1.X +
                               h2 * (double)p2.X +
                               h3 * (double)t1.X +
                               h4 * (double)t2.X);

            result.Y = (float)(h1 * (double)p1.Y +
                               h2 * (double)p1.Y +
                               h3 * (double)t1.Y +
                               h4 * (double)t2.Y);

            return result;
        }

        /// <summary>
        /// Performs a Hermite spline interpolation.
        /// </summary>
        /// <param name="p1">Point 1</param>
        /// <param name="t1">Tangent for point 1</param>
        /// <param name="p2">Point 2</param>
        /// <param name="t2">Tangent for point 2</param>
        /// <param name="scale">Weighting factor.</param>
        public static void Hermite(ref Vector2 p1, ref Vector2 t1, ref Vector2 p2, ref Vector2 t2, float scale, out Vector2 result)
        {
            result = Vector2.Hermite(p1, t1, p2, t2, scale);
        }

        public static Vector2 Bezier(Vector2 p1, Vector2 t1, Vector2 p2, Vector2 t2, float scale)
        {
            // Equation :: http://cubic.org/docs/hermite.htm
            // Hermite spline interpolation!

            // Matrix form of the equation:
            //
            // Vector S: The interpolation-point and it's powers up to 3:
            // Vector C: The parameters of our hermite curve:
            // Matrix h: The matrix form of the 4 hermite polynomials:
            //
            //                                                 h1  h2  h3  h4
            //                                              ___|___|___|___|___
            //      | s ^ 3 |            | P1 |             |  2  -2   1   1  |
            // S =  | s ^ 2 |       C =  | P2 |        h =  | -3   3  -2  -1  |
            //      | s ^ 1 |            | T1 |             |  0   0   1   0  |
            //      | 1     |            | T2 |             |  1   0   0   0  |
            //
            // For Bezier curves, this matrix is used in place of 'h'
            //      
            //                                                 b1  b2  b3  b4
            //                                              ___|___|___|___|___
            //      | s ^ 3 |            | P1 |             | -1   3  -3   1  |
            // S =  | s ^ 2 |       C =  | P2 |        b =  |  3  -6   3   0  |
            //      | s ^ 1 |            | T1 |             | -3   3   0   0  |
            //      | 1     |            | T2 |             |  1   0   0   0  |

            float b = scale;
            float bSquared = (float)Math.Pow(b, 2);
            float bCubed = (float)Math.Pow(b, 3);

            float b1 = (float)(-(double)bCubed + 3.0 * (double)bSquared - 3.0 * (double)b + 1.0);
            float b2 = (float)(3.0 * (double)bCubed - 6.0 * (double)bSquared + 3.0 * (double)b);
            float b3 = (float)(-3.0 * (double)bCubed + 3.0 * (double)bSquared);
            float b4 = bCubed;

            Vector2 result;

            result.X = (float)(b1 * (double)p1.X +
                               b2 * (double)p2.X +
                               b3 * (double)t1.X +
                               b4 * (double)t2.X);

            result.Y = (float)(b1 * (double)p1.Y +
                               b2 * (double)p2.Y +
                               b3 * (double)t1.Y +
                               b4 * (double)t2.Y);

            return result;
        }

        public static void Bezier (ref Vector2 p1, ref Vector2 t1, ref Vector2 p2, ref Vector2 t2, float scale, out Vector2 result)
        {
            result = Vector2.Bezier(p1, t1, p2, t2, scale);
        }

        // 
        // Transform code would go here, but I decided to skip them.
        //
        // Tee-hee~ ;)

        #endregion
    }
}
