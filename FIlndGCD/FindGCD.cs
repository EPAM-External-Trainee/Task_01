using System;
using System.Diagnostics;

namespace FindGCDTask
{
    /// <summary>
    /// A class that implements GCD finding algorithms
    /// </summary>
    /// <remarks>
    /// The class provides the ability to find the GCD of integers and calculate the runtime using cut algorithms
    /// </remarks>
    public static class FindGCD
    {
        /// <summary>
        /// Finding GCD using the Euclidean algorithm for two numbers
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <returns>Greatest common divisor</returns>
        public static uint GCDByEuclid(uint num1, uint num2)
        {
            if(num1 == 0 || num2 == 0)
            {
                throw new ArgumentException("All numbers must be greater than 0");
            }

            if (num1 == num2)
            {
                return num1;
            }

            while (num2 != 0)
            {
                uint tmp = num2;
                num2 = num1 % num2;
                num1 = tmp;
            }
            return num1;
        }

        /// <summary>
        /// Finding GCD using the Euclidean algorithm for three numbers 
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <param name="num3">Third number</param>
        /// <returns>Greatest common divisor</returns>
        public static uint GCDByEuclid(uint num1, uint num2, uint num3) => GCDByEuclid(GCDByEuclid(num1, num2), num3);

        /// <summary>
        /// Finding GCD using the Euclidean algorithm for four numbers
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <param name="num3">Third number</param>
        /// <param name="num4">Fourth number</param>
        /// <returns>Greatest common divisor</returns>
        public static uint GCDByEuclid(uint num1, uint num2, uint num3, uint num4) => GCDByEuclid(GCDByEuclid(num1, num2), GCDByEuclid(num3, num4));

        /// <summary>
        /// Finding GCD using the Euclidean algorithm for five numbers
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <param name="num3">Third number</param>
        /// <param name="num4">Fourth number</param>
        /// <param name="num5">Fifth number</param>
        /// <returns>Greatest common divisor</returns>
        public static uint GCDByEuclid(uint num1, uint num2, uint num3, uint num4, uint num5) => GCDByEuclid(GCDByEuclid(GCDByEuclid(num1, num2), GCDByEuclid(num3, num4)), num5);

        /// <summary>
        /// Finding GCD using the Euclid algorithm for two numbers and calculating the execution time
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <param name="time">Execution time</param>
        /// <returns>Greatest common divisor</returns>
        public static uint GCDByEuclid(uint num1, uint num2, out TimeSpan time)
        {
            Stopwatch startTime = Stopwatch.StartNew();
            time = new TimeSpan();

            // I don't call the already written method, because there will be an incorrect measurement of the execution time.
            
            if (num1 == 0 || num2 == 0)
            {
                throw new ArgumentException("All numbers must be greater than 0");
            }

            if (num1 == num2)
            {
                startTime.Stop();
                time = startTime.Elapsed;
                return num1;
            }

            while (num2 != 0)
            {
                uint temp = num2;
                num2 = num1 % num2;
                num1 = temp;
            }

            startTime.Stop();
            time = startTime.Elapsed;
            return num1;
        }

        /// <summary>
        /// Finding GCD using Stein's algorithm for two numbers and calculating the execution time
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <param name="time">Execution time</param>
        /// <returns>Greatest common divisor</returns>
        public static uint GCDByStein(uint num1, uint num2, out TimeSpan time)
        {
            Stopwatch startTime = Stopwatch.StartNew();
            time = new TimeSpan();

            if (num1 == 0 || num2 == 0)
            {
                throw new ArgumentException("All numbers must be greater than 0");
            }

            if (num1 == num2)
            {
                startTime.Stop();
                time = startTime.Elapsed;
                return num1;
            }

            int i;
            for (i = 0; ((num1 | num2) & 1) == 0; ++i)
            {
                num1 >>= 1;
                num2 >>= 1;
            }

            while ((num1 & 1) == 0)
            {
                num1 >>= 1;
            }

            do
            {
                while ((num2 & 1) == 0)
                {
                    num2 >>= 1;
                }

                if (num1 > num2)
                {
                    uint temp = num1;
                    num1 = num2;
                    num2 = temp;
                }

                num2 -= num1;
            } while (num2 != 0);

            startTime.Stop();
            time = startTime.Elapsed;
            return num1 << i;
        }

        /// <summary>
        /// Comparison of the execution time finding GCD for two numbers using the Euclid and Stein algorithms
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <returns>The time spent on finding the GCD by the Euclidean, Stein algorithm</returns>
        public static (TimeSpan euclidTimeGCD, TimeSpan steinsTimeGCD) CompareExecMethodsTime(uint num1 = 10, uint num2 = 20)
        {
            GCDByEuclid(num1, num2, out TimeSpan timeEuclidGCD);
            GCDByStein(num1, num2, out TimeSpan timeSteinsGCD);
            return (euclidTimeGCD: timeEuclidGCD, steinsTimeGCD: timeSteinsGCD);
        }
    }
}