using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTree;

namespace Servicios
{
    public partial class frmServicios : Form
    {
        enum Action { Refresh, Play, Stop, Restart }

        string configFile = "Servicios.xml";

        List<Server> servers = null;

        public frmServicios()
        {
            InitializeComponent();
        }

        private void frmServicios_Load(object sender, EventArgs e)
        {
            cargarServicios();
        }


        private void tsb_Click(object sender, EventArgs e)
        {
            cargarServicios();
        }

        private void tsbRefrescarEstado_Click(object sender, EventArgs e)
        {
            selectNodesAction(Action.Refresh);
        }


        private void tsbPlay_Click(object sender, EventArgs e)
        {
            selectNodesAction(Action.Play);
        }
        
        private void tsbReset_Click(object sender, EventArgs e)
        {
            selectNodesAction(Action.Restart);
        }
        
        private void tsbStop_Click(object sender, EventArgs e)
        {
            selectNodesAction(Action.Stop);
        }


        private void cargarServicios()
        {
            try
            {
                servers = (List<Server>)DNOTA.Tools.Funciones.Serializer.getObjectDeserialized(new List<Server>(), System.IO.File.ReadAllText(configFile));

                tree.Nodes.Clear();

                servers.ForEach(s =>
                    {
                        var n = tree.Nodes.Add(null, s.Name);
                        n.Tag = s;
                        n.LeftImages.Add(global::Servicios.Properties.Resources.server);

                        s.Servicios.ForEach(srv => {
                            try
                            {
                                ServicioEstado se = new ServicioEstado();
                                se.Name = srv;
                                se.ServController = new ServiceController(srv, s.IP);

                                var ns = n.Nodes.Add(null,srv);
                                ns.Tag = se;
                                ns.LeftImages.Add(global::Servicios.Properties.Resources.gear_replace);

                                refresStatus(ns);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Agregando servicio[" + srv + "]" + ex.ToString());
                                var ns = n.Nodes.Add(srv);
                                ns.Tag = null;
                                ns.LeftImages.Add(global::Servicios.Properties.Resources.gear_warning);
                            }
                        });

                        n.Expanded=true;
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show("cargarServicios:"+ex.ToString());
            }

        }


        private void refresStatus(UltraTreeNode n)
        {
            //n.ForeColor = Color.Black;
            n.LeftImages[0] = global::Servicios.Properties.Resources.gear_replace;

            try
            {             
                Task t = new Task(() =>
                {
                    if (n.Tag != null)
                    {
                        ((ServicioEstado)n.Tag).ServController.Refresh(); 
                        ((ServicioEstado)n.Tag).LastStatus = ((ServicioEstado)n.Tag).ServController.Status; 
                    }
                });


                t.ContinueWith((x) =>
                {

                    if (x.Exception != null)
                    {
                        n.LeftImages[0] = global::Servicios.Properties.Resources.gear_warning; 
                    }
                    else
                    {
                        switch (((ServicioEstado)n.Tag).LastStatus)
                        {
                            case ServiceControllerStatus.Running:
                                //n.ForeColor = Color.Green;
                                n.LeftImages[0] = global::Servicios.Properties.Resources.gear_run;
                                break;
                            case ServiceControllerStatus.Stopped:
                                //n.ForeColor = Color.Red;
                                n.LeftImages[0] = global::Servicios.Properties.Resources.gear_stop;
                                break;
                            case ServiceControllerStatus.Paused:
                                //n.ForeColor = Color.Blue;
                                n.LeftImages[0] = global::Servicios.Properties.Resources.gear_pause;
                                break;
                        }
                    }
                },TaskScheduler.Current);

                t.Start();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("refresStatus:" + ex.ToString());
                n.LeftImages[0] = global::Servicios.Properties.Resources.gear_warning; 
            }
        }


        private void selectNodesAction(Action act)
        {
            foreach (var n in tree.SelectedNodes)
            {
                if (n.Tag is Server)
                {
                    foreach (var n2 in n.Nodes)
                    {
                        if (n2.Tag is ServicioEstado)
                        {
                            switch (act)
                            {
                                case Action.Refresh: refresStatus(n2); break;
                                case Action.Play: start(n2); break;
                                case Action.Stop: stop(n2); break;
                                case Action.Restart: restart(n2); break;
                            }
                        }
                    }
                }
                else if (n.Tag is ServicioEstado)
                {
                    switch (act)
                    {
                        case Action.Refresh: refresStatus(n); break;
                        case Action.Play: start(n); break;
                        case Action.Stop: stop(n); break;
                        case Action.Restart: restart(n); break;
                    }
                }
            }
        }

        private void start(UltraTreeNode n)
        {
            n.LeftImages[0] = global::Servicios.Properties.Resources.gear_replace;
            n.Nodes.Clear();

            ServicioEstado se = (ServicioEstado)n.Tag;

            Task t = new Task(() =>
            {
                if (n.Tag != null)
                {
                    se.ServController.Start();
                }
            });

            t.ContinueWith((x) =>
            {
                if (x.Exception != null)
                {
                    n.LeftImages[0] = global::Servicios.Properties.Resources.gear_warning;
                    n.Nodes.Add(null, x.Exception.ToString());
                }
                else
                {
                    refresStatus(n);
                }
            }, TaskScheduler.Current);

            t.Start();

        }

        private void stop(UltraTreeNode n)
        {
            n.LeftImages[0] = global::Servicios.Properties.Resources.gear_replace;
            n.Nodes.Clear();

            ServicioEstado se = (ServicioEstado)n.Tag;

            Task t = new Task(() =>
            {
                if (n.Tag != null)
                {
                    se.ServController.Stop();
                }
            });

            t.ContinueWith((x) =>
            {

                if (x.Exception != null)
                {
                    n.LeftImages[0] = global::Servicios.Properties.Resources.gear_warning;
                    n.Nodes.Add(null, x.Exception.ToString());
                }
                else
                {
                    refresStatus(n);
                }
            }, TaskScheduler.Current);

            t.Start();

        }

        private void restart(UltraTreeNode n)
        {
            n.LeftImages[0] = global::Servicios.Properties.Resources.gear_replace;
            n.Nodes.Clear();

            ServicioEstado se = (ServicioEstado)n.Tag;

            Task t = new Task(() =>
            {
                if (n.Tag != null)
                {
                    se.ServController.Stop();
                    se.ServController.Start();
                }
            });

            t.ContinueWith((x) =>
            {
                if (x.Exception != null)
                {
                    n.LeftImages[0] = global::Servicios.Properties.Resources.gear_warning;
                    n.Nodes.Add(null, x.Exception.ToString());
                }
                else
                {
                    refresStatus(n);
                }
            }, TaskScheduler.Current);

            t.Start();

        }

        private void tsbSelectAll_Click(object sender, EventArgs e)
        {
            tree.SelectedNodes.Clear();
            foreach (var n in tree.Nodes)
            {
                n.Selected = true;
            }
        }

    }
}
