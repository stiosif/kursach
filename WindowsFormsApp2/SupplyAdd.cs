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
    public partial class SupplyAdd : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionStringG);
        public SupplyAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox2.Text != "нажмите дважды" && dateTimePicker1.Value.ToString() != "")
            {
                try
                {
                    Supplies main = this.Owner as Supplies;
                    SqlCommand comm = new SqlCommand("SupplyAdd", conn) { CommandType = CommandType.StoredProcedure };
                    comm.Parameters.Add(new SqlParameter("@date", SqlDbType.Date) { Value = dateTimePicker1.Value.ToString() });
                    comm.Parameters.Add(new SqlParameter("@area", SqlDbType.Float) { Value = Convert.ToDouble(textBox1.Text) });
                    comm.Parameters.Add(new SqlParameter("@materials_id", SqlDbType.Int) { Value = Convert.ToInt32(textBox2.Text) });
                    SqlCommand comm2 = new SqlCommand("select * from supplies", conn) { CommandType = CommandType.Text };
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

        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            PickMaterial f = new PickMaterial("SupplyAdd") { Owner = this};
            f.Show();
        }

        private void bunifuFormCaptionButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
