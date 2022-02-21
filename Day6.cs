using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day6
    {

        public class LanternFish
        {
            public LanternFish()
            {
                timer = 0;

            }

            public int timer { get; set; }


        }

        public static void Day6Function()
        {
            List<ulong> fish12 = new List<ulong>();
            int days = 80;
            string[] lines = File.ReadAllLines("D:\\Projekti\\AdventOfCode\\InputFiles\\Day6.txt");
            List<string> splitLine = lines[0].Split(',').ToList();
            splitLine.ForEach(x => fish12.Add(ulong.Parse(x)));

       
            
           
           // foreach (string num in splitLine)
           // {
           //     fish1 += ulong.Parse(num);
           // }
           
            List<LanternFish> listOfFishes = new List<LanternFish>();
            //listOfFishes = fillListOfFishes(splitLine);
            for (int i=0;i<days;i++)
            {
             
              //listOfFishes= 
              
              fish12 = completeDay(fish12);
            }

            Console.WriteLine("There are: " + listOfFishes.Count() + " lanternfishes");
        }

        private static List<LanternFish> fillListOfFishes(string[] lines)
        {
            List<LanternFish> listOfFishes = new List<LanternFish>();
            var lf1 = new LanternFish();

            foreach (string line in lines)
            {
                lf1.timer = int.Parse(line);
                listOfFishes.Add(lf1);
                lf1 = new LanternFish();
            }

            return listOfFishes;

        }

        private static List<ulong> completeDay(List<ulong> fishes)
        {
            List<ulong> tt = new List<ulong>();
            var oth = fishes.Where(x => x == 0).ToList();
            oth.ForEach(x => tt.Add(8));
            oth.ForEach(x => tt.Add(6));


            tt.AddRange(fishes.Where(x => x > 0 && x < 8).Select(f => { f = f - 1; return f; }));
            tt.AddRange(fishes.Where(x => x == 0).Select(f => { f = 6; return f; }));
            
            //fishes.Clear();
           // fishes.AddRange(oth);
            //fishes.AddRange(k);
            //fishes.AddRange(s);
            
            //fishes.Where(x => x != 0).Select(f => f=f-1);
            //
            // var k = fishes.Where(w => w == 0).ToList();
            // k.ForEach(f => f = 6);
            //fishes.Clear();
            //fishes.AddRange(s);
            //fishes.AddRange(k);

            //t.ForEach(f => fishes.Add(8));


            //for (int i=0;i<countZeros;i++)
            //{
            //    var lf1 = new LanternFish();
            //    lf1.timer = 8;
            //    fishes.Add(lf1);
            //}

            // foreach (LanternFish fish in fishes)
            // {
            //     fish.timer = fish.timer - 1;
            //
            //     if (fish.timer==0)
            //     {
            //        
            //         
            //
            //     } else if(fish.timer<0)
            //     {
            //         fish.timer = 6;
            //         var lf1 = new LanternFish();
            //         lf1.timer = 8;
            //         newlist.Add(lf1);
            //
            //     }
            //
            //     newlist.Add(fish);
            // }

            return fishes;

        }






    }
}