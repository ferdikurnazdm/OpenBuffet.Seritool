using Seritool.Application.Ports;
using Seritool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seritool.Application.Managers {
    /// <summary>
    /// this class manage the seriport process
    /// </summary>
    public sealed class SeriportManager {
        private readonly ISeriport _seriportAdapter;

        public SeriportManager(ISeriport seriportAdapter) {
            _seriportAdapter = seriportAdapter;
        }





        public bool TryBuildSeriport(PortConfig portConfig, out Exception exception) {
            return _seriportAdapter.TryBuildSeriport(portConfig, out exception);
        }
        public bool TryConnect(out Exception exception) {
            return _seriportAdapter.TryConnect(out exception);
        }
        public bool TryDisconnect(out Exception exception) {
            return _seriportAdapter.TryDisconnect(out exception);
        }
        public bool TryGetConnectionState(out bool isConnected, out Exception exception) {
            return _seriportAdapter.TryGetConnectionState(out isConnected, out exception);
        }
        public bool TryGetSeriports(out string[] ports, out Exception exception) {
            return _seriportAdapter.TryGetSeriports(out ports, out exception);
        }
        public bool TryReadData(out string readedData, out int readedBytes, out TimeSpan readedTime, out Exception exception) {
            return _seriportAdapter.TryReadData(out readedData, out readedBytes, out readedTime, out exception);
        }
        public bool TryWriteData(string data, out int writedByte, out TimeSpan writedTime, out Exception exception) {
            return _seriportAdapter.TryWriteData(data, out writedByte, out writedTime, out exception);
        }




    }
}
