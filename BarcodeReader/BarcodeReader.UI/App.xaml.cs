using BarcodeReader.Core;
using BarcodeReader.Implementation.CognexDm375;
using BarcodeReader.Implementation.CognexDm375.ConnectionPointFactories;
using BarcodeReader.Implementation.CognexDm375.DeviceCommands;
using BarcodeReader.Toolkit.MVVM.ViewModels;
using MvvmCross.Base;
using MvvmCross.IoC;
using System.Windows;
using MvvmCross.Plugin.Messenger;

namespace BarcodeReader.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IMvxIoCProvider IoCProvider => MvxSingleton<IMvxIoCProvider>.Instance;

        public App()
        {
            ConfigureServices();
        }

        private static void ConfigureServices()
        {
            var instance = MvxIoCProvider.Initialize();
            instance.ConstructAndRegisterSingleton<IMvxMessenger, MvxMessengerHub>();
            instance.ConstructAndRegisterSingleton<IAuthentication, Authentication>();
            instance.ConstructAndRegisterSingleton<IConnectionPointFactory, EthSystemConnectionPointFactory>(
                );
            instance.ConstructAndRegisterSingleton<IDataManProvider, DataManProvider>();
            instance.ConstructAndRegisterSingleton<IDeviceCommand, TriggerOnDeviceCommand>();
            instance.ConstructAndRegisterSingleton<IBarcodeValueReader, BarcodeValueReader>();
            instance.ConstructAndRegisterSingleton<IConnector, Connector>();

            //ViewModels
            instance.ConstructAndRegisterSingleton<WaitViewModel, WaitViewModel>();
            instance.ConstructAndRegisterSingleton<IpAddressViewModel, IpAddressViewModel>();
            instance.ConstructAndRegisterSingleton<ConnectStatusViewModel, ConnectStatusViewModel>();
            instance.ConstructAndRegisterSingleton<ConnectorViewModel, ConnectorViewModel>();
            instance.ConstructAndRegisterSingleton<BarcodeReaderResponseViewModel, BarcodeReaderResponseViewModel>();
            instance.ConstructAndRegisterSingleton<MenuViewModel, MenuViewModel>();
            instance.ConstructAndRegisterSingleton<CompositeViewModel, CompositeViewModel>();


            //Ioc.Default.ConfigureServices(
            //    new ServiceCollection()

            //        //Services
            //        .AddSingleton<IDataManProvider, DataManProvider>()
            //        .AddSingleton<IDeviceCommand, TriggerOnDeviceCommand>()
            //        //.AddSingleton<IAuthentication, Authentication>()
            //        .AddSingleton<IBarcodeValueReader, BarcodeValueReader>()
            //        .AddSingleton<IConnectionPointFactory>(sp =>
            //            new EthSystemConnectionPointFactory(
            //                new IPAddress(new byte[] { 192, 168, 0, 135 }),
            //                sp.GetRequiredService<IAuthentication>()
            //            ))
            //        .AddSingleton<IConnector, Connector>()

            //        //ViewModels
            //        .AddSingleton<WaitViewModel>()
            //        .AddSingleton<IpAddressViewModel>()
            //        .AddSingleton<ConnectStatusViewModel>()
            //        .AddSingleton<ConnectorViewModel>()
            //        .AddSingleton<BarcodeReaderResponseViewModel>()
            //        .AddSingleton<MenuViewModel>()
            //        .BuildServiceProvider());
        }
    }
}