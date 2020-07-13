using Figures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileWorker
{
    /// <summary>
    /// Static class for parsing data in CSV format
    /// </summary>
    public static class MyParser
    {
        private const string _rectangleNameConst = "Rectangle";
        private const string _triangleNameConst = "Triangle";
        private const string _squareNameConst = "Square";
        private static ShapeCreator _shapeCreator;

        /// <summary>
        /// Parsing a list of strings containing information about vertex coordinates
        /// </summary>
        /// <param name="coords">Vertex coordinates</param>
        /// <returns>List of vertex coordinates</returns>
        public static List<(double, double)> ParseStringArrayContainigCoords(string[] coords)
        {
            if (coords == null)
                throw new ArgumentNullException();

            if (coords.Length == 0)
                throw new ArgumentException();

            return coords?.Select(s => s.Split(',')).Select(s => (Convert.ToDouble(s[0]), Convert.ToDouble(s[1]))).ToList();
        }

        /// <summary>
        /// Parsing a list of strings containing information about shapes
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>List of polygons</returns>
        public static List<Polygon> ParseCSVDataFromFile(List<string> lines)
        {
            if (lines == null)
                throw new ArgumentNullException();

            if (lines.Count == 0)
                throw new ArgumentException();

            List<Polygon> shapes = new List<Polygon>();
            foreach (string item in lines)
            {
                string[] tmp = item.Split(';');
                switch (tmp[0])
                {
                    case _rectangleNameConst:
                        {
                            _shapeCreator = new RectanlgeCreator();
                            shapes.Add(_shapeCreator.GetShape(tmp[0], tmp.Skip(1).ToArray()));
                            break;
                        }
                    case _triangleNameConst:
                        {
                            _shapeCreator = new TriangleCreator();
                            shapes.Add(_shapeCreator.GetShape(tmp[0], tmp.Skip(1).ToArray()));
                            break;
                        };
                    case _squareNameConst:
                        {
                            _shapeCreator = new SquareCreator();
                            shapes.Add(_shapeCreator.GetShape(tmp[0], tmp.Skip(1).ToArray()));
                            break;
                        }
                    default: break;
                }
            }
            return shapes;
        }
    }
}