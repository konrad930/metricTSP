using System.Collections.Generic;

namespace metricTSP
{
    class Vertex
    {
        public Vertex(string _name)
        {
            Name = _name;
            Neighbors = new List<Edge>();
        }

        #region Properties

        public string Name { get; set; }

        public Edge FatherEdge { get; set; }

        public List<Edge> Neighbors { get; set; }

        #endregion

        #region Override Methods

        public override string ToString()
        {
            return Name;
        }

        #endregion

    }
}
