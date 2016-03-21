using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metricTSP
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph();

            //g.AddVertex("0");
            g.AddVertex("1");
            g.AddVertex("2");
            g.AddVertex("3");
            g.AddVertex("4");
            g.AddVertex("5");

            g.AddEdge("1", "2", 1);
            g.AddEdge("1", "3", 1);
            g.AddEdge("1", "4", 1);
            g.AddEdge("1", "5", 2);
            g.AddEdge("2", "3", 1);
            g.AddEdge("2", "4", 2);
            g.AddEdge("2", "5", 1);
            g.AddEdge("3", "4", 1);
            g.AddEdge("3", "5", 1);
            g.AddEdge("4", "5", 1);

            var mst = Graph.CreateMST(g);

            var odd = Graph.GetVerticesWithOddDegree(mst);
            var sub = Graph.CreateSubGraph(g, odd);
            var pm = Graph.PerfectMatching(sub);

            var union = Graph.Union(pm, mst);

            var result = Graph.Euler(union);

            result.ForEach(Console.WriteLine);





            //  g.AddVertex("6");
            //   g.AddVertex("7");

            /*
            try {
                g.AddEdge("4", "6", 1);
                g.AddEdge("4", "5", 2);
                g.AddEdge("2", "7", 3);
                g.AddEdge("0", "6", 3);
                g.AddEdge("2", "4", 4);
                g.AddEdge("0", "1", 5);
                g.AddEdge("2", "6", 5);
                g.AddEdge("1", "5", 6);
                g.AddEdge("5", "6", 6);
                g.AddEdge("1", "7", 7);
                g.AddEdge("1", "4", 8);
                g.AddEdge("3", "6", 8);
                g.AddEdge("0", "3", 9);
                g.AddEdge("1", "2", 9);
                g.AddEdge("2", "3", 9);
                g.AddEdge("6", "7", 9);

            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

           // g.Vertices.ForEach(Console.WriteLine);
           // g.Edges.ForEach(Console.WriteLine);

            Graph t = Graph.CreateMST(g);

            Graph.GetVerticesWithOddDegree(t).ForEach(Console.WriteLine);


            */
            Console.ReadKey();
        }
    }
}
