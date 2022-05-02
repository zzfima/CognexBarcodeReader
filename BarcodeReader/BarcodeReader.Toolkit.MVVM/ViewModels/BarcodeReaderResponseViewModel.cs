using BarcodeReader.Core;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace BarcodeReader.Toolkit.MVVM.ViewModels
{
    public sealed class BarcodeReaderResponseViewModel : ObservableObject
    {
        private readonly IDeviceCommand _deviceCommand;

        #region Members

        private string _dataStringArrived;
        private Image _imageArrived;

        #endregion

        #region Constructor

        public BarcodeReaderResponseViewModel(IDeviceCommand deviceCommand,
            ConnectStatusViewModel connectStatusViewModel)
        {
            _deviceCommand = deviceCommand;
            ImageReadCommand = new CustomRelayCommand((o) => connectStatusViewModel.IsConnected, ExecuteImageRead);
            DataStringArrived = "DataStringArrived not arrived";

            ImageArrived = new Image
            {
                Source = new BitmapImage(new Uri(
                    AppDomain.CurrentDomain.BaseDirectory + @"\Images\No_image_available.svg.png"))
            };
        }

        #endregion

        #region Derpendency Properties

        public string DataStringArrived
        {
            get => _dataStringArrived;
            set => SetProperty(ref _dataStringArrived, value);
        }

        public Image ImageArrived
        {
            get => _imageArrived;
            set => SetProperty(ref _imageArrived, value);
        }

        public ICommand ImageReadCommand { get; }

        #endregion

        #region Methods

        private void ExecuteImageRead(object o)
        {
            _deviceCommand.SendCommand();
        }

        #endregion
    }
}