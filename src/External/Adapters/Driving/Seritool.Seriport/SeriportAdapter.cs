using Seritool.Application.Ports;
using Seritool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seritool.Seriport {
    /// <summary>
    /// this class communicate with seriport
    /// </summary>
    public sealed class SeriportAdapter : ISeriport {
        public event EventHandler DataReceivedEvent;
        private readonly SerialPort _serialPort;

        public SeriportAdapter() {
            _serialPort = new SerialPort();
        }

        public bool TryBuildSeriport(PortConfig portConfig, out Exception exception) {
            bool result = false;
            exception = null;
            try {
                if (_serialPort.IsOpen) { _serialPort.Close(); }
                _serialPort.PortName = $"COM{portConfig.Comport}";
                _serialPort.DataBits = portConfig.Databit;
                _serialPort.BaudRate = portConfig.Baudrate;
                _serialPort.Parity = portConfig.Parity;
                _serialPort.StopBits = portConfig.StopBits;
                _serialPort.WriteBufferSize = portConfig.WriteBufferSize;
                _serialPort.ReadBufferSize = portConfig.ReadBufferSize;
                _serialPort.ReadTimeout = portConfig.ReadTimeout;
                _serialPort.WriteTimeout = portConfig.WriteTimeout;
                result = true;
            }
            catch (Exception ex) {
                exception = ex;
                result = false;
            }
            return result;
        }
        public bool TryConnect(out Exception exception) {
            bool result = false;
            exception = null;
            try {
                if (_serialPort.IsOpen) {
                    exception = new Exception($"port ({_serialPort.PortName}) already open");
                    return false;
                }
                _serialPort.Open();
                result = true;
            }
            catch (Exception ex) {
                exception = ex;
                result = false;
            }
            return result;
        }
        public bool TryDisconnect(out Exception exception) {
            bool result = false;
            exception = null;
            try {
                if (!_serialPort.IsOpen) {
                    exception = new Exception($"port ({_serialPort.PortName}) already closed");
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
        public bool TryGetConnectionState(out bool isConnected, out Exception exception) {
            bool result = false;
            exception = null;
            isConnected = false;
            try {
                isConnected = _serialPort.IsOpen;
                result = true;
            }
            catch (Exception ex) {
                exception = ex;
                result = false;
            }
            return result;
        }
        public bool TryGetSeriports(out string[] ports, out Exception exception) {
            bool result = false;
            exception = null;
            ports = null;
            try {
                ports = SerialPort.GetPortNames();
                result = true;
            }
            catch (Exception ex) {
                exception = ex;
                result = false;
            }
            return result;
        }
        public bool TryReadData(out string readedData, out int readedBytes, out TimeSpan readedTime, out Exception exception) {
            bool result = false;
            exception = null;
            readedData = string.Empty;
            readedBytes = 0;
            readedTime = TimeSpan.Zero;
            try {
                result = true;
            }
            catch (Exception ex) {
                exception = ex;
                result = false;
            }
            return result;
        }
        public bool TryWriteData(string data, out int writedByte, out TimeSpan writedTime, out Exception exception) {
            bool result = false;
            exception = null;
            writedByte = 0;
            writedTime = TimeSpan.Zero;
            try {
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
