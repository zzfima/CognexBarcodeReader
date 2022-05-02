using BarcodeReader.Core;
using BarcodeReader.Implementation.CognexDm375;
using BarcodeReader.Implementation.CognexDm375.ConnectionPointFactories;
using BarcodeReader.Implementation.CognexDm375.DeviceCommands;
using BarcodeReader.Toolkit.MVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.Net;
using System.Windows;

namespace BarcodeReader.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ConfigureServices();
        }

        private static void ConfigureServices()
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()

                    //Services
                    .AddSingleton<IDataManProvider, DataManProvider>()
                    .AddSingleton<IDeviceCommand, TriggerOnDeviceCommand>()
                    .AddSingleton<IAuthentication, Authentication>()
                    .AddSingleton<IBarcodeValueReader, BarcodeValueReader>()
                    .AddSingleton<IConnectionPointFactory>(sp =>
                        new EthSystemConnectionPointFactory(
                            new IPAddress(new byte[] { 192, 168, 0, 135 }),
                            sp.GetRequiredService<IAuthentication>()
                        ))
                    .AddSingleton<IConnector, Connector>()

                    //ViewModels
                    .AddSingleton<WaitViewModel>()
                    .AddSingleton<IpAddressViewModel>()
                    .AddSingleton<ConnectStatusViewModel>()
                    .AddSingleton<ConnectorViewModel>()
                    .AddSingleton<BarcodeReaderResponseViewModel>()
                    .AddSingleton<MenuViewModel>()
                    .BuildServiceProvider());
        }
    }
}