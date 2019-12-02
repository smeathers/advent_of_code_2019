using System;
using System.IO;

//https://adventofcode.com/2019/day/2

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");

            foreach(var line in lines)
            {
                var positions = line.Split(',');
                
                // overide start values
                positions[1] = "12";
                positions[2] = "2";


                for (int i = 0; i < positions.Length; i = i + 4)
                {
                    int opcode = int.Parse(positions[i]);
                    int value1 = int.Parse(positions[int.Parse(positions[i + 1])]);
                    int value2 = int.Parse(positions[int.Parse(positions[i + 2])]);
                    int storeAddress = int.Parse(positions[i + 3]);
                    switch (opcode)
                    {
                        case 1:
                            //add
                            positions[storeAddress] = (value1 + value2).ToString();
                            break;
                        case 2:
                            //multiply
                            positions[storeAddress] = (value1 * value2).ToString();
                            break;
                        case 99:
                            //print and halt
                            Console.WriteLine(positions[0]);
                            Console.ReadKey();
                            break;
                        default:
                            break;
                    }

                }

            }
        }
    }
}
