using EPAM_External_Trainee_Task_01_Part_1.Models;
using System;

namespace EPAM_External_Trainee_Task_01_Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            (TimeSpan euclidGCD, TimeSpan binaryGCD) = FindGCD.CompareExecMethodsTime(10, 10);
            Console.WriteLine($"Время, затраченное на нахождения НОД по алгоритму Евклида: {euclidGCD}, по алгоритму Стейна: {binaryGCD}");
            //Console.WriteLine(FindGCD.GCDByEuclid(1, 2, 3, 4, 5));
            Console.ReadLine();
        }
    }
}