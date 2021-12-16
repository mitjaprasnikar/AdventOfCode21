using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day7
    {
        public static void Day7Function()
        {
            string[] lines = File.ReadAllLines("D:\\Projekti\\AdventOfCode\\InputFiles\\Day7.txt");
            string[] splitLine = lines[0].Split(',');
            int[] total = new int[splitLine.Length];

            for(int j=0;j<splitLine.Length;j++)
            {
                int results = 0;
                int crb = int.Parse(splitLine[j]);
               
                for(int i=0;i<splitLine.Length;i++)
                {
                    var steps = Math.Abs( (int.Parse(splitLine[i]) - crb));
                    var counter = 1;
                    var sum = 0;

                    do {
                        sum += counter;
                        counter++;
                    } while (counter <= steps);

                   // Console.WriteLine("Position: " + splitLine[i] + " to: " + crb + " fuel: " + sum);
                    results += sum;
                   
                }
               // Console.WriteLine("Total cost:" + results);
                total[j] = results;
            }


            //total.Min();
          //  int lowest = total[0];
          //  foreach(int value in total)
          //  {
          //      if(value<lowest)
          //      {
          //          lowest = value;
          //      }
          //  }


            Console.WriteLine("Cheapest outcome: " + total.Min());


        }

    }
}
