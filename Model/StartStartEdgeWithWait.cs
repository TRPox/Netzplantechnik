using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netzplantechnik.Model
{
    class StartStartEdgeWithWait : Edge
    {
        public TimeSpan Wait
        {
            get;
            set;
        }

        public override void calculateEarliestStartForNext()
        {
            DateTime newStart = Previous.EarliestStart + Wait;  // FAZ_n = FAZ_(n-1) + b
            if (Next.EarliestStart.CompareTo(newStart) < 0)
            {
                Next.EarliestStart = newStart;
            }
        }
    }
}
