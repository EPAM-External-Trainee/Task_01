using System;
using System.Linq;

namespace Figures
{
    /// <summary>
    /// Сlass that describes a square
    /// </summary>
    public class Square : Polygon
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the square</param>
        /// <param name="a">Сoordinates of the first vertex</param>
        /// <param name="b">Сoordinates of the second vertex</param>
        /// <param name="c">Сoordinates of the third vertex</param>
        /// <param name="d">Сoordinates of the fourth vertex</param>
        public Square(string name, (double, double) a, (double, double) b, (double, double) c, (double, double) d) : base(name)
        {
            Coords.AddRange(new (double, double)[] { a, b, c, d });
            Sides.Add(Math.Round(Math.Sqrt(Math.Pow(Coords[1].Item1 - Coords[0].Item1, 2) + Math.Pow(Coords[1].Item2 - Coords[0].Item2, 2))));
        }

        /// <summary>
        /// Сalculating the area of a square
        /// </summary>
        /// <returns>The area of a square</returns>
        public override double GetArea() => Sides[0] * Sides[0];

        /// <summary>
        /// Сalculating the perimeter of a square
        /// </summary>
        /// <returns>The perimeter of a square</returns>
        public override double GetPerimeter() => 4 * Sides[0];

        public override string ToString() => $"{Name};{Coords[0].Item1},{Coords[0].Item2};{Coords[1].Item1},{Coords[1].Item2};{Coords[2].Item1},{Coords[2].Item2};{Coords[3].Item1},{Coords[3].Item2}";

        public override bool Equals(object obj) => obj is Square square && Coords.SequenceEqual(square.Coords) && Sides.SequenceEqual(square.Sides) && Name == square.Name;

        public override int GetHashCode()
        {
            int hashCode = -831016500;
            hashCode = hashCode * -1521134295 + Coords.GetHashCode();
            hashCode = hashCode * -1521134295 + Sides.GetHashCode();
            hashCode = hashCode * -1521134295 + Name.GetHashCode();
            return hashCode;
        }
    }
}