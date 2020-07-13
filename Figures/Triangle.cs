using System;

namespace Figures
{
    /// <summary>
    /// Сlass that describes a triangle
    /// </summary>
    public class Triangle : Polygon
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the triangle</param>
        /// <param name="a">Сoordinates of the first vertex</param>
        /// <param name="b">Сoordinates of the second vertex</param>
        /// <param name="c">Сoordinates of the third vertex</param>
        public Triangle(string name, (double, double) a, (double, double) b, (double, double) c) : base(name)
        {
            Coords.AddRange(new (double, double)[] { a, b, c });
            Sides.AddRange(new double[] {
                Math.Round(Math.Sqrt(Math.Pow(Coords[1].Item1 - Coords[0].Item1, 2) + Math.Pow(Coords[1].Item2 - Coords[0].Item2, 2)), 2),
                Math.Round(Math.Sqrt(Math.Pow(Coords[2].Item1 - Coords[0].Item1, 2) + Math.Pow(Coords[2].Item2 - Coords[2].Item2, 2)), 2),
                Math.Round(Math.Sqrt(Math.Pow(Coords[2].Item1 - Coords[1].Item1, 2) + Math.Pow(Coords[2].Item2 - Coords[1].Item2, 2)), 2)
            });
        }

        /// <summary>
        /// Сalculating the area of a triangle
        /// </summary>
        /// <returns>The area of a rectangle</returns>
        public override double GetArea()
        {
            double p = GetPerimeter();
            return Math.Round(Math.Sqrt(p * (p - Sides[0]) * (p - Sides[1]) * (p - Sides[2])), 2);
        }

        /// <summary>
        /// Сalculating the perimeter of a triangle
        /// </summary>
        /// <returns>The perimeter of a triangle</returns>
        public override double GetPerimeter() => Math.Round((Sides[0] + Sides[1] + Sides[2]) / 2, 2);

        /// <summary>
        /// Information about the triangle in the form of the name and coordinates of the vertices
        /// </summary>
        /// <returns>Triangle information as a string in CSV format</returns>
        public override string ToString() => $"{Name};{Coords[0].Item1},{Coords[0].Item2};{Coords[1].Item1},{Coords[1].Item2};{Coords[2].Item1},{Coords[2].Item2}";

        /// <summary>
        /// Comparing triangles by area
        /// </summary>
        /// <param name="obj">Triangle</param>
        /// <returns>Сomparison result</returns>
        public override bool Equals(object obj) => GetArea().Equals((obj as Triangle)?.GetArea());

        /// <summary>
        /// Calculating hash code
        /// </summary>
        /// <returns>Hash сode</returns>
        public override int GetHashCode() => GetArea().GetHashCode();
    }
}