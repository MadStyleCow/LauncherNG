using System;
using System.ComponentModel;

namespace Launcher.Model.Classes
{
    public class Server : ClassBase
    {
        /* Fields */
        private Guid _Id;
        private String _Name;
        private SteamInfo _SteamInfo;

        /* Properties */
        public Guid Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public SteamInfo SteamInfo
        {
            get
            {
                return _SteamInfo;
            }
            set
            {
                if (_SteamInfo != value)
                {
                    _SteamInfo = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
