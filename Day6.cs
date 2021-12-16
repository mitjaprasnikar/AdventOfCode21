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

            int days = 256;
            string[] lines = File.ReadAllLines("D:\\Projekti\\AdventOfCode\\InputFiles\\Day6.txt");
            string[] splitLine = lines[0].Split(',');
            List<LanternFish> listOfFishes = new List<LanternFish>();
            listOfFishes = fillListOfFishes(splitLine);
            for (int i=0;i<days;i++)
            {
             
              listOfFishes= completeDay(listOfFishes);
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

        private static List<LanternFish> completeDay(List<LanternFish> fishes)
        {
            List<LanternFish> newlist = new List<LanternFish>();

            foreach (LanternFish fish in fishes)
            {
                fish.timer = fish.timer - 1;

                if (fish.timer==0)
                {
                   
                    

                } else if(fish.timer<0)
                {
                    fish.timer = 6;
                    var lf1 = new LanternFish();
                    lf1.timer = 8;
                    newlist.Add(lf1);

                }

                newlist.Add(fish);
            }

            return newlist;

        }






    }
}