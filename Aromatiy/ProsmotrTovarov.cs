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

        int countBucket = 0;
        

        public ProsmotrTovarov()
        {
            InitializeComponent();
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

            if (  Variables.allName != null)
            {
                panel5.Visible = true;
                FIOLable.Text = Variables.allName;
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
            Basket.BasketForm basketForm = new Basket.BasketForm();
            basketForm.ShowDialog();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            Variables.id = 0;
            Variables.allName = null;
            this.Close();
            login.Show();
        }

   

        private void AddBtn_Click(object sender, EventArgs e)
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

                    foreach (DataGridViewRow row in productDataGridView.SelectedRows)
                    {
                        // Создаем новую строку во втором DataGridView
                        int rowIndex = BucketDgv.Rows.Add();

                        // Копируем данные из определенных колонок
                        BucketDgv.Rows[rowIndex].Cells[0].Value = row.Cells["ProductID"].Value; // Копируем данные из колонки "Column1"
                        BucketDgv.Rows[rowIndex].Cells[1].Value = row.Cells["ProductName"].Value; // Копируем данные из колонки "Column2"
                        BucketDgv.Rows[rowIndex].Cells[2].Value = row.Cells["ProductCost"].Value; // Копируем данные из колонки "Column1"
                        BucketDgv.Rows[rowIndex].Cells[3].Value = row.Cells["ProductDiscountAmount"].Value; // Копируем данные из колонки "Column2"
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите строку .");

            }
        }
    }
}
