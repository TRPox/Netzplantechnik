using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netzplantechnik.Model
{
    public class Process : RootProcess
    {
        public Process() {
            this.Previous = new List<Process>();
            this.Next = new List<Process>();
        }


        public List<Process> Previous
        {
            get;
            set;
        }

    }
}
