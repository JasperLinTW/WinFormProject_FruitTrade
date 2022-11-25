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
    public partial class OrderDetailForm : Form
    {
        private int order_Id;
        private OrderDetailVM order = new OrderDetailVM();
        public OrderDetailForm(int orderId)
        {
            InitializeComponent();
            this.order_Id = orderId;
            DisplayOrderInfo();
        }




        private void DisplayOrderInfo()
        {
            var order = new OrderService().GetOrderDetails(order_Id).ToArray();
            
            dataGridView1.DataSource = order;
            var member = new UserService().GetMember(order[0].Member_Id);
            orderIdLable.Text += order[0].Order_Id;
            orderDateLable.Text += order[0].OrderDate;
            statusLable.Text += order[0].Status;
            addressLable.Text += member[0].Address;
            totalPriceLable.Text = order[0].TotalPrice.ToString("#,#")+"元";
            
        }

        private void OrderDetailForm_Load(object sender, EventArgs e)
        {
			

			if (dataGridView1.Rows.Count > 0)
			{
				dataGridView1.Rows[0].Selected = false;
			}

		}

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
			dataGridView1.ClearSelection();
		}
    }
}
