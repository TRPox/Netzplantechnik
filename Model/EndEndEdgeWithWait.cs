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
        public override void calculateEarliestStartForNext()
        {
            DateTime newEnd = Previous.EarliestEnd + Wait;  // FEZ_n = FEZ_(n-1) + c
            if (Next.EarliestEnd.CompareTo(newEnd) < 0)   
            {
                Next.EarliestEnd = newEnd;
            }
        }
    }
}
