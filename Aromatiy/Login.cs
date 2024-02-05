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
using System.Xml.Linq;

namespace Aromatiy
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void TobariButton_Click(object sender, EventArgs e)
        {
            ProsmotrTovarov prosmotrTovarov = new ProsmotrTovarov();
            prosmotrTovarov.Show();
            this.Hide();
        }

        private void EnableButton_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            SqlConnection conn = new SqlConnection(Connection.con);
            // Простая проверка учетных данных (замените на вашу логику проверки)
            try
            {
                conn.Open();
                string query = $"SELECT * FROM [dbo].[User] WHERE [UserLogin]='{username}' AND [UserPassword]='{password}'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int? idValue = reader.IsDBNull(reader.GetOrdinal("PassengerId")) ? null : (int?)reader["PassengerId"];

                    reader.Close();
                    if (idValue.HasValue)
                    {
                        MessageBox.Show("Вы успешно вошли!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Не верный логин и пароль!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
