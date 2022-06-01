using BarcodeReader.Core;
using BarcodeReader.Toolkit.MVVM.Properties;
using MvvmCross;
using MvvmCross.ViewModels;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace BarcodeReader.Toolkit.MVVM.ViewModels
{
    public sealed class ConfigurationViewModel : MvxViewModel
    {
        private readonly IDeviceCommand _deviceCommand;

        #region Members

        private string _dataStringArrived;
        private Image _imageArrived;

        #endregion

        #region Constructor

        public ConfigurationViewModel(IDeviceCommand deviceCommand,
            ConnectStatusViewModel connectStatusViewModel)
        {
            _deviceCommand = deviceCommand;
            ConfigurationReadCommand = new CustomRelayCommand((o) => connectStatusViewModel.IsConnected, ExecuteConfigurationRead);
        }

        private void ExecuteConfigurationRead(object obj)
        {
            var dataManProvider = Mvx.IoCProvider.Resolve<IDataManProvider>();
            dataManProvider.DataManSystem.SendCommand("config.export");
        }

        #endregion

        #region Derpendency Properties


        public ICommand ConfigurationReadCommand { get; }

        #endregion

    }
}