using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metricTSP
{
    class Vertex
    {
        public Vertex(string _name)
        {
            Name = _name;
        }

        #region Properties

        public string Name { get; set; }

        public bool IsSelected { get; set;}
        #endregion

        #region Override Methods

        public override string ToString()
        {
            return Name;
        }

        #endregion

    }
}
