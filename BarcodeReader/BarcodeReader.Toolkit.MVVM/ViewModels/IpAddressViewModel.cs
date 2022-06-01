using MvvmCross.ViewModels;

namespace BarcodeReader.Toolkit.MVVM.ViewModels
{
    public sealed class IpAddressViewModel : MvxViewModel
    {
        #region Members

        private byte _ipPart1;
        private byte _ipPart2;
        private byte _ipPart3;
        private byte _ipPart4;

        #endregion

        #region Constructor

        public IpAddressViewModel()
        {
            _ipPart1 = 192;
            _ipPart2 = 168;
            _ipPart3 = 0;
            _ipPart4 = 6;
        }

        #endregion

        #region Dependency Properties

        public byte IpPart1
        {
            get => _ipPart1;
            set => SetProperty(ref _ipPart1, value);
        }

        public byte IpPart2
        {
            get => _ipPart2;
            set => SetProperty(ref _ipPart2, value);
        }

        public byte IpPart3
        {
            get => _ipPart3;
            set => SetProperty(ref _ipPart3, value);
        }

        public byte IpPart4
        {
            get => _ipPart4;
            set => SetProperty(ref _ipPart4, value);
        }

        #endregion
    }
}