using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day10
    {

        public static void Day10Function()
        {
            string[] lines = File.ReadAllLines("D:\\Projekti\\AdventOfCode\\InputFiles\\Day10.txt");

            List<char> open = new List<char>() { '[', '(', '{', '<' };
            List<char> close = new List<char>() { ']', ')', '}', '>' };
            Dictionary<char, int> score = new Dictionary<char, int>() { { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 } };
            Dictionary<char, int> acScore = new Dictionary<char, int>() { { ')', 1 }, { ']', 2 }, { '}', 3 }, { '>', 4 } };

            int illegalScore = 0;
            List<long> autocompScore = new List<long>();

            foreach (string d in lines)
            {
                char[] sequence = d.ToCharArray();
                List<char> stack = new List<char>();
                bool invalidSequence = false;

                foreach (char c in sequence)
                {
                    if (open.Contains(c))
                        stack.Add(c);

                    if (close.Contains(c))
                    {
                        char lastItemInStack = stack.Last();

                        char expect = close[open.IndexOf(lastItemInStack)];

                        if (expect == c)
                        {
                            stack.RemoveAt(stack.Count - 1);
                            continue;
                        }
                        else
                        {
                            illegalScore += score[c];
                            invalidSequence = true;
                            break;
                        }
                    }
                }
                if (!invalidSequence && stack.Count > 0)
                {
                    List<char> complete = new List<char>();
                    for (int i = stack.Count - 1; i >= 0; i--)
                        complete.Add(close[open.IndexOf(stack[i])]);

                    long ac = 0;
                    foreach (char c in complete)
                        ac = (ac * 5) + acScore[c];

                    autocompScore.Add(ac);
                }

            }

            autocompScore.Sort();
            Console.WriteLine($"Part One. The final corrupted line score is: {illegalScore}");
            Console.WriteLine($"Part Two. The final autocomplete score is: {autocompScore[autocompScore.Count() / 2]}");


        }
    }

}
