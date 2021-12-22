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
            segmentA = "";
            segmentB = "";
            segmentC = "";
            segmentD = "";
            segmentE = "";
            segmentF = "";
            segmentG = "";

        }

        public string segmentA { get; set; }
        public string segmentB { get; set; }
        public string segmentC { get; set; }
        public string segmentD { get; set; }
        public string segmentE { get; set; }
        public string segmentF { get; set; }
        public string segmentG { get; set; }
       


    }

    class Day8
    {
        public static void Day8Function()
        {
            string[] lines = File.ReadAllLines("D:\\Projekti\\AdventOfCode\\InputFiles\\Day8.txt");
           
            List<string> split1 = new List<string>();
            List<string> split2 = new List<string>();
            List<int> totalINT = new List<int>();

            foreach (string line in lines)
            {
                string[] input = line.Split('|')[0].Split(' ');
                string[] output = line.Split('|')[1].Split(' ');

                input = input.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                output = output.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Segments lineSegments = new Segments();

                string valueOfLine = "";

                foreach (string outputDigit in output) 
                {
                    foreach (string inputDigit in input)
                    {

                        //Console.WriteLine(returnNumber(inputDigit).ToString());
                        if (inputDigit.Length == outputDigit.Length)
                        {
                            char[] chars1 = inputDigit.ToCharArray();
                            char[] chars2 = outputDigit.ToCharArray();
                            Array.Sort(chars1);
                            Array.Sort(chars2);
                            if(chars1.SequenceEqual(chars2))
                            {
                                
                                valueOfLine = valueOfLine + returnNumber(inputDigit).ToString();
                            }
                        } else { continue; }
                    }
                }
                totalINT.Add(int.Parse(valueOfLine));
                Console.WriteLine(valueOfLine);
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


        private static int returnNumber(string input)
        {

            int num = 0;
            if (input.Length == 2 || input.Length == 4 || input.Length == 3 || input.Length == 7)
            {
               num = return1478(input);
               
            }
            else if (input.Length == 5)
            {
                num=return235(input);
            }
            else if (input.Length == 6)
            {
                num=return069(input);
            }

            return num;
        }


        public static int return1478(string signal)
        {
            int num = 0;
            
            if(signal.Length == 2)
            {
                num = 1;
            } else if(signal.Length == 3)
            {
                num = 7;
            }
            else if (signal.Length == 4)
            {
                num = 4;
            }
            else if (signal.Length == 7)
            {
                num = 8;
            }

            return num;

        }

        private static int return235(string signal)
        {
            int num = 0;

            if (signal.Contains('e'))
            {
                num = 5;
            } else
            {
                if (signal.Contains('a'))
                {
                    num = 3;
                }
                else { num = 2; }

            }
            
            

            return num;
            

        }

        private static int return069(string signal)
        {
            int num = 0;

            if (signal.Contains('c'))
            {
                if (signal.Contains('d'))
                {
                    num = 9;
                }
                else { num = 0; }
            }
            else
            {

                    num = 6;

            }


            return num;

        }


    }
}
