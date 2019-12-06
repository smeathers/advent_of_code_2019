using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

// https://adventofcode.com/2019/day/6

namespace Day6
{

    public class Node<T>
    {
        public Node<T> First, Second;
        public T Name;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Node<string> planets = new Node<string>();
            ///planets.Name = "COM";

            var lines = new List<string>(File.ReadAllLines("input.txt"));

            string nextNode = "COM";
            Console.WriteLine(nextNode);

            while (lines.Count() > 0)
            {

            

                foreach (var line in lines)
                {
                    int joinCount = 0;
                    var values = line.Split(")");
                    if (values[0] == nextNode)
                    {
                        //Console.WriteLine(values[1]);
                        nextNode = values[1];
                        //lines.Remove(line);
                        joinCount++;
                        Console.WriteLine(joinCount + " : " + values[1]);
                        if (joinCount > 1)
                            Console.ReadKey();
                        //planets.Name = nextNode;
                        //break;
                    }
                    //else
                    //    Console.WriteLine("Not Found!");

                }
            }
        }
    }
}
