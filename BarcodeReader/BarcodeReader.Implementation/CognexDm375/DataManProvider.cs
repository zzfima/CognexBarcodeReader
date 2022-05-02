﻿using BarcodeReader.Core;
using Cognex.DataMan.SDK;
using Cognex.DataMan.SDK.Utils;
using Microsoft.Toolkit.Mvvm.Messaging;

namespace BarcodeReader.Implementation.CognexDm375
{
    public class DataManProvider : IDataManProvider
    {
        private readonly IConnectionPointFactory _connectionPointFactory;

        public DataManProvider(IConnectionPointFactory connectionPointFactory)
        {
            _connectionPointFactory = connectionPointFactory;
            Init();
        }

        private void Init()
        {
            DataManSystem = new DataManSystem(_connectionPointFactory.Create());
            DataManSystem.DefaultTimeout = 5000;
            ResultTypes requested_result_types =
                ResultTypes.ReadXml | ResultTypes.Image | ResultTypes.ImageGraphics;
            var results = new ResultCollector(DataManSystem, requested_result_types);
            results.ComplexResultCompleted += Results_ComplexResultCompleted;
            DataManSystem.SetKeepAliveOptions(true, 3000, 1000);
            DataManSystem.SetResultTypes(requested_result_types);
        }

        public DataManSystem DataManSystem { get; private set; }

        private void Results_ComplexResultCompleted(object sender, ComplexResult e)
        {
            WeakReferenceMessenger.Default.Send(e);
        }
    }
}