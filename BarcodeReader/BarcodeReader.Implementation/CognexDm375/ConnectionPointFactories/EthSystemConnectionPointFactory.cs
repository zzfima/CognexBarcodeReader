using BarcodeReader.Core;
using Cognex.DataMan.SDK;
using System.Net;

namespace BarcodeReader.Implementation.CognexDm375.ConnectionPointFactories
{
    public sealed class EthSystemConnectionPointFactory : IConnectionPointFactory
    {
        private readonly IPAddress _ipAddress;
        private readonly IAuthentication _authentication;

        public EthSystemConnectionPointFactory(IPAddress ipAddress, IAuthentication authentication)
        {
            _ipAddress = ipAddress;
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