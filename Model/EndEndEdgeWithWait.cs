using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netzplantechnik.Model
{
    class EndEndEdgeWithWait : Edge
    {
        public TimeSpan Wait
        {
            get;
            set;
        }
        //if (Wait < Next.Duration)   //Wait !> Duration of next
           // {
                //Exception
           // }

        public override void calculateEarliestDatesForNext()
        {
            calculateEarliestEndForNext();
            calculateEarliestStartForNext();
        }

        protected override void calculateEarliestStartForNext()
        {
            Next.EarliestStart = Next.EarliestEnd - Next.Duration + new TimeSpan(1, 0, 0, 0);
        }

        protected override void calculateEarliestEndForNext()
        {
            DateTime newEnd = Previous.EarliestEnd + Wait;  // FEZ_n = FEZ_(n-1) + c
            if (Next.EarliestEnd.CompareTo(newEnd) < 0)
            {
                Next.EarliestEnd = newEnd;
            }
        }

        protected override void calculateLatestEndForPrevious()
        {
            DateTime newEnd = Next.LatestEnd - Wait;  // FEZ_n = FEZ_(n+1) - c
            if (Previous.LatestEnd.CompareTo(newEnd) < 0)
            {
                Previous.LatestEnd = newEnd;
            }
        }

        public override void calculateLatestDatesForPrevious()
        {
            calculateEarliestEndForNext();
            calculateEarliestStartForNext();

            DateTime newEnd = Next.LatestEnd - Wait;   //SE_n = SE_(n+1) - c
            if (Previous.LatestEnd.CompareTo(newEnd) > 0) // if Previous.LatestEnd - newEnd > 0
            {
                Previous.LatestEnd = newEnd;
            }
        }



    }
}
