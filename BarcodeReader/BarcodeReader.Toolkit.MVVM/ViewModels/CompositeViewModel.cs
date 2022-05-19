using BarcodeReader.Core;
using BarcodeReader.Toolkit.MVVM.Helpers;
using Cognex.DataMan.SDK.Utils;
using MvvmCross;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using System.Windows;
using BarcodeReader.Implementation.CognexDm375;

namespace BarcodeReader.Toolkit.MVVM.ViewModels
{
    public sealed class CompositeViewModel : MvxViewModel
    {
        private readonly IMvxMessenger _messenger;
        private MvxSubscriptionToken _token;

        #region Members

        private IpAddressViewModel _ipAddressViewModel;
        private ConnectorViewModel _connectorViewModel;
        private BarcodeReaderResponseViewModel _barcodeReaderResponseViewModel;
        private WaitViewModel _waitViewModel;
        private MenuViewModel _menuViewModel;

        #endregion

        #region Constructor

        public CompositeViewModel(IMvxMessenger messenger)
        {
            _messenger = messenger;
            InstantiateViewModel();
            InstantiateRegisterMessenger();
        }

        private void InstantiateRegisterMessenger()
        {
            _token = _messenger.Subscribe<MvxMessageComplexResult>(
                res => ComplexResultCompleted(res.ComplexResult));

            _token = _messenger.Subscribe<WindowHelp>(
                (res) =>
                {
                    Window win2 = new Window();
                    win2.ShowDialog();
                });
        }

        private void InstantiateViewModel()
        {
            _waitViewModel = Mvx.IoCProvider.Resolve<WaitViewModel>();
            _ipAddressViewModel = Mvx.IoCProvider.Resolve<IpAddressViewModel>();
            _connectorViewModel = Mvx.IoCProvider.Resolve<ConnectorViewModel>();
            _barcodeReaderResponseViewModel = Mvx.IoCProvider.Resolve<BarcodeReaderResponseViewModel>();
            _menuViewModel = Mvx.IoCProvider.Resolve<MenuViewModel>();
        }

        #endregion

        public void ComplexResultCompleted(ComplexResult complexResult)
        {
            var barcodeValueReader = Mvx.IoCProvider.Resolve<IBarcodeValueReader>();
            barcodeValueReader.ComplexResultRead(complexResult);

            BarcodeReaderResponseViewModel.DataStringArrived = barcodeValueReader.ReadResult;

            var drawingImage = barcodeValueReader.Images[0];

            BarcodeReaderResponseViewModel.ImageArrived.Dispatcher.Invoke(() =>
                BarcodeReaderResponseViewModel.ImageArrived.Source = ImageHelper.Convert(drawingImage));
        }

        #region Dependency Properties

        public IpAddressViewModel IpAddressViewModel
        {
            get => _ipAddressViewModel;
            set => SetProperty(ref _ipAddressViewModel, value);
        }

        public ConnectorViewModel ConnectorViewModel
        {
            get => _connectorViewModel;
            set => SetProperty(ref _connectorViewModel, value);
        }

        public BarcodeReaderResponseViewModel BarcodeReaderResponseViewModel
        {
            get => _barcodeReaderResponseViewModel;
            set => SetProperty(ref _barcodeReaderResponseViewModel, value);
        }

        public MenuViewModel MenuViewModel
        {
            get => _menuViewModel;
            set => SetProperty(ref _menuViewModel, value);
        }

        public WaitViewModel WaitViewModel
        {
            get => _waitViewModel;
            set => SetProperty(ref _waitViewModel, value);
        }

        #endregion
    }
}