using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace BarcodeReader.Toolkit.MVVM.ViewModels
{
    public sealed class ConnectStatusViewModel : ObservableObject
    {
        #region Members

        private bool _isConnected;

        #endregion

        #region Dependency Properties

        public bool IsConnected
        {
            get => _isConnected;
            set => SetProperty(ref _isConnected, value);
        }

        #endregion
    }
}