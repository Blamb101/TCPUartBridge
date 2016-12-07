using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Bwl.Framework;
using System.Windows.Forms;

namespace TcpUartBridge.Server.App
{
    public partial class App : FormAppBase
    {
        public App()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bStart_Click(object sender, EventArgs e)
        {
            new Server(8070).start();
            _logger.AddMessage("Сервер запущен");
        }
    }
}
