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
    public partial class BOrdersForm : Form
    {
        private OrderVM[] orders;
        private int id;
        public BOrdersForm(EmployeeIndexVM employee)
        {
            InitializeComponent();
            this.id = employee.Employee_Id;
            DisplayOrders();
        }
        

        private void DisplayOrders()
        {
            orders = new OrderService().GetAllOrders().ToArray();

            BindData(orders);
            //AddComboxCoulum();
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


			var frm = new BOrderDetailForm(row, id);
			var result = frm.ShowDialog();
            if(result == DialogResult.OK)
            {
                DisplayOrders();
            }
		
        }

        private void BOrdersForm_Load(object sender, EventArgs e)
        {
			if (ordersGridView.Rows.Count > 0)
			{
				ordersGridView.Rows[0].Selected = false;
			}
		}

        
    }
}
