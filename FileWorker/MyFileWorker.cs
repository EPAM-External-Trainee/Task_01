using System.Collections.Generic;

namespace FileWorker
{
    /// <summary>
    /// Defining the class interface for working with files
    /// </summary>
    public abstract class MyFileWorker
    {
        /// <summary>
        /// Reading CSV data from a text file
        /// </summary>
        /// <param name="fileName">Name of the file containing information about shapes</param>
        /// <returns>List of strings</returns>
        /// <example>
        /// <code>Rectangle;8,19;16,34;46,16;38,2</code>
        /// </example>
        //public abstract List<Polygon> ReadDataFromCSVFile(string fileName);

        public abstract List<string> ReadingCSVDataFromTextFile(string fileName);
    }
}