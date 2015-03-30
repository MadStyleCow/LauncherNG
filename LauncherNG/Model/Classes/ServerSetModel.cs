using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Launcher.Model.Utilities;

namespace Launcher.Model.Classes
{
    [Serializable]
    public class ServerSetModel : BaseModel
    {
        /* Properties */
        public List<ServerModel> Servers { get; set; }

        /* Constructors */
        public ServerSetModel() { }
        
        /* Public methods */
        public static async Task<List<ServerModel>> GetServers(String pUri)
        {
            try
            {
                var deserializedServerList = await new WebClient().DownloadStringTaskAsync(pUri);

                return ((ServerSetModel)(XMLSerializer.DeserializeFromString(deserializedServerList, typeof(ServerSetModel)))).Servers;
            }
            catch(WebException)
            {
                // TODO: Load a cached list
                return new List<ServerModel>();
            }
            catch(Exception)
            {
                // TODO: Log
                return new List<ServerModel>();
            }
        }
    }
}
