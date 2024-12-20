using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Menu : Form
    {
        int perm;

        


        public Menu()
        {
            InitializeComponent();
            RadioButton radioButton = new RadioButton();
            radioButton.Text = "Option 1";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Materials f = new Materials(perm);
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Orders f = new Orders();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clients f = new Clients(perm);
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InStockMaterials f = new InStockMaterials();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Request f = new Request();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Supplies f = new Supplies();
            f.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            bunifuPictureBox2.Visible = true;
            bunifuPictureBox3.Visible = false;
            bunifuPictureBox2.Visible = true;
            bunifuPictureBox3.Visible = false;
            bunifuButton1.Visible = true;
            bunifuButton2.Visible = true;
            bunifuButton3.Visible = true;
            bunifuButton4.Visible = true;
            bunifuButton5.Visible = true;
            bunifuButton6.Visible = true;
            bunifuButton7.Visible = false;
            bunifuButton8.Visible = false;
            bunifuLabel2.Visible = false;
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        

        private void label1_Click(object sender, EventArgs e)
        {
            bunifuPictureBox2.Visible = true;
            bunifuPictureBox3.Visible = false;
            bunifuButton1.Visible = true;
            bunifuButton2.Visible = true;
            bunifuButton3.Visible = true;
            bunifuButton4.Visible = true;
            bunifuButton5.Visible = true;
            bunifuButton6.Visible = true; 
            bunifuButton7.Visible = false;
            bunifuButton8.Visible = false;
            bunifuLabel1.Visible = true;
            bunifuLabel2.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            bunifuPictureBox3.Visible = true;
            bunifuPictureBox2.Visible = false;
            bunifuButton1.Visible = false;
            bunifuButton2.Visible = false;
            bunifuButton3.Visible = false;
            bunifuButton4.Visible = false;
            bunifuButton5.Visible = false;
            bunifuButton6.Visible = false;
            bunifuButton7.Visible = true;
            bunifuButton8.Visible = true;
            bunifuLabel1.Visible = false;
            bunifuLabel2.Visible = true;
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }
    }
}
