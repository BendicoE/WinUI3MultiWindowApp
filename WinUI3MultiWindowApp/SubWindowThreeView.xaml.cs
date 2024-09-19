using System;
using System.Reflection;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Popups;
using WinRT;
using WinRT.Interop;
using static Windows.Storage.Pickers.WindowsStoragePickersExtensions;

namespace WinUI3MultiWindowApp
{
    public sealed partial class SubWindowThreeView : UserControl
    {
        public SubWindowThree ParentWindow
        {
            get
            {
                return null;
            }
        }

        public SubViewModel Model { get; set; }

        public GlobalModel Globals
        {
            get => ((App)Application.Current).Globals;
        }

        public SubWindowThreeView()
        {
            this.InitializeComponent();
            Model = new();
        }

        public void SetModelNo(int no)
        {
            Model.No = no;
        }

        private void myButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            Model.IncreaseArrayLength();
        }

        private async void ButtonCommand_ExecuteRequested(Microsoft.UI.Xaml.Input.XamlUICommand sender, Microsoft.UI.Xaml.Input.ExecuteRequestedEventArgs args)
        {
            var messageDialog = new MessageDialog($"You clicked the command button in view {Model.No}", "Message");
            IInitializeWithWindow withWindow = messageDialog.As<IInitializeWithWindow>();
            var appWnd = AppWindow.GetFromWindowId(XamlRoot.ContentIslandEnvironment.AppWindowId);
            var window = MainView.GetFromAppWindow(appWnd);
            if (window != null)
            {
                //var handle = WindowNative.GetWindowHandle(window);
                var handle = window.As<IWindowNative>().WindowHandle;
                try
                {
                    withWindow.Initialize(handle);
                    UICommand cmd = await messageDialog.ShowAsync() as UICommand;
                }
                catch
                {
                }
            }
        }

        private void ButtonCommand_CanExecuteRequested(Microsoft.UI.Xaml.Input.XamlUICommand sender, Microsoft.UI.Xaml.Input.CanExecuteRequestedEventArgs args)
        {
            args.CanExecute = true;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            Model = null;
            GC.Collect();
        }
    }
}
