using fruitTrade.Models;
using fruitTrade.Models.Services;
using iSpan.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace fruitTrade.後台
{
	public partial class BEditProductForm : Form
	{
		private int id;
		public BEditProductForm(int id)
		{
			InitializeComponent();
			this.id = id;
			BindData();
		}
		private ProductVM product;
		private void BindData()
		{
			string sql = @"select * from Products where Product_Id = @Product_Id";
			var parameters = new SqlParameterBuilder()
							.AddInt("Product_Id", id)
							.Build();
			DataTable data = new SqlDbHelper("default").Select(sql, parameters);
			if (data.Rows.Count == 0)
			{
				MessageBox.Show("抱歉找不到要編輯的目標");
				this.Close();
				this.DialogResult = DialogResult.OK;
				return;
			}
			product =new ProductsService().ToProductVM(data.Rows[0]);
			ProductNameTxtBx.Text = product.ProductName;
			PriceTxtbx.Text = product.Price.ToString();
			InventoryTxtBx.Text = product.inventory.ToString();

		}

		private void SaveBtn_Click(object sender, EventArgs e)
		{
			bool isInt = uint.TryParse(InventoryTxtBx.Text, out uint inventory);
			bool isIntPrice = uint.TryParse(PriceTxtbx.Text, out uint price);
			if (isInt == false) { MessageBox.Show("您輸入的數量非正整數"); return; }
			if (isIntPrice == false){ MessageBox.Show("您輸入的價格非正整數");return; }

			var editProduct = new ProductVM()
			{
				Product_Id = id,
				ProductName = ProductNameTxtBx.Text,
				Price = (int)price,
				inventory = (int)inventory
			};

			if (new ProductsService().Update(editProduct)) this.DialogResult = DialogResult.OK;


		}

		private void ProductNameTxtBx_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
            {
                this.SaveBtn_Click(sender, e);
            }
        }
	}
	
}
