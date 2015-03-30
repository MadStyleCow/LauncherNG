using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Model.Classes
{
    [Serializable]
    public class MirrorCollectionModel
    {
        /* Properties */
        public List<MirrorModel> Mirrors { get; set; }

        /* Constructors */
        public MirrorCollectionModel() { }
    }
}
