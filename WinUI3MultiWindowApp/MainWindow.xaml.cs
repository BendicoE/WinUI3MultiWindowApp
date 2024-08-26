using Microsoft.UI.Xaml;
using System;

namespace WinUI3MultiWindowApp
{
    public sealed partial class MainWindow : Window
    {

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                var window = new SubWindow();
                window.Model.No = i + 1;
                window.Activate();
                window.Closed += SubWindow_Closed;
            }
        }

        private void SubWindow_Closed(object sender, WindowEventArgs args)
        {
            GC.Collect();
        }

        private void myButton2_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                var window = new SubWindowTwo();
                window.SetWindowNo(i + 1);
                window.Activate();
                window.Closed += SubWindowTwo_Closed;
            }
        }

        private void SubWindowTwo_Closed(object sender, WindowEventArgs args)
        {
            GC.Collect();
        }

        private void myButton3_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                var window = new SubWindowThree();
                window.SetWindowNo(i + 1);
                window.Activate();
                window.Closed += SubWindowThree_Closed;
            }
        }

        private void SubWindowThree_Closed(object sender, WindowEventArgs args)
        {
            GC.Collect();
        }
    }
}
