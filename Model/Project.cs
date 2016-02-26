using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netzplantechnik.Model
{
    public class Project
    {
        public Project()
        {
            EdgeFactory ef = new EdgeFactory();
            this.Processes = new List<Process>();
            this.RootProcesses = new List<Process>();
        }

        public List<Process> Processes
        {
            get;
            set;
        }

        public List<Process> RootProcesses
        {
            get;
            set;
        }

        public void CalcAllTimes()
        {
            foreach (Process p in RootProcesses)
            {
                Process current = p;
                while (current.HasNext())
                {
                    foreach (Edge e in current.Next)
                    {
                        e.calculateEarliestDatesForNext();
                    }

                }
            }
        }


    }
}
