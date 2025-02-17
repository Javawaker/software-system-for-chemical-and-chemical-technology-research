using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Authorization : Form
    {
        int i = 0;
        public Authorization()
        {
            InitializeComponent();
            DataBase.openConnection();
            this.MouseDown += new MouseEventHandler(Authorization_MouseDown);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string loginUser = textBox14.Text;
            string passUser = textBox1.Text;


            if (textBox14.Text != "" && textBox1.Text != "")
            {
                i++;
                if (i <= 3)
                {
                    button1.Enabled = true;
                    using (SqlCommand command = new SqlCommand("SELECT * FROM users WHERE login = @uL AND password = @uP", DataBase.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@uL", System.Data.DbType.String).Value = loginUser;
                        command.Parameters.AddWithValue("@uP", System.Data.DbType.String).Value = passUser;
                        DataTable table = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = command;
                        adapter.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            if (Convert.ToString(table.Rows[0][3]) == "Администратор")
                            {
                                Form1 form = new Form1();
                                form.Show();
                                this.Hide();

                            }
                            else if (Convert.ToString(table.Rows[0][3]) == "Исследователь")
                            {
                                Complex form = new Complex();
                                form.Show();
                                this.Hide();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Неверные данные", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else
                {
                    button1.Enabled = false;
                    MessageBox.Show("Вы превысили количество возможных попыток входа!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Заполните необходимые поля", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase.closeConnection();
            Application.Exit();
        }

        private void Authorization_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
