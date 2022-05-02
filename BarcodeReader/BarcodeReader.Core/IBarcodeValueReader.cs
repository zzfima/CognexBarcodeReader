using Cognex.DataMan.SDK.Utils;
using System.Collections.Generic;
using System.Drawing;

namespace BarcodeReader.Core
{
    /// <summary>
    /// Describes Reading barcode value behaviour
    /// </summary>
    public interface IBarcodeValueReader
    {
        List<Image> Images { get; set; }
        List<string> ImageGraphics { get; set; }
        int ResultId { get; set; }
        string ReadResult { get; set; }
        void ComplexResultRead(ComplexResult e);
    }
}