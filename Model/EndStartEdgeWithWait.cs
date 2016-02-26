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

        protected override void calculateEarliestStartForNext()
        {
            DateTime newStart = Previous.EarliestEnd.AddDays(1) + Wait;
            if (Next.EarliestStart.CompareTo(newStart) < 0)  // if Next.EarliestStart - newStart < 0
            {
                Next.EarliestStart = newStart;
            }
        }

        protected override void calculateLatestEndForPrevious()
        {
            DateTime newEnd = Next.LatestStart.AddDays(-1) - Wait;   //SE_n = SA_(n+1) -c -1
            if (Previous.LatestEnd.CompareTo(newEnd) < 0)
            {
                Previous.LatestEnd = newEnd;
            }
        }

        protected override void calculateLatestStartForPrevious()
        {
            throw new NotImplementedException();
        }
    }
}
