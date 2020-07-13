using Figures;
using System.Collections.Generic;

namespace FileWorker
{
    /// <summary>
    /// Implementation of the ShapeCreator class for creating a Square object
    /// </summary>
    class SquareCreator : ShapeCreator
    {
        /// <summary>
        /// Creating a Square object based on the name and corresponding vertex coordinates
        /// </summary>
        /// <param name="shapeName">Name of the square</param>
        /// <param name="coords">Vertex coordinates</param>
        /// <returns>Square object</returns>
        public override Polygon GetShape(string shapeName ,string[] coords)
        {
            List<(double, double)> tmp = MyParser.ParseStringArrayContainigCoords(coords);
            return new Square(shapeName, tmp[0], tmp[1], tmp[2], tmp[3]);
        }
    }
}