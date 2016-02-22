using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netzplantechnik.Model
{
    public class EdgeFactory
    {
        public EdgeFactory() {
        }

        public Edge createEdge(Process previous, Process next)
        {
            return new EndStartEdge() { Previous = previous, Next = next };
        }

        public Edge createEdge(EdgeType type, Process previous, Process next, TimeSpan timespan)
        {
            switch (type)
            {
                case EdgeType.EndStartEdge:
                    return createEdge(previous, next);
                case EdgeType.EndStartEdgeWithWait:
                    return new EndStartEdgeWithWait() { Previous = previous, Next = next, Wait = timespan};
                default:
                    throw new Exception();
            }
        }

    }

    public enum EdgeType
    {
        EndStartEdge,
        EndStartEdgeWithWait
    }
}
