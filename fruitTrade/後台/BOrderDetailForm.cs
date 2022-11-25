using fruitTrade.Models.Services;
using fruitTrade.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fruitTrade.後台
{
    public partial class BOrderDetailForm : Form
    {

        private OrderVM order1;
        private int employeeId;
        public BOrderDetailForm(OrderVM row , int employee_Id)
        {
            InitializeComponent();
            this.order1 = row;
            this.employeeId = employee_Id;
            DisplayOrderInfo();
        }
        private void DisplayOrderInfo()
        {
            var order = new OrderService().GetOrderDetails(order1.Order_ID).ToArray();
            var member = new UserService().GetMember(order1.Member_Id);
            var employee = new UserService().GetEmployee(employeeId);
			
            statusComboBox.DataSource = new List<string>
			{
				"未處理","準備中","已出貨","已完成","已取消"
			};


			dataGridView1.DataSource = order;
            orderIdLable.Text += order[0].Order_Id;
            orderDateLable.Text += order[0].OrderDate;
            statusComboBox.Text = order1.status;
            addressLable.Text += member[0].Address;
            memberName.Text += member[0].Name;
            phoneNumLable.Text += member[0].Phone_Number;

            //int totalPrice = 0;
            //foreach (var item in order)
            //{
            //    totalPrice += item.ItemCost;
            //}
            totalPriceLable.Text += order[0].TotalPrice.ToString("#,#") + "元";
        }

        private void button2_Click(object sender, EventArgs e)
        {
			new OrderService().Update(order1.Order_ID, employeeId, statusComboBox.Text);
            this.DialogResult = DialogResult.OK;
        }

        private void BOrderDetailForm_Load(object sender, EventArgs e)
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
