using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileWorker
{
    /// <summary>
    /// Implementation of the MyFileWorker class for reading data from a file
    /// </summary>
    public class FileReader : MyFileWorker
    {
        /// <summary>
        /// Reading CSV data from a text file
        /// </summary>
        /// <param name="fileName">Name of the file containing information about shapes</param>
        /// <returns>List of polygons</returns>
        public override List<string> ReadingCSVDataFromTextFile(string fileName)
        {
            try
            {
                return File.ReadAllLines(fileName).ToList();
            }
            catch (ArgumentNullException ane)
            {
                throw new ArgumentNullException("Argument can't null", ane);
            }
            catch (Exception exc)
            {
                throw new Exception("Error reading data from file", exc);
            }
        }
    }
}