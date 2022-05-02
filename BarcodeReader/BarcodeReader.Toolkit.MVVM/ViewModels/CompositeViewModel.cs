using System.Windows;
using BarcodeReader.Core;
using BarcodeReader.Toolkit.MVVM.Helpers;
using Cognex.DataMan.SDK.Utils;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace BarcodeReader.Toolkit.MVVM.ViewModels
{
    public sealed class CompositeViewModel : ObservableObject
    {
        #region Members

        private IpAddressViewModel _ipAddressViewModel;
        private ConnectorViewModel _connectorViewModel;
        private BarcodeReaderResponseViewModel _barcodeReaderResponseViewModel;
        private WaitViewModel _waitViewModel;
        private MenuViewModel _menuViewModel;

        #endregion

        #region Constructor

        public CompositeViewModel()
        {
            InstantiateViewModel();
            InstantiateRegisterMessenger();
        }

        private void InstantiateRegisterMessenger()
        {
            WeakReferenceMessenger.Default.Register<ComplexResult>(this,
                (obj, complexResult) =>
                {
                    ComplexResultCompleted(complexResult);
                });
            WeakReferenceMessenger.Default.Register<WindowHelp>(this,
                (obj, res) =>
                {
                    Window win2 = new Window();
                    win2.ShowDialog();
                });
        }

        private void InstantiateViewModel()
        {
            _waitViewModel = Ioc.Default.GetRequiredService<WaitViewModel>();
            _ipAddressViewModel = Ioc.Default.GetRequiredService<IpAddressViewModel>();
            _connectorViewModel = Ioc.Default.GetRequiredService<ConnectorViewModel>();
            _barcodeReaderResponseViewModel = Ioc.Default.GetRequiredService<BarcodeReaderResponseViewModel>();
            _menuViewModel = Ioc.Default.GetRequiredService<MenuViewModel>();
        }

        #endregion

        public void ComplexResultCompleted(ComplexResult complexResult)
        {
            var barcodeValueReader = Ioc.Default.GetRequiredService<IBarcodeValueReader>();
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