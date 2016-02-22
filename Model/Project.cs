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
            this.RootProcesses = new List<RootProcess>();
            RootProcess p = new RootProcess();
            
        }

        public List<RootProcess> RootProcesses
        {
            get;
            set;
        }

        public void CalcAllTimes()
        {
            foreach (RootProcess p in RootProcesses)
            {

            }
        }


    }
}
