using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3MultiWindowApp
{
    public sealed partial class MainView : UserControl
    {
        public MainView()
        {
            this.InitializeComponent();
            WindowList = new();
        }

        public static List<Window> WindowList { get; private set; }

        public static Window GetFromAppWindow(AppWindow appWindow)
        {
            return WindowList.Where(w => w.AppWindow == appWindow).FirstOrDefault();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                var window = new SubWindow();
                window.Model.No = i + 1;
                window.Activate();
                WindowList.Add(window);
                window.Closed += SubWindowWindow_Closed;
            }
        }

        private void SubWindowWindow_Closed(object sender, WindowEventArgs args)
        {
            if (sender is Window window)
            {
                WindowList.Remove(window);
                window.Closed -= SubWindowWindow_Closed;
            }
        }

        private void myButton2_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                var window = new SubWindowTwo();
                window.SetWindowNo(i + 1);
                window.Activate();
                WindowList.Add(window);
                window.Closed += SubWindowTwoWindow_Closed;
            }
        }

        private void SubWindowTwoWindow_Closed(object sender, WindowEventArgs args)
        {
            if (sender is Window window)
            {
                WindowList.Remove(window);
                window.Closed -= SubWindowTwoWindow_Closed;
            }
        }


        private void myButton3_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                var window = new SubWindowThree();
                window.SetWindowNo(i + 1);
                window.Activate();
                WindowList.Add(window);
                window.Closed += SubWindowThreeWindow_Closed;
            }
        }

        private void SubWindowThreeWindow_Closed(object sender, WindowEventArgs args)
        {
            if (sender is Window window)
            {
                WindowList.Remove(window);
                window.Closed -= SubWindowThreeWindow_Closed;
            }
        }
    }
}
