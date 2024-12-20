using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Clients : Form
    {
        int perm;
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionStringG);
        public Clients(int perm)
        {
            InitializeComponent();
            this.perm = perm;
            if (perm > 1)
            {
                bunifuButton1.Enabled = false; bunifuButton2.Enabled = false; bunifuButton3.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kptypoDataSet.clients". При необходимости она может быть перемещена или удалена.
            this.clientsTableAdapter.Fill(this.kptypoDataSet.clients);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientAdd f = new ClientAdd();
            f.Owner = this;
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value);
            if (id > 0)
            {
                string surname = dataGridView1[1, dataGridView1.SelectedCells[0].RowIndex].Value.ToString();
                string name = dataGridView1[2, dataGridView1.SelectedCells[0].RowIndex].Value.ToString();
                string phone = dataGridView1[3, dataGridView1.SelectedCells[0].RowIndex].Value.ToString();
                ClientEdit f = new ClientEdit(id, surname, name, phone);
                f.Owner = this;
                f.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        if (textBox1.Text != "")
                        {
                            clientsBindingSource.Filter = "id = '" + textBox1.Text + "'";  
                        }
                        else
                        {
                            clientsBindingSource.Filter = "";
                        }
                        break;
                    }
                case 1:
                    clientsBindingSource.Filter = "surname like '%" + textBox1.Text + "%'";
                    break;
                case 2:
                    clientsBindingSource.Filter = "name like '%" + textBox1.Text + "%'";
                    break;
                case 3:
                    if (textBox1.Text != "")
                    {
                        clientsBindingSource.Filter = "phone = '" + textBox1.Text + "'";
                    }
                    else
                    {
                        clientsBindingSource.Filter = "";
                    }
                    break;
                default: break;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value);
                if (id > 0)
                {
                    // Удаляем записи из таблицы orders, связанных с текущим клиентом
                    SqlCommand comm2 = new SqlCommand("DELETE FROM orders WHERE clients_id = @clientId", conn);
                    comm2.Parameters.AddWithValue("@clientId", id);

                    // Удаляем текущего клиента
                    SqlCommand comm = new SqlCommand("DELETE FROM clients WHERE id = @clientId", conn);
                    comm.Parameters.AddWithValue("@clientId", id);

                    conn.Open();

                    // Выполняем сначала удаление из orders, затем из clients
                    comm2.ExecuteNonQuery(); // Удаление из orders
                    comm.ExecuteNonQuery();  // Удаление клиента

                    conn.Close();

                    // Обновляем данные в DataGridView
                    RefreshClientsTable();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RefreshClientsTable()
        {
            // Загружаем обновленные данные в clientsBindingSource
            this.clientsTableAdapter.Fill(this.kptypoDataSet.clients);
            dataGridView1.DataSource = clientsBindingSource; // Обновляем источник данных
        }

        private void clientsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFormCaptionButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
