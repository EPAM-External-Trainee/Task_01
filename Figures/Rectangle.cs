using System;
using System.Linq;

namespace Figures
{
    /// <summary>
    /// Сlass that describes a rectangle
    /// </summary>
    public class Rectangle : Polygon
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the rectangle</param>
        /// <param name="a">Сoordinates of the first vertex</param>
        /// <param name="b">Сoordinates of the second vertex</param>
        /// <param name="c">Сoordinates of the third vertex</param>
        /// <param name="d">Сoordinates of the fourth vertex</param>
        public Rectangle(string name, (double, double) a, (double, double) b, (double, double) c, (double, double) d) : base(name)
        {
            Coords.AddRange(new (double, double)[] { a, b, c, d });
            Sides.AddRange(new double[] {
                Math.Round(Math.Sqrt(Math.Pow(Coords[0].Item1 - Coords[1].Item1, 2) + Math.Pow(Coords[0].Item2 - Coords[1].Item2, 2)), 2),
                Math.Round(Math.Sqrt(Math.Pow(Coords[1].Item1 - Coords[0].Item1, 2) + Math.Pow(Coords[1].Item2 - Coords[2].Item2, 2)), 2),
            });
        }

        /// <summary>
        /// Сalculating the area of a rectangle
        /// </summary>
        /// <returns>The area of a rectangle</returns>
        public override double GetArea() => Sides[0] * Sides[1];

        /// <summary>
        /// Сalculating the perimeter of a rectangle
        /// </summary>
        /// <returns>The perimeter of a rectangle</returns>
        public override double GetPerimeter() => Sides.Count * (Sides[0] + Sides[1]);

        public override string ToString() => $"{Name};{Coords[0].Item1},{Coords[0].Item2};{Coords[1].Item1},{Coords[1].Item2};{Coords[2].Item1},{Coords[2].Item2};{Coords[3].Item1},{Coords[3].Item2}";

        public override bool Equals(object obj) => obj is Rectangle rectangle && Coords.SequenceEqual(rectangle.Coords) && Sides.SequenceEqual(rectangle.Sides) && Name == rectangle.Name;

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