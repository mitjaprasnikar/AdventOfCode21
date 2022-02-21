using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day14
    {
        public static void Day14Function()
        {



        List<string> data = File.ReadAllLines("D:\\Projekti\\AdventOfCode\\InputFiles\\Day14.txt").ToList();
        List<string> polymer = new List<string>();

        string polymerTemp = data[0];
        int steps = 40;

        var pairs = data.Where(row => row.Contains("->"))
                         .Select(row => row.Split(' '))
                         .Select(e => ((e.First(), e.Last())))
                         .Select(p => (Pair: p.Item1, Element: p.Item2))
                         .ToList();

          while(steps > 0 )
            {
                polymer.Clear();
                for (int i = 0; i < polymerTemp.Length - 1; i++)
                {
                    string pair;
                    
                    try
                    {
                         pair = polymerTemp[i].ToString() + polymerTemp[i + 1].ToString();
                    }
                    catch
                    {
                        continue;
                    }


                    polymer.Add(polymerTemp[i].ToString());

                    var insertChar = pairs.Where(x => x.Pair == pair)
                                          .Select(x => x.Element);
                    polymer.Add(insertChar.FirstOrDefault());
                 //polymer.Add(polymerTemp[i+1].ToString());
                }
                Console.WriteLine(steps);
                polymer.Add(polymerTemp.Last().ToString());
                polymerTemp = String.Join("", polymer);
                steps--;

            }
            List<long> counts = new List<long>();

            IEnumerable<char> distinctAges = polymerTemp.Distinct();

            foreach (char ch in distinctAges)
            {
                int counter = 0;
                foreach (char cm in polymerTemp)
                {
                    
                    if (ch == cm)
                    {

                        counter++;
                    }
                    
                }
                counts.Add(counter);

            }


            long sum = counts.Max() - counts.Min();
            Console.WriteLine(sum);














        }
    }
}
