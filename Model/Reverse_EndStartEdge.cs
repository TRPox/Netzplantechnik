//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Netzplantechnik.Model
//{
//    class Reverse_EndStartEdge : Edge
//    {
//        public override void calculateEarliestDatesForNext()
//        {
//            DateTime newEnd = Next.LatestStart.AddDays(-1);   //SE_n = SA_(n+1) -1
//            if (Previous.LatestEnd.CompareTo(newEnd) > 0)
//            {
//                Previous.LatestEnd = newEnd;
//            }
//        }
//    }
//}
