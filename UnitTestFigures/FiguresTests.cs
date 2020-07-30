using Figures;
using FileWorker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnitTestForFigures
{
    [TestClass]
    public class FiguresTests
    {
        private readonly FileReader _reader = new FileReader(); 
        private readonly string _figuresFilePath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "Resources", "Figures.txt");

        [TestMethod, Description("Reading CSV data from text file with null argument as file name. Throw ArgumentNullException")]
        public void ReadingCSVDataFromTextFile_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _reader.ReadingCSVDataFromTextFile(null));
        }

        [DataTestMethod, Description("Reading CSV data from text file with wrong file name. Throw Exception")]
        [DataRow("")]
        [DataRow("NonexistentPath")]
        public void ReadingCSVDataFromTextFile_Exception(string pathToFile)
        {
            Assert.ThrowsException<Exception>(() => _reader.ReadingCSVDataFromTextFile(pathToFile));
        }

        [TestMethod, Description("Reading CSV data from text file with correct file name. Positive test result")]
        public void ReadingCSVDataFromTextFile_PositiveTestResult()
        {
            Assert.AreNotEqual(null, _reader.ReadingCSVDataFromTextFile(_figuresFilePath));
        }

        [TestMethod, Description("Pasring vertex coordinates from null string array. Throw ArgumentNullException")]
        public void ParseStringArrayContainigCoords_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => MyParser.ParseStringArrayContainigCoords(null));
        }

        [TestMethod, Description("Pasring vertex coordinates from empty string array. Throw ArgumentException")]
        public void ParseStringArrayContainigCoords_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => MyParser.ParseStringArrayContainigCoords(new string[0]));
        }

        [TestMethod, Description("Reading CSV data from text file and parsing data from null string array. Throw ArgumentNullException")]
        public void ParseCSVDataFromFile_ArgumentNullException()
        {
            Assert.AreNotEqual(null, _reader.ReadingCSVDataFromTextFile(_figuresFilePath));
            Assert.ThrowsException<ArgumentNullException>(() => MyParser.ParseCSVDataFromFile(null));
        }

        [TestMethod, Description("Reading CSV data from text file and parsing data from empty string array. Throw ArgumentException")]
        public void ParseCSVDataFromFile_ArgumentException()
        {
            Assert.AreNotEqual(null, _reader.ReadingCSVDataFromTextFile(_figuresFilePath));
            Assert.ThrowsException<ArgumentException>(() => MyParser.ParseCSVDataFromFile(new List<string>()));
        }

        [TestMethod, Description("Reading CSV data from text file and parsing data from string array. Positive test result")]
        public void ParseCSVDataFromFile_PositiveTestResult() 
        {
            Assert.AreNotEqual(null, _reader.ReadingCSVDataFromTextFile(_figuresFilePath));
            Assert.AreNotEqual(null, MyParser.ParseCSVDataFromFile(_reader.ReadingCSVDataFromTextFile(_figuresFilePath)));
        }

        [DataTestMethod, Description("Reading CSV data from text file, parsing data from string array and searchig equal shapes. Positive test result")]
        [DynamicData(nameof(GetFigures), DynamicDataSourceType.Method)]
        public void FindEqualShapes_PositiveTestResult(params Polygon[] shapes) 
        {
            Assert.AreNotEqual(null, _reader.ReadingCSVDataFromTextFile(_figuresFilePath));

            List<Polygon> shapesFromFile = MyParser.ParseCSVDataFromFile(_reader.ReadingCSVDataFromTextFile(_figuresFilePath));
            Assert.AreNotEqual(null, shapesFromFile);

            List<Polygon> eqaulShapes = (from Polygon shape in shapes
                                         where shapesFromFile.Any(s => s.Equals(shape))
                                         select shapesFromFile.FirstOrDefault(s => s.Equals(shape))).ToList();
            Assert.IsTrue(eqaulShapes.Count != 0);
        }

        /// <summary>
        /// Create polygon array of different shapes
        /// </summary>
        /// <returns>IEnumerable<Polygon[]></returns>
        private static IEnumerable<Polygon[]> GetFigures()
        {
            yield return new Rectangle[] {
                new Rectangle("Rectangle", (8, 19), (16, 34), (46, 16), (38, 2)),
                new Rectangle("Rectangle", (10, 20), (14, 38), (60, 19), (39, 4)),
                new Rectangle("Rectangle", (11, 22), (15, 31), (51, 22), (30, 7)),
                new Rectangle("Rectangle", (8, 19), (16, 34), (46, 16), (38, 2)),
            };
            yield return new Triangle[] {
                new Triangle("Triangle", (15, 15), (47, 40), (65, 20)),
                new Triangle("Triangle", (14, 17), (41, 52), (61, 19))
            };
            yield return new Square[] {
                new Square("Square", (6, 3), (6, 27), (30, 27), (30, 3)),
                new Square("Square", (7, 2), (5, 30), (31, 27), (30, 3))
            };
        }
    }
}