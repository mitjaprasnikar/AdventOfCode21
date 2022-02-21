using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Segments
    {
        public Segments()
        {
            one = "";
            two = "";
            three = "";
            four = "";
            five = "";
            six = "";
            seven = "";
            eight = "";
            nine = "";


        }

        public string one { get; set; }
        public string two { get; set; }
        public string three { get; set; }
        public string four { get; set; }
        public string five { get; set; }
        public string six { get; set; }
        public string seven { get; set; }
        public string eight { get; set; }
        public string nine { get; set; }


        public int returnNumber(string input)
        {

            int num = 0;
            if (input.Length == 2 || input.Length == 4 || input.Length == 3 || input.Length == 7)
            {
                num = return1478(input);
                
            }
            
            if (input.Length == 5)
            {
                num = return235(input);
            }


            if (input.Length == 6)
            {
                num = return069(input);
            }

            return num;
        }


        public int return1478(string signal)
        {
            int num = 0;

            if (signal.Length == 2)
            {
                num = 1;
                one = signal;

            }
            else if (signal.Length == 3)
            {
                num = 7;
                seven = signal;
            }
            else if (signal.Length == 4)
            {
                num = 4;
                four = signal;
            }
            else if (signal.Length == 7)
            {
                num = 8;
                eight = signal;
            }

            return num;

        }

        public int return235(string signal)
        {
            int num = 0;
            int cc = 0;
            if (signal.Length == 5)
            {

                foreach (char c in four)
                {
                    if (signal.Contains(c))
                    {
                        cc++;
                    }
                }

                if (signal.Contains(one[0]) && signal.Contains(one[1]))
                {
                    three = signal;
                    num = 3;
                }
                else if (cc == 3)
                {
                    num = 5;
                    five = signal;
                }

                else
                {
                    num = 2;
                    two = signal;
                }



            }

            return num;


        }

        public int return069(string signal)
        {
            int num = 0;
            int c3 = 0;
            int c7 = 0;

            if (signal.Length == 6)
            {
                foreach (char ch in three)
                {
                    if (signal.Contains(ch))
                    {
                        c3++;
                    }
                }

                foreach (char ch in seven)
                {
                    if (signal.Contains(ch))
                    {
                        c7++;
                    }
                }


                if (c3 == 5)
                {

                    num = 9;
                    nine = signal;

                }


                else if (c7 == 3)
                {
                    num = 0;

                }
                else
                {
                    num = 6;
                    six = signal;
                }

            }
            return num;

        }

    }

    class Day8
    {
         
        public static void Day8Function()
        {
            string[] lines = File.ReadAllLines("D:\\Projekti\\AdventOfCode\\InputFiles\\Day8.txt");
            List<string> split1 = new List<string>();
            List<string> split2 = new List<string>();
            List<int> totalINT = new List<int>();
            Segments lineSegments = new Segments();
            
            foreach (string line in lines)
            {
                string[] input = line.Split('|')[0].Split(' ');
                string[] output = line.Split('|')[1].Split(' ');

                var inputLst = input.Where(x => !string.IsNullOrEmpty(x)).ToList();

                var outputLst = output.Where(x => !string.IsNullOrEmpty(x)).ToList() ;



                inputLst.ForEach(x => lineSegments.return1478(x));
                inputLst.ForEach(x => lineSegments.return235(x));
                inputLst.ForEach(x => lineSegments.return069(x));


                string valueOfLine = "";
                foreach (string outDigit in output)
                {
                    valueOfLine = valueOfLine + lineSegments.returnNumber(outDigit).ToString();
                }

                Console.WriteLine(valueOfLine);


                //foreach (string outputDigit in output) 
                //{
                //    
                //
                //    foreach (string inputDigit in input)
                //    {
                //        
                //        //Console.WriteLine(returnNumber(inputDigit).ToString());
                //        if (inputDigit.Length == outputDigit.Length)
                //        {
                //            char[] chars1 = inputDigit.ToCharArray();
                //            char[] chars2 = outputDigit.ToCharArray();
                //            Array.Sort(chars1);
                //            Array.Sort(chars2);
                //            if(chars1.SequenceEqual(chars2))
                //            {
                //
                //                valueOfLine = valueOfLine + lineSegments.returnNumber(inputDigit).ToString();
                //            }
                //        } else { continue; }
                //    }
                //}
                totalINT.Add(int.Parse(valueOfLine));
                //Console.WriteLine(valueOfLine);
            }



            calculate(totalINT);
         
            //Console.WriteLine("Day8: " + counter);

        }

        private static void calculate(List<int> totalINT)
        {
            int sum = 0;
            foreach(int value in totalINT)
            {
                sum += value;
            }

            Console.WriteLine("Total: " + sum);
        }


       


    }
}
