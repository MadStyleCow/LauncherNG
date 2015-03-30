using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Launcher.Model.Classes;
using System.ComponentModel;

namespace Launcher.ViewModels.ViewModel
{
    public class ServerVM : BaseVM
    {
        /* Fields */
        ServerModel _Server;
 
        /* Properties */
        public Guid Id
        {
            get
            {
                return _Server.Id;
            }
        }

        public string Name
        {
            get
            {
                return _Server.Name;
            }
        }

        public string Hostname
        {
            get
            {
                return _Server.Hostname;
            }
        }

        public string Port
        {
            get
            {
                return _Server.Port.ToString();
            }
        }

        public string Online
        {
            get
            {
                return _Server.SteamData.Online ? "Online" : "Offline";
            }
        }

        public string Address
        {
            get
            {
                return String.Format("{0}:{1}",Hostname, Port);
            }
        }

        public string Mission
        {
            get
            {
                return _Server.SteamData.Mission;
            }
        }

        public string Island
        {
            get
            {
                return _Server.SteamData.Island;
            }
        }

        public int CurrentPlayers
        {
            get
            {
                return _Server.SteamData.CurrentPlayers;
            }
        }

        public int MaxPlayers
        {
            get
            {
                return _Server.SteamData.MaxPlayers;
            }
        }

        public string FrameContent
        {
            get
            {
                return "http://www.wogames.info";
            }
        }

        

        /* Event handlers */
        public void ServerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged(e.PropertyName);
        }

        /* Constructors */
        public ServerVM(ServerModel pServerModel)
        {
            this._Server = pServerModel;
            _Server.PropertyChanged += ServerPropertyChanged;
        }
    }
}
