using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day13
    {


        public static void Day13Function()
        {

            List<string> data = File.ReadAllLines("D:\\Projekti\\AdventOfCode\\InputFiles\\Day13.txt").ToList();
            List<string> dots = new List<string>();
           // List<string> folds = new List<string>();
            

           var points = data.Where(row => row.Contains(","))
                            .Select(row => row.Split(','))
                            .Select(e => (Convert.ToInt32(e[0]), Convert.ToInt32(e[1])))
                            .Select(p => (X: p.Item1, Y: p.Item2))
                            .ToList();

            var folds = data.Where(row => row.Contains("fold along"))
                            .Select(row => row.Replace("fold along ", "").Split('='))
                            .Select(axis => (X: axis[0] == "x" ? Convert.ToInt32(axis[1]) : 0,
                                             Y: axis[0] == "y" ? Convert.ToInt32(axis[1]) : 0))
                            .ToList();

            var maxX = points.Select(x => x.X).Max();
            var maxY = points.Select(x => x.Y).Max();

            string[,] board = new string[maxY+1, maxX+1];

            foreach ((int x,int y) d1 in points)
            {
                
                board[d1.y, d1.x] = "#";
            }


             foreach ((int x, int y) comm in folds)
             {

                 if(comm.x ==0)
                 {
                     board = foldUp(board, comm.y);
                 }
                 else { board = foldLeft(board, comm.x); }
              }
           
            drawBoard(board);

            




        }


        private static void drawBoard(string[,] board)
        {
            int counter = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == "#")
                    {
                        counter++;
                       Console.Write(board[i, j]);
                    }
                 else { Console.Write("."); }


                }
              Console.WriteLine();
            }
            //Console.WriteLine(counter);
        }

        private static string[,] foldUp(string[,] board, int position)
        {
            string[,] b1 = new string[position, board.GetLength(1)];

            for (int i = 0; i < position; i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    b1[i, j] = board[(board.GetLength(0)-1) - i, j];

                }
            }

            for (int i = 0; i < b1.GetLength(0); i++)
            {
                for (int j = 0; j < b1.GetLength(1); j++)
                {
                    if(board[i,j] == "#")
                    {
                        b1[i, j] = "#";
                    }
                    

                }
            }

            return b1;
        }

        private static string[,] foldLeft(string[,] board, int position)
        {
            string[,] b1 = new string[board.GetLength(0), position];

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < position; j++)
                {
                    b1[i, j] = board[i, (board.GetLength(1) - 1) - j];

                }
            }

            for (int i = 0; i < b1.GetLength(0); i++)
            {
                for (int j = 0; j < b1.GetLength(1); j++)
                {
                    if (board[i, j] == "#")
                    {
                        b1[i, j] = "#";
                    }


                }
            }

            return b1;
        }
    }

}
