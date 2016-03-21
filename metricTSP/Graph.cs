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

        public List<Edge> Edges { get; private set;}
        public List<Vertex> Vertices { get; private set;}

        #endregion

        #region Public Methods

        /*
        * TO DO NIEROWNOSC TROJKATA
        */
        public void AddEdge(string vertexA,string vertexB,int weight)
        {
            var edgeVertices = Vertices.Where(
                v => v.Name.Equals(vertexA) || v.Name.Equals(vertexB)).ToList();

            if(Edges.Any((v => v.First.Name.Equals(vertexA) && v.Second.Name.Equals(vertexB) ||
                (v.First.Name.Equals(vertexB) && v.Second.Name.Equals(vertexA)))))
            {
                throw new ArgumentException("Istnieje juz krawędz pomiedzy wierzchołkami "+ vertexA + "->"+ vertexB);
            }

            if (edgeVertices.Count() == 2)
                Edges.Add(new Edge(edgeVertices[0],edgeVertices[1], weight));
            else
                throw new ArgumentException("Bledne argumenty");

        }

        private void AddEdge(Edge edge)
        {
            var edgeVertices = Vertices.Where(
                v => v.Name.Equals(edge.First.Name) || v.Name.Equals(edge.Second.Name)).ToList();

            if (Edges.Any((v => v.First.Name.Equals(edge.First.Name) && v.Second.Name.Equals(edge.Second.Name) ||
                 (v.First.Name.Equals(edge.Second.Name) && v.Second.Name.Equals(edge.First.Name)))))
            {
                throw new ArgumentException("Istnieje juz krawędz pomiedzy wierzchołkami " + edge.First.Name + "->" + edge.Second.Name);
            }

            if (edgeVertices.Count() == 2)
                Edges.Add(new Edge(edgeVertices[0], edgeVertices[1], edge.Weight));
            else
                throw new ArgumentException("Bledne argumenty");
        }

        public void AddVertex(string name)
        {
            if (!Vertices.Any(v => v.Name.Equals(name)))
                Vertices.Add(new Vertex(name));
        }

        private void AddVertex(Vertex vertex)
        {
            if (!Vertices.Any(v => v.Name.Equals(vertex.Name)))
                Vertices.Add(vertex);
        }

        public static Graph CreateMST(Graph g)
        {
            var tree = new Graph();
          
            var sortedEdges = g.Edges.OrderBy(e => e.Weight).ToList();

            var forest = new List<List<Vertex>>();

            foreach (var vertex in g.Vertices)
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
                tree.AddEdge(edge);

            }
            tree.Edges.ForEach(Console.WriteLine);
            return tree;
        }

        public static List<Vertex> GetVerticesWithOddDegree(Graph g)
        {
            List<Vertex> vertices = new List<Vertex>();

            foreach (var edge in g.Edges)
            {
                vertices.Add(edge.First);
                vertices.Add(edge.Second);
            }

            var agr = vertices.GroupBy(x => x);
            var enumerable = agr as IList<IGrouping<Vertex, Vertex>> ?? agr.ToList();

            return enumerable.Where(e => e.Count() % 2 != 0).Select(e => e.Key).ToList();
        }

        public static Graph CreateSubGraph(Graph g,List<Vertex> vertices)
        {
            var names = vertices.Select(v => v.Name);
            var edges = g.Edges.Where(e => names.Contains(e.First.Name) && names.Contains(e.Second.Name));

            var subGraph = new Graph();
            foreach (var vertex in vertices)
                subGraph.AddVertex(vertex);

            foreach (var edge in edges)
                subGraph.AddEdge(edge);
            return subGraph;

        }

        #endregion

    }
}
