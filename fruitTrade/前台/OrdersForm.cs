using fruitTrade.Models.Services;
using fruitTrade.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fruitTrade.Models.ViewModels;

namespace fruitTrade
{
    public partial class OrdersForm : Form
    {
		private OrderVM[] orders;
		private int id;
		
        public OrdersForm(int memberId)
        {
            InitializeComponent();
			this.id = memberId;
			DisplayOrders();

		}
		private void DisplayOrders()
		{
			orders = new OrderService().GetOrders(id).ToArray();
			

			BindData(orders);

		}

		private void BindData(OrderVM[] orders)
		{

			ordersGridView.DataSource = orders;
		}

		private void ordersGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
            int rowIndex = e.RowIndex;
            if (rowIndex < 0) return;

            OrderVM row = this.orders[rowIndex];
            int orderId = row.Order_ID;
            var frm = new OrderDetailForm(orderId);
			frm.Show();
		}

		private void OrdersForm_Load(object sender, EventArgs e)
		{
			if (ordersGridView.Rows.Count > 0)
			{
				ordersGridView.Rows[0].Selected = false;
			}
		}
	}
}
