using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{

    public class Location
    {
        public int ?X;
        public int ?Y;
        public int ?Distance;

        public Location(int ?x = null, int ?y = null, int ?distance = null)
        {
            X = x;
            Y = y;
            Distance = distance;
        }

    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var lines = File.ReadAllLines("input.txt");

            var firstPath = Plot(lines[0]);
            Trace(lines[1], firstPath);



    //plot

    //check for overlaps

    //maths

    //closest

        }

        static List<Location> Plot(string line)
        {
            List<Location> list = new List<Location>();
            List<Location> path = list;
            path.Add(new Location(0,0,0));
            

            foreach (var instruction in line.Split(','))
            {
                string Direction = instruction.Substring(0, 1);
                int Distnace = int.Parse(instruction.Substring(1));

                for (int i = 1; i <= Distnace; i++)
                {
                    Location loc = new Location();
                    switch (Direction)
                    {
                        case "R":
                            // x-
                            loc.X = path.Last().X - 1;
                            loc.Y = path.Last().Y;
                            loc.Distance = path.Last().Distance +1;;
                            break;
                        case "L":
                            // x+
                            loc.X = path.Last().X + 1;
                            loc.Y = path.Last().Y;
                            loc.Distance = path.Last().Distance +1;;
                            break;
                        case "U":
                            // y+
                            loc.X = path.Last().X;
                            loc.Y = path.Last().Y + 1;
                            loc.Distance = path.Last().Distance +1;;
                            break;
                        case "D":
                            // y-
                            loc.X = path.Last().X;
                            loc.Y = path.Last().Y - 1;
                            loc.Distance = path.Last().Distance +1;;
                            break;
                        default:
                            break;
                    }
                    path.Add(loc);
                }
            }

            return path;
        }

        static List<Location> Trace(string line, List<Location> firstPath)
        {
            List<Location> list = new List<Location>();
            List<Location> path = list;
            path.Add(new Location(0,0,0));
            int? DistanceFromOrigin = null;
            int? CombinedDistance = null;
            

            foreach (var instruction in line.Split(','))
            {
                string Direction = instruction.Substring(0, 1);
                int Distnace = int.Parse(instruction.Substring(1));

                for (int i = 1; i <= Distnace; i++)
                {
                    Location loc = new Location();
                    switch (Direction)
                    {
                        case "R":
                            // x-
                            loc.X = path.Last().X - 1;
                            loc.Y = path.Last().Y;
                            loc.Distance = path.Last().Distance +1;
                            break;
                        case "L":
                            // x+
                            loc.X = path.Last().X + 1;
                            loc.Y = path.Last().Y;
                            loc.Distance = path.Last().Distance +1;;
                            break;
                        case "U":
                            // y+
                            loc.X = path.Last().X;
                            loc.Y = path.Last().Y + 1;
                            loc.Distance = path.Last().Distance +1;;
                            break;
                        case "D":
                            // y-
                            loc.X = path.Last().X;
                            loc.Y = path.Last().Y - 1;
                            loc.Distance = path.Last().Distance +1;;
                            break;
                        default:
                            break;
                    }
                    path.Add(loc);
                    foreach (var firstLoc in firstPath)
                    {
                        if (loc.X == firstLoc.X && loc.Y == firstLoc.Y)
                        {
                            int dist = System.Math.Abs(loc.X ?? default) + System.Math.Abs(loc.Y ?? default);
                            int? combiDist = loc.Distance + firstLoc.Distance;

                            if (dist < DistanceFromOrigin || DistanceFromOrigin is null)
                            {
                                Console.WriteLine(loc.X.ToString() + "," + loc.Y.ToString() + " OD: " + dist);
                                DistanceFromOrigin = dist;
                            }
                            if (combiDist < CombinedDistance || CombinedDistance is null)
                            {
                                Console.WriteLine(loc.X.ToString() + "," + loc.Y.ToString() + " TD: " + combiDist);
                                CombinedDistance = combiDist;
                            }

                        }
                        //}
                    }
                }
            }
            return path;
        }

    }
}
