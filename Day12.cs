using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day12
    {
        public class Path
        {
            public string Cave { get; set; }
           // public int X { get; set; }
           // public int Y { get; set; }
           // public bool Flashed { get; set; }


            public Path(string value)
            {
                Cave = value;

            }
        }


        public static void Day12Function()
        {
            bool end = false;
            string path = "start";
            List<string> paths = File.ReadAllLines("D:\\Projekti\\AdventOfCode\\InputFiles\\Day12.txt").ToList();
            List<string> builder = new List<string>();
            var findStart = paths.Where(x => x.Contains("start"));
            var findEnd = paths.Where(x => x.Contains("end"));
            
            

           


            }


        

        public static string splitConn(string paths,string search)
        {
           
            string[] split = paths.Split('-');
            if(split[0].Contains(search))
            {
                return split[1];
            } else { return split[0]; }
            


            
        }



        }
}
