using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class AuthDialog : Form
    {
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
        public AuthDialog()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.timer = new Timer();
            this.timer.Interval = 3000; 
            this.timer.Tick += new EventHandler(Timer_Tick);
            this.timer.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
        private Timer timer;
        private void Timer_Tick(object sender, EventArgs e)
        {
            Menu m = new Menu();

            timer.Stop(); // Останавливаем таймер
            
            m.Show(); // Показываем вторую форму
            this.Hide(); // Скрываем первую форму
        }

        private void AuthDialog_Load(object sender, EventArgs e)
        {
            
        }
        
    }
}
