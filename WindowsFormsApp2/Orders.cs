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
    public partial class Orders : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionStringG);
        public Orders()
        {
            InitializeComponent();
            //comboBox3.Visible= false;
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kptypoDataSet.orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.kptypoDataSet.orders);
            SqlCommand comm = new SqlCommand("select id, substring(name, 1, 1) + surname as name from clients", conn) { CommandType = CommandType.Text };
            SqlCommand comm2 = new SqlCommand("select id, name from materials", conn) { CommandType = CommandType.Text };
            DataTable ComboBox1Table = new DataTable();
            DataTable ComboBox2Table = new DataTable();
            DataTable ComboBox3Table = new DataTable();
            conn.Open();
            ComboBox1Table.Load(comm.ExecuteReader());
            ComboBox2Table.Load(comm2.ExecuteReader());
            ComboBox3Table.Load(comm2.ExecuteReader());
            conn.Close();
            //comboBox2.DataSource = ComboBox1Table.DefaultView;
            //comboBox2.DisplayMember = "name";
            //comboBox2.ValueMember = "id";
            //comboBox3.DataSource = ComboBox2Table.DefaultView;
            //comboBox3.DisplayMember = "name";
            //comboBox3.ValueMember = "id";
            //comboBox4.DataSource = ComboBox3Table.DefaultView;
            //comboBox4.DisplayMember = "name";
            //comboBox4.ValueMember = "id";
            //comboBox2.Enabled = true;
            //comboBox3.Enabled = true;
            //comboBox4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        if (textBox1.Text != "")
                        {
                            ordersBindingSource.Filter = "id = '" + textBox1.Text + "'";
                        }
                        else
                        {
                            ordersBindingSource.Filter = "";
                        }
                        break;
                    }
                case 1:
                    {
                        if (textBox1.Text != "")
                        {
                            ordersBindingSource.Filter = "books_amount = '" + textBox1.Text + "'";
                        }
                        else
                        {
                            ordersBindingSource.Filter = "";
                        }
                        break;
                    }
                case 2:
                    {
                        if (textBox1.Text != "")
                        {
                            ordersBindingSource.Filter = "total = '" + textBox1.Text + "'";
                        }
                        else
                        {
                            ordersBindingSource.Filter = "";
                        }
                        break;
                    }
                case 3:
                    {
                        if (textBox1.Text != "")
                        {
                            ordersBindingSource.Filter = "cost = '" + textBox1.Text + "'";
                        }
                        else
                        {
                            ordersBindingSource.Filter = "";
                        }
                        break;
                    }
                case 4:
                    {
                        if (textBox1.Text != "")
                        {
                            ordersBindingSource.Filter = "pages = '" + textBox1.Text + "'";
                        }
                        else
                        {
                            ordersBindingSource.Filter = "";
                        }
                        break;
                    }
                default: break;
            }
        }

        //private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBox2.Enabled)
        //        ordersBindingSource.Filter = "clients_id = " + comboBox2.SelectedValue.ToString();
        //}

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBox4.Enabled)
        //        ordersBindingSource.Filter = "cover_material = " + comboBox4.SelectedValue.ToString();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text != "")
            {
                int id = Convert.ToInt32(dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value);
                if (id > 0)
                {
                    SqlCommand comm = new SqlCommand("update orders set status = '" + comboBox5.Text + "' where id = " + id, conn) { CommandType = CommandType.Text };
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                    this.ordersTableAdapter.Fill(this.kptypoDataSet.orders);
                }
            }
        }

        private void bunifuFormCaptionButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
