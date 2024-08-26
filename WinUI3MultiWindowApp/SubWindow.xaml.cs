using Microsoft.UI.Xaml;

namespace WinUI3MultiWindowApp
{
    public sealed partial class SubWindow : Window
    {
        public SubViewModel Model { get; set; }

        public SubWindow()
        {
            this.InitializeComponent();
            Model = new();
        }

        private void Window_Closed(object sender, WindowEventArgs args)
        {
            // BARF!! Without this, the application will leak a SubViewModel object per window
            //Model = null;
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            Model.IncreaseArrayLength();
        }
    }
}
