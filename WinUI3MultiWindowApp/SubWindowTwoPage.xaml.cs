using Microsoft.UI.Xaml.Controls;

namespace WinUI3MultiWindowApp
{
    public sealed partial class SubWindowTwoPage : Page
    {
        public SubViewModel Model { get; set; }

        public SubWindowTwoPage()
        {
            this.InitializeComponent();
            Model = new();
        }

        private void myButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            Model.IncreaseArrayLength();
        }
    }
}
