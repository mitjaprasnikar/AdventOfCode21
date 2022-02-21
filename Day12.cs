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
            public bool End { get; set; }


            public Path(string value)
            {
                Cave = value;
                End = false;

            }
        }


        public static void Day12Function()
        {
            bool end = false;
            string path = "start";
            List<string> paths = File.ReadAllLines("D:\\Projekti\\AdventOfCode\\InputFiles\\Day12.txt").ToList();
            List<Path> allPaths = new List<Path>();
            var findStart = paths.Where(x => x.Contains("start")).ToList();
            var findEnd = paths.Where(x => x.Contains("end"));

            findStart.ForEach(x => { var p1 = new Path(x); allPaths.Add(p1); });

           while(allPaths.Count(x => x.End == true) != allPaths.Count())
            {
                List<Path> tempPaths = new List<Path>();
                foreach (var p in allPaths)
                {
                    

                    if (!p.End)
                    {
                        var prev = p.Cave;
                        var points = p.Cave.Split('-');
                        var lastPoint = points.Last();

                        var nextPoint = paths.Where(x => x.Contains(lastPoint)).ToList();
                        nextPoint.RemoveAll(x => x.Contains("start"));
                        var first = nextPoint[0].Split('-');

                        if(first[1] == "")
                        {

                            var test = first[0].Replace("-", "");
                            if (test.ToString().Equals(p.Cave.Last()) && first[0].All(char.IsUpper))
                            {
                                p.Cave += ("-" + first[0].ToString());
                                nextPoint.RemoveAt(0);
                            }
                            else if (test.ToString().Equals(p.Cave.Last()) && first[0].All(char.IsLower))
                            {
                                p.End = true;
                                nextPoint.RemoveAt(0);
                            }
                            else
                            {
                                p.Cave += ("-" + test.ToString());
                                nextPoint.RemoveAt(0);

                            }

                            
                        } else
                        {
                            var test = first[1].Replace("-", "");
                            if(test.ToString().Equals(p.Cave.Last()) && first[0].All(char.IsUpper))
                            {
                                p.Cave += ("-" + first[0].ToString());
                                nextPoint.RemoveAt(0);
                            } else if(test.ToString().Equals(p.Cave.Last()) && first[0].All(char.IsLower))
                            {
                                p.End = true;
                                nextPoint.RemoveAt(0);
                            } else
                            {
                                p.Cave += ("-" + test.ToString());
                                nextPoint.RemoveAt(0);

                            }
                            //if (test.All(char.IsUpper) && p.Cave.Contains(test))
                            //{
                               
                            //}
                           // else
                           // {
                           //     p.End = true;
                           // }
                        }

                        foreach (var p2 in nextPoint)
                        {
                            var p1 = new Path("");


                                var test = p2.Split('-');
                                if (test[0].ToString().Equals(p.Cave.Last()) && first[0].All(char.IsUpper))
                                {
                                    p1.Cave += (p.Cave + "-" + first[0].ToString());
                                    //nextPoint.RemoveAt(0);
                                }
                                else if (test[1].ToString().Equals(p.Cave.Last()) && test[1].All(char.IsLower))
                                {
                                    p1.End = true;
                                    //nextPoint.RemoveAt(0);
                                }
                                else
                                {
                                    p1.Cave += (p.Cave +  "-" + test.ToString());
                                    //nextPoint.RemoveAt(0);

                                }



                            tempPaths.Add(p1);



                        }

                            
                        
                        allPaths.ForEach(x => { if (x.Cave.Contains("end")){ x.End = true; } });
                        tempPaths.ForEach(x => { if (x.Cave.Contains("end")) { x.End = true; } });
                    }
                    
                    
                }

                allPaths.AddRange(tempPaths);
            }


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
