using Microsoft.UI.Xaml;
using System;

namespace WinUI3MultiWindowApp
{
    public sealed partial class SubWindowThree : Window
    {
        public SubWindowThree()
        {
            this.InitializeComponent();
            Closed += SubWindowThree_Closed;
            
        }

        private void SubWindowThree_Closed(object sender, WindowEventArgs args)
        {
            Closed -= SubWindowThree_Closed;
            UnloadObject(theView);
        }

        public void SetWindowNo(int i)
        {
            theView.SetModelNo(i);
        }
    }
}
