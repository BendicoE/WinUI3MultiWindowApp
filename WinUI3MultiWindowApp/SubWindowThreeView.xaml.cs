using Microsoft.UI.Xaml.Controls;

namespace WinUI3MultiWindowApp
{
    public sealed partial class SubWindowThreeView : UserControl
    {
        public SubViewModel Model { get; set; }

        public SubWindowThreeView()
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
