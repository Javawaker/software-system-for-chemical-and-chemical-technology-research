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
    public partial class PlotCapSpeed : Form
    {
        public PlotCapSpeed()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(PlotCapSpeed_MouseDown);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PlotCapSpeed_MouseDown(object sender, MouseEventArgs e)
        {

            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void PlotCapSpeed_Load(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
            this.chart2.Series[0].Points.Clear();
            this.chart3.Series[0].Points.Clear();

            chart1.Series[0].ToolTip = "Скорость крышки, м/с = #VALX, Производительность, кг/ч = #VALY";
            chart2.Series[0].ToolTip = "Скорость крышки, м/с = #VALX, Температура продукта, С = #VALY";
            chart3.Series[0].ToolTip = "Скорость крышки, м/с = #VALX, Вязкость продукта, Па*с = #VALY";

            chart1.ChartAreas[0].AxisX.Maximum = PlotExperiment.maxPar; //Задаешь максимальные значения координат
            chart1.ChartAreas[0].AxisX.Minimum = PlotExperiment.minPar; //Задаешь максимальные значения координат
            chart1.ChartAreas[0].AxisY.Maximum = PlotExperiment.efficiencyPlotExperiment.Max();
            chart1.ChartAreas[0].AxisY.Minimum = PlotExperiment.efficiencyPlotExperiment.Min(); //Задаешь максимальные значения координат

            chart2.ChartAreas[0].AxisX.Maximum = PlotExperiment.maxPar; //Задаешь максимальные значения координат
            chart2.ChartAreas[0].AxisX.Minimum = PlotExperiment.minPar; //Задаешь максимальные значения координат
            chart2.ChartAreas[0].AxisY.Maximum = PlotExperiment.temperaturePlotExperiment.Max();
            chart2.ChartAreas[0].AxisY.Minimum = PlotExperiment.temperaturePlotExperiment.Min();

            chart3.ChartAreas[0].AxisX.Maximum = PlotExperiment.maxPar; //Задаешь максимальные значения координат
            chart3.ChartAreas[0].AxisX.Minimum = PlotExperiment.minPar; //Задаешь максимальные значения координат
            chart3.ChartAreas[0].AxisY.Maximum = PlotExperiment.viscosityPlotExperiment.Max();
            chart3.ChartAreas[0].AxisY.Minimum = PlotExperiment.viscosityPlotExperiment.Min();


            int z1 = 0, z2 = 0, z3 = 0;
            double y1 = 0, y2 = 0, y3 = 0;

            while (z1 < PlotExperiment.par.Count)
            {
                y1 = PlotExperiment.efficiencyPlotExperiment.ElementAt(z1);
                this.chart1.Series[0].Points.AddXY(PlotExperiment.par.ElementAt(z1), y1);
                z1++;
            }

            while (z2 < PlotExperiment.par.Count)
            {
                y2 = PlotExperiment.temperaturePlotExperiment.ElementAt(z2);
                this.chart2.Series[0].Points.AddXY(PlotExperiment.par.ElementAt(z2), y2);
                z2++;
            }

            while (z3 < PlotExperiment.par.Count)
            {
                y3 = PlotExperiment.viscosityPlotExperiment.ElementAt(z3);
                this.chart3.Series[0].Points.AddXY(PlotExperiment.par.ElementAt(z3), y3);
                z3++;
            }
        }
    }
}
