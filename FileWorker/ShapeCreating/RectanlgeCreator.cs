using Figures;
using System.Collections.Generic;

namespace FileWorker
{
    /// <summary>
    /// Implementation of the ShapeCreator class for creating a Rectangle object
    /// </summary>
    class RectanlgeCreator : ShapeCreator 
    {
        /// <summary>
        /// Creating a Rectangle object based on the name and corresponding vertex coordinates
        /// </summary>
        /// <param name="shapeName">Name of the rectangle</param>
        /// <param name="coords">Vertex coordinates</param>
        /// <returns>Rectangle object</returns>
        public override Polygon GetShape(string shapeName, string[] coords)
        { 
            List<(double, double)> tmp = MyParser.ParseStringArrayContainigCoords(coords);
            return new Rectangle(shapeName, tmp[0], tmp[1], tmp[2], tmp[3]);
        }
    }
}