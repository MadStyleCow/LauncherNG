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
    public class SteamInfo : ClassBase
    {
        /* Fields */
        private bool _Available;
        private string _IP;
        private string _Mission;
        private string _Island;
        private int _Players;
        private int _PlayersMax;

        /* Properties */
        public string IP
        {
            get
            {
                return _IP;
            }
            set
            {
                if (_IP != value)
                {
                    _IP = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool Available
        {
            get
            {
                return _Available;
            }
            set
            {
                if(_Available != value)
                {
                    _Available = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Mission
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
        public string Island
        {
            get
            {
                return _Island;
            }
            set
            {
                if(_Island != value)
                {
                    _Island = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int Players
        {
            get
            {
                return _Players;
            }
            set
            {
                if(_Players != value)
                {
                    _Players = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public int PlayersMax
        {
            get
            {
                return _PlayersMax;
            }
            set
            {
                if(_PlayersMax != value)
                {
                    _PlayersMax = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /* Constructors */
        public SteamInfo(string hostname, int steamPort) 
        {
            this.RequestUpdates(hostname, steamPort);
        }

        /* Private methods */
        private IPAddress GetIpAddress(string hostname)
        {
            IPAddress resultAddress = null;

            if (!IPAddress.TryParse(hostname, out resultAddress))
                resultAddress = Dns.GetHostAddresses(hostname)[0];

            return resultAddress;
        }

        private void RequestUpdates(string hostname, int steamPort)
        {
            var remoteServer = ServerQuery.GetServerInstance(EngineType.Source, new IPEndPoint(GetIpAddress(hostname), steamPort));

            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        var remoteServerInfo = remoteServer.GetInfo();

                        Available = true;
                        IP = remoteServerInfo.Address;
                        Mission = remoteServerInfo.Description;
                        Island = remoteServerInfo.Map;
                        Players = remoteServerInfo.Players;
                        PlayersMax = remoteServerInfo.MaxPlayers;
                    }
                    catch (SocketException)
                    {
                        Available = false;
                        IP = String.Empty;
                        Mission = String.Empty;
                        Island = String.Empty;
                        Players = 0;
                        PlayersMax = 0;
                    }
                    catch(Exception ex)
                    {
                        // TODO: LOG IT
                        var exMessage = ex.Message;
                    }
                    finally
                    {
                        Task.Delay(TimeSpan.FromSeconds(60)).Wait();
                    }
                }
            });  
        }
    }
}
