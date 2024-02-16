using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aromatiy
{
    public partial class ProsmotrTovarov : Form
    {
        private int id;
        private string allName;


        public ProsmotrTovarov(int id, string allName)
        {
            InitializeComponent();
            this.id = id;
            this.allName = allName;
        }

        private void orderBindingSource1BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.orderBindingSource1.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.tovarDataSet);

        }

        private void ProsmotrTovarov_Load_1(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tovarDataSet.Product". При необходимости она может быть перемещена или удалена.
            this.productTableAdapter.Fill(this.tovarDataSet.Product);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tovarDataSet.Order". При необходимости она может быть перемещена или удалена.
            this.orderTableAdapter1.Fill(this.tovarDataSet.Order);

            if (allName != null)
            {
                FIOLable.Text = allName;
                FIOLable.Visible = true;
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
           
        }

        private void ProsmotrTovarov_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void panel10_Click(object sender, EventArgs e)
        {
            Basket.BasketForm basketForm=new Basket.BasketForm();
            basketForm.ShowDialog();
        }
    }
}
