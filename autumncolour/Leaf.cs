using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autumncolour
{
    public class Leaf
    {
        public LeafColour CurrentColour { get; set; }
        public List<LeafColour> PossibleColours { get; set; }
    }
}
