using Launcher.Model.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.ViewModel
{
    public class ViewModelMain : ViewModelBase
    {
        /* Properties */
        public ObservableCollection<Server> Servers { get; set; }

        /* Constructors */
        public ViewModelMain()
        {
            this.Servers = new ObservableCollection<Server>()
            {
                new Server() { Id = Guid.NewGuid(), Name = "WOG Test Server #1 [ARMA 3IF]", SteamInfo = new SteamInfo("arma2.wogames.info", 2313)},
                new Server() { Id = Guid.NewGuid(), Name = "WOG Test Server #2 [ARMA 2]", SteamInfo = new SteamInfo("arma2.wogames.info", 2302)},
                new Server() { Id = Guid.NewGuid(), Name = "WOG Test Server #3 [ARMA 3]", SteamInfo = new SteamInfo("arma2.wogames.info", 2303)},
                new Server() { Id = Guid.NewGuid(), Name = "WOG Test Server #4 [ARMA 4]", SteamInfo = new SteamInfo("arma2.wogames.info", 2305)},
            };
        }
    }
}
