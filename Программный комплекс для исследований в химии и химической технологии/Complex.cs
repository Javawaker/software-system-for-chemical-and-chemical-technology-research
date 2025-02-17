using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Complex : Form
    {
        public Complex()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(Complex_MouseDown);
            button6.Enabled = false;
            button8.Enabled = false;
            DataBase.openConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase.closeConnection();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчики: Емельянова К.И. и Шахов М.А.\nСПБГТИ(ТУ)\nГруппа 405\n", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Complex_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool flag = true;

            if (textBox1.Text.Equals(""))
            {
                textBox1.BackColor = Color.Red;
                flag = false;
            }
            if (textBox2.Text.Equals(""))
            {
                textBox2.BackColor = Color.Red;
                flag = false;
            }
            if (textBox3.Text.Equals(""))
            {
                textBox3.BackColor = Color.Red;
                flag = false;
            }
            if (textBox4.Text.Equals(""))
            {
                textBox4.BackColor = Color.Red;
                flag = false;
            }
            if (textBox5.Text.Equals(""))
            {
                textBox5.BackColor = Color.Red;
                flag = false;
            }
            if (textBox6.Text.Equals(""))
            {
                textBox6.BackColor = Color.Red;
                flag = false;
            }
            if (textBox7.Text.Equals(""))
            {
                textBox7.BackColor = Color.Red;
                flag = false;
            }
            if (textBox8.Text.Equals(""))
            {
                textBox8.BackColor = Color.Red;
                flag = false;
            }
            if (textBox9.Text.Equals(""))
            {
                textBox9.BackColor = Color.Red;
                flag = false;
            }
            if (textBox10.Text.Equals(""))
            {
                textBox10.BackColor = Color.Red;
                flag = false;
            }
            if (textBox11.Text.Equals(""))
            {
                textBox11.BackColor = Color.Red;
                flag = false;
            }
            if (textBox12.Text.Equals(""))
            {
                textBox12.BackColor = Color.Red;
                flag = false;
            }
            if (textBox13.Text.Equals(""))
            {
                textBox13.BackColor = Color.Red;
                flag = false;
            }
            if (flag == false) { MessageBox.Show("Введите необходимые значения", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                Calculator.length = Convert.ToDouble(textBox1.Text);
                Calculator.width = Convert.ToDouble(textBox2.Text);
                Calculator.depth = Convert.ToDouble(textBox3.Text);
                Calculator.density = Convert.ToDouble(textBox4.Text);
                Calculator.heatCapacity = Convert.ToDouble(textBox5.Text);
                Calculator.meltingTemperature = Convert.ToDouble(textBox6.Text);
                Calculator.capSpeed = Convert.ToDouble(textBox7.Text);
                Calculator.temperature = Convert.ToDouble(textBox8.Text);
                try
                {
                    Calculator.stepCanal = Convert.ToDouble(textBox15.Text);
                }
                catch (Exception)
                {

                    MessageBox.Show("Неверный формат данных");
                    return;
                }
                Calculator.consistencyRatio = Convert.ToDouble(textBox10.Text);
                Calculator.viscosityCoefficient = Convert.ToDouble(textBox9.Text);
                Calculator.reductionTemperature = Convert.ToDouble(textBox11.Text);
                Calculator.flowIndex = Convert.ToDouble(textBox12.Text);
                Calculator.heatTransferCoefficient = Convert.ToDouble(textBox13.Text);

                if (Calculator.length <= 0)
                {
                    textBox1.BackColor = Color.Red;
                    flag = false;
                }
                if (Calculator.width <= 0)
                {
                    textBox2.BackColor = Color.Red;
                    flag = false;
                }
                if (Calculator.depth <= 0)
                {
                    textBox3.BackColor = Color.Red;
                    flag = false;
                }
                if (Calculator.stepCanal <= 0)
                {
                    textBox15.BackColor = Color.Red;
                    flag = false;
                }
                if (Calculator.density <= 0)
                {
                    textBox4.BackColor = Color.Red;
                    flag = false;
                }
                if (Calculator.heatCapacity <= 0)
                {
                    textBox5.BackColor = Color.Red;
                    flag = false;
                }
                if (Calculator.meltingTemperature <= 0)
                {
                    textBox6.BackColor = Color.Red;
                    flag = false;
                }
                if (Calculator.capSpeed <= 0)
                {
                    textBox7.BackColor = Color.Red;
                    flag = false;
                }
                if (Calculator.temperature <= 0)
                {
                    textBox8.BackColor = Color.Red;
                    flag = false;
                }
                if (Calculator.consistencyRatio <= 0)
                {
                    textBox10.BackColor = Color.Red;
                    flag = false;
                }
                if (Calculator.viscosityCoefficient <= 0)
                {
                    textBox9.BackColor = Color.Red;
                    flag = false;
                }
                if (Calculator.reductionTemperature <= 0)
                {
                    textBox11.BackColor = Color.Red;
                    flag = false;
                }
                if (Calculator.flowIndex <= 0)
                {
                    textBox12.BackColor = Color.Red;
                    flag = false;
                }
                if (Calculator.heatTransferCoefficient <= 0)
                {
                    textBox13.BackColor = Color.Red;
                    flag = false;
                }
                if (flag==false)
                {
                    MessageBox.Show("Значения не могут быть отрицательными или нулевыми, введите корректные значения!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    button6.Enabled = true;
                    textBox1.BackColor = Color.White;
                    textBox2.BackColor = Color.White;
                    textBox3.BackColor = Color.White;
                    textBox4.BackColor = Color.White;
                    textBox5.BackColor = Color.White;
                    textBox6.BackColor = Color.White;
                    textBox7.BackColor = Color.White;
                    textBox8.BackColor = Color.White;
                    textBox9.BackColor = Color.White;
                    textBox10.BackColor = Color.White;
                    textBox11.BackColor = Color.White;
                    textBox12.BackColor = Color.White;
                    textBox13.BackColor = Color.White;

                    Stopwatch stopwatch = new Stopwatch();
                    //засекаем время начала операции
                    stopwatch.Start();

                    double qy, qa, viscosity = 0;
                    qy = Calculator.CalcQGamma(Calculator.depth, Calculator.width, Calculator.consistencyRatio, Calculator.capSpeed, Calculator.flowIndex);
                    qa = Calculator.CalcQAlpha(Calculator.heatTransferCoefficient, Calculator.width, Calculator.viscosityCoefficient, Calculator.temperature, Calculator.reductionTemperature);
                    double FirstPartCalc;
                    double SecondPartCalc;
                    double ThirdPartCalc;
                    double Efficiency;
                    double Temperature = 0;
                    double f;
                    double qch;
                    double z = 0; //координата по длине канала
                    int i = 0; // движение по массиву

                    PlotData.coordinateCanalPlot.Clear();
                    PlotData.temperatureProductPlot.Clear();
                    PlotData.viscosityProductPlot.Clear();
                    dataGridView1.Rows.Clear();


                    f = Calculator.CalcF(Calculator.depth, Calculator.width);

                    while (Math.Round(z, 2) <= Calculator.length)

                    {

                        double Coordinate = Math.Round(z, 2);
                        qch = Calculator.CalcQCh(Calculator.width, Calculator.depth, Calculator.capSpeed, f);
                        FirstPartCalc = Calculator.CalcFirstPart(Calculator.viscosityCoefficient, qy, Calculator.width, Calculator.heatTransferCoefficient, qa);
                        SecondPartCalc = Calculator.CalcSecondPart(Calculator.density, Calculator.heatCapacity, qch);
                        ThirdPartCalc = Calculator.CalcThirdPart(Calculator.meltingTemperature, Calculator.reductionTemperature, qa, z, SecondPartCalc);

                        Temperature = Calculator.CalcTemperature(Calculator.reductionTemperature, Calculator.viscosityCoefficient, FirstPartCalc, qa, z, SecondPartCalc, ThirdPartCalc);

                        viscosity = Calculator.CalcViscosity(Calculator.consistencyRatio, Calculator.viscosityCoefficient, Temperature, Calculator.reductionTemperature, Calculator.capSpeed, Calculator.depth, Calculator.flowIndex);

                        dataGridView1.Rows.Add(Coordinate, Temperature, viscosity);
                        PlotData.coordinateCanalPlot.Add(Coordinate);
                        PlotData.temperatureProductPlot.Add(Temperature);
                        PlotData.viscosityProductPlot.Add(viscosity);
                        i++;
                        z += Math.Round(Calculator.stepCanal, 2);
                    }

                    Efficiency = Calculator.CalcEfficiency(Calculator.density, Calculator.width, Calculator.depth, Calculator.capSpeed, f);
                    textBox14.Text = String.Format(Convert.ToString(Efficiency));
                    Indicators.efficiencyCanal = Efficiency;
                    textBox16.Text = String.Format(Convert.ToString(Temperature));
                    Indicators.temperatureProduct = Temperature;
                    textBox17.Text = String.Format(Convert.ToString(viscosity));
                    Indicators.viscosityProduct = viscosity;
                    stopwatch.Stop();
                    textBox18.Text = String.Format(Convert.ToString(stopwatch.ElapsedMilliseconds));

                    Process pr = Process.GetCurrentProcess();
                    int mem = (int)pr.WorkingSet64 / (1024 * 1024);
                    textBox19.Text = String.Format(Convert.ToString(mem));
                    button8.Enabled = true;

                }
            }

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            using (SqlCommand command = new SqlCommand("SELECT name_materials FROM Materials", DataBase.GetConnection1()))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    comboBox1.Items.Add((string)reader["name_materials"]);
                reader.Close(); 
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlCommand command = new SqlCommand("SELECT value_characteristic FROM Value_parametrs INNER JOIN Materials ON Value_parametrs.id_materials = Materials.id_materials INNER JOIN Parametrs_material ON Value_parametrs.id_parametr = Parametrs_material.id_parametr  WHERE name_materials = @nM AND name_parametr = @nP", DataBase.GetConnection1()))
            {
                command.Parameters.AddWithValue("nM", comboBox1.Text);
                command.Parameters.AddWithValue("nP", "Плотность");

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    textBox4.Text = reader[0].ToString();
                reader.Close();
                command.Parameters.Clear();

                command.Parameters.AddWithValue("nM", comboBox1.Text);
                command.Parameters.AddWithValue("nP", "Удельная теплоемкость");
                reader = command.ExecuteReader();
                while (reader.Read())
                    textBox5.Text = reader[0].ToString();
                reader.Close();
                command.Parameters.Clear();
                command.Parameters.AddWithValue("nM", comboBox1.Text);
                command.Parameters.AddWithValue("nP", "Температура плавления");
                reader = command.ExecuteReader();
                while (reader.Read())
                    textBox6.Text = reader[0].ToString();
                reader.Close();
                command.Parameters.Clear();
                command.Parameters.AddWithValue("nM", comboBox1.Text);
                command.Parameters.AddWithValue("nP", "Коэффициент консистенции при температуре приведения");
                reader = command.ExecuteReader();
                while (reader.Read())
                    textBox10.Text = reader[0].ToString();
                reader.Close();
                command.Parameters.Clear();
                command.Parameters.AddWithValue("nM", comboBox1.Text);
                command.Parameters.AddWithValue("nP", "Температурный коэффициент вязкости");
                reader = command.ExecuteReader();
                while (reader.Read())
                    textBox9.Text = reader[0].ToString();
                reader.Close();
                command.Parameters.Clear();
                command.Parameters.AddWithValue("nM", comboBox1.Text);
                command.Parameters.AddWithValue("nP", "Температура приведения");
                reader = command.ExecuteReader();
                while (reader.Read())
                    textBox11.Text = reader[0].ToString();
                reader.Close();
                command.Parameters.Clear();
                command.Parameters.AddWithValue("nM", comboBox1.Text);
                command.Parameters.AddWithValue("nP", "Индекс течения");
                reader = command.ExecuteReader();
                while (reader.Read())
                    textBox12.Text = reader[0].ToString();
                reader.Close();
                command.Parameters.Clear();
                command.Parameters.AddWithValue("nM", comboBox1.Text);
                command.Parameters.AddWithValue("nP", "Коэффициент теплоотдачи от крышки канала к материалу");
                reader = command.ExecuteReader();
                while (reader.Read())
                    textBox13.Text = reader[0].ToString();
                reader.Close();


            }
            }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "XLSX (*.xlsx)|*.xlsx";
                sfd.FileName = "Отчет.xlsx";



                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Невозможно записать данные на диск." + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            Excel.Application excelapp = new Excel.Application();
                            Excel.Workbook workbook = excelapp.Workbooks.Add();
                            Excel.Worksheet worksheet = workbook.ActiveSheet;

                            worksheet.Range["A1"].ColumnWidth = 64;
                            worksheet.Range["B1"].ColumnWidth = 18;
                            worksheet.Range["C1"].ColumnWidth = 29;
                            worksheet.Range["D1"].ColumnWidth = 15;
                            worksheet.Range["E1"].ColumnWidth = 15;
                            worksheet.Range["F1"].ColumnWidth = 29;
                            worksheet.Range["G1"].ColumnWidth = 10;

                            // Добавление названий столбцов
                            worksheet.Range["C1"].Offset[0, 0].Value = "Координата по длине канала, м";
                            worksheet.Range["C1"].Font.Bold = true;
                            worksheet.Range["C1"].Offset[0, 1].Value = "Температура, С";
                            worksheet.Range["D1"].Font.Bold = true;
                            worksheet.Range["C1"].Offset[0, 2].Value = "Вязкость, Па*с";
                            worksheet.Range["E1"].Font.Bold = true;

                            //прорисовка границ
                            worksheet.Range["C1"].Offset[0, 0].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["C1"].Offset[0, 1].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["C1"].Offset[0, 2].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;


                            for (int i = 1; i < PlotData.coordinateCanalPlot.Count + 1; i++)
                            {
                                //заполнение данными
                                worksheet.Range["C1"].Offset[i, 0].Value = PlotData.coordinateCanalPlot[i - 1];
                                worksheet.Range["C1"].Offset[i, 1].Value = PlotData.temperatureProductPlot[i - 1];
                                worksheet.Range["C1"].Offset[i, 2].Value = PlotData.viscosityProductPlot[i - 1];

                                //прорисовка границ
                                worksheet.Range["C1"].Offset[i, 0].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                                worksheet.Range["C1"].Offset[i, 1].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                                worksheet.Range["C1"].Offset[i, 2].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            }

                            worksheet.Range["F1"].Value = "Критериальные показатели";
                            worksheet.Range["F1"].Font.Bold = true;
                            worksheet.Range["F1"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["G1"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;

                            worksheet.Range["F2"].Value = "Производительность канала, кг/ч";
                            worksheet.Range["F2"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["G2"].Value = Indicators.efficiencyCanal;
                            worksheet.Range["G2"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;

                            worksheet.Range["F3"].Value = "Температура, С";
                            worksheet.Range["F3"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["G3"].Value = Indicators.temperatureProduct; ;
                            worksheet.Range["G3"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;

                            worksheet.Range["F4"].Value = "Вязкость продукта, Па*с";
                            worksheet.Range["F4"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["G4"].Value = Indicators.viscosityProduct; ;
                            worksheet.Range["G4"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;

                            worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 2]].Merge();
                            worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 2]].Value = "Входные параметры";
                            worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 2]].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 2]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 2]].Font.Bold = true;

                            worksheet.Range["A2"].Value = "Геометрические параметры";
                            worksheet.Range["A2"].Font.Bold = true;
                            worksheet.Range["A2"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["B2"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["A3"].Value = "Ширина, м";
                            worksheet.Range["A3"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["B3"].Value = Calculator.width;
                            worksheet.Range["B3"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["A4"].Value = "Длина, м";
                            worksheet.Range["A4"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["B4"].Value = Calculator.length;
                            worksheet.Range["B4"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["A5"].Value = "Глубина, м";
                            worksheet.Range["A5"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["B5"].Value = Calculator.depth;
                            worksheet.Range["B5"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;

                            worksheet.Range["A7"].Value = "Материал";
                            worksheet.Range["A7"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["B7"].Value = comboBox1.Text;
                            worksheet.Range["B7"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;

                            worksheet.Range["A9"].Value = "Параметры свойств материала";
                            worksheet.Range["A9"].Font.Bold = true;
                            worksheet.Range["A9"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["B9"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["A10"].Value = "Плотность, кг/м^3";
                            worksheet.Range["A10"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["B10"].Value = Calculator.density;
                            worksheet.Range["B10"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["A11"].Value = "Удельная теплоемкость, Дж/(кг*С)";
                            worksheet.Range["A11"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["B11"].Value = Calculator.heatCapacity;
                            worksheet.Range["B11"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["A12"].Value = "Температура плавления, С";
                            worksheet.Range["A12"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["B12"].Value = Calculator.meltingTemperature;
                            worksheet.Range["B12"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;

                            worksheet.Range["A14"].Value = "Варьируемые параметры";
                            worksheet.Range["A14"].Font.Bold = true;
                            worksheet.Range["A14"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["B14"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["A15"].Value = "Скорость крышки, м/с";
                            worksheet.Range["A15"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["B15"].Value = Calculator.capSpeed;
                            worksheet.Range["B15"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["A16"].Value = "Температура крышки, С";
                            worksheet.Range["A16"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["B16"].Value = Calculator.temperature;
                            worksheet.Range["B16"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;

                            worksheet.Range["A18"].Value = "Эмпирические коэффициенты математической модели";
                            worksheet.Range["A18"].Font.Bold = true;
                            worksheet.Range["A18"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["B18"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["A19"].Value = "Коэффициент консистенции при температуре приведения, Па*с^n";
                            worksheet.Range["A19"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["B19"].Value = Calculator.consistencyRatio;
                            worksheet.Range["B19"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["A20"].Value = "Температурный коэффициент вязкости, 1/C";
                            worksheet.Range["A20"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["B20"].Value = Calculator.viscosityCoefficient;
                            worksheet.Range["B20"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["A21"].Value = "Температура приведения, С";
                            worksheet.Range["A21"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["B21"].Value = Calculator.reductionTemperature;
                            worksheet.Range["B21"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["A22"].Value = "Индекс течения";
                            worksheet.Range["A22"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["B22"].Value = Calculator.flowIndex;
                            worksheet.Range["B22"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["A23"].Value = "Коэффициент теплоотдачи от крышки канала к материалу, Вт/(м^2*C)";
                            worksheet.Range["A23"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["B23"].Value = Calculator.heatTransferCoefficient;
                            worksheet.Range["B23"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;

                            worksheet.Range["A25"].Value = "Параметры метода решения модели";
                            worksheet.Range["A25"].Font.Bold = true;
                            worksheet.Range["A25"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["B25"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["A26"].Value = "Шаг расчета по длине канала, м";
                            worksheet.Range["A26"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;
                            worksheet.Range["B26"].Value = Calculator.stepCanal;
                            worksheet.Range["B26"].Borders.LineStyle = Excel.XlAboveBelow.xlBelowAverage;


                            excelapp.AlertBeforeOverwriting = false;
                            workbook.SaveAs(sfd.FileName);
                            excelapp.Quit();

                            var result = MessageBox.Show("Данные успешно сохранены!\nОткрыть файл?", "Экспорт в Excel", MessageBoxButtons.YesNo);

                            switch (result)
                            {
                                case DialogResult.Yes:
                                    Process.Start(sfd.FileName);
                                    break;
                                case DialogResult.No:

                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка:" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Нет данных для сохранения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Plot plot = new Plot();
            plot.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Authorization form = new Authorization();
            form.Show();
            this.Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 44))
                    e.Handled = true;
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Exprmnt exp = new Exprmnt();
            exp.Show();
        }

        private void Complex_Load(object sender, EventArgs e)
        {

        }
    }
    }

