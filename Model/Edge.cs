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

        public virtual void calculateEarliestDatesForNext()
        {
            calculateEarliestStartForNext();
            calculateEarliestEndForNext();
        }

        protected abstract void calculateEarliestStartForNext();

        protected virtual void calculateEarliestEndForNext() //always the same for every edge
        {
            Next.EarliestEnd = Next.EarliestStart + Next.Duration - new TimeSpan(1, 0, 0, 0);
        }


        public void calculateLatestDatesForPrevious()
        {
            calculateLatestEndForPrevious();
            calculateLatestStartForPrevious();
        }


        protected abstract void calculateLatestEndForPrevious();


        protected abstract void calculateLatestStartForPrevious();
        

    }
}
