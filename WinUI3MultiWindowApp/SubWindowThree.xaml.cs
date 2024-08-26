using Microsoft.UI.Xaml;

namespace WinUI3MultiWindowApp
{
    public sealed partial class SubWindowThree : Window
    {
        public SubWindowThree()
        {
            this.InitializeComponent();
        }

        public void SetWindowNo(int i)
        {
            theView.Model.No = i;
        }
    }
}
