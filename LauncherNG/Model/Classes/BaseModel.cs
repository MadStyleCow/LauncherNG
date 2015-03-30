using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using System.Runtime.CompilerServices;

namespace Launcher.Model.Classes
{
    public class BaseModel : INotifyPropertyChanged
    {
        //basic BaseVM
        internal void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    } 
}
