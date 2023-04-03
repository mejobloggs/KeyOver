using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyOver.Models;
public class KeyboardLayoutModel
{
    public List<KeyGroup> KeyGroups { get; set; }
    public class KeyGroup
    {
        public string UniqueName { get; set; }
        public List<List<string>> KeyRows { get; set; }

        //future ideas
        //public int Angle { get; set; }
        //public string VerticalAlignment { get; set; }
        public GridAlignment GridAlignment { get; set; }
        public string IndexFingerLetter { get; set; }
    }

    public enum GridAlignment
    {
        Stagger,
        Ortho
    }
}
