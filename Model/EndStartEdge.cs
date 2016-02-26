using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netzplantechnik.Model
{
    public class EndStartEdge : Edge
    {
        
        protected override void calculateEarliestStartForNext()
        {
            DateTime newStart = Previous.EarliestEnd.AddDays(1);
            if (Next.EarliestStart.CompareTo(newStart) < 0) 
            {
                Next.EarliestStart = newStart;
            }
        }

        protected override void calculateLatestEndForPrevious()
        {
            DateTime newEnd = Next.LatestStart.AddDays(-1);   //SE_n = SA_(n+1) -1
            if (Previous.LatestEnd.CompareTo(newEnd) < 0)
            {
                Previous.LatestEnd = newEnd;
            }
        }

    }
}
