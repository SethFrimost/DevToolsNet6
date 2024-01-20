using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevToolsNet.WinFormsControlLibrary.Chart
{
    public partial class ChartBar : UserControl
    {
        #region Properties 

        public Collection<ChartSerie> Series { get; private set; } = new Collection<ChartSerie>();
        public ChartLegend Legend { get; private set; } = new ChartLegend();
        public ChartTitle Title { get; private set; } = new ChartTitle();
        public Padding Padding { get; set; }

        public int AxisYMaxDivisions { get; set; } = 10;
        public int AxisYMinValueJump { get; set; } = 1;
        public int AxisYDivisions { get; set; } = 0;
        
        #endregion


        public ChartBar()
        {
            InitializeComponent();
            Series.Add(new ChartSerie() { Name="Ingresos", Values=new List<float>() { 1, 2,3,4 } });
            Series.Add(new ChartSerie() { Name="Gastos", Values=new List<float>() { 3, 1,5, 8 } });
        }


        #region Draw

        private RectangleF titleRect = RectangleF.Empty;
        private RectangleF legendRect = RectangleF.Empty;
        private RectangleF xAxisRect = RectangleF.Empty;
        private RectangleF yAxisRect = RectangleF.Empty;
        private RectangleF grafRect = RectangleF.Empty;

        private float yAxisWidth = 0;
        private float yAxisHeight = 0;
        private float yAxisValueHeightRatio = 0;
        private float yAxisJumpVal = 0;
        private float yAxisJumpHeight = 0;
        private float yAxisJumpValue = 0;
        private float yAxisMaxVal = 0;

        private int xAxisGroups = 0;
        private float xAxisGroupWidht = 0;
        private float xAxisBarWidth = 0;
        private int xAxisNameAngle = 0;
        private float xAxisGroupHeight = 0;

        
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            try
            {
                var g = e.Graphics;
                g.DrawLine(Pens.Black, 0, 0, 10, 10);
                g.DrawLine(Pens.Gray, 0, 0, this.Width, this.Height);
                /*calculateDraws(g);
                drawGraf(g);*/
                g.DrawLine(Pens.Red, this.Width, 0, 0, this.Height);
            }
            catch (Exception ex)
            {

            }
            
        }


        private void calculateDraws(Graphics g)
        {
            //calculateDrawsTitle(g);
            //calculateDrawsLegend(g);
            calculateDrawsAxis(g);
        }

        private void calculateDrawsTitle(Graphics g)
        {
            if (Title.Visible && !string.IsNullOrEmpty(Title.Text))
            {
                switch (Title.Location)
                {
                    case ChartLocation.Top:
                    case ChartLocation.Bottom:
                        titleRect.Size = new SizeF(this.Width - Padding.Horizontal, g.MeasureString(Title.Text, Title.Font ?? Font).Height + Title.Padding.Vertical);
                        break;
                    case ChartLocation.Left:
                    case ChartLocation.Right:
                        titleRect.Size = new SizeF(g.MeasureString(Title.Text, Title.Font ?? Font).Width + Title.Padding.Horizontal, this.Height - Padding.Vertical);
                        break;
                }

                switch(Title.Location)
                {
                    case ChartLocation.Top:
                        titleRect.Location = new PointF(Padding.Left, Padding.Top);
                        break;
                    case ChartLocation.Bottom:
                        titleRect.Location = new PointF(Padding.Left, this.Height-Padding.Bottom- titleRect.Size.Height);
                        break;
                    case ChartLocation.Left:
                        titleRect.Location = new PointF(Padding.Left, Padding.Top);
                        break;
                    case ChartLocation.Right:
                        titleRect.Location = new PointF(this.Width - titleRect.Width, Padding.Top);
                        break;
                }

            }
            else
            {
                titleRect = RectangleF.Empty;
            }
                
        }

        private void calculateDrawsLegend(Graphics g)
        {
            if (Legend.Visible && Series.Count > 0) 
            {
                switch (Legend.Location)
                {
                    case ChartLocation.Top:
                    case ChartLocation.Bottom:
                        /*var h = g.MeasureString(Series[0].Name, Legend.Font ?? Font).Height;
                        var w = Series.Sum(x => g.MeasureString(x.Name, Legend.Font ?? Font).Width + Legend.Padding.Right + h*0.7);
                        legendRect.Size = new SizeF((float)w, h + Legend.Padding.Vertical);*/
                        break;
                    case ChartLocation.Left:
                    case ChartLocation.Right:
                        var maxLen = Series.Select(x => new { name = x.Name, len = x.Name.Length }).Where(x => x.len == Series.Max(y => y.Name.Length)).FirstOrDefault();
                        var maxItem = g.MeasureString(maxLen.name, Legend.Font ?? Font);
                        maxItem.Width += Legend.Padding.Horizontal + Legend.Padding.Right + (maxItem.Height * 0.7f);
                        maxItem.Height += Legend.Padding.Top;
                        legendRect.Size = new SizeF(maxItem.Width, maxItem.Height * Series.Count);
                        break;
                }

                switch (Legend.Location)
                {
                    case ChartLocation.Top:
                        //legendRect.Location = new PointF(Padding.Left, titleRect.Top+titleRect.Height);
                        break;
                    case ChartLocation.Bottom:
                        //legendRect.Location = new PointF(Padding.Left, this.Height - Padding.Bottom - titleRect.Size.Height);
                        break;
                    case ChartLocation.Left:
                        //legendRect.Location = new PointF(Padding.Left, Padding.Top);
                        break;
                    case ChartLocation.Right:
                        legendRect.Location = new PointF(this.Width - legendRect.Width, titleRect.Top + titleRect.Height);
                        break;
                }

            }
            else
            {
                legendRect = RectangleF.Empty;
            }
        }

        private void calculateDrawsAxis(Graphics g)
        {
            // calc series text sizes
            var serieSize = Series.Select(x => new { name = x.Name, len = x.Name.Length, size = g.MeasureString(x.Name, this.Font),
                valTxt = x.Values.Max().ToString(),
                valLen = x.Values.Max().ToString().Length
            }).ToList();

            var maxValLen = serieSize.Find(x => x.valLen == serieSize.Max(x => x.valLen));
            var vaxValSize = g.MeasureString(maxValLen.valTxt, Font);

            //var aXw = this.Width - legendRect.Width - Padding.Left;
            var xAxisMaxCalcWidth = serieSize.Find(x=>x.name.Length == serieSize.Max(x =>x.name.Length));

            // calulo del tamaño del texto con el último angulo
            g.RotateTransform(xAxisNameAngle); 
            var maxXSize = g.MeasureString(xAxisMaxCalcWidth.name, Font);


            // Y Axis : valor y ancho
            yAxisMaxVal = Series.Max(x => x.Values.Max());
            yAxisWidth = vaxValSize.Width + 2 + 4;

            // X Axis Calular el angulo del texto y ancho
            xAxisBarWidth = xAxisGroupWidht / Series.Max(x => x.Values.Count);
            if(maxXSize.Width * serieSize.Count > xAxisBarWidth)
            {
                xAxisNameAngle = 45;
                g.RotateTransform(xAxisNameAngle); 
                maxXSize = g.MeasureString(xAxisMaxCalcWidth.name, Font);
                if (maxXSize.Width * serieSize.Count > xAxisBarWidth)
                {
                    xAxisNameAngle = 90;
                    g.RotateTransform(xAxisNameAngle);
                    maxXSize = g.MeasureString(xAxisMaxCalcWidth.name, Font);
                }
            }
            xAxisGroupHeight = maxXSize.Height;
            xAxisGroups = serieSize.Count();
            xAxisGroupWidht = xAxisBarWidth / xAxisGroups;

            // Y Axis : Alto
            yAxisHeight = this.Height - titleRect.Size.Height - xAxisGroupHeight;

            // Y Axis : Alto
            //yAxisJumpVal = yAxisMaxVal / AxisYMaxDivisions;

            yAxisRect = new RectangleF(titleRect.Height, Padding.Left, yAxisWidth, yAxisHeight);
            xAxisRect = new RectangleF(titleRect.Height+yAxisRect.Height, Padding.Left + yAxisRect.Size.Width, xAxisBarWidth, xAxisGroupHeight);
            grafRect = new RectangleF(yAxisRect.Width, yAxisRect.Y, xAxisRect.Width, yAxisRect.Height);
        }

        #endregion


        private void drawGraf(Graphics g)
        {
            g.DrawRectangle(Pens.Red, yAxisRect.X, yAxisRect.Y, yAxisRect.Width, yAxisRect.Height);
            g.FillRectangle(Brushes.LightCoral, yAxisRect);
            g.DrawRectangle(Pens.Green, xAxisRect.X, xAxisRect.Y, xAxisRect.Width, xAxisRect.Height);
            g.DrawRectangle(Pens.Black, grafRect.X, grafRect.Y, grafRect.Width, grafRect.Height);
        }
    }
}
