using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
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
            string userlogin = textBox1.Text;
            string password = textBox2.Text;
            SqlConnection conn = new SqlConnection(Connection.con);
            try
            {
                conn.Open();
                string query = "SELECT * FROM [dbo].[User] WHERE [UserLogin]=@Username AND [UserPassword]=@Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", userlogin);
                cmd.Parameters.AddWithValue("@Password", password);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int? idValue = reader.IsDBNull(reader.GetOrdinal("UserId")) ? null : (int?)reader["UserId"];
                    Variables.id = idValue.Value;
                    Variables.allName = (string)reader["UserSurname"] + " " + (string)reader["UserName"] + " " + (string)reader["UserPatronymic"]; ;

                    reader.Close();

                    MessageBox.Show("Вы успешно вошли!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ProsmotrTovarov prosmotrTovarov = new ProsmotrTovarov();
                    prosmotrTovarov.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Не верный логин и пароль!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
