using BarcodeReader.Toolkit.MVVM.ViewModels;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Windows;

namespace BarcodeReader.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            WeakReferenceMessenger.Default.Register<WindowClose>(this,
                (obj, res) => Close());
        }
    }
}