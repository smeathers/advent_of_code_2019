using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// input = 347312-805915
// part1 = 594
// part2 = 

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int input = 347312, inputStop = 805915;
            int passwordCount = 0;
            

            for (; input <= inputStop; input++)
            {
                //Console.WriteLine(input);
                if (DecreaseCheck(input))
                {
                    Console.WriteLine(input);
                    passwordCount++;
                }
                //input.ToString().
            }
            Console.WriteLine("Password Count: " + passwordCount);
        }

        static bool DecreaseCheck(int input)
        {
            //int? previous = null;
            bool doubleCheck = false;
            List<int> previous = new List<int>();
            //List<int> previous;

            foreach (char number in input.ToString().ToCharArray())
            {
                //previous.Add(number);


                if (previous.Count == 0)
                    previous.Add(int.Parse(number.ToString()));
                else
                {
                    if (int.Parse(number.ToString()) >= previous.Last())
                    {

                        //Console.WriteLine();



                        if (previous.Last() == int.Parse(number.ToString()))
                        {
                            doubleCheck = true;
                        }

                        previous.Add(int.Parse(number.ToString()));
                    }
                    else
                        return false;
                }

            }
            if (doubleCheck)
            {
                if (Regex.Matches(input.ToString(), @"^(?=[0-9]{6}$)(?=(?:.*([0-9])(?!\1))?([0-9])\2(?!\2))(?:0|1(?!0)|2(?![01])|3(?![0-2])|4(?![0-3])|5(?![0-4])|6(?![0-5])|7(?![0-6])|8(?![0-7])|9(?![0-8]))+$").Count() > 0)
                {
                    return true;
                }
            }
            return false;

        }

    }
}
