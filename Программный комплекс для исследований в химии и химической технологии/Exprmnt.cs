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
    public partial class Exprmnt : Form
    {
        public Exprmnt()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(Exprmnt_MouseDown);
            button6.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            double qy, qa, viscosity = 0;
            double FirstPartCalc;
            double SecondPartCalc;
            double ThirdPartCalc;
            double Efficiency;
            double Temperature = 0;
            double f;
            double qch;
            double minParam;
            double maxParam, stepV;
            // int i = 0; // движение по массиву

            PlotExperiment.par.Clear();
            PlotExperiment.efficiencyPlotExperiment.Clear();
            PlotExperiment.temperaturePlotExperiment.Clear();
            PlotExperiment.viscosityPlotExperiment.Clear();

            minParam = Convert.ToDouble(minPar.Text);
            maxParam = Convert.ToDouble(maxPar.Text);
            stepV = Convert.ToDouble(step.Text);
            PlotExperiment.minPar = minParam;
            PlotExperiment.maxPar = maxParam;

            if ( minPar.Text != "" && maxPar.Text != "" && step.Text != "")
            {
                if (minPar.Text != "0" && maxPar.Text != "0" && step.Text != "0")
                {
                    if (Convert.ToDouble(minPar.Text) <= Convert.ToDouble(maxPar.Text))
                    {
                        button6.Enabled = true;

                            dataGridView1.Columns[0].HeaderText = "Скорость крышки канала, м/с";
                            dataGridView1.Columns[1].HeaderText = "Производительность канала, кг/ч";
                            dataGridView1.Columns[2].HeaderText = "Температура продукта, °С";
                            dataGridView1.Columns[3].HeaderText = "Вязкость продукта, Па*с";
                            PlotExperiment.varPar = "Скорость крышки канала, м/с";

                            while (Math.Round(minParam, 2) <= Math.Round(maxParam, 2))

                            {
                                qy = Calculator.CalcQGamma(Calculator.depth, Calculator.width, Calculator.consistencyRatio, minParam, Calculator.flowIndex);
                                qa = Calculator.CalcQAlpha(Calculator.heatTransferCoefficient, Calculator.width, Calculator.viscosityCoefficient, Calculator.temperature, Calculator.reductionTemperature);
                                f = Calculator.CalcF(Calculator.depth, Calculator.width);
                                qch = Calculator.CalcQCh(Calculator.width, Calculator.depth, minParam, f);
                                FirstPartCalc = Calculator.CalcFirstPart(Calculator.viscosityCoefficient, qy, Calculator.width, Calculator.heatTransferCoefficient, qa);
                                SecondPartCalc = Calculator.CalcSecondPart(Calculator.density, Calculator.heatCapacity, qch);
                                ThirdPartCalc = Calculator.CalcThirdPart(Calculator.meltingTemperature, Calculator.reductionTemperature, qa, Calculator.length, SecondPartCalc);

                                Temperature = Calculator.CalcTemperature(Calculator.reductionTemperature, Calculator.viscosityCoefficient, FirstPartCalc, qa, Calculator.length, SecondPartCalc, ThirdPartCalc);

                                viscosity = Calculator.CalcViscosity(Calculator.consistencyRatio, Calculator.viscosityCoefficient, Temperature, Calculator.reductionTemperature, minParam, Calculator.depth, Calculator.flowIndex);

                                Efficiency = Calculator.CalcEfficiency(Calculator.density, Calculator.width, Calculator.depth, minParam, f);

                                dataGridView1.Rows.Add(minParam, Efficiency, Temperature, viscosity);
                                PlotExperiment.par.Add(minParam);
                                PlotExperiment.efficiencyPlotExperiment.Add(Efficiency);
                                PlotExperiment.temperaturePlotExperiment.Add(Temperature);
                                PlotExperiment.viscosityPlotExperiment.Add(viscosity);
                                // i++;

                                minParam += Math.Round(stepV, 2);
                            }
                        button6.Enabled = true;

                    }


                    else
                    {
                        MessageBox.Show("Начальное значение не может быть больше конечного!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Значения не могут быть равны нулю!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                MessageBox.Show("Введите необходимые значения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Exprmnt_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void button6_Click(object sender, EventArgs e)
        {

              PlotCapSpeed plot = new PlotCapSpeed();
             plot.Show();
           
        }
    }
}
