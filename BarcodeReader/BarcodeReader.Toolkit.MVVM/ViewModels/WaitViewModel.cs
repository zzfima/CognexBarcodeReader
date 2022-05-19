using MvvmCross.ViewModels;

namespace BarcodeReader.Toolkit.MVVM.ViewModels
{
    public sealed class WaitViewModel : MvxViewModel
    {
        #region Members

        private bool _isWaiting;

        #endregion


        #region Constructor

        public WaitViewModel()
        {
            _isWaiting = false;
        }

        #endregion

        #region Dependency Properties

        public bool IsWaiting
        {
            get => _isWaiting;
            set => SetProperty(ref _isWaiting, value);
        }

        #endregion
    }
}