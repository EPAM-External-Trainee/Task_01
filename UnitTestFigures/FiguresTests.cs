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

        [TestMethod]
        public void ReadingCSVDataFromTextFile_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _reader.ReadingCSVDataFromTextFile(null));
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("NonexistentPath")]
        public void ReadingCSVDataFromTextFile_Exception(string pathToFile)
        {
            Assert.ThrowsException<Exception>(() => _reader.ReadingCSVDataFromTextFile(pathToFile));
        }

        [TestMethod]
        public void ReadingCSVDataFromTextFile_PositiveTestResult()
        {
            Assert.AreNotEqual(null, _reader.ReadingCSVDataFromTextFile(_figuresFilePath));
        }

        [TestMethod]
        public void ParseStringArrayContainigCoords_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => MyParser.ParseStringArrayContainigCoords(null));
        }

        [TestMethod]
        public void ParseStringArrayContainigCoords_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => MyParser.ParseStringArrayContainigCoords(new string[0]));
        }

        [TestMethod]
        public void ParseCSVDataFromFile_ArgumentNullException()
        {
            Assert.AreNotEqual(null, _reader.ReadingCSVDataFromTextFile(_figuresFilePath));
            Assert.ThrowsException<ArgumentNullException>(() => MyParser.ParseCSVDataFromFile(null));
        }

        [TestMethod]
        public void ParseCSVDataFromFile_ArgumentException()
        {
            Assert.AreNotEqual(null, _reader.ReadingCSVDataFromTextFile(_figuresFilePath));
            Assert.ThrowsException<ArgumentException>(() => MyParser.ParseCSVDataFromFile(new List<string>()));
        }

        [TestMethod]
        public void ParseCSVDataFromFile_PositiveTestResult() 
        {
            Assert.AreNotEqual(null, _reader.ReadingCSVDataFromTextFile(_figuresFilePath));
            Assert.AreNotEqual(null, MyParser.ParseCSVDataFromFile(_reader.ReadingCSVDataFromTextFile(_figuresFilePath)));
        }

        [DataTestMethod]
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

        private static IEnumerable<Polygon[]> GetFigures()
        {
            yield return new Rectangle[] {
                new Rectangle("Rectangle1", (8, 19), (16, 34), (46, 16), (38, 2)),
                new Rectangle("Rectangle2", (10, 20), (14, 38), (60, 19), (39, 4)),
                new Rectangle("Rectangle3", (11, 22), (15, 31), (51, 22), (30, 7)),
                new Rectangle("Rectangle4", (8, 19), (16, 34), (46, 16), (38, 2)),
            };
            yield return new Triangle[] {
                new Triangle("Triangle1", (15, 15), (47, 40), (65, 20)),
                new Triangle("Triangle2", (14, 17), (41, 52), (61, 19))
            };
            yield return new Square[] {
                new Square("Square", (6, 3), (6, 27), (30, 27), (30, 3)),
                new Square("Square", (7, 2), (5, 30), (31, 27), (30, 3))
            };
        }
    }
}