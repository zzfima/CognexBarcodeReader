using System.Net;
using Cognex.DataMan.SDK;

namespace BarcodeReader.Core
{
    /// <summary>
    /// Describes ISystemConnector creation, depends on connection medium (Ethernet, Serial etc.)
    /// </summary>
    public interface IConnectionPointFactory
    {
        ISystemConnector Create();
    }
}