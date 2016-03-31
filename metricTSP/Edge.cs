using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metricTSP
{
    class Edge
    {
        public Edge(Vertex a,Vertex b,int _weight)
        {
            First = a;
            Second = b;
            Weight = _weight;
        }

        #region Properties

        public Vertex First { get; set; }
        public Vertex Second { get; set; }
        
        public int Weight {get; set;}
        public bool isSelected { get; set; }

        #endregion

        #region Override Methods

        public override string ToString()
        {
            return First.ToString()+"->"+Second.ToString()+" : "+Weight;
        }

        #endregion
    }
}
