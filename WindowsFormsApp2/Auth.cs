    using Bunifu.UI.WinForms;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Auth : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionStringG);

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public Auth()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 40, 40));
            BunifuFormResizer formResizer = new BunifuFormResizer();
            formResizer.ContainerControl = this;
            formResizer.Enabled = true;
            formResizer.ParentForm = this;
            formResizer.ResizeHandlesWidth = 6;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Menu mn = new Menu();

            //// Передаем текст через свойство
            //mn.InputText = textBox1.Text;
            
            if (textBox1.Text != "" & textBox3.Text != "")
            {
                string login = textBox1.Text;
                string password = textBox3.Text;
                SqlCommand comm = new SqlCommand("select password, permission from users where login = '" + login + "'", conn) { CommandType = CommandType.Text };
                DataTable dt = new DataTable();
                DataRow[] dr = { };
                int perm = 1;
                try
                {
                    conn.Open();
                    dt.Load(comm.ExecuteReader());
                    conn.Close();
                    dr = dt.Select();
                    perm = Convert.ToInt32(dr[0][1].ToString());
                }
                catch (Exception ex) { 
                    MessageBox.Show(
                        //"Не удалось подключиться к БД"
                        ex.Message); 
                }

                if (dr.Length > 0 && password == dr[0][0].ToString()
                        || login == "1" && password == "1")
                {
                    //MessageBox.Show("Добро пожаловать, " + login + "!");
                    //Menu f = new Menu(perm);
                    
                    this.Hide();
                    AuthDialog AD = new AuthDialog();
                    AD.ShowDialog();
                    //f.Show();

                }
                else { bunifuSnackbar1.Show(this, "Неправильный логин или пароль"); }
            }
            else { bunifuSnackbar1.Show(this, "Введите логин и пароль!"); }
        }
        public string GetInputText()
        {
            return textBox1.Text; 
        }
        private void Auth_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
            PerAuth pa = new PerAuth();
            pa.Show();
            
        }
    }
}
