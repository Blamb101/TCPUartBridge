using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpUartBridge.Server.App
{
    class ClientProcessor
    {
        private TcpClient _client = null;
        private StreamReader reader = null;
        private StreamWriter writer = null;
        public ClientProcessor(TcpClient _client)
        {
            this._client = _client;
            reader = new StreamReader(_client.GetStream());
            writer = new StreamWriter(_client.GetStream());
        }

        public void sendLine(String line)
        {
            writer.WriteLine(line);
        }
    }
}
