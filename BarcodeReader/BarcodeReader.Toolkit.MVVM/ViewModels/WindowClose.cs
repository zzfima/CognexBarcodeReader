namespace BarcodeReader.Toolkit.MVVM.ViewModels
{
    public sealed class WindowClose : MvvmCross.Plugin.Messenger.MvxMessage
    {
        public WindowClose(object sender) : base(sender)
        {
        }
    }
}