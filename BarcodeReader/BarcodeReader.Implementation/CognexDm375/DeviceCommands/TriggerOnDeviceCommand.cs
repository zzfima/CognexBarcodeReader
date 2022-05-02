using BarcodeReader.Core;

namespace BarcodeReader.Implementation.CognexDm375.DeviceCommands
{
    public sealed class TriggerOnDeviceCommand : IDeviceCommand
    {
        private readonly IDataManProvider _dataManProvider;

        public TriggerOnDeviceCommand(IDataManProvider dataManProvider)
        {
            _dataManProvider = dataManProvider;
        }

        public void SendCommand()
        {
            _dataManProvider.DataManSystem.SendCommand("TRIGGER ON");
        }
    }
}