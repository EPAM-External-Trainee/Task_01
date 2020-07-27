using System.Collections.Generic;

namespace Figures
{
    /// <summary>
    /// Class that describes shapes defined on the plane
    /// </summary>
    public abstract class Polygon
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the shape</param>
        protected Polygon(string name) => Name = name;

        /// <summary>
        /// List of vertex coordinates
        /// </summary>
        protected List<(double, double)> Coords { get; set; } = new List<(double, double)>();

        /// <summary>
        /// List of sides
        /// </summary>
        protected List<double> Sides { get; set; } = new List<double>();

        /// <summary>
        /// Name of the shape
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Сalculating the area
        /// </summary>
        /// <returns>Area of the shape</returns>
        public abstract double GetArea();

        /// <summary>
        /// Сalculating the perimeter
        /// </summary>
        /// <returns>Perimeter of the shape</returns>
        public abstract double GetPerimeter();
    }
}