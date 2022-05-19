using BarcodeReader.Core;
using BarcodeReader.Implementation.CognexDm375;
using BarcodeReader.Implementation.CognexDm375.ConnectionPointFactories;
using Cognex.DataMan.SDK.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace BarcodeReader.UnitTest
{
    [TestClass]
    public class UnitTestConnectable
    {
        [TestMethod]
        public void TestMethodConnector()
        {
            var authentication = new Authentication("user1", "pass34");
            var ipAddress = IPAddress.Parse("192.168.0.135");
            var connectionPointFactory = new EthSystemConnectionPointFactory(authentication, ipAddress);
            //var dataMan = new DataManProvider(connectionPointFactory);
            //IConnector connector = new Connector(dataMan);
        }

        private void ComplexResultCompleted(ComplexResult obj)
        {
            throw new System.NotImplementedException();
        }
    }
}