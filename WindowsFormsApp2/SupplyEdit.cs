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
    public partial class SupplyEdit : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionStringG);
        int id;
        public SupplyEdit(int id, string date, double area, int materials_id)
        {
            InitializeComponent();
            this.id = id;
            
            var DateConverted = DateTime.Parse(date);
            dateTimePicker1.Value = DateConverted;
            textBox1.Text = area.ToString();
            textBox2.Text = materials_id.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox2.Text != "нажмите дважды" && dateTimePicker1.Value.ToString() != "")
            {
                try
                {
                    Supplies main = this.Owner as Supplies;
                    SqlCommand comm = new SqlCommand("SupplyEdit", conn) { CommandType = CommandType.StoredProcedure };
                    comm.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
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

        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            PickMaterial f = new PickMaterial("SupplyEdit") { Owner = this };
            f.Show();
        }

        private void SupplyEdit_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFormCaptionButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
