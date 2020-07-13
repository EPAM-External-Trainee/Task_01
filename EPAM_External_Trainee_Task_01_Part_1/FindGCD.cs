using System;
using System.Diagnostics;

namespace EPAM_External_Trainee_Task_01_Part_1.Models
{
    internal static class FindGCD
    {
        internal static int GCDByEuclid(int num1, int num2)
        {
            while (num2 != 0)
            {
                int temp = num2;
                num2 = num1 % num2;
                num1 = temp;
            }
            return Math.Abs(num1);
        }

        internal static int GCDByEuclid(int num1, int num2, int num3) => GCDByEuclid(GCDByEuclid(num1, num2), num3);

        internal static int GCDByEuclid(int num1, int num2, int num3, int num4) => GCDByEuclid(GCDByEuclid(num1, num2), GCDByEuclid(num3, num4));

        internal static int GCDByEuclid(int num1, int num2, int num3, int num4, int num5) => GCDByEuclid(GCDByEuclid(GCDByEuclid(num1, num2), GCDByEuclid(num3, num4)), num5);

        internal static int GCDByEuclid(int num1, int num2, out TimeSpan time)
        {
            Stopwatch startTime = Stopwatch.StartNew();
            time = new TimeSpan();
            while (num2 != 0)
            {
                int temp = num2;
                num2 = num1 % num2;
                num1 = temp;
            }

            startTime.Stop();
            time = startTime.Elapsed;
            return Math.Abs(num1);
        }

        internal static int BinaryGCD(int num1, int num2, out TimeSpan time)
        {
            Stopwatch startTime = Stopwatch.StartNew();
            time = new TimeSpan();

            if (num1 == 0)
            {
                startTime.Stop();
                time = startTime.Elapsed;
                return num2;
            }

            if (num2 == 0)
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
                    num1 = num1 + num2;
                    num2 = num2 - num1;
                    num1 = num1 - num2;
                }

                num2 = (num2 - num1);
            } while (num2 != 0);

            startTime.Stop();
            time = startTime.Elapsed;
            return num1 << i;
        }

        internal static (TimeSpan euclidGCD, TimeSpan binaryGCD) CompareExecMethodsTime(int num1 = 10, int num2 = 20)
        {
            TimeSpan timeEuclidGCD, timeBinaryGCD;
            GCDByEuclid(num1, num2, out timeEuclidGCD);
            BinaryGCD(num1, num2, out timeBinaryGCD);
            return (euclidGCD: timeEuclidGCD, binaryGCD: timeBinaryGCD);
        }
    }
}