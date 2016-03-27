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
        private EdgeFactory edgeFactory;

        public Project()
        {
            this.EndProcesses = new List<Process>();
            this.RootProcesses = new List<Process>();
            this.edgeFactory = new EdgeFactory();
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

        public void CalculateAllTimes()
        {
            CalculateForwardForAllProcesses();
            CalculateBackwardsForAllProcesses();
        }

        private void CalculateForwardForAllProcesses()
        {
            foreach (Process p in RootProcesses)
            {
                CalculateForward(p);
            }
        }

        private void CalculateBackwardsForAllProcesses()
        {
            foreach (Process p in EndProcesses)
            {
                p.LatestEnd = latestProcess.EarliestEnd;
                p.LatestStart = p.LatestEnd - p.Duration + new TimeSpan(1, 0, 0, 0);
                CalculateBackward(p);
            }
        }

        private void CalculateForward(Process current)
        {
            if (!current.HasNext())
                AddProcessToEndProcesses(current);
            else
                CalculateDatesForwardForAllEdges(current);
        }

        private void CalculateDatesForwardForAllEdges(Process current)
        {
            foreach (Edge e in current.Next)
            {
                e.calculateEarliestDatesForNext();
                CalculateForward(e.Next);
            }
        }

        private void AddProcessToEndProcesses(Process current)
        {
            CompareToLatestProcess(current);
            EndProcesses.Add(current);
        }

        private void CompareToLatestProcess(Process current)
        {
            if (latestProcess == null || latestProcess.EarliestEnd.CompareTo(current.EarliestEnd) < 0)
                latestProcess = current;
        }

        private void CalculateBackward(Process current)
        {
            if (current.HasPrevious())
                CalculateBackwardForAllEdges(current);
        }

        private void CalculateBackwardForAllEdges(Process current)
        {
            foreach (Edge e in current.Previous)
            {
                e.calculateLatestDatesForPrevious();
                CalculateBackward(e.Previous);
            }
        }


    }
}
