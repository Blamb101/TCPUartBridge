using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpUartBridge.Server.App
{
  
    class Server
    {
        private TcpListener _server = null;
        private static  IDictionary<string, ClientProcessor> clients = new Dictionary<string, ClientProcessor>();
        public Server(int port)
        {
            _server = new TcpListener(port);
            
        }

        public void start()
        {
            _server.Start();
            new Thread(TcpServerListener).Start();
            new Thread(HttpServerListener).Start();
        }
        private void TcpServerListener()
        {
            while (true)
            {
                TcpClient client = _server.AcceptTcpClient();
                StreamReader reader = new StreamReader(client.GetStream());
                String devName = reader.ReadLine();
                reader.Close();
                clients.Add(devName, new ClientProcessor(client));                                
            }
        }

        private void HttpClientHandler(object ob)
        {
            TcpClient httpClient = ob as TcpClient;
            StreamReader httpReader = new StreamReader(httpClient.GetStream());
            String request = httpReader.ReadLine();
            string content = "<html><header><title>Remote Control</title></header><body>";
            String[] pairs = { };
            if (request != null)
            {
                if (request.Contains('?')) pairs = request.Split(' ')[1].Split('?')[1].Split('&');

                if (request.Contains("devices"))
                {

                    content += "Device count: " + clients.Keys.Count + "<br>";
                    for (int i = 0; i < clients.Keys.Count; i++)
                    {
                        content += "Device name: " + clients.Keys.ElementAt(i) + "<br>";
                    }


                }

                if (request.Contains("device"))
                {
                    String device_name = "";
                    String cmd = "";
                    foreach (String s in pairs)
                    {
                        if (s.Contains("device"))
                        {
                            device_name = s.Split('=')[1];
                        }
                        if (s.Contains("cmd"))
                        {
                            cmd = s.Split('=')[1];
                        }

                        if (device_name.Length == 0 || cmd.Length == 0)
                        {
                            content += "Bad parameters<br>";
                        }
                        else
                        {
                            if (clients.ContainsKey(device_name))
                            {
                                content += "device not found";
                            }
                            else
                            {
                                clients[device_name].sendLine(cmd);
                                content += "Command Ok!";
                            }
                        }
                    }
                }
            }
            content += "</body></html>";
            string response = "HTTP/1.1 200\nContent-type: text/html\nContent-Length:" + content.Length.ToString() + "\n\n" + content;
            byte[] Buffer = Encoding.ASCII.GetBytes(response);
            httpClient.GetStream().Write(Buffer, 0, Buffer.Length);
            httpClient.Close();

        }

        private void HttpServerListener()
        {
            TcpListener httpServer = new TcpListener(IPAddress.Parse("127.0.0.1"),8000);
            httpServer.Start();
            while (true)
            {
                TcpClient httpClient = httpServer.AcceptTcpClient();
                new Thread(HttpClientHandler).Start(httpClient);
            }
        }

       

       
    }
}
