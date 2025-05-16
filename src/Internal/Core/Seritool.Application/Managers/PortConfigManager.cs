using Seritool.Application.Ports;
using Seritool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seritool.Application.Managers {
    public sealed class PortConfigManager {
        private readonly Dictionary<int, PortConfig> _portConfigs;
        private readonly ISeriport _seriportAdapter;

        public PortConfigManager(ISeriport seriportAdapter) {
            _seriportAdapter = seriportAdapter;
            _portConfigs = new Dictionary<int, PortConfig>();
            _portConfigs.Clear();
            string[] portNames;
            Exception exception;
            if (!_seriportAdapter.TryGetSeriports(out portNames, out exception)) {
                throw exception;
            }
            foreach (var portname in portNames) {
                int portNumber = int.Parse(portname.Substring(3, (portname.Length - 3)));
                _portConfigs.Add(portNumber, new PortConfig {
                    Comport = portNumber
                });
            }
        }

        public void RefreshConfigs() {
            _portConfigs.Clear();
            string[] portNames;
            Exception exception;
            if (!_seriportAdapter.TryGetSeriports(out portNames, out exception)) {
                throw exception;
            }
            foreach (var portname in portNames) {
                int portNumber = int.Parse(portname.Substring(3, (portname.Length - 3)));
                _portConfigs.Add(portNumber, new PortConfig {
                    Comport = portNumber
                });
            }
        }

        public bool TryGetPortConfig(int port, out PortConfig portConfig, out Exception exception) {
            bool result = false;
            exception = null;
            portConfig = null;
            try {
                if (!_portConfigs.ContainsKey(port)) {
                    exception = new Exception("port config not found");
                    return false;
                }
                if (!_portConfigs.TryGetValue(port, out portConfig)) {
                    exception = new Exception("get value invalid this port");
                    return false;
                }
                result = true;
            }
            catch (Exception ex) {
                exception = ex;
                result = false;
            }
            return result;
        }






    }
}
