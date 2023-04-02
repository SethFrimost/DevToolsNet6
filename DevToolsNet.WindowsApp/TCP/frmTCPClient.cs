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
    public partial class frmTCPClient : Form
    {
        DevToolsNet.TCP.TcpCliente cliente;

        public frmTCPClient()
        {
            InitializeComponent();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                cliente = new TCP.TcpCliente(new TCP.Configs.TcpConfig()
                {
                    Address = txtAddress.Text,
                    Port = int.Parse(txtPort.Text),
                    Key = Guid.NewGuid().ToString()
                });

                cliente.DataReaded += Server_DataReaded;
                txtMessages.Text += "- Client started -" + Environment.NewLine;

                btnStart.Enabled = false;
                btnSend.Enabled = btnStop.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void Server_DataReaded(object? sender, EventArgs e)
        {
            if (txtMessages.InvokeRequired) txtMessages.Invoke(() => txtMessages.Text += "<- " + cliente.RawRecivedData + Environment.NewLine);
            else txtMessages.Text += "<- " + cliente.RawRecivedData + Environment.NewLine;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(cliente != null)
            {
                cliente.CloseClient();
                cliente.Dispose();
                cliente = null;
            }

            btnStart.Enabled = true;
            btnSend.Enabled = btnStop.Enabled = false;

            txtMessages.Text += "- Client stoped -" + Environment.NewLine;

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (cliente != null)
                {
                    txtMessages.Text += "-> " + txtSendText.Text + Environment.NewLine;
                    cliente.Send(txtSendText.Text);
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