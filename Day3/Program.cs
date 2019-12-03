using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    class Program
    {

        struct longLat
        {
            public int x;
            public int y;
        }
        

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var lines = File.ReadAllLines("input.txt");

            
            //List<int[2]> path2 = new List<int[2]>();
            //longLat Location = new longLat();
            //Location.x = 0;
            //Location.y = 0;
            //path.Add(Location);

            var firstPath = Plot(lines[0]);
            Trace(lines[1], firstPath);

            foreach (var line in lines)
            {
                
            }


    //plot

    //check for overlaps

    //maths

    //closest

        }

        static List<longLat> Plot(string line)
        {
            //List<longLat> path = new List<longLat>();
            List<longLat> path = new List<longLat>();
            longLat Location = new longLat();
            Location.x = 0;
            Location.y = 0;
            path.Add(Location);

            foreach (var instruction in line.Split(','))
            {
                string Direction = instruction.Substring(0, 1);
                int Distnace = int.Parse(instruction.Substring(1));
                longLat loc = new longLat();

                for (int i = 1; i <= Distnace; i++)
                {
                    switch (Direction)
                    {
                        case "R":
                            // x-
                            loc.x = path.Last().x - 1;
                            loc.y = path.Last().y;
                            break;
                        case "L":
                            // x+
                            loc.x = path.Last().x + 1;
                            loc.y = path.Last().y;
                            break;
                        case "U":
                            // y+
                            loc.x = path.Last().x;
                            loc.y = path.Last().y + 1;
                            break;
                        case "D":
                            // y-
                            loc.x = path.Last().x;
                            loc.y = path.Last().y - 1;
                            break;
                        default:
                            break;
                    }
                    path.Add(loc);
                }
            }

            return path;
        }

        static List<longLat> Trace(string line, List<longLat> firstPath)
        {
            List<longLat> path = new List<longLat>();
            longLat Location = new longLat();
            Location.x = 0;
            Location.y = 0;
            path.Add(Location);

            foreach (var instruction in line.Split(','))
            {
                string Direction = instruction.Substring(0, 1);
                int Distnace = int.Parse(instruction.Substring(1));
                longLat loc = new longLat();

                for (int i = 1; i <= Distnace; i++)
                {
                    switch (Direction)
                    {
                        case "R":
                            // x-
                            loc.x = path.Last().x - 1;
                            loc.y = path.Last().y;
                            break;
                        case "L":
                            // x+
                            loc.x = path.Last().x + 1;
                            loc.y = path.Last().y;
                            break;
                        case "U":
                            // y+
                            loc.x = path.Last().x;
                            loc.y = path.Last().y + 1;
                            break;
                        case "D":
                            // y-
                            loc.x = path.Last().x;
                            loc.y = path.Last().y - 1;
                            break;
                        default:
                            break;
                    }
                    path.Add(loc);
                    int count = firstPath.BinarySearch(loc);
                    if (count > 0)
                        Console.WriteLine();
                }
            }
            return path;
        }

    }
}
