using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Model.Classes
{
    [Serializable]
    public class MirrorModel
    {
        /* Properties */
        public string Uri { get; set; }
        public bool Preferred { get; set; }
        public bool Disabled { get; set; }

        /* Constructors */
        public MirrorModel() { }
    }
}
