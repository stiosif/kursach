using Bunifu.UI.WinForms;
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WindowsFormsApp2
{

    public partial class PerAuth : Form
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionStringG);
        public PerAuth()
        {
            InitializeComponent();
        }

        private void PerAuth_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Auth a = new Auth();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                bunifuSnackbar1.Show(this, "Поля не заполнены");
                return;
            }

            if (textBox2.Text != textBox3.Text)
            {
                bunifuSnackbar1.Show(this, "Пароли не совпадают");
                return;
            }

            try
            {
                conn.Open();

                // Проверка на существование логина
                SqlCommand checkUserCommand = new SqlCommand("SELECT COUNT(*) FROM users WHERE login = @login", conn);
                checkUserCommand.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar) { Value = textBox1.Text });

                int userExists = (int)checkUserCommand.ExecuteScalar();

                if (userExists > 0)
                {
                    // Если пользователь существует, выводим сообщение
                    bunifuSnackbar1.Show(this, "Логин занят");
                    return;
                }

                // Если логин не занят, добавляем нового пользователя
                SqlCommand comm = new SqlCommand("UserAdd", conn) { CommandType = CommandType.StoredProcedure };
                comm.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar) { Value = textBox1.Text });
                comm.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar) { Value = textBox2.Text });
                comm.Parameters.Add(new SqlParameter("@permission", SqlDbType.Int) { Value = 1 }); // Здесь используется SqlDbType.Int

                comm.ExecuteNonQuery();
                bunifuSnackbar1.Show(this, "Пользователь успешно добавлен");

                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close(); // Важно закрыть соединение в случае ошибки
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close(); // Закрываем соединение, если оно открыто
                }
            }
        }
    }
}
