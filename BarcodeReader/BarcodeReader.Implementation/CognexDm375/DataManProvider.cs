using System;
using BarcodeReader.Core;
using Cognex.DataMan.SDK;
using Cognex.DataMan.SDK.Utils;
using MvvmCross.Plugin.Messenger;

namespace BarcodeReader.Implementation.CognexDm375
{
    public class DataManProvider : IDataManProvider
    {
        private readonly IConnectionPointFactory _connectionPointFactory;
        private readonly IMvxMessenger _messenger;
        private bool _disposed;

        public DataManProvider(IConnectionPointFactory connectionPointFactory, IMvxMessenger messenger)
        {
            _connectionPointFactory = connectionPointFactory;
            _messenger = messenger;
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
            _messenger.Publish<MvxMessageComplexResult>(new MvxMessageComplexResult(this, e));
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                DataManSystem?.Dispose();
            }

            // TODO: free unmanaged resources (unmanaged objects).
            // TODO: set large fields to null.

            _disposed = true;
        }
    }
}