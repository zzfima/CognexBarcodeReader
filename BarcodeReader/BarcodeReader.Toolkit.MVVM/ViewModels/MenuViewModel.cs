using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace BarcodeReader.Toolkit.MVVM.ViewModels
{
    public sealed class MenuViewModel : DependencyObject
    {
        public MenuViewModel()
        {
            MenuExitCommand = new RelayCommand(ExecuteExit);
            MenuHelpCommand = new RelayCommand(ExecuteHelp);
        }

        private void ExecuteExit()
        {
            WeakReferenceMessenger.Default.Send(new WindowClose());
        }

        private void ExecuteHelp()
        {
            WeakReferenceMessenger.Default.Send(new WindowHelp());
        }

        public ICommand MenuExitCommand { get; set; }

        public ICommand MenuHelpCommand { get; set; }
    }
}