using Microsoft.UI.Xaml;
using System.ComponentModel;
using System.Runtime.CompilerServices;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3MultiWindowApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SubWindow : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private SubViewModel _model;
        public SubViewModel Model
        {
            get => _model;
            set
            {
                if (_model != value)
                {
                    _model = value;
                    OnPropertyChanged(nameof(Model));
                }
            }
        }

        public SubWindow()
        {
            this.InitializeComponent();
            Model = new();
        }

        private void Window_Closed(object sender, WindowEventArgs args)
        {
            // BARF!! Without this, the application will leak a SubViewModel object per window
            Model = null;
        }
    }
}
