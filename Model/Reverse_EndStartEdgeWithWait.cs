//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Netzplantechnik.Model
//{
//    class Reverse_EndStartEdgeWithWait : Edge
//    {
//        public TimeSpan Wait
//        {
//            get;
//            set;
//        }

//        public override void calculateEarliestDatesForNext()
//        {
//            DateTime newEnd = Next.LatestStart.AddDays(-1) - Wait;   //SE_n = SA_(n+1) -1 -a
//            if (Previous.LatestEnd.CompareTo(newEnd) > 0) // if Previous.LatestEnd - newEnd > 0
//            {
//                Previous.LatestEnd = newEnd;
//            }
//        }
//    }
//}
