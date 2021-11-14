using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        TcpClient client = new TcpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            client.Connect(new IPEndPoint(IPAddress.Loopback, 5000));
            Byte[] data = System.Text.Encoding.ASCII.GetBytes("");
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);

            Console.WriteLine("Sent: {0}", "");
            data = new Byte[256];
            String responseData = String.Empty;
            int bytes = stream.Read(data, 0, data.Length);

            while (bytes > 0) {
                Console.WriteLine("bytes received: " + bytes);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);
                bytes = 0;
                bytes = stream.Read(data, 0, data.Length);
            }

            client.Close();
        }
    }
}
