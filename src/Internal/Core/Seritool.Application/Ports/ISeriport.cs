using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seritool.Domain.Entities;

namespace Seritool.Application.Ports {
    /// <summary>
    /// this interface ensure the seriport talents
    /// </summary>
    public interface ISeriport {
        /// <summary>
        /// this event represent the data receive
        /// </summary>
        event EventHandler DataReceivedEvent;
        /// <summary>
        /// this method build the seriport adapter
        /// </summary>
        /// <param name="portConfig">seriport configuration</param>
        /// <param name="exception">return null if method runned successfully otherwise return exception</param>
        /// <returns>return true if method runned successfully otherwise return false</returns>
        bool TryBuildSeriport(PortConfig portConfig, out Exception exception);
        /// <summary>
        /// this metho connect the seriport
        /// </summary>
        /// <param name="exception">return null if method runned successfully otherwise return exception</param>
        /// <returns>return true if method runned successfully otherwise return false</returns>
        bool TryConnect(out Exception exception);
        /// <summary>
        /// this method disconnect from seriport
        /// </summary>
        /// <param name="exception">return null if method runned successfully otherwise return exception</param>
        /// <returns>return true if method runned successfully otherwise return false</returns>
        bool TryDisconnect(out Exception exception);
        /// <summary>
        /// this method return the seriport connection state
        /// </summary>
        /// <param name="isConnected">seriport connection state</param>
        /// <param name="exception">return null if method runned successfully otherwise return exception</param>
        /// <returns>return true if method runned successfully otherwise return false</returns>
        bool TryGetConnectionState(out bool isConnected, out Exception exception);
        /// <summary>
        /// this method return data on seriport
        /// </summary>
        /// <param name="readedData">readed data</param>
        /// <param name="readedBytes">readed bytes</param>
        /// <param name="readedTime">readed time taken</param>
        /// <param name="exception">return null if method runned successfully otherwise return exception</param>
        /// <returns>return true if method runned successfully otherwise return false</returns>
        bool TryReadData(out string readedData, out int readedBytes, out TimeSpan readedTime, out Exception exception);
        /// <summary>
        /// this method write data to seriport
        /// </summary>
        /// <param name="data">writing data</param>
        /// <param name="writedByte">writing bytes</param>
        /// <param name="writedTime">writing time taken</param>
        /// <param name="exception">return null if method runned successfully otherwise return exception</param>
        /// <returns>return null if method runned successfully otherwise return exception</returns>
        bool TryWriteData(string data, out int writedByte, out TimeSpan writedTime, out Exception exception);
        /// <summary>
        /// this method return the seriports
        /// </summary>
        /// <param name="ports">seriports</param>
        /// <param name="exception">return null if method runned successfully otherwise return exception</param>
        /// <returns>return true if method runned successfully otherwise return falses</returns>
        bool TryGetSeriports(out string[] ports, out Exception exception);
    }
}
