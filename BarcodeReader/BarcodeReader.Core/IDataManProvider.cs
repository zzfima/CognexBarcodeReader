using Cognex.DataMan.SDK;

namespace BarcodeReader.Core
{
    public interface IDataManProvider
    {
        DataManSystem DataManSystem { get; }
    }
}