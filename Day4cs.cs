using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{

    public class Board
    {
        public Board()
        {
            BoardNum = new string[5, 5]; 
            Win = false;
            lastNum = "";

        }

        public string[,] BoardNum { get; set; }
        public bool Win { get; set; }
        public string lastNum { get; set; }

    }

    class Day4cs
    {
        public static void Day4Function()
        {
            string[] lines = File.ReadAllLines("D:\\Projekti\\AdventOfCode\\InputFiles\\Day4.txt");
            string[] drawNumbers = lines[0].Split(',');
            List<Board> boardList = new List<Board>();
            List<Board> ranking = new List<Board>();

            boardList = fillListOfBoards(lines);
            




            foreach(string number in drawNumbers)
            {
                foreach(Board b1 in boardList)
                {
                    if(b1.Win==false)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (b1.BoardNum[i, j].Equals(number))
                                {
                                    b1.BoardNum[i, j] = "X";
                                }
                            }
                        }
                        if (checkBingo(b1.BoardNum, boardList.IndexOf(b1)) == true)
                        {
                            b1.Win = true;
                            b1.lastNum = number;
                            ranking.Add(b1);
                        }
                    } else { continue; }
                }
                
            }

            drawBoard(ranking[0].BoardNum);
            calculateWinner(ranking[0].BoardNum, ranking[0].lastNum);
            drawBoard(ranking[ranking.Count - 1].BoardNum);
            calculateWinner(ranking[ranking.Count - 1].BoardNum, ranking[ranking.Count - 1].lastNum);

        }



        private static void calculateWinner(string[,] board,string lastNumber)
        {
            int sum = 0;
            int lstNum = int.Parse(lastNumber);
            for (int k = 0; k < 5; k++)
            {
                for (int z = 0; z < 5; z++)
                {
                   
                    if(board[k, z] != "X")
                    {
                        int num = int.Parse(board[k, z]);
                        sum = sum + num;
                    }

                }

            }
            Console.WriteLine("Sum is: " + sum + " Last number: " + lstNum + " Final score: " + sum*lstNum);
        }

        private static void drawBoard(string[,] board)
        {
            for (int k = 0; k < 5; k++)
            {

                for (int z = 0; z < 5; z++)
                {
                    Console.Write(" " + board[k, z] + " ");

                }

             Console.WriteLine();
            }

                }
        private static bool  checkBingo(string[,] board,int index)
        {

           bool bingo = false;    
           int x = 0;

           //Rows
            for (int k = 0; k < 5; k++)
                {
                x = 0;
                for (int z = 0; z < 5; z++)
                    {
                         if (board[k, z] == "X")
                         {
                             x++;

                             if(x==5)
                             {
                                bingo= true;
                                break;
                             }
                         }
                }
               
            }
            //Columns
            for (int i = 0; i <= 4; i++)
            {
               x = 0;
                for (int j = 0; j <= 4; j++)
                {
                    if (board[j, i] == "X")
                    {
                        x++;
                    }
                }
                if (x == 5)
                {
                    bingo = true;
                    break;
                }
            }




            if (bingo)
            {
                return bingo;
            }
            return bingo;


           

            }
        

        private static List<Board> fillListOfBoards(string[] lines)
        {
            string[,] board = new string[5, 5];
            int counter = 0;
           
            List<Board> boardList = new List<Board>();


            var b1 = new Board();

            foreach (string line in lines)
            {
                if (line.Length == 14)
                {
                    string[] splitLine = line.Split(' ');
                    splitLine = splitLine.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    for (int i = 0; i < 5; i++)
                    {
                        board[counter, i] = splitLine[i]; 




                    }

                    if (counter < 4)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                        b1.BoardNum = board;
                        b1.Win = false;
                        boardList.Add(b1);
                        board = new string[5, 5];
                        b1 = new Board();

                    }
                }
                
            }
            return boardList;
        }


    }
}
