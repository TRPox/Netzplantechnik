using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netzplantechnik.Model
{
    public class EndStartEdge : Edge
    {
        public void calculateEarliestStartForNext()
        {
            Next.EarliestStart = Previous.EarliestEnd.AddDays(1);
        }
    }
}
