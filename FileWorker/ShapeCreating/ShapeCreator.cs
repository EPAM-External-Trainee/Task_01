using Figures;

namespace FileWorker
{
    /// <summary>
    /// Defines the interface of the class to create objects for.
    /// </summary>
    public abstract class ShapeCreator
    {
        /// <summary>
        /// Creating a shape based on the corresponding vertex coordinates
        /// </summary>
        /// <param name="shapeName">The name of the shape</param>
        /// <param name="coords">Vertex coordinates</param>
        /// <returns>Polygon object</returns>
        public abstract Polygon GetShape(string shapeName, string[] coords);
    }
}