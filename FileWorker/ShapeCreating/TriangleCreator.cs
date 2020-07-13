using Figures;
using System.Collections.Generic;

namespace FileWorker
{
    /// <summary>
    /// Implementation of the ShapeCreator class for creating a Triangle object
    /// </summary>
    class TriangleCreator : ShapeCreator
    {
        /// <summary>
        /// Creating a Triangle object based on the name and corresponding vertex coordinates
        /// </summary>
        /// <param name="shapeName">Name of the triangle</param>
        /// <param name="coords">Vertex coordinates</param>
        /// <returns>Triangle object</returns>
        public override Polygon GetShape(string shapeName, string[] coords)
        {
            List<(double, double)> tmp = MyParser.ParseStringArrayContainigCoords(coords);
            return new Triangle(shapeName, tmp[0], tmp[1], tmp[2]);
        }
    }
}