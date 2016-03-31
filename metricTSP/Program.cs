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

            List<Vertex> vertices = new List<Vertex>();

            for(int i = 0; i < 6; i++)
            {
                var vertex = new Vertex((i + 1) + "");
                vertices.Add(new Vertex((i + 1) + ""));
                g.AddVertex(vertex);
            }

            g.AddEdge(vertices[0], vertices[1],1);
            g.AddEdge(vertices[0], vertices[2], 1);
            g.AddEdge(vertices[1], vertices[3], 1);

            g.Path();

            Console.ReadKey();
        }
    }
}
