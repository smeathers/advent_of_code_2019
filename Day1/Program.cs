using System;
using System.IO;

//https://adventofcode.com/2019/day/1

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            int FuelCount = 0;
            var lines = File.ReadLines("input.txt");

            Console.WriteLine(CalculateFuel(2));

            foreach (var line in lines)
            {

                int RequiredFuel = CalculateFuel(int.Parse(line));

                FuelCount = FuelCount + RequiredFuel;

                bool flag = true;

                //Maths for Fuel for Fuel.
                int InterFuel = 0;

                while (flag)
                {
                    Console.WriteLine("Beep!");
                    InterFuel = CalculateFuel(RequiredFuel);
                    if (InterFuel == 0)
                        flag = false;
                    else
                    {
                        FuelCount = FuelCount + InterFuel;
                        RequiredFuel = InterFuel;
                    }
                }
            }

            Console.WriteLine("Fuel Needed: " + FuelCount);
        }

        static int CalculateFuel(int mass)
        {
            int ReturnValue;
            ReturnValue = (mass / 3) - 2;
            if (ReturnValue < 0)
                ReturnValue = 0;
            return ReturnValue;
        }
    }
}
