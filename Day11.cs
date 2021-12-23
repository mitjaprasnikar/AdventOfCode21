using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    

        class Day11
        {

        public class OctopusBoard
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public int Flashes { get; set; }
            public int Step { get; set; }
            public List<Octopus> OctopusList { get; set; }



            public OctopusBoard(int width, int height, List<char> numbers)
            {
                Width = width;
                Height = height;
                Flashes = 0;
                Step = 0;
                OctopusList = new List<Octopus>();


                int id = 0;
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        OctopusList.Add(new Octopus(int.Parse(numbers[id].ToString()), j, i));
                        id++;
                    }

                }


            }

            public void stepMade()
            {
                foreach(Octopus octopus in OctopusList)
                {
                    octopus.Energy++;
                    octopus.Flashed = false;
                }
                checkForFlash();
            }

            public void checkForFlash()
            {
                int counter = 0;
                foreach (Octopus octopus in OctopusList)
                {
                    
                    var nearbyOctopuses= OctopusList.Where(nearby => nearby.X >= (octopus.X - 1) && nearby.X <= (octopus.X + 1)
                                            && nearby.Y >= (octopus.Y - 1) && nearby.Y <= (octopus.Y + 1));

                    var currentPanel = OctopusList.Where(nearby => nearby.X == octopus.X && nearby.Y == octopus.Y);
                    nearbyOctopuses = nearbyOctopuses.Except(currentPanel);

                    if (octopus.Energy > 9 && !octopus.Flashed)
                    {
                        
                        Flashes++;
                        foreach(Octopus nearby in nearbyOctopuses) { nearby.Energy++; }
                       
                        octopus.Flashed = true;
                        checkForFlash();
                        
                        octopus.Energy = 0;
                    }
                }

                foreach(Octopus octo in OctopusList)
                {
                    if(octo.Energy==0)
                    {
                        counter++;
                    }
                }

                if(counter==OctopusList.Count) {
                    Console.WriteLine("All on step: " + (Step+1));
                }
                
            }

        }
        public class Octopus
        {
            public int Energy { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public bool Flashed { get; set; }


            public Octopus(int value, int x, int y)
            {
                Energy = value;
                X = x;
                Y = y;
                Flashed = false;
            }
        }
        public static void Day11Function()
            {
                string[] lines = File.ReadAllLines("D:\\Projekti\\AdventOfCode\\InputFiles\\Day11.txt");
                int[,] board = new int[10, 10];
                List<char> boardNumbers = new List<char>();


                foreach (string line in lines)
                {
                    boardNumbers.AddRange(line);
                }

                OctopusBoard ob = new OctopusBoard(lines[0].Length, lines.Length, boardNumbers);
            

            for(int step=0; step < 500; step++)
            {
                ob.Step = step;
                ob.stepMade();
            }

            Console.WriteLine(ob.Flashes);



           


            }





            public static int[,] fillBoard(string[] lines)
            {
                int[,] board = new int[10, 10];
                int line1 = 0;
                foreach (string line in lines)
                {

                    for (int j = 0; j < 10; j++)
                    {
                        board[line1, j] = int.Parse(line[j].ToString());
                    }
                    line1++;
                }




                return board;
            }



            private static void drawBoard(OctopusBoard board)
            {
            int count = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {


                        Console.Write(" " + board.OctopusList[count].Energy + " ");
                    count++;
                    }
                    Console.WriteLine();
                }

            }



        }

    
            }



