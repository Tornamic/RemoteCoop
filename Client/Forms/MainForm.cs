using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MainForm : Form
    {
        public static MainForm Instance;
        public MainForm()
        {
            Instance = this;
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            string ip = tb_ip.Text;
            ushort port = ushort.Parse(tb_port.Text);
            Program.Network.Connect(ip, port);
        }

        public static void Log(string message, string timeFormat = "HH:mm:ss")
        {
            Instance.Invoke((MethodInvoker)delegate
            {
                Instance.tb_logs.Text += $"[{DateTime.Now.ToString(timeFormat)}] {message}" + Environment.NewLine;

                Instance.tb_logs.SelectionStart = Instance.tb_logs.Text.Length;
                Instance.tb_logs.ScrollToCaret();
            });
        }
    }
}
