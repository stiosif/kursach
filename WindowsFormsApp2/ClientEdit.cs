using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class ClientEdit : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionStringG);
        int id;
        public ClientEdit(int id, string surname, string name, string phone)
        {
            Clients main = this.Owner as Clients;
            InitializeComponent();
            this.id = id;
            textBox1.Text = surname;
            textBox2.Text = name;
            textBox3.Text = phone;   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {

                try
                {
                    Clients main = this.Owner as Clients;
                    SqlCommand comm = new SqlCommand("ClientEdit", conn) { CommandType = CommandType.StoredProcedure };
                    comm.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
                    comm.Parameters.Add(new SqlParameter("@surname", SqlDbType.VarChar) { Value = textBox1.Text });
                    comm.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar) { Value = textBox2.Text });
                    comm.Parameters.Add(new SqlParameter("@phone", SqlDbType.VarChar) { Value = Convert.ToDecimal(textBox3.Text) });
                    SqlCommand comm2 = new SqlCommand("select * from clients", conn) { CommandType = CommandType.Text };
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
    }
}
