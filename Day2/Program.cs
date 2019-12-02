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
                //positions[1] = "12";
                //positions[2] = "2";


                for (int instructionPointer = 0; instructionPointer < positions.Length; instructionPointer += 4)
                {
                    int opcode = int.Parse(positions[instructionPointer]);
                    int noun = int.Parse(positions[int.Parse(positions[instructionPointer + 1])]);
                    int verb = int.Parse(positions[int.Parse(positions[instructionPointer + 2])]);
                    int storeAddress = int.Parse(positions[instructionPointer + 3]);
                    switch (opcode)
                    {
                        case 1:
                            //add
                            positions[storeAddress] = (noun + verb).ToString();
                            break;
                        case 2:
                            //multiply
                            positions[storeAddress] = (noun * verb).ToString();
                            break;
                        case 99:
                            //print and halt
                            Console.WriteLine(positions[0]);
                            Console.ReadKey();
                            break;
                        default:
                            int value = (100 * noun + verb);
                            if (value == 19690720)
                                Console.WriteLine();
                            positions[storeAddress] = (100 * noun + verb).ToString();
                            break;
                    }

                }

            }
        }
    }
}
