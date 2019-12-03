using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var lines = File.ReadAllLines("input.txt");

            var firstPath = Plot(lines[0]);
            var secondPath = Trace(lines[1], firstPath);



    //plot

    //check for overlaps

    //maths

    //closest

        }

        static List<string> Plot(string line)
        {
            //List<longLat> path = new List<longLat>();
            List<string> path = new List<string>();
            //longLat Location = new longLat();
            //Location.x = 0;
            //Location.y = 0;
            path.Add("0,0");

            foreach (var instruction in line.Split(','))
            {
                string Direction = instruction.Substring(0, 1);
                int Distnace = int.Parse(instruction.Substring(1));

                for (int i = 1; i <= Distnace; i++)
                {
                    switch (Direction)
                    {
                        case "R":
                            // x-
                            path.Add((int.Parse(path.Last().Split(',')[0]) - 1).ToString() + "," + path.Last().Split(',')[1]);
                            break;
                        case "L":
                            // x+
                            path.Add((int.Parse(path.Last().Split(',')[0]) + 1).ToString() + "," + path.Last().Split(',')[1]);
                            break;
                        case "U":
                            // y+
                            path.Add((path.Last().Split(',')[0]) + "," + (int.Parse(path.Last().Split(',')[1]) + 1).ToString());
                            break;
                        case "D":
                            // y-
                            path.Add((path.Last().Split(',')[0]) + "," + (int.Parse(path.Last().Split(',')[1]) - 1).ToString());
                            break;
                        default:
                            break;
                    }
                    //path.Add(loc);
                }
            }

            return path;
        }

        static List<string> Trace(string line, List<string> firstPath)
        {
            List<string> path = new List<string>();
            path.Add("0,0");
            int x = 0, y = 0;
            int ?DistanceFromOrigin = null;

            foreach (var instruction in line.Split(','))
            {
                string Direction = instruction.Substring(0, 1);
                int Distnace = int.Parse(instruction.Substring(1));

                for (int i = 1; i <= Distnace; i++)
                {
                    switch (Direction)
                    {
                        case "R":
                            // x-
                            x--;
                            //path.Add((int.Parse(path.Last().Split(',')[0]) - 1).ToString() + "," + path.Last().Split(',')[1]);
                            break;
                        case "L":
                            // x+
                            x++;
                            //path.Add((int.Parse(path.Last().Split(',')[0]) + 1).ToString() + "," + path.Last().Split(',')[1]);
                            break;
                        case "U":
                            // y+
                            y++;
                            //path.Add((path.Last().Split(',')[0]) + "," + (int.Parse(path.Last().Split(',')[1]) + 1).ToString());
                            break;
                        case "D":
                            // y-
                            y--;
                            //path.Add((path.Last().Split(',')[0]) + "," + (int.Parse(path.Last().Split(',')[1]) - 1).ToString());
                            break;
                        default:
                            break;
                    }
                    //path.Add(loc);
                    foreach (string location in firstPath)
                    {
                        if (location == x.ToString() + "," + y.ToString())
                        {
                            int dist = System.Math.Abs(x) + System.Math.Abs(y);
                            if (dist < DistanceFromOrigin || DistanceFromOrigin is null)
                            {
                                Console.WriteLine(location + " : " + dist);
                                DistanceFromOrigin = dist;
                            }
                        }
                    }
                }
            }
            return path;
        }

    }
}
