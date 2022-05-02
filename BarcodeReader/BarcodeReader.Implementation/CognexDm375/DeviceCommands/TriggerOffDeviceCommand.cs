using BarcodeReader.Core;
using Cognex.DataMan.SDK;

namespace BarcodeReader.Implementation.CognexDm375.DeviceCommands
{
    public sealed class TriggerOffDeviceCommand : IDeviceCommand
    {
        private readonly DataManSystem _system;

        public TriggerOffDeviceCommand(DataManSystem system)
        {
            _system = system;
        }

        public void SendCommand()
        {
            _system.SendCommand("TRIGGER OFF");
        }
    }
}