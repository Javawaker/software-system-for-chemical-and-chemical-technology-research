using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Plot : Form
    {
        public Plot()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(Plot_MouseDown);
        }

        private void Plot_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void Plot_Load(object sender, EventArgs e)
        {
            int i = 0, j = 0;
            while (i < PlotData.coordinateCanalPlot.Count)
            {
                dataGridView1.Rows.Add(PlotData.coordinateCanalPlot.ElementAt(i), PlotData.temperatureProductPlot.ElementAt(i));
                i++;
            }
            while (j < PlotData.coordinateCanalPlot.Count)
            {
                dataGridView2.Rows.Add(PlotData.coordinateCanalPlot.ElementAt(j), PlotData.viscosityProductPlot.ElementAt(j));
                j++;
            }

            this.chart1.Series[0].Points.Clear();
            this.chart2.Series[0].Points.Clear();
            chart1.Series[0].ToolTip = "Координата, м = #VALX, Температура, С = #VALY";
            chart2.Series[0].ToolTip = "Координата, м = #VALX, Вязкость, Па*с = #VALY";

            chart1.ChartAreas[0].AxisX.Maximum = Calculator.length; //Задаешь максимальные значения координат
            chart1.ChartAreas[0].AxisX.Minimum = 0; //Задаешь максимальные значения координат

            chart1.ChartAreas[0].AxisY.Maximum = Indicators.temperatureProduct;
            chart1.ChartAreas[0].AxisY.Minimum = Calculator.meltingTemperature;

            chart2.ChartAreas[0].AxisX.Maximum = Calculator.length; //Задаешь максимальные значения координат
            chart2.ChartAreas[0].AxisX.Minimum = 0; //Задаешь максимальные значения координат

            chart2.ChartAreas[0].AxisY.Minimum = Indicators.viscosityProduct;

            int z1 = 0, z2 = 0;
            double y1 = 0, y2 = 0;

            while (z1 < PlotData.coordinateCanalPlot.Count)
            {
                y1 = PlotData.temperatureProductPlot.ElementAt(z1);
                this.chart1.Series[0].Points.AddXY(PlotData.coordinateCanalPlot.ElementAt(z1), y1);
                z1++;
            }

            while (z2 < PlotData.coordinateCanalPlot.Count)
            {
                y2 = PlotData.viscosityProductPlot.ElementAt(z2);
                this.chart2.Series[0].Points.AddXY(PlotData.coordinateCanalPlot.ElementAt(z2), y2);
                z2++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
