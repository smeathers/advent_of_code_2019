using System;

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
                    Console.WriteLine("     " + input);
                    passwordCount++;
                }
                //input.ToString().
            }
            Console.WriteLine("Password Count: " + passwordCount);
        }

        static bool DecreaseCheck(int input)
        {
            int? previous = null;
            bool doubleCheck = false;

            foreach (char number in input.ToString().ToCharArray())
            {
                if (previous == null)
                    previous = int.Parse(number.ToString());
                else 
                {
                    if (int.Parse(number.ToString()) >= previous)
                    {
                        if (previous == int.Parse(number.ToString()))
                        {
                            doubleCheck = true;
                        }
                            
                        previous = int.Parse(number.ToString());
                    }
                    else
                        return false;
                }


            }
            return doubleCheck;

        }
    }
}
