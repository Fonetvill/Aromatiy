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
        public ProsmotrTovarov()
        {
            InitializeComponent();
        }

        private void orderBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.orderBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tradeDataSet);

        }

        private void ProsmotrTovarov_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tradeDataSet.Order". При необходимости она может быть перемещена или удалена.
            this.orderTableAdapter.Fill(this.trade//DataSet.Order);

        }
    }
}
