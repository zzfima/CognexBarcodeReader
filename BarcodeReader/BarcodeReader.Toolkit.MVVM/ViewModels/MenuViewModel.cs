using MvvmCross.Commands;
using MvvmCross.Plugin.Messenger;
using System.Windows;
using System.Windows.Input;

namespace BarcodeReader.Toolkit.MVVM.ViewModels
{
    public sealed class MenuViewModel : DependencyObject
    {
        private readonly IMvxMessenger _messenger;

        public MenuViewModel(IMvxMessenger messenger)
        {
            _messenger = messenger;
            MenuExitCommand = new MvxCommand(ExecuteExit);
            MenuHelpCommand = new MvxCommand(ExecuteHelp);
        }

        private void ExecuteExit()
        {
            _messenger.Publish<WindowClose>(new WindowClose(this));
        }

        private void ExecuteHelp()
        {
            _messenger.Publish<WindowHelp>(new WindowHelp(this));
        }

        public ICommand MenuExitCommand { get; set; }

        public ICommand MenuHelpCommand { get; set; }
    }
}