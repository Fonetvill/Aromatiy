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

namespace Aromatiy
{
    public partial class ProsmotrTovarov : Form
    {
        private int id;
        private string allName;


        int countBucket = 0;
        

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
            panel5.Visible = false;
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tovarDataSet.Product". При необходимости она может быть перемещена или удалена.
            this.productTableAdapter.Fill(this.tovarDataSet.Product);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tovarDataSet.Order". При необходимости она может быть перемещена или удалена.
            this.orderTableAdapter1.Fill(this.tovarDataSet.Order);

            if (allName != null)
            {
                panel5.Visible = true;
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

    

        private void ProsmotrTovarov_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void panel10_Click(object sender, EventArgs e)
        {
            Basket.BasketForm basketForm = new Basket.BasketForm(id, selectProduct);
            basketForm.ShowDialog();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            id = 0;
            allName = null;
            this.Close();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (productDataGridView.SelectedRows.Count > 0)
            {
                int selectedIndex = productDataGridView.SelectedRows[0].Index;

                // Получите значение ключа, которое необходимо удалить
                int ProductID = Convert.ToInt32(productDataGridView.Rows[selectedIndex].Cells["ProductID"].Value);

                // Показать подтверждающий диалог перед удалением
                DialogResult result = MessageBox.Show("Вы уверены, что хотите добавить товар в корзину?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    countBucket++;
                    CountBucketLbl.Text = countBucket.ToString();
                    selectProduct.Add(ProductID);
                }
            }
            else
            {
                MessageBox.Show("Выберите строку .");
               
            }
        }
    }
}
