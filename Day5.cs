using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{

    public class Line
    {
        public Line()
        {
            Start = "";
            End = "";

        }

        public string Start { get; set; }
        //public bool Win { get; set; }
        public string End { get; set; }

    }

    class Day5
    {
      

        public static void Day5Function()
        {

            
            string[] lines = File.ReadAllLines("D:\\Projekti\\AdventOfCode\\InputFiles\\Day5.txt");
            List<Line> listOfLines = new List<Line>();
            string[,] board = new string[1000,1000];
            listOfLines = fillListOfLines(lines);
            board = writeLinesToBoard(listOfLines);
            countOverleaps(board);
            drawBoard(board);
            

        }

        private static string[,]  writeLinesToBoard(List<Line> listOfLines)
        {
            int count = 0;
            string[,] board = new string[1000, 1000];

            foreach (Line l1 in listOfLines)
            {
                int startX = int.Parse(l1.Start.Split(',')[0]);
                int startY = int.Parse(l1.Start.Split(',')[1]);
                int endX = int.Parse(l1.End.Split(',')[0]);
                int endY = int.Parse(l1.End.Split(',')[1]);

                if (startX == endX || startY == endY)
                {
                    if (startX == endX)
                    {
                        if (startY > endY)
                        {
                            for (int z = startY; z >= endY; z--)
                            {
                                int num;
                                bool isNum = int.TryParse(board[z, startX], out num);
                                if (isNum)
                                {

                                    num++;
                                    board[z, startX] = num.ToString();
                                    count++;
                                }
                                else { board[z, startX] = "1"; }

                            }
                        }
                        else if (startY < endY)
                        {
                            for (int z = startY; z <= endY; z++)
                            {

                                int num;
                                bool isNum = int.TryParse(board[z, startX], out num);
                                if (isNum)
                                {

                                    num++;
                                    board[z, startX] = num.ToString();
                                    count++;
                                }
                                else { board[z, startX] = "1"; }
                            }
                        }
                    }
                    else if (startY == endY)
                    {
                        if (startX > endX)
                        {
                            for (int z = startX; z >= endX; z--)
                            {
                                int num;
                                bool isNum = int.TryParse(board[startY, z], out num);
                                if (isNum)
                                {

                                    num++;
                                    board[startY, z] = num.ToString();
                                    count++;
                                }
                                else { board[startY, z] = "1"; }

                            }
                        }
                        else if (startX < endX)
                        {
                            for (int z = startX; z <= endX; z++)
                            {
                                int num;
                                bool isNum = int.TryParse(board[startY, z], out num);
                                if (isNum)
                                {

                                    num++;
                                    board[startY, z] = num.ToString();
                                    count++;
                                }
                                else { board[startY, z] = "1"; }

                            }
                        }
                    }

                }
                else {

                    if (endX > startX && endY > startY)
                    {
                        //Desno Dol

                        for (int z = 0; z <= (endX-startX); z++)
                        {
                            int num;
                            bool isNum = int.TryParse(board[startY + z, startX + z], out num);
                            if (isNum)
                            {

                                num++;
                                board[startY + z, startX + z] = num.ToString();
                                count++;
                            }
                            else { board[startY + z, startX + z] = "1"; }

                        }




                    }
                    else if (endX > startX && endY<startY)
                    {
                        //Desno Gor
                        for (int z = 0; z <=  (endX-startX); z++)
                        {

                            int num;
                            bool isNum = int.TryParse(board[startY - z, startX + z], out num);
                            if (isNum)
                            {

                                num++;
                                board[startY - z, startX + z] = num.ToString();
                                count++;
                            }
                            else { board[startY - z, startX + z] = "1"; }

                        }





                    }
                    else if(endX < startX && endY < startY)
                    {
                        //Levo Gor

                        for (int z = 0; z <= (startX-endX); z++)
                        {

                            int num;
                            bool isNum = int.TryParse(board[startY - z, startX - z], out num);
                            if (isNum)
                            {

                                num++;
                                board[startY - z, startX - z] = num.ToString();
                                count++;
                            }
                            else { board[startY - z, startX - z] = "1"; }

                        }



                    }
                    else if (endX < startX && endY > startY)
                    {
                        //Levo Dol

                        for (int z = 0; z <= (startX-endX); z++)
                        {

                            int num;
                            bool isNum = int.TryParse(board[startY + z, startX - z], out num);
                            if (isNum)
                            {

                                num++;
                                board[startY + z, startX - z] = num.ToString();
                                count++;
                            }
                            else { board[startY + z, startX - z] = "1"; }

                        }



                    }





                }



                }


            return board;

        }


        private static void drawBoard(string[,] board)
        {
            using (var sw = new StreamWriter("D:\\Projekti\\AdventOfCode\\InputFiles\\Day5Output.txt"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        if (board[i, j] == null)
                        {
                            sw.Write(" " + "." + " ");
                        }
                        else { sw.Write(" " + board[i, j] + " "); }
                        
                    }
                    sw.Write("\n");
                }

                sw.Flush();
                sw.Close();
            }

            

        }

        private static void countOverleaps(string[,] board)
        {
            int counter = 0;

                for (int i = 0; i < 1000; i++)
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        int num;
                        bool isNum = int.TryParse(board[i, j], out num);
                        if (num>1)
                        {
                            counter++; 
                        }

                    }
                    
                }

            Console.WriteLine("Overlap count: " + counter);

                
            }



        







        private static List<Line> fillListOfLines(string[] lines)
        {
            List<Line> listOfLines = new List<Line>();
            var l1 = new Line();
            foreach (string line in lines)
            {
               string data= line.Replace("->", "|");
                string[] splitLine = data.Split('|');
                l1.Start = splitLine[0];
                l1.End = splitLine[1];
                listOfLines.Add(l1);
                l1 = new Line();
            }

            return listOfLines;

        }











        }
}
