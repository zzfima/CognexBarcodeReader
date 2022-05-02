using BarcodeReader.Core;
using BarcodeReader.Implementation.CognexDm375;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarcodeReader.UnitTest
{
    [TestClass]
    public class UnitTestAuthentication
    {
        [TestMethod]
        public void TestMethodAuthentication()
        {
            IAuthentication authentication = new Authentication("user1", "pass34");
            authentication.Password.Should().Be("pass34");
            authentication.Username.Should().Be("user1");
        } 
    }
}