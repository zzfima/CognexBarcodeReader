using MvvmCross.ViewModels;

namespace BarcodeReader.Toolkit.MVVM.ViewModels
{
    public sealed class ConnectStatusViewModel : MvxViewModel
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