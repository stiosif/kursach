using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class ClientAdd : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionStringG);
        public ClientAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                
                try
                {
                    Clients main = this.Owner as Clients;
                    SqlCommand comm = new SqlCommand("ClientAdd", conn) { CommandType = CommandType.StoredProcedure };
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox3.Text.Length<20 && (e.KeyChar >= '0') && (e.KeyChar <= '9') || Char.IsControl(e.KeyChar) )
            {
                return;
            }
            e.Handled = true;
        }

        private void ClientAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
