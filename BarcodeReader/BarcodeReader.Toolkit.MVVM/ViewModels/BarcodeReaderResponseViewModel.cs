using BarcodeReader.Core;
using BarcodeReader.Toolkit.MVVM.Properties;
using MvvmCross.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace BarcodeReader.Toolkit.MVVM.ViewModels
{
    public sealed class BarcodeReaderResponseViewModel : MvxViewModel
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
                Source = Helpers.ImageHelper.Convert(Resources.No_image_available_svg)
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