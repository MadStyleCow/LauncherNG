using Launcher.Common.Enums;
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Launcher.Model.Classes
{
    [Serializable]
    public class ServerModel : BaseModel
    {
        /* Fields */
        SteamModel _SteamData;

        /* Properties */
        public Guid Id { get; set; }
        public GameType Type { get; set; }
        public String Name { get; set; }
        public String Hostname { get; set; }
        public String Password { get; set; }
        public Boolean Displayed { get; set; }
        public Int32 ThreadCount { get; set; }
        public Int32 Port { get; set; }
        public Int32 SteamQueryPort { get; set; }
        public MirrorCollectionModel ChangelogMirrors { get; set; }
        public MirrorCollectionModel AddonMirrors { get; set; }

        [XmlIgnore]
        public SteamModel SteamData
        {
            get
            {
                if (_SteamData == null)
                {
                    _SteamData = new SteamModel(Hostname, SteamQueryPort);
                    _SteamData.PropertyChanged += SteamPropertyChanged;
                }

                return _SteamData;
            }
        }

        /* Event handlers */
        public void SteamPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged(e.PropertyName);
        }

        /* Constructors */
        public ServerModel() { }
    }
}
