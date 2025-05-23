﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seritool.Domain.Entities {
    /// <summary>
    /// this entitiy ensure seriport config parameters
    /// </summary>
    public sealed class PortConfig {
        /// <summary>
        /// this field keeps the comport
        /// </summary>
        private int _comport = 1;
        /// <summary>
        /// this field keeps the baudrate
        /// </summary>
        private int _baudrate = 9600;
        /// <summary>
        /// this field keeps the databit
        /// </summary>
        private int _databit = 8;
        /// <summary>
        /// this field keeps the parity
        /// </summary>
        private Parity _parity = Parity.None;
        /// <summary>
        /// this field keeps the stopbit
        /// </summary>
        private StopBits _stopbit = StopBits.One;
        /// <summary>
        /// this field keeps theread timeout
        /// </summary>
        private int _readTimeout = 1000;
        /// <summary>
        /// this field keeps the write timeout
        /// </summary>
        private int _writeTimeout = 1000;
        /// <summary>
        /// this field keeps the read buffer size
        /// </summary>
        private int _readBufferSize = 1024;
        /// <summary>
        /// this field keeps the write buffer size
        /// </summary>
        private int _writeBufferSize = 1024;

        /// <summary>
        /// this property keeps the comport
        /// </summary>
        [Category("Connection")]
        [DisplayName("COM Port")]
        [Description("The COM port number to use (e.g., 1 for COM1).")]
        public int Comport {
            get { return _comport; }
            set {
                if (value > 0 && _comport != value) {
                    _comport = value;
                }
            }
        }
        /// <summary>
        /// this property keeps the baudrate
        /// </summary>
        [Category("Connection")]
        [DisplayName("Baud Rate")]
        [Description("The speed of communication in bits per second (bps).")]
        public int Baudrate {
            get { return _baudrate; }
            set {
                if (value > 0 && _baudrate != value) {
                    _baudrate = value;
                }
            }
        }
        /// <summary>
        /// this property keeps the databit
        /// </summary>
        [Category("Connection")]
        [DisplayName("Data Bits")]
        [Description("The number of data bits per byte.")]
        public int Databit {
            get { return _databit; }
            set {
                if (value > 0 && _databit != value) {
                    _databit = value;
                }
            }
        }
        /// <summary>
        /// this property keeps the parity
        /// </summary>
        [Category("Connection")]
        [DisplayName("Parity")]
        [Description("The parity-checking protocol to use.")]
        public Parity Parity {
            get { return _parity; }
            set {
                if (_parity != value) {
                    _parity = value;
                }
            }
        }
        /// <summary>
        /// this property keeps the stopbit
        /// </summary>
        [Category("Connection")]
        [DisplayName("Stop Bits")]
        [Description("The number of stop bits to use.")]
        public StopBits StopBits {
            get { return _stopbit; }
            set {
                if (_stopbit != value) {
                    _stopbit = value;
                }
            }
        }
        /// <summary>
        /// this porperty keeps the receive timeout as milisecond
        /// </summary>
        [Category("Timeouts")]
        [DisplayName("Read Timeout (ms)")]
        [Description("The number of milliseconds before a read operation times out.")]
        public int ReadTimeout {
            get { return _readTimeout; }
            set {
                if (value > 0 && _readTimeout != value) {
                    _readTimeout = value;
                }
            }
        }
        /// <summary>
        /// this porperty keeps the transfer timeout as milisecond
        /// </summary>
        [Category("Timeouts")]
        [DisplayName("Write Timeout (ms)")]
        [Description("The number of milliseconds before a write operation times out.")]
        public int WriteTimeout {
            get { return _writeTimeout; }
            set {
                if (value > 0 && _writeTimeout != value) {
                    _writeTimeout = value;
                }
            }
        }
        /// <summary>
        /// this porperty keeps the receive buffer size as byte
        /// </summary>
        [Category("Buffers")]
        [DisplayName("Read Buffer Size (bytes)")]
        [Description("The size of the input buffer in bytes.")]
        public int ReadBufferSize {
            get { return _readBufferSize; }
            set {
                if (value > 0 && _readBufferSize != value) {
                    _readBufferSize = value;
                }
            }
        }
        /// <summary>
        /// this porperty keeps the transfer buffer size as byte
        /// </summary>
        [Category("Buffers")]
        [DisplayName("Write Buffer Size (bytes)")]
        [Description("The size of the output buffer in bytes.")]
        public int WriteBufferSize {
            get { return _writeBufferSize; }
            set {
                if (value > 0 && _writeBufferSize != value) {
                    _writeBufferSize = value;
                }
            }
        }
    }
}





















