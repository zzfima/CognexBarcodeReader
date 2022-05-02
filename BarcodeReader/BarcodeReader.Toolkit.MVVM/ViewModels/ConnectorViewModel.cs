using BarcodeReader.Core;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace BarcodeReader.Toolkit.MVVM.ViewModels
{
    public sealed class ConnectorViewModel : ObservableObject
    {
        #region Members

        private readonly IConnector _connector;
        private readonly WaitViewModel _waitViewModel;
        private ConnectStatusViewModel _connectStatusViewModel;

        #endregion

        #region Constructor

        public ConnectorViewModel(IConnector connector, WaitViewModel waitViewModel,
            ConnectStatusViewModel connectStatusViewModel)
        {
            DisconnectCommand = new CustomRelayCommand((o) => ConnectStatusViewModel.IsConnected, ExecuteDisconnect);
            ConnectCommand = new CustomRelayCommand((o) => !ConnectStatusViewModel.IsConnected, ExecuteConnect);
            _waitViewModel = waitViewModel;
            _connectStatusViewModel = connectStatusViewModel;
            _connectStatusViewModel.IsConnected = false;
            _connector = connector;
        }

        #endregion

        #region Dependency Properties

        public ConnectStatusViewModel ConnectStatusViewModel
        {
            get => _connectStatusViewModel;
            set => SetProperty(ref _connectStatusViewModel, value);
        }

        public string ConnectButtonToolTip => "Connect to device";

        public string DisconnectButtonToolTip => "Disconnect from device";

        public ICommand ConnectCommand { get; }


        public ICommand DisconnectCommand { get; }

        private async void ExecuteConnect(object o)
        {
            _waitViewModel.IsWaiting = true;
            var isSucceedDoConnect = await _connector.Connect();
            if (isSucceedDoConnect)
            {
                ConnectStatusViewModel.IsConnected = true;
            }
            else
                ConnectStatusViewModel.IsConnected = false;

            _waitViewModel.IsWaiting = false;
            CommandManager.InvalidateRequerySuggested();
        }

        private async void ExecuteDisconnect(object o)
        {
            _waitViewModel.IsWaiting = true;
            await _connector.Disconnect();
            ConnectStatusViewModel.IsConnected = false;
            _waitViewModel.IsWaiting = false;
            CommandManager.InvalidateRequerySuggested();
        }

        #endregion
    }
}