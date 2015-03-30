using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using QueryMaster;
using System.Net.Sockets;

namespace Launcher.Model.Classes
{
    public class SteamModel : BaseModel
    {
        /* Fields */
        Boolean _Online;
        String _Mission;
        String _Island;
        Int32 _CurrentPlayers;
        Int32 _MaxPlayers;

        /* Properties */
        public Boolean Online
        {
            get
            {
                return _Online;
            }
            set
            {
                if(_Online != value)
                {
                    _Online = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public String Mission
        {
            get
            {
                return _Mission;
            }
            set
            {
                if (_Mission != value)
                {
                    _Mission = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public String Island
        {
            get
            {
                return _Island;
            }
            set
            {
                if (_Island != value)
                {
                    _Island = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Int32 CurrentPlayers
        {
            get
            {
                return _CurrentPlayers;
            }
            set
            {
                if (_CurrentPlayers != value)
                {
                    _CurrentPlayers = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Int32 MaxPlayers
        {
            get
            {
                return _MaxPlayers;
            }
            set
            {
                if (_MaxPlayers != value)
                {
                    _MaxPlayers = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /* Constructors */
        public SteamModel(String pHostname, Int32 pQueryPort)
        {
            RequestUpdates(pHostname, pQueryPort);
        }

        /* Private methods */
        private IPAddress GetIpAddress(string pHostname)
        {
            IPAddress resultAddress = null;
            if (!IPAddress.TryParse(pHostname, out resultAddress))
                resultAddress = Dns.GetHostAddresses(pHostname)[0];
            return resultAddress;
        }

        private void RequestUpdates(String pHostname, Int32 pQueryPort)
        {
            Server serverInstance = ServerQuery.GetServerInstance(EngineType.Source, new IPEndPoint(GetIpAddress(pHostname), pQueryPort));

            Task.Run(() =>
                {
                    while (true)
                    {
                        try
                        {
                            ServerInfo serverInfo = serverInstance.GetInfo();

                            Online = true;
                            Mission = serverInfo.Description;
                            Island = serverInfo.Map;
                            CurrentPlayers = serverInfo.Players;
                            MaxPlayers = serverInfo.MaxPlayers;
                        }
                        catch (SocketException)
                        {
                            Online = false;
                            Mission = String.Empty;
                            Island = String.Empty;
                            CurrentPlayers = 0;
                            MaxPlayers = 0;
                        }
                        catch (Exception)
                        {
                            // TODO: Logging?
                        }
                        finally
                        {
                            // TODO: Remove hardcode
                            Task.Delay(TimeSpan.FromSeconds(30)).Wait();
                        }
                    }
                });
        }
    }
}
