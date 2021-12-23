using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace AdventOfCode
{
    class Day9
    {
        public class Point
        {
            public int Value { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
           

            public Point(int value, int x, int y)
            {
                Value = value;
                X = x;
                Y = y;
             }
        }

        public class HeightMap
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public List<Point> Points { get; set; }
            public List<Point> CountedPoints { get; set; }
            

            public HeightMap(int width, int height, List<char> numbers)
            {
                Width = width;
                Height = height;
                Points = new List<Point>();
                CountedPoints = new List<Point>();

                int id = 0;
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Points.Add(new Point(int.Parse(numbers[id].ToString()), j, i));
                        id++;
                    }

                }


            }

            public List<Point> GetNeighbors(int x, int y)
            {
                return GetNeighbors(x, y, 1);
            }

            public List<Point> GetNeighbors(int x, int y, int depth)
            {
                var nearbyPoints = Points.Where(point => point.X == (x - 1) && point.Y == y || point.X == (x + 1) && point.Y == y || point.X == x && point.Y == (y - 1)
                    || point.X == x && point.Y == (y + 1));

                var currentPoint = Points.Where(panel => panel.X == x && panel.Y == y);
                return nearbyPoints.Except(currentPoint).ToList();
            }

            public bool isLowPoint(int x,int y,List<Point> neighbors)
            {
                var currentPoint = Points.Where(panel => panel.X == x && panel.Y == y);
                int counter = 0;
                foreach (var neighbor in neighbors)
                {
                    if(currentPoint.FirstOrDefault().Value < neighbor.Value)
                    {
                        counter++;
                    }
                    
                }
                if(counter==neighbors.Count)
                {
                    return true;
                } else { return false; }

                

            }

            public int findBasin(Point point)
            {
                
                int counter = 1;
                Point lastPoint = point;
                List<Point> list = new List<Point>();
               
                var leftBasin = Points.Where(x => x.X == (lastPoint.X - 1) && x.Y == lastPoint.Y 
                                               || x.X == (lastPoint.X + 1) && x.Y == lastPoint.Y 
                                               || x.X == lastPoint.X && x.Y == (lastPoint.Y - 1) 
                                               || x.X == lastPoint.X && x.Y == (lastPoint.Y + 1));

               foreach(var p1 in leftBasin)
                {
                    
                    if (!CountedPoints.Contains(p1))
                    {
                        CountedPoints.Add(p1);
                        if(p1.Value != 9)
                        {
                            counter += findBasin(p1);
                        }
                    }
                }


                return counter;

            }

        }
        
        public static void Day9Function()
        {
            string[] lines = File.ReadAllLines("D:\\Projekti\\AdventOfCode\\InputFiles\\Day9.txt");
            
            List<char> boardNumbers = new List<char>();
            List<Point> lowPoint = new List<Point>();
            List<int> allBasins = new List<int>();
            List<Point> counted = new List<Point>();

            foreach (string line in lines) {
                boardNumbers.AddRange(line);
            }
            
            HeightMap hm = new HeightMap(lines[0].Length, lines.Length, boardNumbers);

            foreach (var point in hm.Points)
            {
                var nearbyPanels = hm.GetNeighbors(point.X, point.Y);

                if (hm.isLowPoint(point.X, point.Y, nearbyPanels))
                {
                    lowPoint.Add(hm.Points.Where(item => item.X == point.X && item.Y == point.Y).FirstOrDefault());
                }

            }
            int sum = 0;
           
            foreach (var point in lowPoint)
            {
                hm.CountedPoints.Add(point);
                allBasins.Add(hm.findBasin(point));
                sum += point.Value + 1;
            }

            allBasins.Sort();

            int num = allBasins[allBasins.Count-1] * allBasins[allBasins.Count - 2] * allBasins[allBasins.Count - 3];


            Console.WriteLine("Part1 Answer: " + sum);
            Console.WriteLine("Part2 Answer: " + num);



        }


    }
}
