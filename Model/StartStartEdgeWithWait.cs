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

        
        protected override void calculateEarliestStartForNext()
        {
            DateTime newStart = Previous.EarliestStart + Wait;  // FAZ_n = FAZ_(n-1) + b
            if (Next.EarliestStart.CompareTo(newStart) < 0)
            {
                Next.EarliestStart = newStart;
            }
        }

        public override void calculateLatestDatesForPrevious()
        {
            calculateLatestStartForPrevious();
            calculateLatestEndForPrevious();
        }

        protected override void calculateLatestEndForPrevious()
        {
            Previous.LatestEnd = Previous.LatestStart + Previous.Duration - new TimeSpan(1, 0, 0, 0);
        }

        protected override void calculateLatestStartForPrevious()
        {
            DateTime newStart = Next.LatestStart - Wait;  
            if (Previous.LatestStart.CompareTo(newStart) < 0)
            {
                Previous.LatestStart = newStart;
            }
        }
    }
}
