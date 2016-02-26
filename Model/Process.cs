using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netzplantechnik.Model
{
    public class Process 
    {
        public Process()
        {
            this.Next = new List<Edge>();
            this.Previous = new List<Edge>();
        }

        #region Base Attributes
        public string Name
        {
            get;
            set;
        }

        public DateTime EarliestStart
        {
            get;
            set;
        }

        public DateTime EarliestEnd
        {
            get;
            set;
        }

        public DateTime LatestStart
        {
            get;
            set;
        }

        public DateTime LatestEnd
        {
            get;
            set;
        }

        public TimeSpan Duration
        {
            get;
            set;
        }
        #endregion


        #region GraphStructure

        public List<Edge> Next
        {
            get;
            set;
        }

        public List<Edge> Previous
        {
            get;
            set;
        }

        public bool HasNext ()
        {
            return this.Next.Count() > 0;
        }

        public bool HasPrevious()
        {
            return this.Previous.Count() > 0;
        }
        #endregion

    }


}