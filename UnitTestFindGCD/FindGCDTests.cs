using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindGCDTask;
using System.Collections.Generic;

namespace UnitTestForFindGCD
{
    [TestClass]
    public class FindGCDTests
    {
        private TimeSpan _time;

        [DataTestMethod]
        [DataRow(0u, 0u)]
        public void GCDByEuclid_TakeZerosParameters_ThrowsArgumentException(uint num1, uint num2)
        {
            Assert.ThrowsException<ArgumentException>(() => FindGCD.GCDByEuclid(num1, num2));
        }

        [DataTestMethod]
        [DataRow(0u, 5u)]
        [DataRow(5u, 0u)]
        public void GCDByEuclid_TakeZeroParameters_ThrowsArgumentException(uint num1, uint num2)
        {
            Assert.ThrowsException<ArgumentException>(() => FindGCD.GCDByEuclid(num1, num2));
        }

        [DataTestMethod]
        [DataRow(10u, 50u, 10u)]
        [DataRow(20u, 21u, 1u)]
        [DataRow(1500u, 3000u, 1500u)]
        [DataRow(22u, 15u, 1u)]
        public void GCDByEuclid_TakesTwoParameters_PositiveTestResult(uint num1, uint num2, uint expected)
        {
            Assert.AreEqual(expected, FindGCD.GCDByEuclid(num1, num2));
        }

        [DataTestMethod]
        [DataRow(10u, 50u, 15u, 5u)]
        [DataRow(20u, 40u, 60u, 20u)]
        [DataRow(1500u, 300u, 500u, 100u)]
        [DataRow(10u, 20u, 30u, 10u)]
        public void GCDByEuclid_TakesThreeParameters_PositiveTestResult(uint num1, uint num2, uint num3, uint expected) => Assert.AreEqual(expected, FindGCD.GCDByEuclid(num1, num2, num3));

        [DataTestMethod]
        [DataRow(10u, 50u, 15u, 25u, 5u)]
        [DataRow(20u, 40u, 60u, 10u, 10u)]
        [DataRow(1500u, 300u, 500u, 50u, 50u)]
        [DataRow(15u, 30u, 60u, 90u, 15u)]
        public void GCDByEuclid_TakesFourParameters_PositiveTestResult(uint num1, uint num2, uint num3, uint num4, uint expected)
        {
            Assert.AreEqual(expected, FindGCD.GCDByEuclid(num1, num2, num3, num4));
        }

        [DataTestMethod]
        [DataRow(15u, 30u, 60u, 90u, 3u, 3u)]
        [DataRow(1500u, 300u, 500u, 50u, 25u, 25u)]
        [DataRow(6u, 5u, 4u, 3u, 2u, 1u)]
        [DataRow(15u, 30u, 60u, 90u, 15u, 15u)]
        public void GCDByEuclid_TakesFiveParameters_PositiveTestResult(uint num1, uint num2, uint num3, uint num4, uint num5, uint expected)
        {
            Assert.AreEqual(expected, FindGCD.GCDByEuclid(num1, num2, num3, num4, num5));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetDataForGCD), DynamicDataSourceType.Method)]
        public void GCDByEuclid_TakesTwoNumsAndTimeParameters_PositiveTestResult(uint num1, uint num2, uint expected)
        {
            uint actual = FindGCD.GCDByEuclid(num1, num2, out _time);
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(_time != TimeSpan.FromSeconds(0));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetDataForGCD), DynamicDataSourceType.Method)]
        public void GCDByStein_TakesTwoNumsAndTimeParameters_PositiveTestResult(uint num1, uint num2, uint expected)
        {
            uint actual = FindGCD.GCDByStein(num1, num2, out _time);
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(_time != TimeSpan.FromSeconds(0));
        }

        private static IEnumerable<object[]> GetDataForGCD()
        {
            yield return new object[] { 10u, 50u, 10u };
            yield return new object[] { 20u, 21u, 1u };
            yield return new object[] { 1500u, 3000u, 1500u };
            yield return new object[] { 22u, 15u, 1u };
        }

        [DataTestMethod]
        [DataRow(10u, 50u)]
        [DataRow(20u, 21u)]
        [DataRow(1500u, 3000u)]
        [DataRow(22u, 15u)]
        public void CompareExecMethodsTime_TakesTwoParameters_PositiveTestResult(uint num1, uint num2)
        {
            Assert.IsTrue(FindGCD.CompareExecMethodsTime(num1, num2) != (TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(0)));
        }
    }
}