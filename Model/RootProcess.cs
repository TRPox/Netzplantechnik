using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netzplantechnik.Model
{
    public class RootProcess 
    {
        public RootProcess()
        {
            this.Next = new List<Process>();
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

        public List<Process> Next
        {
            get;
            set;
        }
        #endregion
    
    }


}
