using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Load : Form
    {
        public Load()
        {
            InitializeComponent();
            bunifuProgressBar1.Value = 0;            
            bunifuProgressBar1.TransitionValue(100, 2300);
            
        }

        private void bunifuProgressBar1_ProgressChanged(object sender, Bunifu.UI.WinForms.BunifuProgressBar.ProgressChangedEventArgs e)
        {
            int value = Convert.ToInt32(bunifuProgressBar1.Value);
            if (value == 100)
            {
                
                Auth a1 = new Auth();
                a1.Show();
                this.Hide();
            }
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
