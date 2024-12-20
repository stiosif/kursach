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
    public partial class PickMaterial : Form
    {
        string owner;
        public PickMaterial(string owner)
        {
            InitializeComponent();
            this.owner = owner;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (owner == "SupplyEdit")
                {
                    SupplyEdit main = Owner as SupplyEdit;
                    main.textBox2.Text = dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value.ToString();
                }
                if (owner == "SupplyAdd")
                {
                    SupplyAdd main = Owner as SupplyAdd;
                    main.textBox2.Text = dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value.ToString();
                }
            }
            this.Hide();
        }

        private void PickMaterial_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kptypoDataSet.InStockMaterials". При необходимости она может быть перемещена или удалена.
            this.inStockMaterialsTableAdapter.Fill(this.kptypoDataSet.InStockMaterials);

        }

        private void bunifuFormCaptionButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
