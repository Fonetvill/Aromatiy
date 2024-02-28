using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aromatiy.AdminManeger
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void TovarBtn_Click(object sender, EventArgs e)
        {
            ProsmotrTovarov prosmotrTovarov = new ProsmotrTovarov();
            prosmotrTovarov.ShowDialog();
            }

        private void OrderBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
