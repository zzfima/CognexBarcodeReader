using BarcodeReader.Core;
using System.Threading.Tasks;

namespace BarcodeReader.Implementation.CognexDm375
{
    public sealed class Connector : IConnector
    {
        #region Members

        private readonly IDataManProvider _dataManProvider;

        #endregion

        #region Constructor

        public Connector(IDataManProvider dataManProvider)
        {
            _dataManProvider = dataManProvider;
        }

        #endregion

        #region Methods

        public async Task<bool> Connect()
        {
            var connectTask = Task.Run(() => { _dataManProvider.DataManSystem.Connect(); });
            if (await Task.WhenAny(connectTask, Task.Delay(5000)) == connectTask)
                return true;
            return false;
        }


        public async Task<bool> Disconnect()
        {
            var disconnectTask = Task.Run(() => _dataManProvider.DataManSystem.Disconnect());
            if (await Task.WhenAny(disconnectTask, Task.Delay(5000)) == disconnectTask)
                return true;
            return false;
        }

        #endregion
    }
}