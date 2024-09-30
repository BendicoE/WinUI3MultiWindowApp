using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUI3MultiWindowApp
{
    public class GlobalModel : ObservableObject
    {
        private string _name = "WinUI3MultiWindowApp";
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
    }
}
