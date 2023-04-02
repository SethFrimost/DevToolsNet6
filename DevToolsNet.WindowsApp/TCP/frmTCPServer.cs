using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevToolsNet.WindowsApp
{
    public partial class frmTCPServer : Form
    {
        DevToolsNet.TCP.TcpServer server;

        public frmTCPServer()
        {
            InitializeComponent();
        }

        private void pConfig_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                server = new TCP.TcpServer(new TCP.Configs.TcpConfig()
                {
                    Address = txtAddress.Text,
                    Port = int.Parse(txtPort.Text),
                    Key = Guid.NewGuid().ToString()
                });

                server.DataReaded += Server_DataReaded;
                server.ClientConected += Server_ClientConected;
                server.ClientDisconected += Server_ClientDisconected; 

                server.Start();

                txtMessages.Text += "- Server started -" + Environment.NewLine;

                btnSend.Enabled = btnSendToAll.Enabled = btnStop.Enabled = true;
                btnStart.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Server_ClientDisconected(object? sender, EventArgs e)
        {
            if (txtMessages.InvokeRequired) txtMessages.Invoke(() => txtMessages.Text += "- Client disconected -" + Environment.NewLine);
            else txtMessages.Text += "- Client disconected -" + Environment.NewLine;
        }

        private void Server_ClientConected(object? sender, EventArgs e)
        {
            if (txtMessages.InvokeRequired) txtMessages.Invoke(() => txtMessages.Text += "- Client connected -" + Environment.NewLine);
            else txtMessages.Text += "- Client connected -" + Environment.NewLine;

        }

        private void Server_DataReaded(object? sender, EventArgs e)
        {
            if (txtMessages.InvokeRequired) txtMessages.Invoke(() => txtMessages.Text += "<- " + server.RawRecivedData + Environment.NewLine);
            else txtMessages.Text += "<- " + server.RawRecivedData + Environment.NewLine;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(server != null)
            {
                server.Stop();
                server.Dispose();
                server = null;

                btnSend.Enabled = btnSendToAll.Enabled = btnStop.Enabled = false;
                btnStart.Enabled = true;

                txtMessages.Text += "- Server Stoped -" + Environment.NewLine;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (server != null)
                {
                    txtMessages.Text += "-> " + txtSendText.Text + Environment.NewLine;
                    server.SendToLastServerClient(txtSendText.Text);
                    txtSendText.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSendToAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (server != null)
                {
                    txtMessages.Text += "=> " + txtSendText.Text + Environment.NewLine;
                    server.SendToClients(txtSendText.Text);
                    txtSendText.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
