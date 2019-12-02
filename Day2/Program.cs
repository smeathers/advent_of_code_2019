using System;
using System.IO;

//https://adventofcode.com/2019/day/2

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int noun = 0; noun <= 99; noun++)
                for (int verb = 0; verb <= 99; verb++)
                {
                    string output = ProgramRun(noun.ToString(), verb.ToString());
                    //Console.WriteLine("Noun: " + noun + " Verb: " + verb + " Output: " + output);
                    if (output == "19690720")
                    {
                        Console.WriteLine("Noun: " + noun + " Verb: " + verb + " Done");
                        Console.ReadKey();
                    }
                }


            //Console.WriteLine(ProgramRun("12","2"));
        }

        static string ProgramRun(string noun, string verb) { 
            var lines = File.ReadAllLines("input.txt");

            string output = "";

            foreach(var line in lines)
            {
                var positions = line.Split(',');

                // overide start values
                //positions[1] = "12";
                //positions[2] = "2";
                positions[1] = noun;
                positions[2] = verb;



                for (int instructionPointer = 0; instructionPointer < positions.Length; instructionPointer += 4)
                {
                    int opcode = int.Parse(positions[instructionPointer]);
                    int value1 = int.Parse(positions[int.Parse(positions[instructionPointer + 1])]);
                    int value2 = int.Parse(positions[int.Parse(positions[instructionPointer + 2])]);
                    int storeAddress = int.Parse(positions[instructionPointer + 3]);
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
                            output = positions[0];
                            //Console.WriteLine(output);
                            instructionPointer = positions.Length;
                            //if (output == "19690720")
                            //    Console.ReadKey();
                            break;
                        default:
                            //int value = (100 * noun + verb);
                            //if (value == 19690720)
                            //    Console.WriteLine();
                            //positions[storeAddress] = (100 * noun + verb).ToString();
                            break;
                    }

                }
                
            }
            return output;
        }
    }
}
