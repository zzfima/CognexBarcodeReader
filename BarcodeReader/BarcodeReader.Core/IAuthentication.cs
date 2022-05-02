namespace BarcodeReader.Core
{
    /// <summary>
    /// Describes authentication behaviour
    /// </summary>
    public interface IAuthentication
    {
        string Password { get; set; }
        string Username { get; set; }
    }
}