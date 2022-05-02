using BarcodeReader.Core;
using Cognex.DataMan.SDK;
using Cognex.DataMan.SDK.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;

namespace BarcodeReader.Implementation.CognexDm375
{
    /// <summary>
    /// Convert Cognex Dm375 result to images and text
    /// </summary>
    public sealed class BarcodeValueReader : IBarcodeValueReader
    {
        private readonly IDataManProvider _dataManProvider;

        #region Members

        private readonly object _currentResultInfoSyncLock = new object();

        #endregion

        #region Constructor

        public BarcodeValueReader(IDataManProvider dataManProvider)
        {
            _dataManProvider = dataManProvider;
        }

        #endregion

        #region Properties

        public List<Image> Images { get; set; }
        public List<string> ImageGraphics { get; set; }
        public int ResultId { get; set; }
        public string ReadResult { get; set; }

        #endregion

        #region Methods

        public void ComplexResultRead(ComplexResult e)
        {
            Images = new List<Image>();
            ImageGraphics = new List<string>();
            ReadResult = null;
            ResultId = -1;
            ResultTypes collected_results = ResultTypes.None;

            lock (_currentResultInfoSyncLock)
            {
                foreach (var simple_result in e.SimpleResults)
                {
                    collected_results |= simple_result.Id.Type;

                    switch (simple_result.Id.Type)
                    {
                        case ResultTypes.Image:
                            var image = ImageArrivedEventArgs.GetImageFromImageBytes(simple_result.Data);
                            if (image != null)
                                Images.Add(image);
                            break;

                        case ResultTypes.ImageGraphics:
                            ImageGraphics.Add(simple_result.GetDataAsString());
                            break;

                        case ResultTypes.ReadXml:
                            ReadResult = GetReadStringFromResultXml(simple_result.GetDataAsString());
                            ResultId = simple_result.Id.Id;
                            break;

                        case ResultTypes.ReadString:
                            ReadResult = simple_result.GetDataAsString();
                            ResultId = simple_result.Id.Id;
                            break;
                    }
                }
            }
        }

        private string GetReadStringFromResultXml(string resultXml)
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                doc.LoadXml(resultXml);

                XmlNode full_string_node = doc.SelectSingleNode("result/general/full_string");

                if (full_string_node != null && _dataManProvider.DataManSystem != null &&
                    _dataManProvider.DataManSystem.State == ConnectionState.Connected)
                {
                    XmlAttribute encoding = full_string_node.Attributes["encoding"];
                    if (encoding != null && encoding.InnerText == "base64")
                    {
                        if (!string.IsNullOrEmpty(full_string_node.InnerText))
                        {
                            byte[] code = Convert.FromBase64String(full_string_node.InnerText);
                            return _dataManProvider.DataManSystem.Encoding.GetString(code, 0, code.Length);
                        }
                        else
                        {
                            return "";
                        }
                    }

                    return full_string_node.InnerText;
                }
            }
            catch
            {
            }

            return "";
        }

        #endregion
    }
}