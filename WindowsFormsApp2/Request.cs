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
    public partial class Request : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionStringG);
        int clients_id, books_amount, pages_material, pages, cover_material;
        double total, cost, pages_area, cover_area;

        private void bunifuFormCaptionButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Request_Load(object sender, EventArgs e)
        {

        }

        public Request()
        {
            InitializeComponent();
            SqlCommand comm = new SqlCommand("select materials.id, materials.name, materials.price from materials join InStockMaterials on materials.id = InStockMaterials.id where InStockMaterials.instock > 0", conn) { CommandType = CommandType.Text };
            DataTable ComboBox2Table = new DataTable();
            DataTable ComboBox1Table = new DataTable();
            conn.Open();
            ComboBox2Table.Load(comm.ExecuteReader());
            ComboBox1Table.Load(comm.ExecuteReader());
            conn.Close();
            comboBox2.DataSource = ComboBox2Table.DefaultView;
            comboBox2.DisplayMember= "name";
            comboBox2.ValueMember = "price";
            comboBox1.DataSource = ComboBox1Table.DefaultView;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "price";
        }
        private void textBox4_DoubleClick(object sender, EventArgs e)
        {
            PickClient f = new PickClient() { Owner = this };
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                
                SqlCommand comm = new SqlCommand("OrderCreate", conn) { CommandType = CommandType.StoredProcedure };
                comm.Parameters.Add(new SqlParameter("@clients_id", SqlDbType.Int) { Value =        clients_id      });
                comm.Parameters.Add(new SqlParameter("@books_amount", SqlDbType.Int) { Value =      books_amount    });
                comm.Parameters.Add(new SqlParameter("@total", SqlDbType.Money) { Value =           total           });
                comm.Parameters.Add(new SqlParameter("@cost", SqlDbType.Money) { Value =            cost            });
                comm.Parameters.Add(new SqlParameter("@pages_material", SqlDbType.Int) { Value =    pages_material  });
                comm.Parameters.Add(new SqlParameter("@pages_area", SqlDbType.Float) { Value =      pages_area      });
                comm.Parameters.Add(new SqlParameter("@pages", SqlDbType.Int) { Value =             pages           });
                comm.Parameters.Add(new SqlParameter("@cover_material", SqlDbType.Int) { Value =    cover_material  });
                comm.Parameters.Add(new SqlParameter("@cover_area", SqlDbType.Float) { Value =      cover_area      });
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
                this.Hide();
            }
            else { MessageBox.Show("Расчитайте стоимость"); }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) { comboBox1.Enabled = false; }
            else { comboBox1.Enabled = true; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "" && textBox4.Text != "нажмите дважды" && textBox5.Text != "" & textBox6.Text != "")
            {
                double PageArea = Convert.ToDouble(textBox5.Text) * Convert.ToDouble(textBox6.Text) / 10000;
                double Pages = Convert.ToDouble(textBox1.Text);
                double BooksAmount = Convert.ToDouble(textBox2.Text);
                double MaterialPrice = Convert.ToDouble(comboBox2.SelectedValue);
                double BindingPrice = 0;
                SqlCommand comm1 = new SqlCommand("select instock from InStockMaterials where name = '" + comboBox1.Text + "'", conn) { CommandType = CommandType.Text };
                SqlCommand comm1_1 = new SqlCommand("select id from InStockMaterials where name = '" + comboBox1.Text + "'", conn) { CommandType = CommandType.Text };
                SqlCommand comm2 = new SqlCommand("select instock from InStockMaterials where name = '" + comboBox2.Text + "'", conn) { CommandType = CommandType.Text };
                SqlCommand comm2_1 = new SqlCommand("select id from InStockMaterials where name = '" + comboBox2.Text + "'", conn) { CommandType = CommandType.Text };
                DataTable ProcResult1 = new DataTable();
                DataTable ProcResult2 = new DataTable();
                DataTable ProcResult1_1 = new DataTable();
                DataTable ProcResult2_1 = new DataTable();
                conn.Open();
                ProcResult1.Load(comm1.ExecuteReader());
                ProcResult2.Load(comm2.ExecuteReader());
                ProcResult1_1.Load(comm1_1.ExecuteReader());
                ProcResult2_1.Load(comm2_1.ExecuteReader());
                conn.Close();
                DataRow[] rw1 = ProcResult1.Select();
                DataRow[] rw2 = ProcResult2.Select();
                DataRow[] rw1_1 = ProcResult1_1.Select();
                DataRow[] rw2_1 = ProcResult2_1.Select();
                int amount1 = Convert.ToInt32(rw1[0][0]);
                int amount2 = Convert.ToInt32(rw2[0][0]);
                int id1 = Convert.ToInt32(rw1_1[0][0]);
                int id2 = Convert.ToInt32(rw2_1[0][0]);
                double CoverArea = 0;
                if (PageArea * Pages * BooksAmount > amount2) { MessageBox.Show("Недостаточно материалов на страницы, выберите другой" + (PageArea * Pages * BooksAmount).ToString() + " " + amount2.ToString()); }
                else if (PageArea * 2.2 > amount1) { MessageBox.Show("Недостаточно материалов на обложку, выберите другой"); }
                else
                {
                    if (radioButton2.Checked)
                    {
                        CoverArea = PageArea * 2.2;
                        BindingPrice = CoverArea * Convert.ToDouble(comboBox1.SelectedValue);
                    }
                    double k = 2;
                    if (BooksAmount > 20) { k = 1.8; }
                    if (BooksAmount > 100) { k = 1.5; }
                    if (BooksAmount > 1000) { k = 1.4; }
                    if (BooksAmount > 10000) { k = 1.3; }
                    if (BooksAmount > 100000) { k = 1.2; }
                    double Cost = (PageArea * Pages * MaterialPrice + BindingPrice) * BooksAmount;
                    double Total = Cost * k;
                    textBox3.Text = Total.ToString();

                    clients_id = Convert.ToInt32(textBox4.Text);
                    books_amount = Convert.ToInt32(BooksAmount);
                    total = Total;
                    cost = Cost;
                    pages_material = id2;
                    pages_area = PageArea*Pages*BooksAmount;
                    pages = Convert.ToInt32(Pages);
                    cover_material = id1;
                    cover_area = CoverArea;        
                }
            }
            else { MessageBox.Show("Заполните все поля"); }
        }
    }
}
