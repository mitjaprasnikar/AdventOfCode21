using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day2
    {
        
       public static void Day2Function()
        {
            string[] lines = File.ReadAllLines("D:\\Projekti\\AdventOfCode\\InputFiles\\Day2.txt");
            int horizontal = 0;
            int depth = 0;
            int aim = 0;
            foreach (string line in lines)
            {
                string[] command = line.Split(' ');
                switch(command[0])
                {
                    case "forward":
                        horizontal += int.Parse(command[1]);
                        depth = depth + (int.Parse(command[1]) * aim);
                        break;
                    case "down":
                        aim += int.Parse(command[1]);
                        break;
                    case "up":
                        aim -= int.Parse(command[1]);
                        break;

                }
                
            }
            Console.WriteLine("Depth: " + depth + "  Horizontal: " + horizontal + " Multiply: " + horizontal * depth);
        }
            
        
    }
}
