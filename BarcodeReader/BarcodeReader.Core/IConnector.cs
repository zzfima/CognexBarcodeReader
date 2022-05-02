using System.Threading.Tasks;

namespace BarcodeReader.Core
{
    /// <summary>
    /// Describes connectivity behaviour
    /// </summary>
    public interface IConnector
    {
        Task<bool> Connect();
        Task<bool> Disconnect();
    }
}