using CommunityToolkit.Mvvm.ComponentModel;

namespace WinUI3MultiWindowApp
{
    public class SubViewModel : ObservableObject
    {
        private int _no = 1;
        public int No
        { 
            get => _no;
            set => SetProperty(ref _no, value);
        }

        private int[] _bigArray = null;
        public int[] BigArray
        {
            get => _bigArray;
            set => SetProperty(ref _bigArray, value);
        }

        public int ArraySize
        {
            get => BigArray.Length;
        }

        public SubViewModel()
        {
            _bigArray = new int[10000000];
            for (int i = 0; i < _bigArray.Length; i++)
                _bigArray[i] = i;
        }
    }
}
