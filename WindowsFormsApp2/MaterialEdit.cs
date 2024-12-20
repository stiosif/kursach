using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp2
{
    public partial class MaterialEdit : Form
    {
        int id;
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionStringG);
        public MaterialEdit(int id, string name, int price)
        {
            InitializeComponent();
            this.id = id;
            textBox1.Text = name;
            textBox2.Text = price.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {

                try
                {
                    Materials main = this.Owner as Materials;

                    
                    SqlCommand comm = new SqlCommand("MaterialEdit", conn) { CommandType = CommandType.StoredProcedure };
                    comm.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
                    comm.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar) { Value = textBox1.Text });
                    comm.Parameters.Add(new SqlParameter("@price", SqlDbType.Money) { Value = Convert.ToInt32(textBox2.Text) });
                    SqlCommand comm2 = new SqlCommand("select * from materials", conn) { CommandType = CommandType.Text };
                    DataTable RefreshedTable = new DataTable();
                    conn.Open();
                    comm.ExecuteNonQuery();
                    RefreshedTable.Load(comm2.ExecuteReader());
                    conn.Close();
                    main.dataGridView1.DataSource = RefreshedTable.DefaultView;
                    this.Hide();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox2.Text.Length < 20 && (e.KeyChar >= '0') && (e.KeyChar <= '9') || Char.IsControl(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        private void bunifuFormCaptionButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
