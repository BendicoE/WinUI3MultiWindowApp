﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace WinUI3MultiWindowApp
{
    public class SubViewModel : ObservableObject
    {
        private int _no = 1;
        public int No
        { 
            get => _no;
            set
            {
                if (_no != value)
                { 
                    SetProperty(ref _no, value); 
                    OnPropertyChanged(nameof(ButtonName));
                }
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string ButtonName
        {
            get => $"Button No {No}";
        }

        private int[] _bigArray = null;
        public int[] BigArray
        {
            get => _bigArray;
            set
            {
                if (value != _bigArray)
                {
                    SetProperty(ref _bigArray, value);
                    OnPropertyChanged(nameof(ArraySize));
                }
            }
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

        public void IncreaseArrayLength()
        {
            var newArray = new int[20000000];
            for (int i = 0; i < newArray.Length; i++)
                newArray[i] = i;
            BigArray = newArray;
        }
    }
}
