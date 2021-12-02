using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day1
    {
        public static void Day1Function()
        {
            string[] lines = File.ReadAllLines("D:\\Projekti\\AdventOfCode\\InputFiles\\Day1.txt");
            int counter = 0;
            int prevLine = 0;
            List<int> sums = new List<int>();
            for (int i = 1; i < lines.Length; i++)
            {
                int first = int.Parse(lines[i - 1]);
                int third;
                int second = int.Parse(lines[i]);

                if (i < lines.Length - 1)
                {
                    third = int.Parse(lines[i + 1]);
                }
                else { continue; }

                sums.Add(first + second + third);

                // int lineInt = int.Parse(line);

                // prevLine = lineInt;
            }
            
            foreach (int line in sums)
            {
                if (prevLine < line)
                {
                    counter++;
                }

                prevLine = line;
            }
            Console.WriteLine(counter - 1);

        }
       
            
        
    }
}
