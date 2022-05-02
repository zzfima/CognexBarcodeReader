using BarcodeReader.Core;

namespace BarcodeReader.Implementation.CognexDm375
{
    public sealed class Authentication : IAuthentication
    {
        public Authentication(string username = "", string password = "")
        {
            Username = username;
            Password = password;
        }

        public string Password { get; set; }
        public string Username { get; set; }
    }
}