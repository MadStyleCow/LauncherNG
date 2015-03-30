using Launcher.Model.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Launcher.ViewModels.ViewModel
{
    public class MainVM : BaseVM
    {
        /* Tasks */
        Task InitializeTask;

        /* Properties */
        public ObservableCollection<ServerVM> Servers { get; set; }

        /* Constructors */
        public MainVM()
        {
            /* Load server list asynchronously */
            Servers = new ObservableCollection<ServerVM>();
            // TODO: REMOVE HARDCODE
            InitializeTask = Initialize(@"http://www.wogames.info/launcherng/servermanifest.xml");
        }

        /* Private methods */
        private async Task Initialize(String pUri)
        {
            foreach (ServerModel serverModel in await ServerSetModel.GetServers(@"http://www.wogames.info/launcherng/servermanifest.xml"))
            {
                await Application.Current.Dispatcher.BeginInvoke(new Action(() => Servers.Add(new ServerVM(serverModel))));
            }
        }
    }
}
