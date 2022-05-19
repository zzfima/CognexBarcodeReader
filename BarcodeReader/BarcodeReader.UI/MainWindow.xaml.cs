using BarcodeReader.Toolkit.MVVM.ViewModels;
using MvvmCross;
using MvvmCross.Plugin.Messenger;
using System.Windows;

namespace BarcodeReader.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MvxSubscriptionToken _token;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = Mvx.IoCProvider.Resolve<CompositeViewModel>();
            var messenger = Mvx.IoCProvider.Resolve<IMvxMessenger>();


            _token = messenger.Subscribe<WindowClose>(
                (res) => { Close(); });
        }
    }
}