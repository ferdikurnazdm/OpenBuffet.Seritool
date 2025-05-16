using Seritool.Application.Managers;
using Seritool.Application.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seritool.Application.Engine {
    /// <summary>
    /// this class manage the all process
    /// </summary>
    public sealed class SeritoolEngine {
        private readonly SeriportManager _seriportManager;
        private readonly PortConfigManager _portConfigManager;


        public SeritoolEngine(ISeriport seriportAdapter) {
            _seriportManager = new SeriportManager(seriportAdapter);
            _portConfigManager = new PortConfigManager(seriportAdapter);
        }


        public SeriportManager SeriportManager {
            get { return _seriportManager; }
        }

        public PortConfigManager PortConfigManager {
            get { return _portConfigManager; }
        }

    }
}
