using System;
using System.Collections.Generic;
using System.Linq;

namespace metricTSP
{
    class Graph
    {

        public Graph()
        {
            Edges = new List<Edge>();
            Vertices = new List<Vertex>();
        }

        #region Properties

        public List<Edge> Edges { get; private set; }
        public List<Vertex> Vertices { get; private set; }

        #endregion
      
        #region Methods

        public void Path()
        {
            var MST = CreateMST();
            MST.DFS(MST.Vertices[0]);
        }


        private void DFS(Vertex vertex)
        {
            PrintFatherEdge(vertex);
            if(vertex.FatherEdge!=null)
                vertex.FatherEdge.isSelected = true;

            foreach (var edge in vertex.Neighbors)
                DFS(edge.Second);
            if (vertex.FatherEdge != null)
                PrintFatherEdge(vertex);
        }

        private void PrintFatherEdge(Vertex v)
        {
            Console.WriteLine(v.FatherEdge);
        }


        public void AddEdge(Vertex vertexA,Vertex vertexB, int weight)
        {
            var newEdge = new Edge(vertexA, vertexB, weight);
            Edges.Add(newEdge);
        }


        public void AddVertex(Vertex vertex)
        {
            if (!Vertices.Any(v => v.Name.Equals(vertex.Name)))
                Vertices.Add(vertex);
        }

        private Graph CreateMST()
        {
            var tree = new Graph();
          
            var sortedEdges = Edges.OrderBy(e => e.Weight).ToList();

            var forest = new List<List<Vertex>>();

            foreach (var vertex in Vertices)
                forest.Add(new List<Vertex> {vertex});

            foreach(var edge in sortedEdges)
            {
                int f=0, s=0;

                for(int i = 0; i < forest.Count; i++)
                {
                    if (forest[i].Any(e => e.Name.Equals(edge.First.Name)))
                        f = i;
                    if (forest[i].Any(e => e.Name.Equals(edge.Second.Name)))
                        s = i;
                }

                if (f==s)
                    continue;

                forest[f] = forest[f].Union(forest[s]).ToList();
                forest.Remove(forest[s]);

                tree.AddVertex(edge.First);
                tree.AddVertex(edge.Second);
                tree.AddEdge(edge.First, edge.Second,edge.Weight);

                edge.First.Neighbors.Add(edge);
                edge.Second.FatherEdge = edge;
            }
            return tree;
        }

        #endregion

    }
}
