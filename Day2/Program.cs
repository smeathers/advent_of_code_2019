using System;
using System.IO;

// https://adventofcode.com/2019/day/2
// Part 1 = 5098658
// Part 2 = Noun:50 Verb:64

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
                    //else
                    //    Console.WriteLine(output);
                }


            //Console.WriteLine(ProgramRun("12","2"));
        }

        static string ProgramRun(string noun, string verb) { 
            var lines = File.ReadAllLines("input.txt");

            string output = "";

            foreach(var line in lines)
            {
                var addressSpace = line.Split(',');

                // overide start values
                //positions[1] = "12";
                //positions[2] = "2";
                addressSpace[1] = noun;
                addressSpace[2] = verb;



                for (int instructionPointer = 0; instructionPointer < addressSpace.Length;)// instructionPointer += 4)
                {
                    int opcode = int.Parse(addressSpace[instructionPointer]);
                    //int value1 = int.Parse(addressSpace[int.Parse(addressSpace[instructionPointer + 1])]);
                    //int value2 = int.Parse(addressSpace[int.Parse(addressSpace[instructionPointer + 2])]);
                    //int storeAddress = int.Parse(addressSpace[instructionPointer + 3]);

                    //Console.WriteLine(instructionPointer);

                    switch (opcode)
                    {
                        case 1:
                            //add
                            addressSpace[int.Parse(addressSpace[instructionPointer + 3])] = (int.Parse(addressSpace[int.Parse(addressSpace[instructionPointer + 1])]) + int.Parse(addressSpace[int.Parse(addressSpace[instructionPointer + 2])])).ToString();
                            instructionPointer += 4;
                            //addressSpace[storeAddress] = (value1 + value2).ToString();
                            break;
                        case 2:
                            //multiply
                            addressSpace[int.Parse(addressSpace[instructionPointer + 3])] = (int.Parse(addressSpace[int.Parse(addressSpace[instructionPointer + 1])]) * int.Parse(addressSpace[int.Parse(addressSpace[instructionPointer + 2])])).ToString();
                            instructionPointer += 4;
                            //addressSpace[storeAddress] = (value1 * value2).ToString();
                            break;
                        case 99:
                            //print and halt
                            output = addressSpace[0];
                            //Console.WriteLine(output);
                            instructionPointer = addressSpace.Length;
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
