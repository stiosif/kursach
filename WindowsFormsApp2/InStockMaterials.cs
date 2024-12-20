using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.HSSF;
using NPOI.XSSF.UserModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class InStockMaterials : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionStringG);
        List<Material> materials = new List<Material>();

        public InStockMaterials()
        {
            InitializeComponent();
        }

        private void InStockMaterials_Load(object sender, EventArgs e)
        {
            SqlCommand comm = new SqlCommand("select * from InStockMaterials", conn) { CommandType = CommandType.Text };
            DataTable RefreshedTable = new DataTable();
            conn.Open();
            RefreshedTable.Load(comm.ExecuteReader());
            conn.Close();
            dataGridView1.DataSource = RefreshedTable.DefaultView;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dialog.DefaultExt = ".xlsx";
            dialog.Filter = "Таблицы Excel (*.xlsx)|*.xlsx|Все файлы (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.FileName = "Отчет";

            SqlCommand comm = new SqlCommand("SelectInStockMaterials", conn) { CommandType = CommandType.StoredProcedure };
            DataTable dt = new DataTable();
            conn.Open();
            dt.Load(comm.ExecuteReader());
            conn.Close();
            DataRow[] rows = dt.Select();
            for (int i = 0; i < rows.Length; i++)
            {
                materials.Add(new Material(Convert.ToInt32(rows[i][0].ToString()), rows[i][1].ToString(), Convert.ToInt32(rows[i][2].ToString())));
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var file = new FileStream(dialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                var template = new MemoryStream(Properties.Resources.Шаблон, true);
                var workbook = new XSSFWorkbook(template);
                var sheet = workbook.GetSheetAt(0);
                sheet.GetRow(0).GetCell(1).SetCellValue(DateTime.Today.ToShortDateString());
                sheet.GetRow(1).GetCell(1).SetCellValue(materials.Count());
                sheet.ShiftRows(5, sheet.LastRowNum, materials.Count(), true, true);
                int row = 5;
                foreach (var item in materials.OrderBy(o => o.id))
                {
                    var rowInsert = sheet.CreateRow(row);
                    rowInsert.CreateCell(0).SetCellValue(item.id);
                    rowInsert.CreateCell(1).SetCellValue(item.name);
                    rowInsert.CreateCell(2).SetCellValue(item.instock);
                    row++;
                }
                workbook.Write(file);
            }

        }

        private void bunifuFormCaptionButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
