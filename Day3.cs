using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day3
    {
        public static void Day3Function()
        {
            List<string> lines = new List<string>();
            List<string> oxlines = new List<string>();
            List<string> co2lines = new List<string>();
            lines =File.ReadAllLines("D:\\Projekti\\AdventOfCode\\InputFiles\\Day3.txt").ToList();

           

            string oxygen = "";
            string co2 = "";
            int one = 0;
            int zero = 0;
            int lenght = 0;

            List<string> sums = new List<string>();
            //List<string> sums = new List<string>();

            do
            {
               
                foreach (string line in lines)
                {
                   

                    if (lines[0].Length > lenght)
                    {
                        sums.Add(line[lenght].ToString());
                    }


                    //  string bit = lines[lenght];
                    //  if(bit=="1")
                    //  {
                    //      one++;
                    //  } else { zero++; }
                    //
                    //  if (one > zero)
                    //  {
                    //      gamma += one;
                    //      epsilon += zero;
                    //
                    //  } else
                    //  {
                    //      gamma += zero;
                    //      epsilon += one;
                    //  }
                    //
                    //  lenght++;

                }
                one = 0;
                zero = 0;
                foreach (string bit in sums)
                {
                   

                    //string bit = lines[lenght];
                    if (bit == "1")
                    {
                        one++;
                    }
                    else { zero++; }

                }

                if (one > zero)
                {
                   
                    
                    lines.RemoveAll(x => x[lenght].ToString() == "1");
                    

                }
                else if (one == zero)
                {
                    lines.RemoveAll(x => x[lenght].ToString() == "1");
                }
                else
                {
                    lines.RemoveAll(x => x[lenght].ToString() == "0");
                   
                }
                if (lines.Count == 1)
                {
                    Console.WriteLine("CC " + lines.Count());
                    Console.WriteLine(lines[0]);
                    break;

                }
                lenght++;
                sums.Clear();
                
                
            } while (lenght < lines[0].Length);

           
            Console.WriteLine("Power usage: " );

        }

        private static void DeleteEntry(List<string> lines,int len)
        {
            
            
            }
    }
}
