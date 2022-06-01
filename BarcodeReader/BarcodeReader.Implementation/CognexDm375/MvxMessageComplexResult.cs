using Cognex.DataMan.SDK.Utils;
using MvvmCross.Plugin.Messenger;

namespace BarcodeReader.Implementation.CognexDm375
{
    public class MvxMessageComplexResult : MvxMessage
    {
        public ComplexResult ComplexResult { get; private set;}

        public MvxMessageComplexResult(object sender, ComplexResult complex) : base(sender)
        {
            ComplexResult = complex;
        }
    }
}