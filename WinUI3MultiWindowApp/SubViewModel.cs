using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUI3MultiWindowApp
{
    public class SubViewModel : ObservableObject
    {
        private int _no = 1;
        public int No
        { 
            get => _no;
            set => SetProperty(ref _no, value);
        }
    }
}
