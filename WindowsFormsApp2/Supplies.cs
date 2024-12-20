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

namespace WindowsFormsApp2
{
    public partial class Supplies : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionStringG);
        public Supplies()
        {
            InitializeComponent();
        }

        private void Supplies_Load(object sender, EventArgs e)
        {
            
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kptypoDataSet1.supplies". При необходимости она может быть перемещена или удалена.
            this.suppliesTableAdapter.Fill(this.kptypoDataSet1.supplies);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        if (textBox1.Text != "")
                        {
                            suppliesBindingSource.Filter = "id = '" + textBox1.Text + "'";
                        }
                        else
                        {
                            suppliesBindingSource.Filter = "";
                        }
                        break;
                    }
                case 1:
                    {
                        suppliesBindingSource.Filter = "Date like '%" + textBox1.Text + "%'";
                        break;
                    }
                case 2:
                    {
                        if (textBox1.Text != "")
                        {
                            suppliesBindingSource.Filter = "area = '" + textBox1.Text + "'";
                        }
                        else
                        {
                            suppliesBindingSource.Filter = "";
                        }
                        break;
                    }
                case 3:
                    {
                        suppliesBindingSource.Filter = "materials_id like '%" + textBox1.Text + "%'";
                        break;
                    }
                default: break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //int id = Convert.ToInt32(dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value);
                //if (id > 0)
                //{
                    int id = Convert.ToInt32(dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value);
                    SqlCommand comm = new SqlCommand("delete from supplies where id = " + id, conn) { CommandType = CommandType.Text };
                    SqlCommand comm2 = new SqlCommand("select * from supplies", conn) { CommandType = CommandType.Text };
                    DataTable RefreshedTable = new DataTable();
                    conn.Open();
                    comm.ExecuteNonQuery();
                    RefreshedTable.Load(comm2.ExecuteReader());
                    conn.Close();
                    dataGridView1.DataSource = RefreshedTable.DefaultView;
                //}
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value);
            if (id > 0)
            {
                string date = dataGridView1[1, dataGridView1.SelectedCells[0].RowIndex].Value.ToString();
                double area = Convert.ToDouble(dataGridView1[2, dataGridView1.SelectedCells[0].RowIndex].Value);
                int materials_id = Convert.ToInt32(dataGridView1[3, dataGridView1.SelectedCells[0].RowIndex].Value);
                SupplyEdit f = new SupplyEdit(id, date, area, materials_id);
                f.Owner = this;
                f.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SupplyAdd f = new SupplyAdd();
            f.Owner = this;
            f.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFormCaptionButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void suppliesBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
