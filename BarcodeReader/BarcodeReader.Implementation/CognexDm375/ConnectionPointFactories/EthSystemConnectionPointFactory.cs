using BarcodeReader.Core;
using Cognex.DataMan.SDK;
using System.Net;

namespace BarcodeReader.Implementation.CognexDm375.ConnectionPointFactories
{
    public sealed class EthSystemConnectionPointFactory : IConnectionPointFactory
    {
        private readonly IPAddress _ipAddress;
        private readonly IAuthentication _authentication;

        public EthSystemConnectionPointFactory(IAuthentication authentication, IPAddress ipAddress = null)
        {
            _ipAddress = ipAddress ?? new IPAddress(new byte[] { 192, 168, 0, 6 });
            _authentication = authentication;
        }

        public ISystemConnector Create()
        {
            EthSystemConnector systemConnector = new EthSystemConnector(_ipAddress);
            systemConnector.Password = _authentication.Password;
            systemConnector.UserName = _authentication.Username;

            return systemConnector;
        }
    }
}