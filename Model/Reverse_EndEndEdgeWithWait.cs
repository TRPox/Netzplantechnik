//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Netzplantechnik.Model
//{
//    class Reverse_EndEndEdgeWithWait : Edge
//    {
//        public TimeSpan Wait
//        {
//            get;
//            set;
//        }

//        public override void calculateEarliestDatesForNext()
//        {
//            DateTime newEnd = Next.LatestEnd - Wait;   //SE_n = SE_(n+1) - c
//            if (Previous.LatestEnd.CompareTo(newEnd) > 0) // if Previous.LatestEnd - newEnd > 0
//            {
//                Previous.LatestEnd = newEnd;
//            }
//        }
//    }
//}
