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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            DataBase.openConnection();
            using (SqlCommand command = new SqlCommand("SELECT id_user as 'ID пользователя', login as 'Логин', password as 'Пароль', role as 'Роль' FROM users", DataBase.GetConnection()))
            {
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            dataGridView1.Columns[1].Width = 137;
            dataGridView1.Columns[2].Width = 137;
            dataGridView1.Columns[3].Width = 137;
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

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox2.Text !="")
            {

                using (SqlCommand command = new SqlCommand("INSERT INTO users(login, password, role) values (@uL, @uP, @rL)", DataBase.GetConnection()))
                {
                    command.Parameters.AddWithValue("@uL", textBox1.Text);
                    command.Parameters.AddWithValue("@uP", textBox2.Text);
                    command.Parameters.AddWithValue("@rL", comboBox2.Text);
                    command.ExecuteNonQuery();

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    command.CommandText = "SELECT id_user as 'ID пользователя', login as 'Логин', password as 'Пароль', role as 'Роль' FROM users";

                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                    MessageBox.Show("Данные успешно добавлены!", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Нет данных для добавления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlCommand command = new SqlCommand("UPDATE Users SET login = @log, password = @pass, role = @rL WHERE id_user = @id", DataBase.GetConnection()))
            {
                command.Parameters.AddWithValue("@log", textBox1.Text);
                command.Parameters.AddWithValue("@rL", comboBox2.Text);
                command.Parameters.AddWithValue("@pass", textBox2.Text);
                command.Parameters.AddWithValue("@id", comboBox1.Text);

                command.ExecuteNonQuery();

                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                command.CommandText = "SELECT id_user as 'ID пользователя', login as 'Логин', password as 'Пароль', role as 'Роль' FROM users";

                adapter.SelectCommand = command;
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                MessageBox.Show("Данные успешно изменены!", "Смена данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись? Это действие нельзя будет отменить", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var id = dataGridView1.SelectedRows[0].Cells[0].Value;
                    using (SqlCommand command = new SqlCommand("DELETE FROM users WHERE id_user = @id_user", DataBase.GetConnection()))
                    {
                        command.Parameters.AddWithValue("id_user", Convert.ToInt32(id));
                        command.ExecuteNonQuery();

                        DataTable table = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        command.CommandText = "SELECT id_user as 'ID пользователя', login as 'Логин', password as 'Пароль', role as 'Роль' FROM users";

                        adapter.SelectCommand = command;
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                        MessageBox.Show("Запись была успешно удалена из базы данных", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlCommand command = new SqlCommand("SELECT id_materials as 'ID материала', name_materials as 'Название материала' FROM Materials", DataBase.GetConnection1()))
            {
                DataTable ds1 = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(ds1);
                dataGridView2.DataSource = ds1;


                DataTable ds2 = new DataTable();
                SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT id_parametr as 'ID параметра', name_parametr as 'Название параметра', Units.name_unit as 'Единицы измерения', type_parametr as 'Тип параметра' FROM Parametrs_material INNER JOIN Units ON Parametrs_material.id_unit = Units.id_unit ", DataBase.GetConnection1());
                ds2.Clear();
                adapter2.Fill(ds2);
                dataGridView3.DataSource = ds2;

                DataTable ds3 = new DataTable();
                SqlDataAdapter adapter3 = new SqlDataAdapter("SELECT id_value as 'ID значения', name_parametr as 'Название параметра', name_materials as 'Название материала', value_characteristic as 'Значение' FROM Value_parametrs INNER JOIN Materials ON Value_parametrs.id_materials = Materials.id_materials INNER JOIN Parametrs_material ON Value_parametrs.id_parametr = Parametrs_material.id_parametr", DataBase.GetConnection1());
                ds3.Clear();
                adapter3.Fill(ds3);
                dataGridView4.DataSource = ds3;

                DataTable ds4 = new DataTable();
                SqlDataAdapter adapter4 = new SqlDataAdapter("SELECT id_unit as 'ID единицы измерения', name_unit as 'Единица измерения' FROM Units", DataBase.GetConnection1());
                ds4.Clear();
                adapter4.Fill(ds4);
                dataGridView5.DataSource = ds4;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {

                using (SqlCommand command = new SqlCommand("INSERT INTO Materials(name_materials) values (@nM)", DataBase.GetConnection1()))
                {
                    command.Parameters.AddWithValue("@nM", System.Data.DbType.String).Value = textBox4.Text;
                    command.ExecuteNonQuery();

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    command.CommandText = "SELECT id_materials as 'ID материала', name_materials as 'Название материала' FROM Materials";

                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    dataGridView2.DataSource = table;
                    MessageBox.Show("Данные успешно добавлены!", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Нет данных для добавления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись? Это действие нельзя будет отменить", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM Materials WHERE id_materials = @id", DataBase.GetConnection1()))
                {
                    var id = dataGridView2.SelectedRows[0].Cells[0].Value;
                    command.Parameters.AddWithValue("id", Convert.ToInt32(id));
                    command.ExecuteNonQuery();

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    command.CommandText = "SELECT id_materials as 'ID материала', name_materials as 'Название материала' FROM Materials";

                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    dataGridView2.DataSource = table;
                    MessageBox.Show("Запись была успешно удалена из базы данных", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int idUnit = 0;
            if (comboBox3.Text != "" && comboBox4.Text != "" && textBox5.Text != "")
            {
                using (SqlCommand command = new SqlCommand("SELECT id_unit FROM Units WHERE name_unit = @nU", DataBase.GetConnection1()))
                {
                    command.Parameters.AddWithValue("@nU", System.Data.DbType.String).Value = comboBox3.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                        idUnit = Convert.ToInt32(reader["id_unit"]);
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    reader.Close();

                    command.CommandText = "INSERT INTO Parametrs_material(name_parametr, type_parametr, id_unit) values (@nP, @tP, @iU)";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@nP", System.Data.DbType.String).Value = textBox5.Text;
                    command.Parameters.AddWithValue("@tP", System.Data.DbType.String).Value = comboBox4.Text;
                    command.Parameters.AddWithValue("@iU", System.Data.DbType.String).Value = idUnit;
                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT id_parametr as 'ID параметра', name_parametr as 'Название параметра', name_unit as 'Единицы измерения', type_parametr as 'Тип параметра' FROM Parametrs_material INNER JOIN Units ON Parametrs_material.id_unit = Units.id_unit";
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    dataGridView3.DataSource = table;
                    MessageBox.Show("Данные успешно добавлены!", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
            }
            else
            {
                MessageBox.Show("Нет данных для добавления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись? Это действие нельзя будет отменить", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM Parametrs_material WHERE id_parametr = @id", DataBase.GetConnection1()))
                {
                    string id = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
                    command.Parameters.AddWithValue("id", id);
                    command.ExecuteNonQuery();

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    command.CommandText = "SELECT id_parametr as 'ID параметра', name_parametr as 'Название параметра', name_unit as 'Единицы измерения', type_parametr as 'Тип параметра' FROM Parametrs_material INNER JOIN Units ON Parametrs_material.id_unit = Units.id_unit ";
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    dataGridView3.DataSource = table;
                    MessageBox.Show("Запись была успешно удалена из базы данных", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int idMaterial = 0;
            int idParametr = 0;
            if (comboBox5.Text != "" && comboBox6.Text != "" && textBox3.Text != "")
            {
                using (SqlCommand command = new SqlCommand("SELECT id_materials FROM Materials WHERE name_materials = @nM", DataBase.GetConnection1()))
                {
                    command.Parameters.AddWithValue("@nM", System.Data.DbType.String).Value = comboBox5.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                        idMaterial = Convert.ToInt32(reader["id_materials"]);
                    reader.Close();
                    command.Parameters.Clear();
                    command.CommandText = "SELECT id_parametr FROM Parametrs_material WHERE name_parametr = @nP";
                    command.Parameters.AddWithValue("@nP", System.Data.DbType.String).Value = comboBox6.Text;
                    reader= command.ExecuteReader();
                    while (reader.Read())
                        idParametr = Convert.ToInt32(reader["id_parametr"]);
                    reader.Close();
                    command.Parameters.Clear();
                    command.CommandText = "INSERT INTO Value_parametrs(id_materials, id_parametr, value_characteristic) values (@iM, @iP, @vC)";
                    command.Parameters.AddWithValue("@iM", System.Data.DbType.String).Value = idMaterial;
                    command.Parameters.AddWithValue("@iP", System.Data.DbType.String).Value = idParametr;
                    command.Parameters.AddWithValue("@vC", System.Data.DbType.Double).Value = textBox3.Text;
                    command.ExecuteNonQuery();
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    command.CommandText = "SELECT id_value as 'ID значения', name_parametr as 'Название параметра', name_materials as 'Название материала', value_characteristic as 'Значение' FROM Value_parametrs INNER JOIN Materials ON Value_parametrs.id_materials = Materials.id_materials INNER JOIN Parametrs_material ON Value_parametrs.id_parametr = Parametrs_material.id_parametr";
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    dataGridView4.DataSource = table;
                    MessageBox.Show("Данные успешно добавлены!", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Нет данных для добавления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись? Это действие нельзя будет отменить", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM Value_parametrs WHERE id_value = @id", DataBase.GetConnection1()))
                {
                    string id = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    command.CommandText= "SELECT id_value as 'ID значения', name_parametr as 'Название параметра', name_materials as 'Название материала', value_characteristic as 'Значение' FROM Value_parametrs INNER JOIN Materials ON Value_parametrs.id_materials = Materials.id_materials INNER JOIN Parametrs_material ON Value_parametrs.id_parametr = Parametrs_material.id_parametr";
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    dataGridView4.DataSource = table;
                    MessageBox.Show("Запись была успешно удалена из базы данных", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                using (SqlCommand command = new SqlCommand("INSERT INTO Units(name_unit) values (@nU)", DataBase.GetConnection1()))
                {
                     command.Parameters.AddWithValue("@nU", System.Data.DbType.String).Value = textBox6.Text;
                    command.ExecuteNonQuery();
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    command.CommandText = "SELECT id_unit as 'ID единицы измерения', name_unit as 'Единица измерения' FROM Units";
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    dataGridView5.DataSource = table;
                    MessageBox.Show("Данные успешно добавлены!", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Нет данных для добавления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись? Это действие нельзя будет отменить", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM Units WHERE id_unit = @id", DataBase.GetConnection1()))
                {
                    string id = dataGridView5.SelectedRows[0].Cells[0].Value.ToString();
                    command.Parameters.AddWithValue("id", id);
                    command.ExecuteNonQuery();
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    command.CommandText = "SELECT id_unit as 'ID единицы измерения', name_unit as 'Единица измерения' FROM Units";
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    dataGridView5.DataSource = table;
                    MessageBox.Show("Запись была успешно удалена из базы данных", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            SqlCommand command = new SqlCommand("SELECT id_user FROM users", DataBase.GetConnection());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                comboBox1.Items.Add(Convert.ToString(reader["id_user"]));
            reader.Close();
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            SqlCommand command = new SqlCommand("SELECT name_unit FROM Units", DataBase.GetConnection1());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                comboBox3.Items.Add((string)reader["name_unit"]);
            reader.Close();
        }

        private void comboBox5_Click(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            SqlCommand command = new SqlCommand("SELECT name_materials FROM Materials", DataBase.GetConnection1());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                comboBox5.Items.Add((string)reader["name_materials"]);
            reader.Close();
        }

        private void comboBox6_Click(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            SqlCommand command = new SqlCommand("SELECT name_parametr FROM Parametrs_material", DataBase.GetConnection1());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                comboBox6.Items.Add((string)reader["name_parametr"]);
            reader.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Authorization form = new Authorization();
            form.Show();
            this.Hide();
        }
    }
}
