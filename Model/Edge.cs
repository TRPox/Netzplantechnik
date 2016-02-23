using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netzplantechnik.Model
{
    public abstract class Edge
    {
        public Process Previous { get; set; }

        public Process Next { get; set; }

        public abstract void calculateEarliestStartForNext(); //Koennte man hier vielleicht noch calculateLatestStartForPrevious und alle anderen Kombinationen aufnehmen?

    }
}
