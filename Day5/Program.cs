using System;
using System.IO;

// https://adventofcode.com/2019/day/5
// Part 1 = 5098658
// Part 2 = 5064

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {

            //for (int noun = 0; noun <= 99; noun++)
            //    for (int verb = 0; verb <= 99; verb++)
            //    {
            //        string output = ProgramRun(noun.ToString(), verb.ToString());
            //        //Console.WriteLine("Noun: " + noun + " Verb: " + verb + " Output: " + output);
            //        if (output == "19690720")
            //        {
            //            Console.WriteLine("Noun: " + noun + " Verb: " + verb + " Done");
            //            Console.ReadKey();
            //        }
            //    }


            Console.WriteLine(ProgramRun("12","2"));
        }

        static string ProgramRun(string noun, string verb)
        {
            var lines = File.ReadAllLines("input.txt");

            string output = "";

            foreach (var line in lines)
            {
                var memory = line.Split(',');

                // overide start values
                //positions[1] = "12";
                //positions[2] = "2";
                //memory[1] = noun;
                //memory[2] = verb;

                int? register = null;

                for (int instructionPointer = 0; instructionPointer < memory.Length;)//; instructionPointer += 4)
                {
                    int opcode = int.Parse(memory[instructionPointer]);
                    //int value1 = int.Parse(addressSpace[int.Parse(addressSpace[instructionPointer + 1])]);
                    //int value2 = int.Parse(addressSpace[int.Parse(addressSpace[instructionPointer + 2])]);
                    //int storeAddress = int.Parse(addressSpace[instructionPointer + 3]);

                    switch (opcode)
                    {
                        case 1:
                            //add
                            memory[int.Parse(memory[instructionPointer + 3])] = (int.Parse(memory[int.Parse(memory[instructionPointer + 1])]) + int.Parse(memory[int.Parse(memory[instructionPointer + 2])])).ToString();
                            instructionPointer += 4;
                            //addressSpace[storeAddress] = (value1 + value2).ToString();
                            break;
                        case 2:
                            //multiply
                            memory[int.Parse(memory[instructionPointer + 3])] = (int.Parse(memory[int.Parse(memory[instructionPointer + 1])]) * int.Parse(memory[int.Parse(memory[instructionPointer + 2])])).ToString();
                            instructionPointer += 4;
                            //addressSpace[storeAddress] = (value1 * value2).ToString();
                            break;
                        case 3:
                            //save / input
                            Console.Write("input: ");
                            register = int.Parse(Console.ReadLine());
                            memory[int.Parse(memory[instructionPointer + 1])] = register.ToString();
                            instructionPointer += 2;
                            break;
                        case 4:
                            //load / output
                            register = int.Parse(memory[int.Parse(memory[instructionPointer + 1])]);
                            Console.WriteLine("OpCode 4: " + register);
                            instructionPointer += 2;
                            break;

                        case 99:
                            //print and halt
                            output = memory[0];
                            instructionPointer = memory.Length;
                            break;
                        default:
                            break;
                    }

                }

            }
            return output;
        }
    }
}
