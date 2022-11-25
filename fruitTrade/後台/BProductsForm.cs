using fruitTrade.Models;
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
	
	public partial class BProductsForm : Form
    {
		private ProductIndexVM[] products = null;
		public BProductsForm()
        {
            InitializeComponent();
			DisplayProducts();
		}
		private void DisplayProducts()
		{
			string keyword = searchTxt.Text;
			products = new ProductsService().GetAll(keyword).ToArray();

			BindData(products);

		}
		private void BindData(ProductIndexVM[] products)
		{
			ProductDataGridView.DataSource = products;
		}
		private void SearchBtn_Click(object sender, EventArgs e)
		{
			DisplayProducts();
		}
		private void ProductDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			int rowIndex = e.RowIndex;
			if (rowIndex < 0) return;

			ProductIndexVM row = this.products[rowIndex];

			var frm = new BEditProductForm(row.Product_Id);

			DialogResult result = frm.ShowDialog();
			if (result == DialogResult.OK)
			{
				DisplayProducts();
			}



		}

		private void addNewBtn_Click(object sender, EventArgs e)
		{
			var frm = new CreatProductForm();

			DialogResult result = frm.ShowDialog();
			if (result == DialogResult.OK)
			{
				DisplayProducts();
			}
		}

		private void searchTxt_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
            {
                this.SearchBtn_Click(sender, e);
            }
        }

		private void panel4_Paint(object sender, PaintEventArgs e)
		{

		}

		private void BProductsForm_Load(object sender, EventArgs e)
		{
			if (ProductDataGridView.Rows.Count > 0)
			{
				ProductDataGridView.Rows[0].Selected = false;
			}
		}
	}
}
