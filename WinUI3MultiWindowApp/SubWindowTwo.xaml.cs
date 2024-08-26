using Microsoft.UI.Xaml;

namespace WinUI3MultiWindowApp
{
    public sealed partial class SubWindowTwo : Window
    {
        public SubWindowTwo()
        {
            this.InitializeComponent();
        }

        public void SetWindowNo(int i)
        {
            thePage.Model.No = i;
        }
    }
}
