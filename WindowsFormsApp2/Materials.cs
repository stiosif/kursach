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
    public partial class Materials : Form
    {
        int perm;
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionStringG);
        public Materials(int perm)
        {
            InitializeComponent();
            this.perm = perm;
            if (perm > 1)
            {
                bunifuButton1.Enabled = false; bunifuButton2.Enabled = false; bunifuButton3.Enabled = false;
            }
        }

        private void Materials_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kptypoDataSet.materials". При необходимости она может быть перемещена или удалена.
            this.materialsTableAdapter.Fill(this.kptypoDataSet.materials);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MaterialAdd f = new MaterialAdd();
            f.Owner = this;
            f.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value);
                if (id > 0)
                {
                    string name = dataGridView1[1, dataGridView1.SelectedCells[0].RowIndex].Value.ToString();
                    int price = Convert.ToInt32(dataGridView1[2, dataGridView1.SelectedCells[0].RowIndex].Value);
                    MaterialEdit f = new MaterialEdit(id, name, price);
                    f.Owner = this;
                    f.Show();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
}
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value);
                if (id > 0)
                {
                    SqlCommand comm = new SqlCommand("delete from materials where id = " + id, conn) { CommandType = CommandType.Text };
                    SqlCommand comm2 = new SqlCommand("select * from materials", conn) { CommandType = CommandType.Text };
                    DataTable RefreshedTable = new DataTable();
                    conn.Open();
                    comm.ExecuteNonQuery();
                    RefreshedTable.Load(comm2.ExecuteReader());
                    conn.Close();
                    dataGridView1.DataSource = RefreshedTable.DefaultView;

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        if (textBox1.Text != "")
                        {
                            materialsBindingSource.Filter = "id = '" + textBox1.Text + "'";
                        }
                        else
                        {
                            materialsBindingSource.Filter = "";
                        }
                        break;
                    }
                case 1:
                    {
                        materialsBindingSource.Filter = "name like '%" + textBox1.Text + "%'";
                        break;
                    }
                case 2:
                    {
                        if (textBox1.Text != "")
                        {
                            materialsBindingSource.Filter = "price = '" + textBox1.Text + "'";
                        }
                        else
                        {
                            materialsBindingSource.Filter = "";
                        }
                        break;
                    }
                default: break;
            }
        }

        private void bunifuFormCaptionButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
