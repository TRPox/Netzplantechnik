using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netzplantechnik.Model
{
    class EndStartEdgeWithWait : Edge
    {
        public TimeSpan Wait
        {
            get;
            set;
        }

        public override void calculateEarliestStartForNext()
        {
            Next.EarliestStart = Previous.EarliestEnd.AddDays(1) + Wait;
        }
    }
}
