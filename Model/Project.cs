using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netzplantechnik.Model
{
    public class Project
    {

        private Process latestProcess;

        public Project()
        {
            this.EndProcesses = new List<Process>();
            this.RootProcesses = new List<Process>();
        }

        public List<Process> EndProcesses
        {
            get;
            private set;
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
                calculateForward(p);
            }
            foreach (Process p in EndProcesses)
            {
                p.LatestEnd = latestProcess.EarliestEnd;
                p.LatestStart = p.LatestEnd - p.Duration + new TimeSpan(1, 0, 0, 0);
                calculateBackward(p);
            }
        }

        

        private void calculateForward(Process current)
        {
            if (!current.HasNext())
            {
                if (latestProcess == null || latestProcess.EarliestEnd.CompareTo(current.EarliestEnd) < 0)
                {
                    latestProcess = current;
                }
                EndProcesses.Add(current);
            }
            else
            {
                foreach (Edge e in current.Next)
                {
                    e.calculateEarliestDatesForNext();
                    calculateForward(e.Next);
                }
            }
        }

        private void calculateBackward(Process current)
        {
            if (current.HasPrevious())
            {
                foreach (Edge e in current.Previous)
                {
                    e.calculateLatestDatesForPrevious();
                    calculateBackward(e.Previous);
                }
            }
        }


    }
}
