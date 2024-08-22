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
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using WinRT;
using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3MultiWindowApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SubWindow : Window
    {
        private SubViewModel _model;
        public SubViewModel Model
        {
            get => _model;
        }

        public int[] BigArray = null;

        public SubWindow()
        {
            this.InitializeComponent();
            BigArray = new int[10000000];
            for (int i = 0; i < BigArray.Length; i++)
                BigArray[i] = i;
            _model = new();
        }

        ~SubWindow()
        { 
            _model = null;
        }

        private async void GetArraySizeButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await ShowDialogAsync($"Size of array is {BigArray.Length}");
        }

        public IAsyncOperation<IUICommand> ShowDialogAsync(string content, string title = null)
        {
            var dlg = new MessageDialog(content, title ?? "");
            var handle = this.As<IWindowNative>().WindowHandle;
            if (handle == IntPtr.Zero)
                throw new InvalidOperationException();
            dlg.As<IInitializeWithWindow>().Initialize(handle);
            return dlg.ShowAsync();
        }

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("3E68D4BD-7135-4D10-8018-9FB6D9F33FA1")]
        internal interface IInitializeWithWindow
        {
            void Initialize(IntPtr hwnd);
        }

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("EECDBF0E-BAE9-4CB6-A68E-9598E1CB57BB")]
        internal interface IWindowNative
        {
            IntPtr WindowHandle { get; }
        }

        private void Window_Closed(object sender, WindowEventArgs args)
        {
            BigArray = null;
            //this.Bindings.StopTracking();
        }
    }
}
