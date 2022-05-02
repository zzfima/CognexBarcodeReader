namespace BarcodeReader.Core
{
    /// <summary>
    /// Describes sending command to device behaviour
    /// </summary>
    public interface IDeviceCommand
    {
        void SendCommand();
    }
}