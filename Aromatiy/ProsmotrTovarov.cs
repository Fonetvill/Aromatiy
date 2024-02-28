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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tovarDataSet.PickupPoint". При необходимости она может быть перемещена или удалена.
            this.pickupPointTableAdapter.Fill(this.tovarDataSet.PickupPoint);
            panel5.Visible = false;
    
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tovarDataSet.Product". При необходимости она может быть перемещена или удалена.
            this.productTableAdapter.Fill(this.tovarDataSet.Product);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tovarDataSet.Order". При необходимости она может быть перемещена или удалена.
            this.orderTableAdapter1.Fill(this.tovarDataSet.Order);
            UpdateDeleteButtonVisibility();

            if (  Variables.allName != null)
            {
                panel5.Visible = true;
                FIOLable.Text = Variables.allName;
                FIOLable.Visible = true;
            }

            label1.Text = "День заказа "+DateTime.Now.ToShortDateString();
            UpdateDataInfoLabel();
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
           
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            Variables.id = 0;
            Variables.allName = null;
            this.Close();
            login.Show();
        }

        private void UpdateDeleteButtonVisibility()
        {
            // Проверяем, есть ли строки в корзине
            bool hasItemsInBasket = BucketDgv.Rows.Count > 0;
            // Показываем или скрываем кнопку удаления в зависимости от наличия товаров в корзине
            DeleteBtn.Visible = hasItemsInBasket;
            panel3.Visible = hasItemsInBasket;
            panel13.Visible = hasItemsInBasket;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (productDataGridView.SelectedRows.Count > 0)
            {
                int selectedIndex = productDataGridView.SelectedRows[0].Index;
                int ProductID = Convert.ToInt32(productDataGridView.Rows[selectedIndex].Cells["ProductID"].Value);
                int ProductQuantityInStock = Convert.ToInt32(productDataGridView.Rows[selectedIndex].Cells["ProductQuantityInStock"].Value);

                // Проверяем, есть ли достаточное количество товара в наличии
                if (ProductQuantityInStock > 0)
                {
                    // Показать подтверждающий диалог перед добавлением в корзину
                    DialogResult result = MessageBox.Show("Вы уверены, что хотите добавить товар в корзину?",
                        "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bool productFound = false;
                        foreach (DataGridViewRow row in BucketDgv.Rows)
                        {
                            // Проверяем, если товар с таким ID уже в корзине
                            if (Convert.ToInt32(row.Cells["IdColumn"].Value) == ProductID)
                            {
                                // Увеличиваем количество товара в корзине
                                int newQuantity = Convert.ToInt32(row.Cells["CountColumn"].Value) + 1;
                                row.Cells["CountColumn"].Value = newQuantity;
                                productFound = true;
                                break;
                            }
                        }

                        // Если товара еще нет в корзине, добавляем его
                        if (!productFound)
                        {
                            // Создаем новую строку во втором DataGridView (корзине)
                            int rowIndex = BucketDgv.Rows.Add();

                            // Копируем данные из определенных колонок
                            BucketDgv.Rows[rowIndex].Cells[0].Value = ProductID; 
                            BucketDgv.Rows[rowIndex].Cells[1].Value = productDataGridView.Rows[selectedIndex].Cells["ProductName"].Value; 
                            BucketDgv.Rows[rowIndex].Cells[2].Value = productDataGridView.Rows[selectedIndex].Cells["ProductCost"].Value; 
                            BucketDgv.Rows[rowIndex].Cells[3].Value = 1; // Количество в корзине
                        }


                        ProductQuantityInStock--;
                        productDataGridView.Rows[selectedIndex].Cells["ProductQuantityInStock"].Value = ProductQuantityInStock;

                        // Обновляем отображение количества товара в корзине
                        countBucket++;
                        CountBucketLbl.Text = countBucket.ToString();
                        UpdateDeleteButtonVisibility();
                    }
                }
                else
                {
                    MessageBox.Show("Товара нет в наличии");
                }
            }
            else
            {
                MessageBox.Show("Выберите строку");
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (BucketDgv.SelectedRows.Count > 0)
            {
                int selectedIndex = BucketDgv.SelectedRows[0].Index;

                // Получаем значение ProductID, которое нужно вернуть в таблицу товаров
                int ProductID = Convert.ToInt32(BucketDgv.Rows[selectedIndex].Cells["IdColumn"].Value);
                int ProductQuantityInBasket = Convert.ToInt32(BucketDgv.Rows[selectedIndex].Cells["CountColumn"].Value);

                // Удаляем выбранную строку из корзины
                BucketDgv.Rows.RemoveAt(selectedIndex);

                // Увеличиваем количество товара в наличии в таблице товаров
                foreach (DataGridViewRow row in productDataGridView.Rows)
                {
                    // Находим товар с нужным ID
                    if (Convert.ToInt32(row.Cells["ProductID"].Value) == ProductID)
                    {
                        // Увеличиваем количество товара в наличии на количество из корзины
                        int ProductQuantityInStock = Convert.ToInt32(row.Cells["ProductQuantityInStock"].Value);
                        ProductQuantityInStock += ProductQuantityInBasket;
                        row.Cells["ProductQuantityInStock"].Value = ProductQuantityInStock;
                        break; // Выходим из цикла, после того как нашли товар
                    }
                }

                // Обновляем отображение количества товара в корзине
                countBucket -= ProductQuantityInBasket;
                CountBucketLbl.Text = countBucket.ToString();
                UpdateDeleteButtonVisibility();
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления");
            }
        }

        private int GenerateOrderGetCode()
        {
            Random random = new Random();
            return random.Next(300, 9999); 
        }

        private void CreateOrderBtn_Click(object sender, EventArgs e)
        {
            // Проверяем, есть ли товары в корзине
            if (BucketDgv.Rows.Count > 0)
            {
                // Устанавливаем статус заказа
                string orderStatus = "Новый";

                // Создаем новый заказ
                using (SqlConnection connection = new SqlConnection(Connection.con))
                {
                    connection.Open();

                    foreach (DataGridViewRow row in BucketDgv.Rows)
                    {
                        int productID = Convert.ToInt32(row.Cells["IdColumn"].Value);
                        int quantity = Convert.ToInt32(row.Cells["CountColumn"].Value);
                        DateTime orderCreateDate = DateTime.Today;
                        DateTime orderDeliveryDate = DateTime.Today.AddDays(5); // Примерно через 7 дней
                        int pickupPointId = comboBox1.SelectedIndex+1; // Здесь должно быть ваше значение для пункта выдачи заказов
                        int orderGetCode = GenerateOrderGetCode(); // Генерируем уникальный код получения заказа

                        // Формируем запрос для вставки заказа
                        string insertOrderQuery = @"INSERT INTO [Order] (OrderStatus, ProductArticleId, OrderCount, OrderCreateDate, OrderDeliveryDate, IdPickupPoint, OrderGetCode) 
                                            VALUES (@OrderStatus, @ProductArticleId, @OrderCount, @OrderCreateDate, @OrderDeliveryDate, @IdPickupPoint, @OrderGetCode);";

                        // Создаем команду для вставки заказа
                        using (SqlCommand command = new SqlCommand(insertOrderQuery, connection))
                        {
                            // Параметры запроса
                            command.Parameters.AddWithValue("@OrderStatus", orderStatus);
                            command.Parameters.AddWithValue("@ProductArticleId", productID);
                            command.Parameters.AddWithValue("@OrderCount", quantity);
                            command.Parameters.AddWithValue("@OrderCreateDate", orderCreateDate);
                            command.Parameters.AddWithValue("@OrderDeliveryDate", orderDeliveryDate);
                            command.Parameters.AddWithValue("@IdPickupPoint", pickupPointId);
                            command.Parameters.AddWithValue("@OrderGetCode", orderGetCode);

                            // Выполняем запрос
                            command.ExecuteNonQuery();
                        }
                    }
                }

                // Очищаем корзину после создания заказа
                UpdateDeleteButtonVisibility();
                BucketDgv.Rows.Clear();
                countBucket = 0;
                CountBucketLbl.Text = countBucket.ToString();


                // Оповещаем пользователя о том, что заказ успешно сформирован
                MessageBox.Show("Заказ успешно сформирован!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Корзина пуста. Нет товаров для формирования заказа.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void searchTb_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = searchTb.Text.Trim();
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                productBindingSource.Filter = string.Format("ProductName LIKE '%{0}%'", searchKeyword);
                UpdateDataInfoLabel();
            }
            else
            {
                productBindingSource.RemoveFilter();
                UpdateDataInfoLabel();
            }
        }

        private void UpdateDataInfoLabel()
        {
            int totalRecords = productBindingSource.Count;
            int displayedRecords = productDataGridView.RowCount;
            dataInfoLabel.Text = $"{displayedRecords} из {totalRecords}";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRange = discountComboBox.SelectedItem.ToString();

            // Определите диапазон скидки на основе выбранного элемента ComboBox
            string filter = "";
            switch (selectedRange)
            {
                case "Все диапазоны":
                    productBindingSource.RemoveFilter(); // Сбросить фильтр
                    UpdateDataInfoLabel();
                    break;
                case "0-9,99%":
                    filter = "ProductMaxDiscountAmount >= 0 AND ProductMaxDiscountAmount <= 9.99";
                    UpdateDataInfoLabel();
                    break;
                case "10-14,99%":
                    filter = "ProductMaxDiscountAmount >= 10 AND ProductMaxDiscountAmount <= 14.99";
                    UpdateDataInfoLabel();
                    break;
                case "15% и более":
                    filter = "ProductMaxDiscountAmount >= 15";
                    UpdateDataInfoLabel();
                    break;
            }
            if (!string.IsNullOrEmpty(filter))
            {
                productBindingSource.Filter = filter;
                UpdateDataInfoLabel();
            }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string sortOrder = comboBox2.SelectedItem.ToString();
            if (sortOrder == "По возрастанию")
            {
                productDataGridView.Sort(productDataGridView.Columns["ProductCost"], ListSortDirection.Ascending);
             
            }
            else if (sortOrder == "По убыванию")
            {
                productDataGridView.Sort(productDataGridView.Columns["ProductCost"], ListSortDirection.Descending);

            }
            else if (sortOrder == "Все цены")
            {
                productBindingSource.RemoveFilter();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

