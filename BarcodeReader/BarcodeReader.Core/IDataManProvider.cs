using System;
using Cognex.DataMan.SDK;

namespace BarcodeReader.Core
{
    public interface IDataManProvider : IDisposable
    {
        DataManSystem DataManSystem { get; }
    }
}