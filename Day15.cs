using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace AdventOfCode
{
    class Day15
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

        public class Path
        {
            public int TotalRisk { get; set; }
            public Point currentPoint { get; set; }
            public List<Point> Points { get; set; }

            public bool End { get; set; }

            public Path()
            {
                currentPoint = new Point(0, 0, 0);
                TotalRisk = 0;
                Points = new List<Point>();
                End = false;
            }
        }

        public class Cavern
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public List<Point> Points { get; set; }
            public List<Point> CountedPoints { get; set; }
            public List<Path> AllPaths { get; set; }
            public int bestPath { get; set; }

            public int counter { get; set; }




            public Cavern(int width, int height, List<char> numbers)
            {
                Width = width;
                Height = height;
                Points = new List<Point>();
                CountedPoints = new List<Point>();
                AllPaths = new List<Path>();
                bestPath = 500;
                counter = 0;


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

            public List<Point> GetNeighbors(int x, int y, int depth)
            {
                var nearbyPoints = Points.Where(point => point.X == (x + 1) && point.Y == y
                                                            || point.X == x && point.Y == (y + 1));


                return nearbyPoints.ToList();
            }
            
    
            public void stepMade()
            {
                
               // var endCheck = AllPaths.Where(x => x.End == false).ToList();

               
                List<Path> tempPath = new List<Path>();


                Path pth = AllPaths[counter]; 
               //foreach (Path pth in endCheck)
               //{
                var nearbyPanels = GetNeighbors(pth.currentPoint.X, pth.currentPoint.Y, 1);
                //var tt = nearbyPanels.OrderBy(x => x.Value).ToList();
                var tmp = pth;

                if (pth.currentPoint.Y == Height - 1 && pth.currentPoint.X == Width - 1)
                {
                    pth.End = true;
                    //AllPaths.Remove(pth);
                    counter--;
                    if (pth.TotalRisk < bestPath) { bestPath = pth.TotalRisk; }
                    return;
                }
                if (nearbyPanels.Count > 1)
                {
                    if((tmp.TotalRisk + nearbyPanels[1].Value) < bestPath)
                    {
                        if (nearbyPanels[0].Value == nearbyPanels[1].Value || nearbyPanels[1].Value < tmp.currentPoint.Value || nearbyPanels[0].Value < tmp.currentPoint.Value)
                        {
                            //tt.RemoveAt(0);

                            // foreach (var point in tt)
                            // {
                            Path p1 = new Path();
                            var pts = tmp.Points;

                            p1.Points.AddRange(pts);
                            p1.Points.Add(nearbyPanels[1]);
                            p1.currentPoint = nearbyPanels[1];
                            p1.TotalRisk = tmp.TotalRisk + nearbyPanels[1].Value;
                            tempPath.Add(p1);
                            //}
                        }
                    }
                    


                }
                if ((pth.TotalRisk + nearbyPanels[0].Value) < bestPath)
                {
                    pth.currentPoint = nearbyPanels.FirstOrDefault();
                    pth.Points.Add(nearbyPanels.FirstOrDefault());
                    pth.TotalRisk += pth.currentPoint.Value;

                    AllPaths.AddRange(tempPath);
                } else
                {
                    pth.End = true;
                    //AllPaths.Remove(pth);
                    counter--;
                    return;

                }

                    
                   // if (pth.TotalRisk > bestPath) { 
                   //     pth.End = true; 
                   //     AllPaths.Remove(pth);
                   // counter--;
                   //     return; 
                   // } else if (bestPath ==0) { }
                    stepMade();

                //}
                


            }

        }

        class Tile
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Cost { get; set; }
            public int Distance { get; set; }
            public int CostDistance => Cost + Distance;
            public Tile Parent { get; set; }


            //The distance is essentially the estimated distance, ignoring walls to our target. 
            //So how many tiles left and right, up and down, ignoring walls, to get there. 
            public void SetDistance(int targetX, int targetY)
            {
                this.Distance = Math.Abs(targetX - X) + Math.Abs(targetY - Y);
            }


        }
        

        private static List<Tile> GetWalkableTiles(List<Tile> map, Tile currentTile, Tile targetTile, int width, int height)
        {


            var possibleTiles = new List<Tile>()
    {
        new Tile { X = currentTile.X, Y = currentTile.Y - 1, Parent = currentTile, Cost = currentTile.Cost + map.Where(x => x.X == currentTile.X && x.Y == currentTile.Y - 1 ).Select(y => y.Cost).FirstOrDefault() },
        new Tile { X = currentTile.X, Y = currentTile.Y + 1, Parent = currentTile, Cost = currentTile.Cost + map.Where(x => x.X == currentTile.X && x.Y == currentTile.Y + 1 ).Select(y => y.Cost).FirstOrDefault()},
        new Tile { X = currentTile.X - 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + map.Where(x => x.X == currentTile.X -1 && x.Y == currentTile.Y ).Select(y => y.Cost).FirstOrDefault() },
        new Tile { X = currentTile.X + 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + map.Where(x => x.X == currentTile.X + 1 && x.Y == currentTile.Y  ).Select(y => y.Cost).FirstOrDefault() },
    };

            possibleTiles.ForEach(tile => tile.SetDistance(targetTile.X, targetTile.Y));

            var maxX =width-1;
            var maxY = height-1;

            return possibleTiles
                    .Where(tile => tile.X >= 0 && tile.X <= maxX)
                    .Where(tile => tile.Y >= 0 && tile.Y <= maxY)
                    //.Where(tile => map[tile.Y][tile.X] == ' ' || map[tile.Y][tile.X] == 'B')
                    .ToList();
        }

        private static void findPath(List<Tile> grph,int width,int height)
        {

            var start = new Tile();
            start.Y = 0;
            start.X = 0;

            var finish = new Tile();
            finish.Y = height -1;
            finish.X = width-1;

            start.SetDistance(finish.X, finish.Y);

            var activeTiles = new List<Tile>();
            activeTiles.Add(start);
            var visitedTiles = new List<Tile>();
            int minCost = int.MaxValue;

            while (activeTiles.Any())
            {

                var checkTile = activeTiles.OrderBy(x => x.Cost).First();

                if (checkTile.X == finish.X && checkTile.Y == finish.Y)
                {
                    //We found the destination and we can be sure (Because the the OrderBy above)
                    //That it's the most low cost option. 
                    var tile = checkTile;
                    Console.WriteLine("Retracing steps backwards...");
                    while (true)
                    {
                        Console.WriteLine($"{tile.X} : {tile.Y}" + " - " + tile.Cost);

                        tile = tile.Parent;
                        if (tile == null)
                        {
                            Console.WriteLine("Map looks like :");
                            //map.ForEach(x => Console.WriteLine(x));
                            Console.WriteLine("Done!");
                            return;
                        }
                    }

                }

                visitedTiles.Add(checkTile);
                activeTiles.Remove(checkTile);

                var walkableTiles = GetWalkableTiles(grph, checkTile, finish,width,height);

                foreach (var walkableTile in walkableTiles)
                {
                    //We have already visited this tile so we don't need to do so again!
                    if (visitedTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                        continue;

                    //It's already in the active list, but that's OK, maybe this new tile has a better value (e.g. We might zigzag earlier but this is now straighter). 
                    if (activeTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                    {
                        var existingTile = activeTiles.First(x => x.X == walkableTile.X && x.Y == walkableTile.Y);
                        if (existingTile.Cost > walkableTile.Cost)
                        {
                            activeTiles.Remove(existingTile);
                            activeTiles.Add(walkableTile);
                        }
                    }
                    else
                    {
                        //We've never seen this tile before so add it to the list. 
                        activeTiles.Add(walkableTile);
                    }
                }
            }



            Console.WriteLine("No Path Found!");


        }
        public static void Day15Function()
        {
            string[] data = File.ReadAllLines("D:\\Projekti\\AdventOfCode\\InputFiles\\Day15.txt");
            List<Tile> grph = new List<Tile>();
            //List<char> boardNumbers = new List<char>();
            for (int i = 0; i < data.Length; i++)
            {
                string line = data[i];
                for (int j = 0; j < line.Length; j++)
                {

                    grph.Add(new Tile
                    {
                        X = j,
                        Y = i,
                        Cost = int.Parse(line[j].ToString())

                    });
                }

            }



            //findPath(grph, data.Length, data[0].Length);



            

            List<Tile> grph5X = new List<Tile>();
            //matrixPartTwo = new Node[_matrixPartOne.Length * 5][];
            var height = data.Length;
            var width = data[0].Length;
            for (var y = 0; y < 5; y++)
            {
                var targetY = y * height;
                for (var i = 0; i < height; i++) //10 then 100 times
                {
                    //_matrixPartTwo[targetY + i] = new Node[width * 5];
                    for (var x = 0; x < 5; x++)
                    {
                        var targetX = x * width;
                        for (var j = 0; j < width; j++)
                        {

                            var value1 = grph.Where(item => item.X == i && item.Y == j).FirstOrDefault();
                            int numt = (value1.Cost-1+y+x) % 9 +1; 
                            

                            // var value = (_matrixPartOne[i][j].Value - 1 + y + x) % 9 + 1;
                            grph5X.Add(new Tile
                            {
                                Y = targetY + j,
                                X = targetX + i,
                                Cost = numt
                            });
                            //var value = (_matrixPartOne[i][j].Value - 1 + y + x) % 9 + 1;
                            //_matrixPartTwo[targetY + i][targetX + j] = new Node()
                            //{ Value = value, Y = targetY + i, X = targetX + j };
                        }
                    }
                }






            }

            findPath(grph5X, data[0].Length*5, data[0].Length*5);
        }

        
        
       
    }



        
}
