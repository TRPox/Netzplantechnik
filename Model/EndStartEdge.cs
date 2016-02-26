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
            throw new NotImplementedException();
        }

        protected override void calculateLatestStartForPrevious()
        {
            throw new NotImplementedException();
        }
    }
}
